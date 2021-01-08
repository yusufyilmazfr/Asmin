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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key, object obj)
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

        public T Get<T>(string key) where T : class
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
    }
}
