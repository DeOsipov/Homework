using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--------------------------------------------------------------
             * во всех задачах с массивами необходимо проинициализровать его случайными числами
             ---------------------------------------------------------------
            Дан двуменый массив заполненный случайными числами, необходимо высчитать значение суммы по столбцам и по строчкам*/
            Console.WriteLine("Input raw length of array.");
            int arrLenRaw = int.Parse(Console.ReadLine());
            Console.WriteLine("Input column length of array.");
            int arrLenCol = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            int[,] arr = new int[arrLenRaw, arrLenCol];
            for (int i = 0; i < arrLenRaw; i++)
            {
                for (int j = 0; j < arrLenCol; j++)
                {
                    arr[i, j] = rnd.Next(1, 101);
                }
            }

            for (int j = 0; j < arrLenCol; j++)
            {
                int sum = 0;
                for (int i = 0; i < arrLenRaw; i++)
                {
                    sum += arr[i, j];
                }

                Console.WriteLine($"Array {j + 1}-raw sum is {sum}.");
            }

            for (int i = 0; i < arrLenRaw; i++)
            {
                int sum = 0;
                for (int j = 0; j < arrLenCol; j++)
                {
                    sum += arr[i, j];
                }

                Console.WriteLine($"Array {i + 1}-column sum is {sum}.");
            }
            //Можно и в метод записать циклы - тогда надо подумать как выводить информацию
            //отдельно прописывать "вывод" - создавать массив с результатами
            //и выводить элементы массива
            //уточнить на уроке
            Console.ReadLine();
        }

        /*void Summary(int i, int j, int firVal, int secVal, int [,] arr)
        {
            for (j = 0; j < firVal; j++)
            {
                int sum = 0;
                for (i = 0; i < secVal; i++)
                {
                    sum += arr[i, j];
                }
                Console.WriteLine($"Array {j}-column sum is {sum}.");
            }            
        }*/
    }
}