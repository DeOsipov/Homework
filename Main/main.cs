using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {        
        static IView view = new ConsoleView();
        static User user = new User();
        static Control control = new Control();
        static Plant plantFirst = new Plant();
        static Plant plantSecond = new Plant();
        static Plant plantThird = new Plant();

        static Plant ChoosePlant(string UserInput)
        {
            switch (UserInput)
            {
                case "1":
                    return plantFirst;
                case "2":
                    return plantSecond;
                case "3":
                    return plantThird;
            }
            return view.Alert(view.notCorrectInput);
        }

        static void Main()
        {
            string userInput = view.UserInput();
            Plant actualPlant = ChoosePlant(userInput);
            
            view.Login(user);
            view.GetUserAction(actualPlant, user);
            view.ShowMenu();
            view.EndGame(actualPlant, user);
        }
    }
}