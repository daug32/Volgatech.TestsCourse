using Lab1.Application.Domain;

namespace Lab1.Application.DTOs;

public class ResultDto
{
    public readonly string Message;

    public static ResultDto Error() => new( "неизвестная ошибка" );

    public static ResultDto Ok( TriangleType triangleType ) => new( SerializeTriangleType( triangleType ) );

    private ResultDto( string message )
    {
        Message = message;
    }

    private static string SerializeTriangleType( TriangleType triangleType )
    {
        return triangleType switch
        {
            TriangleType.Unknown => "не треугольник",
            TriangleType.Ordinary => "обычный",
            TriangleType.Isosceles => "равнобедренный",
            TriangleType.Equilateral => "равносторонний",
            _ => throw new ArgumentOutOfRangeException( nameof( triangleType ), triangleType, null )
        };
    }
}