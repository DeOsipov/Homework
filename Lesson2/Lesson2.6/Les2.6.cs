using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Length of array + create an array
            Console.WriteLine("Input a length of an array.");
            int n = Int32.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string userInput = "";

            //Push values into array
            Console.WriteLine("Input an integer number into array. \nType an \"exit\" to close the application.");
            for (int counter = 0; counter < n;)
            {
                userInput = Console.ReadLine();
                bool rightInput = int.TryParse(userInput, out int value);

                if (userInput == "exit" || userInput == "close")
                {
                    Console.WriteLine("U close the application.");
                    break;
                }
                else if (rightInput || userInput != "exit")
                {
                    arr[counter] = value;
                    counter++;
                }
                else
                {
                    Console.WriteLine("Input an integer.");
                }
            }

            if (userInput != "exit" && userInput != "close")
            {
                Console.WriteLine("Sorting array...");

                //sorting
                int temp, i, j;
                i = 1;
                j = 2;

                while (i < arr.Length)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        i--;
                        if (i <= 0)
                        {
                            i = j;
                            j++;
                        }
                    }
                }

                arr.ToList().ForEach(Console.WriteLine);
                Console.ReadLine();
            }
        }
    }
}