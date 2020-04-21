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
            // context.Database.EnsureCreated();// Don't use this statement in production code
            //Console.WriteLine("---------Before Add----------");
             GetUsers();
            //   AddUser();            
            //Console.WriteLine("----------After Add-----------");
            //GetUsers();
            // UpdateUser();
           // RemoveUser();
            //BatchUpdateUser();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void AddUser()
        {
            var user = new User { Name = "Ramesh" };
            context.Users.Add(user); 
            context.SaveChanges();// Saves all changes made in this context to the database
        }
        public static void GetUsers()
        {                    
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }           
        }
        public static void UpdateUser()
        {
            var user = context.Users.Find(2);
            user.Name += " Kumar";
            context.Users.Update(user);
            context.SaveChanges();
        }
        public static void BatchUpdateUser()
        {
            var users = context.Users.ToList();
            users.ForEach(s => s.Name += "kumar");
            //foreach (var user in users)
            //{
            //    user.Name += " Kumar";
            //}
            context.SaveChanges();
        }

        public static void RemoveUser()
        {
            var user = context.Users.Find(5);
            context.Users.Remove(user);
            context.SaveChanges();
        }

    }
}
