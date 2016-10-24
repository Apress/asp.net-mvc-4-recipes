using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace Ch5.R5_8.CustomReg.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", 
            ErrorMessage="Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        

        [Required]
        [Display(Name = "Primary Instrument")]
        public string SelectedPrimaryInstrument { get; set; }

        public IEnumerable<InstrumentItem> InstrumentItems
        {
            get {
                return new List<InstrumentItem>
                {
                    new InstrumentItem{ Text="Please Select", Value=""},
                    new InstrumentItem{ Text="Bass Guitar", Value="Bass Guitar"},
                    new InstrumentItem{ Text="Clarinet", Value="Clarinet"},
                    new InstrumentItem{ Text="DJ", Value="DJ"},
                    new InstrumentItem{ Text="Drums", Value="Drums"},
                    new InstrumentItem{ Text="Flute", Value="Flute"},
                    new InstrumentItem{ Text="Guitar", Value="Guitar"},
                    new InstrumentItem{ Text="Harmonica", Value="Harmonica"},
                    new InstrumentItem{ Text="Keyboards", Value="Keyboards"},
                    new InstrumentItem{ Text="Lyricist", Value="Lyricist"},
                    new InstrumentItem{ Text="Producer", Value="Producer"},
                    new InstrumentItem{ Text="Saxophone", Value="Saxophone"},
                    new InstrumentItem{ Text="Songwriter", Value="Songwriter"},
                    new InstrumentItem{ Text="Trumpet", Value="Trumpet"},
                    new InstrumentItem{ Text="Vocal", Value="Vocal"},                
                    
                };
            }
        }
    }

    public class InstrumentItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
   
}
