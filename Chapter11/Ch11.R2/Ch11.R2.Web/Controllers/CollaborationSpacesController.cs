using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ch11.R2.Web.Models;

namespace Ch11.R2.Web.Controllers
{
    public class CollaborationSpacesController : ApiController
    {


        IAjaxDataGridRepository m_repository;

        public CollaborationSpacesController(IAjaxDataGridRepository respository)
        {
            m_repository = respository;
        }

        //constructor required by MVC Framework
        // uses the EFArchitectRepository as the default controller
        public CollaborationSpacesController() : this(new EFAjaxDataGridRepository()) { }

        // GET api/CollaborationSpaces?Page=1&SortExpression=CreateDate
        public CollaborationSpaceSearchResultModel Get(int? Page, string SortExpression)
        {
            int resultsFound;
            int page = Page ?? 1;
            string sortExpression = SortExpression ?? "CreateDate";
            var model = new CollaborationSpaceSearchResultModel();
            model.CollaborationSpaceSearchResults = m_repository.GetActiveCollaborationSpaces(page, 10, SortExpression, out resultsFound);
            model.NumberOfResults = resultsFound;
            model.ItemsPerPage = 10;
            model.CurrentPage = page;
            model.SortExpression = sortExpression;
            return model;
        }

      
    }
}