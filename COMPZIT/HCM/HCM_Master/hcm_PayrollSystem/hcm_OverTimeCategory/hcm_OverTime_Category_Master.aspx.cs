using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_OverTimeCategory_hcm_OverTime_Category_Master : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblEntry.Text = "Add Overtime Category";
        txtCatgName.Focus();
        chkbxListPayGrd.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        chkbxListPayGrd.Attributes.Add("onkeypress", "return isTag(event)");

        if (!IsPostBack)
        {
            PaygradeLoad();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            
            HiddenSuccessMsgType.Value = "0";
            if (Session["SuccessMsg"] != null)
            {
                HiddenSuccessMsgType.Value = Session["SuccessMsg"].ToString();
            }

            Session["SuccessMsg"] = null;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
          
            btnUpdate.Visible = false;
            btnUpdateCls.Visible = false;
            btnAdd.Visible = true;
            btnAddCls.Visible = true;
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["EditId"] = strId;
                
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["OvrViewId"] = strId;
                
            }

            if (Session["EditId"] != null && Session["EditId"].ToString() != "")
            {
                btnUpdate.Visible = true;
                btnUpdateCls.Visible = true;
                btnAdd.Visible = false;
                btnAddCls.Visible = false;
                btnClear.Visible = false;
                string strId = Session["EditId"].ToString();
                Edit(strId);
               // Session["EditId"] = "";
            }

            if (Session["OvrViewId"] != null && Session["OvrViewId"].ToString() != "")
            {
                btnUpdate.Visible = false;
                btnUpdateCls.Visible = false;
                btnAdd.Visible = false;
                btnClear.Visible = false;
                btnAddCls.Visible = false;
                string strId = Session["OvrViewId"].ToString();
                Edit(strId);
               // Session["EditId"] = "";
            }
            
            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //Allocating child roles
            //hiddenRoleAdd.Value = "0";
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Overtime_Category);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
        }
    }
    public void PaygradeLoad()
    {
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntity_OverTime_Category.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtPayGrade = new DataTable();
        dtPayGrade = objBusiness_OverTime_Category.ReadPaygrade(objEntity_OverTime_Category);
        HiddenFieldCbxCount.Value = dtPayGrade.Rows.Count.ToString();
        if (dtPayGrade.Rows.Count > 0)
        {
            chkbxListPayGrd.DataSource = dtPayGrade;
            chkbxListPayGrd.DataValueField = "PYGRD_ID";
            chkbxListPayGrd.DataTextField = "PYGRD_NAME";
            chkbxListPayGrd.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            
            Button clickedButton = sender as Button;
            clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
            clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
       
            List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List = new List<clsEntity_OverTIme_Category_List>();
 

            if (Session["CORPOFFICEID"] != null)
            {
                objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntity_OverTime_Category.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            //Next Id Method
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.OVERTIME_CATEGORY);
            objEntityCommon.CorporateID = objEntity_OverTime_Category.Corporate_id;
            objEntityCommon.Organisation_Id = objEntity_OverTime_Category.Organisation_id;

            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntity_OverTime_Category.OvrtmCatgrMasterId= Convert.ToInt32(strNextId);
            objEntity_OverTime_Category.OvrtmCategoryName = txtCatgName.Text.Trim().ToUpper();
            objEntity_OverTime_Category.OvrtmCategoryRate = Convert.ToDouble(txtRate.Text.Trim().ToUpper());

            if (CbxStatus.Checked == true)
            {
                objEntity_OverTime_Category.Status_id = 1;
            }
            else
            {
                objEntity_OverTime_Category.Status_id = 0;
            }

            int j = 0;
            for (int i = 0; i < chkbxListPayGrd.Items.Count; i++)
            {
                if (chkbxListPayGrd.Items[i].Selected)
                {
                    clsEntity_OverTIme_Category_List objEntity_OverTime = new clsEntity_OverTIme_Category_List();
                    j++;
                    objEntity_OverTime.PayGradeId = Int32.Parse(chkbxListPayGrd.Items[i].Value);
                    objEntity_OverTIme_Category_List.Add(objEntity_OverTime);
                }
            }

            objEntity_OverTime_Category.Date = System.DateTime.Now;

            
            //Checking is there table have any name like this
            string strNameCount = objBusiness_OverTime_Category.CheckCategoryName(objEntity_OverTime_Category);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                if (clickedButton.ID == "btnAdd")
                {
                    objBusiness_OverTime_Category.InsertOvrtmCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
                    Session["SuccessMsg"] = "SAVE";
                    Response.Redirect("hcm_OverTime_Category_Master.aspx");   
                }
                else if (clickedButton.ID == "btnAddCls")
                {
                    objBusiness_OverTime_Category.InsertOvrtmCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
                    Session["SuccessMsg"] = "SAVE";
                    Response.Redirect("hcm_OverTime_CategoryList.aspx");
                }
                else
                {
                    string strId = Session["EditId"].ToString();
                    objEntity_OverTime_Category.OvrtmCatgrMasterId = Convert.ToInt32(strId);

                    objBusiness_OverTime_Category.UpdateOverTimeCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
                    Session["SuccessMsg"] = "UPDATE";
                    Response.Redirect("hcm_OverTime_Category_Master.aspx");
                }

            }
            //If have
            else
            {
                HiddenSuccessMsgType.Value = "DUPLICATE";
                txtCatgName.Focus();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }

    public void Edit(string strWId)
    {
        lblEntry.Text = "Edit Overtime Category";
        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List = new List<clsEntity_OverTIme_Category_List>();

        objEntity_OverTime_Category.OvrtmCatgrMasterId = Convert.ToInt32(strWId);
        DataTable dtOvrtmByID = new DataTable();
        dtOvrtmByID = objBusiness_OverTime_Category.ReadOverTimeCategById(objEntity_OverTime_Category);

        if (dtOvrtmByID.Rows.Count > 0)
        {
            txtCatgName.Text = dtOvrtmByID.Rows[0]["OVRTMCATG_NAME"].ToString();
            txtRate.Text = dtOvrtmByID.Rows[0]["OVRTMCATG_RATE"].ToString(); 
            if (dtOvrtmByID.Rows[0]["OVRTMCATG_STATUS"].ToString() == "1")
        {
            CbxStatus.Checked = true;
        }
        else
        {
            CbxStatus.Checked = false;
        }
        }

        if (dtOvrtmByID.Rows.Count > 0)
        {
            for (int count = 0; count < dtOvrtmByID.Rows.Count; count++)
            {
                string strpaygrid = dtOvrtmByID.Rows[count]["OVRTMCATG_DTLS_PAYG_ID"].ToString();
                string paygrdsts = dtOvrtmByID.Rows[count]["PYGRD_STATUS"].ToString();
                string paygrdname = dtOvrtmByID.Rows[count]["PYGRD_NAME"].ToString().ToUpper();
                if (paygrdsts == "1")
                {
                    for (int i = 0; i < chkbxListPayGrd.Items.Count; i++)
                    {
                        if (chkbxListPayGrd.Items[i].Value == strpaygrid)
                        {
                            chkbxListPayGrd.Items[i].Selected = true;
                        }
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtOvrtmByID.Rows[count]["PYGRD_NAME"].ToString().ToUpper(), dtOvrtmByID.Rows[count]["OVRTMCATG_DTLS_PAYG_ID"].ToString().ToUpper());
                    chkbxListPayGrd.Items.Insert(1, lstGrp);
                    chkbxListPayGrd.Items.FindByValue(dtOvrtmByID.Rows[count]["OVRTMCATG_DTLS_PAYG_ID"].ToString().ToUpper()).Selected = true;
                }
            }
        }
}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List = new List<clsEntity_OverTIme_Category_List>();
        string a=Session["EditId"].ToString();
        
        if (Session["EditId"].ToString() != "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntity_OverTime_Category.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strId = Session["EditId"].ToString();
            objEntity_OverTime_Category.OvrtmCatgrMasterId = Convert.ToInt32(strId);

            if (txtCatgName.Text != "" && txtCatgName.Text != null)
            {
                objEntity_OverTime_Category.OvrtmCategoryName = txtCatgName.Text.Trim().ToUpper();
            }
            if (txtRate.Text != "" && txtRate.Text != null)
            {
                objEntity_OverTime_Category.OvrtmCategoryRate = Convert.ToDouble(txtRate.Text.Trim().ToUpper());
            }

            if (CbxStatus.Checked == true)
            {
                objEntity_OverTime_Category.Status_id = 1;
            }
            else
            {
                objEntity_OverTime_Category.Status_id = 0;
            }

            objEntity_OverTime_Category.Date = System.DateTime.Now;
            int j = 0;
            for (int i = 0; i < chkbxListPayGrd.Items.Count; i++)
            {
                if (chkbxListPayGrd.Items[i].Selected)
                {
                    clsEntity_OverTIme_Category_List objEntity_OverTime = new clsEntity_OverTIme_Category_List();
                    j++;
                    objEntity_OverTime.PayGradeId = Int32.Parse(chkbxListPayGrd.Items[i].Value);
                    objEntity_OverTIme_Category_List.Add(objEntity_OverTime);
                }
            }
        }

        //Checking is there table have any name like this
        string strNameCount = objBusiness_OverTime_Category.CheckCategoryName(objEntity_OverTime_Category);
        //If there is no name like this on table.    
        if (clickedButton.ID == "btnUpdate")
        {
            if (strNameCount == "0")
            {
                string strId = Session["EditId"].ToString();
                objEntity_OverTime_Category.OvrtmCatgrMasterId = Convert.ToInt32(strId);

                objBusiness_OverTime_Category.UpdateOverTimeCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
                Session["SuccessMsg"] = "UPDATE";
                Response.Redirect("hcm_OverTime_Category_Master.aspx"); 

            }
            else
            {
                HiddenSuccessMsgType.Value = "DUPLICATE";
                txtCatgName.Focus();
            }
        }
        else if (clickedButton.ID == "btnUpdateCls")
        {
            if (strNameCount == "0")
            {
                objBusiness_OverTime_Category.UpdateOverTimeCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
                Session["SuccessMsg"] = "UPDATE";
                Response.Redirect("hcm_OverTime_CategoryList.aspx");
            }
            else
            {
                HiddenSuccessMsgType.Value = "DUPLICATE";
                txtCatgName.Focus();
            }
        }
        //If have   
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string s = Session["EditId"].ToString();
        Session["EditId"] = "";
        Response.Redirect("hcm_OverTime_CategoryList.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_OverTime_Category_Master.aspx");
    }
}

