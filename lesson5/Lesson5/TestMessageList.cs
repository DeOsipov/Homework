using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{    
    class TestMessageList : IMessageList //для получения списка сообщений из тестового массива
    {
        public void GetMessageList()
        {
            Message[] messages = new Message[4];
            for(int i = 0; i < messages.Length; i++)
            {
                messages[i].MessageName = "name" + i;
                messages[i].MessageMainText = "main text" + i;
                messages[i].MessageName = "name" + i;
            }
        }
    }
}