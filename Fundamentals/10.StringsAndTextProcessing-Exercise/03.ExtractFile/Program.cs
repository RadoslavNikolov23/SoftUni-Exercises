using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string[] fileName = Path.GetFileNameWithoutExtension(path).Split('\\');
            string fileExtention = Path.GetExtension(path);



            Console.WriteLine($"File name: {fileName[fileName.Length - 1]}");
            Console.WriteLine($"File extension: {fileExtention.TrimStart('.')}");

        }
    }
}
