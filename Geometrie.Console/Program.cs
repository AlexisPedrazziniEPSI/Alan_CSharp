using System.Diagnostics.Tracing;
using Geometrie.BLL;

var p1 = new Point(4, 8);
var p2 = new Point(2, 3);

var text = new SetHelloWorld("Hello World");

var poly = new Quadrilatère(new Point(0, 0), new Point(0,4), new Point(4,0), new Point(4,4));

Console.WriteLine($"Le point p1 a pour coordonnées ({p1.X}, {p1.Y})");
Console.WriteLine(p2.CalculDistance(p1));
Console.WriteLine(text.Texte);

for (int i = 0; i < poly.Count; i++)
{
    Console.WriteLine($"Le point {i + 1} a pour coordonnées ({poly[i].X}, {poly[i].Y})");
}

foreach (var point in poly)
{
    Console.WriteLine(point);
}

var Cercle = new Cercle(new Point(4, 8), 5);
Console.WriteLine(Cercle.CalculerPerimetre());
Console.WriteLine(poly.CalculerPerimetre());

var ListeDeFormes = new List<IForme>();
ListeDeFormes.Add(poly);
ListeDeFormes.Add(Cercle);

foreach (var forme in ListeDeFormes)
{
    Console.WriteLine(forme.CalculerPerimetre());
    Console.WriteLine(forme.CalculAire());
}