using System;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using EL_Compzit;
using System.IO;

// CREATED BY:EVM-0020
// CREATED DATE:11/07/2017
// REVIEWED BY:
// REVIEW DATE:
public partial class HCM_HCM_Reports_hcm_VisaQuota_Status_Report_hcm_VisaQuota_Status_Report : System.Web.UI.Page
{
    clsBusinessVisaQuotaStatusReport objBusinessVisaQuota = new clsBusinessVisaQuotaStatusReport();

    //EVM-0027
   public int intUserId = 0, intUsrRolMstrId, intEnableHRallocation, intEnableAllBuint = 0;
    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    clsCommonLibrary objCommon = new clsCommonLibrary();
         
    
    //END
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            ddlBusUnit.Focus();
            BussnsUnitLoad();
            SelectNationsLoad();
            VisaTypLoad();
            LoadBundleNumber();
            HiddenBundleNo.Value = "0";
            HiddenNation.Value = "0";
            HiddenGender.Value = "0";
            HiddenProfession.Value = "0";
            HiddenHr.Value = "0";
            HiddenAllDivision.Value = "0";
           
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                hiddenUserId.Value = intUserId.ToString();

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                        objEntityVisaQuota.HrManager = intEnableHRallocation;
                        HiddenHr.Value = intEnableHRallocation.ToString();
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                        objEntityVisaQuota.HrManager = intEnableAllBuint;
                        HiddenAllDivision.Value = intEnableAllBuint.ToString();
                    }

                }
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVisaQuota.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityVisaQuota.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityVisaQuota.UserId = Convert.ToInt32(Session["USERID"].ToString());
                hiddenUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (intEnableAllBuint != 0)
            {
                if (ddlBusUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
                {
                    objEntityVisaQuota.BussnsId = Convert.ToInt32(ddlBusUnit.SelectedItem.Value);
                }
            }
            if (intEnableAllBuint != 0)
            {
                objEntityVisaQuota.BussUnit = 1;
            }
            if (ddlBundleNumber.SelectedItem.Value != "--SELECT BUNDLE NUMBER--")
            {
                objEntityVisaQuota.VisaBundleNo = Convert.ToString(ddlBundleNumber.SelectedItem.Value);
            }
            if (ddlVisTyp.SelectedItem.Value != "--SELECT VISA PROFESSION--")
            {
                objEntityVisaQuota.VisaTypeId = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
            }
            if (ddlNation.SelectedItem.Value != "--SELECT NATION--")
            {
                objEntityVisaQuota.CountryId = Convert.ToInt32(ddlNation.SelectedItem.Value);
            }
            if (RadioButtonMale.Checked == true)
            {
                objEntityVisaQuota.Gender = 0;
            }
            else
            {
                objEntityVisaQuota.Gender = 1;
            }
            DataTable dtCorp = objBusinessVisaQuota.ReadCorporateAddress(objEntityVisaQuota);
            objEntityVisaQuota.CorpId = 0;
            objEntityVisaQuota.OrgId = 0;
            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessVisaQuota.ReadVisaQuotaStatus(objEntityVisaQuota);

            string strHtm = ConvertDataTableToHTML(dtManpwr);
          divReport.InnerHtml = strHtm;

          string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
          divPrintReport.InnerHtml = strPrintReport;
         
        }

    }
    public void VisaTypLoad()
    {
        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessVisaQuota.ReadVisaTyp(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlVisTyp.DataSource = dtSubConrt;
            ddlVisTyp.DataTextField = "VISA_NAME";
            ddlVisTyp.DataValueField = "VISATYP_ID";
            ddlVisTyp.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlVisTyp.Items.Insert(0, "--SELECT VISA PROFESSION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    public void LoadBundleNumber()
    {
        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessVisaQuota.ReadBundleNumber(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlBundleNumber.DataSource = dtSubConrt;
            ddlBundleNumber.DataTextField = "BUNDLE NUMBER";
            ddlBundleNumber.DataValueField = "VISQT_ID";
            ddlBundleNumber.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlBundleNumber.Items.Insert(0, "--SELECT BUNDLE NUMBER--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    public void SelectNationsLoad()
    {
        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessVisaQuota.ReadSelectNations(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlNation.DataSource = dtSubConrt;
            ddlNation.DataTextField = "CNTRY_NAME";
            ddlNation.DataValueField = "CNTRY_ID";
            ddlNation.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlNation.Items.Insert(0, "--SELECT NATION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    public void BussnsUnitLoad()
    {
        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();
        string strcorp = "";
        //int intUserId , intUsrRolMstrId, intEnableHRallocation = 0, intEnableAllBuint = 0;
        intUserId = Convert.ToInt32(Session["USERID"]); 
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            int CoprId = Convert.ToInt32(Session["CORPOFFICEID"]);
            strcorp = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]); 
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);

        //Allocating child roles

        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableHRallocation;
                    HiddenHr.Value = intEnableHRallocation.ToString();
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                {
                    intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableAllBuint;
                    HiddenAllDivision.Value = intEnableAllBuint.ToString();
                }


            }
        }


  


        if (intEnableAllBuint == 1)
        {
            DataTable dtSubConrt = objBusinessVisaQuota.ReadBussnsUnit(objEntityVisQuotInfo);
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlBusUnit.DataSource = dtSubConrt;
                ddlBusUnit.DataTextField = "CORPRT_NAME";
                ddlBusUnit.DataValueField = "CORPRT_ID";
                ddlBusUnit.DataBind();

            }
        }
        else
        {
            objEntityVisaQuota.BussUnit = 1;
        }
        //END

        ddlBusUnit.Items.Insert(0, "--SELECT BUSINESS UNIT--");
        
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        //int intUserId = 0, intUsrRolMstrId, intEnableHRall = 0, intEnableAllBuint = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);

        //Allocating child roles

        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableHRallocation;
                    HiddenHr.Value = intEnableHRallocation.ToString();
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                {
                    intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableAllBuint;
                    HiddenAllDivision.Value = intEnableAllBuint.ToString();
                }

            }
        }





        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">BUNDLE NUMBER</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROFESSION</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">NATIONALITY</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">GENDER</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">TOTAL NUMBER OF VISA</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA ALLOTTED</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA AVAILABLE</th>";
            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (intEnableHRallocation == 1)
        {
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";


            string strId = dt.Rows[intRowBodyCount][0].ToString();

          

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISQT_NUM"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISA_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        int gender = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_GENDER"]);
                        string strGender = "";
                        if (gender == 0)
                        {
                            strGender = "MALE";
                        }
                        else
                        {
                            strGender = "FEMALE";
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strGender + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        int COUNT3 = COUNT1 - Count;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (COUNT3 <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = COUNT3.ToString();
                        }




                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strCount + "</td>";
                  
                    }
                    if (intColumnBodyCount == 7)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (Count <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = Count.ToString();
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strCount + "</td>";


                       }
                }


               
            strHtml += "</tr>";
        } 
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }





  

  
    //EVM-0027
    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();

        int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);
        int intUserId = Convert.ToInt32(hiddenUserId.Value);

        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisQuotInfo.HrManager = intEnableHRallocation;
                    HiddenHr.Value = intEnableHRallocation.ToString();
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                {
                    intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisQuotInfo.HrManager = intEnableAllBuint;
                    HiddenAllDivision.Value = intEnableAllBuint.ToString();
                }

            }
        }

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Visa Quota Status Report";
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
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">BUNDLE NUMBER</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROFESSION</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">NATIONALITY</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">GENDER</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">TOTAL NUMBER OF VISA</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA ALLOTTED</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA AVAILABLE</th>";
            }
        }

        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">BUNDLE NUMBER</th>";
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROFESSION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">NATIONALITY</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">GENDER</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">TOTAL NUMBER OF VISA</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA ALLOTTED</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">NUMBER OF VISA AVAILABLE</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (intEnableHRallocation == 1)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISQT_NUM"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISA_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        int gender = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_GENDER"]);
                        string strGender = "";
                        if (gender == 0)
                        {
                            strGender = "MALE";
                        }
                        else
                        {
                            strGender = "FEMALE";
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strGender + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        int COUNT3 = COUNT1 - Count;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (COUNT3 <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = COUNT3.ToString();
                        }




                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strCount + "</td>";
                      
                    }
                    if (intColumnBodyCount == 7)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());


                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (Count <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = Count.ToString();
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strCount + "</td>";
                    }
                }

                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

    }

