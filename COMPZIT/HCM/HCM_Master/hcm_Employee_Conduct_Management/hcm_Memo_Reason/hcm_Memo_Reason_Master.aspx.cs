using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Memo_Reason_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intUserId = 0, intEnableAdd = 0;
            hiddenupd.Value = "";
            RsnNme.Focus();
            if (Session["USERID"] != null)
            {
                objEntityMemoReason.User_Id = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
         
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityMemoReason.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
             

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityMemoReason.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {

                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenFieldQryString.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.Text = "Edit Employee Conduct Category";

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MemoSuccessUpdation", "MemoSuccessUpdation();", true);
                    }
                   
                }

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

              View(strId);

              lblEntry.Text = "View Employee Conduct Category";
            }

            else
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                lblEntry.Text = "Add Employee Conduct Category";

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MemoSuccessConfirmation", "MemoSuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MemoSuccessUpdation", "MemoSuccessUpdation();", true);
                    }



                }
            }

            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Memo_Reason);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }

                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

               
            }
            else
            {

                

            }



        }

    }

    public void Update(string strWId)
    {
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        objEntityMemoReason.MemoId = Convert.ToInt32(strWId);
        DataTable dtReadLMemoResnById = objBusinessMemoReason.ReadLMemoResnById(objEntityMemoReason);
        hiddenupd.Value = strWId;
        RsnNme.Text = dtReadLMemoResnById.Rows[0]["M_REASON"].ToString();
        txtDesc.Text = dtReadLMemoResnById.Rows[0]["M_DESCRPTION"].ToString();
        if (dtReadLMemoResnById.Rows[0]["RSN_STATUS"].ToString() == "1")
        {
            CbxStatus.Checked = true;
        }
        else
        {
            CbxStatus.Checked = false;
        }
    }
    public void View(string strWId)
    {
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        objEntityMemoReason.MemoId = Convert.ToInt32(strWId);
        DataTable dtReadLMemoResnById = objBusinessMemoReason.ReadLMemoResnById(objEntityMemoReason);
        hiddenupd.Value = strWId;
        RsnNme.Enabled = false;
        txtDesc.Enabled = false;
        CbxStatus.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        RsnNme.Text = dtReadLMemoResnById.Rows[0]["M_REASON"].ToString();
        txtDesc.Text = dtReadLMemoResnById.Rows[0]["M_DESCRPTION"].ToString();
        if (dtReadLMemoResnById.Rows[0]["RSN_STATUS"].ToString() == "1")
        {
            CbxStatus.Checked = true;
        }
        else
        {
            CbxStatus.Checked = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
       Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
              // DateTime dateCurnt;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMemoReason.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMemoReason.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityMemoReason.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        string strNameCount = "0";




        if (RsnNme.Text != "" && RsnNme.Text != null)
        {
            objEntityMemoReason.MemoRsnName = RsnNme.Text.ToUpper();
            strNameCount = objBusinessMemoReason.CheckCategoryName(objEntityMemoReason);
        }
        objEntityMemoReason.MemoDesc = txtDesc.Text;
        if (CbxStatus.Checked == true)
        {
            objEntityMemoReason.MemoStatus = 1;
        }
        else
        {
            objEntityMemoReason.MemoStatus = 0;
        }

        objEntityMemoReason.MemoUserDate = DateTime.Now;

        if (strNameCount == "0")
        {
            objBusinessMemoReason.AddMemoReason(objEntityMemoReason);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_Memo_Reason_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Memo_Reason_Master_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //decimal decHalfFrmday = 0, decHalfToDay = 0;
        // DateTime dateCurnt;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMemoReason.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMemoReason.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityMemoReason.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityMemoReason.MemoId = Convert.ToInt32(strId);
        string strNameCount = "0";
        if (RsnNme.Text != "" && RsnNme.Text != null)
        {
            objEntityMemoReason.MemoRsnName = RsnNme.Text.ToUpper();
            strNameCount = objBusinessMemoReason.CheckCategoryName(objEntityMemoReason);
        }
        objEntityMemoReason.MemoDesc = txtDesc.Text;
        if (CbxStatus.Checked == true)
        {
            objEntityMemoReason.MemoStatus = 1;
        }
        else
        {
            objEntityMemoReason.MemoStatus = 0;
        }

        objEntityMemoReason.MemoUserDate = DateTime.Now;
        objEntityMemoReason.MemoId =Convert.ToInt32( hiddenupd.Value);
        if (strNameCount == "0")
        {
            objBusinessMemoReason.UpdateMemoReason(objEntityMemoReason);
            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_Memo_Reason_Master.aspx?InsUpd=Upd&Id=" + strRandomMixedId);
                //   Response.Redirect("hcm_Memo_Reason_Master.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("hcm_Memo_Reason_Master_List.aspx?InsUpd=Upd");
            }


        }
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }
        }


    }
}