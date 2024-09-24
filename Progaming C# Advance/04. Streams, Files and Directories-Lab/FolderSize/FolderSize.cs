namespace FolderSize
{
    using System;
    using System.IO;
    using System.Reflection.Emit;
    using static System.Net.WebRequestMethods;

    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            long size = GetSizeFolder(folder);

            DirectoryInfo[] subFolders = folder.GetDirectories();

            foreach (DirectoryInfo dir in subFolders)
            {
                size += GetSizeFolder(dir);
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{size / 1024.0} KB");
            }

        }

        private static long GetSizeFolder(DirectoryInfo folder)
        {
            long size = 0;

            FileInfo[] allFiles = folder.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                size += file.Length;
            }

            return size;
        }
    }
}
