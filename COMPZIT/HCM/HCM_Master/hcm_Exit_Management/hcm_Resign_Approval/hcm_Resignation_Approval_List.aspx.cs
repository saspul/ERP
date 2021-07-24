using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_AWMS;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlEmployee.Focus();
            LoadRole();
            //DepartmentLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
                      clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
            clsEntityLayerresignationApproval objEntityResignApproval = new clsEntityLayerresignationApproval();
            int intUserId = 0, intEnableDMApprove=0, intcorpid =0,intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0,intEnableConfirm=0,intEnableReOpen=0, intEnableClose=0,intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0;

              if (Session["CORPOFFICEID"] != null)
            {
                Hiddencorpid.Value = Session["CORPOFFICEID"].ToString();
                intcorpid=Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityResignApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                Hiddenorgid.Value = Session["ORGID"].ToString();
                objEntityResignApproval.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityResignApproval.User_Id = Convert.ToInt32(Session["USERID"]);
                HiddenUsrId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 0;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Resignation_Approval);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

          //  ddrole.Items.Clear();
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
                        Hiddenenabledit.Value = intEnableModify.ToString(); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                      //  rolecount = rolecount++;
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);//22
                      //  ddrole.Items.Insert(0, "HR");
                       // ddrole.Items.Add("HR");
                        HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                      //  ddrole.Items.Add("DIVISION MANAGER");
                        //ddrole.Items.Insert(1, "DIVISION MANAGER");
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);//7
                       // rolecount = rolecount++;
                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString();

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                       // ddrole.Items.Add("GENERAL MANAGER");//25

                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                       // REPORTING OFFICER
                               //ddrole.Items.Add("DIVISION MANAGER");
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;//17

                    }
                 //   ddrole.DataBind();

                }
            }
            if (intEnableDMApprove != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("DIVISION MANAGER");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableHrConfirm != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("HR");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableGMApprove != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("GENERAL MANAGER");
                ddrole.Items.Remove(removeItem);

            }
            objEntityResignApproval.Mode = 5;
            objEntityResignApproval.StatsSrch = 5;
            objEntityResignApproval.EmplySrch = 5;
            DataTable dtManpower = objBusinessResignApproval.ReadResignationreqBySearch(objEntityResignApproval);
            int flag1 = 0;
            int flag = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtManpower.Rows.Count; intRowBodyCount++)
            {
                string ReportEmployee = dtManpower.Rows[intRowBodyCount]["REPORTEMP"].ToString();
                if (ReportEmployee == intUserId.ToString())
                { flag = 1; }
                else
                {
                   
                }
            }
            if (flag != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("REPORTING OFFICER");
              //  ddrole.Items.Remove(removeItem);
            }
           
            // if (intEnableAdd == 0)
            divAdd.Visible = false;
            if (Request.QueryString["Approve"] != null)
            {//when Canceled  
                string strRandomMixedId = Request.QueryString["Approve"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ApproveRequst(strId, intUserId);

            }
            if (Request.QueryString["Close"] != null)
            {//when Canceled  
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);


            }
            if (Request.QueryString["Approve"] != null)
            {//when Canceled  
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);


            }
            if (Request.QueryString["canId"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["canId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityResignApproval.Resignation_Id = Convert.ToInt32(strId);
                objEntityResignApproval.User_Id = intUserId;

                objEntityResignApproval.Date = System.DateTime.Now;



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intcorpid);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        objEntityResignApproval.CancelReason = objCommon.CancelReason();

                       // objBusinessResignApproval.CancelManpowerRecruitmentById(objEntityResignApproval);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                        }

                    }
                    else
                    {

                        hiddenRsnid.Value = strId;

                    }
                }
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
                else if (strInsUpd == "Appr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
                else if (strInsUpd == "Close")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (strInsUpd == "Rejected")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);
                }
                else if (strInsUpd == "verify")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessVerified", "SuccessVerified();", true);
                }
                else if (strInsUpd == "ApprovedRep")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedRep", "SuccessApprovedRep();", true);
                }
                else if (strInsUpd == "ApprovedDivmanager")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedDivmanager", "SuccessApprovedDivmanager();", true);
                }
                else if (strInsUpd == "ApprovedHr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedHr", "SuccessApprovedHr();", true);
                }
               
                else if (strInsUpd == "ApprovedGm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedGm", "SuccessApprovedGm();", true);
                }
            }


           objEntityResignApproval.Mode = 1;
          objEntityResignApproval.StatsSrch = 0;
          DataTable dtEmployee = objBusinessResignApproval.ReadEmployee(objEntityResignApproval);
            for (int intRowBodyCount = 0; intRowBodyCount < dtEmployee.Rows.Count; intRowBodyCount++)
            {
               // string ReportEmployee = dtEmployee.Rows[0]["REPORTEMP"].ToString();
            }
            if (ddlStatus.SelectedItem.Text == "APPROVED")
            {
                objEntityResignApproval.StatsSrch = 1;
            }
            else if (ddlStatus.SelectedItem.Text == "REJECTED")
            {
                objEntityResignApproval.StatsSrch = 2;
            }
            else if (ddlStatus.SelectedItem.Text == "APPROVAL PENDING")
            {
                objEntityResignApproval.StatsSrch = 0;
            }
            if (ddlStatus.SelectedItem.Text == "APPROVAL PENDING")
            {
                if (ddrole.SelectedItem.Text == "HR")
                {
                    objEntityResignApproval.EmplySrch = 3;
                }
                else if (ddrole.SelectedItem.Text == "DIVISION MANAGER")
                {
                    objEntityResignApproval.EmplySrch = 2;
                }
                else if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
                {
                    objEntityResignApproval.EmplySrch = 1;
                }
                else if (ddrole.SelectedItem.Text == "GENERAL MANAGER")
                {
                    objEntityResignApproval.EmplySrch = 4;
                }
                else
                    objEntityResignApproval.EmplySrch = 0;
            }
                 dtManpower = objBusinessResignApproval.ReadResignationreqBySearch(objEntityResignApproval);
            LoadEmployee(dtEmployee);
            string strHtm = ConvertDataTableToHTML(dtManpower, intEnableModify, intEnableCancel, intEnableRecall,intEnableGMApprove);
            //Write to divReport
            divReport.InnerHtml = strHtm;

        }
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableGMApprove)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        int intCnclUsrId = 0;
        int intReCallForTAble = 0;
        //  int intReCallForTAble = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            intReCallForTAble = Convert.ToInt32(dt.Rows[intRowBodyCount]["RSGNTN_STATUS"].ToString());



        }

        // strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">" +"SL#" +"</th>";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DEISGNATION</th>";
            }

            else if (intColumnHeaderCount ==4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">PREFFERED LEAVING DATE</th>";
            }

            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\"></th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string reporttingsearch = "";
            string ReportEmployee = dt.Rows[0]["REPORTEMP"].ToString();
            if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
            {
                reporttingsearch = "1";
            }

            intReCallForTAble = Convert.ToInt32(dt.Rows[intRowBodyCount]["RSGNTN_STATUS"].ToString());

            intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            string strStatusMode = "";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            if (reporttingsearch == "1")
            {
                if (HiddenUsrId.Value != ReportEmployee)
                {
                    continue;
                }

                //slno = intRowBodyCount + 1;
                strHtml += "<tr  >";
                //strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a class=\"tooltip\" style=\" opacity: 1; margin-top: -9px;font-family: calibri;font-size: 13px;z-index: 4;\" title=\"\" onclick='return getdetails(this.href);' " +
                             " href=\"hcm_Resignation_Approval.aspx?Id=" + Id + "\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE ID"].ToString() + "</a> </td>";

                    }

                   else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +   dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + " </td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                    }


                    else if (intColumnBodyCount == 6)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + " </td>";

                    }

                 


                }
                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return JobDescrpId('" + Id + "');\" /></td>";


                strHtml += "</tr>";
            }

            else
            {

                //slno = intRowBodyCount + 1;
                strHtml += "<tr  >";
                //strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" style=\" opacity: 1; margin-top: -9px;font-family: calibri;font-size: 13px;z-index: 4;\" title=\"\" onclick='return getdetails(this.href);' " +
                             " href=\"hcm_Resignation_Approval.aspx?Id=" + Id + "\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE ID"].ToString() + "</a> </td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                    }


                    else if (intColumnBodyCount == 5)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][2].ToString() + " </td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + " </td>";

                    }



                }

                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return JobDescrpId('" + Id + "');\" /></td>";
                strHtml += "</tr>";

            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

   
    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval objEntityResignApproval = new clsEntityLayerresignationApproval();

        int intUserId = 0, intcorpid = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0;

      
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityResignApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityResignApproval.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityResignApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            //objEntityCntrct.User_Id = 
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.HCM_STAFF_LEAVE_APROVAL);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
        int rolecount=0;
      //  ddrole.Items.Clear();
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
                    Hiddenenabledit.Value = intEnableModify.ToString(); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    rolecount = rolecount++;
                       intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    rolecount = rolecount++;
                    HiddenGMApprove.Value = intEnableGMApprove.ToString();

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }

            }
        }
               DataTable dtBrnd = new DataTable();
             //  objEntityResignApproval.StatsSrch =Convert.ToInt32( ddlStatus.SelectedItem.Value);
               if (ddlStatus.SelectedItem.Text == "APPROVED")
               {
                   objEntityResignApproval.StatsSrch = 1;
               }
               else if (ddlStatus.SelectedItem.Text == "REJECTED")
               {
                   objEntityResignApproval.StatsSrch = 2;
               }
               else if (ddlStatus.SelectedItem.Text == "APPROVAL PENDING")
               {
                   objEntityResignApproval.StatsSrch = 0;
               }
               if (ddlStatus.SelectedItem.Text == "APPROVAL PENDING")
               {
                   if (ddrole.SelectedItem.Text == "HR")
                   {
                       objEntityResignApproval.EmplySrch = 3;
                   }
                   else if (ddrole.SelectedItem.Text == "DIVISION MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 2;
                   }
                   else if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
                   {
                       objEntityResignApproval.EmplySrch = 1;
                   }
                   else if (ddrole.SelectedItem.Text == "GENERAL MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 4;
                   }
                   
               }
               else if (ddlStatus.SelectedItem.Text == "APPROVED")
               {
                   if (ddrole.SelectedItem.Text == "HR")
                   {
                       objEntityResignApproval.EmplySrch = 3;
                   }
                   else if (ddrole.SelectedItem.Text == "DIVISION MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 2;
                   }
                   else if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
                   {
                       objEntityResignApproval.EmplySrch = 1;
                   }
                   else if (ddrole.SelectedItem.Text == "GENERAL MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 4;
                   }
                   else
                       objEntityResignApproval.EmplySrch = 0;
               }
               else if (ddlStatus.SelectedItem.Text == "REJECTED")
               {
                   if (ddrole.SelectedItem.Text == "HR")
                   {
                       objEntityResignApproval.EmplySrch = 3;
                   }
                   else if (ddrole.SelectedItem.Text == "DIVISION MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 2;
                   }
                   else if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
                   {
                       objEntityResignApproval.EmplySrch = 1;
                   }
                   else if (ddrole.SelectedItem.Text == "GENERAL MANAGER")
                   {
                       objEntityResignApproval.EmplySrch = 4;
                   }
                   else
                       objEntityResignApproval.EmplySrch = 0;
               }
              
               else
                   objEntityResignApproval.EmplySrch = 0;
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {

            objEntityResignApproval.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        dtBrnd = objBusinessResignApproval.ReadResignationreqBySearch(objEntityResignApproval);


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
            intEnableRecall = 0;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.HCM_STAFF_LEAVE_APROVAL);
      //  DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }

            }
        }


        string strHtm = ConvertDataTableToHTML(dtBrnd, intEnableModify, intEnableCancel, intEnableRecall,intEnableGMApprove);
        //Write to divReport
        // LoadEmployee(dtBrnd);
        DataTable dtEmployee = objBusinessResignApproval.ReadEmployee(objEntityResignApproval);

         // LoadEmployee(dtEmployee);
        divReport.InnerHtml = strHtm;
    }


    
    public void ApproveRequst(string stid,int intUserId)
    {

        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval objEntityResignApproval = new clsEntityLayerresignationApproval();
        objEntityResignApproval.ApprovalStatus = 1;
        objEntityResignApproval.Requeststatus = 6;
        objEntityResignApproval.Date = DateTime.Today;
        objEntityResignApproval.User_Id = Convert.ToInt32(intUserId);
        objEntityResignApproval.Resignation_Id = Convert.ToInt32(stid);

        objBusinessResignApproval.DivsionManagerApproval(objEntityResignApproval);

    }

    public void LoadEmployee(DataTable dt)
    {
        DataView view = new DataView(dt);
        DataTable distinctValues = view.ToTable(true, "USR_ID", "EMPLOYEE");


        ddlEmployee.DataSource = distinctValues;
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataTextField = "EMPLOYEE";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    public void LoadRole()
    {
   
         ListItem lstGrp = new ListItem("REPORTING OFFICER", "0");

        ddrole.Items.Insert(0, lstGrp);
   
        lstGrp = new ListItem("DIVISION MANAGER", "1");
        ddrole.Items.Insert(1, lstGrp);
        lstGrp = new ListItem("HR", "2");
        ddrole.Items.Insert(2, lstGrp);
        lstGrp = new ListItem("GENERAL MANAGER", "3");
        ddrole.Items.Insert(3, lstGrp);
       
    }
}