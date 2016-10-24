using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch10.WebFormsExamples.Web.DataControlExamples
{
    public partial class DataListExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (MobEntities context = new MobEntities())
            {
                //last 20 Artist records created
                var newArtistsQuery = (from m in context.Artists
                                       orderby m.CreateDate descending
                                       select m).Take(20);
                List<Artist> newArtistsList = newArtistsQuery.ToList<Artist>();

                NewArtistDataList.DataSource = newArtistsList;
                NewArtistDataList.DataBind();
            }
        }
    }
}