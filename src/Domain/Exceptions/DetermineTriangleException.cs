using Domain.Entities;

namespace Domain.Exceptions;

public class DetermineTriangleException : Exception
{
    public DetermineTriangleException(Triangle triangle)
        : base($"Could not determine type of triangle with sides {triangle.Side1}, {triangle.Side2}, {triangle.Side3}")
    {
    }
}