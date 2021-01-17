using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void ClearFolder(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                Console.WriteLine(directoryInfo.FullName);
                FileInfo[] files = directoryInfo.GetFiles();
                DirectoryInfo[] directories = directoryInfo.GetDirectories();


                foreach (var fi in files)
                {
                    Console.WriteLine(fi.Name);
                    if (TimeSpan.FromMinutes(30) < DateTime.Now.Subtract(fi.LastWriteTime))
                    {
                        Console.WriteLine($"{fi.Name} deleted");
                        try
                        {
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
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to folder you want to clear");
            string path = Console.ReadLine();
            ClearFolder(path);
        }
    }
}
