using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch7.R7_2.Models
{
    public class SongCollaborationWorkspaceListModel
    {
        [Display(Name = "Number of Workspaces Found: ")]
        public int NumberofMatchingWorkspaces { get; set; }
        public List<CollaborationSpace> CollaborationSpaces { get; set; }
    }
}