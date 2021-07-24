using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;

// CREATED BY:EVM-0008
// CREATED DATE:10/30/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = null;
        if (!IsPostBack)
        {
            
           // radioCustType2.Focus();
            Session["SALARPRSS"] = null;
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);


            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.CorpOffice = intCorpId;
            objEnt.UserId = intUserId;
            objEnt.Orgid = intOrgId;
            //if (radioCustType2.Checked == true)
          //  {
                objEnt.SavConf = 0;
          //  }
          //  else if (radioCustType1.Checked == true)
          //  {
           //     objEnt.SavConf = 1;
          //  }
                objEnt.PendFinshId = 0;
            DataTable dtList = objBuss.LoadMonthlySalList(objEnt);
            string STRLIST = ConvertDataTableToHTML(dtList);
            divlistview.InnerHtml = STRLIST;

            if (Request.QueryString["Deleted"] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelete", "SuccessDelete();", true);
            }

        }
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {
        int SaveOrConf = 0, SaveOrConfQrString=0, pendOrfinsh = 0;
        if (radioCustType2.Checked == true)
        {
            SaveOrConf = 0;
            SaveOrConfQrString = 0;
        }
        else if (radioCustType1.Checked == true)
        {
            SaveOrConf = 1;
            SaveOrConfQrString = 1;
           
        }
        else if (radioPaymnt.Checked == true)
        {
            SaveOrConf = 2;
            pendOrfinsh = 0;
            SaveOrConfQrString = 2;
        }
        else if (radioPaymntFin.Checked == true)
        {
            SaveOrConf = 3;
            pendOrfinsh = 1;
        }
        
            
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";



        strHtml += "<tr >";



        int intCnclUsrId = 0;
        int intReCallForTAble = 0;

      

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
           {
                strHtml += "<th class=\"hasinput\" style=\"width:25%\"> MONTH & YEAR";


                strHtml += "	<input class=\"form-control\" placeholder=\"MONTH & YEAR\" type=\"text\">";
                strHtml += "</th >";
           }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:24%\">TYPE ";


                strHtml += "	<input class=\"form-control\" placeholder=\"TYPE\" type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;\"> DEPARTMENT";


                strHtml += "	<input class=\"form-control\" placeholder=\"DEPARTMENT\" type=\"text\">";
                strHtml += "</th >";
           }

            else if (intColumnHeaderCount == 4)
           {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;\">NO. Of EMPLOYEE " ;


                strHtml += "	<input class=\"form-control\" placeholder=\"NO. Of EMPLOYEE \" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;\">DATE";


                strHtml += "	<input class=\"form-control\" placeholder=\"DATE\" type=\"text\">";
                strHtml += "</th >";
            }


        }
        if (SaveOrConf == 0  )
        {
            strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> EDIT";
            strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PRINT";
            strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> DELETE";

        }
        else if(SaveOrConf == 1)
        {
            strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
            strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PRINT";
        }
        else
        {
            //strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
           // if (SaveOrConf == 1)
          //  {
            if (pendOrfinsh == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PAYMENT";
            }
            else
            {
                strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PAYMENT";
                strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PRINT";
            }
          //  }
        }
        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;display:none\"> Edit";
        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;display:none\"> Edit";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
          

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["month"].ToString() + " " + dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    string StaffWork = "";
                    if (dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString() == "0")
                    {
                        StaffWork = "Staff";
                    }
                    else
                    {
                        StaffWork = "Worker";
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + StaffWork + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPCOUNT"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["SLPRCDMNTH_FROM_DATE"].ToString() + "</td>";
                }

            }

            int CorpdepId = 0;
            if (dt.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() != "")
            {
                CorpdepId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString());
            }
            string staffWrk = dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString();
            string ddate=dt.Rows[intRowBodyCount]["SLPRCDMNTH_FROM_DATE"].ToString();
            string pMonth = dt.Rows[intRowBodyCount]["SLPRCDMNTH_NUMBR"].ToString();
            string pYear=dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString();
           // string pBussUnitName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();


            string passingvalues = SaveOrConfQrString + "~" + CorpdepId + "~" + staffWrk + "~" + ddate + "~" + pMonth + "~" + pYear;
            string passingvaluesPaid = pendOrfinsh + "~" + CorpdepId + "~" + staffWrk + "~" + ddate + "~" + pMonth + "~" + pYear ;
            
            if (SaveOrConf == 0)
            {
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return EditRow(" + intRowBodyCount + ");\"><i class=\"fa fa-pencil\"></i></button></td>";
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PrintSalaryDetails(" + intRowBodyCount + ",'SAVE');\"><i class=\"fa fa-print\"></i></button></td>";
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"  onclick=\"return DeleteMnthlyPrcssList(" + CorpdepId + "," + staffWrk + ",'" + ddate + "'," + pMonth + "," + pYear + ");\"><i class=\"fa fa-trash\"></i></button></td>";
            }
            else if (SaveOrConf == 1)
            {
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return EditRow(" + intRowBodyCount + ");\"><i class=\"fa fa-eye\"></i></button></td>";
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PrintSalaryDetails(" + intRowBodyCount + ",'CONF');\"><i class=\"fa fa-print\"></i></button></td>";

                //EVM-0027 02-02-2019
                // strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PrintSalaryDetails(" + intRowBodyCount + ");\"><i class=\"fa fa-print\"></i></button></td>";
                //END
            }
            //EVM-0027
            else if (pendOrfinsh == 1)
            {
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return EditRowFinish(" + intRowBodyCount + ");\"><i class=\"fa fa-eye\"></i></button></td>";
            }
            else
            {


                // if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3")
                //  {
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return EditRowFinish(" + intRowBodyCount + ");\"><i class=\"fa fa-pencil\"></i></button></td>";
                //  }
                //else
                //{
                //    strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button style=\"opacity:.2;pointer-events: none;\"  class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return EditRowFinishNot();\"><i  class=\"fa fa-pencil\"></i></button></td>";
                //}
                strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PrintSalaryDetails(" + intRowBodyCount + ",'CONF');\"><i class=\"fa fa-print\"></i></button></td>";
            }
            //END

            strHtml += "<td  style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"  value=\"" + passingvalues + "\" id=\"Para" + intRowBodyCount + "\"></td>";
            strHtml += "<td  style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"  value=\"" + passingvaluesPaid + "\" id=\"ValuePaid" + intRowBodyCount + "\"></td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = HiddenViewId.Value;
        Response.Redirect("hcm_Monthly_Salary_Process.aspx");

    }
    protected void btnRedirect1_Click(object sender, EventArgs e)
    {
        Session["SALARPRSS_PAYMENT"] = HiddenViewId.Value;
        Response.Redirect("hcm_Salary_Payment_Process.aspx");

    }
    
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);


        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.CorpOffice=intCorpId;
        objEnt.UserId=intUserId;
        objEnt.Orgid = intOrgId;
        if (radioCustType2.Checked == true)
        {
            objEnt.SavConf = 0;
        }
        else if (radioCustType1.Checked == true)
        {
            objEnt.SavConf = 1;
         
        }
        else if (radioPaymnt.Checked == true)
        {
            objEnt.SavConf = 2;
        }
        else if (radioPaymntFin.Checked == true)
        {
            objEnt.SavConf = 3;
        }
        
      
        DataTable dtList = objBuss.LoadMonthlySalList(objEnt);
      string STRLIST=  ConvertDataTableToHTML(dtList);
      divlistview.InnerHtml = STRLIST;
    }

    protected void btnRedirect2_Click(object sender, EventArgs e)
    {
        string Mode = HiddenSaveConf.Value;
        Session["SALARPRS"] = HiddenViewId.Value;

        //0041
        Response.Redirect("../hcm_Monthly_Salary_statement/hcm_Monthly_Salary_Statement_print.aspx");
        //  Response.Redirect("hcm_Monthly_Salary_Satement.aspx?SaveOrConf=" + Mode);
        //    Response.Redirect("hcm_Monthly_Salary_Satement.aspx");
        //END
    }
    
    [WebMethod]
    public static string DeleteMonthlyProcesList(string CorpdepId, string staffWrk, string ddate, string pMonth, string pYear)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        cls_Entity_Monthly_Salary_Process objEntityMonthlySalaryProcess = new cls_Entity_Monthly_Salary_Process();
        cls_Business_Monthly_Salary_Process objBussMonthlySalaryProcess = new cls_Business_Monthly_Salary_Process();

        objEntityMonthlySalaryProcess.CorpOffice = Convert.ToInt32(CorpdepId);
        objEntityMonthlySalaryProcess.StffWrkr = Convert.ToInt32(staffWrk);
        objEntityMonthlySalaryProcess.date = objCommon.textToDateTime(ddate);
        objEntityMonthlySalaryProcess.Month = Convert.ToInt32(pMonth);
        objEntityMonthlySalaryProcess.Year = Convert.ToInt32(pYear);

        objBussMonthlySalaryProcess.DeleteMonthlySalaryProcesList(objEntityMonthlySalaryProcess);
        return "";
    }

}