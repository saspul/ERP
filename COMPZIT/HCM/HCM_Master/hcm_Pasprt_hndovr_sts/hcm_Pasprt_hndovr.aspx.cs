using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Pasprt_hndovr_sts_hcm_Pasprt_hndovr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
            ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();

            Corp_DivisionLoad();
            Corp_DepartmentLoad();
            DesignationLoad();
            Employee_load();

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
            objentityPassport.employee = 0;
            objentityPassport.department = 0;

            objentityPassport.designation = 0;
            objentityPassport.HandStatus = 1;

            DataTable dtCandidateList = objBussinesspasprt.ReadEmployeepassportList(objentityPassport);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;

            DataTable dtCorp = objBussinesspasprt.ReadCorporateAddress(objentityPassport);
            string strPrintReport = ConvertDataTableToHTMLPrint(dtCorp, dtCandidateList);
            divPrintReport.InnerHtml = strPrintReport;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
            }
        }
    }
    public void Corp_DivisionLoad()
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
        DataTable dtSubConrt = objBussinesspasprt.ReadDivision(objentityPassport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddldiv.DataSource = dtSubConrt;
            ddldiv.DataTextField = "CPRDIV_NAME";
            ddldiv.DataValueField = "CPRDIV_ID";
            ddldiv.DataBind();
        }

        ddldiv.Items.Insert(0, "--SELECT DIVISION--");

    }



    public void Corp_DepartmentLoad()
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
        DataTable dtSubConrt = objBussinesspasprt.ReadDepartment(objentityPassport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddldep.DataSource = dtSubConrt;
            ddldep.DataTextField = "CPRDEPT_NAME";
            ddldep.DataValueField = "CPRDEPT_ID";
            ddldep.DataBind();

        }

        ddldep.Items.Insert(0, "--SELECT DEPARTMENT--");


    }
    public void DesignationLoad()
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
        DataTable dtSubConrt = objBussinesspasprt.ReadDesignation(objentityPassport);

        if (dtSubConrt.Rows.Count > 0)
        {

            ddldesig.DataSource = dtSubConrt;
            ddldesig.DataTextField = "DSGN_NAME";
            ddldesig.DataValueField = "DSGN_ID";
            ddldesig.DataBind();

        }
        ddldesig.Items.Insert(0, "--SELECT DESIGNATION--");

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

        if (ddldiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objentityPassport.division = Convert.ToInt32(ddldiv.SelectedItem.Value);
        }
        else
        {
            objentityPassport.division = 0;
        }

        if (ddldesig.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objentityPassport.designation = Convert.ToInt32(ddldesig.SelectedItem.Value);
        }
        else
        {
            objentityPassport.designation = 0;
        }
        if (ddldep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objentityPassport.department = Convert.ToInt32(ddldep.SelectedItem.Value);
        }
        else
        {
            objentityPassport.department = 0;
        }

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
    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 23%;\" onkeypress=\"return DisableEnter(event)\"; onchange=\"selectAllEmployees()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DIVISION</th>";

        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + "IN HANDS OF" + "</th>";

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
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onkeypress=\"return DisableEnter(event)\"; onchange=\"IncrmntConfrmCounter()\"></td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount ==3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount ==4)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                    }


                }
                objentityPassport.employee = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
                DataTable dtDivisions = objBussinesspasprt.ReadDivisionOfEmp(objentityPassport);

                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
                }
                if (strDivisions != "")
                {
                    strDivisions = strDivisions.Remove(strDivisions.Length - 1);
                }
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                strHtml += "<td class=\"tdT\" id=\"tdcandiateid" + intRowBodyCount + "\"   style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>";


                string handovr = "";
                if (dt.Rows[intRowBodyCount]["IN HANDS OF"].ToString() != "")
                {
                    handovr = dt.Rows[intRowBodyCount]["IN HANDS OF"].ToString();
                }
                else
                {
                    handovr = "EMPLOYEE";
                }
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + handovr + "</td>";


                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
        if (radioAHr.Checked == true)
        {
            // 1-Hr 0 emp
            HiddenStatus.Value = "0";
            objentityPassport.HandStatus = 1;
        }

        else
        {
            HiddenStatus.Value = "1";
            objentityPassport.HandStatus = 0;

        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objentityPassport.employee = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddldiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objentityPassport.division = Convert.ToInt32(ddldiv.SelectedItem.Value);
        }
        if (ddldesig.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objentityPassport.designation = Convert.ToInt32(ddldesig.SelectedItem.Value);
        }
        if (ddldep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objentityPassport.department = Convert.ToInt32(ddldep.SelectedItem.Value);
        }


        DataTable dtCandidateList1 = objBussinesspasprt.ReadEmployeepassportList(objentityPassport);
        string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList1);
        divReport.InnerHtml = strHtm;

        DataTable dtCorp = objBussinesspasprt.ReadCorporateAddress(objentityPassport);

        string strPrintReport = ConvertDataTableToHTMLPrint(dtCorp, dtCandidateList1);

        divPrintReport.InnerHtml = strPrintReport;

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
        if (HiddenStatus.Value == "1")
        {

            objentityPassport.HandStatus = 1;
        }

        else
        {
            objentityPassport.HandStatus = 0;

        }
        objentityPassport.Date = System.DateTime.Now;

        objentityPassport.HandoverDate = ObjCommon.textToDateTime(txthandOvrDt.Text);

        List<clsEntity_Passport_Handover_Stslist> objEntityuseridlist = new List<clsEntity_Passport_Handover_Stslist>();

        string strUserlId = "";
        string[] strarruserlIds = strUserlId.Split(',');
        if (Hiddenchecklist.Value != "" && Hiddenchecklist.Value != null)
        {
            strUserlId = Hiddenchecklist.Value;
            strarruserlIds = strUserlId.Split(',');

        }
        //Cancel the rows that have been cancelled when editing in Detail table
        foreach (string strusrId in strarruserlIds)
        {
            if (strusrId != "" && strusrId != null)
            {
                int intDtlId = Convert.ToInt32(strusrId);
                clsEntity_Passport_Handover_Stslist objEntityuser = new clsEntity_Passport_Handover_Stslist();
                objEntityuser.Employeeid = Convert.ToInt32(strusrId);
                objEntityuseridlist.Add(objEntityuser);

            }
        }
        objBussinesspasprt.AddPassportdate(objentityPassport, objEntityuseridlist);


        Response.Redirect("hcm_Pasprt_hndovr.aspx?InsUpd=Upd");

    }




    public string ConvertDataTableToHTMLPrint(DataTable dtCorp, DataTable dt)
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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


        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Passport Hand Over Status";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
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

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";

        string div = "";
        if (ddldiv.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            div = "";
        }
        else
        {
            div = "<tr>Division : " + ddldiv.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string dept = "";
        if (ddldep.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            dept = "";
        }
        else
        {
            dept = "<tr>Department : " + ddldep.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string desgntn = "";
        if (ddldesig.SelectedItem.Text.ToString() == "--SELECT DESIGNATION--")
        {
            desgntn = "";
        }
        else
        {
            desgntn = "<tr>Designation : " + ddldesig.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string strCaptionTabstop = "</table>";
        
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop+div+dept+desgntn;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();


        //add header row
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DIVISION</th>";

        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + "IN HANDS OF" + "</th>";
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


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                }
                objentityPassport.employee = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
                DataTable dtDivisions = objBussinesspasprt.ReadDivisionOfEmp(objentityPassport);

                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
                }
                if (strDivisions != "")
                {
                    strDivisions = strDivisions.Remove(strDivisions.Length - 1);
                }
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                strHtml += "<td class=\"tdT\" id=\"tdcandiateid" + intRowBodyCount + "\"   style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>";


                string handovr = "";
                if (dt.Rows[intRowBodyCount]["IN HANDS OF"].ToString() != "")
                {
                    handovr = dt.Rows[intRowBodyCount]["IN HANDS OF"].ToString();
                }
                else
                {
                    handovr = "EMPLOYEE";
                }
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + handovr + "</td>";


                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }



    protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Employee_load();
    }
    protected void ddldiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        Employee_load();
    }
    protected void ddldesig_SelectedIndexChanged(object sender, EventArgs e)
    {
        Employee_load();
    }
}

 

