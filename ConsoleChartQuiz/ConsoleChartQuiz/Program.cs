using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleChartQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> grouping = new Dictionary<string, int>();
            Dictionary<string, int> numerning = new Dictionary<string, int>();

            //  string group = args[0];

            string[] allLines = File.ReadAllLines("data.txt");

            //Einlesen in die Dictionary
            for (int i = 1; i < allLines.Length; i++)
            {
                if (!grouping.ContainsKey(allLines[i].Split('\t')[2]))
                {
                    grouping.Add(allLines[i].Split('\t')[2], int.Parse(allLines[i].Split('\t')[3]));
                }
                else
                {
                    grouping[allLines[i].Split('\t')[2]] += int.Parse(allLines[i].Split('\t')[3]);
                }
            }

                grouping = grouping.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

                for (int i = 0; i < grouping.Count; i++)
                {
                    Console.WriteLine($"{grouping.ElementAt(i).Key}, {grouping.ElementAt(i).Value}");
                }

            Console.ReadLine();

        }

        }

    }

