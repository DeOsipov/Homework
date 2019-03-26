using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static IAction action = new ConsoleAction();
        static IMessageList;
        //argue getmessagelist

        static void Main(string[] args)
        {
            action.Login();//ok
            //while(!isExit)
            action.ShowMenu();//ok
            result = action.GetUserInput(out bool isExit);//ok
            //show abstract
            //take enum of user input
        }
    }
}
