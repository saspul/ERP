using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
//using BL
// CREATED BY:EVM-0005
// CREATED DATE:28/12/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class GMS_GMS_Master_gen_Contract_Category_Master_gen_Contract_Category_Master : System.Web.UI.Page
{
    classBusinessLayerContractCategory ObjBussinessCntrct = new classBusinessLayerContractCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
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



            txtName.Focus();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.Text = "Edit Contract Category";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.Text = "View Contract Category";
            }
            else
            {
                lblEntry.Text = "Add Contract Category";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
               
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
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Category_Master);
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


            }
            else
            {

                btnUpdate.Visible = false;

            }
        }
    }
      protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {

            classEntityLayerContractCategory objEntityCntrctCat = new classEntityLayerContractCategory();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCntrctCat.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCntrctCat.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityCntrctCat.JobCat_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCntrctCat.JobCat_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCntrctCat.CntrctCatId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityCntrctCat.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityCntrctCat.D_Date = System.DateTime.Now;
            objEntityCntrctCat.CntrctCatname = txtName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = ObjBussinessCntrct.CheckContractCatName(objEntityCntrctCat);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                ObjBussinessCntrct.UpdateContractCategory(objEntityCntrctCat);
                if (clickedButton.ID == "btnUpdate")
                {
                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    objEntityCommon.RedirectUrl = "gen_Contract_Category_Master.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);

                    //Response.Redirect("gen_Contract_Category_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtName.Focus();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        classEntityLayerContractCategory objEntityCntrctCat = new classEntityLayerContractCategory();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrctCat.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCntrctCat.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityCntrctCat.JobCat_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCntrctCat.JobCat_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityCntrctCat.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityCntrctCat.D_Date = System.DateTime.Now;

        objEntityCntrctCat.CntrctCatname = txtName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = ObjBussinessCntrct.CheckContractCatName(objEntityCntrctCat);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            ObjBussinessCntrct.AddContractCategory(objEntityCntrctCat);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Contract_Category_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtName.Focus();
        }
    }
     //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        classEntityLayerContractCategory objEntityCntrctCat = new classEntityLayerContractCategory();
        objEntityCntrctCat.CntrctCatId = Convert.ToInt32(strP_Id);
        objEntityCntrctCat.CorpOffice_Id = intCorpId;
        DataTable dtJobById = ObjBussinessCntrct.ReadContractCategryById(objEntityCntrctCat);
        if (dtJobById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtName.Text = dtJobById.Rows[0]["CNTRCTYPE_NAME"].ToString().Trim();
            int intComplaintStatus = Convert.ToInt32(dtJobById.Rows[0]["CNTRCTYPE_STATUS"]);
            if (intComplaintStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;
        cbxStatus.Enabled = false;
        
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        classEntityLayerContractCategory objEntityCntrctCat = new classEntityLayerContractCategory();
        objEntityCntrctCat.CntrctCatId = Convert.ToInt32(strP_Id);
        objEntityCntrctCat.CorpOffice_Id = intCorpId;
        DataTable dtComplaintById = ObjBussinessCntrct.ReadContractCategryById(objEntityCntrctCat);
        if (dtComplaintById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtName.Text = dtComplaintById.Rows[0]["CNTRCTYPE_NAME"].ToString();
            int intComplaintStatus = Convert.ToInt32(dtComplaintById.Rows[0]["CNTRCTYPE_STATUS"]);
            if (intComplaintStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }
}
