using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Collections;
using CL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:10/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Complaints_gen_ComplaintAdd : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinesslayerComplaint objBusinessLayerComplaint = new clsBusinesslayerComplaint();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtComplaintDesc.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtComplaintDesc.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCtgry.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCtgry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPenalty.Attributes.Add("onkeypress", "return isTag(event)");
        txtPenalty.Attributes.Add("onchange", "IncrmntConfrmCounter()");
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
          
            txtComplaintDesc.Focus();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
              
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {     clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                              
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenFloatingValueMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
               
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.InnerText = "Edit Complaint Master";
                lblEntryB.InnerText = "Edit Complaint Master";
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.InnerText = "View Complaint Master";
                lblEntryB.InnerText = "View Complaint Master";
            }

            else
            {
                lblEntry.InnerText = "Add Complaint Master";
                lblEntryB.InnerText = "Add Complaint Master";
                Category_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                btnClearF.Visible = true;
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

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Complaint_Master);
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

                btnUpdate.Visible = false;

            }
            

        }

    }

    //Method for assigning departments to the dropdown list
    public void Category_Load()
    {
        ddlCtgry.Items.Clear();
        clsEntityComplaint objEntityComplaint = new clsEntityComplaint();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityComplaint.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityComplaint.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtCategory = objBusinessLayerComplaint.ReadComplaintCtgry(objEntityComplaint);

        ddlCtgry.DataSource = dtCategory;

        ddlCtgry.DataTextField = "CMPLNTCTGRY_NAME";
        ddlCtgry.DataValueField = "CMPLNTCTGRY_ID";
        ddlCtgry.DataBind();

        ddlCtgry.Items.Insert(0, "--SELECT CATEGORY--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityComplaint objEntityComplaint = new clsEntityComplaint();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityComplaint.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityComplaint.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityComplaint.CtgryId = Convert.ToInt32(ddlCtgry.SelectedItem.Value);
        if (txtPenalty.Value.Trim() != "")
        {
            objEntityComplaint.Penalty = Convert.ToDecimal(txtPenalty.Value.Trim());
        
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityComplaint.Complaint_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityComplaint.Complaint_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityComplaint.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else 
        {
            Response.Redirect("~/Default.aspx");
        }
  
        objEntityComplaint.D_Date = System.DateTime.Now;

        objEntityComplaint.ComplaintDesc = txtComplaintDesc.Value.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerComplaint.CheckComplaintDesc(objEntityComplaint);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerComplaint.Insert_Complaint(objEntityComplaint);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Complaint.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_ComplaintList.aspx?InsUpd=Ins");
            }
           
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtComplaintDesc.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityComplaint objEntityComplaint = new clsEntityComplaint();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityComplaint.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityComplaint.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityComplaint.CtgryId = Convert.ToInt32(ddlCtgry.SelectedItem.Value);
            if (txtPenalty.Value.Trim() != "")
            {
                objEntityComplaint.Penalty = Convert.ToDecimal(txtPenalty.Value.Trim());

            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityComplaint.Complaint_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityComplaint.Complaint_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityComplaint.Complaint_Master_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityComplaint.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityComplaint.D_Date = System.DateTime.Now;

            objEntityComplaint.ComplaintDesc = txtComplaintDesc.Value.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerComplaint.CheckComplaintDesc(objEntityComplaint);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLayerComplaint.Update_Complaint(objEntityComplaint);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Complaint.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_ComplaintList.aspx?InsUpd=Upd");
                }
                
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtComplaintDesc.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityComplaint objEntityComplaint = new clsEntityComplaint();
        objEntityComplaint.Complaint_Master_Id = Convert.ToInt32(strP_Id);
        objEntityComplaint.CorpOffice_Id = intCorpId;
        DataTable dtComplaintById = objBusinessLayerComplaint.ReadComplaintById(objEntityComplaint);
        if (dtComplaintById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtComplaintDesc.Value = dtComplaintById.Rows[0]["CMPLNTMSTR_DSCPTN"].ToString();
            ddlCtgry.Items.Clear();
            ListItem lst = new ListItem(dtComplaintById.Rows[0]["CMPLNTCTGRY_NAME"].ToString(), dtComplaintById.Rows[0]["CMPLNTCTGRY_ID"].ToString());
            ddlCtgry.Items.Insert(0, lst);
            txtPenalty.Value = dtComplaintById.Rows[0]["PENALTY AMOUNT"].ToString().Trim();
            int intComplaintStatus = Convert.ToInt32(dtComplaintById.Rows[0]["CMPLNTMSTR_STATUS"]);
            if (intComplaintStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtPenalty.Disabled = true;
        txtComplaintDesc.Disabled = true;
        ddlCtgry.Enabled = false;
        cbxStatus.Disabled = true;
        
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityComplaint objEntityComplaint = new clsEntityComplaint();
        objEntityComplaint.Complaint_Master_Id = Convert.ToInt32(strP_Id);
        objEntityComplaint.CorpOffice_Id = intCorpId;
        DataTable dtComplaintById = objBusinessLayerComplaint.ReadComplaintById(objEntityComplaint);
        if (dtComplaintById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtComplaintDesc.Value = dtComplaintById.Rows[0]["CMPLNTMSTR_DSCPTN"].ToString();
            Category_Load();
            //ie IF  Department IS ACTIVE
            if (dtComplaintById.Rows[0]["CMPLNTCTGRY_STATUS"].ToString() == "1" )
            {
                ddlCtgry.Items.FindByText(dtComplaintById.Rows[0]["CMPLNTCTGRY_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtComplaintById.Rows[0]["CMPLNTCTGRY_NAME"].ToString(), dtComplaintById.Rows[0]["CMPLNTCTGRY_ID"].ToString());
                ddlCtgry.Items.Insert(1, lst);

                SortDDL(ref this.ddlCtgry);

                ddlCtgry.Items.FindByText(dtComplaintById.Rows[0]["CMPLNTCTGRY_NAME"].ToString()).Selected = true;
            }

            txtPenalty.Value = dtComplaintById.Rows[0]["PENALTY AMOUNT"].ToString();
            int intComplaintStatus = Convert.ToInt32(dtComplaintById.Rows[0]["CMPLNTMSTR_STATUS"]);
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