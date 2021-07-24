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
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.IO;
// CREATED BY:EVM-0005
// CREATED DATE:16/1/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Request_For_Guarantee_gen_Request_For_Guarantee_List : System.Web.UI.Page
{
    classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            GuaranteeCategoryLoad();
            CustomerLoad();
            HiddenReissue.Value = "";
            HiddenUserId.Value = "";
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReissue=0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenUserId.Value = intUserId.ToString();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString())
                    {
                        intEnableReissue = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReissue.Value = intEnableReissue.ToString();
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

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }

                //Creating objects for business layer
                classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

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
                    string strGrntyStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];
                    string strCustomer = strSearchFields[3];
                    string strGuarantCat = strSearchFields[4];


                    if (strCustomer != null && strCustomer != "")
                    {
                        if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                        {
                            ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                        }
                    }

                    if (strGuarantCat != null && strGuarantCat != "")
                    {
                        if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                        {
                            ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                        }
                    }

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strGrntyStatus != null && strGrntyStatus != "")
                    {
                        if (ddlGuaranteeStatus.Items.FindByValue(strGrntyStatus) != null)
                        {
                            ddlGuaranteeStatus.Items.FindByValue(strGrntyStatus).Selected = true;
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
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strId);
                    ObjEntityRequest.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;



                    ObjBussinessRequest.ReCallRequest(ObjEntityRequest);
                    if (HiddenSearchField.Value == "")
                    {
                        Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Recl");
                    }
                    else
                    {
                        Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                    }
                }

                 //when Request A print
                else if (Request.QueryString["PriId"] != null)
                {
                    clsCommonLibrary objComm = new clsCommonLibrary();
                    string strRandomMixedId = Request.QueryString["PriId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    Pdfgen(Convert.ToInt32(strId));

                    string strFilePath = objComm.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
                    string strFileName = "Request-" + strId + "_GUARANTEE.pdf";

                    string pageurl = strFilePath + strFileName;

                    ScriptManager.RegisterStartupScript(this, GetType(), "PreviewPDF", "PreviewPDF('" + pageurl + "');", true);


                }
                else if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strId);
                    ObjEntityRequest.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            ObjEntityRequest.Cancel_reason = objCommon.CancelReason();

                            ObjBussinessRequest.CancelRequest(ObjEntityRequest);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(ddlGuaranteeStatus.SelectedItem.Value);
                                ObjEntityRequest.Guarantee_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                ObjEntityRequest.CustomerId = 0;
                                ObjEntityRequest.GuarCatId = 0;
                                ObjEntityRequest.Cancel_Status = 0;
                            }
                            else
                            {
                                ObjEntityRequest.Guarantee_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(ddlGuaranteeStatus.SelectedItem.Value);
                                if (ddlCustomer.SelectedItem.Value.ToString() != "--SELECT CUSTOMER--")
                                {
                                    ObjEntityRequest.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                                }
                                else
                                {
                                    ObjEntityRequest.CustomerId = 0;
                                }
                                if (ddlGuaranteCat.SelectedItem.Value.ToString() != "--SELECT CATEGORY--")
                                {
                                    ObjEntityRequest.GuarCatId = Convert.ToInt32(ddlGuaranteCat.SelectedItem.Value);
                                }
                                else
                                {
                                    ObjEntityRequest.GuarCatId = 0;
                                }
                                if (cbxCnclStatus.Checked == true)
                                    ObjEntityRequest.Cancel_Status = 1;
                                else
                                    ObjEntityRequest.Cancel_Status = 0;

                            }
                        }
                            DataTable dtContract = new DataTable();
                            ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(ddlGuaranteeStatus.SelectedItem.Value);
                            dtContract = ObjBussinessRequest.ReadRequestFrGrntyList(ObjEntityRequest);

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
                        ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(ddlGuaranteeStatus.SelectedItem.Value);
                        ObjEntityRequest.Guarantee_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                        ObjEntityRequest.CustomerId = 0;
                        ObjEntityRequest.GuarCatId = 0;
                        ObjEntityRequest.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strddlStatus = strSearchFields[0];
                        string strGrntyStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];
                        string strCustomer = strSearchFields[3];
                        string strGuarantCat = strSearchFields[4];


                        if (strCustomer != "")
                        {
                            if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            {

                                ObjEntityRequest.CustomerId = Convert.ToInt32(strCustomer);
                            }
                        }

                        if (strGuarantCat != "")
                        {
                            if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                            {

                                ObjEntityRequest.GuarCatId = Convert.ToInt32(strGuarantCat);
                            }
                        }

                        if (strddlStatus != null && strddlStatus != "")
                        {
                            if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                            {

                                ObjEntityRequest.Guarantee_Status = Convert.ToInt32(strddlStatus);
                            }
                        }
                        if (strGrntyStatus != null && strGrntyStatus != "")
                        {
                            if (ddlGuaranteeStatus.Items.FindByValue(strGrntyStatus) != null)
                            {
                                ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(strGrntyStatus);
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

                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    DataTable dtContract = new DataTable();
                    dtContract = ObjBussinessRequest.ReadRequestFrGrntyList(ObjEntityRequest);

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
                        else if (strInsUpd == "Cnfrm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                        }
                        else if (strInsUpd == "ReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                        }
                        else if (strInsUpd == "Cls")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                        }
                        else if (strInsUpd == "PrcedCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessProceed", "SuccessProceed();", true);
                        }
                        
                    }


                }
            }
        }
    }
    public void GuaranteeCategoryLoad()
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityRequest.ProjectId = 0;
        DataTable dtGuaranteCat = ObjBussinessRequest.ReadGuaranteeCat(ObjEntityRequest);
        ddlGuaranteCat.Items.Clear();
        if (dtGuaranteCat.Rows.Count > 0)
        {
            ddlGuaranteCat.DataSource = dtGuaranteCat;
            ddlGuaranteCat.DataTextField = "GUANTCAT_NAME";
            ddlGuaranteCat.DataValueField = "GUANTCAT_ID";
            ddlGuaranteCat.DataBind();

        }
        ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");

    }
    public void CustomerLoad()
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCustomer = ObjBussinessRequest.ReadCustomer(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtCustomer;
            ddlCustomer.DataTextField = "CSTMR_NAME";
            ddlCustomer.DataValueField = "CSTMR_ID";
            ddlCustomer.DataBind();

        }

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER--");

    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (hiddenDfltCurrencyMstrId.Value != "")
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string stsMode = ddlGuaranteeStatus.SelectedItem.Value;
        string stsModeActInct = ddlStatus.SelectedItem.Value;
        
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
                break;
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
                strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
                //EVM-0024
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END

        }
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
  
            if ( stsMode == "1" || stsMode == "6")
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (stsModeActInct != "2")
                    {
                        if (intReCallForTAble == 0)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">PROCEED</th>";
                        }
                    }

                }

            }
        

        if (stsMode == "1")
        {
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
            
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
                }
            }
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
                }
            }

        }
       
        else if (stsMode == "4")
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            }
        }
        else if (stsMode == "3")
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            }
        }
        else if (stsMode == "2")
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            }
        }

        if (stsMode == "5" )
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            }
        }
         if (stsMode == "6")
         {
             if (HiddenReissue.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
             {

                 strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";

             }
         }
       
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">PRINT</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
            int intRFQGurntSts = Convert.ToInt32(dt.Rows[intRowBodyCount]["RFQ_GRNTY_STATUS"].ToString());
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
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "(" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                    }
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {

                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() +"</td>";
                }
                //EVM-0024
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >"+ dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                }
                //END
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount]["STATUS"].ToString();//EVM-0024 5->6

            if (stsMode == "4" )
            {
                if (strStatusMode == "ACTIVE")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                }
            }
            else
            {
                if (intCnclUsrId == 0)
                {
                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intRFQGurntSts == 5)
                        {
                            if (strStatusMode == "ACTIVE")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                                  "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                            }
                        }
                        else if (stsMode != "2" && stsMode != "3" )
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
                        else {
                            if (strStatusMode == "ACTIVE")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" >" +
                                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" >" +
                                  "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                            }
                        
                        }
                    }
                    else
                    {
                        if (strStatusMode == "ACTIVE")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" >" +
                                "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" >" +
                              "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                        }
                    }

                }
                else
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
            }
           

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0 && strStatusMode == "ACTIVE")
                {
                    if ((stsMode == "1" || stsMode == "6"))
                    {
                        if (intCnclUsrId == 0 && (stsMode == "1" || stsMode == "6"))
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"PROCEED\" onclick=\"return ChangeToProceed('" + strId + "');\" >" +
                                         "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"PROCEED\" style=\"opacity: 1;\"  >" +
                                      "<img  style=\"cursor:pointer;opacity: .2;\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                        }
                    }
                }
                else
                {
                  //  strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                }
            }

            if (stsMode == "5")
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
               " href=\"gen_Request_For_Guarantee.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
            }
            if (stsMode == "6")
            {
                if (HiddenReissue.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                 " href=\"gen_Request_For_Guarantee.aspx?ReissueId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
            }


            if (stsMode == "1")
            {
               
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Request_For_Guarantee.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    

                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Request_For_Guarantee.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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
                                if (HiddenSearchField.Value == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                     " href=\"gen_Request_For_Guarantee_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                   " href=\"gen_Request_For_Guarantee_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                            }



                        }
                        else
                        {

                           // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
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
                                     " href=\"gen_Request_For_Guarantee_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Request_For_Guarantee_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                            }
                        }
                    }
                }
            }
            else if (stsMode == "3")
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Request_For_Guarantee.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";



                }
            }
            else if (stsMode == "4")
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Request_For_Guarantee.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";



                }
            }
            else if (stsMode == "2")
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {


                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                              " href=\"gen_Request_For_Guarantee.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";




                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Request_For_Guarantee.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                    }
                }
            }


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Print\"  onclick='return PrintAlert(this.href);' " +
                                    " href=\"gen_Request_For_Guarantee_List.aspx?PriId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Other Images/imgPrint.png' /> " + "</a> </td>";



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
        classBusinessLayerRequestForGrnte ObjBussinessRequestFrGrnty = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityRequest.D_Date = System.DateTime.Now;

            ObjEntityRequest.Cancel_reason = txtCnclReason.Text.Trim();
            ObjBussinessRequestFrGrnty.CancelRequest(ObjEntityRequest);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        classBusinessLayerRequestForGrnte ObjBussinessRequestGrnty = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
       
        ObjEntityRequest.Guarantee_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        ObjEntityRequest.Guarantee_Confirm_Status = Convert.ToInt32(ddlGuaranteeStatus.SelectedItem.Value);
        if (ddlCustomer.SelectedItem.Value.ToString() != "--SELECT CUSTOMER--")
        {
            ObjEntityRequest.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
        }
        else
        {
            ObjEntityRequest.CustomerId = 0;
        }
        if (ddlGuaranteCat.SelectedItem.Value.ToString() != "--SELECT CATEGORY--")
        {
            ObjEntityRequest.GuarCatId = Convert.ToInt32(ddlGuaranteCat.SelectedItem.Value);
        }
        else
        {
            ObjEntityRequest.GuarCatId = 0;
        }
        if (cbxCnclStatus.Checked == true)
            ObjEntityRequest.Cancel_Status = 1;
        else
            ObjEntityRequest.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest .User_Id= Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtBrnd = new DataTable();

        dtBrnd = ObjBussinessRequestGrnty.ReadRequestFrGrntyList(ObjEntityRequest);


        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReissue=0;
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString())
                {
                    intEnableReissue = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenReissue.Value = intEnableReissue.ToString();
                }

            }
        }

        string strHtm = ConvertDataTableToHTML(dtBrnd, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }


    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus)
    {

        classBusinessLayerRequestForGrnte ObjBussinessRequestGrnty = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            ObjEntityRequest.Guarantee_Status = 0;
        }
        else
        {
            ObjEntityRequest.Guarantee_Status = 1;
        }
        ObjEntityRequest.ReqForGuarId = strCatId;
        try
        {
            ObjBussinessRequestGrnty.ChangeRequestStatus(ObjEntityRequest);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    
          [WebMethod]
    public static string ChangeToProceed(int strCatId, string UserId)
    {

        classBusinessLayerRequestForGrnte ObjBussinessRequestGrnty = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRet = "success";
        ObjEntityRequest.User_Id = Convert.ToInt32(UserId);
      
            ObjEntityRequest.Guarantee_Status = 5;
       
        ObjEntityRequest.ReqForGuarId = strCatId;

        DataTable dtRqstFrGrnt = ObjBussinessRequestGrnty.ReadRqstFrGrntyById(ObjEntityRequest);

        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            string strDate = dtRqstFrGrnt.Rows[0]["RFQ_CLOSING_DATE"].ToString();
            DateTime DtClsDate = objCommon.textToDateTime(strDate);

            if (DtClsDate < DateTime.Today)
            {
                strRet = "DateError";
            }
            else
            {
                try
                {
                    ObjBussinessRequestGrnty.ChangeReqToProcd(ObjEntityRequest);
                }
                catch
                {
                    strRet = "failed";
                }
            }
        }

      
        return strRet;
    }
    public void Pdfgen(int intReqId)
    {


        clsCommonLibrary objcommon = new clsCommonLibrary();
        classEntityLayerRequestForGrnte objEntityReqguarent = new classEntityLayerRequestForGrnte();
        classBusinessLayerRequestForGrnte objBusinesReqguarent = new classBusinessLayerRequestForGrnte();
        //declaring string variables for retrieving from db;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqguarent.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReqguarent.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        string g_id = "";
        string g_category = "";
        string g_clos_date = "";
        string g_amount = "";
        string g_abbrv = "";
        string g_customer_details = "";
        string g_Addr2 = "";
        string g_Addr3 = "";
        string g_customer_name = "";
        string g_ins_date = "";
        string g_remarks = "";
        string g_Favour_Of = "";
        string g_Valdt_Days = "";

        string g_Projct_refno = "";
        string g_Projct_name = "";
        string g_Projct_Date = "";
        string g_User_Name = "";

        ////for pdf 


        //  int intCounter = 0;
        int yPoint = 0;
        int yLine = 0;
        int xPoint = 0;
        PdfSharp.Drawing.XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
        PdfDocument pdf = new PdfDocument();
        pdf.Info.Title = "Compzit-ReqGuarantee-";
        PdfPage pdfPage = pdf.AddPage();


        pdfPage.Orientation = PageOrientation.Portrait;

        pdfPage.Width = size.Width;
        pdfPage.Height = size.Height;
        pdfPage.TrimMargins.Top = 5;
        pdfPage.TrimMargins.Right = 5;
        pdfPage.TrimMargins.Bottom = 5;
        pdfPage.TrimMargins.Left = 5;


        XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        XTextFormatter tf = new XTextFormatter(graph);
        XFont fontImportants = new XFont("Calibri", 7, XFontStyle.Bold);
        XFont font = new XFont("Times New Roman", 18, XFontStyle.Bold);
        XFont fontEntry = new XFont("Calibri", 7, XFontStyle.Regular);
        XFont fontEntryNetAmnt = new XFont("Calibri", 9, XFontStyle.Bold);
        XFont fontEntryHeading = new XFont("Calibri", 9, XFontStyle.Bold);
        XFont fontCustmrDtl = new XFont("Calibri", 10, XFontStyle.Regular);
        XFont fontRefDate = new XFont("Calibri", 10, XFontStyle.Bold);
        XFont fontsignature = new XFont("Calibri", 10, XFontStyle.Bold);
        XFont fontdatereq = new XFont("Calibri", 8, XFontStyle.Regular);

        string HeadImg = objcommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "pdf.png";
        if (File.Exists(Server.MapPath(HeadImg)))
        {




            XImage xImg = XImage.FromFile(Server.MapPath(HeadImg));
            graph.DrawImage(xImg, 42, 40);
            xImg.Dispose();

            //  tf.Alignment = XParagraphAlignment.Left;
            //  tf.DrawString(Label1.Text, fontCustmrDtl, XBrushes.Black, new XRect(40, 70, 555, pdfPage.Height.Point), XStringFormats.TopLeft);

        }



        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        objEntityReqguarent.ReqForGuarId = Convert.ToInt32(intReqId);//entity layer
        //  ObjEntityRequest.User_Id = intUserId;
        //int strRqid= Request.QueryString["Id"];
        //ObjBussinessRequest.ReqForGuarId=
        objBusinesReqguarent.ReqgurnteePrint(objEntityReqguarent); // bussiness layer

        DataTable dtreqg = new DataTable();
        dtreqg = objBusinesReqguarent.ReqgurnteePrint(objEntityReqguarent);
        if (dtreqg.Rows.Count > 0)
        {
            /////
            g_id = dtreqg.Rows[0]["RFQ_REF_NUMBER"].ToString();
            g_category = dtreqg.Rows[0]["GUANTCAT_NAME"].ToString();

            g_abbrv = dtreqg.Rows[0]["CRNCMST_ABBRV"].ToString();
            g_amount = dtreqg.Rows[0]["RFQ_AMOUNT"].ToString();
            g_customer_details = dtreqg.Rows[0]["CSTMR_ADDRESS1"].ToString();
            g_ins_date = dtreqg.Rows[0]["RFQ_INS_DATE"].ToString();
            g_customer_name = dtreqg.Rows[0]["CSTMR_NAME"].ToString();
            g_Favour_Of = dtreqg.Rows[0]["RFQ_FAVOUR_OF"].ToString();
            if (dtreqg.Rows[0]["CSTMR_ADDRESS2"].ToString() != "")
            {
                g_Addr2 = dtreqg.Rows[0]["CSTMR_ADDRESS2"].ToString();
            }

            if (dtreqg.Rows[0]["CSTMR_ADDRESS3"].ToString() != "")
            {
                g_Addr3 = dtreqg.Rows[0]["CSTMR_ADDRESS3"].ToString();
            }

            if (dtreqg.Rows[0]["RFQ_REMARKS"].ToString() != "")
            {
                g_remarks = dtreqg.Rows[0]["RFQ_REMARKS"].ToString();
            }
            else
            {
                g_remarks = "Remarks";
            }
            if (dtreqg.Rows[0]["RFQ_VALIDITY_DAYS"].ToString() != "")
            {
                g_Valdt_Days = dtreqg.Rows[0]["RFQ_VALIDITY_DAYS"].ToString();
            }
            else
            {
                g_Valdt_Days = "";
            }
            if (dtreqg.Rows[0]["RFQ_CLOSING_DATE"].ToString() != "")
            {
                g_clos_date = dtreqg.Rows[0]["RFQ_CLOSING_DATE"].ToString();
            }
            else
            {

                g_clos_date = "";
            }
            /////RFQ_VALIDITY_DAYS  g_Projct_refno
            if (dtreqg.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
            {
                g_Projct_refno = dtreqg.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            }
            else
            {

                g_Projct_refno = "";
            }

            if (dtreqg.Rows[0]["PROJECT_NAME"].ToString() != "")
            {
                g_Projct_name = dtreqg.Rows[0]["PROJECT_NAME"].ToString();
            }
            else
            {

                g_Projct_name = "";
            }
            if (dtreqg.Rows[0]["RFQ_INS_DATE"].ToString() != "")
            {
                g_Projct_Date = dtreqg.Rows[0]["RFQ_INS_DATE"].ToString();
            }
            else
            {
                g_Projct_Date = "";
            }

            if (dtreqg.Rows[0]["USR_NAME"].ToString() != "")
            {
                g_User_Name = dtreqg.Rows[0]["USR_NAME"].ToString();
            }
            else
            {
                g_User_Name = "";
            }
        }




        yPoint = yPoint + 80;
        //graph.DrawString("PARTICULARS OF TENDER BOND", font, XBrushes.Black, new XRect(0, 30, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
        yLine = yLine + 50;
        //graph.DrawLine(XPens.Black, 150, yLine, 445, yLine);
        yPoint = yPoint + 80;
        yLine = 0;






        //tf.Alignment = XParagraphAlignment.Right;




        //tf.Alignment = XParagraphAlignment.Left;
        //tf.DrawString("SL#", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint, 250, pdfPage.Height.Point), XStringFormats.TopLeft);
        string strclientfname = "";
        string strclientlname = "";
        string strclientmname = "";
        yPoint = yPoint + 25;


        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("01", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint, 170, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("TENDER NO & TITLE", fontEntryHeading, XBrushes.Black, new XRect(72, yPoint, 75, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString(g_Projct_refno + " , " + g_Projct_name, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);

        yPoint = yPoint + 20;
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("02", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint+10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("CLIENT", fontEntryHeading, XBrushes.Black, new XRect(72, yPoint+10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);

        if (g_customer_name.Length > 44)
        {
            strclientfname = g_customer_name.Substring(0, 42);
            strclientlname = g_customer_name.Substring(42,40);
           strclientmname = g_customer_name.Substring(82);
            tf.DrawString(strclientfname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint + 10;
            tf.DrawString(strclientlname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint +10;
            tf.DrawString(strclientmname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint + 10;
        }
        else
        {
            tf.DrawString(g_customer_name, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint+10, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
        }


        yPoint = yPoint + 30;
       
        if (g_Favour_Of != "")
        {
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("03", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint+10 , 170, pdfPage.Height.Point), XStringFormats.TopLeft);
            tf.DrawString("IN FAVOUR OF ", fontEntryHeading, XBrushes.Black, new XRect(72, yPoint + 10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);
            if (g_Favour_Of.Length > 44) 
            {
                strclientfname = g_Favour_Of.Substring(0, 42);
            strclientlname = g_Favour_Of.Substring(42,40);
           strclientmname = g_Favour_Of.Substring(82);
            tf.DrawString(strclientfname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint + 10;
            tf.DrawString(strclientlname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint +10;
            tf.DrawString(strclientmname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint = yPoint + 10;
            }
            else
            {
                tf.DrawString(g_Favour_Of, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint+10, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
            }
        }
        else
        {
           
            if (g_customer_name.Length > 44)
            {
                yPoint = yPoint - 30;
                tf.Alignment = XParagraphAlignment.Left;
                tf.DrawString("03", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint + 10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);
                tf.DrawString("IN FAVOUR OF ", fontEntryHeading, XBrushes.Black, new XRect(72, yPoint + 10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);

                strclientfname = g_customer_name.Substring(0, 42);
                strclientlname = g_customer_name.Substring(42, 40);
                strclientmname = g_customer_name.Substring(82);
                tf.DrawString(strclientfname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint + 10;
                tf.DrawString(strclientlname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint + 10;
                tf.DrawString(strclientmname, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint - 20;
            }
            else
            {
                tf.Alignment = XParagraphAlignment.Left;
                tf.DrawString("03", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint + 10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);
                tf.DrawString("IN FAVOUR OF ", fontEntryHeading, XBrushes.Black, new XRect(72, yPoint + 10, 170, pdfPage.Height.Point), XStringFormats.TopLeft);

                yPoint = yPoint + 30;
                tf.DrawString(g_customer_name, fontEntryHeading, XBrushes.Black, new XRect(210, yPoint-20, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint - 30;
            }

        }
        yPoint = yPoint + 40;
        tf.Alignment = XParagraphAlignment.Right;
        tf.DrawString("04", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("VALIDITY OF TENDER", fontEntryHeading, XBrushes.Black, new XRect(54, yPoint, 95, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("", fontEntryHeading, XBrushes.Black, new XRect(163.5, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        if (g_Valdt_Days == "")
        {
            yPoint = yPoint + 30;
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("05", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            tf.DrawString("VALIDITY OF TENDER BOND(DAYS)", fontEntryHeading, XBrushes.Black, new XRect(69, yPoint, 130, pdfPage.Height.Point), XStringFormats.TopLeft);
            tf.DrawString("**********", fontEntryHeading, XBrushes.Black, new XRect(163.5, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);

            //    yPoint = yPoint + 30;
            //    tf.Alignment = XParagraphAlignment.Right;
            //    tf.DrawString("05", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            //    tf.DrawString("Validity of Tender Bond", fontEntryHeading, XBrushes.Black, new XRect(70, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            //    tf.DrawString(g_clos_date, fontEntryHeading, XBrushes.Black, new XRect(153, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        }
        else
        {
            g_Valdt_Days = g_Valdt_Days.Trim();
            int e = 132;
            yPoint = yPoint + 30;
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("05", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            tf.DrawString("VALIDITY OF TENDER BOND(DAYS)", fontEntryHeading, XBrushes.Black, new XRect(69, yPoint, 130, pdfPage.Height.Point), XStringFormats.TopLeft);
            if (g_Valdt_Days.Length == 5)
            {
                e = e + 23;
                //tf.DrawString(stramount, fontEntryHeading, XBrushes.Black, new XRect(l, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
                tf.DrawString(g_Valdt_Days, fontEntryHeading, XBrushes.Black, new XRect(e, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            }
            if (g_Valdt_Days.Length > 5)
            {
                e = e + 33;
                //tf.DrawString(stramount, fontEntryHeading, XBrushes.Black, new XRect(l, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
                tf.DrawString(g_Valdt_Days, fontEntryHeading, XBrushes.Black, new XRect(e, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            }
            else
            {
                tf.DrawString(g_Valdt_Days, fontEntryHeading, XBrushes.Black, new XRect(e, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            }

            //yPoint = yPoint + 30;
            //tf.Alignment = XParagraphAlignment.Right;
            //tf.DrawString("05", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            //tf.DrawString("Validity of Tender Bond", fontEntryHeading, XBrushes.Black, new XRect(70, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
            //tf.DrawString(g_clos_date, fontEntryHeading, XBrushes.Black, new XRect(153, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        }
        //if (g_Valdt_Days == "")
        //{
        //    yPoint = yPoint + 30;
        //    tf.Alignment = XParagraphAlignment.Right;
        //    tf.DrawString("06", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //    tf.DrawString("Closing Date of Tender", fontEntryHeading, XBrushes.Black, new XRect(67, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //    tf.DrawString("**********", fontEntryHeading, XBrushes.Black, new XRect(153.5, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //}
        //else
        //{
        yPoint = yPoint + 30;
        tf.Alignment = XParagraphAlignment.Right;
        tf.DrawString("06", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("CLOSING DATE OF TENDER", fontEntryHeading, XBrushes.Black, new XRect(69, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString(g_clos_date, fontEntryHeading, XBrushes.Black, new XRect(162, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);

        // }
        //yPoint = yPoint + 30;
        //tf.Alignment = XParagraphAlignment.Right;
        //tf.DrawString("04", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //tf.DrawString("Validity of Tender", fontEntryHeading, XBrushes.Black, new XRect(48, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //tf.DrawString("**********", fontEntryHeading, XBrushes.Black, new XRect(153.5, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);


        yPoint = yPoint + 30;
        tf.Alignment = XParagraphAlignment.Right;
        tf.DrawString("07", fontEntryHeading, XBrushes.Black, new XRect(-30, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString("VALUE OF TENDER BOND", fontEntryHeading, XBrushes.Black, new XRect(69, yPoint, 95, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.Alignment = XParagraphAlignment.Right;
        if (g_abbrv == "INR")
        {
            //tf.DrawString(g_abbrv, fontEntryHeading, XBrushes.Black, new XRect(127, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        }
        else
        {
            // tf.DrawString(g_abbrv, fontEntryHeading, XBrushes.Black, new XRect(130, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        }
        int l = 160;
        if (g_amount.Length >= 9)
        {
            string stramount = objBusiness.AddCommasForNumberSeperation(g_amount, objEntityCommon);
            // decimal decamount = Convert.ToDecimal(stramount);
            //string strfloatValue =hiddenDecimalCount.Value;
            //int intDecmlCount = Convert.ToInt32(strfloatValue);
            //stramount = Convert.ToString(Math.Round(decamount, intDecmlCount));
            l = l + 40;
            tf.DrawString(stramount + " " + g_abbrv, fontEntryHeading, XBrushes.Black, new XRect(l, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
        }
        //else if (g_amount.Length <= 4)
        //{ objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

        //    tf.DrawString(g_amount, fontEntryHeading, XBrushes.Black, new XRect(l, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
        //}
        else if (g_amount.Length <= 8)
        {

            string stramount = objBusiness.AddCommasForNumberSeperation(g_amount, objEntityCommon);

            //double decamount = Convert.ToDouble(stramount);
            // string strfloatValue = hiddenDecimalCount.Value;
            // int intDecmlCount = Convert.ToInt32(strfloatValue);
            // stramount = Convert.ToString(Math.Round(decamount, intDecmlCount));
            l = l + 20;
            tf.DrawString(stramount + " " + g_abbrv, fontEntryHeading, XBrushes.Black, new XRect(l, yPoint, 100, pdfPage.Height.Point), XStringFormats.TopLeft);
        }

        yPoint = yPoint + 100;
        tf.Alignment = XParagraphAlignment.Left;

        tf.DrawString("REQUESTED BY", fontEntryHeading, XBrushes.Black, new XRect(95, yPoint, 510, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.Alignment = XParagraphAlignment.Right;
        tf.DrawString("APPROVED BY", fontEntryHeading, XBrushes.Black, new XRect(-110, yPoint, 510, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 30;
        tf.Alignment = XParagraphAlignment.Left;


        tf.DrawString("NAME :", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.DrawString(g_User_Name, fontEntryHeading, XBrushes.Black, new XRect(90, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.Alignment = XParagraphAlignment.Right;


        tf.DrawString("DIVISION HEAD", fontEntryHeading, XBrushes.Black, new XRect(250, yPoint, 65, pdfPage.Height.Point), XStringFormats.TopLeft);

        tf.DrawString("GM", fontEntryHeading, XBrushes.Black, new XRect(395, yPoint, 65, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 30;
        tf.Alignment = XParagraphAlignment.Left;

        tf.DrawString("SIGN :", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);
        //tf.DrawString("*******", fontEntryHeading, XBrushes.Black, new XRect(90, yPoint, 90, pdfPage.Height.Point), XStringFormats.TopLeft);

        yPoint = yPoint + 60;

        tf.Alignment = XParagraphAlignment.Left;

        tf.DrawString("FOR FINANCE DEPT:", fontEntryHeading, XBrushes.Black, new XRect(50, yPoint, 510, pdfPage.Height.Point), XStringFormats.TopLeft);
        //tf.DrawString("*******", fontEntryHeading, XBrushes.Black, new XRect(70, yPoint, 580, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 25;
        tf.Alignment = XParagraphAlignment.Right;

        tf.DrawString("RECEIVED DATE", fontEntryHeading, XBrushes.Black, new XRect(245, yPoint, 65, pdfPage.Height.Point), XStringFormats.TopLeft);

        yPoint = yPoint + 25;
        tf.Alignment = XParagraphAlignment.Right;

        tf.DrawString("FINANCE MANAGER", fontEntryHeading, XBrushes.Black, new XRect(40, yPoint, 85, pdfPage.Height.Point), XStringFormats.TopLeft);
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("BANK", fontEntryHeading, XBrushes.Black, new XRect(257, yPoint, 75, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 30;

        yLine = yLine + 22;




        //row line
        //graph.DrawLine(XPens.Black, -100, yLine, 500, yLine);

        //graph.DrawLine(XPens.Black, -40, yLine, 555, yLine);



        yLine = yLine + 155;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);

        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        //column line0 
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, 177, 40, yLine);
        //xPoint = xPoint + 10;
        graph.DrawLine(XPens.Black, 40, 177, 40, yLine);
        //yLine = yLine + 45;
        //graph.DrawLine(XPens.Black, 40, 177, 40, yLine);

        //yLine = yLine + 25;
        // for coloumn   graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);

        //column line1
        yLine = yLine + 0;
        graph.DrawLine(XPens.Black, 200, 177, 200, yLine);

        //column line2


        //column line3
        graph.DrawLine(XPens.Black, 555, 177, 555, yLine);//177 for line lngth;555 x y cordinates same;
        graph.DrawLine(XPens.Black, 69, 177, 69, yLine);
        yLine = yLine + 0;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);


        /* first table closed*/

        /* second table*/
        //coloums;;
        yLine = yLine + 77;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);//310 for row length;
        yLine = yLine + 25;


        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);// 555 for x end length; 40 x start length
        yLine = yLine + 25;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 35;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);

        graph.DrawLine(XPens.Black, 40, 464, 40, yLine);
        graph.DrawLine(XPens.Black, 200, 464, 200, yLine);
        graph.DrawLine(XPens.Black, 375, 489, 375, yLine);
        graph.DrawLine(XPens.Black, 555, 464, 555, yLine);

        /*second table close*/
        /* third table start*/


        yLine = yLine + 35;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 15;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 250, yLine, 555, yLine);
        yLine = yLine + 30;
        graph.DrawLine(XPens.Black, 40, yLine, 555, yLine);

        graph.DrawLine(XPens.Black, 40, 583, 40, yLine);//1 st line 

        graph.DrawLine(XPens.Black, 555, 584, 555, yLine);// last line;
        graph.DrawLine(XPens.Black, 380, 600, 380, yLine);
        graph.DrawLine(XPens.Black, 250, 600, 250, yLine);

        /* 3 table closed*/

        yPoint = yPoint + 17;
        tf.Alignment = XParagraphAlignment.Right;
        tf.DrawString("IMPORTANT NOTE:", fontEntryHeading, XBrushes.Black, new XRect(38, yPoint, 75, pdfPage.Height.Point), XStringFormats.TopLeft);
        yLine = yLine + 33;
        graph.DrawLine(XPens.Black, 42, yLine, 110, yLine);

        yPoint = yPoint + 15;
        tf.DrawString("*    TENDER BOND REQUEST MUST BE SENT 3 WORKING DAYS BEFORE CLOSING DATE", fontImportants, XBrushes.Black, new XRect(-7.5, yPoint, 290, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 10;
        tf.DrawString("*    TENDER BOND ANNEXURE TO BE ATTACHED WITH THIS FORM ", fontImportants, XBrushes.Black, new XRect(-45, yPoint, 270, pdfPage.Height.Point), XStringFormats.TopLeft);

        string strFilePath = objcommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
        yPoint = 0;
        yLine = 0;
        yLine = yLine + 40;
        graph.DrawLine(XPens.Black, 42, yLine, 554, yLine);
        yLine = yLine + 55;
        graph.DrawLine(XPens.Black, 144, yLine, 554, yLine);
        yLine = yLine + 10;
        graph.DrawLine(XPens.Black, 42, yLine, 554, yLine);

        yPoint = yPoint + 60;
        tf.DrawString("TENDER BOND REQUEST FORM", font, XBrushes.Black, new XRect(-45, yPoint, 500, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 35;
        tf.DrawString("REV NO :  03", fontImportants, XBrushes.Black, new XRect(-125, yPoint, 425, pdfPage.Height.Point), XStringFormats.TopLeft);

        tf.DrawString("DOC NO : F 106", fontImportants, XBrushes.Black, new XRect(-210, yPoint, 400, pdfPage.Height.Point), XStringFormats.TopLeft);
        // tf.DrawString(g_id, fontImportants, XBrushes.Black, new XRect(-155, yPoint, 400, pdfPage.Height.Point), XStringFormats.TopLeft);

        tf.DrawString("DATE : 22.09.15", fontImportants, XBrushes.Black, new XRect(30, yPoint, 400, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 25;
        tf.DrawString("DATE OF REQUEST :", fontdatereq, XBrushes.Black, new XRect(120, yPoint, 400, pdfPage.Height.Point), XStringFormats.TopLeft);
        yPoint = yPoint + 1;
        tf.DrawString(g_Projct_Date, fontImportants, XBrushes.Black, new XRect(155, yPoint, 400, pdfPage.Height.Point), XStringFormats.TopLeft);
        graph.DrawString("PARTICULARS OF TENDER BOND", font, XBrushes.Black, new XRect(20, 133, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

        yPoint = 0;
        graph.DrawLine(XPens.Black, 144, 40, 144, yLine);// last line;
        graph.DrawLine(XPens.Black, 380, 95, 380, yLine);
        graph.DrawLine(XPens.Black, 260, 95, 260, yLine);
        graph.DrawLine(XPens.Black, 554, 40, 554, yLine);
        graph.DrawLine(XPens.Black, 42, 40, 42, yLine);

        yLine = yLine + 47;
        graph.DrawLine(XPens.Black, 170, yLine, 465, yLine);
        string strFileName = "Request-" + intReqId + "_GUARANTEE.pdf";

        string pageurl = strFilePath + strFileName;
        ScriptManager.RegisterStartupScript(this, GetType(), "PreviewPDF", "PreviewPDF('" + pageurl + "');", true);


        pdf.Save(Server.MapPath(strFilePath) + strFileName);
        pdf.Close();
        pdf.Dispose();
    }
}