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
        UserAction GetUserInput();
        void ShowMessageList(Message[] messages);
        Message Pick(Message[] messages);
        bool RemoveSeal(Message message, string targetName);
        void ShowMessage(Message message);
        void WrongInput();
    }
}