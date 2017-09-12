using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;

namespace LibAtem.XmlState.MacroSpec
{
    public class Program
    {
        private static ExpressionSyntax ConvertVariable(ExpressionSyntax expr, string fromType, string toType)
        {
            if (toType == fromType)
                return expr;
            
            if (fromType == "LibAtem.Common.VideoSource" && toType == "LibAtem.XmlState.MacroInput")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("ToMacroInput()"));
            if (fromType == "LibAtem.XmlState.MacroInput" && toType == "LibAtem.Common.VideoSource")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("ToVideoSource()"));

            if (fromType == "LibAtem.Common.AudioSource" && toType == "LibAtem.XmlState.MacroInput")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("ToMacroInput()"));
            if (fromType == "LibAtem.XmlState.MacroInput" && toType == "LibAtem.Common.AudioSource")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("ToAudioSource()"));

            if (fromType == "System.Boolean" && toType == "LibAtem.XmlState.AtemBool")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("ToAtemBool()"));
            if (fromType == "LibAtem.XmlState.AtemBool" && toType == "System.Boolean")
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, IdentifierName("Value()"));

            if (fromType == "System.UInt32" && toType == "LibAtem.Common.DownstreamKeyId")
                return CastExpression(ParseTypeName("LibAtem.Common.DownstreamKeyId"), expr);
            if (fromType == "LibAtem.Common.DownstreamKeyId" && toType == "System.UInt32")
                return CastExpression(ParseTypeName("System.UInt32"), expr);

            return expr;
        }
        
        private static Tuple<List<Operation>, List<Field>> FakeSpec()
        {
            var operations = new List<Operation>();
            var fields = new List<Field>();

            IReadOnlyDictionary<MacroOperationType, Type> types = MacroOpManager.FindAll();
            foreach (var t in types)
            {
                MacroOperationType id = t.Key;
                Type type = t.Value;
                
                IEnumerable<PropertyInfo> props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(prop => prop.GetCustomAttribute<NoSerializeAttribute>() == null);

                var opFields = new List<OperationField>();
                foreach (PropertyInfo prop in props)
                {
                    var fieldAttr = prop.GetCustomAttribute<MacroFieldAttribute>();
                    if (fieldAttr == null)
                        continue;

                    fields.Add(new Field(fieldAttr.Id, fieldAttr.Name, TypeMappings.MapType(prop.PropertyType.ToString()), prop.PropertyType.GetCustomAttributes<FlagsAttribute>().Any()));

                    opFields.Add(new OperationField(fieldAttr.Id, prop.Name, prop.PropertyType.ToString()));
                }

                operations.Add(new Operation(id.ToString(), type.FullName, opFields));
            }

            fields = fields.Distinct().OrderBy(f => f.Id).ToList();

            var groups = fields.GroupBy(f => f.Id);
            if (groups.Any(g => g.Count() > 1))
                throw new Exception("Found mismatch in field specs");

            return Tuple.Create(operations, fields);
        }

        public static void Main(string[] args)
        {
            Tuple<List<Operation>, List<Field>> spec = FakeSpec();

            if (spec.Item1.Select(o => o.Id).Distinct().Count() != spec.Item1.Count)
                throw new Exception("Found duplicated Operation Ids");

            if (spec.Item1.Any(o => o.Fields.Count == 0))
                throw new Exception("Found some Operation with no fields");

            Console.WriteLine(string.Format("Loaded spec with {0} Fields and {1} Operations", spec.Item2.Count, spec.Item2.Count));

            var code = GenerateClass(spec.Item1, spec.Item2);

            // Save to file
            File.WriteAllText("../LibAtem.XmlState/MacroOperation.cs", code);

            // Output new code to the console
            Console.WriteLine(code);

            // Wait to exit
            // Console.Read();
        }

        private static IEnumerable<MemberDeclarationSyntax> GenerateField(Field field, IReadOnlyList<Operation> operations)
        {
            List<string> opNames = operations.Where(o => o.Fields.Any(f => f.Id == field.Id)).Select(o => o.Id).ToList();
            if (opNames.Count == 0)
                throw new Exception("Found Field with no usages: " + field.Name);

            if (field.EnumAsString)
            {
                yield return CreateAutoProperty(field.Name, field.Type, CreateIgnoreAttribute());

                string getStr = string.Format("{0}.ToString();", field.Name);
                string setStr = string.Format("{0} = ({1})Enum.Parse(typeof({1}), value);", field.Name, field.Type);

                yield return CreateProperty(field.Name + "String", "string", CreateAttribute(field.Id))
                    .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.GetAccessorDeclaration, getStr))
                    .AddAccessorListAccessors(CreateArrowExpression(SyntaxKind.SetAccessorDeclaration, setStr));

                yield return CreateCanSerializeAt(field.Name + "String", opNames);

                yield break;
            }

            yield return CreateAutoProperty(field.Name, field.Type, CreateAttribute(field.Id));

            yield return CreateCanSerializeAt(field.Name, opNames);
        }

        private static AccessorDeclarationSyntax CreateArrowExpression(SyntaxKind kind, string expression)
        {
            return AccessorDeclaration(kind, List<AttributeListSyntax>(), TokenList(), ArrowExpressionClause(ParseExpression(expression)));
        }

        private static MethodDeclarationSyntax CreateCanSerializeAt(string name, IReadOnlyList<string> opNames)
        {
            IEnumerable<SwitchLabelSyntax> labels = opNames.Select(o => CaseSwitchLabel(ParseExpression("MacroOperationType." + o)));
            var switchTrue = SwitchSection(List(labels), List(new StatementSyntax[] { ReturnStatement(ParseExpression("true"))}));

            var switchFalse = SwitchSection(List(new SwitchLabelSyntax[] { DefaultSwitchLabel()}), List(new StatementSyntax[] { ReturnStatement(ParseExpression("false"))}));

            var switchStmt = SwitchStatement(ParseExpression("Id"));
            switchStmt = switchStmt.AddSections(switchTrue, switchFalse);

            return MethodDeclaration(ParseTypeName("bool"), "ShouldSerialize" + name)
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(switchStmt);
        }

        private static PropertyDeclarationSyntax CreateProperty(string name, string type, AttributeListSyntax attribute)
        {
            return PropertyDeclaration(ParseTypeName(type), name)
                .AddAttributeLists(attribute)
                .AddModifiers(Token(SyntaxKind.PublicKeyword));
        }

        private static PropertyDeclarationSyntax CreateAutoProperty(string name, string type, AttributeListSyntax attribute)
        {
            return CreateProperty(name, type, attribute)
                .AddAccessorListAccessors(
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                    AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
        }

        private static AttributeListSyntax CreateAttribute(string fieldName)
        {
            AttributeArgumentSyntax arg = AttributeArgument(ParseExpression("\"" + fieldName + "\""));
            AttributeSyntax attr = Attribute(ParseName("XmlAttribute")).AddArgumentListArguments(arg);
            return AttributeList(SeparatedList(new[] {attr}));
        }

        private static AttributeListSyntax CreateIgnoreAttribute()
        {
            AttributeSyntax attr = Attribute(ParseName("XmlIgnore"));
            return AttributeList(SeparatedList(new[] {attr}));
        }

        private static string GenerateClass(List<Operation> operations, List<Field> fields)
        {
            // Create CompilationUnitSyntax
            var newFile = CompilationUnit();

            // Add using statements
            var namespaces = new[]
            {
                "System",
                "System.Xml.Serialization",
                "LibAtem.Common",
                "LibAtem.MacroOperations",
            };
            newFile = newFile.AddUsings(namespaces.Select(n => UsingDirective(ParseName(n))).ToArray());

            // Create Id Property
            var idProp = CreateAutoProperty("Id", "MacroOperationType", CreateAttribute("id"));
            
            // Create class
            var newClass = ClassDeclaration("MacroOperation").AddModifiers(Token(SyntaxKind.PublicKeyword));

            newClass = newClass.AddMembers(idProp)
                .AddMembers(fields.SelectMany(f => GenerateField(f, operations)).ToArray());
            
            var opExtClass = ClassDeclaration("MacroOpExtensions")
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword));
            opExtClass = opExtClass.AddMembers(GenerateMacroOpToXml(operations, fields));

            var operationsExtClass = ClassDeclaration("MacroOperationsExtensions")
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword));
            operationsExtClass = operationsExtClass.AddMembers(GenerateXmlToMacroOp(operations, fields));

            // Create namespace
            var newNamespace = NamespaceDeclaration(ParseName("LibAtem.XmlState"))
                .AddMembers(newClass, opExtClass, operationsExtClass);

            // Add the namespace to the file
            newFile = newFile.AddMembers(newNamespace);

            // Normalize and get code as string
            return newFile
                .NormalizeWhitespace()
                .ToFullString();
        }

        private static MemberDeclarationSyntax GenerateMacroOpToXml(IReadOnlyList<Operation> operations, IReadOnlyList<Field> fields)
        {
            var switchStmt = SwitchStatement(MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("op"),
                IdentifierName("GetType().FullName")));

            foreach (Operation op in operations)
            {
                var label = CaseSwitchLabel(ParseExpression("\"" + op.Classname + "\""));
                var opCase = SwitchSection(List(new SwitchLabelSyntax[] { label }), List(GenerateMacroOpToXml(op, fields).ToArray()));
                switchStmt = switchStmt.AddSections(opCase);
            }

            // TODO throw an exception instead of returning null.
            var defaultCase = SwitchSection(List(new SwitchLabelSyntax[] { DefaultSwitchLabel() }), List(new StatementSyntax[] { ReturnStatement(ParseExpression("null")) }));
            switchStmt = switchStmt.AddSections(defaultCase);

            return MethodDeclaration(ParseTypeName("MacroOperation"), "ToMacroOperation")
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(Parameter(Identifier("op")).AddModifiers(Token(SyntaxKind.ThisKeyword)).WithType(IdentifierName("MacroOpBase")))
                .AddBodyStatements(switchStmt);
        }

        private static IEnumerable<StatementSyntax> GenerateMacroOpToXml(Operation op, IReadOnlyList<Field> fields)
        {
            string[] nameParts = op.Classname.Split(".");
            string id = nameParts[nameParts.Count() - 1];

            var props = SeparatedList<ExpressionSyntax>()
                .Add(AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    IdentifierName("Id"),
                    IdentifierName("MacroOperationType." + op.Id)));

            foreach (OperationField f in op.Fields)
            {
                Field field = fields.First(g => g.Id == f.Id);

                var expr = AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    IdentifierName(field.Name),
                    ConvertVariable(MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName("op" + id),
                            IdentifierName(f.PropName)),
                        f.Type, TypeMappings.MapType(f.Type)));
                
                props = props.Add(expr);
            }

            yield return LocalDeclarationStatement(VariableDeclaration(IdentifierName("var"))
                .WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier("op" + id))
                    .WithInitializer(EqualsValueClause(CastExpression(IdentifierName(op.Classname), IdentifierName("op")))))));

            yield return ReturnStatement(ObjectCreationExpression(IdentifierName("MacroOperation"))
                .WithNewKeyword(Token(SyntaxKind.NewKeyword)).WithInitializer(InitializerExpression(SyntaxKind.ObjectInitializerExpression, props)));
        }

        private static MemberDeclarationSyntax GenerateXmlToMacroOp(IReadOnlyList<Operation> operations, IReadOnlyList<Field> fields)
        {
            var switchStmt = SwitchStatement(MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("mac"),
                IdentifierName("Id")));

            foreach (Operation op in operations)
            {
                var label = CaseSwitchLabel(ParseExpression("MacroOperationType." + op.Id));
                var opCase = SwitchSection(List(new SwitchLabelSyntax[] {label}), List(new StatementSyntax[] {GenerateXmlToMacroOp(op, fields)}));
                switchStmt = switchStmt.AddSections(opCase);
            }

            // TODO throw an exception instead of returning null.
            var defaultCase = SwitchSection(List(new SwitchLabelSyntax[] { DefaultSwitchLabel() }), List(new StatementSyntax[] { ReturnStatement(ParseExpression("null")) })); 
            switchStmt = switchStmt.AddSections(defaultCase);
            
            return MethodDeclaration(ParseTypeName("IMacroOperation"), "ToMacroOp")
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(Parameter(Identifier("mac")).AddModifiers(Token(SyntaxKind.ThisKeyword)).WithType(IdentifierName("MacroOperation")))
                .AddBodyStatements(switchStmt);
        }

        private static ReturnStatementSyntax GenerateXmlToMacroOp(Operation op, IReadOnlyList<Field> fields)
        {
            var props = SeparatedList<ExpressionSyntax>();

            foreach (OperationField f in op.Fields)
            {
                Field field = fields.First(g => g.Id == f.Id);

                var expr = AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    IdentifierName(f.PropName),
                    ConvertVariable(MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName("mac"),
                        IdentifierName(field.Name)),
                        TypeMappings.MapType(f.Type), f.Type));

                props = props.Add(expr);
            }

            var inst = ObjectCreationExpression(IdentifierName(op.Classname))
                .WithNewKeyword(Token(SyntaxKind.NewKeyword)).WithInitializer(InitializerExpression(SyntaxKind.ObjectInitializerExpression, props));

            return ReturnStatement(inst);
        }

    }
}