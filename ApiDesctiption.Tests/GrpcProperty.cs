using ApiDescriptions.Grpc;

namespace ApiDesctiption.Tests.Grpc;

public class GrpcPropertyTests
{
    [Fact]
    public void PropertyEqualsTest()
    {
        // Arrange
        var property = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(int)};
        var property2 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(int)};
        var property3 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 2, Type = typeof(int)};
        var property4 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(short)};
        // Assert
        Assert.Equal(property, property2);
        Assert.NotEqual(property, property3);
        Assert.NotEqual(property, property4);
    }

    [Fact]
    public void PropertyGetHashCodesTests()
    {        
        // Arrange
        var property = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(int)};
        var property2 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(int)};
        
        var property3 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 2, Type = typeof(int)};
        var property33 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 2, Type = typeof(int)};
        
        var property4 = new ApiDescriptions.Grpc.PropertyDescription(){Position = 1, Type = typeof(short)};

        var set = new HashSet<ApiDescriptions.Grpc.PropertyDescription>() { property, property2, property3,property33, property4 };
        // Assert
        Assert.Equal(property.GetHashCode(), property2.GetHashCode());
        Assert.NotEqual(property.GetHashCode(), property3.GetHashCode());
        Assert.NotEqual(property.GetHashCode(), property4.GetHashCode());
        Assert.Equal(3,set.Count);
    }
}