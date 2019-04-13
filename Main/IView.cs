using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    interface IView
    {
        void Login(User user);
        void ShowScore(User user);
        string UserInput();
        void ShowMenu();
        void GetUserAction(Plant plant, User user);
        void Wait(Plant plant, out bool isExit);
        void Closed();
        void Died();
        void TakeFlower(Plant plant);
        void Alert(string message);
        void Water(Plant plant);
    }
}
