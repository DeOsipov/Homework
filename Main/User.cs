using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class User
    {
        internal string name;
        internal int score;

        internal void Login(IRepresent represent)
        {
            name = represent.UserInput();
        }
    }
}