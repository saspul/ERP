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
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class GMS_Reports_Rep_Client_Gurantees_Rep_Client_Gurantees : System.Web.UI.Page
{

    clsBusinessLayerGmsReports ObjBussinessReports = new clsBusinessLayerGmsReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divTitle.InnerHtml = "Client Guarantee";
            clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
            ReadDivision();
            ReadClients();
            CurrencyLoad();
            ddlDivision.Focus();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableSuplier = 0, intEnableClient = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
            clsEntityReports objEntityReports = new clsEntityReports(); 
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Expired_Guarantee);
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
                        // HiddenFieldSuplier.Value = intEnableSuplier.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenFieldClient.Value = intEnableClient.ToString();

                    }


                }

                //if (intEnableSuplier == 0 && intEnableClient == 0)
                //{
                //    ddlGCatagry.Enabled = false;

                //}
                //else if (intEnableSuplier == 0)
                //{
                //    ddlGCatagry.Items.Remove(ddlGCatagry.Items[1]);
                //    ddlGCatagry.Items.Remove(ddlGCatagry.Items[0]);
                //}
                //else if (intEnableClient == 0)
                //{
                //    ddlGCatagry.Items.Remove(ddlGCatagry.Items[2]);
                //    ddlGCatagry.Items.Remove(ddlGCatagry.Items[0]);
                //}

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    objEntityReports.Corporate_Id = intCorpId;

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    objEntityReports.Organisation_Id = ObjEntityBankGuarantee.Organisation_Id;
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                clsBusinessLayer objBusiness = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                                clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               };

                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    // hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }

                clsEntityCommon objEntityCommon = new clsEntityCommon();
                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                DataTable dtCurrencyDetail = new DataTable();
                dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
                if (dtCurrencyDetail.Rows.Count > 0)
                {
                    hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                }
                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;
                    string[] strSearchFields = strHidden.Split(',');
                    //  string[] strSearchFields = strHidden.Split(',');
                    string strDivision = strSearchFields[0];
                    string strclient = strSearchFields[1];

                    // string strCntrctrType = strSearchFields[3];



                    if (strDivision != null && strDivision != "")
                    {
                        if (ddlDivision.Items.FindByValue(strDivision) != null)
                        {
                            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                            {
                                ddlDivision.ClearSelection();
                                ddlDivision.Items.FindByValue(strDivision).Selected = true;
                                ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(strDivision);
                            }
                        }
                    }

                    if (strclient != null && strclient != "")
                    {
                        if (Ddlclient.Items.FindByValue(strclient) != null)
                        {
                            if (Ddlclient.SelectedItem.Value != "--SELECT CLIENT--")
                            {
                                Ddlclient.ClearSelection();
                                Ddlclient.Items.FindByValue(strclient).Selected = true;
                                ObjEntityBankGuarantee.GuaranteeTempID = Convert.ToInt32(strclient);
                            }
                        }
                    }

                }






                if (HiddenSearchField.Value == "")
                {

                    ObjEntityBankGuarantee.Division_Id = 0;
                    ObjEntityBankGuarantee.GuaranteeTempID = 0;
                }
                else
                {
                    string strHidden = "";
                    strHidden = HiddenSearchField.Value;


                    HiddenSearchField.Value = strHidden;
                    string[] strSearchFields = strHidden.Split(',');
                    //  string[] strSearchFields = strHidden.Split(',');
                    string strDivision = strSearchFields[0];
                    string strclient = strSearchFields[1];

                    if (strDivision != null && strDivision != "")
                    {
                        if (ddlDivision.Items.FindByValue(strDivision) != null)
                        {
                            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                            {
                                ddlDivision.ClearSelection();
                                ddlDivision.Items.FindByValue(strDivision).Selected = true;
                                ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(strDivision);
                            }
                        }
                    }

                    if (strclient != null && strclient != "")
                    {
                        if (Ddlclient.Items.FindByValue(strclient) != null)
                        {
                            if (Ddlclient.SelectedItem.Value != "--SELECT CLIENT--")
                            {
                                Ddlclient.ClearSelection();
                                Ddlclient.Items.FindByValue(strclient).Selected = true;
                                ObjEntityBankGuarantee.GuaranteeTempID = Convert.ToInt32(strclient);
                            }
                        }
                    }


                }
                ObjEntityBankGuarantee.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                DataTable dtBankGurante = new DataTable();
                //if (ddlGCatagry.SelectedItem.Value == "--SELECT GUARANTEE METHOD--")
                //{
                //    dtBankGurante = null;
                //}
                //else
                //{
                dtBankGurante = ObjBussinessReports.ReadClientGurntyReprtList(ObjEntityBankGuarantee);
                //}

                string strHtm = ConvertDataTableToHTML(dtBankGurante);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
                string strPrintReport = ConvertDataTableForPrint(dtBankGurante, dtCorp);
               
                divPrintReport.InnerHtml = strPrintReport;




            }
        }


    }
    public void ReadClients()
    {

        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtclients = ObjBussinessReports.Read_Client(ObjEntityBankGuarantee);
        if (dtclients.Rows.Count > 0)
        {
            Ddlclient.DataSource = dtclients;
            Ddlclient.DataTextField = "CSTMR_NAME";
            Ddlclient.DataValueField = "CSTMR_ID";
            Ddlclient.DataBind();

        }

        Ddlclient.Items.Insert(0, "--SELECT CLIENT--");
    }
    public void ReadDivision()
    {

        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdivision = ObjBussinessReports.ReadDivision(ObjEntityBankGuarantee);
        if (dtdivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
      
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:17%;text-align: left; word-wrap:break-word;\">GUARANTEE REF#</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: left; word-wrap:break-word;\">CLIENT NAME</th>";
            }
            //else if (intColumnHeaderCount == 3)
            //{
            //    strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">GUARANTEE MODE</th>";
            //}
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }
        
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">GUARANTEE CATEGORY</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">BANK</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:11%;text-align: left; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            //EVM-0024
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
               
            }
            //END
        }





        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 0;
        lblToalRowCount.Text = "0";
        if ((Ddlclient.SelectedItem.Text != "--SELECT CLIENT--") || (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") )
        {
            lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {


                strHtml += "<tr  >";
                count++;
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                //int intage = 0;
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    //DateTime dateExDate = DateTime.MinValue;
                    //  string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    // DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE_REF_NUM"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        string hiddenDate = "";
                        if (dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() != null)
                        {
                            string[] arr = new string[3];
                            arr = dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString().Split('-');
                            hiddenDate = arr[2] + arr[1] + arr[0];
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + hiddenDate + "</span>" + dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                        }
                    }
                    //else if (intColumnBodyCount == 3)
                    //{
                    //    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    //}
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:10%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_REF_NUMBER"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 4)
                    {
                        string hiddenDate = "";
                        if (dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() != null)
                        {
                            string[] arr = new string[3];
                            arr = dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString().Split('-');
                            hiddenDate = arr[2] + arr[1] + arr[0];
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:8%;;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + hiddenDate + "</span>" + dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";
                        //dateExDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                        //intage = Convert.ToInt32((dateCurrntdte - dateExDate).TotalDays);
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 8)
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + " </td>";


                    }
                    //EVM_0024
                    else if (intColumnBodyCount == 9)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:7%;;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                    //END
                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;








                strHtml += "</tr>";
            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }



    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();  
        //Creating objects for business layer

        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        if (HiddenSearchField.Value == "")
        {
            ObjEntityBankGuarantee.GuaranteeTempID = 0;
            ObjEntityBankGuarantee.Division_Id = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;



            string[] strSearchFields = strHidden.Split(',');
            //  string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strclient = strSearchFields[1];




            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }
            if (strclient != null && strclient != "")
            {
                if (Ddlclient.Items.FindByValue(strclient) != null)
                {
                    if (Ddlclient.SelectedItem.Value != "--SELECT CLIENT--")
                    {
                        Ddlclient.ClearSelection();
                        Ddlclient.Items.FindByValue(strclient).Selected = true;
                        ObjEntityBankGuarantee.GuaranteeTempID = Convert.ToInt32(strclient);
                    }
                }
            }


        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityBankGuarantee.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        DataTable dtBankGurante = new DataTable();
        dtBankGurante = ObjBussinessReports.ReadClientGurntyReprtList(ObjEntityBankGuarantee);




        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Expired_Guarantee);
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

            }
        }

        string strHtm = ConvertDataTableToHTML(dtBankGurante);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);        //emp17
        string strPrintReport = ConvertDataTableForPrint(dtBankGurante, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }


    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
         objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Client Wise Guarantee Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
       // string TotalRowCnt = "<B> Client Wise Total Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "",Client="";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // clsBusinessLayer objBusiness = new clsBusinessLayer();



        if (HiddenSearchField.Value.ToString() != "")
        {
            // string strHidden = "";
            strHidden = HiddenSearchField.Value;



            // string[] strSearchFields = strHidden.Split(',');
            string[] strSearchFields = strHidden.Split(',');
            //  string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strclient = strSearchFields[1];



            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        GuaranteDivsn = "<B>Division  : </B>" + ddlDivision.SelectedItem.Text;
                    }
                }
            }


            if (strclient != null && strclient != "")
            {
                if (Ddlclient.Items.FindByValue(strclient) != null)
                {
                    if (Ddlclient.SelectedItem.Value != "--SELECT CLIENT--")
                    {
                        Ddlclient.ClearSelection();
                        Ddlclient.Items.FindByValue(strclient).Selected = true;
                        Client = "<B>Client  : </B>" + Ddlclient.SelectedItem.Text;

                    }
                }
            }



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
        string strTotalCount = "";


        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (GuaranteDivsn != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        }
        if (Client != "")
        {
            strGuaranteCatgry = "<tr><td class=\"RprtDiv\">" + Client + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        //if (TotalRowCnt != "")
        //{
        //    strTotalCount = "<tr><td class=\"RprtDiv\">" + TotalRowCnt + "</td></tr>";
        //}

        //if (GuaranteCatgry != "")
        //{
        //    strGuaranteCatgry = "<tr><td class=\"RprtDiv\">" + GuaranteCatgry + "</td></tr>";

        //}


        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strUsrName + strGuaranteCatgry+strCaptionTabTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">GUARANTEE REF#</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">CLIENT NAME</th>";
            }
            //else if (intColumnHeaderCount == 3)
            //{
            //    strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">GUARANTEE MODE</th>";
            //}
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }
  
            else if (intColumnHeaderCount ==4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">EXPIRED DATE</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">GUARANTEE CATEGORY</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">BANK</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows
        decimal totalAmount = 0;
        string CurrencyName = "";
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<td class=\"thT\"colspan=11 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";

        }
        else
        {
            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CRNCMST_ABBRV"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };
            if ((Ddlclient.SelectedItem.Text != "--SELECT CLIENT--") || (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--"))
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    count++;
                    strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                    // int intage = 0;
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        // DateTime dateExDate = DateTime.MinValue;
                        //string strCurrentDate = objBusiness.LoadCurrentDateInString();
                        // DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                        if (intColumnBodyCount == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE_REF_NUM"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + "</td>";
                        }
                        //else if (intColumnBodyCount == 3)
                        //{
                        //    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        //}
                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:12%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_REF_NUMBER"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 8)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";
                            if (totalAmount == 0)
                            {
                                totalAmount = Convert.ToDecimal(strNetAmount);
                            }
                            else
                            {
                                totalAmount = totalAmount + Convert.ToDecimal(strNetAmount);
                            }

                        }
                        else if (intColumnBodyCount == 9)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            CurrencyName = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();

                        }
                    }
                    strHtml += "</tr>";
                }
                foreach (var row in result)
                {
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<tfoot>";
                    strHtml += "<td  class=\"tdT\" colspan=\"9\"; style=\"border-right-color: white;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
                    string strtotalAmount = "";
                    strtotalAmount = Convert.ToString(row.Sum);
                    string strTotal = objBusiness.AddCommasForNumberSeperation(strtotalAmount, objEntityCommon);
                    strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strTotal + "</td>";
                    strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: left;border-left-color: white;\" >" + row.Group + "</td>";
                    strHtml += "</tfoot>";
                }
            }
            else
            {
                strHtml += "<tr id=\"TableRprtRow\" >";
                strHtml += "<tfoot>";
                strHtml += "<td  class=\"tdT\" colspan=\"11\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
                //string stamt = sum2.ToString();
                //string strNetAmo = objBusiness.AddCommasForNumberSeperation(stamt, ObjEntityCommon);


                strHtml += "</tfoot>";
            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

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
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (HiddenSearchField.Value == "")
        {
            ObjEntityBankGuarantee.GuaranteeTempID = 0;
            ObjEntityBankGuarantee.Division_Id = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strclient = strSearchFields[1];
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }
            if (strclient != null && strclient != "")
            {
                if (Ddlclient.Items.FindByValue(strclient) != null)
                {
                    if (Ddlclient.SelectedItem.Value != "--SELECT CLIENT--")
                    {
                        Ddlclient.ClearSelection();
                        Ddlclient.Items.FindByValue(strclient).Selected = true;
                        ObjEntityBankGuarantee.GuaranteeTempID = Convert.ToInt32(strclient);
                    }
                }
            }
        }
        if (Session["USERID"] != null)
        {
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityBankGuarantee.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        DataTable dt = new DataTable();
        dt = ObjBussinessReports.ReadClientGurntyReprtList(ObjEntityBankGuarantee);
        DataTable table = new DataTable();
        table.Columns.Add("GUARANTEE REF#", typeof(string));
        table.Columns.Add("DATE", typeof(string));
        table.Columns.Add("CLIENT NAME", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add("GUARANTEE CATEGORY", typeof(string));
        table.Columns.Add("BANK", typeof(string));
        table.Columns.Add("JOB CODE", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));
        if ((Ddlclient.SelectedItem.Text != "--SELECT CLIENT--") || (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--"))
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string DATE = "";
                string CUSTOMER = "";
                string PROJECT = "";
                string EXPIRED = "";
                string JOB = "";
                string AMOUNT = "";
                string CURRENCY = "";
                string REf = "";
                string BANK = "";
                string CATEGORY = "";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 0)
                    {
                        REf = dt.Rows[intRowBodyCount]["GUARANTEE_REF_NUM"].ToString();
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString() != null)
                        {
                            DATE = dt.Rows[intRowBodyCount]["GUARANTEE_DATE"].ToString();

                        }

                    }
                    else if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["CSTMR_NAME"].ToString();
                        }
                        else
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")";
                        }
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        PROJECT = dt.Rows[intRowBodyCount]["PROJECT_REF_NUMBER"].ToString();
                    }

                    else if (intColumnBodyCount == 4)
                    {
                        if (dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString() != null)
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["GUARANTEE_EXP_DATE"].ToString();
                        }
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        CATEGORY = dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString();
                    }
                    else if (intColumnBodyCount == 6)
                    {
                        BANK = dt.Rows[intRowBodyCount]["BANK"].ToString();
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        JOB = dt.Rows[intRowBodyCount]["JOB CODE"].ToString();
                    }
                    else if (intColumnBodyCount == 8)
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        AMOUNT = strNetAmountWithComma;
                    }
                    else if (intColumnBodyCount == 9)
                    {
                        CURRENCY = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                }
                table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + CUSTOMER + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + CATEGORY + '"', '"' + BANK + '"', '"' + JOB + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
            }
        }
        return table;
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CLIENTGRANTEE_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/GMS CSV/Client Guarantee/Client_Wise_Guarantee_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Client_Wise_Guarantee_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLENT_GRANTEE_CSV);
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
    public void CurrencyLoad()
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessLayerReports.ReadCurrency(objEntityReports);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
        }
        DataTable dtDefaultcurc = objBusinessLayerReports.ReadDefualtCurrency(objEntityReports);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
}