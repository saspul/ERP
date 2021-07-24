using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_intrvw_Process_hcm_Exit_intrvw_Process : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit_Hcm.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
            clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();

            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                //objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                //intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                //objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Request.QueryString["Id"] != null && Request.QueryString["UserId"] != null)
            {             
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);           
                int intId = Convert.ToInt32(strId);
                HiddenId.Value = intId.ToString();
                string strRandomMixedUsrId = Request.QueryString["UserId"].ToString();
                string strLenghtofUsrId = strRandomMixedUsrId.Substring(0, 2);
                int intLenghtofUsrId = Convert.ToInt16(strLenghtofUsrId);
                string strUsrId = strRandomMixedUsrId.Substring(2, intLenghtofUsrId);
                int intEmpId = Convert.ToInt32(strUsrId);
                hiddenUserId.Value = intEmpId.ToString();
                EditView(intId, intEmpId);
                objEntityExitIntrvwProcess.EmpId = intEmpId;
                objEntityExitIntrvwProcess.DesgId = intId;
                DataTable dtanswers = new DataTable();
                dtanswers = objBusinessExitIntrvwProcess.ReadAnswers(objEntityExitIntrvwProcess);
                if (dtanswers.Rows.Count > 0)
                {
                    string strAnsr = "";
                    for (int i = 0; i < dtanswers.Rows.Count; i++)
                    {
                        if (strAnsr == "")
                        {
                            strAnsr = dtanswers.Rows[i]["INTRVW_ANSWER"].ToString();
                        }
                        else
                        {
                            strAnsr = strAnsr + "," + dtanswers.Rows[i]["INTRVW_ANSWER"].ToString();
                        }
                    }
                    HiddenAnswer.Value = strAnsr;
                }



            }
           
            if (Request.QueryString["MstrId"] != "")
            {
                string strRandomMixedMstrId = Request.QueryString["MstrId"].ToString();
                string strLenghtofMstrId = strRandomMixedMstrId.Substring(0, 2);
                int intLenghtofMstrId = Convert.ToInt16(strLenghtofMstrId);
                string strMstrId = strRandomMixedMstrId.Substring(2, intLenghtofMstrId);
                int intMstrId = 0;
                if (strMstrId != "")
                {
                    intMstrId = Convert.ToInt32(strMstrId);
                    HiddenMstrId.Value = strMstrId;
                }

                DataTable dtMasterid = new DataTable();
                objEntityExitIntrvwProcess.NextId = intMstrId;
                dtMasterid = objBusinessExitIntrvwProcess.ReadMstrId(objEntityExitIntrvwProcess);
                if (dtMasterid.Rows.Count > 0)
                {
                    btnSave.Visible = false;
                    btnSaveCnfrm.Visible = false;
                    if (dtMasterid.Rows[0]["CNFRM_STS"].ToString() != "0")
                    {
                        btnSave.Visible = false;
                        btnSaveCnfrm.Visible = false;
                        btnUpdate.Visible = false;
                        btnUpdateCnfrm.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "txtDisable", "txtDisable();", true);
                    }
                }
            }
            else
            {
                DataTable dtUserid = new DataTable();
                dtUserid = objBusinessExitIntrvwProcess.ReadUserId(objEntityExitIntrvwProcess);
                if (dtUserid.Rows.Count > 0)
                {
                    btnSave.Visible = false;
                    btnSaveCnfrm.Visible = false;
                    if (dtUserid.Rows[0]["CNFRM_STS"].ToString() != "0")
                    {
                        btnSave.Visible = false;
                        btnSaveCnfrm.Visible = false;
                        btnUpdate.Visible = false;
                        btnUpdateCnfrm.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "txtDisable", "txtDisable();", true);
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnSaveCnfrm.Visible = true;
                        btnUpdate.Visible = false;
                        btnUpdateCnfrm.Visible = false;
                    }
                }
                else
                {
                    btnSave.Visible = true;
                    btnSaveCnfrm.Visible = true;
                    btnUpdate.Visible = false;
                    btnUpdateCnfrm.Visible = false;
                }

            }
            if (Request.QueryString["RFGP"] != null)
            {
                btnCancel.Visible = false;
                divList.Visible = false;
                btnSave.Visible = false;
                btnSaveCnfrm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateCnfrm.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "txtDisable", "txtDisable();", true);
            }
        }
    }
    private void EditView(int Id, int EmpId)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
       
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityExitIntrvwProcess.EmpId = EmpId;

        DataTable dtInterviewCatDtl = new DataTable();
        DataTable dtEmpDivision = new DataTable();
        dtInterviewCatDtl = objBusinessExitIntrvwProcess.ReadEmployeeDlts(objEntityExitIntrvwProcess);
        dtEmpDivision = objBusinessExitIntrvwProcess.ReadEmployeeDivsn(objEntityExitIntrvwProcess);
    
            if (dtInterviewCatDtl.Rows.Count > 0)
            {
                lblEmpl.Text = dtInterviewCatDtl.Rows[0]["USR_NAME"].ToString();
                lblDesign.Text = dtInterviewCatDtl.Rows[0]["DSGN_NAME"].ToString();
                lblPay.Text = dtInterviewCatDtl.Rows[0]["PYGRD_NAME"].ToString();
            }
            if (dtEmpDivision.Rows.Count > 0)
            {
                lblDivision.Text = dtEmpDivision.Rows[0]["CPRDIV_NAME"].ToString();

            }
            objEntityExitIntrvwProcess.DesgId = Id;
            DataTable dtProductSrch = new DataTable();          
            dtProductSrch = objBusinessExitIntrvwProcess.ReadQuestions(objEntityExitIntrvwProcess);       
            string strHtm = ConvertDataTableToHTML(dtProductSrch);
            //Write to divReport
            divReport.InnerHtml = strHtm;
    }

    public string ConvertDataTableToHTML(DataTable dt)
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
            //if (i  0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
          
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:100%;text-align: left; word-wrap:break-word;\">Questions</th>";
            }
           

        }
       

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int i = intRowBodyCount + 1;
            strHtml += "<tr  >";

            
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><label style=\"float: left; width: 11.2%;\"> Question "+i+":</label>" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                
            }

            strHtml += "</tr>";
            strHtml += "<td class=\"tdT\" style=\"width:100%; word-wrap:break-word;text-align: left;\">Answer: <input name=\"ctl00$cphMain$txtYrOfExp\" maxlength=\"2000\" id=\"cphMain_txtanswr" + intRowBodyCount + "\" onchange=\"IncrmntConfrmCounter();\" onkeypress=\"return isTag(event)\" onblur=\"RemoveTag();\" class=\"form1\" style=\"width: 82.3%; margin-right: 4.7%; height: 30px\" type=\"text\"></td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
        List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList = new List<clsEntityLayer_Exit_Intrvw_Process_List>();

        if (Session["USERID"] != null)
        {
            objEntityExitIntrvwProcess.InsId = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityExitIntrvwProcess.DesgId = Convert.ToInt32(HiddenId.Value);
        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessExitIntrvwProcess.ReadQuestions(objEntityExitIntrvwProcess);      

        objEntityExitIntrvwProcess.InsDate = DateTime.Now;
        
        objEntityExitIntrvwProcess.EmpId =Convert.ToInt32(hiddenUserId.Value);
        objEntityExitIntrvwProcess.CnfrmSts = 0;
        string[] tokens = HiddenQuestions.Value.Split('~');

        for (int i = 0; i < tokens.Count(); i++)
        {

            string DesnationId =tokens[i];
           // DesnationId = DesnationId.Replace(" ", String.Empty);
            clsEntityLayer_Exit_Intrvw_Process_List objentityDesignation = new clsEntityLayer_Exit_Intrvw_Process_List();
            objentityDesignation.QuesId = Convert.ToInt32(dtProductSrch.Rows[i]["EXTINTRVQT_ID"].ToString());
            objentityDesignation.Ques = DesnationId;
            objEntityExitIntrvwProcessList.Add(objentityDesignation);
        }
     
        if (clickedButton.ID == "btnSave")
        {
            objBusinessExitIntrvwProcess.InsertQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
            Response.Redirect("hcm_Exit_intrvw_Process_List.aspx?InsUpd=Ins");
            
        }
        else if (clickedButton.ID == "btnSaveCnfrm")
        {
            DataTable dtUsrid = objBusinessExitIntrvwProcess.ReadUserId(objEntityExitIntrvwProcess);
            if (dtUsrid.Rows.Count < 1)
            {
                objEntityExitIntrvwProcess.CnfrmSts = 1;
                objBusinessExitIntrvwProcess.InsertQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
            }
            else
            {
                objEntityExitIntrvwProcess.CnfrmSts = 1;
                objEntityExitIntrvwProcess.NextId =Convert.ToInt32(dtUsrid.Rows[0]["INTRVW_MSTR_ID"].ToString());
                objBusinessExitIntrvwProcess.UpdateQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
            }
            Response.Redirect("hcm_Exit_intrvw_Process_List.aspx?InsUpd=Ins");
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_Exit_intrvw_Process_List.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
        List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList = new List<clsEntityLayer_Exit_Intrvw_Process_List>();

        if (Session["USERID"] != null)
        {
            objEntityExitIntrvwProcess.InsId = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        } objEntityExitIntrvwProcess.DesgId = Convert.ToInt32(HiddenId.Value);
        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessExitIntrvwProcess.ReadQuestions(objEntityExitIntrvwProcess);      
        objEntityExitIntrvwProcess.InsDate = DateTime.Now;
        objEntityExitIntrvwProcess.DesgId = Convert.ToInt32(HiddenId.Value);
        objEntityExitIntrvwProcess.EmpId = Convert.ToInt32(hiddenUserId.Value);
        objEntityExitIntrvwProcess.NextId = Convert.ToInt32(HiddenMstrId.Value);
        string[] tokens = HiddenQuestions.Value.Split('~');
       
        for (int i = 0; i < tokens.Count(); i++)
        {

            string DesnationId = tokens[i];
          //  DesnationId = DesnationId.Replace(" ", String.Empty);
            clsEntityLayer_Exit_Intrvw_Process_List objentityDesignation = new clsEntityLayer_Exit_Intrvw_Process_List();
            if(dtProductSrch.Rows.Count>i)
            objentityDesignation.QuesId = Convert.ToInt32(dtProductSrch.Rows[i]["EXTINTRVQT_ID"].ToString());
            objentityDesignation.Ques = DesnationId;
            objEntityExitIntrvwProcessList.Add(objentityDesignation);
        }
        
        if (clickedButton.ID == "btnUpdate")
        {
            objBusinessExitIntrvwProcess.UpdateQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
            Response.Redirect("hcm_Exit_intrvw_Process_List.aspx?InsUpd=Upd");
            
        }
        else if (clickedButton.ID == "btnUpdateCnfrm")
        {
            objEntityExitIntrvwProcess.CnfrmSts = 1;
            objBusinessExitIntrvwProcess.UpdateQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
            Response.Redirect("hcm_Exit_intrvw_Process_list.aspx?InsUpd=Upd");
        }
        
    }
}