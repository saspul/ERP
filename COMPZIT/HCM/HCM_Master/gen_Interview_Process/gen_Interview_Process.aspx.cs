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
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Xml;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class HCM_HCM_Master_gen_Interview_Process_gen_Interview_Process : System.Web.UI.Page
{
    clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        divtile.InnerHtml = "Interview Process";
        if (!IsPostBack)
        {
            bindScore();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableClose = 0, intEnableHold = 0, intEnableReopen = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            btnClose.Visible = false;
            btnReopen.Visible = false;
            btnOnHold.Visible = false;


           

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Interview_Process);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        btnClose.Visible = true;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        btnReopen.Visible = true;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString())
                    {
                        intEnableHold = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        btnOnHold.Visible = true;

                    }
                }

                int HoldId = Convert.ToInt32(Request.QueryString["Hld"]);
                HiddenFieldHoldStatus.Value = Request.QueryString["Hld"].ToString();
                if (HoldId == 1)
                {
                   
                    btnOnHold.Visible = false;
                    if (intEnableReopen == 1)
                    {
                        btnReopen.Visible = true;
                    }
                    //btnAdd.Visible = false;
                    //btnClear.Visible = false;
                }
                else
                {
                    if (intEnableHold == 1)
                    {
                        btnOnHold.Visible = true;
                    }
                    btnReopen.Visible = false;
                    //btnAdd.Visible = true;
                    //btnClear.Visible = true;
                }

                if (Session["USERID"] != null)
                {
                    objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    HiddenCorp.Value=Session["CORPOFFICEID"].ToString();

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    HiddenOrg.Value = Session["ORGID"].ToString();
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                HiddenFieldQryString.Value = Request.QueryString["Id"].ToString();

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(strId);

                HiddenFieldReqrmntId.Value = strId;

                DataTable dtReqmntDetails = new DataTable();
                dtReqmntDetails = objBusinessIntervewProcess.ReadRqmntDetails(objEntityIntervewProcess);

                lblRefNum.Text = dtReqmntDetails.Rows[0]["MNP_REFNUM"].ToString().ToUpper(); 
                lblDateOfReq.Text = dtReqmntDetails.Rows[0]["RQST DATE"].ToString().ToUpper();
                lblNumber.Text = dtReqmntDetails.Rows[0]["MNP_RESOURCENUM"].ToString().ToUpper();
                lblDesign.Text = dtReqmntDetails.Rows[0]["DSGN_NAME"].ToString().ToUpper();
                lblDeprtmnt.Text = dtReqmntDetails.Rows[0]["CPRDEPT_NAME"].ToString().ToUpper();
                lblPrjct.Text = dtReqmntDetails.Rows[0]["PROJECT_NAME"].ToString().ToUpper();
                lblExprnce.Text = dtReqmntDetails.Rows[0]["MNP_EXPERIENCE"].ToString().ToUpper()+" Years";
                lblPaygrd.Text = dtReqmntDetails.Rows[0]["PYGRD_NAME"].ToString().ToUpper();


                DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

                DataTable dtShrtlstdCandList = new DataTable();
                dtShrtlstdCandList = objBusinessIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);

                string strHtm = ConvertDataTableToHTML(dtShrtlstdCandList, intEnableAdd, intEnableModify);
                //Write to divReport
                divCandidateList.InnerHtml = strHtm;

                //Write to divReport


                string strPrintReport = ConvertDataTableForPrint(dtReqmntDetails, dtShrtlstdCandList, dtCorp);
                divPrintReport.InnerHtml = strPrintReport;


               

                if (Request.QueryString["CandId"] != null && Request.QueryString["InsUpd"] == null)
                {
                    string qulfd = "false";
                    string strCandId = Request.QueryString["CandId"].ToString();
                    HiddenFieldIns.Value = "ins";
                    ScriptManager.RegisterStartupScript(this, GetType(), "getCandInfo", "getCandInfo(" + strCandId + "," + qulfd + ");", true);
                }
            }


            if (Request.QueryString["InsUpd"] != null)
            {


                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                   
                    string qulfd = "false";

                    clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
                    objEntityIntervewProcess.User_Id = Convert.ToInt32(Request.QueryString["CandId"].ToString());
                    objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
                    //Start:-For checking candidate complete all levels and all are qualified
                    DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
                    DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
                    int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
                    int candQlfiedLvlNo = Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());
                    if (candTotalLvlNo == candQlfiedLvlNo)
                    {
                        qulfd = "true";
                    }



                    string strCandId = Request.QueryString["CandId"].ToString();
                    HiddenFieldIns.Value = "insLvl";
                    ScriptManager.RegisterStartupScript(this, GetType(), "getCandInfo", "getCandInfo(" + strCandId + "," + qulfd + ");", true);
                }
                if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
                if (strInsUpd == "Hold")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessHold", "SuccessHold();", true);
                }
                if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
            }

        }
    }


    public string ConvertDataTableForPrint(DataTable dtReqmntDetails, DataTable dtShrtlstdCandList, DataTable dtCorp)
    {

      //  clsEntityCommon objEntityCommon = new clsEntityCommon();
        //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Interview Process";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //for printing product division on print
        string strHidden = "", RefNum = "", DateRqst = "", NoOfResourse = "", Desgatn = "", Department = "", Project = "", MinExp = "", ExpireDate = "", Paygrd = "";


        if (dtReqmntDetails.Rows.Count>0)
        {





            RefNum = "<B>Ref# : </B>" + dtReqmntDetails.Rows[0]["MNP_REFNUM"].ToString().ToUpper();


            DateRqst = "<B>Date Of Request  : </B>" + dtReqmntDetails.Rows[0]["RQST DATE"].ToString().ToUpper();


            NoOfResourse = "<B>No. Of Resources : </B>" + dtReqmntDetails.Rows[0]["MNP_RESOURCENUM"].ToString().ToUpper();


            Desgatn = "<B>Designation : </B>" + dtReqmntDetails.Rows[0]["DSGN_NAME"].ToString().ToUpper();


            Department = "<B> Department  : </B>" + dtReqmntDetails.Rows[0]["CPRDEPT_NAME"].ToString().ToUpper(); ;


            Project = "<B> Project  : </B>" + dtReqmntDetails.Rows[0]["PROJECT_NAME"].ToString().ToUpper(); ;


            MinExp = "<B> Experience  : </B>" + dtReqmntDetails.Rows[0]["MNP_EXPERIENCE"].ToString().ToUpper() + " Years";

            Paygrd = "<B> Pay Grade  : </B>" + dtReqmntDetails.Rows[0]["PYGRD_NAME"].ToString().ToUpper();

                 
       

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

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
       
        
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr+ "</td></tr>";
        
      //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

       // StringBuilder sbCap = new StringBuilder();



        
       
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "",
            strCustOrSuplTitle = "", strExpireDateTitle = "", strBankIdTitle = "", strGuranteStsTitle = "";

        
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }

        strFromDteTitle = "<tr><td class=\"RprtDiv\">" + RefNum + "</td></tr>";


        strToDateTitle = "<tr><td class=\"RprtDiv\">" + DateRqst + "</td></tr>";
       
     
            strGuaranteTypeTitle = "<tr><td class=\"RprtDiv\">" + NoOfResourse + "</td></tr>";
        
      
            strGuaranteMdeTitle = "<tr><td class=\"RprtDiv\">" + Desgatn + "</td></tr>";
        
       
            strBidingTitle = "<tr><td class=\"RprtDiv\">" + Department + "</td></tr>";
    
            strCustOrSuplTitle = "<tr><td class=\"RprtDiv\">" + Project + "</td></tr>";


            strExpireDateTitle = "<tr><td class=\"RprtDiv\">" + MinExp + "</td></tr>";
        
   
            strBankIdTitle = "<tr><td class=\"RprtDiv\">" + Paygrd + "</td></tr>";
        
    

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart+strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabstart + strCaptionTabRprtDate + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strGuaranteTypeTitle + strGuaranteMdeTitle +
            strBidingTitle + strCustOrSuplTitle + strExpireDateTitle + strBankIdTitle + strGuranteStsTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtShrtlstdCandList.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<td class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">LOCATION</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<td class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REFERENCE</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">FILE NAME</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: right; word-wrap:break-word;\">NO.OF LEVELS</th>";
            }




        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dtShrtlstdCandList.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dtShrtlstdCandList.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtShrtlstdCandList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtShrtlstdCandList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtShrtlstdCandList.Rows[intRowBodyCount]["REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {

                    strHtml += "<td class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtShrtlstdCandList.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dtShrtlstdCandList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


            }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();


        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int selctdCount = 0;
        //strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">LOCATION</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">REFERENCE</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">FILE NAME</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">NO.OF LEVELS</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">EVALUATION</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            //Start:-For Checking candidate interview status
            string rejected = "false";
            string qualified = "false";
            string completeAll = "false";
            string ins="";
            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
            DataTable dtCandRejectSts = objBusinessIntervewProcess.checkCandStatus(objEntityIntervewProcess);
            if (dtCandRejectSts.Rows.Count > 0)
            {
                rejected = "true";
            }
            //End:-For Checking candidate interview status

            //Start:-For checking candidate complete all levels and all are qualified
            DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
            DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
            int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
            int candQlfiedLvlNo=Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());


            DataTable dtComltAllLvl = objBusinessIntervewProcess.readCompleteLevel(objEntityIntervewProcess);
            int CompltAll = Convert.ToInt32(dtComltAllLvl.Rows[0][0].ToString());

            if (candTotalLvlNo == CompltAll && candTotalLvlNo != 0)
            {

                completeAll = "true";
            }

            if (candTotalLvlNo == candQlfiedLvlNo && candTotalLvlNo!=0)
            {
                selctdCount++;
                qualified = "true";
            }
            //End:-For checking candidate complete all levels and all are qualified
            if (rejected == "true")
            {
                strHtml += "<tr>";
                //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + count.ToString() + "</td>";
                count++;
                qualified = "true";
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" +
                               dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + dt.Rows[intRowBodyCount]["REF"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                           " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a> </td>";
                    }

                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;color:red;padding-right: 0.5%;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                }

                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getCandInfo(" + strId + "," + qualified + ");'> " +
                               "<img title=\"View\"  style=\" cursor:pointer;\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                strHtml += "</tr>";
            }
            else if (qualified == "true")
            {
                strHtml += "<tr>";
                //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;color:green;\" >" + count.ToString() + "</td>";
                count++;

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;color:green;\" >" +
                               dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;color:green;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;color:green;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                            " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a> </td>";
                    }

                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;color:green;padding-right: 0.5%;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                }

                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getCandInfo(" + strId + "," + qualified + ");'> " +
                               "<img title=\"View\"  style=\" cursor:pointer;\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                strHtml += "</tr>";
            }

          
            else
            {

                strHtml += "<tr>";
                //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
                count++;

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +
                               dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                            " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a> </td>";
                    }

                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;padding-right: 0.5%;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                }
                if (candTotalLvlNo != 0)
                {
                    if (HiddenFieldHoldStatus.Value != "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getCandInfo(" + strId + "," + qualified + ");'> " +
                                       "<img title=\"Evaluate\"  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        qualified = "true";
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getCandInfo(" + strId + "," + qualified + ");'> " +
                                     "<img title=\"Evaluate\"  style=\" cursor:pointer;\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (HiddenFieldHoldStatus.Value != "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return EditNot();'> " +
                                        "<img title=\"Evaluate\"  style=\" cursor:pointer;opacity:0.5;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return EditNot();'> " +
                                        "<img title=\"Evaluate\"  style=\" cursor:pointer;opacity:0.5;\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                    }
                }
                strHtml += "</tr>";

            }
               

            }


        lblCount.Text = "Candidate Selected:" + selctdCount + "/" + dt.Rows.Count;

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
    }

    public class clsScheduleLevel
    {
        public string SCHDLID { get; set; }
        public string SAVEASMNT { get; set; }
        public string SCOREID { get; set; }
        public string DECSNID { get; set; }
        public string DATEINTVEW { get; set; }
        public string INTERVWRID { get; set; }
        public string TBLID { get; set; }

    }

    public class clsAssessment
    {
        public string SCHDLID { get; set; }
        public string ASMNTID { get; set; }
        public string SCORE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string TBLID { get; set; }  
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string buttn = HiddenFieldSenderButton.Value;

        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        if (Session["USERID"] != null)
        {
            objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityIntervewProcess.date = System.DateTime.Now;
        objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
        objEntityIntervewProcess.CandId = Convert.ToInt32(HiddenFieldCandId.Value);

       DataTable dtInterPrs = objBusinessIntervewProcess.CheckIntervProcessADDorUPD(objEntityIntervewProcess);

        
       //For schedule level detail table
       List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlList = new List<clsEntityLayerScheduleLevelDtls>();
       string jsonDataPW = HiddenFieldJobSbmsnDtls.Value;
       string R1PW = jsonDataPW.Replace("\"{", "\\{");
       string R2PW = R1PW.Replace("\\n", "\r\n");
       string R3PW = R2PW.Replace("\\", "");
       string R4PW = R3PW.Replace("}\"]", "}]");
       string R5PW = R4PW.Replace("}\",", "},");
       List<clsScheduleLevel> objWBDataPWList = new List<clsScheduleLevel>();
        // UserData  data
       if (HiddenFieldJobSbmsnDtls.Value != null && HiddenFieldJobSbmsnDtls.Value != "")
       {
           objWBDataPWList = JsonConvert.DeserializeObject<List<clsScheduleLevel>>(R5PW);
           foreach (clsScheduleLevel objclsJSData in objWBDataPWList)
           {
               if (objclsJSData.SCHDLID.ToString() != "")
               {

               clsEntityLayerScheduleLevelDtls objEntitySchdlLvl = new clsEntityLayerScheduleLevelDtls();
               objEntitySchdlLvl.SchdlLvlId = Convert.ToInt32(objclsJSData.SCHDLID);
               objEntitySchdlLvl.ScoreId = Convert.ToInt32(objclsJSData.SCOREID);
               objEntitySchdlLvl.DescnId = Convert.ToInt32(objclsJSData.DECSNID);
               if (objclsJSData.DATEINTVEW != "")
               {
                   objEntitySchdlLvl.IntervewDate = objCommon.textToDateTime(objclsJSData.DATEINTVEW);
               }
               objEntitySchdlLvl.IntervewrId = Convert.ToInt32(objclsJSData.INTERVWRID);
               objEntityJobSubmsnDtlList.Add(objEntitySchdlLvl);
               }
           }

       }

        //For assessment table
        List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsList = new List<clsEntityLayerAssessmentDtls>();
        jsonDataPW = HiddenFieldAddtnlJobs.Value;
        R1PW = jsonDataPW.Replace("\"{", "\\{");
        R2PW = R1PW.Replace("\\n", "\r\n");
        R3PW = R2PW.Replace("\\", "");
        R4PW = R3PW.Replace("}\"]", "}]");
        R5PW = R4PW.Replace("}\",", "},");
        List<clsAssessment> objWBDataPWList1 = new List<clsAssessment>();
        // UserData  data
        if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
        {
            objWBDataPWList1 = JsonConvert.DeserializeObject<List<clsAssessment>>(R5PW);
            foreach (clsAssessment objclsJSData in objWBDataPWList1)
            {
                if (objclsJSData != null)
                {
                    if (objclsJSData.ASMNTID.ToString() != "")
                    {
                        clsEntityLayerAssessmentDtls objEntityDetails = new clsEntityLayerAssessmentDtls();
                        objEntityDetails.SchdlLvlAsmntId = Convert.ToInt32(objclsJSData.SCHDLID);
                        objEntityDetails.AsmntId = Convert.ToInt32(objclsJSData.ASMNTID);
                        objEntityDetails.Score = Convert.ToInt32(objclsJSData.SCORE);
                        objEntityAddtnlJobsList.Add(objEntityDetails);
                    }
                }
            }
        }

        //Start:-update
        if (dtInterPrs.Rows.Count > 0)
        {

            objEntityIntervewProcess.IntervewProcessId = Convert.ToInt32(dtInterPrs.Rows[0][0].ToString());

            //for Schedule level table
            List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListUpdate = new List<clsEntityLayerScheduleLevelDtls>();
            List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListAdd = new List<clsEntityLayerScheduleLevelDtls>();
            jsonDataPW = HiddenFieldJobSbmsnDtls.Value;
            R1PW = jsonDataPW.Replace("\"{", "\\{");
            R2PW = R1PW.Replace("\\n", "\r\n");
            R3PW = R2PW.Replace("\\", "");
            R4PW = R3PW.Replace("}\"]", "}]");
            R5PW = R4PW.Replace("}\",", "},");
            List<clsScheduleLevel> objWBDataPWList4 = new List<clsScheduleLevel>();
            // UserData  data
            if (HiddenFieldJobSbmsnDtls.Value != null && HiddenFieldJobSbmsnDtls.Value != "")
            {
                objWBDataPWList4 = JsonConvert.DeserializeObject<List<clsScheduleLevel>>(R5PW);
                foreach (clsScheduleLevel objclsJSData in objWBDataPWList4)
                {

                    if (objclsJSData.TBLID == "")
                    {
                        if (objclsJSData.SCHDLID.ToString() != "")
                        {
                            clsEntityLayerScheduleLevelDtls objEntitySchdlLvl = new clsEntityLayerScheduleLevelDtls();
                            objEntitySchdlLvl.SchdlLvlId = Convert.ToInt32(objclsJSData.SCHDLID);
                            objEntitySchdlLvl.ScoreId = Convert.ToInt32(objclsJSData.SCOREID);
                            objEntitySchdlLvl.DescnId = Convert.ToInt32(objclsJSData.DECSNID);
                            if (objclsJSData.DATEINTVEW != "")
                            {
                                objEntitySchdlLvl.IntervewDate = objCommon.textToDateTime(objclsJSData.DATEINTVEW);
                            }
                            objEntitySchdlLvl.IntervewrId = Convert.ToInt32(objclsJSData.INTERVWRID);
                            objEntityJobSubmsnDtlListAdd.Add(objEntitySchdlLvl);
                        }
                    }
                    else if (objclsJSData.TBLID != "")
                    {
                        if (objclsJSData.SCHDLID.ToString() != "")
                        {
                            clsEntityLayerScheduleLevelDtls objEntitySchdlLvl = new clsEntityLayerScheduleLevelDtls();
                            objEntitySchdlLvl.SchdlTableId = Convert.ToInt32(objclsJSData.TBLID);
                            objEntitySchdlLvl.SchdlLvlId = Convert.ToInt32(objclsJSData.SCHDLID);
                            objEntitySchdlLvl.ScoreId = Convert.ToInt32(objclsJSData.SCOREID);
                            objEntitySchdlLvl.DescnId = Convert.ToInt32(objclsJSData.DECSNID);
                            //objEntitySchdlLvl.IntervewrId = Convert.ToInt32(objclsJSData.INTERVWRID);
                            if (objclsJSData.DATEINTVEW != "")
                            {
                                objEntitySchdlLvl.IntervewDate = objCommon.textToDateTime(objclsJSData.DATEINTVEW);
                            }
                            objEntitySchdlLvl.IntervewrId = Convert.ToInt32(objclsJSData.INTERVWRID);
                            objEntityJobSubmsnDtlListUpdate.Add(objEntitySchdlLvl);
                        }
                    }

                }

            }
            //for assignment table
            List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListUpdate = new List<clsEntityLayerAssessmentDtls>();
            List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListAdd = new List<clsEntityLayerAssessmentDtls>();
            jsonDataPW = HiddenFieldAddtnlJobs.Value;
            R1PW = jsonDataPW.Replace("\"{", "\\{");
            R2PW = R1PW.Replace("\\n", "\r\n");
            R3PW = R2PW.Replace("\\", "");
            R4PW = R3PW.Replace("}\"]", "}]");
            R5PW = R4PW.Replace("}\",", "},");
            List<clsAssessment> objWBDataPWList2 = new List<clsAssessment>();
            // UserData  data
            if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
            {
                objWBDataPWList2 = JsonConvert.DeserializeObject<List<clsAssessment>>(R5PW);
                foreach (clsAssessment objclsJSData in objWBDataPWList2)
                {
                    if (objclsJSData != null)
                    {
                        if (objclsJSData.EVTACTION == "INS")
                        {
                            if (objclsJSData.ASMNTID.ToString() != "")
                            {
                                clsEntityLayerAssessmentDtls objEntityDetails = new clsEntityLayerAssessmentDtls();
                                objEntityDetails.SchdlLvlAsmntId = Convert.ToInt32(objclsJSData.SCHDLID);
                                objEntityDetails.AsmntId = Convert.ToInt32(objclsJSData.ASMNTID);
                                objEntityDetails.Score = Convert.ToInt32(objclsJSData.SCORE);
                                objEntityAddtnlJobsListAdd.Add(objEntityDetails);
                            }
                        }

                        else if (objclsJSData.EVTACTION == "UPD")
                        {

                            if (objclsJSData.ASMNTID.ToString() != "")
                            {
                                clsEntityLayerAssessmentDtls objEntityDetails = new clsEntityLayerAssessmentDtls();
                                objEntityDetails.AsmntTableId = Convert.ToInt32(objclsJSData.TBLID);
                                objEntityDetails.SchdlLvlAsmntId = Convert.ToInt32(objclsJSData.SCHDLID);
                                objEntityDetails.AsmntId = Convert.ToInt32(objclsJSData.ASMNTID);
                                objEntityDetails.Score = Convert.ToInt32(objclsJSData.SCORE);
                                objEntityAddtnlJobsListUpdate.Add(objEntityDetails);
                            }

                        }
                    }
                }
            }


            objBusinessIntervewProcess.updateEvaltnDtls(objEntityIntervewProcess, objEntityJobSubmsnDtlListAdd, objEntityJobSubmsnDtlListUpdate, objEntityAddtnlJobsListAdd, objEntityAddtnlJobsListUpdate);

          
        }
        //End:-Update
        else
        {
        objBusinessIntervewProcess.insertEvaltnDtls(objEntityIntervewProcess, objEntityJobSubmsnDtlList, objEntityAddtnlJobsList);
        }


        //Start:-for updating process status
        objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
        objEntityIntervewProcess.User_Id = Convert.ToInt32(HiddenFieldCandId.Value);
        //Start:-For checking candidate complete all levels and all are qualified
        DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
        DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
        int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
        int candQlfiedLvlNo = Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());
        if (candTotalLvlNo == candQlfiedLvlNo && candTotalLvlNo!=0)
        {
            objBusinessIntervewProcess.updateStatus(objEntityIntervewProcess);
        }
        //End:-for updating process status



        bindScore();
        if (buttn == "asmnt")
        {
            Response.Redirect("gen_Interview_Process.aspx?Id=" + HiddenFieldQryString.Value + "&Hld=" + 0 + "&CandId="+HiddenFieldCandId.Value+"");
        }
        else
        {
            Response.Redirect("gen_Interview_Process.aspx?Id=" + HiddenFieldQryString.Value + "&Hld=" + 0 + "&CandId=" + HiddenFieldCandId.Value + "&InsUpd=Ins");
        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();

        if (HiddenFieldReqrmntId.Value != null && HiddenFieldReqrmntId.Value != "")
        {
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);


            if (Session["USERID"] != null)
            {
                objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityIntervewProcess.date = System.DateTime.Now;
            objBusinessIntervewProcess.ReopenIntervewProcess(objEntityIntervewProcess);
            bindScore();
            Response.Redirect("gen_Interview_Process.aspx?Id=" + HiddenFieldQryString.Value + "&Hld=" + 0 + "&InsUpd=Reopen");

        } 
     }
    protected void btnOnHold_Click (object sender, EventArgs e)
    {
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();

        if (HiddenFieldReqrmntId.Value != null && HiddenFieldReqrmntId.Value != "")
        {
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);


            if (Session["USERID"] != null)
            {
                objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityIntervewProcess.date = System.DateTime.Now;
            objBusinessIntervewProcess.holdIntervewProcess(objEntityIntervewProcess);
            bindScore();
            Response.Redirect("gen_Interview_Process_List.aspx?InsUpd=Hold");

        } 
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();

        if (HiddenFieldReqrmntId.Value != null && HiddenFieldReqrmntId.Value != "")
        {
             objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);


            if (Session["USERID"] != null)
            {
                objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityIntervewProcess.date = System.DateTime.Now;

            objEntityIntervewProcess.CancelReasn = txtCnclReason.Text.Trim();
            objBusinessIntervewProcess.CloseIntervewProcess(objEntityIntervewProcess);
            bindScore();
            Response.Redirect("gen_Interview_Process_List.aspx?InsUpd=Cncl");

        } 
    }

    public class Candidate
    {
      
        public string CandName = "";
        public string Location = "";
        public string Reference = "";
        public string FileName = "";
        public string SchdlList = "";
        public string SchdlListPrint = "";
        public string SchdlListPrintcAPTION = "";
        public string[] ScdlLVlEditInfo=new string[2];

        public string ConvertDataTableToHTMLSchdl(DataTable dt,string reqrmntId)
        {
            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

                   

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableSchdl\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";


            strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";          
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Schedule Name</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Score</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Decision</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Date Of Interview</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">Interviewer</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            int count = 1;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string id = dt.Rows[intRowBodyCount][0].ToString();

                objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(reqrmntId);
                objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                DataTable dtPnl= objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                if (dtPnl.Rows.Count > 0)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td id=\"CatgryId" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount]["INTWCTGRY_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"ScoreChck" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount]["INVTEM_DTLS_SCORE_STS"].ToString() + "</td>";
                    strHtml += "<td id=\"ValidateLvl" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount]["INVTEM_VALIDT_LVL"].ToString() + "</td>";
                    strHtml += "<td id=\"SchdlId" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
                    strHtml += "<td id=\"savedLvl" + intRowBodyCount + "\" style=\"display:none;\" ></td>";
                    strHtml += "<td id=\"savedAsmnt" + intRowBodyCount + "\" style=\"display:none;\" ></td>";
                    strHtml += "<td id=\"intervrId" + intRowBodyCount + "\" style=\"display:none;\" >" + dtPnl.Rows[0][0].ToString() + "</td>";
                    strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
                    count++;


                    strHtml += "<td id=\"LinkId" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"Edit\" onclick='return OpenAsmnt(" + id + "," + dt.Rows[intRowBodyCount]["INTWCTGRY_ID"].ToString() + "," + intRowBodyCount+ ");' href=\"\"; >" +
                              dt.Rows[intRowBodyCount][1].ToString() + "</a> </td>";



                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    strHtml += "<select id=\"ddlscore" + intRowBodyCount + "\"  style=\" width:100%;\" onchange=\"IncrmntConfrmCounter();\" onkeydown=\"return isEnter(event);\"></select>";
                    strHtml += "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    strHtml += "<select id=\"ddlDecsn" + intRowBodyCount + "\"  style=\" width:100%;\" onchange=\"IncrmntConfrmCounter();\" onkeydown=\"return isEnter(event);\"></select>";
                    strHtml += "</td>";


                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    strHtml += "<input id=\"dateIntvew" + intRowBodyCount + "\" placeholder=\"DD-MM-YYYY\" type=text  style=\" width:100%;\" onkeydown=\"return isTagDate(event);\"  onblur=\"return BlurJSTime('dateIntvew'," + intRowBodyCount + ");\" />";
                    strHtml += "</td>";


                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    strHtml += "<input id=\"interviewer" + intRowBodyCount + "\"  type=text disabled  style=\" width:100%;\" value=\"" + dtPnl.Rows[0][1].ToString() + "\" />";
                    strHtml += "</td>";


                    strHtml += "</tr>";
                }
            }
          
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }

        public string ConvertDataTableToHTMLSchdlPrint(DataTable dt, DataTable dtCorp, DataTable dtSchdlList, string reqrmntId, DataTable dtSchdlLvlEditInfo,string CandId)
        {
            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            //  clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strTitle = "";
            strTitle = "Interview Process";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            //for printing product division on print
            string strHidden = "", CandName1 = "", DateRqst = "", Location1 = "", Reference1 = "", FileName1 = "";


            if (dt.Rows.Count > 0)
            {


                CandName1 = "<B>Candidate Name : </B>" + dt.Rows[0]["CAND_NAME"].ToString().ToUpper();


                Location1 = "<B>Location  : </B>" + dt.Rows[0]["CAND_LOC"].ToString().ToUpper();


                Reference1 = "<B>Reference : </B>" + dt.Rows[0]["REF"].ToString().ToUpper();


                FileName1 = "<B>Resume : </B>" + dt.Rows[0]["CAND_ACT_RESUMENAME"].ToString().ToUpper();

            


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

            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";


            string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
            string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

            //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
            //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

            // StringBuilder sbCap = new StringBuilder();





            string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "",
                strCustOrSuplTitle = "", strExpireDateTitle = "", strBankIdTitle = "", strGuranteStsTitle = "";


            if (dat != "")
            {
                strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
            }
            if (strTitle != "")
            {
                strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
            }

            strFromDteTitle = "<tr><td class=\"RprtDiv\">" + CandName1 + "</td></tr>";


            strToDateTitle = "<tr><td class=\"RprtDiv\">" + Reference1 + "</td></tr>";


            strGuaranteTypeTitle = "<tr><td class=\"RprtDiv\">" + FileName1 + "</td></tr>";



            string strCaptionTabstop = "</table>";
            string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabstart + strCaptionTabRprtDate + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strGuaranteTypeTitle  +
                        strGuranteStsTitle + strCaptionTabstop;



            sbCap.Append(strPrintCaptionTable);
            ////write to  divPrintCaption
           // divPrintCaption.InnerHtml = sbCap.ToString();


            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtSchdlList.Columns.Count; intColumnHeaderCount++)
            {

                
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">SCHEDULE NAME</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<td class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">SCORE</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<td class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DECISION</th>";
                }
                else if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE OF INTERVIEW</th>";
                }
                else if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">INTERVIEWER</th>";
                }
                else if (intColumnHeaderCount == 6)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: center; word-wrap:break-word;\">ASSESSMENT POINTS</th>";
                }
                //else if (intColumnHeaderCount == 7)
                //{
                //    strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">SCORE</th>";
                //}




            }
          
         

            strHtml += "</tr>";
            strHtml += "</thead>";

            //add rows

            strHtml += "<tbody>";
            if (dtSchdlList.Rows.Count > 0)
            {

                for (int intRowBodyCount = 0; intRowBodyCount < dtSchdlList.Rows.Count; intRowBodyCount++)
                {
                    string id = dtSchdlList.Rows[intRowBodyCount]["INVTEM_DTLS_ID"].ToString();

                    objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(reqrmntId);
                    objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                    objEntityIntervewProcess.User_Id = Convert.ToInt32(CandId);
                    DataTable dtReadAsmntInfo = objBusinessIntervewProcess.ReadAsmntInfo(objEntityIntervewProcess);

                    // if (dtReadAsmntInfo.Rows.Count > 0)
                    // {
                    DataTable dtASSMNTPOINTS = objBusinessIntervewProcess.ReadAsmntEditDtls(objEntityIntervewProcess);
                    //  }
                    int assmntinfo = 0, intchk = 0;
                    assmntinfo = dtReadAsmntInfo.Rows.Count;
                    if (assmntinfo == 0)
                    {
                        assmntinfo = dtASSMNTPOINTS.Rows.Count;
                    }
                    DataTable dtPnl = objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                    if (dtPnl.Rows.Count > 0)
                    {


                        strHtml += "<tr id=\"TableRprtRow\" >";
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dtSchdlList.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td  class=\"rowHeight1\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlList.Rows[intRowBodyCount]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";

                            }

                            else if (intColumnBodyCount == 2)
                            {

                                strHtml += "<td  class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtSchdlList.Rows[intRowBodyCount]["INTSCR_NAME"].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 3)
                            {

                                strHtml += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlList.Rows[intRowBodyCount]["DECNAME"].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 4)
                            {


                                strHtml += "<td  class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlList.Rows[intRowBodyCount]["INTERDATE"].ToString() + "</td>";

                            }


                            else if (intColumnBodyCount == 5)
                            {

                                strHtml += "<td   class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";

                            }





                        }


                        if (dtReadAsmntInfo.Rows.Count > 0)
                        {
                            StringBuilder sb1 = new StringBuilder();
                            string strHtml1 = "<table id=\"PrintTable1\" class=\"tabinnertable\" style=\" width: 100%;\" >";
                            for (int intRowBodyCount1 = 0; intRowBodyCount1 < dtReadAsmntInfo.Rows.Count; intRowBodyCount1++)
                            {

                                strHtml1 += "<tr id=\"TableRprtRow1\" >";




                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtReadAsmntInfo.Rows[intRowBodyCount1]["INTWCTGRYDTL_NAME"].ToString() + "</td>";

                                if (dtASSMNTPOINTS.Rows.Count > 0 && dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() != "")
                                {
                                    strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >0</td>";
                                }

                                strHtml1 += "</tr>";

                            }
                            strHtml1 += "</tbody>";

                            strHtml1 += "</table>";
                            //sb1.Append(strHtml1);
                            strHtml += "<td  class=\"rowHeight1\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strHtml1 + "</td>";

                        }
                        else if (dtASSMNTPOINTS.Rows.Count > 0)
                        {

                            StringBuilder sb1 = new StringBuilder();
                            string strHtml1 = "<table id=\"PrintTable1\" class=\"tabinnertable\" style=\" width: 100%;\" >";
                            for (int intRowBodyCount1 = 0; intRowBodyCount1 < dtASSMNTPOINTS.Rows.Count; intRowBodyCount1++)
                            {

                                strHtml1 += "<tr id=\"TableRprtRow1\" >";

                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INTWCTGRYDTL_NAME"].ToString() + "</td>";

                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() + "</td>";



                                strHtml1 += "</tr>";

                            }
                            strHtml1 += "</tbody>";

                            strHtml1 += "</table>";
                            //sb1.Append(strHtml1);
                            strHtml += "<td  class=\"rowHeight1\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strHtml1 + "</td>";





                        }
                        strHtml += "</tr>";




                    }
                }
            }
            else
            {


                for (int intRowBodyCount = 0; intRowBodyCount < dtSchdlLvlEditInfo.Rows.Count; intRowBodyCount++)
                {
                    string id = dtSchdlLvlEditInfo.Rows[intRowBodyCount]["INVTEM_DTLS_ID"].ToString();

                    objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(reqrmntId);
                    objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                    objEntityIntervewProcess.User_Id = Convert.ToInt32(CandId);
                    DataTable dtReadAsmntInfo = objBusinessIntervewProcess.ReadAsmntInfo(objEntityIntervewProcess);

                    // if (dtReadAsmntInfo.Rows.Count > 0)
                    // {
                    DataTable dtASSMNTPOINTS = objBusinessIntervewProcess.ReadAsmntEditDtls(objEntityIntervewProcess);
                    //  }
                    int assmntinfo = 0, intchk = 0;
                    assmntinfo = dtReadAsmntInfo.Rows.Count;
                    if (assmntinfo == 0)
                    {
                        assmntinfo = dtASSMNTPOINTS.Rows.Count;
                    }
                    DataTable dtPnl = objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                    if (dtPnl.Rows.Count > 0)
                    {


                        strHtml += "<tr id=\"TableRprtRow\" >";
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dtSchdlLvlEditInfo.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td  class=\"rowHeight1\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCount]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";

                            }

                            else if (intColumnBodyCount == 2)
                            {

                                strHtml += "<td  class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";

                            }
                            else if (intColumnBodyCount == 3)
                            {

                                strHtml += "<td class=\"rowHeight1\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

                            }
                            else if (intColumnBodyCount == 4)
                            {


                                strHtml += "<td  class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

                            }


                            else if (intColumnBodyCount == 5)
                            {

                                strHtml += "<td   class=\"rowHeight1\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";

                            }





                        }


                        if (dtReadAsmntInfo.Rows.Count > 0)
                        {
                            StringBuilder sb1 = new StringBuilder();
                            string strHtml1 = "<table id=\"PrintTable1\" class=\"tabinnertable\"  >";
                            for (int intRowBodyCount1 = 0; intRowBodyCount1 < dtReadAsmntInfo.Rows.Count; intRowBodyCount1++)
                            {

                                strHtml1 += "<tr id=\"TableRprtRow1\" >";




                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtReadAsmntInfo.Rows[intRowBodyCount1]["INTWCTGRYDTL_NAME"].ToString() + "</td>";

                                if (dtASSMNTPOINTS.Rows.Count > 0 && dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() != "")
                                {
                                    strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >0</td>";
                                }

                                strHtml1 += "</tr>";

                            }
                            strHtml1 += "</tbody>";

                            strHtml1 += "</table>";
                            //sb1.Append(strHtml1);
                            strHtml += "<td  class=\"rowHeight1\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strHtml1 + "</td>";

                        }
                        else if (dtASSMNTPOINTS.Rows.Count > 0)
                        {

                            StringBuilder sb1 = new StringBuilder();
                            string strHtml1 = "<table id=\"PrintTable1\" class=\"tabinnertable\"  >";
                            for (int intRowBodyCount1 = 0; intRowBodyCount1 < dtASSMNTPOINTS.Rows.Count; intRowBodyCount1++)
                            {

                                strHtml1 += "<tr id=\"TableRprtRow1\" >";

                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INTWCTGRYDTL_NAME"].ToString() + "</td>";

                                strHtml1 += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtASSMNTPOINTS.Rows[intRowBodyCount1]["INPRSDAS_SCORE"].ToString() + "</td>";



                                strHtml1 += "</tr>";

                            }
                            strHtml1 += "</tbody>";

                            strHtml1 += "</table>";
                            //sb1.Append(strHtml1);
                            strHtml += "<td  class=\"rowHeight1\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strHtml1 + "</td>";





                        }
                        else
                        {
                            strHtml += "<td  class=\"rowHeight1\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" ></td>";
                        }
                        strHtml += "</tr>";




                    }
                }
            
            }

        
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }

        public string ConvertDataTableToHTMLSchdlPrintcAPTION(DataTable dt, DataTable dtCorp, DataTable dtSchdlList, string reqrmntId)
        {
            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            //  clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strTitle = "";
            strTitle = "Interview Process";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            //for printing product division on print
            string strHidden = "", CandName1 = "", DateRqst = "", Location1 = "", Reference1 = "", FileName1 = "";


            if (dt.Rows.Count > 0)
            {


                CandName1 = "<B>Candidate Name : </B>" + dt.Rows[0]["CAND_NAME"].ToString().ToUpper();


                Location1 = "<B>Location  : </B>" + dt.Rows[0]["CAND_LOC"].ToString().ToUpper();


                Reference1 = "<B>Reference: </B>" + dt.Rows[0]["REF"].ToString().ToUpper();


                FileName1 = "<B>Resume : </B>" + dt.Rows[0]["CAND_ACT_RESUMENAME"].ToString().ToUpper();

              


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

            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";


            string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
            string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

            //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
            //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

            // StringBuilder sbCap = new StringBuilder();





            string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "",
                strCustOrSuplTitle = "", strExpireDateTitle = "", strBankIdTitle = "", strGuranteStsTitle = "",strLocation="";


            if (dat != "")
            {
                strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
            }
            if (strTitle != "")
            {
                strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
            }

            strFromDteTitle = "<tr><td class=\"RprtDiv\">" + CandName1 + "</td></tr>";


            strToDateTitle = "<tr><td class=\"RprtDiv\">" + Reference1 + "</td></tr>";
            strLocation = "<tr><td class=\"RprtDiv\">" + Location1 + "</td></tr>";


            strGuaranteTypeTitle = "<tr><td class=\"RprtDiv\">" + FileName1 + "</td></tr>";



            string strCaptionTabstop = "</table>";
            string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabstart + strCaptionTabRprtDate + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strLocation + strGuaranteTypeTitle +
                        strGuranteStsTitle + strCaptionTabstop;



            sbCap.Append(strPrintCaptionTable);
            ////write to  divPrintCaption
            // divPrintCaption.InnerHtml = sbCap.ToString();



            return sbCap.ToString();
        }
    }
    [WebMethod]
    public static Candidate ReadEmpSchdlInfoById(string CandId, string ReqrmntId,string CorpId,string OrgId)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();

   
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);


        Candidate objCand = new Candidate();
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(OrgId);

        DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

        objEntityIntervewProcess.User_Id = Convert.ToInt32(CandId);
        DataTable dt = objBusinessIntervewProcess.ReadEmpInfoById(objEntityIntervewProcess);
        if (dt.Rows.Count > 0)
        {
            objCand.CandName = dt.Rows[0]["CAND_NAME"].ToString().ToUpper();
            objCand.Location = dt.Rows[0]["CAND_LOC"].ToString().ToUpper();
            objCand.Reference = dt.Rows[0]["REF"].ToString().ToUpper();

            string  strHtml="<a href=\""+ imgpath + dt.Rows[0]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[0]["CAND_ACT_RESUMENAME"].ToString() + "</a>";
            objCand.FileName = strHtml;         
            //objCand.FileName = dt.Rows[0]["CAND_ACT_RESUMENAME"].ToString();
            
        }
        objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ReqrmntId);
        DataTable dtSchdlList = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
        objCand.SchdlList = objCand.ConvertDataTableToHTMLSchdl(dtSchdlList, ReqrmntId);

        //FOR DISPLAYING SCHEDULE LEVEL DETAILS
        DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);

        objCand.SchdlListPrint = objCand.ConvertDataTableToHTMLSchdlPrint(dt, dtCorp, dtSchdlLvlEditInfo, ReqrmntId, dtSchdlList, CandId);
        objCand.SchdlListPrintcAPTION= objCand.ConvertDataTableToHTMLSchdlPrintcAPTION(dt, dtCorp, dtSchdlList, ReqrmntId);
        
       
        // objCand.SchdlList = objCand.ConvertDataTableToHTMLSchdl(dtSchdlList, ReqrmntId,dtSchdlLvlEditInfo);
        string[] strJsonDW = new string[1];
        if (dtSchdlLvlEditInfo.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(string));
            dtDetail.Columns.Add("SchdlTableId", typeof(string));
            dtDetail.Columns.Add("ScoreId", typeof(string));
            dtDetail.Columns.Add("DescnId", typeof(string));
            dtDetail.Columns.Add("IntervDate", typeof(string));
            dtDetail.Columns.Add("SchdlLvlId", typeof(string));
           

            for (int intcnt = 0; intcnt < dtSchdlLvlEditInfo.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = dtSchdlLvlEditInfo.Rows[intcnt]["INVPRS_ID"].ToString();
                drDtl["SchdlTableId"] = dtSchdlLvlEditInfo.Rows[intcnt]["INPRSDEV_ID"].ToString();
                drDtl["ScoreId"] = dtSchdlLvlEditInfo.Rows[intcnt]["INTSCR_ID"].ToString();
                drDtl["DescnId"] = dtSchdlLvlEditInfo.Rows[intcnt]["INPRSDEV_DECSN_ID"].ToString();
                drDtl["IntervDate"] = dtSchdlLvlEditInfo.Rows[intcnt]["INTERDATE"].ToString();
                drDtl["SchdlLvlId"] = dtSchdlLvlEditInfo.Rows[intcnt]["INVTEM_DTLS_ID"].ToString();

                dtDetail.Rows.Add(drDtl);
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[0] = jsSerializer.Serialize(parentRow);
        }

        objCand.ScdlLVlEditInfo = strJsonDW;



        return objCand;
    }

    public void bindScore()
    {
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = objBusinessIntervewProcess.ReadScoreList();
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        HiddenFieldScoreDdl.Value = result;
    }

    [WebMethod]
    public static string[] ReadAsmntInfo(int intId, int intRqrmntId, int intCandId)
    {

        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityIntervewProcess.SchdlLvlId = intId;

        DataTable dt = objBusinessIntervewProcess.ReadAsmntInfo(objEntityIntervewProcess);
        string[] strJsonDW = new string[2];
        if (dt.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("AsmntTableId", typeof(string));
            dtDetail.Columns.Add("CtgryDtlId", typeof(int));
            dtDetail.Columns.Add("CatgryId", typeof(int));
            dtDetail.Columns.Add("AsmntName", typeof(string));
            dtDetail.Columns.Add("Score", typeof(int));
          
            for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = intId;
                drDtl["AsmntTableId"] = "";
                drDtl["CtgryDtlId"] = Convert.ToInt32(dt.Rows[intcnt]["INTWCTGRYDTL_ID"].ToString());
                drDtl["CatgryId"] = Convert.ToInt32(dt.Rows[intcnt]["INTWCTGRY_ID"].ToString());
                drDtl["AsmntName"] = dt.Rows[intcnt]["INTWCTGRYDTL_NAME"].ToString();
                drDtl["Score"] = 0;
                dtDetail.Rows.Add(drDtl);
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[0] = jsSerializer.Serialize(parentRow);
        }



        //For display assignment details
        objEntityIntervewProcess.User_Id = intCandId;
        objEntityIntervewProcess.ReqrmntId = intRqrmntId;
        DataTable dtAsmntEditDtls = objBusinessIntervewProcess.ReadAsmntEditDtls(objEntityIntervewProcess);
        if (dtAsmntEditDtls.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("AsmntTableId", typeof(string));
            dtDetail.Columns.Add("CtgryDtlId", typeof(int));
            dtDetail.Columns.Add("CatgryId", typeof(int));
            dtDetail.Columns.Add("AsmntName", typeof(string));
            dtDetail.Columns.Add("Score", typeof(int));


            for (int intcnt = 0; intcnt < dtAsmntEditDtls.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = intId;
                drDtl["AsmntTableId"] = dtAsmntEditDtls.Rows[intcnt]["INPRSDAS_ID"].ToString();
                drDtl["CtgryDtlId"] = Convert.ToInt32(dtAsmntEditDtls.Rows[intcnt]["INTWCTGRYDTL_ID"].ToString());
                drDtl["CatgryId"] = Convert.ToInt32(dtAsmntEditDtls.Rows[intcnt]["INTWCTGRY_ID"].ToString());
                drDtl["AsmntName"] = dtAsmntEditDtls.Rows[intcnt]["INTWCTGRYDTL_NAME"].ToString();
                drDtl["Score"] = Convert.ToInt32(dtAsmntEditDtls.Rows[intcnt]["INPRSDAS_SCORE"].ToString());
                dtDetail.Rows.Add(drDtl);
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[1] = jsSerializer.Serialize(parentRow);
        }



        return strJsonDW;
    }

    [WebMethod]
    public static string SbmsnNotChckd(string tableName, string SchdlId)
    {


        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(SchdlId);
        DataTable dtVehicles = objBusinessIntervewProcess.ReadAsmntNotChcked(objEntityIntervewProcess);

        dtVehicles.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtVehicles.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }


   
}