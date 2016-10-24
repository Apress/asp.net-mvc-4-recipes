using Ch7.SharedAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10.Mvc.Web.Models
{
    public interface IDataExampleRepository: IDisposable
    {
        List<Artist> GetNewArtistList();
        Artist GetArtistDetails(int id);
        IList<CollaborationSpaceSearchResult> GetActiveCollaborationSpaces(int page, int count, string sortExpression, int categoryId, bool useDefaultSort, out int resultsFound);
        IList<GenreLookUp> GetGenreLookupList();

        List<ArtistSkill> GetArtistSkills(int artistId);
        void UpdateSkill(ArtistSkill skill);
        void CreateSkill(ArtistSkill skill);
        void DeleteSkill(int artistSkillId);

        void CreateAds(OpenPositionsNeeded openPositionsNeeded);

        void Save();

        void CreateCollaborationSpace(CollaborationSpace collaborationSpace);
    }
}
