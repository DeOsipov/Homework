using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._1
{
    class Program
    {
        static void Main(string[] args)
        {//написать расчёт чисел фибоначи с помощью рекурсии

            Console.WriteLine("Input a position of number in Fibonacci number.");
            int userInput = int.Parse(Console.ReadLine());

            int sum = 0;
            int num = fibonacci(userInput);

            for (int i = 1; i <= userInput; ++i)
            {
                sum += fibonacci(i);
            };

            Console.WriteLine($"Result is {num}.");
            Console.WriteLine($"Summary is {sum}.");
            Console.ReadLine();
        }
        
        static int fibonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return fibonacci(n - 2) + fibonacci(n - 1);
        }
    }
}