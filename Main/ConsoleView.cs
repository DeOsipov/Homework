using System;

namespace Main
{
    class ConsoleView : IView
    {
        public string UserInput()
        {
            return Console.ReadLine();
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
                case "save":
                    return UserAction.Save;
                case "6":
                case "load":
                    return UserAction.Load;
                case "7":
                case "del":
                    return UserAction.Delete;
                case "8":
                case "exit":
                    return UserAction.Exit;
                default:
                    return UserAction.Default;
            }
        }

        ViewText viewText = new ViewText();
        public void ShowStatus(Plant plant)
        {
            if (plant.isDead)
            {
                Alert(viewText.LifeStatus(plant));
                return;
            }
            Success(viewText.LifeStatus(plant));

            if (plant.isPour)
                Success(viewText.WaterStatus(plant));
            else
                Alert(viewText.WaterStatus(plant));

            Attention(viewText.WillDry(plant));
            Info(viewText.Ready(plant));
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

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Attention(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}