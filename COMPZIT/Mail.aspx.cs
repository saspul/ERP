using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using MailUtility_ERP;
// CREATED BY:EVM-0001
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the class in UI Layer for accesing MailUtility .

public partial class mail : System.Web.UI.Page
{//Creating object for clsBusinessLayer Mail in in the BusinessLayer
    clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
    //Creating object for clsMail  in in the MailUtility Layer
    clsMail objMail = new clsMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Mail();
        }
    }
    public void Mail()
    {
        DataTable dtCompanyDetail = new DataTable();
        DataTable dtTemplateDetail = new DataTable();
        dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
        objMail.InstantMail("1", ref dtTemplateDetail);
        // save to registration table
        // save to message table
        objBusinessLayerMail.InstantMailInsert("1", "akhilp@volviar.com", "2", dtCompanyDetail, dtTemplateDetail);
        // on success send mail
        objMail.BulkMail("1", "2", dtCompanyDetail);
     //   objMail.BulkMail();
    }
}