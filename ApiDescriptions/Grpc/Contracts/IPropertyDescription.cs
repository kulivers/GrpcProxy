using System;

namespace ApiDescriptions.Grpc
{
    public interface IPropertyDescription
    {
        Type Type { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        
    }
}