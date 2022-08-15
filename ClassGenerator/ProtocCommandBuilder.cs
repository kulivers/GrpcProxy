using System.Text;

namespace ClassGenerator;

public class ProtocCommandBuilder
{
    public string ProtocToolPath { get; }
    public string PluginPath { get; }
    public string ProtosDir { get; }
    public string Filename { get; }
    public string Output { get; }

    public ProtocCommandBuilder(string protocToolPath, string pluginPath, string protosDir, string filename,
        string output = @"obj\Debug\net6.0\Protos")
    {
        //todo fix output, im not sure that it will work good on realise
        ProtocToolPath = protocToolPath;
        PluginPath = pluginPath;
        Filename = filename;
        ProtosDir = protosDir;
        Output = output;
    }

    public override string ToString()     
    {
        var parameters = new string[]
        {
            $"--proto_path={ProtosDir}",
            $"--csharp_out={Output}",
            $"--grpc_out={Output}",
            $"--plugin=protoc-gen-grpc=\"{PluginPath}\"",
            Filename,
        };
        return $"{ProtocToolPath} {string.Join(' ', parameters)}";
    }

    public string GetParameters()
    {
        var parameters = new string[]
        {
            $"--proto_path={ProtosDir}",
            $"--csharp_out={Output}",
            $"--grpc_out={Output}",
            $"--plugin=protoc-gen-grpc=\"{PluginPath}\"",
            Filename,
        };
        return string.Join(' ', parameters);
    }
}

