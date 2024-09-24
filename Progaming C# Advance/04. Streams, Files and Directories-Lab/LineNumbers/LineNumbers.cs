namespace LineNumbers
{
    using System.IO;
    using System.Threading;

    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader inputReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                {
                    string line=inputReader.ReadLine();
                    int count = 1;
                    while(line!=null)
                    {

                        string newLine = $"{count++}. {line}";
                        outputWriter.WriteLine(newLine);

                        line = inputReader.ReadLine();
                    }
                }
            }
        }
    }
}
