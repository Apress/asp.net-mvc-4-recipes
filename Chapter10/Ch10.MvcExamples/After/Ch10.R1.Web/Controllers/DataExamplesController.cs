using Ch10.Mvc.Web.Models;
using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ch10.Mvc.Web.Controllers
{
    public class DataExamplesController : Controller
    {
        private IDataExampleRepository m_repository;
        public DataExamplesController(IDataExampleRepository repository)
        {
            m_repository = repository;
        }
        public DataExamplesController()
            : this(new EFDataExchangeRepository())
        {
        }
        //
        // GET: /DataExamples/

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult RepeaterReplacement()
        {

            List<Artist> newArtistsList = m_repository.GetNewArtistList();
            
            return View("RepeaterReplacement", newArtistsList);
        }

        public ActionResult DataListReplacement()
        {
            List<Artist> newArtistsList = m_repository.GetNewArtistList();

            return View("DataListReplacement", newArtistsList);
        }

        public ActionResult GridViewReplacement(int? Page, string SortExpression, bool? Accending, int? CategoryId)
        {
            //Set default values for all optional  parameters
            //int page = Page.HasValue ? Page.Value : 1;
            int page = Page ?? 1;
            string sortExpression = string.IsNullOrEmpty(SortExpression) ? "CreateDate" : SortExpression;
            bool useDefaultSort = Accending.HasValue ? Accending.Value : true;
            int categoryId = CategoryId.HasValue ? CategoryId.Value : 0;
            int resultsFound=0;
            // set up model
            CollaborationSpaceSearchResultModel model = new CollaborationSpaceSearchResultModel();

            
            model.CollaborationSpaceSearchResults = m_repository.GetActiveCollaborationSpaces(page, 10, sortExpression, categoryId, useDefaultSort, out resultsFound);
            model.GenreLookUpList = m_repository.GetGenreLookupList();
            model.NumberOfResults = resultsFound;
            model.CurrentPage = page;
            model.ItemsPerPage = 10;
            model.CategoryId = categoryId;
            model.SortExpression = sortExpression;
            return View("GridViewReplacement", model);
        }

        public ActionResult GridViewReplacementWithInplaceEditing(int ? Selected)
        {
            //hard code artistId for this example
            var skills = m_repository.GetArtistSkills(2);
            var model = new InlineEditingArtistSkillListModel();
            model.ArtistSkillList = skills;
            if (Selected.HasValue)
            {
                model.SelectedRow = Selected.Value;
            }
            return View("GridViewReplacementWithInplaceEditing", model);
        }

        [HttpPost]
        public ActionResult GridViewReplacementWithInplaceEditing(FormCollection collection)
        {
            ArtistSkill skill = new ArtistSkill();
            skill.ArtistId = Int32.Parse(collection["item.ArtistId"]);
            skill.ArtistTalentID = Int32.Parse(collection["item.ArtistTalentID"]);
            skill.TalentName = collection["item.TalentName"];
            skill.SkillLevel = Int32.Parse(collection["item.SkillLevel"]);
            skill.Details = collection["item.Details"];
            skill.Styles = collection["item.Styles"];
            m_repository.UpdateSkill(skill);
            return RedirectToAction("GridViewReplacementWithInplaceEditing");
        }

        public ActionResult GridViewReplacementWithInplaceEditingv2(int? Selected)
        {
            //hard code artistId for this example
            var skills = m_repository.GetArtistSkills(2);
            var model = new InlineEditingArtistSkillListModel();
            model.ArtistSkillList = skills;
            if (Selected.HasValue)
            {
                model.SelectedRow = Selected.Value;
            }
            return View("GridViewReplacementWithInplaceEditingv2", model);
        }

        [HttpPost]
        public ActionResult GridViewReplacementWithInplaceEditingv2(InlineEditingArtistSkillListModel model)
        {
            m_repository.UpdateSkill(model.ArtistSkillList[model.SelectedRow]);
            return RedirectToAction("GridViewReplacementWithInplaceEditingv2");
        }


        public ActionResult MasterDetailsView(int ? SelectedItemId)
        {
            List<Artist> newArtistsList = m_repository.GetNewArtistList();
            var model = new ArtistMasterDetailsModel();
            model.ArtistList = newArtistsList;
            if (SelectedItemId.HasValue)
            {
                model.SelectedArtist = newArtistsList.Find(a => a.ArtistId == SelectedItemId.Value);
                model.SelectedArtistId = SelectedItemId.Value;
            }

            return View("MasterDetailsView", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_repository != null)
                    m_repository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
