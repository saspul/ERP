using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using EL_Compzit;

using System.IO;
public partial class HCM_HCM_Reports_hcm_JobOffer_Status_Report_hcm_JobOffer_Status_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProjectLoad();
            ManpowerRqrmntLoad();
            Employee_load();
            clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();
            clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
            if (Session["USERID"] != null)
            {
                objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtShortlistcandidates = objBusinessJoingIntimation.ReadCandidatesReport(objEntityJoiningList);
            DataTable dtShortlistedcandidatelist = null;

            string strHtm = ConvertDataTableToHTML(dtShortlistcandidates, dtShortlistedcandidatelist,"page load");
            divReport.InnerHtml = strHtm;

            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

            string strprint = ConvertDataTableForPrint(dtShortlistcandidates, dtCorp, "page load");
            divPrintReport.InnerHtml = strprint;

        }

    }

       public void ProjectLoad()
    {
        clcBusiness_Joining_Intimation objJoiningList = new clcBusiness_Joining_Intimation();
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtProjct = objJoiningList.ReadProject(objEntityJoiningList);
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }
        ddlProject.Items.Insert(0, "--SELECT PROJECT--");

    }

       public void ManpowerRqrmntLoad()
       {
                clcBusiness_Joining_Intimation objJoiningList = new clcBusiness_Joining_Intimation();
                clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();                           
                if (Session["USERID"] != null)
                {
                    objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                DataTable dtAprvdManpwrRqst = new DataTable();
                dtAprvdManpwrRqst = objJoiningList.ReadJoingReqrmntList(objEntityJoiningList);
                if (dtAprvdManpwrRqst.Rows.Count > 0)
                {
                    ddlManPower.DataSource = dtAprvdManpwrRqst;
                    ddlManPower.DataTextField = "REF#";
                    ddlManPower.DataValueField = "MNPRQST_ID";
                    ddlManPower.DataBind();
                }

                ddlManPower.Items.Insert(0, "--SELECT MANPOWER--");
              
            }

       public void Employee_load()
       {
           ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
           ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
           if (Session["CORPOFFICEID"] != null)
           {
               objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
           }
           else if (Session["CORPOFFICEID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }

           if (Session["ORGID"] != null)
           {
               objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
           }
           else if (Session["ORGID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }
           if (Session["USERID"] != null)
           {
               objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
           }
           else if (Session["USERID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }      
           objentityPassport.division = 0;
           objentityPassport.designation = 0;
           objentityPassport.department = 0;
        
           DataTable dtEmployee = objBussinesspasprt.ReadEmployee(objentityPassport);
           ddlEmployee.Items.Clear();
           if (dtEmployee.Rows.Count > 0)
           {
               ddlEmployee.DataSource = dtEmployee;
               ddlEmployee.DataTextField = "USR_NAME";
               ddlEmployee.DataValueField = "USR_ID";
               ddlEmployee.DataBind();
           }
           ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
       }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityJoiningList.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityJoiningList.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }

           
        DataTable dtShortlistcandidates = objBusinessJoingIntimation.ReadCandidatesReport(objEntityJoiningList);
        DataTable dtShortlistedcandidatelist = null;
        string strHtm = ConvertDataTableToHTML(dtShortlistcandidates, dtShortlistedcandidatelist,"Search");

        divReport.InnerHtml = strHtm;

        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

        string strprint = ConvertDataTableForPrint(dtShortlistcandidates, dtCorp, "Search");
        divPrintReport.InnerHtml = strprint;

       

    }
    //evm-0019 Start
    public string ConvertDataTableToHTML(DataTable dt, DataTable Shortlist, string load )
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";     
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">OFFER RESPONSE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE OF RESPONSE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";   
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
      
        strHtml += "<tbody>";
        int count = 1;
        if (dt.Rows.Count > 0)
        {
            if (load != "page load")
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {

                    strHtml += "<tr  >";
                    count++;

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";

                    if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >PENDING</td>";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >CONFIRMED</td>";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >REJECTED</td>";
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE OF RESPONSE"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                    strHtml += "</tr >";
                }
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }



    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp,string search)
    {

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Job Offer Status Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
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
        string strUsrName = "";
        StringBuilder sbCap = new StringBuilder();
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">OFFER RESPONSE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE OF RESPONSE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>"; 
        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        if (search != "page load")
        {
            if (dt.Rows.Count > 0)
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    strHtml += "<tr  >";
                    count++;
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";

                    if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >PENDING</td>";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >CONFIRMED</td>";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >REJECTED</td>";
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE OF RESPONSE"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                    strHtml += "</tr >";
                }
            }
        }
        if (search == "page load")
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=7 style=\"width:100%;text-align: center; word-wrap:break-word;padding: 0px 2px;\">No Data Available</td></tr>";
        }
        if (dt.Rows.Count == 0)
        {
            if (search != "page load")
            {
                strHtml += "<tr>";
                strHtml += "<td class=\"thT\"colspan=7 style=\"width:100%;text-align: center; word-wrap:break-word;padding: 0px 2px;\">No Data Available</td></tr>";
            }
        }
    
        strHtml += "</tbody>";
        strHtml += "</table>";

        sb.Append(strHtml);
        //write to divPrintReport
        return sb.ToString();
    }

    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strImagePath = "";
        string filepath = "";
        string strResult = DataTableToCSV(dt, ',');
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOB_OFFER_STATUS_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Job_Offer_Status/Job_Offer_Status_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Job_Offer_Status_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOB_OFFER_STATUS_RPRT_CSV);
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
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable table = new DataTable();

        table.Columns.Add("REF#", typeof(string));
        table.Columns.Add("CANDIDATE NAME", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("OFFER RESPONSE", typeof(string));
        table.Columns.Add("DATE OF RESPONSE", typeof(string));
        table.Columns.Add("ASSIGNED TO", typeof(string));
        clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityJoiningList.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityJoiningList.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }


        DataTable dt = objBusinessJoingIntimation.ReadCandidatesReport(objEntityJoiningList);


        //for printing table
        string Ref = "";
        string CadidateName = "";
        string Department = "";
        string Project = "";
        string OfferResponse = "";
        string DateOfResponse = "";
        string AssignedTo = "";
        int count=0;

          for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {

                   
                    count++;
                    Ref = dt.Rows[intRowBodyCount]["MNP_REFNUM"].ToString();
                    CadidateName = dt.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                    Department = dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                    Project = dt.Rows[intRowBodyCount]["PROJECT"].ToString();
                  
               
                   
                    if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0")
                    {
                        OfferResponse = "PENDING";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "1")
                    {
                        OfferResponse = "CONFIRMED";
                    }
                    else if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "2")
                    {
                        OfferResponse = "REJECTED";
                    }
                    DateOfResponse = dt.Rows[intRowBodyCount]["DATE OF RESPONSE"].ToString();
                    AssignedTo = dt.Rows[intRowBodyCount]["USR_NAME"].ToString();

                    table.Rows.Add('"' + Ref + '"', '"' + CadidateName + '"', '"' + Department + '"', '"' + Project + '"', '"' + OfferResponse + '"', '"' + DateOfResponse + '"', '"' + AssignedTo  + '"');
                }
          

        return table;
    }
}