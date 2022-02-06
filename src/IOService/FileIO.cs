using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using ToDoListApp.Model;

namespace ToDoListApp.IOService
{
    public sealed class FileIO
    {
        public string FilePath => Path.Combine($"{System.Environment.CurrentDirectory}", "ToDoDataList.json");

        public FileIO() { }

        public BindingList<ToDoModel> LoadData()
        {
            if (!File.Exists(FilePath))
            {
                File.CreateText(FilePath).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (StreamReader Reader = File.OpenText(FilePath))
            {
                string FileText = Reader.ReadToEnd();

                return FileText.Length > 0 ? JsonConvert.DeserializeObject<BindingList<ToDoModel>>(FileText) : new BindingList<ToDoModel>();
            }
        }

        public void SaveData(object ToDoDataList)
        {
            using (StreamWriter Writer = File.CreateText(FilePath))
            {
                Writer.Write(JsonConvert.SerializeObject(ToDoDataList));
            }
        }
    }
}