namespace OddLines;

using System;
using System.Collections.Specialized;
using System.IO;

public class OddLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\Files\input.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        ExtractOddLines(inputFilePath, outputFilePath);
    }

    public static void ExtractOddLines(string inputFilePath, string outputFilePath)
    {
        using (StreamReader srInput = new StreamReader(inputFilePath))
        {
            string line=srInput.ReadLine();
            using (StreamWriter swOutput = new StreamWriter(outputFilePath))
            {
                int count = 1;
                while(line!=null)
                {
                    if (count % 2 == 0)
                    {
                        swOutput.WriteLine(line);
                    }
                    line = srInput.ReadLine();
                    count++;
                }

            }
        }
    }
}
