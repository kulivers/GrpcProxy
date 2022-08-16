using System.Collections.Generic;

namespace ApiDescriptions.Grpc
{
    public interface IServiceDescription
    {
        string Name { get; set; }
        IEnumerable<IMethodDescription> Methods { get; set; }
    }
}