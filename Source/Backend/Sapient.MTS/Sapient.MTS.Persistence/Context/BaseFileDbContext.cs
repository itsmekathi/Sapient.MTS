using Newtonsoft.Json;
using System.IO;

namespace Sapient.MTS.Persistence.Context
{
    public abstract class BaseFileDbContext<T>
    {
        public BaseFileDbContext(string filePath)
        {
            _filePath = filePath;
        }
        private string _filePath { get; set; }

        protected virtual T LoadData()
        {
            if (!File.Exists(_filePath))
            {
                CreateEmptyFile();
            }

            string fileContents;
            using (StreamReader file = File.OpenText(_filePath))
            {
                fileContents = file.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(fileContents);

        }
        protected virtual void SaveChanges(T items)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(items));

        }
        private void CreateEmptyFile()
        {
            File.WriteAllText(_filePath, "[]");
        }
    }
}
