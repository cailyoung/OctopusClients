using System;
using System.IO;
using Octopus.Client;
using Serilog;

namespace Scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.ColoredConsole().CreateLogger();

            var repository = new OctopusRepository(new OctopusServerEndpoint("http://localhost/"));
            repository.Users.SignIn("Admin", "Password01!");

            repository.BuiltInPackageRepository.PushPackage(@"Zip.2.0.0.zip", File.OpenRead(@"c:\temp\packages\Zip.2.0.0.zip"), true, true);
        }
    }
}