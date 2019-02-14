using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("U r plaing the game \"Flower Lover v 0.1.0\".\n" +
                "U can do 3 things:\n" +
                "1st - water the plant (type \"water\");\n" +
                "2nd - take the flower (type \"take\");\n" +
                "3rd - skip a turn (type \"wait\");\n" +
                "U can exit the game by typing \"exit\" or \"close\"\n" +
                "Your plant give a flower every three turns.\n" +
                "If plant is staing dried more then 5 turns - it dies.\n" +
                "Take as biggest bouquet.\n");
            bool pour = false;
            bool grow = false;
            int bouquet = 0;
            int flowerGrows = 0;
            int alive = 5;
            string userInput = "";
            string s = ".";
            string only = "only ";

            //-----base loop
            while (userInput != "exit" && userInput != "close" && alive != 0)
            {
                //-----player turn
                userInput = Console.ReadLine();
                //evaporate the plant every 3rd turn
                if (alive == 2)
                {
                    pour = false;
                }

                switch (userInput)
                {
                    //-----water the plant
                    case "water":
                        if (pour == false)
                        {
                            pour = true;
                            flowerGrows++;
                            alive = 5;
                            Console.WriteLine($"U watered the plant.\n" +
                                $"Plant will be dried after {alive} moves.\n" +
                                $"Your flower is starting to grow\n" +
                                $"U have {bouquet} flower");
                        }
                        else
                        {
                            Console.WriteLine("U can\'t water more...");
                            continue;
                        }
                        break;

                    //-----take the flower
                    case "take":
                        if (grow = true && flowerGrows >= 3)
                        {
                            bouquet++;
                            grow = false;
                            flowerGrows = 0;
                            if (pour == false)
                                alive--;
                            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                                $"Plant will be dried after {alive} moves.\n" +
                                $"U have {bouquet} flower");
                        }
                        else if (pour == true)
                        {
                            Console.WriteLine("Your flower is not growning yet...");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("At first - water the plant and then wait some moves...");
                        };
                        break;

                    //-----skip the turn
                    case "wait":
                        flowerGrows++;
                        if (pour == false)
                            alive--;
                        Console.WriteLine($"Plant will be dried after {alive} moves.\n");
                        if (flowerGrows >= 3)
                        {
                            Console.WriteLine("U flower is ready");
                        }
                        else
                        {
                            Console.WriteLine($"Your flower will grow after {flowerGrows} moves.");
                        }
                        break;

                    //-----else
                    default:
                        Console.WriteLine("Input right action");
                        break;
                }
            }

            //-----dried = died
            if (alive == 0)
            {
                Console.WriteLine("YOU ARE DIED");
            }

            //-----one or more flowers
            if (bouquet != 1)
            {
                s = "s.";
                only = "";
            }

            //-----end the game - view the score
            Console.WriteLine($"U have taken {only}{bouquet} flower{s}");
            Console.ReadLine();
        }
    }
}