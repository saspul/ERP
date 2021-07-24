using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit;
using System.Data;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
public partial class HCM_HCM_Master_Employee_Performance_Mangmnt_Performance_Evaluation_Analysis_Performance_Evaluation_Analysis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //lisum.Focus();
            ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
            ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();


            clsBusiness_Payroll_Report objBusinssPayroll = new clsBusiness_Payroll_Report();
            clsEntityPayrollProcess objEntityPayroll = new clsEntityPayrollProcess();
          

            HiddenFieldView.Value = "";
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UsrId = intUserId;
                objEntityPayroll.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.CorpId = intCorpId;
                objEntityPayroll.CorpId = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityPayroll.OrganizatonId = intOrgId;
                objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();



            if (Request.QueryString["Uid"] != null)
            {
                string strRandomMixedId = Request.QueryString["Uid"].ToString();
                string strEmpLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofEmpId = Convert.ToInt16(strEmpLenghtofId);
                string strEmpId = strRandomMixedId.Substring(2, intLenghtofEmpId);

                HiddenEmpId.Value = strEmpId;
            }



            string strId = "";
            if (Request.QueryString["IssueId"] != null)
            {

                //  lblEntry.Text = "Edit Perfomance From Template";
                string strRandomMixedId = Request.QueryString["IssueId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                 strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenIssueId.Value = strId;

            }
            if (strId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                objEntity.IssueId = Convert.ToInt32(strId);
                // objEntity.PerfomanceId = Convert.ToInt32(HiddenIssueId.Value);
                objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
                DataTable dtEmpDtls = objEmpPerfomance.ReadPerEmployeeDtls(objEntity);
                DataTable dt = objEmpPerfomance.ReadEmployeEvaluationSummary(objEntity);
                DataTable dtGoal = objEmpPerfomance.ReadGoals(objEntity);
                lblPrfmncNam.Text = dt.Rows[0]["ISSUE_PRFM"].ToString();
                lblEmpId.Text = dtEmpDtls.Rows[0]["USR_CODE"].ToString();
                lblEmpName.Text = dtEmpDtls.Rows[0]["EMPLOYEE_NAME"].ToString();
                lblDesg.Text = dtEmpDtls.Rows[0]["DSGN_NAME"].ToString();
                lblDept.Text = dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString();
                lblJob.Text = dtEmpDtls.Rows[0]["PROJECT_NAME"].ToString();
                lblJoinDate.Text = dtEmpDtls.Rows[0]["EMP_JOINED_DATE"].ToString();
                lblNote.Text = dt.Rows[0]["PRFMNC_TMPLT_NOTE"].ToString();
                lblRef.Text = dt.Rows[0]["ISSUE_ID"].ToString() + "-" + dt.Rows[0]["ISSUE_REVNO"].ToString();

                // DataTable dtlist = objEmpPerfomance.ReadEmployeEvaluationSummary(objEntity);
                LoadSummaryDetls(dt, dtGoal);
                DataTable dtCorp = objBusinssPayroll.ReadCorporateAddress(objEntityPayroll);
                ConvertDataTableForPrint(dt, dtEmpDtls, dtCorp);
            }

        }
        txtGoal.Enabled = false;
    }

    public void ConvertDataTableForPrint(DataTable dt, DataTable dtEmpDtls, DataTable dtCorp)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = " PERFORMANCE EVALUATION ANALYSIS";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        dat = "";
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\" >" + strTitle + "</td></tr>";





        string strPerformance = "";
        if (dt.Rows[0]["PRFMNC_TMPLT_FORM"].ToString() == "")
        {
            strPerformance = "";
        }
        else
        {
            strPerformance = "<tr>Performance Form &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt.Rows[0]["PRFMNC_TMPLT_FORM"].ToString() + "<br/></tr>";
        }

        string strEmpId = "";
        if (dtEmpDtls.Rows[0]["USR_CODE"].ToString() == "")
        {
            strEmpId = "";
        }
        else
        {
            strEmpId = "<tr>Employee Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["USR_CODE"].ToString() + "<br/></tr>";

        }
        string strEmpname = "";

        if (dtEmpDtls.Rows[0]["EMPLOYEE_NAME"].ToString() == "")
        {
            strEmpname = "";
        }
        else
        {
            strEmpname = "<tr>Employee Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["EMPLOYEE_NAME"].ToString() + "<br/></tr>";
        }
        string strDesgName = "";
        if (dtEmpDtls.Rows[0]["DSGN_NAME"].ToString() == "")
        {
            strDesgName = "";
        }
        else
        {
            strDesgName = "<tr>Designation &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["DSGN_NAME"].ToString() + "<br/></tr>";
        }
        string strDep = "";
        if (dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString() == "")
        {
            strDep = "";
        }
        else
        {
            strDep = "<tr>Department &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString() + "<br/></tr>";
        }
        string strProject = "";
        if (dtEmpDtls.Rows[0]["PROJECT_NAME"].ToString() == "")
        {
            strProject = "";
        }
        else
        {
            strProject = "<tr>Job &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["PROJECT_NAME"].ToString() + "<br/></tr>";
        }

        string strDateJoing = "";
        if (dtEmpDtls.Rows[0]["EMP_JOINED_DATE"].ToString() == "")
        {
            strDateJoing = "";
        }
        else
        {
            strDateJoing = "<tr>Date Of Joining &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtEmpDtls.Rows[0]["EMP_JOINED_DATE"].ToString() + "<br/></tr>";
        }


        string strNotes = "";
        if (dt.Rows[0]["PRFMNC_TMPLT_NOTE"].ToString() == "")
        {
            strNotes = "";
        }
        else
        {
            strNotes = "<tr>Notes/Instruction &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt.Rows[0]["PRFMNC_TMPLT_NOTE"].ToString() + "<br/></tr>";
        }

        string strRef = "";
        if (dt.Rows[0]["ISSUE_ID"].ToString() == "")
        {
            strRef = "";
        }
        else
        {
            strRef = "<tr>Reference No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt.Rows[0]["ISSUE_ID"].ToString() + "<br/></tr>";
        }




        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop + strPerformance + strEmpId + strEmpname + strDesgName + strDep + strProject + strDateJoing + strNotes + strRef;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
        // StringBuilder sb = new StringBuilder();

    }
    public void LoadSummaryDetls(DataTable dtlist, DataTable dtGoal)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbGrp = new StringBuilder();
        StringBuilder sbPrint = new StringBuilder();
        string Groupid = "";
        // for Graph
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("PIEDGRM_ID", typeof(string));
        dtDetail.Columns.Add("NUMYES", typeof(int));
        dtDetail.Columns.Add("NUMNO", typeof(int));



        divGoal.Attributes["style"] = "display:none;";

       // divPrintReport.Attributes["style"] = "display:block;";
        if (dtlist.Rows.Count > 0)
        {




            //  sb.Append(" <hr /></div>");




            int flagGrp = 0, flagGrpIn = 0;
            for (int row1 = 0; row1 < dtlist.Rows.Count; row1++)
            {

                string strGrpId = dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                DataTable Copy = new DataTable();
                Copy = dtlist.Copy();

                if (!(Groupid.Contains(dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString())))
                {
                    flagGrp++;
                    if (flagGrp == 4)
                    {

                        flagGrpIn++;
                        sb.Append("<div class=\"col-md-12\" style=\"padding:0px;margin-top:14px;\">");
                        sb.Append("<a href=\"#\" onclick=\"return toggler('myContent" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "');\"><button  onclick=\"return false\" class=\"btn btn-primary  btn-grey  btn-width\"   style=\"border-radius:0px;\"> <i class=\"fa fa-eye\" style=\"margin-right:10px;\"></i>View Groups </button></a>");

                        sb.Append("<div id=\"myContent" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" class=\"hiddenn\"><div>");



                    }


                    for (int i = Copy.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = Copy.Rows[i];
                        string a = dr["PRFMNC_GRP_ID"].ToString();
                        if (a != strGrpId)
                            Copy.Rows.Remove(dr);
                        // dr.Table.Rows.Remove(dr);

                    }



                    string QstnId = "";

                    //string chkVal = dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                    if (!(Groupid.Contains(dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString())))
                    {
                        sb.Append(" <div class=\"sec_one\"  style=\"border: black;border: 1px solid black;padding: 1px;\"> <div class=\"col-lg-12\" style=\"padding:1px;\">");
                        sb.Append("<i class=\"fa fa-object-group\" aria-hidden=\"true\"></i> GROUP :" + dtlist.Rows[row1]["PRFMNC_GRP_NAME"].ToString() + "</div>");

                        sbPrint.Append(" <div class=\"sec_one\"  style=\"border: black;border: 1px solid black;padding: 1px;\"> <div class=\"col-lg-12\" style=\"padding:1px;\">");
                        sbPrint.Append("<i class=\"fa fa-object-group\" aria-hidden=\"true\"></i> GROUP :" + dtlist.Rows[row1]["PRFMNC_GRP_NAME"].ToString() + "</div>");




                        Groupid = Groupid + "," + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString();

                        int flagQtn = 0, flagQtnIn = 0;
                        for (int rowin = 0; rowin < Copy.Rows.Count; rowin++)
                        {

                            DataTable CopyQst = new DataTable();
                            CopyQst = Copy.Copy();

                            string strQstId = Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString();

                            if (!(QstnId.Contains(Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString())))
                            {
                                flagQtn++;
                                if (flagQtn == 5)
                                {

                                    flagQtnIn++;
                                    sb.Append("<div class=\"col-md-12\" style=\"padding:0px;margin-top:14px;\">");
                                    sb.Append("<a href=\"#\" onclick=\"return toggler('myContent" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "');\"><button  onclick=\"return false\" class=\"btn btn-primary  btn-grey  btn-width\"   style=\"border-radius:0px;\"> <i class=\"fa fa-eye\" style=\"margin-right:10px;\"></i>View all Questions </button></a>");

                                    sb.Append("<div id=\"myContent" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\" class=\"hiddenn\"><div>");




                                }
                                for (int i = CopyQst.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow dr = CopyQst.Rows[i];
                                    string a = dr["PRFMNC_QSTN_ID"].ToString();
                                    if (a != strQstId)
                                        CopyQst.Rows.Remove(dr);
                                    // dr.Table.Rows.Remove(dr);

                                }

                                if (!(QstnId.Contains(Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString())))
                                {
                                    QstnId = QstnId + "," + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString();
                                }

                                if (CopyQst.Rows.Count > 0)
                                {
                                    sb.Append("<div style=\"clear:both\"></div>");
                                    sb.Append("<hr> <div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;border:1px solid #868686;padding:10px;\">");
                                    sb.Append("<div class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\"></i> QUESTION :" + CopyQst.Rows[0]["PRFMNC_QSTN"].ToString() + "</div>");
                                    sb.Append("<div class=\"form-row\">");
                                    sb.Append("<div class=\"form-group col-md-8 padding5\" style=\"margin-top: 1%;\">");
                                    //   sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[0]["PRFMNC_QSTN"].ToString() + "</label>");


                                    sbPrint.Append("<div style=\"clear:both\"></div>");
                                    sbPrint.Append(" <br><div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;border:1px solid #868686;padding:10px;\">");
                                    sbPrint.Append("<div class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\"></i> QUESTION :" + CopyQst.Rows[0]["PRFMNC_QSTN"].ToString() + "</div>");
                                    sbPrint.Append("<div class=\"form-row\">");
                                    sbPrint.Append("<div class=\"form-group col-md-8 padding5\" >");



                                    if (CopyQst.Rows[0]["PRMNC_ANS_TYPE"].ToString() == "0")
                                    {
                                           //sb.Append("<table border=0>");
                                           //sbPrint.Append("<table border=0>");
                                        for (int rowQstin = 0; rowQstin < CopyQst.Rows.Count; rowQstin++)
                                        {

                                            string strEvaluator = "";
                                            string strEvName = CopyQst.Rows[rowQstin]["USR_NAME"].ToString();
                                            if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "0")
                                            {
                                               // strEvaluator = "Self";

                                             sb.Append(" <ul style=\"list-style-type:square\">");
                                             sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Self (" + strEvName + ")</label></li>");
                                             sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Self (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                               // sb.Append("<p class=\"bold_text\">Self (" + strEvName + ")&emsp;&emsp; &emsp;&emsp; &emsp;&emsp;&emsp;&ensp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                               // sbPrint.Append("<p class=\"bold_text\">Self (" + strEvName + ")&emsp;&emsp; &emsp;&emsp; &emsp;&emsp;&emsp;&ensp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                            }
                                            else if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "1")
                                            {
                                                //strEvaluator = "Reporting Officer";
                                               // sb.Append("<p class=\"bold_text\">Reporting Officer (" + strEvName + ")&emsp;&ensp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                               // sbPrint.Append("<p class=\"bold_text\">Reporting Officer (" + strEvName + ")&emsp;&ensp;&nbsp;&nbsp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");

                                                sb.Append(" <ul style=\"list-style-type:square\">");
                                                sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Reporting Officer (" + strEvName + ")</label></li>");
                                                sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Reporting Officer (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                            }
                                            else if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "2")
                                            {
                                                //strEvaluator = "Division Manager";
                                                //sb.Append("<p class=\"bold_text\">Division Manager  (" + strEvName + ")&emsp;&ensp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                               // sbPrint.Append("<p class=\"bold_text\">Division Manager  (" + strEvName + ")&emsp;&ensp;&nbsp;&nbsp;&nbsp;&nbsp;:" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");

                                                sb.Append(" <ul style=\"list-style-type:square\">");
                                                sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Division Manager (" + strEvName + ")</label></li>");
                                                sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Division Manager (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                            }
                                            else if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "3")
                                            {
                                                //strEvaluator = "General Manager";
                                               // sb.Append("<p class=\"bold_text\">General Manager  (" + strEvName + ")&emsp;&ensp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                               // sbPrint.Append("<p class=\"bold_text\">General Manager (" + strEvName + ") &emsp;&ensp;&nbsp;&nbsp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");

                                                sb.Append(" <ul style=\"list-style-type:square\">");
                                                sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">General Manager (" + strEvName + ")</label></li>");
                                                sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">General Manager (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                            }
                                            else if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "4")
                                            {
                                               // strEvaluator = "HR";
                                               // sb.Append("<p class=\"bold_text\">HR  (" + strEvName + ")&emsp;&emsp; &emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                               // sbPrint.Append("<p class=\"bold_text\">HR  (" + strEvName + ")&emsp;&emsp; &emsp;&emsp; &emsp;&emsp;&emsp;&emsp;&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");

                                                sb.Append(" <ul style=\"list-style-type:square\">");
                                                sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">HR (" + strEvName + ")</label></li>");
                                                sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">HR (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                            }
                                            else if (CopyQst.Rows[rowQstin]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "5")
                                            {
                                                //strEvaluator = "Additional Employee";
                                                //sb.Append("<p class=\"bold_text\">Additional Employee(" + strEvName + ")&nbsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");
                                              //  sbPrint.Append("<p class=\"bold_text\">AdditionalEmployee (" + strEvName + ")&nbsp;&emsp;: " + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</p>");

                                                sb.Append(" <ul style=\"list-style-type:square\">");
                                                sb.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Additional Employee (" + strEvName + ")</label></li>");
                                                sb.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sb.Append("</ul>");
                                                sbPrint.Append(" <ul style=\"list-style-type:square\">");
                                                sbPrint.Append("<li><label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Additional Employee (" + strEvName + ")</label></li>");
                                                sbPrint.Append("<label for=\"inputCity\" style=\"margin-bottom:8px;\">" + CopyQst.Rows[rowQstin]["PRMNC_EVL_TEXT"].ToString() + "</label>");
                                                sbPrint.Append("</ul>");
                                            }


                                          

                                        }

                                    }
                                    else if (CopyQst.Rows[0]["PRMNC_ANS_TYPE"].ToString() == "1")
                                    {
                                        decimal Intrate = 0;
                                        for (int rowQstin = 0; rowQstin < CopyQst.Rows.Count; rowQstin++)
                                        {

                                            Intrate = Intrate + Convert.ToInt32(CopyQst.Rows[rowQstin]["PRMNC_EVL_RATE"].ToString());

                                        }
                                        if (CopyQst.Rows.Count>0)
                                        {
                                            int intcount=CopyQst.Rows.Count;
                                            Intrate = Intrate / intcount;
                                        }
                                        String strRating = CopyQst.Rows[0]["TMPLT_BKUP_RATING"].ToString();
                                        
                                        sb.Append("<p class=\"bold_text\">" + Intrate + " out of "+strRating+"</p>");
                                        sbPrint.Append("<p class=\"bold_text\">" + Intrate + "</p>");

                                    }
                                    else if (CopyQst.Rows[0]["PRMNC_ANS_TYPE"].ToString() == "2")
                                    {
                                        int Gyes = 0, Gno = 0;
                                        for (int rowQstin = 0; rowQstin < CopyQst.Rows.Count; rowQstin++)
                                        {
                                            if (Convert.ToInt32(CopyQst.Rows[rowQstin]["PRMNC_EVL_CHK"].ToString()) == 1)
                                            {
                                                Gyes++;
                                            }
                                            else if (Convert.ToInt32(CopyQst.Rows[rowQstin]["PRMNC_EVL_CHK"].ToString()) == 0)
                                            {
                                                Gno++;
                                            }


                                        }
                                        DataRow drDtl = dtDetail.NewRow();
                                        drDtl["PIEDGRM_ID"] = dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString();

                                        drDtl["NUMYES"] = Gyes;
                                        drDtl["NUMNO"] = Gno;

                                        dtDetail.Rows.Add(drDtl);

                                        sb.Append("<div style=\"clear:both\"></div> <hr>");
                                        sb.Append("<div class=\"col-md-6\" id=\"Div2" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"height:auto;border:1px solid #868686;padding:10px;width:68%\">");
                                        //  sb.Append("<div class=\"col-lg-12\" style=\"padding:0px;\"><b> <i class=\"fa fa-comments-o\" aria-hidden=\"true\"></i>  Do you recommend the renewal of employee's contract</b> </div>");
                                        sb.Append("<div class=\"form-row\"> <div class=\"form-group col-md-12 padding5\">");

                                        sb.Append("<div id=\"chart_wrap" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\">");

                                        sb.Append("<div id=\"piechart" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:400px; height:300px;\"></div>");
                                        sb.Append("</div> </div> </div> </div>");



                                        sbPrint.Append("<div style=\"clear:both\"></div><br>");
                                        sbPrint.Append("<div class=\"col-md-6\" id=\"Div3" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"height:auto;border:1px solid #868686;padding:10px;width:36%\">");
                                        //  sb.Append("<div class=\"col-lg-12\" style=\"padding:0px;\"><b> <i class=\"fa fa-comments-o\" aria-hidden=\"true\"></i>  Do you recommend the renewal of employee's contract</b> </div>");
                                        sbPrint.Append("<div class=\"form-row\"> <div class=\"form-group col-md-12 padding5\">");

                                        sbPrint.Append("<div id=\"chart_wrapprint" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\">");

                                        sbPrint.Append("<div id=\"piechartPrint" + dtlist.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "" + Copy.Rows[rowin]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:400px; height:300px;\"></div>");
                                        sbPrint.Append("</div> </div> </div> </div>");


                                    }




                                    sb.Append("</div></div></div>");
                                    sbPrint.Append("</div></div></div>");


                                }


                            }




                        }
                        if (flagQtnIn != 0)
                        {
                            sb.Append("</div></div></div>");
                        }
                        sb.Append("<div style=\"clear:both\"></div> </div><hr>");
                        sbPrint.Append("<div style=\"clear:both\"></div> </div><br>");


                    }
          



                }



            }
            if (flagGrpIn != 0)
            {
                sb.Append("</div></div></div>");
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            HiddenFieldView.Value = strJson;
            string s = sb.ToString();
            Summaries.InnerHtml = sb.ToString();
            divPrintReport.InnerHtml = sbPrint.ToString();
            StringBuilder sbGoal = new StringBuilder();
            StringBuilder sbGoalprint = new StringBuilder();
            if (dtGoal.Rows.Count > 0)      //emp0025
            {
                boxhide.Attributes["style"] = "display:block;";
                boxhide.Attributes["style"] = "width:100%;";

                string strhhtml = "";
                string strthtml = "";
                int flagAd = 0;
                int flagDm = 0;
                int flagHr = 0;
                int flagGm = 0;
                var max = dtGoal.AsEnumerable()
               .Where(row => row["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "5");
                var maxDm = dtGoal.AsEnumerable()
               .Where(row => row["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "2");
                var maxHr = dtGoal.AsEnumerable()
               .Where(row => row["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "4");
                var maxGm = dtGoal.AsEnumerable()
              .Where(row => row["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "3");
                for (int glCount = 0; glCount < dtGoal.Rows.Count; glCount++)
                {

                    if (dtGoal.Rows[glCount]["PRMNC_EVLTR_GOL"].ToString() != "")
                    {
                        strhhtml = " <ul style=\"list-style-type:square\">";
                        if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "0")
                        {


                            strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Self</label>";
                            strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + dtGoal.Rows[glCount]["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + dtGoal.Rows[glCount]["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                            //strhhtml += "</ul>";
                        }
                        else if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "1")
                        {

                            // strhhtml = " <ul style=\"list-style-type:square\">";
                            strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Reporting Officer</label>";
                            strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + dtGoal.Rows[glCount]["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + dtGoal.Rows[glCount]["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                            // strhhtml += "</ul>";
                        }
                        else if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "2")
                        {

                            if (flagDm == 0)
                            {
                                flagDm = 1;

                                strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Division Manager</label>";

                                foreach (DataRow row in maxDm)
                                {
                                    strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + row["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + row["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                                }


                            }

                        }
                        else if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "3")
                        {
                            if (flagGm == 0)
                            {
                                flagGm = 1;

                                strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">General Manager</label>";

                                foreach (DataRow row in maxGm)
                                {
                                    strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + row["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + row["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                                }


                            }

                        }
                        else if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "4")
                        {
                            if (flagHr == 0)
                            {
                                flagHr = 1;

                                strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">HR</label>";

                                foreach (DataRow row in maxHr)
                                {
                                    strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + row["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + row["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                                }


                            }


                        }
                        else if (dtGoal.Rows[glCount]["PRMNC_EVLTR_RSPNS_TYP"].ToString() == "5")
                        {

                            if (flagAd == 0)
                            {
                                flagAd = 1;

                                strhhtml += "<label for=\"inputCity\" style=\"margin-bottom:8px;font-weight:600\">Additional Employee</label>";

                                foreach (DataRow row in max)
                                {
                                    strhhtml += "<li><label for=\"inputCity\" style=\"margin-bottom:8px;\">" + row["USR_NAME"].ToString() + " &nbsp;&nbsp; : &nbsp;&nbsp;  " + row["PRMNC_EVLTR_GOL"].ToString() + "</label></li>";
                                }


                            }

                        }


                        strhhtml += "</ul>";

                    }
                    else
                    {
                        boxhide.Attributes["style"] = "display:none;";
                    }
                    sbGoal.Append(strhhtml);
                }

                SummeryGoal.InnerHtml = sbGoal.ToString();
                if (SummeryGoal.InnerHtml != "")
                {



                    strthtml = " <div class=\"col-lg-12\" style=\"padding:0px;\"><b> <i class=\"fa fa-dot-circle-o\" aria-hidden=\"true\"></i> Goals</b> </div>";

                    strthtml += " <div class=\"form-row\">";
                    strthtml += "<div class=\"form-group col-md-12 padding5\" >";
                    strthtml += " <div class=\"col-md-12\" id=\"Div1\" style=\"height:auto;border:1px solid #868686;padding:10px;\">";
                    //  strthtml+= " <div class=\"col-lg-12\" style=\"padding:0px;\"><b> <i class=\"fa fa-comments-o\" aria-hidden=\"true\"></i> Evaluator comments</b> </div>";
                    strthtml += " <div class=\"form-row\">";
                    strthtml += " <div id=\"SummeryGoal\" runat=\"server\"  class=\"form-group col-md-12 padding5\">";

                    strthtml += SummeryGoal.InnerHtml;


                    strthtml += "  </div>";
                    strthtml += "  </div>";
                    strthtml += "  </div>";
                    strthtml += "  </div>";
                    strthtml += "  </div>";

                }
                sbGoalprint.Append(strthtml);
            }
            divPrintReport.InnerHtml = sbPrint.ToString() + sbGoalprint.ToString();
           // HiddenInnertml.Value = sbPrint.ToString() + sbGoalprint.ToString();
        }
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

      protected void btnSelf_Click(object sender, EventArgs e)
    {
        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
       
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        divEmpLoad.Attributes["style"] = "display:none;";
        boxhide.Attributes["style"] = "display:none;";
        int type = 0;
        objEntity.RspnTypeId = 0;
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);

       
        string strHtm = ConvertDataTableToHTML(dtEvltn, dtGrpQstn);

        Summaries.InnerHtml = strHtm;

       

    }

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtGrp)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int count = dt.Rows.Count;

        StringBuilder sb = new StringBuilder();
        StringBuilder sbGoal = new StringBuilder();
        StringBuilder sbGoalprint = new StringBuilder();

        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();

         string strthtml="";
        if (dt.Rows.Count > 0)
        {

            string GLsTS=dt.Rows[0]["PRMNC_EVLTR_GOL"].ToString() ;

            if (GLsTS != "")
            {
                divGoal.Attributes["style"] = "display:block;";
                txtGoal.Text = dt.Rows[0]["PRMNC_EVLTR_GOL"].ToString();
               // sbGoal.Append(dtxtGoal.Text);
            }
            else
            {
                divGoal.Attributes["style"] = "display:none;";

            }
            string QstnId = "";
            for (int qstnCount = 0; qstnCount < dt.Rows.Count; qstnCount++)
            {
                if (QstnId == "")
                {
                    QstnId = dt.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }
                else
                {
                    QstnId = QstnId + "," + dt.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }
                

            }





            for (int intRowBodyCount = 0; intRowBodyCount < dtGrp.Rows.Count; intRowBodyCount++)
            {
                if (dt.Rows.Count > 0)
                {
                    objEntity.QstnSts = 1;

                }
                else
                {
                    objEntity.QstnSts = 0;
                }

                objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);  //EMP0025
                objEntity.QustnId = QstnId;
                objEntity.GrpId = Convert.ToInt32(dtGrp.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                hiddenGrpId.Value = dtGrp.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString();
                DataTable dtReadQstn = objEmpPerfomance.ReadQstnById(objEntity);
                HiddenQstnCount.Value = dtReadQstn.Rows.Count.ToString();

                string strHtml;
               
                strHtml = "<table id=\"ReportTable_" + intRowBodyCount + "\" >";
                if (dtReadQstn.Rows.Count > 0)
                {
                    strHtml += "</br>";
                    // strHtml += "<tr id=\""+dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString()+"\">";
                    strHtml += "<div id=\"Tableborder\" style=\"padding:1px;border: 1px solid;margin-top: 15px; \">";
                    strHtml += " <div id=\"TableGrp\" class=\"col-lg-12\" style=\"padding:1px;\"><div class=\"btn btn-hide\" onclick=\"myFunction()\" data-toggle=\"modal\" data-target=\".bs-example-modal-sm\" style=\"float:right;\"></div><i class=\"fa fa-object-group\" aria-hidden=\"true\" style=\"font-size: 15px;\">Group: " + "  " + dtGrp.Rows[intRowBodyCount]["PRFMNC_GRP_NAME"].ToString() + "</i></div>";
                    strHtml += "<div style=\"clear:both\"></div>";
                    //grp name


                    for (int intCount = 0; intCount < dtReadQstn.Rows.Count; intCount++)
                    {
                        string text = "";
                        string rate = "";
                        string CHK = "";
                        for (int intRowDtl = 0; intRowDtl < dt.Rows.Count; intRowDtl++)
                        {

                            if (dt.Rows[intRowDtl]["PRFMNC_QSTN_ID"].ToString() == dtReadQstn.Rows[intCount]["PRFMNC_QSTN_ID"].ToString())
                            {
                                int ansTyp = Convert.ToInt32(dt.Rows[intRowDtl]["PRMNC_ANS_TYPE"]);
                                if (ansTyp == 0)
                                {
                                    text = dt.Rows[intRowDtl]["PRMNC_EVL_TEXT"].ToString();
                                }
                                if (ansTyp == 1)
                                {
                                    rate = dt.Rows[intRowDtl]["PRMNC_EVL_RATE"].ToString();


                                }
                                if (ansTyp == 2)
                                {
                                    CHK = dt.Rows[intRowDtl]["PRMNC_EVL_CHK"].ToString();


                                }

                            }

                        }


                        int flag = 0;

                        int ResponseType = Convert.ToInt32(dtReadQstn.Rows[intCount]["PRFMNC_ANSWR_TYPE"].ToString());
                        if (ResponseType == 0)
                        {
                            flag = 2;
                        }
                        else if (ResponseType == 1)
                        {
                            flag = 1;
                        }
                        else if (ResponseType == 2)
                        {
                            flag = 3;
                        }


                        strHtml += "<hr >";



                        if (flag == 1)
                        {


                            strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                            strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding: 0px; font-size: 15px; font-family: calibri;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\"></i>Question" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\" style=\"margin-top: 1%;\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label> <label  style=\"margin-bottom:8px;\" ></label>";
                            strHtml += "<select onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:12%;\" onkeydown=\"return isEnter(event);\" disabled=\"true\"><option selected=\"selected\" value=\"" + rate + "\">" + rate + "</option></select>";
                            //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                            strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + rate + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                            strHtml += " </div> </div> </div></div>";


                            //<div style="clear:both"></div>
                        }
                        if (flag == 2)
                        {

                            strHtml += "<div class=\"col-md-12\" style=\"height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;\">";
                            strHtml += "<div id=\"TableQstn_\"   class=\"col-lg-12\" style=\"padding: 0px; font-size: 15px; font-family: calibri;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\"></i>Question" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label  style=\"margin-bottom:8px;\" ></label><textarea class=\"form-control\" name=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" id=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" text=\"" + text + "\" value=\"" + text + "\" rows=\"3\" style=\"resize:none\" disabled=\"true\">" + text + "</textarea> </div></div>";
                            strHtml += "</div>";


                        }

                        if (flag == 3)
                        {
                            if (CHK == "")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding: 0px; font-size: 15px; font-family: calibri;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\"></i>Question" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 20%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" ><span class=\"checkmark\"></span></label> <label style=\"float: right; margin-right: 35%;\" class=\"ch\">No<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                            else if (CHK == "1")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding: 0px; font-size: 15px; font-family: calibri;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\"></i> Question" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 20%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" checked=\"true\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"   id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span></label><label style=\"float: right; margin-right: 35%;\" class=\"ch\">No<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"1\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                            else if (CHK == "0")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding: 0px; font-size: 15px; font-family: calibri;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\"></i>Question" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 20%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" ><span class=\"checkmark\"></span></label><label style=\"float: right; margin-right: 35%;\" class=\"ch\">No<input type=\"checkbox\" checked=\"true\"  disabled=\"true\"  name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" ><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                        }



                        strHtml += "<div style=\"clear:both\"></div><hr />";

                    }



                    strHtml += "</div>";
                }

                strHtml += "</table>";


                sb.Append(strHtml);
            }
            if (GLsTS != "")
            {
                divGoal.Attributes["style"] = "display:block;";
                txtGoal.Text = dt.Rows[0]["PRMNC_EVLTR_GOL"].ToString();

                strthtml = "<div class=\"form-group col-md-7 padding5\" style=\" margin-top: 10px;background-color: rgb(234, 234, 234);padding-top: 1.5%; padding-bottom: 1.5%;\">";

    strthtml+= " <label for=\"inputCity\" style=\"margin-left: 6px;\">Goal : </label>";
    strthtml+= " <label for=\"inputCity\" style=\"margin-left: 6px;\">"+ dt.Rows[0]["PRMNC_EVLTR_GOL"].ToString()+"</label>";

    strthtml += " </div>";
                sbGoalprint.Append(strthtml);
                // sbGoal.Append(dtxtGoal.Text);
            }
        }
        else
        {
            divGoal.Attributes["style"] = "display:none;";
            string strHtml;
            strHtml = "<table id=\"ReportTable_\" >";
            strHtml += "<div id=\"Tableborder\" style=\"padding:1px;\">";


            strHtml += "<tr class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

            strHtml += "</tr>";
            strHtml += "</div>";
      
            strHtml += "</table>";
            sb.Append(strHtml);
        }
      


        divPrintReport.InnerHtml = sb.ToString() + sbGoalprint.ToString();
        return sb.ToString();
    }

    protected void btnReptngOfficer_Click(object sender, EventArgs e)
    {
        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
       
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int type = 1;
        divEmpLoad.Attributes["style"] = "display:none;";
        boxhide.Attributes["style"] = "display:none;";
        objEntity.RspnTypeId = 1;
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);

   
        string strHtm = ConvertDataTableToHTML(dtEvltn, dtGrpQstn);

        Summaries.InnerHtml = strHtm;
       
            //divGoal.Attributes["style"] = "display:none;";
        

  
    }
    protected void btnDm_Click(object sender, EventArgs e)
    {
        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
     
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int type = 2;
        divEmpLoad.Attributes["style"] = "display:none;";
        boxhide.Attributes["style"] = "display:none;";
        objEntity.RspnTypeId = 2;
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);



        if (dtEvltn.Rows.Count > 0)
        {

            HiddenType.Value = "2";
            objEntity.EmpTypId = Convert.ToInt32(dtEvltn.Rows[0]["ISSUE_EVAL"].ToString());


            divEmpLoad.Attributes["style"] = "display:block;width:43%;";

            DataTable dtEmp = objEmpPerfomance.readEvaluator(objEntity);

            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();



            }


            divGoal.Attributes["style"] = "display:none;";

            ddlEmployee.Items.Insert(0, "--SELECT NAME--");
            ddlEmployee.Focus();
            string strHtm = "";
            Summaries.InnerHtml = strHtm;
        }

        else
        {
            string strHtm = "No Data Available";
            Summaries.InnerHtml = strHtm;

            divGoal.Attributes["style"] = "display:none;";


        }



    }
    protected void btnGm_Click(object sender, EventArgs e)
    {

        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
       
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int type = 3;
        objEntity.RspnTypeId = 3;
        divEmpLoad.Attributes["style"] = "display:none;";
        boxhide.Attributes["style"] = "display:none;";
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);

        if (dtEvltn.Rows.Count > 0)
        {

            HiddenType.Value = "3";
            objEntity.EmpTypId = Convert.ToInt32(dtEvltn.Rows[0]["ISSUE_EVAL"].ToString());


            divEmpLoad.Attributes["style"] = "display:block;width:43%;";

           
            DataTable dtEmp = objEmpPerfomance.readEvaluator(objEntity);

            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();



            }


            divGoal.Attributes["style"] = "display:none;";

            ddlEmployee.Items.Insert(0, "--SELECT NAME--");
            ddlEmployee.Focus();
            string strHtm = "";
            Summaries.InnerHtml = strHtm;
        }

        else
        {
            string strHtm = "No Data Available";
            Summaries.InnerHtml = strHtm;

            divGoal.Attributes["style"] = "display:none;";


        }
     

    }
    protected void btnHr_Click(object sender, EventArgs e)
    {

        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
    
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        divEmpLoad.Attributes["style"] = "display:none;";
        boxhide.Attributes["style"] = "display:none;";
        int type = 4;
        objEntity.RspnTypeId = 4;
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);


        if (dtEvltn.Rows.Count > 0)
        {

            HiddenType.Value = "4";
            objEntity.EmpTypId = Convert.ToInt32(dtEvltn.Rows[0]["ISSUE_EVAL"].ToString());


            divEmpLoad.Attributes["style"] = "display:block;width:43%;";

           
            DataTable dtEmp = objEmpPerfomance.readEvaluator(objEntity);

            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();



            }


            divGoal.Attributes["style"] = "display:none;";

            ddlEmployee.Items.Insert(0, "--SELECT NAME--");
            ddlEmployee.Focus();
            string strHtm = "";
            Summaries.InnerHtml = strHtm;
        }

        else
        {
            string strHtm = "No Data Available";
            Summaries.InnerHtml = strHtm;

            divGoal.Attributes["style"] = "display:none;";


        }
    }
    protected void btnAditnlEmp_Click(object sender, EventArgs e)   
    {

        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();
       
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int type = 5;
        objEntity.RspnTypeId = 5;
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);

      
        boxhide.Attributes["style"] = "display:none;";
        divEmpLoad.Attributes["style"] = "display:none;width:43%;";
          
        if (dtEvltn.Rows.Count > 0)
        {


            objEntity.EmpTypId = Convert.ToInt32(dtEvltn.Rows[0]["ISSUE_EVAL"].ToString());


            divEmpLoad.Attributes["style"] = "display:block;width:43%;";
          
           
            DataTable dtEmp = objEmpPerfomance.LoadEmployee(objEntity);
            HiddenType.Value = "5";
            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();



            }


            divGoal.Attributes["style"] = "display:none;";

            ddlEmployee.Items.Insert(0, "--SELECT NAME--");
           ddlEmployee.Focus();
            string strHtm = "";
            Summaries.InnerHtml = strHtm;
        }

        else
        {
            string strHtm = "No Data Available";
            Summaries.InnerHtml = strHtm;

            divGoal.Attributes["style"] = "display:none;";
            

        }
       

    }

    protected void btnSummaries_Click(object sender, EventArgs e)
    {
        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        divEmpLoad.Attributes["style"] = "display:none;";

        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        // objEntity.PerfomanceId = Convert.ToInt32(HiddenIssueId.Value);
        objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
        DataTable dt = objEmpPerfomance.ReadEmployeEvaluationSummary(objEntity);
        DataTable dtGoal = objEmpPerfomance.ReadGoals(objEntity);
        LoadSummaryDetls(dt, dtGoal);
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)  //emp0025
    {
        ClsBusiness_Performance_Evaluation_Analysis objEmpPerfomance = new ClsBusiness_Performance_Evaluation_Analysis();
        ClsEntity_Performance_Evaluation_Analysis objEntity = new ClsEntity_Performance_Evaluation_Analysis();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT NAME--")
        {
            objEntity.EmpUsrId = Convert.ToInt32(HiddenEmpId.Value);
            objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
            objEntity.usrDtlId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            objEntity.RspnTypeId = Convert.ToInt32(HiddenType.Value);
            DataTable dtEvltn = objEmpPerfomance.readEvaluation(objEntity);
            DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);


            string strHtm = ConvertDataTableToHTML(dtEvltn, dtGrpQstn);

            Summaries.InnerHtml = strHtm;
        }
        else
        {
            divGoal.Attributes["style"] = "display:none;";

            string strHtm = "";
            Summaries.InnerHtml = strHtm;
        }
    }
}