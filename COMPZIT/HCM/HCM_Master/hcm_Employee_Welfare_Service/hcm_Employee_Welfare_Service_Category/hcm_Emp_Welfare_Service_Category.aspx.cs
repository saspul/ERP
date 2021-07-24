using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;

public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Category_hcm_Emp_Welfare_Service_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        txtCategoryName.Focus();
        txtCategoryName.Attributes.Add("onkeypress", "return isTagEnter(event)");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtCatgoryDesc.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            txtCategoryName.Attributes.Add("onkeypress", "return isTag(event)");
            cbxStatus.Checked = true;
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenEnableModify.Value = "0";
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value=Convert.ToString(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Welfare Service Category";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Welfare Service Category";
            }

            else
            {
                lblEntry.Text = "Add Welfare Service Category";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                
            }
        }
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityWelfare_Category.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityWelfare_Category.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityWelfare_Category.Status = 0;
        }
        string strNameCount = "0";
        if (txtCategoryName.Text != "" && txtCategoryName.Text != null)
        {
            objEntityWelfare_Category.categoryName = txtCategoryName.Text.Trim().ToUpper();
            strNameCount = objBusinessWelfare_Category.CheckCategoryName(objEntityWelfare_Category);
        }

        objEntityWelfare_Category.categoryDescription = txtCatgoryDesc.Text.Trim();
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessWelfare_Category.InsertWelfareCcategory(objEntityWelfare_Category);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_Emp_Welfare_Service_Category.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Emp_Welfare_Category_List.aspx?InsUpd=Ins");
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
    public void Update(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        if (HiddenEnableModify.Value == "Active")
        {
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
        }
        else{
             btnUpdate.Visible = false;;
             btnUpdateClose.Visible = false;
        }
        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityWelfare_Category.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    
        objEntityWelfare_Category.CategoryId = Convert.ToInt32(strId);
        DataTable dtAccommodationById = objBusinessWelfare_Category.ReadCategoryDetailsById(objEntityWelfare_Category);
        if (dtAccommodationById.Rows.Count > 0)
        {
            txtCategoryName.Text = dtAccommodationById.Rows[0]["WLFRCAT_NAME"].ToString();
            txtCatgoryDesc.Text = dtAccommodationById.Rows[0]["WLFRCAT_DES"].ToString();
            int intAccmdtnStatus = Convert.ToInt32(dtAccommodationById.Rows[0]["WLFRCAT_STATUS"]);
            if (intAccmdtnStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }
    public void View(string strId)
    {
        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;       
        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityWelfare_Category.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityWelfare_Category.CategoryId = Convert.ToInt32(strId);
        DataTable dtAccommodationById = objBusinessWelfare_Category.ReadCategoryDetailsById(objEntityWelfare_Category);
        if (dtAccommodationById.Rows.Count > 0)
        {
            txtCategoryName.Text = dtAccommodationById.Rows[0]["WLFRCAT_NAME"].ToString();
            txtCatgoryDesc.Text = dtAccommodationById.Rows[0]["WLFRCAT_DES"].ToString();
            int intAccmdtnStatus = Convert.ToInt32(dtAccommodationById.Rows[0]["WLFRCAT_STATUS"]);
            if (intAccmdtnStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtCategoryName.Enabled = false;
            txtCatgoryDesc.Enabled = false;
            cbxStatus.Enabled = false;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
            clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
            if (Session["USERID"] != null)
            {
                objEntityWelfare_Category.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (cbxStatus.Checked == true)
            {
                objEntityWelfare_Category.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityWelfare_Category.Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityWelfare_Category.CategoryId = Convert.ToInt32(strId);

            //objEntityWelfare_Category. categoryName = txtCategoryName.Text.Trim();
            //objEntityWelfare_Category.categoryDescription = txtCatgoryDesc.Text.Trim();

            string strNameCount = "0";
            if (txtCategoryName.Text != "" && txtCategoryName.Text != null)
            {
                objEntityWelfare_Category.categoryName = txtCategoryName.Text.Trim().ToUpper();
                strNameCount = objBusinessWelfare_Category.CheckCategoryName(objEntityWelfare_Category);
            }

            objEntityWelfare_Category.categoryDescription = txtCatgoryDesc.Text.Trim();
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessWelfare_Category.UpdateWelfareCategory(objEntityWelfare_Category);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("hcm_Emp_Welfare_Service_Category.aspx?InsUpd=Upd&Id=" + strRandomMixedId);
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("hcm_Emp_Welfare_Category_List.aspx?InsUpd=Upd");
                }

            }
            //If have

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtCategoryName.Focus();

            }
        }
    }
}