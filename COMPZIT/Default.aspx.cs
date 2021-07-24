using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // Response.Redirect("~/FINANCE/Fn_Security/Fn_Login.aspx");
      Response.Redirect("~/Security/Login.aspx"); 
    }
}