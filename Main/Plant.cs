using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Plant
    {
        internal int lifeBar = 5;
        internal const int fullHealth = 5;
        internal const int needWater = 2;

        internal int counterToGrew = 0;
        internal int readyToTake = 3;

        internal bool isPour = false;
        internal bool grow = false;
    }
}