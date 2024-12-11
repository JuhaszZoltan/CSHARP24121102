using BarlangCLI;
using System.Text;

const string FILE = "..\\..\\..\\resources\\barlangok.txt";
List<Barlang> barlangok = [];

using StreamReader sr = new(FILE, Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) barlangok.Add(new(sr.ReadLine()));

Console.WriteLine($"4. feladat: barlangok szama: {barlangok.Count}");