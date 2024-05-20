namespace Lab1.Tests.Runners;

public class CheckTriangleTypeTestCase
{
    public readonly string Arguments;
    public readonly string ExpectedResult;

    public CheckTriangleTypeTestCase(
        string arguments,
        string expectedResult )
    {
        Arguments = arguments;
        ExpectedResult = String.IsNullOrWhiteSpace( expectedResult )
            ? throw new ArgumentException( "Expected result can not be null or whitespace" )
            : expectedResult.Trim();
    }
}