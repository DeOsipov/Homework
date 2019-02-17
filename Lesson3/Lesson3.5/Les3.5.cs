using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--------------------------------------------------------------
             * во всех задачах с массивами необходимо проинициализровать его случайными числами
             ---------------------------------------------------------------*/
            //Найти среднефармфитическое значение массива
            //version1
            Console.WriteLine("Input length of array.");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLength];
            string userInput = "";

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine($"Input {i + 1} value of array.");
                //array[i] = int.Parse(Console.ReadLine());
                userInput = Console.ReadLine();
                bool correctInput = Int16.TryParse(userInput, out short value);
                if (correctInput)
                {
                    array[i] = value;
                }
                else if (userInput == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please, input correct number.");
                    i--;
                }
            }

            double sum = 0;
            foreach (int num in array)
            {
                sum += num;
            };

            if (userInput != "exit")
            {
                Console.WriteLine($"Average of array is {sum / arrayLength}.");
            }
            else
            {
                Console.WriteLine("U close the program.");
            }
           
            Console.ReadLine();

            //version2
            Console.WriteLine("Input length of array.");
            int arrLen = int.Parse(Console.ReadLine());
            int[] arr = new int[arrLen];
            for (int i = 0; i < arrLen; i++)
            {
                Random rnd = new Random();
                arr[i] = rnd.Next(100);
            }

            double aver = 0;
            foreach (int val in arr)
            {
                aver += val;
            };

            for (int i = 0; i < arrLen; i++)
            {
                Console.WriteLine($"Array {i} value is {arr[i]}.");
            }
            Console.WriteLine($"Average of array is {aver / arrLen}.");
            Console.ReadLine();
        }
    }
}
