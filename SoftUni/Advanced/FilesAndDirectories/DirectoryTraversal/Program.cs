using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirectoryTraversal
{
    public class Program
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
            Dictionary<string, Dictionary<string, double>> files = new Dictionary<string, Dictionary<string, double>>();

            string[] result = Directory.GetFiles(inputFolderPath);

            for (int i = 0; i < result.Length; i++)
            {
                FileInfo currentFile = new FileInfo(result[i]);

                if (!files.ContainsKey(currentFile.Extension))
                {
                    var dict = new Dictionary<string, double>(){
                        {
                            currentFile.Name,
                            currentFile.Length / 1024
                        }
                    };

                    files.Add(currentFile.Extension, dict);
                }
                else
                {
                    files[currentFile.Extension].Add(currentFile.Name, currentFile.Length);
                }
            }

            StringBuilder sb = GetInfoToString(files);

            return sb.ToString();
        }

        private static StringBuilder GetInfoToString(Dictionary<string, Dictionary<string, double>> files)
        {
            StringBuilder sb = new StringBuilder();

            files.OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ThenBy(f => f.Value.Values);

            foreach (var file in files)
            {
                sb.AppendLine(file.Key);

                foreach (var info in file.Value)
                {
                    sb.AppendLine($"--{info.Key} - {info.Value}kb");
                }
            }

            return sb;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktop = Environment.GetFolderPath(
                         Environment.SpecialFolder.DesktopDirectory);

            using (FileStream fs = new FileStream(desktop + $"{reportFileName}", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(textContent);
                }
            }
        }
    }
}
