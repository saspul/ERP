using System;
using BL_Compzit;
using EL_Compzit;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

// CREATED BY:EVM-0001
// CREATED DATE:22/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Org_Approval_Pending_gen_Org_ApprovalAdd : System.Web.UI.Page
{
    //Creating objects for business layer.
    clsBusinessLayerApproval objBusinessLayerApproval = new clsBusinessLayerApproval();
    protected void Page_Load(object sender, EventArgs e)
    {

        txtOrgName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgAdd1.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgAdd2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgAdd3.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgCountryName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgStateName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgCityName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgZip.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgPhone.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgMobile.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgWebsite.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgEmail.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgLicPac.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgLicPacCount.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgCorPac.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtOrgCorPacCount.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {

            if (Request.QueryString["ViewParkId"] != null)
            {
                lblEntry.Text = "View Organization";

                //When view button is clicked
                clsEntityLayerApproval objEntityAprvl = new clsEntityLayerApproval();

                string strRandomMixedId = Request.QueryString["ViewParkId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityAprvl.Park_id = Convert.ToInt32(strId);
                DataTable dtOrg = objBusinessLayerApproval.Select_Organisation(objEntityAprvl);
                //After fetch organisation details in datatable,we need to differentiate.
                txtOrgName.Text = dtOrg.Rows[0]["ORG_PARK_NAME"].ToString();
                txtOrgType.Text = dtOrg.Rows[0]["ORGCTY_NAME"].ToString();
                txtOrgAdd1.Text = dtOrg.Rows[0]["ORG_PARK_ADDR1"].ToString();
                txtOrgAdd2.Text = dtOrg.Rows[0]["ORG_PARK_ADDR2"].ToString();
                txtOrgAdd3.Text = dtOrg.Rows[0]["ORG_PARK_ADDR3"].ToString();
                txtOrgCountryName.Text = dtOrg.Rows[0]["CNTRY_NAME"].ToString();
                txtOrgStateName.Text = dtOrg.Rows[0]["STATE_NAME"].ToString();
                txtOrgCityName.Text = dtOrg.Rows[0]["CITY_NAME"].ToString();
                txtOrgZip.Text = dtOrg.Rows[0]["ORG_PARK_ZIP"].ToString();
                txtOrgPhone.Text = dtOrg.Rows[0]["ORG_PARK_PHONE"].ToString();
                txtOrgMobile.Text = dtOrg.Rows[0]["ORG_PARK_MOBILE"].ToString();
                txtOrgWebsite.Text = dtOrg.Rows[0]["ORG_PARK_WEBSITE"].ToString();
                txtOrgEmail.Text = dtOrg.Rows[0]["ORG_PARK_EMAIL"].ToString();
                txtOrgLicPac.Text = dtOrg.Rows[0]["LIC_PACK_NAME"].ToString();
                txtOrgLicPacCount.Text = dtOrg.Rows[0]["ORG_PARK_LICENSE_COUNT"].ToString();
                txtOrgCorPac.Text = dtOrg.Rows[0]["CORP_PACK_NAME"].ToString();
                txtOrgCorPacCount.Text = dtOrg.Rows[0]["ORG_PARK_CORP_COUNT"].ToString();
            }
        }
    }
   
}