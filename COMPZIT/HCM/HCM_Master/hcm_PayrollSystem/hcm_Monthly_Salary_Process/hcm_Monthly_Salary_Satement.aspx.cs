using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
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


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Satement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayerSalaryStatement objBusinessSalarySatement = new clsBusinessLayerSalaryStatement();
        clsEntityLayerSalaryStatement objEntitySalarySatement = new clsEntityLayerSalaryStatement();
        clsCommonLibrary objCommon = new clsCommonLibrary();
       
        if (Request.UrlReferrer != null)
        {
            string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
            string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
            if (previousPageName == "hcm_Monthly_Salary_Process_List.aspx" || previousPageName == "hcm_Payment_Closing_Process_List.aspx")
            {
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

                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityIntervewProcess.CorpOffice_Id);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
                }

                DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

                string strprint = ConvertDataTableForPrint(dtCorp);
                divPrintCaption.InnerHtml = strprint;

                if (Request.QueryString["SaveOrConf"] == "SAVE")
                    idPageHead.InnerHtml = "Monthly Salary Statement(Draft)";
                else
                    idPageHead.InnerHtml = "Monthly Salary Statement";
                

                if (Session["SALARPRSS"] != null)
                {
                    var strSALARPRSS = Session["SALARPRSS"];
                    string[] StrProssId = strSALARPRSS.ToString().Split('~');
                    int intSaveOrConf = Convert.ToInt32(StrProssId[0]);
                    HiddenFieldListMode.Value = StrProssId[0];
                    int intCorpdepId = Convert.ToInt32(StrProssId[1]);
                    int intstaffWrk = Convert.ToInt32(StrProssId[2]);
                    if (StrProssId[3] != "0" && StrProssId[3] != "" && StrProssId[3] != null)
                    {
                        DateTime dtdate = objCommon.textToDateTime(StrProssId[3]);
                        hiddenDate.Value = dtdate.ToString();
                        objEntitySalarySatement.date = dtdate;
                    }
                    int intCorpId = 0;
                    int intOrgid = 0;

                    objEntitySalarySatement.CorpOffice = Convert.ToInt32(intCorpdepId);
                    if (Session["ORGID"] != null)
                    {
                        intOrgid = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    if (Session["CORPOFFICEID"] != null)
                    {
                        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    //objEntitySalarySatement.SavConf = Convert.ToInt32(intSaveOrConf);
                    //objEntitySalarySatement.CorpOffice = Convert.ToInt32(intCorpdepId);
                    //objEntitySalarySatement.StffWrkr = Convert.ToInt32(intstaffWrk);                   
                    //objEntitySalarySatement.Month = Convert.ToInt32(StrProssId[4]);
                    //objEntitySalarySatement.Year = Convert.ToInt32(StrProssId[5]);
                    //objEntitySalarySatement.Orgid = intOrgid;
                    //objEntitySalarySatement.CorpID = intCorpId;
                    //DataTable dtorglist = objBusinessSalarySatement.LoadSalaryPrssListPrssTable(objEntitySalarySatement);
                    //DataTable dtAllownce1 = objBusinessSalarySatement.ReadAllwnc(objEntitySalarySatement);
                    //DataTable dtDeduction1 = objBusinessSalarySatement.ReadDedctn(objEntitySalarySatement);
                    
                }
            }
        }
    }



    public string ConvertDataTableForPrint(DataTable dtCorp)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Monthly Salary Statement";
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
        string strCaptionTabstop = "</table>";

        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        return sbCap.ToString();
    }
}
    

   
