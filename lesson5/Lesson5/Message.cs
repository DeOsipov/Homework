о using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Message
    {        
        private string messageName;
        private string mainText;        
        private string targetUserName;
        private bool isRead = false;
        private bool isSealed = true;

        public string MessageName
        {
            get { return messageName; }
            set { messageName = value; }
        }

        public string MessageMainText
        {
            get { return mainText; }
            set { mainText = value; }
        }

        public string Target
        {
            get { return targetUserName; }
            set { targetUserName = value; }
        }

        public bool IsRightTarget(string targetName)
        {
            if (targetName == Target)
                return true;
            else
                return false;
        }

        public bool RemoveSeal()
        {
            Console.WriteLine("Remove seal? Y/N");
            while (true)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Y":
                        isSealed = false;
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Uncorrect input.");
                        break;
                }
            }
        }

        public void Read()
        {
            if (RemoveSeal())
            {
                Console.WriteLine(MessageMainText);
                isRead = true;
            }
        }
    }
}