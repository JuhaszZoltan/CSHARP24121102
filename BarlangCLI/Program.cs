using BarlangCLI;
using System.Text;

const string FILE = "..\\..\\..\\resources\\barlangok.txt";
List<Barlang> barlangok = [];

using StreamReader sr = new(FILE, Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) barlangok.Add(new(sr.ReadLine()));

Console.WriteLine($"4. feladat: barlangok szama: {barlangok.Count}");

var f5 = barlangok
    .Where(b => b.Telepules.StartsWith("Miskolc"))
    .Average(b => b.Melyseg);
Console.WriteLine("5. feladat: miskolci barlangok atlagos melysege: " +
    $"{f5:0.000} meter");

Console.Write("6. feladat: kerem a vedettsegi szintet: ");
string f6VSzint = Console.ReadLine() ?? throw new Exception("fck off!");
var f6 = barlangok
    .Where(b => b.Vedettseg == f6VSzint)
    .MaxBy(b => b.Hossz);
Console.WriteLine(f6 is null
    ? "\tnincs ilyen vedettsegi szinttel jelolt barlang az adfatok kozt"
    : $"\tleghoszabb {f6VSzint} barlang:\n {f6}");

var f7 = barlangok
    .GroupBy(b => b.Vedettseg)
    .ToDictionary(g => g.Key, g => g.Count());
Console.WriteLine("7. feladat: statisztika:");
foreach (var kvp in f7) Console.WriteLine(
    $"{kvp.Key,-30}".Replace(' ', '-') + $"> {kvp.Value,3} db");

