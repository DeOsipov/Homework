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
            //3. Игра угадайка
            /*create an answer*/
            int from = -10;
            int to = 10;
            Random rnd = new Random();
            int answer = rnd.Next(from, to);
            Console.WriteLine($"Win the game. Type a integer in a period between {from} and {to}. \n ");
            //check an answer
            Console.WriteLine(answer);

            /*checking right input*/
            bool rightInput = false;
            string userInput = "";
            int inputNumber = from - 1;
            
            while (inputNumber != answer) {
                if (userInput == "exit")
                {
                    Console.WriteLine("U close the application");
                    break;
                }
                userInput = Console.ReadLine();
                rightInput = int.TryParse(userInput, out inputNumber);
                Console.WriteLine("U r near...");
            }
            //win the game
            if (inputNumber == answer)
                Console.WriteLine("Congratulation. You won.");
        }
    }
}