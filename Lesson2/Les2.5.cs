using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //5. перевернуть число
            Console.WriteLine("Input a number");
            string userInput = Console.ReadLine();
            char[] Arr = new char[userInput.Length];

            for (int i = 0; i < userInput.Length; i++)
                Arr[userInput.Length - 1 - i] = userInput[i];

            Arr.ToList().ForEach(Console.Write);
        }
    }
}