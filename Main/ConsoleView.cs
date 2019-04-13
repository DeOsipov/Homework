using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    enum UserAction
    {
        Default,
        Take,
        Water,
        Wait,
        Exit
    }

    enum PlantNumber
    {
        Default,
        First,
        Second,
        Third,
        Exit
    }

    class ConsoleView : AView
    {
        public override void Login(User user)
        {
            user.name = UserInput();
        }

        public override string UserInput()
        {
            return Console.ReadLine();
        }

        public override void ShowMenu()
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

        public override void ShowScore(User user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"U have {user.score} flower.");
            Console.ResetColor();
        }        

        public override void GetUserAction(Plant plant, User user)
        {
            bool isExit = false;
            while (isExit == false)
            {
                switch (UserInput())
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
                        Alert(notCorrectInput);
                        break;
                }
            }
        }

        public override void Water(Plant plant)
        {
            Console.WriteLine($"U watered the plant.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n" +
                $"Your flower is starting to grow\n");
        }        

        public override void TakeFlower(Plant plant)
        {
            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n");
        }

        public override void Wait(Plant plant)
        {
            Console.WriteLine($"Plant will be dried after {plant.lifeBar} moves.\n");
        }

        public override void Ready()
        {
            Console.WriteLine("Your flower is ready");
        }

        public override void NotGrowYet(Plant plant)
        {
            Console.WriteLine($"Your flower will grow after {plant.readyToTake - plant.counterToGrew} moves.");
        }

        public override void Alert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }        

        public override void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public override void Died()
        {
            Console.WriteLine("YOU ARE DIED...");
        }

        public override void Closed()
        {
            Console.WriteLine("You closed the game.");
        }
    }
}