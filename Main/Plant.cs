using System;

namespace Main
{
    [Serializable]
    class Plant
    {
        static Random rand = new Random();
        internal int number;
        internal int lifeBar;
        internal int counterToGrew = 0;
        internal bool isPour = false;
        internal bool isDead = false;

        private int fullHealth;
        internal int FullHealth
        {
            get { return fullHealth; }
            private set { fullHealth = rand.Next(8, 11); }
        }

        private int needWater;
        internal int NeedWater
        {
            get { return needWater; }
            private set { needWater = rand.Next(3, 6); }
        }

        private int readyToTake;
        internal int ReadyToTake
        {
            get { return readyToTake; }
            private set { readyToTake = rand.Next(3, 6); }
        }
    }
}