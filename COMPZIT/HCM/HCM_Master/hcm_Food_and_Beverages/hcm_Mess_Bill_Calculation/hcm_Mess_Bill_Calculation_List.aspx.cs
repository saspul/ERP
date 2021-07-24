using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// CREATED BY:EVM-0005
// CREATED DATE:22/08/2017
// REVIEWED BY:

public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Bill_Calculation_hcm_Mess_Bill_Calculation_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Accomodation_Load();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mess_Bill_Calculation);
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


                //Creating object for business layer and data table
                cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
                clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();



                if (Session["ORGID"] != null)
                {
                    objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                objEntityMessBill.AccomoDationId = 0;

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    hiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split('_');

                    string strddlAcco = strSearchFields[0];
                    string strCbxShowCancel = strSearchFields[1];

                    if (strddlAcco != null && strddlAcco != "")
                    {
                        if (ddlAccomo.Items.FindByValue(strddlAcco) != null)
                        {
                            ddlAccomo.Items.FindByValue(strddlAcco).Selected = true;
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



                else if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityMessBill.MessBillId = Convert.ToInt32(strId);
                    objEntityMessBill.User_Id = intUserId;

                    int intCorpId = 0;

                    intCorpId = objEntityMessBill.CorpOffice_Id;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityMessBill.cancelReason = objCommon.CancelReason();
                            objBusinessLayerMessBill.DeleteMessBill(objEntityMessBill);
                            if (hiddenSearchField.Value == "")
                            {
                                Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                            }

                        }
                        else
                        {

                            DataTable dtMessBill = new DataTable();
                            if (hiddenSearchField.Value == "")
                            {
                                objEntityMessBill.AccomoDationId = 0;
                                objEntityMessBill.CancelStatus = 0;

                            }
                            else
                            {
                                string strHidden = hiddenSearchField.Value;

                                string[] strSearchFields = strHidden.Split('_');

                                string strAccomo = strSearchFields[0];
                                string strCbxShowCancel = strSearchFields[1];

                                objEntityMessBill.AccomoDationId = Convert.ToInt32(strAccomo);
                                objEntityMessBill.CancelStatus = Convert.ToInt32(strCbxShowCancel);

                            }
                            dtMessBill = objBusinessLayerMessBill.ReadMessBill_List(objEntityMessBill);

                            string strHtm = "";
                            if (objEntityMessBill.CancelStatus == 0)
                            {
                                blShowCancel = false;
                            }
                            else
                            {
                                blShowCancel = true;

                            }

                            strHtm = ConvertDataTableToHTML(dtMessBill, intEnableModify, intEnableCancel, intUserId, blShowCancel);

                            //Write to divReport
                            divReport.InnerHtml = strHtm;
                            hiddenCancelPrimaryId.Value = strId;

                        }

                    }
                    else
                    {
                        objEntityMessBill.cancelReason = objCommon.CancelReason();
                        objBusinessLayerMessBill.DeleteMessBill(objEntityMessBill);
                        if (hiddenSearchField.Value == "")
                        {
                            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

                        }

                    }



                }
                else
                {

                    if (hiddenSearchField.Value == "")
                    {
                        objEntityMessBill.CancelStatus = 0;
                        objEntityMessBill.AccomoDationId = 0;

                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlAccomo = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityMessBill.AccomoDationId = Convert.ToInt32(strddlAccomo);
                        objEntityMessBill.CancelStatus = Convert.ToInt32(strCbxShowCancel);

                    }

                    DataTable dtMessBill = new DataTable();
                    dtMessBill = objBusinessLayerMessBill.ReadMessBill_List(objEntityMessBill);

                    string strHtm = "";
                    if (objEntityMessBill.CancelStatus == 0)
                    {
                        blShowCancel = false;
                    }
                    else
                    {
                        blShowCancel = true;

                    }

                    strHtm = ConvertDataTableToHTML(dtMessBill, intEnableModify, intEnableCancel, intUserId, blShowCancel);

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

                        else if (strInsUpd == "Conf")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MessConfirmation", "MessConfirmation();", true);
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
    //Method for assigning departments to the dropdown list
    public void Accomodation_Load()
    {
        ddlAccomo.Items.Clear();
        clsEntity_Mess_Bill ObjMessBill = new clsEntity_Mess_Bill();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        DataTable dtAccomo = objBusinessLayerMessBill.ReadAccomodation(ObjMessBill);

        ddlAccomo.DataSource = dtAccomo;

        ddlAccomo.DataTextField = "ACCMDTN_NAME";
        ddlAccomo.DataValueField = "ACCMDTN_ID";
        ddlAccomo.DataBind();
        SortDDL(ref this.ddlAccomo);
        ddlAccomo.Items.Insert(0, "--SELECT ACCOMODATION--");
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


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
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intUserId, bool blShowCancelled)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:50%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align:center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }


        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (blShowCancelled == false)
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
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
            }
        }



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intConfirmUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MESSBILL_CONF_USR_ID"].ToString());
            int intProcessedCount = Convert.ToInt32(dt.Rows[intRowBodyCount]["SALARY_STS_COUNT"].ToString());

            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    clsEntityCommon objEntityCommon = new clsEntityCommon();

                    string  strAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                    string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strAmount, objEntityCommon);

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString()  +"</td>";
                }
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0 && intProcessedCount == 0 && intConfirmUsrId==0)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"hcm_Mess_Bill_Calculation.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a title=\"View\"  onclick='return getdetails(this.href);' " +
                            " href=\"hcm_Mess_Bill_Calculation.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
            }
            if (blShowCancelled == false)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    if (intCnclUsrId == 0)
                    {
                        if ( intProcessedCount == 0)
                        {
                            if (hiddenSearchField.Value == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"hcm_Mess_Bill_Calculation_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a title=\"Delete\"  onclick='return CancelAlert(this.href);' " +
                                    " href=\"hcm_Mess_Bill_Calculation_List.aspx?Id=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Delete\" onclick='alert(\"Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!\"); return false;' " +
                               " href=\"#\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                     
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mess_Bill_Calculation);
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



            cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
            clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
            if (ddlAccomo.SelectedItem.Value.ToString() != "--SELECT ACCOMODATION--")
            {
                objEntityMessBill.AccomoDationId = Convert.ToInt32(ddlAccomo.SelectedItem.Value);
            }
            else
            {
                objEntityMessBill.AccomoDationId = 0;
            }


            if (cbxCnclStatus.Checked == true)
            {
                objEntityMessBill.CancelStatus = 1;
            }
            else
            {
                objEntityMessBill.CancelStatus = 0;
            }


            if (Session["ORGID"] != null)
            {
                objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            DataTable dtMessBill = new DataTable();
            dtMessBill = objBusinessLayerMessBill.ReadMessBill_List(objEntityMessBill);
            string strHtm = "";
            if (objEntityMessBill.CancelStatus == 0)
            {
                blShowCancel = false;
            }
            else
            {
                blShowCancel = true;

            }
            strHtm = ConvertDataTableToHTML(dtMessBill, intEnableModify, intEnableCancel, intUserId, blShowCancel);

            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityMessBill.MessBillId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityMessBill.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityMessBill.cancelReason = txtCnclReason.Text.Trim();
            objBusinessLayerMessBill.DeleteMessBill(objEntityMessBill);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

            }


        }
    }
}