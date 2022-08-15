using System.IO.Compression;
using System.Runtime.InteropServices;
using Mono.Unix;

namespace ClassGenerator;

public class GrpcToolsHelper
{
    private const string ToolsUrl = "https://www.nuget.org/api/v2/package/Grpc.Tools/";
    private bool IsInited => !Directory.Exists("Tools");

    public async Task<string> GetProtocToolPath()
    {
        if (IsInited)
            return ProtocPath();
        await InitToolsAsync();
        return ProtocPath();
    }

    public async Task<string> GetProtocCSharpPluginPath()
    {
        if (IsInited)
            return ProtocPluginPath();
        await InitToolsAsync();
        return ProtocPluginPath();
    }

    public async Task InitToolsAsync()
    {
        if (!Directory.Exists("Tools"))
        {
            Console.WriteLine("No local tools found, downloading binaries from nuget...");
            Directory.CreateDirectory("Tools");
            await DownloadTools();
            ExtractTools();
        }
    }

    private static void ExtractTools()
    {
        ZipFile.ExtractToDirectory(Path.Combine("Tools", "tools.zip"), Path.Combine("Tools", "bin"));
    }

    private static async Task DownloadTools()
    {
        using (var client = new HttpClient())
        {
            Console.WriteLine($"Fetching: {ToolsUrl}");
            using (var result = await client.GetAsync(ToolsUrl))
            {
                if (!result.IsSuccessStatusCode)
                    throw new Exception($"Unable to download tools ({result.StatusCode}), check URL");
                var localArchive = Path.Combine("Tools", "tools.zip");
                Console.WriteLine($"Saving to: {localArchive}");
                File.WriteAllBytes(localArchive, await result.Content.ReadAsByteArrayAsync());
            }
        }
    }

    private static string ProtocPath()
    {
        var path = Path.Combine("Tools", "bin", "tools", DetermineArch(), "protoc");
        RequireExecutablePermission(path);
        return WithExeExtensionIfRequired(path);
    }

    private static string ProtocPluginPath()
    {
        var path = Path.Combine("Tools", "bin", "tools", DetermineArch(), "grpc_csharp_plugin");
        RequireExecutablePermission(path);
        return WithExeExtensionIfRequired(path);
    }

    private static void RequireExecutablePermission(string path)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

        Console.WriteLine($"Ensuring +x on {path}");
        var unixFileInfo = new UnixFileInfo(path);
        unixFileInfo.FileAccessPermissions = FileAccessPermissions.UserRead | FileAccessPermissions.UserWrite |
                                             FileAccessPermissions.UserExecute;
    }

    private static string WithExeExtensionIfRequired(string path)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            path += ".exe";
        }

        return path;
    }

    private static string DetermineArch()
    {
        var arch = RuntimeInformation.OSArchitecture;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return WithArch("windows_", arch);
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return WithArch("macosx_", arch);
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return WithArch("linux_", arch);
        }

        throw new Exception("Unable to determine runtime");
    }

    private static string WithArch(string platform, Architecture arch)
    {
        switch (arch)
        {
            case Architecture.X64:
                return $"{platform}x86";
            case Architecture.X86:
                return $"{platform}x64";
            default:
                throw new ArgumentOutOfRangeException(nameof(arch), arch, null);
        }
    }
}