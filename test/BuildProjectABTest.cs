using System;
using System.IO;
using Selenium.WebDriver.IEDriver.NuPkg.Test.Lib;
using Xunit;

namespace Selenium.WebDriver.IEDriver.NuPkg.Test
{
    public class BuildProjectABTest : IDisposable
    {
        private string WorkDir { get; }

        public BuildProjectABTest()
        {
            WorkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString("N"));
            var srcDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProjectAB");
            Shell.XcopyDir(srcDir, WorkDir);
        }

        public void Dispose()
        {
            Shell.DeleteDir(WorkDir);
        }

        [Fact]
        public void Output_of_ProjectB_Contains_DriverFile_Test()
        {
            var devenv = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\devenv.exe";
            Shell.Run(WorkDir, "nuget", "restore").Is(0);
            Shell.Run(WorkDir, devenv, "ProjectAB.sln", "/Build").Is(0);

            var outDir = Path.Combine(WorkDir, "ProjectB", "bin", "Debug", "net472");
            var driverFullPath = Path.Combine(outDir, "iedriverserver.exe");
            File.Exists(driverFullPath).IsTrue();
        }
    }
}
