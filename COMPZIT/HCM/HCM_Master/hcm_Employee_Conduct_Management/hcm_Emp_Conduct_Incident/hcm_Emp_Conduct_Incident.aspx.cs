using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit.BusinessLayer_GMS;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;

// CREATED BY:EVM-0008
// CREATED DATE:16/30/2018
// REVIEWED BY:
// REVIEW DATE:


public partial class HCM_HCM_Master_hcm_Emp_Conduct_Incident_hcm_Emp_Conduct_Incident : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BtnNotTerminate.Visible = false;
            BtnNotClose.Visible = false;
            clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
            clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
            ddlEmployee.ClearSelection();
            Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            ddlEmployee.Items.Insert(0, "--SELECT NAME--");
            ddlEmpId.ClearSelection();
            ddlEmpId.Items.Insert(0, "--SELECT ID--");
            HiddenRoleUpd.Value = "0";
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UserId = intUserId;

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


            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate=0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Conduct_Incident);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenRoleUpd.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString())
                    {
                        IntAllDivision = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }


                }
            }
            if (IntAllDivision == 0)
            {
                DataTable dtEmp = objEmpConduct.LoadEmployee(objEntity);

                if (dtEmp.Rows.Count > 0)
                {
                    ddlEmployee.DataSource = dtEmp;
                    ddlEmployee.DataTextField = "USR_NAME";
                    ddlEmployee.DataValueField = "USR_ID";
                    ddlEmployee.DataBind();

                    ddlEmpId.DataSource = dtEmp;
                    ddlEmpId.DataTextField = "USR_CODE";
                    ddlEmpId.DataValueField = "USR_ID";
                    ddlEmpId.DataBind();

                }



                ddlEmpId.Items.Insert(0, "--SELECT ID--");

                ddlEmployee.Items.Insert(0, "--SELECT NAME--");
                ddlEmployee.Focus();

            }
            else
            { 
            ddlBusnssUnit.Focus();
            }
          
            //int AllDivision = 1;

            HiddenAllUserDivision.Value = IntAllDivision.ToString();
            if (IntAllDivision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               // AllDivision = 1;
                //ddlBusnssUnit.Attributes["style"] = "disabled: false";
                //ddldep.Attributes["style"] = "disabled: false";
                //ddlDivision.Attributes["style"] = "disabled: false";
                ddlBusnssUnit.Enabled = true;
                ddldep.Enabled = true;
                ddlDivision.Enabled = true;
            }
            else
            {
                ddlBusnssUnit.Enabled = false;
                ddldep.Enabled = false;
                ddlDivision.Enabled = false;
            }

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONDUCT_INCIDENT_REF);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumber(objEntityCommon);
            string year = DateTime.Today.Year.ToString();
            string Month = DateTime.Today.Month.ToString();
           RefH2.InnerHtml = "REF#" + year + "" + strNextId;

           objEntity.AllDivisionChk = IntAllDivision;

            LoadAllDivisionDropDowns(objEntity);
            bttnUpdate.Visible = false;
            bttnUpdateCls.Visible = false;
            bttnCofrm.Visible = false;

            DivPrint.Attributes["style"] = "display:none;";
            BtnTerminate.Visible = false;
            BtnClose.Visible = false;
            BtnNotTerminate.Visible = false;
            BtnNotClose.Visible = false;
            if (Request.QueryString["Id"] != null)
            {
                BtnClose.Visible = true;
              
                string status = "";
                if (Request.QueryString["STS"] != null)
                {
                    status = Request.QueryString["STS"].ToString();
                }
                

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenConductId.Value = strId;

                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                bttnUpdate.Visible = true;
                bttnUpdateCls.Visible = true;
                bttnCofrm.Visible = true;

                if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    bttnCofrm.Visible = true;
                }
                else
                {
                    bttnCofrm.Visible = false;
                }

                
                Update(strId, status);

            }

      
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               // bttnsave.Visible = true;
               // btnSaveCls.Visible = true;
            }
            else
            {
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                bttnUpdate.Visible = false;

            }
            if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               
            }
            else
            {
                bttnUpdate.Visible = false;
                bttnUpdateCls.Visible = false;
            }
            

        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "CancelMsg")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelMsg", "SuccessCancelMsg();", true);
            }
        }

    }
    public void Update(string strP_Id, string status)
    {
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntityUser = new clsEntity_Emp_conduct_Incident();
        objEntity.ConductIncident_Id = Convert.ToInt32(strP_Id);
        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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


        DataTable dt = objEmpConduct.ReadIncidentDetailsByid(objEntity);
        if (dt.Rows.Count > 0)
        {
            HiddenConductInsId.Value = dt.Rows[0]["CNDTINC_ID"].ToString();
            RefH2.InnerHtml = dt.Rows[0]["CNDTINC_REFNO"].ToString();
            objEntityUser.UserId = Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString());
            objEntityUser.CorpId = intCorpId;
            objEntityUser.OrgId = intOrgId;
            DataTable dtPdfDtls = objEmpConduct.PdfEmployeeDetails(objEntityUser);
            divPrintReport.InnerHtml = ConvertDataTableForPrint(dtPdfDtls);
       
           
          
            if (HiddenAllUserDivision.Value == "1")
            {

                if (dt.Rows[0]["CPRDIV_ID"].ToString() != "")
                {
                    if (ddlDivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()) != null)
                    {
                        ddlDivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CPRDIV_NAME"].ToString(), dt.Rows[0]["CPRDIV_ID"].ToString());
                        ddlDivision.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlDivision);

                        ddlDivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;

                    }
                }
                //else
                //{ 
                
                //}
                if (dt.Rows[0]["CNDTINC_CORPRT_ID"].ToString() != "")
                {
                    if (ddlBusnssUnit.Items.FindByValue(dt.Rows[0]["CNDTINC_CORPRT_ID"].ToString()) != null)
                    {
                        ddlBusnssUnit.Items.FindByValue(dt.Rows[0]["CNDTINC_CORPRT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CORPRT_NAME"].ToString(), dt.Rows[0]["CNDTINC_CORPRT_ID"].ToString());
                        ddlBusnssUnit.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlBusnssUnit);

                        ddlBusnssUnit.Items.FindByValue(dt.Rows[0]["CNDTINC_CORPRT_ID"].ToString()).Selected = true;

                    }
                }
                if (dt.Rows[0]["CPRDEPT_ID"].ToString() != "")
                {
                    if (ddldep.Items.FindByValue(dt.Rows[0]["CPRDEPT_ID"].ToString()) != null)
                    {
                        ddldep.Items.FindByValue(dt.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CPRDEPT_NAME"].ToString(), dt.Rows[0]["CPRDEPT_ID"].ToString());
                        ddldep.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddldep);

                        ddldep.Items.FindByValue(dt.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;

                    }
                }
            }

            EmployeeLoad();
            HiddenUserId.Value = dt.Rows[0]["USR_ID"].ToString();
            HiddenUserIdValidate.Value = dt.Rows[0]["USR_ID"].ToString();
            if (ddlEmployee.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()) != null)
            {
                ddlEmployee.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {
                System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["USR_NAME"].ToString(), dt.Rows[0]["USR_ID"].ToString());
                ddlEmployee.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlEmployee);

                ddlEmployee.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()).Selected = true;

            }

            if (ddlEmpId.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()) != null)
            {
                ddlEmpId.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {
                System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["USR_CODE"].ToString(), dt.Rows[0]["USR_ID"].ToString());
                ddlEmpId.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlEmpId);

                ddlEmpId.Items.FindByValue(dt.Rows[0]["USR_ID"].ToString()).Selected = true;

            }

            txtCondtdescrp.Text = dt.Rows[0]["CNDTINC_DESCRPTN"].ToString();
            Hiddentxtefctvedate.Value = dt.Rows[0]["CNDTINC_DATE"].ToString();
            ddlPriorty.Items.FindByValue(dt.Rows[0]["CNDTINC_SEVERITY"].ToString()).Selected = true;

            if (dt.Rows[0]["CNDTINC_TYPE"].ToString() == "0")
            {
                typNegtve.Checked = true;
            }
            else if (dt.Rows[0]["CNDTINC_TYPE"].ToString() == "1")
            {
              
                typGood.Checked = true;
            }
            //evm-0024
            if (dt.Rows[0]["CNDTINC_EMP_NOTIFY"].ToString() == "1")
            {
                ChkBxEmployee.Checked = true;
            }
            //end
            if (dt.Rows[0]["CNDTINC_NOTIFY"].ToString() == "1")
            {
                ChkBxReprtOff.Checked = true;
            }
            else if (dt.Rows[0]["CNDTINC_NOTIFY"].ToString() == "2")
            {
                ChkBxDivMngr.Checked = true;
            }
            else if (dt.Rows[0]["CNDTINC_NOTIFY"].ToString() == "3")
            {
                ChkBxReprtOff.Checked = true;
                ChkBxDivMngr.Checked = true;
            }


            if (dt.Rows[0]["CNDTINC_RECIVE"].ToString() == "1")
            {
                if (dt.Rows[0]["CNDTINC_MEMO_ISSUE"].ToString() == "1")
                {
                    checkMemo.Checked = true;
                    DivChatMsg.Attributes["style"] = "display: block";
                    divReplyMssg.Attributes["style"] = "display: block";
                    DataTable dtMsg = objEmpConduct.ReadChatMessageByid(objEntity);
                    DivMssgBox.InnerHtml = ConvertDataTableToHTML(dtMsg);

                }


            }
            if (dt.Rows[0]["CNDTINC_CATGORYID"].ToString() != "")
            {
                ddlCategory.Items.FindByValue(dt.Rows[0]["CNDTINC_CATGORYID"].ToString()).Selected = true;
            }
            if (dt.Rows[0]["CNDTINC_MEMO_ISSUE"].ToString() == "1")
            {
                checkMemo.Checked = true;

               
                txtmemodes.Text = dt.Rows[0]["CNDTINC_CATGORYRSN"].ToString();
                if (dt.Rows[0]["CNDTINC_MAIL_NOTFY"].ToString() == "1")
                {
                    ChkBxMailNotfcn.Checked = true;
                }

                //  divPrintReport.InnerHtml=  ConvertDataTableForPrint(dt);
            }
            HiddenEmailAddress.Value = dt.Rows[0]["USR_EMAIL"].ToString();
            if (dt.Rows[0]["CNDTINC_MEMO_ISSUE"].ToString() == "1")
            {

            }
            if (status == "CLOSED" || status == "TERMINATED" || status == "CONFIRMED")
            {
                ddlBusnssUnit.Enabled = false;
                ddldep.Enabled = false;
                ddlDivision.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlEmpId.Enabled = false;
                txtCondtdescrp.Enabled = false;
                typGood.Disabled = true;
                typNegtve.Disabled = true;
                ChkBxReprtOff.Disabled = true;
               // ChkBxDivMngr.Disabled = false;
                ddlPriorty.Enabled = false;
                ddlCategory.Enabled = false;
                ChkBxMailNotfcn.Disabled = true;
                txtmemodes.Enabled = false;
                txtmessg.Enabled = false;
                checkMemo.Disabled = true;
                ChkBxDivMngr.Disabled = true;
                ChkBxEmployee.Disabled = true;
            }



            if (status != "")
            {

                if (status == "CLOSED" || status == "TERMINATED")
                {
                    bttnsave.Visible = false;
                    btnSaveCls.Visible = false;
                    bttnUpdate.Visible = false;
                    bttnUpdateCls.Visible = false;
                    bttnCofrm.Visible = false;
                    BtnClose.Visible = false;
                    BtnTerminate.Visible = false;
                    BtnNotTerminate.Visible = false;
                    BtnNotClose.Visible = false;
                }
                else if (status == "CONFIRMED")
                {
                    BtnTerminate.Visible = true;
                    bttnsave.Visible = false;
                    btnSaveCls.Visible = false;
                    bttnCofrm.Visible = false;
                    //BtnClose.Visible = false;
                    //  BtnTerminate.Visible = false;
                    bttnUpdate.Visible = true;
                    bttnUpdateCls.Visible = true;
                    
                    DivPrint.Attributes["style"] = "display: block;float:right;margin-right: 3.5%;";
                    //if (dt.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
                    //{
                    //    BtnNotClose.Visible = true;
                    //    BtnClose.Visible = false;
                    //    BtnTerminate.Visible = false;

                    //}
                    //if (dt.Rows[0]["EXITPRS_ID"].ToString() != "")
                    //{
                    //    BtnNotTerminate.Visible = true;
                    //    BtnNotClose.Visible = true;
                    //    BtnTerminate.Visible = false;
                    //    BtnClose.Visible = false;
                    //}
                }
                else if (status == "ACKNOWLEDGED")
                {

                }
                //if (status == "SAVED")
                //{
                //    if (dt.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
                //    {
                //        BtnNotClose.Visible = true;
                //        BtnClose.Visible = false;
                //    }
                //    else
                //    {
                //        BtnClose.Visible = true;
                //        BtnNotClose.Visible = false;
                //    }
                //}
            }
            if (status == "CONFIRMED")
            {
                txtmessg.Enabled = true;
                if (dt.Rows[0]["CNDTINC_RECIVE"].ToString() == "1")
                {
                    if (HiddenRoleUpd.Value == "0")
                    {

                        bttnUpdate.Visible = false;
                        bttnUpdateCls.Visible = false;

                    }
                }
                else
                {
                    bttnUpdate.Visible = false;
                    bttnUpdateCls.Visible = false;
                }

            }

        }
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int maxintCondctId = int.MinValue;
        string strmaxintCondctId = "";
        string strEndTime = "";

        DateTime EndTime = DateTime.MinValue;
        foreach (DataRow dr in dt.Rows)
        {
            int intCondctId = dr.Field<int>("CNDTINCSUB_ID");
            maxintCondctId = Math.Max(maxintCondctId, intCondctId);
            string sEndTime = dt.Compute("max(CNDTINCSUB_DATE)", string.Empty).ToString();
            EndTime = objCommon.textToDateTime(sEndTime);
            strEndTime = EndTime.ToString("dd-MM-yyyy");
        }
        strmaxintCondctId = Convert.ToString(maxintCondctId);
        StringBuilder sb = new StringBuilder();
        foreach (DataRow Rowd in dt.Rows)
        {

            DateTime DATE;
            string strHtml;
            if (Rowd["CNDTINCSUB_STATUS"].ToString() == "1")
            {


                string strId = Rowd["CNDTINCSUB_ID"].ToString();
                string strDate =Rowd["CNDTINCSUB_DATE"].ToString();
                string strtime = Rowd["CNDTINCSUB_DATETIME"].ToString();
                strHtml = "<div class=\"col-xs-12\" style=\" height:auto;text-align:left;padding-bottom:10px;\">";
                strHtml += " <div class=\"panel panel-info col-xs-10 arrow_left_box  padding-0\">";
                strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + " " + strtime + "</div></div></div></div>";

            }
            else 
            {
                string strId = Rowd["CNDTINCSUB_ID"].ToString();
                string strDate = Rowd["CNDTINCSUB_DATE"].ToString();
                string strtime = Rowd["CNDTINCSUB_DATETIME"].ToString();
                strHtml = "<div class=\"col-xs-12\" style=\" height:auto;text-align:right;padding-bottom:10px;\">";
                strHtml += " <div class=\"panel panel-default col-xs-11 arrow_right_box  padding-0\" style=\"float:right;\">";
                if (strmaxintCondctId == strId && strEndTime == strDate)
                {
                    strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + strtime + "<div class=\"smart-form\"> <img title=\"DELETE MESSAGE\" style=\"float: left;margin-top: -1%; cursor: pointer;\" onclick=\"return CancelEntry('" + strId + "');\" src=\"../../../../Images/Icons/removeQuotCatgry.png\" height=\"15px\" width=\"15px\" /></div></div></div></div></div>";
                }
                else
                {
                    strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + strtime + "</div></div></div></div>";
                }
            }


            sb.Append(strHtml);

        }

        return sb.ToString();
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (System.Web.UI.WebControls.ListItem li in objDDL.Items)
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
            System.Web.UI.WebControls.ListItem objItem = new System.Web.UI.WebControls.ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }

    public void LoadAllDivisionDropDowns(clsEntity_Emp_conduct_Incident objEntity)
    {

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        DataTable dtCategory = objEmpConduct.LoadCategoery(objEntity);

        if (dtCategory.Rows.Count > 0)
        {
            ddlCategory.DataSource = dtCategory;
            ddlCategory.DataTextField = "M_REASON";
            ddlCategory.DataValueField = "RSN_ID";
            ddlCategory.DataBind();

        }


        DataTable dtBussUnit;
        dtBussUnit = objEmpConduct.LoadBissnusUnit(objEntity);
        if (dtBussUnit.Rows.Count > 0)
        {
            ddlBusnssUnit.DataSource = dtBussUnit;
            ddlBusnssUnit.DataTextField = "CORPRT_NAME";
            ddlBusnssUnit.DataValueField = "CORPRT_ID";
            ddlBusnssUnit.DataBind();

        }

    
     
        
        ddlCategory.ClearSelection();
      

        ddlBusnssUnit.ClearSelection();
        ddldep.ClearSelection();
        ddlDivision.ClearSelection();
        ddlBusnssUnit.Items.Insert(0, "--SELECT--");
        ddldep.Items.Insert(0, "--SELECT--");
        ddlDivision.Items.Insert(0, "--SELECT--");
        ddlCategory.Items.Insert(0, "--SELECT--");

    }
    public void EmployeeLoad()
    {
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();


        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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

        ddlEmployee.ClearSelection();
        ddlEmployee.Items.Clear();
        ddlEmpId.ClearSelection();
        ddlEmpId.Items.Clear();
        if (ddldep.SelectedItem.Value != "--SELECT--" && ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT--")
                objEntity.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            else
                objEntity.DivId = -1;
            objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);
            objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
            objEntity.AllDivisionChk = Convert.ToInt32(HiddenAllUserDivision.Value);
            DataTable dtEmp;
            dtEmp = objEmpConduct.LoadEmployee(objEntity);

            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();

                ddlEmpId.DataSource = dtEmp;
                ddlEmpId.DataTextField = "USR_CODE";
                ddlEmpId.DataValueField = "USR_ID";
                ddlEmpId.DataBind();

            }

        }

        ddlEmpId.Items.Insert(0, "--SELECT ID--");

        ddlEmployee.Items.Insert(0, "--SELECT NAME--");
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
     
        
        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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

        ddlEmployee.ClearSelection();
        ddlEmployee.Items.Clear();
        ddlEmpId.ClearSelection();
        ddlEmpId.Items.Clear();
        if ( ddldep.SelectedItem.Value != "--SELECT--" && ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT--")
                objEntity.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            else
                objEntity.DivId = -1;
            objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);
            objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
            objEntity.AllDivisionChk = Convert.ToInt32(HiddenAllUserDivision.Value);
            DataTable dtEmp;
            dtEmp = objEmpConduct.LoadEmployee(objEntity);

            if (dtEmp.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();

                ddlEmpId.DataSource = dtEmp;
                ddlEmpId.DataTextField = "USR_CODE";
                ddlEmpId.DataValueField = "USR_ID";
                ddlEmpId.DataBind();

            }

        }
       
        ddlEmpId.Items.Insert(0, "--SELECT ID--");
       
          ddlEmployee.Items.Insert(0, "--SELECT NAME--");
        //  ScriptManager.RegisterStartupScript(this, GetType(), "FocusAll", "FocusAll(" + HiddenFocus.Value + ");", true);

        if( HiddenFocus.Value =="Dep")
        {
            ddldep.Focus();
        }
        else if(HiddenFocus.Value =="D")
        {
            ddlDivision.Focus();
        }
     
    }
    [WebMethod]
    public static string ReadDescrption(string varCategoryId)
    {
        string result = "";
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        objEntity.CatgoryId = Convert.ToInt32(varCategoryId);
        DataTable dtCategoryDescp = objEmpConduct.LoadCategoryDescrption(objEntity);
        if (dtCategoryDescp.Rows.Count > 0)
        {
            result = dtCategoryDescp.Rows[0]["M_DESCRPTION"].ToString();
        }
        return result;
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntity.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


      
           
        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
        if (HiddenAllUserDivision.Value == "1")
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT--")
                objEntity.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            if (ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
                objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
            if (ddldep.SelectedItem.Value != "--SELECT--")
                objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);

        
         
        }
        if (ddlPriorty.SelectedItem.Value != "--SELECT--")
            objEntity.Severity = Convert.ToInt32(ddlPriorty.SelectedItem.Value);
       objEntity.IncidentDate=objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        if (ddlEmployee.SelectedItem.Value != "--SELECT NAME--")
            objEntity.UsrId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);

        if (ddlEmpId.SelectedItem.Value != "--SELECT ID--")
            objEntity.UsrId = Convert.ToInt32(ddlEmpId.SelectedItem.Value);

        objEntity.IncidentDescripton = txtCondtdescrp.Text.Trim();
        if (typGood.Checked==true)
            {
        objEntity.IncidentType = 1;
            }
            else if(typNegtve.Checked==true)
                {
                 objEntity.IncidentType = 0;
                }
        if (checkMemo.Checked == true)
            {
        objEntity.MemoIssue = 1;
            }
        objEntity.REFNo = RefH2.InnerHtml;
    
        if (ChkBxReprtOff.Checked == true)
        {
            objEntity.OfficierNotify = 1;
        }
        if (ChkBxDivMngr.Checked == true)
        {
            objEntity.OfficierNotify = 2;
        }
        if (ChkBxDivMngr.Checked == true && ChkBxReprtOff.Checked == true )
        {
            objEntity.OfficierNotify = 3;
        }
        //EVM-0024
        if (ChkBxEmployee.Checked == true)
        {
            objEntity.Employee = 1;
        }
        else
        {
            objEntity.Employee = 0;

        }
        if (ddlCategory.SelectedItem.Value != "--SELECT--")
            objEntity.CatgoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        //END
        if (checkMemo.Checked == true)
        {
            objEntity.MemoIssue = 1;
           //
            objEntity.CatgoryReson = txtmemodes.Text.Trim();

            if (ChkBxMailNotfcn.Checked == true)
        {
            objEntity.MailNotify = 1;
        }
            
        }

            objEmpConduct.InsertConductIncident(objEntity);
            if (clickedButton.ID == "bttnsave")
            {
                Session["MESSG_CONDINCDNT"] = "INS";
                Response.Redirect("hcm_Emp_Conduct_Incident.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnSaveCls")
            {
                Session["MESSG_CONDINCDNT_LIST"] = "INS";
                Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=Ins");
            }
        
    }
    protected void bttnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntity.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        objEntity.ConductIncident_Id = Convert.ToInt32(HiddenConductInsId.Value);

        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
        if (HiddenAllUserDivision.Value == "1")
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT--")
                objEntity.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            if (ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
                objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
            if (ddldep.SelectedItem.Value != "--SELECT--")
                objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);



        }
        if (ddlPriorty.SelectedItem.Value != "--SELECT--")
            objEntity.Severity = Convert.ToInt32(ddlPriorty.SelectedItem.Value);

        objEntity.IncidentDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        if (ddlEmployee.SelectedItem.Value != "--SELECT NAME--")
            objEntity.UsrId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);

        if (ddlEmpId.SelectedItem.Value != "--SELECT ID--")
            objEntity.UsrId = Convert.ToInt32(ddlEmpId.SelectedItem.Value);


        objEntity.IncidentDescripton = txtCondtdescrp.Text.Trim();
        if (typGood.Checked == true)
        {
            objEntity.IncidentType = 1;
        }
        else if (typNegtve.Checked == true)
        {
            objEntity.IncidentType = 0;
        }
        if (checkMemo.Checked == true)
        {
            objEntity.MemoIssue = 1;
        }
        objEntity.REFNo = RefH2.InnerHtml;

        if (ChkBxReprtOff.Checked == true)
        {
            objEntity.OfficierNotify = 1;
        }
        if (ChkBxDivMngr.Checked == true)
        {
            objEntity.OfficierNotify = 2;
        }
        if (ChkBxDivMngr.Checked == true && ChkBxReprtOff.Checked == true)
        {
            objEntity.OfficierNotify = 3;
        }
        //EVM-0024
        if (ChkBxEmployee.Checked == true)
        {
            objEntity.Employee = 1;
        }
        else
        {
            objEntity.Employee = 0;

        }
        if (ddlCategory.SelectedItem.Value != "--SELECT--")
            objEntity.CatgoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        //END
        if (checkMemo.Checked == true)
        {
            objEntity.MemoIssue = 1;

            objEntity.CatgoryReson = txtmemodes.Text.Trim();

            if (ChkBxMailNotfcn.Checked == true)
            {
                objEntity.MailNotify = 1;


            }
            objEntity.Message = txtmessg.Text;

        }

        DataTable dtCancel = objEmpConduct.CancelNotPossible(objEntity);
        DataTable dtTermn = objEmpConduct.TerminationNotPossible(objEntity);
        if (dtCancel.Rows.Count > 0)
        {
            if (dtCancel.Rows[0]["CNDTINC_TRMNTN_USRID"].ToString() != "")
            {

                Session["MESSG_CONDINCDNT"] = "TERMINATED";
            }
            else if (dtCancel.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
            {
                Session["MESSG_CONDINCDNT"] = "CLOSED";
            }
        }
        else if (dtTermn.Rows.Count > 0)
        {
            Session["MESSG_CONDINCDNT"] = "TERMNTN_UNDER_PRSS";
        }
        else
        {
            objEmpConduct.Update_ConductIncident(objEntity);
            if (clickedButton.ID == "bttnCofrm" || clickedButton.ID == "BtnConfirm")
            {
                objEmpConduct.Confirm_ConductIncident(objEntity);
            }

            if (ChkBxMailNotfcn.Checked == true)
            {
                if (clickedButton.ID == "bttnCofrm" || clickedButton.ID == "BtnConfirm")
                {
                    string pdfPath = PdfMemo(objEntity);
                    if (ChkBxEmployee.Checked == true)
                    {
                        DataTable dtmailid = objEmpConduct.ReadUsermail(objEntity);
                        if (dtmailid.Rows.Count > 0)
                        {
                            if (dtmailid.Rows[0]["USR_EMAIL"].ToString() != "")
                            {
                                Thread thrSendMail = new Thread(() => SendMailToEmployee(dtmailid.Rows[0]["USR_EMAIL"].ToString(), objEntity, pdfPath));
                                thrSendMail.Start();
                            }
                        }
                    }
                }
            }

            if (clickedButton.ID == "bttnUpdate")
            {
                Session["MESSG_CONDINCDNT"] = "UPD";
                Response.Redirect("hcm_Emp_Conduct_Incident.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "bttnUpdateCls")
            {
                Session["MESSG_CONDINCDNT_LIST"] = "UPD";
                Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "bttnCofrm")
            {

                Session["MESSG_CONDINCDNT_LIST"] = "CNFM";
                Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "BtnConfirm")
            {

                Session["MESSG_CONDINCDNT_LIST"] = "CNFM";
                Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=Upd");
            }
        }
    }

    private void SendMailToEmployee(string Email, clsEntity_Emp_conduct_Incident objEntity, string pdfPath)
    {
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntityCon = new clsEntity_Emp_conduct_Incident();

        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();

        EntityTemMailServce.CorpOffice_Id = objEntity.CorpId;
        DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);




        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        objEntityMail.Email_Subject = "OFFICE MEMO";
        objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

        objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
        objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
        objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
        objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
        objEntityMail.D_Date = System.DateTime.Now;
        string strDate = System.DateTime.Now.ToString("dd-MM-yyyy");
        objEntityMail.To_Email_Address = Email;
            //HiddenConductInsId.Value;
        string strMailContent = "";
        objEntityCon.OrgId = objEntity.OrgId;
        objEntityCon.CorpId = objEntity.CorpId;
        objEntityCon.UserId = objEntity.UsrId;
        DataTable dtPdfDtls = objEmpConduct.PdfEmployeeDetails(objEntityCon);
        if (dtPdfDtls.Rows.Count > 0)
        {

            strMailContent = "Dear  " + dtPdfDtls.Rows[0]["USR_NAME"] + " ,";


            strMailContent += "<br/><br/> " + dtPdfDtls.Rows[0]["CNDTINC_DESCRPTN"]; 


            strMailContent += "<br/><br/>   *** This is an automatically generated email, please do not reply *** ";
            strMailContent += "<br/><br/><br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
          
        }
        objEntityMail.Email_Content = strMailContent;
        clsEntityMailAttachment objAttachmnt = new clsEntityMailAttachment();
        objAttachmnt.Attch_Path = Server.MapPath(pdfPath);
        objEntityMailAttachList.Add(objAttachmnt);

        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

        // objMail.SendMailAsHtml(objEntityMail, objEntityMailAttachList);
        try
        {
            objMail.SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
        }
        catch
        {
        
        }
    }

    private string PdfMemo( clsEntity_Emp_conduct_Incident objEntity)
    {
        clsBusiness_Emp_Conduct_Incident objBusinessEmpConduct = new clsBusiness_Emp_Conduct_Incident();
      
        int intCorpId = 0, intOrgId = 0, intUserId = 0;


        objEntity.UserId = objEntity.UsrId;



        intCorpId = objEntity.CorpId;

        intOrgId = objEntity.OrgId;
        
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
        iTextSharp.text.Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string path = "";
        DataTable dtPdfDtls = objBusinessEmpConduct.PdfEmployeeDetails(objEntity);
        //string strPrintReport = ConvertDataTableForPrint(dtPdfDtls);
        //divPrintReport.InnerHtml = strPrintReport;
        if (dtPdfDtls.Rows.Count > 0)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                //  PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONDUCT_INCIDENT_PDF);
                objEntityCommon.CorporateID = objEntity.CorpId;
                string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
                int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CONDUCT_INCIDENT_PDF);
                string strImageName = "Conduct Incident" + strNextId.ToString() + "_" + ".pdf";
                string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CONDUCT_INCIDENT_PDF);
                path = strImagePath + strImageName;
                // PdfWriter.GetInstance(document, new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create));


                System.IO.FileStream file = new System.IO.FileStream(Server.MapPath(strImagePath) + strImageName , System.IO.FileMode.OpenOrCreate);

                PdfWriter writer = PdfWriter.GetInstance(document, file);
                // calling PDFFooter class to Include in document
                writer.PageEvent = new PDFFooter();

                document.Open();

                PdfPTable tableLayout = new PdfPTable(2);
                float[] headersBody = { 8, 92 };
                tableLayout.SetWidths(headersBody);
                tableLayout.WidthPercentage = 100;

                tableLayout.AddCell(new PdfPCell(new Phrase("Ref", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, PaddingTop = 120 });
                tableLayout.AddCell(new PdfPCell(new Phrase(":  " + dtPdfDtls.Rows[0]["CNDTINC_REFNO"].ToString(), FontFactory.GetFont("Arial", 12, BaseColor.BLACK))) { Border = 0, PaddingTop = 120, HorizontalAlignment = Element.ALIGN_LEFT });
                tableLayout.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tableLayout.AddCell(new PdfPCell(new Phrase(": " + DateTime.Now.ToString("dd-MM-yyyy"), FontFactory.GetFont("Arial", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                document.Add(tableLayout);

                PdfPTable headtable2 = new PdfPTable(2);
                float[] headHeading = { 5, 95 };
                headtable2.SetWidths(headHeading);
                headtable2.WidthPercentage = 100;
                headtable2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_CENTER });
                headtable2.AddCell(new PdfPCell(new Phrase("OFFICE MEMO", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_CENTER });
                document.Add(headtable2);

                PdfPTable tableLayout2 = new PdfPTable(2);
                float[] headersBody2 = { 0, 100 };
                tableLayout2.SetWidths(headersBody2);
                tableLayout2.WidthPercentage = 100;
                tableLayout2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_CENTER });

                tableLayout2.AddCell(new PdfPCell(new Phrase(dtPdfDtls.Rows[0]["USR_NAME"].ToString(), FontFactory.GetFont("Arial", 10, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT });

                if (dtPdfDtls.Rows[0]["DSGN_NAME"].ToString() != "")
                {
                    tableLayout2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });

                    tableLayout2.AddCell(new PdfPCell(new Phrase(dtPdfDtls.Rows[0]["DSGN_NAME"].ToString(), FontFactory.GetFont("Arial", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }

                tableLayout2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tableLayout2.AddCell(new PdfPCell(new Phrase(dtPdfDtls.Rows[0]["USR_CODE"].ToString(), FontFactory.GetFont("Arial", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

                document.Add(tableLayout2);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(dtPdfDtls.Rows[0]["CNDTINC_CATGORYRSN"].ToString(), FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))));


                PdfPTable tableLayout3 = new PdfPTable(2);
                float[] headersBody3 = { 0, 100 };
                tableLayout3.SetWidths(headersBody2);
                tableLayout3.WidthPercentage = 100;
                tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_CENTER });
                tableLayout3.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Arial", 12, BaseColor.BLACK))) { Border = 0, PaddingTop = 30, HorizontalAlignment = Element.ALIGN_LEFT });
                tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_CENTER });

                tableLayout3.AddCell(new PdfPCell(new Phrase("c.c  HR & Admin", FontFactory.GetFont("Arial", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                document.Add(tableLayout3);


                document.Close();
                Response.Write(document);
               
            }
        }
        return path;
    }
    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/CustomImages/Corporate Logos/quotation-header.png"));
            image.ScalePercent(PdfPCell.ALIGN_CENTER);
            image.ScaleToFit(600f, 80f);
            cell = new PdfPCell(new PdfPCell(image));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 145, document.Top, writer.DirectContent);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/CustomImages/Corporate Logos/quotation-footer.png"));
            image.ScalePercent(PdfPCell.ALIGN_LEFT);
            image.ScaleToFit(594f, 80f);
            cell = new PdfPCell(new PdfPCell(image));
            tabFot.AddCell(cell);
            float row = 70;
            tabFot.WriteSelectedRows(0, -1, 0, row, writer.DirectContent);
            //tabFot.WriteSelectedRows(
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }

    public string ConvertDataTableForPrint(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table style=\"width: 82%; margin-left: 9%;border: 1px solid rgb(195, 186, 186);\" id=\"PrintTable\" >";
        if (dt.Rows.Count > 0)
        {
            strHtml += "<tbody style=\"width: 76%; margin-left: 10%;\">";

            strHtml += "<tr><td style=\"width:100%;height:15%; word-wrap:break-word;text-align: center;padding-left:2%;\">" + "<img src='/CustomImages/Corporate Logos/quotation-header.png' /> " + "</a> </td></tr>";

            strHtml += "<tr><td style=\"width:100%;text-align: left;font-weight: bold;padding-left:5%;font-size:12px;padding-top:7%; word-wrap:break-word;\">Ref   :" + dt.Rows[0]["CNDTINC_REFNO"].ToString() + "</td></tr>";
            strHtml += "<tr><td style=\"width:100%;text-align: left;padding-left:5%;font-weight: bold;font-size:12px;word-wrap:break-word;\">Date   :" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr>";
            strHtml += "<tr><td style=\"width:100%;text-align: center;font-weight: bold;padding-top:2%;font-size:14px;word-wrap:break-word;\"><u>OFFICE MEMO</u></td></tr>";

            strHtml += "<tr><td style=\"width:60%;text-align: left;padding-top:4%;font-size:13px; padding-left:5%; word-wrap:break-word;\">" + dt.Rows[0]["USR_NAME"].ToString() + "</td></tr>";
            strHtml += "<tr><td style=\"width:60%;text-align: left;font-size:12px;padding-left:5%; word-wrap:break-word;\">" + dt.Rows[0]["DSGN_NAME"].ToString() + "</td></tr>";
            strHtml += "<tr><td style=\"width:60%;text-align: left;;padding-left:5%;font-size:12px; word-wrap:break-word;\">" + dt.Rows[0]["USR_CODE"].ToString() + "</td></tr>";

            strHtml += "<tr><td style=\"width:60%;text-align: left;padding-top:3%;font-size:13px;font-weight: bold; padding-left:5%; word-wrap:break-word;\">" + dt.Rows[0]["CNDTINC_CATGORYRSN"].ToString() + "</td></tr>";
            strHtml += "<tr><td style=\"width:60%;text-align: left;padding-top:3%;font-size:12px;padding-left:5%; word-wrap:break-word;\">GENERAL MANAGER</td></tr>";
            strHtml += "<tr><td style=\"width:60%;text-align: left;;padding-left:5%;font-size:12px;word-wrap:break-word;\">c.c HR & Admin</td></tr>";
            strHtml += "<tr><td tyle=\"width:60%;text-align: left;padding-left:5%;font-size:12px;font-weight: bold; word-wrap:break-word;\"></td></tr>";
            strHtml += "<tr><td style=\"width:100%;height:15%; word-wrap:break-word;text-align: center;padding-top:100%;\">" + "<img src='/CustomImages/Corporate Logos/quotation-footer.png' /> " + "</a> </td></tr>";

            strHtml += "</tbody>";
            //add rows

        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void bttnClose_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntity.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntity.ConductIncident_Id = Convert.ToInt32(HiddenConductInsId.Value);
        DataTable dtCancel = objEmpConduct.CancelNotPossible(objEntity);
        if (dtCancel.Rows.Count > 0)
        {

            if (dtCancel.Rows[0]["CNDTINC_TRMNTN_USRID"].ToString() != "")
            {

                Session["MESSG_CONDINCDNT"] = "TERMINATED";
              //  ScriptManager.RegisterStartupScript(this, GetType(), "ValidateTerminated", "ValidateTerminated();", true);
            }
            else if (dtCancel.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
            {
                Session["MESSG_CONDINCDNT"] = "CLOSED";
               // ScriptManager.RegisterStartupScript(this, GetType(), "ValidateNotClose", "ValidateNotClose();", true);
            }
            else
            {
                objEmpConduct.CloseConductIncident(objEntity);
                Session["MESSG_CONDINCDNT_LIST"] = "CLS";
                Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=CLS");
            }
        }
        else
        {
            objEmpConduct.CloseConductIncident(objEntity);
            Session["MESSG_CONDINCDNT_LIST"] = "CLS";
            Response.Redirect("hcm_Emp_Conduct_Incident_List.aspx?InsUpd=CLS");
        }



      
    }

    //EVM-0024
    protected void bttnTerminate_Click(object sender, EventArgs e)
    {

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        //  if (ddlEmployee.SelectedValue != "--SELECT NAME--")
        // {
        //string strId = ddlEmployee.SelectedValue;
        string strId = HiddenUserId.Value;
        int intIdLength = strId.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId + strRandom;

        objEntity.UserId = Convert.ToInt32(strId);
        DataTable dtTermn = objEmpConduct.TerminationNotPossible(objEntity);

        DataTable dtTermnConfm = objEmpConduct.TerminationNotPossibleConfrm(objEntity);
        int Flag = 0;
        if (dtTermn.Rows.Count > 0)
        {
            Flag++;
            Session["MESSG_CONDINCDNT"] = "TERMNTN_UNDER_PRSS";
           // ScriptManager.RegisterStartupScript(this, GetType(), "ValidateNotTerminate", "ValidateNotTerminate();", true);
        }
        objEntity.ConductIncident_Id = Convert.ToInt32(HiddenConductInsId.Value);

        DataTable dtCancel = objEmpConduct.CancelNotPossible(objEntity);
        if (dtCancel.Rows.Count > 0)
        {

            if (dtCancel.Rows[0]["CNDTINC_TRMNTN_USRID"].ToString() != "")
            {
                Flag++;
                Session["MESSG_CONDINCDNT"] = "TERMINATED";
              //  ScriptManager.RegisterStartupScript(this, GetType(), "ValidateTerminated", "ValidateTerminated();", true);
            }
            else if (dtCancel.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
            {
                Flag++;
                Session["MESSG_CONDINCDNT"] = "CLOSED";
              //  ScriptManager.RegisterStartupScript(this, GetType(), "ValidateNotClose", "ValidateNotClose();", true);
            }
            else
            {
                Response.Redirect("../../hcm_Exit_Management/hcm_Employee_Exit_Process/hcm_Emp_Exit_Process.aspx?Incident=" + Id);
            }
        }
        if (Flag == 0)
        {
            Response.Redirect("../../hcm_Exit_Management/hcm_Employee_Exit_Process/hcm_Emp_Exit_Process.aspx?Incident=" + Id);
        }
        //if (dtTermnConfm.Rows.Count > 0)
        //{

        //}
      
        //   }
    }
    //end

    protected void BusSelectChane_Click(object sender, EventArgs e)
    {

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();


        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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

        ddldep.ClearSelection();
        ddldep.Items.Clear();
        ddlDivision.ClearSelection();
        ddlDivision.Items.Clear();
      
        ddlEmployee.Items.Clear();
        ddlEmpId.Items.Clear();
        ddlEmployee.ClearSelection();
        ddlEmployee.Items.Insert(0, "--SELECT NAME--");
        ddlEmpId.ClearSelection();
        ddlEmpId.Items.Insert(0, "--SELECT ID--");
        if ( ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
        {
            
          
            objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
         
            DataTable dtEmp;
          

            DataTable dtDep;
            dtDep = objEmpConduct.LoadDepartment(objEntity);
            if (dtDep.Rows.Count > 0)
            {
                ddldep.DataSource = dtDep;
                ddldep.DataTextField = "CPRDEPT_NAME";
                ddldep.DataValueField = "CPRDEPT_ID";
                ddldep.DataBind();

            }
           


        }



        ddldep.Items.Insert(0, "--SELECT--");
        ddlDivision.Items.Insert(0, "--SELECT--");
        ScriptManager.RegisterStartupScript(this, GetType(), "FocusBusness", "FocusBusness();", true);

    }
    protected void DeptSelectChange_Click(object sender, EventArgs e)
    {
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();


        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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

        ddlDivision.ClearSelection();
        ddlDivision.Items.Clear();
        if (ddldep.SelectedItem.Value != "--SELECT--" && ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
        {
            objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);
            objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);
            objEntity.AllDivisionChk = Convert.ToInt32(HiddenAllUserDivision.Value);
            DataTable dtDivision;
            dtDivision = objEmpConduct.LoadDivision(objEntity);

            if (dtDivision.Rows.Count > 0)
            {
                ddlDivision.DataSource = dtDivision;
                ddlDivision.DataTextField = "CPRDIV_NAME";
                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataBind();

            }


        }
        //else
        //{
        //    ddldep.ClearSelection();
        //    ddldep.Items.Clear();
        //    ddldep.Items.Insert(0, "--SELECT--");
        //}

        ddlDivision.Items.Insert(0, "--SELECT--");
        ddldep.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "AlldivisionEmployeeLoad", "AlldivisionEmployeeLoad('Dep');", true);
    }
    [WebMethod]
    public static string[] CancelMessage(string IncidentSubID, string varId)
    {
         string[] a = new string[2]; 
        HCM_HCM_Master_hcm_Emp_Conduct_Incident_hcm_Emp_Conduct_Incident obj = new HCM_HCM_Master_hcm_Emp_Conduct_Incident_hcm_Emp_Conduct_Incident();
        string strreturn = "";
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        objEntity.ConductSubIncident_Id = Convert.ToInt32(IncidentSubID);
        objEmpConduct.CancelMessageBox(objEntity);
        objEntity.ConductIncident_Id =Convert.ToInt32(varId);
        DataTable dtMsg = objEmpConduct.ReadChatMessageByid(objEntity);
      a[0]  = obj.ConvertDataTableToHTML(dtMsg);

        strreturn = "Cancel";
        return a;
    }
}