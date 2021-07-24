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
using EL_Compzit.EntityLayer_HCM;
using System.Collections;
using BL_Compzit.BusineesLayer_HCM;
//using EL_Compzit.EntityLayer_HCM;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections.Generic;

// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:


public partial class HCM_HCM_Master_gen_Interview_Temp_Master_gen_Interview_Temp_Master : System.Web.UI.Page
{
    clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
    protected void Page_Load(object sender, EventArgs e)
    {


        cbxValidateSts.Attributes.Add("onkeypress", "return isTag(event)");
        cbxValidateSts.Attributes.Add("onclick", "return IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return isTag(event)");
        cbxStatus.Attributes.Add("onclick", "return IncrmntConfrmCounter()");
        txtTemplateName.Attributes.Add("onkeypress", "return isTag(event)");
              txtTemplateName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            txtTemplateName.Focus();
            DropDownCatagory();
            DropDownTyp();
            HiddenUpdateChk.Value = "";
            HiddenFieldDuplcnChk.Value = "";
            hiddenTemNextId.Value = "0";
            btnClear.Visible = false;
            clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
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

                btnUpdate.Visible = true;

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

                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgid.Value = Session["ORGID"].ToString();
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

               // btnClear.Visible = false;
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;

                }
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenJobId.Value = strId;
                HiddenUpdateChk.Value = strId;
               Update(strId);
                lblEntry.Text = "Edit Interview Template";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
              //  btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Interview Template";
            }

            else
            {
                lblEntry.Text = "Add Interview Template";





                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
               // btnClear.Visible = true;
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
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }




        objEntityIntrvTem.D_Date = System.DateTime.Now;


        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);



        if (txtTemplateName.Text != "" && txtTemplateName.Text != null)
            objEntityIntrvTem.TemplateNme = txtTemplateName.Text.Trim().ToUpper();

        if (cbxStatus.Checked == true)
        {
            objEntityIntrvTem.TempSts = 1;
        }
        else {
            objEntityIntrvTem.TempSts = 0;
        }
        if (cbxValidateSts.Checked == true)
        {
            objEntityIntrvTem.ValidateSts = 1;
        }
        else
        {
            objEntityIntrvTem.ValidateSts = 0;
        }

        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_TEMPLATE);
        //objEntityCommon.CorporateID = objEntityIntrvTem.CorpOffice_Id;
        //objEntityCommon.Organisation_Id = objEntityIntrvTem.Organisation_Id;
        //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        //objEntityIntrvTem.NextTempId = Convert.ToInt32(strNextId);
       
     //   objBusinessJobDesrp.AddJobDescptn(objEntityIntrvTem);

        List<clsEntityInterviewShedule> objEntityIntervSheduleList = new List<clsEntityInterviewShedule>();
        if (HiddenIntervw_Tem.Value != "")
        {
            string jsonData = HiddenIntervw_Tem.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsIntervTemData> objSheduleList = new List<clsIntervTemData>();
            //   UserData  data
            objSheduleList = JsonConvert.DeserializeObject<List<clsIntervTemData>>(i);
            foreach (clsIntervTemData objclsIntrv in objSheduleList)
            {
                //clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();
                clsEntityInterviewShedule objEntityIntervShedule = new clsEntityInterviewShedule();
                objEntityIntervShedule.sheduleNme = objclsIntrv.LNKTXT.ToUpper();
                objEntityIntervShedule.CatagryId = Convert.ToInt32(objclsIntrv.CATID);
                objEntityIntervShedule.ShdlTypId = Convert.ToInt32(objclsIntrv.SHEDTYPID);
                objEntityIntervShedule.ScoreStsstatus = Convert.ToInt32(objclsIntrv.SCORECHK);
                // objEntityDetails.RcptNumber = objclsWBData.RCPTNUMBR;
                // objEntityDetails.Rcptdate = objCommon.textToDateTime(objclsWBData.RCPTDATE.ToString());
                // objEntityDetails.VhclId = Convert.ToInt32(objclsWBData.VHCLID);
                //   objEntityDetails.RcptAmnt = Convert.ToDecimal(objclsWBData.AMOUNT);



                objEntityIntervSheduleList.Add(objEntityIntervShedule);

            }
        }
        string strdupAllownce = "";
        strdupAllownce = objBusinessIntrvTem.DuplCheckIntervwTem(objEntityIntrvTem);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            int intNextIdId = objBusinessIntrvTem.Insert_Interv_Templates(objEntityIntrvTem, objEntityIntervSheduleList);

            hiddenTemNextId.Value = intNextIdId.ToString();

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Interview_Temp_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Ins");
            }

        }
        else
        {
            HiddenFieldDuplcnChk.Value = "1";
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationIntervwTemName", "DuplicationIntervwTemName();", true);
        }


        //}

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        objEntityIntrvTem.NextTempId = Convert.ToInt32(hiddenTemNextId.Value);
        objEntityIntrvTem.D_Date = System.DateTime.Now;


        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);



        if (txtTemplateName.Text != "" && txtTemplateName.Text != null)
            objEntityIntrvTem.TemplateNme = txtTemplateName.Text.Trim().ToUpper();

        if (cbxStatus.Checked == true)
        {
            objEntityIntrvTem.TempSts = 1;
        }
        else
        {
            objEntityIntrvTem.TempSts = 0;
        }
        if (cbxValidateSts.Checked == true)
        {
            objEntityIntrvTem.ValidateSts = 1;
        }
        else
        {
            objEntityIntrvTem.ValidateSts = 0;
        }

        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_TEMPLATE);
        //objEntityCommon.CorporateID = objEntityIntrvTem.CorpOffice_Id;
        //objEntityCommon.Organisation_Id = objEntityIntrvTem.Organisation_Id;
        //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        //objEntityIntrvTem.NextTempId = Convert.ToInt32(strNextId);

        //   objBusinessJobDesrp.AddJobDescptn(objEntityIntrvTem);

        List<clsEntityInterviewShedule> objEntityIntervSheduleInsList = new List<clsEntityInterviewShedule>();
        List<clsEntityInterviewShedule> objEntityIntervSheduleUpdList = new List<clsEntityInterviewShedule>();
        if (HiddenIntervw_Tem.Value != "")
        {
            string jsonData = HiddenIntervw_Tem.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsIntervTemData> objSheduleList = new List<clsIntervTemData>();
            //   UserData  data
            objSheduleList = JsonConvert.DeserializeObject<List<clsIntervTemData>>(i);
            foreach (clsIntervTemData objclsIntrv in objSheduleList)
            {
                if (objclsIntrv.EVTACTION == "INS")
                {
                    //clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();
                    clsEntityInterviewShedule objEntityIntervShedule = new clsEntityInterviewShedule();
                    objEntityIntervShedule.sheduleNme = objclsIntrv.LNKTXT.ToUpper();
                    objEntityIntervShedule.CatagryId = Convert.ToInt32(objclsIntrv.CATID);
                    objEntityIntervShedule.ShdlTypId = Convert.ToInt32(objclsIntrv.SHEDTYPID);
                    objEntityIntervShedule.ScoreStsstatus = Convert.ToInt32(objclsIntrv.SCORECHK);
                    // objEntityDetails.RcptNumber = objclsWBData.RCPTNUMBR;
                    // objEntityDetails.Rcptdate = objCommon.textToDateTime(objclsWBData.RCPTDATE.ToString());
                    // objEntityDetails.VhclId = Convert.ToInt32(objclsWBData.VHCLID);
                    //   objEntityDetails.RcptAmnt = Convert.ToDecimal(objclsWBData.AMOUNT);
                    objEntityIntervSheduleInsList.Add(objEntityIntervShedule);
                }
                else if (objclsIntrv.EVTACTION == "UPD")
                {
                    clsEntityInterviewShedule objEntityIntervShedule = new clsEntityInterviewShedule();
                    objEntityIntervShedule.sheduleNme = objclsIntrv.LNKTXT.ToUpper();
                    objEntityIntervShedule.CatagryId = Convert.ToInt32(objclsIntrv.CATID);
                    objEntityIntervShedule.ShdlTypId = Convert.ToInt32(objclsIntrv.SHEDTYPID);
                    objEntityIntervShedule.ScoreStsstatus = Convert.ToInt32(objclsIntrv.SCORECHK);
                    objEntityIntervShedule.ShedulId = Convert.ToInt32(objclsIntrv.DTLID);
                    objEntityIntervSheduleUpdList.Add(objEntityIntervShedule);
                }



            }
        }
        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
        {
            strCanclDtlId = hiddenCanclDtlId.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }
        objBusinessIntrvTem.Update_Interv_Templates(objEntityIntrvTem, objEntityIntervSheduleInsList, objEntityIntervSheduleUpdList, strarrCancldtlIds);
       // hiddenTemNextId.Value = intNextIdId.ToString(); ;
        if (clickedButton.ID == "btnUpdate")
        {
            hiddenEdit.Value = "";
            Response.Redirect("gen_Interview_Temp_Master.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Upd");
        }




        //}

    }
   
         private void View(string intrvwTemId)
    {//when Editing 
        
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        objEntityIntrvTem.NextTempId = Convert.ToInt32(intrvwTemId);
        hiddenTemNextId.Value = intrvwTemId.ToString() ;
         if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
      

     
            if (Session["ORGID"] != null)
            {
                objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
       
        DataTable dtIntervw = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtIntervw = objBusinessIntrvTem.ReadIntervwTemDetails(objEntityIntrvTem);



        if (dtIntervw.Rows.Count > 0)
        {

            if (dtIntervw.Rows[0]["TEMPLATE NAME"].ToString() != "" || dtIntervw.Rows[0]["TEMPLATE NAME"].ToString() != null)
            {
                txtTemplateName.Text = dtIntervw.Rows[0]["TEMPLATE NAME"].ToString();

            }
            if (dtIntervw.Rows[0]["INVTEM_VALIDT_LVL"].ToString() != "" || dtIntervw.Rows[0]["INVTEM_VALIDT_LVL"].ToString() != null)
            {
                if (dtIntervw.Rows[0]["INVTEM_VALIDT_LVL"].ToString() == "1")
                {
                    cbxValidateSts.Checked = true;
                }
                else
                {
                    cbxValidateSts.Checked = false;
                }
            }
            if (dtIntervw.Rows[0]["INVTEM_STATUS"].ToString() != "" || dtIntervw.Rows[0]["INVTEM_STATUS"].ToString() != null)
            {
                if (dtIntervw.Rows[0]["INVTEM_STATUS"].ToString() == "1")
                {
                    cbxStatus.Checked = true;
                }
                else
                {
                    cbxStatus.Checked = false;
                }
            }



            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();

           // HiddenTempDetailId.Value=

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TempDetlId", typeof(int));
            dtDetail.Columns.Add("SheduleName", typeof(string));
            dtDetail.Columns.Add("CatgoryId", typeof(int));
            dtDetail.Columns.Add("TempTypId", typeof(int));
            dtDetail.Columns.Add("ScoreSts", typeof(string));
            dtDetail.Columns.Add("CatgryName", typeof(string));
            dtDetail.Columns.Add("Catgrysts", typeof(int));
           // dtDetail.Columns.Add("VhclId", typeof(int));
          //  dtDetail.Columns.Add("Amount", typeof(decimal));


            for (int intcnt = 0; intcnt < dtIntervw.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TempDetlId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["INVTEM_DTLS_ID"].ToString());
                drDtl["SheduleName"] = dtIntervw.Rows[intcnt]["INVTEM_DLS_SHEDL_NAME"].ToString();
                drDtl["CatgoryId"] =Convert.ToInt32( dtIntervw.Rows[intcnt]["INTWCTGRY_ID"].ToString());
                drDtl["TempTypId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["SHEDL_TYP_ID"].ToString());
                drDtl["ScoreSts"] =Convert.ToInt32(dtIntervw.Rows[intcnt]["INVTEM_DTLS_SCORE_STS"].ToString());
                drDtl["CatgryName"] = dtIntervw.Rows[intcnt]["INTWCTGRY_NAME"].ToString();
                drDtl["Catgrysts"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["INTWCTGRY_STATUS"].ToString());
               // drDtl["VhclId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["VHCL_ID"].ToString());
               // drDtl["Amount"] = Convert.ToDecimal(dtIntervw.Rows[intcnt]["RCPT_AMNT"].ToString());

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            //if (intEditOrView == 1)
            //{
        
              //  btnReOpen.Visible = false;
                hiddenView.Value = strJson;
          //  }
            //else if (intEditOrView == 2)
            //{

            //  btnSave.Visible = false;
            //    btnSaveClose.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    btnConfirm.Visible = false;
            //    hiddenView.Value = strJson;
            //}


        }
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        txtTemplateName.Enabled = false;
        cbxValidateSts.Enabled = false;
        cbxStatus.Enabled = false;
    }

    private void Update(string intrvwTemId)
    {//when Editing 
        
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        objEntityIntrvTem.NextTempId = Convert.ToInt32(intrvwTemId);
        hiddenTemNextId.Value = intrvwTemId.ToString() ;
       // btnUpdate.Visible = true;
         if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
      

     
            if (Session["ORGID"] != null)
            {
                objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
       
        DataTable dtIntervw = new DataTable();
        //   DataTable dtWBill = new DataTable();
        DataTable dtIntervwTxt = new DataTable();

        dtIntervw = objBusinessIntrvTem.ReadIntervwTemDetails(objEntityIntrvTem);
        dtIntervwTxt = objBusinessIntrvTem.ReadIntervwTemDetailsTxt(objEntityIntrvTem);



        if (dtIntervwTxt.Rows.Count > 0)
        {

            if (dtIntervwTxt.Rows[0]["TEMPLATE NAME"].ToString() != "" || dtIntervwTxt.Rows[0]["TEMPLATE NAME"].ToString() != null)
            {
                txtTemplateName.Text = dtIntervwTxt.Rows[0]["TEMPLATE NAME"].ToString();

            }
            if (dtIntervwTxt.Rows[0]["INVTEM_VALIDT_LVL"].ToString() != "" || dtIntervwTxt.Rows[0]["INVTEM_VALIDT_LVL"].ToString() != null)
            {
                if (dtIntervwTxt.Rows[0]["INVTEM_VALIDT_LVL"].ToString() == "1")
                {
                    cbxValidateSts.Checked = true;
                }
                else
                {
                    cbxValidateSts.Checked = false;
                }
            }
            if (dtIntervwTxt.Rows[0]["INVTEM_STATUS"].ToString() != "" || dtIntervwTxt.Rows[0]["INVTEM_STATUS"].ToString() != null)
            {
                if (dtIntervwTxt.Rows[0]["INVTEM_STATUS"].ToString() == "1")
                {
                    cbxStatus.Checked = true;
                }
                else
                {
                    cbxStatus.Checked = false;
                }
            }



            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();

           // HiddenTempDetailId.Value=

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TempDetlId", typeof(int));
            dtDetail.Columns.Add("SheduleName", typeof(string));
            dtDetail.Columns.Add("CatgoryId", typeof(int));
            dtDetail.Columns.Add("TempTypId", typeof(int));
            dtDetail.Columns.Add("ScoreSts", typeof(string));
            dtDetail.Columns.Add("CatgryName", typeof(string));
            dtDetail.Columns.Add("Catgrysts", typeof(int));
          //  dtDetail.Columns.Add("Amount", typeof(decimal));


            for (int intcnt = 0; intcnt < dtIntervw.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TempDetlId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["INVTEM_DTLS_ID"].ToString());
                drDtl["SheduleName"] = dtIntervw.Rows[intcnt]["INVTEM_DLS_SHEDL_NAME"].ToString();
                drDtl["CatgoryId"] =Convert.ToInt32( dtIntervw.Rows[intcnt]["INTWCTGRY_ID"].ToString());
                drDtl["TempTypId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["SHEDL_TYP_ID"].ToString());
                drDtl["ScoreSts"] =Convert.ToInt32(dtIntervw.Rows[intcnt]["INVTEM_DTLS_SCORE_STS"].ToString());
                drDtl["CatgryName"] = dtIntervw.Rows[intcnt]["INTWCTGRY_NAME"].ToString();
                drDtl["Catgrysts"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["INTWCTGRY_STATUS"].ToString());
                // drDtl["Amount"] = Convert.ToDecimal(dtIntervw.Rows[intcnt]["RCPT_AMNT"].ToString());INTWCTGRY_STATUS

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            //if (intEditOrView == 1)
            //{
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
              //  btnReOpen.Visible = false;
                hiddenEdit.Value = strJson;
          //  }
            //else if (intEditOrView == 2)
            //{

            //    btnSave.Visible = false;
            //    btnSaveClose.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    btnConfirm.Visible = false;
            //    hiddenView.Value = strJson;
            //}


        }
    }

    public void DropDownCatagory()
    {
        
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadCatagoryTypLoad(objEntityIntrvTem);
        dtEmployeeList.TableName = "dtTableCatgryTyp";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        HiddenddlLoad.Value = result;
    }
    public void DropDownTyp()
    {

        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadShedTypLoad(objEntityIntrvTem);
        dtEmployeeList.TableName = "dtTableShdleTyp";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        Hiddenddltyp.Value = result;
    }

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    public class clsIntervTemData
    {
        public string ROWID { get; set; }
        public string LNKTXT { get; set; }
        public string CATID { get; set; }
        public string SHEDTYPID { get; set; }
        public string SCORECHK { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    [WebMethod]
    public static string LoadSheduleTypddl1()
    {
        clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessIntrvTem.ReadShedTypLoad(objEntityIntrvTem);
        dtCorpDetail.TableName = "dtTableShdleTyp";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }
    [WebMethod]
    public static string LoadCatgryddl1(string IntCorpId,string IntOrgId)
    {
        clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(IntCorpId);
        objEntityIntrvTem.Organisation_Id = Convert.ToInt32(IntOrgId);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessIntrvTem.ReadCatagoryTypLoad(objEntityIntrvTem);
        dtCorpDetail.TableName = "dtTableCatgryTyp";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }
    
           [WebMethod]
    public static string DuplcnTempNameChk(string name, string IntCorpId, string IntOrgId, string TempId)
    {
        clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();
        objEntityIntrvTem.TemplateNme = name;
        string result = "";
        objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(IntCorpId);
        objEntityIntrvTem.Organisation_Id = Convert.ToInt32(IntOrgId);
        objEntityIntrvTem.NextTempId = Convert.ToInt32(TempId);
        string strChk="";
        strChk = objBusinessIntrvTem.DuplCheckIntervwTem(objEntityIntrvTem);
        if (strChk == "" || strChk == "0")
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;
    }
 
}