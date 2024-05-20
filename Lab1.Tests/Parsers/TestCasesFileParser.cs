﻿using Lab1.Tests.Runners;

namespace Lab1.Tests.Parsers;

public class TestCasesFileParser
{
    private readonly string _testCasesFilePath;

    public TestCasesFileParser( string testCasesFilePath )
    {
        _testCasesFilePath = testCasesFilePath;
    }

    public List<CheckTriangleTypeTestCase> Parse()
    {
        var result = new List<CheckTriangleTypeTestCase>();

        int lineNumber = 0;
        foreach ( string line in File.ReadAllLines( _testCasesFilePath ) )
        {
            lineNumber++;
            
            string sanitizedLine = line.TrimStart();

            // Skip empty lines
            if ( String.IsNullOrWhiteSpace( sanitizedLine ) )
            {
                continue;
            }

            // Skip comments
            if ( sanitizedLine.StartsWith( Settings.SingleLineComment ) )
            {
                continue;
            }

            CheckTriangleTypeTestCase testCase;
            try
            {
                testCase = ParseSingleTestCase( line );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Couldn't parse line {lineNumber}\nException message: {ex}" );
                continue;
            }

            result.Add( testCase );
        }

        return result;
    }

    private CheckTriangleTypeTestCase ParseSingleTestCase( string line )
    {
        string[] testCaseParts = line.Split( Settings.ExpectedResultSeparator );
        return new CheckTriangleTypeTestCase(
            testCaseParts[0],
            testCaseParts[1] );
    }
}