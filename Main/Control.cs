using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Control
    {
        AView view = new ConsoleView();
        
        public void ChooseUserAction(Plant plant, User user)
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
                        view.Alert(notCorrectInput);
                        break;
                }
            }
        }

        public void Water(Plant plant, User user)//err
        {
            if (plant.isPour == false)
            {
                plant.isPour = true;
                plant.counterToGrew++;
                plant.lifeBar = plant.fullHealth;
                view.Water(plant);
                view.ShowScore(user);
            }
            else
                view.Alert(view.waterNo);
        }

        public void TakeFlower(Plant plant, User user)//err
        {
            if (plant.grow = true && plant.counterToGrew >= plant.readyToTake)
            {
                user.score++;
                plant.grow = false;
                plant.counterToGrew = 0;

                if (plant.isPour == false)
                    plant.lifeBar--;
                view.TakeFlower(plant);
                view.ShowScore(user);
            }
            else if (plant.isPour == true)
                view.Alert(view.notGrowning);
            else
                view.Alert(view.notWatered);
        }

        public void Wait(Plant plant, out bool isExit) // change logic
        {
            isExit = false;
            plant.counterToGrew++;
            if (plant.isPour == false)
            {
                plant.lifeBar--;
                Console.WriteLine($"Plant will be dried after {plant.lifeBar} moves.\n");
            }

            if (plant.counterToGrew >= plant.readyToTake)
                Console.WriteLine("Your flower is ready");
            else
                Console.WriteLine($"Your flower will grow after {plant.readyToTake - plant.counterToGrew} moves.");

            if (plant.lifeBar == 0)
                isExit = true;
        }

        void Pour(Plant plant)//err
        {
            if (plant.isPour == false)
                plant.isPour = true;
            else
                view.Success(view.wateredYes);
        }

        public void EndGame(Plant plant, User user)
        {
            if (plant.lifeBar == 0)
                view.Died();
            else
                view.Closed();
            view.ShowScore(user);
        }
    }
}
