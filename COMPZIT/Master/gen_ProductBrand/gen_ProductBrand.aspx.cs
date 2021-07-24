using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Data;

public partial class MasterPage_Default3 : System.Web.UI.Page
{
    clsBusinessLayerPrdctBrand objBusinessLayerItemGrp = new clsBusinessLayerPrdctBrand();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions.


        txtPrdctBrndName.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrdctBrndName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPrdctCodeName.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrdctCodeName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        
        //If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.

        if (!IsPostBack)
        {
            txtPrdctBrndName.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Product Brand";
                lblEntryB.InnerText = "Edit Product Brand";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Product Brand";
                lblEntryB.InnerText = "View Product Brand";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Product Brand";
                lblEntryB.InnerText = "Add Product Brand";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
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
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityProductBrand objEntityPrdctBrnd = new clsEntityProductBrand();


            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPrdctBrnd.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPrdctBrnd.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }

            
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityPrdctBrnd.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityPrdctBrnd.Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPrdctBrnd.Brand_Id = Convert.ToInt32(strDeptId);

            objEntityPrdctBrnd.User_Id = Convert.ToInt32(Session["USERID"]);
            objEntityPrdctBrnd.D_Date = System.DateTime.Now;
            txtPrdctBrndName.Text = txtPrdctBrndName.Text.ToUpper().Trim();
            objEntityPrdctBrnd.Brand_name = txtPrdctBrndName.Text;
            txtPrdctCodeName.Text = txtPrdctCodeName.Text.ToUpper().Trim();
            objEntityPrdctBrnd.Brand_Code = txtPrdctCodeName.Text;



            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerItemGrp.CheckItemGroupName(objEntityPrdctBrnd);
            string strCodeCount = objBusinessLayerItemGrp.CheckItemGroupCode(objEntityPrdctBrnd);
            //If there is no name like this on table.    
            if (strNameCount == "0" && strCodeCount == "0")
            {
                DataTable dtComplaintDetail = objBusinessLayerItemGrp.ReadItemGroupById(objEntityPrdctBrnd);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["PRDTBRND_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["PRDTBRND_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerItemGrp.UpdateItemGroup(objEntityPrdctBrnd);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_ProductBrand.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_ProductBrandList.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_ProductBrandList.aspx?InsUpd=AlCncl");
                    }
                } 

                     
            }
            //If have
            else
            {
                if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    txtPrdctCodeName.Focus();
                }
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtPrdctBrndName.Focus();
                }
            }
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityProductBrand objEntityPrdctBrnd = new clsEntityProductBrand();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPrdctBrnd.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPrdctBrnd.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityPrdctBrnd.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPrdctBrnd.Status = 0;
        }
        objEntityPrdctBrnd.User_Id = Convert.ToInt32(Session["USERID"]);
        objEntityPrdctBrnd.D_Date = System.DateTime.Now;
        txtPrdctBrndName.Text = txtPrdctBrndName.Text.ToUpper().Trim();
        objEntityPrdctBrnd.Brand_name = txtPrdctBrndName.Text;
        txtPrdctCodeName.Text = txtPrdctCodeName.Text.ToUpper().Trim();
        objEntityPrdctBrnd.Brand_Code = txtPrdctCodeName.Text;
        
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerItemGrp.CheckItemGroupName(objEntityPrdctBrnd);
        string strCodeCount = objBusinessLayerItemGrp.CheckItemGroupCode(objEntityPrdctBrnd);
        //If there is no name like this on table.    
        if (strNameCount == "0" && strCodeCount == "0")
        {
            objBusinessLayerItemGrp.AddProductBrand(objEntityPrdctBrnd);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_ProductBrand.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_ProductBrandList.aspx?InsUpd=Ins");
            }
         
        }
        //If have
        else
        {
            if (strCodeCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                txtPrdctCodeName.Focus();
            }
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtPrdctBrndName.Focus();
            }

        }
    }


    public void View(string strDId)
    {

        clsEntityProductBrand objEntityPrdctBrnd = new clsEntityProductBrand();
        objEntityPrdctBrnd.Brand_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerItemGrp.ReadItemGroupById(objEntityPrdctBrnd);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtPrdctBrndName.Text = dtDeptById.Rows[0]["PRDTBRND_NAME"].ToString();
        txtPrdctCodeName.Text = dtDeptById.Rows[0]["PRDTBRND_CODE"].ToString();


        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["PRDTBRND_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        txtPrdctBrndName.Enabled = false;
        txtPrdctCodeName.Enabled = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Disabled = true;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strDId)
    {
        clsEntityProductBrand objEntityPrdctBrnd = new clsEntityProductBrand();
        objEntityPrdctBrnd.Brand_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerItemGrp.ReadItemGroupById(objEntityPrdctBrnd);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtPrdctBrndName.Text = dtDeptById.Rows[0]["PRDTBRND_NAME"].ToString();
        txtPrdctCodeName.Text = dtDeptById.Rows[0]["PRDTBRND_CODE"].ToString();


        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["PRDTBRND_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }


        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
    }
}