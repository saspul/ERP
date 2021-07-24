using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Web.Services;
using System.Threading;

public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_hcm_Emp_welfare_service : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        if (!IsPostBack)
        {
            Categoryload();
            Designationload();
            Departmentload();
            Divisionload();
            Employeeload();
            //CurrencyLoad();
           // LimitRow();
            divddlCategory.Focus();
            txtServiceName.Attributes.Add("onkeypress", "return isTag(event)");
            cbxStatus.Checked = true;
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service_Master);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
         //   HiddenEnableModify.Value = "0";
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
                       // HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
              //  lblEntry.Text = "Edit Welfare Service Category";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                 View(strId);

           //     lblEntry.Text = "View Welfare Service Category";
            }

            else
            {
             //   lblEntry.Text = "Add Welfare Service Category";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
              //  divCurrency.Visible = false;

            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }

            else if (strInsUpd == "CancelWelfare")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancel", "SuccessCancel();", true);
            }
        }
    }

    public void Categoryload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCategory = objBusiness_Welfare_Service.ReadCategory(objEntityWelfare_Service);
        ddlCategory.Items.Clear();

        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = "WLFRCAT_NAME";
        ddlCategory.DataValueField = "WLFRCAT_ID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "-- SELECT CATEGORY --");
    }
    public void Designationload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDesignation = objBusiness_Welfare_Service.ReadDesignation(objEntityWelfare_Service);
        ddlDesignation.Items.Clear();

        ddlDesignation.DataSource = dtDesignation;
        ddlDesignation.DataTextField = "DSGN_NAME";
        ddlDesignation.DataValueField = "DSGN_ID";
        ddlDesignation.DataBind();
    }
    public void Departmentload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDept = objBusiness_Welfare_Service.ReadDepartment(objEntityWelfare_Service);
        ddlDepartment.Items.Clear();

        ddlDepartment.DataSource = dtDept;
        ddlDepartment.DataTextField = "CPRDEPT_NAME";
        ddlDepartment.DataValueField = "CPRDEPT_ID";
        ddlDepartment.DataBind();
    }
    public void Divisionload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusiness_Welfare_Service.ReadDivision(objEntityWelfare_Service);
        ddlDivision.Items.Clear();

        ddlDivision.DataSource = dtDivision;
        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();
    }
    public void Employeeload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmpl = objBusiness_Welfare_Service.ReadEmployee(objEntityWelfare_Service);
        ddlEmployee.Items.Clear();

        ddlEmployee.DataSource = dtEmpl;
        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();
    }
    public void CurrencyLoad()
    {
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();

        int intUserId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntity_Department_list> ObjEntityDepartmentList = new List<clsEntity_Department_list>();
        List<clsEntity_Designation_list> ObjEntityDesignationList = new List<clsEntity_Designation_list>();
        List<clsEntity_Division_list> ObjEntityDivisionList = new List<clsEntity_Division_list>();
        List<clsEntity_Employee_list> ObjEntityEmployeeList = new List<clsEntity_Employee_list>();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityWelfare_Service.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlCategory.SelectedValue != "-- SELECT CATEGORY --")
        {
            objEntityWelfare_Service.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
        }
        if (txtServiceName.Text != "")
        {
            objEntityWelfare_Service.ServiceName = txtServiceName.Text.Trim().ToUpper();
        }
     
        if (cbxStatus.Checked == true)
        {
            objEntityWelfare_Service.Status = 1;
        }
        else
        {
            objEntityWelfare_Service.Status = 0;
        }
       
        objEntityWelfare_Service.ServiceDescription = txtServiceDesc.Text;
        //if (divCurrency.Visible == true)
        //{
       // objEntityWelfare_Service.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedValue);
        //    }
        if (cbxAllDept.Checked == true)
        {
            objEntityWelfare_Service.AllDepartment = 1;
            cbxAllEmp.Checked = true;
            cbxAllDiv.Checked = true;
            cbxDsgn.Checked = true;
        }
        else
        {
            if (HiddenDeptList.Value != "")
            {
                string[] tokens = HiddenDeptList.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    int DeptId = Convert.ToInt32(tokens[i]);
                    clsEntity_Department_list objentityDept = new clsEntity_Department_list();
                    objentityDept.DepartmentId = DeptId;
                    ObjEntityDepartmentList.Add(objentityDept);
                }
            }
        }
        if (cbxAllDiv.Checked == true)
        {
            objEntityWelfare_Service.AllDivision = 1;
        }
        else
        {
            if (HiddenDivisionList.Value != "")
            {
                string[] tokens = HiddenDivisionList.Value.Split(',');

                for (int i = 0; i < tokens.Count(); i++)
                {
                    int DivId = Convert.ToInt32(tokens[i]);
                    clsEntity_Division_list objentityDiv = new clsEntity_Division_list();
                    objentityDiv.DivisionId = DivId;
                    ObjEntityDivisionList.Add(objentityDiv);
                }
            }
        }
        if (cbxDsgn.Checked == true)
        {
            objEntityWelfare_Service.AllDesignation = 1;
            cbxAllEmp.Checked = true;
        }

        else
        {
            if (hiddenselectedDesignlist.Value != "")
            {
                string[] tokens = hiddenselectedDesignlist.Value.Split(',');

                for (int i = 0; i < tokens.Count(); i++)
                {
                    int dsgnId = Convert.ToInt32(tokens[i]);
                    clsEntity_Designation_list objentityDesgn = new clsEntity_Designation_list();
                    objentityDesgn.DesignationId = dsgnId;
                    ObjEntityDesignationList.Add(objentityDesgn);

                }
            }
        }
        if (cbxAllEmp.Checked == true)
        {
            objEntityWelfare_Service.AllEmployee = 1;
            cbxAllDiv.Checked = true;
            cbxDsgn.Checked = true;
            cbxAllDept.Checked = true;
            objEntityWelfare_Service.AllDesignation = 1;
            objEntityWelfare_Service.AllDivision = 1;
            objEntityWelfare_Service.AllDepartment = 1;

        }

        else
        {
            if (HiddenEmpList.Value != "")
            {
                string[] tokens = HiddenEmpList.Value.Split(',');

                for (int i = 0; i < tokens.Count(); i++)
                {

                    int empId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employee_list objentityEmp = new clsEntity_Employee_list();
                    objentityEmp.EmployeeId = empId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls = new List<clsEntity_Welfare_Limit_list>();
        if (HiddenAdd.Value != "")
        {
            string jsonData = HiddenAdd.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string k = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
            foreach (clsWBData objclsWBData in objWBDataList)
            {

                clsEntity_Welfare_Limit_list objEntity_Welfare_Service = new clsEntity_Welfare_Limit_list();
                if (objclsWBData.QUANTITY != "" && objclsWBData.UNIT != "" && objclsWBData.FREQUENCY != "" && objclsWBData.FROMDATE != "" && objclsWBData.TODATE != "")
                {
                    objEntity_Welfare_Service.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                    objEntity_Welfare_Service.Mandatory = Convert.ToInt32(objclsWBData.MADATORY);
                    objEntity_Welfare_Service.Unit = Convert.ToInt32(objclsWBData.UNIT);
                    if(objclsWBData.UNIT=="1")
                    objEntity_Welfare_Service.CurrencyId = Convert.ToInt32(objclsWBData.CURRENCY);
                    objEntity_Welfare_Service.Frequency = Convert.ToInt32(objclsWBData.FREQUENCY);
                    objEntity_Welfare_Service.FromPeriod = objCommon.textToDateTime(objclsWBData.FROMDATE);
                    objEntity_Welfare_Service.ToPeriod = objCommon.textToDateTime(objclsWBData.TODATE);
                    objWelfare_LimitDtls.Add(objEntity_Welfare_Service);
                }
            }

        }
        DataTable dtCategory = objBusiness_Welfare_Service.CheckCategoryId(objEntityWelfare_Service);
        if (dtCategory.Rows.Count > 0)
        {
            if (dtCategory.Rows[0]["WLFRCAT_ID"].ToString() != "")
            {

                objBusiness_Welfare_Service.AddWelfareService(objEntityWelfare_Service, ObjEntityDepartmentList, ObjEntityDesignationList, ObjEntityDivisionList, ObjEntityEmployeeList, objWelfare_LimitDtls);

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("hcm_Emp_welfare_service.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("hcm_Emp_Welfare_Service_List.aspx?InsUpd=Ins");
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCancelMsg", "CategoryCancelMsg();", true);
            

        }
     
    }
    public class clsWBData
    {
        public string ROWID { get; set; }
        public string QUANTITY { get; set; }
        public string MADATORY { get; set; }
        public string UNIT { get; set; }
        public string CURRENCY { get; set; }
        public string FREQUENCY { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    public void Update(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        Categoryload();
        Designationload();
        Departmentload();
        Divisionload();
        Employeeload();
        CurrencyLoad();
        //   divCurrency.Visible = false;
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        List<clsEntity_Department_list> ObjEntityDepartmentList = new List<clsEntity_Department_list>();
        List<clsEntity_Designation_list> ObjEntityDesignationList = new List<clsEntity_Designation_list>();
        List<clsEntity_Division_list> ObjEntityDivisionList = new List<clsEntity_Division_list>();
        List<clsEntity_Employee_list> ObjEntityEmployeeList = new List<clsEntity_Employee_list>();
        objEntityWelfare_Service.WelfareServiceId = Convert.ToInt32(strId);
        int intCorpId = 0, intAllDept = 0, intAllDiv = 0, intAllDsgn = 0, intAllEmp = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtService = objBusiness_Welfare_Service.ReadServiceDetailsById(objEntityWelfare_Service);
        if (dtService.Rows.Count > 0)
        {
            if (dtService.Rows[0]["WLFRCAT_ID"].ToString() != "")
            {
                ddlCategory.SelectedValue = dtService.Rows[0]["WLFRCAT_ID"].ToString();
            }
            if (dtService.Rows[0]["WLFRSRVC_NAME"].ToString() != "")
            {
                txtServiceName.Text = dtService.Rows[0]["WLFRSRVC_NAME"].ToString();
            }
            if (dtService.Rows[0]["WLFRSRVC_DES"].ToString() != "")
            {
                txtServiceDesc.Text = dtService.Rows[0]["WLFRSRVC_DES"].ToString();
            }
            if (dtService.Rows[0]["WLFRSRVC_STATUS"].ToString() == "0")
            {
                cbxStatus.Checked = false;
            }
            else
            {
                cbxStatus.Checked = true;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDIV"].ToString() == "0")
            {
                cbxAllDiv.Checked = false;
            }
            else
            {
                cbxAllDiv.Checked = true;
                //ddlDivision.Enabled = false;
                intAllDiv = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDEPT"].ToString() == "0")
            {
                cbxAllDept.Checked = false;
            }
            else
            {
                cbxAllDept.Checked = true;
                //ddlDepartment.Enabled = false;
                intAllDept = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDSGN"].ToString() == "0")
            {
                cbxDsgn.Checked = false;
            }
            else
            {
                cbxDsgn.Checked = true;
                //ddlDesignation.Enabled = false;
                intAllDsgn = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLEMP"].ToString() == "0")
            {
                cbxAllEmp.Checked = false;
            }
            else
            {
                cbxAllEmp.Checked = true;
                //ddlEmployee.Enabled = false;
                intAllEmp = 1;
            }
        }


        DataTable dtServiceDept = objBusiness_Welfare_Service.ReadServiceDeptById(objEntityWelfare_Service);
        if (intAllDept == 0)
        {
            for (int i = 0; i < dtServiceDept.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenDeptList.Value = dtServiceDept.Rows[i][0].ToString();
                else
                    HiddenDeptList.Value = HiddenDeptList.Value + "," + dtServiceDept.Rows[i][0];
            }
        }
        DataTable dtServiceDivision = objBusiness_Welfare_Service.ReadServiceDivisionById(objEntityWelfare_Service);
        if (intAllDiv == 0)
        {

            for (int i = 0; i < dtServiceDivision.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenDivisionList.Value = dtServiceDivision.Rows[i][0].ToString();
                else
                    HiddenDivisionList.Value = HiddenDivisionList.Value + "," + dtServiceDivision.Rows[i][0];
            }
        }
        DataTable dtServiceDsgn = objBusiness_Welfare_Service.ReadServiceDesigById(objEntityWelfare_Service);
        if (intAllDsgn == 0)
        {
            for (int i = 0; i < dtServiceDsgn.Rows.Count; i++)
            {
                if (i == 0)
                    hiddenselectedDesignlist.Value = dtServiceDsgn.Rows[i][0].ToString();
                else
                    hiddenselectedDesignlist.Value = hiddenselectedDesignlist.Value + "," + dtServiceDsgn.Rows[i][0];
            }
        }
        DataTable dtServiceEmp = objBusiness_Welfare_Service.ReadServiceEmployeeById(objEntityWelfare_Service);
        if (intAllEmp == 0)
        {
            for (int i = 0; i < dtServiceEmp.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenEmpList.Value = dtServiceEmp.Rows[i][0].ToString();
                else
                    HiddenEmpList.Value = HiddenEmpList.Value + "," + dtServiceEmp.Rows[i][0];
            }
        }
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("WELFAREID", typeof(int));
        dtDetail.Columns.Add("WELFARESUB_ID", typeof(int));
        dtDetail.Columns.Add("QUANTITY", typeof(string));
        dtDetail.Columns.Add("UNIT", typeof(string));
        dtDetail.Columns.Add("MANDATORY", typeof(string));
        dtDetail.Columns.Add("CURRENCY", typeof(int));
        dtDetail.Columns.Add("FREQUENCY", typeof(int));
        dtDetail.Columns.Add("FROMDATE", typeof(string));
        dtDetail.Columns.Add("TODATE", typeof(string));
        dtDetail.Columns.Add("TRANSACTION", typeof(string));
       
        dtDetail.Columns.Add("DEPTCOUNT", typeof(string)); 
        dtDetail.Columns.Add("DSGNCOUNT", typeof(string));
        dtDetail.Columns.Add("DIVCOUNT", typeof(string));
        dtDetail.Columns.Add("EMPCOUNT", typeof(string));

        DataTable dtSubDtls = objBusiness_Welfare_Service.ReadServiceSubDtlById(objEntityWelfare_Service);
        for (int intcnt = 0; intcnt < dtSubDtls.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["WELFAREID"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["WLFRSRVC_ID"].ToString());
            drDtl["WELFARESUB_ID"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["WLFSRVCDTL_ID"].ToString());
            drDtl["QUANTITY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_QNTY"].ToString();
            drDtl["MANDATORY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_MANDTRY"].ToString();
            if (dtSubDtls.Rows[intcnt]["CRNCMST_ID"].ToString() != "")
            {
                drDtl["CURRENCY"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["CRNCMST_ID"].ToString());
            }
            drDtl["UNIT"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_UNIT"].ToString();
            drDtl["FREQUENCY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_FRQNCY"].ToString();
            drDtl["FROMDATE"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_FRMPERD"].ToString();
            drDtl["TODATE"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_TOPERD"].ToString();
            drDtl["TRANSACTION"] = dtSubDtls.Rows[intcnt]["TRANSACTION_COUNT"].ToString();
            drDtl["DEPTCOUNT"] = dtSubDtls.Rows[intcnt]["DEPTCOUNT"].ToString();
            drDtl["DSGNCOUNT"] = dtSubDtls.Rows[intcnt]["DESGNCOUNT"].ToString();
            drDtl["DIVCOUNT"] = dtSubDtls.Rows[intcnt]["DIVCOUNT"].ToString();
            drDtl["EMPCOUNT"] = dtSubDtls.Rows[intcnt]["USERCOUNT"].ToString();

            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

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
    public void View(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnClear.Visible = false;
        Categoryload();
        Designationload();
        Departmentload();
        Divisionload();
        Employeeload();
      //  CurrencyLoad();
        txtServiceDesc.Enabled = false;
        divEmployeeTable.Disabled = true;
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        List<clsEntity_Department_list> ObjEntityDepartmentList = new List<clsEntity_Department_list>();
        List<clsEntity_Designation_list> ObjEntityDesignationList = new List<clsEntity_Designation_list>();
        List<clsEntity_Division_list> ObjEntityDivisionList = new List<clsEntity_Division_list>();
        List<clsEntity_Employee_list> ObjEntityEmployeeList = new List<clsEntity_Employee_list>();
        objEntityWelfare_Service.WelfareServiceId = Convert.ToInt32(strId);
        int intCorpId = 0, intAllDept = 0, intAllDiv = 0, intAllDsgn = 0, intAllEmp = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtService = objBusiness_Welfare_Service.ReadServiceDetailsById(objEntityWelfare_Service);
        if (dtService.Rows.Count > 0)
        {
            if (dtService.Rows[0]["WLFRCAT_ID"].ToString() != "")
            {
                ddlCategory.SelectedValue = dtService.Rows[0]["WLFRCAT_ID"].ToString();
                ddlCategory.Enabled = false;
            }
            if (dtService.Rows[0]["WLFRSRVC_NAME"].ToString() != "")
            {
                txtServiceName.Text = dtService.Rows[0]["WLFRSRVC_NAME"].ToString();
                txtServiceName.Enabled = false;

            }
            if (dtService.Rows[0]["WLFRSRVC_DES"].ToString() != "")
            {
                txtServiceDesc.Text = dtService.Rows[0]["WLFRSRVC_DES"].ToString();
                txtServiceDesc.Enabled = false;

            }
            if (dtService.Rows[0]["WLFRSRVC_STATUS"].ToString() == "0")
            {
                cbxStatus.Checked = false;
                divcbxStatus.Disabled = true;

            }
            else
            {
                cbxStatus.Checked = true;
                cbxStatus.Disabled = false;

            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDIV"].ToString() == "0")
            {
                cbxAllDiv.Checked = false;
                divcbxAllDiv.Disabled = true;

            }
            else
            {
                cbxAllDiv.Checked = true;
                divcbxAllDiv.Disabled = true;

                //ddlDivision.Enabled = false;
                intAllDiv = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDEPT"].ToString() == "0")
            {
                divcbxAllDept.Disabled = true;
                cbxAllDept.Checked = false;
            }
            else
            {
                cbxAllDept.Checked = true;
                divcbxAllDept.Disabled = true;

                //ddlDepartment.Enabled = false;
                intAllDept = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLDSGN"].ToString() == "0")
            {
                cbxDsgn.Checked = false;
                divcbxDsgn.Disabled = true;

            }
            else
            {
                divcbxDsgn.Disabled = true;
                cbxDsgn.Checked = true;
                intAllDsgn = 1;
            }
            if (dtService.Rows[0]["WLFRSRVC_ALLEMP"].ToString() == "0")
            {
                cbxAllEmp.Checked = false;
                divcbxAllEmp.Disabled = true;

            }
            else
            {
                cbxAllEmp.Checked = true;
                divcbxAllEmp.Disabled = true;
                //ddlDesignation.Enabled = false;
                intAllEmp = 1;
            }
        }
        DataTable dtServiceDept = objBusiness_Welfare_Service.ReadServiceDeptById(objEntityWelfare_Service);
        if (intAllDept == 0)
        {
            for (int i = 0; i < dtServiceDept.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenDeptList.Value = dtServiceDept.Rows[i][0].ToString();
                else
                    HiddenDeptList.Value = HiddenDeptList.Value + "," + dtServiceDept.Rows[i][0];
            }
        }
        DataTable dtServiceDivision = objBusiness_Welfare_Service.ReadServiceDivisionById(objEntityWelfare_Service);
        if (intAllDiv == 0)
        {

            for (int i = 0; i < dtServiceDivision.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenDivisionList.Value = dtServiceDivision.Rows[i][0].ToString();
                else
                    HiddenDivisionList.Value = HiddenDivisionList.Value + "," + dtServiceDivision.Rows[i][0];
            }
        }
        DataTable dtServiceDsgn = objBusiness_Welfare_Service.ReadServiceDesigById(objEntityWelfare_Service);
        if (intAllDsgn == 0)
        {
            for (int i = 0; i < dtServiceDsgn.Rows.Count; i++)
            {
                if (i == 0)
                    hiddenselectedDesignlist.Value = dtServiceDsgn.Rows[i][0].ToString();
                else
                    hiddenselectedDesignlist.Value = hiddenselectedDesignlist.Value + "," + dtServiceDsgn.Rows[i][0];
            }
        }
        DataTable dtServiceEmp = objBusiness_Welfare_Service.ReadServiceEmployeeById(objEntityWelfare_Service);
        if (intAllEmp == 0)
        {
            for (int i = 0; i < dtServiceEmp.Rows.Count; i++)
            {
                if (i == 0)
                    HiddenEmpList.Value = dtServiceEmp.Rows[i][0].ToString();
                else
                    HiddenEmpList.Value = HiddenEmpList.Value + "," + dtServiceEmp.Rows[i][0];
            }
        }
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("WELFAREID", typeof(int));
        dtDetail.Columns.Add("WELFARESUB_ID", typeof(int));
        dtDetail.Columns.Add("QUANTITY", typeof(string));
        dtDetail.Columns.Add("UNIT", typeof(string));
        dtDetail.Columns.Add("MANDATORY", typeof(string));
        dtDetail.Columns.Add("CURRENCY", typeof(int));
        dtDetail.Columns.Add("FREQUENCY", typeof(int));
        dtDetail.Columns.Add("FROMDATE", typeof(string));
        dtDetail.Columns.Add("TODATE", typeof(string));
        dtDetail.Columns.Add("TRANSACTION", typeof(string));

        dtDetail.Columns.Add("DEPTCOUNT", typeof(string));
        dtDetail.Columns.Add("DSGNCOUNT", typeof(string));
        dtDetail.Columns.Add("DIVCOUNT", typeof(string));
        dtDetail.Columns.Add("EMPCOUNT", typeof(string));

        DataTable dtSubDtls = objBusiness_Welfare_Service.ReadServiceSubDtlById(objEntityWelfare_Service);
        for (int intcnt = 0; intcnt < dtSubDtls.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["WELFAREID"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["WLFRSRVC_ID"].ToString());
            drDtl["WELFARESUB_ID"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["WLFSRVCDTL_ID"].ToString());
            drDtl["QUANTITY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_QNTY"].ToString();
            drDtl["MANDATORY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_MANDTRY"].ToString();
            if (dtSubDtls.Rows[intcnt]["CRNCMST_ID"].ToString() != "")
            {
                drDtl["CURRENCY"] = Convert.ToInt32(dtSubDtls.Rows[intcnt]["CRNCMST_ID"].ToString());
            }
            drDtl["UNIT"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_UNIT"].ToString();
            drDtl["FREQUENCY"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_FRQNCY"].ToString();
            drDtl["FROMDATE"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_FRMPERD"].ToString();
            drDtl["TODATE"] = dtSubDtls.Rows[intcnt]["WLFRSRVC_TOPERD"].ToString();
            drDtl["TRANSACTION"] = dtSubDtls.Rows[intcnt]["TRANSACTION_COUNT"].ToString();
            drDtl["DEPTCOUNT"] = dtSubDtls.Rows[intcnt]["DEPTCOUNT"].ToString();
            drDtl["DSGNCOUNT"] = dtSubDtls.Rows[intcnt]["DESGNCOUNT"].ToString();
            drDtl["DIVCOUNT"] = dtSubDtls.Rows[intcnt]["DIVCOUNT"].ToString();
            drDtl["EMPCOUNT"] = dtSubDtls.Rows[intcnt]["USERCOUNT"].ToString();

            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenView.Value = strJson;
    }
    [WebMethod]
    public static string DropdownCurrencyBind(string strOrgId, string strCorpId)
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        objEntityWelfare_Service.OrgId = Convert.ToInt32(strOrgId);
        objEntityWelfare_Service.CorpId = Convert.ToInt32(strCorpId);
        DataTable dtSubConrt = objBusiness_Welfare_Service.ReadCurrency(objEntityWelfare_Service);
        dtSubConrt.TableName = "dtTableLoadCurrency";
    
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtSubConrt.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        List<clsEntity_Department_list> ObjEntityDepartmentList = new List<clsEntity_Department_list>();
        List<clsEntity_Designation_list> ObjEntityDesignationList = new List<clsEntity_Designation_list>();
        List<clsEntity_Division_list> ObjEntityDivisionList = new List<clsEntity_Division_list>();
        List<clsEntity_Employee_list> ObjEntityEmployeeList = new List<clsEntity_Employee_list>();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityWelfare_Service.WelfareServiceId = Convert.ToInt32(strId);

            if (Session["USERID"] != null)
            {
                objEntityWelfare_Service.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (ddlCategory.SelectedValue != "-- SELECT CATEGORY --")
            {
                objEntityWelfare_Service.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            }
            if (txtServiceName.Text != "")
            {
                objEntityWelfare_Service.ServiceName = txtServiceName.Text.Trim().ToUpper();
            }
            if (cbxStatus.Checked == true)
            {
                objEntityWelfare_Service.Status = 1;
            }
            else
            {
                objEntityWelfare_Service.Status = 0;
            }

            objEntityWelfare_Service.ServiceDescription = txtServiceDesc.Text;
            if (cbxAllDept.Checked == true)
            {
                objEntityWelfare_Service.AllDepartment = 1;
                cbxAllEmp.Checked = true;
                cbxAllDiv.Checked = true;
                cbxDsgn.Checked = true;
            }
            else
            {
                if (HiddenDeptList.Value != "")
                {
                    string[] tokens = HiddenDeptList.Value.Split(',');
                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        int DeptId = Convert.ToInt32(tokens[i]);
                        clsEntity_Department_list objentityDept = new clsEntity_Department_list();
                        objentityDept.DepartmentId = DeptId;
                        ObjEntityDepartmentList.Add(objentityDept);
                    }
                }
            }
            if (cbxAllDiv.Checked == true)
            {
                objEntityWelfare_Service.AllDivision = 1;
            }
            else
            {
                if (HiddenDivisionList.Value != "")
                {
                    string[] tokens = HiddenDivisionList.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        int DivId = Convert.ToInt32(tokens[i]);
                        clsEntity_Division_list objentityDiv = new clsEntity_Division_list();
                        objentityDiv.DivisionId = DivId;
                        ObjEntityDivisionList.Add(objentityDiv);
                    }
                }
            }
            if (cbxDsgn.Checked == true)
            {
                objEntityWelfare_Service.AllDesignation = 1;
                cbxAllEmp.Checked = true;
            }

            else
            {
                if (hiddenselectedDesignlist.Value != "")
                {
                    string[] tokens = hiddenselectedDesignlist.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        int dsgnId = Convert.ToInt32(tokens[i]);
                        clsEntity_Designation_list objentityDesgn = new clsEntity_Designation_list();
                        objentityDesgn.DesignationId = dsgnId;
                        ObjEntityDesignationList.Add(objentityDesgn);
                    }
                }
            }
            if (cbxAllEmp.Checked == true)
            {
                objEntityWelfare_Service.AllEmployee = 1;
                cbxAllDiv.Checked = true;
                cbxDsgn.Checked = true;
                cbxAllDept.Checked = true;
                objEntityWelfare_Service.AllDesignation = 1;
                objEntityWelfare_Service.AllDivision = 1;
                objEntityWelfare_Service.AllDepartment = 1;
            }

            else
            {
                if (HiddenEmpList.Value != "")
                {
                    string[] tokens = HiddenEmpList.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {

                        int empId = Convert.ToInt32(tokens[i]);
                        clsEntity_Employee_list objentityEmp = new clsEntity_Employee_list();
                        objentityEmp.EmployeeId = empId;
                        ObjEntityEmployeeList.Add(objentityEmp);
                    }
                }
            }
            List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Insert = new List<clsEntity_Welfare_Limit_list>();
            List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Update = new List<clsEntity_Welfare_Limit_list>();
            List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Delete = new List<clsEntity_Welfare_Limit_list>();
            if (HiddenAdd.Value != "")
            {
                string jsonData = HiddenAdd.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                List<clsWBData> objWBDataList = new List<clsWBData>();
                //   UserData  data
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
                foreach (clsWBData objclsWBData in objWBDataList)
                {
                    clsEntity_Welfare_Limit_list objEntity_Welfare_Service = new clsEntity_Welfare_Limit_list();

                    if (objclsWBData.EVTACTION == "INS")
                    {
                        if (objclsWBData.QUANTITY != "" && objclsWBData.UNIT != "" && objclsWBData.FREQUENCY != "" && objclsWBData.FROMDATE != "" && objclsWBData.TODATE != "")
                        {
                            objEntity_Welfare_Service.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                            objEntity_Welfare_Service.Mandatory = Convert.ToInt32(objclsWBData.MADATORY);
                            objEntity_Welfare_Service.Unit = Convert.ToInt32(objclsWBData.UNIT);
                            if (objclsWBData.UNIT == "1")

                                objEntity_Welfare_Service.CurrencyId = Convert.ToInt32(objclsWBData.CURRENCY);
                            objEntity_Welfare_Service.Frequency = Convert.ToInt32(objclsWBData.FREQUENCY);
                            objEntity_Welfare_Service.FromPeriod = objCommon.textToDateTime(objclsWBData.FROMDATE);
                            objEntity_Welfare_Service.ToPeriod = objCommon.textToDateTime(objclsWBData.TODATE);
                            objWelfare_LimitDtls_Insert.Add(objEntity_Welfare_Service);
                        }
                    }
                    if (objclsWBData.EVTACTION == "UPD")
                    {
                        if (objclsWBData.QUANTITY != "" && objclsWBData.UNIT != "" && objclsWBData.FREQUENCY != "" && objclsWBData.FROMDATE != "" && objclsWBData.TODATE != "")
                        {
                            objEntity_Welfare_Service.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                            objEntity_Welfare_Service.Mandatory = Convert.ToInt32(objclsWBData.MADATORY);
                            objEntity_Welfare_Service.Unit = Convert.ToInt32(objclsWBData.UNIT);
                            if (objclsWBData.UNIT == "1")

                                objEntity_Welfare_Service.CurrencyId = Convert.ToInt32(objclsWBData.CURRENCY);
                            objEntity_Welfare_Service.Frequency = Convert.ToInt32(objclsWBData.FREQUENCY);
                            objEntity_Welfare_Service.FromPeriod = objCommon.textToDateTime(objclsWBData.FROMDATE);
                            objEntity_Welfare_Service.ToPeriod = objCommon.textToDateTime(objclsWBData.TODATE);
                            objEntity_Welfare_Service.Welfare_SubDtlId = Convert.ToInt32(objclsWBData.DTLID);
                            objWelfare_LimitDtls_Update.Add(objEntity_Welfare_Service);
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
                        clsEntity_Welfare_Limit_list objEntityDetailsDelete = new clsEntity_Welfare_Limit_list();
                        objEntityDetailsDelete.Welfare_SubDtlId = Convert.ToInt32(strDtlId);
                        objWelfare_LimitDtls_Delete.Add(objEntityDetailsDelete);

                    }
                }


                DataTable dtCategory = objBusiness_Welfare_Service.CheckCategoryId(objEntityWelfare_Service);
                if (dtCategory.Rows.Count > 0)
                {
                    if (dtCategory.Rows[0]["WLFRCAT_ID"].ToString() != "")
                    {


                        objBusiness_Welfare_Service.UpdateWelfareService(objEntityWelfare_Service, ObjEntityDepartmentList, ObjEntityDesignationList, ObjEntityDivisionList, ObjEntityEmployeeList, objWelfare_LimitDtls_Insert, objWelfare_LimitDtls_Update, objWelfare_LimitDtls_Delete);

                        if (clickedButton.ID == "btnUpdate")
                        {
                            Response.Redirect("hcm_Emp_welfare_service.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose")
                        {
                            Response.Redirect("hcm_Emp_Welfare_Service_List.aspx?InsUpd=Upd");
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCancelMsg", "CategoryCancelMsg();", true);


                }

            }
        }
    }

    
}