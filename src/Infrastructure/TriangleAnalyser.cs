using Application;
using Domain.Entities;

namespace Infrastructure;

public class TriangleAnalyser : ITriangleAnalyser
{
    private readonly ITriangleStore _store;
    private readonly ITriangleDeterminer _determiner;
    
    public TriangleAnalyser(ITriangleStore store, ITriangleDeterminer determiner)
    {
        _store = store;
        _determiner = determiner;
    }
    
    public void AnalyseTriangle(Triangle triangle)
    {
        var type = _determiner.DetermineTriangle(triangle);

        _store.AddTriangle(triangle, type);
    }
}