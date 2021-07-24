using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Globalization;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_Master : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    


        ddlmode.Focus();
        ddlEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlMonth.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlMonth.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlYear.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlYear.Attributes.Add("onkeypress", "return DisableEnter(event)");
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (!IsPostBack)
        {

            btn_Excel.Visible = false;
            Session["Succes"] = "";
           
            // DeductionLoad();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0, IntAllBusinessUnit = 0; ;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtemp = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Type_Master);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        IntAllBusinessUnit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
            }
            clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
            ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
            DataTable dtDep, dtDesg, dtbusinesunt, dtbank, dtPayerBank, dtSponsor;
            objEnt.CorprtId = Convert.ToInt32(intCorpId);
            objEnt.OrgId = Convert.ToInt32(intOrgId);
            objEnt.UserId = Convert.ToInt32(intUserId);

            YearLoad();
            monthLoad();
            int AllBussnsUnit = 0;
            if (IntAllBusinessUnit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                AllBussnsUnit = 1;
            }

            dtbusinesunt = objBuss.LoadBissnusUnit(objEnt, AllBussnsUnit);
            dtbank = objBuss.LoadBank(objEnt);
           // dtDivision = objBuss.LoadDivision(objEnt);

            dtDep = objBuss.LoadDep(objEnt);
            dtDesg = objBuss.LoadDesg(objEnt);
            dtSponsor = objBuss.LoadSponsor(objEnt);
            LoadBank(dtbank);
            LoadDep(dtDep);
            LoadDesg(dtDesg); busnsUnitLoad(dtbusinesunt);
           // LoadDivision(dtDivision);
            dtPayerBank=objBuss.LoadPayerBank(objEnt);
            LoadPayerBank(dtPayerBank);
            LoadSponsor(dtSponsor);
            //evm-0027

            //END

        }

    }
    public void LoadPayerBank(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            ddlPayerBank.DataSource = dt;
            ddlPayerBank.DataTextField = "BANK_NAME";
            ddlPayerBank.DataValueField = "BANK_ID";
            ddlPayerBank.DataBind();

        }
        ddlPayerBank.ClearSelection();
        ddlPayerBank.Items.Insert(0, "--SELECT BANK--");
    }
    public void LoadSponsor(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            ddlSponsor.DataSource = dt;
            ddlSponsor.DataTextField = "SPNSR_NAME";
            ddlSponsor.DataValueField = "SPSNSR_ID";
            ddlSponsor.DataBind();

        }
        ddlSponsor.ClearSelection();
        ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");
    }
    public void LoadBank(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            ddlBank.DataSource = dt;
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";
            ddlBank.DataBind();

        }
        ddlBank.ClearSelection();
        ddlBank.Items.Insert(0, "--SELECT BANK--");
    }
    //public void LoadDivision(DataTable dt)
    //{

    //    if (dt.Rows.Count > 0)
    //    {
    //        ddlDivision.DataSource = dt;
    //        ddlDivision.DataTextField = "CPRDIV_NAME";
    //        ddlDivision.DataValueField = "CPRDIV_ID";
    //        ddlDivision.DataBind();

    //    }
    //    ddlDivision.ClearSelection();
    //    ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    //}
    public void LoadEmployee(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }
    }
    public void LoadDep(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlDep.DataSource = dt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }
        ddlDep.ClearSelection();
        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public void LoadDesg(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddldesg.DataSource = dt;
            ddldesg.DataTextField = "DSGN_NAME";
            ddldesg.DataValueField = "DSGN_ID";
            ddldesg.DataBind();
        }
        ddldesg.ClearSelection();
        ddldesg.Items.Insert(0, "--SELECT DESIGNATION--");
    }
    public void busnsUnitLoad(DataTable dtDetails)
    {

        if (dtDetails.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtDetails;
            ddlEmployee.DataValueField = "CORPRT_ID";
            ddlEmployee.DataTextField = "CORPRT_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, "--SELECT BUSINESS UNIT--");
        }
    }
    protected void YearLoad()
    {

        ddlYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = -1; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            ddlYear.Items.Add((currentYear - i).ToString());

        }
        ddlYear.Items.Insert(0, "--SELECT YEAR--");

    }
    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT MONTH--");
    }

    protected void ExportToCSV_Click(object sender, EventArgs e)
    {
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MONTHLY_WPS_LIST);
        objEntityCommon.CorporateID = objEnt.CorprtId;

        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        objEnt.NxtID = Convert.ToInt32(strNextId);
        HiddennXTid.Value = strNextId;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT
                                                              };
        DataTable dtCorpDetail = new DataTable();
        DateTime intmnth;
        HiddenNetAmount.Value = "0";
        HiddenMonth.Value = "0";
        HiddenYear.Value = "0";
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
        }
        if (ddlmode.SelectedValue != "---SELECT MODE---")
        {
            objEnt.Mode = Convert.ToInt32(ddlmode.SelectedValue);
        }
        if (ddlBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
           // HiddenBankName.Value = ddlBank.SelectedItem.Text;
            Session["Bank"] = objEnt.BankId;
        }

        if (ddlPayerBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.PayerBankId = Convert.ToInt32(ddlPayerBank.SelectedItem.Value);
            HiddenBANK.Value = ddlPayerBank.SelectedItem.Text;
        }
        if (ddlmode.SelectedValue == "1")
        {
            objEnt.Month = Convert.ToInt32(ddlMonth.SelectedValue);
            objEnt.Year = Convert.ToInt32(ddlYear.SelectedValue);
            HiddenMonth.Value = Convert.ToString(objEnt.Month);
            HiddenYear.Value = Convert.ToString(objEnt.Year);
        }
        if (ddlDep.SelectedValue != "--SELECT DEPARTMENT--")
        {
            objEnt.Department = Convert.ToInt32(ddlDep.SelectedItem.Value);

        }

        if (ddldesg.SelectedValue != "--SELECT DESIGNATION--")
        {
            objEnt.Designation = Convert.ToInt32(ddldesg.SelectedItem.Value);
        }
        if (ddlDivision.SelectedValue != "--SELECT DIVISION--")
        {
            objEnt.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        //evm-0027
        if (radioCustType1.Checked)
        {
            objEnt.Staff_Worker = 1;
        }
        if (radioCustType2.Checked)
        {
            objEnt.Staff_Worker = 0;
        }
        //END
        objEnt.date = objBusiness.LoadCurrentDate();
        
        //0041

        DataTable SIFRecord = new DataTable();
        DataTable sifrecords = new DataTable();

        if (ddlmode.SelectedValue == "2" || ddlmode.SelectedValue == "3")
        {
            if (ddlmode.SelectedValue == "2" && Hiddenlevsettledate.Value !="")
            {
                string[] levsettledate = Hiddenlevsettledate.Value.Split(',');
                string[] menurootsarray = HiddenFieldEmpName.Value.Split(',');

                for (int i = 0; i < levsettledate.Length; i++)
                {

                    //DateTime dateFromDate = objCommon.textToDateTime(levsettledate[i].ToString());

                    //string strTempDate = dateFromDate.ToString("dd-MM-yyyy");
                    //strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
                    //intmnth = objCommon.textToDateTime(strTempDate);

                   

                    DateTime datevalue = (objCommon.textToDateTime(levsettledate[i].ToString()));


                    

                    //objEnt.Month = intmnth.Month;
                    //objEnt.Year = intmnth.Year;
                    //objEnt.date = dateFromDate;


                    objEnt.Month = datevalue.Month;
                    objEnt.Year = datevalue.Year;
                    objEnt.date = datevalue;

                    HiddenMonth.Value = Convert.ToString(objEnt.Month);
                    HiddenYear.Value = Convert.ToString(objEnt.Year);
                    objEnt.EmpEID = menurootsarray[i].ToString();
                    sifrecords = objBuss.ReadSIFRecordDetailsESPandLSP(objEnt);
                    SIFRecord.Merge(sifrecords);

                }
            }

            if (ddlmode.SelectedValue == "3" && Hiddenespsettledate.Value != "")
            {
                string[] espsettledate = Hiddenespsettledate.Value.Split(',');
                string[] menurootsarray = HiddenFieldEmpName.Value.Split(',');

                for (int i = 0; i < espsettledate.Length; i++)
                {
                   
                    //DateTime dateFromDate = objCommon.textToDateTime(espsettledate[i].ToString());

                    //string strTempDate = dateFromDate.ToString("dd-MM-yyyy");
                    //strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
                    //intmnth = objCommon.textToDateTime(strTempDate);

                    //objEnt.Month = intmnth.Month;
                    //objEnt.Year = intmnth.Year;
                    //objEnt.date = dateFromDate;


                    DateTime datevalue = (objCommon.textToDateTime(espsettledate[i].ToString()));





                    objEnt.Month = datevalue.Month;
                    objEnt.Year = datevalue.Year;
                    objEnt.date = datevalue;

                    HiddenMonth.Value = Convert.ToString(objEnt.Month);
                    HiddenYear.Value = Convert.ToString(objEnt.Year);
                    objEnt.EmpEID = menurootsarray[i].ToString();
                    sifrecords = objBuss.ReadSIFRecordDetailsESPandLSP(objEnt);
                    SIFRecord.Merge(sifrecords);
                }
            }
        }


        

       

        if (ddlmode.SelectedValue == "1")
        {
            string[] menurootsarray = HiddenFieldEmpName.Value.Split(',');
            menurootsarray = menurootsarray.Distinct().ToArray();
            SIFRecord = objBuss.ReadSIFRecordDetails(objEnt, menurootsarray);

        }

        //end

      


        string strHtmlSIFRecord = ConvertDataTableToHtmlSIFRecord(SIFRecord);
        divSIFbody.InnerHtml = strHtmlSIFRecord;


        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        DataTable SIFHeader = objBuss.LoadSIFHeaderDetails(objEnt);

        string strHtmlSIF = ConvertDataTableToHtmlSIFHeader(SIFHeader);
        divSIFHeader.InnerHtml = strHtmlSIF;





        if (HiddenPrsDate.Value != "0")
        {
            //EVM-0027 Mode
            objEnt.date = objCommon.textToDateTime(HiddenPrsDate.Value);
            //END
        }
        objEnt.ExportStatus = 1;
        if (HiddenNoOfRecords.Value != "0")
        {
            objEnt.ExportEmpCount = Convert.ToInt32(HiddenNoOfRecords.Value);
        }
        //EVM-0027
        objEnt.WPS_date = objCommon.textToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
        //END
        objEnt.UserId = intUserId;
        for (int intRow = 0; intRow < SIFHeader.Rows.Count; intRow++)
        {
            if (SIFHeader.Rows[intRow][1].ToString() != "")
            {
                objEnt.EmpEID = SIFHeader.Rows[intRow][1].ToString();
            }

            string day = "";
            objEnt.FileDate = objBusiness.LoadCurrentDate();
            day = Convert.ToString(DateTime.Now.Month);
            
           

            objEnt.Filetime = objBusiness.LoadCurrentDate();

            if (SIFHeader.Rows[intRow]["ORG_CMRCLRGT_NUM"].ToString() != "")
            {
                objEnt.PayerQID = Convert.ToInt32(SIFHeader.Rows[intRow]["ORG_CMRCLRGT_NUM"].ToString());
            }
            DataTable dtBank = objBuss.ReadPayerBank(objEnt);
            if (dtBank.Rows[intRow]["BANK_NAME"].ToString() != "")
            {
                objEnt.PayerBankName = dtBank.Rows[intRow]["BANK_NAME"].ToString();
                HiddenBANK.Value = dtBank.Rows[intRow]["BANK_NAME"].ToString();
            }
            if (dtBank.Rows[intRow]["IBAN"].ToString() != "")
            {
                objEnt.IBAN = dtBank.Rows[intRow]["IBAN"].ToString();
            }
            objEnt.TotalSalary = Convert.ToDecimal(HiddenNetAmount.Value);
            objEnt.TotalRecord = Convert.ToInt32(HiddenNoOfRecords.Value);
        }
        HiddenNetAmount.Value = "0";
        for (int intRowBodyCount = 0; intRowBodyCount < SIFRecord.Rows.Count; intRowBodyCount++)
        {
            string Amount = "";
            string strVisaNo = "";
            string strRPNo = "";
            string Accountno = "";
            string strComments = "";
            double leavecount = 0;
            DateTime aloctn_fromdate;
            DateTime aloctn_todate;
            int start_aloctn = 0;
            int end_aloctn = 0;
            int frommonth = 0;
            int endmonth = 0;
            int leavefrmsctn = 0;
            int leaveendsctn = 0;
            double workingdays = 0;
            string strEmpId = "";
            strComments = Request.Form["txtPaid" + SIFRecord.Rows[intRowBodyCount]["ID"]];


            string NationalIdNum = SIFRecord.Rows[intRowBodyCount]["USR_NTNLID_NUMBR"].ToString();


            HiddenNoOfRecords.Value = Convert.ToString(SIFRecord.Rows.Count);
            string[] menusarray = HiddenFieldEmpName.Value.Split(',');
            for (int i = intRowBodyCount; i < menusarray.Length; i++)
            {
                objEnt.Employee = Convert.ToInt32(menusarray[i]);
                DataTable dtbAcc = objBuss.LoadEmpBank(objEnt);
                for (int J = 0; J < dtbAcc.Rows.Count; J++)
                {
                    if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() != "")
                    {
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "1")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_IBAN"].ToString();
                        }
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "2")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_CARDNUM"].ToString();
                        }
                    }
                    strEmpId = dtbAcc.Rows[J]["EMPBANK_EMPID"].ToString();

                }
                int yr = Convert.ToInt32(HiddenYear.Value);
                int month = Convert.ToInt32(HiddenMonth.Value);
                //  FirstDay = DateSerial(Today.Year, Today.Month, 1)
                objEnt.LvFromDate = new DateTime(yr, month, 1);
                int numtoday = DateTime.DaysInMonth(yr, month);
                objEnt.LvToDate = new DateTime(yr, month, numtoday);
                DataTable dtworkingdays = objBuss.ReadEmpWorkingDays(objEnt);

                for (int loop = 0; loop < dtworkingdays.Rows.Count; loop++)
                {
                    if (dtworkingdays.Rows[loop]["LEAVEFROM"].ToString() != "")
                    {
                        aloctn_fromdate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVEFROM"].ToString());
                        start_aloctn = aloctn_fromdate.Day;
                        frommonth = aloctn_fromdate.Month;
                    }
                    if (dtworkingdays.Rows[loop]["LEAVETO"].ToString() != "")
                    {
                        aloctn_todate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVETO"].ToString());
                        end_aloctn = aloctn_todate.Day;
                        endmonth = aloctn_todate.Month;
                    }
                    if (frommonth == endmonth)
                    {
                        leavecount = end_aloctn - start_aloctn;
                    }
                    else
                    {

                        for (int day = start_aloctn; day <= numtoday; day++)
                        {
                            leavecount++;
                        }
                        if (frommonth != month)
                        {
                            for (int day = 1; day >= end_aloctn; day++)
                            {
                                leavecount++;
                            }
                        }
                    }
                    if (dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString() != "")
                    {
                        leavefrmsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString());
                    }
                    if (dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString() != "")
                    {
                        leaveendsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString());
                    }
                    if (leaveendsctn == 2)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leaveendsctn == 3)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leavefrmsctn == 2)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leavefrmsctn == 3)
                    {
                        leavecount = leavecount - 0.5;
                    }
                }

                workingdays = numtoday - leavecount;
                DataTable dtDoc = objBuss.ReadDocumentName(objEnt);
                if (dtDoc.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDoc.Rows.Count; j++)
                    {
                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "RP")
                        {
                            strRPNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }

                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "Visa")
                        {
                            strVisaNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }
                    }
                }
                break;
            }
            if (strRPNo != "")
            {
                objEnt.EmpQid = strRPNo;
            }
            else if (NationalIdNum != "")
            {
                objEnt.EmpQid = NationalIdNum;
            }
            else if (strVisaNo != "")
            {
                objEnt.EmpQid = strVisaNo;
            }
            else
            {
                objEnt.EmpQid = "";
            }
            if (strVisaNo != "")
            {
                objEnt.EmpVisa = strVisaNo;
            }
            else
            {
                objEnt.EmpVisa = "";
            }
            objEnt.EmpName = SIFRecord.Rows[intRowBodyCount]["EMPNAME"].ToString();
            objEnt.EmpBank = Convert.ToInt32(ddlBank.SelectedItem.Value);
            objEnt.BankAccountno = Accountno;

            objEnt.SalFreqncy = SIFRecord.Rows[intRowBodyCount]["FREQUENCY"].ToString();

            objEnt.WorkingDays = workingdays;

            if (SIFRecord.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() != "")
            {
                objEntityCommon.CorporateID = intCorpId;

                HiddenNetAmount.Value = Convert.ToString(Convert.ToDecimal(HiddenNetAmount.Value) + Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["NET_AMOUNT"].ToString()));
                Amount = objBusiness.AddCommasForNumberSeperation(SIFRecord.Rows[intRowBodyCount]["NET_AMOUNT"].ToString(), objEntityCommon);
                objEnt.NetSalary = Convert.ToDecimal(Amount);
            }
            else
            {
                HiddenNetAmount.Value = "0";
            }
            if (SIFRecord.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() != "")
            {
                objEnt.BasicSalary = Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString());
            }
            if (SIFRecord.Rows[intRowBodyCount]["OVERTIMEHOURS"].ToString() != "")
            {
                objEnt.ExtraHr = Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["OVERTIMEHOURS"].ToString());
            }
            if (SIFRecord.Rows[intRowBodyCount]["ALLOWANCE"].ToString() != "")
            {
                objEnt.ExtraIncome = Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
            }
            if (SIFRecord.Rows[intRowBodyCount]["DEDUCTION"].ToString() != "")
            {
                objEnt.Deduction = Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["DEDUCTION"].ToString());
            }

            if (objEnt.Mode == 2 || objEnt.Mode == 3)  //Leave settlement, End of service settlement
            {
                objEnt.SalaryPrcssdBasicSalary = objEnt.BasicSalary;
            }
            else
            {
                if (SIFRecord.Rows[intRowBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
                {
                    objEnt.SalaryPrcssdBasicSalary = Convert.ToDecimal(SIFRecord.Rows[intRowBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString());
                }
            }

            string[] strComment = HiddenFieldComment.Value.Split(',');
            objEnt.Commentss = strComments;
            objBuss.InsertToWPSList(objEnt);
        }
        string[] SettledIds = HiddenSettledID.Value.Split(',');
        List<ClsEntityLayerWps_List> objEntityLayerWps_List = new List<ClsEntityLayerWps_List>();

        foreach (string strDtlId in SettledIds)
        {
            if (strDtlId != "" && strDtlId != null)
            {
                int intDtlId = Convert.ToInt32(strDtlId);
                ClsEntityLayerWps_List objEntityDetails = new ClsEntityLayerWps_List();
                objEntityDetails.SettledId = Convert.ToInt32(strDtlId);
                objEntityLayerWps_List.Add(objEntityDetails);

            }
        }




        DataTable dt2 = GetTable();

        DataTable dt = GetTable2();

        objBuss.UpdateSettledStatus(objEnt, objEntityLayerWps_List);
        string strResult = DataTableToCSV(dt2, dt, ',');
        //divSIFbody.InnerHtml = strResult;
        DateTime FILEDATE;
        DateTime FILETIME;
        string filedate = "";
        string filetime = "";
        objEnt.FileDate = objBusiness.LoadCurrentDate();
        objEnt.Filetime = objBusiness.LoadCurrentDate();
        FILEDATE = objEnt.FileDate;
        FILETIME = objEnt.Filetime;
        filedate = Convert.ToString(FILEDATE.Year + "" + FILEDATE.Month + "" + FILEDATE.Day);
        filetime = Convert.ToString(FILETIME.Hour + "" + FILETIME.Minute);
        //string newFilePath = Server.MapPath("/CustomFiles/hcm_Monthly_Sal_WPS/new" + HiddennXTid.Value + ".csv");
        string newFilePath = Server.MapPath("/CustomFiles/hcm_Monthly_Sal_WPS/SIF_" + HiddenEID.Value + "_" + HiddenBANK.Value + "_" + filedate + "_" + filetime + ".csv");

        System.IO.File.WriteAllText(newFilePath, strResult);
        Session["fileName"] = "SIF_" + HiddenEID.Value + "_" + HiddenBANK.Value + "_" + filedate + "_" + filetime + ".csv";
        ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);

        btnsearch_Click(sender, e);


    }
    public string ConvertDataTableToHtmlSIFHeader(DataTable dt)
    {
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        if (ddlPayerBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.PayerBankId = Convert.ToInt32(ddlPayerBank.SelectedItem.Value);
          //  HiddenBANK.Value = ddlPayerBank.SelectedItem.Text;
          //  HiddenBANK.Value = dtBank.Rows[intRow]["BANK_NAME"].ToString();
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        string month = "";
        string year = "";
        strHtml = "SIF HEADER:<br><br>";
        strHtml += "Employer EID, File Creation Date, File Creation Time, Payer EID, Payer QID, Payer Bank Short Name, Payer IBAN, Salary Year and Month, Total Salaries, Total Records <br>";
        //add rows
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int mnth;
        DateTime intmnth;
        int yr;
        DataTable dtBank = objBuss.ReadPayerBank(objEnt);
        string strMonth = "";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            for (int intColumnBodyCount = 0; intColumnBodyCount < 10; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0 || intColumnBodyCount == 3)
                {
                    strHtml += dt.Rows[intRowBodyCount][1].ToString() + ",  ";
                }
                else if (intColumnBodyCount == 1)
                {
                    //EVM-0027
                    strHtml += DateTime.Now.Year;
                    if(DateTime.Now.Month<10)
                    strHtml +="0"+ DateTime.Now.Month;
                    else
                        strHtml +=  DateTime.Now.Month;
                    if (DateTime.Now.Day < 10)
                        strHtml += "0" + DateTime.Now.Day + ",  ";
                    else
                    strHtml += DateTime.Now.Day + ",  ";
                    //END
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += DateTime.Now.Hour;
                    string day = Convert.ToString(DateTime.Now.Minute);

                    strHtml += day + ",  ";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += dt.Rows[intRowBodyCount]["ORG_CMPTRCRD_NUM"].ToString() + ",  ";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += dt.Rows[intRowBodyCount]["ORG_CMRCLRGT_NUM"].ToString() + ",  ";
                }

                else if (intColumnBodyCount == 5)
                {
                    if (dtBank.Rows[0]["BANK_NAME"].ToString() != "")
                    {
                        strHtml += dtBank.Rows[0]["BANK_NAME"].ToString() + ",  ";
                        HiddenBANK.Value = dtBank.Rows[0]["BANK_NAME"].ToString();
                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dtBank.Rows[0]["IBAN"].ToString() != "")
                    {
                        strHtml += dtBank.Rows[0]["IBAN"].ToString() + ",  ";
                    }
                    HiddenIBAN.Value = dtBank.Rows[0]["IBAN"].ToString();
                }
                   
                else if (intColumnBodyCount == 7)
                {
                  
                    if (ddlmode.SelectedValue == "1")
                    {
                        
                        mnth = Convert.ToInt32(ddlMonth.SelectedValue);
                        if (mnth < 10)
                            strMonth = "0" + mnth;
                        else
                            strMonth = mnth.ToString();

                         yr = Convert.ToInt32(ddlYear.SelectedValue);
                         strHtml += +yr + "" + strMonth + ",  ";
                       
                    }
                    else
                    {
                        if (Hiddentxtefctvedate.Value.ToString() != "")
                        {
                            //EVM0027
                            DateTime dateFromDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);//END
                            string strTempDate = dateFromDate.ToString("dd-MM-yyyy");
                            strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
                            string mth = "";
                            intmnth = objCommon.textToDateTime(strTempDate);
                            mnth = intmnth.Month;
                            if (mnth != 0)
                            {
                                DateTime date = new DateTime(1, mnth, 1);
                                mth = date.ToString("MMMM");
                            }
                            yr = intmnth.Year;
          
                            if (ddlmode.SelectedValue == "2" || ddlmode.SelectedValue == "3")
                            {
                                strHtml += yr + "" + strMonth + ", ";
                            }
                        }

                        //0041
                        if (ddlmode.SelectedValue == "2" || ddlmode.SelectedValue == "3")
                        {
                            strHtml += DateTime.Now.Year + "" + DateTime.Now.Month + ", ";
                        }

                        //end
                    }
                }
                else if (intColumnBodyCount == 8)
                {
                    objEntityCommon.CorporateID = intCorpId;
                    objBusiness.AddCommasForNumberSeperation(HiddenNetAmount.Value, objEntityCommon);
                    strHtml += HiddenNetAmount.Value + ", ";
                }
                else if (intColumnBodyCount == 9)
                {
                    strHtml += HiddenNoOfRecords.Value;
                }
                
            }
        }
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToHtmlSIFRecord(DataTable dt)
    {

        string indvlRound = HiddenFieldIndividualRound.Value;
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEnt.Mode = Convert.ToInt32(ddlmode.SelectedValue);

        int intUserId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        if (ddlBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            // HiddenBankName.Value = ddlBank.SelectedItem.Text;
        }
        objEnt.UserId = intUserId;
        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";
        strCapTable = "SIF RECORD:<br><br>";
        strCapTable += "Record sequence, Employee QID, Employee Visa ID, Employee Name, Employee Bank Short Name, Employee Account, Salary Frequency, Number Of Working Days, Net Salary, Basic Salary, Extra Hours, Extra Income, Deductions, Payment Type, Notes/Comments,Employee ID <br>";
        int count = 1;
        HiddenNetAmount.Value = "0";

        

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string Amount = "";
            string strVisaNo = "";
            string strRPNo = "";
            string strComments = "";
            string Accountno = "";
            double leavecount = 0;
            DateTime aloctn_fromdate;
            DateTime aloctn_todate;
            int start_aloctn = 0;
            int end_aloctn = 0;
            int frommonth = 0;
            int endmonth = 0;
            double workingdays = 0;
            int leavefrmsctn = 0;
            int leaveendsctn = 0;
            string strempid = "";
            HiddenNoOfRecords.Value = Convert.ToString(dt.Rows.Count);
            string[] menurootsarray = HiddenFieldEmpName.Value.Split(',');


    

            strComments = Request.Form["txtPaid" + dt.Rows[intRowBodyCount]["ID"]];

            string NationalIdNum = dt.Rows[intRowBodyCount]["USR_NTNLID_NUMBR"].ToString();

            for (int i = intRowBodyCount; i < menurootsarray.Length; i++)
            {

                objEnt.Employee = Convert.ToInt32(menurootsarray[i]);
                DataTable dtbAcc = objBuss.LoadEmpBank(objEnt);
                for (int J = 0; J < dtbAcc.Rows.Count; J++)
                {
                    if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() != "")
                    {
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "1")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_IBAN"].ToString();
                        }
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "2")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_CARDNUM"].ToString();
                        }
                    }
                    strempid = dtbAcc.Rows[J]["EMPBANK_EMPID"].ToString();
                }
                DataTable dtDoc = objBuss.ReadDocumentName(objEnt);
                if (dtDoc.Rows.Count > 0)
                {


                    for (int j = 0; j < dtDoc.Rows.Count; j++)
                    {
                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "RP")
                        {
                            strRPNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }

                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "Visa")
                        {
                            strVisaNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }
                    }
                }
                break;

            }

            if (strRPNo == "")
            {

                if (NationalIdNum != "")
                {
                    strRPNo = NationalIdNum;
                }
                else if (strVisaNo != "")
                {
                    strRPNo = strVisaNo;
                }
            }


          
                int yr = Convert.ToInt32(HiddenYear.Value);
                int month = Convert.ToInt32(HiddenMonth.Value);


                //  FirstDay = DateSerial(Today.Year, Today.Month, 1)
                objEnt.LvFromDate = new DateTime(yr, month, 1);
                int numtoday = DateTime.DaysInMonth(yr, month);
                objEnt.LvToDate = new DateTime(yr, month, numtoday);
            
            

           
            //WORKING DAYS
          
            DataTable dtworkingdays = objBuss.ReadEmpWorkingDays(objEnt);

            for (int loop = 0; loop < dtworkingdays.Rows.Count; loop++)
            {
                if (dtworkingdays.Rows[loop]["LEAVEFROM"].ToString() != "")
                {
                    aloctn_fromdate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVEFROM"].ToString());
                    start_aloctn = aloctn_fromdate.Day;
                    frommonth = aloctn_fromdate.Month;
                }
                if (dtworkingdays.Rows[loop]["LEAVETO"].ToString() != "")
                {
                    aloctn_todate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVETO"].ToString());
                    end_aloctn = aloctn_todate.Day;
                    endmonth = aloctn_todate.Month;
                }
                if (frommonth == endmonth)
                {
                    leavecount = end_aloctn - start_aloctn;
                }

                else
                {

                    for (int day = start_aloctn; day <= numtoday; day++)
                    {
                        leavecount++;
                    }
                    if (frommonth != month)
                    {
                        for (int day = 1; day >= end_aloctn; day++)
                        {
                            leavecount++;
                        }
                    }
                }
                if (dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString() != "")
                {
                    leavefrmsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString());
                }
                if (dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString() != "")
                {
                    leaveendsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString());
                }

                if (leaveendsctn == 2)
                {
                    leavecount = leavecount - 0.5;
                }
                if (leaveendsctn == 3)
                {
                    leavecount = leavecount - 0.5;
                }
                if (leavefrmsctn == 2)
                {
                    leavecount = leavecount - 0.5;
                }
                if (leavefrmsctn == 3)
                {
                    leavecount = leavecount - 0.5;
                }

            }

            workingdays = numtoday - leavecount;
            strCapTable += count + ",";

            for (int intColumnBodyCount = 0; intColumnBodyCount <= 14; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strCapTable += strRPNo + ",  ";
                }
                if (intColumnBodyCount == 1)
                {
                    strCapTable += strVisaNo + ", ";

                }
                if (intColumnBodyCount == 2)
                {
                    strCapTable += dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + ",  ";
                }
                else if (intColumnBodyCount == 3)
                {
                    strCapTable += dt.Rows[intRowBodyCount]["BANK_NAME"].ToString() + ",  ";
                }
                else if (intColumnBodyCount == 4)
                {
                    strCapTable += Accountno + ",  ";
                }
                else if (intColumnBodyCount == 5)
                {
                    strCapTable += dt.Rows[intRowBodyCount]["FREQUENCY"].ToString() + ",  ";

                }
                else if (intColumnBodyCount == 6)
                {
                    strCapTable += workingdays + ",  ";
                }
                else if (intColumnBodyCount == 7)
                {
                    if (dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() != "")
                    {
                        objEntityCommon.CorporateID = intCorpId;

                        HiddenNetAmount.Value = Convert.ToString(Convert.ToDecimal(HiddenNetAmount.Value) + Convert.ToDecimal(dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString()));
                        //if (indvlRound == "1")
                        //{
                        Amount = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                        //}
                        //else
                        //{
                        //    Amount = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString(), objEntityCommon);
                        //}
                        strCapTable += Amount + ",  ";
                    }
                    else
                    {
                        strCapTable += dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() + ",  ";
                        HiddenNetAmount.Value = "0";
                    }

                }
                else if (intColumnBodyCount == 8)//--EVM-0039--
                {

                    if (objEnt.Mode == 1)
                    {
                        if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
                        {
                            if (indvlRound == "1")
                            {
                                strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString()), 0).ToString("0.00") + ",  ";
                            }
                            else
                            {
                                strCapTable += dt.Rows[intRowBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() + ",  ";
                            }
                        }
                        else
                        {
                            strCapTable += dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() + ",  ";
                        }
                    }

                       

                    else if (objEnt.Mode == 2)//Leave settlement
                    {

                        

                        decimal value = 0;
                        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                        string format = String.Format("{{0:N{0}}}", precision);
                        string valuestring = String.Format(format, value);

                        DataTable dtleavsetl = new DataTable();
                        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                        objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtLeavSettl = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

                
                        if (dtLeavSettl.Rows.Count > 0)
                        {
                           // if (dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            if (dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            {
                                if (indvlRound == "1")
                                {
                                   // strCapTable += Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["BASIC_PREV"].ToString()), 0).ToString("0.00") + ",  ";
                                    strCapTable += Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["BASIC_PREV"].ToString()), 0).ToString("0.00") + ",  ";
                                }
                                else
                                {
                                    //strCapTable += dtLeavSettl.Rows[intRowBodyCount]["BASIC_PREV"].ToString() + ",  ";

                                    strCapTable += dtLeavSettl.Rows[0]["BASIC_PREV"].ToString() + ",  ";
                                }
                            }
                            else
                            {
                                if (indvlRound == "1")
                                {
                                  //  strCapTable += Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["BASIC_CURR"].ToString()), 0).ToString("0.00") + ",  ";

                                    strCapTable += Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["BASIC_CURR"].ToString()), 0).ToString("0.00") + ",  ";
                                }
                                else
                                {
                                    //strCapTable += dtLeavSettl.Rows[intRowBodyCount]["BASIC_CURR"].ToString() + ",  ";

                                    strCapTable += dtLeavSettl.Rows[0]["BASIC_CURR"].ToString() + ",  ";
                                }
                            }
                        }

                    }
                    else if (objEnt.Mode == 3)//End of Service
                    {
                        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
                        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

                        objEntityLayerEndOfServiceLeaveStlmnt.OrgId = objEnt.OrgId;
                        objEntityLayerEndOfServiceLeaveStlmnt.CorpId = objEnt.CorprtId;
                        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);


                        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
                        {
                            //if (dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "")
                                if (dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString() != "")
                            {
                                if (indvlRound == "1")
                                {
                                   // strCapTable += Math.Round(Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["BASIC_PREV"].ToString()), 0).ToString("0.00") + ",  ";
                                    strCapTable += Math.Round(Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PREV"].ToString()), 0).ToString("0.00") + ",  ";
                                }
                                else
                                {
                                    //strCapTable += dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["BASIC_PREV"].ToString() + ",  ";

                                    strCapTable += dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PREV"].ToString() + ",  ";
                                }
                            }
                            else
                            {
                                if (indvlRound == "1")
                                {
                                    //strCapTable += Math.Round(Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_STLMT_BASICPAY"].ToString()), 0).ToString("0.00") + ",  ";
                                    strCapTable += Math.Round(Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_BASICPAY"].ToString()), 0).ToString("0.00") + ",  ";

                                }
                                else
                                {
                                    //strCapTable += dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_STLMT_BASICPAY"].ToString() + ",  ";
                                    strCapTable += dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_BASICPAY"].ToString() + ",  ";
                                }
                            }

                        }
                    }
                }
                else if (intColumnBodyCount == 9)
                {
                    if (dt.Rows[intRowBodyCount]["OVERTIMEHOURS"].ToString() == "")
                    {
                        strCapTable += "0,  ";
                    }
                    else
                    {
                        if (indvlRound == "1")
                        {
                            strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERTIMEHOURS"].ToString()), 0).ToString("0.00") + ",  ";
                        }
                        else
                        {
                            strCapTable += dt.Rows[intRowBodyCount]["OVERTIMEHOURS"].ToString() + ",  ";
                        }
                    }
                }
                else if (intColumnBodyCount == 10)
                {
                    decimal decAlwnc = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());

                    if (objEnt.Mode == 2)//Leave settlement
                    {
                        decimal value = 0;
                        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                        string format = String.Format("{{0:N{0}}}", precision);
                        string valuestring = String.Format(format, value);

                        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                        objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtLeavSettl = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);
                        
                        //0041

                        if (dtLeavSettl.Rows.Count > 0)
                        {
                            //if (dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            //{
                            //    decimal Allo = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());//allo = allowance include cur mnth aditions
                            //    decimal AlloBasic = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["BASIC_CURR"].ToString());//AlloBasic = basic of current
                            //    decimal Premtadd = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_ADDITION"].ToString());//Premtadd =Previous month empl addition
                            //    decimal premtarr = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_ARREAR_AMNT"].ToString());//premtarr = Previous month arrear
                            //    decimal premtot = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_OVERTIME_AMNT"].ToString());//premtot =Previous month ot amount
                            //    decimal premtother = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_OTHERAMT"].ToString());//premtother =Previous other addition(manual)
                            //    decimal Premtadditions = Premtadd + premtarr + premtot + premtother;

                            //    decAlwnc = AlloBasic + Allo + Premtadditions;
                            //}

                            if (dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            {
                                decimal Allo = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());//allo = allowance include cur mnth aditions
                                decimal AlloBasic = Convert.ToDecimal(dtLeavSettl.Rows[0]["BASIC_CURR"].ToString());//AlloBasic = basic of current
                                decimal Premtadd = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_ADDITION"].ToString());//Premtadd =Previous month empl addition
                                decimal premtarr = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_ARREAR_AMNT"].ToString());//premtarr = Previous month arrear
                                decimal premtot = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OVERTIME_AMNT"].ToString());//premtot =Previous month ot amount
                                decimal premtother = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OTHERAMT"].ToString());//premtother =Previous other addition(manual)
                                decimal Premtadditions = Premtadd + premtarr + premtot + premtother;

                                decAlwnc = AlloBasic + Allo + Premtadditions;
                            }
                        }
                    }
                    else if (objEnt.Mode == 3)//End of Service
                    {
                        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
                        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

                        objEntityLayerEndOfServiceLeaveStlmnt.OrgId = objEnt.OrgId;
                        objEntityLayerEndOfServiceLeaveStlmnt.CorpId = objEnt.CorprtId;
                        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);

                        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
                        {
                            //if (dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "")
                            //{
                            //    decimal Allo1 = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());//Allo1 = including all current mnt additions
                            //    decimal AlloBasic1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_STLMT_BASICPAY"].ToString());//AlloBasic1 = Current mnth basic
                            //    decimal Premtadd1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_PREV_ADDITION"].ToString());//Premtadd1 = Previous month empl addition
                            //    decimal premtot1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_PREV_OVERTIME_AMNT"].ToString());//premtot1 = Previous month ot amount
                            //    decimal premtother1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_OTHER_ADD_AMNT"].ToString());//premtother1 = Prevoius other addition(manual)
                            //    decimal Premtadditions1 = Premtadd1 + premtot1 + premtother1;

                            //    decAlwnc = AlloBasic1 + Allo1 + Premtadditions1;
                            //}if (dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "")
                            {
                                decimal Allo1 = Convert.ToDecimal(dt.Rows[0]["ALLOWANCE"].ToString());//Allo1 = including all current mnt additions
                                decimal AlloBasic1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_BASICPAY"].ToString());//AlloBasic1 = Current mnth basic
                                decimal Premtadd1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_ADDITION"].ToString());//Premtadd1 = Previous month empl addition
                                decimal premtot1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_OVERTIME_AMNT"].ToString());//premtot1 = Previous month ot amount
                                decimal premtother1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_OTHER_ADD_AMNT"].ToString());//premtother1 = Prevoius other addition(manual)
                                decimal Premtadditions1 = Premtadd1 + premtot1 + premtother1;

                                decAlwnc = AlloBasic1 + Allo1 + Premtadditions1;
                            }
                        }
                    }

                    if (indvlRound == "1" && dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString() != "")
                    {
                        strCapTable += Math.Round(decAlwnc, 0).ToString("0.00") + ",  ";
                    }
                    else
                    {
                        strCapTable += decAlwnc.ToString() + ",  ";
                    }
                }
                else if (intColumnBodyCount == 11)
                {
                    decimal decDeduc = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());

                    if (objEnt.Mode == 2)//Leave settlement
                    {
                        decimal value = 0;
                        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                        string format = String.Format("{{0:N{0}}}", precision);
                        string valuestring = String.Format(format, value);

                        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                        objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtLeavSettl = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

                        

                        if (dtLeavSettl.Rows.Count > 0)
                        {
                            //if (dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            //{
                            //    decimal Deduc = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());//Deduc = Dedc include cur mnth deductions
                            //    decimal PremtDedc = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_DEDUCTION"].ToString());//PremtDedct = Previous month empl deduction
                            //    decimal PremtinstDedc = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc = Previous month Payment deduction
                            //    decimal premtotherdeduc = Convert.ToDecimal(dtLeavSettl.Rows[intRowBodyCount]["LEVSETLMT_PREV_OTHERDEDCTN"].ToString());//premtotherdeduc = Previous other deductions(manual)
                            //    decimal Premtdeductions = PremtDedc + PremtinstDedc + premtotherdeduc;

                            //    decDeduc = Deduc + Premtdeductions;
                            //}
                            if (dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                            {
                                decimal Deduc = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());//Deduc = Dedc include cur mnth deductions
                                decimal PremtDedc = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_DEDUCTION"].ToString());//PremtDedct = Previous month empl deduction
                                decimal PremtinstDedc = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc = Previous month Payment deduction
                                decimal premtotherdeduc = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OTHERDEDCTN"].ToString());//premtotherdeduc = Previous other deductions(manual)
                                decimal Premtdeductions = PremtDedc + PremtinstDedc + premtotherdeduc;

                                decDeduc = Deduc + Premtdeductions;
                            }
                        }
                    }
                    else if (objEnt.Mode == 3)//End of Service
                    {
                        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
                        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

                        objEntityLayerEndOfServiceLeaveStlmnt.OrgId = objEnt.OrgId;
                        objEntityLayerEndOfServiceLeaveStlmnt.CorpId = objEnt.CorprtId;
                        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(dt.Rows[intRowBodyCount]["ID"].ToString());
                        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);

                        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
                        {
                            //if (dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_MONTH_SAL"].ToString() != "")
                            //{
                            //    decimal Deduc1 = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());//Deduc1 = Dedc1 include cur mnth deductions
                            //    decimal PremtDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_PREV_DEDUCTION"].ToString());//PremtDedct1 = Previous month empl deduction
                            //    decimal PremtinstDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["SRVCLVE_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc1 = Previous month Payment deduction
                            //    decimal premtotherdeduc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intRowBodyCount]["PREV_OTHER_DEDUCT_AMNT"].ToString());//premtotherdeduc1 = Previous other deductions(manual)
                            //    decimal Premtdeductions1 = PremtDedc1 + PremtinstDedc1 + premtotherdeduc1;

                            //    decDeduc = Deduc1 + Premtdeductions1;
                            //}
                            if (dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString() != "")
                            {
                                decimal Deduc1 = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());//Deduc1 = Dedc1 include cur mnth deductions
                                decimal PremtDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_DEDUCTION"].ToString());//PremtDedct1 = Previous month empl deduction
                                decimal PremtinstDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc1 = Previous month Payment deduction
                                decimal premtotherdeduc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_OTHER_DEDUCT_AMNT"].ToString());//premtotherdeduc1 = Previous other deductions(manual)
                                decimal Premtdeductions1 = PremtDedc1 + PremtinstDedc1 + premtotherdeduc1;

                                decDeduc = Deduc1 + Premtdeductions1;
                            }
                        }
                    }

                    if (indvlRound == "1" && dt.Rows[intRowBodyCount]["DEDUCTION"].ToString() != "")
                    {
                        strCapTable += Math.Round(decDeduc, 0).ToString("0.00") + ",  ";
                    }
                    else
                    {
                        strCapTable += decDeduc.ToString() + ",  ";
                    }
                }
                else if (intColumnBodyCount == 12)
                {
                    strCapTable += dt.Rows[intRowBodyCount]["type"].ToString() + ",  ";
                }
                else if (intColumnBodyCount == 13)
                {
                    strCapTable += strComments + ", ";
                }
                else if (intColumnBodyCount == 14)
                {
                    strCapTable += strempid + "</br>";
                }

            }

            count++;
        }
        sbCap.Append(strCapTable);
        return sbCap.ToString();
    }
    public DataTable GetTable()
    {
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        //Header:
        DataTable table = new DataTable();
        table.Columns.Add("Employer EID", typeof(string));
        table.Columns.Add("File Creation Date", typeof(string));
        table.Columns.Add("File Creation Time", typeof(string));
        table.Columns.Add("Payer EID", typeof(string));
        table.Columns.Add("Payer QID ", typeof(string));
        table.Columns.Add("Payer Bank Short Name", typeof(string));
        table.Columns.Add("Payer IBAN", typeof(string));
        table.Columns.Add("Salary Year and Month", typeof(string));
        table.Columns.Add("Total Salaries", typeof(string));
        table.Columns.Add("Total Records", typeof(string));

        int mnth = 0; ;
        DateTime intmnth;
        int yr = 0000;
        string PayerIban = "";
        string PayerBank = "";
        if (Session["ORGID"] != null)
        {

            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (ddlBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            HiddenBankName.Value = ddlBank.SelectedItem.Text;
        }

        if (ddlPayerBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.PayerBankId = Convert.ToInt32(ddlPayerBank.SelectedItem.Value);
            HiddenBANK.Value = ddlPayerBank.SelectedItem.Text;
        }
        DataTable dtBank = objBuss.ReadPayerBank(objEnt);
        if (dtBank.Rows[0]["BANK_NAME"].ToString() != "")
        {
            PayerBank = dtBank.Rows[0]["BANK_NAME"].ToString();
            HiddenBANK.Value = dtBank.Rows[0]["BANK_NAME"].ToString();
        }
        if (dtBank.Rows[0]["IBAN"].ToString() != "")
        {
            PayerIban = dtBank.Rows[0]["IBAN"].ToString();
        }


        DataTable dt = objBuss.LoadSIFHeaderDetails(objEnt);
        DateTime FILEDATE;
        DateTime FILETIME;
        string filedate = "";
        string filetime = "";
        objEnt.FileDate = objBusiness.LoadCurrentDate();
        objEnt.Filetime = objBusiness.LoadCurrentDate();
        FILEDATE = objEnt.FileDate;
        FILETIME = objEnt.Filetime;
        //EVM-0027
        int intFileDay = FILEDATE.Day;
        int intFileMonth = FILEDATE.Month;
        string   strFileDay="";
        string strFileMonth = "";
        if (intFileDay < 10)
            strFileDay = "0" + intFileDay;
        if (intFileMonth < 10)
            strFileMonth = "0" + intFileMonth;
   //     string strFileMomth = FILEDATE.Month.ToString();

        filedate = Convert.ToString(FILEDATE.Year + "" + strFileMonth + "" + strFileDay);
        //END
        filetime = Convert.ToString(FILETIME.Hour +""+ FILETIME.Minute);
        string strMonth = "";
        if (ddlmode.SelectedValue == "1")
        {
            mnth = Convert.ToInt32(ddlMonth.SelectedValue);
           
            yr = Convert.ToInt32(ddlYear.SelectedValue);

        }
        else
        {

            
            if (Hiddentxtefctvedate.Value.ToString() != "")
            {
                DateTime dateFromDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
                string strTempDate = dateFromDate.ToString("dd-MM-yyyy");
                strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
                intmnth = objCommon.textToDateTime(strTempDate);
                mnth = intmnth.Month;
             
                yr = intmnth.Year;
            }
        }
        //EVM-0027
        if (mnth < 10)
            strMonth = "0" + mnth;
        else
            strMonth = mnth.ToString();
        //END
        HiddenEID.Value = dt.Rows[0]["ORG_CMPTRCRD_NUM"].ToString();
        table.Rows.Add(dt.Rows[0]["ORG_CMPTRCRD_NUM"], filedate, filetime, dt.Rows[0]["ORG_CMPTRCRD_NUM"], dt.Rows[0]["ORG_CMRCLRGT_NUM"], PayerBank, PayerIban, yr + "" + strMonth, HiddenNetAmount.Value, HiddenNoOfRecords.Value);
        return table;
    }
    public DataTable GetTable2()
    {
        int count = 0;

        // Here we create a DataTable with four columns.
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        DataTable table = new DataTable();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DateTime intmnth;
        table.Columns.Add("Record Sequence", typeof(string));
        table.Columns.Add("Employee QID", typeof(string));
        table.Columns.Add("Employee VisaID", typeof(string));
        table.Columns.Add("Employee Name", typeof(string));
        table.Columns.Add("Employee Bank Short Name", typeof(string));
        table.Columns.Add("Employee Acoount", typeof(string));
        table.Columns.Add("Salary Frequency", typeof(string));
        table.Columns.Add("Number Of Working Days", typeof(string));
        table.Columns.Add("NetSalary", typeof(string));
        table.Columns.Add("Basic Salary", typeof(string));
        table.Columns.Add("Extra Hours", typeof(string));
        table.Columns.Add("Extra Income", typeof(string));
        table.Columns.Add("Deductions", typeof(string));
        table.Columns.Add("Payment Type", typeof(string));
        table.Columns.Add("Notes/Comments", typeof(string));
        table.Columns.Add("Employee ID", typeof(string));

        // Here we add five DataRows.
        if (Session["USERID"] != null)
        {
            objEnt.UserId = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"]);
        }
        if (ddlmode.SelectedValue != "---SELECT MODE---")
        {
            objEnt.Mode = Convert.ToInt32(ddlmode.SelectedValue);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (ddlBank.SelectedValue != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            // HiddenBankName.Value = ddlBank.SelectedItem.Text;
        }

        if (ddlmode.SelectedValue == "1")
        {
            objEnt.Month = Convert.ToInt32(ddlMonth.SelectedValue);
            objEnt.Year = Convert.ToInt32(ddlYear.SelectedValue);
        }
        if (ddlmode.SelectedValue == "2" || ddlmode.SelectedValue == "3")
        {
            if (Hiddentxtefctvedate.Value.ToString() != "")
            {
                DateTime dateFromDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);

                string strTempDate = dateFromDate.ToString("dd-MM-yyyy");
                strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
                intmnth = objCommon.textToDateTime(strTempDate);
                objEnt.Month = intmnth.Month;
                objEnt.Year = intmnth.Year;
                objEnt.date = dateFromDate;
            }
        }
        string[] menurootsarray = HiddenFieldEmpName.Value.Split(',');

        menurootsarray = menurootsarray.Distinct().ToArray();


        string[] levsettledate = Hiddenlevsettledate.Value.Split(',');


        
        DataTable dt = objBuss.ReadSIFRecordDetails(objEnt, menurootsarray);

        string usrid = "";

        string[] strComment = HiddenFieldComment.Value.Split(',');
        string strComments = "";
        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Rows.Count; intColumnBodyCount++)
        {
            count++;

            double workingdays = 0;
            string strVisaNo = "";
            string strRPNo = "";
            string Accountno = "";
            DateTime aloctn_fromdate;
            DateTime aloctn_todate;

            string NationalIdNum = dt.Rows[intColumnBodyCount]["USR_NTNLID_NUMBR"].ToString();


            int start_aloctn = 0;
            int end_aloctn = 0;
            int frommonth = 0;
            int endmonth = 0;
            int leavefrmsctn = 0;
            int leaveendsctn = 0;
            string strempid = "";
            HiddenNoOfRecords.Value = Convert.ToString(dt.Rows.Count);
            if (usrid == "")
            {
                usrid = dt.Rows[intColumnBodyCount][10].ToString();
            }
            strComments = Request.Form["txtPaid" + dt.Rows[intColumnBodyCount]["ID"]];
            for (int i = intColumnBodyCount; i < menurootsarray.Length; i++)
            {

                objEnt.Employee = Convert.ToInt32(menurootsarray[i]);
                DataTable dtbAcc = objBuss.LoadEmpBank(objEnt);
                for (int J = 0; J < dtbAcc.Rows.Count; J++)
                {
                    if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() != "")
                    {
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "1")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_IBAN"].ToString();
                        }
                        if (dtbAcc.Rows[J]["EMPBANK_ACCOUNT_TYP"].ToString() == "2")
                        {
                            Accountno = dtbAcc.Rows[J]["EMPBANK_CARDNUM"].ToString();
                        }
                    }
                    strempid = dtbAcc.Rows[J]["EMPBANK_EMPID"].ToString();

                }
                //WORKING DAYS
                int month = 0;
                int yr = Convert.ToInt32(HiddenYear.Value);
                month = Convert.ToInt32(HiddenMonth.Value);
                //  FirstDay = DateSerial(Today.Year, Today.Month, 1)
                objEnt.LvFromDate = new DateTime(yr, month, 1);
                int numtoday = DateTime.DaysInMonth(yr, month);
                objEnt.LvToDate = new DateTime(yr, month, numtoday);
                DataTable dtworkingdays = objBuss.ReadEmpWorkingDays(objEnt);
                double leavecount = 0;
                for (int loop = 0; loop < dtworkingdays.Rows.Count; loop++)
                {

                    if (dtworkingdays.Rows[loop]["LEAVEFROM"].ToString() != "")
                    {
                        aloctn_fromdate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVEFROM"].ToString());
                        start_aloctn = aloctn_fromdate.Day;
                        frommonth = aloctn_fromdate.Month;
                    }
                    if (dtworkingdays.Rows[loop]["LEAVETO"].ToString() != "")
                    {
                        aloctn_todate = objCommon.textToDateTime(dtworkingdays.Rows[loop]["LEAVETO"].ToString());
                        end_aloctn = aloctn_todate.Day;
                        endmonth = aloctn_todate.Month;
                    }
                    if (frommonth == endmonth)
                    {
                        leavecount = end_aloctn - start_aloctn;
                    }
                    else
                    {

                        for (int day = start_aloctn; day <= numtoday; day++)
                        {
                            leavecount++;
                        }
                        if (frommonth != month)
                        {
                            for (int day = 1; day >= end_aloctn; day++)
                            {
                                leavecount++;
                            }
                        }

                    }
                    if (dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString() != "")
                    {
                        leavefrmsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_FROM_SCTN"].ToString());
                    }
                    if (dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString() != "")
                    {
                        leaveendsctn = Convert.ToInt32(dtworkingdays.Rows[loop]["LEAVE_TO_SCTN"].ToString());
                    }
                    if (leaveendsctn == 2)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leaveendsctn == 3)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leavefrmsctn == 2)
                    {
                        leavecount = leavecount - 0.5;
                    }
                    if (leavefrmsctn == 3)
                    {
                        leavecount = leavecount - 0.5;
                    }


                }

                workingdays = numtoday - leavecount;
                DataTable dtDoc = objBuss.ReadDocumentName(objEnt);
                if (dtDoc.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDoc.Rows.Count; j++)
                    {
                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "RP")
                        {
                            strRPNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }

                        if (dtDoc.Rows[j]["EMPIMG_DOC_NAME"].ToString() == "Visa")
                        {
                            strVisaNo = dtDoc.Rows[j]["EMPIMG_DOC_NUMBER"].ToString();
                        }
                    }
                }
                break;
            }
            if (strRPNo == "")
            {
                if (NationalIdNum != "")
                {
                    strRPNo = NationalIdNum;
                }
                else if (strVisaNo != "")
                {
                    strRPNo = strVisaNo;
                }
            }




            string SLRY_BASICPAY_OR_PRSD_BASICPAY = "";

            //EVM-0039

            decimal decAlwnc = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["ALLOWANCE"].ToString());
            decimal decDeduc = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["DEDUCTION"].ToString());

            if (objEnt.Mode == 1)
            {
                if (dt.Rows[intColumnBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
                {
                    SLRY_BASICPAY_OR_PRSD_BASICPAY = dt.Rows[intColumnBodyCount]["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
                }
                else
                {
                    SLRY_BASICPAY_OR_PRSD_BASICPAY = dt.Rows[intColumnBodyCount]["SLRY_BASIC_PAY"].ToString();
                }
            }
            else if (objEnt.Mode == 2)//Leave settlement
            {
                decimal value = 0;
                int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                string valuestring = String.Format(format, value);

                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(dt.Rows[intColumnBodyCount]["ID"].ToString());
                DataTable dtLeavSettl = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

                if (dtLeavSettl.Rows.Count > 0)
                {
                    if (dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != valuestring && dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PRVMNTH_SAL"].ToString() != "")
                    {
                        SLRY_BASICPAY_OR_PRSD_BASICPAY = dtLeavSettl.Rows[intColumnBodyCount]["BASIC_PREV"].ToString();


                        decimal Allo = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["ALLOWANCE"].ToString());//allo = allowance include cur mnth aditions
                        decimal AlloBasic = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["BASIC_CURR"].ToString());//AlloBasic = basic of current
                        decimal Premtadd = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_ADDITION"].ToString());//Premtadd =Previous month empl addition
                        decimal premtarr = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_ARREAR_AMNT"].ToString());//premtarr = Previous month arrear
                        decimal premtot = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_OVERTIME_AMNT"].ToString());//premtot =Previous month ot amount
                        decimal premtother = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_OTHERAMT"].ToString());//premtother =Previous other addition(manual)
                        decimal Premtadditions = Premtadd + premtarr + premtot + premtother;

                        decAlwnc = AlloBasic + Allo + Premtadditions;


                        decimal Deduc = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["DEDUCTION"].ToString());//Deduc = Dedc include cur mnth deductions
                        decimal PremtDedc = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_DEDUCTION"].ToString());//PremtDedct = Previous month empl deduction
                        decimal PremtinstDedc = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc = Previous month Payment deduction
                        decimal premtotherdeduc = Convert.ToDecimal(dtLeavSettl.Rows[intColumnBodyCount]["LEVSETLMT_PREV_OTHERDEDCTN"].ToString());//premtotherdeduc = Previous other deductions(manual)
                        decimal Premtdeductions = PremtDedc + PremtinstDedc + premtotherdeduc;

                        decDeduc = Deduc + Premtdeductions;
                    }
                    else
                    {
                        SLRY_BASICPAY_OR_PRSD_BASICPAY = dtLeavSettl.Rows[intColumnBodyCount]["BASIC_CURR"].ToString();
                    }

                }
            }

            else if (objEnt.Mode == 3)//End of service
            {
                clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
                clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

                objEntityLayerEndOfServiceLeaveStlmnt.OrgId = objEnt.OrgId;
                objEntityLayerEndOfServiceLeaveStlmnt.CorpId = objEnt.CorprtId;
                objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(dt.Rows[intColumnBodyCount]["ID"].ToString());
                DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);

                if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
                {
                    if (dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["PREV_MONTH_SAL"].ToString() != "0" && dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["PREV_MONTH_SAL"].ToString() != "")
                    {
                        SLRY_BASICPAY_OR_PRSD_BASICPAY += dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["BASIC_PREV"].ToString();


                        decimal Allo1 = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["ALLOWANCE"].ToString());//Allo1 = including all current mnt additions
                        decimal AlloBasic1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_STLMT_BASICPAY"].ToString());//AlloBasic1 = Current mnth basic
                        decimal Premtadd1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_PREV_ADDITION"].ToString());//Premtadd1 = Previous month empl addition
                        decimal premtarr1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_PREV_MNTH_ARR_AMT"].ToString());//premtarr1 = Prevous month arrear
                        decimal premtot1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_PREV_OVERTIME_AMNT"].ToString());//premtot1 = Previous month ot amount
                        decimal premtother1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["PREV_OTHER_ADD_AMNT"].ToString());//premtother1 = Prevoius other addition(manual)
                        decimal Premtadditions = Premtadd1 + premtarr1 + premtot1 + premtother1;

                        decAlwnc = AlloBasic1 + Allo1 + Premtadditions;


                        decimal Deduc1 = Convert.ToDecimal(dt.Rows[intColumnBodyCount]["DEDUCTION"].ToString());//Deduc1 = Dedc1 include cur mnth deductions
                        decimal PremtDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_PREV_DEDUCTION"].ToString());//PremtDedct1 = Previous month empl deduction
                        decimal PremtinstDedc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_PREV_PAYMENT_DEDUCT"].ToString());//PremtinstDedc1 = Previous month Payment deduction
                        decimal premtotherdeduc1 = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["PREV_OTHER_DEDUCT_AMNT"].ToString());//premtotherdeduc1 = Previous other deductions(manual)
                        decimal Premtdeductions1 = PremtDedc1 + PremtinstDedc1 + premtotherdeduc1;

                        decDeduc = Deduc1 + Premtdeductions1;
                    }
                    else
                    {
                        SLRY_BASICPAY_OR_PRSD_BASICPAY += dtEndOfServiceLeaveStlmnt.Rows[intColumnBodyCount]["SRVCLVE_STLMT_BASICPAY"].ToString();
                    }

                }

            }

            // table.Rows.Add(count.ToString(), strRPNo, strVisaNo, dt.Rows[intColumnBodyCount]["EMPNAME"], dt.Rows[intColumnBodyCount]["BANK_NAME"].ToString(), Accountno, dt.Rows[intColumnBodyCount]["FREQUENCY"], workingdays, dt.Rows[intColumnBodyCount]["NET_AMOUNT"], dt.Rows[intColumnBodyCount]["SLRY_BASIC_PAY"], dt.Rows[intColumnBodyCount]["OVERTIMEHOURS"], dt.Rows[intColumnBodyCount]["ALLOWANCE"].ToString(), dt.Rows[intColumnBodyCount]["DEDUCTION"], dt.Rows[intColumnBodyCount]["type"], strComments, strempid);
            table.Rows.Add(count.ToString(), strRPNo, strVisaNo, dt.Rows[intColumnBodyCount]["EMPNAME"], dt.Rows[intColumnBodyCount]["BANK_NAME"].ToString(), Accountno, dt.Rows[intColumnBodyCount]["FREQUENCY"], workingdays, dt.Rows[intColumnBodyCount]["NET_AMOUNT"], SLRY_BASICPAY_OR_PRSD_BASICPAY, dt.Rows[intColumnBodyCount]["OVERTIMEHOURS"], decAlwnc.ToString(), decDeduc.ToString(), dt.Rows[intColumnBodyCount]["type"], strComments, strempid);

        }

        return table;
    }
    public string DataTableToCSV(DataTable dtSIFHeader, DataTable dtSIFRecords, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        //SIFHeader
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        //SIFRecords
        for (int i = 0; i < dtSIFRecords.Columns.Count; i++)
        {
            sb.Append(dtSIFRecords.Columns[i]);
            if (i < dtSIFRecords.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFRecords.Rows)
        {
            for (int i = 0; i < dtSIFRecords.Columns.Count; i++)
            {
                if (i == 10 && dr[i].ToString() == "")
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append(dr[i].ToString());
                }
                if (i < dtSIFRecords.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();

    }


    protected void ddlDep_selectedIndexChange(object sender, EventArgs e)     //emp25
    {

        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();

        if (Session["CORPOFFICEID"] != null)
        {
            
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEnt.UserId = Convert.ToInt32(Session["USERID"]);

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
            objEnt.Department = Dept;

            DataTable dtSubConrt = objBuss.LoadDivision(objEnt);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtSubConrt;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }


    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strRandom = objCommon.Random_Number();
        int Corpt_Id = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            Corpt_Id= Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        StringBuilder sb = new StringBuilder();



        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >";

        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"hasinput\" style=\"width:4%;text-align: center;\"> <label class=\"checkbox\"style=\"\" ><input type=\"checkbox\" title=\"SELECT ALL\"  onchange='return changeAll();'   onkeypress='return DisableEnter(event)'  id=\"cbMandatory\"><i  style=\"\"></i></label></th>";

        HiddenRECORD.Value = dt.Rows.Count.ToString();
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:12%\"> EMPLOYEE ID";
                strHtml += "<input class=\"form-control\" placeholder=\"EMPLOYEE ID\" type=\"text\"></th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%\"> EMPLOYEE";
                strHtml += "<input class=\"form-control\" placeholder=\"EMPLOYEE\" type=\"text\"></th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> DESIGNATION";
                strHtml += "<input class=\"form-control\" placeholder=\"DESIGNATION\" type=\"text\"></th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> PAYGRADE";
                strHtml += "<input class=\"form-control\" placeholder=\"PAYGRADE\" type=\"text\"></th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> TOTAL AMOUNT";
                strHtml += "<input class=\"form-control\" placeholder=\"TOTAL AMOUNT\" type=\"text\"></th>";
              
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> ";
                strHtml += "<input class=\"form-control\" placeholder=\"COMMENTS\" type=\"text\"></th>";
            }
        }
        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;display:none\"> Edit";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        int i = 0;
        string SettledLeavMssg = "";
        string amount = "";
        string StlID = "";
        string TableID = "";

        
        string levstldate = "";
        string esplstdate = "";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            i++;      
            strHtml += "<tr  >";
            strHtml += "<td class=\"hasinput\" style=\"width:4%;text-align: center;\"> <label class=\"checkbox\"style=\"\" ><input type=\"checkbox\"  onchange=\"check() \" onkeypress='return DisableEnter(event)'  id=\"cbMandatory" + intRowBodyCount + "\"><i  style=\"\"></i></label></td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (dt.Rows.Count > 0)
                {
                    if (ddlmode.SelectedItem.Value == "1")
                    {
                        objEnt.Employee = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());
                        DataTable dtLeavSettlmentVChk = objBuss.ReadLeavSettlmentChk(objEnt);
                        decimal decSettlmntAmnt = 0;

                        if (dtLeavSettlmentVChk.Rows.Count > 0)
                        {
                            decSettlmntAmnt = Convert.ToDecimal(dtLeavSettlmentVChk.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString());
                            if (decSettlmntAmnt > 0)
                            {
                                SettledLeavMssg = "LEAVE SETTLED";
                            }
                            else
                            {
                                SettledLeavMssg = "";
                            }
                        }
                    }

                    if (intColumnBodyCount == 0)
                    {
                        TableID = dt.Rows[intRowBodyCount]["USR_ID"].ToString();

                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                       
                        if (ddlmode.SelectedItem.Value == "2")
                        {

                            levstldate = dt.Rows[intRowBodyCount]["LEVSETLMT_LST_SETLMTDATE"].ToString();
                        }
                        if (ddlmode.SelectedItem.Value == "3")
                        {
                            esplstdate= dt.Rows[intRowBodyCount]["SRVCLVE_LST_SETLMTDATE"].ToString();
                        }
                    }
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["Empname"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PYGRD_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        objEntityCommon.CorporateID = Convert.ToInt32(Corpt_Id);
                        //if (indvlRound == "1")
                        //{
                            amount = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                        //}
                        //else
                        //{
                        //    amount = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString(), objEntityCommon);
                        //}
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + amount + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {
                        StlID = dt.Rows[intRowBodyCount]["STL_ID"].ToString();
                        strHtml += "<td class=\"tdT\" style=\"width:20%\"><input name=\"txtPaid" + StlID + "\" id=\"txtPaid" + StlID + "\"value=\"" + SettledLeavMssg + "\" style=\"text-align:left;width:100%;\" type=\"text\" class=\"form-control\" onkeypress=\"return isTag(event)\" onblur=\"return blurcomments('#txtPaid" + StlID + "',450);\"  maxlength=100 /></td>";
                
                    }
                  
                }
            }
            if (ddlmode.SelectedItem.Value == "1")
            {
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;display:none\"   ><input type=\"text\"  value=\"" + TableID + "\"  id=\"allIds" + intRowBodyCount + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + StlID + "\"  id=\"STl_id" + intRowBodyCount + "\" style=\"display:none;\" /></td> ";
            }

            if (ddlmode.SelectedItem.Value == "2")
            {
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;display:none\" ><input type=\"text\"  value=\"" + TableID + "\"  id=\"allIds" + intRowBodyCount + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + StlID + "\"  id=\"STl_id" + intRowBodyCount + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + levstldate + "\"  id=\"levstldate" + intRowBodyCount + "\" style=\"display:none;\" /></td> ";
            }

            if (ddlmode.SelectedItem.Value == "3")
            {
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;display:none\" ><input type=\"text\"  value=\"" + TableID + "\"  id=\"allIds" + intRowBodyCount + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + StlID + "\"  id=\"STl_id" + intRowBodyCount + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + esplstdate + "\"  id=\"espstldate" + intRowBodyCount + "\" style=\"display:none;\" /></td> ";
            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

        //End

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {


        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (Session["CORPOFFICEID"] != null)
        {
            objEnt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEnt.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlMonth.SelectedItem.Value != "--SELECT MONTH--")
        {
            objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        }
        if (ddlYear.SelectedItem.Value != "--SELECT YEAR--")
        {
            objEnt.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        }

        if (ddlmode.SelectedItem.Value != "")
        {
            objEnt.Mode = Convert.ToInt32(ddlmode.SelectedItem.Value);

            Hiddenmode.Value = ddlmode.SelectedItem.Value.ToString();
        }
        if (radioCustType1.Checked)
        {
            objEnt.Staff_Worker = 1;
        }
        if (radioCustType2.Checked)
        {
            objEnt.Staff_Worker = 0;
        }
        if (Hiddentxtefctvedate.Value != "")
        {
            objEnt.date = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEnt.BusnsUnitId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
        {
            objEnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        } if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEnt.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddldesg.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEnt.Designation = Convert.ToInt32(ddldesg.SelectedItem.Value);
        }
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEnt.Department = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddlSponsor.SelectedItem.Value != "--SELECT SPONSOR--")
        {
            objEnt.SponsorId = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }
        DataTable dtlist = objBuss.ReadMonthlySal_PaidList(objEnt);
        string ListLoad = ConvertDataTableToHTML(dtlist);
        divList.InnerHtml = ListLoad;

      
    }
}