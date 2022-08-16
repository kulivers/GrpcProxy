using System.Collections.Generic;
using System.Linq;

namespace ApiDescriptions.Grpc
{
    public class MessageDescription : IMessageDescription
    {
        public string Name { get; set; }
        public HashSet<IPropertyDescription> Properties { get; set; }

        public MessageDescription()
        {
            Properties = new HashSet<IPropertyDescription>();
        }
        public void VerifyPositionsNotMissed()
        {
            var position = 1;
            foreach (var _ in Properties)
            {
                if (Properties.Any(property => property.Position==position))
                    throw new MissedPositionsInProps("Wrong positions (Not ordered/Misses)");
                position++;
            }
        }
        
        public bool AddProperty(IPropertyDescription propertyDescription) => Properties.Add(propertyDescription);
        public bool AddProperties(IEnumerable<IPropertyDescription> properties)
        {
            var result = true;
            foreach (var property in properties.ToArray())
            {
                if (!Properties.Add(property)) result = false;
            }
            return result;
        }
    }
}