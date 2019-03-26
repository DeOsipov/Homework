using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static IAction show;// = new ConsolePresenter(); не дописан
        static IMessageList messageList;// = new TestMessageList(); не дописан

        static void Main(string[] args)
        {
            show.Login();
            show.ShowMenu();
            messageList.GetMessageList();
            show.GetUserInput();
            show.ShowMessage();
        }
    }
}
