using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать алгоритм поиска Nго простого числа(к примеру 2, 3, 5, 7
            где 2 это 1ое число 3 - второе и т.д., т.е.если N = 4 то на выходе должно быть 7)*/

            Console.WriteLine("Please, input a position of prime number.");
            int position = int.Parse(Console.ReadLine());

            int[] array = new int[position];

            for (int i = 0; i < position; i++)
            {
                /*for (int j = 2; j * j <= position; j++)
                {
                    if (isPrime(j))
                        array[i] = j;
                    Console.WriteLine($"{j}");
                }*/
                array[i] = 2;
                Console.WriteLine($"{i}");
            }

            Console.WriteLine($"Number is {array[position - 1]}.");
            Console.ReadLine();
        }

        //checking is number prime
        static bool isPrime(int n)
        {
            if (n == 1)
                return false;
            for (int i = 2; i*i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
