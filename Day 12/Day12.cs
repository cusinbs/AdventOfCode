using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Advent_of_Code
{
    class Day12
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt");
            var map = ConvertToMap(data);
            Console.WriteLine(GetPathCount("start", ImmutableHashSet.Create<string>("start"), map, false, false)); //part 1
            Console.WriteLine(GetPathCount("start", ImmutableHashSet.Create<string>("start"), map, true, false)); //part 2
        }

        static int GetPathCount(string currentCave, ImmutableHashSet<string> visitedCaves, Dictionary<string, List<string>> map, bool isPart2, bool hasVisitedSmallCave)
        {
            if(currentCave == "end")
            {
                return 1;
            }

            int total = 0;

            foreach (var cave in map[currentCave])
            {
                bool isBigCave = cave.ToUpper() == cave;
                bool visited = visitedCaves.Contains(cave);
                if (isBigCave || !visited)
                {
                    total += GetPathCount(cave, visitedCaves.Add(currentCave), map, isPart2, hasVisitedSmallCave);
                }
                else if (isPart2 && !isBigCave && !hasVisitedSmallCave && cave != "start") //for part 2 only
                {
                    total += GetPathCount(cave, visitedCaves.Add(currentCave), map, isPart2, true);
                }
            }

            return total;
        }


        static Dictionary<string, List<string>> ConvertToMap(string data)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (var line in data.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (!map.ContainsKey(parts[0]))
                {
                    map.Add(parts[0], new List<string>());
                }
                if (!map.ContainsKey(parts[1]))
                {
                    map.Add(parts[1], new List<string>());
                }
                map[parts[0]].Add(parts[1]);
                map[parts[1]].Add(parts[0]);
            }
            return map;
        }
    }
}
