using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();

            //SQL Server
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True;");

            //SQLite
            //options.UseSqlite("Data Source=SimpleTraderData.db");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
