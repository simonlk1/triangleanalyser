using Application;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure;

public class TriangleStore : ITriangleStore
{
    public ISet<(Triangle, TriangleType)> Triangles { get; }

    public TriangleStore()
    {
        Triangles = new HashSet<(Triangle, TriangleType)>();

    }

    public bool AddTriangle(Triangle triangle, TriangleType type)
    {
        return Triangles.Add((triangle, type));
    }
}