using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {        
        static AView view = new ConsoleView();
        static User user = new User();
        static Control control = new Control();
        static Plant plantFirst = new Plant();
        static Plant plantSecond = new Plant();
        static Plant plantThird = new Plant();

        static Plant actualPlant = new Plant();

        static void ChoosePlant(string UserInput)
        {
            switch (UserInput)
            {
                case "1":
                    actualPlant = plantFirst;
                    break;
                case "2":
                    actualPlant = plantFirst;
                    break;
                case "3":
                    actualPlant = plantFirst;
                    break;
                default:
                    view.Alert(view.notCorrectInput);
                    break;
            }            
        }

        static void Main()
        {
            string userInput = view.UserInput();
            Plant actualPlant = ChoosePlant(userInput);
            
            view.Login(user);
            view.GetUserAction(actualPlant, user);
            view.ShowMenu();
            control.EndGame(actualPlant, user);
        }
    }
}