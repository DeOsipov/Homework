using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a number");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);
            int temp, sum = 0;

            for (int i = 1; i < userInput.Length; i++)
            {
                int position = Convert.ToInt32(Math.Pow(10, i));
                temp = number % position;
                if (temp % 2 == 0)
                {
                    sum += temp;
                }

            }

            Console.WriteLine($"Result of summary even number: {sum}.");
            Console.ReadLine();
        }
    }
}