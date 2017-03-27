using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Ch9.R8.Web.Models
{

    public class Architect
    {

        public int ArchitectId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public string URL { get; set; }

    }

    public class ArchitectContext : DbContext
    {
        public DbSet<Architect> Architects { get; set; }
    }

}