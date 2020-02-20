using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Session
{
    public interface ISessionService
    {
        void SetObject(string key, object obj);
        T GetObject<T>(string key) where T : class;
        void SetInt32(string key, int value);
        int? GetInt32(string key);
        void SetString(string key, string value);
        string GetString(string key);
        void Remove(string key);
        bool Any(string key);
        void Clear();
    }
}
