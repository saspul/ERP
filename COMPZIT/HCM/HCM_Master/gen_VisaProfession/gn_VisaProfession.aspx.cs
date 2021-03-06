using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class Master_gen_VisaProfession_gn_VisaProfession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntityLayerVisaProfession objEntityVisa = new clsEntityLayerVisaProfession();
        clsBusinessLayerVisaProfession objBusinessVisa = new clsBusinessLayerVisaProfession();
        txtVisaName.Focus();
        txtVisaName.Attributes.Add("onkeypress", "return isTagEnter(event)");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            
            txtVisaName.Attributes.Add("onkeypress", "return isTag(event)");
            cbxStatus.Checked = true;
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            hiddenupd.Value = "";
            bool blShowCancel = false;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
             

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVisa.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityVisa.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notification_Template);
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
            else
            {
                ddlStatus.Items.FindByValue("1").Selected = true;
            }

            objEntityVisa.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if(cbxCnclStatus.Checked == true)
            {
            objEntityVisa.Cancel_Status = 1;
            }
            else
            {
                 objEntityVisa.Cancel_Status = 0;
            }
            //EMP17
            DataTable dtVisaDetal = new DataTable();
            dtVisaDetal = objBusinessVisa.ReadDetails(objEntityVisa);
            //int intEnableModify = 1, intEnableCancel = 1, intEnableRecall = 1;
            string strHtm = ConvertDataTableToHTML(dtVisaDetal, intEnableModify, intEnableCancel, intEnableRecall, intUserId, blShowCancel);
            //Write to divReport
            divReport.InnerHtml = strHtm;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusUpdation", "StatusUpdation();", true);
                }
                else if (strInsUpd == "updErr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FailedUpdation", "FailedUpdation();", true);

                }
                else if (strInsUpd == "insErr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FailedInsersion", "FailedInsersion();", true);

                }
                else if (strInsUpd == "upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }


            }
            else if (Request.QueryString["Id1"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["Id1"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityVisa.VisaId = Convert.ToInt32(strId);
                objEntityVisa.UserCnclId = intUserId;

                objEntityVisa.CnclDate = System.DateTime.Now;

                intCorpId = 0;

                intCorpId = objEntityVisa.CorpId;



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        objEntityVisa.Cancel_Reason = objCommon.CancelReason();
                        objBusinessVisa.CancelVisa(objEntityVisa);
                        if (HiddenSearchField.Value == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else
                        {
                            Response.Redirect("gn_VisaProfession.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);

                        }

                    }
                    else
                    {

                        DataTable dtUser = new DataTable();
                        if (HiddenSearchField.Value == "")
                        {
                            objEntityVisa.Status = 1;
                        }
                        else
                        {
                            string strHidden = HiddenSearchField.Value;

                            string[] strSearchFields = strHidden.Split(',');

                            string strStatus = strSearchFields[0];
                            string strCbxShowCancel = strSearchFields[1];

                            objEntityVisa.Status = Convert.ToInt32(strStatus);
                            objEntityVisa.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                        }
                        dtUser = objBusinessVisa.ReadDetails(objEntityVisa);

                        //string strHtm = "";
                        if (objEntityVisa.Status == 0)
                        {
                            blShowCancel = false;
                        }
                        else
                        {
                            blShowCancel = true;

                        }

                        strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecall, intUserId, blShowCancel);

                        //Write to divReport
                        divReport.InnerHtml = strHtm;
                        hiddenCancelPrimaryId.Value = strId;
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "OpenCancelView("+strId+");", true);
                        //  ModalPopupExtenderCncl.Show();

                    }

                }
                else
                {
                    objEntityVisa.Cancel_Reason = objCommon.CancelReason();
                    objBusinessVisa.CancelVisa(objEntityVisa);
                    if (HiddenSearchField.Value == "")
                    {
                        Response.Redirect("gn_VisaProfession.aspx?InsUpd=Cncl");
                    }
                    else
                    {
                        Response.Redirect("gn_VisaProfession.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);

                    }

                }
            }


            //when editing 
            if (Request.QueryString["Id"] != null && Request.QueryString["InsUpd"] != "upd")
            {
                hiddenupd.Value = "upd";
                lblAdd.Text = "Edit Visa Profession";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                txtVisaName.Enabled = true;
                DataTable dt = new DataTable();
                dt = objBusinessVisa.getDetails_ById(strId);
                txtVisaName.Text = dt.Rows[0]["VISA_NAME"].ToString().ToUpper();
                objEntityVisa.VisaName = txtVisaName.Text.Trim().ToUpper();      //emp17

                if (dt.Rows[0]["VISA_STATUS"].ToString() == "1")
                    cbxStatus.Checked = true;
                else
                    cbxStatus.Checked = false;
                // Button clickedButton = sender as Button;

                btnSave.Text = "Update";



                objEntityVisa.UpDate = DateTime.Now;
                objEntityVisa.UserUpId = Convert.ToInt32(Session["USERID"]);

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                //btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblAdd.Text = "View Visa Profession";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerVisaProfession objEntityVisa = new clsEntityLayerVisaProfession();
        clsBusinessLayerVisaProfession objBusinessVisa = new clsBusinessLayerVisaProfession();
        int intUserId = 0, intCorpId = 0;
        int intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisa.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisa.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notification_Template);
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
        //when editing 
        if (btnSave.Text == "Update" && hiddenupd.Value == "upd")
        {
            //Request.QueryString["InsUpd"] = "upd";
            
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            // DataTable dt = new DataTable();
            // dt = objBusinessVisa.getDetails_ById(strId);
            // txtVisaName.Text = dt.Rows[0]["VISA_NAME"].ToString();
            objEntityVisa.VisaId = Convert.ToInt32(strId);       //emp17
            // txbName.Enabled = true;
            //objEntityVisa.VisaName = txtVisaName.Text.Trim();//emp17
            //// string strCount = objBusinessVisa.ReadVisaName(objEntityVisa);
            //  if (Convert.ToInt32(strCount) == 1)
            //     Response.Redirect("gn_VisaType.aspx?InsUpd=updErr");
            // else
            //  {
            objEntityVisa.VisaName = txtVisaName.Text.Trim().ToUpper();//emp17
            string strCount = objBusinessVisa.ReadVisaName(objEntityVisa);
            if (Convert.ToInt32(strCount) == 1)
                ScriptManager.RegisterStartupScript(this, GetType(), "FailedInsersion", "FailedInsersion();", true);
            else
            {       //emp17











                if (cbxStatus.Checked == true)
                    objEntityVisa.Status = 1;
                else
                    objEntityVisa.Status = 0;

                objEntityVisa.UpDate = DateTime.Now;
                objEntityVisa.UserUpId = Convert.ToInt32(Session["USERID"]);
                objBusinessVisa.updateVisa(objEntityVisa);

                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                lblAdd.Text = "Add Visa Profession";
                hiddenupd.Value = "";
                btnSave.Text = "SAVE";
                txtVisaName.Text = "";
                txtVisaName.BorderColor = System.Drawing.Color.Empty;
                txtVisaName.Focus();
                bool blShowCancel = false;
                DataTable dtVisaDetal = new DataTable();
                dtVisaDetal = objBusinessVisa.ReadDetails(objEntityVisa);
                string strHtm = ConvertDataTableToHTML(dtVisaDetal, intEnableModify, intEnableCancel, intEnableRecall, intUserId, blShowCancel);
                divReport.InnerHtml = strHtm;
               




            }//emp17
            //  }
        }
       
        else
        {
            objEntityVisa.VisaId = 0;      //emp17
            objEntityVisa.VisaName = txtVisaName.Text.Trim().ToUpper();//emp17
            string strCount = objBusinessVisa.ReadVisaName(objEntityVisa);
            if (Convert.ToInt32(strCount) == 1)
                ScriptManager.RegisterStartupScript(this, GetType(), "FailedInsersion", "FailedInsersion();", true);
            else
            {
                objEntityVisa.UserInsId = intUserId;
                string visaName = txtVisaName.Text.Trim().ToUpper();//emp17
                objEntityVisa.VisaName = visaName;
                int status = 1;
                if (cbxStatus.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                objEntityVisa.Status = status;
                DateTime today = DateTime.Now;
                objEntityVisa.InsDate = today;

                if (clickedButton.ID == "btnSave")
                {
                    objBusinessVisa.addDetails(objEntityVisa);
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);   //emp17
                    txtVisaName.Text = "";
                    txtVisaName.BorderColor = System.Drawing.Color.Empty;
                    txtVisaName.Focus();
                    bool blShowCancel = false;
                    DataTable dtVisaDetal = new DataTable();
                    dtVisaDetal = objBusinessVisa.ReadDetails(objEntityVisa);
                    string strHtm = ConvertDataTableToHTML(dtVisaDetal, intEnableModify, intEnableCancel, intEnableRecall, intUserId, blShowCancel);
                    divReport.InnerHtml = strHtm;  //emp17
                    
                }
                else
                {
                    Response.Redirect("gn_VisaProfession.aspx");
                }
                txtVisaName.Text = "";    //emp17
            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecallCancelled, int intUserId, bool blShowCancelled)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        //strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL.NO</th>";
        int intReCallForTAble = 0;

        //  int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
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
                strHtml += "<th class=\"thT\" style=\"width:65%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">DELETE</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecallCancelled == 1)
            {
                //strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
            //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + (intRowBodyCount + 1) + "</td>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:65%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][2].ToString();
            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (strStatusMode == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\"  onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png'  /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png'  /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strStatusMode == "1")
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
                if (strStatusMode == "1")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                        "<img  style=\"\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gn_VisaProfession.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                            " href=\"gn_VisaProfession.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
            }


            if (blShowCancelled == false && cbxCnclStatus.Checked==false)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gn_VisaProfession.aspx?Id1=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                   " href=\"gn_VisaProfession.aspx?Id1=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td c lass=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +
                                    "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }

                }
                
            }
            if (blShowCancelled == true && cbxCnclStatus.Checked == false)
            {
                if (intEnableRecallCancelled == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (HiddenSearchField.Value == "")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gn_VisaProfession.aspx?Id1=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                           " href=\"gn_VisaProfession.aspx?Id1=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                }
                else
                {

                }
            }
            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";


        sb.Append(strHtml);
        return sb.ToString();

    }
    [WebMethod]
    public static string ChangeVisaStatus(string strCatId, string strStatus)
    {

        clsEntityLayerVisaProfession objEntityVisa = new clsEntityLayerVisaProfession();
        clsBusinessLayerVisaProfession objBusinessVisa = new clsBusinessLayerVisaProfession();
        string strRet = "success";

        if (strStatus == "1")
        {
            objEntityVisa.Status = 0;
        }
        else
        {
            objEntityVisa.Status = 1;
        }
        objEntityVisa.VisaId = Convert.ToInt32(strCatId);
        try
        {
            objBusinessVisa.ChangeStatus(objEntityVisa);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsBusinessLayerVisaProfession objBusinesVisa = new clsBusinessLayerVisaProfession();
        clsEntityLayerVisaProfession objentityvisa = new clsEntityLayerVisaProfession();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objentityvisa.VisaId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objentityvisa.UserCnclId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objentityvisa.CnclDate = System.DateTime.Now;

            objentityvisa.Cancel_Reason = txtCnclReason.Text.Trim();//emp17
            objBusinesVisa.CancelVisa(objentityvisa);


            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gn_VisaProfession.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gn_VisaProfession.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);

            }

        }
    }
    protected void btnCancl_Click(object sender, EventArgs e)
    {
        txtVisaName.Text = "";
        cbxStatus.Checked = true;
        if (hiddenupd.Value == "upd")
        {
            txtVisaName.Enabled = true;
            txtVisaName.Text = "";
            cbxStatus.Checked = true;
            btnSave.Text = "SAVE";
            Response.Redirect("gn_VisaProfession.aspx");
        }
        if (hiddenupd.Value == "view")
        {
            txtVisaName.Enabled = true;
            txtVisaName.Text = "";
            cbxStatus.Checked = true;
            btnSave.Text = "SAVE";
            Response.Redirect("gn_VisaProfession.aspx");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityLayerVisaProfession objEntityVisaa = new clsEntityLayerVisaProfession();
       string strStatus = ddlStatus.SelectedItem.Text;
       objEntityVisaa.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
            objEntityVisaa.Cancel_Status = 1;
        else
            objEntityVisaa.Cancel_Status = 0;

        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityVisaa.UserInsId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisaa.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisaa.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        bool blShowCancel = false;
        if (cbxCnclStatus.Checked == true)
        {
            blShowCancel = true;
        }
        else
        {
            blShowCancel = false;

        }


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

        DataTable dt = new DataTable();
        clsBusinessLayerVisaProfession objBusinessVisa = new clsBusinessLayerVisaProfession();
        dt = objBusinessVisa.ReadDetails(objEntityVisaa);

        string strHtm = ConvertDataTableToHTML(dt, intEnableModify, intEnableCancel, intEnableRecall, intUserId, blShowCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {

        btnSave.Visible = false;
        //   clsEntitySponsor objEntitySponsor = new clsEntitySponsor();
        clsBusinessLayerVisaProfession objBussVisa = new clsBusinessLayerVisaProfession();
        clsEntityLayerVisaProfession objEntityVisa = new clsEntityLayerVisaProfession();
        if (Session["USERID"] != null)
        {

            objEntityVisa.UserInsId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {

            // objEntityPayroll.UserId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityVisa.CorpId = intCorpId;

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {

            objEntityVisa.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        hiddenupd.Value = "view";
        //txtVisaName.Text = strP_Id;
        //txtVisaName.Enabled = false;
        //objEntityPayroll.Sponsor_Id = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBussVisa.getDetails_ById(strP_Id);
        if (dtSponsor.Rows.Count > 0)
        {

            txtVisaName.Text = dtSponsor.Rows[0]["VISA_NAME"].ToString();
            txtVisaName.Enabled = false;

            int intStatus = Convert.ToInt32(dtSponsor.Rows[0]["VISA_STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            cbxStatus.Enabled = false;
        }
    }
}
