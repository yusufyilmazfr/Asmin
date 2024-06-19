using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.AOP.Attributes
{
    /// <summary>
    /// Reflection sometimes throws exception like 'Ambiguous match found' when creating instance. It attribute ignores class when interceptor loaded.
    /// </summary>
    public class IgnoreAOPAttribute : Attribute
    {

    }
}
