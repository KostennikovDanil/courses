using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            List<string> list = new List<string>();


            string path = Console.ReadLine();

            var stopWatch = Stopwatch.StartNew();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string str = "";
                    while ((str = reader.ReadLine()) != null) 
                    {
                        linkedList.AddLast(str);
                    }

                    Console.WriteLine($"Time of adding to linkedList {linkedList.Count} elements = {stopWatch.Elapsed.TotalMilliseconds} ms");

                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                    stopWatch.Restart();

                    while ((str = reader.ReadLine()) != null)
                    {
                        list.Add(str);
                    }

                    Console.WriteLine($"Time of adding to list {list.Count} elements = {stopWatch.Elapsed.TotalMilliseconds} ms");
                }


            }
            
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    }
}
