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
        string[] backTrackFiles = new string[] { "a_exmaple.in", "b_small.in", "c_medium.in" };
        int[] set = path[1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        int max = Int32.Parse(path[0].Split(' ')[0]);

        if (backTrackFiles.Any(fileName.Contains))
            BackTrack(max, set, generateOutputFile, fileName.Replace(".in", ".out"));
        else
            GreedyLoop(max, set, generateOutputFile, fileName.Replace(".in", ".out"));
    }

    static void GreedyLoop(int max, int[] set, bool generateOutputFile = false, string outputFileName = "")
    {
        int runningSum = 0;
        List<int> resultSet = new List<int>();

        for (int i = set.Length - 1; i >= 0; i--)
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
                resultSet.Add(i);
                runningSum += set[i];
            }
        }
        resultSet.Sort();
        Console.WriteLine("Total: " + runningSum);

        if (generateOutputFile)
            File.WriteAllText(outputFileName, resultSet.Count.ToString());

        resultSet.Sort();

        if (generateOutputFile)
        {
            string count = resultSet.Count.ToString();
            string contents = String.Join(" ", resultSet.Select(p => p.ToString()).ToArray());
            File.WriteAllText(outputFileName, count + "\n" + contents);
        }
    }

    public static bool[,] CreateMatrix(int maxSlices, int[] slices)
    {
        int rows = slices.Length;
        int columns = maxSlices + 1;

        bool[,] matrix = new bool[rows, columns];
        int level = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < maxSlices + 1; c++)
            {
                if (c == 0)
                {
                    //zero slices just set to true
                    matrix[r, c] = true;
                }
                else if (c == slices[r] && level == 0)
                {
                    matrix[r, c] = true;
                }
                else if (c != slices[r] && level == 0)
                {
                    matrix[r, c] = false;
                }
                else if (c < slices[r] && level > 0)
                {
                    //copy the previous row
                    matrix[r, c] = matrix[r - 1, c];
                }
                else if (matrix[r - 1, c] && level > 0)
                {
                    //previous row was true
                    matrix[r, c] = true;
                }
                else if (!matrix[r - 1, c] && level > 0)
                {
                    //previous row was false, hop back the number in the slices array
                    matrix[r, c] = matrix[r - 1, c - slices[r]];
                }
            }
            level++;
        }
        return matrix;
    }

    public static void BackTrack(int maxSlices, int[] pizzaSlices, bool generateOutputFile = false, string outputFileName = "")
    {
        bool[,] matrix = CreateMatrix(maxSlices, pizzaSlices);
        List<int> results = new List<int>();
        int currentRow = matrix.GetLength(0) - 1;
        int currentColumn = matrix.GetLength(1) - 1;
        int sum = 0;

        while (true)
        {
            if (currentColumn == 0)
            {
                break;
            }
            else if ((currentRow - 1 >= 0) && matrix[currentRow - 1, currentColumn] == false)
            {
                sum += pizzaSlices[currentRow];
                results.Add(currentRow);
                currentColumn = currentColumn - pizzaSlices[currentRow];
                currentRow = currentRow - 1;
            }
            else if ((currentRow - 1 >= 0) && matrix[currentRow - 1, currentColumn] == true)
            {
                currentRow = currentRow - 1;
            }
            else if (currentRow == 0)
            {
                if (matrix[0, currentColumn] == true)
                {
                    sum += pizzaSlices[currentRow];
                    results.Add(currentRow);
                }
                break;
            }
        }

        results.Sort();

        if (generateOutputFile)
        {
            string count = results.Count.ToString();
            string contents = String.Join(" ", results.Select(p => p.ToString()).ToArray());
            File.WriteAllText(outputFileName, count + "\n" + contents);
        }


        Console.WriteLine("Total: " + sum);
    }

}
