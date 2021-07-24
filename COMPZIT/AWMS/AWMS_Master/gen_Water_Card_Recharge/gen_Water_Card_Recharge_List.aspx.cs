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
// CREATED BY:EVM-0005
// CREATED DATE:27/10/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Water_Card_Recharge_gen_Water_Card_Recharge_List : System.Web.UI.Page
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
        txtProviderName.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0,intEnableReOpen=0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);

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

                    if (strSearchWord != null && strSearchWord != "")
                    {

                        txtProviderName.Text = strSearchWord;
                    }
                    else
                    {
                        txtProviderName.Text = "";
                    }
                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
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

                clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
                clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                    hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
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


                //when ReOpened

                if (Request.QueryString["ReOpId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReOpId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strId);
                    objEntityWater.User_Id = intUserId;

                    DataTable dtWaterRechargeDetail = new DataTable();
                    dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
                    //After fetch insurance details in datatable,we need to differentiate.
                    decimal intBalance = 0, intRechAmount=0;
                    string strConfirmSts="0";
                    if (dtWaterRechargeDetail.Rows.Count > 0)
                    {
                        intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
                        intRechAmount = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString());
                        objEntityWater.CardNumberId = Convert.ToInt32(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString());
                        strConfirmSts = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString();
                    }
                    

                    decimal TotalAmount = intBalance - intRechAmount;
                    objEntityWater.BalanceAmount = TotalAmount;

                    objEntityWater.Status_id = 0;
                    if (strConfirmSts == "1")
                    {
                        if (intBalance >= intRechAmount)
                        {
                            objBusinessWater.ReOpenWaterCardRecharge(objEntityWater);
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=ReOpen");
                            else
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=ReOpen&Srch=" + this.HiddenSearchField.Value);
                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=ReOpenFail");
                            else
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=ReOpenFail&Srch=" + this.HiddenSearchField.Value);
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=ReOpnAlrd");
                    }
                }








                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strId);
                    objEntityWater.User_Id = intUserId;

                    objEntityWater.Date = System.DateTime.Now;

                    objBusinessWater.ReCallWaterCardRecharge(objEntityWater);
                    if (HiddenSearchField.Value == "")
                        Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Recl");
                    else
                        Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);

                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strId);
                    objEntityWater.User_Id = intUserId;

                    objEntityWater.Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                        string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityWater.CancelReason = objCommon.CancelReason();


                            objBusinessWater.CancelWaterCardRecharge(objEntityWater);
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Cncl");
                            else
                                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);

                        }
                        else
                        {
                            DataTable dtWaterCard = new DataTable();
                            if (HiddenSearchField.Value == "")
                            {
                                objEntityWater.Status_id = 0;
                                objEntityWater.CancelStatus = 0;
                            
                                

                                dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);
                               
                            }

                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;
                                string[] strSearchFields = strHidden.Split(',');
                                string strSearchWord = strSearchFields[0];
                                string strddlStatus = strSearchFields[1];
                                string strCbxStatus = strSearchFields[2];

                                objEntityWater.SearchField = strSearchWord;
                                objEntityWater.DataBase_Field = hiddenSearchDataBaseField.Value;
                                objEntityWater.Status_id = Convert.ToInt32(strddlStatus);
                                objEntityWater.CancelStatus = Convert.ToInt32(strCbxStatus);

                                dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);


                            }
                            string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;
                          

                        }

                    }



                }
                else
                {
                    //to view
                    DataTable dtWaterCard = new DataTable();
                    if (HiddenSearchField.Value == "")
                    {
                       
                        objEntityWater.Status_id = 0;
                        objEntityWater.CancelStatus = 0;
                        dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);
                        
                    }

                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;
                        string[] strSearchFields = strHidden.Split(',');
                        string strSearchWord = strSearchFields[0];
                        string strddlStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];

                        objEntityWater.SearchField = strSearchWord;
                        objEntityWater.DataBase_Field = hiddenSearchDataBaseField.Value;
                        objEntityWater.Status_id = Convert.ToInt32(strddlStatus);
                        objEntityWater.CancelStatus = Convert.ToInt32(strCbxStatus);


                        dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);


                    }
                    string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

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
                        else if (strInsUpd == "ReOpenFail")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailedReOpen", "FailedReOpen();", true);
                        }
                        else if (strInsUpd == "ReOpnAlrd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ReOpenedAlrdy", "ReOpenedAlrdy();", true);
                        }
                    }
                }

            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall,int intEnableReOpen, int intCommodityOffice = 1)
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


            if (intColumnHeaderCount == 1)
            {
                if (hiddenCommodityValue.Value == "1")
                {
                    strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">" + "WATER CARD NUMBER" + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">" + "WATER CARD NUMBER" + "</th>";
                }
            }
            if (intColumnHeaderCount == 2)
            {
                if (hiddenCommodityValue.Value == "1")
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word; text-align: right;\">" + "RECHARGE AMOUNT" + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word; text-align: right;\">" + "RECHARGE AMOUNT" + "</th>";
                }
            }
            else if (intColumnHeaderCount == 3)
            {
                if (hiddenCommodityValue.Value == "1")
                {
                    strHtml += "<th class=\"thT\"  style=\"width:18%;text-align: center; word-wrap:break-word;\">" + "RECHARGE DATE" + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"thT\"  style=\"width:18%;text-align: center; word-wrap:break-word;\">" + "RECHARGE DATE" + "</th>";
                }
            }

            else if (intColumnHeaderCount == 4)
            {
                if (hiddenCommodityValue.Value == "1")
                {
                    strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";
                }
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

        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }
        }

        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
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
                        int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
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
                            if (intColumnBodyCount == 1)
                            {
                                if (hiddenCommodityValue.Value == "1")
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                            }
                            if (intColumnBodyCount == 2)
                            {
                                string rchgAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                                string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                                if (hiddenCommodityValue.Value == "1")
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\"  >" + commarchgAmnt + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\"  >" + commarchgAmnt + "</td>";
                                }
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                if (hiddenCommodityValue.Value == "1")
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                            }
                            else if (intColumnBodyCount == 4)
                            {
                                if (hiddenCommodityValue.Value == "1")
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                            }
                        }


                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        //for checking ReOpen Provision Of Balance Amount limit
                        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
                        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
                        objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strId);
                        DataTable dtWaterRechargeDetail = new DataTable();
                        dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
                        int intReOpenPossible = 0;
                        decimal intRechargeAmnt = 0;
                        if (dtWaterRechargeDetail.Rows.Count > 0)
                        {
                            decimal intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
                            intRechargeAmnt = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString());
                            if (intBalance >= intRechargeAmnt)
                            {
                                intReOpenPossible = 1;
                            }
                        }

                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {


                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                      " href=\"gen_Water_Card_Recharge.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                            }

                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                                 " href=\"gen_Water_Card_Recharge.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                            }
                        }
                        if (intReCallForTAble == 0)
                        {
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intCancTransaction == 0)
                                    {
                                        if (intConfirmed == 0)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                 " href=\"gen_Water_Card_Recharge_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                 " href=\"gen_Water_Card_Recharge_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                        if (intReCallForTAble == 1)
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
                                         " href=\"gen_Water_Card_Recharge_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Water_Card_Recharge_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
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
                                        if (intReOpenPossible == 1)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                                 " href=\"gen_Water_Card_Recharge_List.aspx?ReOpId=" + Id + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                                 " href=\"gen_Water_Card_Recharge_List.aspx?ReOpId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/reopen_small.png'  /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReOpenNotPossible();' >"
                                                      + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
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
                    int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
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
                        if (intColumnBodyCount == 1)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        if (intColumnBodyCount == 2)
                        {
                            string rchgAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                            string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\"  >" + commarchgAmnt + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\"  >" + commarchgAmnt + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 4)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }

                    }


                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;

                    //for checking ReOpen Provision Of Balance Amount limit
                    clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
                    clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
                    objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strId);
                    DataTable dtWaterRechargeDetail = new DataTable();
                    dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
                    int intReOpenPossible = 0;
                    decimal intRechargeAmnt = 0;
                    if (dtWaterRechargeDetail.Rows.Count > 0)
                    {
                        decimal intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
                         intRechargeAmnt= Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString());
                        if (intBalance >= intRechargeAmnt)
                        {
                            intReOpenPossible = 1;
                        }
                    }


                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {


                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Water_Card_Recharge.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                        }

                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                             " href=\"gen_Water_Card_Recharge.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                        }
                    }
                    if (intReCallForTAble == 0)
                    {
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intCancTransaction == 0)
                                {
                                    if (intConfirmed == 0)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"gen_Water_Card_Recharge_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"gen_Water_Card_Recharge_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                    if (intReCallForTAble == 1)
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
                                     " href=\"gen_Water_Card_Recharge_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Water_Card_Recharge_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
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
                                    if (intReOpenPossible == 1)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                             " href=\"gen_Water_Card_Recharge_List.aspx?ReOpId=" + Id + "\">" + "<img id=\"imgReOpenBtn-" + Id + " \"  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                                             " href=\"gen_Water_Card_Recharge_List.aspx?ReOpId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img id=\"imgReOpenBtn-" + Id + " \"  src='/Images/Icons/Re-open.png' />" + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReOpenNotPossible();' >"
                                                  + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
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
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {


        //Creating objects for business layer

        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityWater.WaterCardRchrgeId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityWater.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityWater.Date = System.DateTime.Now;

            objEntityWater.CancelReason = txtCnclReason.Text.Trim();


            objBusinessWater.CancelWaterCardRecharge(objEntityWater);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }


    //at previous records show button click
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }




    //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }





    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen=0;
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

        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtWaterCard = new DataTable();
        if (HiddenSearchField.Value == "")
        {
            objEntityWater.Status_id =0;
            objEntityWater.CancelStatus = 0;

            dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);


        }

        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strSearchWord = strSearchFields[0];
            string strddlStatus = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];

            objEntityWater.SearchField = strSearchWord;
            objEntityWater.DataBase_Field = hiddenSearchDataBaseField.Value;
            objEntityWater.Status_id = Convert.ToInt32(strddlStatus);
            objEntityWater.CancelStatus = Convert.ToInt32(strCbxStatus);


            dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);


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
        if (last < dtWaterCard.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen=0;
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);
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

            clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
            clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                   clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
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
            DataTable dtWaterCard = new DataTable();
            if (HiddenSearchField.Value == "")
            {
                objEntityWater.Status_id = 0;
                objEntityWater.CancelStatus = 0;
                dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);
            }

            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strSearchWord = strSearchFields[0];
                string strddlStatus = strSearchFields[1];
                string strCbxStatus = strSearchFields[2];




                objEntityWater.SearchField = strSearchWord;
                objEntityWater.DataBase_Field = hiddenSearchDataBaseField.Value;
                objEntityWater.Status_id = Convert.ToInt32(strddlStatus);
                objEntityWater.CancelStatus = Convert.ToInt32(strCbxStatus);

                dtWaterCard = objBusinessWater.ReadwaterCardRechargeListBySearch(objEntityWater);


            }

            string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
            //Write to divReport
            divReport.InnerHtml = strHtm;

        }
    }

   

}
