namespace Main
{
    interface IView
    {
        void Login();
        void ShowScore(User user);
        string UserInput();
        void ShowMenu();
        void ShowStartMenu(User user);
        UserAction GetUserAction();
        void ChoosePlant();
        void ShowStatus(Plant plant);
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
