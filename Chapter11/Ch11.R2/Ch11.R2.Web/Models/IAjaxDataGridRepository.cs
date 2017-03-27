using System;
using System.Collections.Generic;

namespace Ch11.R2.Web.Models
{
    public interface IAjaxDataGridRepository: IDisposable
    {

        IList<CollaborationSpaceSearchResult> GetActiveCollaborationSpaces(
            int page, 
            int count, 
            string sortExpression, 
            out int resultsFound);
    }
}
