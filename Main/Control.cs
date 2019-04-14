namespace Main
{
    class Control
    {
        static IView view = new ConsoleView();
        static ConsoleViewText viewText = new ConsoleViewText();

        static void Main()
        {
            User user = new User();
            view.Login(user);

            Plant[] plants = Plants();
            bool isExit = false;            

            while (!EverybodyDies(plants) && isExit != true)
            {
                view.ShowStartMenu(user);
                ChooseUserAction(plants, user, out isExit);
            }
            EndGame(plants, user);
        }
        
        private static int numberOfPlants = 3;
        static Plant[] Plants()
        {
            Plant[] plants = new Plant[numberOfPlants];
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i] = new Plant{ number = i+1 };
            }
            return plants;
        }

        static void ChooseUserAction(Plant[] plants, User user, out bool isExit)
        {
            isExit = false;
            UserAction action = UserAction.Default;

            while (isExit != true)
            {
                view.ShowMenu();
                switch (view.GetUserAction())
                {
                    case UserAction.Water:
                        Water(ChoosePlant(plants));
                        break;
                    case UserAction.Take:
                        TakeFlower(ChoosePlant(plants), user);
                        break;
                    case UserAction.Wait:
                        isExit = Wait(plants);
                        break;
                    case UserAction.Exit:
                        isExit = true;
                        break;
                    default:
                        view.Alert(viewText.notCorrectInput);
                        break;
                }
                view.ShowScore(user);
            }
        }
        
        static public Plant ChoosePlant(Plant[] plants)
        {
            view.ChoosePlant();
            bool success = int.TryParse(view.UserInput(), out int number);
            if (success && number > 0 && number <= plants.Length)
                return plants[number - 1];
            return null;
        }

        static public void Water(Plant plant)
        {
            if (plant.isPour == false)
            {
                plant.isPour = true;
                plant.counterToGrew++;
                plant.lifeBar = plant.fullHealth;
                view.Water(plant);
            }
            else
                view.Alert(viewText.waterNo);
        }
        
        static public void TakeFlower(Plant plant, User user)
        {
            if (plant.isPour = true && plant.counterToGrew >= plant.readyToTake)
            {
                user.score++;
                plant.counterToGrew = 0;
                view.TakeFlower(plant);
            }
            else if (plant.isPour == false)
                view.Alert(viewText.notWatered);
            else
                view.Alert(viewText.notGrowing);
        }        

        static public bool Wait(Plant[] plants)
        {
            foreach (Plant plant in plants)
            {
                if (plant.lifeBar == 0)
                    plant.isDead = true; //TODO if plant is dead - exclude it from the game and show alert

                if (plant.isPour == true)
                {
                    plant.counterToGrew++;
                    if (plant.counterToGrew >= plant.readyToTake)
                        view.Ready(plant);
                    else
                        view.NotGrowYet(plant);
                }

                if (plant.isPour == false)
                {
                    plant.counterToGrew = 0;
                    plant.lifeBar--;
                    view.WillDried(plant);
                }
            }

            if (EverybodyDies(plants))
                return true;
            else
                return false;
        }

        static void Pour(Plant plant)
        {
            if (plant.isPour == false)
                plant.isPour = true;
            else
                view.Success(viewText.wateredYes);
        }

        static public void EndGame(Plant[] plants, User user)
        {
            if (EverybodyDies(plants))
                view.Died();
            else
                view.Closed();
            view.ShowScore(user);
        }

        static bool EverybodyDies(Plant[] plants)
        {
            int counter = 0;
            foreach (var plant in plants)
            {
                counter += plant.lifeBar;
                if (counter != 0)
                    return false;
            }
            return true;
        }
    }
}