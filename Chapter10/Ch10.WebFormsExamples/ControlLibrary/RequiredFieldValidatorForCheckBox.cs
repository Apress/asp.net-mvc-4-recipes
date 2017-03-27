using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ch10.WebFormsExamples.ControlLibrary
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RequiredFieldValidatorForCheckBox runat=server></{0}:RequiredFieldValidatorForCheckBox>")]
    public class RequiredFieldValidatorForCheckBox : BaseValidator
    {
        private CheckBox _listctrl;

        public RequiredFieldValidatorForCheckBox()
        {
            base.EnableClientScript = false;
        }

        protected override bool ControlPropertiesValid()
        {
            Control ctrl = FindControl(ControlToValidate);

            if (ctrl != null)
            {
                _listctrl = (CheckBox)ctrl;
                return (_listctrl != null);
            }
            else
                return false;  // raise exception
        }


        protected override bool EvaluateIsValid()
        {
            return _listctrl.Checked;
        }

    }
}
