using Asmin.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.DataAccess.Concrete.EntityFramework.Context
{
    public class AsminDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private const string CONNECTION_STRING = "Server=YUSUF;Database=Asmin;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
