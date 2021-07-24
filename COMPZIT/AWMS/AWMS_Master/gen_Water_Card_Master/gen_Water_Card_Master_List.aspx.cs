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
// CREATED DATE:25/10/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Water_Card_Master_gen_Water_Card_Master_List : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId,intUsrRolRechargeId,intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0,intEnableRecall=0,intEnableRecharge=0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
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

            intUsrRolRechargeId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);

            DataTable dtChildRolRechrge = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolRechargeId);
            if (dtChildRolRechrge.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolRechrge.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableRecharge = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Master);
           
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

                clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
                clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
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

                  clsCommonLibrary.CORP_GLOBAL[] arrEnumer1 = {  
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
                DataTable dtCorpDetail1 = new DataTable();
                dtCorpDetail1 = objBusinessLayer.LoadGlobalDetail(arrEnumer1, intCorpId);
                if (dtCorpDetail1.Rows.Count > 0)
                {

                  
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail1.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }


                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.WaterCardMasterId = Convert.ToInt32(strId);
                    objEntityWater.User_Id = intUserId;

                    objEntityWater.Date = System.DateTime.Now;

                    DataTable dtWaterCardDetail = new DataTable();
                    dtWaterCardDetail = objBusinessWater.ReadWaterCardById(objEntityWater);
                    string strCardNumber="", strCardName="",strCardNumberCount="0",strCardNameCount="0";
                    if (dtWaterCardDetail.Rows.Count > 0)
                    {
                        strCardNumber = dtWaterCardDetail.Rows[0]["WTRCRD_NUMBER"].ToString();
                        strCardName= dtWaterCardDetail.Rows[0]["WTRCRD_NAME"].ToString();
                    }
                    objEntityWater.CardNumber = strCardNumber;
                    if (strCardName != "")
                    {
                        objEntityWater.CardName = strCardName;
                    }
                    strCardNumberCount = objBusinessWater.CheckWaterCardNumber(objEntityWater);
                    strCardNameCount = objBusinessWater.CheckWaterCardName(objEntityWater);

                    if (strCardNumberCount == "0" && strCardNameCount == "0")
                    {

                        objBusinessWater.ReCallWaterCard(objEntityWater);

                        Response.Redirect("gen_Water_Card_Master_List.aspx?InsUpd=Recl");
                    }
                    else
                    {
                        if (strCardNumberCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNumber", "DuplicationNumber();", true);

                        }

                        if (strCardNameCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCardName", "DuplicationCardName();", true);

                        }
                    }
                   

                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    objEntityWater.Status_id = 1;
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        objEntityWater.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(objEntityWater.Status_id.ToString()).Selected = true;


                    }

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.WaterCardMasterId = Convert.ToInt32(strId);
                    objEntityWater.User_Id = intUserId;

                    objEntityWater.Date = System.DateTime.Now;
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityWater.CancelReason = objCommon.CancelReason();


                            objBusinessWater.CancelWaterCard(objEntityWater);

                            Response.Redirect("gen_Water_Card_Master_List.aspx?InsUpd=Cncl&Srch=" + objEntityWater.Status_id + "");
                       

                        }
                        else
                        {
                            DataTable dtWaterCard = new DataTable();
                            objEntityWater.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                            dtWaterCard = objBusinessWater.ReadwaterCardListBySearch(objEntityWater);
                            string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableRecharge);
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
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        objEntityWater.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(objEntityWater.Status_id.ToString()).Selected = true;


                    }
                    objEntityWater.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    DataTable dtPrdctBrnd = new DataTable();
                    dtWaterCard = objBusinessWater.ReadwaterCardListBySearch(objEntityWater);

                    string strHtm = ConvertDataTableToHTML(dtWaterCard, intEnableModify, intEnableCancel, intEnableRecall, intEnableRecharge);
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
                        else if (strInsUpd == "Rech")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecharge", "SuccessRecharge();", true);
                        }
                        else if (strInsUpd == "RechIns")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRechargeIns", "SuccessRechargeIns();", true);
                        }
                    }
                }

            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableRecharge)
    {
        int intddlStatus =Convert.ToInt32(ddlStatus.SelectedItem.Value);
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

        int intReCallForTAble = 0;
        for (int intRowBodyCount =0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"thT\" style=\"width:18%;text-align: left; word-wrap:break-word;\">" + "VEHICLE NUMBER" + "</th>";

            }

            if (intColumnHeaderCount == 2)
            {
  
                    strHtml += "<th class=\"thT\" style=\"width:18%;text-align: left; word-wrap:break-word;\">" + "WATER CARD NUMBER" + "</th>";
                
            }
            if (intColumnHeaderCount == 3)
            {

                strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word; text-align: left;\">" + "BANK NAME" + "</th>";
               
            }
            else if (intColumnHeaderCount == 4)
            {

                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: right; word-wrap:break-word;\">" + "BALANCE AMOUNT" + "</th>";
               
            }
            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "EXPIRY DATE" + "</th>";

            }
            else if (intColumnHeaderCount == 6)
            {
     
                    strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";
                
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
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> DELETE</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> RE-CALL</th>";
            }
        }
        if (intReCallForTAble ==0)
        {
            if (intEnableRecharge == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">RECHARGE</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount =0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                        int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

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

                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {
                                
                                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                              
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 4)
                            {
                                string balAmnt = dt.Rows[intRowBodyCount][5].ToString();

                                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                                string commabalAmnt = objBusinessLayer.AddCommasForNumberSeperation(balAmnt, objEntityCommon);
                                decimal intAlertAmount = Convert.ToDecimal(dt.Rows[intRowBodyCount][9].ToString());
                                decimal intBalAmount = Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                if (intAlertAmount < intBalAmount)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commabalAmnt + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;color:red;\"  >" + commabalAmnt + "</td>";
                                }
                            }
                            if (intColumnBodyCount == 5)
                            {
                               
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                            
                            }
                           
                            
                            else if (intColumnBodyCount == 6)
                            {
                                
                                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                              
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
                                      " href=\"gen_Water_Card_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                            }

                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                                 " href=\"gen_Water_Card_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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

                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                         " href=\"gen_Water_Card_Master_List.aspx?Id=" + Id + "&Srch=" + intddlStatus + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

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

                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Water_Card_Master_List.aspx?ReId=" + Id + "&Srch=" + intddlStatus + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                                }
                            }
                        }
                        if (intEnableRecharge == 1)
                        {
                           
                           if (intCnclUsrId == 0)
                           {
                               string strCrdSts = dt.Rows[intRowBodyCount][6].ToString();
                               if (strCrdSts == "ACTIVE")
                               {
                                   strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recharge\"  onclick='return ReChargeAlert(this.href);' " +
                                                    " href=\"/AWMS/AWMS_MASTER/gen_Water_Card_Recharge/gen_Water_Card_Recharge.aspx?CrdId=" + Id + "\">" + "<img  src='/Images/Small Icons/Water_Card_Recharge.png' /> " + "</a> </td>";
                               }
                               else
                               {
                                   strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return RechargeNotPossible();' >"
                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Small Icons/Water_Card_Recharge.png' /> " + "</a> </td>";
                               }
                           }
                        }

                        strHtml += "</tr>";

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

        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityWater.WaterCardMasterId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityWater.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
           int status=Convert.ToInt32(ddlStatus.SelectedItem.Value);

            objEntityWater.Date = System.DateTime.Now;

            objEntityWater.CancelReason = txtCnclReason.Text.Trim();


            objBusinessWater.CancelWaterCard(objEntityWater);

           
                Response.Redirect("gen_Water_Card_Master_List.aspx?InsUpd=Cncl&Srch="+status+"");
        


        }
    }



    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();

        objEntityWater.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
            objEntityWater.CancelStatus = 1;
        else
            objEntityWater.CancelStatus = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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


        DataTable dtWater = new DataTable();

        dtWater = objBusinessWater.ReadwaterCardListBySearch(objEntityWater);


        int intUserId = 0, intUsrRolMstrId, intUsrRolRechargeId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableRecharge=0;
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
        intUsrRolRechargeId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);

        DataTable dtChildRolRechrge = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolRechargeId);
        if (dtChildRolRechrge.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRolRechrge.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableRecharge = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }
        }

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Master);
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

        string strHtm = ConvertDataTableToHTML(dtWater, intEnableModify, intEnableCancel, intEnableRecall, intEnableRecharge);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
}
