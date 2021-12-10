using System;
using System.Collections.Generic;
using System.Linq;
namespace Advent_of_Code
{
    class Day10
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllText(@"C:\Users\anguyen\Desktop\Advent of Code\Input\input.txt").Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(data.Select(x => LineErrorScore(x)).Sum());
            data.RemoveAll(x => LineErrorScore(x) != 0);
            var scores = new List<double>();
            foreach(var line in data)
            {
                scores.Add(Part2(line));
            }
            var array = scores.ToArray();
            Array.Sort(array);
            Console.WriteLine(array[(array.Length) / 2]);
        }

        static int Part1(string line)
        {
            var stack = new Stack<char>();

            foreach(var c in line)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '<':
                        stack.Push('>');
                        break;
                    case ')':
                        if(stack.Count == 0 || stack.Pop() != ')')
                        {
                            return 3;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != ']')
                        {
                            return 57;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '}')
                        {
                            return 1197;
                        }
                        break;
                    case '>':
                        if (stack.Count == 0 || stack.Pop() != '>')
                        {
                            return 25137;
                        }
                        break;
                    default:
                        return 0;
                }
            }
            return 0;
        }

        static double Part2(string line)
        {
            var stack = new Stack<char>();
            double total = 0;
            var score = new Dictionary<char, int>
            {
                [')'] = 1,
                [']'] = 2,
                ['}'] = 3,
                ['>'] = 4
            };

            foreach (var c in line)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '<':
                        stack.Push('>');
                        break;
                    default:
                        stack.Pop();
                        break;
                }
            }

            foreach(var c in stack)
            {
                total = total * 5 + score[c];
            }

            return total;
        }
    }
}
