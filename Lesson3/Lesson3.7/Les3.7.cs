using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Les3._7
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Написать игру крестики нолики для игры двумя игроками
            Если будет очень скучно попробовать написать примитивного соперника
            ?? enum or bool ??
            create array of playing area -> info -> chose first turn/ next turn
            player turn -> input number of column and raw of player area [array] -> exchange array[i] value 0->1
            check array
            writeLine win
            check array -> sum of 3 column, sum of 3 raw, sum of 2 diagonal*/

            //create a playing area 
            int endLine = 3;
            int[,] area = new int[endLine, endLine];
            Console.WriteLine($"Hello, let\'s play a game...\n" +
            $"Choose a opponent:\n" +
            $"1 - for playing with a friend.\n" +
            $"2 - for playing with a simple AI.\n" +
            /*$"3 - for playing with a insane AI.\n" +*/
            $"exit - for exit.");
            string userInput = Console.ReadLine();
            int playerNumber = int.Parse(Console.ReadLine());

            bool isPlaying = true;

            while (isPlaying && EmptyCells(area))
            {
                switch (userInput)
                {
                    case "1":
                        while (isPlaying)
                        {
                            if (playerNumber == 1)
                            {
                                playerTurn(playerNumber, area[endLine, endLine]);
                                playerNumber = 2;
                            }
                            else
                            {
                                playerTurn(playerNumber, area[endLine, endLine]);
                                playerNumber = 1;
                            }
                        }
                        if (!(EmptyCells(area[endLine, endLine])))
                        isPlaying = false;
                        break;

                    case "2":
                        while (isPlaying)
                        {
                            if (playerNumber == 1)
                            {
                                playerTurn(playerNumber, area[endLine, endLine]);
                                playerNumber = 2;
                            }
                            else
                            {
                                AIsimpleTurn(playerNumber, area[endLine, endLine]);
                                playerNumber = 1;
                            }
                        }
                        if (!(EmptyCells(area[endLine, endLine])))
                        {
                            isPlaying = false;
                            break;
                        }

                    /*case "3":
                    while (isPlaying)
                    {
                    if (playerNumber == 1)
                    {
                    playerTurn(playerNumber, area[,]);
                    playerNumber = 2;
                    }
                    else
                    {
                    AIinsaneTurn(playerNumber, area[,]);
                    playerNumber = 1;
                    }
                    }
                    break;*/

                    case "exit":
                        isPlaying = false;
                        break;

                    default:
                        Console.WriteLine("Please, input a correct comand.");
                        break;
                }
            }

            Console.WriteLine($"Player {playerNumber} win. Congratulations.");
        }

        //----have empty cells
        static bool EmptyCells(int[,] arr)
        {
            foreach (int n in arr)
            {
                if (n == 0)
                    return true;
            }
            return false;
        }

        //----player turn
        static void PlayerTurn(int playerNumber, int[,] arr)
        {
            bool notTurn = true;

            Console.WriteLine($"Choose a raw.");
            int raw = int.Parse(Console.ReadLine());
            Console.WriteLine($"Choose a column.");
            int column = int.Parse(Console.ReadLine());

            while (notTurn)
            {
                if (arr[raw, column] == 0)
                {
                    arr[raw, column] = playerNumber;
                    notTurn = false;
                }
                else
                {
                    Console.WriteLine($"Cell is not empty");
                }
            }

            IsWinGame(arr);
        }

        //----AI simple turn
        /*
        static AIsimpleTurn(playerNumber, int arr[,])
        {
        bool notTurn = true;
        Console.WriteLine($"Choose a raw.");
        string raw = Console.ReadLine();
        Console.WriteLine($"Choose a column.");
        string column = Console.ReadLine();
        while (notTurn){
        if (arr[raw, column] == 0)
        {
        arr[raw, column] = playerNumber;
        notTurn = false;
        }
        else
        {
        Console.WriteLine($"Cell is not empty");
        }
        }
        }*/

        //----AI insane turn

        //check change in array
        static bool IsChanged(int[,] arr1, int[,] arr2)
        {
            int sum1 = 0;
            foreach (int n in arr1)
            {
                sum1 += n;
            }

            int sum2 = 0;
            foreach (int n in arr2)
            {
                sum2 += n;
            }

            if (sum1 == sum2)
                return false;

            return true;
        }

        //draw method
        static void DrawArea()
        {
            //player symbol
            int firstPlayer = 1;
            int secondPlayer = 2;
            int n = 3; // raw & column length
            //area size
            int[,] playArea = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (playArea[i, j] == 1)
                    {
                        if (j == n)
                        {
                            Console.WriteLine(" X\n");
                        }
                        else
                        {
                            Console.Write(" X |");
                        }
                    }
                    else if (playArea[i, j] == 2)
                    {
                        if (j == n)
                        {
                            Console.WriteLine(" O\n");
                        }
                        else
                        {
                            Console.Write(" O |");
                        }
                    }
                    else
                    {
                        if (j == n)
                        {
                            Console.WriteLine(" \n");
                        }
                        else
                        {
                            Console.Write(" |");
                        }
                    }
                }
            }
        }

        //check method
        static bool IsWin(int a, int b, int c)
        {
            if (a == b && b == c)
                return true;
            return false;
        }
        //check area
        static bool IsWinGame(int[,] arr)
        {
            if (IsWin(arr[1, 1], arr[1, 2], arr[1, 3]) ||
            IsWin(arr[2, 1], arr[2, 2], arr[2, 3]) ||
            IsWin(arr[3, 1], arr[3, 2], arr[3, 3]) ||
            IsWin(arr[1, 1], arr[2, 1], arr[3, 1]) ||
            IsWin(arr[1, 2], arr[2, 2], arr[3, 2]) ||
            IsWin(arr[1, 3], arr[2, 3], arr[3, 3]) ||
            IsWin(arr[1, 1], arr[2, 2], arr[3, 3]) ||
            IsWin(arr[3, 1], arr[2, 2], arr[1, 3]))
                return true;
            return false;
        }
    }
}