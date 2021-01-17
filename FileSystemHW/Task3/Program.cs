using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void ClearFolder(string path)
        {
            if (Directory.Exists(path))
            {

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] files = directoryInfo.GetFiles();
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                double size = 0;

                foreach (var fi in files)
                {
                    if (TimeSpan.FromMinutes(30) < DateTime.Now.Subtract(fi.LastWriteTime))
                    {
                        try
                        {
                            size += fi.Length;
                            fi.Delete();
                        }
                        catch
                        {
                            Console.WriteLine("Exception");
                        }
                    }
                }

                foreach (var dir in directories)
                {

                    Console.WriteLine(dir.Name);
                    ClearFolder(dir.FullName);
                    if (TimeSpan.FromMinutes(30) < DateTime.Now.Subtract(dir.LastWriteTime))
                    {
                        try
                        {
                            dir.Delete();
                        }
                        catch
                        {
                            Console.WriteLine("Exception");
                        }
                    }

                }

            }
            else
                Console.WriteLine("Folder was not found");

        }

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

        static void ClearFolderWithSize(string path)
        {
            if (Directory.Exists(path))
            {
                var originalSize = SizeOfFolder(path);
                Console.WriteLine($"Original folder size: {originalSize}");
                ClearFolder(path);
                var currentSize = SizeOfFolder(path);
                Console.WriteLine($"Freed: {originalSize - currentSize}");
                Console.WriteLine($"Original folder size: {currentSize}");
            }

            else
                Console.WriteLine("Folder was not found");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to folder you want to clear");
            string path = Console.ReadLine();
            ClearFolderWithSize(path);


        }
    }
}
