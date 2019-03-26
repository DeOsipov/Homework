using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    interface IAction
    {
        User Login();
        void ShowMenu();
        void GetUserInput(out bool isExit);
        bool RemoveSeal(Message message);
        void ShowMessage(Message message);                        
    }
}