using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать методы расчёта площади: прямоугольнику, круга, треугольника ну и любой другой фигуры
            Console.WriteLine("Please input length of rectangles.");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("Please input length of rectangles.");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine($"Area of rectangle is {areaRectangle(length, width)}.");

            //circle
            Console.WriteLine("Please input radius of circle");
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"Area of circle is {areaCircle(radius)}.");
            Console.ReadLine();
        }
        //Circle
        static double areaCircle(double r)
        {
            return Math.PI * r * r;
        }
        //Rectangle
        static double areaRectangle(double l, double w)
        {
            return l * w;
        }
    }
}
