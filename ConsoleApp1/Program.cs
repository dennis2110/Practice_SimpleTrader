using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            //Console.WriteLine(userService.Delete(1).Result);                   //output:SimpleTrader.Domain.Models.User 
            //Console.WriteLine(userService.Update(1, new User() { Username = "TestUser_update"}).Result);                   //output:SimpleTrader.Domain.Models.User 
            //Console.WriteLine(userService.Get(1).Result);                   //output:SimpleTrader.Domain.Models.User 
            //Console.WriteLine(userService.GetAll().Result.Count());      //output:1
            //userService.Create(new User { Username = "Test" }).Wait();
            Console.ReadLine();
        }
    }
}
