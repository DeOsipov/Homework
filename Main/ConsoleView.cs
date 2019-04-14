using System;

namespace Main
{
    class ConsoleView : IView
    {
        Plant plant = new Plant();

        public void Login(User user)
        {
            Console.WriteLine("Input your name.");
            user.name = UserInput();
        }

        public string UserInput()
        {
            return Console.ReadLine();
        }

        public void ShowStartMenu(User user)
        {
            Console.WriteLine(
                $"{user.name}, you are playing the game \"Flower Lover v 1.0.0\".\n" +                
                $"Your plant give a flower every {plant.readyToTake} turns.\n" +
                $"If plant is staing dried more then {plant.lifeBar} turns - it dies.\n" +
                "Take a biggest bouquet as you can.\n" +
                "U can do 3 things:\n");
        }

        public void ShowMenu()
        {
            Console.WriteLine(
                $"Take the flower type {(int)UserAction.Take} or \"take\"\n" +
                $"Water the plant type {(int)UserAction.Water} or \"water\"\n" +
                $"Skip a turn type {(int)UserAction.Wait} or \"wait\"\n" +
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

        public void Water(Plant plant)
        {
            Console.WriteLine($"U watered the plant.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n" +
                $"Your flower is starting to grow\n");
        }        

        public void TakeFlower(Plant plant)
        {
            Console.WriteLine($"U take the flower and increase a bouquet.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n");
        }

        public void Wait(Plant plant)
        {
            Console.WriteLine($"Plant will be dried after {plant.lifeBar} moves.\n");
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