namespace ApiDescriptions.Grpc
{
    public class MethodDescription : IMethodDescription
    {
        public string Name { get; set; }
        public bool ClientStreaming { get; set; }
        public bool ServerStreaming { get; set; }
        public IMessageDescription Input { get; set; }
        public IMessageDescription Output { get; set; }
    }
}