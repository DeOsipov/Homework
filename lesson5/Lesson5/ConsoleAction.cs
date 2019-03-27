using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class ConsoleAction : IAction
    {
        public User Login()
        {
            User actualUser = new User();
            Console.WriteLine("Please input your name.");
            actualUser.Name = Console.ReadLine();
            return actualUser;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\nInput a number of action.\n" +
                "1.Show all messages.\n" +
                "2.Pick a messages.\n" +
                "3.Remove seal.\n" +
                "4.Show message.\n" +
                "5.Exit.\n");
        }

        public UserAction GetUserInput()
        {
            while (true)
            {                
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        return UserAction.MessageList;
                    case "2":
                        return UserAction.PickMessage;
                    case "3":
                        return UserAction.RemoveSeal;
                    case "4":
                        return UserAction.ShowMessage;
                    case "5":
                        return UserAction.Exit;
                    default:
                        WrongInput();
                        break;
                }
            }
        }

        public void ShowMessageList(Message[] messages)
        {
            for(int i=0; i < messages.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {messages[i].MessageName}.");
            }
        }

        public Message Pick(Message[] messages)
        {
            Message mes = new Message();
            Console.WriteLine("Input number of message.");
            bool correctInput = false;

            while (!correctInput)
            {
                int userInput = Int32.Parse(Console.ReadLine());

                if (userInput > 0 && userInput < messages.Length)
                {
                    for (int i = 0; i < messages.Length; i++)
                    {
                        if (userInput == i + 1)
                        {
                            mes = messages[i];
                            correctInput = true;
                            break;
                        }
                    }
                }
                else
                    WrongInput();
            }
            return mes;            
        }

        public bool RemoveSeal(Message message, string targetName)
        {
            if (message.IsRightTarget(targetName))
            {
                Console.WriteLine("Remove seal? Y/N");
                while (true)
                {
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "Y":
                            message.Sealed = false;
                            return true;
                        case "N":
                            return false;
                        default:
                            WrongInput();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("It's not your message");
                return false;
            }
        }

        public void ShowMessage(Message message)
        {
            if (!message.Sealed)
            {
                Console.WriteLine(message.MessageName);
                Console.WriteLine(message.Target);
                Console.WriteLine(message.MessageMainText);
                message.Read = true;
            }
            else
                Console.WriteLine("Message is sealed, at first open it.");
        }

        public void WrongInput()
        {
            Console.WriteLine("Wrong input");
        }
    }
}