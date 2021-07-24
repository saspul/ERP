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
// CREATED DATE:29/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Contract_Category_Master_gen_Contract_Category_Master_List : System.Web.UI.Page
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Category_Master);
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
                classBusinessLayerContractCategory objBusinessLayerCntrct = new classBusinessLayerContractCategory();
                classEntityLayerContractCategory objEntityCntrctCatgry = new classEntityLayerContractCategory();
                


                if (Session["ORGID"] != null)
                {
                    objEntityCntrctCatgry.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityCntrctCatgry.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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

                    objEntityCntrctCatgry.CntrctCatId = Convert.ToInt32(strId);
                    objEntityCntrctCatgry.User_Id = intUserId;

                    objEntityCntrctCatgry.D_Date = System.DateTime.Now;
                    DataTable dtJobDetail = new DataTable();
                    dtJobDetail = objBusinessLayerCntrct.ReadContractCategryById(objEntityCntrctCatgry);
                    string strName = "", strNameCount = "0";
                    if (dtJobDetail.Rows.Count > 0)
                    {

                        strName = dtJobDetail.Rows[0]["CNTRCTYPE_NAME"].ToString();
                    }

                    if (strName != "")
                    {
                        objEntityCntrctCatgry.CntrctCatname = strName;
                    }

                    strNameCount = objBusinessLayerCntrct.CheckContractCatName(objEntityCntrctCatgry);

                    if (strNameCount == "0")
                    {

                        objBusinessLayerCntrct.ReCallContractCategory(objEntityCntrctCatgry);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Recl");
                        }
                        else
                        {
                            Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Recl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }
                    else
                    {
                        DataTable dtUser = new DataTable();
                        if (hiddenSearchField.Value == "")
                        {
                            objEntityCntrctCatgry.JobCat_Status = 1;
                            objEntityCntrctCatgry.Cancel_Status = 0;


                        }
                        else
                        {
                            string strHidden = hiddenSearchField.Value;

                            string[] strSearchFields = strHidden.Split('_');

                            string strddlStatus = strSearchFields[0];
                            string strCbxShowCancel = strSearchFields[1];

                            objEntityCntrctCatgry.JobCat_Status = Convert.ToInt32(strddlStatus);
                            objEntityCntrctCatgry.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                        }
                        dtUser = objBusinessLayerCntrct.ReadContractCtgryList(objEntityCntrctCatgry);

                        string strHtm = "";
                        if (objEntityCntrctCatgry.Cancel_Status == 0)
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

                    objEntityCntrctCatgry.CntrctCatId = Convert.ToInt32(strId);
                    objEntityCntrctCatgry.User_Id = intUserId;

                    objEntityCntrctCatgry.D_Date = System.DateTime.Now;

                    int intCorpId = 0;

                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityCntrctCatgry.Cancel_reason = objCommon.CancelReason();
                            objBusinessLayerCntrct.CancelContractCategory(objEntityCntrctCatgry);
                            if (hiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                            }

                        }
                        else
                        {

                            DataTable dtUser = new DataTable();
                            if (hiddenSearchField.Value == "")
                            {
                                objEntityCntrctCatgry.JobCat_Status = 1;
                                objEntityCntrctCatgry.Cancel_Status = 0;


                            }
                            else
                            {
                                string strHidden = hiddenSearchField.Value;

                                string[] strSearchFields = strHidden.Split('_');

                                string strddlStatus = strSearchFields[0];
                                string strCbxShowCancel = strSearchFields[1];

                                objEntityCntrctCatgry.JobCat_Status = Convert.ToInt32(strddlStatus);
                                objEntityCntrctCatgry.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                            }
                            dtUser = objBusinessLayerCntrct.ReadContractCtgryList(objEntityCntrctCatgry);

                            string strHtm = "";
                            if (objEntityCntrctCatgry.Cancel_Status == 0)
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
                        objEntityCntrctCatgry.Cancel_reason = objCommon.CancelReason();
                        objBusinessLayerCntrct.CancelContractCategory(objEntityCntrctCatgry);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Job_Category_Master_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Job_Category_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }



                }
                else
                {

                    if (hiddenSearchField.Value == "")
                    {
                        objEntityCntrctCatgry.JobCat_Status = 1;
                        objEntityCntrctCatgry.Cancel_Status = 0;


                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityCntrctCatgry.JobCat_Status = Convert.ToInt32(strddlStatus);
                        objEntityCntrctCatgry.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

                    }

                    DataTable dtUser = new DataTable();
                    dtUser = objBusinessLayerCntrct.ReadContractCtgryList(objEntityCntrctCatgry);

                    string strHtm = "";
                    if (objEntityCntrctCatgry.Cancel_Status == 0)
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
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel,int intEnableRecallCancelled, int intUserId,bool blShowCancelled)
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
                strHtml += "<th class=\"thT\" style=\"width:76%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
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
                    strHtml += "<td class=\"tdT\" style=\" width:76%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
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
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                }
            }


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                   
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                          " href=\"gen_Contract_Category_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                            " href=\"gen_Contract_Category_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
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
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Contract_Category_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                    " href=\"gen_Contract_Category_Master_List.aspx?Id=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"ReCall\"  onclick='return ReCallAlert(this.href);' " +
                       " href=\"gen_Contract_Category_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                       " href=\"gen_Contract_Category_Master_List.aspx?ReId=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                     
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

        //Created objects for business layer
        classBusinessLayerContractCategory objBusinessLayerCntrct = new classBusinessLayerContractCategory();
        classEntityLayerContractCategory objEntityCntrctCatgry = new classEntityLayerContractCategory();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityCntrctCatgry.CntrctCatId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityCntrctCatgry.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityCntrctCatgry.D_Date = System.DateTime.Now;

            objEntityCntrctCatgry.Cancel_reason = txtCnclReason.Text.Trim();
            objBusinessLayerCntrct.CancelContractCategory(objEntityCntrctCatgry);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Contract_Category_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Category_Master);
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



        classBusinessLayerContractCategory objBusinessLayerCntrct = new classBusinessLayerContractCategory();
        classEntityLayerContractCategory objEntityCntrctCatgry = new classEntityLayerContractCategory();




            objEntityCntrctCatgry.JobCat_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityCntrctCatgry.Cancel_Status = 1;
            }
            else
            {
                objEntityCntrctCatgry.Cancel_Status = 0;
            }


            if (Session["ORGID"] != null)
            {
                objEntityCntrctCatgry.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityCntrctCatgry.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            DataTable dtUser = new DataTable();
            dtUser = objBusinessLayerCntrct.ReadContractCtgryList(objEntityCntrctCatgry);
            string strHtm = "";
            if (objEntityCntrctCatgry.Cancel_Status == 0)
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

        classBusinessLayerContractCategory objBusinessLayerCntrct = new classBusinessLayerContractCategory();
        classEntityLayerContractCategory objEntityCntrctCatgry = new classEntityLayerContractCategory();
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityCntrctCatgry.JobCat_Status = 0;
        }
        else
        {
            objEntityCntrctCatgry.JobCat_Status = 1;
        }
        objEntityCntrctCatgry.CntrctCatId = strCatId;
        try
        {
            objBusinessLayerCntrct.ChangeCategoryStatus(objEntityCntrctCatgry);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
}

