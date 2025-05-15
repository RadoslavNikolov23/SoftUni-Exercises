namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Text;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstTextReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondTextReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                    {
                        string firstText = firstTextReader.ReadLine();
                        string secondText = secondTextReader.ReadLine();
                        StringBuilder sbFinalText = new StringBuilder();

                        while (true)
                        {
                            if (firstText != null)
                                sbFinalText.AppendLine(firstText);

                            if (secondText != null)
                                sbFinalText.AppendLine(secondText);

                            if (firstText == null && secondText == null)
                                break;

                            firstText = firstTextReader.ReadLine();
                            secondText = secondTextReader.ReadLine();

                        }

                        outputWriter.WriteLine(sbFinalText.ToString());
                    }

                }
            }
        }
    }
}
