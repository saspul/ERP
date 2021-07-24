using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Data;
using System.IO;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Employee_Exit_Process_hcm_Emp_Exit_Process : System.Web.UI.Page
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

            LoadEmpExitPrcssMastrSts();

            if (radioStaff.Checked == true)
            {
                LoadFormData(0);
            }
            else if (radioWorker.Checked == true)
            {
                LoadFormData(1);
            }
            

            radioStaff.Checked = true;

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen=0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenDate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Exit_Process);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }


            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnSave.Visible = true;
                btnSaveClose.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                }

                btnUpdateClose.Visible = true;
            }
            else
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }

            if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnConfirm.Visible = true;
            }
            else
            {
                btnConfirm.Visible = false;
            }

            if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                imgbtnReOpen.Visible = true;
            }
            else
            {
                imgbtnReOpen.Visible = false;
            } 

            //Creating objects for business layer

            clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
            clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

            if (Session["USERID"] != null)
            {
                objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
                hiddenUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            int intOrgId = 0;

            if (Session["ORGID"] != null)
            {
                objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenExtPrcsId.Value = strId;
                EditView(strId);


                lblEntry.Text = "Edit Exit Process";

                if (hiddenConfirm.Value == "1")
                {
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;
                    btnClear.Visible = false;
                    btnConfirm.Visible = false;
                    btnCancel.Visible = true;
                    //imgbtnReOpen.Visible = true;

                }
                else
                {
                    btnUpdateClose.Visible = true;
                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;
                    btnClear.Visible = false;
                    //btnConfirm.Visible = true;
                    btnCancel.Visible = true;
                }
            }

            //when  viewing on cancel status checked
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenEmpId.Value = strId;
                EditView(strId);

                hiddenView.Value = "true";

                lblEntry.Text = "View Exit Process";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnClear.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = true;
                imgbtnReOpen.Visible = false;
                if (Request.QueryString["RFGP"] != null)
                {
                    btnCancel.Visible = false;
                    divList.Visible = false;
                }
            }
              //EVM-0024
            else if (Request.QueryString["Incident"] != null)
            {
                string strRandomMixedId = Request.QueryString["Incident"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
               
                IncidentView(strId);
            }
                //end
            //when inserting
            else
            {
                lblEntry.Text = "Add Exit Process";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnSave.Visible = true;
                btnSaveClose.Visible = true;
                btnClear.Visible = true;
                btnConfirm.Visible = false;
                btnCancel.Visible = true;
                imgbtnReOpen.Visible = false;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Save")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Conf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (strInsUpd == "ReOpen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopened", "SuccessReopened();", true);
                }
            }
        }
    }



    [WebMethod]
    public static string EmpDropdownBind(string strMode, int intCorpId, int intOrgId)
    
    {
        //loading employees

        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        objEntitylayrExitPrcs.CorpId = intCorpId;
        objEntitylayrExitPrcs.OrgId = intOrgId;
        objEntitylayrExitPrcs.Mode = Convert.ToInt32(strMode);

        DataTable dtEmp = new DataTable();
        dtEmp = objBusinessExitProcs.ReadToddlEmployee(objEntitylayrExitPrcs);

        dtEmp.TableName = "dtEmpTable";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmp.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }


    public void LoadEmpExitPrcssMastrSts()
    {
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        DataTable dtEmpExitPrcssMastrSts = objBusinessExitProcs.ReadEmpExitProcessMstrSts(objEntitylayrExitPrcs);

        ddlStatus.DataSource = dtEmpExitPrcssMastrSts;
        ddlStatus.DataTextField = "EXIT_PRCS_STS_NAME";
        ddlStatus.DataValueField = "EXIT_PRCS_STS_ID";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "--SELECT STATUS--");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;

        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        //EVM-0024
        if (Request.QueryString["Incident"] != null)
        {
            string strRandomMixedId = Request.QueryString["Incident"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntitylayrExitPrcs.IncidentUserId=Convert.ToInt32(strId);
        }
       //END
        if (Session["USERID"] != null)
        {
            objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (hiddenEmpId.Value != "--SELECT EMPLOYEE--")
        {
            objEntitylayrExitPrcs.EmpId = Convert.ToInt32(hiddenEmpId.Value);
        }

        if (ddlStatus.SelectedItem.Value != "0")
        {
            objEntitylayrExitPrcs.ExitProcsStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }
        objEntitylayrExitPrcs.ExitReason = txtRsn.Text;

        if (txtTermntDate.Text != "")
        {
            objEntitylayrExitPrcs.ExitProcsDate = objCommon.textToDateTime(txtTermntDate.Text.Trim());
        }
        if (hiddenNotcprd.Value != "")
        {
            objEntitylayrExitPrcs.NoticePrd = Convert.ToInt32(hiddenNotcprd.Value);
        }
        objEntitylayrExitPrcs.Date = System.DateTime.Now;

        objBusinessExitProcs.InsertExitPrcs(objEntitylayrExitPrcs);

        if (clickedButton.ID == "btnSave")
        {
            Response.Redirect("hcm_Emp_Exit_Process.aspx?InsUpd=Save");
        }
        else if (clickedButton.ID == "btnSaveClose")
        {
            Response.Redirect("hcm_Emp_Exit_Process_List.aspx?InsUpd=Save");
        }

    }

    [WebMethod]
    public static string[] EmpDtls(int intEmpId)
    {
        //loading employees details

        string[] strJsonEmp = new string[30];

        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();


        objEntitylayrExitPrcs.EmpId = intEmpId;

        DataTable dtEmpDtls = new DataTable();
        dtEmpDtls = objBusinessExitProcs.ReadEmpDtls(objEntitylayrExitPrcs);

        if (dtEmpDtls.Rows.Count > 0)
        {

            strJsonEmp[0] = dtEmpDtls.Rows[0]["USR_NAME"].ToString();
            strJsonEmp[1] = dtEmpDtls.Rows[0]["DSGN_NAME"].ToString();
            strJsonEmp[2] = dtEmpDtls.Rows[0]["PYGRD_NAME"].ToString();
            strJsonEmp[3] = dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString();

            DataTable dtEmpDiv = new DataTable();
            dtEmpDiv = objBusinessExitProcs.ReadDivsnEmp(objEntitylayrExitPrcs);

            string strEmpDiv = "";
            if (dtEmpDiv.Rows.Count > 0)
            {
                foreach (DataRow dtrow in dtEmpDiv.Rows)
                {
                    strEmpDiv = dtrow["CPRDIV_NAME"] + " , " + strEmpDiv;
                }
            }
            strJsonEmp[4] = strEmpDiv.TrimEnd(" , ".ToCharArray());

            if (dtEmpDtls.Rows[0]["NTCPRD_STATUS"].ToString() != "0")
            {
                strJsonEmp[5] = dtEmpDtls.Rows[0]["NTCPRD_DAYS"].ToString();
            }
            else
            {
                strJsonEmp[5] = "0";
            }

        }

        return strJsonEmp;
    }

    public void EditView(string strId)
    {
        hiddenViewEdit.Value = "true";

        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitylayrExitPrcs.ExitProcsId = Convert.ToInt32(strId);

        DataTable dtEmpExt = new DataTable();
        dtEmpExt = objBusinessExitProcs.ReadEmpExitDtls(objEntitylayrExitPrcs);
        //cphMain_imgbtnReOpen
        if (dtEmpExt.Rows.Count > 0)
        {
            if (dtEmpExt.Rows[0]["END_SRVC_STLMNT_STS"].ToString() == "1" || dtEmpExt.Rows[0]["END_SRVC_STLMNT_STS"].ToString() == "2")
            {
                imgbtnReOpen.Visible = false;
            }
            objEntitylayrExitPrcs.EmpId = Convert.ToInt32(dtEmpExt.Rows[0]["USR_ID"].ToString());

            if (dtEmpExt.Rows[0]["STAFF_WORKER"].ToString() == "0")
            {
                radioStaff.Checked = true;
            }
            else if (dtEmpExt.Rows[0]["STAFF_WORKER"].ToString() == "1")
            {
                radioWorker.Checked = true;
            }

            if (ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()) != null)
            {
                ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtEmpExt.Rows[0]["USR_NAME"].ToString(), dtEmpExt.Rows[0]["USR_ID"].ToString());
                ddlEmployee.Items.Insert(0, lstGrp);
                ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }


            lblEmp.Text = dtEmpExt.Rows[0]["USR_NAME"].ToString();
            lblDesgntn.Text = dtEmpExt.Rows[0]["DSGN_NAME"].ToString();
            lblPay.Text = dtEmpExt.Rows[0]["PYGRD_NAME"].ToString();
            lblDept.Text = dtEmpExt.Rows[0]["CPRDEPT_NAME"].ToString();


            DataTable dtEmpDiv = new DataTable();
            dtEmpDiv = objBusinessExitProcs.ReadDivsnEmp(objEntitylayrExitPrcs);

            string strEmpDiv = "";
            string[] DivData = new string[7];
            if (dtEmpDiv.Rows.Count > 0)
            {
                foreach (DataRow dtrow in dtEmpDiv.Rows)
                {
                    strEmpDiv = dtrow["CPRDIV_NAME"] + " , " + strEmpDiv;
                }
            }
            DivData[0] = strEmpDiv.TrimEnd(" , ".ToCharArray());

            if (dtEmpExt.Rows[0]["EXTPRCS_STS"].ToString() != "")
            {
                ddlStatus.Items.FindByValue(dtEmpExt.Rows[0]["EXTPRCS_STS"].ToString()).Selected = true;

                
            }

            txtRsn.Text = dtEmpExt.Rows[0]["EXTPRCS_RSN"].ToString();

            if (dtEmpExt.Rows[0]["NOTICEPRD"].ToString() != "")
            {
                txtNoticePrd.Text = dtEmpExt.Rows[0]["NOTICEPRD"].ToString();
                hiddenNtcPrdPrevious.Value = dtEmpExt.Rows[0]["NOTICEPRD"].ToString();
            }

            txtTermntDate.Text = dtEmpExt.Rows[0]["EXTPRCS_DATE"].ToString();

            hiddenConfirm.Value = dtEmpExt.Rows[0]["EXTPRCS_CONFRMSTS"].ToString();

            if (hiddenConfirm.Value == "1")
            {
                ddlStatus.Enabled = false;
                txtRsn.Enabled = false;
                txtNoticePrd.Enabled = false;
                txtTermntDate.Enabled = false;
                
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnClear.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = true;

            }
        }
    }
    //evm-0024
    public void IncidentView(string strId)
    {
        hiddenViewEdit.Value = "true";

        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitylayrExitPrcs.EmpId = Convert.ToInt32(strId);
        hiddenEmpId.Value = strId;

        DataTable dtEmpExt = new DataTable();
        dtEmpExt = objBusinessExitProcs.ReadEmpIncidentDtls(objEntitylayrExitPrcs);
        //cphMain_imgbtnReOpen
        if (dtEmpExt.Rows.Count > 0)
        {
            objEntitylayrExitPrcs.EmpId = Convert.ToInt32(dtEmpExt.Rows[0]["USR_ID"].ToString());

            if (dtEmpExt.Rows[0]["STAFF_WORKER"].ToString() == "0")
            {
                radioStaff.Checked = true;
            }
            else if (dtEmpExt.Rows[0]["STAFF_WORKER"].ToString() == "1")
            {
                radioWorker.Checked = true;
            }

            if (ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()) != null)
            {
                ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtEmpExt.Rows[0]["USR_NAME"].ToString(), dtEmpExt.Rows[0]["USR_ID"].ToString());
                ddlEmployee.Items.Insert(0, lstGrp);
                ddlEmployee.Items.FindByValue(dtEmpExt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }


            lblEmp.Text = dtEmpExt.Rows[0]["USR_NAME"].ToString();
            lblDesgntn.Text = dtEmpExt.Rows[0]["DSGN_NAME"].ToString();
            lblPay.Text = dtEmpExt.Rows[0]["PYGRD_NAME"].ToString();
            lblDept.Text = dtEmpExt.Rows[0]["CPRDEPT_NAME"].ToString();


            DataTable dtEmpDiv = new DataTable();
            dtEmpDiv = objBusinessExitProcs.ReadDivsnEmp(objEntitylayrExitPrcs);

            string strEmpDiv = "";
            string[] DivData = new string[7];
            if (dtEmpDiv.Rows.Count > 0)
            {
                foreach (DataRow dtrow in dtEmpDiv.Rows)
                {
                    strEmpDiv = dtrow["CPRDIV_NAME"] + " , " + strEmpDiv;
                }
            }
            DivData[0] = strEmpDiv.TrimEnd(" , ".ToCharArray());

            ddlStatus.Items.FindByValue("3").Selected = true;
            //txtRsn.Text = dtEmpExt.Rows[0]["EXTPRCS_RSN"].ToString();
            txtNoticePrd.Text = "";
            txtTermntDate.Text = DateTime.Now.ToString("dd-mm-yyyy");

            // hiddenConfirm.Value = dtEmpExt.Rows[0]["EXTPRCS_CONFRMSTS"].ToString();

            ddlStatus.Enabled = false;
            ddlEmployee.Enabled = false;
            lblEntry.Text = "Add Exit Process";
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnSave.Visible = true;
            btnSaveClose.Visible = true;
            btnClear.Visible = true;
            btnConfirm.Visible = false;
            btnCancel.Visible = true;
            imgbtnReOpen.Visible = false;

        }
    }
    //end
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
            clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }



            objEntitylayrExitPrcs.ExitProcsId = int.Parse(hiddenExtPrcsId.Value);

            if (ddlStatus.SelectedItem.Value != "0")
            {
                objEntitylayrExitPrcs.ExitProcsStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            }
            objEntitylayrExitPrcs.ExitReason = txtRsn.Text;

            if (txtTermntDate.Text.Trim() != "")
            {
                objEntitylayrExitPrcs.ExitProcsDate = objCommon.textToDateTime(txtTermntDate.Text.Trim());
            }

            if (hiddenNotcprd.Value != "")
            {
                objEntitylayrExitPrcs.NoticePrd = Convert.ToInt32(hiddenNotcprd.Value);
            }
            else
            {
                objEntitylayrExitPrcs.NoticePrd = Convert.ToInt32(hiddenNtcPrdPrevious.Value);
            }
            objEntitylayrExitPrcs.Date = System.DateTime.Now;
     

            objBusinessExitProcs.UpdateExitPrcs(objEntitylayrExitPrcs);

            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_Emp_Exit_Process.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("hcm_Emp_Exit_Process_List.aspx?InsUpd=Upd");
            }

        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {

            clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
            clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntitylayrExitPrcs.ExitProcsId = int.Parse(hiddenExtPrcsId.Value);
            objEntitylayrExitPrcs.ConfrmStatus = 1;

            if (ddlStatus.SelectedItem.Value != "0")
            {
                objEntitylayrExitPrcs.ExitProcsStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            }
            objEntitylayrExitPrcs.ExitReason = txtRsn.Text;

            if (txtTermntDate.Text.Trim() != "")
            {
                objEntitylayrExitPrcs.ExitProcsDate = objCommon.textToDateTime(txtTermntDate.Text.Trim());
            }

            if (hiddenNotcprd.Value != "")
            {
                objEntitylayrExitPrcs.NoticePrd = Convert.ToInt32(hiddenNotcprd.Value);
            }
            else
            {
                objEntitylayrExitPrcs.NoticePrd = Convert.ToInt32(hiddenNtcPrdPrevious.Value);
            }
            objEntitylayrExitPrcs.Date = System.DateTime.Now;
        //evm-0024

            if (ddlEmployee.SelectedItem.Value != "0")
            {
                objEntitylayrExitPrcs.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
        //END
            objBusinessExitProcs.UpdateExitPrcs(objEntitylayrExitPrcs);

            Response.Redirect("hcm_Emp_Exit_Process_List.aspx?InsUpd=Conf");
    }


    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitylayrExitPrcs.ExitProcsId = int.Parse(hiddenExtPrcsId.Value);
        objEntitylayrExitPrcs.ConfrmStatus = 0;
        objBusinessExitProcs.UpdateConfrm(objEntitylayrExitPrcs);
        btnUpdateClose.Visible = true;
        btnSave.Visible = false;
        btnSaveClose.Visible = false;
        btnClear.Visible = false;
        //btnConfirm.Visible = true;
        btnCancel.Visible = true;
        hiddenView.Value = "";
        radioStaff.Enabled = true;
        radioWorker.Enabled = true;
        ddlEmployee.Enabled = true;
        ddlStatus.Enabled = true;
        txtRsn.Enabled = true;
        txtTermntDate.Enabled = true;
        EditView(hiddenExtPrcsId.Value);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopened", "SuccessReopened();", true);

      
    }


    protected void radioStaff_CheckedChanged(object sender, EventArgs e)
    {
        int intMode = 0;
        if (radioStaff.Checked == true)
        {
            intMode = 0;
        }
        else if (radioWorker.Checked == true)
        {
            intMode = 1;
        }
        LoadFormData(intMode);
    }


    protected void LoadFormData(int Mode)
    {
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitylayrExitPrcs.Mode = Mode;

        DataTable dtEmp = new DataTable();
        dtEmp = objBusinessExitProcs.ReadToddlEmployee(objEntitylayrExitPrcs);

        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteScrpt", "AutoCompleteScrpt();", true);

    }

}