using System.Diagnostics;

namespace ClassGenerator;

public class GrpcClassGenerator
{
    public async Task GenerateClasses(string protosDirectory)
    {
        var helper = new GrpcToolsHelper();
        await helper.InitToolsAsync();
        var protoc = await helper.GetProtocToolPath();
        var plugin = await helper.GetProtocCSharpPluginPath();
        var fileNames = Directory.GetFiles(protosDirectory);

        foreach (var fileName in fileNames)
        {
            var cmdBuilder = new ProtocCommandBuilder(protoc, plugin, protosDirectory, fileName);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    FileName = cmdBuilder.ProtocToolPath,
                    Arguments = cmdBuilder.GetParameters()
                }
            };

            process.Start();
            await process.WaitForExitAsync(); //todo fix if needed
        }
    }

    public async Task GenerateClasses(string protosDirectory, string outputDir)
    {
        var helper = new GrpcToolsHelper();
        await helper.InitToolsAsync();
        var protoc = await helper.GetProtocToolPath();
        var plugin = await helper.GetProtocCSharpPluginPath();
        var fileNames = Directory.GetFiles(protosDirectory);

        foreach (var fileName in fileNames)
        {
            var cmdBuilder = new ProtocCommandBuilder(protoc, plugin, protosDirectory, fileName, outputDir);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    FileName = cmdBuilder.ProtocToolPath,
                    Arguments = cmdBuilder.GetParameters()
                }
            };

            process.Start();
            await process.WaitForExitAsync(); //todo fix if needed
        }
    }
}


// var protoc = ProtocPath();
// var plugin = ProtocPluginPath();
//
// Console.WriteLine($"Using: {protoc}");
// Console.WriteLine($"Using: {plugin}");
//
// var command = new string[]
// {
//     $"-I{ProtocolPath}",
//     $"--csharp_out={Output}",
//     $"--grpc_out={Output}",
//     $"--plugin=protoc-gen-grpc=\"{plugin}\"",
//     Protocol,
// };
//
// Console.WriteLine($"Exec: {protoc} {string.Join(' ', command)}");
//
// var process = new Process
// {
//     StartInfo = new ProcessStartInfo
//     {
//         UseShellExecute = false,
//         FileName = protoc,
//         Arguments = string.Join(' ', command)
//     }
// };
//
// process.Start();
// process.WaitForExit();
//
// Console.WriteLine($"Completed status: {process.ExitCode}");