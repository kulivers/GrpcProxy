using System;

namespace ApiDescriptions.Grpc
{
    public struct PropertyDescription : IPropertyDescription
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public PropertyDescription(Type type, string name, int position)
        {
            Type = type;
            Name = name;
            Position = position;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IPropertyDescription))
                return false;
            var property = (IPropertyDescription) obj;
            return property.Position == Position && property.Type == Type && property.Name==Name;
        }
        public override int GetHashCode()
        {
            if (Type==null)
            {
                if (Name == null)
                    return Position.GetHashCode();
                return Position.GetHashCode() ^ Name.GetHashCode();
            }
            
            if (Name==null)
            {
                if (Type == null)
                {
                    return Position.GetHashCode();
                }
                return Position.GetHashCode() ^ Type.GetHashCode();
            }
            return Type.GetHashCode() ^ Position.GetHashCode() ^ Name.GetHashCode();
        }
    }
}