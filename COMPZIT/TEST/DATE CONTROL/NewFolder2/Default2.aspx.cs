using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TEST_DATE_CONTROL_NewFolder2_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDatePickerInput.Attributes.Add("onkeydown", "return isNumberDate(event)");
        if (!IsPostBack)
        {

        //    txtDatePickerInput.Text = "23-03-2016";
        
        }
    }
}