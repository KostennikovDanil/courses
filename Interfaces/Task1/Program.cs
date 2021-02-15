using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            Console.WriteLine("Enter to numbers");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sum is {0}",calculator.Sum(a, b));
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
            }
        }

        public interface ICalculator
        {
            public int Sum(int a, int b);
        }

        public class Calculator : ICalculator
        {
            int ICalculator.Sum(int a, int b)
            {
                return a + b;
            }
        }
    }
}
