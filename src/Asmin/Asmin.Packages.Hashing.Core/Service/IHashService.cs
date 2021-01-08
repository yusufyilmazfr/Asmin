using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.Hashing.Core.Service
{
    /// <summary>
    /// Hash service provides generate and compare methods signatures.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Generate hash.
        /// </summary>
        /// <param name="plainText">Plain text for hashing.</param>
        /// <returns></returns>
        string Generate(string plainText);
        /// <summary>
        /// Compare hashed text equals plain text.
        /// </summary>
        /// <param name="hashedText">Hashed text.</param>
        /// <param name="plainText">Plain text.</param>
        /// <returns></returns>
        bool Compare(string hashedText, string plainText);
    }
}
