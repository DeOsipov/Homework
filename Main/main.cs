using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Program
    {
        enum Action
        {
            Water,
            Wait,
            Take,
            Exit,
        }

        static void userAction(out Action action)
        {
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                case "water":
                    action = Action.Water;
                    break;

                case "2":
                case "take":
                    action = Action.Take;
                    break;

                case "3":
                case "wait":
                    action = Action.Wait;
                    break;

                case "4":
                case "exit":
                case "close":
                    action = Action.Exit;
                    break;

                default:
                    Console.WriteLine("Input correct action.");
                    break;
            }
        }
        static void Main()
        {
            Console.WriteLine("U r plaing the game \"Flower Lover v 0.4.0\".\n" +
                "U can do 3 things:\n" +
                "1st - water the plant (type \"water\" or \"1\");\n" +
                "2nd - take the flower (type \"take\" or \"2\");\n" +
                "3rd - skip a turn (type \"wait\" or \"1\");\n" +
                "U can exit the game by typing \"exit\" or \"close\" or \"4\"\n" +
                "Your plant give a flower every three turns.\n" +
                "If plant is staing dried more then 5 turns - it dies.\n" +
                "Take as biggest bouquet.\n");
            bool isPour = false;
            bool grow = false;
            int bouquet = 0;
            int flowerGrows = 0;

            int alive = 5;
            int fullHealth = 5;
            int needWater = 2;

            int readyToTake = 3;

            Action action = Action.Wait;
            while (action != Action.Exit)
            {
                userAction(out action);
                
                if (alive == needWater)
                    isPour = false;

                switch (action)
                {
                    case Action.Water:
                        if (isPour == false)
                        {
                            isPour = true;
                            flowerGrows++;
                            alive = fullHealth;
                            Console.WriteLine($"U watered the plant.\n" +
                                $"Plant will be dried after {alive} moves.\n" +
                                $"Your flower is starting to grow\n" +
                                $"U have {bouquet} flower");
                        }
                        else
                        {
                            Console.WriteLine("U can\'t water more...");
                        }
                        break;
                        
                    case Action.Take:
                        if (grow = true && flowerGrows >= readyToTake)
                        {
                            bouquet++;
                            grow = false;
                            flowerGrows = 0;
                            if (isPour == false)
                                alive--;
                            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                                $"Plant will be dried after {alive} moves.\n" +
                                $"U have {bouquet} flower");
                        }
                        else if (isPour == true)
                        {
                            Console.WriteLine("Your flower is not growning yet...");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("At first - water the plant and then wait some moves...");
                        };
                        break;
                        
                    case Action.Wait:
                        flowerGrows++;
                        if (isPour == false)
                            alive--;
                        Console.WriteLine($"Plant will be dried after {alive} moves.\n");
                        if (flowerGrows >= readyToTake)
                        {
                            Console.WriteLine("U flower is ready");
                        }
                        else
                        {
                            Console.WriteLine($"Your flower will grow after {flowerGrows} moves.");
                        }
                        break;

                    case Action.Exit:
                            break;

                    default:
                        Console.WriteLine("Input right action");
                        break;
                }
            }

            //----------game over
            if (alive == 0)
                Console.WriteLine("YOU ARE DIED...");

            if (action == Action.Exit)
                Console.WriteLine("You closed the game.");

            string s = ".";
            string only = "only ";
            
            if (bouquet != 1)
            {
                s = "s.";
                only = "";
            }
            
            Console.WriteLine($"U have taken {only}{bouquet} flower{s}");
            Console.ReadLine();
        }
    }
}