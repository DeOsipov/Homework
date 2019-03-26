using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class ConsoleAction : IAction//для ввода-вывода информации через консоль
    {
        public void ShowMenu()
        {
            Console.WriteLine("Input a number of action" +
                "1.Show all messages." +
                "2.Pick a messages." +
                "3.Remove seal." +
                "4.Exit.");
        }
        
        public void ShowMessage()
        {

        }

        public void GetUserInput()
        {
            
        }

        public User Login()
        {
            User actualUser = new User();
            actualUser.Name = Console.ReadLine();
            return actualUser;
        }
    }
}