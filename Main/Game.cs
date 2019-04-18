using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Main
{
    class Game
    {
        IView view = new ConsoleView();
        ViewText viewText = new ViewText();

        DataContractJsonSerializer jsonFormPlants = new DataContractJsonSerializer(typeof(Plant[]));
        DataContractJsonSerializer jsonFormUser = new DataContractJsonSerializer(typeof(User));
        readonly string folderPathCurrent = Environment.CurrentDirectory;

        internal void Save(User user, Plant[] plants)
        {
            try
            {
                FileWrite(user, plants);
                view.Success(viewText.gameSaved);
            }
            catch
            {
                view.Alert(viewText.gameNotSaved);
            }
        }

        void FileWrite(User user, Plant[] plants)
        {
            using (FileStream fs = new FileStream(FileName(viewText.chooseGameToSave), FileMode.OpenOrCreate))
            {
                jsonFormUser.WriteObject(fs, user);
                jsonFormPlants.WriteObject(fs, plants);
            }
        }

        internal void Load()
        {
            try
            {
                FileRead();
                view.Success(viewText.gameLoad);
            }
            catch
            {
                view.Alert(viewText.gameNotLoad);
            }
        }

        void FileRead()
        {
            using (FileStream fs = new FileStream(FileName(viewText.chooseGameToLoad), FileMode.OpenOrCreate))
            {
                User user = (User)jsonFormUser.ReadObject(fs);
                Plant[] plant = (Plant[])jsonFormPlants.ReadObject(fs);
            }
        }

        string FileName(string message)
        {
            view.Info(message);
            bool correctUserInput = int.TryParse(view.UserInput(), out int number);

            if (correctUserInput)
                if (number > 0 && number <= 10)
                    return "save" + number.ToString() + ".json";
            return null;
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
            File.Delete(folderPathCurrent + "/" + FileName(viewText.chooseGameDelete));
        }
    }
}
