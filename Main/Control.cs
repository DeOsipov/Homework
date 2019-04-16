namespace Main
{
    class Control
    {
        static IView view = new ConsoleView();
        static ViewText viewText = new ViewText();

        static void Main()
        {
            User user = Login();
            Plant[] plants = CreatePlantsArray();

            view.ShowStartMenu(user);
            ChooseUserAction(plants, user);
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

        static void ChooseUserAction(Plant[] plants, User user)
        {
            UserAction action = UserAction.Default;
            while (action != UserAction.Exit)
            {
                view.ShowMenu();
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
                    case UserAction.Exit:
                        action = UserAction.Exit;
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

        static public void ShowStatus(Plant[] plants)
        {
            foreach(Plant plant in plants)
            {
                view.ShowStatus(plant);
            }
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

        static public void Water(Plant plant)
        {
            if (IsNotAvaible(plant))
                return;

            if (plant.isPour == false)
            {
                plant.isPour = true;
                plant.lifeBar = plant.fullHealth;
                view.Success(viewText.wateredYes);
            }
            else
                view.Alert(viewText.wateredNo);
        }
        
        static public void TakeFlower(Plant plant, User user)
        {
            if (IsNotAvaible(plant))
                return;

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

        static public void Wait(Plant[] plants)
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

        static public void EndGame(Plant[] plants, User user)
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