namespace Main
{
    interface IView
    {
        void Login(User user);
        void ShowScore(User user);
        string UserInput();
        void ShowMenu();
        void ShowStartMenu(User user);
        UserAction GetUserAction();
        void ChoosePlant();
        void TakeFlower(Plant plant);
        void Water(Plant plant);
        void Wait(Plant plant);
        void Ready(Plant plant);
        void NotGrowYet(Plant plant);
        void WillDried(Plant plant);
        void Alert(string message);
        void Success(string message);
        void Closed();
        void Died();
    }
}
