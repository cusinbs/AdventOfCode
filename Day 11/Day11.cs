using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code
{
    class Day11
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt")
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToCharArray().Select(y => new Octopus { Energy = char.GetNumericValue(y), Flashed = false }).ToList()).ToList();
            Console.WriteLine(Part1(100, data));
            Console.WriteLine(100 + Part2(data)); //plus 100 previous steps in part 1
        }

        static int Part1(int steps, List<List<Octopus>> grid)
        {
            int totalFlashes = 0;
            for (int k = 0; k < steps; k++)
            {
                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[0].Count; j++)
                    {
                        totalFlashes += IncreaseNearby(grid, i, j);
                    }
                }
                foreach(var line in grid)
                {
                    foreach(var octopus in line)
                    {
                        octopus.Flashed = false;
                    }
                }
            }
            return totalFlashes;
        }

        static int Part2(List<List<Octopus>> grid) //similar to part 1. just add an additional check if all octopuses have flashed
        {
            int step = 0;
            while (true) //while true goes brr brr
            {
                step++;
                for (int i = 0; i < grid.Count; i++)
                {
                    for (int j = 0; j < grid[0].Count; j++)
                    {
                        IncreaseNearby(grid, i, j);
                    }
                }
                if (grid.All(x => x.All(y => y.Flashed)))
                {
                    return step;
                }
                foreach (var line in grid)
                {
                    foreach (var octopus in line)
                    {
                        octopus.Flashed = false;
                    }
                }
            }
        }

        static int IncreaseNearby(List<List<Octopus>> array, int i, int j)
        {
            if (i < 0 || i >= array.Count || j < 0 || j >= array[0].Count || array[i][j].Flashed)
            {
                return 0;
            }

            array[i][j].Energy++;
            if (array[i][j].Energy > 9)
            {
                array[i][j].Energy = 0;
                array[i][j].Flashed = true;
                return 1 + IncreaseNearby(array, i - 1, j - 1) +
                IncreaseNearby(array, i - 1, j) +
                IncreaseNearby(array, i - 1, j + 1) +
                IncreaseNearby(array, i, j - 1) +
                IncreaseNearby(array, i, j + 1) +
                IncreaseNearby(array, i + 1, j - 1) +
                IncreaseNearby(array, i + 1, j) +
                IncreaseNearby(array, i + 1, j + 1);
            }

            return 0;
        }
    }

    class Octopus
    {
        public double Energy { get; set; }

        public bool Flashed { get; set; }
    }
}
