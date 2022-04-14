using Domain.Entities;
using Domain.Enums;

namespace Application;

public interface ITriangleStore
{
    public ISet<(Triangle, TriangleType)> Triangles { get; }
    public bool AddTriangle(Triangle triangle, TriangleType type);
}