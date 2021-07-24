using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.Services;
using System.IO;

// CREATED BY:EVM-0008
// CREATED DATE:02/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Master_gen_Vehicle_Status_Master : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        TypNme.Attributes.Add("onkeypress", "return isTag(event)");
        TypNme.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCtgry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            VStatustype_Load();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Vehicle Status";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Vehicle Status";
            }

            else
            {
                lblEntry.Text = "Add Vehicle Status";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
            }


        }
    }

    //Method for assigning status type to the dropdown list
    public void VStatustype_Load()
    {
        ddlCtgry.Items.Clear();
        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehStsMstr.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehStsMstr.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtCategory = objBusnssVehStsMstr.ReadVStatusMstr(objEntityVehStsMstr);

        ddlCtgry.DataSource = dtCategory;

        ddlCtgry.DataTextField = "VHCLSTSTYP_NAME";
        ddlCtgry.DataValueField = "VHCLSTSTYP_ID";
        ddlCtgry.DataBind();

        ddlCtgry.Items.Insert(0, "--SELECT STATUS TYPE--");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVehStsMstr.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityVehStsMstr.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityVehStsMstr.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityVehStsMstr.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityVehStsMstr.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityVehStsMstr.VehId = Convert.ToInt32(strWaterId);
            string strNameCount = "0";
            if (TypNme.Text != "" && TypNme.Text != null)
            {
                objEntityVehStsMstr.ClassName = TypNme.Text.Trim().ToUpper();
                strNameCount = objBusnssVehStsMstr.CheckVehStsName(objEntityVehStsMstr);
            }
       
            if (ddlCtgry.SelectedItem.Value != "--SELECT STATUS TYPE--")
            {
                objEntityVehStsMstr.StatusTypeId = Convert.ToInt32(ddlCtgry.SelectedItem.Value);
            }
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusnssVehStsMstr.UpdateVStatusMstr(objEntityVehStsMstr);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Vehicle_Status_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Vehicle_Status_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }

            }
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehStsMstr.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehStsMstr.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityVehStsMstr.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityVehStsMstr.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityVehStsMstr.Status_id = 0;
        }

        string strNameCount = "0";
        if (TypNme.Text != "" && TypNme.Text != null)
        {
            objEntityVehStsMstr.ClassName = TypNme.Text.Trim().ToUpper();
            strNameCount = objBusnssVehStsMstr.CheckVehStsName(objEntityVehStsMstr);
        }


        if (ddlCtgry.SelectedItem.Value != "--SELECT STATUS TYPE--")
        {
            objEntityVehStsMstr.StatusTypeId = Convert.ToInt32(ddlCtgry.SelectedItem.Value);
        }

        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusnssVehStsMstr.AddVStatusMstr(objEntityVehStsMstr);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Vehicle_Status_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Vehicle_Status_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }


    public void View(string strWId)
    {

        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();

        objEntityVehStsMstr.VehId = Convert.ToInt32(strWId);
        DataTable dtLeaveTypDetail = new DataTable();
        dtLeaveTypDetail = objBusnssVehStsMstr.ReadVStatusById(objEntityVehStsMstr);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["VHCLSTS_NAME"].ToString();
             if (dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString() != "" && dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_STATUS"].ToString() == "1")
            {
                ddlCtgry.Items.FindByValue(dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_NAME"].ToString(), dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString());
                ddlCtgry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCtgry);

                ddlCtgry.Items.FindByValue(dtLeaveTypDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }

            int intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["VHCLSTS_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        TypNme.Enabled = false;
        ddlCtgry.Enabled = false;
          btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Enabled = false;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
    }

    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {

        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();
        objEntityVehStsMstr.VehId = Convert.ToInt32(strWId);
        DataTable dtLeaveTypDetail = new DataTable();
        dtLeaveTypDetail = objBusnssVehStsMstr.ReadVStatusById(objEntityVehStsMstr);
      
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["VHCLSTS_NAME"].ToString();
          
            if (dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString() != "" && dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_STATUS"].ToString() == "1")
            {
                ddlCtgry.Items.FindByValue(dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_NAME"].ToString(), dtLeaveTypDetail.Rows[0]["VHCLSTSTYP_ID"].ToString());
                ddlCtgry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCtgry);

                ddlCtgry.Items.FindByValue(dtLeaveTypDetail.Rows[0]["HLDAYTYP_ID"].ToString()).Selected = true;
            }
            int intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["VHCLSTS_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }


        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Type);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }
        }
        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = true;

        }
        else
       {

           btnUpdate.Visible = false;

        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Vehicle_Status_Master.aspx");
    }
      
}