using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using ToDoListApp.Models;

namespace ToDoListApp.IOServices
{
    internal sealed class IOService
    {
        public string FilePath => Path.Combine($"{System.Environment.CurrentDirectory}", "ToDoDataList.json");

        public void CreateFileIfItDoesNotExists()
        {
            if (!File.Exists(this.FilePath))
            {
                File.CreateText(this.FilePath).Dispose();
            }
        }

        public BindingList<ToDoModel> LoadData()
        {
            using (StreamReader reader = File.OpenText(this.FilePath))
            {
                string fileContent = reader.ReadToEnd();
                return this.GetOrCreateBindingList(fileContent);
            }
        }

        private BindingList<ToDoModel> GetOrCreateBindingList(string fileContent)
        {
            return (fileContent.Length > 0) ?
                    JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileContent) : new BindingList<ToDoModel>();
        }

        public void SaveData(object ToDoDataList)
        {
            using (var writer = File.CreateText(this.FilePath))
            {
                writer.Write(JsonConvert.SerializeObject(ToDoDataList));
            }
        }
    }
}