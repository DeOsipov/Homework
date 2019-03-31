using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //4. вывести числа
            /*foreach (char x in userInput)
                Console.Write($"{x}, ");*/
            Console.WriteLine("Input a number");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);
            int temp;
            for (int i = 0; i < userInput.Length; i++)
            {
                int position = (int)Math.Pow(10, i);
                number % position = temp;
                Console.WriteLine($"{temp}, ");
            }
        }
    }
}
