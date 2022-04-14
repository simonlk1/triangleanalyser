using Application;
using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Infrastructure.UnitTests;

public class TriangleAnalyserTests
{
    [Fact]
    public void AnalysingTriangleShouldCallDetermineAndAddOnce()
    {
        var storeMock = new Mock<ITriangleStore>();
        var determinerMock = new Mock<ITriangleDeterminer>();
        var analyser = new TriangleAnalyser(storeMock.Object, determinerMock.Object);
        var triangle = new Triangle(1, 1, 1);
        
        analyser.AnalyseTriangle(triangle);
        
        determinerMock.Verify(d => d.DetermineTriangle(It.IsAny<Triangle>()), Times.Once());
        storeMock.Verify(s => s.AddTriangle(It.IsAny<Triangle>(), It.IsAny<TriangleType>()), Times.Once());
    }
}