using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\input.txt").Split("\n\n").ToList();
            var drawNumbers = text.First().Split(",").ToList();
            text.RemoveAt(0);

            var aob = ConvertBoardsToArrayOfBoards(text.ToList());
            Console.WriteLine(GetFirstBoardScore(drawNumbers, aob));
            Console.WriteLine(GetLastBoardScore(drawNumbers, aob));
        }

        static int GetFirstBoardScore(List<string> drawNumbers, List<List<List<string>>> boards)
        {
            foreach (var num in drawNumbers)
            {
                foreach (var board in boards)
                {
                    foreach (var line in board)
                    {
                        if (line.Contains(num))
                        {
                            var index = line.IndexOf(num);
                            line[index] = "";
                            if(line.All(n => n == "") || board.Select(l => l[index]).All(n => n == "")) //horizontal check and vertical check
                            {
                                return CalculateFinalScore(board, num);
                            }
                            break;
                        }
                    }
                }
            }
            return 0;
        }

        static int GetLastBoardScore(List<string> drawNumbers, List<List<List<string>>> boards)
        {
            foreach (var num in drawNumbers)
            {
                foreach (var board in boards.ToList())
                {
                    foreach (var line in board)
                    {
                        if (line.Contains(num))
                        {
                            var index = line.IndexOf(num);
                            line[index] = "";
                            if (line.All(n => n == "") || board.Select(l => l[index]).All(n => n == "")) //horizontal check and vertical check
                            {
                                if(boards.Count > 1)
                                {
                                    boards.Remove(board);
                                }
                                else
                                {
                                    return CalculateFinalScore(boards.First(), num);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return 0;
        }

        private static int CalculateFinalScore(List<List<string>> board, string num)
        {
            
            return Int32.Parse(num) * board.Sum(x => x.Sum(y => { Int32.TryParse(y, out int value); return value; }));
        }

        static List<List<List<string>>> ConvertBoardsToArrayOfBoards(List<string> input)
        {
            return input.Select(x => ConvertBoardTo2DArray(x.Trim())).ToList();
        }

        static List<List<string>> ConvertBoardTo2DArray(string board)
        {
            return board.Split("\n").Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
        }
    }
}
