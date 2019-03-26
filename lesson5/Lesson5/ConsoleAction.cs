using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class ConsoleAction : IAction//для ввода-вывода информации через консоль
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
            Console.WriteLine("Input a number of action" +
                "1.Show all messages." +
                "2.Pick a messages." +
                "3.Remove seal." +
                "4.Show message" +
                "5.Exit.");
        }

        static IMessageList messageList = new TestMessageList();
        static Message[] actualMessageList = messageList.GetMessageList();

        public void GetUserInput(out bool isExit)
        {
            isExit = false;
            bool correctInput = false;

            while (!correctInput)
            {                
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowMessageList(actualMessageList);
                        correctInput = true;
                        break;
                    case "2":
                        Pick(actualMessageList);
                        correctInput = true;
                        break;
                    case "3":
                        RemoveSeal(Pick(actualMessageList));//exeption when messages have not been chosen
                        correctInput = true;
                        break;
                    case "4":
                        ShowMessage(Pick(actualMessageList));
                        correctInput = true;
                        break;
                    case "5":
                        isExit = true;
                        correctInput = true;
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
                    Console.WriteLine("Input correct number.");
            }
            return mes;            
        }

        public bool RemoveSeal(Message message)
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
                        Console.WriteLine("Uncorrect input.");
                        break;
                }
            }
        }

        public void ShowMessage(Message message)
        {
            if (!message.Sealed)
            {
                Console.WriteLine(message.MessageMainText);
                message.Read = true;
            }
            else
                Console.WriteLine("Message is sealed, at first open it.");
        }        
    }
}