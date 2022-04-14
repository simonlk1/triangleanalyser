using Domain.Entities;
using Domain.Enums;
using Xunit;

namespace Infrastructure.UnitTests;

public class TriangleDeterminerTests
{
    [Fact]
    public void TriangleWithNegativeSide1ShouldBeInvalid()
    {
        var triangle = new Triangle(-1, 1, 1);
        var determiner = new TriangleDeterminer();
        
        var expected = TriangleType.Invalid;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TriangleWithNegativeSide2ShouldBeInvalid()
    {
        var triangle = new Triangle(1, -1, 1);
        var determiner = new TriangleDeterminer();
        
        var expected = TriangleType.Invalid;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TriangleWithNegativeSide3ShouldBeInvalid()
    {
        var triangle = new Triangle(1, 1, -1);
        var determiner = new TriangleDeterminer();

        var expected = TriangleType.Invalid;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TriangleWithAllSidesLengthOneShouldBeEquilateral()
    {
        var triangle = new Triangle(1, 1, 1);
        var determiner = new TriangleDeterminer();
        
        var expected = TriangleType.Equilateral;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TriangleWithSidesLengthOneTwoThreeShouldBeScalene()
    {
        var triangle = new Triangle(1, 2, 3);
        var determiner = new TriangleDeterminer();
        
        var expected = TriangleType.Scalene;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TriangleWithSidesLengthOneTwoTwoShouldBeIsosceles()
    {
        var triangle = new Triangle(1, 2, 2);
        var determiner = new TriangleDeterminer();
        
        var expected = TriangleType.Isosceles;
        var actual = determiner.DetermineTriangle(triangle);
        
        Assert.Equal(expected, actual);
    }

}