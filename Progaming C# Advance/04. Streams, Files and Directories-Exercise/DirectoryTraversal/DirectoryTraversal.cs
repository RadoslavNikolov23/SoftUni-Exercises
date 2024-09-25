using System.Linq;

namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(inputFolderPath);
            FileInfo[] allFiles= directory.GetFiles();

            Dictionary<string, List<FileInfo>> filesExtensions = new Dictionary<string, List<FileInfo>>();

            foreach(var file in allFiles)
            {
                if(!filesExtensions.ContainsKey(file.Extension))
                    filesExtensions.Add(file.Extension, new List<FileInfo>());

                filesExtensions[file.Extension].Add(file);
            }

            StringBuilder sbResult= new StringBuilder();

            foreach (var (extension, files) in filesExtensions.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sbResult.AppendLine($"{extension}");

                foreach (FileInfo file in files.OrderByDescending(x => x.Length))
                {
                    decimal size = (decimal)file.Length / 1024;
                    sbResult.AppendLine($"--{file.Name} - {size}kb");
                }
            }

            return sbResult.ToString();

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, reportFileName);

            File.WriteAllText(outputFilePath, textContent);
        }
    }
}
