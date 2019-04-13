using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    abstract class AView
    {
        //alert
        internal string waterNo = "U can\'t water more...";
        internal string notGrowing = "Your flower is not growning yet...";
        internal string notWatered = "At first - water the plant and then wait some moves...";
        internal string notCorrectInput = "Input right action";
        //success
        internal string wateredYes = "Plant have been watered.";

        abstract public void Login(User user);
        abstract public void ShowScore(User user);
        abstract public string UserInput();
        abstract public void ShowMenu();
        abstract public void GetUserAction(Plant plant, User user);
        abstract public void TakeFlower(Plant plant);
        abstract public void Water(Plant plant);
        abstract public void Wait(Plant plant);
        abstract public void Ready();
        abstract public void NotGrowYet(Plant plant);
        abstract public void Alert(string message);
        abstract public void Success(string message);
        abstract public void Closed();
        abstract public void Died();
    }
}
