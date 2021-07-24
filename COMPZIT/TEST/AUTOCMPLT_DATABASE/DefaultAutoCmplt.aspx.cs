using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TEST_AUTOCMPLT_DATABASE_DefaultAutoCmplt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenDivisionIds.Value = "0";
            hiddenCorporateId.Value = "162";
            hiddenOrganisationId.Value = "102";
            hiddenLimtdMod.Value = "1";
        
        }
    }

    protected void Submit(object sender, EventArgs e)
    {
        string customerName = Request.Form[txtSearch.UniqueID];
        string customerId = Request.Form[hfFocusSelectPrdctId.UniqueID];
    }

}