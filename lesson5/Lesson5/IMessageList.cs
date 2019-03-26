using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{    
    interface IMessageList
    {
        Message[] GetMessageList();
        //void GetMessageListToUser(); письма для определенного пользователя
    }
}