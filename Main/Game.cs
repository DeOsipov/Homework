using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Main
{
    class Game
    {
        IView view = new ConsoleView();
        static ViewText viewText = new ViewText();

        DataContractJsonSerializer jsonFormPlants = new DataContractJsonSerializer(typeof(Plant[]));
        DataContractJsonSerializer jsonFormUser = new DataContractJsonSerializer(typeof(User));
        public static string folderPathCurrent = @"C:\Users\Gala\Desktop\Homework\Main\savedGames"; //Environment.CurrentDirectory; // main problem TODO

        internal void Save(User user, Plant[] plants)
        {
            try
            {
                FileWrite(FileName(viewText.chooseGameToSave), user, plants);
                view.Success(viewText.gameSaved);
            }
            catch
            {
                view.Alert(viewText.gameNotSaved);
            }
        }

        void FileWrite(string fileName, User user, Plant[] plants)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormUser.WriteObject(fs, user);
                jsonFormPlants.WriteObject(fs, plants);
            }
        }

        internal void Load(User user, Plant[] plants)//TODO exeption, maybe return back
        {
            try
            {
                FindAndShowNotes();
                FileRead(user, plants);
                view.Success(viewText.gameLoad);
            }
            catch
            {
                view.Alert(viewText.gameNotLoad);
            }
        }

        void FileRead(User user, Plant[] plants)
        {
            using (FileStream fs = new FileStream(FileName(viewText.chooseGameToLoad), FileMode.OpenOrCreate))
            {
                user = (User)jsonFormUser.ReadObject(fs);
                plants = (Plant[])jsonFormPlants.ReadObject(fs);
            }
        }

        internal void Delete()
        {
            try
            {
                FileDelete();
                view.Success(viewText.gameDelete);
            }
            catch
            {
                view.Alert(viewText.gameNotDelete);
            }
        }

        void FileDelete()
        {
            File.Delete(folderPathCurrent + @"\" + FileName(viewText.chooseGameDelete));
        }

        string FileName(string message)
        {
            view.Info(message);
            bool correctUserInput = int.TryParse(view.UserInput(), out int number);

            if (correctUserInput)
                if (number > 0 && number <= 10)
                    return folderPathCurrent + @"\save" + number.ToString() + ".json";
            return null;
        }

        void FindAndShowNotes()
        {
            string[] notes = Directory.GetFiles(folderPathCurrent, "*.txt");
            if (notes.Length == 0)
                view.Info(viewText.emptyFolder);

            for (int i = 0; i < notes.Length; i++)
            {
                FileInfo note = new FileInfo(notes[i]);
                view.Info(i + 1 + ". " + note.Name);
            }
        }
    }
}