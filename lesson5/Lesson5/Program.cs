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
        static IMessageList messageList = new TestMessageList();

        static void Main(string[] args)
        {
            Message[] actualMessageList = messageList.GetMessageList();
            Message actualMessage = new Message();
            UserAction userAction = UserAction.Default;

            User actualUser = action.Login();

            while (userAction != UserAction.Exit)
            {
                action.ShowMenu();
                userAction = action.GetUserInput();

                switch (userAction)
                {
                    case UserAction.MessageList:
                        action.ShowMessageList(actualMessageList);
                        break;
                    case UserAction.PickMessage:
                        actualMessage = action.Pick(actualMessageList);
                        break;
                    case UserAction.RemoveSeal:
                        action.RemoveSeal(actualMessage, actualUser.Name);
                        break;
                    case UserAction.ShowMessage:
                        action.ShowMessage(actualMessage);
                        break;
                    case UserAction.Exit:
                        break;
                    default:
                        action.WrongInput();
                        break;
                }
            }
        }
    }

    enum UserAction
    {
        Default,
        MessageList,
        PickMessage,
        RemoveSeal,
        ShowMessage,
        Exit,
    }
}
