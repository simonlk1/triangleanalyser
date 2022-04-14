using Domain.Entities;
using Domain.Enums;

namespace Application;

public interface ITriangleDeterminer
{
    public TriangleType DetermineTriangle(Triangle triangle);
}