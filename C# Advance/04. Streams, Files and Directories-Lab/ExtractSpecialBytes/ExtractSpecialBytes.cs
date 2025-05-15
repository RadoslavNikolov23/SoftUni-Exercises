namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream filePNG = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream fileText = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream fileOutput = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[256];

                while (true)
                {
                    int bytesReadPNG = filePNG.Read(buffer);
                    int bytesReadText = fileText.Read(buffer);

                    if (bytesReadPNG == 0 && bytesReadText == 0) break;

                    filePNG.Read(buffer, 0, bytesReadPNG);
                    fileText.Read(buffer, 0, bytesReadText);

                    fileOutput.Write(buffer, 0, bytesReadPNG);
                    fileOutput.Write(buffer, 0, bytesReadText);

                }


            }



        }
    }
}
