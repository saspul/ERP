using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;

public partial class GMS_Reports_Mail_Tracking : System.Web.UI.Page
{
    clsBusinessLayerGmsReports ObjBussinessReports = new clsBusinessLayerGmsReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            divtile.InnerHtml = "Mail Tracking Report";
            clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
            clsEntityReports objEntityReports = new clsEntityReports();  
                 HiddenFieldSuplier.Value = "0";
            HiddenFieldClient.Value = "0";
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableSuplier = 0, intEnableClient = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project_Wise_Bank_Guarantee);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                    {
                        intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                         HiddenFieldSuplier.Value = intEnableSuplier.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                         HiddenFieldClient.Value = intEnableClient.ToString();

                    }


                }
                //ddlGCatagry.Items.Remove(ddlGCatagry.Items[1]);
                //ddlGCatagry.Items.Remove(ddlGCatagry.Items[0]);
               
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = intCorpId.ToString();
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();
         
                    ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }





                DataTable dtBankGurante = ObjBussinessReports.Read_MailTrackingDetails(ObjEntityBankGuarantee);
                string strHtm = ConvertDataTableToHTML(dtBankGurante);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
                string strPrintReport = ConvertDataTableForPrint(dtBankGurante, dtCorp);
                divPrintReport.InnerHtml = strPrintReport;




            }
        }

    }
 
 
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
   //     objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">TRACKING DATE</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: CENTER; word-wrap:break-word;\">TO ADDRESS</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: CENTER; word-wrap:break-word;\">MAIL SUBJECT</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">REF#</th>";
            }
        }





        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            if (COUNT == 15)
            {
                break;


            }
            hiddenLastRow.Value = intRowBodyCount.ToString();

            strHtml += "<tr  >";
            int intage = 0;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                DateTime dateExDate = DateTime.MinValue;
                string strCurrentDate = objBusiness.LoadCurrentDateInString();
                DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
              
                
            }









            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
 
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        // objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        //EVM-0016
        strTitle = "Mail Tracking Report";
        //EVM-0016
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "",GuaranteePrjct="";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // clsBusinessLayer objBusiness = new clsBusinessLayer();


       


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

               
        //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();




        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
      
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteePrjct="";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
      
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteePrjct + strCaptionTabTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
           for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TRACKING DATE</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">TO ADDRESS</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">MAIL SUBJECT</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">REF#</th>";
            }
        }





        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {


                strHtml += "<tr  >";
                int intage = 0;
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                }






                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<tfoot>";
            strHtml += "<td  class=\"tdT\" colspan=\"10\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >NO DATA AVAILABALE</td>";
            //string stamt = sum2.ToString();
            //string strNetAmo = objBusiness.AddCommasForNumberSeperation(stamt, ObjEntityCommon);


            strHtml += "</tfoot>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }
    [WebMethod]
    public static string LoadTableRows(int OrgId, int CorpId, int Rowstart)
    {
        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        ObjEntityBankGuarantee.Corporate_Id = CorpId;
        ObjEntityBankGuarantee.Organisation_Id = OrgId;

        DataTable dt = objBusinessLayerReports.Read_MailTrackingDetails(ObjEntityBankGuarantee);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();



        //add rows


        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //     objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


        StringBuilder sb = new StringBuilder();
        string strHtml ="";
        //add header row
        //strHtml += "";
       
        int COUNT = 0;
        for (int intRowBodyCount = Rowstart; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            if (COUNT == 20)
            {
                break;
            }


            strHtml += "<tr  >";
            int intage = 0;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                DateTime dateExDate = DateTime.MinValue;
                string strCurrentDate = objBusiness.LoadCurrentDateInString();
                DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                if (intColumnBodyCount == 0)
                {
                 
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }
            strHtml += "</tr>";
        }

  
        sb.Append(strHtml);
        return sb.ToString();
    }
}