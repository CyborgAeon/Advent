using Advent.Handlers;
using System.IO;

var path = "C:\\work\\Source\\Advent\\Assets\\TrebuchetCoordinates";
Console.WriteLine($"Reading coordinates at {path}");
var coordinates = new TrebuchetReader().GetCoordinates(path);
Console.WriteLine($"Found the coordinates @'{coordinates}', supreme leader.");
Console.WriteLine("Fire at the SNOWy skies? Yes/No");
if (!Console.ReadLine().Contains('y')) return;

Console.WriteLine("Tally-ho!");
