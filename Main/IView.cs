namespace Main
{
    interface IView
    {
        string UserInput();
        UserAction GetUserAction();
        void ShowStatus(Plant plant);
        void Alert(string message);
        void Success(string message);
        void Info(string message);
        void Attention(string message);
    }
}
