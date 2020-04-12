using EFCoreDemo.Data;
using EFCoreDemo.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static readonly AppDBContext context = new AppDBContext(); 
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();// Don't use this statement in production code
            Console.WriteLine("---------Before Add----------");
            GetUsers();
            AddUser();            
            Console.WriteLine("----------After Add-----------");
            GetUsers();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void AddUser()
        {
            var user = new User { Name = "Gowtham" };
            context.Users.Add(user); // Add user record in database 
            context.SaveChanges();// Saves all changes made in this context to the database
        }
        public static void GetUsers()
        {
            var users = context.Users.ToList();
            Console.WriteLine($"User count is {users.Count}");
            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
