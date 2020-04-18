using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Domain
{
   public class Skill
    {
        public Skill()
        {
            UserSkills = new List<UserSkill>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserSkill> UserSkills { get; set; }// Many to Many mapping 
    }
}
