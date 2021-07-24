using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;


public partial class Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List : System.Web.UI.Page
{
    public string strUsrId;
    public string strImageIconPath = "";
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3

    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //On not is post back

        if (!IsPostBack)
        {
            int intCorpId = 0, intOrgId = 0, intuserId = 0;
            
            cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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
            //string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOINING_FORM_BLANK);
            //divPrint.HRef = strImagePath;
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED), intUsrDsgnId = 0;

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            objEntityDsgnation.DesignationUserId = intUserId;
            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
                intUsrDsgnId = Convert.ToInt32(dtUserDetails.Rows[0]["DSGN_ID"].ToString());

            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
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

            }
                //Creating object for business layer and data table
                clsBusiness_Candidate_Login objBusinessLayerUsrReg = new clsBusiness_Candidate_Login();
                clsEntityCandidatelogin objEntityUserRegistration = new clsEntityCandidatelogin();

                hiddenDsgnTypId.Value = "0";
                hiddenDsgnControlId.Value = "C";
                if (Session["CORPOFFICEID"] != null)
                {
                  //  HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                  //  HiddenOrgId.Value = Session["ORGID"].ToString();

                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                   // HiddenEmpUserId.Value = Session["USERID"].ToString();
                    intUserId = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                //objEntityUserRegistration.LimitedUser = intUserLimited;
              //  objEntityUserRegistration.UserDsgnId = intUsrDsgnId;
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

                    objEntityUserRegistration.CandidateId = Convert.ToInt32(strId);
                    objEntityUserRegistration.User_Id = intUserId;

                    objEntityUserRegistration.CandidateDate = System.DateTime.Now;


                    DataTable dtUser = new DataTable();
                    if (hiddenSearchField.Value == "")
                    {
                        objEntityUserRegistration.UserStatus = 1;
                        objEntityUserRegistration.Cancelstatus = 0;


                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityUserRegistration.UserStatus = Convert.ToInt32(strddlStatus);
                        objEntityUserRegistration.Cancelstatus = Convert.ToInt32(strCbxShowCancel);

                    }
                    dtUser = objBusinessLayerUsrReg.ReadRegisteredCandidates(objEntityUserRegistration);

                    string strHtm = "";


                    strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intUserId);

                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                    hiddenCancelPrimaryId.Value = strId;
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "OpenCancelView("+strId+");", true);
                    //  ModalPopupExtenderCncl.Show();

                }


                else
                {
                    objEntityUserRegistration.CorpOffice_Id = intCorpId;
                    objEntityUserRegistration.Organisation_Id = intOrgId;

                    if (hiddenSearchField.Value == "")
                    {
                        objEntityUserRegistration.UserStatus = 1;
                        objEntityUserRegistration.Cancelstatus = 0;


                    }
                    else
                    {
                        string strHidden = hiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split('_');

                        string strddlStatus = strSearchFields[0];
                        string strCbxShowCancel = strSearchFields[1];

                        objEntityUserRegistration.UserStatus = Convert.ToInt32(strddlStatus);
                        objEntityUserRegistration.Cancelstatus = Convert.ToInt32(strCbxShowCancel);

                    }

                    DataTable dtUser1 = new DataTable();
                   

                    dtUser1 = objBusinessLayerUsrReg.ReadRegisteredCandidates(objEntityUserRegistration);

                    string strHtm1 = "";


                    strHtm1 = ConvertDataTableToHTML(dtUser1, intEnableModify, intEnableCancel, intUserId);

                    //Write to divReport
                    divReport.InnerHtml = strHtm1;
                }
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
                        //code 005 start
                        else if (strInsUpd == "Ipsd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFail", "MailsendFail();", true);
                        }
                        else if (strInsUpd == "IpRMSsd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFailReviewMailStng", "MailsendFailReviewMailStng();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }

                    }
                }

            }






    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intUserId)
    {



        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }



        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        }
        //EVM-0027

        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> PRINT</th>";


        //END


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            //FOR CANCELED COLUMN IDENTIFICATION ICON
            //if (intCnclUsrId == 0)
            //{
            //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
            //}
            //else
            //{
            //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
            //             "<img   src='/Images/Icons/cancel.png' /> " + " </td>";
            //}

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                          " href=\"gen_Candidate_Personal_Informn.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                            " href=\"gen_Candidate_Personal_Informn.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
            }
            strHtml += "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a  style=\"opacity: 1;\"  class=\"btn btn-xs btn-default\" title=\"Print\" href=\"javascript:;\" onclick=\"return PrintPdf('" + strId + "');\" ><i class=\"fa fa-print\"></i></a>";


            strHtml += "</tr>";

        }
        //if (dt.Rows.Count <= 0)
        //{
        //    strHtml += "<tr  ><td  class=\"tdT\" style=\"width:100%; word-wrap:break-word;text-align: center;\">No data available</td>";
        //    strHtml += "<td  class=\"tdT\" style=\"width:0%; word-wrap:break-word;text-align: center;\"></td>";
        //    strHtml += "<td  class=\"tdT\" style=\"width:0%; word-wrap:break-word;text-align: center;\"></td></tr>";
        //}

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
        clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();

        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
        {
            objEntityUserRegistration.UsrRegistrationId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


            if (Session["USERID"] != null)
            {
                objEntityUserRegistration.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityUserRegistration.UserDate = System.DateTime.Now;

            objEntityUserRegistration.UserCancelReason = txtCnclReason.Text.Trim();
            objBusinessLayerUsrReg.UpdateUsrCancel(objEntityUserRegistration);


            if (hiddenSearchField.Value == "")
            {
                Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_UserRegistrationList.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

            }


        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {


        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0, intEnableCancel = 0;
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.User_Registration);
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



            clsBusiness_Candidate_Login objBusinessLayerUsrReg = new clsBusiness_Candidate_Login();
            clsEntityCandidatelogin objEntityUserRegistration = new clsEntityCandidatelogin();

            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED), intUsrDsgnId = 0;

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            objEntityDsgnation.DesignationUserId = intUserId;
            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
                intUsrDsgnId = Convert.ToInt32(dtUserDetails.Rows[0]["DSGN_ID"].ToString());

            }
            
            objEntityUserRegistration.UserStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityUserRegistration.Cancelstatus = 1;
            }
            else
            {
                objEntityUserRegistration.Cancelstatus = 0;
            }

            hiddenDsgnTypId.Value = "0";
            hiddenDsgnControlId.Value = "C";
            if (Session["DSGN_TYPID"] != null)
            {
                hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityUserRegistration.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
            {

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityUserRegistration.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }


            DataTable dtUser = new DataTable();
            dtUser = objBusinessLayerUsrReg.ReadRegisteredCandidates(objEntityUserRegistration);


            string strHtm = "";

            strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intUserId);

            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }

    //evm-0027
    [System.Web.Services.WebMethod]
    public static string PrintJoinigForm(string strId, string UsrName, string strOrgIdID, string strCorpID)
    {
        clsBusiness_Candidate_Login objBusinessLayerUsrReg = new clsBusiness_Candidate_Login();
        clsEntityCandidatelogin objEntityUserRegistration = new clsEntityCandidatelogin();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityUserRegistration.Organisation_Id = Convert.ToInt32(strOrgIdID);
        objEntityUserRegistration.CorpOffice_Id = Convert.ToInt32(strCorpID);
               
       DataTable dtCorp = objBusinessLayerUsrReg.ReadCorpDtls(objEntityUserRegistration);


       DataTable dtCandidate = new DataTable();
       DataTable dtDepentant = new DataTable();
       DataTable dtLanguage = new DataTable();
       DataTable dtExperience = new DataTable();
       DataTable dtQualification = new DataTable();
        

        if(strId != "BlankMode")
        {
            objEntityUserRegistration.CandidateId = Convert.ToInt32(strId);

            dtCandidate = objBusinessLayerUsrReg.ReadStaffDetails(objEntityUserRegistration);
            dtLanguage = objBusinessLayerUsrReg.ReadLanguageDetails(objEntityUserRegistration);
            dtExperience = objBusinessLayerUsrReg.ReadExperienceDetails(objEntityUserRegistration);
            dtQualification = objBusinessLayerUsrReg.ReadQualification(objEntityUserRegistration);
            dtDepentant = objBusinessLayerUsrReg.ReadDepentantDetails(objEntityUserRegistration);
           
            //   string strDepnt = "";
            //   if (dtCandidate.Rows.Count == 0)
            //{
            //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtCandidate.Columns.Count; intColumnHeaderCount++)
            //    {
            //        strDepnt += " dtCandidate.Columns.Add(\"" + dtCandidate.Columns[intColumnHeaderCount].ColumnName + "\", typeof(int));";
            //    }
            //}
        }
        else
        {
            //1. Columns DataTable dtCandidate
            dtCandidate.Columns.Add("STAFF_PR_NAME", typeof(string)); dtCandidate.Columns.Add("CAND_ID", typeof(string)); dtCandidate.Columns.Add("STAFF_PR_LCL_CNT_NUM", typeof(string)); 
            dtCandidate.Columns.Add("STAFF_PR_EMAIL", typeof(string)); dtCandidate.Columns.Add("DSGN_NAME", typeof(string)); dtCandidate.Columns.Add("CPRDIV_NAME", typeof(string)); 
            dtCandidate.Columns.Add("STAFF_PR_FNAME", typeof(string)); dtCandidate.Columns.Add("STAFF_PR_MNAME", typeof(string)); dtCandidate.Columns.Add("STAFF_PR_LNAME", typeof(string)); 
            dtCandidate.Columns.Add("STAFF_CNT_PR_ADDR", typeof(string)); dtCandidate.Columns.Add("STAFF_CNT_EMR_CNT", typeof(string)); dtCandidate.Columns.Add("ACCMDTN_ID", typeof(string));
            dtCandidate.Columns.Add("STAFF_CNT_REFF", typeof(string)); dtCandidate.Columns.Add("SPSNSR_ID", typeof(string)); dtCandidate.Columns.Add("STAFF_FMLY_MRG_STS", typeof(string));
            dtCandidate.Columns.Add("STAFF_FMLY_SPOUSE_NAME", typeof(string)); dtCandidate.Columns.Add("STAFF_OTHRDTLS_DOB", typeof(string)); dtCandidate.Columns.Add("BLOODGRP_ID", typeof(string));
            dtCandidate.Columns.Add("STAFF_OTHRDTLS_ILLNES_STS", typeof(string)); dtCandidate.Columns.Add("STAFF_OTHRDTLS_RELATIVE_STS", typeof(string)); dtCandidate.Columns.Add("STAFF_OTHRDTLS_APLIEDBFR_STS", typeof(string));
            dtCandidate.Columns.Add("STAFF_OTHRDTLS_ILLNES_YES", typeof(string)); dtCandidate.Columns.Add("STAFF_OTHRDTLS_SPOCU", typeof(string)); dtCandidate.Columns.Add("STAFF_OTHRDTLS_APLIEDBFR_STS1", typeof(string));
            dtCandidate.Columns.Add("STAFF_OTHRDTLS_APLIEDBFR_YES", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_A_NAME", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_A_ADDR", typeof(string));
            dtCandidate.Columns.Add("STAFF_REFF_A_OCCUPATION", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_A_PHN", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_B_NAME", typeof(string));
            dtCandidate.Columns.Add("STAFF_REFF_B_ADDR", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_B_OCCUPATION", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_B_PHN", typeof(string));            
            dtCandidate.Columns.Add("STAFF_JOINING_DATE", typeof(string)); dtCandidate.Columns.Add("STAFF_VISA_NUM", typeof(string));dtCandidate.Columns.Add("STAFF_VISA_VALIDITY", typeof(string)); 
            dtCandidate.Columns.Add("STAFF_PASSPORT_NUM", typeof(string)); dtCandidate.Columns.Add("STAFF_PASSPORT_VALIDITY", typeof(string)); dtCandidate.Columns.Add("VISA_NAME", typeof(string)); 
            dtCandidate.Columns.Add("SPNSR_NAME", typeof(string)); dtCandidate.Columns.Add("ACCMDTN_NAME", typeof(string)); dtCandidate.Columns.Add("BLOODGRP_NAME", typeof(string)); 
            dtCandidate.Columns.Add("CNTRY_NAME", typeof(string));   dtCandidate.Columns.Add("STAFF_PR_TELE", typeof(string)); dtCandidate.Columns.Add("STAFF_REFF_SECUR_STS", typeof(string)); 
            dtCandidate.Columns.Add("IMAGE_FILENAME", typeof(string)); dtCandidate.Columns.Add("IMAGE_FLNM_ACT", typeof(string));

           // rows
            dtCandidate.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");


            //2. Columns DataTable dtDepentant
            dtDepentant.Columns.Add("RELATE_ID", typeof(string)); 
            dtDepentant.Columns.Add("STAFF_DPNT_NAME", typeof(string));
            dtDepentant.Columns.Add("STAFF_DPNT_DT_BIRTH", typeof(string));
            dtDepentant.Columns.Add("STAFF_DPNT_OCCUPATION", typeof(string)); 
            dtDepentant.Columns.Add("RELATE_ID1", typeof(string));
            dtDepentant.Columns.Add("RELATE_NAME", typeof(string));
            dtDepentant.Columns.Add("AGE", typeof(string));

            //Rows
            dtDepentant.Rows.Add("", "", "", "", "", "", "");
            dtDepentant.Rows.Add("", "", "", "", "", "", "");
            dtDepentant.Rows.Add("", "", "", "", "", "", "");
            dtDepentant.Rows.Add("", "", "", "", "", "", "");



            //3. Columns DataTable dtLanguage
            dtLanguage.Columns.Add("STAFF_LANG_ID", typeof(string)); 
            dtLanguage.Columns.Add("STAFF_LANG_KNOWN", typeof(string));
            dtLanguage.Columns.Add("STAFF_LANG_READ", typeof(string)); 
            dtLanguage.Columns.Add("STAFF_LANG_WRITE", typeof(string)); 
            dtLanguage.Columns.Add("STAFF_LANG_SPEAK", typeof(string));
            dtLanguage.Columns.Add("STAFF_LANGMOTHER_TONGUE", typeof(string)); 
            dtLanguage.Columns.Add("LANGMSTR_NAME", typeof(string));

            //Rows
            dtLanguage.Rows.Add("", "", "", "", "", "", "");
            dtLanguage.Rows.Add("", "", "", "", "", "", "");
            dtLanguage.Rows.Add("", "", "", "", "", "", "");
            dtLanguage.Rows.Add("", "", "", "", "", "", "");



            //4. Columns  DataTable dtExperience 
           dtExperience.Columns.Add("STAFF_WRK_EXP_ID", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_EXP_YR", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_GCC_EXP", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_NAME_LST_EMP", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_ADDR_LST_EMP", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_DT_JOINING", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_DT_LEAVING", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_DSGN", typeof(string)); 
            dtExperience.Columns.Add("STAFF_WRK_SALARY", typeof(string));

            //Rows
            dtExperience.Rows.Add("", "", "", "", "", "", "", "", "");
            dtExperience.Rows.Add("", "", "", "", "", "", "", "", "");
            dtExperience.Rows.Add("", "", "", "", "", "", "", "", "");
            dtExperience.Rows.Add("", "", "", "", "", "", "", "", "");



            //5. Columns DataTable dtQualification
            dtQualification.Columns.Add("QUAL_COURSE_ID", typeof(string)); 
            dtQualification.Columns.Add("STAFF_QUAL_INST", typeof(string)); 
            dtQualification.Columns.Add("STAFF_QUAL_PASSING_YR", typeof(string)); 
            dtQualification.Columns.Add("STAFF_QUAL_DEGREE", typeof(string)); 
            dtQualification.Columns.Add("STAFF_QUAL_SPEC", typeof(string)); 
            dtQualification.Columns.Add("STAFF_QUAL_PRCTG", typeof(string)); 
            dtQualification.Columns.Add("QUAL_COURSE_NAME", typeof(string));

            //Rows
            dtQualification.Rows.Add("", "", "", "", "", "", "");
            dtQualification.Rows.Add("", "", "", "", "", "", "");
            dtQualification.Rows.Add("", "", "", "", "", "", "");
            dtQualification.Rows.Add("", "", "", "", "", "", "");
        }


        Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List objPage = new Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List();

        //  return objPage.PdfPrint(strId, dt, dtProduct, dtCorp, ObjEntityRequest, PreparedBy, CheckedBy, crncyAbrvt, crncyId);
       

       return objPage.PdfPrint(dtCandidate, strId, dtCorp, dtLanguage, dtExperience, dtQualification, dtDepentant);
       // return "";
    }
    public string PdfPrint(DataTable dtCandidate, string strId, DataTable dtCorp, DataTable dtLanguage, DataTable dtExperience, DataTable dtQualification, DataTable dtDepentant)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOINING_FORM);
        string strImageName = "Joining_Form" + strId + ".pdf";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOINING_FORM);

        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 85f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        string strRet = "";
        try
        {

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                float s = writer.GetVerticalPosition(false);
                document.Open();
                PdfPTable headImg = new PdfPTable(2);


                if (dtCandidate.Rows.Count > 0)
                {

                    string strImagePathProfilePic = "";
                    if (dtCandidate.Rows[0]["IMAGE_FILENAME"].ToString() != "")
                    {
                        strImagePathProfilePic = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_PROFILEPIC) + dtCandidate.Rows[0]["IMAGE_FILENAME"].ToString();
                        string strFileExt = strImagePathProfilePic.Substring(strImagePathProfilePic.LastIndexOf('.') + 1).ToLower();
                        if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                        {                           
                        }
                        else
                        {
                            strImagePathProfilePic = "";
                        }
                    }
                    else
                    {
                        strImagePathProfilePic = "";
                    }


                    PdfPTable tableBody = new PdfPTable(5);
                    float[] tableBody2 = { 15,25, 20, 20, 20 };
                    tableBody.SetWidths(tableBody2);
                    tableBody.WidthPercentage = 100;
                    tableBody.SpacingAfter = 0;
                    tableBody.AddCell(new PdfPCell(new Phrase("Employee Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_PR_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Employee Number", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                   // tableBody.AddCell(new PdfPCell(new Phrase("Please attach your recent photograph here", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { BorderWidthBottom = 0, Rowspan = 5, PaddingTop = 20,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE });


                    if (strImagePathProfilePic != "")
                    {
                        iTextSharp.text.Image CandidateProfileImg = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImagePathProfilePic));
                        CandidateProfileImg.ScalePercent(PdfPCell.ALIGN_CENTER);
                        CandidateProfileImg.ScaleToFit(101f, 650f);
                        tableBody.AddCell(new PdfPCell(CandidateProfileImg) { BorderWidthBottom = 0, Rowspan = 5, PaddingTop = 0, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

                       // tableBody.AddCell(new PdfPCell(new Phrase("Un comment Please attach your recent photograph here", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { BorderWidthBottom = 0, Rowspan = 5, PaddingTop = 20, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

                    }
                    else
                    {
                         tableBody.AddCell(new PdfPCell(new Phrase("Please attach your recent photograph here", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { BorderWidthBottom = 0, Rowspan = 5, PaddingTop = 20,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    }





                    tableBody.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["DSGN_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Division", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["CPRDIV_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Local Contact No", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_PR_LCL_CNT_NUM"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    //This field stores the  reference type consultancy-1, division-2, department-3, employee-4
                    string strRecrutdTH = "";
                    if (dtCandidate.Rows[0]["STAFF_CNT_REFF"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_CNT_REFF"]) == 1)
                        {
                            strRecrutdTH = "Consultancy";
                        }
                        else if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_CNT_REFF"]) == 2)
                        {
                            strRecrutdTH = "Division";
                        }
                        else if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_CNT_REFF"]) == 3)
                        {
                            strRecrutdTH = "Department";
                        }
                        else if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_CNT_REFF"]) == 4)
                        {
                            strRecrutdTH = "Employee";
                        }
                    }

                    string strDateOfJoinigStaff= "";
                    if (dtCandidate.Rows[0]["STAFF_JOINING_DATE"].ToString() != "")
                    {
                        strDateOfJoinigStaff = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtCandidate.Rows[0]["STAFF_JOINING_DATE"]));
                    }


                    tableBody.AddCell(new PdfPCell(new Phrase("Recruited Through", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strRecrutdTH, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    string strDOB = "";
                    if (dtCandidate.Rows[0]["STAFF_OTHRDTLS_DOB"].ToString() != "")
                    {
                        strDOB = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtCandidate.Rows[0]["STAFF_OTHRDTLS_DOB"]));
                    }

                    tableBody.AddCell(new PdfPCell(new Phrase("Date Of Birth", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strDOB, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Date Of Landing (Sponsored Staff)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //  Date Of Landing Not Mentioned
                    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("Date Of Joining", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strDateOfJoinigStaff, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });


                    tableBody.AddCell(new PdfPCell(new Phrase("Passport Number", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_PASSPORT_NUM"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    string strPassporValidity = "";
                    if (dtCandidate.Rows[0]["STAFF_PASSPORT_VALIDITY"].ToString() != "")
                    {
                        strPassporValidity = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtCandidate.Rows[0]["STAFF_PASSPORT_VALIDITY"]));
                    }

                    tableBody.AddCell(new PdfPCell(new Phrase("Passport Validity", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strPassporValidity, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });




                    tableBody.AddCell(new PdfPCell(new Phrase("Sponsored / Local Staff", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    if (dtCandidate.Rows[0]["SPNSR_NAME"] != "")
                    {
                        tableBody.AddCell(new PdfPCell(new Phrase("Sponsored " + dtCandidate.Rows[0]["SPNSR_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    }
                    else
                    {
                        tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["SPNSR_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    }

                    tableBody.AddCell(new PdfPCell(new Phrase("Resident Permit Number (Local Staff Only)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableBody.AddCell(new PdfPCell(new Phrase("Validity", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });

                    tableBody.AddCell(new PdfPCell(new Phrase("Present Sponsor (Local Staff Only)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["SPNSR_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("Location Of Stay", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["ACCMDTN_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    //Telephone Country Of origin-NM
                    tableBody.AddCell(new PdfPCell(new Phrase("Telephone ( Country Of origin)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_PR_TELE"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("Email ID", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_PR_EMAIL"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
                    //   Father's  Name NM

                    string strFathersName = "", strOccupation = "";




                    if (dtDepentant.Rows.Count > 0 && strId != "BlankMode")
                    {
                        DataRow[] tempDataRowsDepentant = dtDepentant.Select("RELATE_ID = 2");

                        if (tempDataRowsDepentant.Length > 0)
                        {
                            for (int i = 0; i < dtDepentant.Rows.Count; i++)
                            {
                                if (dtDepentant.Rows[i]["RELATE_ID"].ToString() == "2")
                                {
                                    strFathersName = dtDepentant.Rows[i]["STAFF_DPNT_NAME"].ToString();
                                    strOccupation = dtDepentant.Rows[i]["STAFF_DPNT_OCCUPATION"].ToString();
                                }
                            }

                        }


                    }

                    tableBody.AddCell(new PdfPCell(new Phrase("Father's Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strFathersName, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("Father's Occupation", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strOccupation, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("Permanent Residential Address", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_CNT_PR_ADDR"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                    tableBody.AddCell(new PdfPCell(new Phrase("In case of Emergency, Contact", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["STAFF_CNT_EMR_CNT"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });




                    tableBody.AddCell(new PdfPCell(new Phrase("Nationality", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtCandidate.Rows[0]["CNTRY_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });






                    //tableBody.AddCell(new PdfPCell(new Phrase("Blood Group  :  " + dtCandidate.Rows[0]["BLOODGRP_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //tableBody.AddCell(new PdfPCell(new Phrase("Nationality  :  " + dtCandidate.Rows[0]["CNTRY_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    // "Possible values are
                    //1-Married
                    //0-Unmarried"
                    string strMartialStatus = "";
                    if (dtCandidate.Rows[0]["STAFF_FMLY_MRG_STS"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_FMLY_MRG_STS"]) == 0)
                        {
                            strMartialStatus = "Single";
                        }
                        else
                        {
                            strMartialStatus = "Married";
                        }
                    }
                    int childCount = 0;
                    string strSpouseName = "";
                    string strSpouseOcptn = "";
                    if (dtDepentant.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDepentant.Rows.Count; i++)
                        {
                            if (dtDepentant.Rows[i]["RELATE_ID"].ToString() != "")
                            {
                                if (Convert.ToInt32(dtDepentant.Rows[i]["RELATE_ID"]) == 9 || (Convert.ToInt32(dtDepentant.Rows[i]["RELATE_ID"]) == 10))
                                {

                                    childCount++;
                                }
                                else if (Convert.ToInt32(dtDepentant.Rows[i]["RELATE_ID"]) == 7)
                                {
                                    strSpouseName = dtDepentant.Rows[i]["STAFF_DPNT_NAME"].ToString();
                                    strSpouseOcptn = dtDepentant.Rows[i]["STAFF_DPNT_OCCUPATION"].ToString();
                                }
                            }
                        }
                    }


                    tableBody.AddCell(new PdfPCell(new Phrase("Blood Group  :  " + dtCandidate.Rows[0]["BLOODGRP_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Marital Status :  " + strMartialStatus, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });



                    tableBody.AddCell(new PdfPCell(new Phrase("Spouse Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE,  });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strSpouseName, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Occupation", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableBody.AddCell(new PdfPCell(new Phrase("" + strSpouseOcptn, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });

                    if (strId != "BlankMode")
                    {
                        tableBody.AddCell(new PdfPCell(new Phrase("No of Children       :    " + childCount, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                    }
                    else
                    {
                        tableBody.AddCell(new PdfPCell(new Phrase("No of Children       :    " , FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                    }

                    if (dtDepentant.Rows.Count > 0)
                    {

                        DataRow[] tempDataRows = dtDepentant.Select("false");
                        if (strId != "BlankMode")
                        {
                            tempDataRows = dtDepentant.Select("RELATE_ID =9 OR RELATE_ID =10");
                        }

                        if (tempDataRows.Length > 0 || strId == "BlankMode")
                        {
                            tableBody.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                            tableBody.AddCell(new PdfPCell(new Phrase("Age", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableBody.AddCell(new PdfPCell(new Phrase("Occupation", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                        }

                        for (int i = 0; i < dtDepentant.Rows.Count; i++)
                        {
                            if (dtDepentant.Rows[i]["RELATE_ID"].ToString() != "")
                            {
                                if (Convert.ToInt32(dtDepentant.Rows[i]["RELATE_ID"]) == 9 || (Convert.ToInt32(dtDepentant.Rows[i]["RELATE_ID"]) == 10))
                                {
                                    // childCount++;
                                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtDepentant.Rows[i]["STAFF_DPNT_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtDepentant.Rows[i]["AGE"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtDepentant.Rows[i]["STAFF_DPNT_OCCUPATION"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                                }
                            }
                            else
                            {
                              tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                              tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                              tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                            }
                        }
                    }
                    //else
                    //{
                    //    tableBody.AddCell(new PdfPCell(new Phrase("1", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    //    tableBody.AddCell(new PdfPCell(new Phrase("2", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    //}
                    // Possible values are
                    //1-YES
                    //0-NO                 
                    string strIllStatus = "";
                    if (dtCandidate.Rows[0]["STAFF_OTHRDTLS_ILLNES_STS"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_OTHRDTLS_ILLNES_STS"]) == 0)
                        {
                            strIllStatus = "NO";
                        }
                        else
                        {
                            strIllStatus = "YES";
                        }
                    }


                    tableBody.AddCell(new PdfPCell(new Phrase("Have you suffered from any major illness? YES / NO If Yes, please give details : " + strIllStatus, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                    string strAppliedStatus = "";
                    if (dtCandidate.Rows[0]["STAFF_OTHRDTLS_APLIEDBFR_STS"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_OTHRDTLS_APLIEDBFR_STS"]) == 0)
                        {
                            strAppliedStatus = "NO";
                        }
                        else
                        {
                            strAppliedStatus = "YES";
                        }
                    }

                    string strRelativeStatus = "";
                    if (dtCandidate.Rows[0]["STAFF_OTHRDTLS_RELATIVE_STS"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtCandidate.Rows[0]["STAFF_OTHRDTLS_RELATIVE_STS"]) == 0)
                        {
                            strRelativeStatus = "NO";
                        }
                        else
                        {
                            strRelativeStatus = "YES";
                        }
                    }

                    tableBody.AddCell(new PdfPCell(new Phrase("Have you applied for an employment with " + dtCorp.Rows[0]["CORPRT_NAME"].ToString() + " earlier? YES/NO if yes, please give details :" + strAppliedStatus, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                    tableBody.AddCell(new PdfPCell(new Phrase("Are you related to any past / present employee / director of this Company?  YES / NO : " + strRelativeStatus, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                   

                    if (dtLanguage.Rows.Count > 0)
                    {
                    tableBody.AddCell(new PdfPCell(new Phrase("Languages Known (underline Mother Tongue)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableBody.AddCell(new PdfPCell(new Phrase("READ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableBody.AddCell(new PdfPCell(new Phrase("WRITE", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableBody.AddCell(new PdfPCell(new Phrase("SPEAK", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });

                    if (strId != "BlankMode")
                    {
                        for (int i = 0; i < dtLanguage.Rows.Count; i++)
                        {

                            string strRead = "";
                            string strWrite = "";
                            string strSpeak = "";
                            if (dtLanguage.Rows[i]["STAFF_LANG_READ"].ToString() != "")
                            {
                                if (Convert.ToInt32(dtLanguage.Rows[i]["STAFF_LANG_READ"]) == 0)
                                {
                                    strRead = "NO";
                                }
                                else
                                {
                                    strRead = "YES";
                                }
                            }
                            if (dtLanguage.Rows[i]["STAFF_LANG_WRITE"].ToString() != "")
                            {
                                if (Convert.ToInt32(dtLanguage.Rows[i]["STAFF_LANG_WRITE"]) == 0)
                                {
                                    strWrite = "NO";
                                }
                                else
                                {
                                    strWrite = "YES";
                                }
                            }
                            if (dtLanguage.Rows[i]["STAFF_LANG_SPEAK"].ToString() != "")
                            {

                                if (Convert.ToInt32(dtLanguage.Rows[i]["STAFF_LANG_SPEAK"]) == 0)
                                {
                                    strSpeak = "NO";
                                }
                                else
                                {
                                    strSpeak = "YES";
                                }
                            }
                            if (dtLanguage.Rows[i]["STAFF_LANGMOTHER_TONGUE"].ToString() != "")
                            {
                                if (Convert.ToInt32(dtLanguage.Rows[i]["STAFF_LANGMOTHER_TONGUE"]) == 1)
                                {
                                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtLanguage.Rows[i]["LANGMSTR_NAME"], FontFactory.GetFont("Arial", 9, Font.UNDERLINE, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                                }
                                else
                                {
                                    tableBody.AddCell(new PdfPCell(new Phrase("" + dtLanguage.Rows[i]["LANGMSTR_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                                }

                            }

                            tableBody.AddCell(new PdfPCell(new Phrase("" + strRead, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableBody.AddCell(new PdfPCell(new Phrase("" + strWrite, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableBody.AddCell(new PdfPCell(new Phrase("" + strSpeak, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                        }
                    }

                    else
                    {
                        for (int i = 0; i < dtLanguage.Rows.Count; i++)
                        {
                            tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                            tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableBody.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });                              
                        }

                    }
                        
                    }
                    //else
                    //{

                    //    tableBody.AddCell(new PdfPCell(new Phrase("1", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("2", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("3", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("4", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    //    tableBody.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });

                    //}
                    document.Add(tableBody);

               
                    PdfPTable tableQualification = new PdfPTable(6);
                    float[] tableQualificationBody = { 30, 20, 10, 10, 20, 10 };
                    tableQualification.SetWidths(tableQualificationBody);
                    tableQualification.WidthPercentage = 100;
                    tableQualification.SpacingBefore = 0;

                    if (dtQualification.Rows.Count > 0)
                    {  
                 
                    tableQualification.AddCell(new PdfPCell(new Phrase("EDUCATIONAL  QUALIFICATION", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Qualification", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Institution Name & Place", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Year & Month of passing", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Degree /Diploma Received", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Specialization", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Percentage", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });

                    if (strId != "BlankMode")
                    {
                        for (int i = 0; i < dtQualification.Rows.Count; i++)
                        {
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtQualification.Rows[i]["QUAL_COURSE_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtQualification.Rows[i]["STAFF_QUAL_INST"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            string strYearOfPassing = "";
                            if (dtQualification.Rows[0]["STAFF_QUAL_PASSING_YR"].ToString() != "")
                            {
                                strYearOfPassing = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtQualification.Rows[i]["STAFF_QUAL_PASSING_YR"]));
                            }
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + strYearOfPassing, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtQualification.Rows[i]["STAFF_QUAL_DEGREE"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtQualification.Rows[i]["STAFF_QUAL_SPEC"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtQualification.Rows[i]["STAFF_QUAL_PRCTG"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtQualification.Rows.Count; i++)
                        {
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                        }
                      
                    }
                    }

                    if (dtExperience.Rows.Count > 0)
                    {
                        tableQualification.AddCell(new PdfPCell(new Phrase("WORK EXPERIENCE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                        tableQualification.AddCell(new PdfPCell(new Phrase("Total  Work Experience in Years:", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                        tableQualification.AddCell(new PdfPCell(new Phrase("" + dtExperience.Rows[0]["STAFF_WRK_EXP_YR"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                        tableQualification.AddCell(new PdfPCell(new Phrase("GCC Experience:  " + dtExperience.Rows[0]["STAFF_WRK_GCC_EXP"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

                 
                        for (int i = 0; i < dtExperience.Rows.Count; i++)
                        {
                            int ExpCount = i+1;

                            tableQualification.AddCell(new PdfPCell(new Phrase(ExpCount + ". Name & Address of Last Employer", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            string strComma = "";
                            if (dtExperience.Rows[i]["STAFF_WRK_NAME_LST_EMP"] != "")
                            {
                                strComma = ", ";
                            }

                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtExperience.Rows[i]["STAFF_WRK_NAME_LST_EMP"] + strComma + dtExperience.Rows[i]["STAFF_WRK_ADDR_LST_EMP"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            string strDateOfJoinig = "";
                            if (dtExperience.Rows[i]["STAFF_WRK_DT_JOINING"].ToString() != "")
                            {
                                strDateOfJoinig = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtExperience.Rows[i]["STAFF_WRK_DT_JOINING"]));
                            }
                            string strDateOfLeaving = "";
                            if (dtExperience.Rows[i]["STAFF_WRK_DT_LEAVING"].ToString() != "")
                            {
                                strDateOfLeaving = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtExperience.Rows[i]["STAFF_WRK_DT_LEAVING"]));
                            }

                            tableQualification.AddCell(new PdfPCell(new Phrase("Date of Joining", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + strDateOfJoinig, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("Date Of Leaving", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + strDateOfLeaving, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            tableQualification.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtExperience.Rows[i]["STAFF_WRK_DSGN"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("Take Home Salary", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                            tableQualification.AddCell(new PdfPCell(new Phrase("" + dtExperience.Rows[i]["STAFF_WRK_SALARY"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                        }
                    }
                  //}////
                  
               
                    tableQualification.AddCell(new PdfPCell(new Phrase("VISA", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Visa Type", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Visa No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("Valid Up to ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase(" " + dtCandidate.Rows[0]["VISA_NAME"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase(" " + dtCandidate.Rows[0]["STAFF_VISA_NUM"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    string strVisaValidity = "";
                    if (dtCandidate.Rows[0]["STAFF_VISA_VALIDITY"].ToString() != "")
                    {
                        strVisaValidity = objCommon.ConvertDateTimeToStringWithoutTime(Convert.ToDateTime(dtCandidate.Rows[0]["STAFF_VISA_VALIDITY"]));
                    }

                    tableQualification.AddCell(new PdfPCell(new Phrase("" + strVisaValidity, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("1. References : (Two references other than relatives)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("A. Name Address, Occupation & Phone Number : \n\n" + dtCandidate.Rows[0]["STAFF_REFF_A_NAME"] + " " + dtCandidate.Rows[0]["STAFF_REFF_A_ADDR"] + " " + dtCandidate.Rows[0]["STAFF_REFF_A_OCCUPATION"] + " " + dtCandidate.Rows[0]["STAFF_REFF_A_PHN"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("B. Name Address, Occupation & Phone Number : \n\n" + dtCandidate.Rows[0]["STAFF_REFF_B_NAME"] + "  " + dtCandidate.Rows[0]["STAFF_REFF_B_ADDR"] + " " + dtCandidate.Rows[0]["STAFF_REFF_B_OCCUPATION"] + " " + dtCandidate.Rows[0]["STAFF_REFF_B_PHN"], FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
                    tableQualification.AddCell(new PdfPCell(new Phrase("2. Do you have any objections to our securing report from your present and previous employers: (if required)", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });

                    if (strId != "BlankMode")
                    {
                        if (dtCandidate.Rows[0]["STAFF_REFF_SECUR_STS"].ToString() == "1")
                        {
                            tableQualification.AddCell(new PdfPCell(new Phrase(" YES", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                        }
                        else
                        {
                            tableQualification.AddCell(new PdfPCell(new Phrase(" NO", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                        }
                    }
                    else
                    {
                        tableQualification.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });

                    }
                    document.Add(tableQualification);

                    PdfPTable tableDeclaration = new PdfPTable(1);
                    float[] tableDeclarationBody = { 100 };
                    tableDeclaration.SetWidths(tableDeclarationBody);
                    tableDeclaration.WidthPercentage = 100;
                    tableDeclaration.AddCell(new PdfPCell(new Phrase("Declaration", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Rowspan = 5, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    tableDeclaration.AddCell(new PdfPCell(new Phrase("I declare that the information and facts stated herein above are true and correct to the best of my knowledge and belief.", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    tableDeclaration.AddCell(new PdfPCell(new Phrase("I also understand that any misrepresentation of facts in this application is sufficient for dismissal, if ever found.", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    tableDeclaration.AddCell(new PdfPCell(new Phrase("Place", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    tableDeclaration.AddCell(new PdfPCell(new Phrase("Date :                                                                                                      Signature :          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    document.Add(tableDeclaration);
                    PdfPTable tableOfficeuse = new PdfPTable(4);
                    float[] tableOfficeuseBody = { 30, 30, 30, 40 };
                    tableOfficeuse.SetWidths(tableOfficeuseBody);
                    tableOfficeuse.WidthPercentage = 100;
                    PdfContentByte cb = writer.DirectContent;
                    tableOfficeuse.DefaultCell.Border = Rectangle.NO_BORDER;
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("----------------------------------------------------------------------FOR OFFICE USE ONLY--------------------------------------------------------------------\n\n", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4, BorderColor = iTextSharp.text.BaseColor.WHITE });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("JOB NO./DIVISION", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 0 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 2 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("   DATE OF JOINING ", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 0 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 2, MinimumHeight = 25 });

                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("Copy To:  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, PaddingTop = 20, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 0, Colspan = 4 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("Division Head                  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 0, Colspan = 2 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER  ", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderWidth = 0, Colspan = 2 });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4, BorderColor = iTextSharp.text.BaseColor.WHITE });
                    tableOfficeuse.AddCell(new PdfPCell(new Phrase("Following original certificates verified and returned:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4, BorderColor = iTextSharp.text.BaseColor.WHITE });
                    document.Add(tableOfficeuse);


                }

                document.Close();
            }


            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
        }

        return strRet;


    } 
    

    public class PDFHeader : PdfPageEventHelper
    {
        

        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {

            clsBusiness_Candidate_Login objBusinessLayerUsrReg = new clsBusiness_Candidate_Login();
            clsEntityCandidatelogin objEntityUserRegistration = new clsEntityCandidatelogin();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (HttpContext.Current.Session["CORPOFFICEID"] != null)
            {
                objEntityUserRegistration.CorpOffice_Id = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"]);
            }

            if (HttpContext.Current.Session["ORGID"] != null)
            {
                objEntityUserRegistration.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"]);
            }

            DataTable dtCorp = objBusinessLayerUsrReg.ReadCorpDtls(objEntityUserRegistration);

            string strImageLogo = "";
            if (dtCorp.Rows.Count > 0)
            {
                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();                
            }

            base.OnStartPage(writer, document);

            PdfPTable tableHeader = new PdfPTable(4);
            float[] tableHeaderBody = { 25, 25, 25, 25 };
            tableHeader.SetWidths(tableHeaderBody);
            tableHeader.WidthPercentage = 100;
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image1.ScalePercent(PdfPCell.ALIGN_CENTER);
                image1.ScaleToFit(100f, 650f);
                tableHeader.AddCell(new PdfPCell(image1) { Rowspan = 2, PaddingTop = 7, PaddingBottom = 7, PaddingLeft = 7, HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tableHeader.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, PaddingTop = 7, PaddingBottom = 7, PaddingLeft = 7, HorizontalAlignment = Element.ALIGN_CENTER });
            }

            //tableHeader.AddCell(new PdfPCell(image1) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
            tableHeader.AddCell(new PdfPCell(new Phrase("JOINING DUTY FORM FOR STAFF", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3, FixedHeight = 55 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Doc No : F 119", FontFactory.GetFont("Arial", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
            tableHeader.AddCell(new PdfPCell(new Phrase("Rev No :  01", FontFactory.GetFont("Arial", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
            tableHeader.AddCell(new PdfPCell(new Phrase("Date : 17.10.16", FontFactory.GetFont("Arial", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
            tableHeader.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, Border = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
            tableHeader.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, Border = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
            tableHeader.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, Border = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
            tableHeader.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7, Border = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

            document.Add(tableHeader);
          
        }

     
    }
}