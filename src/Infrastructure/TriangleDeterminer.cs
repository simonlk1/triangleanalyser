using Application;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;

namespace Infrastructure;

public class TriangleDeterminer : ITriangleDeterminer
{
    public TriangleType DetermineTriangle(Triangle triangle)
    {
        if (!IsValid(triangle))
        {
            return TriangleType.Invalid;
        }
        
        if (IsEquilateral(triangle))
        {
            return TriangleType.Equilateral;
        }

        if (IsIsosceles(triangle))
        {
            return TriangleType.Isosceles;
        }

        if (IsScalene(triangle))
        {
            return TriangleType.Scalene;
        }

        throw new DetermineTriangleException(triangle);
    }

    // We allow degenerate triangles
    public bool IsValid(Triangle triangle)
    {
        if (triangle.Side1 < 0)
        {
            return false;
        }

        if (triangle.Side2 < 0)
        {
            return false;
        }

        if (triangle.Side3 < 0)
        {
            return false;
        }

        if (IsInequal(triangle))
        {
            return false;
        }

        return true;
    }

    public bool IsInequal(Triangle triangle)
    {
        var (side1, side2, side3) = triangle;

        var sides = new[] {side1, side2, side3};
        
        Array.Sort(sides);
        var longestSide = sides[0];
        var midSide = sides[1];
        var shortestSide = sides[2];

        return longestSide > midSide + shortestSide;
    }
    public bool IsScalene(Triangle triangle)
    {
        var (side1, side2, side3) = triangle;
        
        if (side1 == side2)
        {
            return false;
        }

        if (side1 == side3)
        {
            return false;
        }

        if (side2 == side3)
        {
            return false;
        }

        return true;
    }


    public bool IsEquilateral(Triangle triangle)
    {
        var (side1, side2, side3) = triangle;
        
        return side1 == side2 && side1 == side3;
    }

    // We follow the definition that the equilateral triangle is also isosceles (but equilateral binds stronger)
    public bool IsIsosceles(Triangle triangle)
    {
        var (side1, side2, side3) = triangle;
        
        if (side1 == side2)
        {
            return true;
        }

        if (side1 == side3)
        {
            return true;
        }

        if (side2 == side3)
        {
            return true;
        }

        return false;
    }
}