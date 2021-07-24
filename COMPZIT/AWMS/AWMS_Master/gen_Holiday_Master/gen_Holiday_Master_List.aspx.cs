
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
// CREATED BY:EVM-0008
// CREATED DATE:08/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Holiday_Master_gen_Holiday_Master_List : System.Web.UI.Page
{


  
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        ddlModalYear.Attributes.Add("onchange", "IncrmntConfrmCounter()");
       
        if (!IsPostBack)
        {
            ModalYearLoad();
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
            hiddenRoleReOpen.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            string[] strPrsntyr = strCurrentDate.Split('-');
          int  intPrsntYear = Convert.ToInt32(strPrsntyr[2]);

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Holiday_Master);

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
                     string strddlyear = strSearchFields[0];
                    string strddlStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];

                    if (strddlyear != null && strddlyear != "")
                    {
                        if (ddlModalYear.Items.FindByValue(strddlyear) != null)
                    {
                        ddlModalYear.ClearSelection();
                        ddlModalYear.Items.FindByValue(strddlyear).Selected = true;
                    }
                   
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

                clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
                clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                              
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
             

                //when ReOpened
                if (Request.QueryString["ReOpId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReOpId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntHol.Holdy_Id = Convert.ToInt32(strId);
                    objEntHol.User_Id = intUserId;

                  
                    objEntHol.HOlConfmn = 0;

                    objbusHol.ReOpenHoliday(objEntHol);
                    if (HiddenSearchField.Value == "")
                        Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=ReOpen");
                    else
                        Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=ReOpen&Srch=" + this.HiddenSearchField.Value);

                }

                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntHol.Holdy_Id = Convert.ToInt32(strId);
                    objEntHol.User_Id = intUserId;

                    objEntHol.Date = System.DateTime.Now;
                   
                      DataTable dtHolidayDetail = new DataTable();
        dtHolidayDetail = objbusHol.ReadHolidaydetailsById(objEntHol);
            //After fetch holiday details in datatable,we need to differentiate.
        if (dtHolidayDetail.Rows.Count > 0)
        {


            objEntHol.HolidayTitle = dtHolidayDetail.Rows[0]["HLDAYMSTR_TITLE"].ToString();

            objEntHol.HolidayDate = objCommon.textToDateTime(dtHolidayDetail.Rows[0]["HLDAYMSTR_DATE"].ToString());
          
         
        }
                    //Checking is were the salary was processed
            string strprocesscount = objbusHol.Checksalaryprocess(objEntHol);


            //Checking is there table have any name like this
            string strNameCount = objbusHol.CheckHolTitle(objEntHol);
            //If there is no name like this on table.    
            if (strNameCount == "0" && strprocesscount == "0")
            {
                objbusHol.ReCallHolidayDetails(objEntHol);
                if (HiddenSearchField.Value == "")
                    Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Recl");
                else
                    Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
            }
            else
            {
                
                if (strprocesscount != "" && strNameCount == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

                }
                if (strNameCount != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);
                }
            }
                }

                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntHol.Holdy_Id = Convert.ToInt32(strId);
                    objEntHol.User_Id = intUserId;

                    objEntHol.Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntHol.CancelReason = objCommon.CancelReason();


                            objbusHol.CancelHoliday(objEntHol);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            DataTable dtHoliday = new DataTable();
                            if (HiddenSearchField.Value == "")
                            {
                                objEntHol.Status_id = 0;
                                objEntHol.CancelStatus = 0;
                                objEntHol.HOlYear = intPrsntYear;



                                dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);

                            }

                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;
                                string[] strSearchFields = strHidden.Split(',');

                                string strddlyear = strSearchFields[0];
                                string strddlStatus = strSearchFields[1];
                                string strCbxStatus = strSearchFields[2];

                                objEntHol.Status_id = Convert.ToInt32(strddlStatus);
                                objEntHol.CancelStatus = Convert.ToInt32(strCbxStatus);
                                if (strddlyear != intPrsntYear.ToString())
                                {
                                    objEntHol.HOlYear = Convert.ToInt32(strddlyear);
                                }
                                else
                                {
                                    objEntHol.HOlYear = intPrsntYear;
                                }
                              
                                dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);


                            }
                            string strHtm = ConvertDataTableToHTML(dtHoliday, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;


                        }

                    }



                }

                else
                {
                    //to view
                    DataTable dtHoliday = new DataTable();
                    if (HiddenSearchField.Value == "")
                    {

                        objEntHol.Status_id = 0;
                        objEntHol.CancelStatus = 0;
                        objEntHol.HOlYear = intPrsntYear;
                        dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);
                        
                    }

                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;
                        string[] strSearchFields = strHidden.Split(',');
                        string strddlyear = strSearchFields[0];
                        string strddlStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];

                       
                        objEntHol.Status_id = Convert.ToInt32(strddlStatus);
                        objEntHol.CancelStatus = Convert.ToInt32(strCbxStatus);


                        if (strddlyear != intPrsntYear.ToString())
                        {
                            objEntHol.HOlYear = Convert.ToInt32(strddlyear);
                        }
                        else
                        {
                            objEntHol.HOlYear = intPrsntYear;
                        }
                        dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);


                    }
                    string strHtm = ConvertDataTableToHTML(dtHoliday, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
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
                        else if (strInsUpd == "Cncl&Srch")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                    }
                }

            }
            

        }


    }

     //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall,int intEnableReOpen, int intCommodityOffice = 1)
    {

        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
      
        DateTime dateCurnt;
        DateTime dateFrm, dateTo,dateHolConfm,dateLeavConfm;
        DataTable LeavAllocChk;
       

        //foreach (DataRow row in dt.Rows)
        //{
        //    if (row["STATUS"].ToString() == "CONFIRMED")
        //    {

        //        objEntHol.HolidayDate = objCommon.textToDateTime(row["HLDAYMSTR_DATE"].ToString());
        //        dateCurnt = objEntHol.HolidayDate;

        //        if (row["HLDAYMSTR_CNFRM_DATE"] != DBNull.Value && row["HLDAYMSTR_CNFRM_DATE"].ToString() != null && row["HLDAYMSTR_CNFRM_DATE"].ToString() != "")
        //        {
        //            dateHolConfm = objCommon.textToDateTime(row["HLDAYMSTR_CNFRM_DATE"].ToString()); 
                

        //        LeavAllocChk = objbusHol.LeavAlloctnConfrmCk(objEntHol);
        //        if (LeavAllocChk.Rows.Count > 0)
        //        {
        //            foreach (DataRow row1 in LeavAllocChk.Rows)
        //            {
        //                if (row1["LEAVE_CNFRM_DATE"] != DBNull.Value && row1["LEAVE_CNFRM_DATE"].ToString() != null && row1["LEAVE_CNFRM_DATE"].ToString() != "")
        //                {
        //                    dateLeavConfm = objCommon.textToDateTime(row1["LEAVE_CNFRM_DATE"].ToString()); 
                        
        //                if (dateHolConfm <= dateLeavConfm)
        //                {

        //                    if (row1["LEAVE_FROM_DATE"].ToString() == objEntHol.HolidayDate.ToString())
        //                    {
        //                        intFlag++;
        //                        if (intFlag != 0)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                    if (row1["LEAVE_TO_DATE"] != DBNull.Value && row1["LEAVE_TO_DATE"].ToString() != null && row1["LEAVE_TO_DATE"].ToString() != "")
        //                    {
        //                        dateFrm = objCommon.textToDateTime(row1["LEAVE_FROM_DATE"].ToString());
        //                        dateTo = objCommon.textToDateTime(row1["LEAVE_TO_DATE"].ToString());

        //                        if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
        //                        {
        //                            intFlag++;
        //                            if (intFlag != 0)
        //                            {
        //                                break;
        //                            }
        //                        }

        //                    }
        //                }
        //            }



        //            }


        //        }
        //        else
        //        {

        //            //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
        //        }
        //    }
        //    }
        //}
        //if (intFlag != 0)
        //{
        //    intAllcnChck = 1;
        //}

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
       // strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        //for assigning column for reopen
        int intConfirmedForHead = 0;
        int intReCallForTAble = 0;
       
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
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

         

            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "DATE" + "</th>";
                
            }
            if (intColumnHeaderCount == 2)
            {
                
                strHtml += "<th class=\"thT\" style=\"width:16%; word-wrap:break-word; text-align: center;\">" + "HOLIDAY TYPE" + "</th>";
                
            }
            else if (intColumnHeaderCount == 3)
            {
               
                strHtml += "<th class=\"thT\"  style=\"width:46%;text-align: left; word-wrap:break-word;\">" + "HOLIDAY TITLE" + "</th>";
               
            }

            else if (intColumnHeaderCount == 4)
            {
                
                    strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";
                
            }



        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (cbxCnclStatus.Checked == false)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT </th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW </th>";
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
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL </th>";
            }
        }

       

        if (intEnableReOpen == 1)
        {
            if (intConfirmedForHead == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> RE-OPEN</th>";
            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
         strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            DateTime todate = System.DateTime.Now;
            string EmDate = new DateTime(todate.Year, todate.Month, todate.Day).ToString("dd-MM-yyyy");
           // DateTime ddate = objCommon.textToDateTime(EmDate);

            todate = objCommon.textToDateTime(EmDate);
            DateTime holidayDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount][1].ToString());



          
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
                           
                            if (intColumnBodyCount == 1)
                            {
                                
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                               
                            }
                            if (intColumnBodyCount == 2)
                            {
                              
                                strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                             
                            }
                            else if (intColumnBodyCount == 3)
                            {
                             
                                    strHtml += "<td class=\"tdT\" style=\" width:46%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                               
                            }
                            else if (intColumnBodyCount == 4)
                            {
                               
                                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                
                            }
                        }
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        //for checking ReOpen Provision Of Balance Amount limit
                      // clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
               // clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
                objEntHol.Holdy_Id = Convert.ToInt32(strId);
                        DataTable dtHolidayDtls = new DataTable();
                        dtHolidayDtls = objbusHol.ReadHolidaydetailsById(objEntHol);
                        int intReOpenPossible = 0;
                        int intSalaryProcesd = 0;
                        if (dtHolidayDtls.Rows.Count > 0)
                        {
                           int intcheck = Convert.ToInt32(dtHolidayDtls.Rows[0]["HLDAYMSTR_CNFRM_STS"].ToString());
                           int intSalarystats = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCD_STS"].ToString());
                            if (intcheck == 1)
                            {
                                intReOpenPossible = 1;
                            }
                            if (intSalarystats == 0)
                            {
                                intSalaryProcesd = 0;
                            }
                            else
                            { intSalaryProcesd = 1; }
            
                        }
                        int intFlag = 0, intAllcnChck = 0;
                        
                            if ( dt.Rows[intRowBodyCount]["STATUS"].ToString() == "CONFIRMED")
                            {

                                objEntHol.HolidayDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["HLDAYMSTR_DATE"].ToString());
                                dateCurnt = objEntHol.HolidayDate;

                                if (dt.Rows[intRowBodyCount]["HLDAYMSTR_CNFRM_DATE"] != DBNull.Value && dt.Rows[intRowBodyCount]["HLDAYMSTR_CNFRM_DATE"].ToString() != null && dt.Rows[intRowBodyCount]["HLDAYMSTR_CNFRM_DATE"].ToString() != "")
                                {
                                    dateHolConfm = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["HLDAYMSTR_CNFRM_DATE"].ToString());

                                   
                                    LeavAllocChk = objbusHol.LeavAlloctnConfrmCk(objEntHol);
                                    if (LeavAllocChk.Rows.Count > 0)
                                    {
                                        foreach (DataRow row1 in LeavAllocChk.Rows)
                                        {
                                            if (row1["LEAVE_CNFRM_DATE"] != DBNull.Value && row1["LEAVE_CNFRM_DATE"].ToString() != null && row1["LEAVE_CNFRM_DATE"].ToString() != "")
                                            {
                                                dateLeavConfm = objCommon.textToDateTime(row1["LEAVE_CNFRM_DATE"].ToString());

                                                if (dateHolConfm <= dateLeavConfm)
                                                {

                                                    if (row1["LEAVE_FROM_DATE"].ToString() == objEntHol.HolidayDate.ToString())
                                                    {
                                                        intFlag++;
                                                        if (intFlag != 0)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    if (row1["LEAVE_TO_DATE"] != DBNull.Value && row1["LEAVE_TO_DATE"].ToString() != null && row1["LEAVE_TO_DATE"].ToString() != "")
                                                    {
                                                        dateFrm = objCommon.textToDateTime(row1["LEAVE_FROM_DATE"].ToString());
                                                        dateTo = objCommon.textToDateTime(row1["LEAVE_TO_DATE"].ToString());

                                                        if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                                                        {
                                                            intFlag++;
                                                            if (intFlag != 0)
                                                            {
                                                                break;
                                                            }
                                                        }

                                                    }
                                                }
                                            }



                                        }


                                    }
                                    else
                                    {

                                        //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
                                    }
                                }
                            }
                        
                        if (intFlag != 0)
                        {
                            intAllcnChck = 1;
                        }


                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                          
                                if (intCnclUsrId == 0)
                                {
                                    if (intSalaryProcesd == 0)
                                    {


                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                              " href=\"gen_Holiday_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                                     " href=\"gen_Holiday_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                                    }

                                }
                         

                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                                 " href=\"gen_Holiday_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                            }
                        }
                        if (intReCallForTAble == 0)
                        {
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intSalaryProcesd == 0)
                                {
                                    if (intCnclUsrId == 0)
                                    {

                                        if (intCancTransaction == 0)
                                        {
                                            if (intConfirmed == 0)
                                            {
                                                if (HiddenSearchField.Value == "")
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                     " href=\"gen_Holiday_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                     " href=\"gen_Holiday_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                  + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                                        if (holidayDate >= todate)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                             " href=\"gen_Holiday_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                        }
                                    }
                                    else
                                    {
                                         if (holidayDate >= todate)
                                        {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Holiday_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }
                                         else
                                         {
                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                         }
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
                                    if (intSalaryProcesd == 0)
                                    {
                                        if (intConfirmed == 1)
                                        {
                                            if (intReOpenPossible == 1)
                                            {
                                                if (intAllcnChck == 0)
                                                {
                                                    if (HiddenSearchField.Value == "")
                                                    {
                                                         if (holidayDate >= todate)
                                        {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-open\"   onclick='return ReOpenAlert(this.href);' " +
                                                         " href=\"gen_Holiday_Master_List.aspx?ReOpId=" + Id + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                                    }
                                         else
                                         {
                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                         }
                                                         }
                                                    else
                                                    {
                                                              if (holidayDate >= todate)
                                        {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-open\"   onclick='return ReOpenAlert(this.href);' " +
                                                         " href=\"gen_Holiday_Master_List.aspx?ReOpId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                                     }
                                         else
                                         {
                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                         }
                                                              }
                                                    //reopen_small.png
                                                }
                                                else
                                                {
                                                     if (holidayDate >= todate)
                                        {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a onclick='return ReOpenNotPossibleSelctLevAllcn();' >"
                                                              + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
 }
                                         else
                                         {
                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                         }
                                                }
                                            }
                                            else
                                            {
                                                 if (holidayDate >= todate)
                                        {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a onclick='return ReOpenNotPossible();' >"
                                                          + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                            
                                                  }
                                         else
                                         {
                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                         }
                                                 }

                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                        }
                                    }
                                    else
                                    {
                                                         if (holidayDate >= todate)
                                        {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReOpenNotPossible();' >"
                                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";

                                        }
                                                         else
                                                         {
                                                             strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                                         }
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

  

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] strPrsntyr = strCurrentDate.Split('-');
        int intPrsntYear = Convert.ToInt32(strPrsntyr[2]);

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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Holiday_Master);
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

            clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
            clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntHol.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntHol.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


           
         
            //to view
            DataTable dtHoliday = new DataTable();
            if (HiddenSearchField.Value == "")
            {
                objEntHol.Status_id = 0;
                objEntHol.CancelStatus = 0;
                objEntHol.HOlYear = intPrsntYear;



                dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);

            }

            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strddlyear = strSearchFields[0];
                string strddlStatus = strSearchFields[1];
                string strCbxStatus = strSearchFields[2];

          
                objEntHol.Status_id = Convert.ToInt32(strddlStatus);
                objEntHol.CancelStatus = Convert.ToInt32(strCbxStatus);
                if (strddlyear != intPrsntYear.ToString())
                {
                    objEntHol.HOlYear = Convert.ToInt32(strddlyear);
                }
                else {
                    objEntHol.HOlYear = intPrsntYear;
                }
                dtHoliday = objbusHol.ReadHolidayListBySearch(objEntHol);


            }

            string strHtm = ConvertDataTableToHTML(dtHoliday, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
            //Write to divReport
            divReport.InnerHtml = strHtm;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                //else if (strInsUpd == "Cncl")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                //}
            }


        }
    }


    protected void btnRsnSave_Click(object sender, EventArgs e)
    {


        //Creating objects for business layer

        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntHol.Holdy_Id = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntHol.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntHol.Date = System.DateTime.Now;

            objEntHol.CancelReason = txtCnclReason.Text.Trim();


            objbusHol.CancelHoliday(objEntHol);
          

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Holiday_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    protected void ModalYearLoad()
    {
        clsBusinessLayerHolidayMaster objbusHol = new clsBusinessLayerHolidayMaster();
        clsEntityLayerHolidayMaster objEntHol = new clsEntityLayerHolidayMaster();
        ddlModalYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        DataTable dtHolyr=new DataTable();
        int intchckfordate = 0;
        string strMaxyr, strMinyr;
        var currentYear = 0;
        var currentMaxYear = 0;
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] Prsntyr = strCurrentDate.Split('-');
        currentYear = Convert.ToInt32(Prsntyr[2]);
        dtHolyr = objbusHol.ReadYr(objEntHol);
        if (dtHolyr.Rows.Count > 0 && dtHolyr.Rows[0]["HOLMAX"].ToString() != "" && dtHolyr.Rows[0]["HOLMIN"].ToString() != "")
        {
            strMaxyr = dtHolyr.Rows[0]["HOLMAX"].ToString();
            strMinyr = dtHolyr.Rows[0]["HOLMIN"].ToString();
            currentMaxYear = Convert.ToInt32(strMaxyr);



            int minyear = Convert.ToInt32(strMinyr);
            int IntDif = currentMaxYear - minyear;

        for (int range = IntDif; range >= 0; range--)
        {
            // Now just add an entry that's the current year minus the counter
            ddlModalYear.Items.Add((currentMaxYear - range).ToString());

        }
       foreach (ListItem li in ddlModalYear.Items)
{
    if (li.Value == currentYear.ToString())
    {
        intchckfordate++;
    }
        }
       if (intchckfordate == 0)
       {
           ddlModalYear.Items.Add((currentYear).ToString());
           SortDDL(ref this.ddlModalYear);
       }

        }
        else
        {
            string[] split = strCurrentDate.Split('-');
            currentYear = Convert.ToInt32(split[2]);
            ddlModalYear.Items.Add((currentYear).ToString());
        }

        
      //  ddlModalYear.Items.Insert(0, currentYear.ToString());
        ddlModalYear.ClearSelection();
        ddlModalYear.Items.FindByText(currentYear.ToString()).Selected = true;
    }

    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
}