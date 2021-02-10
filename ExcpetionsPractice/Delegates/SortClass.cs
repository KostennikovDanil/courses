using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class SortClass
    {
        public event SortDelegate SortEvent;
        public void StartSort(List<string> list)
        {
            Console.WriteLine("Enter 1 to sort (A-Z), enter 2 to sort (Z-A)");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice != 1 && choice != 2)
            {
                throw new Exception();
            }
            SortEvent?.Invoke(list, choice);
        }

    }
}
