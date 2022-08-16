using System.Collections.Generic;

namespace ApiDescriptions.Grpc
{
    public interface IPackageDescription
    {
        string Syntax { get; set; }
        string Name { get; set; }
        IEnumerable<MessageDescription> Messages { get; set; }
        IEnumerable<ServiceDescription> Services { get; set; }
    }
}