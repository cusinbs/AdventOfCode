using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code
{
    class Day9
    {
        static void Main(string[] args)
        {
            var heightmap = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt")
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToCharArray().Select(y => char.GetNumericValue(y)).ToList()).ToList();
            Console.WriteLine(SumOfRisk(heightmap));
            Console.WriteLine(FindBasins(heightmap));
        }

        static double SumOfRisk(List<List<double>> map)
        {
            double total = 0;
            for (int i = 0; i < map.Count(); i++)
            {
                for (int j = 0; j < map[i].Count(); j++)
                {
                    if (j - 1 >= 0 && map[i][j] >= map[i][j - 1]) //check left
                    {
                        continue;
                    }
                    if (j + 1 < map[i].Count && map[i][j] >= map[i][j + 1]) //check right
                    {
                        continue;
                    }
                    if (i - 1 >= 0 && map[i][j] >= map[i - 1][j]) //check top
                    {
                        continue;
                    }
                    if (i + 1 < map.Count && map[i][j] >= map[i + 1][j]) //check bottom
                    {
                        continue;
                    }
                    total += map[i][j] + 1;
                }
            }

            return total;
        }

        static int FindBasins(List<List<double>> map)
        {
            var basins = new List<int>();
            for (int i = 0; i < map.Count(); i++) //loop thru everypoint that is not 9
            {
                for (int j = 0; j < map[i].Count(); j++)
                {
                    if(map[i][j] == 9)
                    {
                        continue;
                    }
                    basins.Add(FindBasinSize(map, i, j));
                }
            }

            var tempArr = basins.ToArray();
            Array.Sort(tempArr);
            Array.Reverse(tempArr);
            return tempArr[0] * tempArr[1] * tempArr[2];
        }

        static int FindBasinSize(List<List<double>> map, int i, int j) //recursion to find basin size
        {
            if (i < 0 || i >= map.Count || j < 0 || j >= map[0].Count || map[i][j] == 9)
            {
                return 0;
            }
            map[i][j] = 9;
            return 1 + FindBasinSize(map, i - 1, j) + FindBasinSize(map, i + 1, j) + FindBasinSize(map, i, j - 1) + FindBasinSize(map, i, j + 1);
        }
    }
}
