using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asmin.Packages.JWT.Filters
{
    /// <summary>
    /// It provides to ignore token control.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AsminIgnoreTokenAuthFilter : ActionFilterAttribute
    {
    }
}
