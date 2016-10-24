using System.Data.Entity;

namespace Ch11.R3.Web.Models
{
    public class AppointmentsContext2 : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}