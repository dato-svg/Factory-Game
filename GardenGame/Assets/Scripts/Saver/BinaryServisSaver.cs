using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saver
{
    public class BinaryServisSaver : IServisSaver
    {
    
        public void Save(string key, object data)
        {
            string path = BuildPath(key);
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(path,FileMode.Create))
            {
                formatter.Serialize(fileStream,data);
            }
        
        }

        public void Load<T>(string key, Action<T> callback)
        {
            string path = BuildPath(key);
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(path,FileMode.Open))
                {
                    var data = (T)formatter.Deserialize(fileStream);
                    callback?.Invoke(data);
                }
            }
        
      
        }

        public bool HasData(string key)
        {
            throw new NotImplementedException();
        }


        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
