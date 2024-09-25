using System.IO;

namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo outPutDirectory = new DirectoryInfo(outputPath);

            if(outPutDirectory.Exists) outPutDirectory.Delete();
            outPutDirectory.Create();

            DirectoryInfo inPutDirectory = new DirectoryInfo(inputPath);
            FileInfo[] files = inPutDirectory.GetFiles();
            
            foreach (FileInfo file in files)
            {
                string destinationPath = Path.Combine(outputPath, file.Name);
                file.CopyTo(destinationPath);
            }


        }
    }
}
