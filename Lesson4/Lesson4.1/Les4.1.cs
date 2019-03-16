using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4._1
{

    class Program
    {
        static int level = 0;

        static void Main(string[] args)
        {
            string path = @"C:\Program files";

            string[] dir = Directory.GetDirectories(path);

            for (int position = 0; position < dir.Length || dir.Length == 0; position++)
            {
                if (dir.Length == 0)
                {
                    level--;
                    if (level < 0)
                        break;
                }
                else
                {
                    Console.WriteLine(dir[position]);
                };

                Loop(dir, position);
                Console.Read();
            }
        }

        static void Loop(string[] dir, int position)
        {
            string[] subDir = Directory.GetDirectories(dir[position]);

            for (int i = 0; i < dir.Length || dir.Length == 0; i++)
            {
                if (subDir.Length == 0)
                {
                    level--;
                    if (level < 0)
                        break;
                }
                else
                {
                    Console.WriteLine(subDir[i]);
                }
            }
        }
    }
}