using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Session
{
    /// <summary>
    /// Register your session data and use it.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Set data to session.
        /// </summary>
        /// <param name="key">Session unique key.</param>
        /// <param name="obj">Session data.</param>
        void Set(string key, object obj);

        /// <summary>
        /// Get data. Returns default when key not found.
        /// </summary>
        /// <typeparam name="T">Data type.</typeparam>
        /// <param name="key">Unique key.</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;

        /// <summary>
        /// Remove data from session when key exists.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// Check specified key exists in session.
        /// </summary>
        /// <param name="key">Unique key.</param>
        /// <returns></returns>
        bool Any(string key);

        /// <summary>
        /// Clear all data from session.
        /// </summary>
        void Clear();
    }
}
