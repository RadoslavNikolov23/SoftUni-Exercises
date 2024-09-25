namespace CopyBinaryFile
{
    using System;
    using System.Buffers;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {

            using (FileStream filePNG = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream outputPNG = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);


                while (true)
                {
                    int readBytes = filePNG.Read(buffer);

                    if (readBytes == 0) break;

                    outputPNG.Write(buffer, 0, readBytes);
                }

                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
