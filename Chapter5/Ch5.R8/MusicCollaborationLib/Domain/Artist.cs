using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicCollaborationLib.Domain
{
    public class Artist
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Skill PrimarySkill { get; set; }
    }
}
