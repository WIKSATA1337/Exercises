using System.IO.Compression;
using System.IO;

namespace ZipAndExtract
{
    public class Program
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (FileStream file = new FileStream(zipArchiveFilePath, FileMode.Create))
            {
            }

            using (FileStream fs = new FileStream(zipArchiveFilePath, FileMode.Open))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Update))
                {
                    zip.CreateEntryFromFile(inputFilePath, "extracted.png");
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (FileStream fs = new FileStream(zipArchiveFilePath, FileMode.Open))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    zip.ExtractToDirectory(@"..\..\..\");
                }
            }
        }
    }
}
