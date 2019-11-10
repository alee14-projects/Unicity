using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;

namespace Unicity.DevLauncher
{
    class Program
    {
        const string devUrl = "https://dl.dropboxusercontent.com/s/2rfo1tycz73rr5s/dev.zip";
        static string tempDir = Path.GetTempPath() + "unicity";

        static void Main(string[] args)
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
            Directory.CreateDirectory(tempDir);
            
            using (WebClient client = new WebClient())
            {
                System.Console.WriteLine("Downloading latest build...");
                client.DownloadFile(devUrl, tempDir + "/game.zip");
                Console.WriteLine("Extracting files...");
                ZipFile.ExtractToDirectory(tempDir + "/game.zip", tempDir + "/game");

                Console.WriteLine("Launching game...");
                Assembly assembly = Assembly.LoadFrom(Path.GetFullPath(tempDir + "/game/dotnet-framework-all/Unicity.Game.exe"));
                Type program = assembly.GetType("Unicity.Game.Program");
                MethodInfo main = program.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
                main.Invoke(null, new object[] { args });
            }
        }
    }
}
