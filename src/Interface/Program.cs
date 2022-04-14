using Domain.Entities;
using Infrastructure;

var determiner = new TriangleDeterminer();
var store = new TriangleStore();
var analyser = new TriangleAnalyser(store, determiner);

for (int i = 0; i < 5; i++)
{
    var input = Console.ReadLine()?.Split(';');
    Int32.TryParse(input[0], out var side1);
    Int32.TryParse(input[1], out var side2);
    Int32.TryParse(input[2], out var side3);
    
    var triangle = new Triangle(side1, side2, side3);
    
    analyser.AnalyseTriangle(triangle);
}

foreach (var trianglePair in store.Triangles)
{
    Console.WriteLine($"{trianglePair.Item1} has type {trianglePair.Item2}");
}
