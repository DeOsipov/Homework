using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*3. Сделать записную книжку, которая будет сохранять данные в файл.*/
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

        void CreateFolder(out DirectoryInfo dirInfo)
        {
            string path = @"C:\Users\Gala\Desktop";
            dirInfo = new DirectoryInfo(path);
            string subPath = @"notes";
            dirInfo.CreateSubdirectory(subPath);
        }

        void CreateInfoFile(out FileStream fileInfoStream)
        {
            string fileInfoPath = @"C:\Users\Gala\Desktop\notes\system.sys";
            fileInfoStream = new FileStream(fileInfoPath, FileMode.OpenOrCreate);
            File.SetAttributes(fileInfoStream.Name, FileAttributes.Hidden);
        }

        void Menu()
        {
            Console.WriteLine("\n" +
                        "Input a command:\n" +
                        "1.Write - to write in a notepad.\n" +
                        "2.Read - to read info from notepad.\n" +
                        "3.Exit - to close a notepad.\n");
        }

        FileAction fileAction = FileAction.Default;

        void UserAction()
        {
            bool correctInput = false;
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

        void FileWrite(string filePathCurrent)
        {
            Console.WriteLine("Write your notes:");
            string userInput = Console.ReadLine();
            using (FileStream fstream = new FileStream(filePathCurrent, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(userInput);
                fstream.Write(array, 0, array.Length);
            }
        }

        void FileRead(string filePathCurrent)
        {
            using (FileStream fstream = File.OpenRead(filePathCurrent))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine("Notes: {0}", textFromFile);
            }
        }

        void Main(string[] args)
        {
            CreateFolder(out DirectoryInfo dirInfo);
            CreateInfoFile(out FileStream fileInfoStream);

            string filePathCurrent = @"C:\Users\Gala\Desktop\notes\notes.txt";

            while (fileAction != FileAction.Exit)
            {
                UserAction();
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