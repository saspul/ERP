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
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Worker_hcm_Clearance_Form_Worker : System.Web.UI.Page
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

            LoadEmployee();         
            ddlEmployee.Focus();
            LoadLeave();
            //NEW
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableAprv=0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                     

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
            }

            btnApprove.Visible = false;
            btnReject.Visible = false;
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdateClose.Visible = true;

            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                HiddenDelView.Value = "FALSE";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId, intOrgId);
                lblEntry.Text = "Edit Clearance Form Worker";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                ddlLeave.Focus();
                ddlEmployee.Enabled = false;
                ddlLeave.Enabled = false;
                if (intEnableAdd != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = false;
                }
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenDelView.Value = "TRUE";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenViewId.Value = strId;
                Update(strId, intCorpId, intOrgId);

                //img1.Disabled = true;
                lblEntry.Text = "View Clearance Form Worker";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                ddlEmployee.Enabled = false;
                ddlLeave.Enabled = false;

                txtComments.Enabled = false;
                txtQpPassRemarks.Enabled = false;
                txtSimCardRemarks.Enabled = false;
                txtdrivingLicRemarks.Enabled = false;
                txtToolsAndCompanyRemarks.Enabled = false;
                txtClearanceTrafficRemarks.Enabled = false;
                txtMessAmountRemarks.Enabled = false;

                cbMessAmount.Enabled = false;
                cbClearanceTrafficDept.Enabled = false;
                cbToolsAndCompany.Enabled = false;
                cbDrivingLic.Enabled = false;
                cbSimCard.Enabled = false;
                cbQpPass.Enabled = false;
              
                if (Request.QueryString["Page"] != null)
                {
                    if (Request.QueryString["Page"] != "View")
                    {


                      intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Clearance_Approval_Form);
                      DataTable dtChildRols = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
                      if (dtChildRols.Rows.Count > 0)
                       {
                           string strChildRolDeftn = dtChildRols.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                     string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                     foreach (string strC_Role in strChildDefArrWords)
                     {
                      if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                      {
                        btnReject.Visible = true;
                       }
                      else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                     {
                        btnApprove.Visible = true;
                     }
                   
                      }
                   }

                        
                           
                       
                           
                       
                    }
                    divList.Visible = false;
                    HiddenFieldPage.Value = "Aprvl";
                }
                if (Request.QueryString["RFGP"] != null)
                {
                    btnCancel.Visible = false;
                    divList.Visible = false;
                }

            }
            else
            {
                lblEntry.Text = "Add Clearance Form Worker";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
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
                }
                ddlEmployee.Focus();
            }
           
        }
    }

    public class clsWBData
    {
        public string ROWID { get; set; }
        public string ITEM { get; set; }
        public string STATUS { get; set; }
        public string REMARKS { get; set; }
        public string TYPE { get; set; }
        public string DETAILID { get; set; }
        public string EVTACTION { get; set; }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityClearanceFormWorker.LeaveClrWkrID = 0;
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--" && ddlLeave.SelectedItem.Value != "--SELECT LEAVE--")
        {
            objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            objEntityClearanceFormWorker.LeaveID = Convert.ToInt32(ddlLeave.SelectedItem.Value);
            objEntityClearanceFormWorker.QpPass_Sts = (cbQpPass.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.SimCard_sts = (cbSimCard.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.DrivingLic_sts = (cbDrivingLic.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.Tools_sts = (cbToolsAndCompany.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.CLrTraffic_sts = (cbClearanceTrafficDept.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.MessAmount_sts = (cbMessAmount.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.Comments = txtComments.Text.Trim();
            objEntityClearanceFormWorker.QpPass = txtQpPassRemarks.Text.Trim();
            objEntityClearanceFormWorker.SimCard = txtSimCardRemarks.Text.Trim();
            objEntityClearanceFormWorker.DrivingLic = txtdrivingLicRemarks.Text.Trim();
            objEntityClearanceFormWorker.Tools = txtToolsAndCompanyRemarks.Text.Trim();
            objEntityClearanceFormWorker.CLrTraffic = txtClearanceTrafficRemarks.Text.Trim();
            objEntityClearanceFormWorker.MessAmount = txtMessAmountRemarks.Text.Trim();
            objEntityClearanceFormWorker.Date = DateTime.Now;

            List<clsEntityClearanceFormWorkerDetail> objEntityDetilsList = new List<clsEntityClearanceFormWorkerDetail>();
            if (hiddenTotalData.Value != "")
            {
                string jsonData = hiddenTotalData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsWBData> objWBDataList = new List<clsWBData>();
                //   UserData  data
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
                foreach (clsWBData objclsWBData in objWBDataList)
                {
                    clsEntityClearanceFormWorkerDetail objEntityDetails = new clsEntityClearanceFormWorkerDetail();
                    objEntityDetails.Particular = objclsWBData.ITEM;
                    objEntityDetails.Particular_sts = Convert.ToInt32(objclsWBData.STATUS);
                    objEntityDetails.Particular_Type = (objclsWBData.TYPE == "GATEPASS") ? 0 : 1;
                    objEntityDetails.ParticularRemarks = objclsWBData.REMARKS;
                    objEntityDetilsList.Add(objEntityDetails);
                }
            }
            objBusinessClearanceFormWorker.InsertClearanceFormWorker(objEntityClearanceFormWorker, objEntityDetilsList);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_Clearance_Form_Worker.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Ins");
            }
        }

    }
    public void Update(string strId, int intCorpId, int intOrgId)
    {
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
        objEntityClearanceFormWorker.CorpOffice_Id = intCorpId;
        objEntityClearanceFormWorker.Organisation_Id = intOrgId;
        objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strId);
        DataTable dtClrFormWkr = objBusinessClearanceFormWorker.ReadClearanceFormWorkerByID(objEntityClearanceFormWorker);
        DataTable dtClrFormWkrDtl = objBusinessClearanceFormWorker.ReadClearanceFormWkrDetailByID(objEntityClearanceFormWorker);
        if (dtClrFormWkr.Rows.Count > 0)
        {
            //           LVECLRWKR_ID,LVECLRWKR_USR_ID,HCM_LEAVE_CLEARANCE_FORM_WKR.LEAVE_ID,LVECLRWKR_COMMENTS,
            //LVECLRWKR_APPRVL_USR_ID,LVECLRWKR_APPRVL_STS,
            //LVECLRWKR_CNCL_USR_ID,GN_USERS.USR_NAME,
            //TO_CHAR(LEAVE_FROM_DATE,'dd-mm-yyyy') ||' TO '||TO_CHAR(LEAVE_TO_DATE,'dd-mm-yyyy') "DATE"

            if (dtClrFormWkr.Rows[0]["LVECLRWKR_QP_PASS_STS"].ToString() == "1")
                cbQpPass.Checked = true;
            else
                cbQpPass.Checked = false;
            if (dtClrFormWkr.Rows[0]["LVECLRWKR_SIM_CARD_STS"].ToString() == "1")
                cbSimCard.Checked = true;
            else
                cbSimCard.Checked = false;
            if (dtClrFormWkr.Rows[0]["LVECLRWKR_DRIVING_LIC_STS"].ToString() == "1")
                cbDrivingLic.Checked = true;
            else
                cbDrivingLic.Checked = false;
            if (dtClrFormWkr.Rows[0]["LVECLRWKR_TOOLS_STS"].ToString() == "1")
                cbToolsAndCompany.Checked = true;
            else
                cbToolsAndCompany.Checked = false;
            if (dtClrFormWkr.Rows[0]["LVECLRWKR_CLR_TRAFFIC_STS"].ToString() == "1")
                cbClearanceTrafficDept.Checked = true;
            else
                cbClearanceTrafficDept.Checked = false;
            if (dtClrFormWkr.Rows[0]["LVECLRWKR_MESS_AMT_STS"].ToString() == "1")
                cbMessAmount.Checked = true;
            else
                cbMessAmount.Checked = false;
            txtComments.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_COMMENTS"].ToString();
            txtQpPassRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_QP_PASS_RMKS"].ToString();
            txtSimCardRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_SIM_CARD_RMKS"].ToString();
            txtdrivingLicRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_DRIVING_LIC_RMKS"].ToString();
            txtToolsAndCompanyRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_TOOLS_RMKS"].ToString();
            txtClearanceTrafficRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_CLR_TRAFFIC_RMKS"].ToString();
            txtMessAmountRemarks.Text = dtClrFormWkr.Rows[0]["LVECLRWKR_MESS_AMT_RMKS"].ToString();

            //if (ddlEmployee.Items.FindByValue(dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString()) != null)
            //{
            //    ddlEmployee.Items.FindByValue(dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString()).Selected = true;
            //}


            if (ddlEmployee.Items.FindByValue(dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString()) != null)
                {
                    ddlEmployee.ClearSelection();
                    ddlEmployee.Items.FindByValue(dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString()).Selected = true;
                }
            
            else
            {

                string strDate = dtClrFormWkr.Rows[0]["EMPERDTL_FNAME"].ToString();
                if (strDate != "")
                {
                    strDate = dtClrFormWkr.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormWkr.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormWkr.Rows[0]["EMPERDTL_LNAME"].ToString();

                }
                else
                {
                    strDate = dtClrFormWkr.Rows[0]["USR_NAME"].ToString();
                }



                ListItem lst = new ListItem(strDate, dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString());
                ddlEmployee.Items.Insert(1, lst);

                SortDDL(ref this.ddlEmployee);
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByValue(dtClrFormWkr.Rows[0]["LVECLRWKR_USR_ID"].ToString()).Selected = true;
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
                DataTable dtDetails = objBusinessClearanceFormWorker.ReadEmployeeDtls(objEntityClearanceFormWorker);
                lblEmpNo.Text = dtDetails.Rows[0]["USR_CODE"].ToString();
                lblDesig.Text = dtDetails.Rows[0]["DESIGNATION"].ToString();

                clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaffs = new clsBusinessLayerClearanceFormStaff();
                clsEntityLayerClearanceFormStaff objEntityClearanceFormStaffs = new clsEntityLayerClearanceFormStaff();
                objEntityClearanceFormStaffs.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
                DataTable dtDivisions = objBusinessClearanceFormStaffs.ReadDivisionOfEmp(objEntityClearanceFormStaffs);
                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    if (strDivisions == "")
                    {
                        strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                    }
                    else
                    {
                        strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                    }
                }
                lblDivision.Text = strDivisions;
                lblDept.Text = dtDetails.Rows[0]["DEPARTMENT"].ToString();
                
            }
            LoadLeave();
            //if (ddlLeave.Items.FindByValue(dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString()) != null)
            //{
            //    ddlLeave.Items.FindByValue(dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString()).Selected = true;
            //}
            if (ddlLeave.Items.FindByValue(dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString()) != null)
            {
                ddlLeave.ClearSelection();
                ddlLeave.Items.FindByValue(dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString()).Selected = true;
            }

            else
            {

                string strDate = dtClrFormWkr.Rows[0]["DATE"].ToString();
                string final = "";
                string[] spitDayStr = strDate.Split('O');
                if (spitDayStr[1] == " ")
                {
                    final = strDate.Remove(10);
                }
                else
                {
                    final = strDate;
                }


                ListItem lst = new ListItem(strDate, dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString());
                ddlLeave.Items.Insert(1, lst);

                SortDDL(ref this.ddlLeave);
                ddlLeave.ClearSelection();
                ddlLeave.Items.FindByValue(dtClrFormWkr.Rows[0]["LEAVE_ID"].ToString()).Selected = true;
            }
            if (ddlLeave.SelectedItem.Value != "--SELECT LEAVE--")
            {
            objEntityClearanceFormWorker.LeaveID = Convert.ToInt32(ddlLeave.SelectedItem.Value);
            DataTable dtDetails = objBusinessClearanceFormWorker.ReadTrvlDtls(objEntityClearanceFormWorker);          
            if (dtDetails.Rows.Count > 0)
            {
                lblDateOfTravel.Text = dtDetails.Rows[0]["TRVL_DATE"].ToString();
                lblDateOfReturn.Text = dtDetails.Rows[0]["RETRN_DATE"].ToString();
            }

            }

            if (dtClrFormWkr.Rows[0]["LVECLRWKR_APPRVL_STS"].ToString() == "1" || dtClrFormWkr.Rows[0]["LVECLRWKR_APPRVL_STS"].ToString() == "2")
            {
                HiddenDelView.Value = "TRUE";
                btnClear.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                ddlEmployee.Enabled = false;
                ddlLeave.Enabled = false;

                txtComments.Enabled = false;
                txtQpPassRemarks.Enabled = false;
                txtSimCardRemarks.Enabled = false;
                txtdrivingLicRemarks.Enabled = false;
                txtToolsAndCompanyRemarks.Enabled = false;
                txtClearanceTrafficRemarks.Enabled = false;
                txtMessAmountRemarks.Enabled = false;

                cbMessAmount.Enabled = false;
                cbClearanceTrafficDept.Enabled = false;
                cbToolsAndCompany.Enabled = false;
                cbDrivingLic.Enabled = false;
                cbSimCard.Enabled = false;
                cbQpPass.Enabled = false;

            }


            

        }
        if (dtClrFormWkrDtl.Rows.Count > 0)
        {

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtClrFormWkrDtl);
            hiddenEdit.Value = strJson;
            //if (intEditOrView == 1)
            //{
            //    btnSave.Visible = false;
            //    btnSaveClose.Visible = false;

            //}
            //else if (intEditOrView == 2)
            //{
            //    cbxCnclStatus.Enabled = false;
            //    btnSave.Visible = false;
            //    btnSaveClose.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    hiddenView.Value = strJson;
            //}
        }
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

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strId);
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--" && ddlLeave.SelectedItem.Value != "--SELECT LEAVE--")
        {
            objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            objEntityClearanceFormWorker.LeaveID = Convert.ToInt32(ddlLeave.SelectedItem.Value);
            objEntityClearanceFormWorker.QpPass_Sts = (cbQpPass.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.SimCard_sts = (cbSimCard.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.DrivingLic_sts = (cbDrivingLic.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.Tools_sts = (cbToolsAndCompany.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.CLrTraffic_sts = (cbClearanceTrafficDept.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.MessAmount_sts = (cbMessAmount.Checked == false) ? 0 : 1;
            objEntityClearanceFormWorker.Comments = txtComments.Text.Trim();
            objEntityClearanceFormWorker.QpPass = txtQpPassRemarks.Text.Trim();
            objEntityClearanceFormWorker.SimCard = txtSimCardRemarks.Text.Trim();
            objEntityClearanceFormWorker.DrivingLic = txtdrivingLicRemarks.Text.Trim();
            objEntityClearanceFormWorker.Tools = txtToolsAndCompanyRemarks.Text.Trim();
            objEntityClearanceFormWorker.CLrTraffic = txtClearanceTrafficRemarks.Text.Trim();
            objEntityClearanceFormWorker.MessAmount = txtMessAmountRemarks.Text.Trim();
            objEntityClearanceFormWorker.Date = DateTime.Now;

            List<clsEntityClearanceFormWorkerDetail> objEntityDetilsInsertList = new List<clsEntityClearanceFormWorkerDetail>();
            List<clsEntityClearanceFormWorkerDetail> objEntityDetilsUpdateList = new List<clsEntityClearanceFormWorkerDetail>();
            List<clsEntityClearanceFormWorkerDetail> objEntityDetilsDeleteList = new List<clsEntityClearanceFormWorkerDetail>();
            if (hiddenTotalData.Value != "")
            {
                string jsonData = hiddenTotalData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsWBData> objWBDataList = new List<clsWBData>();
                //   UserData  data
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
                foreach (clsWBData objclsWBData in objWBDataList)
                {
                    if (objclsWBData.EVTACTION == "INS")
                    {
                        clsEntityClearanceFormWorkerDetail objEntityDetails = new clsEntityClearanceFormWorkerDetail();
                        objEntityDetails.Particular = objclsWBData.ITEM;
                        objEntityDetails.Particular_sts = Convert.ToInt32(objclsWBData.STATUS);
                        objEntityDetails.Particular_Type = (objclsWBData.TYPE == "GATEPASS") ? 0 : 1;
                        objEntityDetails.ParticularRemarks = objclsWBData.REMARKS;
                        objEntityDetilsInsertList.Add(objEntityDetails);
                    }
                    else
                    {
                        clsEntityClearanceFormWorkerDetail objEntityDetails = new clsEntityClearanceFormWorkerDetail();
                        objEntityDetails.Particular = objclsWBData.ITEM;
                        objEntityDetails.Particular_sts = Convert.ToInt32(objclsWBData.STATUS);
                        objEntityDetails.Particular_Type = (objclsWBData.TYPE == "GATEPASS") ? 0 : 1;
                        objEntityDetails.ParticularRemarks = objclsWBData.REMARKS;
                        objEntityDetails.LeaveClrWkrDtlID = Convert.ToInt32(objclsWBData.DETAILID);
                        objEntityDetilsUpdateList.Add(objEntityDetails);
                    }
                }
            }
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
            {
                strCanclDtlId = hiddenCanclDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');
            }
            //Cancel the rows that have been cancelled when editing in Detail table
            foreach (string strDtlId in strarrCancldtlIds)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);
                    clsEntityClearanceFormWorkerDetail objEntityDetails = new clsEntityClearanceFormWorkerDetail();
                    objEntityDetails.LeaveClrWkrDtlID = Convert.ToInt32(strDtlId);
                    objEntityDetilsDeleteList.Add(objEntityDetails);

                }
            }

            objBusinessClearanceFormWorker.UpdateClearanceFormWorker(objEntityClearanceFormWorker, objEntityDetilsInsertList, objEntityDetilsUpdateList, objEntityDetilsDeleteList);
            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_Clearance_Form_Worker.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("hcm_Clearance_Form_WorkerList.aspx?InsUpd=Upd");
            }
        }
    }

    public void LoadLeave()
    {
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (Request.QueryString["Id"] == null && Request.QueryString["ViewId"] == null)         
        {
            objEntityClearanceFormWorker.ApprvStatus = 1;
        }

        DataTable dtCountryList = objBusinessClearanceFormWorker.ReadLeave(objEntityClearanceFormWorker);
        ddlLeave.Items.Clear();

        foreach (DataRow rowDepnt in dtCountryList.Rows)
        {
            string strDate = rowDepnt["DATE"].ToString();
            string[] spitDayStr = strDate.Split('O');
            if (spitDayStr[1] == " ")
            {
                rowDepnt["DATE"] = strDate.Remove(10);
            }
                           
        }


        if (dtCountryList.Rows.Count > 0)
        {
            ddlLeave.DataSource = dtCountryList;
            ddlLeave.DataTextField = "DATE";
            ddlLeave.DataValueField = "LEAVE_ID";
            ddlLeave.DataBind();
        }
        ddlLeave.Items.Insert(0, "--SELECT LEAVE--");
    }
    public void LoadEmployee()
    {
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCountryList = objBusinessClearanceFormWorker.ReadEmployee(objEntityClearanceFormWorker);


        foreach (DataRow rowDepnt in dtCountryList.Rows)
        {
            string strDate = rowDepnt["EMPERDTL_FNAME"].ToString();
            if (strDate != "")
            {
                strDate = rowDepnt["EMPERDTL_FNAME"].ToString() + " " + rowDepnt["EMPERDTL_MNAME"].ToString() + " " + rowDepnt["EMPERDTL_LNAME"].ToString();
                rowDepnt["USR_NAME"] = strDate;
            }

        }


        if (dtCountryList.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtCountryList;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
            objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            DataTable dtDetails = objBusinessClearanceFormWorker.ReadEmployeeDtls(objEntityClearanceFormWorker);
            lblEmpNo.Text = dtDetails.Rows[0]["USR_CODE"].ToString();
            lblDesig.Text = dtDetails.Rows[0]["DESIGNATION"].ToString();

            lblDept.Text = dtDetails.Rows[0]["DEPARTMENT"].ToString();


            clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaffs = new clsBusinessLayerClearanceFormStaff();
            clsEntityLayerClearanceFormStaff objEntityClearanceFormStaffs = new clsEntityLayerClearanceFormStaff();
            objEntityClearanceFormStaffs.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            DataTable dtDivisions = objBusinessClearanceFormStaffs.ReadDivisionOfEmp(objEntityClearanceFormStaffs);
            string strDivisions = "";
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                }
                else
                {
                    strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                }
            }
            lblDivision.Text = strDivisions;
            LoadLeave();
        }
        else
        {
            lblEmpNo.Text = "";
            lblDesig.Text = "";

            lblDept.Text = "";
            lblDivision.Text = "";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
    }

    protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLeave.SelectedItem.Value != "--SELECT LEAVE--")
        {
            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
            objEntityClearanceFormWorker.LeaveID = Convert.ToInt32(ddlLeave.SelectedItem.Value);
            DataTable dtDetails = objBusinessClearanceFormWorker.ReadTrvlDtls(objEntityClearanceFormWorker);
            //string strDates = ddlLeave.SelectedItem.Text;
            //try
            //{
            //    lblDateOfTravel.Text = strDates.Substring(0, 10);
            //    lblDateOfReturn.Text = strDates.Substring(strDates.Length - 10); 
            //}
            //catch (Exception)
            //{

            //    lblDateOfTravel.Text = "";
            //    lblDateOfReturn.Text = ""; 
            //}
            if (dtDetails.Rows.Count > 0)
            {
                lblDateOfTravel.Text = dtDetails.Rows[0]["TRVL_DATE"].ToString();
                lblDateOfReturn.Text = dtDetails.Rows[0]["RETRN_DATE"].ToString();
            }
            else
            {
                lblDateOfTravel.Text = "";
                lblDateOfReturn.Text = "";
            }

        }
        else
        {
            lblDateOfTravel.Text = "";
            lblDateOfReturn.Text = ""; 
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityClearanceFormWorker.ApprvStatus = 1;

        // objEntityClearanceFormWorker.User_Id = 1;

        objEntityClearanceFormWorker.Date = DateTime.Today;

                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strId);
        //objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);

        objBusinessClearanceFormWorker.ApproveClearanceFormWorker(objEntityClearanceFormWorker);
        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx?InsUpd=Aprvd");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        clsBusinessLayerClearanceFormWorker objBusinessClearanceFormWorker = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker = new clsEntityLayerClearanceFormWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormWorker.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormWorker.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormWorker.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityClearanceFormWorker.ApprvStatus = 2;

        // objEntityClearanceFormWorker.User_Id = 1;

        objEntityClearanceFormWorker.Date = DateTime.Today;
        objEntityClearanceFormWorker.CancelReason = TextBox1.Text;
        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityClearanceFormWorker.LeaveClrWkrID = Convert.ToInt32(strId);
        //objEntityClearanceFormWorker.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);

        objBusinessClearanceFormWorker.RejectClearanceFormWorker(objEntityClearanceFormWorker);
        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx?InsUpd=Rejctd");
    }
}