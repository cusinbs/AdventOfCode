using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent_of_Code
{
    static class Day5
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt").Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList(); //remove \r
            var vents = text.Select(l => ConvertToVent(l)).ToList();
            var diagram = ConvertVentsToDiagram(vents);
            Console.WriteLine(diagram.Values.Where(x => x > 1).Count());
        }

        private static Dictionary<(int, int), int> ConvertVentsToDiagram(List<Vent> vents)
        {
            var diagram = new Dictionary<(int, int), int>();
            foreach (var vent in vents)
            {
                if (vent.X1 == vent.X2)
                {
                    int min = Math.Min(vent.Y1, vent.Y2);
                    int max = Math.Max(vent.Y1, vent.Y2);
                    for (int i = min; i <= max; i++)
                    {
                        if (diagram.ContainsKey((vent.X1, i)))
                        {
                            diagram[(vent.X1, i)] += 1;
                        }
                        else
                        {
                            diagram[(vent.X1, i)] = 1;
                        }
                    }
                }
                else if (vent.Y1 == vent.Y2)
                {
                    int min = Math.Min(vent.X1, vent.X2);
                    int max = Math.Max(vent.X1, vent.X2);
                    for (int i = min; i <= max; i++)
                    {
                        if (diagram.ContainsKey((i, vent.Y1)))
                        {
                            diagram[(i, vent.Y1)] += 1;
                        }
                        else
                        {
                            diagram[(i, vent.Y1)] = 1;
                        }
                    }
                }
                else
                {
                    var xRange = (vent.X1 < vent.X2 ? Enumerable.Range(vent.X1, vent.X2 - vent.X1 + 1) : Enumerable.Range(vent.X2, vent.X1 - vent.X2 + 1).Reverse()).ToList();
                    var yRange = (vent.Y1 < vent.Y2 ? Enumerable.Range(vent.Y1, vent.Y2 - vent.Y1 + 1) : Enumerable.Range(vent.Y2, vent.Y1 - vent.Y2 + 1).Reverse()).ToList();
                    for (int i = 0; i < xRange.Count(); i++)
                    {
                        if (diagram.ContainsKey((xRange[i], yRange[i])))
                        {
                            diagram[(xRange[i], yRange[i])] += 1;
                        }
                        else
                        {
                            diagram[(xRange[i], yRange[i])] = 1;
                        }
                    }
                }

            }
            return diagram;
        }

        private static Vent ConvertToVent(string line)
        {
            var coordinates = line.Split(" -> ").SelectMany(x => x.Split(",")).ToList();
            return new Vent
            {
                X1 = Int32.Parse(coordinates[0]),
                Y1 = Int32.Parse(coordinates[1]),
                X2 = Int32.Parse(coordinates[2]),
                Y2 = Int32.Parse(coordinates[3])
            };
        }
    }

    public class Vent
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}
