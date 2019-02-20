using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать кальякулятор с множеством функций
            Console.WriteLine("Please input a first number.");
            double result = double.Parse(Console.ReadLine()); //At first iteration first number == result
            Console.WriteLine();

            bool isTrue = true;

            while (isTrue)
            {
                Menu(); //choose an operation
                string userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput == "0") //not in switch because we dont need a "next" input after input "0" as operation
                {
                    Console.WriteLine($"Answer is {result}.");
                    isTrue = false;
                    break;
                }

                Console.WriteLine("Please input a next number."); //Next number
                double next = double.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        result = Add(result, next);
                        input(result);
                        break;

                    case "2":
                        result = Sub(result, next);
                        input(result);
                        break;

                    case "3":
                        result = Mul(result, next);
                        input(result);
                        break;

                    case "4":
                        result = Div(result, next);
                        input(result);
                        break;

                    case "5":
                        result = Pow(result, next);
                        input(result);
                        break;

                    case "6":
                        result = Sqrt(result);
                        input(result);
                        break;

                    default:
                        Console.WriteLine("Input correct operation.");
                        break;
                }
            }

            Console.ReadLine();
        }

        static double Mul(double a, double b)
        {
            return a * b;
        }

        static double Div(double a, double b)
        {
            return a / b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Sub(double a, double b)
        {
            return a - b;
        }

        static double Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }

        static double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }

        static void Menu()
        {
            Console.WriteLine("Please input an operation.\n" +
                    "1.Addition.\n" +
                    "2.Substraction.\n" +
                    "3.Multiply.\n" +
                    "4.Division.\n" +
                    "5.Pow.\n" +
                    "6.Square Root.\n" +
                    "0.Answer.\n");
        }

        static void input(double i)
        {
            Console.WriteLine($"Answer is {i}.\n");
        }
    }
}