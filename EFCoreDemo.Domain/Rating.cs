using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Domain
{
   public class Rating
    {              
        public int RatingId { get; set; }
        public string RatingLevel { get; set; }
        public ICollection<User> Users { get; set; } // One to Many Relationship
    }
}
