using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch10.WebFormsExamples.Web.Forms
{
    public partial class CustomValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                MessageLabel.Text = "Form is valid";
            }
            else
            {
                MessageLabel.Text = "Form is not valid";
            }
        }
    }
}