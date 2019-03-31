using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. умножение через сложение
            Console.WriteLine("Input a first number.");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input a second number.");
            int y = Int32.Parse(Console.ReadLine());
            int sum = 0;
            
            for (int i = 0; i < Math.Abs(y); i++)
                sum += x;

            if (x < 0 && y > 0 || x > 0 && y < 0)
                sum *= -1;

            Console.WriteLine($"Result: {sum}.");
            Console.ReadLine();
        }
    }
}