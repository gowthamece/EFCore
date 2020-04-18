using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Domain
{
   public class Department
    {

        public Department()
        {
         //   User = new User();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       // public User User { get; set; } // One to One relationship 
    }
}
