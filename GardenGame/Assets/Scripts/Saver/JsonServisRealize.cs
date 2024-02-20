using System;
using System.IO;
using UnityEngine;

namespace Saver
{
    public class JsonServisRealize : IServisSaver
    {
        public void Save(string key, object data)
        {
            string path = BuildPath(key);
            var json = JsonUtility.ToJson(data);

            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
            }

        }
        

        public void Load<T>(string key, Action<T> callback)
        {
            string path = BuildPath(key);
            
           
            using (var fileStream = new StreamReader(path))
            {

                var read = fileStream.ReadToEnd();
                var json = JsonUtility.FromJson<T>(read);
                callback?.Invoke(json);
            }
        }

        public bool HasData(string key)
        {
            string path = BuildPath(key);
            return File.Exists(path);
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
