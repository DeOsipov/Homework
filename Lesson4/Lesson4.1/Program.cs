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
        static void Main(string[] args)
        {
            string path = @"C:\Program Files";
            Loop(path);
            Console.Read();
        }

        static void Loop(string path)
        {
            try
            {
                string[] fileNamesCatalog = Directory.GetFiles(path);
                foreach (string fileName in fileNamesCatalog)
                {
                    Console.WriteLine(fileName);
                }

                string[] subDir = Directory.GetDirectories(path);
                if (subDir.Length != 0)
                {
                    for (int i = 0; i < subDir.Length; i++)
                    {
                        path = subDir[i];
                        Console.WriteLine(subDir[i]);
                        Loop(path);
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Access denied {path}.");
            }
        }
    }
}