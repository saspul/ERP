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
// CREATED BY:EVM-0008
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Leave_Type_Master_gen_Leave_Type_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TypNme.Attributes.Add("onkeypress", "return isTag(event)");
        TypNme.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        NumDays.Attributes.Add("onkeypress", "return isTag(event)");
        NumDays.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            HiddenAllocatnConfirmed.Value = "0";
            //when editing 

            if (Request.QueryString["SelctdId"] != null)
            {
                string strRandomMixedId = Request.QueryString["SelctdId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenAllocatnConfirmed.Value = "1";
                Update(strId);
                lblEntry.Text = "Edit Leave Type";
            
            }
            else if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Leave Type";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Leave Type";
            }

            else
            {
                lblEntry.Text = "Add Leave Type";

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

  
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinessLayerLeaveTypeMaster objBusinessLeave = new clsBussinessLayerLeaveTypeMaster();
        clsEntityLayerLeaveTypeMaster objEntityLeave = new clsEntityLayerLeaveTypeMaster();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeave.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLeave.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityLeave.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityLeave.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityLeave.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityLeave.LeaveTypeMasterId = Convert.ToInt32(strId);
            string strNameCount = "0";
            if (TypNme.Text != "" && TypNme.Text != null)
            {
                objEntityLeave.LeaveTypeName = TypNme.Text.Trim().ToUpper();
                strNameCount = objBusinessLeave.CheckLeaveName(objEntityLeave);
            }
            objEntityLeave.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());
                       
                   
                //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLeave.UpdateLeaveType(objEntityLeave);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Leave_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Leave_Type_Master_List.aspx?InsUpd=Upd");
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
        clsBussinessLayerLeaveTypeMaster objBusinessLeave = new clsBussinessLayerLeaveTypeMaster();
        clsEntityLayerLeaveTypeMaster objEntityLeave = new clsEntityLayerLeaveTypeMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeave.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLeave.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLeave.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityLeave.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityLeave.Status_id = 0;
        }
                     
        string strNameCount = "0";
        if (TypNme.Text != "" && TypNme.Text != null)
        {
            objEntityLeave.LeaveTypeName = TypNme.Text.Trim().ToUpper();
            strNameCount = objBusinessLeave.CheckLeaveName(objEntityLeave);
        }
        objEntityLeave.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());
        


        //If there is no name like this on table.    
        if (strNameCount == "0" )
        {
            objBusinessLeave.AddLeaveType(objEntityLeave);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Leave_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Leave_Type_Master_List.aspx?InsUpd=Ins");
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

        clsBussinessLayerLeaveTypeMaster objBusinessLeave = new clsBussinessLayerLeaveTypeMaster();
        clsEntityLayerLeaveTypeMaster objEntityLeave = new clsEntityLayerLeaveTypeMaster();

        objEntityLeave.LeaveTypeMasterId = Convert.ToInt32(strWId);
        DataTable dtLeaveTypDetail = new DataTable();
        dtLeaveTypDetail = objBusinessLeave.ReadLeavedetailsById(objEntityLeave);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NAME"].ToString();
            NumDays.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NUMDAYS"].ToString();

            int intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"]);
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
        NumDays.Enabled = false;
       

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Enabled = false;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {

        clsBussinessLayerLeaveTypeMaster objBusinessLeave = new clsBussinessLayerLeaveTypeMaster();
        clsEntityLayerLeaveTypeMaster objEntityLeave = new clsEntityLayerLeaveTypeMaster();
        objEntityLeave.LeaveTypeMasterId = Convert.ToInt32(strWId);
        DataTable dtLeaveTypDetail = new DataTable();
        dtLeaveTypDetail = objBusinessLeave.ReadLeavedetailsById(objEntityLeave);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NAME"].ToString();
            NumDays.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NUMDAYS"].ToString();

            int intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"]);
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
        if (HiddenAllocatnConfirmed.Value == "1")
        {
            NumDays.Enabled = false;
        
        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Leave_Type_Master.aspx");
    }
}