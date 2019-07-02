using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._7altered
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            Area area = new Area();
            User user1 = new User { name = 1 };
            User user2 = new User { name = 2 };
            User ActualUser(int counter) => counter % 2 == 1 ? user1 : user2;
            
            int size = CorrectInputAreaSize(area.minAreaSize, area.maxAreaSize, "size of area");
            int[,] gameArea = area.Create(size);
            bool isPlay = true;
            int turn = 0;
            while (isPlay)
            {
                User actualUser = ActualUser(++turn);
                view.Clear();
                view.ShowArea(gameArea);
                view.ShowMenu(actualUser);
                int row = CorrectInputCellPosition(gameArea.GetLength(0), "row");
                int column = CorrectInputCellPosition(gameArea.GetLength(1), "column");
                if (gameArea[row, column] == 0)
                    area.ChangeCell(gameArea, row, column, actualUser);
                else
                {
                    view.Error();
                    --turn;
                }
                isPlay = !area.CheckIsWin(gameArea, actualUser) && area.CheckHaveEmptyCells(gameArea);
            }

            if (area.CheckIsWin(gameArea, ActualUser(turn)))
            {
                view.ShowArea(gameArea);
                if (user1.win == true)
                {
                    user1.score++;
                    view.EndGame(user1);
                }
                else
                    view.EndGame(user2);
            }
            else
                view.IsExit();
            Console.ReadLine(); //test

            int CorrectInputCellPosition(int length, string text)
            {
                bool sucess = false;
                int value = 0;
                while (!sucess)
                {
                    view.Choose(text);
                    sucess = Int32.TryParse(view.UserInput(), out value) && value - 1 < length;
                    if (!sucess)
                        view.Error();
                }
                return value - 1;
            }
            int CorrectInputAreaSize(int min, int max, string text)
            {
                bool sucess = false;
                int value = 0;
                while (!sucess)
                {
                    view.Choose(text);
                    sucess = Int32.TryParse(view.UserInput(), out value) && (value >= min) && (value <= max);
                    if (!sucess)
                        view.Error();
                }
                return value;
            }
        }
        class User
        {
            public int name;
            public int score;
            public bool win;
        }
        class Area
        {
            public int minAreaSize = 3;
            public int maxAreaSize = 10;
            public int[,] Create(int size)
            {
                return new int[size, size];
            }
            public bool CheckHaveEmptyCells(int[,] area)
            {
                foreach (int cell in area)
                    if (cell == 0)
                        return true;
                return false;
            }
            public bool CheckIsWin(int[,] area, User user)
            {
                user.win = true;
                for (int i = 0; i < area.GetLength(0) - 2; i++)
                    for (int j = 0; j < area.GetLength(0) - 2; j++)
                    {
                        if (area[i, j] == area[i + 1, j] && area[i, j] == area[i + 2, j] && area[i, j] != 0)
                            return true;
                        if (area[i, j] == area[i, j + 1] && area[i, j] == area[i, j + 2] && area[i, j] != 0)
                            return true;
                        if (area[i, j] == area[i + 1, j + 1] && area[i, j] == area[i + 2, j + 2] && area[i + 1, j + 1] != 0)
                            return true;
                        if (area[i + 2, j] == area[i + 1, j + 1] && area[i + 2, j] == area[i, j + 2] && area[i + 1, j + 1] != 0)
                            return true;
                    }
                user.win = false;
                return false;
            }
            public void ChangeCell(int[,] area, int column, int row, User user)
            {
                    area[column, row] = user.name;
            }
        }
        class View
        {
            public void ShowArea(int[,] baseArea)
            {
                string[,] area = VisualArea(baseArea);
                for (int i = 0; i < area.GetLength(0); i++)
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        switch (area[i, j])
                        {
                            case " O ":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case " X ":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            default:
                                break;
                        }
                        Console.Write(area[i, j]);

                        if (j % area.GetLength(1) == area.GetLength(1) - 1)
                            Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
            }
            string[,] VisualArea(int[,] area)
            {
                string[,] visualArea = new string[area.GetLength(0), area.GetLength(1)];
                for (int i = 0; i < visualArea.GetLength(0); i++)
                    for (int j = 0; j < visualArea.GetLength(1); j++)
                        switch (area[i, j])
                        {
                            case 1:
                                visualArea[i, j] = " O ";
                                break;
                            case 2:
                                visualArea[i, j] = " X ";
                                break;
                            default:
                                visualArea[i, j] = " - ";
                                break;
                        }
                return visualArea;
            }
            public string UserInput()
            {
                return Console.ReadLine();
            }
            public void Error()
            {
                Console.WriteLine("Incorrect input");
            }
            public void ShowMenu(User user)
            {
                Console.WriteLine($"Player {user.name} turn.");
            }
            public void EndGame(User user)
            {
                Console.WriteLine($"Player {user.name} is win. His score is {user.score}.");
            }
            public void IsExit()
            {
                Console.WriteLine("The game was closed.");
            }
            public void Choose(string text)
            {
                Console.WriteLine($"Chose a {text}");
            }
            public void Clear()
            {
                Console.Clear();
            }
        }        
    }
}
