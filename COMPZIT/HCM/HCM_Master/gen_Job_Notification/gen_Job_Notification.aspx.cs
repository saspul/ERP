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
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Collections.Generic;
using EL_Compzit;

// CREATED BY:EVM-0005
// CREATED DATE:16/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_Job_Notification_gen_Job_Notification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        cbxDivisionList.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxDepartmntList.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        chkbxListConsultancy.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        

        if (!IsPostBack)
        {
            ConsultancyLoad();
            DepartMentLoad();
            DivisionLoad();
            EmployeeLoad();
            cbxInterOffice.Checked = false;
            //when editing 
            if (Request.QueryString["Id"] != null)
            {

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                FillInitialData(strId);

            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }

            }
        }
    }
    public void FillInitialData(string RqstId)
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        objEntityJobNotify.ManPwrRqstId = Convert.ToInt32(RqstId);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtReqstDetail = objBussinessJobNOtify.ReadManPwrReqstById(objEntityJobNotify);
        if (dtReqstDetail.Rows.Count > 0)
        {
            lblRefNum.Text = dtReqstDetail.Rows[0]["MNP_REFNUM"].ToString();
            lblNumber.Text = dtReqstDetail.Rows[0]["MNP_RESOURCENUM"].ToString();
            lblDesign.Text = dtReqstDetail.Rows[0]["DESIGNATION"].ToString(); ;
            lblDeprtmnt.Text = dtReqstDetail.Rows[0]["DEPARTMENT"].ToString();
            lblDateOfReq.Text = dtReqstDetail.Rows[0]["MNPRQST_DATE"].ToString();
            lblExprnce.Text = dtReqstDetail.Rows[0]["MNP_EXPERIENCE"].ToString() + "  Years";
            lblPaygrd.Text = dtReqstDetail.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
            lblPrjct.Text = dtReqstDetail.Rows[0]["PROJECT"].ToString();
            lblReqDate.Text = dtReqstDetail.Rows[0]["MNPRQRD_DATE"].ToString();
            lblPayRange.Text = dtReqstDetail.Rows[0]["PYGRD_RANGE_FRM"].ToString() + "--" + dtReqstDetail.Rows[0]["PYGRD_RANGE_TO"].ToString() + "  " + dtReqstDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
        }


        DataTable dtSendeddata = objBussinessJobNOtify.ReadJobNotifyById(objEntityJobNotify);
        if(dtSendeddata.Rows.Count>0)
        {
            objEntityJobNotify.JObNotifyId = Convert.ToInt32(dtSendeddata.Rows[0]["JBNTFY_ID"]);
            if (dtSendeddata.Rows[0]["MNPRQST_INTROFC_STS"].ToString() == "1")
            {
                cbxInterOffice.Checked = true;
            }

            DataTable dtSendedCnslt = objBussinessJobNOtify.ReadJobNotifyCnsltById(objEntityJobNotify);
            DataTable dtSendedDiv = objBussinessJobNOtify.ReadJobNotifyDivById(objEntityJobNotify);
            DataTable dtSendedDep = objBussinessJobNOtify.ReadJobNotifyDepById(objEntityJobNotify);
            DataTable dtSendedEmp = objBussinessJobNOtify.ReadJobNotifyEmpById(objEntityJobNotify);
            if (dtSendedCnslt.Rows.Count>0)
            {
                foreach (DataRow RowCn in dtSendedCnslt.Rows)
                {
                    string intCnslt = RowCn["CNSLT_ID"].ToString();
                    for (int i = 0; i < chkbxListConsultancy.Items.Count; i++)
                    {
                        if (chkbxListConsultancy.Items[i].Value == intCnslt)
                        {
                            chkbxListConsultancy.Items[i].Selected = true;
                            chkbxListConsultancy.Items[i].Text=chkbxListConsultancy.Items[i].Text +"[Already Send]";
                            chkbxListConsultancy.Items[i].Attributes.Add("style", "color:#ba0202;");
                        }
                    }
                }
            }
            if (dtSendedDiv.Rows.Count > 0)
            {
                foreach (DataRow RowCn in dtSendedDiv.Rows)
                {
                    string intCnslt = RowCn["CPRDIV_ID"].ToString();
                    for (int i = 0; i < cbxDivisionList.Items.Count; i++)
                    {
                        if (cbxDivisionList.Items[i].Value == intCnslt)
                        {
                            cbxDivisionList.Items[i].Selected = true;
                            cbxDivisionList.Items[i].Text = cbxDivisionList.Items[i].Text + "[Already Send]";
                            cbxDivisionList.Items[i].Attributes.Add("style", "color:#ba0202;");
                        }
                    }
                }
            }
            if (dtSendedDep.Rows.Count > 0)
            {
                foreach (DataRow RowCn in dtSendedDep.Rows)
                {
                    string intDep = RowCn["CPRDEPT_ID"].ToString();
                    for (int i = 0; i < cbxDepartmntList.Items.Count; i++)
                    {
                        if (cbxDepartmntList.Items[i].Value == intDep)
                        {
                            cbxDepartmntList.Items[i].Selected = true;
                            cbxDepartmntList.Items[i].Text = cbxDepartmntList.Items[i].Text + "[Already Send]";
                            cbxDepartmntList.Items[i].Attributes.Add("style", "color: #ba0202;");
                        }
                    }
                }
            }

            if (dtSendedEmp.Rows.Count > 0)
            {
                string StrEmpFull = "";
                foreach (DataRow RowCn in dtSendedEmp.Rows)
                {
                    StrEmpFull += "|" + RowCn["USR_ID"].ToString();
                    StrEmpFull += "," + RowCn["USR_NAME"].ToString()+"|";
                }

                HiddenEmpIdsEdit.Value = StrEmpFull;
            }
        }
    }
    public void EmployeeLoad()
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinessJobNOtify.ReadEmployee(objEntityJobNotify);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtSubConrt;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    public void ConsultancyLoad()
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinessJobNOtify.ReadConsultancies(objEntityJobNotify);
        if (dtSubConrt.Rows.Count > 0)
        {
            chkbxListConsultancy.DataSource = dtSubConrt;
            chkbxListConsultancy.DataTextField = "CNSLT_NAME";
            chkbxListConsultancy.DataValueField = "CNSLT_ID";
            chkbxListConsultancy.DataBind();

        }

    }
    public void DivisionLoad()
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivi = objBussinessJobNOtify.ReadDivision(objEntityJobNotify);
        if (dtDivi.Rows.Count > 0)
        {
            cbxDivisionList.DataSource = dtDivi;
            cbxDivisionList.DataTextField = "CPRDIV_NAME";
            cbxDivisionList.DataValueField = "CPRDIV_ID";
            cbxDivisionList.DataBind();

        }

    }
    public void DepartMentLoad()
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDep = objBussinessJobNOtify.ReadDepartment(objEntityJobNotify);
        if (dtDep.Rows.Count > 0)
        {
            cbxDepartmntList.DataSource = dtDep;
            cbxDepartmntList.DataTextField = "CPRDEPT_NAME";
            cbxDepartmntList.DataValueField = "CPRDEPT_ID";
            cbxDepartmntList.DataBind();

        }

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();


        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobNotify.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobNotify.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobNotify.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strId = "";
        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        if (cbxInterOffice.Checked == true)
        {
            objEntityJobNotify.IfInterOfc = 1;
        }
        else
        {
            objEntityJobNotify.IfInterOfc = 1;
        }

        objEntityJobNotify.ManPwrRqstId = Convert.ToInt32(strId);

        List<clsEntityConsultDetail> objEntityCnsltDetailList = new List<clsEntityConsultDetail>();
        List<clsEntityConsultDetail> objEntityCnsltDetailListAdd = new List<clsEntityConsultDetail>();

        for (int i = 0; i < chkbxListConsultancy.Items.Count; i++)
        {
            clsEntityConsultDetail objEntityCnsltDetail = new clsEntityConsultDetail();
            clsEntityConsultDetail objEntityCnsltDetailAdd = new clsEntityConsultDetail();
            if (chkbxListConsultancy.Items[i].Selected)
            {
                objEntityJobNotify.ConsltId = Convert.ToInt32(chkbxListConsultancy.Items[i].Value);
                objEntityCnsltDetail.ConsultId = Convert.ToInt32(chkbxListConsultancy.Items[i].Value);
                objEntityCnsltDetailAdd.ConsultId = Convert.ToInt32(chkbxListConsultancy.Items[i].Value);
                objEntityCnsltDetailListAdd.Add(objEntityCnsltDetailAdd);
                DataTable dtConsult = objBussinessJobNOtify.ReadConsultancyById(objEntityJobNotify);
                if (dtConsult.Rows.Count > 0)
                {
                    objEntityCnsltDetail.ConsltToaddrs = dtConsult.Rows[0]["CNSLT_EMAIL"].ToString();
                    string ConsultContent = "";
                    ConsultContent = " Dear " + dtConsult.Rows[0]["CNSLT_NAME"].ToString() + ",";
                    ConsultContent += "<br/><br/>This email is to notify you about the new vacancy in the capacity of " + lblDesign.Text+".";
                    ConsultContent += "<br/>Listed below are the core competencies and requirements for this position: ";
                    ConsultContent += "<br/>Total No of Manpower Required: " + lblNumber.Text;
                    ConsultContent += "<br/>Relevant Years of Experience:  " + lblExprnce.Text;
                    ConsultContent += "<br/>Proposed Salary Range :  " + lblPayRange.Text;
                    ConsultContent += "<br/>Request you to please share relevant resume on or before "+lblReqDate.Text+" to the email sfademo@albalagh.com ";

                    ConsultContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                    ConsultContent += "<br/><br/><br/>Best Regards,";
                    ConsultContent += "<br/><font color=\"#0a409b\"><b>HR & Admin Department</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";

                    objEntityCnsltDetail.ConsltContent = ConsultContent;
                    objEntityCnsltDetailList.Add(objEntityCnsltDetail);
                }
            }


        }

        List<clsEntityDivisionDetail> ObjEntityDivisionList = new List<clsEntityDivisionDetail>();
        List<clsEntityDivisionDetail> ObjEntityDivisionListForAdd = new List<clsEntityDivisionDetail>();

        for (int i = 0; i < cbxDivisionList.Items.Count; i++)
        {
            clsEntityDivisionDetail ObjEntityDiv = new clsEntityDivisionDetail();
            clsEntityDivisionDetail ObjEntityDivAdd = new clsEntityDivisionDetail();
            if (cbxDivisionList.Items[i].Selected)
            {
                ObjEntityDivAdd.DivisionId = Convert.ToInt32(cbxDivisionList.Items[i].Value);
                ObjEntityDivisionListForAdd.Add(ObjEntityDivAdd);
                objEntityJobNotify.DivId = Convert.ToInt32(cbxDivisionList.Items[i].Value);
                DataTable dtDivUsers = objBussinessJobNOtify.ReadDivisionById(objEntityJobNotify);
                foreach (DataRow Row in dtDivUsers.Rows)
                {
                    ObjEntityDiv.DivToaddrs = Row["USR_EMAIL"].ToString();

                    string DivisionContent = "";
                    DivisionContent = " Dear " + Row["USR_NAME"].ToString() + ",";
                    DivisionContent += "<br/><br/>This email is to notify you about the new vacancy in the capacity of " + lblDesign.Text +".";
                    DivisionContent += "<br/>Listed below are the core competencies and requirements for this position: ";
                    DivisionContent += "<br/>Total No of Manpower Required: " + lblNumber.Text;
                    DivisionContent += "<br/>Relevant Years of Experience:  " + lblExprnce.Text;
                    DivisionContent += "<br/>Proposed Salary Range :  " + lblPayRange.Text;
                    DivisionContent += "<br/>Request you to please share relevant resume on or before " + lblReqDate.Text + " to the email sfademo@albalagh.com ";
                    DivisionContent += "<br/>Staff are welcome to recommend their friends and family members should they prove to be competent and eligible.";
                    DivisionContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                    DivisionContent += "<br/><br/><br/>Best Regards,";
                    DivisionContent += "<br/><font color=\"#0a409b\"><b>HR & Admin Department</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
                    ObjEntityDiv.DivContent = DivisionContent;

                    ObjEntityDivisionList.Add(ObjEntityDiv);
                }
            }
        }

        List<clsEntityDepartmentDetail> ObjEntityDeprtmntList = new List<clsEntityDepartmentDetail>();
        List<clsEntityDepartmentDetail> ObjEntityDeprtmntListAdd = new List<clsEntityDepartmentDetail>();
        for (int i = 0; i < cbxDepartmntList.Items.Count; i++)
        {
            clsEntityDepartmentDetail ObjEntityDeprtmnt = new clsEntityDepartmentDetail();
            clsEntityDepartmentDetail ObjEntityDeprtmntAdd = new clsEntityDepartmentDetail();
            if (cbxDepartmntList.Items[i].Selected)
            {
                ObjEntityDeprtmntAdd.DepartmentId = Convert.ToInt32(cbxDepartmntList.Items[i].Value);
                ObjEntityDeprtmntListAdd.Add(ObjEntityDeprtmntAdd);

                objEntityJobNotify.Deprt_Id = Convert.ToInt32(cbxDepartmntList.Items[i].Value);
                DataTable dtDepUsers = objBussinessJobNOtify.ReadDepartmntById(objEntityJobNotify);
                foreach (DataRow Row in dtDepUsers.Rows)
                {
                    ObjEntityDeprtmnt.DepToaddrs = Row["USR_EMAIL"].ToString();

                    string DprtmntContent = "";
                    DprtmntContent = " Dear " + Row["USR_NAME"].ToString() + ",";
                    DprtmntContent += "<br/><br/>This email is to notify you about the new vacancy in the capacity of " + lblDesign.Text+".";
                    DprtmntContent += "<br/>Listed below are the core competencies and requirements for this position: ";
                    DprtmntContent += "<br/>Total No of Manpower Required: " + lblNumber.Text;
                    DprtmntContent += "<br/>Relevant Years of Experience:  " + lblExprnce.Text;
                    DprtmntContent += "<br/>Proposed Salary Range :  " + lblPayRange.Text;
                    DprtmntContent += "<br/>Request you to please share relevant resume on or before " + lblReqDate.Text + " to the email sfademo@albalagh.com ";
                    DprtmntContent += "<br/>Staff are welcome to recommend their friends and family members should they prove to be competent and eligible.";
                    DprtmntContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                    DprtmntContent += "<br/><br/><br/>Best Regards,";
                    DprtmntContent += "<br/><font color=\"#0a409b\"><b>HR & Admin Department</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";

                    ObjEntityDeprtmnt.DepContent = DprtmntContent;
                    ObjEntityDeprtmntList.Add(ObjEntityDeprtmnt);
                }
            }
        }

        List<clsEntityEmployeeDetail> ObjEntityEmployeeList = new List<clsEntityEmployeeDetail>();

        string totatlEmp = HiddenEmpIds.Value;
        string[] EachEmpArr = totatlEmp.Split(',');

        foreach (string empid in EachEmpArr)
        {
            if (empid != "")
            {

                clsEntityEmployeeDetail ObjEntityEmployee = new clsEntityEmployeeDetail();

                ObjEntityEmployee.EmpId = Convert.ToInt32(empid);
                objEntityJobNotify.Empid = Convert.ToInt32(empid);
                DataTable dtUsers = objBussinessJobNOtify.ReadEmployeeById(objEntityJobNotify);


                ObjEntityEmployee.EmpToaddrs = dtUsers.Rows[0]["USR_EMAIL"].ToString();
                string EmployeeContent = "";
                EmployeeContent = " Dear " + dtUsers.Rows[0]["USR_NAME"].ToString() + ",";
                EmployeeContent += "<br/><br/>This email is to notify you about the new vacancy in the capacity of " + lblDesign.Text+".";
                EmployeeContent += "<br/>Listed below are the core competencies and requirements for this position: ";
                EmployeeContent += "<br/>Total No of Manpower Required: " + lblNumber.Text;
                EmployeeContent += "<br/>Relevant Years of Experience:  " + lblExprnce.Text;
                EmployeeContent += "<br/>Proposed Salary Range :  " + lblPayRange.Text;
                EmployeeContent += "<br/>Request you to please share relevant resume on or before " + lblReqDate.Text + " to the email sfademo@albalagh.com ";
                EmployeeContent += "<br/>Staff are welcome to recommend their friends and family members should they prove to be competent and eligible.";
                EmployeeContent += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                EmployeeContent += "<br/><br/><br/>Best Regards,";
                EmployeeContent += "<br/><font color=\"#0a409b\"><b>HR & Admin Department</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
                ObjEntityEmployee.EmpContent = EmployeeContent;

                ObjEntityEmployeeList.Add(ObjEntityEmployee);

            }
        }

        DataTable dtFromMail = objBussinessJobNOtify.ReadFromMailDetails(objEntityJobNotify);
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        objEntityMail.Email_Subject = "NEW JOB ANNOUNCEMENT";
        //objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();
        //objEntityMail.Email_Content = objEntityMail.Email_Content + objEntityMail.Signature;

        objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

        objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
        objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
        objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
        objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();

