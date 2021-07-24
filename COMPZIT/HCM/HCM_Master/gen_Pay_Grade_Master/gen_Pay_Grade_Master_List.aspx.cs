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
using EL_Compzit;
using System.Web.Services;
using System.Collections;
using System.IO;
using BL_Compzit.HCM;
using EL_Compzit.HCM;

public partial class HCM_HCM_Master_gen_Pay_Grade_Master_gen_Pay_Grade_Master_List : System.Web.UI.Page
{
    clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
          
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Pay_Grades);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

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
                clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);
                    objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                clsBusinessLayer objBusiness = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];
                 

                   

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            //ddlStatus.Items.Clear();
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
                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strHidden = Request.QueryString["ReId"].ToString();
                   

                    string[] strSearchFields = strHidden.Split(',');
                    string strnextId = strSearchFields[0];
                    string strName = strSearchFields[1];

                    string strRandomMixedId = strnextId;
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(strId);
                    objEntityPaygrd.User_Id = intUserId;

                    objEntityPaygrd.D_Date = System.DateTime.Now;

                    objEntityPaygrd.PayGrdName = strName;
        string strdupName = "";
        strdupName = objBussnsPayGrd.DuplCheckNamePayGrade(objEntityPaygrd);
        if (strdupName == "" || strdupName == "0")
        {

            objBussnsPayGrd.ReCallPayGrade(objEntityPaygrd);
            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Recl");
            }
            else
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
            }
        }
        else
        {

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Dupl");
            }
            else
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Dupl&Srch=" + this.HiddenSearchField.Value);
            }
        }
                }

         
                else if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(strId);
                    objEntityPaygrd.User_Id = intUserId;

                    objEntityPaygrd.D_Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityPaygrd.Cancel_reason = objCommon.CancelReason();

                            objBussnsPayGrd.CancelPayGrade(objEntityPaygrd);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                
                                objEntityPaygrd.PayGrdStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                
                                objEntityPaygrd.Cancel_Status = 0;
                            }
                            else
                            {
                                objEntityPaygrd.PayGrdStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                                            
                            
                                if (cbxCnclStatus.Checked == true)
                                    objEntityPaygrd.Cancel_Status = 1;
                                else
                                    objEntityPaygrd.Cancel_Status = 0;

                            }
                        }
                        DataTable dtContract = new DataTable();

                        dtContract = objBussnsPayGrd.ReadPayGradeList(objEntityPaygrd);

                        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
                        //Write to divReport
                        divReport.InnerHtml = strHtm;

                        hiddenRsnid.Value = strId;
                    }

                }
                else
                {
                    //to view
                    if (HiddenSearchField.Value == "")
                    {
                      
                        objEntityPaygrd.PayGrdStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    
                        objEntityPaygrd.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strddlStatus = strSearchFields[0];
                    
                        string strCbxStatus = strSearchFields[1];
                       


                      

                        if (strddlStatus != null && strddlStatus != "")
                        {
                            if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                            {
                              //  ddlStatus.Items.Clear();

                                objEntityPaygrd.PayGrdStatus = Convert.ToInt32(strddlStatus);
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

                        objEntityPaygrd.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    DataTable dtContract = new DataTable();
                    dtContract = objBussnsPayGrd.ReadPayGradeList(objEntityPaygrd);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
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
                        else if (strInsUpd == "StsCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                        }
                        else if (strInsUpd == "Dupl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPaygrdName", "DuplicationPaygrdName();", true);
                        }
                       
                    }


                }
            
        }
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (hiddenDfltCurrencyMstrId.Value!="")
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
      

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">PAY GRADE</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">BASIC PAY RANGE</th>";
            }

          

        }
       


        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
            }
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
                }
            }
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
                }
            }

      
      

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string amountFrm = "", amountTo = "";
        Decimal totalAmntFrm = 0, totalAmntTo = 0;
        int count = 1;
        string paygrdName = "";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
            clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

            objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(dt.Rows[intRowBodyCount]["PYGRD_ID"].ToString());

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            DataTable dtOvrtmCategory = objBussnsPayGrd.ReadCountPayGradeOverTime(objEntityPaygrd);
            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
            count++;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    paygrdName = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
                else if (intColumnBodyCount == 2)
                {
                   
                    //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    amountFrm = strNetAmountWithComma;
                    totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                }

                else if (intColumnBodyCount == 3)
                {
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    amountTo = strNetAmountWithComma;
                    totalAmntTo = totalAmntTo + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + "-" + amountTo + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                }
                //else if (intColumnBodyCount == 4)
                //{

                //    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                //    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                //    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";
                //}


            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][4].ToString();


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
            }


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Pay_Grade_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
            else {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                       " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
            }
                if (intReCallForTAble == 0)
                {
                    
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intCancTransaction == 0 && dtOvrtmCategory.Rows.Count == 0) 
                                    {

                                            if (HiddenSearchField.Value == "")
                                            {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                             " href=\"gen_Pay_Grade_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                           " href=\"gen_Pay_Grade_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                    }
                                    else
                                    {

                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelNotPossible();' >"
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
                                     " href=\"gen_Pay_Grade_Master_List.aspx?ReId=" + Id + "," + paygrdName + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Pay_Grade_Master_List.aspx?ReId=" + Id + "," + paygrdName + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                            }
                        }
                    }
                }
            

            strHtml += "</tr>";
        }
        string NetAmountWithCommaTo = "0";
        string stramntSummary = "0";
        //if (totalAmntTo != 0)
        //{
        //    totalAmntTo = totalAmntTo / count;
        //    totalAmntFrm = totalAmntFrm / count;
        //    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmntFrm.ToString(), objEntityCommon);
        //    NetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(totalAmntTo.ToString(), objEntityCommon);
        //    stramntSummary = NetAmountWithCommaFrm + " - " + NetAmountWithCommaTo;
        //}
      //  Session["SalarySummary"] = stramntSummary;
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus)
    {

        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        else
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        objEntityPaygrd.NextIdForPayGrade = strCatId;
        try
        {
            objBussnsPayGrd.ChangeRequestStatus(objEntityPaygrd);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();


        objEntityPaygrd.PayGrdStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
       
        
        if (cbxCnclStatus.Checked == true)
            objEntityPaygrd.Cancel_Status = 1;
        else
            objEntityPaygrd.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtBrnd = new DataTable();

        dtBrnd = objBussnsPayGrd.ReadPayGradeList(objEntityPaygrd);


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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Pay_Grades);
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

        string strHtm = ConvertDataTableToHTML(dtBrnd, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityPaygrd.NextIdForPayGrade= Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPaygrd.D_Date = System.DateTime.Now;

            objEntityPaygrd.Cancel_reason = txtCnclReason.Text.Trim();
            objBussnsPayGrd.CancelPayGrade(objEntityPaygrd);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }


}