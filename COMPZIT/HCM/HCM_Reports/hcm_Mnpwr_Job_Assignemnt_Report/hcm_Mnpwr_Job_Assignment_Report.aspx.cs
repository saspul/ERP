using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.IO;

public partial class HCM_HCM_Reports_hcm_Mnpwr_Job_Assignemnt_Report_hcm_Mnpwr_Job_Assignment_Report : System.Web.UI.Page
{
    clsBusinessManpwrJobAssignemntReport objBusinessRqrmntAlctn = new clsBusinessManpwrJobAssignemntReport();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
        if (!IsPostBack)
        {
            Hiddenstatus.Value = "0";
            hiddenFromDate.Value = "0";
            hiddenTodate.Value = "0";
            hiddenproject.Value = "0";
            hiddenAssignedTo.Value = "0";
            ProjectLoad();
            EmployeeLoad();
            ddlSts.Items.Clear();
            ddlSts.Items.Insert(0, "--SELECT STATUS--");
            ddlSts.Items.Insert(1, "GM APPROVED");
            ddlSts.Items.Insert(2, "REQUIREMENT ALLOCATED");
            ddlSts.Items.Insert(3, "JOB NOTIFIED");
            ddlSts.Items.Insert(4, "CLOSED");
            ddlSts.Items.Insert(5, "INTERVIEW DONE");
             ddlSts.Items.Insert(6, "CANDIDATE SHORTLISTED");
              ddlSts.Items.Insert(7, "REJECTED");
            clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn = new clsEntityManpwrJobAsignment_Report();
            int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId=0;
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

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intOrgId = 0;
            if (Session["ORGID"] != null)
            {
                objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mnpwr_Job_Assignemt_Report);
                      
            //Allocating child roles
           
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        objEntityReqrmntAlctn.HrManager= intEnableHRallocation;
                        HiddenHr.Value = intEnableHRallocation.ToString();
                    }

                }
            }
            if (txtFromDate.Text.Trim() != "")
            {
                objEntityReqrmntAlctn.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            }
            if (txtTodate.Text.Trim() != "")
            {
                objEntityReqrmntAlctn.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
            if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
            {
                objEntityReqrmntAlctn.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }

            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityReqrmntAlctn.Employee_Id = Convert.ToString(ddlEmployee.SelectedItem.Value);
            }



            if (ddlSts.SelectedItem.Value != "--SELECT STATUS--")
            {
                if (ddlSts.SelectedValue == "GM APPROVED")
                {
                    objEntityReqrmntAlctn.SelfAlctnSts = 4;
                }
                else if (ddlSts.SelectedValue == "REQUIREMENT ALLOCATED")
                {
                    //if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                    //{
                    //    status = "REQUIREMENT ALLOCATED";
                    //}
                    objEntityReqrmntAlctn.SelfAlctnSts = 4;
                }
                else if (ddlSts.SelectedValue == "JOB NOTIFIED")
                {
                    objEntityReqrmntAlctn.SelfAlctnSts = 4;
                }
                else if (ddlSts.SelectedValue == "CLOSED")
                {
                    objEntityReqrmntAlctn.SelfAlctnSts = 7;
                }
                else if (ddlSts.SelectedValue == "INTERVIEW DONE")
                {
                    objEntityReqrmntAlctn.SelfAlctnSts = 4;
                }
                else if (ddlSts.SelectedValue == "REJECTED")
                {
                    objEntityReqrmntAlctn.SelfAlctnSts = 4;
                }
            }




            //objEntityReqrmntAlctn.SelfAlctnSts = Convert.ToInt32(ddlSts.SelectedItem.Value);
         

            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessRqrmntAlctn.ReadManpwrJobAssignment(objEntityReqrmntAlctn);

            string strHtm = ConvertDataTableToHTML(dtManpwr);
          divReport.InnerHtml = strHtm;
        }

    }
    public void EmployeeLoad()
    {
        clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn = new clsEntityManpwrJobAsignment_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReqrmntAlctn.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //if (HiddenFieldSelfAllocation.Value == "true")
        //{
        //    objEntityReqrmntAlctn.SelfAlctnSts = 1;
        //}

        DataTable dtSubConrt = objBusinessRqrmntAlctn.ReadEmployeeList(objEntityReqrmntAlctn);
        if (dtSubConrt.Rows.Count > 0)
        {
         //   ddlEmployee.Items.Clear();

            ddlEmployee.DataSource = dtSubConrt;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
          //  ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
            //ddlEmployee.DataSource = dtSubConrt;
           // ddlEmployee.DataTextField = "USR_NAME";
           // ddlEmployee.DataValueField = "USR_ID";
           // ddlEmployee.DataBind();
        }

        

    }
    public void ProjectLoad()
    {
        clsEntityManpwrJobAsignment_Report objEntityJobNotify = new clsEntityManpwrJobAsignment_Report();
      
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtProjct = objBusinessRqrmntAlctn.ReadProject(objEntityJobNotify);
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");


    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        string str = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
    //  clsBusinessManpwrJobAssignemntReport objBusinessRqrmnt = new clsBusinessManpwrJobAssignemntReport();
        clsEntityManpwrJobAsignment_Report objEntityJobAlocation = new clsEntityManpwrJobAsignment_Report();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">APPROVED DATE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">ASSIGNED DATE</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:18%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">STATUS</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">AGING (DAYS)</th>";
            }

        }

      //  strHtml += "<th class=\"thT\" style=\"width:11%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";


        strHtml += "</tr>";


        strHtml += "</thead>";
        strHtml += "<tbody>";





        int count = 1;
       
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string status = "";
            string StsChk = "";

            string sts = dt.Rows[intRowBodyCount]["MNP_PROCESS_STATUS"].ToString();

                if (sts == "0")
                {
                    // status = "NEW";
                }
                if (sts == "1")
                {
                    // status = "REQUEST CREATED";

                }
                else if (sts == "2")
                {
                    // status = "REQUEST APPROVED";

                }
                else if (sts == "3")
                {
                    // status = "HR VERIFIED";
                }

                if (sts == "4")
                {
                    status = "GM APPROVED";

                    if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                    {
                        status = "REQUIREMENT ALLOCATED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                    {
                        status = "JOB NOTIFIED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                    {
                        status = "CANDIDATE SELECTED";
                        //status = "GM APPROVED";
                    }

                    clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                    clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                    //objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                    string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                    if (strshtlst != "0")
                    {
                        status = "CANDIDATE SHORTLISTED";
                        StsChk = "8";
                    }
                    string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                    if (strintrvw != "0")
                    {
                        status = "INTERVIEW DONE";
                        StsChk = "8";
                    }


                    if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                    {
                        status = "REJECTED";
                    }
                }
                if (sts == "6")
                {
                    status = "CANDIDATE SELECTION";
                }
                if (sts == "7")

                    status = "CLOSED";

                HiddenCheckedText.Value = ddlSts.Text;
             if ((ddlSts.Text != "--SELECT STATUS--"))
                {
                   
                    if (ddlSts.Text == status)
                    {
                        strHtml += "<tr  >";
                    }
                }
                else
                {
                    strHtml += "<tr  >";
                }

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

              

                      //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";

                    if ((ddlSts.Text != "--SELECT STATUS--"))
                    {
                        if (ddlSts.Text == status)
                        {

                            if (dt.Rows.Count == 0)
                            {
                                strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                            }
                            else if (dt.Rows.Count > 0)
                            {

                                string strId = dt.Rows[intRowBodyCount][0].ToString();
                                hiddenManpwrId.Value = strId;

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["APPROVE_DATE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";  //emp25
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["RQNTALCT_INS_DATE"].ToString() + "</td>";  //emp25
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 6)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        string aprovedate = dt.Rows[intRowBodyCount]["MNP_APPRVL2_DATE"].ToString();
                        DateTime aprovedate1 = Convert.ToDateTime(aprovedate);
                        DateTime today = DateTime.Now;

                        int aging = Convert.ToInt32((today - aprovedate1).TotalDays);

                        //Double DAYS = Convert.ToDouble(aging);
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + aging + "</td>";
                    }
                        }
                            // strHtml += "</tr>";

                        }    //MoreInfo
                    }
                      else
                    {
                         if (dt.Rows.Count == 0)
                        {
                            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            string strId = dt.Rows[intRowBodyCount][0].ToString();
                            hiddenManpwrId.Value = strId;

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["APPROVE_DATE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";  //emp25
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["RQNTALCT_INS_DATE"].ToString() + "</td>";  //emp25
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 6)
                    {

                   

                        strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        string aprovedate = dt.Rows[intRowBodyCount]["MNP_APPRVL2_DATE"].ToString();
                        DateTime aprovedate1 = Convert.ToDateTime(aprovedate);
                        DateTime today = DateTime.Now;

                        int aging = Convert.ToInt32((today - aprovedate1).TotalDays);

                        //Double DAYS = Convert.ToDouble(aging);
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + aging + "</td>";
                    }
                        }
                           

                        }   
                    }



           
            strHtml += "</tr>";

        }


        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string[] ManpwrDetailsPrint(string strManpwrId, int intCorpId, int intOrgId, string fromDate, string ToDate, string AssignedTo, string Project, string sts1, string Selectedsts, string ProjectText, string AssginedText, string Gnrtedby)
    {

        //printing details

        string[] strJsonPrint = new string[30];

        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();


        clsBusinessManpwrJobAssignemntReport objBusinessRqrmntAlctn = new clsBusinessManpwrJobAssignemntReport();
        clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn = new clsEntityManpwrJobAsignment_Report();
        if (strManpwrId != "")
        {
            objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(strManpwrId);
        }
        objEntityReqrmntAlctn.CorpOffice_Id = intCorpId;
        objEntityReqrmntAlctn.Organisation_Id = intOrgId;

        DataTable dtCorp = new DataTable();
        dtCorp = objBusinessRqrmntAlctn.ReadCorporateAddress(objEntityReqrmntAlctn);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Manpower Job Assignment Report";
        DateTime datetm = DateTime.Now;
        string usrName = "";
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        if (Gnrtedby != "")
        {
            usrName = "<B> Report Generated By: </B>" + Gnrtedby;
        }
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strFrom = "";

        if (fromDate == "" || fromDate == "0")
        {
            strFrom = "";
        }
        else
        {
            DateTime dtFrom = Convert.ToDateTime(fromDate);
            String newFrom = dtFrom.ToString("dd-MM-yyyy");
            strFrom = "<tr>From date : " + newFrom + "<br/></tr>";
        }
        string strTo = "";

        if (ToDate == "" || ToDate == "0")
        {
            strTo = "";
        }
        else
        {
            DateTime dtTo = Convert.ToDateTime(ToDate);
            String newTo = dtTo.ToString("dd-MM-yyyy");
            strTo = "<tr>To date : " + newTo + "<br/></tr>";
        }
        string strproject = "";
        if (ProjectText == "")
        {
            strproject = "";
        }
        else
        {
            strproject = "<tr>Project : " + ProjectText + "<br/></tr>";
        }

        string strStatus = "";
        if (Selectedsts == "" ||Selectedsts =="--SELECT STATUS--")
        {
            strStatus = "";
        }
        else
        {
            strStatus = "<tr>Status : " + Selectedsts + "<br/></tr>";
        }
        string strAssign = "";
        if (AssignedTo != "")
        {
            if (AssginedText == "")
            {
                strAssign = "";
            }
            else
            {
                strAssign = "<tr>Accommodation : " + AssginedText.TrimEnd(" , ".ToCharArray()) + "<br/></tr>";
            }
        }

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+ strCaptionTabTitle + strCaptionTabstop + strFrom + strTo + strproject + strStatus + strAssign;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaptionDetails
        strJsonPrint[0] = sbCap.ToString();
      
       


        string[] strJson = new string[30];
        if (fromDate != "0")
        {
            objEntityReqrmntAlctn.FromDate = Convert.ToDateTime(fromDate);
           
        }
        if (ToDate != "0")
        {
            objEntityReqrmntAlctn.ToDate = Convert.ToDateTime(ToDate);
          
        }
        if (Project != "0")
        {
            objEntityReqrmntAlctn.PrjctId = Convert.ToInt32(Project);
        }
        if (AssignedTo != "0")
        {
            objEntityReqrmntAlctn.Employee_Id = AssignedTo;
        }
        //if (sts1 != "--SELECT STATUS--")
        //{

        //    objEntityReqrmntAlctn.SelfAlctnSts = Convert.ToInt32(sts1);
        //}
        
        DataTable dtManPwrId = new DataTable();
        dtManPwrId = objBusinessRqrmntAlctn.ReadManpwrJobAssignment(objEntityReqrmntAlctn);
       

            //strJson[1] = dtManPwrId.Rows[0]["MNP_REFNUM"].ToString().ToUpper();
            //strJson[2] = dtManPwrId.Rows[0]["APPROVE_DATE"].ToString();
            //strJson[3] = dtManPwrId.Rows[0]["USR_NAME"].ToString();
            //strJson[4] = dtManPwrId.Rows[0]["RQNTALCT_INS_DATE"].ToString();
            //strJson[5] = dtManPwrId.Rows[0]["PROJECT_NAME"].ToString();
            //strJson[6] = dtManPwrId.Rows[0]["MNP_APPRVL2_DATE"].ToString();
       
        StringBuilder sbCapMnpwrDtls = new StringBuilder();
        if (fromDate != "0" && AssignedTo=="0" && Project=="0")
        {
            string strMnpwrstart = "<table>";
            DateTime strfromDate =Convert.ToDateTime( fromDate);
           string Ftime= strfromDate.ToString("dd-MM-yyyy");
            // string strRef = "<tr><td>Ref# : " + strJson[1] + "</td></tr>";
           DateTime strToDate = Convert.ToDateTime(ToDate);
           string Ttime = strToDate.ToString("dd-MM-yyyy");
           string strFromDate = "<tr><td>From :  " + Ftime + "</td></tr>";
           string strTDate = "<tr><td>To :  " + Ttime + "</td></tr>";
          //  string strResrc = "<tr><td>Approved Date   : " + strJson[2] + "</td></tr>";
           // string strDiv = "<tr><td>Assigned To : " + strJson[3] + "</td></tr>";
           // string strDsgntn = "<tr><td>Assigned Date : " + strJson[4] + "</td></tr>";
            //string strproject = "<tr><td>Project : " + strJson[5] + "</td></tr>";
           string strprint = strMnpwrstart + strFromDate + strTDate;

            sbCapMnpwrDtls.Append(strprint);
            //write to  lblPrintOnBrdDtls

            strJsonPrint[1] = sbCapMnpwrDtls.ToString();
        }

        DataTable dtManpwrCand = new DataTable();
        dtManpwrCand = objBusinessManpwrReqmt.ReadManpwrCandidts(objEntityManpwrReqmt);

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtManPwrId.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">APPROVED DATE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">ASSIGNED DATE</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">STATUS</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">AGING (DAYS)</th>";
            }
        }
        if (dtManPwrId.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
            strHtml += "<td class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">APPROVED DATE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">ASSIGNED TO</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">ASSIGNED DATE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">PROJECT</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            strHtml += "<td class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">AGING (DAYS)</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int flag = 0;

      
        int count = 1;

        for (int intRowBodyCount = 0; intRowBodyCount < dtManPwrId.Rows.Count; intRowBodyCount++)
        {
            string status = "";
            string StsChk = "";

            string sts = dtManPwrId.Rows[intRowBodyCount]["MNP_PROCESS_STATUS"].ToString();

            if (sts == "0")
            {
                // status = "NEW";
            }
            if (sts == "1")
            {
                // status = "REQUEST CREATED";

            }
            else if (sts == "2")
            {
                // status = "REQUEST APPROVED";

            }
            else if (sts == "3")
            {
                // status = "HR VERIFIED";
            }

            if (sts == "4")
            {
                status = "GM APPROVED";

                if (dtManPwrId.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                {
                    status = "REQUIREMENT ALLOCATED";
                    //status = "GM APPROVED";
                }

                if (dtManPwrId.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                {
                    status = "JOB NOTIFIED";
                    //status = "GM APPROVED";
                }

                if (dtManPwrId.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                {
                    status = "CANDIDATE SELECTED";
                    //status = "GM APPROVED";
                }

                // clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                ///  clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                //objEntityReqrmntAlctn. = strManpwrId;

                string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                if (strshtlst != "0")
                {
                    status = "CANDIDATE SHORTLISTED";
                    StsChk = "8";
                }
                string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                if (strintrvw != "0")
                {
                    status = "INTERVIEW DONE";
                    StsChk = "8";
                }


                if (dtManPwrId.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                {
                    status = "REJECTED";
                }
            }
            if (sts == "6")
            {
                status = "CANDIDATE SELECTION";
            }
            if (sts == "7")

                status = "CLOSED";


            if ((Selectedsts != "--SELECT STATUS--"))
            {
                if (Selectedsts == status)
                {
                    strHtml += "<tr  >";
                }
            }
            else
            {
                strHtml += "<tr  >";
            }

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtManPwrId.Columns.Count; intColumnBodyCount++)
            {



                //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";

                if ((Selectedsts != "--SELECT STATUS--"))
                {
                    if (Selectedsts == status)
                    {
                        flag++;
                        if (dtManPwrId.Rows.Count == 0)
                        {
                            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                        }
                        else if (dtManPwrId.Rows.Count > 0)
                        {

                            string strId = dtManPwrId.Rows[intRowBodyCount][0].ToString();


                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManPwrId.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManPwrId.Rows[intRowBodyCount]["APPROVE_DATE"].ToString() + "</td>";
                            }

                            else if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManPwrId.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";  //emp25
                            }
                            else if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtManPwrId.Rows[intRowBodyCount]["RQNTALCT_INS_DATE"].ToString() + "</td>";  //emp25
                            }
                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtManPwrId.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 6)
                            {



                                strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                            }
                            else if (intColumnBodyCount == 7)
                            {
                                string aprovedate = dtManPwrId.Rows[intRowBodyCount]["MNP_APPRVL2_DATE"].ToString();
                                DateTime aprovedate1 = Convert.ToDateTime(aprovedate);
                                DateTime today = DateTime.Now;

                                int aging = Convert.ToInt32((today - aprovedate1).TotalDays);

                                //Double DAYS = Convert.ToDouble(aging);
                                strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + aging + "</td>";
                            }
                        }
                        // strHtml += "</tr>";

                    }    //MoreInfo
                }
                else
                {
                    flag++;
                    if (dtManPwrId.Rows.Count == 0)
                    {
                        strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                    }
                    else if (dtManPwrId.Rows.Count > 0)
                    {
                        string strId = dtManPwrId.Rows[intRowBodyCount][0].ToString();
                        // hiddenManpwrId.Value = strId;

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManPwrId.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManPwrId.Rows[intRowBodyCount]["APPROVE_DATE"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManPwrId.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";  //emp25
                        }
                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtManPwrId.Rows[intRowBodyCount]["RQNTALCT_INS_DATE"].ToString() + "</td>";  //emp25
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtManPwrId.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {



                            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            string aprovedate = dtManPwrId.Rows[intRowBodyCount]["MNP_APPRVL2_DATE"].ToString();
                            DateTime aprovedate1 = Convert.ToDateTime(aprovedate);
                            DateTime today = DateTime.Now;

                            int aging = Convert.ToInt32((today - aprovedate1).TotalDays);

                            //Double DAYS = Convert.ToDouble(aging);
                            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + aging + "</td>";
                        }
                    }


                }
              
            }
         
            strHtml += "</tr>";

        }
        if (flag == 0)
        {
            strHtml += "<tr><td  class=\"thT\" colspan=\"7\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        strJsonPrint[2] = sb.ToString();


        return strJsonPrint;
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn = new clsEntityManpwrJobAsignment_Report();
        List<clsEntityManpwrJobAsignment_Report> objemp = new List<clsEntityManpwrJobAsignment_Report>();
        int intUserId = 0,  intCorpId = 0;
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

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtFromDate.Text.Trim() != "")
        {
            objEntityReqrmntAlctn.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            hiddenFromDate.Value = Convert.ToString(objCommon.textToDateTime(txtFromDate.Text.Trim()));
            
        }
        if (txtTodate.Text.Trim() != "")
        {
            objEntityReqrmntAlctn.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            hiddenTodate.Value = Convert.ToString(objCommon.textToDateTime(txtTodate.Text.Trim()));
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityReqrmntAlctn.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            hiddenproject.Value = objEntityReqrmntAlctn.PrjctId.ToString();
            HiddenProjectText.Value=ddlProject.SelectedItem.Text;
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
         
            string strEmpid = hiddenselectedlist.Value;
            objEntityReqrmntAlctn.Employee_Id = hiddenselectedlist.Value;
            hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();
        }
        if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
        {
            DateTime startDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            DateTime EndDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

            if (diff > 0)
            {
                objEntityReqrmntAlctn.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                objEntityReqrmntAlctn.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
            else
            {
            }
        }
           

        //objEntityReqrmntAlctn.SelfAlctnSts=Convert.ToInt32(ddlSts.SelectedItem.Value);
        Hiddenstatus.Value = "0";
        if (ddlSts.SelectedItem.Text != "--SELECT STATUS--")
        {

            Hiddenstatus.Value = ddlSts.SelectedItem.Value;
        }
        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessRqrmntAlctn.ReadManpwrJobAssignment(objEntityReqrmntAlctn);

        string strHtm = ConvertDataTableToHTML(dtManpwr);
        divReport.InnerHtml = strHtm;

    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MNPWR_JOB_ASIGNMNT_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Manpower_Job_Assignment/Manpower_Job_Assignment_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Manpower_Job_Assignment_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MNPWR_JOB_ASIGNMNT_RPRT_CSV);
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }
        }
        catch (Exception)
        { }
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
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
        return sb.ToString();

    }
    public DataTable GetTable()
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn = new clsEntityManpwrJobAsignment_Report();
        List<clsEntityManpwrJobAsignment_Report> objemp = new List<clsEntityManpwrJobAsignment_Report>();
        int intUserId = 0, intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtFromDate.Text.Trim() != "")
        {
            objEntityReqrmntAlctn.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            hiddenFromDate.Value = Convert.ToString(objCommon.textToDateTime(txtFromDate.Text.Trim()));

        }
        if (txtTodate.Text.Trim() != "")
        {
            objEntityReqrmntAlctn.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            hiddenTodate.Value = Convert.ToString(objCommon.textToDateTime(txtTodate.Text.Trim()));
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityReqrmntAlctn.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            hiddenproject.Value = objEntityReqrmntAlctn.PrjctId.ToString();
            HiddenProjectText.Value = ddlProject.SelectedItem.Text;
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {

            string strEmpid = hiddenselectedlist.Value;
            objEntityReqrmntAlctn.Employee_Id = hiddenselectedlist.Value;
            hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();
        }
        if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
        {
            DateTime startDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            DateTime EndDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

            if (diff > 0)
            {
                objEntityReqrmntAlctn.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                objEntityReqrmntAlctn.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
            else
            {
            }
        }


        //objEntityReqrmntAlctn.SelfAlctnSts=Convert.ToInt32(ddlSts.SelectedItem.Value);
        Hiddenstatus.Value = "0";
        if (ddlSts.SelectedItem.Text != "--SELECT STATUS--")
        {

            Hiddenstatus.Value = ddlSts.SelectedItem.Value;
        }
        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessRqrmntAlctn.ReadManpwrJobAssignment(objEntityReqrmntAlctn);
        string strRandom = objCommon.Random_Number();
        DataTable table = new DataTable();
        table.Columns.Add("DATE", typeof(string));
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("IDLE HOURS", typeof(string));
        table.Columns.Add("OT TYPE", typeof(string));
        table.Columns.Add("OT HOURS", typeof(string));
        table.Columns.Add("TOTAL HOURS", typeof(string));
       
        return table;
    }
}