using System;
using System.IO;

/// <summary>
/// @author: jaracoder
/// </summary>
/// 
namespace GoogleCodeJam16
{
    public class CountingSheep
    {
        static int totalCases;

        static string inputFile = "A-small-practice.in";
        static string[] inputLines = null;

        static string outputFile = "solved.in";
        static string[] outputLines = null;

        static int[] viewedNumbers = new int[10];

        static void Main()
        {
            int casesCount = 0;
            int count = 1;
            int number;

            try
            {
                inputLines = GetLinesFromFile();
                totalCases = Int32.Parse(inputLines[0]);
                outputLines = new string[totalCases];


                for (int i = 1; i < inputLines.Length; i++)
                {
                    if (Int32.Parse(inputLines[i]) > 0)
                    {
                        do
                        {
                            number = Int32.Parse(inputLines[i]) * count;
                            count++;

                            // Reads digits of the number and stores them
                            int digit;
                            for (int c = 0; c < number.ToString().Length; c++)
                            {
                                digit = (int)number.ToString()[c];
                                viewedNumbers[digit] = digit;
                            }

                        } while (!HasAllDigits());

                        outputLines[casesCount] = "Case #" + (casesCount + 1) + ": " + count;
                    }
                    else
                    {
                        outputLines[casesCount] = "Case #" + (casesCount + 1) + ": INSOMNIA";
                    }

                    casesCount++;
                    count = 1;
                }

                SaveLinesOnFile(outputLines);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Check if all the numbers are in the array.
        /// </summary>
        static bool HasAllDigits()
        {
            for (int i = 0; i < viewedNumbers.Length; i++)
            {
                if (viewedNumbers[i] == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets all lines of a text file.
        /// </summary>
        static string[] GetLinesFromFile()
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(inputFile);
            }
            catch
            {
                lines = null;
            }

            return lines;
        }


        /// <summary>
        /// Gets all lines of a text file.
        /// </summary>
        static void SaveLinesOnFile(string[] lines)
        {
            try
            {
                File.WriteAllLines(outputFile, lines);
            }
            catch { }
        }
    }
}