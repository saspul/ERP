using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Notice_Period_Allocation_hcm_Notice_Period_Allocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
            clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenFieldDesgContrl.Value = Session["DSGN_CONTROL"].ToString();
                objEntityNoticePeriod.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
                hiddenFieldDesgContrl.Value = Convert.ToString(objEntityNoticePeriod.DsgControl);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["DSGN_TYPID"] != null)
            {
                objEntityNoticePeriod.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());
                hiddenFieldDesgTypId.Value = Session["DSGN_TYPID"].ToString();                
            }
            else if (Session["DSGN_TYPID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

        }
    }

    [WebMethod]
    public static string Insert_Notice_Period_Details(string StrNoticePrdId, string strDesignationId, string strStatus, string strDays, string UserId, string OrgId, string CorpId)
    {
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

        if(strDesignationId!="")
        {
            objEntityNoticePeriod.DesgntnId = Convert.ToInt32(strDesignationId);
        }
        if (strStatus != "")
        {
            objEntityNoticePeriod.Status = Convert.ToInt32(strStatus);
        }
        if (strDays != "")
        {
            objEntityNoticePeriod.NoticePrdDays = Convert.ToInt32(strDays);
        }
        if (UserId != "")
        {
            objEntityNoticePeriod.UserId = Convert.ToInt32(UserId);
        }
        if (OrgId != "")
        {
            objEntityNoticePeriod.OrgId = Convert.ToInt32(OrgId);
        }
        if (CorpId != "")
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(CorpId);
        }

        objEntityNoticePeriod.UserDate = System.DateTime.Now;

        if (StrNoticePrdId == "")
        {
            objBusinessNoticePeriod.AddNoticePrdDtls(objEntityNoticePeriod);
        }
        else
        {
            objEntityNoticePeriod.NoticePrdId = Convert.ToInt32(StrNoticePrdId);
            objBusinessNoticePeriod.UpdateNoticePrd(objEntityNoticePeriod);
        }       
        return "success";
    }
}