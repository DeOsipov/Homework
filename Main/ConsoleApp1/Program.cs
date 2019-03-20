using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your notes:");
            string userInput = Console.ReadLine();
            string fileName = userInput.Substring(0, 10) + "(...).txt";
            using (FileStream fstream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(userInput);
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
