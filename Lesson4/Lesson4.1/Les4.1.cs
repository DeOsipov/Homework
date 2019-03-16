using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4._1
{
    //1. Получить всё дерево папок и файлов входящих в эти папки (вложенность папок должна быть не меньше 3х папок и не меньше 4х файлов),
    //запрещено использовать массивы. Можете для примера потренироваться на папке Program Files или C:\Users\%USERNAME%\.
    class Program
    {
        static SubDirectoryName(string path)
        {
            string[] dir = Directory.GetDirectories(path);

            for (int i = 0; i < dir.Length; i++)
            {
                Console.WriteLine(dir[i]);
            }
        }

        static string SubDirectoryNameLoop(string path)
        {
            return SubDirectoryName(path);
        }

        static void Main(string[] args)
        {
            string path = @"C:/Program Files";

            SubDirectoryName(path);
            Console.ReadLine();
        }
    }
}
