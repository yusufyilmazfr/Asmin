using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
