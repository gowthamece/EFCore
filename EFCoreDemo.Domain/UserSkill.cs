using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Domain
{
    public class UserSkill
    {
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
    }
}
