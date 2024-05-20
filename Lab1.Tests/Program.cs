using Lab1.Tests.Parsers;
using Lab1.Tests.Runners;

namespace Lab1.Tests;

public class Program
{
    private static readonly string _testCasesSourceFilePath = @"D:\Development\Projects\TestsCourse\Lab1.Tests\testCasesSource.txt";
    private static readonly string _testCasesRunResultFilePath = @"D:\Development\Projects\TestsCourse\Lab1.Tests\testCasesRunResult.txt";
    private static readonly string _programPath = @"D:\Development\Projects\TestsCourse\Lab1.Application\bin\Debug\net8.0\Lab1.Application.exe";

    public static void Main()
    {
        var testCasesFileParser = new TestCasesFileParser( _testCasesSourceFilePath );
        List<CheckTriangleTypeTestCase> testCases = testCasesFileParser.Parse();
        
        var testRunner = new TestRunner( _testCasesRunResultFilePath, _programPath );
        testRunner.RunTests( testCases );
    }
}