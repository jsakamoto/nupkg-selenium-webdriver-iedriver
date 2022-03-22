namespace Selenium.WebDriver.IEDriver.NuPkg.Test;

[Parallelizable(ParallelScope.All)]
public class BuildTest
{
    private WorkDirectory CreateWorkDir()
    {
        var unitTestProjectDir = FileIO.FindContainerDirToAncestor("*.csproj");
        return WorkDirectory.CreateCopyFrom(Path.Combine(unitTestProjectDir, "Project"), predicate: item => item.Name is not "obj" and not "bin");
    }

    [Test]
    public async Task Build_Test()
    {
        using var workDir = this.CreateWorkDir();
        var dotnet = await XProcess.Start("dotnet", "build -o out", workDir).WaitForExitAsync();
        dotnet.ExitCode.Is(0);

        var driverFullPath = Path.Combine(workDir, "out", "iedriverserver.exe");
        File.Exists(driverFullPath).IsTrue();
    }

    [Test]
    public async Task Publis_NoPublish_Test()
    {
        using var workDir = this.CreateWorkDir();
        var dotnet = await XProcess.Start("dotnet", "publish -o out", workDir).WaitForExitAsync();
        dotnet.ExitCode.Is(0);

        var driverFullPath = Path.Combine(workDir, "out", "iedriverserver.exe");
        File.Exists(driverFullPath).IsFalse();
    }

    [Test]
    public async Task Publish_with_MSBuildProp_Test()
    {
        using var workDir = this.CreateWorkDir();
        var dotnet = await XProcess.Start("dotnet", "publish -o out -p:PublishIEDriver=true", workDir).WaitForExitAsync();
        dotnet.ExitCode.Is(0);

        var driverFullPath = Path.Combine(workDir, "out", "iedriverserver.exe");
        File.Exists(driverFullPath).IsTrue();
    }

    [Test]
    public async Task Publish_with_DefineConstants_Test()
    {
        using var workDir = this.CreateWorkDir();
        var dotnet = await XProcess.Start("dotnet", "publish -o out -p:DefineConstants=_PUBLISH_IEDRIVER", workDir).WaitForExitAsync();
        dotnet.ExitCode.Is(0);

        var driverFullPath = Path.Combine(workDir, "out", "iedriverserver.exe");
        File.Exists(driverFullPath).IsTrue();
    }
}
