using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit;
using System.Data;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
public partial class HCM_HCM_Master_Employee_Performance_Mangmnt_Employee_Perfomance_Evaluation_Employee_Performance_Evaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           

            clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
            clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

           

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UsrId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.CorpId = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            



            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                string strEmpId = "0";
                if (Request.QueryString["EmpId"] != "0")
                {
                    strRandomMixedId = Request.QueryString["Id"].ToString();
                    string result = strRandomMixedId.Substring( strRandomMixedId.LastIndexOf('.') );
                    result = result.Replace(".", "");
                   string   strEmpLenghtofId = result.Substring(0, 2);
                    int intLenghtofEmpId = Convert.ToInt16(strEmpLenghtofId);
                    strEmpId = result.Substring(2, intLenghtofEmpId);

                }


                Update(strId, strEmpId);

            }
        }
        
      
    }

    public void Update(string strP_Id, string strEmpId)
    {


        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.IssueId = Convert.ToInt32(strP_Id);
        HiddenIssueId.Value = strP_Id;

        objEntity.EmpUsrId = Convert.ToInt32(strEmpId);
        DataTable dt = objEmpPerfomance.ReadPerfomanceEvltionById(objEntity);
        int EmpUsrId=0;
        int RoEvaluvation = 0;
        int hrEvaluvation = 0;
        int DmEvaluvation = 0;
        int GmEvaluvation = 0;
        int SelfEvaluvation = 0;
        int ReptEvaluvation = 0;
        int RoEvaluvationGoal = 0;
        int hrEvaluvationGoal = 0;
        int DmEvaluvationGoal = 0;
        int GmEvaluvationGoal = 0;
        int SelfEvaluvationGoal = 0;
        int IssueEval=0;
        int CommentSts = 0;
        if (dt.Rows.Count > 0)
        {
            EmpUsrId=Convert.ToInt32( dt.Rows[0]["USR_ID"].ToString());
            HiddenUserId.Value = dt.Rows[0]["USR_ID"].ToString();
           
            if (dt.Rows[0]["EMPREPORTING"].ToString() != "")
            {
                RoEvaluvation = Convert.ToInt32(dt.Rows[0]["EMPREPORTING"].ToString());
            }
             hrEvaluvation = Convert.ToInt32(dt.Rows[0]["ISSUE_HR_EVLTOR"].ToString());
             DmEvaluvation = Convert.ToInt32(dt.Rows[0]["ISSUE_DM_EVLTOR"].ToString());
            GmEvaluvation = Convert.ToInt32(dt.Rows[0]["ISSUE_GM_EVLTOR"].ToString());
            SelfEvaluvation = Convert.ToInt32(dt.Rows[0]["ISSUE_SELF_EVLTOR"].ToString());
             ReptEvaluvation = Convert.ToInt32(dt.Rows[0]["ISSUE_RO_EVLTOR"].ToString());
            SelfEvaluvationGoal = Convert.ToInt32(dt.Rows[0]["ISSUE_SELF_EVLTOR_GOAL"].ToString());
            RoEvaluvationGoal = Convert.ToInt32(dt.Rows[0]["ISSUE_RO_EVLTOR_GOAL"].ToString());
            DmEvaluvationGoal = Convert.ToInt32(dt.Rows[0]["ISSUE_DM_EVLTOR_GOAL"].ToString());
            GmEvaluvationGoal = Convert.ToInt32(dt.Rows[0]["ISSUE_GM_EVLTOR_GOAL"].ToString());
            hrEvaluvationGoal = Convert.ToInt32(dt.Rows[0]["ISSUE_HR_EVLTOR_GOAL"].ToString());
            IssueEval = Convert.ToInt32(dt.Rows[0]["ISSUE_EVAL"].ToString());
            lblTmpltNName.Text = dt.Rows[0]["ISSUE_PRFM"].ToString();  //emp0025
            lblRef.Text = dt.Rows[0]["ISSUE_REFNO"].ToString() + "-" + dt.Rows[0]["ISSUE_REVNO"].ToString(); 
          //  lblRevNo.Text = dt.Rows[0]["ISSUE_REVNO"].ToString();
            lblDate.Text = dt.Rows[0]["ISSUE_DATE"].ToString();
            lblEmpId.Text = dt.Rows[0]["USR_CODE"].ToString();
            lblEmpName.Text = dt.Rows[0]["EMPLOYEE_NAME"].ToString();
            lblDesg.Text = dt.Rows[0]["DSGN_NAME"].ToString();
            lblDept.Text = dt.Rows[0]["CPRDEPT_NAME"].ToString();
            lblJob.Text = dt.Rows[0]["PROJECT_NAME"].ToString();
            lblJoinDate.Text = dt.Rows[0]["EMP_JOINED_DATE"].ToString();
            lblNote.Text = dt.Rows[0]["PRFMNC_TMPLT_NOTE"].ToString();

           
     
          
        }

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intConfirm = 0, intUsrRolMstrId = 0, HrApprove = 0, intEnableDMApprove = 0, intEnableGMApprove = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Evalvtn);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    HrApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //  HiddenDMApprove.Value = intEnableDMApprove.ToString();

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {


                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);



                }


            }

            DataTable dtUsrDtls = objEmpPerfomance.ReadUsrDesgDept(objEntity);
            if (IssueEval == 1)
            {
                objEntity.IssueType = 1;
                objEntity.UsrId = intUserId;
                DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                if (DdteVLTR.Rows.Count > 0)
                {
                    for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                    {
                        if (intUserId == Convert.ToInt32(DdteVLTR.Rows[count]["ISSUE_EVLTR_USR_ID"].ToString()))
                        {
                            HiddenRespnsTyp.Value = "ADDITIONAL EMPLOYEE";
                            if (DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString() == "1")
                            {
                                int glsts = Convert.ToInt32(DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString());
                                if (glsts == 1)
                                {
                                    divGoal.Visible = true;
                                    hiddenGoalsts.Value = "1";
                                }
                                else
                                {
                                    divGoal.Visible = false;
                                    hiddenGoalsts.Value = "0";
                                }
                            }
                            else
                            {
                                divGoal.Visible = false;
                                hiddenGoalsts.Value = "0";
                            }

                        }
                    }
                }

            }
            else if (IssueEval == 2)
            {
                if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() != "")
                {
                    objEntity.IssueType = 2;
                    objEntity.DeptId = Convert.ToInt32(dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString());
                    DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                    if (DdteVLTR.Rows.Count > 0)
                    {
                        for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                        {
                            if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DEPTID"].ToString())
                            {
                                HiddenRespnsTyp.Value = "DEPARTMENT";

                                if (DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString() == "1")
                                {
                                    int glsts = Convert.ToInt32(DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString());
                                    if (glsts == 1)
                                    {
                                        divGoal.Visible = true;
                                        hiddenGoalsts.Value = "1";
                                    }
                                    else
                                    {
                                        divGoal.Visible = false;
                                        hiddenGoalsts.Value = "0";
                                    }
                                }
                                else
                                {
                                    divGoal.Visible = false;
                                    hiddenGoalsts.Value = "0";
                                }

                            }
                        }
                    }
                }
            }
            else if (IssueEval == 3)
            {
                if (dtUsrDtls.Rows[0]["DSGN_ID"].ToString() != "")
                {
                    objEntity.IssueType = 3;
                    objEntity.DesgId = Convert.ToInt32(dtUsrDtls.Rows[0]["DSGN_ID"].ToString());
                    DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                    if (DdteVLTR.Rows.Count > 0)
                    {
                        for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                        {
                            if (dtUsrDtls.Rows[0]["DSGN_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DSGNID"].ToString())
                            {
                                HiddenRespnsTyp.Value = "DESIGNATION";
                                if (DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString() == "1")
                                {
                                    int glsts = Convert.ToInt32(DdteVLTR.Rows[count]["ISSUE_EVLTR_GOAL"].ToString());
                                    if (glsts == 1)
                                    {
                                        divGoal.Visible = true;
                                        hiddenGoalsts.Value = "1";
                                    }
                                    else
                                    {
                                        divGoal.Visible = false;
                                        hiddenGoalsts.Value = "0";
                                    }
                                }
                                else
                                {
                                    divGoal.Visible = false;
                                    hiddenGoalsts.Value = "0";
                                }

                            }
                        }
                    }
                }
            }




            if ((SelfEvaluvation == 1) )
            if (EmpUsrId == intUserId)
            {


                if (HiddenRespnsTyp.Value == "")
                {
                    HiddenRespnsTyp.Value = "SELF";
               
                }
                
            }
            if (RoEvaluvation != 0 && ReptEvaluvation==1)
            {
                if (RoEvaluvation == intUserId)
                {


                    if (HiddenRespnsTyp.Value == "")
                    {
                        HiddenRespnsTyp.Value = "REPORTING OFFICER";

                    }
                    else
                    {
                        HiddenRespnsTyp.Value = HiddenRespnsTyp.Value + "," + "REPORTING OFFICER";
                    }
                }
            }
            if (DmEvaluvation == 1 && intEnableDMApprove == 1)
            {

                if (HiddenRespnsTyp.Value == "")
                {
                    HiddenRespnsTyp.Value = "DIVISION MANAGER";
                }
                else
                {
                    HiddenRespnsTyp.Value = HiddenRespnsTyp.Value + "," + "DIVISION MANAGER";
                }
            }

            if (hrEvaluvation==1 && HrApprove == 1)
            {
                if (HiddenRespnsTyp.Value == "")
                {
                    HiddenRespnsTyp.Value = "HR";
                }
                else
                {
                    HiddenRespnsTyp.Value = HiddenRespnsTyp.Value + "," + "HR";
                   
                }
            }

            if (GmEvaluvation==1 && intEnableGMApprove == 1)
            {

                if (HiddenRespnsTyp.Value == "")
                {
                    HiddenRespnsTyp.Value = "GENERAL MANAGER";
                }
                else
                {
                    HiddenRespnsTyp.Value = HiddenRespnsTyp.Value + "," + "GENERAL MANAGER";
                }
            }
            string rsTyp_0 = "";
            string rsTyp_1 = "";
            string rsTyp_2 = "";
            string rsTyp_3 = "";
            string rsTyp_4 = "";
            string rsTyp_5 = "";
            string rsTyp_6 = "";
            string TYPE = HiddenRespnsTyp.Value;
            string[] vars = TYPE.Split(',');
            int length = vars.Length;
            if (length == 1)
            {
                rsTyp_0 = vars[0];
                HiddenRespnsTyp.Value = rsTyp_0;
            }
            else if (length == 2)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                HiddenRespnsTyp.Value = rsTyp_1;

            }
            else if (length == 3)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                rsTyp_2 = vars[2];
                HiddenRespnsTyp.Value = rsTyp_2;

            }

            else if (length == 4)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                rsTyp_2 = vars[2];
                rsTyp_3 = vars[3];

                HiddenRespnsTyp.Value = rsTyp_3;

            }
            else if (length == 5)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                rsTyp_2 = vars[2];
                rsTyp_3 = vars[3];
                rsTyp_4 = vars[4];
                HiddenRespnsTyp.Value = rsTyp_4;

            }
            else if (length == 5)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                rsTyp_2 = vars[2];
                rsTyp_3 = vars[3];
                rsTyp_4 = vars[4];
                rsTyp_5 = vars[5];
                HiddenRespnsTyp.Value = rsTyp_5;

            }
            else if (length == 5)
            {
                rsTyp_0 = vars[0];
                rsTyp_1 = vars[1];
                rsTyp_2 = vars[2];
                rsTyp_3 = vars[3];
                rsTyp_4 = vars[4];
                rsTyp_5 = vars[5];
                rsTyp_6 = vars[6];
                HiddenRespnsTyp.Value = rsTyp_6;

            } 

        }

        string typ = HiddenRespnsTyp.Value;
        lblTyp.Text = HiddenRespnsTyp.Value +"   " +"EVALUATION";
        
        if (typ == "SELF")
        {
              HiddenTypId.Value = "0";
          
            if (SelfEvaluvationGoal == 1)
            {
                divGoal.Visible = true;
                hiddenGoalsts.Value = "1";
            }
            else
            {
                divGoal.Visible = false;
                hiddenGoalsts.Value = "0";
            }
        }
        else if (typ == "REPORTING OFFICER")
        {
            HiddenTypId.Value = "1";
           
            if (RoEvaluvationGoal == 1)
            {
                divGoal.Visible = true;
                hiddenGoalsts.Value = "1";
            }
            else
            {
                divGoal.Visible = false;
                hiddenGoalsts.Value = "0";
            }
        }
        else if (typ == "DIVISION MANAGER")
        {
            HiddenTypId.Value = "2";
            if (DmEvaluvationGoal == 1)
            {
                hiddenGoalsts.Value = "1";
                divGoal.Visible = true;
            }
            else
            {
                hiddenGoalsts.Value = "0";
                divGoal.Visible = false;
            }

        }
        else if (typ == "HR")
        {
            HiddenTypId.Value = "4";
            if (hrEvaluvationGoal == 1)
            {
                divGoal.Visible = true;
                hiddenGoalsts.Value = "1";
            }
            else
            {
                divGoal.Visible = false;
                hiddenGoalsts.Value = "0";
            }

        }
        else if (typ == "GENERAL MANAGER")
        {
            HiddenTypId.Value = "3";
            if (GmEvaluvationGoal == 1)
            {
                divGoal.Visible = true;
                hiddenGoalsts.Value = "1";
            }
            else
            {
                divGoal.Visible = false;
                hiddenGoalsts.Value = "0";
            }

        }
       
        else
        {
            HiddenTypId.Value = "5";

        }

      

        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);
        hiddenGrpCount.Value= dtGrpQstn.Rows.Count.ToString();
        objEntity.PerfomanceId = Convert.ToInt32(dtGrpQstn.Rows[0]["PRFMNC_TMPLT_ID"].ToString());
        objEntity.EmpUsrId = EmpUsrId;
      //  objEntity.RspnTypeId = Convert.ToInt32(HiddenTypId.Value);
        DataTable dtReadAns = objEmpPerfomance.ReadEvltnAns(objEntity);
        if (dtReadAns.Rows.Count > 0)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            if (dtReadAns.Rows[0]["PRMNC_EVLTR_GOL"].ToString() != "")
            {
                txtGoal.Text = dtReadAns.Rows[0]["PRMNC_EVLTR_GOL"].ToString();
            }
            if (dtReadAns.Rows[0]["PRMNC_CNFRM_STS"].ToString() == "1")
            {
               
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                HiddenView.Value = "1";
                txtGoal.Enabled = false;
            }
            else
               
            {
                btnConfirm.Visible = true;
                btnUpdate.Visible = true;
                HiddenView.Value = "0";
                txtGoal.Enabled = true;

            }
        }
        else
        {
            btnConfirm.Visible = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            HiddenView.Value = "0";
        }
       
        string strHtm = ConvertDataTableToHTML(dtGrpQstn, dtReadAns);
        //Write to divReport
        group1.InnerHtml = strHtm;

     ScriptManager.RegisterStartupScript(this, GetType(), "FocusEvaluation", "FocusEvaluation();", true);

    }

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtAns)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int count = dt.Rows.Count;
        int GrpSts = 0;

        StringBuilder sb = new StringBuilder();

        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();





        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            if (dtAns.Rows.Count > 0)
            {
                objEntity.QstnSts = 1;

            }
            else
            {
                objEntity.QstnSts = 0;
            }

            objEntity.GrpId = Convert.ToInt32(dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());

            hiddenGrpId.Value = dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString();
            string QstnId = "";
            for (int qstnCount = 0; qstnCount < dtAns.Rows.Count; qstnCount++)
            {
                if (QstnId == "")
                {
                    QstnId = dtAns.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }
                else
                {
                    QstnId = QstnId + "," + dtAns.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }
                //if (dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() == dtAns.Rows[qstnCount]["PRFMNC_GRP_ID"].ToString())
                //{
                //    GrpSts = 0;
                //    break;
                //}
                //else
                //{
                //    GrpSts = 1;
                //}


            }

            objEntity.QustnId = QstnId;
            objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
            DataTable dtReadQstn = objEmpPerfomance.ReadQstnById(objEntity);
            HiddenQstnCount.Value = dtReadQstn.Rows.Count.ToString();


            string strHtml;

            strHtml = "<table id=\"ReportTable_" + intRowBodyCount + "\" >";
            if (dtReadQstn.Rows.Count > 0)
            {
                strHtml += "</br>";
                // strHtml += "<tr id=\""+dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString()+"\">";
                strHtml += "<div id=\"Tableborder\" style=\"padding:1px;\">";
                strHtml += " <div id=\"TableGrp\" class=\"col-lg-12\" style=\"padding:1px;\"><div class=\"btn btn-hide\" onclick=\"myFunction()\" data-toggle=\"modal\" data-target=\".bs-example-modal-sm\" style=\"float:right;\"></div><i class=\"fa fa-object-group\" aria-hidden=\"true\" style=\"font-size: 15px;\">" + "  " + "Group :" + "  " + dt.Rows[intRowBodyCount]["PRFMNC_GRP_NAME"].ToString() + "</i></div>";
                strHtml += "<div style=\"clear:both\"></div>";
                //grp name

                for (int intCount = 0; intCount < dtReadQstn.Rows.Count; intCount++)
                {
                    string text = "";
                    string rate = "";
                    string CHK = "";
                    int UpdTmplt = 1;
                    int newTempl = 0;
                    for (int intRowDtl = 0; intRowDtl < dtAns.Rows.Count; intRowDtl++)
                    {

                        if (dtAns.Rows[intRowDtl]["PRFMNC_QSTN_ID"].ToString() == dtReadQstn.Rows[intCount]["PRFMNC_QSTN_ID"].ToString())
                        {
                            int ansTyp = Convert.ToInt32(dtAns.Rows[intRowDtl]["PRMNC_ANS_TYPE"]);
                            if (ansTyp == 0)
                            {
                                text = dtAns.Rows[intRowDtl]["PRMNC_EVL_TEXT"].ToString();
                            }
                            if (ansTyp == 1)
                            {
                                rate = dtAns.Rows[intRowDtl]["PRMNC_EVL_RATE"].ToString();


                            }
                            if (ansTyp == 2)
                            {
                                CHK = dtAns.Rows[intRowDtl]["PRMNC_EVL_CHK"].ToString();


                            }
                            newTempl = 0;
                            break;
                        }

                        else
                        {
                            newTempl = 1;
                        }
                    }


                    int flag = 0;

                    int ResponseType = Convert.ToInt32(dtReadQstn.Rows[intCount]["PRFMNC_ANSWR_TYPE"].ToString());
                    if (ResponseType == 0)
                    {
                        flag = 2;
                    }
                    else if (ResponseType == 1)
                    {
                        flag = 1;
                    }
                    else if (ResponseType == 2)
                    {
                        flag = 3;
                    }


                    strHtml += "<hr >";
                    if (dtAns.Rows.Count > 0)
                    {
                        int evltnId = Convert.ToInt32(dtAns.Rows[0]["PRMNC_EVLTN_ID"].ToString());

                        HiddenEvltnId.Value = dtAns.Rows[0]["PRMNC_EVLTN_ID"].ToString();
                        strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + evltnId + "\" name=\"txtEvltnId \"  id=\"txtEvltnId\">";


                    }
                    if (HiddenView.Value == "0")
                    {
                        int focus = 0;
                        if (intRowBodyCount == 0)
                        {
                            focus = 1;
                        }
                        else
                        {
                            focus = 0;
                        }


                        if (flag == 1 && newTempl == 0)
                        {
                            int RateRange = Convert.ToInt32(dt.Rows[intRowBodyCount]["PRFMNC_TMPLT_RATING"].ToString());
                           
                            if (RateRange == 1)
                            {
                                if (rate == "")
                                {
                                  


                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }

                            if (RateRange == 2)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\" value=\"1\">1</option><option  value=\"2\">2</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }

                            if (RateRange == 3)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"2\">2</option><option  value=\"3\">3</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 4)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"   onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 5)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option> </select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 6)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\" value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option><option  value=\"6\">6</option> </select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "6")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option selected=\"selected\" value=\"6\">6</option> </select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 7)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option><option  value=\"6\">6</option> <option  value=\"7\">7</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "6")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option selected=\"selected\" value=\"6\">6</option><option  value=\"7\">7</option> </select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "7")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option selected=\"selected\" value=\"7\">7</option> </select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 8)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\" value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                                
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option><option  value=\"6\">6</option> <option  value=\"7\">7</option><option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "6")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option selected=\"selected\" value=\"6\">6</option><option  value=\"7\">7</option> <option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "7")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option selected=\"selected\" value=\"7\">7</option> <option  value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "8")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option  selected=\"selected\" value=\"8\">8</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 9)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\" value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option><option  value=\"6\">6</option> <option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "6")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option selected=\"selected\" value=\"6\">6</option><option  value=\"7\">7</option> <option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "7")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option selected=\"selected\" value=\"7\">7</option> <option  value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "8")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option  selected=\"selected\" value=\"8\">8</option><option  value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "9")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option   value=\"8\">8</option><option selected=\"selected\" value=\"9\">9</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                            if (RateRange == 10)
                            {
                                if (rate == "")
                                {



                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";

                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option selected=\"selected\" value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                    strHtml += "</br>";
                                }
                               
                                if (rate == "1")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option selected=\"selected\"  value=\"1\">1</option><option  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "2")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option selected=\"selected\"  value=\"2\">2</option><option  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "3")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option selected=\"selected\"  value=\"3\">3</option><option  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "4")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option selected=\"selected\"  value=\"4\">4</option><option  value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "5")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option  selected=\"selected\"   value=\"5\">5</option><option  value=\"6\">6</option> <option  value=\"7\">7</option><option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "6")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"> <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option selected=\"selected\" value=\"6\">6</option><option  value=\"7\">7</option> <option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "7")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\"  onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\"><option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option selected=\"selected\" value=\"7\">7</option> <option  value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "8")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select  style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option  selected=\"selected\" value=\"8\">8</option><option  value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "9")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option   value=\"8\">8</option><option selected=\"selected\" value=\"9\">9</option><option  value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                                if (rate == "10")
                                {
                                    strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                    strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                                    strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                                    strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\">  <option value=\"1\">1</option><option   value=\"2\">2</option><option   value=\"3\">3</option><option value=\"4\">4</option><option     value=\"5\">5</option><option  value=\"6\">6</option><option  value=\"7\">7</option> <option   value=\"8\">8</option><option  value=\"9\">9</option><option selected=\"selected\" value=\"10\">10</option></select>";
                                    //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                                    strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + Convert.ToInt32(rate) + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                                    strHtml += " </div> </div> </div></div>";
                                    strHtml += "</tr>";
                                }
                            }
                        }
                        if (flag == 2 && newTempl == 0)
                        {
                            strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                            strHtml += "<div class=\"col-md-12\" style=\"height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;\">";
                            strHtml += "<div id=\"TableQstn_\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "','" + HiddenQstnCount.Value + "','" + flag + "\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <textarea  onkeypress=\"return isTagEnter(event);\"  maxlength=\"245\"  class=\"form-control\" class=\"form-control\"   onblur =\"return BlurTextvalue(" + "'" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "'" + ");\" class=\"form-control\" name=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" id=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" text=\"" + text + "\" value=\"" + text + "\" rows=\"3\" style=\"resize:none\" placeholder=\" Type Answer...\">" + text + "</textarea> </div></div>";
                            strHtml += "</div>";

                            strHtml += "</tr>";
                            strHtml += "</br>";
                        }

                        if (flag == 3 && newTempl == 0)
                        {
                            if (CHK == "")
                            {
                                strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";

                                strHtml += "<div class=\"col-md-12\" id=\"TableQstn_\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input   style=\" outline: 1px solid #F4F6FB;\"  type=\"checkbox\" onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\" checked=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input   style=\" outline: 1px solid #F4F6FB; \" type=\"checkbox\" onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"   id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"1\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                                strHtml += "</tr>";
                            }
                            else if (CHK == "0")
                            {
                                strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                strHtml += "<div class=\"col-md-12\" id=\"TableQstn_\" value=\"\"  onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input   style=\" outline: 1px solid #F4F6FB;\"   type=\"checkbox\"   onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"   id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" class=\"product-list\"><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input  style=\" outline: 1px solid #F4F6FB;\"  type=\"checkbox\" onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\"  name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" checked=\"true\"  class=\"product-list\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                                strHtml += "</tr>";
                                strHtml += "</n>";
                            }
                            else if (CHK == "1")
                            {
                                strHtml += "<tr id=\"tdQs\"  style=\"width: 1%;\" value=\"" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "," + HiddenQstnCount.Value + "," + flag + "," + intCount + "\">";
                                strHtml += "<div class=\"col-md-12\" id=\"TableQstn_\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input  style=\" outline: 1px solid #F4F6FB;\"  type=\"checkbox\" onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\" checked=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input   style=\" outline: 1px solid #F4F6FB;\"  type=\"checkbox\" onblur=\"IncrmntConfrmCounter()\"   onkeypress=\"return  DisableEnter(event);\"  name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"   id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"1\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                                strHtml += "</tr>";
                            }

                        }




                    }
                    else
                    {


                        if (flag == 1 && rate != "")
                        {


                            strHtml += "<div class=\"col-md-12\" id=\"boxhide\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\">";
                            strHtml += "<div id=\"TableQstn_\" class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " <div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <label id=\"Qstn_\" style=\"margin-bottom:8px;\"></label>";
                            strHtml += "<select style=\"width: 9%;\" onchange=\"return ChangeddlRate('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\"  id=\"ddlRate_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  style=\" width:50%;\" onkeydown=\"return isEnter(event);\" disabled=\"true\"><option selected=\"selected\" value=\"" + rate + "\">" + rate + "</option></select>";
                            //     strHtml += " <input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"0\" id=\"txtddlValue_"+ intRowBodyCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() +" \">";
                            strHtml += " <input type=\"text\" style=\"display:none;\" value=\"" + rate + "\" name=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtddlValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";
                            strHtml += " </div> </div> </div></div>";


                            //<div style="clear:both"></div>
                        }
                        if (flag == 2 && text != "")
                        {

                            strHtml += "<div class=\"col-md-12\" style=\"height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;\">";
                            strHtml += "<div id=\"TableQstn_\"   class=\"col-lg-12\" style=\"padding:0px;\"> <i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>" + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"> <div class=\"form-group col-md-8 padding5\"> <textarea class=\"form-control\" name=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" id=\"txtComment_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" text=\"" + text + "\" value=\"" + text + "\" rows=\"3\" style=\"resize:none\" disabled=\"true\">" + text + "</textarea> </div></div>";
                            strHtml += "</div>";


                        }

                        if (flag == 3 && CHK != "")
                        {
                            if (CHK == "")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px; width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\" ><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                            else if (CHK == "1")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" checked=\"true\" disabled=\"true\" checked=\"true\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input type=\"checkbox\" disabled=\"true\" id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"1\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                            else if (CHK == "0")
                            {
                                strHtml += "<div class=\"col-md-12\" id=\"Div2\" onchange=\"return ChangeChkSts('" + intCount + "','" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "');\" style=\"height:auto;background-color:#eaeaea;padding:10px;overflow: auto;\"><div class=\"col-lg-12\" style=\"padding:0px;\"><i class=\"fa fa-tasks\" aria-hidden=\"true\" style=\"width: 71px; height: 31px; font-size: 15px;\">Question</i>   " + "  : " + dtReadQstn.Rows[intCount]["PRFMNC_QSTN"].ToString() + " </div><div class=\"form-row\"><div class=\"form-group col-md-8 padding5\"><label for=\"inputCity\" style=\"margin-bottom:8px;\"></label><div style=\"clear:both\"></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;width: 14%;\"><div class=\"form-group form-inline row\"><label class=\"ch\">Yes<input type=\"checkbox\" disabled=\"true\" name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"    id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span></label></div></div><div class=\"col-sm-3 col-md-3\" style=\"margin-top:3px;\"><div class=\"form-group form-inline row\"><label class=\"ch\">No<input type=\"checkbox\" checked=\"true\"  disabled=\"true\"  name=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"checkYes_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"CheckNo_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"><span class=\"checkmark\"></span> </label></div></div>";
                                strHtml += " <input type=\"text\" style=\"display:none;\" value=\"0\" name=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\"  id=\"txtchkValue_" + intCount + ":" + dt.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString() + "\">";

                                strHtml += "  </div></div></div>";
                            }
                        }


                    }
                    strHtml += "<div style=\"clear:both\"></div><hr />";

                }


                strHtml += "</div>";
            }
            strHtml += "</table>";

            sb.Append(strHtml);
        }


        return sb.ToString();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        List<clsEntity_Emp_perfomance_Evaluation> ObjEntityGrpList = new List<clsEntity_Emp_perfomance_Evaluation>();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int flag = 0;
        List<clsEntity_Emp_perfomance_Evaluation> objGrp = new List<clsEntity_Emp_perfomance_Evaluation>();
        List<clsEntity_Emp_perfomance_Evaluation> objTotalList = new List<clsEntity_Emp_perfomance_Evaluation>();
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);
        for (int intRowBodyCount = 0; intRowBodyCount < dtGrpQstn.Rows.Count; intRowBodyCount++)
        {

            clsEntity_Emp_perfomance_Evaluation objTextEvltn = new clsEntity_Emp_perfomance_Evaluation();
            objEntity.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
            DataTable dtReadQstn = objEmpPerfomance.ReadQstnById(objEntity);
            objTextEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
            objGrp.Add(objTextEvltn);
            objEntity.PerfomanceId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_TMPLT_ID"].ToString());
            objEntity.IssueId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["ISSUE_ID"].ToString());
            objEntity.EmpUsrId = Convert.ToInt32(HiddenUserId.Value);
            int COUNT = dtReadQstn.Rows.Count;

            for (int i = 0; i < COUNT; i++)
            {
                clsEntity_Emp_perfomance_Evaluation objEvltn = new clsEntity_Emp_perfomance_Evaluation();
                int type = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());

                if (type == 0)
                {
                    objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());
                    objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                    objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());
                    if (Request.Form["txtComment_" + i + ":" + objEntity.GrpId] != "")
                    {
                        objEvltn.RateText = Request.Form["txtComment_" + i + ":" + objEntity.GrpId];
                    }
                    else
                    {
                        flag = 1;
                    }

                    objTotalList.Add(objEvltn);

                }
                if (type == 1)
                {
                    objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());

                    objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());
                    objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                    if (Request.Form["txtddlValue_" + i + ":" + objEntity.GrpId] != "")
                    {
                        objEvltn.RateList = Convert.ToInt32(Request.Form["txtddlValue_" + i + ":" + objEntity.GrpId]);
                    }
                    else
                    {
                        flag = 1;
                    }
                    //  objEntity.RateText = Request.Form["txtComment_" + i];

                    objTotalList.Add(objEvltn);

                }
                if (type == 2)
                {
                    objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());

                    objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());
                    objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());

                    objEvltn.Ratechk = Convert.ToInt32(Request.Form["txtchkValue_" + i + ":" + objEntity.GrpId]);
                    //  objEntity.RateText = Request.Form["txtComment_" + i];

                    objTotalList.Add(objEvltn);

                }
            }

        }

        objEntity.EmpTyp = Convert.ToInt32(HiddenTypId.Value);

        objEntity.EvlComment = txtGoal.Text;

        if (flag == 1)
        {

            //  ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);

        }
        else
        {

            objEmpPerfomance.insert_Evaluatn_Dtls(objEntity, objGrp, objTotalList);




            if (clickedButton.ID == "btnSave")
            {

                Response.Redirect("Employee_Perfomance_Evaluation_List.aspx?InsUpd=Ins");
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        List<clsEntity_Emp_perfomance_Evaluation> ObjEntityGrpList = new List<clsEntity_Emp_perfomance_Evaluation>();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        List<clsEntity_Emp_perfomance_Evaluation> objGrp = new List<clsEntity_Emp_perfomance_Evaluation>();
        List<clsEntity_Emp_perfomance_Evaluation> objTotalList = new List<clsEntity_Emp_perfomance_Evaluation>();

        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        DataTable dtGrpQstn = objEmpPerfomance.ReadGrpQstnById(objEntity);

        for (int intRowBodyCount = 0; intRowBodyCount < dtGrpQstn.Rows.Count; intRowBodyCount++)
        {

            clsEntity_Emp_perfomance_Evaluation objTextEvltn = new clsEntity_Emp_perfomance_Evaluation();
            objEntity.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());

            objEntity.PerfomanceId = Convert.ToInt32(dtGrpQstn.Rows[0]["PRFMNC_TMPLT_ID"].ToString());
            objEntity.EmpUsrId = Convert.ToInt32(HiddenUserId.Value);
            objEntity.RspnTypeId = Convert.ToInt32(HiddenTypId.Value);
            DataTable dtReadAns = objEmpPerfomance.ReadEvltnAns(objEntity);
            if (dtReadAns.Rows.Count > 0)
            {
                objEntity.QstnSts = 1;
            }
            else
            {
                objEntity.QstnSts = 0;

            }
            string QstnId = "";
            for (int qstnCount = 0; qstnCount < dtReadAns.Rows.Count; qstnCount++)
            {
                if (QstnId == "")
                {
                    QstnId = dtReadAns.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }
                else
                {
                    QstnId = QstnId + "," + dtReadAns.Rows[qstnCount]["PRFMNC_QSTN_ID"].ToString();
                }

            }
            objEntity.QustnId = QstnId;
            DataTable dtReadQstn = objEmpPerfomance.ReadQstnById(objEntity);
            objEntity.EvltnId = Convert.ToInt32(dtReadAns.Rows[0]["PRMNC_EVLTN_ID"].ToString());

            objEntity.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
            DataTable dtEvltnGrpAns = objEmpPerfomance.ReadEvltnGrpAns(objEntity);
            objTextEvltn.EvltnGrpId = Convert.ToInt32(dtEvltnGrpAns.Rows[intRowBodyCount]["EVLTN_GRP_ID"].ToString());
            for (int j = 0; j < dtEvltnGrpAns.Rows.Count; j++)
            {
                objEntity.EvltnGrpId = Convert.ToInt32(dtEvltnGrpAns.Rows[j]["EVLTN_GRP_ID"].ToString());
                objTextEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                DataTable dtReadAnsById = objEmpPerfomance.ReadEvltnAnsById(objEntity);
                objGrp.Add(objTextEvltn);
                objEntity.PerfomanceId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_TMPLT_ID"].ToString());
                hidddenTemplateId.Value = dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_TMPLT_ID"].ToString();
                objEntity.IssueId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["ISSUE_ID"].ToString());

                int COUNT = dtReadQstn.Rows.Count;
                for (int i = 0; i < dtReadAnsById.Rows.Count; i++)
                {
                    clsEntity_Emp_perfomance_Evaluation objEvltn = new clsEntity_Emp_perfomance_Evaluation();
                    int type = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());







                    // objEvltn.EvltnGrpId = Convert.ToInt32(dtReadAns.Rows[j]["EVLTN_GRP_ID"].ToString());


                    objEvltn.EvltnQstnId = Convert.ToInt32(dtReadAnsById.Rows[i]["EVLTN_QSTN_ID"].ToString());






                    if (type == 0)
                    {
                        objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());
                        objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                        objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());

                        objEvltn.RateText = Request.Form["txtComment_" + i + ":" + objEntity.GrpId];


                        objTotalList.Add(objEvltn);

                    }
                    else if (type == 1)
                    {
                        objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());

                        objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());
                        objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                        objEvltn.RateList = Convert.ToInt32(Request.Form["txtddlValue_" + i + ":" + objEntity.GrpId]);
                        //  objEntity.RateText = Request.Form["txtComment_" + i];

                        objTotalList.Add(objEvltn);

                    }
                    else if (type == 2)
                    {
                        objEvltn.RspnTypeId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_ANSWR_TYPE"].ToString());

                        objEvltn.QstnId = Convert.ToInt32(dtReadQstn.Rows[i]["PRFMNC_QSTN_ID"].ToString());
                        objEvltn.GrpId = Convert.ToInt32(dtGrpQstn.Rows[intRowBodyCount]["PRFMNC_GRP_ID"].ToString());
                        objEvltn.Ratechk = Convert.ToInt32(Request.Form["txtchkValue_" + i + ":" + objEntity.GrpId]);
                        //  objEntity.RateText = Request.Form["txtComment_" + i];

                        objTotalList.Add(objEvltn);

                    }

                }
            }
        }

        objEntity.EmpTyp = Convert.ToInt32(HiddenTypId.Value);

        objEntity.EvlComment = txtGoal.Text;
        objEmpPerfomance.Update_Evaluatn_Dtls(objEntity, objGrp, objTotalList);
        if (clickedButton.ID == "btnUpdate")
        {

            Response.Redirect("Employee_Perfomance_Evaluation_List.aspx?InsUpd=Upd");
        }

        if (clickedButton.ID == "btnConfirm" || clickedButton.ID == "bbtnConfirm")
        {

            objEntity.PerfomanceId = Convert.ToInt32(hidddenTemplateId.Value);
            objEntity.EmpUsrId = Convert.ToInt32(HiddenUserId.Value);
            objEntity.RspnTypeId = Convert.ToInt32(HiddenTypId.Value);
            DataTable dtReadAns = objEmpPerfomance.ReadEvltnAns(objEntity);
            string sts = dtReadAns.Rows[0]["PRMNC_CNFRM_STS"].ToString();
            if (sts == "")
            {


                objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
                objEntity.EvltnId = Convert.ToInt32(HiddenEvltnId.Value);

                objEmpPerfomance.Cnfrm_Evaluatn_Dtls(objEntity);

                Response.Redirect("Employee_Perfomance_Evaluation_List.aspx?InsUpd=CNFM");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmError", "ConfirmError();", true);


                Response.Redirect("Employee_Perfomance_Evaluation_List.aspx?InsUpd=CNFMERROR");
            }
        }

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.IssueId = Convert.ToInt32(HiddenIssueId.Value);
        objEntity.EvltnId = Convert.ToInt32(HiddenEvltnId.Value);




        objEmpPerfomance.Cnfrm_Evaluatn_Dtls(objEntity);
        if (clickedButton.ID == "bbtnConfirm")
        {

            Response.Redirect("Employee_Perfomance_Evaluation_List.aspx?InsUpd=CNFM");
        }
    }
}