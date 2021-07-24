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
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Exemption_hcm_Mess_Exemption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAccomo.Focus();
            Accomodation_Load();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();
                

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {

                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

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
    //for loading accomodation drpdown
    public void Accomodation_Load()
    {
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAcco = ObjBussinesMessException.ReadAccomodation(objEntityMessException);
        if (dtAcco.Rows.Count > 0)
        {
            ddlAccomo.DataSource = dtAcco;
            ddlAccomo.DataTextField = "ACCMDTN_NAME";
            ddlAccomo.DataValueField = "ACCMDTN_ID";
            ddlAccomo.DataBind();

        }

        ddlAccomo.Items.Insert(0, "--SELECT ACCOMMODATION--");

    }
    [WebMethod]

    //It build the Html table by using the datatable provided


        //evm-0023
    public static string[] ConvertDataTableToHTML(string intCorpId, string intOrgId, string intAccoId, string strAccoName, string datFrom, string datTo)
    {
        
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        

        string[] StrDataPassing = new string[2];

        objEntityMessException.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessException.Organisation_Id = Convert.ToInt32(intOrgId);
        if (intAccoId != "--SELECT ACCOMMODATION--")
        {
            objEntityMessException.AccomoDationId = Convert.ToInt32(intAccoId);
        }
        if (datFrom != "" && datTo != "")
        {
            objEntityMessException.Fromdate = objCommon.textToDateTime(datFrom);
            objEntityMessException.Todate = objCommon.textToDateTime(datTo);
            //hiddenFromDate.value = objCommon.textToDateTime(datFrom);
        }
        DataTable dt = ObjBussinesMessException.ReadEmployee_ByAccoId(objEntityMessException);

       
        string strRandom = objCommon.Random_Number();

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
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }


            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\"></th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + " </td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + " </td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                    }

                }
                   objEntityMessException.EmpId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
              
                    DataTable dtDivisions = ObjBussinesMessException.ReadDivisionOfEmp(objEntityMessException);

                    string strDivisions = "";
                    foreach (DataRow dtDiv in dtDivisions.Rows)
                    {
                        strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
                    }
                    if (strDivisions != "")
                    {
                        strDivisions = strDivisions.Remove(strDivisions.Length - 1);
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ><input type=\"button\" style=\"width:68%;margin-left: 8%;color: #060e07;background-color: #cefed2;\" value=\"Add Mess Exemption\" Onclick=\"OpenPopUp('" + objEntityMessException.EmpId + "')\"/></td>";
                    strHtml += "</tr>";
                }
            }
        else
        {
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" ></td>";
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" ></td>";
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        StrDataPassing[0] = sb.ToString();
        StrDataPassing[1] = dt.Rows.Count.ToString();
        return StrDataPassing;
    }

    protected void btnExceptSave_Click(object sender, EventArgs e)
    {
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityMessException.AccomoDationId =Convert.ToInt32(ddlAccomo.SelectedItem.Value);
        objEntityMessException.EmpId = Convert.ToInt32(hiddenEmployeeId.Value);
        objEntityMessException.Fromdate =objCommon.textToDateTime(txtFromDate.Text);
        objEntityMessException.Todate =objCommon.textToDateTime(txtToDate.Text);

        DataTable dtDup = ObjBussinesMessException.CheckDuplication(objEntityMessException);
        if (dtDup.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "MessDuplication", "MessDuplication();", true);
        }
        else
        {
            ObjBussinesMessException.InsertMessExcept(objEntityMessException);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSave", "SuccessSave();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "ClearTextBx", "ClearTextBx();", true);
    }

    [WebMethod]
    public static string[] ReadAndFillUserData(string intCorpId, string intOrgId, string intUserId)
    {
        string[] datapassing = new string[5];
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();

        objEntityMessException.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessException.Organisation_Id = Convert.ToInt32(intOrgId);
        objEntityMessException.EmpId = Convert.ToInt32(intUserId);

        DataTable dtDivisions = ObjBussinesMessException.ReadDivisionOfEmp(objEntityMessException);

        string strDivisions = "";
        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
        }
        if (strDivisions != "")
        {
            strDivisions = strDivisions.Remove(strDivisions.Length - 1);
        }
        DataTable dtEmp = ObjBussinesMessException.ReadEmpDetailById(objEntityMessException);
        if (dtEmp.Rows.Count > 0)
        {
            datapassing[0] = dtEmp.Rows[0]["EMPERDTL_FNAME"].ToString();
            datapassing[1] = dtEmp.Rows[0]["DSGN_NAME"].ToString();
            datapassing[2] = dtEmp.Rows[0]["ACCMDTN_NAME"].ToString();


            datapassing[3] = strDivisions;

        }
        return datapassing;
    }
}