namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            { 
                string[] wordsArray = wordReader.ReadToEnd().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                Dictionary<string,int>wordCounter= new Dictionary<string,int>();

                for (int i = 0; i < wordsArray.Length; i++)
                {
                    if (!wordCounter.ContainsKey(wordsArray[i]))
                        wordCounter.Add(wordsArray[i].ToLower(), 0);
                   
                }

                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    string lineText=textReader.ReadLine();
                    while (lineText != null)
                    {
                        string[] arrayText=lineText.Split(new char[] { ' ', '.', ',', '!', '?', '\n', '\t', '\r', '(', ')', '@', '_', '-' },StringSplitOptions.RemoveEmptyEntries);

                        foreach(string word in arrayText)
                        {
                            if (wordCounter.ContainsKey(word.ToLower()))
                                wordCounter[word.ToLower()]++;
                        }


                        lineText = textReader.ReadLine();
                    }
                }

                using (StreamWriter outWriter = new StreamWriter(outputFilePath))
                {
                    foreach(var (word,couter) in wordCounter.OrderByDescending(x=>x.Value))
                    {
                        string textOutput = $"{word} - {couter}";
                        outWriter.WriteLine(textOutput);
                    }
                }
            }

        }
    }
}
