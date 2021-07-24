using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;

public partial class GMS_GMS_Master_gen_Insurance_Type_Master_gen_Insurance_Type_Master_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlStatus.Focus();
        if (!IsPostBack)
        {
            cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Type_Master);
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
                clsBusinessLayerInsuranceTypMaster ObjBussinessInsrncTyp = new clsBusinessLayerInsuranceTypMaster();
                clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();

                if (Session["ORGID"] != null)
                {
                    objEntityInsrncTyp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityInsrncTyp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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

                if (Request.QueryString["Id"] != null)
                {//when Canceled
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    objEntityInsrncTyp.InsrTypId = Convert.ToInt32(strId);
                    objEntityInsrncTyp.User_Id = intUserId;
                    objEntityInsrncTyp.D_Date = System.DateTime.Now;
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
                            objEntityInsrncTyp.Cancel_reason = objCommon.CancelReason();
                            ObjBussinessInsrncTyp.CancelInsuranceTyp(objEntityInsrncTyp);
                            if (hiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);
                            }
                        }
                        else
                        {
                            DataTable dtUser = new DataTable();
                            if (hiddenSearchField.Value == "")
                            {
                                objEntityInsrncTyp.InsrTypStatus = 1;
                                objEntityInsrncTyp.Cancel_Status = 0;
                            }
                            else
                            {
                                string strHidden = hiddenSearchField.Value;

                                string[] strSearchFields = strHidden.Split('_');

                                string strddlStatus = strSearchFields[0];
                                string strCbxShowCancel = strSearchFields[1];

                                objEntityInsrncTyp.InsrTypStatus = Convert.ToInt32(strddlStatus);
                                objEntityInsrncTyp.Cancel_Status = Convert.ToInt32(strCbxShowCancel);
                            }
                            dtUser = ObjBussinessInsrncTyp.ReadInsuranceTypList(objEntityInsrncTyp);

                            string strHtm = "";
                            if (objEntityInsrncTyp.Cancel_Status == 0)
                            {
                                blShowCancel = false;
                            }
                            else
                            {
                                blShowCancel = true;
                            }

                            strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intUserId, blShowCancel);

                            //Write to divReport
                            divReport.InnerHtml = strHtm;
                            hiddenCancelPrimaryId.Value = strId;
                        }
                    }
                    else
                    {
                        objEntityInsrncTyp.Cancel_reason = objCommon.CancelReason();
                        ObjBussinessInsrncTyp.CancelInsuranceTyp(objEntityInsrncTyp);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);
                        }
                    }
                }
                else
                {
                    if (hiddenSearchField.Value == "")
                    {
                        objEntityInsrncTyp.InsrTypStatus = 1;
                        objEntityInsrncTyp.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityInsrncTyp.InsrTypStatus = Convert.ToInt32(strddlStatus);
                        objEntityInsrncTyp.Cancel_Status = Convert.ToInt32(strCbxShowCancel);
                    }

                    DataTable dtUser = new DataTable();
                    dtUser = ObjBussinessInsrncTyp.ReadInsuranceTypList(objEntityInsrncTyp);

                    string strHtm = "";
                    if (objEntityInsrncTyp.Cancel_Status == 0)
                    {
                        blShowCancel = false;
                    }
                    else
                    {
                        blShowCancel = true;
                    }

                    strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intUserId, blShowCancel);

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

    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intUserId, bool blShowCancelled)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:7%;text-align: center; word-wrap:break-word;\">Sl No</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
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

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
            int rowCount = intRowBodyCount + 1;

            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + rowCount + "</td>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:76%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE TYPE NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount]["STATUS"].ToString();

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                          " href=\"gen_Insurance_Type_Master.aspx?Id=" + Id + "\">" + "<img  title=\"Edit\" style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                            " href=\"gen_Insurance_Type_Master.aspx?ViewId=" + Id + "\">" + "<img title=\"View\" style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
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
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Insurance_Type_Master_List.aspx?Id=" + Id + "\">" + "<img title=\"Delete\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                    " href=\"gen_Insurance_Type_Master_List.aspx?Id=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img title=\"Delete\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +
                                    "<img  style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Created objects for business layer
        clsBusinessLayerInsuranceTypMaster ObjBussinessInsrncTyp = new clsBusinessLayerInsuranceTypMaster();
        clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityInsrncTyp.InsrTypId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityInsrncTyp.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityInsrncTyp.D_Date = System.DateTime.Now;

            objEntityInsrncTyp.Cancel_reason = txtCnclReason.Text.Trim();
            ObjBussinessInsrncTyp.CancelInsuranceTyp(objEntityInsrncTyp);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0, intEnableCancel = 0;
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

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Type_Master);
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



            clsBusinessLayerInsuranceTypMaster ObjBussinessInsrncTyp = new clsBusinessLayerInsuranceTypMaster();
            clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();




            objEntityInsrncTyp.InsrTypStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityInsrncTyp.Cancel_Status = 1;
            }
            else
            {
                objEntityInsrncTyp.Cancel_Status = 0;
            }


            if (Session["ORGID"] != null)
            {
                objEntityInsrncTyp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityInsrncTyp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtUser = new DataTable();
            dtUser = ObjBussinessInsrncTyp.ReadInsuranceTypList(objEntityInsrncTyp);
            string strHtm = "";
            if (objEntityInsrncTyp.Cancel_Status == 0)
            {
                blShowCancel = false;
            }
            else
            {
                blShowCancel = true;

            }
            strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intUserId, blShowCancel);

            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }
}