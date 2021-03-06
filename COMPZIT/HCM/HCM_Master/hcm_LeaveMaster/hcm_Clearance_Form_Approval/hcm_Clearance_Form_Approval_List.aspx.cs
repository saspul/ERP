using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Collections;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Worker_hcm_Clearance_Form_WorkerList : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlStatus.Focus();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Clearance_Form_Worker);
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

                hiddenEnableModify.Value = Convert.ToString(intEnableModify);
                hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);


                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');


                    string strPrdctName = strSearchFields[0];
                    string strddlStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];




                    if (strPrdctName != null && strPrdctName != "")
                    {
                        if (ddlEmployee.Items.FindByValue(strPrdctName) != null)
                        {
                            ddlEmployee.ClearSelection();
                            ddlEmployee.Items.FindByValue(strPrdctName).Selected = true;
                        }
                    }

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.ClearSelection();
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
                clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
                clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();


                //  objEntityClearanceFormWorker.ApprvStatus = 1;
                DataTable dtCorpDetail = new DataTable();
                int intCorpId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE 

                                                               };

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


                if (dtCorpDetail.Rows.Count > 0)
                {
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





                    if (Request.QueryString["Id"] != null)
                    {//when Canceled

                        string strRandomMixedId = Request.QueryString["Id"].ToString();
                        string strLenghtofId = strRandomMixedId.Substring(0, 2);
                        int intLenghtofId = Convert.ToInt16(strLenghtofId);
                        string strId = strRandomMixedId.Substring(2, intLenghtofId);

                        objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strId);
                        objEntityClearanceFormWorker.User_Id = intUserId;

                        objEntityClearanceFormWorker.Date = System.DateTime.Now;

                        if (CnclrsnMust == "0")
                        {
                            objEntityClearanceFormWorker.CancelReason = objCommon.CancelReason();

                            objBusinessClearanceFormWorker.CancelClearanceFormWorker(objEntityClearanceFormWorker);


                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            DataTable dtProductSrch = new DataTable();
                            if (HiddenSearchField.Value == "")
                            {
                                objEntityClearanceFormWorker.ApprvStatus = 1;
                            }

                            dtProductSrch = objBusinessClearanceFormWorker.ReadClearanceFormList(objEntityClearanceFormWorker);

                            string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;

                        }
                    }
                    else
                    {
                        if (HiddenSearchField.Value == "")
                        {
                            objEntityClearanceFormWorker.Empid = 0;
                            objEntityClearanceFormWorker.ApprvStatus = 0;
                            objEntityClearanceFormWorker.CancelStatus = 0;
                        }
                        else
                        {
                            string strHidden = "";
                            strHidden = HiddenSearchField.Value;

                            string[] strSearchFields = strHidden.Split(',');

                            string strEmployee = strSearchFields[0];
                            string strddlStatus = strSearchFields[1];
                            string strCbxStatus = strSearchFields[2];

                            if (strEmployee != null && strEmployee != "")
                            {
                                if (ddlEmployee.Items.FindByValue(strEmployee) != null)
                                {
                                    ddlEmployee.ClearSelection();
                                    ddlEmployee.Items.FindByValue(strEmployee).Selected = true;
                                    objEntityClearanceFormWorker.Empid = Convert.ToInt32(strEmployee);
                                }
                            }

                            if (strddlStatus != null && strddlStatus != "")
                            {
                                if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                                {
                                    ddlStatus.ClearSelection();
                                    ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                                    objEntityClearanceFormWorker.ApprvStatus = Convert.ToInt32(strddlStatus);
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

                            objEntityClearanceFormWorker.CancelStatus = Convert.ToInt32(strCbxStatus);
                        }
                        objEntityClearanceFormWorker.Empid = 2;

                        radioLeave.Checked = true;
                        //to view
                        DataTable dtProductSrch = new DataTable();

                        dtProductSrch = objBusinessClearanceFormWorker.ReadClearanceFormList(objEntityClearanceFormWorker);

                        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                        //Write to divReport
                        divReport.InnerHtml = strHtm;


                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd"].ToString();
                            if (strInsUpd == "Ins")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                            }
                            else if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                            }
                            else if (strInsUpd == "Cncl")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                            }
                            else if (strInsUpd == "Aprvd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
                            }
                            else if (strInsUpd == "Rejctd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);
                            }
                        }

                    }
                }
            }
        }
    }


    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
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
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE MODE</th>";
            }



        }
        strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"></th>";

        strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">DECISION </th>";



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int staffworker = 0;
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            string strDate = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString();
            if (strDate != "")
            {
                strDate = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString() + " " + dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString() + " " + dt.Rows[intRowBodyCount]["EMPERDTL_LNAME"].ToString();

            }
            else
            {
                strDate = dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString();
            }


            if (dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString() != "")
            {
                staffworker = Convert.ToInt32(dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString());
            }



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
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDate + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    if (staffworker == 0)
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">STAFF</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">WORKER</td>";

                }




            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (staffworker == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return WorkrId('" + Id + "');\" /></td>";
                if (ddlStatus.SelectedItem.Value == "0")
                {

                    strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                     " href=\"/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Worker/hcm_Clearance_Form_Worker.aspx?ViewId=" + Id + "&Page=Aprvl\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                    " href=\"/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Worker/hcm_Clearance_Form_Worker.aspx?ViewId=" + Id + "&Page=View\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }

            }

            else
            {
                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return StaffId('" + Id + "');\" /></td>";
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Staff/hcm_Clearance_Form_Staff.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
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
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();




        int intCorpId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedValue);
        objEntityClearanceFormWorker.ApprvStatus = Convert.ToInt32(ddlStatus.SelectedValue);


        if (radioLeave.Checked == true)
        {
           // objEntityClearanceFormWorker.Empid = 3;
            objEntityClearanceFormWorker.ClearanceStaffMode = 0;
        }
        else
        {
            objEntityClearanceFormWorker.ClearanceStaffMode = 1;
        }

        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessClearanceFormWorker.ReadClearanceFormList(objEntityClearanceFormWorker);

        int intEnableModify = 0, intEnableCancel = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);
        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    




        if (HiddenSearchField.Value == "")
        {

            objEntityClearanceFormWorker.Empid = 0;
            objEntityClearanceFormWorker.ApprvStatus = 0;
            objEntityClearanceFormWorker.CancelStatus = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');

            string strEmployee = strSearchFields[0];
            string strddlStatus = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];



            if (strEmployee != null && strEmployee != "")
            {
                if (ddlEmployee.Items.FindByValue(strEmployee) != null)
                {
                    ddlEmployee.ClearSelection();
                    ddlEmployee.Items.FindByValue(strEmployee).Selected = true;
                    objEntityClearanceFormWorker.Empid = Convert.ToInt32(strEmployee);
                }
            }

            if (strddlStatus != null && strddlStatus != "")
            {
                if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                {
                    ddlStatus.ClearSelection();
                    ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                    objEntityClearanceFormWorker.ApprvStatus = Convert.ToInt32(strddlStatus);
                }
            }
            //if (strCbxStatus == "1")
            //{
            //    cbxCnclStatus.Checked = true;
            //}
            //else
            //{
            //    cbxCnclStatus.Checked = false;
            //}

            //objEntityClearanceFormWorker.CancelStatus = Convert.ToInt32(strCbxStatus);
        }



        //DataTable dtProductSrch = new DataTable();
        //dtProductSrch = objBusinessClearanceFormWorker.ReadClearanceFormList(objEntityClearanceFormWorker);

        //int intEnableModify = 0, intEnableCancel = 0;

        //intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        //intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);
        //string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
        ////Write to divReport
        //divReport.InnerHtml = strHtm;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(hiddenRsnid.Value);

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityClearanceFormWorker.Date = System.DateTime.Now;

            objEntityClearanceFormWorker.CancelReason = txtCnclReason.Text.Trim();
            objBusinessClearanceFormWorker.CancelClearanceFormWorker(objEntityClearanceFormWorker);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }

}