using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Ch11.R3.Web.Models
{
    [DataContract]
    public class Person
    {
        [DataMember(IsRequired = true)]
        public int PersonId { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        [MaxLength(50)]
        [Display(Name="First Name")]
        [DataMember(IsRequired = true)]
        public string FirstName{get;set; }

        [Required(ErrorMessage ="Last Name is required.")]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.DateTime)]
        [Required]
        [DataMember(IsRequired = true)]
        public DateTime ? AppointmentDate{get;set;}
    }

}