using System;
using System.IO;

namespace CopyDirectory
{
    public class Program
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            DirectoryInfo dinfo = new DirectoryInfo(inputPath);
            outputPath = outputPath + $@"\{dinfo.Name}";

            Directory.CreateDirectory(outputPath);

            string[] fileNames = Directory.GetFiles(inputPath);
            for (int i = 0; i < fileNames.Length; i++)
            {
                File.Copy(inputPath + $@"\{fileNames[i]}", outputPath);
            }
        }
    }
}
