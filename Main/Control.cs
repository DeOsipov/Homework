namespace Main
{
    class Control
    {
        static IView view = new ConsoleView();
        static ViewText viewText = new ViewText();
        static Game game = new Game();

        static void Main()
        {
            User user = Login();
            Plant[] plants = CreatePlantsArray();

            view.ShowStartMenu(user);

            UserAction action = UserAction.Default;
            while (action != UserAction.Exit)
            {
                view.ShowMenu();
                ChooseUserAction(plants, user, action);
                view.ShowScore(user);
            }
            EndGame(plants, user);
            view.UserInput();//чтоб не закрывалась
        }

        static User Login()
        {
            User user = new User();
            view.Login();
            user.name = view.UserInput();
            return user;
        }

        private const int numberOfPlants = 3;
        static Plant[] CreatePlantsArray()
        {
            Plant[] plants = new Plant[numberOfPlants];
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i] = new Plant{ number = i+1 };
            }
            return plants;
        }

        static void ChooseUserAction(Plant[] plants, User user, UserAction action)
        {
            switch (action = view.GetUserAction())
            {
                case UserAction.Water:
                    Water(ChoosePlant(plants));
                    break;
                case UserAction.Take:
                    TakeFlower(ChoosePlant(plants), user);
                    break;
                case UserAction.Wait:
                    Wait(plants);
                    if (IsEverybodyDead(plants))
                        action = UserAction.Exit;                        
                    break;
                case UserAction.ShowStatus:
                    ShowStatus(plants);
                    break;
                case UserAction.Save:
                    game.Save(user, plants);
                    break;
                case UserAction.Load:
                    game.Load();
                    break;
                //case UserAction.Delete:
                //    game.Delete();
                //    break;
                case UserAction.Exit:
                    action = UserAction.Exit;
                    break;
                default:
                    view.Alert(viewText.notCorrectInput);
                    break;
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

        static public void ShowStatus(Plant[] plants)
        {
            foreach(Plant plant in plants)
                view.ShowStatus(plant);
        }

        static bool IsNotAvaible(Plant plant)
        {
            if (plant == null)
            {
                view.Alert(viewText.notCorrectInput);
                return true;
            }
            if (plant.isDead)
            {
                view.Alert(viewText.isDead);
                return true;
            }
            return false;
        }        

        static void Water(Plant plant)
        {
            if (IsNotAvaible(plant))
                return;

            if (plant.isPour == false)
                WaterSuccess(plant);
            else
                view.Alert(viewText.wateredNo);
        }

        static void WaterSuccess(Plant plant)
        {
            plant.isPour = true;
            plant.lifeBar = plant.fullHealth;
            view.Success(viewText.wateredYes);
        }
        
        static void TakeFlower(Plant plant, User user)
        {
            if (IsNotAvaible(plant))
                return;

            if (plant.isPour == false)
                view.Alert(viewText.notWatered);
            else if (plant.isPour = true && IsReadyToTake(plant))
                TakeSuccess(user, plant);
            else
                view.Alert(viewText.notGrowing);
        }

        static bool IsReadyToTake(Plant plant)
        {
            return plant.counterToGrew >= plant.readyToTake;
        }

        static void TakeSuccess(User user, Plant plant)
        {
            user.score++;
            plant.counterToGrew = 0;
            view.TakeFlower(plant);
        }

        static void Wait(Plant[] plants)
        {                                       //TODO make smaler methods
            foreach (Plant plant in plants)
            {
                plant.lifeBar--;
                if (plant.lifeBar <= 0)
                {
                    plant.isDead = true;
                    continue;
                }
                else if (plant.lifeBar <= 2)
                    plant.isPour = false;

                if (plant.isPour == true)
                {
                    plant.counterToGrew++;
                    if (plant.counterToGrew >= plant.readyToTake)
                        view.Ready(plant);
                    else
                        view.NotGrowYet(plant);
                }
                else
                {
                    plant.counterToGrew = 0;
                    view.WillDried(plant);                    
                }
            }
        }

        static void EndGame(Plant[] plants, User user)
        {
            if (IsEverybodyDead(plants))
                view.Alert(viewText.youDead);
            else
                view.Closed();
        }

        static bool IsEverybodyDead(Plant[] plants)
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