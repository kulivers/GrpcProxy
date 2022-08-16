using ApiDescriptions.Grpc;

namespace ApiDesctiption.Tests.Grpc;

public class GrpcMessageTests
{
    [Fact]
    public void VerifyPositionsNotMissedThrowsEx()
    {
        // Arrange
        var property = new PropertyDescription { Position = 1, Type = typeof(int) };
        var property2 = new PropertyDescription { Position = 2, Type = typeof(int) };
        var property3 = new PropertyDescription { Position = 4, Type = typeof(int) };
        var property4 = new PropertyDescription { Position = 3, Type = typeof(short) };
        var message = new MessageDescription();
        message.AddProperties(new List<IPropertyDescription> { property, property2, property3, property4 });
        
        // Assert
        Assert.Throws<MissedPositionsInProps>(() => { message.VerifyPositionsNotMissed(); });
    }
}