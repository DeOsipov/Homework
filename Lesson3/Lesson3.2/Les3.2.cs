using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._2
{
    class Program
    {

        static bool NotCheck(int i)
        {
            if (i > 5)
                return i % 2 == 0 || i % 10 == 5;
            return false;
        }
        static void Main(string[] args)
        {
            /*Написать алгоритм поиска Nго простого числа(к примеру 2, 3, 5, 7
            где 2 это 1ое число 3 - второе и т.д., т.е.если N = 4 то на выходе должно быть 7)*/
            Console.WriteLine("Please, input a position of prime number.");
            int position = int.Parse(Console.ReadLine());
            int end = 0;
            int prime = 0;

            for (prime = 2; end != position; prime++)
            {
                if (NotCheck(prime))
                    continue;

                int div = 0;
                for (int j = 1; j <= prime; j++)
                {
                    if (prime % j == 0)
                    {
                        div++;
                        if (div > 2)
                            break;
                    }
                }

                if (div == 2)
                    end++;                
            }

            Console.WriteLine($"{position} prime number is {prime - 1}.");            
            Console.ReadLine();
        }
    }
}