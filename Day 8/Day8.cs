using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code
{
    class Day8
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt");
            var lines = data.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(GetPartOne(lines));
            Console.WriteLine(GetPartTwo(lines));
        }

        static int GetPartOne(List<string> lines)
        {
            int total = 0;
            foreach(var line in lines)
            {
                var parts = line.Split("|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                var numbersInPart2 = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                total += numbersInPart2.Where(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7).Count();
            }

            return total;
        }

        static decimal GetPartTwo(List<string> lines)
        {
            decimal total = 0;

            foreach(var line in lines)
            {
                var parts = line.Split("|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                var map = MapSignals(parts[0]);
                var values = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                total += Int32.Parse(String.Join("", values.Select(x => map.Single(y => y.Value.Length == x.Length && !x.ToCharArray().Except(y.Value.ToCharArray()).Any()).Key)));
            }

            return total;
        }

        static Dictionary<string, string> MapSignals(string input)
        {
            var signals = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var map = new Dictionary<string, string>
            {
                ["1"] = signals.Single(x => x.Length == 2) ,
                ["4"] = signals.Single(x => x.Length == 4),
                ["7"] = signals.Single(x => x.Length == 3),
                ["8"] = signals.Single(x => x.Length == 7)
            };

            map["3"] = signals.Single(x => x.Length == 5 && !map["1"].ToCharArray().Except(x.ToCharArray()).Any()); //1 is subset of 3 and length 5
            map["9"] = signals.Single(x => x.Length == 6 && !map["4"].ToCharArray().Union(map["7"].ToCharArray()).Except(x.ToCharArray()).Any()); // 4union7 is subset of 9 and length 6
            map["2"] = signals.Single(x => x.Length == 5 && x.ToCharArray().Except(map["9"].ToCharArray()).Any()); //2 is not a subset of 9 and length 5
            map["5"] = signals.Single(x => x.Length == 5 && !map.Values.Contains(x)); //only length 5 left
            map["6"] = signals.Single(x => x.Length == 6 && !map["5"].ToCharArray().Except(x.ToCharArray()).Any() && x != map["9"]); //5 is non subset of 6 and not 9 and length 6
            map["0"] = signals.Single(x => !map.Values.Contains(x));

            return map;
        }
    }
}
