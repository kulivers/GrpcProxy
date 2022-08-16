using System.Collections.Generic;

namespace ApiDescriptions.Grpc
{
    public class ServiceDescription : IServiceDescription
    {
        public string Name { get; set; }
        public IEnumerable<IMethodDescription> Methods { get; set; }
    }
}