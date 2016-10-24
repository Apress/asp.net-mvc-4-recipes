using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCollaborationLib.Domain;

namespace MusicCollaborationLib.Repository
{
    public class SampleArtistRepository: IArtistRepository
    {
        #region IArtistRepository Members

        public Artist Create(Artist artist)
        {
            return new Artist { FirstName = "John", LastName = "Ciliberti", PrimarySkill = new Skill {  SkillLevel=11, SkillName="Guitar"} };
        }

        public void Delete(int id)
        {
            //code to delete artist
        }

        public Artist GetArtist(int id)
        {
            return new Artist { FirstName = "John", LastName = "Ciliberti", PrimarySkill = new Skill { SkillLevel = 11, SkillName = "Guitar" } };
        }

        public IEnumerable<Artist> GetArtists()
        {
            //code that returns a list of artists 
            return new List<Artist>();
        }

        #endregion
    }
}
