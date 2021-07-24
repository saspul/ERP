using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
// CREATED BY:EVM-0001
// CREATED DATE:12/05/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Transaction_gen_Lead_gen_TaskManipulation : System.Web.UI.Page
{
    static string PintMode = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intUserId = 0, intCorpId = 0, intOrgId = 0, intListMode=0;

            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
            clsBusinessLayerLeadIndividual objBusinessLeadIndvl = new clsBusinessLayerLeadIndividual();
            clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityLead.Active_UserId = intUserId;
            objEntityLead.Corp_Id = intCorpId;
            objEntityLead.Org_Id = intOrgId;
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();               
                 if (strInsUpd == "UpdTask")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationTask", "SuccessUpdationTask();", true);
                }
                 else if (strInsUpd == "LdCls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "LeadAlreadyClosed", "LeadAlreadyClosed();", true);
                }
                 else if (strInsUpd == "ClsTask")
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationTask", "SuccessCancelationTask();", true);
                 }                
            }
         
            if (Request.QueryString["T_MODE"] != null)
            {
                string strTaskListMode = Request.QueryString["T_MODE"].ToString();
                if (strTaskListMode == "O")
                {
                    intListMode = 3;
                    //pHeader.InnerHtml = "Listing Open Follow-Up/Task";
                }
                else if (strTaskListMode == "A")
                {
                    intListMode = 1;
                    //pHeader.InnerHtml = "Listing Follow-Up/Task about to Breach";
                   // divclrIndctnBreachd.Visible = false;
                   
                }
                else if (strTaskListMode == "B")
                {
                    intListMode = 2;
                    //pHeader.InnerHtml = "Listing Breached Follow-Up/Task";
                    //divclrIndctnOpen.Visible = false;
                }
                else if (strTaskListMode == "U")
                {
                    intListMode = 4;
                    //pHeader.InnerHtml = "Listing Upcoming Follow-Up/Task";
                    //divclrIndctnBreachd.Visible = false;
                }
               HiddenFieldListMode.Value = intListMode.ToString();
               //DataTable dtTask = objBusinessDashBoard.Read_Task_List(objEntityLead,intListMode);
               // string strHtmTask = ConvertDataTableToHTMLTask(dtTask);              
               //Write to divReport
               //divReport.InnerHtml = strHtmTask;
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;
            // FOR TASK TIME SELECT
            LoadTaskTimeDropDowns();
            //for Task Subject drop down in Task ddl
            DataTable dtTaskSubjctList = objBusinessLeadIndvl.Read_TaskSubject();
            divOptionsTaskSubject.InnerHtml = ConvertDataTableToHTMLSelectOptions(dtTaskSubjctList);
        }

    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLSelectOptions(DataTable dtSelect)
    {
        //add options

        string strOptn = "";
        for (int i = 0; i < dtSelect.Rows.Count; i++)
        {

            strOptn += "<option ";

            for (int j = 0; j < dtSelect.Columns.Count; j++)
            {
                if (j == 0)
                {//id
                    strOptn += "value=\"" + dtSelect.Rows[i][j].ToString() + "\">";
                }
                if (j == 1)
                {//name
                    strOptn += dtSelect.Rows[i][j].ToString();
                }


            }
            strOptn += "</option>";
        }
        string strDynamicOptions = strOptn;
        return strDynamicOptions;

    }
    public static string ConvertDataTableToHTMLTask(DataTable dt)
    {
        int intWinLoss=0;
        clsCommonLibrary objCommon = new clsCommonLibrary();     
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
       
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tr_c\" colspan=\"4\">No data available in table</td>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intStsId = 0;
                intStsId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDSTS_ID"].ToString());

                if (intStsId == Convert.ToInt32(clsCommonLibrary.LeadStatus.Success) || intStsId == Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss))
                {
                    intWinLoss = 1;

                }
                else
                {
                    intWinLoss = 0;
                }
                //for replacing special characters

                string strLeadId = "";
                strLeadId = dt.Rows[intRowBodyCount]["LEADS_ID"].ToString();

                string strId = strLeadId;
                int intIdLength = strLeadId.Length;
                string stridLength = intIdLength.ToString("00");
                string strLeadMixedId = stridLength + strId + strRandom;


                string strTaskId = "";
                strTaskId = dt.Rows[intRowBodyCount]["TASK_ID"].ToString();
                strTaskId = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskId);

                string strTaskSbjctId = dt.Rows[intRowBodyCount]["TASKSUBJCT_ID"].ToString();
                strTaskSbjctId = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskSbjctId);


                string strTaskSbjctName = dt.Rows[intRowBodyCount]["TASKSUBJCT_NAME"].ToString();
                strTaskSbjctName = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskSbjctName);

                string strTaskDueDate = dt.Rows[intRowBodyCount]["T_DUE_DATE"].ToString();
                strTaskDueDate = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskDueDate);

                string strTaskDueHr = dt.Rows[intRowBodyCount]["T_DUE_HOUR"].ToString();
                strTaskDueHr = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskDueHr);

                string strTaskDueMin = dt.Rows[intRowBodyCount]["T_DUE_MIN"].ToString();
                strTaskDueMin = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskDueMin);

                string strTaskDueAM_PM = dt.Rows[intRowBodyCount]["T_DUE_AM_PM"].ToString();
                strTaskDueAM_PM = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskDueAM_PM);

                string strTaskInsDate = dt.Rows[intRowBodyCount]["T_INS_DATE"].ToString();
                strTaskInsDate = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskInsDate);

                string strTaskInsHr = dt.Rows[intRowBodyCount]["T_INS_HOUR"].ToString();
                strTaskInsHr = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskInsHr);

                string strTaskInsMin = dt.Rows[intRowBodyCount]["T_INS_MIN"].ToString();
                strTaskInsMin = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskInsMin);

                string strTaskInsAM_PM = dt.Rows[intRowBodyCount]["T_INS_AM_PM"].ToString();
                strTaskInsAM_PM = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskInsAM_PM);


                string strTaskClsDate = dt.Rows[intRowBodyCount]["T_CLS_DATE"].ToString();
                strTaskClsDate = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskClsDate);

                string strTaskClsHr = dt.Rows[intRowBodyCount]["T_CLS_HOUR"].ToString();
                strTaskClsHr = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskClsHr);

                string strTaskClsMin = dt.Rows[intRowBodyCount]["T_CLS_MIN"].ToString();
                strTaskClsMin = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskClsMin);

                string strTaskClsAM_PM = dt.Rows[intRowBodyCount]["T_CLS_AM_PM"].ToString();
                strTaskClsAM_PM = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskClsAM_PM);

                string strTaskCurDate = dt.Rows[intRowBodyCount]["T_CUR_DATE"].ToString();
                strTaskCurDate = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskCurDate);

                string strTaskCurHr = dt.Rows[intRowBodyCount]["T_CUR_HOUR"].ToString();
                strTaskCurHr = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskCurHr);

                string strTaskCurMin = dt.Rows[intRowBodyCount]["T_CUR_MIN"].ToString();


                if (strTaskCurMin != "")
                {
                    int intCurMin = Convert.ToInt32(strTaskCurMin);
                    if (intCurMin >= 0 && intCurMin < 5)
                    {
                        int intMin = 0;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 5 && intCurMin < 10)
                    {
                        int intMin = 5;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 10 && intCurMin < 15)
                    {

                        int intMin = 10;
                        strTaskCurMin = intMin.ToString("00");
                    }
                    else if (intCurMin >= 15 && intCurMin < 20)
                    {
                        int intMin = 15;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 20 && intCurMin < 25)
                    {
                        int intMin = 20;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 25 && intCurMin < 30)
                    {
                        int intMin = 25;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 30 && intCurMin < 35)
                    {
                        int intMin = 30;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 35 && intCurMin < 40)
                    {
                        int intMin = 35;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 40 && intCurMin < 45)
                    {

                        int intMin = 40;
                        strTaskCurMin = intMin.ToString("00");
                    }
                    else if (intCurMin >= 45 && intCurMin < 50)
                    {
                        int intMin = 45;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 50 && intCurMin < 55)
                    {
                        int intMin = 50;
                        strTaskCurMin = intMin.ToString("00");

                    }
                    else if (intCurMin >= 55 && intCurMin < 60)
                    {

                        int intMin = 55;
                        strTaskCurMin = intMin.ToString("00");
                    }
                }

                strTaskCurMin = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskCurMin);

                string strTaskCurAM_PM = dt.Rows[intRowBodyCount]["T_CUR_AM_PM"].ToString();
                strTaskCurAM_PM = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskCurAM_PM);

                string strDescptn = dt.Rows[intRowBodyCount]["TASK_DESCRIPTION"].ToString();
                strDescptn = objCommon.ReplaceEscapeSequence_ForJavascript(strDescptn);

                string strStatus = dt.Rows[intRowBodyCount]["TASK_STATUS"].ToString();
                strStatus = objCommon.ReplaceEscapeSequence_ForJavascript(strStatus);

                string strTaskCloseStatus = dt.Rows[intRowBodyCount]["TASK_CLOSE_STATUS"].ToString();
                strTaskCloseStatus = objCommon.ReplaceEscapeSequence_ForJavascript(strTaskCloseStatus);

                
                    string strDueDate = strTaskDueDate + "-" + strTaskDueHr + "-" + strTaskDueMin + "-" + strTaskDueAM_PM;
                    DateTime dtDueDateTime = objCommon.textWithTimeToDateTime(strDueDate);
                    if (dtDueDateTime < System.DateTime.Now)
                    {
                        strHtml += "<tr>";
                        strHtml += "<td class=\"tr_l\"><div class=\"bo_not1 mrl_bon flt_l fol_1_ico\" title=\"Breached task / Follow-Up\">";
                        strHtml += "<i class=\"fa fa-book\"></i></div>";
                        strHtml +="<a onclick='return GetIndividual(this.href);' " +
                              " href=\"/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strLeadMixedId + "\">" + dt.Rows[intRowBodyCount]["CUSTOMER_NAME"].ToString() + "</a></td>";
                    }
                    else
                    {
                        strHtml += "<tr >";
                        strHtml += "<td class=\"tr_l\"><div class=\"bo_not1 mrl_bon flt_l fol_3_ico\" title=\"Open task / Follow-Up\">";
                        strHtml += "<i class=\"fa fa-book\"></i></div>";
                        strHtml += " <a onclick='return GetIndividual(this.href);' " +
                              " href=\"/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strLeadMixedId + "\">" + dt.Rows[intRowBodyCount]["CUSTOMER_NAME"].ToString() + "</a></td>";
                    }
                


                int intCnt = intRowBodyCount + 1;
                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;padding-left: 0px;\">" + intCnt + "</td>";
                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["TASKSUBJCT_NAME"].ToString() + "</td>";
                strHtml += "<td>" + dt.Rows[intRowBodyCount]["TASK_DUE_DATE"].ToString() + "</td>";


                strHtml += "<td>";
                if (intWinLoss == 0 )//if not win or loss 
                {
                     strHtml += "<button class=\"btn act_btn bn1 bt_e\" id='SpanEditViewTask" + intRowBodyCount + "' onclick=\"return EditModalTask('SpanEditViewTask" + intRowBodyCount + "',event,'" + strTaskId + "','" + strTaskSbjctId + "','" + strTaskSbjctName + "','" + strTaskDueDate + "','" + strTaskDueHr + "','" + strTaskDueMin + "','" + strTaskDueAM_PM + "','" + strDescptn + "','" + strStatus + "');\" title=\"Edit Followup / Task\">";
                     strHtml += "<i class=\"fa fa-edit\"></i>";
                     strHtml += "</button>";


                     strHtml += "<button class=\"btn act_btn bn1\" id='SpanEditViewCancelTask" + intRowBodyCount + "' onclick=\"return OpenModalCancelTask('SpanEditViewCancelTask" + intRowBodyCount + "',event,'" + strTaskId + "','" + strTaskInsDate + "','" + strTaskInsHr + "','" + strTaskInsMin + "','" + strTaskInsAM_PM + "','" + strTaskCurDate + "','" + strTaskCurHr + "','" + strTaskCurMin + "','" + strTaskCurAM_PM + "');\" title=\"Close this task\">";
                    strHtml += "<i class=\"fa fa-tasks\"></i>";
                    strHtml += "</button>";

                        
                }
                else
                {
                    strHtml += "<button class=\"btn act_btn bn4\" id='SpanEditViewTask" + intRowBodyCount + "'  onclick=\"return ViewModalTask('SpanEditViewTask" + intRowBodyCount + "',event,'" + strTaskSbjctId + "','" + strTaskSbjctName + "','" + strTaskDueDate + "','" + strTaskDueHr + "','" + strTaskDueMin + "','" + strTaskDueAM_PM + "','" + strDescptn + "','" + strStatus + "');\" title=\"View Followup / Task\">";
                    strHtml += "<i class=\"fa fa-list-alt\"></i>";
                    strHtml += "</button>";

                   
                    strHtml += "<button class=\"btn act_btn bn1\" disabled title=\"Close this task\">";
                    strHtml += "<i class=\"fa fa-tasks\"></i>";
                    strHtml += "</button>";


                }

                strHtml += "</tr>";
            }
        }
        return strHtml;
    }

    private void LoadTaskTimeDropDowns()
    {
        ddlPlusWeek.Items.Clear();
        ddlTaskHr.Items.Clear();
        ddlTaskMin.Items.Clear();
        ddlTask_AM_PM.Items.Clear();

  
        ddlCCancelTaskHr.Items.Clear();
      
        ddlCCancelTaskMin.Items.Clear();
     
        ddlCCancel_AM_PM.Items.Clear();

        for (int intHr = 1; intHr <= 12; intHr++)
        {
            string strHour = intHr.ToString("00");

            ddlTaskHr.Items.Add(strHour);
         
            ddlCCancelTaskHr.Items.Add(strHour);

        }
        for (int intMin = 0; intMin <= 59; intMin = intMin + 5)
        {
            string strMinute = intMin.ToString("00");

            ddlTaskMin.Items.Add(strMinute);
          
            ddlCCancelTaskMin.Items.Add(strMinute);

        }
        ddlTask_AM_PM.Items.Add("AM");
        ddlTask_AM_PM.Items.Add("PM");
      
        ddlCCancel_AM_PM.Items.Add("AM");
        ddlCCancel_AM_PM.Items.Add("PM");


        ddlPlusWeek.Items.Add("--Select Week--");
        System.Web.UI.WebControls.ListItem lst4Week = new System.Web.UI.WebControls.ListItem("4 Weeks", "4");
        ddlPlusWeek.Items.Insert(1, lst4Week);
        System.Web.UI.WebControls.ListItem lst3Week = new System.Web.UI.WebControls.ListItem("3 Weeks", "3");
        ddlPlusWeek.Items.Insert(1, lst3Week);
        System.Web.UI.WebControls.ListItem lst2Week = new System.Web.UI.WebControls.ListItem("2 Weeks", "2");
        ddlPlusWeek.Items.Insert(1, lst2Week);
        System.Web.UI.WebControls.ListItem lst1Week = new System.Web.UI.WebControls.ListItem("1 Week", "1");
        ddlPlusWeek.Items.Insert(1, lst1Week);
    }

    protected void btnTaskUpd_Click(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["T_MODE"] != null && hiddenTaskId.Value != "")
            {
                clsBusinessLayerLeadIndividual objBusinessLeadIndvl = new clsBusinessLayerLeadIndividual();
                clsEntityTask objEntityTask = new clsEntityTask();
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityTask.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityTask.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityTask.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityTask.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (hiddenTaskSubjctId.Value != null && hiddenTaskSubjctId.Value != "")
                {
                    objEntityTask.TaskSubjectId = Convert.ToInt32(hiddenTaskSubjctId.Value);

                }
                string strTaskDate = txtTaskDate.Text;
                string strHour = "", strMinute = "", strAM_PM = "";

                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (strTaskDate != "")
                {
                    strHour = ddlTaskHr.SelectedValue.ToString();
                    strMinute = ddlTaskMin.SelectedValue.ToString();
                    strAM_PM = ddlTask_AM_PM.SelectedValue.ToString();
                    string strDateTime = strTaskDate + "-" + strHour + "-" + strMinute + "-" + strAM_PM;
                    objEntityTask.DueDate = objCommon.textWithTimeToDateTime(strDateTime);
                }
                objEntityTask.Description = txtTaskDescptn.Value.Trim();


                string strTaskListMode = Request.QueryString["T_MODE"].ToString();

                //Status checkbox checked
                if (cbxTaskStatus.Checked == true)
                {
                    objEntityTask.TaskStatus = 1;
                }
                //Status checkbox not checked
                else
                {
                    objEntityTask.TaskStatus = 0;
                }

                if (Session["USERID"] != null)
                {
                    objEntityTask.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                objEntityTask.Date = System.DateTime.Now;

                objEntityTask.TaskId = Convert.ToInt32(hiddenTaskId.Value);
               DataTable dtLeadStatus= objBusinessLeadIndvl.Read_LeadStatus_By_TaskId(objEntityTask);
               if (dtLeadStatus.Rows.Count > 0)
               {
                   int intWinLoss = 0;
                   int intLeadSts = Convert.ToInt32(dtLeadStatus.Rows[0]["LDSTS_ID"].ToString());
                   if (intLeadSts == Convert.ToInt32(clsCommonLibrary.LeadStatus.Success) || intLeadSts == Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss))
                   {
                       intWinLoss = 1;

                   }
                   else
                   {
                       intWinLoss = 0;
                   }
                   if (intWinLoss == 0)
                   {
                       objBusinessLeadIndvl.UpdateTask(objEntityTask);
                       Response.Redirect("gen_TaskManipulation.aspx?T_MODE=" + strTaskListMode + "&InsUpd=UpdTask");
                   }
                   else
                   {
                       Response.Redirect("gen_TaskManipulation.aspx?T_MODE=" + strTaskListMode + "&InsUpd=LdCls");
                      
                   
                   }
               }


            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }

     protected void btnCancelTaskSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["T_MODE"] != null && hiddenTaskId.Value != "")
            {
                clsBusinessLayerLeadIndividual objBusinessLeadIndvl = new clsBusinessLayerLeadIndividual();
                clsEntityTask objEntityTask = new clsEntityTask();

              
               
                string strTaskClosedDate = txtCCancelTaskDate.Text;
                string strHour = "", strMinute = "", strAM_PM = "";

                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (strTaskClosedDate != "")
                {
                    strHour = ddlCCancelTaskHr.SelectedValue.ToString();
                    strMinute = ddlCCancelTaskMin.SelectedValue.ToString();
                    strAM_PM = ddlCCancel_AM_PM.SelectedValue.ToString();
                    string strDateTime = strTaskClosedDate + "-" + strHour + "-" + strMinute + "-" + strAM_PM;
                    objEntityTask.Date = objCommon.textWithTimeToDateTime(strDateTime);
                }



                string strTaskListMode = Request.QueryString["T_MODE"].ToString();

              

                if (Session["USERID"] != null)
                {
                    objEntityTask.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            

                objEntityTask.TaskId = Convert.ToInt32(hiddenTaskId.Value);

                objBusinessLeadIndvl.DeleteTask(objEntityTask);
                Response.Redirect("gen_TaskManipulation.aspx?T_MODE=" + strTaskListMode + "&InsUpd=ClsTask");

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }
     [WebMethod]
     public static string PrintList(string OrgId, string CorpId, string FromDate, string ToDate, string Status, string SearchText, string Condition, string Ageing1, string Ageing2, string StatusT, string UpdRole, string L_MODE, string hiddenLMode, string HiddenTeamId, string UserId)
     {

         PintMode = "0";
         string strReturn = "";
         //end
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsBusinessLayer objBusiness = new clsBusinessLayer();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         clsBusinessLayerLeadCreation objBusinessLayerLead = new clsBusinessLayerLeadCreation();
         clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
         objEntityLead.Org_Id = Convert.ToInt32(OrgId);
         objEntityLead.Corp_Id = Convert.ToInt32(CorpId);
         objEntityLead.User_Id = Convert.ToInt32(UserId);
         if (FromDate != "")
             objEntityLead.LeadDate = objCommon.textToDateTime(FromDate);
         if (ToDate != "")
             objEntityLead.InsertDate = objCommon.textToDateTime(ToDate);
         if (Ageing1 != "")
             objEntityLead.LeadSourceId = Convert.ToInt32(Condition);
         if (Ageing1 != "")
             objEntityLead.LeadId = Convert.ToInt32(Ageing1);
         if (Ageing2 != "")
             objEntityLead.DivisionId = Convert.ToInt32(Ageing2);

         DataTable dtUser = new DataTable();

         if (L_MODE == null || L_MODE == "")
         {// normal method
             objEntityLead.Customer_Name = SearchText;
             if (Status == "ALL STATUS" || Status == "")
             {
                 objEntityLead.Status = 0;
             }
             else
             {

                 objEntityLead.Status = Convert.ToInt32(Status);
             }
             dtUser = objBusinessLayerLead.Read_Customer_List_BySearch(objEntityLead);
         }
         else if (L_MODE != null && L_MODE != "")
         {
             string strLeadListMode = hiddenLMode;

             //from dashboard
             // here status id =0 for active leads
             objEntityLead.Customer_Name = SearchText;
             if (Status == "ALL ACTIVE STATUS" || Status == "")
             {
                 objEntityLead.Status = 0;
             }
             else
             {

                 objEntityLead.Status = Convert.ToInt32(Status);
             }
             if (strLeadListMode == "APRV_PNDNG")
             {

                 string strId = "0";
                 if (HiddenTeamId != "")
                 {
                     string strRandomMixedId = HiddenTeamId;
                     string strLenghtofId = strRandomMixedId.Substring(0, 2);
                     int intLenghtofId = Convert.ToInt16(strLenghtofId);
                     strId = strRandomMixedId.Substring(2, intLenghtofId);
                 }
                 objEntityLead.Team = Convert.ToInt32(strId);

                 dtUser = objBusinessLayerLead.Read_Pending_Lead_Detail_ByTeam(objEntityLead);

             }
             else if (strLeadListMode == "NEW" || strLeadListMode == "APRV" || strLeadListMode == "ACTV" || strLeadListMode == "DPEND")
             {
                 dtUser = objBusinessLayerLead.Read_Customer_List_Indvl_BySearch(objEntityLead);
             }
             else if (strLeadListMode == "TCNVRTD" || strLeadListMode == "TJUNK" || strLeadListMode == "TONOLD")
             {
                 dtUser = objBusinessLayerLead.Read_Customer_List_Indvl_BySearch(objEntityLead);
             }
             else if (strLeadListMode == "MCNVRTD" || strLeadListMode == "MJUNK" || strLeadListMode == "MOPEND")
             {
                 dtUser = objBusinessLayerLead.Read_Customer_List_Indvl_Mnthly_BySearch(objEntityLead);
             }
         }
    
         string strRet = "";
         string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.OPPORTUNITY_LIST_PDF);
         objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.OPPORTUNITY_LIST_PDF);

         objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
         objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
         string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
         string strImageName = "OpportunityList_" + CorpId + "_" + strNextNumber + ".pdf";

         Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
         document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
         Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
         try
         {
             using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
             {
                 FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                 PdfWriter writer = PdfWriter.GetInstance(document, file);
                 writer.PageEvent = new PDFHeader();
                 document.Open();


                 PdfPTable footrtable = new PdfPTable(3);
                 float[] footrsBody1 = { 20, 5, 75 };
                 footrtable.SetWidths(footrsBody1);
                 footrtable.WidthPercentage = 100;


                 if (FromDate != "")
                 {
                     footrtable.AddCell(new PdfPCell(new Phrase("From Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(FromDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 }
                 if (ToDate != "")
                 {
                     footrtable.AddCell(new PdfPCell(new Phrase("To Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(ToDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 }

                 footrtable.AddCell(new PdfPCell(new Phrase("Status  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 footrtable.AddCell(new PdfPCell(new Phrase(StatusT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                 if (SearchText != "")
                 {
                     footrtable.AddCell(new PdfPCell(new Phrase("Customer Name", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                     footrtable.AddCell(new PdfPCell(new Phrase(SearchText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                 }

                 if (Ageing1 != "")
                 {
                     if (Condition == "1")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Equal To "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                     }
                     else if (Condition == "2")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Lessthan "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                     }
                     else if (Condition == "3")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Greaterthan "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                     }
                     else if (Condition == "4")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Lessthan Equal "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                     }
                     else if (Condition == "5")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Greaterthan Equal "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                     }
                     else if (Condition == "6")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Not Equal "+Ageing1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                     }
                     else if (Condition == "7" && Ageing2!="")
                     {
                         footrtable.AddCell(new PdfPCell(new Phrase("Ageing", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                         footrtable.AddCell(new PdfPCell(new Phrase("Between " + Ageing1 + " And " + Ageing2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                     }
                 }

                 document.Add(footrtable);


                 //adding table to pdf
                 PdfPTable TBCustomer = new PdfPTable(8);
                 float[] footrsBody = { 10, 10, 19,20,10,10,10,11 };
                 TBCustomer.SetWidths(footrsBody);
                 TBCustomer.WidthPercentage = 100;
                 TBCustomer.HeaderRows = 1;

                 var FontGray = new BaseColor(138, 138, 138);
                 var FontColour = new BaseColor(134, 152, 160);
                 var FontSmallGray = new BaseColor(230, 230, 230);

                 TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("AGEING", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("OPPORTUNITY OWNER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("SOURCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("LAST UPDATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTATION#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 
                 string strRandom = objCommon.Random_Number();


                 if (dtUser.Rows.Count > 0)
                 {
                     for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                     {
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][11].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                     }
                 }
                 else
                 {
                     TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
                 }
                 document.Add(TBCustomer);
                 document.Close();
                 strRet = strImagePath + strImageName;
             }
         }
         catch (Exception)
         {
             document.Close();
             strRet = "";
         }
         return strRet;
     }
     public class PDFHeader : PdfPageEventHelper
     {
         PdfContentByte cb;
         PdfTemplate footerTemplate;
         BaseFont bf = null;
         DateTime PrintTime = DateTime.Now;
         public override void OnOpenDocument(PdfWriter writer, Document document)
         {
             try
             {
                 PrintTime = DateTime.Now;
                 bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                 cb = writer.DirectContent;
                 footerTemplate = cb.CreateTemplate(200, 200);
             }
             catch (DocumentException de)
             {
                 //handle exception here
             }
             catch (System.IO.IOException ioe)
             {
                 //handle exception here
             }
         }
         public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
         {
             clsCommonLibrary objCommon = new clsCommonLibrary();
             clsEntityCommon ObjEntityCommon = new clsEntityCommon();
             clsBusinessLayer objDataCommon = new clsBusinessLayer();
             ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
             ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
             DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
             string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
             string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
             if (dtCorp.Rows.Count > 0)
             {
                 if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                 {
                     string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                     string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                     strImageLogo = imaeposition + icon;
                 }
                 strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                 strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                 strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                 strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
             }
             string strAddress = "";
             strAddress = strCompanyAddr1;
             if (strCompanyAddr2 != "")
             {
                 strAddress += ", " + strCompanyAddr2;
             }
             if (strCompanyAddr3 != "")
             {
                 strAddress += ", " + strCompanyAddr3;
             }
             //Head Table
             PdfPTable headtable = new PdfPTable(2);
             string strx = "OPPORTUNITY LIST";
             if (PintMode == "1")
             {
                 strx = "TASKS LIST";
             }

             headtable.AddCell(new PdfPCell(new Phrase(strx, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             if (strImageLogo != "")
             {
                 iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                 image.ScalePercent(PdfPCell.ALIGN_CENTER);
                 image.ScaleToFit(60f, 40f);
                 headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
             }
             else
             {
                 headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             }
             headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
             headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
             float[] headersHeading = { 80, 20 };
             headtable.SetWidths(headersHeading);
             headtable.WidthPercentage = 100;
             document.Add(headtable);
             PdfPTable tableLine = new PdfPTable(1);
             float[] tableLineBody = { 100 };
             tableLine.SetWidths(tableLineBody);
             tableLine.WidthPercentage = 100;
             tableLine.TotalWidth = 650F;
             tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             float pos9 = writer.GetVerticalPosition(false);
         }
         public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
         {
             // base.OnEndPage(writer, document);
             string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
             PdfPTable table3 = new PdfPTable(1);
             float[] tableBody3 = { 100 };
             table3.SetWidths(tableBody3);
             table3.WidthPercentage = 100;
             table3.TotalWidth = 650F;
             table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
             PdfPTable headImg = new PdfPTable(3);
             string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
             //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

             headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
             if (strImageLogo != "")
             {
                 iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                 image.ScalePercent(PdfPCell.ALIGN_CENTER);
                 image.ScaleToFit(60f, 40f);
                 headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
             }

             headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
             headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
             float[] headersHeading = { 20, 60, 20 };
             headImg.SetWidths(headersHeading);
             headImg.WidthPercentage = 100;
             headImg.TotalWidth = document.PageSize.Width - 80f;

             headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

             String text = "Page " + writer.PageNumber + " of ";
             //Add paging to footer
             {
                 cb.BeginText();
                 cb.SetFontAndSize(bf, 8);
                 cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                 cb.ShowText(text);
                 cb.EndText();
                 float len = bf.GetWidthPoint(text, 8);
                 cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
             }
         }
         public override void OnCloseDocument(PdfWriter writer, Document document)
         {
             base.OnCloseDocument(writer, document);
             footerTemplate.BeginText();
             footerTemplate.SetFontAndSize(bf, 8);
             footerTemplate.SetTextMatrix(0, 0);
             footerTemplate.ShowText((writer.PageNumber).ToString());
             footerTemplate.EndText();
         }
     }


     [WebMethod]
     public static string[] GetData(string OrgId, string CorpId, string userID, string ListingMode,string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
     {
         clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
         clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
         clsBusinessLayerLeadIndividual objBusinessLeadIndvl = new clsBusinessLayerLeadIndividual();
         clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
         objEntityLead.Active_UserId = Convert.ToInt32(userID);
         objEntityLead.Corp_Id = Convert.ToInt32(CorpId);
         objEntityLead.Org_Id = Convert.ToInt32(OrgId);

         string[] strResults = new string[2];
         objEntityLead.PageNumber = Convert.ToInt32(PageNumber);
         objEntityLead.PageMaxSize = Convert.ToInt32(PageMaxSize);
         objEntityLead.OrderMethod = Convert.ToInt32(OrderMethod);
         objEntityLead.OrderColumn = Convert.ToInt32(OrderColumn);
         objEntityLead.CommonSearchTerm = strCommonSearchTerm;
   
         DataTable dt = new DataTable();
         dt = objBusinessDashBoard.Read_Task_List(objEntityLead, Convert.ToInt32(ListingMode));

         strResults[0] = ConvertDataTableToHTMLTask(dt);
         if (dt.Rows.Count > 0)
         {
             int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
             int intCurrentRowCount = dt.Rows.Count;
             //Pagination
             strResults[1] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityLead.PageNumber, objEntityLead.PageMaxSize, intCurrentRowCount);
         }
         return strResults;
     }
     [WebMethod]
     public static string[] LoadStaticDatafordt()//Filters
     {
         StringBuilder html = new StringBuilder();
         StringBuilder sbSearchInputColumns = new StringBuilder();

         string[] strResults = new string[3];
         html.Append("<div>");

         html.Append("<div class=\"col-md-2\" style=\"padding-left: 0px;\">");//length
         html.Append("<label><span>Show</span> <select onchange=\"getdata(1);\" id=\"ddl_page_size\" style=\"height: 24px;margin: 0px 2px;margin-right: 2px;\">");
         html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
         html.Append("</label></div>");
         //page length ends
         //common filter
         html.Append("<div class=\"pull-right\" style=\"padding-right: 0px;\">");
         html.Append("<label>Search:");
         html.Append("<input  autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer(event);\" class=\"tbl_fil_s\" id=\"txtCommonSearch_dt\"  type=\"search\" aria-controls=\"example\">");
         html.Append("</label>");
         html.Append("</div>");
         //common filter ends
         html.Append("</div>");
         strResults[0] = html.ToString();

         int intSearchColumnCount = 0;
         sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-4 tr_l\" style=\"word-wrap:break-word;\">CUSTOMER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
         sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-3 tr_l\" style=\"word-wrap:break-word;\">SUBJECT<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
         sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"sorting col-md-2 tr_c\" style=\"word-wrap:break-word;\">DUE DATE & TIME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>"); 
         sbSearchInputColumns.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">ACTIONS</th>");

         strResults[1] = sbSearchInputColumns.ToString();
         strResults[2] = intSearchColumnCount.ToString();
         return strResults;
     }
     [WebMethod]
     public static string PrintList1(string orgID, string corptID, string userID, string ListingMode)
     {
         PintMode = "1";
         string strReturn = "";
         //end
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsBusinessLayer objBusiness = new clsBusinessLayer();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
         clsBusinessLayerLeadIndividual objBusinessLeadIndvl = new clsBusinessLayerLeadIndividual();
         clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
         objEntityLead.Active_UserId = Convert.ToInt32(userID);
         objEntityLead.Corp_Id = Convert.ToInt32(corptID);
         objEntityLead.Org_Id = Convert.ToInt32(orgID);
         objEntityLead.Allocate_UserId = 1;
         DataTable dtUser = new DataTable();
         dtUser = objBusinessDashBoard.Read_Task_List(objEntityLead, Convert.ToInt32(ListingMode));

         string strRet = "";
         string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TASKS_LIST_PDF);
         objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TASKS_LIST_PDF);

         objEntityCommon.CorporateID = Convert.ToInt32(corptID);
         objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
         string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
         string strImageName = "TasksList_" + corptID + "_" + strNextNumber + ".pdf";

         Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
         document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
         Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
         try
         {
             using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
             {
                 FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                 PdfWriter writer = PdfWriter.GetInstance(document, file);
                 writer.PageEvent = new PDFHeader();
                 document.Open();


                 //adding table to pdf
                 PdfPTable TBCustomer = new PdfPTable(3);
                 float[] footrsBody = { 40, 40, 20 };
                 TBCustomer.SetWidths(footrsBody);
                 TBCustomer.WidthPercentage = 100;
                 TBCustomer.HeaderRows = 1;

                 var FontGray = new BaseColor(138, 138, 138);
                 var FontColour = new BaseColor(134, 152, 160);
                 var FontSmallGray = new BaseColor(230, 230, 230);

                 TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("SUBJECT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 TBCustomer.AddCell(new PdfPCell(new Phrase("DUE DATE & TIME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 string strRandom = objCommon.Random_Number();


                 if (dtUser.Rows.Count > 0)
                 {
                     for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                     {
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount]["CUSTOMER_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount]["TASKSUBJCT_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount]["TASK_DUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                     }
                 }
                 else
                 {
                     TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 3 });
                 }
                 document.Add(TBCustomer);
                 document.Close();
                 strRet = strImagePath + strImageName;
             }
         }
         catch (Exception)
         {
             document.Close();
             strRet = "";
         }
         return strRet;
     }
}