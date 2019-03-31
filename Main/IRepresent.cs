using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    interface IRepresent
    {
        string UserInput();
        void ShowMenu();
        void ShowScore(User user);
        void UserAction(Plant plant, User user);
        void Water(Plant plant, User user);
        void TakeFlower(Plant plant, User user);
        void Wait(Plant plant);
        void AlertNotCorrectInput();
        void EndGame(Plant plant, User user);
    }
}
