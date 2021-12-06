using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent_of_Code
{
    internal class Day6
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt").Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var data = text.Select(x => Int32.Parse(x)).ToList();
            var dayTillReproduce = new Dictionary<int, double>
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };

            foreach (var fishAge in data)
            {
                dayTillReproduce[fishAge]++;
            }

            Console.WriteLine(BeingAFishSimulator(dayTillReproduce, 256));
        }

        static double BeingAFishSimulator(Dictionary<int, double> dayTillReproduce, int day)
        {
            for(int i = 0; i < day; i++)
            {
                var tempDict = new Dictionary<int, double>();
                tempDict[0] = dayTillReproduce[1];
                tempDict[1] = dayTillReproduce[2];
                tempDict[2] = dayTillReproduce[3];
                tempDict[3] = dayTillReproduce[4];
                tempDict[4] = dayTillReproduce[5];
                tempDict[5] = dayTillReproduce[6];
                tempDict[6] = dayTillReproduce[7] + dayTillReproduce[0];
                tempDict[7] = dayTillReproduce[8];
                tempDict[8] = dayTillReproduce[0];
                dayTillReproduce = tempDict;
            }

            return dayTillReproduce.Values.Sum();
        }
    }
}
