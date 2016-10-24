using Microsoft.AspNet.Mvc.Facebook.Attributes;
using Microsoft.AspNet.Mvc.Facebook.Models;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// https://developers.facebook.com/docs/reference/api/user/

namespace Ch12.R9.Web.Models
{
    public class MyAppUser : FacebookUser
    {
        public string Name { get; set; }

        [FacebookField(FieldName = "picture", JsonField = "picture.data.url")]
        public string PictureUrl { get; set; }

        public string Email { get; set; }
    }
}
