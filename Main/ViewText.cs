namespace Main
{
    class ViewText
    {
        internal string notCorrectInput = "Input right action";
        internal string wateredNo = "U can\'t water more...";
        internal string notGrowing = "Your flower is not growning yet...";
        internal string notWatered = "At first - water the plant and then wait some moves...";
        internal string isDead = "Plant is dead.";
        internal string youDead = "Everything in this world is dead, game over...";
        internal string gameNotSaved = "Game is not saved, change name";
        internal string gameNotLoad = "Game not load";
        internal string gameNotDelete = "Game not delete";

        internal string wateredYes = "Plant have been watered.";
        internal string gameSaved = "Game saved";
        internal string gameLoad = "Game load";
        internal string gameDelete = "Game deleted";
        
        internal string login = "Input your name.";
        internal string showMenu = $"Take the flower type {(int)UserAction.Take} or \"take\"\n" +
                $"Water the plant type {(int)UserAction.Water} or \"water\"\n" +
                $"Skip a turn type {(int)UserAction.Wait} or \"wait\"\n" +
                $"Show plant status info type {(int)UserAction.ShowStatus} or \"show\"\n" +
                $"Save game - {(int)UserAction.Save} or \"save\"\n" +
                $"Load game - {(int)UserAction.Load} or \"load\"\n" +
                $"Delete game - {(int)UserAction.Delete} or \"del\"\n" +
                $"U can exit the game by typing {(int)UserAction.Exit} or \"exit\"\n";
        internal string choosePlant = "Choose a plant";
        internal string chooseGameToSave = "Input number of slot to save the game, you can save in slots from 1 to 10.";
        internal string chooseGameToLoad = "Input number of slot to load the game, you can load from slots 1 to 10.";
        internal string chooseGameDelete = "Input number of slot to delete the game.";
        internal string emptyFolder = "Folder is empty.";

        internal string ShowStartMenu(User user)
        {
            return $"Hello, {user.name}, you are playing the game \"Flower Lover v 1.0.1\".\n" +
                $"Your plant give a flower after watering and some turns.\n" +
                $"If plant is staing dried too long - it dies.\n" +
                "Take a biggest bouquet as you can.\n" +
                "U can do:";
        }

        internal string TakeFlower(Plant plant)
        {
            return $"U take the flower and increase a bouquet.\n" +
                $"Plant will be dried after {plant.lifeBar} moves.\n";
        }

        internal string Ready(Plant plant)
        {
            return $"Plant {plant.number} is ready to take.";
        }

        internal string NotGrowYet(Plant plant)
        {
            return $"Your plant {plant.number} will grow after {plant.ReadyToTake - plant.counterToGrew} moves.";
        }

        internal string Closed()
        {
            return "You closed the game.";
        }
        
        internal string ShowScore(User user)
        {
            return $"{user.name}, you score is {user.score}";
        }

        public string LifeStatus(Plant plant)
        {
            return string.Format("Plant {0} is {1}", plant.number, plant.isDead ? "dead" : "alive");
        }

        public string WaterStatus(Plant plant)
        {
            string prefix = plant.isPour ? "" : "not ";
            return $"Plant {plant.number} is {prefix}watered.";
        }

        internal string WillDry(Plant plant)
        {
            return $"After {plant.lifeBar} moves plant {plant.number} will died.\n";
        }
    }
}