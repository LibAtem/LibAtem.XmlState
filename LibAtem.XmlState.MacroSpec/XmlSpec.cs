using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.XmlState.MacroSpec
{
    public class Field : IEquatable<Field>
    {
        public Field(string id, string name, string type, bool enumAsString)
        {
            Id = id;
            Name = name;
            Type = type;
            EnumAsString = enumAsString;
        }

        public string Id { get; }
        public string Name { get; }
        public string Type { get; }
        public bool EnumAsString { get; }

        public bool Equals(Field other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id) && string.Equals(Name, other.Name) && string.Equals(Type, other.Type) && EnumAsString == other.EnumAsString;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Field) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EnumAsString.GetHashCode();
                return hashCode;
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}: {1} - {2} ({3})", Id, Name, Type);
        }
    }
    
    public class Operation
    {
        public Operation(string id, string classname, IEnumerable<OperationField> fields)
        {
            Id = id;
            Classname = classname;
            Fields = fields.ToList();
        }

        public string Id { get; }
        public string Classname { get; }
        public IReadOnlyList<OperationField> Fields { get; }
    }

    public class OperationField
    {
        public string Id { get; }
        public string PropName { get; }
        public string Type { get; }

        public OperationField(string id, string propName, string type)
        {
            Id = id;
            PropName = propName;
            Type = type;
        }
        
    }
}
