using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static double SizeOfFolder(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                double size = 0;
                foreach (var fi in fileInfos)
                {
                    try
                    {
                        size += fi.Length;
                    }
                    catch
                    {
                        Console.WriteLine("Exception");
                    }

                }

                foreach (var dir in directories)
                    SizeOfFolder(dir.FullName);

                return size;
            }
            else
            {
                Console.WriteLine("Folder was not found");
                return 0;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to folder");
            string path = Console.ReadLine();
            var size = SizeOfFolder(path);
            Console.WriteLine(size);
        }
    }
}
