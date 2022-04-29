using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory
    {
        private readonly string _connectionString;

        public SimpleTraderDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<SimpleTraderDbContext> options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer(_connectionString);


            //SQL Server
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True;");

            //SQLite
            //options.UseSqlite("Data Source=SimpleTraderData.db");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
