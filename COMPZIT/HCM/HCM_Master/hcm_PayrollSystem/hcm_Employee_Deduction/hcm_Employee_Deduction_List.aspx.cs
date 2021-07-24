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

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_List : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Session["EmpDeductionView"] = "";
            Session["DeleteView"] = "";
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.EMPLOYEE_DEDUCTION_MASTER);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }
                if (intEnableAdd == 0)
                {
                    divAdd.Visible = false;
                }

            } clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

            // for adding comma

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
            ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
            clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();

            objEntityEmployeeDeduction.CorpId = intCorpId;
            objEntityEmployeeDeduction.orgid = intOrgId;
         //   DataTable dtlist=  objBusinessLayerEmployeeDeductn.ReadDeductionList(objEntityEmployeeDeduction);
       //   divList.InnerHtml = ConvertDataTableToHTML(dtlist);
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
                strHead += " <th data-class=\"expand\">DOC NUMBER</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 20%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">EMPLOYEE ID</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 20%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">DEDUCTION</th>";

            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">AMOUNT</th>";

            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">AMOUNT PAID</th>";

            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 30%\"><input type=\"text\" class=\"form-control\" placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">NO OF INSTALLMENT</th>";

            }

        }
        strHead += "<th data-class=\"expand\">EDIT</th></tr>";
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
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount ==3)
                {
                    strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word\" >" + dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["EMPDEDTN_DEDCTNID"].ToString() + "</td>";
                }
                else if (intColumnBodyCount ==5)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["TOTALPAID"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["EMPDEDTN_INSTLMNTNO"].ToString() + "</td>";
                }
            }

            strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"  ><button runat=\"server\" class=\"btn btn-xs btn-default\" title=\"Delete\" onclick=\"return ViewRow(" + strCountryId + ");\"><i class=\"fa fa-eye\"></i></button>";



            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
         protected void btnRedirect_Click(object sender, EventArgs e)
         {
             Session["EmpDeductionView"] = HiddenViewId.Value;
             Session["DeleteView"] = HiddenFieldDeleView.Value;
             Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Deduction/hcm_Employee_Deduction_Master.aspx");

         }
         [WebMethod]
         public static string DeleteDedctn(string strCatId, string strReason, string strReasonMust, string UserId)
         {
             clsCommonLibrary objCommon = new clsCommonLibrary();

             ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
             clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
             string strRet = "success";

             objEntityEmployeeDeduction.DeductionId = Convert.ToInt32(strCatId);
             objEntityEmployeeDeduction.UserId = Convert.ToInt32(UserId);
             objEntityEmployeeDeduction.EffectiveDate = System.DateTime.Now;
             if (strReasonMust == "1")
             {
                 objEntityEmployeeDeduction.Remarks = strReason;
             }
             else
             {
                 objEntityEmployeeDeduction.Remarks = objCommon.CancelReason();
             }
             try
             {
                 objBusinessLayerEmployeeDeductn.DeleDeductionById(objEntityEmployeeDeduction);
                 Page objpage = new Page();
                 objpage.Session["Succes"] = "DELETE";      
             }
             catch
             {
                 strRet = "failed";
             }
             return strRet;

         }
}
