using Ch7.SharedAPI;
using System.Collections.Generic;

namespace Ch10.Mvc.Web.Models
{
    public class InlineEditingArtistSkillListModel
    {
        public int SelectedRow { get; set; }
        public List<ArtistSkill> ArtistSkillList { get; set; }
        public bool IsSelected(ArtistSkill item)
        {
            if (item == null)
                return false;
            return item.ArtistTalentID == SelectedRow;
        }
    }
}