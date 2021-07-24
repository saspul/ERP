using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using BL_Compzit.HCM;
using EL_Compzit.HCM;
using System.Collections;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

public partial class HCM_HCM_Master_gen_Job_Description_Master_gen_Job_Description_Master : System.Web.UI.Page
{
    clsBusiness_Job_Description_Master objBusinessJobDesrp = new clsBusiness_Job_Description_Master();


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit_Hcm.master";
        }
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      //  ddlDivision.Focus();
        //Assigning  Key actions  .

        ddlDivision.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDep.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlDep.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddldesgn.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddldesgn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlpaygrd.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlpaygrd.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddltyppos.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddltyppos.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlreportdesg.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlreportdesg.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtSumrypos.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txtSumrypos.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDesiredQual.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txtDesiredQual.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtManSklls.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txtManSklls.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEdu.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txtEdu.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCertTrain.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txtCertTrain.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtMinExp.Attributes.Add("onkeypress", "return isTag(event)");
        txtMinExp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txt_job_respblty.Attributes.Add("onkeypress", "return isTagMultTxt(event)");
        txt_job_respblty.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        
     
        if (!IsPostBack)
        {
           // Corp_DivisionLoad();
            Corp_DepartmentLoad();
            PayGradeLoad();
            DesignationLoad();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

             int  intUserRoleRecall=0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
             //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Interview_Template);
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

                     if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {

                btnUpdate.Visible = false;

            }
           
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
            //btnAddNext.Visible = false;
            //  btnSkip.Visible = false;
            //when editing 

           

            if (Request.QueryString["Id"] != null)
            {
                
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenJobId.Value = strId;
                Update(strId);
                lblEntry.Text = "Edit Job Description";

           

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Job Description";
                if (Request.QueryString["RFGP"] != null)
                {
                    btnCancel.Visible = false;
                    divList.Visible = false;
                }
            }
          
            else
            {
                lblEntry.Text = "Add Job Description";


              


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

                    else if (strInsUpd == "PrjIns")
                    {
                        //  btnSkip.Visible = true;
                        //  btnAddNext.Visible = true;
                       // btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrj", "SuccessConfirmationPrj();", true);
                    }
                    else if (strInsUpd == "PrjUpd")
                    {
                        //    btnSkip.Visible = true;
                        //   btnAddNext.Visible = true;
                       // btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrj", "SuccessUpdationPrj();", true);
                    }
                }






            }
        }
    }
   
    public void Corp_DepartmentLoad()
    {
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessJobDesrp.ReadDepartment(objEntityJobDesrp);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDep.DataSource = dtSubConrt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }
        
        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");   //EMP25
      
    }

    public void PayGradeLoad()
    {
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessJobDesrp.ReadPayGrade(objEntityJobDesrp);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlpaygrd.DataSource = dtSubConrt;
            ddlpaygrd.DataTextField = "PYGRD_NAME";
            ddlpaygrd.DataValueField = "PYGRD_ID";
            ddlpaygrd.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlpaygrd.Items.Insert(0, "--SELECT PAY GRADE--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    public void DesignationLoad()
    {
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessJobDesrp.ReadDesignation(objEntityJobDesrp);
        DataTable dtDesgReport= objBusinessJobDesrp.ReadDesignationReport(objEntityJobDesrp);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddldesgn.DataSource = dtSubConrt;
            ddldesgn.DataTextField = "DSGN_NAME";
            ddldesgn.DataValueField = "DSGN_ID";
            ddldesgn.DataBind();
           

        }
        if (dtDesgReport.Rows.Count > 0)
        {
            ddlreportdesg.DataSource = dtDesgReport;
            ddlreportdesg.DataTextField = "DSGN_NAME";
            ddlreportdesg.DataValueField = "DSGN_ID";
            ddlreportdesg.DataBind();
        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddldesgn.Items.Insert(0, "--SELECT DESIGNATION--");
        ddlreportdesg.Items.Insert(0, "--SELECT DESIGNATION--");
        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
       
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

       
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id= Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
       
             
      
     
        objEntityJobDesrp.D_Date = System.DateTime.Now;
       

        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        objEntityJobDesrp.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
          if(ddlDep.SelectedItem.Value!="--SELECT DEPARTMENT--")
          objEntityJobDesrp.Deprt_Id = Convert.ToInt32(ddlDep.SelectedItem.Value);
         objEntityJobDesrp.DesgId = Convert.ToInt32(ddldesgn.SelectedItem.Value);
         objEntityJobDesrp.PayGradeId = Convert.ToInt32(ddlpaygrd.SelectedItem.Value);
          objEntityJobDesrp.PostnTyp = Convert.ToInt32(ddltyppos.SelectedItem.Value);
          objEntityJobDesrp.PostnRprtDesgId = Convert.ToInt32(ddlreportdesg.SelectedItem.Value);


           objEntityJobDesrp.MinExprnce=Convert.ToInt32(txtMinExp.Text);

        if (txtSumrypos.Text != "" && txtSumrypos.Text != null)
            objEntityJobDesrp.SummryPostn = txtSumrypos.Text;

        if (txtDesiredQual.Text != "" && txtDesiredQual.Text != null)
            objEntityJobDesrp.DesiredQual = txtDesiredQual.Text;

            if (txtManSklls.Text != "" && txtManSklls.Text != null)
            objEntityJobDesrp.MandtrySkls = txtManSklls.Text;

              if (txtEdu.Text != "" && txtEdu.Text != null)
            objEntityJobDesrp.Education = txtEdu.Text;

            if (txtCertTrain.Text != "" && txtCertTrain.Text != null)
                objEntityJobDesrp.CertfcnTraing = txtCertTrain.Text;
            objEntityJobDesrp.JobRspblty= txt_job_respblty.Text;
            objEntityJobDesrp.MinExprnce =Convert.ToInt32(txtMinExp.Text);
            objBusinessJobDesrp.AddJobDescptn(objEntityJobDesrp);


     //   string strcount = objBusinessEmployeeSponsor.CheckEmployeeSponsor(objEntityEmployee);
        //if (strcount == "1")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);


        //}
        //else
        //{
        // //   objBusinessEmployeeSponsor.AddEmployeeSponsor(objEntityEmployee);



          if (clickedButton.ID == "btnAdd")
          {
              Response.Redirect("gen_Job_Description_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Ins");
           }




        //}

    }
    //when submit update button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        objEntityJobDesrp.JobDescrpId =Convert.ToInt32(HiddenJobId.Value);

        objEntityJobDesrp.D_Date = System.DateTime.Now;


        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            objEntityJobDesrp.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
            objEntityJobDesrp.Deprt_Id = Convert.ToInt32(ddlDep.SelectedItem.Value);
        //objEntityJobDesrp.DesgId = Convert.ToInt32(ddldesgn.SelectedItem.Value);
        objEntityJobDesrp.PayGradeId = Convert.ToInt32(ddlpaygrd.SelectedItem.Value);
        objEntityJobDesrp.PostnTyp = Convert.ToInt32(ddltyppos.SelectedItem.Value);
        objEntityJobDesrp.PostnRprtDesgId = Convert.ToInt32(ddlreportdesg.SelectedItem.Value);


        objEntityJobDesrp.MinExprnce = Convert.ToInt32(txtMinExp.Text);

        if (txtSumrypos.Text != "" && txtSumrypos.Text != null)
            objEntityJobDesrp.SummryPostn = txtSumrypos.Text;

        if (txtDesiredQual.Text != "" && txtDesiredQual.Text != null)
            objEntityJobDesrp.DesiredQual = txtDesiredQual.Text;

        if (txtManSklls.Text != "" && txtManSklls.Text != null)
            objEntityJobDesrp.MandtrySkls = txtManSklls.Text;

        if (txtEdu.Text != "" && txtEdu.Text != null)
            objEntityJobDesrp.Education = txtEdu.Text;

        if (txtCertTrain.Text != "" && txtCertTrain.Text != null)
            objEntityJobDesrp.CertfcnTraing = txtCertTrain.Text;
        objEntityJobDesrp.JobRspblty = txt_job_respblty.Text;
        objEntityJobDesrp.MinExprnce = Convert.ToInt32(txtMinExp.Text);
        objBusinessJobDesrp.UpdateJobDescptn(objEntityJobDesrp);


        //   string strcount = objBusinessEmployeeSponsor.CheckEmployeeSponsor(objEntityEmployee);
        //if (strcount == "1")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);


        //}
        //else
        //{
        // //   objBusinessEmployeeSponsor.AddEmployeeSponsor(objEntityEmployee);



        if (clickedButton.ID == "btnUpdate")
        {
            Response.Redirect("gen_Job_Description_Master.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Upd");
        }




        //}

    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        ddldesgn.Enabled = false;
        btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Description);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;

            }



        }





        objEntityJobDesrp.JobDescrpId = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBusinessJobDesrp.ReadJobDescrpnById(objEntityJobDesrp);
        if (dtSponsor.Rows.Count > 0)
        {

            if (dtSponsor.Rows[0]["CPRDIV_ID"].ToString() != null && dtSponsor.Rows[0]["CPRDIV_ID"].ToString() != "")
            {
                ddlDivision.ClearSelection();
                if (dtSponsor.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()) != null)
                    {
                        ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DIVISION"].ToString(), dtSponsor.Rows[0]["CPRDIV_ID"].ToString());
                        ddlDivision.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlDivision);

                        ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;

                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DIVISION"].ToString(), dtSponsor.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
            }



            if (dtSponsor.Rows[0]["CPRDEPT_ID"].ToString() != null && dtSponsor.Rows[0]["CPRDEPT_ID"].ToString() != "")
            {
                ddlDep.ClearSelection();
                if (dtSponsor.Rows[0]["CPRDEPT_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["CPRDEPT_CNCL_USR_ID"].ToString() == "")
                {
                    ddlDep.Items.FindByValue(dtSponsor.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DEPARTMENT"].ToString(), dtSponsor.Rows[0]["CPRDEPT_ID"].ToString());
                    ddlDep.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDep);

                    ddlDep.Items.FindByValue(dtSponsor.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                }
              
            }

            ddldesgn.ClearSelection();
         
            if (dtSponsor.Rows[0]["A_DESGSTATUS"].ToString() == "1" && dtSponsor.Rows[0]["A_DESGCNCL_USR_ID"].ToString() == "")
            {
                if (ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()) != null)
                ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                   else
                   {
                       ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DESIGNATION"].ToString(), dtSponsor.Rows[0]["DSGN_ID"].ToString());
                       ddldesgn.Items.Insert(1, lstGrp);

                       SortDDL(ref this.ddldesgn);

                       ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                   }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DESIGNATION"].ToString(), dtSponsor.Rows[0]["DSGN_ID"].ToString());
                ddldesgn.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
            }
            ddlpaygrd.ClearSelection();
            if (dtSponsor.Rows[0]["PYGRD_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["PYGRD_CNCL_USR_ID"].ToString() == "")
            {
                ddlpaygrd.Items.FindByValue(dtSponsor.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["PAY_GRADE"].ToString(), dtSponsor.Rows[0]["PYGRD_ID"].ToString());
                ddlpaygrd.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddlpaygrd.Items.FindByValue(dtSponsor.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            ddltyppos.ClearSelection();
            ddltyppos.Items.FindByValue(dtSponsor.Rows[0]["TYPE OF POSITION"].ToString()).Selected = true;
            ddlreportdesg.ClearSelection();
            if (dtSponsor.Rows[0]["B_DESGSTATUS"].ToString() == "1" && dtSponsor.Rows[0]["b_DESGCNCL_USR_ID"].ToString() == "")
            {
                ddlreportdesg.Items.FindByValue(dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["POSTN_DESIG"].ToString(), dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString());
                ddlreportdesg.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddlreportdesg.Items.FindByValue(dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString()).Selected = true;
            }

            if (dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString() != null && dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString() != "")
                txtMinExp.Text = dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != "")
                txtDesiredQual.Text = dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != "")
                txtSumrypos.Text = dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString() != null && dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString() != "")
                txtManSklls.Text = dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString() != null && dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString() != "")
                txtEdu.Text = dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString() != null && dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString() != "")
                txtCertTrain.Text = dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString();

            txt_job_respblty.Text = dtSponsor.Rows[0]["JOBDES_JOB_RSPBLTY"].ToString();
           // txtMinExp.Text = dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString();
          
  


        }
   

    }

    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        //   clsEntitySponsor objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0;
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        objEntityJobDesrp.JobDescrpId = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBusinessJobDesrp.ReadJobDescrpnById(objEntityJobDesrp);
        if (dtSponsor.Rows.Count > 0)
        {

            if (dtSponsor.Rows[0]["CPRDIV_ID"].ToString() != null && dtSponsor.Rows[0]["CPRDIV_ID"].ToString() != "")
            {
                ddlDivision.ClearSelection();
                if (dtSponsor.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()) != null)
                        ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    else
                    {
                        ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DIVISION"].ToString(), dtSponsor.Rows[0]["CPRDIV_ID"].ToString());
                        ddlDivision.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlDivision);

                        ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }

                }
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DIVISION"].ToString(), dtSponsor.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
            }



            if (dtSponsor.Rows[0]["CPRDEPT_ID"].ToString() != null && dtSponsor.Rows[0]["CPRDEPT_ID"].ToString() != "")
            {
                ddlDep.ClearSelection();
                if (dtSponsor.Rows[0]["CPRDEPT_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["CPRDEPT_CNCL_USR_ID"].ToString() == "")
                {
                    ddlDep.Items.FindByValue(dtSponsor.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DEPARTMENT"].ToString(), dtSponsor.Rows[0]["CPRDEPT_ID"].ToString());
                    ddlDep.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDep);

                    ddlDep.Items.FindByValue(dtSponsor.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                }

            }

            ddldesgn.ClearSelection();
            if (dtSponsor.Rows[0]["A_DESGSTATUS"].ToString() == "1" && dtSponsor.Rows[0]["A_DESGCNCL_USR_ID"].ToString() == "")
            {
                if (ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()) != null)
                ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DESIGNATION"].ToString(), dtSponsor.Rows[0]["DSGN_ID"].ToString());
                    ddldesgn.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddldesgn);

                    ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["DESIGNATION"].ToString(), dtSponsor.Rows[0]["DSGN_ID"].ToString());
                ddldesgn.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddldesgn.Items.FindByValue(dtSponsor.Rows[0]["DSGN_ID"].ToString()).Selected = true;
            }
            ddlpaygrd.ClearSelection();
            if (dtSponsor.Rows[0]["PYGRD_STATUS"].ToString() == "1" && dtSponsor.Rows[0]["PYGRD_CNCL_USR_ID"].ToString() == "")
            {
                ddlpaygrd.Items.FindByValue(dtSponsor.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["PAY_GRADE"].ToString(), dtSponsor.Rows[0]["PYGRD_ID"].ToString());
                ddlpaygrd.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddlpaygrd.Items.FindByValue(dtSponsor.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            ddltyppos.ClearSelection();
            ddltyppos.Items.FindByValue(dtSponsor.Rows[0]["TYPE OF POSITION"].ToString()).Selected = true;
            ddlreportdesg.ClearSelection();
            if (dtSponsor.Rows[0]["B_DESGSTATUS"].ToString() == "1" && dtSponsor.Rows[0]["b_DESGCNCL_USR_ID"].ToString() == "")
            {
                ddlreportdesg.Items.FindByValue(dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["POSTN_DESIG"].ToString(), dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString());
                ddlreportdesg.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddldesgn);

                ddlreportdesg.Items.FindByValue(dtSponsor.Rows[0]["JOBDES_POSTN_REPT_DSGN_ID"].ToString()).Selected = true;
            }

            if (dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString() != null && dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString() != "")
                txtMinExp.Text = dtSponsor.Rows[0]["JOBDES_MIN_EXP"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != "")
                txtDesiredQual.Text = dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != "")
                txtSumrypos.Text = dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString() != null && dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString() != "")
                txtManSklls.Text = dtSponsor.Rows[0]["JOBDES_MANDATORY_SKILLS"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString() != null && dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString() != "")
                txtEdu.Text = dtSponsor.Rows[0]["JOBDES_EDUCATION"].ToString();

            if (dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString() != null && dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString() != "")
                txtCertTrain.Text = dtSponsor.Rows[0]["JOBDES_CERTF_TRANG"].ToString();

            txt_job_respblty.Text = dtSponsor.Rows[0]["JOBDES_JOB_RSPBLTY"].ToString();



        }

        ddlDivision.Enabled = false;
        ddlDep.Enabled = false;
        ddldesgn.Enabled = false;
        ddlpaygrd.Enabled = false;
        ddltyppos.Enabled = false;
        ddlreportdesg.Enabled = false;
        txtMinExp.Enabled = false;
        txtSumrypos.Enabled = false;
        txtDesiredQual.Enabled = false;
        txtManSklls.Enabled = false;
        txtEdu.Enabled = false;
        txtCertTrain.Enabled = false;
        txt_job_respblty.Enabled = false;
        txtMinExp.Enabled = false;
   

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

    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDep.SelectedItem.Value);
            objEntityJobDesrp.Deprt_Id = Dept;
            DataTable dtDivision = objBusinessJobDesrp.ReadDivision(objEntityJobDesrp);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtDivision.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtDivision;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }
        ddlDep.Focus();
    }
}