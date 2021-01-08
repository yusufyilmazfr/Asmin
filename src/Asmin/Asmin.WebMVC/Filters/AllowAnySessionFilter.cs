using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asmin.WebMVC.Filters
{
    /// <summary>
    /// AllowAnySessionFilter provides access any action without session.
    /// </summary>
    public class AllowAnySessionFilter : ActionFilterAttribute
    {

    }
}
