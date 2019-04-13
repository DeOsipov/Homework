using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Control
    {
        IView view = new ConsoleView();
        
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
                        view.AlertNotCorrectInput();
                        break;
                }
            }
        }

        public void Water(Plant plant, User user)
        {
            if (plant.isPour == false)
            {
                plant.isPour = true;
                plant.CounterToGrew++;
                plant.lifeBar = plant.fullHealth;
                view.Water(plant);
                view.showScore();
            }
            else
                view.AlertWater();
        }

        public void TakeFlower(Plant plant, User user)
        {
            if (plant.grow = true && plant.CounterToGrew >= plant.readyToTake)
            {
                user.score++;
                plant.grow = false;
                plant.CounterToGrew = 0;

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

        void Pour(Plant plant)
        {
            if (plant.isPour == false)
                plant.isPour = true;
            else
                view.Confirm(view.wateredYes);
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
