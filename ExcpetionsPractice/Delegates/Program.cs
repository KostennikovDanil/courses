using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Muler");
            list.Add("Nielsen");
            list.Add("Larsen");
            list.Add("Andreev");
            list.Add("Vitale");
            foreach (var i in list)
                Console.WriteLine(i);
            SortClass sortClass = new SortClass();
            sortClass.SortEvent += Sort;
            try
            {
                sortClass.StartSort(list);
                foreach (var i in list)
                    Console.WriteLine(i);
            }
            catch (Exception)
            {
                Console.WriteLine("Enter wrong value");

            }

            
        }
        static void Sort(List<string> list, int choice)
        {
            if (choice == 1)
                list.Sort();
            else if (choice == 2)
                list.Sort((str1, str2) => { return string.Compare(str2, str1); });
            else
                throw new Exception("choice exception");
        }
    }
    public delegate void SortDelegate(List<string> list, int choice);
    
}
