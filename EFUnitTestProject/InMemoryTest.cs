using EFCoreDemo.Data;
using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Xunit.Sdk;

namespace EFUnitTestProject
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void InMemoryAddEntityTest()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("UserInsert");
            using (var context = new AppDBContext(builder.Options))
            {
                var user = new User();
                context.Users.Add(user);               
                Assert.AreEqual(EntityState.Added, context.Entry(user).State);

            }
        }
    }
}

//Debug.WriteLine($"Before Save :{user.Id}");
//                context.SaveChanges();
//                Debug.WriteLine($"After Save:{user.Id}");
//                Assert.AreNotEqual(0, user.Id);
// Assert.AreEqual(EntityState.Added, context.Entry(user).State);
