using Ch7.SharedAPI;
using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;

namespace Ch10.WebFormsExamples.Web.DataControlExamples
{
    public partial class GridViewExample : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                loadCategories();
            }
        }

        protected void WorkspaceGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            WorkspaceGridView.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void WorkspaceGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            WorkspaceGridView.PageIndex = 0;
            SortExpression = e.SortExpression;
            loadData();
        }

        private string SortExpression
        {
            get
            {
                if (ViewState["SortExpression"] != null)
                {
                    return ViewState["SortExpression"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState.Add("SortExpression", value);
            }
        }

        private int GenreFilterExpressions
        {
            get
            {
                if (Request.QueryString["filter"] != null)
                {
                    int genreNum = 0;
                    Int32.TryParse(Request.QueryString["filter"],out genreNum);
                    return genreNum;
                }
                return 0;
            }
        }

        MobEntities m_DataContext = new MobEntities();
        private void loadCategories()
        {
            var categories = from c in m_DataContext.GenreLookUps
                             orderby c.GenreName
                             select new { c.GenreName , c.GenreLookUpId};
            CategoriesRepeater.DataSource = categories.ToList();
            CategoriesRepeater.DataBind();
        }


        private void loadData()
        {
            var collabSpacesQuery = from a in m_DataContext.CollaborationSpaces
                                     join o in m_DataContext.CollaborationSpaceGenres
                                     on a.CollaborationSpaceId equals o.CollaborationSpaceId
                                     join p in m_DataContext.ArtistCollaborationSpaces
                                     on a.CollaborationSpaceId equals p.CollaborationSpaceId
                                     where a.Status != CollaborationSpaceStatus.Canceled &&
                                     a.Status != CollaborationSpaceStatus.OnHold &&
                                     a.Status != CollaborationSpaceStatus.Published &&
                                     a.AllowPublicView == true &&
                                     p.IsCreator == true
                                     select new
                                     {
                                         a.CollaborationSpaceId,
                                         a.CreateDate,
                                         a.Description,
                                         a.LastPostDate,
                                         a.ModifiedDate,
                                         a.NumberComments,
                                         a.NumberViews,
                                         a.RestrictContributorsToBand,
                                         a.Status,
                                         a.Title,
                                         o.GenreLookUpId,
                                         p.Artist.UserName,
                                         p.Artist.WebSite,
                                         p.Artist.AvatarURL
                                     };


            if (GenreFilterExpressions>0)
            {
                collabSpacesQuery = from a in collabSpacesQuery
                                    where a.GenreLookUpId == GenreFilterExpressions
                                    select a;
            }
            //get rid of duplicates
            collabSpacesQuery = from a in collabSpacesQuery
                                group a by a.CollaborationSpaceId into u
                                select u.FirstOrDefault();

            if (!string.IsNullOrEmpty(SortExpression))
            {
                switch (SortExpression)
                {
                    case "DateCreated":
                        collabSpacesQuery = from a in collabSpacesQuery
                                            orderby a.CreateDate
                                            select a;
                        break;
                    case "DateModified":
                        collabSpacesQuery = from a in collabSpacesQuery
                                            orderby a.ModifiedDate
                                            select a;
                        break;
                    case "ProjectName":
                        collabSpacesQuery = from a in collabSpacesQuery
                                            orderby a.Title
                                            select a;
                        break;
                    case "Artist":
                        collabSpacesQuery = from a in collabSpacesQuery
                                            orderby a.UserName
                                            select a;
                        break;
                    case "Stats":
                        collabSpacesQuery = from a in collabSpacesQuery
                                            orderby a.NumberViews
                                            select a;
                        break;

                }

            }
            IList list = collabSpacesQuery.ToList();
            WorkspaceGridView.DataSource = list;
            WorkspaceGridView.DataBind();
            ProjectsFoundLabel.Text = string.Format("{0} Active online music collaboration projects found.", list.Count);
        }



        public override void Dispose()
        {
            if (m_DataContext != null)
                m_DataContext.Dispose();
            base.Dispose();
        }

    }
}