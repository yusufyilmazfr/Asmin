using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Hashing.Core.Service;
using AsminSHA256 = System.Security.Cryptography.SHA256;

namespace Asmin.Packages.Hashing.SHA256.Service
{
    /// <summary>
    /// SHA256 hash service.
    /// </summary>
    public class SHA256HashService : IHashService
    {
        public string Generate(string plainText)
        {
            using (AsminSHA256 sha256Hash = AsminSHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Compare(string hashedText, string plainText)
        {
            return Generate(plainText) == hashedText;
        }
    }
}
