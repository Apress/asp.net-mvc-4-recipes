using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.R6.Library.Entities
{

    public partial class ArtistSkill
    {
        public ArtistSkill()
        {
            this.TalentName = "\"Guitar\"";
            this.SkillLevel = 0;
        }

        public int ArtistSkillId { get; set; }
        [MaxLength(50)]
        public string TalentName { get; set; }

        public int SkillLevel { get; set; }

        [MaxLength(500)]
        public string Details { get; set; }

        [MaxLength(500)]
        public string Styles { get; set; }

        public int YearsExperience { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
