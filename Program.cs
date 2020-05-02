using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static void WriteToFile(List<string> list)
    {
        string outputPath = Environment.CurrentDirectory.ToString() + "\\Words.txt";
        File.AppendAllLines(outputPath, list);
    }

    public static void Main()
    {
        int currentFile = 1;
        int wordCounter = 0;
        string inputFile = Environment.CurrentDirectory.ToString() + $"\\Files\\File{currentFile}.txt";

        while (File.Exists(inputFile))
        {
            List<string> list = new List<string>();

            Console.WriteLine($"Starting File{currentFile}.txt");

            using (StreamReader reader = new StreamReader(inputFile))
            {
                while (reader.ReadLine() != null)
                {
                    list.Add(reader.ReadLine());

                    if (list.Count >= 10000000)
                    {
                        Console.WriteLine($"Emergency write out. Word Count: {wordCounter}");
                        WriteToFile(list);

                        list = new List<string>();
                    }

                    wordCounter++;
                }
            }

            Console.WriteLine($"Writing words to file. Password Count: {wordCounter}");
            WriteToFile(list);

            Console.WriteLine($"Finished File{currentFile}.txt");

            currentFile++;
            inputFile = Environment.CurrentDirectory.ToString() + $"\\Files\\File{currentFile}.txt";
        }

        Console.WriteLine("Press any key to continue...");
        _ = Console.ReadKey();
    }
}
