using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Other_Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        txtToDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtToDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtFromDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDescription.Attributes.Add("onkeypress", "return isTag(event)");
        txtDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStatusType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
            clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
            StatusTypeLoad();
            btnAssign.Visible = false;
            btnUpdate.Visible = false;
            ddlStatusType.Focus();
            ddlStatus.Items.Clear();
            ddlStatus.Items.Insert(0, "--SELECT--");
            if (Request.QueryString["VehId"] != null)
            {
                lblEntry.Text = "Add Vehicle Status";
                hiddenMode.Value = "ADD";
                hiddenVehicleId.Value = Request.QueryString["VehId"].ToString();
                btnAssign.Visible = true;
                objEntityVehicle.VehicleId = Convert.ToInt32(Request.QueryString["VehId"].ToString());
                objEntityVehicle.VehAsignId = 0;

                DataTable dtVehicleName = objBusinessVehicle.ReadVehNumber(objEntityVehicle);
                if (dtVehicleName.Rows.Count > 0)
                {
                    lblVehicleNum.Text =dtVehicleName.Rows[0]["VHCL_NUMBR"].ToString();
                }
            }
            if (Request.QueryString["VehAsgn"] != null)
            {
                lblEntry.Text = "Edit Vehicle Status";
                hiddenMode.Value = "EDIT";
                string strVehAsgnId = Request.QueryString["VehAsgn"].ToString();
                string[] strSplit = strVehAsgnId.Split(',');

                int VehAsgnId = Convert.ToInt32(strSplit[0]);
                hiddenVehicleId.Value = strSplit[1];
                btnUpdate.Visible = true;


                objEntityVehicle.VehAsignId = Convert.ToInt32(Convert.ToInt32(strSplit[0]));
                objEntityVehicle.VehicleId = 0;
                DataTable dtVehicleName = objBusinessVehicle.ReadVehNumber(objEntityVehicle);
                if (dtVehicleName.Rows.Count > 0)
                {
                    lblVehicleNum.Text = dtVehicleName.Rows[0]["VHCL_NUMBR"].ToString();
                }
                Update(VehAsgnId);
            }

            if (Request.QueryString["Back"] != null)
            {
                HiddenBackPage.Value = Request.QueryString["Back"].ToString();
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
            }

            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;
        }

    }

    public void StatusTypeLoad()
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtStsType = new DataTable();
        dtStsType = objBusinessVehicle.ReadVehicleStatsType(objEntityVehicle);
        if (dtStsType.Rows.Count > 0)
        {
            if (dtStsType.Rows.Count == 1)
            {
                ddlStatusType.DataSource = dtStsType;
                ddlStatusType.DataValueField = "VHCLSTSTYP_ID";
                ddlStatusType.DataTextField = "VHCLSTSTYP_NAME";
                ddlStatusType.DataBind();


                ddlStatusType.Items.FindByValue(dtStsType.Rows[0]["VHCLSTSTYP_ID"].ToString()).Selected = true;
                objEntityVehicle.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
                DataTable dtVehSts = new DataTable();
                dtVehSts = objBusinessVehicle.ReadVehicleStats(objEntityVehicle);
                if (dtVehSts.Rows.Count > 0)
                {
                    ddlStatus.DataSource = dtVehSts;
                    ddlStatus.DataValueField = "VHCLSTS_ID";
                    ddlStatus.DataTextField = "VHCLSTS_NAME";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, "--SELECT--");
                }
            }
            else
            {
                ddlStatusType.DataSource = dtStsType;
                ddlStatusType.DataValueField = "VHCLSTSTYP_ID";
                ddlStatusType.DataTextField = "VHCLSTSTYP_NAME";
                ddlStatusType.DataBind();
                ddlStatusType.Items.Insert(0, "--SELECT--");
            }
        }
        //ddlStatus.Items.Insert(0, "--SELECT--");
    }
    protected void ddlStatusType_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlStatusType.SelectedItem.Text != "--SELECT--")
        {
            objEntityVehicle.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
            ddlStatus.Items.Clear();
            ddlStatus.Items.Insert(0, "--SELECT--");
        }

        DataTable dtVehSts = new DataTable();
        dtVehSts = objBusinessVehicle.ReadVehicleStats(objEntityVehicle);
        if (dtVehSts.Rows.Count > 0)
        {
            ddlStatus.Items.Clear();
            ddlStatus.DataSource = dtVehSts;
            ddlStatus.DataValueField = "VHCLSTS_ID";
            ddlStatus.DataTextField = "VHCLSTS_NAME";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, "--SELECT--");
        }
        else
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Insert(0, "--SELECT--");
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlFocus", "ddlFocus();", true);
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_ASSIGN);
        objEntityCommon.CorporateID = objEntityVehicle.CorporateId;
        objEntityCommon.Organisation_Id = objEntityVehicle.Org_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityVehicle.NextIdForAssign = Convert.ToInt32(strNextId);

        objEntityVehicle.VehicleId = Convert.ToInt32(hiddenVehicleId.Value);
        objEntityVehicle.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
        objEntityVehicle.VehicleSts = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntityVehicle.VehicleAgnDescriptn = txtDescription.Text.Trim();
        if(txtFromDate.Text.Trim()!="")
        {
        objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text.Trim()!="")
        {
        objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }
        objEntityVehicle.Cnfrm_Sts = 0;

        objBusinessVehicle.AddAssignVehicle(objEntityVehicle);
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {

            Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "&InsUpd=InsOther");
         }
          else
         {
         Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=InsOther");
         }
          
       
    }

    public void Update(int VehAsgnId)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Management);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {

                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }

            }
        }

        objEntityVehicle.VehAsignId = VehAsgnId;

        DataTable dtAsignDetail = new DataTable();
        dtAsignDetail = objBusinessVehicle.ReadVehicleAssignDetailsById(objEntityVehicle);
        if (dtAsignDetail.Rows.Count > 0)
        {
            txtFromDate.Text = dtAsignDetail.Rows[0]["FROM_DATE"].ToString();
            txtToDate.Text = dtAsignDetail.Rows[0]["TO_DATE"].ToString();
            txtDescription.Text = dtAsignDetail.Rows[0]["VHCLASGN_DESCPTN"].ToString();

          
                if (dtAsignDetail.Rows[0]["VHCLSTSTYP_ID"].ToString() != "" && dtAsignDetail.Rows[0]["VHCLSTSTYP_ID"] != DBNull.Value)
                {
                    ddlStatusType.Items.FindByValue(dtAsignDetail.Rows[0]["VHCLSTSTYP_ID"].ToString()).Selected = true;
                    objEntityVehicle.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
                    DataTable dtVehSts = new DataTable();
                    dtVehSts = objBusinessVehicle.ReadVehicleStats(objEntityVehicle);
                    if (dtVehSts.Rows.Count > 0)
                    {
                        ddlStatus.DataSource = dtVehSts;
                        ddlStatus.DataValueField = "VHCLSTS_ID";
                        ddlStatus.DataTextField = "VHCLSTS_NAME";
                        ddlStatus.DataBind();
                        ddlStatus.Items.Insert(0, "--SELECT--");
                    }

                }
                if (dtAsignDetail.Rows[0]["VHCLSTS_ID"].ToString() != "" && dtAsignDetail.Rows[0]["VHCLSTS_ID"] != DBNull.Value)
                {
                    if (dtAsignDetail.Rows[0]["VHCLSTS_STATUS"].ToString() == "1")
                    {
                        ddlStatus.Items.FindByValue(dtAsignDetail.Rows[0]["VHCLSTS_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["VHCLSTS_NAME"].ToString(), dtAsignDetail.Rows[0]["VHCLSTS_ID"].ToString());
                        ddlStatus.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlStatus);

                        ddlStatus.Items.FindByValue(dtAsignDetail.Rows[0]["VHCLSTS_ID"].ToString()).Selected = true;
                    }

                }
                if (dtAsignDetail.Rows[0]["VHCLASGN_CNFRM_STS"].ToString() == "1")
                {
                    lblEntry.Text = "View Vehicle Status";
                    btnUpdate.Visible = false;
                    txtFromDate.Enabled = false;
                    txtToDate.Enabled = false;
                    ddlStatus.Enabled = false;
                    ddlStatusType.Enabled = false;
                    txtDescription.Enabled = false;
                }


        }

        if (intEnableModify != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = false;
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ddlStatus.Enabled = false;
            ddlStatusType.Enabled = false;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        string strVehId = "";
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["VehAsgn"].ToString() != "")
        {
            string strVehAsgnId = Request.QueryString["VehAsgn"].ToString();
            string[] strSplit = strVehAsgnId.Split(',');

            int VehAsgnId = Convert.ToInt32(strSplit[0]);
            strVehId = strSplit[1];
            objEntityVehicle.VehAsignId = Convert.ToInt32(strSplit[0]);

        }

        objEntityVehicle.VehicleStsTyp = Convert.ToInt32(ddlStatusType.SelectedItem.Value);
        objEntityVehicle.VehicleSts = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntityVehicle.VehicleAgnDescriptn = txtDescription.Text.Trim();

        if (txtFromDate.Text.Trim()!="")
        {
        objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text.Trim() != "")
        {
            objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

        objBusinessVehicle.UpdateAssignVehicle(objEntityVehicle);
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {
            // string strVeh = hiddenRedirect.Value.ToString();
            //Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "&InsUpd=InsOther");
            Response.Redirect("gen_Vehicle_Assigned_List.aspx?InsUpd=UpdOther&&VehId=" + strVehId + "&Back=" + Request.QueryString["Back"] + "");
        }
        else
        {
            Response.Redirect("gen_Vehicle_Assigned_List.aspx?InsUpd=UpdOther&&VehId=" + strVehId + "");
        }
       

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        
        int intVehId=0;
        if (Request.QueryString["VehAsgn"] != null)
        {
            string strVehAsgnId = Request.QueryString["VehAsgn"].ToString();
            string[] strSplit = strVehAsgnId.Split(',');

            intVehId = Convert.ToInt32(strSplit[1]);
        }
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {

            Response.Redirect("gen_Vehicle_Assigned_List.aspx?VehId=" + intVehId + "&Back=" + Request.QueryString["Back"] + "");
        }
        if (hiddenVehicleId.Value != "")
        {
            if (hiddenMode.Value == "EDIT")
            {
                Response.Redirect("gen_Vehicle_Assigned_List.aspx?VehId=" + intVehId + "");
            }
            else
            {
                Response.Redirect("gen_Vehicle_Status_Management.aspx"); 
            }
        }
        else
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx"); 
        }
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
}