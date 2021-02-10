using System;
using System.Collections.Generic;

namespace ExcpetionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Exception[] ArrOfException = {new MyException(), new ArgumentException(), new DivideByZeroException(), new IndexOutOfRangeException(), new TimeoutException()};
            foreach(var ex in ArrOfException)
            {
                Console.WriteLine(ex);
            }
            try
            {
                Console.WriteLine("Try block");
                //throw new MyException("MyException");
            }
            catch(ArgumentException argEx)
            {
                Console.WriteLine($"ArgumentException with message: {argEx.Message}");
            }
            catch (DivideByZeroException divideEx)
            {
                Console.WriteLine($"DivideByZeroException with message: {divideEx.Message}");
            }
            catch (IndexOutOfRangeException indexEx)
            {
                Console.WriteLine($"IndexOutOfRangeException with message: {indexEx.Message}");
            }
            catch (TimeoutException timeEx)
            {
                Console.WriteLine($"TimeoutException with message: {timeEx.Message}");
            }
            catch (MyException myEx)
            {
                Console.WriteLine(myEx.Message);
            }
        }

    }

}
