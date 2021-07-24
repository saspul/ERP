using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit.BusineesLayer_HCM;

public partial class MasterPage_MasterPageHcmCandidate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
   
        DataTable Dtcandidate = objBusiness_Candidate_Login.Checklogin(objEntityCandRegistr);


        if (Session["CANDNAME"] != null)
            {
             //   btnsignout.Visible = true;
                string strId = Session["CANDNAME"].ToString();
            lblUserName.Text = strId;
            hiddenlogout.Value = "loggedin";
        }
        else
            hiddenlogout.Value = "";
   
             
       
    }
}
