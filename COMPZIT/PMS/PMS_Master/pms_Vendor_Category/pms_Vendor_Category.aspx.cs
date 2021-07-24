using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using System.Data;

public partial class PMS_PMS_Master_pms_Vendor_Category_pms_Vendor_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayerVendorCategory objBusinessVendorCategory = new clsBusinessLayerVendorCategory();
            clsEntityVendorCategory objEntityVendorCategory = new clsEntityVendorCategory();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                objEntityVendorCategory.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
           
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVendorCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }

            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityVendorCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PMS_Vendor_Category);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                LoadVenderCaregoryDetails(strId,1);
                lblEntry.Text = "Edit Vendor Category";
                btnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                ButtnClear.Visible = false;
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                LoadVenderCaregoryDetails(strId,0);
                lblEntry.Text = "View Vendor Category";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnsaveAndClose.Visible = false;
                btnsave.Visible = false;
                btnsaveAndClose.Visible = false;

            }
            else
            {
                lblEntry.Text = "Add Vendor Category";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnsaveAndClose.Visible = false;
                btnsave.Visible = true;
                btnsaveAndClose.Visible = true;
            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsert", "SuccessInsert();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            else if (strInsUpd == "Dup")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerVendorCategory objBusinessVendorCategory = new clsBusinessLayerVendorCategory();
        clsEntityVendorCategory objEntityVendorCategory = new clsEntityVendorCategory();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int flag = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVendorCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVendorCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityVendorCategory.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityVendorCategory.VendorCategory = txtCategory.Text.Trim();
        objEntityVendorCategory.VendorCategoryCode = txtCategoryCode.Text.Trim();

        if (ChkStatus.Checked == true)
        {
            objEntityVendorCategory.Status = 1;
        }
        else
        {
            objEntityVendorCategory.Status = 0;
        }
        DataTable dtIns = objBusinessVendorCategory.VendorCategoryDplctnChk(objEntityVendorCategory);
        if (dtIns.Rows.Count > 0)
        {
            int idcount = Convert.ToInt32(dtIns.Rows[0][0].ToString());
            if (idcount > 0)
            {
                flag++;
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
        else
        {
            objBusinessVendorCategory.InsertVendorCategory(objEntityVendorCategory);
            if (clickedButton.ID == "btnsave")
            {
                Response.Redirect("pms_Vendor_Category.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnsaveAndClose")
            {
                Response.Redirect("pms_VendorCategoryList.aspx?InsUpd=Ins");
            }
        }
       
    }

    public void LoadVenderCaregoryDetails(string strP_Id,int EditOrView)
    {

        clsBusinessLayerVendorCategory objBusinessVendorCategory = new clsBusinessLayerVendorCategory();
        clsEntityVendorCategory objEntityVendorCategory = new clsEntityVendorCategory();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityVendorCategory.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityVendorCategory.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityVendorCategory.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityVendorCategory.vendorCategoryID = Convert.ToInt32(strP_Id);
        DataTable dt = objBusinessVendorCategory.ReadVendorCategory_ByID(objEntityVendorCategory);
        if (dt.Rows.Count > 0)
        {
            txtCategory.Text = dt.Rows[0]["VNDRCTGRY_NAME"].ToString();
            txtCategoryCode.Text = dt.Rows[0]["VNDRCTGRY_CODE"].ToString();
            if (dt.Rows[0]["VNDRCTGRY_STATUS"].ToString() == "1")
            {
                ChkStatus.Checked = true;
            }
            else
            {
                ChkStatus.Checked = false;
            }
        }
        if (EditOrView == 0)
        {
            txtCategory.Enabled = false;
            txtCategoryCode.Enabled = false;
            ChkStatus.Disabled = true;
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerVendorCategory objBusinessVendorCategory = new clsBusinessLayerVendorCategory();
        clsEntityVendorCategory objEntityVendorCategory = new clsEntityVendorCategory();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityVendorCategory.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityVendorCategory.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityVendorCategory.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityVendorCategory.vendorCategoryID = Convert.ToInt32(strId);
        objEntityVendorCategory.VendorCategory = txtCategory.Text;
        objEntityVendorCategory.VendorCategoryCode = txtCategoryCode.Text;
        if (ChkStatus.Checked == true)
        {
            objEntityVendorCategory.Status = 1;
        }
        else
        {
            objEntityVendorCategory.Status = 0;
        }
        string strNameCount = "0";
        DataTable dtIns = objBusinessVendorCategory.VendorCategoryDplctnChk(objEntityVendorCategory);
        if (dtIns.Rows.Count > 0 )
        {
            int idcount = Convert.ToInt32(dtIns.Rows[0][0].ToString());
            if (idcount > 0 && strId!=idcount.ToString())
            {
                //flag++;
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
        else
        {
            if (txtCategory.Text != "" && txtCategory.Text != null && txtCategoryCode.Text != "" && txtCategoryCode != null)
            {
                objBusinessVendorCategory.updateVendorCategory(objEntityVendorCategory);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("pms_Vendor_Category.aspx?InsUpd=Upd&Id=" + Request.QueryString["Id"].ToString());
                }
                else
                {
                    Response.Redirect("pms_VendorCategoryList.aspx?InsUpd=Upd");
                }
            }
        }
    }
}
