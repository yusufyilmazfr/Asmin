using Asmin.Core.Entities.Concrete;
using Asmin.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Context;

namespace Asmin.DataAccess.Concrete.EntityFramework.Context
{
    /// <summary>
    /// AsminDbContext contains database entities.
    /// </summary>
    public class AsminDbContext : DbContext
    {
        private readonly string _connectionString;

        public AsminDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<IncomingVisitor> IncomingVisitors { get; set; }

        /// <summary>
        /// Asmin provides normally MySQL.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder instance.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString);
        }
    }
}
