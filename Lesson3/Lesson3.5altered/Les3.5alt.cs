using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._5altered
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--------------------------------------------------------------
             * во всех задачах с массивами необходимо проинициализровать его случайными числами
             ---------------------------------------------------------------*/
            //Найти среднефармфитическое значение массива
            //version2
            Console.WriteLine("Input length of array.");
            int arrLen = int.Parse(Console.ReadLine());
            int[] arr = new int[arrLen];
            Random rnd = new Random();

            for (int i = 0; i < arrLen; i++)
            {                
                arr[i] = rnd.Next(100);
            }

            double aver = 0;
            foreach (int val in arr)
            {
                aver += val;
            };

            for (int i = 0; i < arrLen; i++)
            {
                Console.WriteLine($"Array {i + 1} value is {arr[i]}.");
            }

            Console.WriteLine($"Average of array is {aver / arrLen}.");
            Console.ReadLine();
        }
    }
}
