using System;

namespace Saver
{
    public interface IServisSaver
    {
        void Save(string key, object data);
        void Load<T>(string key, Action<T> callback);
        bool HasData(string key);
    }
}
