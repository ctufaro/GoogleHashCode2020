using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a file path");
            return;
        }

        string filePath = args[0];
        bool generateOutputFile = args[1] != null;
        string fileName = Path.GetFileName(filePath);
        string[] path = File.ReadAllLines(filePath);
        int[] set = path[1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        int max = Int32.Parse(path[0].Split(' ')[0]);
        GreedyLoop(max, set, generateOutputFile, fileName.Replace(".in", ".out"));
    }

    static void GreedyLoop(int max, int[] set, bool generateOutputFile = false, string outputFileName = "")
    {
        int bestSetLength = 0;
        int runningSum = 0;

        // DECREASE THE SIZE OF THE ARRAY FOR A BETTER APPROXIMATION
        int setLength = set.Length - 1;
        // BEST APPROXIMATION SHOULD BE CLOSEST TO ZERO (ZERO IS TARGET FOUND)
        int bestApproximation = Int32.MaxValue;

        while (setLength >= 0)
        {
            for (int i = setLength; i >= 0; i--)
            {
                if (runningSum == max)
                {
                    break;
                }
                else if (runningSum + set[i] > max)
                {
                    continue;
                }
                else
                {
                    runningSum += set[i];
                }
            }

            // RUNNING BEST APPROXIMATION, STORE SETLENGTH IN MEMORY
            if (Math.Abs(runningSum - max) == 0 || Math.Abs(runningSum - max) < bestApproximation)
            {
                bestApproximation = Math.Abs(runningSum - max);
                bestSetLength = setLength;
            }

            runningSum = 0;
            setLength--;
        }

        int outSum = 0;
        List<int> resultSet = GetOutputSet(bestSetLength, set, max, out outSum);
        Console.WriteLine("Total:" + outSum);

        if (generateOutputFile)
        {
            string count = resultSet.Count.ToString();
            string contents = String.Join(" ", resultSet.Select(p => p.ToString()).ToArray());
            File.WriteAllText(outputFileName, count + "\n" + contents);
        }
    }

    public static List<int> GetOutputSet(int setLength, int[] set, int max, out int sum)
    {
        int runningSum = 0;
        List<int> resultSet = new List<int>();

        for (int i = setLength; i >= 0; i--)
        {
            if (runningSum == max)
            {
                setLength = 0;
                break;
            }
            else if (runningSum + set[i] > max)
            {
                continue;
            }
            else
            {
                resultSet.Add(i);
                runningSum += set[i];
            }
        }

        sum = runningSum;
        resultSet.Sort();
        return resultSet;
    }

}