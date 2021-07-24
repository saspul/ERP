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
using EL_Compzit;
using System.Collections.Generic;
using System.Net.Mail;

// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_visa_quota_info_gen_visa_quota_info_list : System.Web.UI.Page
{
    
    clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
    clsBusinessLayerVisaProfession objBusinessLayerVisaType = new clsBusinessLayerVisaProfession();
    clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
    protected void Page_Load(object sender, EventArgs e)
    {
    
        //clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtFromDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtToDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtToDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtBundlNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtIssuedDate.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");
        txtExpDate.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");

        txtBundlNum.Attributes.Add("onkeypress", "return isTag(event)");
        txtIssuedDate.Attributes.Add("onkeypress", "return isTagDisableEnter(event)");
        txtExpDate.Attributes.Add("onkeypress", "return isTagDisableEnter(event)");
        if (!IsPostBack)
        {
            HiddenRenwSts.Value = "";
            txtBundlNum.Enabled=false;
           // VisaTypLoad();
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            HiddenDate.Value = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy");
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0,intRenew=0,intConfirm=0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
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



                if (Session["USERID"] != null)
                {
                    objEntityVisQuotInfo.UserId= Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strFromDate = strSearchFields[0];
                    string strToDate = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];



                    if (strFromDate != null && strFromDate != "")
                    {

                        txtFromDate.Text = strFromDate;
                         
                    }


                    if (strToDate != null && strToDate != "")
                    {
                        txtToDate.Text = strToDate;
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
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    string strNUM  = Request.QueryString["RNAME"].ToString();
                    objEntityVisQuotInfo.BundleNum = strNUM;
                    objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(strId);
                    objEntityVisQuotInfo.UserId = intUserId;

                    objEntityVisQuotInfo.dateNow = System.DateTime.Now;
                    DataTable dtJobDetail = new DataTable();
                    //dtJobDetail = objBussnsVisQuotInfo.ReadContractCategryById(objEntityVisQuotInfo);
                              DataTable strdupName ;
        strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuota(objEntityVisQuotInfo);
        if (strdupName.Rows.Count > 0)
        {

            if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
            {

                //objBussnsVisQuotInfo.ReCallContractCategory(objEntityVisQuotInfo);
                objBussnsVisQuotInfo.ReCallBundleNumber(objEntityVisQuotInfo);


                if (HiddenSearchField.Value == "")
                {
                    Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=Recl");
                }
                else
                {
                    //Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=Recl");
                    Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);

                }
            }
            else
            {
                Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=DUP");
            }
        }
                        
                }




                if (Request.QueryString["canId"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["canId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(strId);
                    objEntityVisQuotInfo.UserId = intUserId;

                    objEntityVisQuotInfo.dateNow = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityVisQuotInfo.Cancel_Reason = objCommon.CancelReason();

                           objBussnsVisQuotInfo.CancelVisaQuota(objEntityVisQuotInfo);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_visa_quota_info_list .aspx?InsUpd=Cncl");
                            }
                            else
                            {
                               
                              Response.Redirect("gen_visa_quota_info_list .aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {



                               clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
                             DataTable dtContract = new DataTable();
                            

                             dtContract = objBussnsVisQuotInfo.ReadVisaquotaList(objEntityVisQuotInfo);

                             string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intRenew, intConfirm);
                             //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;


                        }
                        

                    }



                }
                else
                {
                    //to view

                    if (HiddenSearchField.Value == "")
                    {
                        objEntityVisQuotInfo.FromDate=DateTime.MinValue;
                        objEntityVisQuotInfo.ToDate = DateTime.MinValue; 
                        objEntityVisQuotInfo.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            objEntityVisQuotInfo.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim()); 
                           
                        }


                        if (strToDate != null && strToDate != "")
                        {
                            txtToDate.Text = strToDate;
                            objEntityVisQuotInfo.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim()); 
                        }
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                            // objEntityJobDesrp.Cancel_Status = 1;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                            //objEntityJobDesrp.Cancel_Status = 0;
                        }

                        objEntityVisQuotInfo.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    objEntityVisQuotInfo.UserId = intUserId;

                    DataTable dtContract = new DataTable();
                    dtContract = objBussnsVisQuotInfo.ReadVisaquotaList(objEntityVisQuotInfo);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intRenew, intConfirm);
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
                        else if (strInsUpd == "CNFM")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Successreniewed", "Successreniewed();", true);
                        }
                        else if (strInsUpd == "REOPN")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                        }
                        else if (strInsUpd == "CNFIRM")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Successconfirm", "Successconfirm();", true);
                        }
                        else if (strInsUpd == "DUP")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        }
                        

                    }
                }
            }
        }
    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        VisaTypLoad();
        HiddenRenwSts.Value = "1";
        ScriptManager.RegisterStartupScript(this, GetType(), "RenewelView", "RenewelView();", true);

    }
    public void VisaTypLoad()
    {
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
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
      objEntityVisQuotInfo.NxtVisaId=Convert.ToInt32(HiddenVisaQuotaId.Value);
        DataTable dtSubConrt = objBussnsVisQuotInfo.ReadVisaTypForRenew(objEntityVisQuotInfo);
        ddlVisTyp.ClearSelection();
        ddlVisTyp.Items.Clear();
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlVisTyp.DataSource = dtSubConrt;
            ddlVisTyp.DataTextField = "VISA_NAME";
            ddlVisTyp.DataValueField = "VISATYP_ID";
            ddlVisTyp.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlVisTyp.Items.Insert(0, "--SELECT VISA TYPE--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intRenew, int intConfirm)
    {
        intEnableRecall = 1;
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

        //   strHtml += "<th class=\"thT\" style=\"width:6%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }



        }
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }
        if (intRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RENEW</th>";
            }
        }

        if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble != 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RECALL</th>";
            }
        }
        //if (intConfirm == 1)
        //{
        //    if (intEnableRecall == 1)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CONFIRM</th>";
        //    }
        //}


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
            // strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
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
                    strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


            }

            int IntConfirmSts = Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_CNFRM_STATUS"].ToString());
            string strissuedate = dt.Rows[intRowBodyCount]["ISSUED DATE"].ToString();
            string strexprydate = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString();
            // string strcurrntdate = DateTime.Today.ToString("dd-mm-yyyy");

            DateTime currentDate = DateTime.Now;
            //objCommon.textToDateTime(strcurrntdate);
            DateTime issuedate = objCommon.textToDateTime(strissuedate);
            DateTime exprydate = objCommon.textToDateTime(strexprydate);

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            //  strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
            string IntBundleNum = dt.Rows[intRowBodyCount]["BUNDLE NUMBER"].ToString();

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    if (IntConfirmSts != 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"z-index: 29;cursor:pointer;margin-top:-1.5%;opacity:1;\" onclick='return getdetails(this.href);' " +
                              " href=\"gen_visa_quota_info.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 29;cursor:pointer;margin-top:-1%;opacity:1;margin-left: -0.4%;opacity:1\" title=\"View\" onclick='return getdetails(this.href);' " +
                        " href=\"gen_visa_quota_info.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";

                    }



                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 29;cursor:pointer;margin-top:-1%;opacity:1;margin-left:.6%;opacity:1\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_visa_quota_info.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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
                            if (IntConfirmSts != 1)
                            {
                                if (HiddenSearchField.Value == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" onclick='return CancelAlert(this.href);' " +
                                     " href=\"gen_visa_quota_info_List.aspx?canId=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" onclick='return CancelAlert(this.href);' " +
                                   " href=\"gen_visa_quota_info_List.aspx?canId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                       + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                            }
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                }
            }
            if (intRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    if (IntConfirmSts == 1)
                    {
                        if (currentDate >= exprydate)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left: 0.8%;\" title=\"Renew\" onclick=\"return OpenCancelViewRenwl('" + strId + "','" + IntBundleNum + "');\" >" +
                                                                        "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:.2;margin-left: 0.8%;\" title=\"Renew\"   " +
                                                                            "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:.2;margin-left: 0.8%;\" title=\"Renew\"   " +
                                                                        "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                    }
                }
            }
            if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intReCallForTAble != 0)
                {
                    if (HiddenSearchField.Value == "")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                             " href=\"gen_visa_quota_info_list.aspx?ReId=" + Id + "&RNAME=" + dt.Rows[intRowBodyCount]["BUNDLE NUMBER"].ToString() + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                             " href=\"gen_visa_quota_info_list.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "&RNAME=" + dt.Rows[intRowBodyCount]["BUNDLE NUMBER"].ToString() + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
       

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenSearchField.Value == "")
        {
            objEntityVisQuotInfo.FromDate = DateTime.MinValue;
            objEntityVisQuotInfo.ToDate = DateTime.MinValue;
            objEntityVisQuotInfo.Cancel_Status = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];

            if (strFromDate != null && strFromDate != "")
            {

                txtFromDate.Text = strFromDate;
                objEntityVisQuotInfo.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());

            }


            if (strToDate != null && strToDate != "")
            {
                txtToDate.Text = strToDate;
                objEntityVisQuotInfo.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
                // objEntityJobDesrp.Cancel_Status = 1;
            }
            else
            {
                cbxCnclStatus.Checked = false;
                //objEntityJobDesrp.Cancel_Status = 0;
            }

            objEntityVisQuotInfo.Cancel_Status = Convert.ToInt32(strCbxStatus);
        }
        objEntityVisQuotInfo.UserId = intUserId;

        DataTable dtContract = new DataTable();
        dtContract = objBussnsVisQuotInfo.ReadVisaquotaList(objEntityVisQuotInfo);

      


        //int intUsrRolMstrId=0;
         int  intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0,intRenew=0,intConfirm=0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
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
            }

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intRenew, intConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        //Creating objects for business layer
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

       


        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityVisQuotInfo.dateNow = System.DateTime.Now;

            objEntityVisQuotInfo.Cancel_Reason = txtCnclReason.Text.Trim();
            objBussnsVisQuotInfo.CancelVisaQuota(objEntityVisQuotInfo);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_visa_quota_info_list.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
      //  clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
       // int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
            
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (HiddenVisaQuotaId.Value != "")
        {

            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);

            objEntityVisQuotInfo.BundleNum = HiddenBundlNum.Value;
            objEntityVisQuotInfo.IssueDate = objCommon.textToDateTime(txtIssuedDate.Text.Trim());
            objEntityVisQuotInfo.ExpiryDate = objCommon.textToDateTime(txtExpDate.Text.Trim());

            if (ddlVisTyp.SelectedItem.Value.ToString() != "--SELECT VISA TYPE--")
            {
                objEntityVisQuotInfo.VisaTyp = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
                if(HiddenVisaNum.Value!="")
                objEntityVisQuotInfo.NumVisa =Convert.ToInt32(HiddenVisaNum.Value);
            }
            objEntityVisQuotInfo.ConfrmChkId = 1;

            string strBundlenum = objEntityVisQuotInfo.BundleNum;
            string strIssDate = objEntityVisQuotInfo.IssueDate.Date.ToString("dd-MM-yyyy");
            string strExpDate = objEntityVisQuotInfo.ExpiryDate.Date.ToString("dd-MM-yyyy");
            objBussnsVisQuotInfo.UpDateVisaQuota(objEntityVisQuotInfo);
            txtIssuedDate.Text = "";
            txtExpDate.Text = "";
            txtBundlNum.Text = "";
   

            DataTable dtEmailid= objBussnsVisQuotInfo.ReadEmailId(objEntityVisQuotInfo);
            string MailAddress = "";
            if (dtEmailid.Rows.Count > 0)
            {
                List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
                List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                MailAddress = dtEmailid.Rows[0]["HR_EMAIL"].ToString();
                string CurrntDate = DateTime.Now.Date.ToString("dd-MM-yyyy");
                if (MailAddress != "")
                {
                    string DivisionContent = "";
                  
                        DivisionContent = " Dear Sir/Madam,";


                        DivisionContent += "<br/><br/>The below Visa Quota  Renewed on " + CurrntDate + "." ;

                        DivisionContent += "<br/><b><br/><u>Visa Quota Renewal Details</u></b> ";
                        DivisionContent += "<br/><br/>Bundle Number &nbsp;&nbsp;:   " + strBundlenum ;
                        DivisionContent += "<br/><br/>New Issued Date        :   "+strIssDate ;
                        DivisionContent += "<br/><br/>New Expiry Date         :   "+strExpDate;





 
                    DivisionContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                    DivisionContent += "<br/><br/><br/>Best Regards,";
                    DivisionContent += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
                  //  objentityShortList.DivContent = DivisionContent;
                   


                    Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
                    clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
                    EntityTemMailServce.CorpOffice_Id = objEntityVisQuotInfo.CorpOffice;
                    DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
                    // DataTable dtFromMail = objBussinessJobNOtify.ReadFromMailDetails(objEntityJobNotify);
                    clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                    objEntityMail.Email_Subject = "VISA QUOTA RENEWAL";
                    //objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();
                    //objEntityMail.Email_Content = objEntityMail.Email_Content + objEntityMail.Signature;

                    objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

                    objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                    objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                    objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                    objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();


                    objEntityMail.D_Date = System.DateTime.Now;
                    objEntityMail.To_Email_Address = MailAddress;
                      
                    objEntityMail.Email_Content = DivisionContent;
                    MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                    try
                    {
                        objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);

                      
                       // Response.Redirect("gen_Joining_Intimation_List.aspx?InsUpd=Ins&&Id=" + Request.QueryString["Id"] + "");
                    }
                    catch
                    {
                        //Response.Redirect("gen_Joining_Intimation_List.aspx?InsUpd=Fail&&Id=" + Request.QueryString["Id"] + "");
                    }
                }
            }

       

    

            if (clickedButton.ID == "btnConfirm")
            {
                Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=CNFM");
            }

        }

    }


    protected void btnMail_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        //  clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
       // clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        // int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        //if (Session["CORPOFFICEID"] != null)
        //{
        //    objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);

        //}
        //else if (Session["CORPOFFICEID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        //if (Session["ORGID"] != null)
        //{
        //    objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        //}
        //else if (Session["ORGID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        //if (Session["USERID"] != null)
        //{
        //    objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"].ToString());
        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        DateTime currntdate = DateTime.Now;
        DateTime dateChk;
        int intdays=10;
       dateChk= currntdate.AddDays(-(intdays));
       objEntityVisQuotInfo.dateNow = dateChk;
            DataTable dtContract = new DataTable();
                    dtContract = objBussnsVisQuotInfo.ReadVisaquotaListForMail(objEntityVisQuotInfo);

                    if (dtContract.Rows.Count > 0)
                    {
                        foreach (DataRow rowrqst in dtContract.Rows)
                        {

                            if (rowrqst["CORPRT_ID"].ToString() != "")
                        {

                            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(rowrqst["CORPRT_ID"].ToString());
                            objEntityVisQuotInfo.Orgid = Convert.ToInt32(rowrqst["ORG_ID"].ToString());
                            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(rowrqst["VISQT_ID"].ToString());
                            string strBundlenum = rowrqst["BUNDLE NUMBER"].ToString();
                            string strIssDate = rowrqst["ISSUED DATE"].ToString();
                          DateTime IssDate=  objCommon.textToDateTime(strIssDate);
                          strIssDate = IssDate.Date.ToString("dd-MM-yyyy");
                            string strExpDate = rowrqst["EXPIRY DATE"].ToString();
                            DateTime ExpDate = objCommon.textToDateTime(strExpDate);
                            strExpDate = ExpDate.Date.ToString("dd-MM-yyyy");
                        DataTable dtEmailid = objBussnsVisQuotInfo.ReadEmailId(objEntityVisQuotInfo);
                        string MailAddress = "";
                        if (dtEmailid.Rows.Count > 0)
                        {
                            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
                            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                            MailAddress = dtEmailid.Rows[0]["HR_EMAIL"].ToString();
                            string CurrntDate = DateTime.Now.Date.ToString("dd-MM-yyyy");
                            if (MailAddress != "")
                            {
                                string DivisionContent = "";

                                DivisionContent = " Dear Sir/Madam,";


                                DivisionContent += "<br/><br/>The below Visa Quota  will expire on " + CurrntDate + ".";

                                DivisionContent += "<br/><b><br/><u>Visa Quota Expiry Details</u></b> ";
                                DivisionContent += "<br/><br/>Bundle Number &nbsp;&nbsp;:   " + strBundlenum ;
                                DivisionContent += "<br/><br/>New Issued Date        :   " + strIssDate ;
                                DivisionContent += "<br/><br/>New Expiry Date         :   " + strExpDate ;





                                DivisionContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                                DivisionContent += "<br/><br/><br/>Best Regards,";
                                DivisionContent += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


                                Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
                                clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
                                EntityTemMailServce.CorpOffice_Id = objEntityVisQuotInfo.CorpOffice;
                                DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
                                // DataTable dtFromMail = objBussinessJobNOtify.ReadFromMailDetails(objEntityJobNotify);
                                clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                                objEntityMail.Email_Subject = "VISA QUOTA EXPIRATION";
                                //objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();
                                //objEntityMail.Email_Content = objEntityMail.Email_Content + objEntityMail.Signature;

                                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

                                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();


                                objEntityMail.D_Date = System.DateTime.Now;
                                objEntityMail.To_Email_Address = MailAddress;

                                objEntityMail.Email_Content = DivisionContent;
                                MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                                try
                                {
                                    objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);

                                    objBussnsVisQuotInfo.UpdVisaquotaMailSts(objEntityVisQuotInfo);
                                    // Response.Redirect("gen_Joining_Intimation_List.aspx?InsUpd=Ins&&Id=" + Request.QueryString["Id"] + "");
                                }
                                catch
                                {
                                    //Response.Redirect("gen_Joining_Intimation_List.aspx?InsUpd=Fail&&Id=" + Request.QueryString["Id"] + "");
                                }
                            }
                        }
                    }
                    }
                    }

        
    }

}