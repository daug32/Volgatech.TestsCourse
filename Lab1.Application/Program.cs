using Lab1.Application.Domain;
using Lab1.Application.DTOs;

namespace Lab1.Application;

public class Program
{
    private static readonly TriangleTypeChecker _triangleTypeChecker = new();

    public static void Main( string[] args )
    {
        ResultDto resultDto = CheckTriangleType( args );
        Console.Write( resultDto.Message );
    }

    private static ResultDto CheckTriangleType( string[] args )
    {
        if ( args.Length != 3 )
        {
            return ResultDto.Error();
        }

        var sides = new List<float>( 3 );

        foreach ( string rawTriangleSideLength in args )
        {
            if ( !Single.TryParse( rawTriangleSideLength, out float side ) )
            {
                return ResultDto.Error();
            }

            sides.Add( side );
        }

        return ResultDto.Ok( _triangleTypeChecker.Check( 
            sides[0],
            sides[1],
            sides[2] ) );
    }
}