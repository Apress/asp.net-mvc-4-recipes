using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10.Mvc.Web.Models
{
    public interface IDataExampleRepository
    {
        IEnumerable<Artist> GetNewArtistList();
        Artist GetArtistDetails(int id);
        IQueryable<OpenPosition> GetOpenPositions(int page, int count);

        void UpdateSkill(ArtistSkill skill);
        void CreateSkill(ArtistSkill skill);
        void DeleteSkill(int ArtistId, int SkillId);

        void CreateCollaborationSpace(CollaborationSpace collaborationSpace);
        void UpdateCollaborationSpace(CollaborationSpace collaborationSpace);
    }
}
