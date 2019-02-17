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
            // ?? enum or bool ??
            //create array of playing area -> info -> chose first turn/ next turn

            //player turn -> input number of column and raw of player area [array] -> exchange array[i] value 0->1
            //check array
            //writeLine win

            //check array -> sum of 3 column, sum of 3 raw, sum of 2 diagonal

            //create a playing area
            int[,] playArea = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (playArea[i, j] == 1)
                    {
                        Console.Write("X");
                    }
                    else if (playArea[i, j] == 2)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.ReadLine();
        }



        /*static bool checkWin( int[,])
        {
            int[] checkArray = new int[8];

            /*for (int i = 0; i < checkArray.Length; i++)
            {
                for 
            }
            checkArray[0] = playArea[1, 1] + playArea[1, 2] + playArea[1, 3];
            checkArray[1] = playArea[2, 1] + playArea[2, 2] + playArea[2, 3];
            checkArray[2] = playArea[3, 1] + playArea[3, 2] + playArea[3, 3];

            checkArray[3] = playArea[1, 1] + playArea[2, 1] + playArea[3, 1];
            checkArray[3] = playArea[1, 1] + playArea[2, 1] + playArea[3, 1];

            //сразу проводить сравнение и break
            //проверка изменения состояния строки, колонки и диагонали

            /*-------
             * 2 вариант
             * for (int i = 0; i < 3; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {

                 }
             }*/


        /* foreach (int sum in checkArray)
         {
             if (sum == 3)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }*/
    }
}