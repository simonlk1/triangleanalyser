using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.UnitTests;
using Xunit;

public class TriangleStoreTests
{
    [Fact]
    public void AddingTriangleToEmptyStoreShouldSucceed()
    {
        var store = new TriangleStore();
        var triangle = new Triangle(1, 1, 1);
        var type = TriangleType.Equilateral;

        var success = store.AddTriangle(triangle, type);

        Assert.True(success);
    }

    [Fact]
    public void AddingTriangleToEmptyStoreTwiceShouldFail()
    {
        var store = new TriangleStore();
        var triangle = new Triangle(1, 1, 1);
        var type = TriangleType.Equilateral;

        store.AddTriangle(triangle, type);
        var success = store.AddTriangle(triangle, type);

        Assert.False(success);
    }
    
}