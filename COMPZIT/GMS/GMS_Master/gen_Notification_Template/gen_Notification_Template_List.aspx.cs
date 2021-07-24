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
// CREATED BY:EVM-0005
// CREATED DATE:7/1/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Notification_Template_gen_Notification_Template_List : System.Web.UI.Page
{
    classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
    protected void Page_Load(object sender, EventArgs e)
    {

        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ReadNotificationType();
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

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }

                //Creating objects for business layer
                classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];
                    string strTempType = strSearchFields[2];
                   // string strCntrctrType = strSearchFields[3];


                    if (strTempType != null && strTempType != "")
                    {
                        if (ddlTempType.Items.FindByValue(strTempType) != null)
                        {
                            ddlTempType.Items.FindByValue(strTempType).Selected = true;
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
                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
                    objEntityNotTemp.User_Id = intUserId;

                    objEntityNotTemp.D_Date = System.DateTime.Now;

                    DataTable dtTemplateDetail = new DataTable();
                    dtTemplateDetail = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);
                    string strNameCount = "0";
                    if (dtTemplateDetail.Rows.Count > 0)
                    {
                        objEntityNotTemp.TemplateName = dtTemplateDetail.Rows[0]["NOTFTEMP_NAME"].ToString();
                    }
                    strNameCount = ObjBusinessNotiFi.CheckTemplateName(objEntityNotTemp);

                    if (strNameCount == "0")
                    {
                        ObjBusinessNotiFi.ReCallNotificationTemp(objEntityNotTemp);
                       if (HiddenSearchField.Value == "")
                      {
                           Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Recl");
                      }
                     else
                       {
                           Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                       }
                   }
                    else
                    {
                        if (strNameCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        }
                      
                    }

                }

                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
                    objEntityNotTemp.User_Id = intUserId;

                    objEntityNotTemp.D_Date = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityNotTemp.CancelReason = objCommon.CancelReason();

                            ObjBusinessNotiFi.CancelNotificationTemp(objEntityNotTemp);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {




                            if (HiddenSearchField.Value == "")
                            {
                                objEntityNotTemp.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                objEntityNotTemp.NotTypeId = 0;
                                objEntityNotTemp.Cancel_Status = 0;
                            }
                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;

                                string[] strSearchFields = strHidden.Split(',');
                                string strddlStatus = strSearchFields[0];
                                string strCbxStatus = strSearchFields[1];
                                string strTempType = strSearchFields[2];

                                if (strTempType != "")
                                {
                                    if (ddlTempType.Items.FindByValue(strTempType) != null)
                                    {
                                        ddlTempType.Items.FindByValue(strTempType).Selected = true;
                                        objEntityNotTemp.NotTypeId = Convert.ToInt32(strTempType);
                                    }
                                }

                                if (strddlStatus != null && strddlStatus != "")
                                {
                                    if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                                    {
                                        ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                                        objEntityNotTemp.Status = Convert.ToInt32(strddlStatus);
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
                                objEntityNotTemp.Cancel_Status = Convert.ToInt32(strCbxStatus);
                            }
                            DataTable dtTemplate = new DataTable();
                            dtTemplate = ObjBusinessNotiFi.ReadNotfcnTempList(objEntityNotTemp);

                            string strHtm = ConvertDataTableToHTML(dtTemplate, intEnableModify, intEnableCancel, intEnableRecall);
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
                        objEntityNotTemp.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                        objEntityNotTemp.NotTypeId = Convert.ToInt32(ddlTempType.SelectedItem.Value);
                        objEntityNotTemp.Cancel_Status = 0;
                    }

                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strddlStatus = strSearchFields[0];
                        string strCbxStatus = strSearchFields[1];
                        string strTempType = strSearchFields[2];


                        if (strTempType != "")
                        {
                            if (ddlTempType.Items.FindByValue(strTempType) != null)
                            {
                                ddlTempType.Items.FindByValue(strTempType).Selected = true;
                                objEntityNotTemp.NotTypeId = Convert.ToInt32(strTempType);
                            }
                        }

                        if (strddlStatus != null && strddlStatus != "")
                        {
                            if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                            {
                                ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                                objEntityNotTemp.Status = Convert.ToInt32(strddlStatus);
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
                        objEntityNotTemp.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    DataTable dtTemplate = new DataTable();
                    dtTemplate = ObjBusinessNotiFi.ReadNotfcnTempList(objEntityNotTemp);

                    string strHtm = ConvertDataTableToHTML(dtTemplate, intEnableModify, intEnableCancel, intEnableRecall);
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
                        else if (strInsUpd == "StsDfltCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusDefaultChange", "SuccessStatusDefaultChange();", true);
                        }
                        else if (strInsUpd == "InsFail")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailedConfirmation", "FailedConfirmation();", true);
                        }
                            //emp0015
                        else if (strInsUpd == "InsModify")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ModifyConfirmation", "ModifyConfirmation();", true);
                        }
                    }
                }
                
            }
        }
    }
    //for binding dropdown
    public void ReadNotificationType()
    {

        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtTempType = ObjBusinessNotiFi.ReadTemplateType(objEntityNotTemp);
        if (dtTempType.Rows.Count > 0)
        {
            ddlTempType.DataSource = dtTempType;
            ddlTempType.DataTextField = "TEMPTYPE_NAME";
            ddlTempType.DataValueField = "TEMPTYPE_ID";
            ddlTempType.DataBind();

        }

        //ddlTempType.Items.Insert(0, "--SELECT TEMPLATE TYPE--");
    }
  
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int intReCallForTAble = 0;
        if (cbxCnclStatus.Checked==true)
        {
            intReCallForTAble = 1;
        }


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:42%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }


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
        //EVM-0027
        if (Convert.ToInt32(ddlTempType.SelectedItem.Value) == 101)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">MODIFY-GUARANTEES</th>";
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">MODIFY-INSURANCES</th>";
        }
        //END
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            string strDefaultStsMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:42%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][3].ToString();
            strDefaultStsMode = dt.Rows[intRowBodyCount][4].ToString();
            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
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


            //for default
            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (strDefaultStsMode == "DEFAULT")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Change From Default \" onclick=\"return ChangeDefaultStatus('" + strId + "','" + strDefaultStsMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/DefaultNotify.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Default\" onclick=\"return ChangeDefaultStatus('" + strId + "','" + strDefaultStsMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/cancel.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strDefaultStsMode == "DEFAULT")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Change From Default \" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/DefaultNotify.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Default\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/cancel.png' /> " + "</a> </td>";
                    }
                }

            }
            else
            {
                if (strDefaultStsMode == "DEFAULT")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Default\" >" +
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/DefaultNotify.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Change From Default \" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/cancel.png' /> " + "</a> </td>";
                }
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Notification_Template.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Notification_Template.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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
                                 " href=\"gen_Notification_Template_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                               " href=\"gen_Notification_Template_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



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
                                 " href=\"gen_Notification_Template_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                 " href=\"gen_Notification_Template_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                        }
                    }
                }
            }
            //EVM-0027
            if (Convert.ToInt32(ddlTempType.SelectedItem.Value) == 101)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Modify Gurantees\"  onclick=\"return ModifyGurantess('" + Id + "'); \"style=\"cursor: pointer;\" " +
                                     " href=\"# \">" + "<img  src='/Images/Icons/success.png' /> " + "</a> </td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Modify Insurances\"  onclick=\"return ModifyInsurances('" + Id + "'); \"style=\"cursor: pointer;\" " +
                                 " href=\"# \">" + "<img  src='/Images/Icons/success.png' /> " + "</a> </td>";
            }
            //END
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
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityNotTemp.NotTempId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityNotTemp.D_Date = System.DateTime.Now;

            objEntityNotTemp.CancelReason = txtCnclReason.Text.Trim();
            ObjBusinessNotiFi.CancelNotificationTemp(objEntityNotTemp);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Notification_Template_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        objEntityNotTemp.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        //if (ddlTempType.SelectedItem.Value.ToString() != "--SELECT TEMPLATE TYPE--")
        //{
            objEntityNotTemp.NotTypeId = Convert.ToInt32(ddlTempType.SelectedItem.Value);
        //}
        //else
        //{
            //objEntityNotTemp.NotTypeId = 0;
        //}
      
        if (cbxCnclStatus.Checked == true)
            objEntityNotTemp.Cancel_Status = 1;
        else
            objEntityNotTemp.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtTemplate = new DataTable();

        dtTemplate = ObjBusinessNotiFi.ReadNotfcnTempList(objEntityNotTemp);


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

        string strHtm = ConvertDataTableToHTML(dtTemplate, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }


    [WebMethod]
    public static string ChangeTemplateStatus(int strCatId, string strStatus)
    {

        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityNotTemp.Status = 0;
        }
        else
        {
            objEntityNotTemp.Status = 1;
        }
        objEntityNotTemp.NotTempId = strCatId;
        try
        {
            ObjBusinessNotiFi.ChangeStatusTemp(objEntityNotTemp);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    //EVM-0027 
    [WebMethod]
    public static string ChangeTemplateDefault(int strCatId, string strStatus, string ddlType)
    {

        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        string strRet = "success";

        if (strStatus == "DEFAULT")
        {
            objEntityNotTemp.DefaultOrNot = 0;
        }
        else
        {
            objEntityNotTemp.DefaultOrNot = 1;
        }
        objEntityNotTemp.NotTypeId = Convert.ToInt32(ddlType);
        objEntityNotTemp.NotTempId = strCatId;
        try
        {
            ObjBusinessNotiFi.ChangeDefaultSts(objEntityNotTemp);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    //END
}