using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
public partial class HCM_HCM_Master_hcm_Employee_Transfer_hcm_Employee_Transfer_Single : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BussinessUnitload();
            ddlBusinessUnit.Focus();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Transfer);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }

                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

            }
            else
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
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
                btnUpdate.Visible = false;
            }

            if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnConfirm.Visible = true;
            }
            else
            {
                btnConfirm.Visible = false;
            }

            if (Request.QueryString["EditId"] != null)
            {
                string strRandomMixedId = Request.QueryString["EditId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string Id = strRandomMixedId.Substring(2, intLenghtofId);
                Session["EDIT"] = Id;
                string strId = Session["EDIT"].ToString();
               
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
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnConfirm.Visible = true;
                }
                else
                {
                    btnConfirm.Visible = false;
                }
               
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                lblHeader.InnerText = "Edit Employee Transfer";
                Update(strId);
            }
            else
            {
                ddlNewDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
                ddlPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");
                ddlproject.Items.Insert(0, "--SELECT PROJECT--");
                ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");
                ddlreporter.Items.Insert(0, "--SELECT REPORTER--");
                ddlNewDivision.Items.Insert(0, "--SELECT DIVISION--");
                lblHeader.InnerText = "Add Employee Transfer";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
            }


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocompletePartial", "RecallAutocompletePartial();", true); 
        }
    }

   
    public void BussinessUnitload()
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtBusinessUnit = objBusinessEmployeeTrnsfr.ReadBussinessUnit(objEntitylayerEmployeeTrnsfr);
        ddlBusinessUnit.Items.Clear();

        ddlBusinessUnit.DataSource = dtBusinessUnit;
        ddlBusinessUnit.DataTextField = "CORPRT_NAME";
        ddlBusinessUnit.DataValueField = "CORPRT_ID";
        ddlBusinessUnit.DataBind();
        ddlBusinessUnit.Items.Insert(0, "--SELECT BUSINESS UNIT--");

        ddlNewBussinessunit.Items.Clear();

        ddlNewBussinessunit.DataSource = dtBusinessUnit;
        ddlNewBussinessunit.DataTextField = "CORPRT_NAME";
        ddlNewBussinessunit.DataValueField = "CORPRT_ID";
        ddlNewBussinessunit.DataBind();
        ddlNewBussinessunit.Items.Insert(0, "--SELECT BUSINESS UNIT--");

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

        
    }

    public void FixedDropdownload(string Default)
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Default == "N0")
        {
            if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
            {
                objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
            }
        }
        else
        {
            if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
            {
                objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
            }
            else
            {
                if (ddlBusinessUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
                {
                    objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
                }
            }
        }

        DataTable dtDepartment = objBusinessEmployeeTrnsfr.ReadCorporateDepartments(objEntitylayerEmployeeTrnsfr);
        DataTable dtPaygrade = objBusinessEmployeeTrnsfr.ReadPaygrade(objEntitylayerEmployeeTrnsfr);
        DataTable dtproject = objBusinessEmployeeTrnsfr.ReadProjects(objEntitylayerEmployeeTrnsfr);
        DataTable dtSponsor = objBusinessEmployeeTrnsfr.ReadSponsor(objEntitylayerEmployeeTrnsfr);
        DataTable dtReporter = objBusinessEmployeeTrnsfr.ReadEmployees(objEntitylayerEmployeeTrnsfr);


        ddlNewDepartment.Items.Clear();

        ddlNewDepartment.DataSource = dtDepartment;
        ddlNewDepartment.DataTextField = "CPRDEPT_NAME";
        ddlNewDepartment.DataValueField = "CPRDEPT_ID";
        ddlNewDepartment.DataBind();
        ddlNewDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
       
        ddlPaygrade.Items.Clear();

        ddlPaygrade.DataSource = dtPaygrade;
        ddlPaygrade.DataTextField = "PYGRD_NAME";
        ddlPaygrade.DataValueField = "PYGRD_ID";
        ddlPaygrade.DataBind();
        ddlPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");

        ddlproject.Items.Clear();

        ddlproject.DataSource = dtproject;
        ddlproject.DataTextField = "PROJECT_NAME";
        ddlproject.DataValueField = "PROJECT_ID";
        ddlproject.DataBind();
        ddlproject.Items.Insert(0, "--SELECT PROJECT--");

        ddlSponsor.Items.Clear();

        ddlSponsor.DataSource = dtSponsor;
        ddlSponsor.DataTextField = "SPNSR_NAME";
        ddlSponsor.DataValueField = "SPSNSR_ID";
        ddlSponsor.DataBind();
        ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");

        ddlreporter.Items.Clear();

        ddlreporter.DataSource = dtReporter;
        ddlreporter.DataTextField = "USR_NAME";
        ddlreporter.DataValueField = "USR_ID";
        ddlreporter.DataBind();
        ddlreporter.Items.Insert(0, "--SELECT REPORTER--");


        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //clsEntityCommon objEntityCommon = new clsEntityCommon();
        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERSONAL_DETAILS);
        //objEntityCommon.CorporateID = objEntitylayerEmployeeTrnsfr.CorpId;
        //objEntityCommon.Organisation_Id = objEntitylayerEmployeeTrnsfr.OrgId;
        //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        //string year = DateTime.Today.Year.ToString();
        //lblNewEmpId.Text = "EMP/" + year + "/" + strNextId;
        if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--" && ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
        int corpID=Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
        lblNewEmpId.Text = empRefFormatLoad(corpID); 
        }
    }
    public string empRefFormatLoad(int corpId)
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();
        objEntityUsrRegistr.UserCrprtId = corpId;
        DataTable dtRefFormat = objBusinessLayerUserRegisteration.ReadReferenceFormatEmp(objEntityUsrRegistr);
        string refFormatByDiv = "";
        string strRealFormat = "";
        string insDate = "";
        if (dtRefFormat.Rows.Count != 0)
        {
         refFormatByDiv = dtRefFormat.Rows[0]["EMP_REF_FORMAT"].ToString();

         string strReferenceFormat = "";
         strReferenceFormat = refFormatByDiv;

         int flag = 0;
         string[] arrReferenceSplit = strReferenceFormat.Split('*');
         int intArrayRowCount = arrReferenceSplit.Length;
         for (int intRowCount = 0; intRowCount < intArrayRowCount; intRowCount++)
         {
             if (arrReferenceSplit[intRowCount] != "" && arrReferenceSplit[intRowCount] != null)
             {
                 if (arrReferenceSplit[intRowCount].Contains("#"))
                 {
                     string[] strSplitWithHash = arrReferenceSplit[intRowCount].Split('#');
                     int intArraySplitHashCount = strSplitWithHash.Length;
                     for (int intcount = 0; intcount < intArraySplitHashCount; intcount++)
                     {
                         if (strSplitWithHash[intcount] != "" && strSplitWithHash[intcount] != null)
                         {
                             if (strSplitWithHash[intcount] == "COR" || strSplitWithHash[intcount] == "USR" || strSplitWithHash[intcount] == "YER" || strSplitWithHash[intcount] == "MON")
                             {

                             }
                             else
                             {
                                 flag = 1;
                             }
                         }

                     }
                 }
             }
         }
         if (flag == 1)
         {
             refFormatByDiv = "#COR#*/*#USR#";
         }


         objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        int intUserId = 0, UserOrgId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityUsrRegistr.UserId = objEntityUsrRegistr.UsrRegistrationId;
        DataTable dtUsrMastr = objBusinessLayerUserRegisteration.ReadUsrMasterEdit(objEntityUsrRegistr);

        if (dtUsrMastr.Rows.Count > 0)
        {
            insDate = dtUsrMastr.Rows[0]["INSDATE"].ToString();
        }


                    if (refFormatByDiv == "" || refFormatByDiv == null)
                    {
                        strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + ddlEmployee.SelectedItem.Value;
                    }
                    else
                    {
                        clsCommonLibrary objCommon = new clsCommonLibrary();

                        DateTime dt = objCommon.textToDateTime(insDate);

                        strRealFormat = refFormatByDiv.ToString();
                        if (strRealFormat.Contains("#COR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#COR#", dtRefFormat.Rows[0]["CORPRT_CODE"].ToString());
                        }

                        if (strRealFormat.Contains("#USR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#USR#",ddlEmployee.SelectedItem.Value);
                        }
                        if (strRealFormat.Contains("#YER#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YER#", dt.Year.ToString());
                        }

                        if (strRealFormat.Contains("#MON#"))
                        {
                            strRealFormat = strRealFormat.Replace("#MON#", dt.Month.ToString());

                        }

                        if (strRealFormat == "")
                        {
                            strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + ddlEmployee.SelectedItem.Value;
                        }
                        strRealFormat = strRealFormat.Replace("#", "");
                        strRealFormat = strRealFormat.Replace("*", "");
                        strRealFormat = strRealFormat.Replace("%", "");

                    }

        }
        return strRealFormat;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();

       List<clsEntity_Emp_Transfer> objEntitylayerDivList = new List<clsEntity_Emp_Transfer>();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlBusinessUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.BusinesUnitId_Old = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntitylayerEmployeeTrnsfr.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.BusinesUnitId = Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
        }

        if (cbxNewEmployeeId.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.EmpId = lblNewEmpId.Text;
        }
        if (ddlNewDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(ddlNewDepartment.SelectedItem.Value);
        }
        if (ddlPaygrade.SelectedItem.Value != "--SELECT PAYGRADE--")
        {
            objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(ddlPaygrade.SelectedItem.Value);
        } if (ddlreporter.SelectedItem.Value != "--SELECT REPORTER--")
        {
            objEntitylayerEmployeeTrnsfr.ReporterId = Convert.ToInt32(ddlreporter.SelectedItem.Value);
        }

        if (ddlSponsor.SelectedItem.Value != "--SELECT SPONSOR--")
        {
            objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }
        if (ddlproject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntitylayerEmployeeTrnsfr.ProjectId = Convert.ToInt32(ddlproject.SelectedItem.Value);
        }

        if (radioBUtransfer.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.Trans_Type = 1;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.BusinesUnitId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);

            if (hiddenManpowerId.Value != "")
            {
                objEntitylayerEmployeeTrnsfr.manPOwerId = Convert.ToInt32(hiddenManpowerId.Value);
            }
            if (hiddenDepartmentId.Value != "")
            {
                objEntitylayerEmployeeTrnsfr.DepartmentId=Convert.ToInt32(hiddenDepartmentId.Value);
            }
            if (hiddenPaygradeId.Value != "")
            {
                objEntitylayerEmployeeTrnsfr.PaygradeId=Convert.ToInt32(hiddenPaygradeId.Value);
            }
            if (HiddenProjectId.Value != "")
            {
                objEntitylayerEmployeeTrnsfr.ProjectId = Convert.ToInt32(HiddenProjectId.Value);
            }

            objEntitylayerEmployeeTrnsfr.Trans_Type = 2;
        }
        if (radioTemporary.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.Trans_Method = 2;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.Trans_Method =1;
        }
        objEntitylayerEmployeeTrnsfr.Trans_Mode = 1;

        objEntitylayerEmployeeTrnsfr.FromDate = objCommon.textToDateTime(txtFromdate.Value.Trim());
        if (txtTodate.Value.Trim() != "")
        {
            objEntitylayerEmployeeTrnsfr.Todate = objCommon.textToDateTime(txtTodate.Value.Trim());
        }

        string TotalDivi = hiddenDivIds.Value;

        string[] EachDivi = TotalDivi.Split(',');

        foreach (string DivId in EachDivi)
        {
            if (DivId != "" && DivId != "--SELECT DIVISION--")
            {
                clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfrdiv = new clsEntity_Emp_Transfer();
                objEntitylayerEmployeeTrnsfrdiv.DivisionId = Convert.ToInt32(DivId);
                objEntitylayerDivList.Add(objEntitylayerEmployeeTrnsfrdiv);
            }
        }
        List<clsEntity_Emp_Transfer> objEntitylayerEmpList = new List<clsEntity_Emp_Transfer>();
        if (clickedButton.ID == "btnSave")
        {
            objBusinessEmployeeTrnsfr.InsertEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            Session["SUCCESS_EMPTRNS"] = "SAVE";
            Response.Redirect("hcm_Emp_Transfer_Single.aspx");
        }
        else if (clickedButton.ID == "btnSaveClose")
        {
            objBusinessEmployeeTrnsfr.InsertEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            Session["SUCCESS_EMPTRNS"] = "SAVE";
            Response.Redirect("hcm_Emp_Transfer_List.aspx");
        }
        else if (clickedButton.ID == "btnUpdate")
        {
            string strRandomMixedId = Request.QueryString["EditId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string Id = strRandomMixedId.Substring(2, intLenghtofId);
            objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(Id);
            objBusinessEmployeeTrnsfr.UpdateEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            Session["SUCCESS_EMPTRNS"] = "UPD";
            Response.Redirect("hcm_Emp_Transfer_Single.aspx");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            string strRandomMixedId = Request.QueryString["EditId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string Id = strRandomMixedId.Substring(2, intLenghtofId);
            objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(Id);
            objBusinessEmployeeTrnsfr.UpdateEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            Session["SUCCESS_EMPTRNS"] = "UPD";
            Response.Redirect("hcm_Emp_Transfer_List.aspx");
        }
        else if (clickedButton.ID == "btnConfirm")
        {
            string strRandomMixedId = Request.QueryString["EditId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string Id = strRandomMixedId.Substring(2, intLenghtofId);
            objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(Id);
            objBusinessEmployeeTrnsfr.UpdateEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            objBusinessEmployeeTrnsfr.ConfirmEmpTransfer(objEntitylayerEmployeeTrnsfr);
            Session["SUCCESS_EMPTRNS"] = "CONFIRM";
            Response.Redirect("hcm_Emp_Transfer_List.aspx");
        }
       

    }
    public void SelectedBUchange()
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlBusinessUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }

        DataTable dtEmployee = objBusinessEmployeeTrnsfr.ReadEmployees(objEntitylayerEmployeeTrnsfr);
        ddlEmployee.Items.Clear();

        ddlEmployee.DataSource = dtEmployee;
        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
        FixedDropdownload("YES");//if yes all the dropdown will refresh
    }
    protected void ddlBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedBUchange();
        hiddenManpowerId.Value = "";
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{BU}');", true);
    }

    public void selectedEmployeeChange()
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlBusinessUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntitylayerEmployeeTrnsfr.UserId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        DataTable dtEmployeeDetails = objBusinessEmployeeTrnsfr.ReadEmployeesDetailsById(objEntitylayerEmployeeTrnsfr);

        if (dtEmployeeDetails.Rows.Count > 0)
        {
            lblNationality.Text = dtEmployeeDetails.Rows[0]["CNTRY_NAME"].ToString();
            lblSponsor.Text = dtEmployeeDetails.Rows[0]["SPNSR_NAME"].ToString();
            string strDivNames = "";
            if (dtEmployeeDetails.Rows.Count == 1)
            {
                strDivNames = dtEmployeeDetails.Rows[0]["CPRDIV_NAME"].ToString();
            }
            else
            {
                foreach (DataRow dtRow in dtEmployeeDetails.Rows)
                {
                    strDivNames = dtRow["CPRDIV_NAME"].ToString().ToUpper() + "," + strDivNames;
                }
                strDivNames = strDivNames.TrimEnd(',');
            }
            lblDivision.Text = strDivNames;
            lblDepartment.Text = dtEmployeeDetails.Rows[0]["CPRDEPT_NAME"].ToString().ToUpper();
            lblReporter.Text = dtEmployeeDetails.Rows[0]["USR_NAME"].ToString().ToUpper();
            lblPaygrade.Text = dtEmployeeDetails.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
            lblProject.Text = dtEmployeeDetails.Rows[0]["PROJECT_NAME"].ToString().ToUpper();
        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedEmployeeChange();
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{EMP}');", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "labelDivVisible", "labelDivVisible();", true);
    }
    protected void ddlNewBussinessunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        FixedDropdownload("NO");
        ddlNewDivision.Items.Clear();
        ddlNewDivision.Items.Insert(0, "--SELECT DIVISION--");
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{NBU}');", true);
    }
    public void selectedDepartmentChange()
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        if (Session["ORGID"] != null)
        {
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }
        if (ddlNewDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(ddlNewDepartment.SelectedItem.Value);
        }
        DataTable dtDivisions = objBusinessEmployeeTrnsfr.ReadDivisions(objEntitylayerEmployeeTrnsfr);
        ddlNewDivision.Items.Clear();

        ddlNewDivision.DataSource = dtDivisions;
        ddlNewDivision.DataTextField = "CPRDIV_NAME";
        ddlNewDivision.DataValueField = "CPRDIV_ID";
        ddlNewDivision.DataBind();
        ddlNewDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    protected void ddlNewDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedDepartmentChange();
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{DEPT}');", true);
    }



    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(strP_Id);
        DataTable dtTrnsDetails = objBusinessEmployeeTrnsfr.ReadEmployeeTransferById(objEntitylayerEmployeeTrnsfr);
        if (dtTrnsDetails.Rows.Count > 0)
        {

            if (dtTrnsDetails.Rows[0]["EMPTRNS_TYPE"].ToString() == "1")
            {
                radioBUtransfer.Checked = true;
            }

            if (dtTrnsDetails.Rows[0]["EMPTRNS_METHOD"].ToString() == "1")
            {
                radioPermanent.Checked = true;
            }

            txtFromdate.Value = dtTrnsDetails.Rows[0]["EMPTRNS_FROM"].ToString();
            txtTodate.Value = dtTrnsDetails.Rows[0]["EMPTRNS_TO"].ToString();

                ddlBusinessUnit.ClearSelection();
                if (dtTrnsDetails.Rows[0]["OLDCORP_STS"].ToString() == "1" )
                {
                    ddlBusinessUnit.Items.FindByValue(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString()).Selected = true;

                    SelectedBUchange();
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["OLDCORP_NAME"].ToString(), dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString());
                    ddlBusinessUnit.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlBusinessUnit);

                    ddlBusinessUnit.Items.FindByValue(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString()).Selected = true;
                }

                ddlEmployee.ClearSelection();
                if (dtTrnsDetails.Rows[0]["USR_STATUS"].ToString() == "1")
                {
                    if (ddlEmployee.Items.FindByValue(dtTrnsDetails.Rows[0]["USR_ID"].ToString()) != null)
                    {
                        ddlEmployee.Items.FindByValue(dtTrnsDetails.Rows[0]["USR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["USR_NAME"].ToString(), dtTrnsDetails.Rows[0]["USR_ID"].ToString());
                        ddlEmployee.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlEmployee);

                        ddlEmployee.Items.FindByValue(dtTrnsDetails.Rows[0]["USR_ID"].ToString()).Selected = true;
                        selectedEmployeeChange();
                    }
                    selectedEmployeeChange();
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["USR_NAME"].ToString(), dtTrnsDetails.Rows[0]["USR_ID"].ToString());
                    ddlEmployee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlEmployee);

                    ddlEmployee.Items.FindByValue(dtTrnsDetails.Rows[0]["USR_ID"].ToString()).Selected = true;
                    selectedEmployeeChange();
                }

                ddlNewBussinessunit.ClearSelection();
                if (dtTrnsDetails.Rows[0]["CORPRT_STATUS"].ToString() == "1")
                {
                    ddlNewBussinessunit.Items.FindByValue(dtTrnsDetails.Rows[0]["CORPRT_ID"].ToString()).Selected = true;
                    FixedDropdownload("NO");
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CORPRT_NAME"].ToString(), dtTrnsDetails.Rows[0]["CORPRT_ID"].ToString());
                    ddlNewBussinessunit.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlNewBussinessunit);

                    ddlNewBussinessunit.Items.FindByValue(dtTrnsDetails.Rows[0]["CORPRT_ID"].ToString()).Selected = true;
                    FixedDropdownload("NO");
                }

                ddlNewDepartment.ClearSelection();
                if (dtTrnsDetails.Rows[0]["CPRDEPT_STATUS"].ToString() == "1")
                {
                    ddlNewDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                    selectedDepartmentChange();
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDEPT_NAME"].ToString(), dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString());
                    ddlNewDepartment.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlNewDepartment);

                    ddlNewDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                    selectedDepartmentChange();
                }

                ddlPaygrade.ClearSelection();
                if (dtTrnsDetails.Rows[0]["PYGRD_STATUS"].ToString() == "1")
                {
                    ddlPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["PYGRD_NAME"].ToString(), dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString());
                    ddlPaygrade.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlPaygrade);

                    ddlPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
                }

                ddlreporter.ClearSelection();
                if (dtTrnsDetails.Rows[0]["REPORT_STS"].ToString() == "1")
                {
                    ddlreporter.Items.FindByValue(dtTrnsDetails.Rows[0]["REPORT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["REPORT_NAME"].ToString(), dtTrnsDetails.Rows[0]["REPORT_ID"].ToString());
                    ddlreporter.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlreporter);

                    ddlreporter.Items.FindByValue(dtTrnsDetails.Rows[0]["REPORT_ID"].ToString()).Selected = true;
                }

                if (dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString() != "")
                {
                    ddlSponsor.ClearSelection();
                    if (dtTrnsDetails.Rows[0]["SPSNSR_STATUS"].ToString() == "1")
                    {
                        ddlSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["SPNSR_NAME"].ToString(), dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString());
                        ddlSponsor.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlSponsor);

                        ddlSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
                    }
                }
                if (dtTrnsDetails.Rows[0]["PROJECT_ID"].ToString() != "")
                {
                    ddlproject.ClearSelection();
                    if (dtTrnsDetails.Rows[0]["PROJECT_STATUS"].ToString() == "1")
                    {
                        ddlproject.Items.FindByValue(dtTrnsDetails.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["PROJECT_NAME"].ToString(), dtTrnsDetails.Rows[0]["PROJECT_ID"].ToString());
                        ddlproject.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlproject);

                        ddlproject.Items.FindByValue(dtTrnsDetails.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                    }
                }
            if (dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString() != "")
                {
                    ddlNewDivision.ClearSelection();
                    if (dtTrnsDetails.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
                    {
                        if (ddlNewDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString()) != null)
                            ddlNewDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                        else
                        {
                            ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDIV_NAME"].ToString(), dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString());
                            ddlNewDivision.Items.Insert(1, lstGrp);

                            SortDDL(ref this.ddlNewDivision);

                            ddlNewDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                        }
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDIV_NAME"].ToString(), dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString());
                        ddlNewDivision.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlNewDivision);

                        ddlNewDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }
                }

            if (dtTrnsDetails.Rows[0]["EMPTRNS_NEW_EMP_ID"].ToString() != "")
            {
                cbxNewEmployeeId.Checked = true;
                lblNewEmpId.Text = dtTrnsDetails.Rows[0]["EMPTRNS_NEW_EMP_ID"].ToString();
            }

            if (dtTrnsDetails.Rows[0]["MNPRQST_ID"].ToString() != "")
            {
                ManYes.Checked = true;
                hiddenManpowerId.Value = dtTrnsDetails.Rows[0]["MNPRQST_ID"].ToString();
            }
            else
            {
                ManYes.Checked = false;
            }
            if (dtTrnsDetails.Rows[0]["EMPTRNS_CNFRM_USR_ID"].ToString() != "")
            {
                ddlBusinessUnit.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlNewBussinessunit.Enabled = false;
                ddlNewDepartment.Enabled = false;
                ddlPaygrade.Enabled = false;
                ddlproject.Enabled = false;
                ddlSponsor.Enabled = false;
                txtFromdate.Disabled = true;
                txtTodate.Disabled = true;
                ddlNewDivision.Enabled = false;
                ddlreporter.Enabled = false;
                radioBUtransfer.Disabled = true;
                radioPermanent.Disabled = true;
                radioTemporary.Disabled = true;
                radioIOtransfer.Disabled = true;
                ManNo.Disabled = true;
                ManYes.Disabled = true;
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible=false;
            }
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

  [WebMethod]
    public static string ManpowerTableCreator(string strCorpId,string strOrgId)
    {
      
      clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();

        objEntitylayerEmployeeTrnsfr.OrgId =Convert.ToInt32(strOrgId);
        objEntitylayerEmployeeTrnsfr.CorpId =Convert.ToInt32(strCorpId);
        DataTable dtManList = objBusinessEmployeeTrnsfr.ReadManpowerRequestList(objEntitylayerEmployeeTrnsfr);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"tableManPower\" style=\"width:99%;\" class=\"tbMan\" cellspacing=\"0\" cellpadding=\"2px\" >";

        strHtml += "<thead>";

        strHtml += "<tr class=\"ManTableHead\">";
        strHtml += "<th class=\"MHead\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"MHead\" style=\"width:20%;text-align: left; word-wrap:break-word;\">REF#</th>";
        strHtml += "<th class=\"MHead\" style=\"width:16%;text-align: center; word-wrap:break-word;\">DATE OF REQUEST</th>";
        strHtml += "<th class=\"MHead\" style=\"width:10%;text-align: center; word-wrap:break-word;\">VACANCY</th>";
        strHtml += "<th class=\"MHead\" style=\"width:20%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"MHead\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"MHead\" style=\"width:10%;text-align: center; word-wrap:break-word;\">ASSIGN</th>";
        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        if (dtManList.Rows.Count > 0)
        {
            int intCount = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtManList.Rows.Count; intRowBodyCount++)
            {
                intCount++;
                strHtml += "<tr  >";
                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intCount + " </td>";
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + " </td>";
                strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManList.Rows[intRowBodyCount]["DATE"].ToString() + " </td>";

                int totalResource = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["MNP_RESOURCENUM"].ToString());
                int intFilledCount = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["SELECTED COUNT"].ToString());
                int IntRemainCount = totalResource - intFilledCount;

                string ManpowerId = dtManList.Rows[intRowBodyCount]["MNPRQST_ID"].ToString();
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + IntRemainCount + " </td>";
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + " </td>";
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["PROJECT"].ToString() + " </td>";
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"checkbox\" name=\"CbxMan\" Id=\"cbxManPwr_" + dtManList.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() + "\"  onchange=\"IncrmntConfrmCounter()\"  onclick=\"ManCbxClick(this.id,'"+ManpowerId+"')\" ></td>";
                strHtml += "<td class=\"tdT\" style=\"display:none; width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManList.Rows[intRowBodyCount]["MNPRQST_ID"] + "</td>";
                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" colspan=\"7\" style=\"word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
  public static string[] ManPowerDetailsFill(string intCorpId,string intOrgId, string intManpId)
  {
      clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
      clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
      string[] PassingString = new string[12];

      objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(intOrgId);
      objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(intCorpId);
      objEntitylayerEmployeeTrnsfr.manPOwerId = Convert.ToInt32(intManpId);
      DataTable dtShortlist = objBusinessEmployeeTrnsfr.ReadManpowerRequestDetailsById(objEntitylayerEmployeeTrnsfr);
      if (dtShortlist.Rows.Count > 0)
      {
          PassingString [0]= dtShortlist.Rows[0]["MNP_REFNUM"].ToString();

          PassingString[1] = dtShortlist.Rows[0]["DATE OF REQUEST"].ToString();

          PassingString[2] = dtShortlist.Rows[0]["MNP_RESOURCENUM"].ToString();

          PassingString[3] = dtShortlist.Rows[0]["DESIGNATION"].ToString();
          PassingString[4] = dtShortlist.Rows[0]["DEPARTMENT"].ToString();

          PassingString[5] = dtShortlist.Rows[0]["PROJECT"].ToString();

          PassingString[6] = dtShortlist.Rows[0]["MNP_EXPERIENCE"].ToString() + "  Years";

          PassingString[7] = dtShortlist.Rows[0]["PYGRD_NAME"].ToString();

          PassingString[8] = dtShortlist.Rows[0]["PYGRD_ID"].ToString();
          PassingString[9] = dtShortlist.Rows[0]["CPRDEPT_ID"].ToString();
          PassingString[10] = dtShortlist.Rows[0]["PROJECT_ID"].ToString();
          PassingString[11] = dtShortlist.Rows[0]["CPRDIV_ID"].ToString();
      }
      return PassingString;
  }
}