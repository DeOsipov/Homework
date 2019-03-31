using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {        
        static IRepresent represent = new ConsoleRepresent();
        static User user = new User();
        static Plant plant = new Plant();

        static void Main()
        {
            user.Login(represent);
            represent.UserAction(plant, user);
            represent.ShowMenu();
            represent.EndGame(plant, user);
        }
    }
}