namespace Lab1.Tests.Parsers;

public class ParsingSettings
{
    public readonly string SingleLineComment;
    public readonly string ExpectedResultSeparator;

    public ParsingSettings(
        string singleLineComment = "#",
        string expectedResultSeparator = "|" )
    {
        SingleLineComment = singleLineComment;
        ExpectedResultSeparator = expectedResultSeparator;
    }
}