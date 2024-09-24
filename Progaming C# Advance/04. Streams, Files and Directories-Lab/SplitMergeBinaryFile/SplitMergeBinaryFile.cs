namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream filePNG = new FileStream(sourceFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (FileStream firstPart = new FileStream(partOneFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (FileStream secondPart = new FileStream(partTwoFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[254];

                bool isOdd = true;
                while (true)
                {
                    int readBytes = filePNG.Read(buffer);

                    if (readBytes == 0) break;

                    if (isOdd)
                    {
                        firstPart.Write(buffer, 0, readBytes);
                    }
                    else
                    {
                        secondPart.Write(buffer, 0, readBytes);
                    }

                    isOdd = !isOdd;
                }

            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream firstFile = new FileStream(partOneFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (FileStream secondFile = new FileStream(partTwoFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (FileStream finalFile = new FileStream(joinedFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] bufferOne = new byte[254];
                byte[] bufferTwo = new byte[254];

                bool isOdd = true;
                while (true)
                {
                    int readBytesOne = firstFile.Read(bufferOne);
                    int readBytesTwo = secondFile.Read(bufferTwo);

                    if (readBytesOne == 0 && readBytesTwo == 0) break;

                    finalFile.Write(bufferOne, 0, readBytesOne);

                    finalFile.Write(bufferTwo, 0, readBytesTwo);

                }
            }

        }
    }
}