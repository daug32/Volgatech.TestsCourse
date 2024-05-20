using System.Diagnostics;

namespace Lab1.Tests.Runners;

public class TestRunner
{
    private readonly string _runResultFilePath;
    private readonly string _programPath;

    public TestRunner( string runResultFilePath, string programPath )
    {
        _runResultFilePath = runResultFilePath;
        _programPath = programPath;
    }

    public void RunTests( IEnumerable<CheckTriangleTypeTestCase> testCases )
    {
        using var writer = new StreamWriter( _runResultFilePath, false );

        foreach ( CheckTriangleTypeTestCase testCase in testCases )
        {
            RunTest( testCase, writer );
        }
    }

    private void RunTest( CheckTriangleTypeTestCase testCase, StreamWriter writer )
    {
        string programOutput;

        try
        {
            programOutput = RunProgram( testCase.Arguments );
        }
        catch ( Exception ex )
        {
            writer.WriteLine( ex.ToString() );
            return;
        }

        string testResult = testCase.ExpectedResult == programOutput
            ? "success"
            : "error";

        Console.WriteLine( $"Test: \"{testCase.Arguments}\" Result: {testResult}" );
        writer.WriteLine( testResult );
    }

    private string RunProgram( string arguments )
    {
        var processStartInfo = new ProcessStartInfo
        {
            Arguments = $"{arguments}",
            FileName = _programPath,
            RedirectStandardOutput = true
        };

        var process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();

        return process.StandardOutput.ReadToEnd();
    }
}