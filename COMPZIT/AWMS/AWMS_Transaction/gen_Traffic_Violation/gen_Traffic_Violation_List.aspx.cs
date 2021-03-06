using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
// CREATED BY:EVM-0009
// CREATED DATE:05/01/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class AWMS_AWMS_Master_gen_Traffic_Violation_gen_Traffic_Violation_List : System.Web.UI.Page
{
    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        txtSearchName.Attributes.Add("onkeypress", "return isTag(event)");
        cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
            hiddenRoleReOpen.Value = "0";
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
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation);

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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strSearchWord = strSearchFields[0];
                    string strddlStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];

                    if (strSearchWord.Trim() != null && strSearchWord.Trim() != "")
                    {

                        txtSearchName.Text = strSearchWord.Trim();
                    }
                    else
                    {
                        txtSearchName.Text = "";
                    }
                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.ClearSelection();
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }


                //Creating objects for business layer

                clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
                clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityTrficVioltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityTrficVioltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {

                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();

                   


                    int intListingMode = Convert.ToInt32(strListingMode);

                    if (intListingMode == 2)//variant
                    {
                        btnNext.Text = "Show Next Records";
                        btnPrevious.Text = "Show Previous Records";
                        hiddenMemorySize.Value = strLstingModeSize;
                    }
                    else if (intListingMode == 1)//fixed
                    {
                        btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                        btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                        hiddenTotalRowCount.Value = strLstingModeSize;
                        hiddenNext.Value = strLstingModeSize;
                    }
                    hiddenPrevious.Value = "0";

                }


                //when ReOpened

                if (Request.QueryString["ReOpId"] != null)
                {
                    bool blIsConfirmed = true;
                    string strRandomMixedId = Request.QueryString["ReOpId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);                
                    objEntityTrficVioltn.TrafficVltnId = Convert.ToInt32(strId);
                    

                        objEntityTrficVioltn.User_Id = intUserId;
                        objEntityTrficVioltn.D_Date = System.DateTime.Now;
                        DataTable dtTrficVioltnDetail = new DataTable();
                        dtTrficVioltnDetail = objBusinessLayerTrficVioltn.ReadTraficVioltnById(objEntityTrficVioltn);
                        //After fetch insurance details in datatable,we need to differentiate.
                        // decimal intTotal = 0 ;
                        if (dtTrficVioltnDetail.Rows.Count > 0)
                        {

                            objEntityTrficVioltn.VehicleId = Convert.ToInt32(dtTrficVioltnDetail.Rows[0]["VHCL_ID"].ToString());
                            if (dtTrficVioltnDetail.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "0")
                            {
                                blIsConfirmed = false;

                            }
                            if (blIsConfirmed == true)
                            {





                                objBusinessLayerTrficVioltn.Reopen_TrficVioltn(objEntityTrficVioltn);
                                if (HiddenSearchField.Value == "")
                                {
                                    Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=ReOpen");
                                }
                                else
                                {
                                    Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=ReOpen&Srch=" + this.HiddenSearchField.Value);
                                }
                            }
                            else
                            {
                                if (HiddenSearchField.Value == "")
                                {
                                    Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=NotReOpen");
                                }
                                else
                                {
                                    Response.Redirect("fgen_Traffic_Violation_List.aspx?InsUpd=NotReOpen&Srch=" + this.HiddenSearchField.Value);
                                }
                            }
                        }
                    
                 
                    
                }








                //when recalled
                if (Request.QueryString["ReId"] != null && Request.QueryString["RptNo"] != null)
                {
                  string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityTrficVioltn.TrafficVltnId = Convert.ToInt32(strId);
                    objEntityTrficVioltn.ReceiptNumber = Request.QueryString["RptNo"];
                    string strNameCount = objBusinessLayerTrficVioltn.CheckDupReceiptNoByID(objEntityTrficVioltn);
                    if (strNameCount == "0")
                    {
                        objEntityTrficVioltn.User_Id = intUserId;
                        objEntityTrficVioltn.D_Date = System.DateTime.Now;

                        objBusinessLayerTrficVioltn.ReCallCanceledTrafficVioltn(objEntityTrficVioltn);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Recl");
                        }
                        else
                        {
                            Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                        }
                    }
                    else
                    {
                        //Duplicate Receipt NO

                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateReceiptNO", "DuplicateReceiptNO();", true);
                    }
                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled
                  
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityTrficVioltn.TrafficVltnId = Convert.ToInt32(strId);
                    objEntityTrficVioltn.User_Id = intUserId;
                    objEntityTrficVioltn.D_Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {

                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityTrficVioltn.CancelReason = objCommon.CancelReason();


                         objBusinessLayerTrficVioltn.CancelTrafficVioltn(objEntityTrficVioltn);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            DataTable dtTrficVioltn = new DataTable();
                            if (HiddenSearchField.Value == "")
                            {
                                objEntityTrficVioltn.Status_id = 0;
                                objEntityTrficVioltn.CancelStatus = 0;



                                dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);

                            }

                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;
                                string[] strSearchFields = strHidden.Split(',');
                                string strSearchWord = strSearchFields[0];
                                string strddlStatus = strSearchFields[1];
                                string strCbxStatus = strSearchFields[2];

                                objEntityTrficVioltn.SearchField = strSearchWord;
                                objEntityTrficVioltn.DataBase_Field = hiddenSearchDataBaseField.Value;
                                objEntityTrficVioltn.Status_id = Convert.ToInt32(strddlStatus);
                                objEntityTrficVioltn.CancelStatus = Convert.ToInt32(strCbxStatus);

                                dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);


                            }
                            string strHtm = ConvertDataTableToHTML(dtTrficVioltn, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId.Trim();


                        }
                  
                    }



                }
                else
                {
                    //to view
                    DataTable dtTrficVioltn = new DataTable();
                    if (HiddenSearchField.Value == "")
                    {
                        objEntityTrficVioltn.Status_id = 0;
                        objEntityTrficVioltn.CancelStatus = 0;



                        dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);

                    }

                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;
                        string[] strSearchFields = strHidden.Split(',');
                        string strSearchWord = strSearchFields[0];
                        string strddlStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];

                        objEntityTrficVioltn.SearchField = strSearchWord;
                        objEntityTrficVioltn.DataBase_Field = hiddenSearchDataBaseField.Value;
                        objEntityTrficVioltn.Status_id = Convert.ToInt32(strddlStatus);
                        objEntityTrficVioltn.CancelStatus = Convert.ToInt32(strCbxStatus);

                        dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);


                    }
                    string strHtm = ConvertDataTableToHTML(dtTrficVioltn, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Save")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        }
                        else if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                        }
                        else if (strInsUpd == "ReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                        }
                        else if (strInsUpd == "NotReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                        }
                        else if (strInsUpd == "Cnfrm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation1", "SuccessConfirmation1();", true);
                        }

                    }
                }

            }
        }
    }
    //It build the Html table by using the datatable provided

    //EVM-0027
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableReOpen)
    {
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";


        //for assigning column for reopen
        int intConfirmedForHead = 0;
        int intReCallForTAble = 0;
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string ConfirmedTransaction = dt.Rows[intRowBodyCount]["STATUS"].ToString();
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            if (ConfirmedTransaction == "CONFIRMED")
            {
                intConfirmedForHead = 1;
            }

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}

            //hiddencommodityvalue=1 means the current corporate office is a commodity maintained corporate office else not maintained corporate office.


            if (intColumnHeaderCount == 2)
            {

                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">" + "VEHICLE NUMBER" + "</th>";

            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">REFERENCE NO</th>";

            }

            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word; text-align: center;\">" + "DATE" + "</th>";

            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + "RECEIPT NUMBER" + "</th>";

            }

            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">" + "AMOUNT" + "</th>";

            }
            else if (intColumnHeaderCount == 6)
            {

                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";

            }


        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (cbxCnclStatus.Checked == false)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> VIEW</th>";
            }
        }

        if (cbxCnclStatus.Checked == false)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }
        }

        else if (cbxCnclStatus.Checked == true)
        {
            if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> RE-CALL</th>";
            }
        }



        if (intEnableReOpen == 1)
        {
            if (intConfirmedForHead == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-OPEN </th>";
            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);
            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value != "")
                {
                    if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
                    {
                        hiddenTotalRowCount.Value = intRowBodyCount.ToString();
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                        btnNext.Enabled = true;
                        break;
                    }
                    else
                    {
                        int intConfirmed;
                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                        string ConfirmedTransaction = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                        if (ConfirmedTransaction == "CONFIRMED")
                        {
                            intConfirmed = 1;
                        }
                        else
                        {
                            intConfirmed = 0;
                        }


                        strHtml += "<tr  >";


                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {
                            //if (j == 0)
                            //{
                            //    int intCnt = i + 1;
                            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                            //}
                            if (intColumnBodyCount == 2)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCL_NUMBR"].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 3)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_INS_DATE"].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 4)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["RCPT_NUMBER"].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 5)
                            {
                                string rcptAmnt = dt.Rows[intRowBodyCount]["RCPT_AMNT"].ToString();

                               objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                               string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);
                               strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaRcptAmnt + "</td>";

                            }
                            else if (intColumnBodyCount == 6)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";

                            }
                        }


                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;



                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {


                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                      " href=\"gen_Traffic_Violation.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                            }

                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                                 " href=\"gen_Traffic_Violation.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                            }
                        }
                        if (intReCallForTAble == 0)
                        {
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {

                                    if (intConfirmed == 0)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"gen_Traffic_Violation_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"gen_Traffic_Violation_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {

                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                    }




                                }
                                else
                                {

                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                            }
                        }
                        else if (intReCallForTAble == 1)
                        {
                            if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                                else
                                {

                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?RptNo="+dt.Rows[intRowBodyCount][3].ToString()+"&ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?RptNo=" + dt.Rows[intRowBodyCount][3].ToString() + "&ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }


                                }
                            }
                        }
                        if (intConfirmedForHead == 1)
                        {
                            if (intEnableReOpen == 1)
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intConfirmed == 1)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                             " href=\"gen_Traffic_Violation_List.aspx?ReOpId=" + Id + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                             " href=\"gen_Traffic_Violation_List.aspx?ReOpId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/Re-open.png'  /> " + "</a> </td>";
                                        }


                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }

                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                            }
                        }



                        strHtml += "</tr>";

                    }
                }
            }
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                {
                    int intConfirmed;
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                    string ConfirmedTransaction = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                    if (ConfirmedTransaction == "CONFIRMED")
                    {
                        intConfirmed = 1;
                    }
                    else
                    {
                        intConfirmed = 0;
                    }

                    strHtml += "<tr  >";


                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}
                        if (intColumnBodyCount == 2)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCL_NUMBR"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";

                        }
                        if (intColumnBodyCount == 3)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_INS_DATE"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 4)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["RCPT_NUMBER"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 5)
                        {
                            string rcptAmnt = dt.Rows[intRowBodyCount]["RCPT_AMNT"].ToString();

                            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                            string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaRcptAmnt + "</td>";

                        }
                        else if (intColumnBodyCount == 6)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";

                        }

                    }


                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;




                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {


                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Traffic_Violation.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                        }

                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                             " href=\"gen_Traffic_Violation.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                        }
                    }
                    if (intReCallForTAble == 0)
                    {
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {

                                if (intConfirmed == 0)
                                {
                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {

                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                }



                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }
                    else if (intReCallForTAble == 1)
                    {
                        if (intEnableRecall == 1)
                        {
                            if (intCnclUsrId == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                            else
                            {
                                if (HiddenSearchField.Value == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Traffic_Violation_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Traffic_Violation_List.aspx?RptNo=" + dt.Rows[intRowBodyCount][3].ToString() + "&ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }

                            }
                        }
                    }
                    if (intConfirmedForHead == 1)
                    {
                        if (intEnableReOpen == 1)
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intConfirmed == 1)
                                {

                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?ReOpId=" + Id + "\">" + "<img id=\"imgReOpenBtn-" + Id + " \"  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                         " href=\"gen_Traffic_Violation_List.aspx?ReOpId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img id=\"imgReOpenBtn-" + Id + " \"  src='/Images/Icons/Re-open.png' />" + "</a> </td>";
                                    }


                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }



                    strHtml += "</tr>";
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //END
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityTrficVioltn.TrafficVltnId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityTrficVioltn.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityTrficVioltn.D_Date = System.DateTime.Now;

            objEntityTrficVioltn.CancelReason = txtCnclReason.Text.Trim();


            objBusinessLayerTrficVioltn.CancelTrafficVioltn(objEntityTrficVioltn);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }
    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles

        if (hiddenRoleAdd.Value == "1")
        {
            intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        if (hiddenRoleUpdate.Value == "1")
        {
            intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        if (hiddenRoleCancel.Value == "1")
        {
            intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        if (hiddenRoleReOpen.Value == "1")
        {
            intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }

        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            divAdd.Visible = true;

        }
        else
        {

            divAdd.Visible = false;

        }
        if (hiddenRoleRecall.Value != "")
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Creating objects for business layer

        clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTrficVioltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTrficVioltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtTrficVioltn = new DataTable();
        if (HiddenSearchField.Value == "")
        {
            objEntityTrficVioltn.Status_id = 0;
            objEntityTrficVioltn.CancelStatus = 0;

            dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);


        }

        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strSearchWord = strSearchFields[0];
            string strddlStatus = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];

            objEntityTrficVioltn.SearchField = strSearchWord.Trim();
            objEntityTrficVioltn.DataBase_Field = hiddenSearchDataBaseField.Value;
            objEntityTrficVioltn.Status_id = Convert.ToInt32(strddlStatus);
            objEntityTrficVioltn.CancelStatus = Convert.ToInt32(strCbxStatus);


            dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);


        }

        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtTrficVioltn.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strHtm = ConvertDataTableToHTML(dtTrficVioltn, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
        hiddenRoleAdd.Value = "0";
        hiddenRoleUpdate.Value = "0";
        hiddenRoleCancel.Value = "0";
        hiddenRoleReOpen.Value = "0";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //allocating provision for recall
        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
            hiddenRoleRecall.Value = "1";
        }
        else
        {
            intEnableRecall = 0;
            hiddenRoleRecall.Value = "0";
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation);
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
                    hiddenRoleAdd.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleUpdate.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleCancel.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleReOpen.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                {
                    //future

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    //future

                }

            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;

            }
            else
            {

                divAdd.Visible = false;

            }

            //Creating objects for business layer

            clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
            clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTrficVioltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTrficVioltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                   clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                            
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {

                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

                int intListingMode = Convert.ToInt32(strListingMode);

                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                    hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";

            }

            //to view
            DataTable dtTrficVioltn = new DataTable();
            if (HiddenSearchField.Value == "")
            {
                objEntityTrficVioltn.Status_id = 0;
                objEntityTrficVioltn.CancelStatus = 0;
                dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);
            }

            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strSearchWord = strSearchFields[0];
                string strddlStatus = strSearchFields[1];
                string strCbxStatus = strSearchFields[2];




                objEntityTrficVioltn.SearchField = strSearchWord;
                objEntityTrficVioltn.DataBase_Field = hiddenSearchDataBaseField.Value;
                objEntityTrficVioltn.Status_id = Convert.ToInt32(strddlStatus);
                objEntityTrficVioltn.CancelStatus = Convert.ToInt32(strCbxStatus);

                dtTrficVioltn = objBusinessLayerTrficVioltn.ReadTrficVioltnListBySearch(objEntityTrficVioltn);


            }

            string strHtm = ConvertDataTableToHTML(dtTrficVioltn, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
            //Write to divReport
            divReport.InnerHtml = strHtm;

        }
    }
}