//EMP0026
        objEntityMail.D_Date = System.DateTime.Now;
        clsEntityMailAttachment objEntityAttach = new clsEntityMailAttachment();
        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
      
        foreach (clsEntityConsultDetail objEntityConsultEach in objEntityCnsltDetailList)
        {
            objEntityMail.To_Email_Address = objEntityConsultEach.ConsltToaddrs;
            objEntityMail.Email_Content = objEntityConsultEach.ConsltContent;
            //objEntityMailAttachList.Add(objEntityAttach);
            if (objEntityConsultEach.ConsltToaddrs!="")
            {
                objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);
            }
           
        }
        foreach (clsEntityDivisionDetail objEntityDivEach in ObjEntityDivisionList)
        {
            objEntityMail.To_Email_Address = objEntityDivEach.DivToaddrs;
            objEntityMail.Email_Content = objEntityDivEach.DivContent;
            if (objEntityDivEach.DivToaddrs!="")
            {
                objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);
            }
        }
        foreach (clsEntityDepartmentDetail objDepartEach in ObjEntityDeprtmntList)
        {
            objEntityMail.To_Email_Address = objDepartEach.DepToaddrs;
            objEntityMail.Email_Content = objDepartEach.DepContent;
            if(objDepartEach.DepToaddrs!="")
            {
                objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);
            }
          
        }

        foreach (clsEntityEmployeeDetail objEmployEach in ObjEntityEmployeeList)
        {
            objEntityMail.To_Email_Address = objEmployEach.EmpToaddrs;
            objEntityMail.Email_Content = objEmployEach.EmpContent;
            if (objEmployEach.EmpToaddrs != "")
            {
                objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);
            }
           
        }
        DataTable dtInsCount = objBussinessJobNOtify.CheckIsInserted(objEntityJobNotify);
        if (dtInsCount.Rows.Count > 0)
        {
            objEntityJobNotify.JObNotifyId =Convert.ToInt32( dtInsCount.Rows[0]["JBNTFY_ID"]);
            objBussinessJobNOtify.UpdateNotificationDetail(objEntityJobNotify, objEntityCnsltDetailList, ObjEntityDivisionListForAdd, ObjEntityDeprtmntListAdd, ObjEntityEmployeeList);
        }
        else
        {
            objBussinessJobNOtify.AddNotificationDetail(objEntityJobNotify, objEntityCnsltDetailListAdd, ObjEntityDivisionListForAdd, ObjEntityDeprtmntListAdd, ObjEntityEmployeeList);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
        Response.Redirect("gen_Job_Notification.aspx?InsUpd=Ins&&Id=" + Request.QueryString["Id"] +"");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Job_Notification_List.aspx");
    }
}