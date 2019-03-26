using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    interface IAction
    {
        void ShowMenu();
        void ShowMessage();
        void GetUserInput();
        User Login();
    }
}