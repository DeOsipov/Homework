using System;

namespace Main
{
    [Serializable]
    class Plant
    {
        internal int number;
        internal int lifeBar;
        internal int counterToGrew = 0;
        internal bool isPour = false;
        internal bool isDead = false;

        static Random rand = new Random();
        int fullHealth;
        public int FullHealth { get => fullHealth; private set => fullHealth = rand.Next(8, 11); }

        private int needWater;
        internal int NeedWater { get => needWater; private set => needWater = rand.Next(1, 2); }

        private int readyToTake;
        public int ReadyToTake { get => readyToTake; private set => readyToTake = rand.Next(3, 6); }
    }
}