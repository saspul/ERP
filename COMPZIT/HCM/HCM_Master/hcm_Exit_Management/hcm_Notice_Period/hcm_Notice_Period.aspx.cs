using BL_Compzit;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Notice_Period_hcm_Notice_Period : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       

        ddlDesgntn.Attributes.Add("onkeypress", "return isTag(event)");
        ddlDesgntn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNtcPrddays.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return isTag(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            DesigntnLoad();
           
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
           
            //when editing 

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notice_Period);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        HiddnEnableCacel.Value = "1";
                        intEnableCancel = 1;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = 1;

                    }

                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

            }
            else
            {



            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

            }
            else
            {
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

            }
            else
            {

            }

            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Notice Period";

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.Text = "View Notice Period";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                ddlDesgntn.Enabled = false;
                txtNtcPrddays.Enabled = false;
                cbxStatus.Enabled = false;
            }
           

            else
            {
                lblEntry.Text = "Add Notice Period";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
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

  
    public void DesigntnLoad()
    {
       clsBusinessLayerNoticePeriod objBusinessNoticePeriod=new clsBusinessLayerNoticePeriod();
       clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

       if (Session["CORPOFFICEID"] != null)
       {

           objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


       }
       else if (Session["CORPOFFICEID"] == null)
       {
           Response.Redirect("/Default.aspx");
       }
       if (Session["ORGID"] != null)
       {
           objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
       }
       else if (Session["ORGID"] == null)
       {
           Response.Redirect("/Default.aspx");
       }
       DataTable dtCountry = objBusinessNoticePeriod.ReadDesgntn(objEntityNoticePeriod);

       ddlDesgntn.Items.Clear();

       ddlDesgntn.DataSource = dtCountry;

       ddlDesgntn.DataTextField = "DSGN_NAME";
       ddlDesgntn.DataValueField = "DSGN_ID";
       ddlDesgntn.DataBind();

       ddlDesgntn.Items.Insert(0, "--SELECT DESIGNATION--");
      



    }


   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityNoticePeriod.Status = 1;
        }
        else
        {
            objEntityNoticePeriod.Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityNoticePeriod.UserDate = System.DateTime.Now;

        objEntityNoticePeriod.DesgntnId = Convert.ToInt32(ddlDesgntn.SelectedItem.Value);

       

       DataTable strcount = objBusinessNoticePeriod.CheckDuplctn(objEntityNoticePeriod);
        if (strcount.Rows.Count>0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
        }
        else
        {
            objEntityNoticePeriod.NoticePrdId = Convert.ToInt32(txtNtcPrddays.Text);
            objBusinessNoticePeriod.AddNoticePrdDtls(objEntityNoticePeriod);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_Notice_Period.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Notice_Period_List.aspx?InsUpd=Ins");
            }

        }

    }

    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
           
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityNoticePeriod.Status = 1;
        }
        else
        {
            objEntityNoticePeriod.Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
     
        objEntityNoticePeriod.UserDate = System.DateTime.Now;

        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityNoticePeriod.NoticePrdId = Convert.ToInt32(strId);
        objEntityNoticePeriod.DesgntnId = Convert.ToInt32(ddlDesgntn.SelectedItem.Value);
        DataTable strcount = objBusinessNoticePeriod.CheckDuplctn(objEntityNoticePeriod);
        if (strcount.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
        }
        else
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(txtNtcPrddays.Text);
            objBusinessNoticePeriod.UpdateNoticePrd(objEntityNoticePeriod);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("hcm_Notice_Period.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("hcm_Notice_Period_List.aspx?InsUpd=Upd");
                }

        }       
        }

    }

    
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

        btnUpdateClose.Visible = true;
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        if (Session["USERID"] != null)
        {
            objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notice_Period);
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

            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;

            }
        }

        objEntityNoticePeriod.NoticePrdId = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBusinessNoticePeriod.ReadNoticePrdDtlsById(objEntityNoticePeriod);
       if(dtSponsor.Rows.Count>0){
           if (ddlDesgntn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()) != null)
           //if (dtSponsor.Rows[0]["DSGN_ID"].ToString() != "" && dtSponsor.Rows[0]["DSGN_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["DSGN_CNCL_USR_ID"].ToString() == "")
           {
               ddlDesgntn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
           }
           else
           {
               ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DSGN_NAME"].ToString(), dtSponsor.Rows[0]["DSGN_ID"].ToString());
               ddlDesgntn.Items.Insert(1, lstGrp);
               SortDDL(ref this.ddlDesgntn);
               ddlDesgntn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
           }
        
        txtNtcPrddays.Text = dtSponsor.Rows[0]["NTCPRD_DAYS"].ToString();
        int intStatus = Convert.ToInt32(dtSponsor.Rows[0]["NTCPRD_STATUS"]);
        if (intStatus == 1)
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