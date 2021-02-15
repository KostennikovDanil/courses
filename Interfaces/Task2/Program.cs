using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            ICalculator calculator = new Calculator(logger);
            Console.WriteLine("Enter to numbers");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                calculator.Sum(a, b);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }

    public interface ILogger
    {
        public void Error(string message);
        public void Event(string message);

    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }
    }


    public interface ICalculator
    {
        public void Sum(int a, int b);
    }

    public class Calculator : ICalculator
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }
        void ICalculator.Sum(int a, int b)
        {
            Logger.Event(Convert.ToString(a+b));;
        }
    }
}
