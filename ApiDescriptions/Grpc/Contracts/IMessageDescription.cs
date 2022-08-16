using System.Collections.Generic;

namespace ApiDescriptions.Grpc
{
    public interface IMessageDescription
    {
        string Name { get; set; }
        HashSet<IPropertyDescription> Properties { get; set; }
        void VerifyPositionsNotMissed();
        bool AddProperty(IPropertyDescription propertyDescription);
        bool AddProperties(IEnumerable<IPropertyDescription> properties);
    }
}