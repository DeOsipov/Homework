using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class ConsoleView : IView
    {
        public void Login(User user)
        {
            user.name = UserInput();
        }

        public string UserInput()
        {
            return Console.ReadLine();
        }

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
        }

        public void ShowScore(User user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"U have {user.score} flower.");
            Console.ResetColor();
        }

        enum UserAction
        {
            Default,
            Take,
            Water,
            Wait,
            Exit
        }

        public void GetUserAction(Plant plant, User user)
        {
            bool isExit = false;
            while (isExit == false)
            {
                switch (view.UserInput())
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
                        view.AlertNotCorrectInput();
                        break;
                }
            }
        }

        public void Water(Plant plant)
        {
            Console.WriteLine($"U watered the plant.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n" +
                $"Your flower is starting to grow\n");
        }

        string wateredNo = "U can\'t water more...";
        string notGrowing = "Your flower is not growning yet...";
        string notWatered = "At first - water the plant and then wait some moves...";
        string notCorrectInput = "Input right action";

        public void Alert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        string wateredYes = "Plant have been watered.";

        public void Confirm(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void TakeFlower(Plant plant)
        {
            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n");
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

        public void Died()
        {
            Console.WriteLine("YOU ARE DIED...");
        }

        public void Closed()
        {
            Console.WriteLine("You closed the game.");
        }
    }
}