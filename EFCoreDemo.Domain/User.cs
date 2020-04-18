using System.Collections.Generic;

namespace EFCoreDemo.Domain
{
    public class User
    {
        public User()
        {
               UserSkills = new List<UserSkill>();
               Address = new Address();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Rating Rating { get; set; } // one to Many Relationship
        public List<UserSkill> UserSkills { get; set; } // Many to Many Relationship 
        public Address Address { get; set; } // One to One Relationship
    }
}
