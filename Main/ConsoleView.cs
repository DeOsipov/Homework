using System;

namespace Main
{
    class ConsoleView : IView
    {
        public void Login()
        {
            Console.WriteLine("Input your name.");
        }

        public string UserInput()
        {
            return Console.ReadLine();
        }
        
        Plant plant = new Plant();
        public void ShowStartMenu(User user)
        {
            Console.WriteLine(
                $"{user.name}, you are playing the game \"Flower Lover v 1.0.0\".\n" +                
                $"Your plant give a flower every {plant.readyToTake} turns.\n" +
                $"If plant is staing dried more then {plant.lifeBar} turns - it dies.\n" +
                "Take a biggest bouquet as you can.\n" +
                "U can do:");
        }

        public void ShowMenu()
        {
            Console.WriteLine(
                $"Take the flower type {(int)UserAction.Take} or \"take\"\n" +
                $"Water the plant type {(int)UserAction.Water} or \"water\"\n" +
                $"Skip a turn type {(int)UserAction.Wait} or \"wait\"\n" +
                $"Show plant status info type {(int)UserAction.ShowStatus} or \"show\"\n" +
                $"U can exit the game by typing {(int)UserAction.Exit} or \"exit\"\n");
        }

        public UserAction GetUserAction()
        {
            switch (UserInput().ToLower())
            {
                case "1":
                case "take":
                    return UserAction.Take;
                case "2":
                case "water":
                    return UserAction.Water;
                case "3":
                case "wait":
                    return UserAction.Wait;
                case "4":
                case "show":
                    return UserAction.ShowStatus;
                case "5":
                case "exit":
                    return UserAction.Exit;
                default:
                    return UserAction.Default;
            }
        }

        public void ChoosePlant()
        {
            Console.WriteLine("Choose a plant");
        }

        public void ShowStatus(Plant plant)
        {
            string lifeStatus = string.Format("Plant {0} is {1}", plant.number, plant.isDead ? "dead" : "alive");
            if (plant.isDead)
            {
                Alert(lifeStatus);
                return;
            }
            Success(lifeStatus);

            string prefix = plant.isPour ? "" : "not ";
            string waterStatus = ($"Plant {plant.number} is {prefix}watered.");
            if (plant.isPour) //create a delegate
                Success(waterStatus);
            else                
                Alert(waterStatus);
            Console.WriteLine($"After {plant.lifeBar} moves plant {plant.number} will died.\n" +
                $"After {plant.readyToTake - plant.counterToGrew} moves plant will be ready.\n");
        }

        public void TakeFlower(Plant plant)
        {
            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n");
        }

        public void Wait(Plant plant)
        {
            Console.WriteLine($"Plant {plant.number} will be dried after {plant.lifeBar} moves.\n");
        }

        public void Ready(Plant plant)
        {
            Console.WriteLine($"Plant {plant.number} is ready to take.");
        }

        public void NotGrowYet(Plant plant)
        {
            Console.WriteLine($"Your plant {plant.number} will grow after {plant.readyToTake - plant.counterToGrew} moves.");
        }

        public void WillDried(Plant plant)
        {
            Console.WriteLine($"Plant will be dried after {plant.lifeBar} moves.\n");
        }

        public void ShowScore(User user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{user.name} have {user.score} flower.");
            Console.ResetColor();
        }

        public void Alert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Closed()
        {
            Console.WriteLine("You closed the game.");
        }
    }
}