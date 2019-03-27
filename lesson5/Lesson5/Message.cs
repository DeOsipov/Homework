using System;
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

        public bool Read
        {
            get { return isRead; }
            set { isRead = true; }
        }

        public bool Sealed
        {
            get { return isSealed; }
            set { isSealed = false; }
        }
               
        public bool IsRightTarget(string targetName)
        {
            if (targetName == Target)
                return true;
            else
                return false;
        }
    }
}