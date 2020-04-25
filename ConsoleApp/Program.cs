using EFCoreDemo.Data;
using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            // GetUsers();
            //   AddUser();            
            //Console.WriteLine("----------After Add-----------");
            //GetUsers();
            // UpdateUser();
            // RemoveUser();
            //BatchUpdateUser();
            //AddUserWithRating();
            //AddRatingtoExistingUsers();
            // EargerLoadingWithRating();
            //ProjectionLoadingWithRating();
            QueryFilteringWithRating();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void AddUser()
        {
            var user = new User { Name = "Ramesh" };
            context.Users.Add(user); 
            context.SaveChanges();// Saves all changes made in this context to the database
        }
        public static void AddUserWithRating()
        {
            var user = new User
            {
                Name = "Saravanan",
                
                Rating = new Rating {RatingLevel="A"}
                
            };
            context.Users.Add(user);
            context.SaveChanges();// Saves all changes made in this context to the database
        }
        public static void AddRatingtoExistingUsers()
        {
            var user = context.Users.ToList();
            context.Ratings.Add(new Rating
            {
                RatingLevel = "B",
                Users = user
            });
            context.SaveChanges();
        }
        public static void EargerLoadingWithRating()
        {
            var ratings = context.Ratings.Include(r => r.Users).ToList();
            var rating = context.Ratings.Include(r => r.Users).FirstOrDefault(u=>u.RatingLevel=="B");
        }

        public static void ProjectionLoadingWithRating()
        {
            //var ratings = context.Ratings.Select(s => new { s.RatingLevel, s.Users }).ToList();
            var ratings = context.Ratings.Select(r => new { ratings=r , B_rating= r.Users.Where(q=>q.Name.Contains("gow"))}).ToList();

            var rating = ratings[1].ratings.RatingLevel += "*";
        }

        public static void QueryFilteringWithRating()
        {
            //var ratings = context.Ratings.Select(s => new { s.RatingLevel, s.Users }).ToList();
            var ratings = context.Ratings.Where(r => r.Users.Any(q=>q.Name.Contains("gow"))).ToList();

            
        }

        //public static void AddRatingtoExistingUsers1()
        //{
        //    var rating = context.Ratings.Find(2);
        //    rating.Users.Add(new User
        //    {
        //        Name="Ramu"
        //    });
        //    using (var newContext)
        //    context.SaveChanges();
        //}
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
