using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code
{
    class Day7
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt").Split(",", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            var median = Convert.ToInt32(Math.Floor(Median(data)));

            Console.WriteLine(TotalFuelUsed(data, median));
            Console.WriteLine(TotalFuelUsedPart2(data));
        }

        static decimal TotalFuelUsed(int[] data, int endpoint)
        {
            return data.Select(x => Math.Abs(x - endpoint)).Sum();
        }

        static decimal TotalFuelUsedPart2(int[] data) //let's crank up the CPU
        {
            decimal minSum = Decimal.MaxValue;
            Array.Sort(data);
            for (int i = data[0]; i <= data[data.Length-1]; i ++)
            {
                decimal tempMinSum = 0;
                foreach (var num in data)
                {
                    for (int j = 1; j <= Math.Abs(num - i); j++)
                    {
                        tempMinSum += j;
                    }
                    
                }
                minSum = Math.Min(tempMinSum, minSum);
            }
            return minSum;
        }

        static decimal Median(int[] data)
        {
            Array.Sort(data);
            return data[data.Length / 2];
        }
    }
}
