namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader textReader = new StreamReader(inputFilePath))
            using (StreamWriter outputText = new StreamWriter(outputFilePath))
            {
                string line= textReader.ReadLine();

                int countLines = 1;
                while(line!=null)
                {
                    int countLetters = 0;
                    int countPunctuation = 0;

                    foreach (char temp in line)
                    { 
                        if(char.IsLetter(temp)) countLetters++;

                        if(char.IsPunctuation(temp)) countPunctuation++;
                    }

                    outputText.Write($"Line {countLines++}: {line} ({countLetters})({countPunctuation}) \n");

                    line = textReader.ReadLine();
                }
            }

        }
    }
}
