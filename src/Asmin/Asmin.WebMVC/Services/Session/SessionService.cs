using Asmin.WebMVC.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Session
{
    public class SessionService : ISessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetObject(string key, object obj)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, obj);
        }

        public bool Any(string key)
        {
            return _httpContextAccessor.HttpContext.Session.Get(key) != null;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public T GetObject<T>(string key) where T : class
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<T>(key);
        }

        public void Remove(string key)
        {
            if (Any(key))
            {
                _httpContextAccessor.HttpContext.Session.Remove(key);
            }
        }

        public void SetInt32(string key, int value)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }

        public int? GetInt32(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32(key);
        }

        public void SetString(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string GetString(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
