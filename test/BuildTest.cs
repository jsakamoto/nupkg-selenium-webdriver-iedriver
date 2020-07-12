using System;
using System.IO;
using Selenium.WebDriver.IEDriver.NuPkg.Test.Lib;
using Xunit;

namespace Selenium.WebDriver.IEDriver.NuPkg.Test
{
    public class BuildTest : IDisposable
    {
        private string WorkDir { get; }

        public BuildTest()
        {
            WorkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString("N"));
            var srcDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Project");
            Shell.XcopyDir(srcDir, WorkDir);
        }

        public void Dispose()
        {
            Shell.DeleteDir(WorkDir);
        }

        [Fact]
        public void Build_Test()
        {
            var exitCode = Shell.Run(WorkDir, "dotnet", "build", "-o", "out");
            exitCode.Is(0);

            var driverFullPath = Path.Combine(WorkDir, "out", "iedriverserver.exe");
            File.Exists(driverFullPath).IsTrue();
        }

        [Fact]
        public void Publis_NoPublish_Test()
        {
            var exitCode = Shell.Run(WorkDir, "dotnet", "publish", "-o", "out");
            exitCode.Is(0);

            var driverFullPath = Path.Combine(WorkDir, "out", "iedriverserver.exe");
            File.Exists(driverFullPath).IsFalse();
        }

        [Fact]
        public void Publish_with_MSBuildProp_Test()
        {
            var exitCode = Shell.Run(WorkDir, "dotnet", "publish", "-o", "out", "-p:PublishIEDriver=true");
            exitCode.Is(0);

            var driverFullPath = Path.Combine(WorkDir, "out", "iedriverserver.exe");
            File.Exists(driverFullPath).IsTrue();
        }

        [Fact]
        public void Publish_with_DefineConstants_Test()
        {
            var exitCode = Shell.Run(WorkDir, "dotnet", "publish", "-o", "out", "-p:DefineConstants=_PUBLISH_IEDRIVER");
            exitCode.Is(0);

            var driverFullPath = Path.Combine(WorkDir, "out", "iedriverserver.exe");
            File.Exists(driverFullPath).IsTrue();
        }
    }
}
