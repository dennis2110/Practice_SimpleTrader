using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTranderDbContextFactory : IDesignTimeDbContextFactory<SimpleTranderDbContext>
    {
        public SimpleTranderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTranderDbContext>();

            //SQL Server
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True;");

            //SQLite
            //options.UseSqlite("Data Source=SimpleTraderData.db");

            return new SimpleTranderDbContext(options.Options);
        }
    }
}
