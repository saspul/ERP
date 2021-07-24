using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_List : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YearLoad();
            monthLoad();

            Session["EmpPymtclsView"] = "";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            // DeductionLoad();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;

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
            ;
          //  DataTable dtemp = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);

           // loademployee(dtemp);
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Payment_closing);

            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            divAdd.Visible = false;
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {

                        divAdd.Visible = true;
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
            clsEntityLayer_Payment_Closing objEntityPaymtCls = new clsEntityLayer_Payment_Closing();
            clsBusinessLayer_payment_Closing objBusinessLayerPaymtCls = new clsBusinessLayer_payment_Closing();

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
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            ddlYear.Items.Add((currentYear - i).ToString());

        }
        ddlYear.Items.Insert(0, "--SELECT YEAR--");
        ddlYear.ClearSelection();
        if (split[2] != null && split[2]!="")
        {
            if (ddlYear.Items.FindByValue(split[2]) != null)
            {
                ddlYear.Items.FindByValue(split[2]).Selected = true;
            }
        }
    }
    public void monthLoad()
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');
        var currentMnth = Convert.ToInt32(split[1]);

        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT MONTH--");
        ddlMonth.ClearSelection();
        if (split[1] != null && split[1] != "")
        {
            if (ddlMonth.Items.FindByValue(split[1]) != null)
            {
                ddlMonth.Items.FindByValue(split[1]).Selected = true;
            }
        }
    }

         public string ConvertDataTableToHTML(DataTable dt)
    {

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";

        string strHead = "<tr>";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 35%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "'</th>";
                strHead += " <th data-class=\"expand\">EMPLOYEE ID</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 20%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">EMPLOYEE</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">PROCESS</th>";

            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">CLOSED DATE</th>";

            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">PAID AMOUNT</th>";

            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">TOTAL AMOUNT</th>";
            }

        }
        strHead += "<th data-class=\"expand\"></th></tr>";
        strHtml += "<th class=\"hasinput\" style=\"width:5%\"></th >";
        strHtml += "</tr>";
        strHtml += strHead;
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string strCountryId = dt.Rows[intRowBodyCount][0].ToString();
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td style=\" width:35%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"ViewRow(" + strCountryId + ");\"><i class=\"fa fa-eye\"></i></button>";



            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
         protected void btnRedirect_Click(object sender, EventArgs e)
         {
             Session["EmpPymtclsView"] = HiddenViewId.Value;

             Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Deduction/hcm_Employee_Deduction_Master.aspx");

         }
         protected void btnRedirect2_Click(object sender, EventArgs e)
         {
             string Mode = "5~0~3~0~"+HiddenFieldMonth.Value+"~"+HiddenFieldYear.Value;
             Session["SALARPRSS"] = Mode;
             Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Monthly_Salary_Process/hcm_Monthly_Salary_Satement.aspx?SaveOrConf=CLOSE");
           
         }
       
}
