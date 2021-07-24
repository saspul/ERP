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
using System.Web.Script.Services;
using System.Web.Services;
using System.IO;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Staff_hcm_Clearance_Form_Staff : System.Web.UI.Page
{
    //Enumeration for identifying apllication typeid 
    private enum SUBJECTS
    {

        MOBILE_NUMBER = 1,
        CAR_KEY_AND_DOCUMENTS = 2,
        DRIVING_LICENCE = 3,
        H2SBA_CARDS = 4,
        OFFICIAL_KEYS = 5,
        IMPREST = 6,
        STAFF_ADVANCE = 7,
        TELEPHONE_BILLS_PERSONAL = 8,
        IT_CLEARANCE = 9,
        EXIT_PERMIT = 10
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        cbMobNo.Attributes.Add("onkeypress", "return isTag(event)");
        cbCarKeysDoc.Attributes.Add("onkeypress", "return isTag(event)");
        cbDrivingLic.Attributes.Add("onkeypress", "return isTag(event)");
        cbH2SBA.Attributes.Add("onkeypress", "return isTag(event)");
        cbOfficialKey.Attributes.Add("onkeypress", "return isTag(event)");
        cbImpreset.Attributes.Add("onkeypress", "return isTag(event)");
        cbStaffAdvance.Attributes.Add("onkeypress", "return isTag(event)");
        cbTeleBillsPer.Attributes.Add("onkeypress", "return isTag(event)");
        cbItClearanc.Attributes.Add("onkeypress", "return isTag(event)");

        DropDownEmployeeDataStore();
        if (!IsPostBack)
        {

            LoadEmployee();
            LoadAllEmployeeDDL();
         
            ddlEmployee.Focus();
            //NEW
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
            clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles

            //intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Consultancy_Master);
            //DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            //if (dtChildRol.Rows.Count > 0)
            //{
            //    string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
            //    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            //    foreach (string strC_Role in strChildDefArrWords)
            //    {
            //        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
            //        {
            //            intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //        }
            //        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
            //        {
            //            intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //        }
            //        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
            //        {
            //            intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

            //        }
            //        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
            //        {
            //            //future

            //        }
            //        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
            //        {
            //            //future

            //        }
            //        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
            //        {
            //            //future

            //        }

            //    }
            //}
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdateClose.Visible = true;

            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }

            btnConfirm.Visible = false;
            btnReject.Visible = false;
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                HiddenFieldCancelPage.Value = "LR";
                HiddenDelView.Value = "FALSE";

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenFieldQryStringId.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //string strId = Request.QueryString["Id"].ToString();
                objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);
                DataTable dtEmpDetails = objBusinessClearanceFormStaff.ReadLeaveDtls(objEntityClearanceFormStaff);
                if (dtEmpDetails.Rows.Count > 0)
                {
                    //HR_LEAVE_REQST_MSTR.USR_ID,USR_NAME,USR_CODE,GN_DESIGNATIONS.DSGN_NAME "DESIGNATION",
                    //GN_CORP_DIVISIONS.CPRDIV_NAME "DIVISION",GN_CORP_DEPTS.CPRDEPT_NAME "DEPARTMENT",
                    //TO_CHAR(LEAVE_FROM_DATE,'DD-MM-YYYY') "LEAVE_FROM_DATE",TO_CHAR(LEAVE_TO_DATE,'DD-MM-YYYY') "LEAVE_TO_DATE",
                    //LEAVE_NUM_DAYS,LEAVE_CLEARANCE_STS


                    objEntityClearanceFormStaff.Empid = Convert.ToInt32(dtEmpDetails.Rows[0]["USR_ID"]);
                    DataTable dtDivisions = objBusinessClearanceFormStaff.ReadDivisionOfEmp(objEntityClearanceFormStaff);
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


                    string strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString();
                    if (strDate != "")
                    {
                        strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_LNAME"].ToString();
                    }
                    else
                    {
                        strDate = dtEmpDetails.Rows[0]["USR_NAME"].ToString();
                    }


                    lblEmployeeName.Text = strDate;
                    lblEmpNo.Text = dtEmpDetails.Rows[0]["USR_CODE"].ToString();
                    lblDesig.Text = dtEmpDetails.Rows[0]["DESIGNATION"].ToString();                 
                    lblDept.Text = dtEmpDetails.Rows[0]["DEPARTMENT"].ToString();
                    lblDateOfTravel.Text = dtEmpDetails.Rows[0]["LEAVE_FROM_DATE"].ToString();
                    lblDateOfReturn.Text = dtEmpDetails.Rows[0]["LEAVE_TO_DATE"].ToString();
                    if (dtEmpDetails.Rows[0]["LEAVE_CLEARANCE_STS"].ToString() == "1")
                    {
                        //update mode

                        if (dtEmpDetails.Rows[0]["LVECLRSTF_APPRVL_STS"].ToString() == "1" || dtEmpDetails.Rows[0]["LVECLRSTF_CNCL_USR_ID"].ToString() != "")
                        {
                            lblEntry.Text = "View Clearance Form Staff";
                            HiddenDelView.Value = "TRUE";
                            btnAdd.Visible = false;
                            btnAddClose.Visible = false;
                            ddlEmployee.Enabled = false;
                            btnUpdate.Visible = false;
                            btnUpdateClose.Visible = false;
                        }
                        else
                        {
                            lblEntry.Text = "Edit Clearance Form Staff";
                            btnAdd.Visible = false;
                            btnAddClose.Visible = false;
                            //ddlEmployee.Enabled = false;
                        }

                        Update(strId, intCorpId, intOrgId);
                       
                       
                      
                       
                    }
                    else
                    {
                        //insert mode
                        lblEntry.Text = "Add Clearance Form Staff";
                        btnUpdate.Visible = false;
                        btnUpdateClose.Visible = false;
                        btnAdd.Visible = false;
                        btnAddClose.Visible = true;
                        btnClear.Visible = true;

                       
                      

                    }
                }

             
                btnClear.Visible = false;



            }
            ////when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenFieldCancelPage.Value = "LA";
                HiddenDelView.Value = "TRUE";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);     
                objEntityClearanceFormStaff.ApprvStatus = 1;

               objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);
               DataTable dtClrFormStaff = objBusinessClearanceFormStaff.ReadClearanceFormStaffByID(objEntityClearanceFormStaff);

              

        if (dtClrFormStaff.Rows.Count > 0)
        {
            DataTable dtEmpDetails = new DataTable();
            objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(dtClrFormStaff.Rows[0]["LEAVE_ID"].ToString());
            if (dtClrFormStaff.Rows[0]["LVECLRSTF_MODE"].ToString() == "0")
            {
               dtEmpDetails = objBusinessClearanceFormStaff.ReadLeaveDtls(objEntityClearanceFormStaff);
            }
            else
            {
                dtEmpDetails = objBusinessClearanceFormStaff.ReadLeaveDtlsResg(objEntityClearanceFormStaff);
                HiddenFieldParentPage.Value = "Resg";
            }

        
         
            if (dtEmpDetails.Rows.Count > 0)
            {

                objEntityClearanceFormStaff.Empid = Convert.ToInt32(dtEmpDetails.Rows[0]["USR_ID"]);
                DataTable dtDivisions = objBusinessClearanceFormStaff.ReadDivisionOfEmp(objEntityClearanceFormStaff);
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
                string strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString();
                if (strDate != "")
                {
                    strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_LNAME"].ToString();
                }
                else
                {
                    strDate = dtEmpDetails.Rows[0]["USR_NAME"].ToString();
                }


                lblEmployeeName.Text = strDate;
                lblEmpNo.Text = dtEmpDetails.Rows[0]["USR_CODE"].ToString();
                lblDesig.Text = dtEmpDetails.Rows[0]["DESIGNATION"].ToString();
                lblDivision.Text = strDivisions;
                lblDept.Text = dtEmpDetails.Rows[0]["DEPARTMENT"].ToString();
                if (dtClrFormStaff.Rows[0]["LVECLRSTF_MODE"].ToString() == "0")
                {
                    lblDateOfTravel.Text = dtEmpDetails.Rows[0]["LEAVE_FROM_DATE"].ToString();
                    lblDateOfReturn.Text = dtEmpDetails.Rows[0]["LEAVE_TO_DATE"].ToString();
                }
                if (dtEmpDetails.Rows[0]["LVECLRSTF_APPRVL_STS"].ToString() == "1" || dtEmpDetails.Rows[0]["LVECLRSTF_CNCL_USR_ID"].ToString() != "")
                {

                    lblEntry.Text = "View Clearance Form Staff";
                    btnAdd.Visible = false;
                    btnAddClose.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    ddlEmployee.Enabled = false;
                    btnConfirm.Visible = false;
                    btnReject.Visible = false;
                }
                else
                {

                    lblEntry.Text = "Edit Clearance Form Staff";
                    btnAdd.Visible = false;
                    btnAddClose.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    ddlEmployee.Enabled = false;


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
                                 btnConfirm.Visible = true;
                            }

                        }
                    }
                  
                   
                }
            }
        }




                Update(strId, intCorpId, intOrgId);



            }



            //Resignation form
            else if (Request.QueryString["ResgId"] != null)
            {
                HiddenFieldParentPage.Value = "Resg";


                HiddenFieldCancelPage.Value = "Resg";
                HiddenDelView.Value = "FALSE";
                string strId = Request.QueryString["ResgId"].ToString();
                objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);
                DataTable dtEmpDetails = objBusinessClearanceFormStaff.ReadLeaveDtlsResg(objEntityClearanceFormStaff);
                if (dtEmpDetails.Rows.Count > 0)
                {


                    objEntityClearanceFormStaff.Empid = Convert.ToInt32(dtEmpDetails.Rows[0]["USR_ID"]);
                    DataTable dtDivisions = objBusinessClearanceFormStaff.ReadDivisionOfEmp(objEntityClearanceFormStaff);
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


                    string strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString();
                    if (strDate != "")
                    {
                        strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtEmpDetails.Rows[0]["EMPERDTL_LNAME"].ToString();
                    }
                    else
                    {
                        strDate = dtEmpDetails.Rows[0]["USR_NAME"].ToString();
                    }


                    lblEmployeeName.Text = strDate;
                    lblEmpNo.Text = dtEmpDetails.Rows[0]["USR_CODE"].ToString();
                    lblDesig.Text = dtEmpDetails.Rows[0]["DESIGNATION"].ToString();
                    lblDept.Text = dtEmpDetails.Rows[0]["DEPARTMENT"].ToString();
                    if (dtEmpDetails.Rows[0]["RSGNTN_CLEARANCE_STS"].ToString() == "1")
                    {
                        //update mode

                        if (dtEmpDetails.Rows[0]["LVECLRSTF_APPRVL_STS"].ToString() == "1" || dtEmpDetails.Rows[0]["LVECLRSTF_CNCL_USR_ID"].ToString() != "")
                        {
                            lblEntry.Text = "View Clearance Form Staff";
                            HiddenDelView.Value = "TRUE";
                            btnAdd.Visible = false;
                            btnAddClose.Visible = false;
                            ddlEmployee.Enabled = false;
                            btnUpdate.Visible = false;
                            btnUpdateClose.Visible = false;
                        }
                        else
                        {
                            lblEntry.Text = "Edit Clearance Form Staff";
                            btnAdd.Visible = false;
                            btnAddClose.Visible = false;
                            //ddlEmployee.Enabled = false;
                        }

                        Update(strId, intCorpId, intOrgId);




                    }
                    else
                    {
                        //insert mode
                        lblEntry.Text = "Add Clearance Form Staff";
                        btnUpdate.Visible = false;
                        btnUpdateClose.Visible = false;
                        btnAdd.Visible = false;
                        btnAddClose.Visible = true;
                        btnClear.Visible = true;




                    }
                }


                btnClear.Visible = false;





            }
        }
    }

    public class clsWBData
    {
        public string ROWID { get; set; }
        public string ITEM { get; set; }
        public string EMPID { get; set; }
        public string REMARKS { get; set; }
        public string TYPE { get; set; }
        public string DETAILID { get; set; }
        public string EVTACTION { get; set; }
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
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
            //string strId = Request.QueryString["Id"].ToString();
            objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);
            objEntityClearanceFormStaff.ClrnceStaffMode = 0;
        }
        if (Request.QueryString["ResgId"] != null)
        {
            objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(Request.QueryString["ResgId"].ToString());
            objEntityClearanceFormStaff.ClrnceStaffMode = 1;
        }
        // ID
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CLEARANCE_FORM_STAFF);
        objEntityCommon.CorporateID = objEntityClearanceFormStaff.CorpOffice_Id;
        objEntityCommon.Organisation_Id = objEntityClearanceFormStaff.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(strNextId);
        objEntityClearanceFormStaff.Empid = objEntityClearanceFormStaff.User_Id;
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityClearanceFormStaff.TakeOverEmpID = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            objEntityClearanceFormStaff.Comments = txtComments.Text.Trim();
            objEntityClearanceFormStaff.Date = DateTime.Now;


            //file
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF);
            if (FileUploadLicence.HasFile)
            {
                // GET FILE EXTENSION
                string strFileExt;
                objEntityClearanceFormStaff.ActualFileName = FileUploadLicence.FileName;
                strFileExt = FileUploadLicence.FileName.Substring(FileUploadLicence.FileName.LastIndexOf('.') + 1).ToLower();
                string strImageName = intImageSection.ToString() + "_" + objEntityClearanceFormStaff.LeaveClrStaffID + "_" + FileUploadLicence.FileName + "." + strFileExt;
                objEntityClearanceFormStaff.FileName = strImageName;
            }

      

            //store sub data
            List<clsEntityClearanceFormStaffSub> objEntitySubList = new List<clsEntityClearanceFormStaffSub>();
            clsEntityClearanceFormStaffSub objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.MOBILE_NUMBER);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbMobNo.Checked == false)
            {
                if (ddlMobileNoHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlMobileNoHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtMobNoRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbMobNo.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.CAR_KEY_AND_DOCUMENTS);
            objEntitySub.HandedOverEmpID = 0;
            objEntitySub.SubjectRemarks = "";
            if (cbCarKeysDoc.Checked == false)
            {
                if (ddlCarKeyAndDoc.SelectedItem.Value != "--SELECT EMPLOYEE--")
                objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlCarKeyAndDoc.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtCarKeysDocRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbCarKeysDoc.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.DRIVING_LICENCE);
            objEntitySub.SubjectRemarks = ""; objEntitySub.HandedOverEmpID = 0;
            if (cbDrivingLic.Checked == false)
            {

                if (ddlDrvLicHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlDrvLicHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtdrivingLicRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbDrivingLic.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.H2SBA_CARDS);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbH2SBA.Checked == false)
            {
                if (ddlH2SBAHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlH2SBAHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtH2SBACardsRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbH2SBA.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.OFFICIAL_KEYS);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbOfficialKey.Checked == false)
            {
                if (ddlOfficialKeysHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlOfficialKeysHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtOfficialKeyRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbOfficialKey.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.IMPREST);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbImpreset.Checked == false)
            {
                if (ddlImprestHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlImprestHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtImpresetRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbImpreset.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.STAFF_ADVANCE);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbStaffAdvance.Checked == false)
            {
                if (ddlStaffAdvanceHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlStaffAdvanceHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtStaffAdvanceRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbStaffAdvance.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.TELEPHONE_BILLS_PERSONAL);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbTeleBillsPer.Checked == false)
            {
                if (ddlTelephoneBillsHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlTelephoneBillsHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtTeleBillsPerRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbTeleBillsPer.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.IT_CLEARANCE);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbItClearanc.Checked == false)
            {
                if (ddlItClearanceHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlItClearanceHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtItClearanceRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbItClearanc.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            List<clsEntityClearanceFormStaffDetail> objEntityDetilsList = new List<clsEntityClearanceFormStaffDetail>();
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
                    clsEntityClearanceFormStaffDetail objEntityDetails = new clsEntityClearanceFormStaffDetail();
                    objEntityDetails.Subject = objclsWBData.ITEM;
                    objEntityDetails.HandedOverEmpID = Convert.ToInt32(objclsWBData.EMPID);
                    objEntityDetails.Subject_Type = (objclsWBData.TYPE == "GATEPASS") ? 1 : 0;
                    objEntityDetails.SubjectRemarks = objclsWBData.REMARKS;
                    objEntityDetilsList.Add(objEntityDetails);
                }
            }

          
                objBusinessClearanceFormStaff.InsertClearanceFormStaff(objEntityClearanceFormStaff, objEntityDetilsList, objEntitySubList);
                if (FileUploadLicence.HasFile)
                {
                    FileUploadLicence.SaveAs(Server.MapPath(strImgPath) + objEntityClearanceFormStaff.FileName);
                }
                if (HiddenFieldParentPage.Value != "Resg")
                {
                    Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request.aspx?Id=" + HiddenFieldQryStringId.Value + "&InsUpd=InsStf");
                }
                else
                {
                    Response.Redirect("/HCM/HCM_Master/hcm_Exit_Management/hcm_Resignation_Master/hcm_Resignation_Master.aspx?Ins=InsStf");
                }
        }

    }
    public void Update(string strId, int intCorpId, int intOrgId)
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityClearanceFormStaff.CorpOffice_Id = intCorpId;
        objEntityClearanceFormStaff.Organisation_Id = intOrgId;
        objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);

        if (Request.QueryString["ViewId"] != null)
        {
            objEntityClearanceFormStaff.ApprvStatus = 1;
        }

        if (HiddenDelView.Value == "TRUE")
        {
         
            ddlMobileNoHndOvr.Enabled = false;
            ddlCarKeyAndDoc.Enabled = false;
            ddlDrvLicHndOvr.Enabled = false;
            ddlH2SBAHndOvr.Enabled = false;
            ddlOfficialKeysHndOvr.Enabled = false;
            ddlImprestHndOvr.Enabled = false;
            ddlStaffAdvanceHndOvr.Enabled = false;
            ddlTelephoneBillsHndOvr.Enabled = false;
            ddlItClearanceHndOvr.Enabled = false;

            txtMobNoRemarks.Enabled = false;
            cbMobNo.Enabled = false;
            txtCarKeysDocRemarks.Enabled = false;
            cbCarKeysDoc.Enabled = false;
            txtdrivingLicRemarks.Enabled = false;
            cbDrivingLic.Enabled = false;
            txtH2SBACardsRemarks.Enabled = false;
            cbH2SBA.Enabled = false;
            txtOfficialKeyRemarks.Enabled = false;

            cbOfficialKey.Enabled = false;
            txtImpresetRemarks.Enabled = false;
            cbImpreset.Enabled = false;
            txtStaffAdvanceRemarks.Enabled = false;
            cbStaffAdvance.Enabled = false;
            txtTeleBillsPerRemarks.Enabled = false;
            cbTeleBillsPer.Enabled = false;
            txtItClearanceRemarks.Enabled = false;
            cbItClearanc.Enabled = false;
            txtComments.Enabled = false;
        }
       

        DataTable dtClrFormStaff = objBusinessClearanceFormStaff.ReadClearanceFormStaffByID(objEntityClearanceFormStaff);


        if (dtClrFormStaff.Rows.Count > 0)
        {

            HiddenFieldMstrTblId.Value = dtClrFormStaff.Rows[0]["LVECLRSTF_ID"].ToString();
            objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(HiddenFieldMstrTblId.Value);

            if (ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString()) != null)
            {
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString()).Selected = true;
            }

            else
            {


                string strDate = dtClrFormStaff.Rows[0]["EMPERDTL_FNAME"].ToString();
                if (strDate != "")
                {
                    strDate = dtClrFormStaff.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaff.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaff.Rows[0]["EMPERDTL_LNAME"].ToString();

                }
                else
                {
                    strDate = dtClrFormStaff.Rows[0]["TAKE_OVR_USR_NAME"].ToString();
                }


                ListItem lst = new ListItem(strDate, dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString());
                ddlEmployee.Items.Insert(1, lst);

                SortDDL(ref this.ddlEmployee);
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString()).Selected = true;
            }

            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormStaffw = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormStaffw = new clsEntityLayerClearanceFormWorker();
            objEntityClearanceFormStaffw.Empid = Convert.ToInt32(dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString());
            DataTable dtDetails = objBusinessClearanceFormStaffw.ReadEmployeeDtls(objEntityClearanceFormStaffw);

            clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaffs = new clsBusinessLayerClearanceFormStaff();
            clsEntityLayerClearanceFormStaff objEntityClearanceFormStaffs = new clsEntityLayerClearanceFormStaff();
            objEntityClearanceFormStaffs.Empid = Convert.ToInt32(dtClrFormStaff.Rows[0]["LVECLRSTF_TAKE_OVR_USR_ID"].ToString());
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
            lblDesigTakeOverEmp.Text = dtDetails.Rows[0]["DESIGNATION"].ToString();
            lblDivisionTakeOverEmp.Text = strDivisions;




            hiddenLicenceFile.Value = dtClrFormStaff.Rows[0]["LVECLRSTF_FILE_NAME"].ToString();

            if (hiddenLicenceFile.Value != null && hiddenLicenceFile.Value != "")
            {
                //    divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF) + hiddenLicenceFile.Value;
                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";

                string strFileExt = strImagePath.Substring(strImagePath.LastIndexOf('.') + 1).ToLower();
                string strImage;
                 if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                 {
                     strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                     strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                     strImage += " <img src=\"" + strImagePath + "\"/>";
                     strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                     strImage += "</div>";
                    
                 }
                 else
                 {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                 }
                 divImageDisplay.InnerHtml = strImage;
            }
            txtComments.Text = dtClrFormStaff.Rows[0]["LVECLRSTF_COMMENTS"].ToString();
        }

       
        DataTable dtClrFormStaffSub = objBusinessClearanceFormStaff.ReadClrFormStaffSubByID(objEntityClearanceFormStaff);
        DataTable dtClrFormStaffDetail = objBusinessClearanceFormStaff.ReadClrFormStaffDetailByID(objEntityClearanceFormStaff);
        if (dtClrFormStaffSub.Rows.Count > 0)
        {
            for (int intRowCount = 0; intRowCount < dtClrFormStaffSub.Rows.Count; intRowCount++)
            {

                if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.MOBILE_NUMBER))
                {
                    //ddlMobileNoHndOvr

                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlMobileNoHndOvr.ClearSelection();
                            ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlMobileNoHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlMobileNoHndOvr);
                            ddlMobileNoHndOvr.ClearSelection();
                            ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn1.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt1.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view1.Visible = false;
                    }
                    txtMobNoRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbMobNo.Checked = true;
                    }

                   



                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"])  == Convert.ToInt32(SUBJECTS.CAR_KEY_AND_DOCUMENTS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlCarKeyAndDoc.ClearSelection();
                            ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {

                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlCarKeyAndDoc.Items.Insert(1, lst);

                            SortDDL(ref this.ddlCarKeyAndDoc);
                            ddlCarKeyAndDoc.ClearSelection();
                            ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn2.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt2.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view2.Visible = false;
                    }
                    txtCarKeysDocRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbCarKeysDoc.Checked = true;
                    }
                 
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.DRIVING_LICENCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlDrvLicHndOvr.ClearSelection();
                            ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString(), dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlDrvLicHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlDrvLicHndOvr);
                            ddlDrvLicHndOvr.ClearSelection();
                            ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn3.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt3.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view3.Visible = false;
                    }
                    txtdrivingLicRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbDrivingLic.Checked = true;
                    }
                   
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.H2SBA_CARDS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlH2SBAHndOvr.ClearSelection();
                            ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {

                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlH2SBAHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlH2SBAHndOvr);
                            ddlH2SBAHndOvr.ClearSelection();
                            ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn4.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt4.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view4.Visible = false;
                    }
                    txtH2SBACardsRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbH2SBA.Checked = true;
                    }
                  
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"])  == Convert.ToInt32(SUBJECTS.OFFICIAL_KEYS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlOfficialKeysHndOvr.ClearSelection();
                            ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlOfficialKeysHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlOfficialKeysHndOvr);
                            ddlOfficialKeysHndOvr.ClearSelection();
                            ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn5.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt5.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view5.Visible = false;
                    }
                    txtOfficialKeyRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbOfficialKey.Checked = true;
                    }
                  
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"])  == Convert.ToInt32(SUBJECTS.IMPREST))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlImprestHndOvr.ClearSelection();
                            ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlImprestHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlImprestHndOvr);
                            ddlImprestHndOvr.ClearSelection();
                            ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn6.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt6.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view6.Visible = false;
                    }
                    txtImpresetRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbImpreset.Checked = true;
                    }
                   
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.STAFF_ADVANCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlStaffAdvanceHndOvr.ClearSelection();
                            ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlStaffAdvanceHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlStaffAdvanceHndOvr);
                            ddlStaffAdvanceHndOvr.ClearSelection();
                            ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn7.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt7.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view7.Visible = false;
                    }
                    txtStaffAdvanceRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbStaffAdvance.Checked = true;
                    }
                  
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.TELEPHONE_BILLS_PERSONAL))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlTelephoneBillsHndOvr.ClearSelection();
                            ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlTelephoneBillsHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlTelephoneBillsHndOvr);
                            ddlTelephoneBillsHndOvr.ClearSelection();
                            ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn8.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt8.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view8.Visible = false;
                    }
                    txtTeleBillsPerRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbTeleBillsPer.Checked = true;
                    }
                   
                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["SUBJECT_ID"])  == Convert.ToInt32(SUBJECTS.IT_CLEARANCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlItClearanceHndOvr.ClearSelection();
                            ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["TAKE_OVR_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlItClearanceHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlItClearanceHndOvr);
                            ddlItClearanceHndOvr.ClearSelection();
                            ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn9.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt9.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view9.Visible = false;
                    }
                    txtItClearanceRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbItClearanc.Checked = true;
                    }
                  
                }
            }

        }
        if (dtClrFormStaffDetail.Rows.Count > 0)
        {
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtClrFormStaffDetail);
            hiddenEdit.Value = strJson;
            
        }
    }
    public void UpdateResg(string strId, int intCorpId, int intOrgId)
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityClearanceFormStaff.CorpOffice_Id = intCorpId;
        objEntityClearanceFormStaff.Organisation_Id = intOrgId;
        objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);

        if (Request.QueryString["ViewId"] != null)
        {
            objEntityClearanceFormStaff.ApprvStatus = 1;
        }

        if (HiddenDelView.Value == "TRUE")
        {

            ddlMobileNoHndOvr.Enabled = false;
            ddlCarKeyAndDoc.Enabled = false;
            ddlDrvLicHndOvr.Enabled = false;
            ddlH2SBAHndOvr.Enabled = false;
            ddlOfficialKeysHndOvr.Enabled = false;
            ddlImprestHndOvr.Enabled = false;
            ddlStaffAdvanceHndOvr.Enabled = false;
            ddlTelephoneBillsHndOvr.Enabled = false;
            ddlItClearanceHndOvr.Enabled = false;

            txtMobNoRemarks.Enabled = false;
            cbMobNo.Enabled = false;
            txtCarKeysDocRemarks.Enabled = false;
            cbCarKeysDoc.Enabled = false;
            txtdrivingLicRemarks.Enabled = false;
            cbDrivingLic.Enabled = false;
            txtH2SBACardsRemarks.Enabled = false;
            cbH2SBA.Enabled = false;
            txtOfficialKeyRemarks.Enabled = false;

            cbOfficialKey.Enabled = false;
            txtImpresetRemarks.Enabled = false;
            cbImpreset.Enabled = false;
            txtStaffAdvanceRemarks.Enabled = false;
            cbStaffAdvance.Enabled = false;
            txtTeleBillsPerRemarks.Enabled = false;
            cbTeleBillsPer.Enabled = false;
            txtItClearanceRemarks.Enabled = false;
            cbItClearanc.Enabled = false;
            txtComments.Enabled = false;
        }


        DataTable dtClrFormStaff = objBusinessClearanceFormStaff.ReadClearanceFormStaffByIDResg(objEntityClearanceFormStaff);


        if (dtClrFormStaff.Rows.Count > 0)
        {

            HiddenFieldMstrTblId.Value = dtClrFormStaff.Rows[0]["RSGCLRSTF_ID"].ToString();
            objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(HiddenFieldMstrTblId.Value);

            if (ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString()) != null)
            {
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString()).Selected = true;
            }

            else
            {


                string strDate = dtClrFormStaff.Rows[0]["EMPERDTL_FNAME"].ToString();
                if (strDate != "")
                {
                    strDate = dtClrFormStaff.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaff.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaff.Rows[0]["EMPERDTL_LNAME"].ToString();

                }
                else
                {
                    strDate = dtClrFormStaff.Rows[0]["TAKE_OVR_USR_NAME"].ToString();
                }


                ListItem lst = new ListItem(strDate, dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString());
                ddlEmployee.Items.Insert(1, lst);

                SortDDL(ref this.ddlEmployee);
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByValue(dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString()).Selected = true;
            }

            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormStaffw = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormStaffw = new clsEntityLayerClearanceFormWorker();
            objEntityClearanceFormStaffw.Empid = Convert.ToInt32(dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString());
            DataTable dtDetails = objBusinessClearanceFormStaffw.ReadEmployeeDtls(objEntityClearanceFormStaffw);

            clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaffs = new clsBusinessLayerClearanceFormStaff();
            clsEntityLayerClearanceFormStaff objEntityClearanceFormStaffs = new clsEntityLayerClearanceFormStaff();
            objEntityClearanceFormStaffs.Empid = Convert.ToInt32(dtClrFormStaff.Rows[0]["RSGCLRSTF_TAKE_OVR_USR_ID"].ToString());
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
            lblDesigTakeOverEmp.Text = dtDetails.Rows[0]["DESIGNATION"].ToString();
            lblDivisionTakeOverEmp.Text = strDivisions;




            hiddenLicenceFile.Value = dtClrFormStaff.Rows[0]["RSGCLRSTF_FILE_NAME"].ToString();

            if (hiddenLicenceFile.Value != null && hiddenLicenceFile.Value != "")
            {
                //    divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF) + hiddenLicenceFile.Value;
                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";

                string strFileExt = strImagePath.Substring(strImagePath.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay.InnerHtml = strImage;
            }
            txtComments.Text = dtClrFormStaff.Rows[0]["RSGCLRSTF_COMMENTS"].ToString();
        }





        DataTable dtClrFormStaffSub = objBusinessClearanceFormStaff.ReadClrFormStaffSubByIDResg(objEntityClearanceFormStaff);
        DataTable dtClrFormStaffDetail = objBusinessClearanceFormStaff.ReadClrFormStaffDetailByIDResg(objEntityClearanceFormStaff);
        if (dtClrFormStaffSub.Rows.Count > 0)
        {
            for (int intRowCount = 0; intRowCount < dtClrFormStaffSub.Rows.Count; intRowCount++)
            {

                if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.MOBILE_NUMBER))
                {
                    //ddlMobileNoHndOvr

                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlMobileNoHndOvr.ClearSelection();
                            ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlMobileNoHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlMobileNoHndOvr);
                            ddlMobileNoHndOvr.ClearSelection();
                            ddlMobileNoHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn1.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt1.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view1.Visible = false;
                    }
                    txtMobNoRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbMobNo.Checked = true;
                    }





                }


                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.CAR_KEY_AND_DOCUMENTS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlCarKeyAndDoc.ClearSelection();
                            ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {

                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlCarKeyAndDoc.Items.Insert(1, lst);

                            SortDDL(ref this.ddlCarKeyAndDoc);
                            ddlCarKeyAndDoc.ClearSelection();
                            ddlCarKeyAndDoc.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn2.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt2.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view2.Visible = false;
                    }
                    txtCarKeysDocRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbCarKeysDoc.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.DRIVING_LICENCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlDrvLicHndOvr.ClearSelection();
                            ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString(), dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlDrvLicHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlDrvLicHndOvr);
                            ddlDrvLicHndOvr.ClearSelection();
                            ddlDrvLicHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn3.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt3.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view3.Visible = false;
                    }
                    txtdrivingLicRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbDrivingLic.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.H2SBA_CARDS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlH2SBAHndOvr.ClearSelection();
                            ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {

                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlH2SBAHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlH2SBAHndOvr);
                            ddlH2SBAHndOvr.ClearSelection();
                            ddlH2SBAHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn4.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt4.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view4.Visible = false;
                    }
                    txtH2SBACardsRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbH2SBA.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.OFFICIAL_KEYS))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlOfficialKeysHndOvr.ClearSelection();
                            ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlOfficialKeysHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlOfficialKeysHndOvr);
                            ddlOfficialKeysHndOvr.ClearSelection();
                            ddlOfficialKeysHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn5.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt5.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view5.Visible = false;
                    }
                    txtOfficialKeyRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbOfficialKey.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.IMPREST))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlImprestHndOvr.ClearSelection();
                            ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlImprestHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlImprestHndOvr);
                            ddlImprestHndOvr.ClearSelection();
                            ddlImprestHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn6.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt6.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view6.Visible = false;
                    }
                    txtImpresetRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbImpreset.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.STAFF_ADVANCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlStaffAdvanceHndOvr.ClearSelection();
                            ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlStaffAdvanceHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlStaffAdvanceHndOvr);
                            ddlStaffAdvanceHndOvr.ClearSelection();
                            ddlStaffAdvanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn7.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt7.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view7.Visible = false;
                    }
                    txtStaffAdvanceRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbStaffAdvance.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.TELEPHONE_BILLS_PERSONAL))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlTelephoneBillsHndOvr.ClearSelection();
                            ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlTelephoneBillsHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlTelephoneBillsHndOvr);
                            ddlTelephoneBillsHndOvr.ClearSelection();
                            ddlTelephoneBillsHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn8.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt8.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view8.Visible = false;
                    }
                    txtTeleBillsPerRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbTeleBillsPer.Checked = true;
                    }

                }
                else if (Convert.ToInt32(dtClrFormStaffSub.Rows[intRowCount]["LVECLRSTF_SUBJECT_ID"]) == Convert.ToInt32(SUBJECTS.IT_CLEARANCE))
                {
                    if (dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString() != "")
                    {
                        if (ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()) != null)
                        {
                            ddlItClearanceHndOvr.ClearSelection();
                            ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }

                        else
                        {
                            string strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString();
                            if (strDate != "")
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_FNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_MNAME"].ToString() + " " + dtClrFormStaffSub.Rows[intRowCount]["EMPERDTL_LNAME"].ToString();

                            }
                            else
                            {
                                strDate = dtClrFormStaffSub.Rows[intRowCount]["HNDED_USR_NAME"].ToString();
                            }

                            ListItem lst = new ListItem(strDate, dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString());
                            ddlItClearanceHndOvr.Items.Insert(1, lst);

                            SortDDL(ref this.ddlItClearanceHndOvr);
                            ddlItClearanceHndOvr.ClearSelection();
                            ddlItClearanceHndOvr.Items.FindByValue(dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_HNDED_USR_ID"].ToString()).Selected = true;
                        }
                        Decsn9.InnerText = dtClrFormStaffSub.Rows[intRowCount]["Decsn"].ToString();
                        divcmnt9.InnerHtml = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_COMMENTS"].ToString();
                    }
                    else
                    {
                        view9.Visible = false;
                    }
                    txtItClearanceRemarks.Text = dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_SUB_REMARKS"].ToString();
                    if (dtClrFormStaffSub.Rows[intRowCount]["RSGCLRSTF_AVAILABLE"].ToString() == "0")
                    {
                        cbItClearanc.Checked = true;
                    }

                }
            }

        }
        if (dtClrFormStaffDetail.Rows.Count > 0)
        {
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtClrFormStaffDetail);
            hiddenEdit.Value = strJson;

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
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
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
            //string strId = Request.QueryString["Id"].ToString();
            objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(strId);
        }
        if (Request.QueryString["ResgId"] != null)
        {
            objEntityClearanceFormStaff.LeaveID = Convert.ToInt32(Request.QueryString["ResgId"].ToString());
        }
        // ID


        objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(HiddenFieldMstrTblId.Value);
        objEntityClearanceFormStaff.Empid = objEntityClearanceFormStaff.User_Id;
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityClearanceFormStaff.TakeOverEmpID = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            objEntityClearanceFormStaff.Comments = txtComments.Text.Trim();
            objEntityClearanceFormStaff.Date = DateTime.Now;


            //file
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CLEARANCE_FORM_STAFF);
            if (FileUploadLicence.HasFile)
            {
                // GET FILE EXTENSION
                string strFileExt;
                objEntityClearanceFormStaff.ActualFileName = FileUploadLicence.FileName;
                strFileExt = FileUploadLicence.FileName.Substring(FileUploadLicence.FileName.LastIndexOf('.') + 1).ToLower();
                string strImageName = intImageSection.ToString() + "_" + objEntityClearanceFormStaff.LeaveClrStaffID + "_" + FileUploadLicence.FileName + "." + strFileExt;
                objEntityClearanceFormStaff.FileName = strImageName;
            }



            //store sub data
            List<clsEntityClearanceFormStaffSub> objEntitySubList = new List<clsEntityClearanceFormStaffSub>();
            clsEntityClearanceFormStaffSub objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.MOBILE_NUMBER);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbMobNo.Checked == false)
            {
                if (ddlMobileNoHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlMobileNoHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtMobNoRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbMobNo.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.CAR_KEY_AND_DOCUMENTS);
            objEntitySub.HandedOverEmpID = 0;
            objEntitySub.SubjectRemarks = "";
            if (cbCarKeysDoc.Checked == false)
            {
                if (ddlCarKeyAndDoc.SelectedItem.Value != "--SELECT EMPLOYEE--")
                objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlCarKeyAndDoc.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtCarKeysDocRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbCarKeysDoc.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.DRIVING_LICENCE);
            objEntitySub.SubjectRemarks = ""; objEntitySub.HandedOverEmpID = 0;
            if (cbDrivingLic.Checked == false)
            {

                if (ddlDrvLicHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlDrvLicHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtdrivingLicRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbDrivingLic.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.H2SBA_CARDS);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbH2SBA.Checked == false)
            {
                if (ddlH2SBAHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlH2SBAHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtH2SBACardsRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbH2SBA.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.OFFICIAL_KEYS);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbOfficialKey.Checked == false)
            {
                if (ddlOfficialKeysHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlOfficialKeysHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtOfficialKeyRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbOfficialKey.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.IMPREST);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbImpreset.Checked == false)
            {
                if (ddlImprestHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlImprestHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtImpresetRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbImpreset.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.STAFF_ADVANCE);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbStaffAdvance.Checked == false)
            {
                if (ddlStaffAdvanceHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlStaffAdvanceHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtStaffAdvanceRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbStaffAdvance.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.TELEPHONE_BILLS_PERSONAL);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbTeleBillsPer.Checked == false)
            {
                if (ddlTelephoneBillsHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlTelephoneBillsHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtTeleBillsPerRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbTeleBillsPer.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            objEntitySub.SubjectID = Convert.ToInt32(SUBJECTS.IT_CLEARANCE);
            objEntitySub.SubjectRemarks = "";
            objEntitySub.HandedOverEmpID = 0;
            if (cbItClearanc.Checked == false)
            {
                if (ddlItClearanceHndOvr.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    objEntitySub.HandedOverEmpID = Convert.ToInt32(ddlItClearanceHndOvr.SelectedItem.Value);
                objEntitySub.SubjectRemarks = txtItClearanceRemarks.Text.Trim();
            }
            objEntitySub.AvailabilitySts = (cbItClearanc.Checked == false) ? 1 : 0;
            objEntitySubList.Add(objEntitySub);
            objEntitySub = new clsEntityClearanceFormStaffSub();
            List<clsEntityClearanceFormStaffDetail> objEntityDetilsInsList = new List<clsEntityClearanceFormStaffDetail>();
            List<clsEntityClearanceFormStaffDetail> objEntityDetilsUpdList = new List<clsEntityClearanceFormStaffDetail>();
            List<clsEntityClearanceFormStaffDetail> objEntityDetilsDeleList = new List<clsEntityClearanceFormStaffDetail>();
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
                        clsEntityClearanceFormStaffDetail objEntityDetails = new clsEntityClearanceFormStaffDetail();
                        objEntityDetails.Subject = objclsWBData.ITEM;
                        objEntityDetails.HandedOverEmpID = Convert.ToInt32(objclsWBData.EMPID);
                        objEntityDetails.Subject_Type = (objclsWBData.TYPE == "GATEPASS") ? 1 : 0;
                        objEntityDetails.SubjectRemarks = objclsWBData.REMARKS;
                        objEntityDetilsInsList.Add(objEntityDetails);
                    }
                    else
                    {
                        clsEntityClearanceFormStaffDetail objEntityDetails = new clsEntityClearanceFormStaffDetail();
                        objEntityDetails.Subject = objclsWBData.ITEM;
                        objEntityDetails.HandedOverEmpID = Convert.ToInt32(objclsWBData.EMPID);
                        objEntityDetails.Subject_Type = (objclsWBData.TYPE == "GATEPASS") ? 1 : 0;
                        objEntityDetails.SubjectRemarks = objclsWBData.REMARKS;
                        objEntityDetails.LeaveClrStaffDtlID = Convert.ToInt32(objclsWBData.DETAILID);
                        objEntityDetilsUpdList.Add(objEntityDetails);

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
                    clsEntityClearanceFormStaffDetail objEntityDetails = new clsEntityClearanceFormStaffDetail();
                    objEntityDetails.LeaveClrStaffDtlID = Convert.ToInt32(strDtlId);
                    objEntityDetilsDeleList.Add(objEntityDetails);

                }
            }
           

            objBusinessClearanceFormStaff.UpdateClearanceFormStaff(objEntityClearanceFormStaff, objEntityDetilsInsList, objEntityDetilsUpdList, objEntityDetilsDeleList, objEntitySubList);
            if (FileUploadLicence.HasFile)
            {
                FileUploadLicence.SaveAs(Server.MapPath(strImgPath) + objEntityClearanceFormStaff.FileName);
            }
            if (HiddenFieldParentPage.Value != "Resg")
            {
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request.aspx?Id=" + HiddenFieldQryStringId.Value + "&InsUpd=UpdStf");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request.aspx?Id=" + HiddenFieldQryStringId.Value + "&InsUpd=UpdStf");
                }
            }
            else
            {
                Response.Redirect("/HCM/HCM_Master/hcm_Exit_Management/hcm_Resignation_Master/hcm_Resignation_Master.aspx?Ins=UpdStf");
            }
           
        }
    }


    public void LoadEmployee()
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCountryList = objBusinessClearanceFormStaff.ReadEmployee(objEntityClearanceFormStaff);

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

    public void LoadAllEmployeeDDL()
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDate = objBusinessClearanceFormStaff.ReadFromDate(objEntityClearanceFormStaff);
        if (dtDate.Rows.Count >1)
        {
            if (dtDate.Rows[0][0].ToString() != "" && dtDate.Rows[0][0].ToString() != null)
            {
                objEntityClearanceFormStaff.RequstDate = Convert.ToDateTime(dtDate.Rows[0][0].ToString());
            }
            if (dtDate.Rows[1][0].ToString() != "" && dtDate.Rows[1][0].ToString() != null)
            {
                objEntityClearanceFormStaff.AllocationDate = Convert.ToDateTime(dtDate.Rows[1][0].ToString());
            }
        }
        DataTable dtCountryList = objBusinessClearanceFormStaff.ReadEmployee(objEntityClearanceFormStaff);

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


            //ddlMobileNoHndOvr
            ddlMobileNoHndOvr.DataSource = dtCountryList;
            ddlMobileNoHndOvr.DataTextField = "USR_NAME";
            ddlMobileNoHndOvr.DataValueField = "USR_ID";
            ddlMobileNoHndOvr.DataBind();
            //ddlSimCardHndOvr
            ddlCarKeyAndDoc.DataSource = dtCountryList;
            ddlCarKeyAndDoc.DataTextField = "USR_NAME";
            ddlCarKeyAndDoc.DataValueField = "USR_ID";
            ddlCarKeyAndDoc.DataBind();
            //ddlDrvLicHndOvr
            ddlDrvLicHndOvr.DataSource = dtCountryList;
            ddlDrvLicHndOvr.DataTextField = "USR_NAME";
            ddlDrvLicHndOvr.DataValueField = "USR_ID";
            ddlDrvLicHndOvr.DataBind();
            //ddlH2SBAHndOvr
            ddlH2SBAHndOvr.DataSource = dtCountryList;
            ddlH2SBAHndOvr.DataTextField = "USR_NAME";
            ddlH2SBAHndOvr.DataValueField = "USR_ID";
            ddlH2SBAHndOvr.DataBind();
            //ddlOfficialKeysHndOvr
            ddlOfficialKeysHndOvr.DataSource = dtCountryList;
            ddlOfficialKeysHndOvr.DataTextField = "USR_NAME";
            ddlOfficialKeysHndOvr.DataValueField = "USR_ID";
            ddlOfficialKeysHndOvr.DataBind();
            //ddlImprestHndOvr
            ddlImprestHndOvr.DataSource = dtCountryList;
            ddlImprestHndOvr.DataTextField = "USR_NAME";
            ddlImprestHndOvr.DataValueField = "USR_ID";
            ddlImprestHndOvr.DataBind();
            //ddlStaffAdvanceHndOvr
            ddlStaffAdvanceHndOvr.DataSource = dtCountryList;
            ddlStaffAdvanceHndOvr.DataTextField = "USR_NAME";
            ddlStaffAdvanceHndOvr.DataValueField = "USR_ID";
            ddlStaffAdvanceHndOvr.DataBind();
            //ddlTelephoneBillsHndOvr
            ddlTelephoneBillsHndOvr.DataSource = dtCountryList;
            ddlTelephoneBillsHndOvr.DataTextField = "USR_NAME";
            ddlTelephoneBillsHndOvr.DataValueField = "USR_ID";
            ddlTelephoneBillsHndOvr.DataBind();
            //ddlItClearanceHndOvr
            ddlItClearanceHndOvr.DataSource = dtCountryList;
            ddlItClearanceHndOvr.DataTextField = "USR_NAME";
            ddlItClearanceHndOvr.DataValueField = "USR_ID";
            ddlItClearanceHndOvr.DataBind();
        }
        ddlMobileNoHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlCarKeyAndDoc.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlDrvLicHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlH2SBAHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlOfficialKeysHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlImprestHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlStaffAdvanceHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlTelephoneBillsHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

        ddlItClearanceHndOvr.Items.Insert(0, "--SELECT EMPLOYEE--");

    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            clsBusinessLayerClearanceFormWorker objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormWorker();
            clsEntityLayerClearanceFormWorker objEntityClearanceFormStaff = new clsEntityLayerClearanceFormWorker();
            objEntityClearanceFormStaff.Empid = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            DataTable dtDetails = objBusinessClearanceFormStaff.ReadEmployeeDtls(objEntityClearanceFormStaff);

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
            lblDesigTakeOverEmp.Text = dtDetails.Rows[0]["DESIGNATION"].ToString();
            lblDivisionTakeOverEmp.Text = strDivisions;


        }

        ddlEmployee.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
    }
    [WebMethod]
    public static string DropdownEmployeeBind(string tableName, int intOrgID, int intCorrpID)
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();

        objEntityClearanceFormStaff.CorpOffice_Id = intCorrpID;

        objEntityClearanceFormStaff.Organisation_Id = intOrgID;

        DataTable dtCountryList = objBusinessClearanceFormStaff.ReadEmployee(objEntityClearanceFormStaff);

        dtCountryList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountryList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;


    }
    public void DropDownEmployeeDataStore()
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityClearanceFormStaff.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityClearanceFormStaff.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCountryList = objBusinessClearanceFormStaff.ReadEmployee(objEntityClearanceFormStaff);

        foreach (DataRow rowDepnt in dtCountryList.Rows)
        {
            string strDate = rowDepnt["EMPERDTL_FNAME"].ToString();
            if (strDate != "")
            {
                strDate = rowDepnt["EMPERDTL_FNAME"].ToString() + " " + rowDepnt["EMPERDTL_MNAME"].ToString() + " " + rowDepnt["EMPERDTL_LNAME"].ToString();
                rowDepnt["USR_NAME"] = strDate;
            }

        }


        dtCountryList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountryList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmpDdlData.Value = result;
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(HiddenFieldMstrTblId.Value);
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityClearanceFormStaff.Date = System.DateTime.Now;
        objBusinessClearanceFormStaff.ApproveClrncStaff(objEntityClearanceFormStaff);
        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx?InsUpd=Aprvd");
       
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        clsBusinessLayerClearanceFormStaff objBusinessClearanceFormStaff = new clsBusinessLayerClearanceFormStaff();
        clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff = new clsEntityLayerClearanceFormStaff();
        objEntityClearanceFormStaff.LeaveClrStaffID = Convert.ToInt32(HiddenFieldMstrTblId.Value);
        if (Session["USERID"] != null)
        {
            objEntityClearanceFormStaff.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityClearanceFormStaff.Date = System.DateTime.Now;
        objEntityClearanceFormStaff.CancelReason = TextBox1.Text;
        objBusinessClearanceFormStaff.RejectClrncStaff(objEntityClearanceFormStaff);
        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx?InsUpd=Rejctd");
     
    }
}