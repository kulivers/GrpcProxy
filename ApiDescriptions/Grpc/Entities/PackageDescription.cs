using System.Collections.Generic;

namespace ApiDescriptions.Grpc
{
    public class PackageDescription : IPackageDescription
    {
        public string Syntax { get; set; }
        public string Name { get; set; }
        public IEnumerable<MessageDescription> Messages { get; set; }
        public IEnumerable<ServiceDescription> Services { get; set; }

        public PackageDescription()
        {

        }
    }
}