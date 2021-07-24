using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;

public partial class HCM_HCM_Master_hcm_Employee_Transfer_hcm_Emp_Transfer_Bulk : System.Web.UI.Page
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
                        intEnableModify = 1;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = 1;

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
                ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
                ddlNewDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
                ddlPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");
                ddlnewPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");
                ddlproject.Items.Insert(0, "--SELECT PROJECT--");
                ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");
                ddlNewSponsor.Items.Insert(0, "--SELECT SPONSOR--");
                ddlreporter.Items.Insert(0, "--SELECT REPORTER--");
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
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
    }
    protected void ddlBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedBUchange();
        hiddenManpowerId.Value = "";
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{BU}');", true);
    }
    protected void ddlNewBussinessunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        FixedDropdownload("NO");
        ddlNewDivision.Items.Clear();
        ddlNewDivision.Items.Insert(0, "--SELECT DIVISION--");
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{NBU}');", true);
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
        DataTable dtDepartment = objBusinessEmployeeTrnsfr.ReadCorporateDepartments(objEntitylayerEmployeeTrnsfr);
        DataTable dtPaygrade = objBusinessEmployeeTrnsfr.ReadPaygrade(objEntitylayerEmployeeTrnsfr);
        DataTable dtSponsor = objBusinessEmployeeTrnsfr.ReadSponsor(objEntitylayerEmployeeTrnsfr);
        ddlDepartment.Items.Clear();

        ddlDepartment.DataSource = dtDepartment;
        ddlDepartment.DataTextField = "CPRDEPT_NAME";
        ddlDepartment.DataValueField = "CPRDEPT_ID";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");

        ddlPaygrade.Items.Clear();

        ddlPaygrade.DataSource = dtPaygrade;
        ddlPaygrade.DataTextField = "PYGRD_NAME";
        ddlPaygrade.DataValueField = "PYGRD_ID";
        ddlPaygrade.DataBind();
        ddlPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");

        ddlSponsor.Items.Clear();

        ddlSponsor.DataSource = dtSponsor;
        ddlSponsor.DataTextField = "SPNSR_NAME";
        ddlSponsor.DataValueField = "SPSNSR_ID";
        ddlSponsor.DataBind();
        ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");

        FixedDropdownload("YES");//if yes all the dropdown will refresh
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
        if (ddlBusinessUnit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }
       
        if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        DataTable dtDivisions = objBusinessEmployeeTrnsfr.ReadDivisions(objEntitylayerEmployeeTrnsfr);
        ddlDivision.Items.Clear();

        ddlDivision.DataSource = dtDivisions;
        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public void selectedNewDepartmentChange()
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
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedDepartmentChange();
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{DEPT}');", true);
    }
    protected void ddlNewDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedNewDepartmentChange();
        ScriptManager.RegisterStartupScript(this, GetType(), "RecallAutocomplete", "RecallAutocomplete('{NDEPT}');", true);
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

        ddlnewPaygrade.Items.Clear();

        ddlnewPaygrade.DataSource = dtPaygrade;
        ddlnewPaygrade.DataTextField = "PYGRD_NAME";
        ddlnewPaygrade.DataValueField = "PYGRD_ID";
        ddlnewPaygrade.DataBind();
        ddlnewPaygrade.Items.Insert(0, "--SELECT PAYGRADE--");

        ddlproject.Items.Clear();

        ddlproject.DataSource = dtproject;
        ddlproject.DataTextField = "PROJECT_NAME";
        ddlproject.DataValueField = "PROJECT_ID";
        ddlproject.DataBind();
        ddlproject.Items.Insert(0, "--SELECT PROJECT--");

        ddlNewSponsor.Items.Clear();

        ddlNewSponsor.DataSource = dtSponsor;
        ddlNewSponsor.DataTextField = "SPNSR_NAME";
        ddlNewSponsor.DataValueField = "SPSNSR_ID";
        ddlNewSponsor.DataBind();
        ddlNewSponsor.Items.Insert(0, "--SELECT SPONSOR--");

        ddlreporter.Items.Clear();

        ddlreporter.DataSource = dtReporter;
        ddlreporter.DataTextField = "USR_NAME";
        ddlreporter.DataValueField = "USR_ID";
        ddlreporter.DataBind();
        ddlreporter.Items.Insert(0, "--SELECT REPORTER--");

    }
   
   
    protected void btnsearch_Click(object sender, EventArgs e)
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
        else
        {
            objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(ddlBusinessUnit.SelectedItem.Value);
        }
        if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntitylayerEmployeeTrnsfr.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlPaygrade.SelectedItem.Value != "--SELECT PAYGRADE--")
        {
            objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(ddlPaygrade.SelectedItem.Value);
        }
        if (ddlSponsor.SelectedItem.Value != "--SELECT SPONSOR--")
        {
            objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }
        if (radioCustTypeStaff.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.EmpType = 0;
        }
        if (radioCustTypeWorker.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.EmpType = 1;
        }
        DataTable dtEmployee= objBusinessEmployeeTrnsfr.ReadEmployeeList(objEntitylayerEmployeeTrnsfr);
        string strEmplyeeList = CovertListToHTML(dtEmployee,"");
        divEmplyeeList.InnerHtml = strEmplyeeList;

    }
    public string CovertListToHTML(DataTable dt,string EmpIds)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"EmployeeTable\" class=\"tbMan\" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:99.8%;float:left;\">";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<thead>";
        strHtml += "<tr class=\"ManTableHead\">";
        strHtml += "<th class=\"MHead\" style=\"width:5%;text-align: center;\"></th>";
        strHtml += "<th class=\"MHead\" style=\"width:12%;text-align: center; word-wrap:break-word;\">" + "Employee Code" + "</th>";
        strHtml += "<th class=\"MHead\" style=\"width:17%;text-align: left; word-wrap:break-word;\">" + "Employee Name" + "</th>";
        strHtml += "<th class=\"MHead\"  style=\"width:17%;text-align:left; word-wrap:break-word;\">" + "Designation" + "</th>";
        strHtml += "<th class=\"MHead\" style=\"width:17%;text-align: left; word-wrap:break-word;\">" + "Paygrade" + "</th>";
        strHtml += "<th class=\"MHead\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + "Sponsor" + "</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        if (dt.Rows.Count < 1)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        string[] ArrEmpIds = EmpIds.Split(',');
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            intSerialNumber++;
            int intEmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
            string strEmpId = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
           

            if (EmpIds.Contains(strEmpId))
            {
                var list = new List<string>(ArrEmpIds);
                list.Remove(strEmpId);
                ArrEmpIds = list.ToArray();

                strHtml += "<td class=\"tdT\" id=\"tdCheckbox_" + intSerialNumber + "\" style=\"width:5%;text-align: center;\"><input type=\"checkbox\" checked=\"true\" id=\"Checkbox_" + intSerialNumber + "\" onchange=\"EmpCbxClick('" + intSerialNumber + "')\" onkeypress=\"return DisableEnter(event)\" ></td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" id=\"tdCheckbox_" + intSerialNumber + "\" style=\"width:5%;text-align: center;\"><input type=\"checkbox\" id=\"Checkbox_" + intSerialNumber + "\" onchange=\"EmpCbxClick('" + intSerialNumber + "')\" onkeypress=\"return DisableEnter(event)\" ></td>";
            }
                if (dt.Rows[intRowBodyCount]["USR_CODE"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpCode_" + intSerialNumber + "\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpCode_" + intSerialNumber + "\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                }
                if (dt.Rows[intRowBodyCount]["USR_NAME"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpName_" + intSerialNumber + "\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpName_" + intSerialNumber + "\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"></td>";
                }

                if (dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpDsgnName_" + intSerialNumber + "\"  style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" id=\"tdEmpDsgnName_" + intSerialNumber + "\"  style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                }
                if (dt.Rows[intRowBodyCount]["PYGRD_NAME"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" id=\"tdpygrdName_" + intSerialNumber + "\"   style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["PYGRD_NAME"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" id=\"tdpygrdName_" + intSerialNumber + "\"   style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                }
                if (dt.Rows[intRowBodyCount]["SPNSR_NAME"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" id=\"tdSpnsrName_" + intSerialNumber + "\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SPNSR_NAME"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" id=\"tdSpnsrName_" + intSerialNumber + "\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                }

                strHtml += "<td class=\"tdT\" id=\"tdEmployId_" + intSerialNumber + "\"   style=\" display:none;word-break: break-all; word-wrap:break-word;text-align: left;\"  >"+intEmployeeId+"</td>";
                strHtml += "</tr>";
            
        }
        if (ArrEmpIds.Length > 0)
        {
            foreach (string EmpEachId in ArrEmpIds)
            {
                if (EmpEachId != "")
                {
                    clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
                    clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
                    int intEmployeeId = Convert.ToInt32(EmpEachId);
                    objEntitylayerEmployeeTrnsfr.UserId = Convert.ToInt32(intEmployeeId);
                    DataTable dtEmployeeDetails = objBusinessEmployeeTrnsfr.ReadEmployeesDetailsById(objEntitylayerEmployeeTrnsfr);
                    strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                    intSerialNumber++;
                    strHtml += "<td class=\"tdT\" id=\"tdCheckbox_" + intSerialNumber + "\" style=\"width:5%;text-align: center;\"><input type=\"checkbox\" checked=\"true\" id=\"Checkbox_" + intSerialNumber + "\" onchange=\"EmpCbxClick('" + intSerialNumber + "')\" onkeypress=\"return DisableEnter(event)\" ></td>";
                    if (dtEmployeeDetails.Rows[0]["USR_CODE"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpCode_" + intSerialNumber + "\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtEmployeeDetails.Rows[0]["USR_CODE"].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpCode_" + intSerialNumber + "\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }
                    if (dtEmployeeDetails.Rows[0]["EMP_NAME"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpName_" + intSerialNumber + "\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtEmployeeDetails.Rows[0]["EMP_NAME"].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpName_" + intSerialNumber + "\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"></td>";
                    }

                    if (dtEmployeeDetails.Rows[0]["DSGN_NAME"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpDsgnName_" + intSerialNumber + "\"  style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtEmployeeDetails.Rows[0]["DSGN_NAME"].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdEmpDsgnName_" + intSerialNumber + "\"  style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                    }
                    if (dtEmployeeDetails.Rows[0]["PYGRD_NAME"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdpygrdName_" + intSerialNumber + "\"   style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtEmployeeDetails.Rows[0]["PYGRD_NAME"].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdpygrdName_" + intSerialNumber + "\"   style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                    }
                    if (dtEmployeeDetails.Rows[0]["SPNSR_NAME"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdSpnsrName_" + intSerialNumber + "\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtEmployeeDetails.Rows[0]["SPNSR_NAME"].ToString() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" id=\"tdSpnsrName_" + intSerialNumber + "\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                    }

                    strHtml += "<td class=\"tdT\" id=\"tdEmployId_" + intSerialNumber + "\"   style=\" display:none;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intEmployeeId + "</td>";
                    strHtml += "</tr>";
                
                }
            }
        }


        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();

        List<clsEntity_Emp_Transfer> objEntitylayerDivList = new List<clsEntity_Emp_Transfer>();
        List<clsEntity_Emp_Transfer> objEntitylayerEmpList = new List<clsEntity_Emp_Transfer>();
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
        if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentIdOld = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }

        if (ddlPaygrade.SelectedItem.Value != "--SELECT PAYGRADE--")
        {
            objEntitylayerEmployeeTrnsfr.PaygradeIdOld = Convert.ToInt32(ddlPaygrade.SelectedItem.Value);
        }
        if (ddlSponsor.SelectedItem.Value != "--SELECT SPONSOR--")
        {
            objEntitylayerEmployeeTrnsfr.SponsorIdOld = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntitylayerEmployeeTrnsfr.DivisionIdOld = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (radioCustTypeStaff.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.EmpType = 1;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.EmpType = 2;
        }

        if (ddlNewBussinessunit.SelectedItem.Value != "--SELECT BUSINESS UNIT--")
        {
            objEntitylayerEmployeeTrnsfr.BusinesUnitId = Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
        }

        if (cbxNewEmployeeId.Checked == true)
        {
            
        }
        if (ddlNewDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(ddlNewDepartment.SelectedItem.Value);
        }
       
        if (ddlnewPaygrade.SelectedItem.Value != "--SELECT PAYGRADE--")
        {
            objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(ddlnewPaygrade.SelectedItem.Value);
        } if (ddlreporter.SelectedItem.Value != "--SELECT REPORTER--")
        {
            objEntitylayerEmployeeTrnsfr.ReporterId = Convert.ToInt32(ddlreporter.SelectedItem.Value);
        }

        if (ddlNewSponsor.SelectedItem.Value != "--SELECT SPONSOR--")
        {
            objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(ddlNewSponsor.SelectedItem.Value);
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
                objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(hiddenDepartmentId.Value);
            }
            if (hiddenPaygradeId.Value != "")
            {
                objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(hiddenPaygradeId.Value);
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
            objEntitylayerEmployeeTrnsfr.Trans_Method = 1;
        }
        objEntitylayerEmployeeTrnsfr.Trans_Mode = 2;

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

        string TotalEmp = hiddenEmployeeIds.Value;

        string[] EachEmp = TotalEmp.Split(',');

        foreach (string EmpId in EachEmp)
        {
            if (EmpId != "" && EmpId != null)
            {
                clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfrEmp = new clsEntity_Emp_Transfer();
                objEntitylayerEmployeeTrnsfrEmp.EmployeeId = Convert.ToInt32(EmpId);
                if (cbxNewEmployeeId.Checked == true)
                {
                    //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    //clsEntityCommon objEntityCommon = new clsEntityCommon();
                    //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERSONAL_DETAILS);
                    //objEntityCommon.CorporateID = objEntitylayerEmployeeTrnsfr.BusinesUnitId;
                    //objEntityCommon.Organisation_Id = objEntitylayerEmployeeTrnsfr.OrgId;
                    //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    //string year = DateTime.Today.Year.ToString();
                    //objEntitylayerEmployeeTrnsfrEmp.EmpId = "EMP/" + year + "/" + strNextId;
                    int corpId=Convert.ToInt32(ddlNewBussinessunit.SelectedItem.Value);
                    objEntitylayerEmployeeTrnsfrEmp.EmpId = empRefFormatLoad(corpId, EmpId);

                }

                objEntitylayerEmpList.Add(objEntitylayerEmployeeTrnsfrEmp);
            }
        }



        if (clickedButton.ID == "btnSave")
        {
            objBusinessEmployeeTrnsfr.InsertEmployeeTransfer(objEntitylayerEmployeeTrnsfr, objEntitylayerDivList, objEntitylayerEmpList);
            Session["SUCCESS_EMPTRNS"] = "SAVE";
            Response.Redirect("hcm_Emp_Transfer_Bulk.aspx");
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
    public string empRefFormatLoad(int corpId, string EmpId)
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
                                if (strSplitWithHash[intcount] == "COR" || strSplitWithHash[intcount] == "USR"  || strSplitWithHash[intcount] == "YER" || strSplitWithHash[intcount] == "MON" )
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

            objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(EmpId);
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
                strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + EmpId;
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
                    strRealFormat = strRealFormat.Replace("#USR#", EmpId);
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
                    strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "/" + EmpId;
                }
                strRealFormat = strRealFormat.Replace("#", "");
                strRealFormat = strRealFormat.Replace("*", "");
                strRealFormat = strRealFormat.Replace("%", "");

            }

        }
        return strRealFormat;
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
            objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(dtTrnsDetails.Rows[0]["ORG_ID"].ToString());
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
            if (dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString() != "")
            {
                if (dtTrnsDetails.Rows[0]["OLDCORP_STS"].ToString() == "1")
                {
                    objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString());
                    ddlBusinessUnit.Items.FindByValue(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString()).Selected = true;

                    SelectedBUchange();
                }
                else
                {
                    objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString());
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["OLDCORP_NAME"].ToString(), dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString());
                    ddlBusinessUnit.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlBusinessUnit);

                    ddlBusinessUnit.Items.FindByValue(dtTrnsDetails.Rows[0]["OLDCORP_ID"].ToString()).Selected = true;
                }
            }
            ddlDepartment.ClearSelection();
            if (dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString() != "")
            {
                if (dtTrnsDetails.Rows[0]["CPRDEPT_STATUS_OLD"].ToString() == "1")
                {
                    ddlDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString()).Selected = true;
                    objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString());
                    selectedDepartmentChange();
                }
                else
                {
                    objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString());
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDEPT_NAME_OLD"].ToString(), dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString());
                    ddlDepartment.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDepartment);

                    ddlDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID_OLD"].ToString()).Selected = true;
                    selectedDepartmentChange();
                }
            }
            ddlPaygrade.ClearSelection();
            if (dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString()!="")
            {
            if (dtTrnsDetails.Rows[0]["PYGRD_STATUS_OLD"].ToString() == "1")
            {
                ddlPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString()).Selected = true;
                objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString());
            }
            else
            {
                objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString());
                ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["PYGRD_NAME_OLD"].ToString(), dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString());
                ddlPaygrade.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlPaygrade);

                ddlPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID_OLD"].ToString()).Selected = true;
            }
            }
            ddlSponsor.ClearSelection();
            if (dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString() != "")
            {
                if (dtTrnsDetails.Rows[0]["SPSNSR_STATUS_OLD"].ToString() == "1")
                {
                    ddlSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString()).Selected = true;
                    objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString());
                }
                else
                {
                    objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString());
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["SPNSR_NAME_OLD"].ToString(), dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString());
                    ddlSponsor.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlSponsor);

                    ddlSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID_OLD"].ToString()).Selected = true;
                }
            }
            ddlDivision.ClearSelection();
            if (dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString() != "")
            {
                if (dtTrnsDetails.Rows[0]["CPRDIV_STATUS_OLD"].ToString() == "1")
                {
                    ddlDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString()).Selected = true;
                    objEntitylayerEmployeeTrnsfr.DivisionId = Convert.ToInt32(dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString());
                }
                else
                {
                    objEntitylayerEmployeeTrnsfr.DivisionId = Convert.ToInt32(dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString());
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDIV_NAME_OLD"].ToString(), dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID_OLD"].ToString()).Selected = true;
                }
            }
            if (dtTrnsDetails.Rows[0]["EMPTRNS_STFF_OR_WRKR"].ToString() != "")
            {
                if (dtTrnsDetails.Rows[0]["EMPTRNS_STFF_OR_WRKR"].ToString() == "1")
                {
                    radioCustTypeStaff.Checked = true;
                    objEntitylayerEmployeeTrnsfr.EmpType = 0;
                }
                else
                {
                    radioCustTypeWorker.Checked = true;
                    objEntitylayerEmployeeTrnsfr.EmpType = 1;
                }
            }

             string EmpIds = "";
            foreach (DataRow DTROW in dtTrnsDetails.Rows)
            {
                if (DTROW["EMPLOYEE_IDS"].ToString()!="")
                    EmpIds = EmpIds + "," + DTROW["EMPLOYEE_IDS"].ToString();
            }
            hiddenEmployeeIds.Value = EmpIds;
            DataTable dtEmployee = objBusinessEmployeeTrnsfr.ReadEmployeeList(objEntitylayerEmployeeTrnsfr);
            string strEmplyeeList = CovertListToHTML(dtEmployee, EmpIds);
            divEmplyeeList.InnerHtml = strEmplyeeList;


            ddlNewBussinessunit.ClearSelection();
            if (dtTrnsDetails.Rows[0]["CORPRT_ID"].ToString() != "")
            {
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
            }

            ddlNewDepartment.ClearSelection();
            if (dtTrnsDetails.Rows[0]["CPRDEPT_STATUS"].ToString() == "1")
            {
                ddlNewDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                selectedNewDepartmentChange();
            }
            else
            {
                ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["CPRDEPT_NAME"].ToString(), dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString());
                ddlNewDepartment.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlNewDepartment);

                ddlNewDepartment.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDEPT_ID"].ToString()).Selected = true;
                selectedNewDepartmentChange();
            }

            ddlnewPaygrade.ClearSelection();
            if (dtTrnsDetails.Rows[0]["PYGRD_STATUS"].ToString() == "1")
            {
                ddlnewPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["PYGRD_NAME"].ToString(), dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString());
                ddlnewPaygrade.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlnewPaygrade);

                ddlnewPaygrade.Items.FindByValue(dtTrnsDetails.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
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
                ddlNewSponsor.ClearSelection();
                if (dtTrnsDetails.Rows[0]["SPSNSR_STATUS"].ToString() == "1")
                {
                    ddlNewSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtTrnsDetails.Rows[0]["SPNSR_NAME"].ToString(), dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString());
                    ddlNewSponsor.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlNewSponsor);

                    ddlNewSponsor.Items.FindByValue(dtTrnsDetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
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
                    ddlNewDivision.Items.FindByValue(dtTrnsDetails.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
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
            if (dtTrnsDetails.Rows[0]["EMPTRNS_NEW_EMP_ID"].ToString() != "")
            {
                cbxNewEmployeeId.Checked = true;
            }
            if (dtTrnsDetails.Rows[0]["EMPTRNS_CNFRM_USR_ID"].ToString() != "")
            {
                ddlBusinessUnit.Enabled = false;
                ddlNewBussinessunit.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlNewDepartment.Enabled = false;
                ddlPaygrade.Enabled = false;
                ddlnewPaygrade.Enabled = false;
                ddlproject.Enabled = false;
                ddlSponsor.Enabled = false;
                ddlNewSponsor.Enabled = false;
                txtFromdate.Disabled = true;
                txtTodate.Disabled = true;
                ddlDivision.Enabled = false;
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
                btnUpdateClose.Visible = false;
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
    public static string ManpowerTableCreator(string strCorpId, string strOrgId)
    {

        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();

        objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(strOrgId);
        objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(strCorpId);
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
                int totalResource = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["MNP_RESOURCENUM"].ToString());
                int intFilledCount = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["SELECTED COUNT"].ToString());
                int intFilledCountEmpTrnsSngle = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["SELECTED_COUNT_TRNSFR"].ToString());
                int intFilledCountEmpTrnsMult = Convert.ToInt32(dtManList.Rows[intRowBodyCount]["SELECTED_COUNT_TRNSFR_MULTY"].ToString());
                int IntRemainCount = 0;
                if (intFilledCountEmpTrnsMult != 0)
                {
                    IntRemainCount = totalResource - intFilledCount - intFilledCountEmpTrnsMult;
                }
                else
                {
                    IntRemainCount = totalResource - intFilledCount - intFilledCountEmpTrnsSngle;
                }
                if (IntRemainCount > 0)
                { string ManpowerId = dtManList.Rows[intRowBodyCount]["MNPRQST_ID"].ToString();
                    intCount++;
                    strHtml += "<tr id=\"trMan_"+ManpowerId+"\" >";
                    strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intCount + " </td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["MNP_REFNUM"].ToString() + " </td>";
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManList.Rows[intRowBodyCount]["DATE"].ToString() + " </td>";



                   
                    strHtml += "<td Id=\"tdremainCount_" + ManpowerId + "\" class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + IntRemainCount + " </td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + " </td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManList.Rows[intRowBodyCount]["PROJECT"].ToString() + " </td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"checkbox\" name=\"CbxMan\" Id=\"cbxManPwr_" + ManpowerId + "\"  onchange=\"IncrmntConfrmCounter()\"  onclick=\"return ManCbxClick(this.id,'" + ManpowerId + "')\" ></td>";
                    strHtml += "<td class=\"tdT\" style=\"display:none; width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManList.Rows[intRowBodyCount]["MNPRQST_ID"] + "</td>";
                    strHtml += "</tr>";
                }
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
    public static string[] ManPowerDetailsFill(string intCorpId, string intOrgId, string intManpId)
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
            PassingString[0] = dtShortlist.Rows[0]["MNP_REFNUM"].ToString();

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