//END

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intEnableAllBuint = 0;
        clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);

        //Allocating child roles

        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        //if (dtChildRol.Rows.Count > 0)
        //{
        //    string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

        //    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
        //    foreach (string strC_Role in strChildDefArrWords)
        //    {
        //        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
        //        {
        //            intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        //            //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
        //            objEntityVisaQuota.HrManager = intEnableHRallocation;
        //            HiddenHr.Value = intEnableHRallocation.ToString();
        //        }
        //        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
        //        {
        //            intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        //            //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
        //            objEntityVisaQuota.HrManager = intEnableAllBuint;
        //            HiddenAllDivision.Value = intEnableAllBuint.ToString();
        //        }

        //    }
        //}
        if (intEnableAllBuint != 0)
        {

            if (ddlBusUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
            {

                objEntityVisaQuota.BussnsId = Convert.ToInt32(ddlBusUnit.SelectedItem.Value);
            }
        }
        else
        {
            objEntityVisaQuota.BussUnit = 0;
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            hiddenUserId.Value = intUserId.ToString();

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();


        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisaQuota.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisaQuota.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityVisaQuota.UserId = Convert.ToInt32(Session["USERID"].ToString());
            hiddenUserId.Value = Session["USERID"].ToString();
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //EVM_0027
      


        //END

      


        if (ddlBundleNumber.SelectedItem.Value != "--SELECT BUNDLE NUMBER--")
        {
            objEntityVisaQuota.VisaBundleNo = Convert.ToString(ddlBundleNumber.SelectedItem.Value);
            HiddenBundleNo.Value = objEntityVisaQuota.VisaBundleNo;
        }
        else
            HiddenBundleNo.Value = "0";
        if (ddlVisTyp.SelectedItem.Value != "--SELECT VISA PROFESSION--")
        {
            objEntityVisaQuota.VisaTypeId = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
            HiddenProfession.Value = ddlVisTyp.SelectedItem.Value;
        }
        else
            HiddenProfession.Value = "0";
        if (ddlNation.SelectedItem.Value != "--SELECT NATION--")
        {
            objEntityVisaQuota.CountryId = Convert.ToInt32(ddlNation.SelectedItem.Value);
            HiddenNation.Value = ddlNation.SelectedItem.Value;
        }
        HiddenNation.Value = "0";
        if (RadioButtonMale.Checked == true)
        {
            objEntityVisaQuota.Gender = 0;
            HiddenGender.Value = "0";
        }
        else
        {
            objEntityVisaQuota.Gender = 1;
            HiddenGender.Value = "1";
        }

        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessVisaQuota.ReadVisaQuotaStatus(objEntityVisaQuota);

        string strHtm = ConvertDataTableToHTML(dtManpwr);
        divReport.InnerHtml = strHtm;
        //EVM--0027
        DataTable dtCorp = objBusinessVisaQuota.ReadCorporateAddress(objEntityVisaQuota);
        string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
        //END
    }
    [WebMethod]
    public static string[] VisaQuotaDetailsPrint(string intCorpId, string intOrgId, string BundileNo, string Profession, string Nation, string Gender)
    {
        string[] strJsonPrint = new string[30];

        //clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
        //clsBusinessVisaQuotaStatusReport objBusinessVisaQuota = new clsBusinessVisaQuotaStatusReport();



        //objEntityVisaQuota.CorpId =Convert.ToInt32(intCorpId);

        //objEntityVisaQuota.OrgId = Convert.ToInt32(intOrgId);
        //if (BundileNo != "0")
        //{
        //    objEntityVisaQuota.VisaBundleNo = BundileNo;
        //}
        //if (Profession != "0")
        //{
        //    objEntityVisaQuota.VisaTypeId = Convert.ToInt32(Profession);
        //}
        //if (Nation != "0")
        //{
        //    objEntityVisaQuota.CountryId = Convert.ToInt32(Nation);
        //}
        //objEntityVisaQuota.Gender = Convert.ToInt32(Gender);
        //DataTable dtCorp = new DataTable();
        //dtCorp = objBusinessVisaQuota.ReadCorporateAddress(objEntityVisaQuota);

        //string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        //clsBusinessLayer objBusiness = new clsBusinessLayer();
        //string strTitle = "";
        //strTitle = "Manpower Requirement status Details";
        //DateTime datetm = DateTime.Now;
        //string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //if (dtCorp.Rows.Count > 0)
        //{
        //    strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
        //    strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
        //    strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
        //    strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
        //    strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        //}
        //clsCommonLibrary objClsCommon = new clsCommonLibrary();
        //string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        //StringBuilder sbCap = new StringBuilder();
        //string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        //string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        //string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        //string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        //string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        //string strCaptionTabstop = "</table>";
        //string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;

        //sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaptionDetails
        //strJsonPrint[0] = sbCap.ToString();

        //string[] strJson = new string[30];
        //DataTable dtVisaQuota = new DataTable();
        //dtVisaQuota = objBusinessVisaQuota.ReadVisaQuotaStatus(objEntityVisaQuota);
        ////strJson[1] = dtVisaQuota.Rows[0]["MNP_REFNUM"].ToString().ToUpper();
        ////strJson[2] = dtVisaQuota.Rows[0]["APPROVE_DATE"].ToString();
        ////strJson[3] = dtVisaQuota.Rows[0]["USR_NAME"].ToString();
        ////strJson[4] = dtVisaQuota.Rows[0]["RQNTALCT_INS_DATE"].ToString();
        ////strJson[5] = dtVisaQuota.Rows[0]["PROJECT_NAME"].ToString();
        ////strJson[6] = dtVisaQuota.Rows[0]["MNP_APPRVL2_DATE"].ToString();

        //StringBuilder sbCapMnpwrDtls = new StringBuilder();
       
        //    string strMnpwrstart = "<table>";
            
           
        //    //  string strResrc = "<tr><td>Approved Date   : " + strJson[2] + "</td></tr>";
        //    // string strDiv = "<tr><td>Assigned To : " + strJson[3] + "</td></tr>";
        //    // string strDsgntn = "<tr><td>Assigned Date : " + strJson[4] + "</td></tr>";
        //    //string strproject = "<tr><td>Project : " + strJson[5] + "</td></tr>";
        //    string strprint = "";

        //    sbCapMnpwrDtls.Append(strprint);
        //    //write to  lblPrintOnBrdDtls

        //    strJsonPrint[1] = sbCapMnpwrDtls.ToString();
        //    StringBuilder sb = new StringBuilder();
        //    string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //    //add header row
        //    strHtml += "<thead>";
        //    strHtml += "<tr class=\"top_row\">";
        //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtVisaQuota.Columns.Count; intColumnHeaderCount++)
        //    {
        //        if (intColumnHeaderCount == 1)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Bundle Number</th>";
        //        }
        //        if (intColumnHeaderCount == 2)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">Profession</th>";
        //        }
        //        if (intColumnHeaderCount == 3)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">Nationality</th>";
        //        }
        //        if (intColumnHeaderCount == 4)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">Gender</th>";
        //        }
        //        if (intColumnHeaderCount == 5)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">Total No. Of Visa</th>";
        //        }
        //        if (intColumnHeaderCount == 6)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">No. Of Visa Allotted</th>";
        //        }
        //        if (intColumnHeaderCount == 7)
        //        {
        //            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">No. Of Visa Available</th>";
        //        }
        //    }
        //    if (dtVisaQuota.Columns.Count == 0)
        //    {
        //        strHtml += "<td class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">Bundle Number</th>";
        //        strHtml += "<td class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">Profession</th>";
        //        strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Nationality To</th>";
        //        strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Gender</th>";
        //        strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Total No. Of Visa</th>";
        //        strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">No. Of Visa Allotted</th>";
        //        strHtml += "<td class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">No. Of Visa Available</th>";
        //    }
        //    strHtml += "</tr>";
        //    strHtml += "</thead>";
        //    //add rows

        //    strHtml += "<tbody>";
        //    string status = "";
        //    for (int intRowBodyCount = 0; intRowBodyCount < dtVisaQuota.Rows.Count; intRowBodyCount++)
        //    {
        //        strHtml += "<tr  >";


        //        string strId = dtVisaQuota.Rows[intRowBodyCount][0].ToString();


        //        for (int intColumnBodyCount = 0; intColumnBodyCount < dtVisaQuota.Columns.Count; intColumnBodyCount++)
        //        {

        //            if (intColumnBodyCount == 1)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtVisaQuota.Rows[intRowBodyCount]["VISQT_NUM"].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 2)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaQuota.Rows[intRowBodyCount]["VISA_NAME"].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 3)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaQuota.Rows[intRowBodyCount]["CNTRY_NAME"].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 4)
        //            {
        //                int gender = Convert.ToInt32(dtVisaQuota.Rows[intRowBodyCount]["VISQT_DTLS_GENDER"]);
        //                string strGender = "";
        //                if (gender == 0)
        //                {
        //                    strGender = "MALE";
        //                }
        //                else
        //                {
        //                    strGender = "FEMALE";
        //                }
        //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + strGender + "</td>";
        //            }
        //            if (intColumnBodyCount == 5)
        //            {


        //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaQuota.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 6)
        //            {
        //                string strCount = "";

        //                objEntityVisaQuota.VisaTypeId = Convert.ToInt32(dtVisaQuota.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
        //                DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisaQuota);

        //                int COUNT1 = Convert.ToInt32(dtVisaQuota.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
        //                int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
        //                int Count = COUNT1 - COUNT2;
        //                // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
        //                if (Count <= 0)
        //                {
        //                    strCount = " 0";
        //                }
        //                else
        //                {
        //                    strCount = Count.ToString();
        //                }
        //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + strCount + "</td>";
        //            }
        //            if (intColumnBodyCount == 7)
        //            {
        //                string strCount = "";

        //                objEntityVisaQuota.VisaTypeId = Convert.ToInt32(dtVisaQuota.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
        //                DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisaQuota);

        //                int COUNT1 = Convert.ToInt32(dtVisaQuota.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
        //                int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
        //                int Count = COUNT1 - COUNT2;
        //                int COUNT3 = COUNT1 - Count;
        //                // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
        //                if (COUNT3 <= 0)
        //                {
        //                    strCount = " 0";
        //                }
        //                else
        //                {
        //                    strCount = COUNT3.ToString();
        //                }




        //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + strCount + "</td>";
        //            }
        //        }



        //        strHtml += "</tr>";
        //    }
        //    if (dtVisaQuota.Rows.Count == 0)
        //    {
        //        strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        //    }

        //    strHtml += "</tbody>";

        //    strHtml += "</table>";

            //sb.Append(strHtml);
            //strJsonPrint[2] = sb.ToString();


            return strJsonPrint;
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VISA_QUOTA_STATUS_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/VisaQuoata_Staus/VisaQuotaStatus_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "VisaQuotaStatus_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VISA_QUOTA_STATUS_RPRT_CSV);
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

        table.Columns.Add("BUNDLE NUMBER", typeof(string));
        table.Columns.Add("PROFESSION", typeof(string));
        table.Columns.Add("NATIONALITY", typeof(string));
        table.Columns.Add("GENDER", typeof(string));
        table.Columns.Add("TOTAL NUMBER OF VISA", typeof(string));
        table.Columns.Add("NUMBER OF VISA ALLOTTED", typeof(string));
        table.Columns.Add("NUMBER OF VISA AVAILABLE", typeof(string));

      
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            hiddenUserId.Value = intUserId.ToString();

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);


        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);


        if (intEnableAllBuint != 0)
        {

            if (ddlBusUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
            {

                objEntityVisaQuota.BussnsId = Convert.ToInt32(ddlBusUnit.SelectedItem.Value);
            }
        }
        else
        {
            objEntityVisaQuota.BussUnit = 0;
        }
        //clsEntityVisaQuotaStatusReport objEntityVisaQuota = new clsEntityVisaQuotaStatusReport();


        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisaQuota.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisaQuota.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityVisaQuota.UserId = Convert.ToInt32(Session["USERID"].ToString());
            hiddenUserId.Value = Session["USERID"].ToString();
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //EVM_0027



        //END




        if (ddlBundleNumber.SelectedItem.Value != "--SELECT BUNDLE NUMBER--")
        {
            objEntityVisaQuota.VisaBundleNo = Convert.ToString(ddlBundleNumber.SelectedItem.Value);
            HiddenBundleNo.Value = objEntityVisaQuota.VisaBundleNo;
        }
        else
            HiddenBundleNo.Value = "0";
        if (ddlVisTyp.SelectedItem.Value != "--SELECT VISA PROFESSION--")
        {
            objEntityVisaQuota.VisaTypeId = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
            HiddenProfession.Value = ddlVisTyp.SelectedItem.Value;
        }
        else
            HiddenProfession.Value = "0";
        if (ddlNation.SelectedItem.Value != "--SELECT NATION--")
        {
            objEntityVisaQuota.CountryId = Convert.ToInt32(ddlNation.SelectedItem.Value);
            HiddenNation.Value = ddlNation.SelectedItem.Value;
        }
        HiddenNation.Value = "0";
        if (RadioButtonMale.Checked == true)
        {
            objEntityVisaQuota.Gender = 0;
            HiddenGender.Value = "0";
        }
        else
        {
            objEntityVisaQuota.Gender = 1;
            HiddenGender.Value = "1";
        }

        DataTable dt = new DataTable();
        dt = objBusinessVisaQuota.ReadVisaQuotaStatus(objEntityVisaQuota);

        //for printing table
        string BundleNo = "";
        string Profession = "";
        string Nationality = "";
        string Gender = "";
        string TotalNmbrOfVisa = "";
        string No_Visa_Alloted = "";
        string No_of_AvailableVisa = "";
      //  string employee = "";
       
        string strRandom = objCommon.Random_Number();

      
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota_Status_Report);

        //Allocating child roles

      
        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableHRallocation;
                    HiddenHr.Value = intEnableHRallocation.ToString();
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                {
                    intEnableAllBuint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //objEntityReqrmntAlct.HrManager = intEnableHRallocation;
                    objEntityVisaQuota.HrManager = intEnableAllBuint;
                    HiddenAllDivision.Value = intEnableAllBuint.ToString();
                }

            }
        }

                clsEntityVisaQuotaStatusReport objEntityVisQuotInfo = new clsEntityVisaQuotaStatusReport();
        StringBuilder sb = new StringBuilder();
      
      
   


        if (intEnableHRallocation == 1)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
               

                string strId = dt.Rows[intRowBodyCount][0].ToString();

          

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        BundleNo = dt.Rows[intRowBodyCount]["VISQT_NUM"].ToString();
                    }
                    if (intColumnBodyCount == 2)
                    {
                        Profession = dt.Rows[intRowBodyCount]["VISA_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 3)
                    {
                        Nationality = dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 4)
                    {
                        int gender = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_GENDER"]);
                        string strGender = "";
                        if (gender == 0)
                        {
                            strGender = "MALE";
                        }
                        else
                        {
                            strGender = "FEMALE";
                        }
                        Gender = strGender;
                    }
                    if (intColumnBodyCount == 5)
                    {

                        TotalNmbrOfVisa = dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString();
                    }
                    if (intColumnBodyCount == 6)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        int COUNT3 = COUNT1 - Count;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (COUNT3 <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = COUNT3.ToString();
                        }


                        No_Visa_Alloted = strCount;


                    }
                    if (intColumnBodyCount == 7)
                    {
                        string strCount = "";
                        objEntityVisQuotInfo.OrgId = Convert.ToInt32(hiddenOrgId.Value);
                        objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                        objEntityVisQuotInfo.VisaTypeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                        DataTable dtVisaCount = objBusinessVisaQuota.ReadCount(objEntityVisQuotInfo);

                        int COUNT1 = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_VISA"].ToString());
                        int COUNT2 = Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        int Count = COUNT1 - COUNT2;
                        // int Count = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                        if (Count <= 0)
                        {
                            strCount = " 0";
                        }
                        else
                        {
                            strCount = Count.ToString();
                        }
                        No_of_AvailableVisa = strCount;


                    }
                }

              
                table.Rows.Add('"' + BundleNo + '"', '"' + Profession + '"', '"' + Nationality + '"', '"' + Gender + '"', '"' + TotalNmbrOfVisa + '"', '"' + No_Visa_Alloted + '"', '"' + No_of_AvailableVisa + '"');

            }
        }


       

        return table;
    }
}





