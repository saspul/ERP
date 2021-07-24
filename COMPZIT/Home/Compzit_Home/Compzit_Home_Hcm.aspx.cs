using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.Web.Script.Serialization;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

public partial class Home_Compzit_Home_Compzit_Home_Hcm : System.Web.UI.Page
{
    string strCurrencyAbbr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "5";

        if (!IsPostBack)
        {
            HiddenToCheckOthersConduct.Value = "0";
            
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
            clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
          
            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;

                if (Session["CORPOFFICEID"] != null)
                {
                    clsBusinessLayer objBusiness = new clsBusinessLayer();
                    DataTable dtCorpDetails = new DataTable();

                    int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetails = objBusiness.LoadGlobalDetail(arrEnumerr, intCorppId);
                    if (dtCorpDetails.Rows.Count > 0)
                    {
                        if (dtCorpDetails.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetails.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }



                clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
                objEntLogin.CorpOfficeId = Convert.ToInt32(strId);
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtCorpName = new DataTable();
                dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);


                if (dtCorpName.Rows.Count > 0)
                {
                    Session["CORPORATENAME"] = dtCorpName.Rows[0]["CORPRT_NAME"].ToString();
                }
            }




            if (Session["DSGN_CONTROL"] != null)
            {
                string strDesgnCntrl = Session["DSGN_CONTROL"].ToString();
                if (strDesgnCntrl == "O")
                {
                    divContentArea.Visible = false;
                    goto labelouter;
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            int intUserId = 0, intCorpId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                if (dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString() != "")
                {
                    objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
                }
            }            
           DataTable dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
           
            if (dtCurrencyDetails.Rows.Count > 0)
            {
                strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            HandoverNotification();

            LoadBarChartEmployee();
            LoadListDatas();
            LoadPendingCountSection();
            LoadAccomodationData();
            clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
            clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
            
            if (Session["CORPOFFICEID"] != null)
            {
             
                objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
               if (Session["ORGID"] != null)
            {
                objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
               if (Session["USERID"] != null)
               {
                   objEntity.UserId = Convert.ToInt32(Session["USERID"]);
               }
     
         //   DataTable DtConduct = objEmpConduct.ReadConductCount(objEntity);


        labelouter:;


        }
    }

    public void LoadBarChartEmployee()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivisions = objBusinessDashBoard.ReadDivisions(objEntityLead);

        DataTable DtTotal = new DataTable();
        DtTotal.Columns.Add("Division", typeof(string));
        DtTotal.Columns.Add("Alloted", typeof(int));
        DtTotal.Columns.Add("OnLeave", typeof(int));
        DtTotal.Columns.Add("Available", typeof(int));

        foreach (DataRow DtRow in dtDivisions.Rows)
        {
            clsEntityLeadCreation objEntityLead2 = new clsEntityLeadCreation();
            objEntityLead2.Org_Id = objEntityLead.Org_Id;
            objEntityLead2.Corp_Id = objEntityLead.Corp_Id;
            DataRow drDtl = DtTotal.NewRow();

            drDtl["Division"] = (DtRow["CPRDIV_CODE"].ToString());
            objEntityLead2.DivisionId = Convert.ToInt32(DtRow["CPRDIV_ID"]);

            DataTable dtAlloted = objBusinessDashBoard.ReadEmployesAllocated(objEntityLead2);

            drDtl["Alloted"]=Convert.ToInt32(dtAlloted.Rows[0]["COUNT"].ToString());

            DataTable dtOnleave=objBusinessDashBoard.ReadEmployesOnLeave(objEntityLead2);
            drDtl["OnLeave"] = Convert.ToInt32(dtOnleave.Rows[0]["COUNT"].ToString());

            DataTable dtAvailable = objBusinessDashBoard.ReadEmployeesForBarDia(objEntityLead2);
            drDtl["Available"] = Convert.ToInt32(dtAvailable.Rows[0]["COUNT"].ToString());

            DtTotal.Rows.Add(drDtl);

        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(DtTotal);
        hiddenEmployeeBarDiaData.Value = strJson;
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

    public void LoadPendingCountSection()
    {
        clsEntityDashBoard objEntityDashBoard = new clsEntityDashBoard();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int orgid = 0, corpId = 0; 
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDashBoard.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString()); 
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDashBoard.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            orgid = Convert.ToInt32(Session["ORGID"].ToString()); 
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        string StrUserId = "";
        if (Session["USERID"] != null)
        {
            objEntityDashBoard.UserId = Convert.ToInt32(Session["USERID"].ToString());
            StrUserId = objEntityDashBoard.UserId.ToString();
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCount = new DataTable();
        DataTable dtReadFlightAmountList = objBusinessDashBoard.ReadFlightAmountList(objEntityDashBoard);
        dtCount = objBusinessDashBoard.ReadPendingCounts(objEntityDashBoard);
        DataTable dtNextBirthday = objBusinessDashBoard.ReadNextLeave(objEntityDashBoard);
        if (dtNextBirthday.Rows.Count > 0)
        {
            if (dtNextBirthday.Rows.Count == 2)
            {
                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                if (dtNextBirthday.Rows[0]["FROM_DATE"].ToString() == "" || dtNextBirthday.Rows[1]["FROM_DATE"].ToString() == "")
                {
                    if (dtNextBirthday.Rows[0]["FROM_DATE"].ToString() != "")
                        lblNextLeave.InnerText = dtNextBirthday.Rows[0]["FROM_DATE"].ToString();
                    else if (dtNextBirthday.Rows[1]["FROM_DATE"].ToString() != "")
                        lblNextLeave.InnerText = dtNextBirthday.Rows[1]["FROM_DATE"].ToString();
                    else
                        lblNextLeave.InnerText = "Not Mentioned";
                }
                else
                {
                    if (dtNextBirthday.Rows[0]["FROM_DATE"].ToString() != "")
                        dt1 = objCommon.textToDateTime(dtNextBirthday.Rows[0]["FROM_DATE"].ToString());
                    if (dtNextBirthday.Rows[1]["FROM_DATE"].ToString() != "")
                        dt2 = objCommon.textToDateTime(dtNextBirthday.Rows[1]["FROM_DATE"].ToString());
                    if (dt1 != DateTime.MinValue && dt2 != DateTime.MinValue)
                    {
                        if (dt1 < dt2)
                        {
                            lblNextLeave.InnerText = dt1.ToString();
                        }
                        else
                        {
                            lblNextLeave.InnerText = dt2.ToString();
                        }
                    }
                }
            }
            else
            {
                lblNextLeave.InnerText = dtNextBirthday.Rows[0]["FROM_DATE"].ToString();
            }
        }
        else
        {
            lblNextLeave.InnerText = "Not Mentioned";
        }

        if (dtCount.Rows.Count > 0)
        {
            lblOnboarding.InnerText = dtCount.Rows[0]["COUNT"].ToString();
            lblImmigration.InnerText = dtCount.Rows[1]["COUNT"].ToString();
            lblRecruitment.InnerText = dtCount.Rows[2]["COUNT"].ToString();
            lblTotalManPower.InnerText = dtCount.Rows[3]["COUNT"].ToString();
            lblManPowerPndng.InnerText = dtCount.Rows[4]["COUNT"].ToString();
            lblManPowerAprvd.InnerText = dtCount.Rows[5]["COUNT"].ToString();
            lblInterviewprocess.InnerText = dtCount.Rows[6]["COUNT"].ToString();
            lblOnboardingProcess.InnerText = dtCount.Rows[7]["COUNT"].ToString();
            lblEmpPresent.InnerText = dtCount.Rows[8]["COUNT"].ToString();
            lblEmpAbsent.InnerText = dtCount.Rows[9]["COUNT"].ToString();
            lblMyLeaveCount.InnerText = dtCount.Rows[10]["COUNT"].ToString();
            lblLeaveCount.InnerText = dtCount.Rows[11]["COUNT"].ToString();
            lblExitCount.InnerText = dtCount.Rows[12]["COUNT"].ToString();
            lblRejoinCount.InnerText = dtCount.Rows[13]["COUNT"].ToString();

            lblExitAproved.InnerText = dtCount.Rows[25]["COUNT"].ToString();

            lblVisaApplied.InnerText = dtCount.Rows[14]["COUNT"].ToString();
            lblVisaPending.InnerText = dtCount.Rows[15]["COUNT"].ToString();
            lblVisaRejected.InnerText = dtCount.Rows[16]["COUNT"].ToString();
            lblVisaApproved.InnerText = dtCount.Rows[17]["COUNT"].ToString();

            lblTcktApplied.InnerText = dtCount.Rows[19]["COUNT"].ToString();
            lblTcktBuy.InnerText = dtCount.Rows[20]["COUNT"].ToString();
            if (HiddenCurncyAbrv.Value == "")
            {
                if (HiddenFlightAmt.Value != "")
                    lblTcktAmount.InnerText = HiddenFlightAmt.Value + " " + strCurrencyAbbr;
                else
                    lblTcktAmount.InnerText = 0 + " " + strCurrencyAbbr;
            }
            else
            {
                if (HiddenFlightAmt.Value != "")
                    lblTcktAmount.InnerText = HiddenFlightAmt.Value + " " + HiddenCurncyAbrv.Value;
                else
                    lblTcktAmount.InnerText = 0 + " " + HiddenCurncyAbrv.Value;
            }

            lblDepartCount.InnerText = dtCount.Rows[22]["COUNT"].ToString();
            lblArriveCount.InnerText = dtCount.Rows[23]["COUNT"].ToString();
            lblBirthdayToday.InnerText = dtCount.Rows[24]["COUNT"].ToString();
        }

        //To check count employee conduct incident

       // clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intEnableDMApprove = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Conduct);
        int IntUserId= objEntityDashBoard.UserId ;
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(IntUserId, intUsrRolMstrId);
        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
               
                }

            }
        }


        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();  //emp0025
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        objEntity.OrgId = orgid;
        objEntity.CorpId = corpId;
        objEntity.UsrId = Convert.ToInt32(StrUserId);
        DataTable dtUsrDtls = objEmpPerfomance.ReadUsrDesgDept(objEntity);
        DataTable dtList = objEmpPerfomance.ReadPerfomanceEvaluationCount(objEntity);
        string strEvltn = ConvertDataTableToHTML(dtList, dtUsrDtls, StrUserId, corpId, orgid);

        DataTable dtCountConduct = objBusinessDashBoard.ReadPendingCountsEmploeeConduct(objEntityDashBoard);
        if (dtCountConduct.Rows.Count > 0)
        {
            int CountConductOwn = 0;
            int CountConductOthers = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtCountConduct.Rows.Count; intRowBodyCount++)
            {
                
                if (dtCountConduct.Rows[intRowBodyCount]["USR_ID"].ToString() == StrUserId)
                {
                    if (dtCountConduct.Rows[intRowBodyCount]["CNDTINC_EMP_NOTIFY"].ToString() == "1")
                    {
                        CountConductOwn++;
                    }

                }

                else if (dtCountConduct.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "1")
                {
                    if (dtCountConduct.Rows[intRowBodyCount]["EMPREPORTING"].ToString() == StrUserId)
                    {

                        CountConductOthers++;
                    }


                }
                else if (dtCountConduct.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "2")
                {

                    if (intEnableDMApprove == 1)
                    {

                        CountConductOthers++;
                    }
                }
                else if (dtCountConduct.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "3")
                {

                    if (intEnableDMApprove == 1 || dtCountConduct.Rows[intRowBodyCount]["EMPREPORTING"].ToString() == StrUserId)
                    {


                        CountConductOthers++;

                    }
                }

               
            }

            if (CountConductOthers != 0)
            {
                HiddenToCheckOthersConduct.Value = "1";


                OtherCondid.Style.Add("display", "block");

                h5OthersCond.InnerText = CountConductOthers.ToString();

            }
            h5ConductCount.InnerText = CountConductOwn.ToString();
        
        }

    }
    public string ConvertDataTableToHTML(DataTable dt, DataTable dtUsrDtls, string strusrid, int corpId, int orgId) 
    {
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, HrApprove = 0, intEnableDMApprove = 0, intEnableGMApprove = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Evalvtn);

        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(Convert.ToInt32(strusrid), intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    HrApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //  HiddenDMApprove.Value = intEnableDMApprove.ToString();

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {


                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);



                }


            }
        }
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        int Nodata = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        StringBuilder sb = new StringBuilder();



        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int IssueEval = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_EVAL"].ToString());
            int hrEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_HR_EVLTOR"].ToString());
            int DmEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_DM_EVLTOR"].ToString());
            int GmEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_GM_EVLTOR"].ToString());
            int SelfEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_SELF_EVLTOR"].ToString());
            int ReptEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_RO_EVLTOR"].ToString());
            objEntity.EmpTyp = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_EMP"].ToString());
            objEntity.IssueId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_ID"].ToString());

            objEntity.CorpId = corpId;
            objEntity.OrgId = orgId;
            objEntity.UsrId = Convert.ToInt32(strusrid);
            DataTable DdtEmployeeDtls = objEmpPerfomance.ReadUsrDtls(objEntity);

            for (int intRowCount = 0; intRowCount < DdtEmployeeDtls.Rows.Count; intRowCount++)
            {
                string resposetype = HiddenResponseType.Value;

                int RoEvaluvation = 0;
                if (DdtEmployeeDtls.Rows[intRowCount]["EMPREPORTING"].ToString() != "")
                {
                    RoEvaluvation = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["EMPREPORTING"].ToString());
                }
                int EmpSelfEvaluvation = 0;
                if (DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString() != "")
                {
                    EmpSelfEvaluvation = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString());
                }
                int flag = 0;
                HiddenResponseType.Value = "";

                if (IssueEval == 1)
                {
                    objEntity.UsrId = Convert.ToInt32(strusrid);
                    objEntity.IssueType = 1;
                    DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                    if (DdteVLTR.Rows.Count > 0)
                    {
                        for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                        {
                            if (Convert.ToInt32(strusrid) == Convert.ToInt32(DdteVLTR.Rows[count]["ISSUE_EVLTR_USR_ID"].ToString()))
                            {
                                flag = 1;
                                HiddenResponseType.Value = "ADDITIONAL EMPLOYEE";
                            }
                        }
                    }

                }
                else if (IssueEval == 2)
                {
                    if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() != "")
                    {
                        objEntity.IssueType = 2;
                        objEntity.DeptId = Convert.ToInt32(dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString());
                        DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                        if (DdteVLTR.Rows.Count > 0)
                        {
                            for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                            {
                                if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DEPTID"].ToString())
                                {
                                    flag = 1;
                                    HiddenResponseType.Value = "DEPARTMENT";
                                }
                            }
                        }
                    }
                }
                else if (IssueEval == 3)
                {
                    if (dtUsrDtls.Rows[0]["DSGN_ID"].ToString() != "")
                    {
                        objEntity.IssueType = 3;
                        objEntity.DesgId = Convert.ToInt32(dtUsrDtls.Rows[0]["DSGN_ID"].ToString());
                        DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                        if (DdteVLTR.Rows.Count > 0)
                        {
                            for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                            {
                                if (dtUsrDtls.Rows[0]["DSGN_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DSGNID"].ToString())
                                {
                                    flag = 1;
                                    HiddenResponseType.Value = "DESIGNATION";
                                }
                            }
                        }
                    }
                }

                if ((SelfEvaluvation == 1) && (EmpSelfEvaluvation == Convert.ToInt32(strusrid)))
                {

                    flag = 1;
                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "SELF";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "SELF";
                    }
                }

                if ((RoEvaluvation != 0) && (ReptEvaluvation == 1))
                {
                    if (RoEvaluvation == Convert.ToInt32(strusrid))
                    {

                        flag = 1;
                        if (HiddenResponseType.Value == "")
                        {
                            HiddenResponseType.Value = "REPORTING OFFICER";
                        }
                        else
                        {
                            HiddenResponseType.Value = HiddenResponseType.Value + "," + "REPORTING OFFICER";
                        }
                    }

                }

                if (DmEvaluvation == 1 && intEnableDMApprove == 1)
                {
                    flag = 1;

                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "DIVISION MANAGER";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "DIVISION MANAGER";
                    }
                }

                if (hrEvaluvation == 1 && HrApprove == 1)
                {
                    flag = 1;

                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "HR";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "HR";
                    }
                }

                if (GmEvaluvation == 1 && intEnableGMApprove == 1)
                {
                    flag = 1;

                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "GENERAL MANAGER";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "GENERAL MANAGER";
                    }

                }


                string RESPONStYP = HiddenResponseType.Value;


                int flagsts = 0;
                string sts = "";
                objEntity.IssueEmpId = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString());
                DataTable DdtEvltrsDtls = objEmpPerfomance.ReadEvltrsDtls(objEntity);
                if (DdtEvltrsDtls.Rows.Count > 0)
                {
                    for (int cnfCount = 0; cnfCount < DdtEvltrsDtls.Rows.Count; cnfCount++)
                    {
                        sts = DdtEvltrsDtls.Rows[cnfCount]["PRMNC_CNFRM_STS"].ToString();
                        if (DdtEmployeeDtls.Rows[intRowCount]["EMPLOYEE_NAME"].ToString() == DdtEvltrsDtls.Rows[cnfCount]["EMPLOYEE_NAME"].ToString())
                        {
                            flagsts = 1;
                        }
                        else
                        {
                            flagsts = 0;
                        }

                    }
                    if (flag == 1)
                    {

                        if (flagsts == 1)
                        {


                            if (sts == "1")
                            {



                            }

                            else
                            {
                                COUNT = COUNT + 1;
                            }
                        }
                    }
                    else
                    {



                    }

                }
                else
                {
                    if (flag == 1)
                    {

                        COUNT = COUNT + 1;
                    }
                }

                lblPrfmncEvltn.Text = Convert.ToString(COUNT);

            }
            if (COUNT > 0)
            {
                divPerfmncEvltn.Attributes["style"] = "display:block;position: absolute;z-index: 100;width:95%; margin-top: 2.5%;";
            }
            if (COUNT == 0)
            {
                divPerfmncEvltn.Attributes["style"] = "display:none;position: absolute;z-index: 100;width:95%;margin-top: 2.5%;";
            }

        }






        sb.Append(COUNT);
        return sb.ToString();
    }
    public void LoadAccomodationData()
    {
        clsEntityDashBoard objEntityDashBoard = new clsEntityDashBoard();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDashBoard.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDashBoard.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtRoomDetails = objBusinessDashBoard.ReadAccodetails(objEntityDashBoard);
        if (dtRoomDetails.Rows.Count > 0)
        {
            int totalRooms = Convert.ToInt32(dtRoomDetails.Rows[0]["COUNT"]);
            int AllotedRooms = Convert.ToInt32(dtRoomDetails.Rows[1]["COUNT"]);
            TotalRooms.InnerHtml ="TOTAL ROOMS : "+ totalRooms.ToString();
            int remainingRooms = totalRooms - AllotedRooms;
            int VacateRooms = Convert.ToInt32(dtRoomDetails.Rows[2]["COUNT"]);

            HidddenAccodetails.Value = remainingRooms + "," + AllotedRooms + "," + VacateRooms;
        }


    }

    public void LoadListDatas()
    {
        clsEntityDashBoard objEntityDashBoard = new clsEntityDashBoard();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        HiddenFlightAmt.Value = "0";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDashBoard.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDashBoard.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtReadFlyTodayList = objBusinessDashBoard.ReadFlyTodayList(objEntityDashBoard);
        DataTable dtReadFlightAppliedList = objBusinessDashBoard.ReadFlightAppliedList(objEntityDashBoard);
        DataTable dtReadFlightBuyList = objBusinessDashBoard.ReadFlightBuyList(objEntityDashBoard);
        DataTable dtReadFlightAmountList = objBusinessDashBoard.ReadFlightAmountList(objEntityDashBoard);
        DataTable dtReadEmpArrive = objBusinessDashBoard.ReadEmpArrive(objEntityDashBoard);
        DataTable dtReadEmpADepart = objBusinessDashBoard.ReadEmpADepart(objEntityDashBoard);
        DataTable dtReadBirthdayList = objBusinessDashBoard.ReadEmpBirthdayList(objEntityDashBoard);

        string BirthdayInner = TableCreation(dtReadBirthdayList);
        divBirthdayList.InnerHtml = BirthdayInner;

        string FlightAppliedListInner = TableCreation(dtReadFlightAppliedList);
        divFlightApplied.InnerHtml = FlightAppliedListInner;

        string FlightBuyListInner = TableCreation(dtReadFlightBuyList);
        divFlightBuy.InnerHtml = FlightBuyListInner;

        string FlightAmountListInner = TableCreation(dtReadFlightAmountList);
        divFlightAmount.InnerHtml = FlightAmountListInner;

        string FlightArriveListInner = TableCreation(dtReadEmpArrive);
        divEmpArrive.InnerHtml = FlightArriveListInner;

        string FlightDepartListInner = TableCreation(dtReadEmpADepart);
        divEmpDepart.InnerHtml = FlightDepartListInner;
        DataTable dtEmpPerformance = objBusinessDashBoard.ReadExpiredEmpPerformance(objEntityDashBoard);
        string EmpPerformanceListInner = TableCreationEmpPerformance(dtEmpPerformance);
        divEmpPerformance.InnerHtml = EmpPerformanceListInner;
        //Start : EVM-24
        if (dtReadFlightAmountList.Rows.Count > 0)
        {
            if (dtReadFlightAmountList.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                HiddenCurncyAbrv.Value = dtReadFlightAmountList.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
        }
        for (int amtrow = 0; amtrow < dtReadFlightAmountList.Rows.Count; amtrow++)
        {
            if (HiddenFlightAmt.Value == "0")
            {
                HiddenFlightAmt.Value = dtReadFlightAmountList.Rows[amtrow]["AMOUNT"].ToString();
            }
            else
            {
                HiddenFlightAmt.Value = HiddenFlightAmt.Value + dtReadFlightAmountList.Rows[amtrow]["AMOUNT"].ToString();
            }
        }
        //End
    }

    public string TableCreation(DataTable dtDetails)
    {

        StringBuilder sb = new StringBuilder();
        string strHtml = " <table class=\"table table-hover\">";
        string AmountAlign = "false";
        strHtml += "<thead>";
        strHtml += "<tr>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtDetails.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount ==2)
            {
                strHtml += "<th class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                if (dtDetails.Columns[intColumnHeaderCount].ColumnName == "AMOUNT")
                {
                    AmountAlign = "true";
                    strHtml += "<th class=\"text-center\" style=\"text-align: right;\">" + dtDetails.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";

        if (dtDetails.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtDetails.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  class=\"edit\">";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dtDetails.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 3)
                    {
                        if (AmountAlign == "false")
                        {
                            strHtml += "<td class=\"text-center\" style=\"text-align: left;\">" + dtDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"text-center\" style=\"text-align: right;\">" + dtDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }
                }

                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<tr  class=\"edit\">";
            strHtml += "<td class=\"text-center\" colspan=\"2\" style=\"text-align: right;\">NO DATA AVAILABLE</td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //Handover notificatioon startss
    public void HandoverNotification()
    {
        clsBusinessLayerClearanceFormWorker objBusinessLeaveApproval = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
        if (Session["USERID"] != null)
        {
            ObjEntityLeaveApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeaveApproval.Empid = Convert.ToInt32(Session["USERID"]);
            HiddenLoginUserId.Value = Session["USERID"].ToString();
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveApproval.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            // intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeaveApproval.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //   ObjEntityLeaveApproval.Empid = 10027;

        DataTable dtTOtallve = objBusinessLeaveApproval.ReadHadover(ObjEntityLeaveApproval);
        DataView view = new DataView(dtTOtallve);
        DataTable distinctValues = view.ToTable(true, "LVECLRSTF_USR_ID", "USR_NAME");
        lblcountClearance.InnerText = distinctValues.Rows.Count.ToString();
        //lblcountClearance2.Text = distinctValues.Rows.Count.ToString();

        if (distinctValues.Rows.Count.ToString() == "0")
        {

           // divnotific.Visible = false;
        }
        int count = 0;
        foreach (DataRow drOutput in distinctValues.Rows)
        {
            Hiddenrowcount.Value = distinctValues.Rows.Count.ToString();
            count = count + 1;
            string userid = drOutput["LVECLRSTF_USR_ID"].ToString();
            string username = drOutput["USR_NAME"].ToString();
            HtmlGenericControl li = new HtmlGenericControl("li");
            handovernotify.Controls.Add(li);
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "#");
            anchor.Attributes.Add("onclick", "getusernotifications(" + userid + ")");
            anchor.Attributes.Add("class", "ui button default pg-following");
            anchor.Attributes.Add("id", "Notificbutton" + count);
            anchor.InnerText = username;

            li.Controls.Add(anchor);

        }

    }
    public class clsHandover
    {
        public string DECSNID { get; set; }
        public string COMNTS { get; set; }
        public string TBLID { get; set; }

    }
    //It build the Html table by using the datatable provided
    protected void btnProcessSingleSave_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerClearanceFormWorker objBusinessLeaveApproval = new clsBusinessLayerClearanceFormWorker();
        // clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
        //For schedule level detail table
        List<clsEntityLayerClearanceFormWorker> objEntityJobSubmsnDtlList = new List<clsEntityLayerClearanceFormWorker>();
        string jsonDataPW = hiddenjsondtails.Value;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsHandover> objWBDataPWList = new List<clsHandover>();
        // UserData  data
        if (hiddenjsondtails.Value != null && hiddenjsondtails.Value != "")
        {
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsHandover>>(R5PW);
            foreach (clsHandover objclsJSData in objWBDataPWList)
            {
                if (objclsJSData.TBLID.ToString() != "")
                {

                    clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
                    ObjEntityLeaveApproval.Subtableid = Convert.ToInt32(objclsJSData.TBLID);
                    ObjEntityLeaveApproval.Decision = Convert.ToInt32(objclsJSData.DECSNID);
                    ObjEntityLeaveApproval.Comments = objclsJSData.COMNTS;

                    objEntityJobSubmsnDtlList.Add(ObjEntityLeaveApproval);
                }
            }

        }
        objBusinessLeaveApproval.UpdateHadover(objEntityJobSubmsnDtlList);
        HandoverNotification();

    }
    public string TableCreationEmpPerformance(DataTable dtDetails)
    {

        StringBuilder sb = new StringBuilder();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        DateTime dateCurrentDate = objCommon.textToDateTime(strCurrentDate);
        string strRandom = objCommon.Random_Number();
        int flag = 0;
        string strHtml = " <table class=\"table table-hover\">";
        strHtml += "<tbody>";
        string NewRev = "";
        for (int intRowBodyCount = 0; intRowBodyCount < dtDetails.Rows.Count; intRowBodyCount++)
        {
            if (!(NewRev.Contains(dtDetails.Rows[intRowBodyCount]["ISSUE_REFNO"].ToString())))
            {
                var max = dtDetails.AsEnumerable()
                .Where(row => row["ISSUE_REFNO"].ToString() == dtDetails.Rows[intRowBodyCount]["ISSUE_REFNO"].ToString())
                .Max(row => row["ISSUE_REVNO"]);
                var max1 = dtDetails.AsEnumerable()
               .Where(row => row["ISSUE_REVNO"].ToString() == max.ToString() && row["ISSUE_REFNO"].ToString() == dtDetails.Rows[intRowBodyCount]["ISSUE_REFNO"].ToString());
                string searchExpression = "ISSUE_REVNO = '" + max.ToString() + "' and ISSUE_REFNO='" + dtDetails.Rows[intRowBodyCount]["ISSUE_REFNO"].ToString() + "'";
                DataRow[] foundRows = dtDetails.Select(searchExpression);
                foreach (DataRow row in foundRows)
                {
                    string strDate = row["ISSUE_DATE"].ToString();
                    DateTime dateIssueDate = objCommon.textToDateTime(strDate);
                    NewRev = NewRev + "," + row["ISSUE_REFNO"].ToString();

                    if (dateCurrentDate > dateIssueDate)
                    {
                        string strUId = row["ISSUE_ID"].ToString();
                        int intIdLength = strUId.Length;
                        string stridLength = intIdLength.ToString("00");
                        string UId = stridLength + strUId + strRandom;
                        flag++;
                        strHtml += "<tr class=\"edit\">";
                        strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"text-center\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;padding-left: 2em;\"  >" + " <a class=\"tooltip\"  style=\"cursor:pointer;color: blue;opacity: 1;position: sticky;\"onclick='return getdetails(this.href);' " + " href=\"../../HCM/HCM_Master/Employee_Performance_Mangmnt/Issue_Performance_Form/Emp_Issue_Prfrmnce_Form.aspx?DashBrdId=" + UId + "\">" + row["ISSUE_PRFM"].ToString() + "</a></td>";
                        strHtml += "<td id=\"tdUsrName_" + intRowBodyCount + " \" class=\"text-center\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + row["ISSUE_ID"].ToString() + "</td>";
                        strHtml += "</tr>";
                    }
                }
            }
        }
        lblIssuseCount.Text = Convert.ToString(flag);
        if (flag > 0)
        {
            divPopUpPerformance.Attributes["style"] = "display:block;position: absolute;z-index: 100;width:95%;margin-top: -2%;";
        }
        if (flag == 0)
        {
            strHtml += "<tr  class=\"edit\">";
            strHtml += "<td class=\"text-center\" colspan=\"2\" style=\"text-align: right;padding: 25px;font-size: 13px;font-weight: lighter;\">NO DATA AVAILABLE</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}