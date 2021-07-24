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
using System.Text;

public partial class AWMS_AWMS_Transaction_gen_Traffic_Violation_Settlement_gen_Traffic_Violation_Settlement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableConfirm=0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation_Settlement);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                   // divAdd.Visible = true;

                }
                else
                {

                   // divAdd.Visible = false;

                }
            }
            //Creating objects for business layer

            clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
            clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorptId.Value=Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            
            if (Request.QueryString["View"] == "Pending")
            {
                hiddenViewStatus.Value = "Pending";

                  //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            else if (Request.QueryString["View"] == "Settled")
            {
                hiddenViewStatus.Value = "Settled";
            }
            if (Request.QueryString["Save"] == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation1", "SuccessUpdation1();", true);
            }
            if (Request.QueryString["Save"] == "2")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmSuccessfull", "ConfirmSuccessfull();", true);
            }
            if (Request.QueryString["Save"] == "3")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
            }
            if (Request.QueryString["Save"] == "5")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateReceiptNoOnReOpen", "DuplicateReceiptNoOnReOpen();", true);

            }


            if (Request.QueryString["Del"] == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CancelSuccess", "CancelSuccess();", true);
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            string CnclrsnMust = "";
            if (dtCorpDetail.Rows.Count > 0)
            {

               
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();



               

            }
            if (Request.QueryString["VHEId"] != null && Request.QueryString["RecptNo"] != null)
            {
                //Re open
                string strRandomMixedId = Request.QueryString["VHEId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intVehicleId = Convert.ToInt32(strId);
                string strReceiptNo = Request.QueryString["RecptNo"].ToString();

                ReOpenTrafficViolation(strReceiptNo, intVehicleId);
                //LoadViolations(objEntityTrficVioltnStlmnt, intEnableCancel, intEnableReOpen);
                
            }
            else if (Request.QueryString["DVheID"] != null && Request.QueryString["RecptNo"] != null)
            {
                //cancel
                string strRandomMixedId = Request.QueryString["DVheID"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intVehicleId = Convert.ToInt32(strId);
                string strReceiptNo = Request.QueryString["RecptNo"].ToString();
                
               
                   
                    
                    if (CnclrsnMust == "0")
                    {
                        objEntityTrficVioltnStlmnt.CancelReason = objCommon.CancelReason();

                        objEntityTrficVioltnStlmnt.User_Id = intUserId;
                        objEntityTrficVioltnStlmnt.StlUserId = Convert.ToInt32(strReceiptNo);
                        objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;

                        CancelTrafficViolation(objEntityTrficVioltnStlmnt);
                        LoadViolations(objEntityTrficVioltnStlmnt, intEnableCancel, intEnableReOpen);
                       // ScriptManager.RegisterStartupScript(this, GetType(), "CancelSuccess", "CancelSuccess();", true);
                        Response.Redirect("gen_Traffic_Violation_Settlement_List.aspx?Del=1&View=Settled");
                    }
                    else
                    {
                       
                        LoadViolations(objEntityTrficVioltnStlmnt, intEnableCancel, intEnableReOpen);

                        hiddenRsnid.Value = strId.Trim();


                    }
                
                
            }
            else
            {
                //view
                LoadViolations(objEntityTrficVioltnStlmnt, intEnableCancel, intEnableReOpen);
            }

        }
    }
    public void LoadViolations(clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt,int intEnableCancel, int intEnableReOpen)
    {
        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        //Pending List
        DataTable dtPendingViolations = new DataTable();
        dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolations(objEntityTrficVioltnStlmnt);

        string strHtm = ConvertDataTableToHTML(dtPendingViolations);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        //Settled List
        DataTable dtSettledViolations = new DataTable();
        dtSettledViolations = objBusinessLayerTrficVioltnStlmnt.ReadSettledViolations(objEntityTrficVioltnStlmnt);
        string strHtmForSettled = ConvertDataTableToHTMLForSettled(dtSettledViolations, intEnableCancel, intEnableReOpen);
        divReportDate.InnerHtml = strHtmForSettled;
        
    }
    public static string ConvertDataTableToHTML(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                //strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">SL#</th>";

            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:50%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:50%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
          
            }
            // strHtml += "<td>" + dt.Columns[i].ColumnName + "</td>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    //strHtml += "<td>" + i + "</td>";
                  //  strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intRowBodyCount + "</td>";

                }
                if (intColumnBodyCount == 1)
                {
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                   // strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    //strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><a href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

                }
                if (intColumnBodyCount == 2)
                {
                  
                    //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                }
                strHtml += "</tr>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
       
    }
    public string ConvertDataTableToHTMLForSettled(DataTable dt, int intEnableCancel, int intEnableReOpen)
    {
       
        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dtCurrencyDetails = new DataTable();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        string strCurrencyAbbr = "";
        if (dtCurrencyDetails.Rows.Count>0)
        {
            strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        string strRandom = objCommon.Random_Number();
        string strHtml = "<table id=\"ReportTable2\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">REFERENCE NO </th>";

            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
         
            if (intColumnHeaderCount == 5)
            {
                if (cbxCnclStatus.Checked == false)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">EDIT</th>";
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">DELETE</th>";
                    }
                    //if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    //{
                    //    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">REOPEN</th>";
                    //}
                }
                else
                {
                    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">VIEW</th>";
                }
            }


        }
        // strHtml += "<td>" + dt.Columns[i].ColumnName + "</td>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            int mode = Convert.ToInt32(dt.Rows[intRowBodyCount][8].ToString());

          
            strHtml += "<tr>";
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (mode == 0)
                {

                    if (intColumnBodyCount == 0)
                    {
                        //strHtml += "<td>" + i + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 1)
                    {
                        //string strId = dt.Rows[intRowBodyCount][0].ToString();
                        //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        //string stridLength = intIdLength.ToString("00");
                        //string Id = stridLength + strId + strRandom;
                        //// strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        ////strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        //strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><a href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 2)
                    {

                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;color:red;\" >" + String.Format("{0:dd/MM/yyyy}", dt.Rows[intRowBodyCount][intColumnBodyCount]) + "</td>";

                    }
                    if (intColumnBodyCount == 3)
                    {

                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;color:red;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 4)
                    {

                        string rcptAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;color:red;\" >" + commaRcptAmnt + " " + strCurrencyAbbr + "</td>";
                        //strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }

                    if (intColumnBodyCount == 5)
                    {
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        if (cbxCnclStatus.Checked == false)
                        {
                            if (dt.Rows[intRowBodyCount][5].ToString() == "1")
                            {
                                //Confirmed Entry
                                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"View\"   onclick='return getdetails(this.href);' " +
                " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }

                            //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (dt.Rows[intRowBodyCount][5].ToString() == "0")
                                {
                                    //delete possible
                                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Delete\"  onclick='return CancelAlert(this.href);'" +
                                  " href=\"gen_Traffic_Violation_Settlement_List.aspx?DVheID=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][7].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >img</td>";
                                }
                                else
                                {
                                    //Delete Not Possible
                                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                       + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                            }
                            //if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            //{
                            //    if (dt.Rows[intRowBodyCount][5].ToString() == "1")
                            //    {
                            //        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                            //                        " href=\"gen_Traffic_Violation_Settlement_List.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                            //    }
                            //    else
                            //    {
                            //        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"></td>";
                            //    }
                            //}
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"View\" onclick='return getdetails(this.href);' " +
                                        " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?DVHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";

                        }
                    }
                }
                else
                {
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 1)
                    {
                        //string strId = dt.Rows[intRowBodyCount][0].ToString();
                        //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        //string stridLength = intIdLength.ToString("00");
                        //string Id = stridLength + strId + strRandom;
                        //// strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        ////strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        //strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><a href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 2)
                    {

                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + String.Format("{0:dd/MM/yyyy}", dt.Rows[intRowBodyCount][intColumnBodyCount]) + "</td>";

                    }
                    if (intColumnBodyCount == 3)
                    {

                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 4)
                    {

                        string rcptAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + commaRcptAmnt + " " + strCurrencyAbbr + "</td>";
                        //strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }

                    if (intColumnBodyCount == 5)
                    {
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        if (cbxCnclStatus.Checked == false)
                        {
                            if (dt.Rows[intRowBodyCount][5].ToString() == "1")
                            {
                                //Confirmed Entry
                                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"View\"   onclick='return getdetails(this.href);' " +
                " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }

                            //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (dt.Rows[intRowBodyCount][5].ToString() == "0")
                                {
                                    //delete possible
                                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Delete\"  onclick='return CancelAlert(this.href);'" +
                                  " href=\"gen_Traffic_Violation_Settlement_List.aspx?DVheID=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][7].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >img</td>";
                                }
                                else
                                {
                                    //Delete Not Possible
                                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                       + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                            }
                            //if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            //{
                            //    if (dt.Rows[intRowBodyCount][5].ToString() == "1")
                            //    {
                            //        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"Re-Open\"  onclick='return ReOpenAlert(this.href);' " +
                            //                        " href=\"gen_Traffic_Violation_Settlement_List.aspx?VHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                            //    }
                            //    else
                            //    {
                            //        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"></td>";
                            //    }
                            //}
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"position: unset;opacity: 1;\" title=\"View\" onclick='return getdetails(this.href);' " +
                                        " href=\"gen_Traffic_Violation_Settlement_Dtl.aspx?DVHEId=" + Id + "&RecptNo=" + dt.Rows[intRowBodyCount][1].ToString() + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";

                        }
                    }
                }

               
                

            }
            strHtml += "</tr>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
     public void ReOpenTrafficViolation(string strReceiptNo,int intVehicleId)
     {
         
         clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
         clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
         DataTable dtPendingViolations = new DataTable();

         if (Session["CORPOFFICEID"] != null)
         {
             objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }

        
         objEntityTrficVioltnStlmnt.ReceiptNo = strReceiptNo;
         objEntityTrficVioltnStlmnt.VehicleId = 0;
         //string strReceiptNoCount = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltnStlmnt);
         DataTable dtReceiptDtls = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltnStlmnt);
         objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;
         string strReceiptNoCount = "0";

         if (dtReceiptDtls.Rows.Count > 0)
         {
             strReceiptNoCount = "1";
         }
         if (strReceiptNoCount == "0")
         {
             objEntityTrficVioltnStlmnt.StlStatus = 1;
             dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolationsByVehID(objEntityTrficVioltnStlmnt);
             List<clsEntityLayerSettleList> objSettleList = new List<clsEntityLayerSettleList>();
             if (dtPendingViolations.Rows.Count > 0)
             {
                 for (int intRowCount = 0; intRowCount < dtPendingViolations.Rows.Count; intRowCount++)
                 {
                     clsEntityLayerSettleList objSettleCls = new clsEntityLayerSettleList();
                     objSettleCls.TrfcVioltn_ID = Convert.ToInt32(dtPendingViolations.Rows[0]["TRFCVIOLTN_ID"]);
                     objSettleList.Add(objSettleCls);
                 }
                 objBusinessLayerTrficVioltnStlmnt.ReOpenTrafficViolation(objEntityTrficVioltnStlmnt, objSettleList);
                 ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                 Response.Redirect("gen_Traffic_Violation_Settlement_List.aspx?Save=3&View=Settled");
             }
         }
         else
         {
             //re open failed due to duplicated receipt No
             Response.Redirect("gen_Traffic_Violation_Settlement_List.aspx?Save=5&View=Settled");
             

         }
     }
     public void CancelTrafficViolation(clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt)
     {
         clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
         
         DataTable dtPendingViolations = new DataTable();

    


     
       
             objEntityTrficVioltnStlmnt.StlStatus = 1;
             dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolationsByVehID(objEntityTrficVioltnStlmnt);
             List<clsEntityLayerSettleList> objSettleList = new List<clsEntityLayerSettleList>();
             //if (dtPendingViolations.Rows.Count > 0)
             //{
                 for (int intRowCount = 0; intRowCount < dtPendingViolations.Rows.Count; intRowCount++)
                 {
                     clsEntityLayerSettleList objSettleCls = new clsEntityLayerSettleList();
                     objSettleCls.TrfcVioltn_ID = Convert.ToInt32(dtPendingViolations.Rows[0]["TRFCVIOLTN_ID"]);
                     objSettleList.Add(objSettleCls);
                 }
                 objBusinessLayerTrficVioltnStlmnt.CancelTrafficViolationByList(objEntityTrficVioltnStlmnt, objSettleList);
             //}
         
        
     }
     protected void btnRsnSave_Click(object sender, EventArgs e)
     {
         //cancel
         clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
         clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
         int intUserId=0;
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
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
         string strRandomMixedId = Request.QueryString["DVheID"].ToString();
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);
         int intVehicleId = Convert.ToInt32(strId);
         string strReceiptNo = Request.QueryString["RecptNo"].ToString();
         objEntityTrficVioltnStlmnt.CancelReason = txtCnclReason.Text.Trim();

         objEntityTrficVioltnStlmnt.User_Id = intUserId;
         objEntityTrficVioltnStlmnt.StlUserId = Convert.ToInt32(strReceiptNo);
         objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;

         CancelTrafficViolation(objEntityTrficVioltnStlmnt);
         Response.Redirect("gen_Traffic_Violation_Settlement_List.aspx?Del=1&View=Settled");

     }

     protected void btnSearch_Click(object sender, EventArgs e)
     {
         int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
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
         intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation_Settlement);

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
                 else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                 {
                     intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
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
                 // divAdd.Visible = true;

             }
             else
             {

                 // divAdd.Visible = false;

             }
         }
         //Creating objects for business layer

         clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
         clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
         int intCorpId = 0;
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
             intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
             hiddenCorptId.Value = Session["CORPOFFICEID"].ToString();
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
             hiddenOrgId.Value = Session["ORGID"].ToString();
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (cbxCnclStatus.Checked == true)
         {
             objEntityTrficVioltnStlmnt.CancelStatus = 1;
         }
         else
         {
             objEntityTrficVioltnStlmnt.CancelStatus = 0;
         }
         if(txtDate.Text!="")
         {
             objEntityTrficVioltnStlmnt.FromDate = objCommon.textToDateTime(txtDate.Text);

         }
         if (txtToDate.Text != "")
         {
             objEntityTrficVioltnStlmnt.ToDate = objCommon.textToDateTime(txtToDate.Text);

         }
         LoadViolations(objEntityTrficVioltnStlmnt, intEnableCancel, intEnableReOpen);
         hiddenViewStatus.Value = "Settled";
         ScriptManager.RegisterStartupScript(this, GetType(), "ReloadTodate", "ReloadTodate();", true);
         ScriptManager.RegisterStartupScript(this, GetType(), "ReloadFromDate", "ReloadFromDate();", true);

         ScriptManager.RegisterStartupScript(this, GetType(), "TablePagination", "TablePagination();", true);

}

}