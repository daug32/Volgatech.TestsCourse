namespace Lab1.Application.Domain;

public class TriangleTypeChecker
{
    /// <summary>
    /// Checks the type of a triangle using its sides
    /// </summary>
    /// <param name="a">The first side of a triangle</param>
    /// <param name="b">The second side of a triangle</param>
    /// <param name="c">The third side of a triangle</param>
    public TriangleType Check( float a, float b, float c )
    {
        bool isTriangle = a + b > c && a + c > b && b + c > a;
        if ( !isTriangle )
        {
            return TriangleType.Unknown;
        }

        if ( a == b && b == c )
        {
            return TriangleType.Equilateral;
        }

        if ( a == b || a == c || b == c )
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Ordinary;
    }
}