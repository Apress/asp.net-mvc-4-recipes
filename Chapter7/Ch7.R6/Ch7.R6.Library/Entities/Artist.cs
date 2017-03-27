using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.R6.Library.Entities
{

    public partial class Artist
    {
        public Artist()
        {
            this.Country = "USA";
            this.Provence = "New Jersey";
            this.City = "Paterson";
            this.ArtistSkills = new HashSet<ArtistSkill>();
        }

        public int ArtistId { get; set; }

        [MaxLength(256)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Country { get; set; }

        [MaxLength(65)]
        public string Provence { get; set; }

        [MaxLength(50)]
        public string City { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [MaxLength(255)]
        public string WebSite { get; set; }

        public virtual ICollection<ArtistSkill> ArtistSkills { get; set; }
    }
}
