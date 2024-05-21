using Lab1.Tests.Parsers;
using Lab1.Tests.Runners;

namespace Lab1.Tests;

public class Program
{
    private static readonly string _defaultTestCaseSourceFilePath = @"C:\development\projects\qa\Lab1.Tests\testCasesSource.txt";
    private static readonly string _programPath = @"C:\development\projects\qa\Lab1.Application\bin\Debug\net7.0\Lab1.Application.exe";

    public static void Main()
    {
        string? testCasesSourceFilePath = AskForTestCasesSourceFilePath();
        if (testCasesSourceFilePath == null)
        {
            return;
        }

        string testCasesRunResultFilePath = Path.Combine(
            Path.GetDirectoryName(testCasesSourceFilePath),
            "testCasesRunResult.txt");

        var testCasesFileParser = new TestCasesFileParser( testCasesSourceFilePath );
        List<CheckTriangleTypeTestCase> testCases = testCasesFileParser.Parse();
        
        var testRunner = new TestRunner( testCasesRunResultFilePath, _programPath );
        testRunner.RunTests( testCases );
    }

    private static string? AskForTestCasesSourceFilePath()
    {
        Console.WriteLine("Введите путь до файла с тест кейсами (ничего для дефолтного значения):");
        
        string? testCasesSourceFilePath = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(testCasesSourceFilePath))
        {
            testCasesSourceFilePath = _defaultTestCaseSourceFilePath;
        }

        testCasesSourceFilePath = Path.GetFullPath(testCasesSourceFilePath);

        if (!File.Exists(testCasesSourceFilePath))
        {
            Console.WriteLine($"Файл не существует. FilePath: {testCasesSourceFilePath}");
            return null;
        }

        return testCasesSourceFilePath;
    }
}