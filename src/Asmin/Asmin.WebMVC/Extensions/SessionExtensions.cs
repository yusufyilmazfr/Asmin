using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object obj)
        {
            var objText = JsonConvert.SerializeObject(obj);
            session.SetString(key, objText);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            var objText = session.GetString(key);
            return objText == null ? null : JsonConvert.DeserializeObject<T>(objText);
        }
    }
}
