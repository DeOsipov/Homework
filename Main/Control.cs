using System;

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
            view.Info(viewText.ShowStartMenu(user));
            UserAction action = UserAction.Default;
            while (action != UserAction.Exit)
            {
                view.Info(viewText.showMenu);
                ChooseUserAction(plants, user, action);
                view.Attention(viewText.ShowScore(user));
            }
            EndGame(plants, user);
            view.UserInput();
        }

        static User Login()
        {
            User user = new User();
            view.Info(viewText.login);
            user.name = view.UserInput();
            return user;
        }

        private const int numberOfPlants = 3;
        static Plant[] CreatePlantsArray()
        {            
            Plant[] plants = new Plant[numberOfPlants];
            Random random = new Random();
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i] = new Plant { number = i + 1};
                plants[i].lifeBar = plants[i].FullHealth; //TODO сократить
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
                    game.Load(user, plants);
                    break;
                case UserAction.Delete:
                    game.Delete();
                    break;
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
            view.Info(viewText.choosePlant);
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
            plant.lifeBar = plant.FullHealth;
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
            return plant.counterToGrew >= plant.ReadyToTake;
        }

        static void TakeSuccess(User user, Plant plant)
        {
            user.score++;
            plant.counterToGrew = 0;
            view.Info(viewText.TakeFlower(plant));
        }

        static void Wait(Plant[] plants)
        {
            foreach (Plant plant in plants)
            {
                if(plant.lifeBar > 0)
                    plant.lifeBar--;

                if (plant.lifeBar <= 0)
                {
                    plant.isDead = true;
                    continue;
                }
                else if (plant.lifeBar <= 2)
                    plant.isPour = false;

                CheckPourStatus(plant);
            }
        }

        static void CheckPourStatus(Plant plant)
        {
            if (plant.isPour == true)
            {
                plant.counterToGrew++;
                PlantGrowStatus(plant);
            }
            else
            {
                plant.counterToGrew = 0;
                view.Info(viewText.WillDry(plant));
            }
        }

        static void PlantGrowStatus(Plant plant)
        {
            if (plant.counterToGrew >= plant.ReadyToTake)
                view.Info(viewText.Ready(plant));
            else
                view.Info(viewText.NotGrowYet(plant));
        }
        
        static void EndGame(Plant[] plants, User user)
        {
            if (IsEverybodyDead(plants))
                view.Alert(viewText.youDead);
            else
                view.Info(viewText.Closed());
        }

        static bool IsEverybodyDead(Plant[] plants)
        {
            int counter = 0;
            foreach (var plant in plants)
            {
                counter += plant.lifeBar;
                if (counter <= 0)
                    return false;
            }
            return true;
        }
    }
}