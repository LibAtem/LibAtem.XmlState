using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibAtem.XmlState.MacroSpec
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spec = XmlSpec.Load("spec.xml");

            if (spec.Operations.Select(o => o.Id).Distinct().Count() != spec.Operations.Count)
                throw new Exception("Found duplicated Operation Ids");

            if (spec.Operations.Any(o => o.Fields.Count == 0))
                throw new Exception("Found some Operation with no fields");

            Console.WriteLine(string.Format("Loaded spec with {0} Fields and {1} Operations", spec.Fields.Count, spec.Operations.Count));

            var code = GenerateClass(spec);

            // Save to file
            File.WriteAllText("../LibAtem.XmlState/MacroOperation.cs", code);
            
            // Output new code to the console
            Console.WriteLine(code);

            // Wait to exit
            // Console.Read();
        }

        private static IEnumerable<MemberDeclarationSyntax> GenerateField(XmlField field, IReadOnlyList<XmlOperation> operations)
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
            return SyntaxFactory.AccessorDeclaration(kind, SyntaxFactory.List<AttributeListSyntax>(), SyntaxFactory.TokenList(), SyntaxFactory.ArrowExpressionClause(SyntaxFactory.ParseExpression(expression)));
        }

        private static MethodDeclarationSyntax CreateCanSerializeAt(string name, IReadOnlyList<string> opNames)
        {
            IEnumerable<SwitchLabelSyntax> labels = opNames.Select(o => SyntaxFactory.CaseSwitchLabel(SyntaxFactory.ParseExpression("MacroOperationType." + o)));
            var switchTrue = SyntaxFactory.SwitchSection(SyntaxFactory.List(labels), SyntaxFactory.List(new StatementSyntax[] { SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression("true")) }));

            var switchFalse = SyntaxFactory.SwitchSection(SyntaxFactory.List(new SwitchLabelSyntax[] { SyntaxFactory.DefaultSwitchLabel() }), SyntaxFactory.List(new StatementSyntax[] { SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression("false")) }));

            var switchStmt = SyntaxFactory.SwitchStatement(SyntaxFactory.ParseExpression("Id"));
            switchStmt = switchStmt.AddSections(switchTrue, switchFalse);

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("bool"), "ShouldSerialize" + name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(switchStmt);
        }
        
        private static PropertyDeclarationSyntax CreateProperty(string name, string type, AttributeListSyntax attribute)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(type), name)
                .AddAttributeLists(attribute)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
        }
        private static PropertyDeclarationSyntax CreateAutoProperty(string name, string type, AttributeListSyntax attribute)
        {
            return CreateProperty(name, type, attribute)
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        }

        private static AttributeListSyntax CreateAttribute(string fieldName)
        {
            AttributeArgumentSyntax arg = SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression("\"" + fieldName + "\""));
            AttributeSyntax attr = SyntaxFactory.Attribute(SyntaxFactory.ParseName("XmlAttribute")).AddArgumentListArguments(arg);
            return SyntaxFactory.AttributeList(SyntaxFactory.SeparatedList(new[] {attr}));
        }
        private static AttributeListSyntax CreateIgnoreAttribute()
        {
            AttributeSyntax attr = SyntaxFactory.Attribute(SyntaxFactory.ParseName("XmlIgnore"));
            return SyntaxFactory.AttributeList(SyntaxFactory.SeparatedList(new[] { attr }));
        }

        private static string GenerateClass(XmlSpec spec)
        {
            // Create CompilationUnitSyntax
            var newFile = SyntaxFactory.CompilationUnit();

            // Add using statements
            var namespaces = new[]
            {
                "System",
                "System.Xml.Serialization",
                "LibAtem.Common",
            }.Concat(spec.Fields.Select(f => f.Namespace).Where(n => n != null)).Distinct();
            newFile = newFile.AddUsings(namespaces.Select(n => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(n))).ToArray());
            
            // Create Id Property
            var idProp = CreateAutoProperty("Id", "MacroOperationType", CreateAttribute("id"));


            // Create class
            var newClass = SyntaxFactory.ClassDeclaration("MacroOperation")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            newClass = newClass.AddMembers(idProp)
                .AddMembers(spec.Fields.SelectMany(f => GenerateField(f, spec.Operations)).ToArray());

            // Create namespace
            var newNamespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("LibAtem.XmlState"))
                .AddMembers(newClass);

            // Add the namespace to the file
            newFile = newFile.AddMembers(newNamespace);

            // Normalize and get code as string
            return newFile
                .NormalizeWhitespace()
                .ToFullString();
        }
    }
}