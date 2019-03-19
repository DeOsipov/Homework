using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*3. Сделать записную книжку, которая будет сохранять данные в файл.
3* Каждая запись храниться в отдельном файле и при запуске программы, программа проверяет не пустая ли папка, и если нет то выводит
    список доступных записей которые можно выбрать.
3** Все данные хранятся в одном файле разбитые между собой и при запуске программы, программа считыает файл и выводит список
    доступных записей.*/
namespace Lesson4._3
{
    class Program
    {
        enum FileAction
        {
            Default,
            Write,
            Read,
            Exit
        }

        static void CreateFolder(out DirectoryInfo dirInfo)
        {
            string path = @"C:\Users\Gala\Desktop";
            dirInfo = new DirectoryInfo(path);
            string subPath = @"notes";
            dirInfo.CreateSubdirectory(subPath);
        }

        static void CreateInfoFile(out FileStream fileInfoStream)
        {
            string fileInfoPath = @"C:\Users\Gala\Desktop\notes\system.sys";
            fileInfoStream = new FileStream(fileInfoPath, FileMode.OpenOrCreate);
            File.SetAttributes(fileInfoStream.Name, FileAttributes.Hidden);
        }

        static void Menu()
        {
            Console.WriteLine("\n" +
                        "Input a command:\n" +
                        "1.Write - to write in a notepad.\n" +
                        "2.Read - to read info from notepad.\n" +
                        "3.Exit - to close a notepad.\n");
        }

        static void UserAction(out FileAction fileAction)
        {
            bool correctInput = false;
            fileAction = FileAction.Default;
            while (fileAction != FileAction.Exit && !correctInput)
            {
                Menu();

                switch (Console.ReadLine())
                {
                    case "1":
                        fileAction = FileAction.Write;
                        correctInput = true;
                        break;
                    case "2":
                        fileAction = FileAction.Read;
                        correctInput = true;
                        break;
                    case "3":
                        fileAction = FileAction.Exit;
                        break;
                    default:
                        Console.WriteLine("Input correct action.");
                        break;
                }
            }
        }

        static void FileWrite(string filePathCurrent)
        {
            Console.WriteLine("Write your notes:");
            string userInput = Console.ReadLine();
            using (FileStream fstream = new FileStream(filePathCurrent, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(userInput);
                fstream.Write(array, 0, array.Length);
            }
        }

        static void FileRead(string filePathCurrent)
        {
            using (FileStream fstream = File.OpenRead(filePathCurrent))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine("Notes: {0}", textFromFile);
            }
        }

        static void Main(string[] args)
        {
            CreateFolder(out DirectoryInfo dirInfo);
            CreateInfoFile(out FileStream fileInfoStream);

            string filePathCurrent = @"C:\Users\Gala\Desktop\notes\notes.txt";
            FileAction fileAction = FileAction.Default;

            while (fileAction != FileAction.Exit)
            {
                UserAction(out fileAction);
                switch (fileAction)
                {
                    case FileAction.Write:
                        FileWrite(filePathCurrent);
                        break;

                    case FileAction.Read:
                        FileRead(filePathCurrent);
                        break;
                }
            }
        }
    }
}