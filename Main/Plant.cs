using System;

namespace Main
{
    [Serializable]
    class Plant
    {
        internal int number;

        internal int lifeBar = 5;
        internal int fullHealth = 5;
        internal int needWater = 3;

        internal int counterToGrew = 0;
        internal int readyToTake = 3;

        internal bool isPour = false;
        internal bool isDead = false;
    }
}