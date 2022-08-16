using System.Text;

namespace ClassGenerator;

public class ProtocCommandBuilder
{
    public string ProtocToolPath { get; }
    public string GrpcPluginExe { get; }
    public string ProtoFileDir { get; }
    public string Filename { get; }
    public string OutputDir { get; }

    //todo class GrpcOptions
    public ProtocCommandBuilder(string protocToolPath, string grpcPluginExe, string protoFileDir, string filename,
        string outputDir = @"obj\Debug\net6.0\Protos")
    {
        //todo fix output, im not sure that it will work good on realise
        ProtocToolPath = protocToolPath;
        GrpcPluginExe = grpcPluginExe;
        Filename = filename;
        ProtoFileDir = protoFileDir;
        OutputDir = outputDir;
    }

    public override string ToString()     
    {
        var parameters = new string[]
        {
            $"--proto_path={ProtoFileDir}",
            $"--csharp_out={OutputDir}",
            $"--grpc_out={OutputDir}",
            $"--plugin=protoc-gen-grpc=\"{GrpcPluginExe}\"",
            Filename,
        };
        return $"{ProtocToolPath} {string.Join(' ', parameters)}";
    }

    public string GetParameters()
    {
        var parameters = new string[]
        {
            $"--proto_path={ProtoFileDir}",
            $"--csharp_out={OutputDir}",
            $"--grpc_out={OutputDir}",
            $"--plugin=protoc-gen-grpc=\"{GrpcPluginExe}\"",
            Filename,
        };
        return string.Join(' ', parameters);
    }
}

