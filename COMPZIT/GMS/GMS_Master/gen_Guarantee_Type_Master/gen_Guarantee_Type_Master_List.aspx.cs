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
// CREATED DATE:02/01/2017
// REVIEWED BY:
// REVIEW DATE:


public partial class GMS_GMS_Master_gen_Guarantee_Type_Master_gen_Guarantee_Type_Master_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intUsrRolMstrIdRecallCancelled, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecallCancelled = 0;
            bool blShowCancel = false;
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


            intUsrRolMstrIdRecallCancelled = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtChildRolRecallCancelled = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdRecallCancelled);
            if (dtChildRolRecallCancelled.Rows.Count > 0)
            {
                intEnableRecallCancelled = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Guarantee_Type_Master);
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

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }


                //Creating object for business layer and data table
                classBusinessLayerGuaranteType objBusinessLayerGuarantee = new classBusinessLayerGuaranteType();
                classEntityLayerGuaranteType objEntityGuaranteType = new classEntityLayerGuaranteType();

                

                if (Session["ORGID"] != null)
                {
                    objEntityGuaranteType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityGuaranteType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    hiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split('_');

                    string strddlStatus = strSearchFields[0];
                    string strCbxShowCancel = strSearchFields[1];


                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxShowCancel == "1")
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

                    objEntityGuaranteType.GuaranteeTypeId = Convert.ToInt32(strId);
                    objEntityGuaranteType.User_Id = intUserId;

                    objEntityGuaranteType.D_Date = System.DateTime.Now;
                    DataTable dtJobDetail = new DataTable();
                    dtJobDetail = objBusinessLayerGuarantee.ReadGuaranteTypeById(objEntityGuaranteType);
                    string strName = "", strNameCount = "0";
                    if (dtJobDetail.Rows.Count > 0)
                    {

                        strName = dtJobDetail.Rows[0]["GUANTCAT_NAME"].ToString();
                    }

                    if (strName != "")
                    {
                        objEntityGuaranteType.GuaranteTypename = strName;
                    }

                    strNameCount = objBusinessLayerGuarantee.CheckGuaranteTypeName(objEntityGuaranteType);

                    if (strNameCount == "0")
                    {

                        objBusinessLayerGuarantee.ReCallGuaranteType(objEntityGuaranteType);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Recl");
                        }
                        else
                        {
                            Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Recl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }
                    else
                    {
                        DataTable dtUser = new DataTable();
                        if (hiddenSearchField.Value == "")
                        {
                            objEntityGuaranteType.Guar_Typ_Status = 1;
                            objEntityGuaranteType.Cancel_Status = 0;


                        }
                        else
                        {
                            string strHidden = hiddenSearchField.Value;

                            string[] strSearchFields = strHidden.Split('_');

                            string strddlStatus = strSearchFields[0];
                            string strCbxShowCancel = strSearchFields[1];

                            objEntityGuaranteType.Guar_Typ_Status = Convert.ToInt32(strddlStatus);
                            objEntityGuaranteType.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                        }
                        dtUser = objBusinessLayerGuarantee.ReadGuaranteTypeList(objEntityGuaranteType);

                        string strHtm = "";
                        if (objEntityGuaranteType.Cancel_Status == 0)
                        {
                            blShowCancel = false;
                        }
                        else
                        {
                            blShowCancel = true;

                        }

                        strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecallCancelled, intUserId, blShowCancel);

                        //Write to divReport
                        divReport.InnerHtml = strHtm;
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    }


                }


                else if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityGuaranteType.GuaranteeTypeId = Convert.ToInt32(strId);
                    objEntityGuaranteType.User_Id = intUserId;

                    objEntityGuaranteType.D_Date = System.DateTime.Now;

                    int intCorpId = 0;

                    intCorpId = objEntityGuaranteType.CorpOffice_Id;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityGuaranteType.Cancel_reason = objCommon.CancelReason();
                            objBusinessLayerGuarantee.CancelGuaranteType(objEntityGuaranteType);
                            if (hiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                            }

                        }
                        else
                        {

                            DataTable dtUser = new DataTable();
                            if (hiddenSearchField.Value == "")
                            {
                                objEntityGuaranteType.Guar_Typ_Status = 1;
                                objEntityGuaranteType.Cancel_Status = 0;


                            }
                            else
                            {
                                string strHidden = hiddenSearchField.Value;

                                string[] strSearchFields = strHidden.Split('_');

                                string strddlStatus = strSearchFields[0];
                                string strCbxShowCancel = strSearchFields[1];

                                objEntityGuaranteType.Guar_Typ_Status = Convert.ToInt32(strddlStatus);
                                objEntityGuaranteType.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                            }
                            dtUser = objBusinessLayerGuarantee.ReadGuaranteTypeList(objEntityGuaranteType);

                            string strHtm = "";
                            if (objEntityGuaranteType.Cancel_Status == 0)
                            {
                                blShowCancel = false;
                            }
                            else
                            {
                                blShowCancel = true;

                            }

                            strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecallCancelled, intUserId, blShowCancel);

                            //Write to divReport
                            divReport.InnerHtml = strHtm;
                            hiddenCancelPrimaryId.Value = strId;
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "OpenCancelView("+strId+");", true);
                            //  ModalPopupExtenderCncl.Show();

                        }

                    }
                    else
                    {
                        objEntityGuaranteType.Cancel_reason = objCommon.CancelReason();
                        objBusinessLayerGuarantee.CancelGuaranteType(objEntityGuaranteType);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }



                }
                else
                {

                    if (hiddenSearchField.Value == "")
                    {
                        objEntityGuaranteType.Guar_Typ_Status = 1;
                        objEntityGuaranteType.Cancel_Status = 0;


                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityGuaranteType.Guar_Typ_Status = Convert.ToInt32(strddlStatus);
                        objEntityGuaranteType.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                    }

                    DataTable dtUser = new DataTable();
                    dtUser = objBusinessLayerGuarantee.ReadGuaranteTypeList(objEntityGuaranteType);

                    string strHtm = "";
                    if (objEntityGuaranteType.Cancel_Status == 0)
                    {
                        blShowCancel = false;
                    }
                    else
                    {
                        blShowCancel = true;

                    }

                    strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecallCancelled, intUserId, blShowCancel);

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
                    }
                }

            }
            else
            {

                divAdd.Visible = false;
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
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:56%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
               
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (blShowCancelled != true)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        if (blShowCancelled == false)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }
        if (blShowCancelled == true)
        {
            if (intEnableRecallCancelled == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
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


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:56%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                 strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";  
                    
                }
                

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            strStatusMode = dt.Rows[intRowBodyCount][3].ToString();


            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                    }
                }

            }
            else
            {
                if (strStatusMode == "ACTIVE")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                        "<img  style=\"\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Guarantee_Type_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                            " href=\"gen_Guarantee_Type_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
            }
            if (blShowCancelled == false)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    if (intCnclUsrId == 0)
                    {


                        if (intCancTransaction == 0)
                        {
                            if (hiddenSearchField.Value == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Guarantee_Type_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                    " href=\"gen_Guarantee_Type_Master_List.aspx?Id=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +
                                    "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }


                    }

                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }

                }
            }
            if (blShowCancelled == true)
            {
                if (intEnableRecallCancelled == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (hiddenSearchField.Value == "")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReCallAlert(this.href);' " +
                       " href=\"gen_Guarantee_Type_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReCallAlert(this.href);' " +
                       " href=\"gen_Guarantee_Type_Master_List.aspx?ReId=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                    }

                }
                else
                {

                    //  strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
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

        //Creating object for business layer
        classBusinessLayerGuaranteType objBusinessLayerGuarantee = new classBusinessLayerGuaranteType();
        classEntityLayerGuaranteType objEntityGuaranteType = new classEntityLayerGuaranteType();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityGuaranteType.GuaranteeTypeId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityGuaranteType.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityGuaranteType.D_Date = System.DateTime.Now;

            objEntityGuaranteType.Cancel_reason = txtCnclReason.Text.Trim();
            objBusinessLayerGuarantee.CancelGuaranteType(objEntityGuaranteType);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

            }

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {


        int intUserId = 0, intUsrRolMstrId, intUsrRolMstrIdRecallCancelled, intEnableModify = 0, intEnableCancel = 0, intEnableRecallCancelled = 0;
        bool blShowCancel = false;
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

        intUsrRolMstrIdRecallCancelled = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtChildRolRecallCancelled = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdRecallCancelled);
        if (dtChildRolRecallCancelled.Rows.Count > 0)
        {
            intEnableRecallCancelled = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Guarantee_Type_Master);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }



            classBusinessLayerGuaranteType objBusinessLayerGuarantee = new classBusinessLayerGuaranteType();
            classEntityLayerGuaranteType objEntityGuaranteType = new classEntityLayerGuaranteType();




            objEntityGuaranteType.Guar_Typ_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityGuaranteType.Cancel_Status = 1;
            }
            else
            {
                objEntityGuaranteType.Cancel_Status = 0;
            }


            if (Session["ORGID"] != null)
            {
                objEntityGuaranteType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityGuaranteType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            DataTable dtUser = new DataTable();
            dtUser = objBusinessLayerGuarantee.ReadGuaranteTypeList(objEntityGuaranteType);
            string strHtm = "";
            if (objEntityGuaranteType.Cancel_Status == 0)
            {
                blShowCancel = false;
            }
            else
            {
                blShowCancel = true;

            }
            strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecallCancelled, intUserId, blShowCancel);

            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }

    [WebMethod]
    public static string ChangeCategoryStatus(int strCatId, string strStatus)
    {

        classBusinessLayerGuaranteType objBusinessLayerGuarantee = new classBusinessLayerGuaranteType();
        classEntityLayerGuaranteType objEntityGuaranteType = new classEntityLayerGuaranteType();
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityGuaranteType.Guar_Typ_Status = 0;
        }
        else
        {
            objEntityGuaranteType.Guar_Typ_Status = 1;
        }
        objEntityGuaranteType.GuaranteeTypeId = strCatId;
        try
        {
            objBusinessLayerGuarantee.ChangeGuaranteStatus(objEntityGuaranteType);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
}

