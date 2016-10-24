using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ch7.SharedAPI;
using System.Text;

namespace Ch10.WebFormsExamples.Web.DataControlExamples
{
    public partial class RepeaterExample : System.Web.UI.Page
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

                ArtistsRepeater.DataSource = newArtistsList;
                ArtistsRepeater.DataBind();
            }
        }

        protected void ArtistsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Artist currentItem = e.Item.DataItem as Artist;
                Label locationLabel = e.Item.FindControl("LocationLabel") as Label;
                if (currentItem != null && locationLabel!=null)
                {
                    StringBuilder builder = new StringBuilder();
                    if (!String.IsNullOrEmpty(currentItem.City))
                    {
                        builder.Append(currentItem.City);
                        builder.Append("<br/>");
                    }
                    if (!String.IsNullOrEmpty(currentItem.Provence))
                    {
                        builder.Append(currentItem.Provence);
                        builder.Append("<br/>");
                    }
                    if (!String.IsNullOrEmpty(currentItem.Country))
                    {
                        builder.Append(currentItem.Country);
                    }
                    locationLabel.Text = builder.ToString();
                }
            }
        }
    }
}