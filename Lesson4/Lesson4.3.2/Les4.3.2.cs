﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*3. Сделать записную книжку, которая будет сохранять данные в файл. Каждая запись храниться в отдельном файле и при запуске программы,
    программа проверяет не пустая ли папка, и если нет то выводит список доступных записей которые можно выбрать.*/
namespace Lesson4._3._2
{
    class Program
    {
        static string folderPathCurrent = InitFolder();

        static string InitFolder() // Change "path" to actual
        {
            string path = @"C:\Users\Gala\Desktop";
            string subPath = @"notes";           
            string folderPathCurrent = path + @"\" + subPath;
            Directory.CreateDirectory(folderPathCurrent);
            return folderPathCurrent;
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n" +
                        "Input a command:\n" +
                        "1.Write - to write in a notepad.\n" +
                        "2.Read - to read info from notepad.\n" +
                        "3.Exit - to close a notepad.\n");
        }

        static void GetUserInput(out bool isExit)
        {
            isExit = false;
            bool noInput = false;
            do
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        FileWrite();
                        break;
                    case "2":
                        FileRead();
                        break;
                    case "3":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Input correct action.");
                        noInput = true;
                        break;
                }
            }
            while (noInput);
        }

        static void FileWrite()
        {
            Console.WriteLine("Write your notes:");
            string userInput = Console.ReadLine();
            
            using (FileStream fstream = new FileStream(FileName(userInput), FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(userInput);
                fstream.Write(array, 0, array.Length);
            }
        }

        //не создана обработка ошибки с недопустимыми символами в названии файла
        //вариант с отдельным введением названия заметки - не интересно.
        //И человек может даже в названии использовать недопустимые символы.
        static string FileName(string userInput)
        {
            if(userInput.Length >= 10)
                return folderPathCurrent + @"\" + userInput.Substring(0, 10) + "(...).txt";
            else
                return folderPathCurrent + @"\" + userInput + "(...).txt";
        }
        
        static string[] FindAndShowNotes(string folderPath)
        {
            string[] notes = Directory.GetFiles(folderPath, "*.txt");
            for (int i = 0; i < notes.Length; i++)
            {
                FileInfo note = new FileInfo(notes[i]);
                Console.WriteLine(i + 1 + ". " + note.Name);
            }
            return notes;
        }

        static string ChooseNotes(string[] notes)
        {
            bool correctInput = false;
            string fileName = "";

            while (!correctInput)
            {
                Console.WriteLine("Input number of notes");
                int noteCurrent = Int32.Parse(Console.ReadLine());

                if (noteCurrent > 0 && noteCurrent <= notes.Length)
                {
                    fileName = notes[noteCurrent - 1];
                    correctInput = true;
                }                    
            }
            return fileName;
        }

        static void FileRead()
        {
            string filePathCurrent = ChooseNotes(FindAndShowNotes(folderPathCurrent));

            using (FileStream fstream = File.OpenRead(filePathCurrent))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine("Notes: {0}", textFromFile);
            }
        }
        
        static void Main()
        {
            bool isExit = false;
            while (!isExit)
            {
                ShowMenu();
                GetUserInput(out isExit);
            }
        }
    }
}