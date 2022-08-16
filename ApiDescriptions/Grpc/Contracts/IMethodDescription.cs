namespace ApiDescriptions.Grpc
{
    public interface IMethodDescription
    {
        string Name { get; set; }
        bool ClientStreaming { get; set; }
        bool ServerStreaming { get; set; }
        IMessageDescription Input { get; set; }
        IMessageDescription Output { get; set; }
    }
}