using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.Hash
{
    public interface IHashService
    {
        string CreateHash(string text);
        bool Compare(string hashedText, string plainText);
    }
}
