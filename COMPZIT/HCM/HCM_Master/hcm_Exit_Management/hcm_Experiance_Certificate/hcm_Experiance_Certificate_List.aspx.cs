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

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Experiance_Certificate_hcm_Experiance_Certificate_List : System.Web.UI.Page
{

    ClsBusiness_Experiance_Certificate objBussnsExpCertfct = new ClsBusiness_Experiance_Certificate();
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");


        txtFromDate.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtToDate.Attributes.Add("onkeypress", "return DisableEnter(event)");


        if (!IsPostBack)
        {
            ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
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
            DataTable dtLevEmployee = objBussnsExpCertfct.ReadEmployList(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTML(dtLevEmployee);
            divReport.InnerHtml = strHtm;
       
            FillEmployee();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
     
     

        int intCorpId = 0,intUserId=0,intOrg=0;
        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
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

        if (txtFromDate.Text != null && txtFromDate.Text != "")
        {
            objEntityOnBoard.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text != null && txtToDate.Text != "")
        {
            objEntityOnBoard.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            objEntityOnBoard.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        DataTable dtCertfct = new DataTable();
        dtCertfct = objBussnsExpCertfct.ReadEmployList(objEntityOnBoard);

        string strHtm = ConvertDataTableToHTML(dtCertfct);
        divReport.InnerHtml = strHtm;

     

    }


    public string ConvertDataTableToHTML(DataTable dt)
    {

        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        //int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        //string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

         for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:17%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
                else if (intColumnHeaderCount == 2)
            {
            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount ==3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:18%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            
            else if (intColumnHeaderCount ==4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            else if (intColumnHeaderCount ==5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">JOINING DATE</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">LEAVING DATE</th>";
            }
           


        }

   

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
     
        strHtml += "<tbody>";
        int count = 0;
        string strdidchk = "";
        if (dt.Rows.Count == 0)
        {




            
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
           
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count++;
            strHtml += "<tr  >";

            //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

            //string strId = dt.Rows[intRowBodyCount][0].ToString();


            objEntityOnBoard.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPLOYEE ID"]);
            DataTable dtDivisions = objBussnsExpCertfct.ReadDivisionOfEmp(objEntityOnBoard);
            string strDivisions = "";
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = strDivisions + dtDiv["DIVISION"];
                }
                else
                {
                    strDivisions = dtDiv["DIVISION"] + "," + strDivisions;
                }
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string reference = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a  onclick='return getdetails(this.href);' " +
                       " href=\"hcm_Experiance_Certificate.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a> </td>";
                 }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                   

                }
               
                else if (intColumnBodyCount == 4)
                {
  
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strDivisions + "</td>";
                }


                else if (intColumnBodyCount ==5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["JOINING DATE"].ToString() + "</td>";

                }

                else if (intColumnBodyCount ==6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVING DATE"].ToString() + "</td>";

                }
            }


            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    public void FillEmployee()
    {

        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
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
        DataTable dtLevEmployee = objBussnsExpCertfct.ReadEmployee(objEntityOnBoard);
        if (dtLevEmployee.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtLevEmployee;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");



    }
}