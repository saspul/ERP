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

// CREATED BY:WEM-0006
// CREATED DATE:17/08/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the UI Layer for Adding Lead rating Details and also updating,canceling and viewing the same .


public partial class Master_gen_Lead_Rate_Master_gen_Lead_Rate_Master : System.Web.UI.Page
{

    //Creating objects for businesslayer
    clsBusinessLayerLeadRate objBusinessLayerLeadRate = new clsBusinessLayerLeadRate();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtLeadRating.Attributes.Add("onkeypress", "return isTag(event)");
        txtLeadRating.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            txtLeadRating.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
               
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Opportunity Rating";
                lblEntryB.InnerText = "Edit Opportunity Rating";
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

                lblEntry.InnerText = "View Opportunity Rating";
                lblEntryB.InnerText = "View Opportunity Rating";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Opportunity Rating";
                lblEntryB.InnerText = "Add Opportunity Rating";

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
            clsEntityLeadRating objEntityLeadRating = new clsEntityLeadRating();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeadRating.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLeadRating.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
           
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityLeadRating.LeadRateStatus = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityLeadRating.LeadRateStatus = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLeadRating.LeadRateId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityLeadRating.LeadRateUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityLeadRating.LeadRateDate = System.DateTime.Now;
            txtLeadRating.Text = txtLeadRating.Text.ToUpper().Trim();
            objEntityLeadRating.LeadRateName = txtLeadRating.Text;
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerLeadRate.Check_Lead_rate_NameUpdation(objEntityLeadRating);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                 DataTable dtComplaintDetail = objBusinessLayerLeadRate.ReadLeadrateById(objEntityLeadRating);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["LD_RATE_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["LD_RATE_CNCL_USR_ID"].ToString() == null)
                     {
                         if (txtLeadRating.Text != "")
                         {
                             objBusinessLayerLeadRate.Update_LeadRate(objEntityLeadRating);
                             if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                             {
                                 Response.Redirect("gen_Lead_Rate_Master.aspx?InsUpd=Upd");
                             }
                             else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                             {
                                 Response.Redirect("gen_Lead_Rate_MasterList.aspx?InsUpd=Upd");
                             }
                         }
                         else
                         {
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
                     else
                     {
                         Response.Redirect("gen_Lead_Rate_MasterList.aspx?InsUpd=AlCncl");
                     }
                 }

            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtLeadRating.Focus();
            }
        }
    }
    //when save button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityLeadRating objEntityLeadRating = new clsEntityLeadRating();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeadRating.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLeadRating.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityLeadRating.LeadRateStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityLeadRating.LeadRateStatus = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityLeadRating.LeadRateUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityLeadRating.LeadRateDate = System.DateTime.Now;
        txtLeadRating.Text = txtLeadRating.Text.ToUpper().Trim();
        objEntityLeadRating.LeadRateName = txtLeadRating.Text;

        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerLeadRate.CheckLeadRateName(objEntityLeadRating);

         //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerLeadRate.AddLeadRateMstr(objEntityLeadRating);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Lead_Rate_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Lead_Rate_MasterList.aspx?InsUpd=Ins");
            }
           
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtLeadRating.Focus();
        }
    }


    public void View(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityLeadRating objEntityLeadRating = new clsEntityLeadRating();
        objEntityLeadRating.LeadRateId = Convert.ToInt32(strP_Id);
        DataTable dtLeadRateById = objBusinessLayerLeadRate.ReadLeadrateById(objEntityLeadRating);
        if (dtLeadRateById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtLeadRating.Text = dtLeadRateById.Rows[0]["LDRATE_NAME"].ToString();
            int intLeadRateStatus = Convert.ToInt32(dtLeadRateById.Rows[0]["LDRATE_STATUS"]);
            if (intLeadRateStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtLeadRating.Enabled = false;
        cbxStatus.Disabled = true;
    }


    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityLeadRating objEntityLeadRating = new clsEntityLeadRating();
        objEntityLeadRating.LeadRateId = Convert.ToInt32(strP_Id);
        DataTable dtLeadRateById = objBusinessLayerLeadRate.ReadLeadrateById(objEntityLeadRating);
        if (dtLeadRateById.Rows.Count > 0)
        {
            
            txtLeadRating.Text = dtLeadRateById.Rows[0]["LDRATE_NAME"].ToString();
            int intLeadRateStatus = Convert.ToInt32(dtLeadRateById.Rows[0]["LDRATE_STATUS"]);
            if (intLeadRateStatus == 1)
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