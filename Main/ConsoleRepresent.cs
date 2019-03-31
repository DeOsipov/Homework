using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class ConsoleRepresent : IRepresent
    {
        public string UserInput()
        {
            return Console.ReadLine();
        }//ok

        public void ShowMenu()
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
        }//ok

        public void ShowScore(User user)
        {
            Console.WriteLine($"U have {user.score} flower.");
        }//ok

        public void UserAction(Plant plant, User user)
        {
            bool isExit = false;
            while (!isExit)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Water(plant, user);
                        break;
                    case "2":
                        TakeFlower(plant, user);
                        break;
                    case "3":
                        Wait(plant, out isExit);
                        break;
                    case "4":
                        EndGame(plant, user);
                        isExit = true;
                        break;
                    default:
                        AlertNotCorrectInput();
                        break;
                }
            }
        }

        public void Water(Plant plant, User user)
        {
            if (plant.isPour == false)
            {
                plant.isPour = true;
                plant.CounterToGrew++;
                plant.lifeBar = plant.fullHealth;
                Console.WriteLine($"U watered the plant.\n" +
                    $"Plant will be dried after {plant.lifeBar} moves.\n" +
                    $"Your flower is starting to grow\n");
                ShowScore(user);
            }
            else
                Console.WriteLine("U can\'t water more...");
        }

        public void TakeFlower(Plant plant, User user)//ok
        {
            if (plant.grow = true && plant.CounterToGrew >= plant.readyToTake)
            {
                user.score++;
                plant.grow = false;
                plant.CounterToGrew = 0;

                if (plant.isPour == false)
                    plant.lifeBar--;
                Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                    $"Plant will be dried after {plant.lifeBar} moves.\n");
                ShowScore(user);
            }
            else if (plant.isPour == true)
                Console.WriteLine("Your flower is not growning yet...");
            else
                Console.WriteLine("At first - water the plant and then wait some moves...");
        }

        public void Wait(Plant plant, out bool isExit) // change logic
        {
            isExit = false;
            plant.CounterToGrew++;
            if (plant.isPour == false)
            {
                plant.lifeBar--;
                Console.WriteLine($"Plant will be dried after {plant.lifeBar} moves.\n");
            }

            if (plant.CounterToGrew >= plant.readyToTake)
                Console.WriteLine("Ur flower is ready");
            else
                Console.WriteLine($"Your flower will grow after {plant.CounterToGrew} moves.");

            if (plant.lifeBar == 0)
                isExit = true;
        }

        public void AlertNotCorrectInput()
        {
            Console.WriteLine("Input right action");
        }//ok
        
        public void EndGame(Plant plant, User user)
        {
            if (plant.lifeBar == 0)
                Console.WriteLine("YOU ARE DIED...");
            else
                Console.WriteLine("You closed the game.");
            ShowScore(user);
        }//ok
    }
}
