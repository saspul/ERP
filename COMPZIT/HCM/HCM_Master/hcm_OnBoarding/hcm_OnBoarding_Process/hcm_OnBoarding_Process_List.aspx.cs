using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
using System.Collections;

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Process_hcm_OnBoarding_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtTargetDate1.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate2.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate3.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate4.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate5.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate6.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate7.Attributes.Add("onkeypress", "return isTag(event)");
        txtTargetDate8.Attributes.Add("onkeypress", "return isTag(event)");

      
        if (!IsPostBack)
        {
            HiddenBundleName.Value = "";
            FillDropdown();
            clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
            ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
          //  VisaBundleLoad();
            hiddenVisaFileDeleted.Value = "";
            hiddenFlightTicketFileDeleted.Value = "";

            radioNotAssigned.Checked = true;
            ddlVisaType.Items.Clear();
            ddlVisaType.Items.Insert(0, "--VISA PROFESSION--");

            ddlVisatype2.Items.Clear();
            ddlVisatype2.Items.Insert(0, "--VISA PROFESSION--");
            ddlVisaBund.Items.Insert(0, "--VISA QUOTA--");
            ddlVisaBund2.Items.Insert(0, "--VISA QUOTA--");
            //DataTable dtCandidateList = new DataTable();
            //dtCandidateList.Columns.Add("CANDIDATE ID", typeof(int));
            //dtCandidateList.Columns.Add("CANDIDATE NAME", typeof(int));
            //dtCandidateList.Columns.Add("LOCATION", typeof(string));
            //dtCandidateList.Columns.Add("REFERENCE", typeof(string));
            //dtCandidateList.Columns.Add("NATIONALITY", typeof(string));
            //dtCandidateList.Columns.Add("FILE NAME", typeof(string));
            //dtCandidateList.Columns.Add("VISAID", typeof(string));
            //dtCandidateList.Columns.Add("VISA", typeof(string));

            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;
            int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.ONBOARDING_VISA);
            hiddenVisaFileSize.Value = intImageMaxSize.ToString();
            intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.ONBOARDING_FLIGHTTICKET);
            hiddenFlightTicketFileSize.Value = intImageMaxSize.ToString();



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "PrcsAsgn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "PrcsAsgnUpd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Rcl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                }

            }
        }


    }

    protected void ddlVisaBund_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intBundleId = 0;
        if (ddlVisaBund.SelectedItem.Value != "--VISA QUOTA--")
        {
            intBundleId = Convert.ToInt32(ddlVisaBund.SelectedItem.Value);
            hiddenBundleId.Value = intBundleId.ToString();
            LoadVisaTyp(intBundleId);
         

        }
   

    }
    protected void ddlVisaBund2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intBundleId = 0;
        if (hiddenBundleId.Value != "--VISA QUOTA--")
        {
            intBundleId = Convert.ToInt32(hiddenBundleId.Value);
            LoadVisaTyp2(intBundleId);
            VisaBundleLoad(intBundleId);
        }
     

    }
    public void LoadVisaTyp2(int X)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityOnBoard.VisaBundleId = X;
        if (HiddenCountryid.Value != "")
        {
            objEntityOnBoard.CountryId = Convert.ToInt32(HiddenCountryid.Value);
            DataTable dtSubConrt = objBusinessOnboard.ReadVisaBundleType(objEntityOnBoard);
            for (int i = dtSubConrt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtSubConrt.Rows[i];
                objEntityOnBoard.VisatypeId = Convert.ToInt32(dr["VISATYP_ID"]);
                int CountVisa = Convert.ToInt32(dr["VISQT_DTLS_NUM_VISA"]);
                DataTable dtCount = objBusinessOnboard.ReadVisaTypeCount(objEntityOnBoard);
                if (dtCount.Rows.Count > 0)
                {
                    int remngcount = Convert.ToInt32(dtCount.Rows[0]["COUNT"].ToString());
                    CountVisa = CountVisa - remngcount;
                    if (CountVisa <= 0)
                        dr.Delete();
                }
            }
            ddlVisatype2.ClearSelection();
            ddlVisatype2.Items.Clear();
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisatype2.DataSource = dtSubConrt;
                ddlVisatype2.DataTextField = "VISA_NAME";
                ddlVisatype2.DataValueField = "VISATYP_ID";
                ddlVisatype2.DataBind();

            }
        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlVisatype2.Items.Insert(0, "--VISA PROFESSION--");
    }
    public void LoadVisaTyp(int X)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityOnBoard.VisaBundleId = X;
        if (HiddenCountryid.Value != "")
        {
            objEntityOnBoard.CountryId = Convert.ToInt32(HiddenCountryid.Value);
            DataTable dtSubConrt = objBusinessOnboard.ReadVisaBundleType(objEntityOnBoard);
            for (int i = dtSubConrt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtSubConrt.Rows[i];
                objEntityOnBoard.VisatypeId = Convert.ToInt32(dr["VISATYP_ID"]);
                int CountVisa = Convert.ToInt32(dr["VISQT_DTLS_NUM_VISA"]);
                DataTable dtCount = objBusinessOnboard.ReadVisaTypeCount(objEntityOnBoard);
                if (dtCount.Rows.Count > 0)
                {
                    int remngcount = Convert.ToInt32(dtCount.Rows[0]["COUNT"].ToString());
                    CountVisa = CountVisa - remngcount;
                    if (CountVisa <= 0)
                        dr.Delete();
                }
            }

            ddlVisaType.ClearSelection();
            ddlVisaType.Items.Clear();
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisaType.DataSource = dtSubConrt;
                ddlVisaType.DataTextField = "VISA_NAME";
                ddlVisaType.DataValueField = "VISATYP_ID";
                ddlVisaType.DataBind();

            }
        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlVisaType.Items.Insert(0, "--VISA PROFESSION--");
    }
    public void VisaBundleLoad(int x)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
                if (HiddenCountryid.Value != "")
        {
            ddlVisaBund.ClearSelection();
            ddlVisaBund.Items.Clear();
            objEntityOnBoard.CountryId = Convert.ToInt32(HiddenCountryid.Value);
        DataTable dtSubConrt = objBusinessOnboard.ReadVisaBundle(objEntityOnBoard);
       
        ddlVisaBund2.ClearSelection();
        ddlVisaBund2.Items.Clear();
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlVisaBund2.DataSource = dtSubConrt;
            ddlVisaBund2.DataTextField = "VISQT_NUM";
            ddlVisaBund2.DataValueField = "VISQT_ID";
            ddlVisaBund2.DataBind();

        }
      
        }
                int id =Convert.ToInt32( hiddenBundleId.Value);
                if (HiddenBundleName.Value != "")
                {
                    ddlVisaBund2.Items.Insert(0, "--VISA QUOTA--");

                    if (ddlVisaBund2.Items.FindByValue(hiddenBundleId.Value) != null)
                    {
                        ddlVisaBund2.Items.FindByValue(hiddenBundleId.Value).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(HiddenBundleName.Value, hiddenBundleId.Value);
                        ddlVisaBund2.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlVisaBund2);

                       // ddlVisaBund2.Items.FindByValue(dtSponsor.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;

                    }
                }
                ddlVisaBund2.Items.FindByValue(x.ToString()).Selected = true;
      
    }
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


    protected void btnVisaBundle_Click(object sender, EventArgs e)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlVisaBund.ClearSelection();
        ddlVisaBund.Items.Clear();
        ddlVisaType.Items.Clear();
        ddlVisaType.Items.Insert(0, "--VISA PROFESSION--");
        if (HiddenCountryid.Value != "")
        {
            objEntityOnBoard.CountryId = Convert.ToInt32(HiddenCountryid.Value);
            DataTable dtSubConrt = objBusinessOnboard.ReadVisaBundle(objEntityOnBoard);
        

            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisaBund.DataSource = dtSubConrt;
                ddlVisaBund.DataTextField = "VISQT_NUM";
                ddlVisaBund.DataValueField = "VISQT_ID";
                ddlVisaBund.DataBind();


            }
        }
        ddlVisaBund.Items.Insert(0, "--VISA QUOTA--");
        ScriptManager.RegisterStartupScript(this, GetType(), "SelectedCandidate", "SelectedCandidate();", true);
    
    }

    public void FillDropdown()
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtManpwr = objBusinessOnboard.ReadAprvdManPwrReqstList(objEntityOnBoard);
        if (dtManpwr.Rows.Count > 0)
        {
            ddlManPower.DataSource = dtManpwr;
            ddlManPower.DataTextField = "REF#";
            ddlManPower.DataValueField = "MNPRQST_ID";
            ddlManPower.DataBind();

        }

        ddlManPower.Items.Insert(0, "--SELECT MANPOWER--");

        DataTable dtEmployee = objBusinessOnboard.ReadEmployee(objEntityOnBoard);
        if (dtEmployee.Rows.Count > 0)
        {
            ddlEmp1.DataSource = dtEmployee;
            ddlEmp1.DataTextField = "USR_NAME";
            ddlEmp1.DataValueField = "USR_ID";
            ddlEmp1.DataBind();

            ddlEmp2.DataSource = dtEmployee;
            ddlEmp2.DataTextField = "USR_NAME";
            ddlEmp2.DataValueField = "USR_ID";
            ddlEmp2.DataBind();

            ddlEmp3.DataSource = dtEmployee;
            ddlEmp3.DataTextField = "USR_NAME";
            ddlEmp3.DataValueField = "USR_ID";
            ddlEmp3.DataBind();

            ddlEmp4.DataSource = dtEmployee;
            ddlEmp4.DataTextField = "USR_NAME";
            ddlEmp4.DataValueField = "USR_ID";
            ddlEmp4.DataBind();

            ddlEmp5.DataSource = dtEmployee;
            ddlEmp5.DataTextField = "USR_NAME";
            ddlEmp5.DataValueField = "USR_ID";
            ddlEmp5.DataBind();

            ddlEmp6.DataSource = dtEmployee;
            ddlEmp6.DataTextField = "USR_NAME";
            ddlEmp6.DataValueField = "USR_ID";
            ddlEmp6.DataBind();

            ddlEmp7.DataSource = dtEmployee;
            ddlEmp7.DataTextField = "USR_NAME";
            ddlEmp7.DataValueField = "USR_ID";
            ddlEmp7.DataBind();

            ddlEmp8.DataSource = dtEmployee;
            ddlEmp8.DataTextField = "USR_NAME";
            ddlEmp8.DataValueField = "USR_ID";
            ddlEmp8.DataBind();


        }

        //DataTable dtVisaType = objBusinessOnboard.ReadVisaType(objEntityOnBoard);
        //if (dtVisaType.Rows.Count > 0)
        //{

        //    ddlVisaType.DataSource = dtVisaType;
        //    ddlVisaType.DataTextField = "VISA_NAME";
        //    ddlVisaType.DataValueField = "VISATYP_ID";
        //    ddlVisaType.DataBind();

        //    ddlVisatype2.DataSource = dtVisaType;
        //    ddlVisatype2.DataTextField = "VISA_NAME";
        //    ddlVisatype2.DataValueField = "VISATYP_ID";
        //    ddlVisatype2.DataBind();
        //}
        DataTable dtVehicle = objBusinessOnboard.ReadVehicle(objEntityOnBoard);
        if (dtVehicle.Rows.Count > 0)
        {
            ddlVehicle.DataSource = dtVehicle;
            ddlVehicle.DataTextField = "VHCL_NUMBR";
            ddlVehicle.DataValueField = "VHCL_ID";
            ddlVehicle.DataBind();

            ddlVehicle2.DataSource = dtVehicle;
            ddlVehicle2.DataTextField = "VHCL_NUMBR";
            ddlVehicle2.DataValueField = "VHCL_ID";
            ddlVehicle2.DataBind();
        }


        ddlVehicle.Items.Insert(0, "--VEHICLE--");
        ddlVisaType.Items.Insert(0, "--VISA PROFESSION--");

        ddlVehicle2.Items.Insert(0, "--VEHICLE--");
        ddlVisatype2.Items.Insert(0, "--VISA PROFESSION--");
    }



    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" OnkeyPress=\"return DisableEnter(event)\" style=\"margin-left: 23%;\" onchange=\"selectAllCandidate()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

                 if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        
        }
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;display:none;\"></th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;display:none;\"></th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                count++;
                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" OnkeyPress=\"return DisableEnter(event)\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\"></td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string reference = "";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    

                    }

                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        {
                            reference = "Consultancy";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                        {
                            reference = "Division";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                        {
                            reference = "Department";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                        {
                            reference = "Employee";
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + reference + "</td>";
                    }



                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                                " href=\"" + imgpath + dt.Rows[intRowBodyCount][6].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";

                    }
                    else if (intColumnBodyCount == 8)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

                    }
                   
                }
                strHtml += "<td id=\"tdCountryid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["CNTRY_ID"].ToString() + "</td>";
                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "|" + dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() + "</td>";
                strHtml += "<td id=\"tdManRqstid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() + "</td>";
                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

    

        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToHTMLAssigned(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:35%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">EDIT</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count++;
            strHtml += "<tr  >";

            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

            string strId = dt.Rows[intRowBodyCount][0].ToString();

            string reference = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "Consultancy";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "Division";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "Department";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "Employee";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + reference + "</td>";
                }



                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                            " href=\"" + imgpath + dt.Rows[intRowBodyCount][6].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";

                }


            }

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"><a class=\"tooltip\" title=\"Edit\" onclick=\"return ProcessEdit('" + strId + "');\" ><img  style=\"cursor:pointer;margin-left: 10%;float: left;\" src='/Images/Icons/edit.png' /></a> </td>";


            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
           

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        if (radioNotAssigned.Checked == true)
        {
            btnOnBoard.Visible = true;
            objEntityOnBoard.StatusId = 0;

            if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityOnBoard.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            }
            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;

        }
        else
        {
            btnOnBoard.Visible = false;
            objEntityOnBoard.StatusId = 1;
            if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityOnBoard.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            }

            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;
        }

    }

    public void SearchClick()
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        if (radioNotAssigned.Checked == true)
        {
            btnOnBoard.Visible = true;
            objEntityOnBoard.StatusId = 0;

            if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityOnBoard.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            }
            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;

        }
        else
        {
            btnOnBoard.Visible = false;
            objEntityOnBoard.StatusId = 1;
            if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityOnBoard.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            }

            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;
        }
    }
    protected void btnProcessMultySave_Click(object sender, EventArgs e)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

     string strManPwrId=  HiddenManPwrId.Value;
     string[] ArrManPwrId = strManPwrId.Split(',');
     foreach (string strRqstId in ArrManPwrId)
     {
         if (strRqstId != "")
         {
             objEntityOnBoard.ReqstID = Convert.ToInt32(strRqstId);

             int intOnBoardId = objBusinessOnboard.Insert_OnBoardProcess(objEntityOnBoard);

             string strTotalCandidate = Hiddenchecklist.Value;
             string[] strEachCandidate = strTotalCandidate.Split(',');

             ClsEntityOnBoardingProcess objEntityOnBoardVisa = new ClsEntityOnBoardingProcess();
             ClsEntityOnBoardingProcess objEntityOnBoardFlight = new ClsEntityOnBoardingProcess();
             ClsEntityOnBoardingProcess objEntityOnBoardRoom = new ClsEntityOnBoardingProcess();
             ClsEntityOnBoardingProcess objEntityOnBoardAirport = new ClsEntityOnBoardingProcess();
             List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList1 = new List<ClsEntityOnBoardingProcess>();
             List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList2 = new List<ClsEntityOnBoardingProcess>();
             List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList3 = new List<ClsEntityOnBoardingProcess>();
             List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList4 = new List<ClsEntityOnBoardingProcess>();
             clsCommonLibrary objCommon = new clsCommonLibrary();

             int intImageSectionVisa = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);
             string strImgPathVisa = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);
             //Visa

             if (FileUploadVisaMulty.HasFile)
             {
                 // GET FILE EXTENSION
                 string strFileExt;
                 objEntityOnBoardVisa.ActFileName = FileUploadVisaMulty.FileName;
                 strFileExt = FileUploadVisaMulty.FileName.Substring(FileUploadVisaMulty.FileName.LastIndexOf('.') + 1).ToLower();
                 string strImageName = intImageSectionVisa.ToString() + "_" + intOnBoardId + "." + strFileExt;
                 objEntityOnBoardVisa.FileName = strImageName;
             }

             int intImageSectionFlightTicket = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);
             string strImgPathFlightTicket = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);

             //FlightTicket

             if (FileUploadFlightTicketMulty.HasFile)
             {
                 // GET FILE EXTENSION
                 string strFileExt;
                 objEntityOnBoardFlight.ActFileName = FileUploadFlightTicketMulty.FileName;
                 strFileExt = FileUploadFlightTicketMulty.FileName.Substring(FileUploadFlightTicketMulty.FileName.LastIndexOf('.') + 1).ToLower();
                 string strImageName = intImageSectionFlightTicket.ToString() + "_" + intOnBoardId + "." + strFileExt;
                 objEntityOnBoardFlight.FileName = strImageName;
             }

             foreach (string SSstrCandId in strEachCandidate)
             {
                 if (SSstrCandId != "")
                 {
                     string[] arrstrCandId = SSstrCandId.Split('|');
                    string strCandId = arrstrCandId[0];
                     if(arrstrCandId[1]==strRqstId)
                     {
                     objEntityOnBoardVisa.OnboardingId = intOnBoardId;
                     objEntityOnBoardVisa.CandId = Convert.ToInt32(strCandId);
                     objEntityOnBoardVisa.ParticularId = 1;
                     objEntityOnBoardVisa.StatusId = Convert.ToInt32(ddlVisaStatus.SelectedItem.Value);
                     if (txtTargetDate1.Text != "")
                         objEntityOnBoardVisa.UsrDate = ObjCommon.textToDateTime(txtTargetDate1.Text);
                     if (ddlVisaType.SelectedItem.Value != "--VISA PROFESSION--")
                         objEntityOnBoardVisa.VisatypeId = Convert.ToInt32(ddlVisaType.SelectedItem.Value);

                                   if (ddlVisaBund.SelectedItem.Value != "--VISA QUOTA--")
                                       objEntityOnBoardVisa.VisaBundleId = Convert.ToInt32(ddlVisaBund.SelectedItem.Value);
                         
                     objEntityOnBoardVisa.Finishstatus = 0;

                     objEntityOnBoardVisa.CloseStatusId = 0;

                     string TotalEmp = hiddenEmp1.Value;

                     string[] EachEmpId = TotalEmp.Split(',');

                     foreach (string EmpId in EachEmpId)
                     {
                         if (EmpId != "")
                         {
                             ClsEntityOnBoardingProcess objEntityOnBoardVisaEmp = new ClsEntityOnBoardingProcess();
                             objEntityOnBoardVisaEmp.EmployeeId = Convert.ToInt32(EmpId);
                             objEntityOnBoardVisaEmpList1.Add(objEntityOnBoardVisaEmp);
                         }
                     }



                     objEntityOnBoardFlight.OnboardingId = intOnBoardId;
                     objEntityOnBoardFlight.CandId = Convert.ToInt32(strCandId);
                     objEntityOnBoardFlight.ParticularId = 2;
                     objEntityOnBoardFlight.StatusId = Convert.ToInt32(ddlFlightStatus.SelectedItem.Value);
                     if (txtTargetDate2.Text != "")
                         objEntityOnBoardFlight.UsrDate = ObjCommon.textToDateTime(txtTargetDate2.Text);
                     if (ddlFlightTcktType.SelectedItem.Value != "0")
                         objEntityOnBoardFlight.FlightTypeId = Convert.ToInt32(ddlFlightTcktType.SelectedItem.Value);

                     objEntityOnBoardFlight.Finishstatus = 0;

                     objEntityOnBoardFlight.CloseStatusId = 0;




                     string TotalEmp2 = hiddenEmp2.Value;

                     string[] EachEmpId2 = TotalEmp2.Split(',');

                     foreach (string EmpId2 in EachEmpId2)
                     {
                         if (EmpId2 != "")
                         {
                             ClsEntityOnBoardingProcess objEntityOnBoardFlightEmp = new ClsEntityOnBoardingProcess();
                             objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                             objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
                         }
                     }


                     objEntityOnBoardRoom.OnboardingId = intOnBoardId;
                     objEntityOnBoardRoom.CandId = Convert.ToInt32(strCandId);
                     objEntityOnBoardRoom.ParticularId = 3;
                     objEntityOnBoardRoom.StatusId = Convert.ToInt32(ddlRoomAltmntStats.SelectedItem.Value);
                     if (txtTargetDate3.Text != "")
                         objEntityOnBoardRoom.UsrDate = ObjCommon.textToDateTime(txtTargetDate3.Text);
                     if (ddlRoomAltmntType.SelectedItem.Value != "")
                         objEntityOnBoardRoom.RoomTypeId = Convert.ToInt32(ddlRoomAltmntType.SelectedItem.Value);

                     objEntityOnBoardRoom.Finishstatus = 0;

                     objEntityOnBoardRoom.CloseStatusId = 0;

                     string TotalEmp3 = hiddenEmp3.Value;

                     string[] EachEmpId3 = TotalEmp3.Split(',');

                     foreach (string EmpId3 in EachEmpId3)
                     {
                         if (EmpId3 != "")
                         {
                             ClsEntityOnBoardingProcess objEntityOnBoardRoomEmp = new ClsEntityOnBoardingProcess();
                             objEntityOnBoardRoomEmp.EmployeeId = Convert.ToInt32(EmpId3);
                             objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardRoomEmp);
                         }
                     }


                     objEntityOnBoardAirport.OnboardingId = intOnBoardId;
                     objEntityOnBoardAirport.CandId = Convert.ToInt32(strCandId);
                     objEntityOnBoardAirport.ParticularId = 4;
                     objEntityOnBoardAirport.StatusId = Convert.ToInt32(ddlAirPickStats.SelectedItem.Value);
                     if (txtTargetDate4.Text != "")
                         objEntityOnBoardAirport.UsrDate = ObjCommon.textToDateTime(txtTargetDate4.Text);
                     if (ddlVehicle.SelectedItem.Value != "--VEHICLE--")
                         objEntityOnBoardAirport.VehicleId = Convert.ToInt32(ddlVehicle.SelectedItem.Value);

                     objEntityOnBoardAirport.Finishstatus = 0;

                     objEntityOnBoardAirport.CloseStatusId = 0;

                     string TotalEmp4 = hiddenEmp4.Value;

                     string[] EachEmpId4 = TotalEmp4.Split(',');

                     foreach (string EmpId4 in EachEmpId4)
                     {
                         if (EmpId4 != "")
                         {
                             ClsEntityOnBoardingProcess objEntityOnBoardAirEmp = new ClsEntityOnBoardingProcess();
                             objEntityOnBoardAirEmp.EmployeeId = Convert.ToInt32(EmpId4);
                             objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardAirEmp);
                         }
                     }



                     objBusinessOnboard.Insert_Process_Detail(objEntityOnBoard, objEntityOnBoardVisa, objEntityOnBoardFlight, objEntityOnBoardRoom, objEntityOnBoardAirport, objEntityOnBoardVisaEmpList1, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4);
                 }

                 }


             }

             //FlightTicket
             if (FileUploadFlightTicketMulty.HasFile)
             {
                 FileUploadFlightTicketMulty.SaveAs(Server.MapPath(strImgPathFlightTicket) + objEntityOnBoardFlight.FileName);
             }

             //visa
             if (FileUploadVisaMulty.HasFile)
             {
                 FileUploadVisaMulty.SaveAs(Server.MapPath(strImgPathVisa) + objEntityOnBoardVisa.FileName);
             }

             ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
             ScriptManager.RegisterStartupScript(this, GetType(), "CloseProcessMulty", "CloseProcessMulty();", true);
             SearchClick();
         }
     }
        //Response.Redirect("hcm_OnBoarding_Process_List.aspx?InsUpd=PrcsAsgn");
    }


    [WebMethod]
    public static string[] ReadCandidateData(int intCandId)
    {
        string[] CandData = new string[8];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.CandId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadCandidateById(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["CAND_NAME"].ToString();
            CandData[1] = dtCandData.Rows[0]["CAND_LOC"].ToString();

            if (dtCandData.Rows[0]["CAND_REF"].ToString() == "1")
            {
                CandData[2] = "Consultancy";
            }
            else if (dtCandData.Rows[0]["CAND_REF"].ToString() == "2")
            {
                CandData[2] = "Division";
            }
            else if (dtCandData.Rows[0]["CAND_REF"].ToString() == "3")
            {
                CandData[2] = "Department";
            }
            else if (dtCandData.Rows[0]["CAND_REF"].ToString() == "4")
            {
                CandData[2] = "Employee";
            }

            CandData[3] = dtCandData.Rows[0]["CAND_ACT_RESUMENAME"].ToString();
            CandData[4] = imgpath + dtCandData.Rows[0]["CAND_RESUMENAME"].ToString();
            CandData[5] = dtCandData.Rows[0]["CNTRY_NAME"].ToString();

            if (dtCandData.Rows[0]["CAND_VISA"].ToString() == "0")
            {
                CandData[6] = "NO";
            }
            else
            {
                CandData[6] = "YES";
            }
            CandData[7] = dtCandData.Rows[0]["CNTRY_ID"].ToString();
        }


        return CandData;
    }

    [WebMethod]
    public static string[] ReadVisaData(int intCandId, int intorgid, int intcorpid, string intCountryid)
    {
        string[] CandData = new string[24];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.CandId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadVisaDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["ONBRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["ONBRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["ONBRD_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["ONBRD_CLOSE_STS"].ToString();

            CandData[5] = dtCandData.Rows[0]["VISATYP_ID"].ToString();
            CandData[7] = dtCandData.Rows[0]["VISA_STATUS"].ToString();
            CandData[8] = dtCandData.Rows[0]["VISA_NAME"].ToString();

            CandData[16] = dtCandData.Rows[0]["VISQT_ID"].ToString();
            CandData[17] = dtCandData.Rows[0]["VISQT_NUM"].ToString();

            objEntityOnBoard.Orgid = intorgid;
            objEntityOnBoard.CorpOffice = intcorpid;

            objEntityOnBoard.VisaBundleId = Convert.ToInt32(CandData[16]);
            DataTable dtVisatyp = objBusinessOnboard.ReadVisaBundleType(objEntityOnBoard);
            CandData[19] = "0";
            bool existsTyp = dtVisatyp.Select().ToList().Exists(row => row["VISATYP_ID"].ToString().ToUpper() == CandData[5]);
            if (existsTyp == true)
            {
                CandData[19] = "1";
            }

            dtVisatyp.TableName = "dtTableVisaTyp";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtVisatyp.WriteXml(sw);
                result = sw.ToString();
            }
            CandData[20] = result;
            if (intCountryid!="")
            objEntityOnBoard.CountryId =Convert.ToInt32( intCountryid);
          
            DataTable dtSubConrt = objBusinessOnboard.ReadVisaBundle(objEntityOnBoard);
            CandData[18] = "0";
            bool existsCus = dtSubConrt.Select().ToList().Exists(row => row["VISQT_ID"].ToString().ToUpper() == CandData[16]);
            if (existsCus == true)
            {
                CandData[18] = "1";
            }
            dtSubConrt.TableName = "dtTableVisaBund";
            string result1;
            using (StringWriter sw1 = new StringWriter())
            {

                dtSubConrt.WriteXml(sw1);
                result1 = sw1.ToString();
            }
            CandData[21] = result1;
            objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData.Rows[0]["ONBRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }

            }
            CandData[6] = strEmp;
            CandData[14] = Status;
            CandData[15] = UsrName;
            //visa
            if (dtCandData.Rows[0]["ONBRDDTL_FILENAME"] != DBNull.Value && dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString() != "")
            {
                CandData[9]  = dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();
                CandData[10] = dtCandData.Rows[0]["ONBRDDTL_ACT_FILENAME"].ToString();
                string strFileName = dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();
                
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA) + dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
               
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";

                CandData[11] = strImage;
            }

        }

        return CandData;
    }
    [WebMethod]
    public static string[] ReadFlightData(int intCandId)
    {
        string[] CandData = new string[20];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.CandId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["ONBRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["ONBRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["ONBRD_FNSH_STS"].ToString();
            CandData[4] =dtCandData.Rows[0]["ONBRD_CLOSE_STS"].ToString();
            CandData[5] = dtCandData.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString();

            objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData.Rows[0]["ONBRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }

            }
            CandData[6] = strEmp;
            CandData[14] = Status;
            CandData[15] = UsrName;

            //visa
            if (dtCandData.Rows[0]["ONBRDDTL_FILENAME"] != DBNull.Value && dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString() != "")
            {
                CandData[7] = dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();
                CandData[8] = dtCandData.Rows[0]["ONBRDDTL_ACT_FILENAME"].ToString();
                string strFileName = dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();

                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET) + dtCandData.Rows[0]["ONBRDDTL_FILENAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;

                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";

                CandData[9] = strImage;
            }

        }

        return CandData;
    }
    [WebMethod]
    public static string[] ReadRoomData(int intCandId)
    {
        string[] CandData = new string[20];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.CandId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadRoomDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["ONBRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["ONBRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["ONBRD_FNSH_STS"].ToString();
            CandData[4] =dtCandData.Rows[0]["ONBRD_CLOSE_STS"].ToString();
            CandData[5] = dtCandData.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString();

            objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData.Rows[0]["ONBRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }

            }
            CandData[6] = strEmp;
            CandData[14] = Status;
            CandData[15] = UsrName;


        }

        return CandData;
    }
    [WebMethod]
    public static string[] ReadAirData(int intCandId)
    {
        string[] CandData = new string[20];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.CandId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadAirDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["ONBRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["ONBRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["ONBRD_FNSH_STS"].ToString();
            CandData[4] =dtCandData.Rows[0]["ONBRD_CLOSE_STS"].ToString();
            CandData[5] = dtCandData.Rows[0]["VHCL_ID"].ToString();

            objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData.Rows[0]["ONBRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }

            }
            CandData[6] = strEmp;
            CandData[14] = Status;
            CandData[15] = UsrName;


        }

        return CandData;
    }
    protected void btnProcessSingleSave_Click(object sender, EventArgs e)
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ClsEntityOnBoardingProcess objEntityOnBoardVisa = new ClsEntityOnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoardFlight = new ClsEntityOnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoardRoom = new ClsEntityOnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoardAirport = new ClsEntityOnBoardingProcess();
        List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList1 = new List<ClsEntityOnBoardingProcess>();
        List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList2 = new List<ClsEntityOnBoardingProcess>();
        List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList3 = new List<ClsEntityOnBoardingProcess>();
        List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList4 = new List<ClsEntityOnBoardingProcess>();
        int intCandId = Convert.ToInt32(hiddenCandidateId.Value);

        //Visa

        int intImageSectionVisa = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);
        string strImgPathVisa = ObjCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);

        if (FileUploadVisaSingle.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityOnBoardVisa.ActFileName = FileUploadVisaSingle.FileName;
            strFileExt = FileUploadVisaSingle.FileName.Substring(FileUploadVisaSingle.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSectionVisa.ToString() + "_" + hiddenOnBoardDtlId1.Value + "." + strFileExt;
            objEntityOnBoardVisa.FileName = strImageName;
        }
        else
        {
            objEntityOnBoardVisa.FileName = hiddenVisaFile.Value;
            objEntityOnBoardVisa.ActFileName = hiddenVisaFileActual.Value;
        }

        int intImageSectionFlightTicket = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);
        string strImgPathFlightTicket = ObjCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);

        //FlightTicket

        if (FileUploadFlightTicketSingle.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityOnBoardFlight.ActFileName = FileUploadFlightTicketSingle.FileName;
            strFileExt = FileUploadFlightTicketSingle.FileName.Substring(FileUploadFlightTicketSingle.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSectionFlightTicket.ToString() + "_" + hiddenOnBoardDtlId1.Value + "." + strFileExt;
            objEntityOnBoardFlight.FileName = strImageName;
        }
        else
        {
            objEntityOnBoardFlight.FileName = hiddenFlightTicketFile.Value;
            objEntityOnBoardFlight.ActFileName = hiddenFlightTicketFileActual.Value;
        }


        objEntityOnBoardVisa.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId1.Value);
        objEntityOnBoardVisa.CandId = Convert.ToInt32(intCandId);
        objEntityOnBoardVisa.ParticularId = 1;
        objEntityOnBoardVisa.StatusId = Convert.ToInt32(ddlVisaStatus2.SelectedItem.Value);
        if (txtTargetDate5.Text != "")
            objEntityOnBoardVisa.UsrDate = ObjCommon.textToDateTime(txtTargetDate5.Text);
        if (ddlVisatype2.SelectedItem.Value != "--VISA PROFESSION--")
        {
            objEntityOnBoardVisa.VisatypeId = Convert.ToInt32(ddlVisatype2.SelectedItem.Value);
        }

        else
        {
            objEntityOnBoardVisa.VisatypeId = Convert.ToInt32(hiddenVisaTypeId.Value);
        }

        if (hiddenBundleId.Value != "--VISA QUOTA--")
        {
            objEntityOnBoardVisa.VisaBundleId = Convert.ToInt32(hiddenBundleId.Value);
        }

        else
        {
            objEntityOnBoardVisa.VisaBundleId = Convert.ToInt32(hiddenBundleId.Value);
        }
        string FinishStsTotal = hiddenFinishStatus.Value;

        if (FinishStsTotal.Contains("Visa2"))
        {
            objEntityOnBoardVisa.Finishstatus = 1;
            objEntityOnBoardVisa.FinishDate = DateTime.Today;
        }
        else
        {
            objEntityOnBoardVisa.Finishstatus = 0;
        }


        string TotalEmp = hiddenEmp1.Value;

        string[] EachEmpId = TotalEmp.Split(',');

        foreach (string EmpId in EachEmpId)
        {
            if (EmpId != "")
            {
                ClsEntityOnBoardingProcess objEntityOnBoardVisaEmp = new ClsEntityOnBoardingProcess();
                objEntityOnBoardVisaEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardVisaEmp.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId1.Value);
                objEntityOnBoardVisaEmp.EmployeeId = Convert.ToInt32(EmpId);
                objEntityOnBoardVisaEmpList1.Add(objEntityOnBoardVisaEmp);
            }
        }



        objEntityOnBoardFlight.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
        objEntityOnBoardFlight.CandId = Convert.ToInt32(intCandId);
        objEntityOnBoardFlight.ParticularId = 2;
        objEntityOnBoardFlight.StatusId = Convert.ToInt32(ddlFlightStatus2.SelectedItem.Value);
        if (txtTargetDate6.Text != "")
            objEntityOnBoardFlight.UsrDate = ObjCommon.textToDateTime(txtTargetDate6.Text);
        objEntityOnBoardFlight.FlightTypeId = Convert.ToInt32(ddlFlightTcktType2.SelectedItem.Value);
        if (FinishStsTotal.Contains("Flight2"))
        {
            objEntityOnBoardFlight.Finishstatus = 1;
            objEntityOnBoardFlight.FinishDate = DateTime.Today;
        }
        else
        {
            objEntityOnBoardFlight.Finishstatus = 0;
        }



        string TotalEmp2 = hiddenEmp2.Value;

        string[] EachEmpId2 = TotalEmp2.Split(',');

        foreach (string EmpId2 in EachEmpId2)
        {
            if (EmpId2 != "")
            {
                ClsEntityOnBoardingProcess objEntityOnBoardFlightEmp = new ClsEntityOnBoardingProcess();
                objEntityOnBoardFlightEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardFlightEmp.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
                objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
            }
        }


        objEntityOnBoardRoom.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
        objEntityOnBoardRoom.CandId = Convert.ToInt32(intCandId);
        objEntityOnBoardRoom.ParticularId = 3;
        objEntityOnBoardRoom.StatusId = Convert.ToInt32(ddlRoomAltmntStats2.SelectedItem.Value);
        if (txtTargetDate7.Text != "")
            objEntityOnBoardRoom.UsrDate = ObjCommon.textToDateTime(txtTargetDate7.Text);
        objEntityOnBoardRoom.RoomTypeId = Convert.ToInt32(ddlRoomAltmntType2.SelectedItem.Value);
        if (FinishStsTotal.Contains("Room2"))
        {
            objEntityOnBoardRoom.Finishstatus = 1;
            objEntityOnBoardRoom.FinishDate = DateTime.Today;
        }
        else
        {
            objEntityOnBoardRoom.Finishstatus = 0;
        }


        string TotalEmp3 = hiddenEmp3.Value;

        string[] EachEmpId3 = TotalEmp3.Split(',');

        foreach (string EmpId3 in EachEmpId3)
        {
            if (EmpId3 != "")
            {
                ClsEntityOnBoardingProcess objEntityOnBoardRoomEmp = new ClsEntityOnBoardingProcess();
                objEntityOnBoardRoomEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardRoomEmp.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
                objEntityOnBoardRoomEmp.EmployeeId = Convert.ToInt32(EmpId3);
                objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardRoomEmp);
            }
        }


        objEntityOnBoardAirport.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
        objEntityOnBoardAirport.CandId = Convert.ToInt32(intCandId);
        objEntityOnBoardAirport.ParticularId = 4;
        objEntityOnBoardAirport.StatusId = Convert.ToInt32(ddlAirPickStats2.SelectedItem.Value);
        if (txtTargetDate8.Text != "")
            objEntityOnBoardAirport.UsrDate = ObjCommon.textToDateTime(txtTargetDate8.Text);
        if (ddlVehicle2.SelectedItem.Value != "--VEHICLE--")
            objEntityOnBoardAirport.VehicleId = Convert.ToInt32(ddlVehicle2.SelectedItem.Value);
        if (FinishStsTotal.Contains("AirPick2"))
        {
            objEntityOnBoardAirport.Finishstatus = 1;
            objEntityOnBoardAirport.FinishDate = DateTime.Today;
        }
        else
        {
            objEntityOnBoardAirport.Finishstatus = 0;
        }



        string TotalEmp4 = hiddenEmp4.Value;

        string[] EachEmpId4 = TotalEmp4.Split(',');

        foreach (string EmpId4 in EachEmpId4)
        {
            if (EmpId4 != "")
            {
                ClsEntityOnBoardingProcess objEntityOnBoardAirEmp = new ClsEntityOnBoardingProcess();
                objEntityOnBoardAirEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardAirEmp.OnboardingDetailId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
                objEntityOnBoardAirEmp.EmployeeId = Convert.ToInt32(EmpId4);
                objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardAirEmp);
            }
        }
        objBusinessOnboard.UpdateVisaDtl(objEntityOnBoardVisa);
        objBusinessOnboard.UpdateFlightDtl(objEntityOnBoardFlight);
        objBusinessOnboard.UpdateRoomDtl(objEntityOnBoardRoom);
        objBusinessOnboard.UpdateAirDtl(objEntityOnBoardAirport);

        objBusinessOnboard.DeleteEmployee(objEntityOnBoardVisa);
        objBusinessOnboard.DeleteEmployee(objEntityOnBoardFlight);
        objBusinessOnboard.DeleteEmployee(objEntityOnBoardRoom);
        objBusinessOnboard.DeleteEmployee(objEntityOnBoardAirport);
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList1);
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList2);
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList3);
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList4);

        //FlightTicket
        if (FileUploadFlightTicketSingle.HasFile)
        {
            FileUploadFlightTicketSingle.SaveAs(Server.MapPath(strImgPathFlightTicket) + objEntityOnBoardFlight.FileName);
        }
        else
        {
            if (hiddenFlightTicketFileDeleted.Value != "")
            {
                System.IO.File.Delete(Server.MapPath(strImgPathFlightTicket) + hiddenFlightTicketFileDeleted.Value);

            }
        }
        //visa
        if (FileUploadVisaSingle.HasFile)
        {
            FileUploadVisaSingle.SaveAs(Server.MapPath(strImgPathVisa) + objEntityOnBoardVisa.FileName);
        }
        else
        {
            if (hiddenVisaFileDeleted.Value != "")
            {
                System.IO.File.Delete(Server.MapPath(strImgPathVisa) + hiddenVisaFileDeleted.Value);
            }

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);

        //Response.Redirect("hcm_OnBoarding_Process_List.aspx?InsUpd=PrcsAsgnUpd");
    }


    [WebMethod]
    public static string RecallProcess(int ProcessDetailId)
    {
        string Sucess = "true";
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.OnboardingDetailId = ProcessDetailId;

        objBusinessOnboard.RecallProcess(objEntityOnBoard);
        return Sucess;
    }
    [WebMethod]
    public static string CloseProcess(int ProcessDetailId)
    {
        string Sucess = "true";
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.OnboardingDetailId = ProcessDetailId;

        objBusinessOnboard.CloseProcess(objEntityOnBoard);
        return Sucess;
    }
       [WebMethod]
    public static int CheckVisanumber(string intvisbundleid, string intTypeid)
    {
        int  Count = 0;
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        if (intvisbundleid!="")
        objEntityOnBoard.VisaBundleId = Convert.ToInt32(intvisbundleid);
        objEntityOnBoard.VisatypeId = Convert.ToInt32(intTypeid);
        int CountVisa = 0;
        DataTable dtCount = objBusinessOnboard.ReadVisaTypeCount(objEntityOnBoard);
                DataTable dt = objBusinessOnboard.ReadVisaDetailbyid(objEntityOnBoard);
        if (dtCount.Rows.Count > 0)
        {
            if (dt.Rows.Count > 0)
            {
                 CountVisa = Convert.ToInt32(dt.Rows[0]["VISQT_DTLS_NUM_VISA"]);
            }
          
            int remngcount = Convert.ToInt32(dtCount.Rows[0]["COUNT"].ToString());
            CountVisa = CountVisa - remngcount;
            Count = CountVisa;
            if (CountVisa <= 0)
            {
                Count = 0;
            }
               
        }
        return Count;
    }
    
}