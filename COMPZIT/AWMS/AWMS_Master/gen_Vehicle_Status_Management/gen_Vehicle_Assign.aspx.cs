using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Services;

public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Assign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtToDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtToDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtFromDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDivision.Attributes.Add("onkeypress", "DisableEnter(event)");
        ddlProject_Employee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlProject_Employee.Attributes.Add("onkeypress", "DisableEnter(event)");
        radioProject.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        radioEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        radioGeneral.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
            clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
            DivisionLoad();
            ProjectDefaultLoad();
            btnAssign.Visible = false;
            btnUpdate.Visible = false;
            if (Request.QueryString["VehId"] != null)
            {
                lblEntry.Text = "Add Vehicle Assign";
                hiddenVehicleId.Value = Request.QueryString["VehId"].ToString();
                btnAssign.Visible = true;
                objEntityVehicle.VehicleId = Convert.ToInt32(Request.QueryString["VehId"].ToString());
                objEntityVehicle.VehAsignId = 0;

                DataTable dtVehicleName = objBusinessVehicle.ReadVehNumber(objEntityVehicle);
                if (dtVehicleName.Rows.Count > 0)
                {
                    lblVehicleNum.Text = dtVehicleName.Rows[0]["VHCL_NUMBR"].ToString();
                }
            }

            if (Request.QueryString["VehAsgn"] != null)
            {
                lblEntry.Text = "Edit Vehicle Assign";
                int VehAsgnId = Convert.ToInt32(Request.QueryString["VehAsgn"].ToString());
                btnAssign.Visible = false;
                btnUpdate.Visible = true;
                Update(VehAsgnId);
                objEntityVehicle.VehAsignId = Convert.ToInt32(Request.QueryString["VehAsgn"].ToString());
                objEntityVehicle.VehicleId = 0;
                DataTable dtVehicleName = objBusinessVehicle.ReadVehNumber(objEntityVehicle);
                if (dtVehicleName.Rows.Count > 0)
                {
                    lblVehicleNum.Text =dtVehicleName.Rows[0]["VHCL_NUMBR"].ToString();
                }
            }
            if (Request.QueryString["Back"] != null)
            {
                HiddenBackPage.Value = Request.QueryString["Back"].ToString();
            }
            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;
            ddlDivision.Focus();
        }
    }
    public void ProjectDefaultLoad()
    {
        ddlProject_Employee.Items.Insert(0, "--SELECT--");
    }
    public void DivisionLoad()
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
     
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtInsDetails = new DataTable();
        dtInsDetails = objBusinessVehicle.ReadDivision(objEntityVehicle);
        if (dtInsDetails.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtInsDetails;
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--SELECT--");
        }
       
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
 
        if(ddlDivision.SelectedItem.Text!="--SELECT--")
        {
            objEntityVehicle.DivisionId =Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }

        if (radioGeneral.Checked != true)
        {
            ddlProject_Employee.Items.Clear();

            if (radioEmployee.Checked == true)
            {
                DataTable dtEmployee = new DataTable();
                dtEmployee = objBusinessVehicle.ReadEmployee(objEntityVehicle);
                if (dtEmployee.Rows.Count > 0)
                {
                    ddlProject_Employee.DataSource = dtEmployee;
                    ddlProject_Employee.DataValueField = "USR_ID";
                    ddlProject_Employee.DataTextField = "USR_NAME";
                    ddlProject_Employee.DataBind();
                }
            }

            if (radioProject.Checked == true)
            {
                DataTable dtProject = new DataTable();
                dtProject = objBusinessVehicle.ReadProject(objEntityVehicle);
                if (dtProject.Rows.Count > 0)
                {
                    ddlProject_Employee.DataSource = dtProject;
                    ddlProject_Employee.DataValueField = "PROJECT_ID";
                    ddlProject_Employee.DataTextField = "PROJECT_NAME";
                    ddlProject_Employee.DataBind();
                }
            }
            //ddlProject_Employee.Enabled = true;
            ddlProject_Employee.Items.Insert(0, "--SELECT--");
            //lblproject_emp.Text = "Project/Employee*";
        }
        //else
        //{
        //    ddlProject_Employee.Enabled = false;
        //    lblproject_emp.Text = "Project/Employee";
        //}
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlFocus", "ddlFocus();", true);
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_ASSIGN);
        objEntityCommon.CorporateID = objEntityVehicle.CorporateId;
        objEntityCommon.Organisation_Id = objEntityVehicle.Org_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityVehicle.NextIdForAssign = Convert.ToInt32(strNextId);


        objEntityVehicle.VehicleId = Convert.ToInt32(hiddenVehicleId.Value);
        objEntityVehicle.DivisionId =Convert.ToInt32(ddlDivision.SelectedItem.Value);
        if(radioProject.Checked==true)
        {
        objEntityVehicle.AssignMode = 1;
        objEntityVehicle.AssignedToPrjct=Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);

        }
        if (radioEmployee.Checked == true)
        {
            objEntityVehicle.AssignMode =2;
            objEntityVehicle.AssignedToUser = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);
        }
        if (radioGeneral.Checked == true)
        {
            objEntityVehicle.AssignMode = 3;
        }
        objEntityVehicle.VehicleStsTyp = 1;
        objEntityVehicle.VehicleSts = 1;

        if (txtFromDate.Text.Trim() != "")
        {
            objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
       
        if (txtToDate.Text.Trim() != "")
        {
            objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

               string DateCount = objBusinessVehicle.CheckDateInAsgn(objEntityVehicle);
               if (DateCount == "0")
               {
                   objBusinessVehicle.AddAssignVehicle(objEntityVehicle);
                   if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
                   {
                      // string strVeh = hiddenRedirect.Value.ToString();
                      
                       Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "&InsUpd=InsAsgn");
                   }
                   else
                   {
                       Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=InsAsgn");
                   }
               }
               else
               {
                   ScriptManager.RegisterStartupScript(this, GetType(), "InvalidDateAlert", "InvalidDateAlert();", true);
               }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] != "")
        {
            // string strVeh = hiddenRedirect.Value.ToString();
            Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "");
        }
        if (Request.QueryString["VehAsgn"] != null)
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx");
        }
        if (Request.QueryString["VehId"] != null)
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx");
        }
        
    }


    public void Update(int VehAsgnId)
    {
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();

        int intUserId = 0, intUsrRolMstrId, intEnableModify = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Management);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
              
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }

            }
        }
        objEntityVehicle.VehAsignId = VehAsgnId;

        DataTable dtAsignDetail = new DataTable();
        dtAsignDetail = objBusinessVehicle.ReadVehicleAssignDetailsById(objEntityVehicle);
        if (dtAsignDetail.Rows.Count > 0)
        {
            txtFromDate.Text = dtAsignDetail.Rows[0]["FROM_DATE"].ToString();
            txtToDate.Text = dtAsignDetail.Rows[0]["TO_DATE"].ToString();


            if (dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString() != "")
            {
                if (dtAsignDetail.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
                {
                    ddlDivision.Items.FindByValue(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["CPRDIV_NAME"].ToString(), dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }

                objEntityVehicle.DivisionId = Convert.ToInt32(dtAsignDetail.Rows[0]["CPRDIV_ID"].ToString());
            }

            if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "1")
            {
                radioProject.Checked = true;
                radioGeneral.Checked = false;
            }
            else if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "2")
            {
                radioEmployee.Checked = true;
                radioGeneral.Checked = false;
            }
            else if (dtAsignDetail.Rows[0]["ASSAIGNED_TO_MODE"].ToString() == "3")
            {
                radioGeneral.Checked = true;
            }

            if (radioGeneral.Checked != true)
            {
                ddlProject_Employee.Items.Clear();
                if (radioEmployee.Checked == true)
                {
                    DataTable dtEmployee = new DataTable();
                    dtEmployee = objBusinessVehicle.ReadEmployee(objEntityVehicle);
                    if (dtEmployee.Rows.Count > 0)
                    {
                        ddlProject_Employee.DataSource = dtEmployee;
                        ddlProject_Employee.DataValueField = "USR_ID";
                        ddlProject_Employee.DataTextField = "USR_NAME";
                        ddlProject_Employee.DataBind();
                    }
                }

                if (radioProject.Checked == true)
                {
                    DataTable dtProject = new DataTable();
                    dtProject = objBusinessVehicle.ReadProject(objEntityVehicle);
                    if (dtProject.Rows.Count > 0)
                    {
                        ddlProject_Employee.DataSource = dtProject;
                        ddlProject_Employee.DataValueField = "PROJECT_ID";
                        ddlProject_Employee.DataTextField = "PROJECT_NAME";
                        ddlProject_Employee.DataBind();
                    }
                }

                ddlProject_Employee.Items.Insert(0, "--SELECT--");
                //ddlProject_Employee.Enabled = true;
                //lblproject_emp.Text = "Project/Employee*";
            }
            else
            {
                ddlProject_Employee.Enabled = false;
                //lblproject_emp.Text = "Project/Employee";
            }

            if (dtAsignDetail.Rows[0]["PROJECT_ID"].ToString() != "" && dtAsignDetail.Rows[0]["PROJECT_ID"] != DBNull.Value)
            {
                if (dtAsignDetail.Rows[0]["PROJECT_STATUS"].ToString() == "1")
                {
                ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["PROJECT_NAME"].ToString(), dtAsignDetail.Rows[0]["PROJECT_ID"].ToString());
                    ddlProject_Employee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProject_Employee);

                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }

            }
            if (dtAsignDetail.Rows[0]["USR_ID"].ToString() != "" && dtAsignDetail.Rows[0]["USR_ID"] != DBNull.Value)
            {
                if (dtAsignDetail.Rows[0]["USR_STATUS"].ToString() == "1")
                {
                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtAsignDetail.Rows[0]["USR_NAME"].ToString(), dtAsignDetail.Rows[0]["USR_ID"].ToString());
                    ddlProject_Employee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProject_Employee);

                    ddlProject_Employee.Items.FindByValue(dtAsignDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }

            if (dtAsignDetail.Rows[0]["VHCLASGN_CNFRM_STS"].ToString() == "1")
            {
                lblEntry.Text = "View Vehicle Assign";
                btnUpdate.Visible = false;
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                ddlDivision.Enabled = false;
                ddlProject_Employee.Enabled = false;
                radioEmployee.Enabled = false;
                radioGeneral.Enabled = false;
                radioProject.Enabled = false;
                
            }
            

        }
        if (intEnableModify != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = false;
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ddlDivision.Enabled = false;
            ddlProject_Employee.Enabled = false;
            radioEmployee.Enabled = false;
            radioGeneral.Enabled = false;
            radioProject.Enabled = false;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlFocusonUpdate", "ddlFocusonUpdate();", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinesLayerVehicleStatusMngmnt objBusinessVehicle = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt objEntityVehicle = new clsEntityVehicleStatusMngmnt();
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["VehAsgn"].ToString()!="")
        {
            objEntityVehicle.VehAsignId = Convert.ToInt32(Request.QueryString["VehAsgn"].ToString());

        }

        objEntityVehicle.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        if (radioProject.Checked == true)
        {
            objEntityVehicle.AssignMode = 1;
            objEntityVehicle.AssignedToPrjct = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);

        }
        if (radioEmployee.Checked == true)
        {
            objEntityVehicle.AssignMode = 2;
            objEntityVehicle.AssignedToUser = Convert.ToInt32(ddlProject_Employee.SelectedItem.Value);
        }
        if (radioGeneral.Checked == true)
        {
            objEntityVehicle.AssignMode = 3;
        }
        objEntityVehicle.VehicleStsTyp = 1;
        objEntityVehicle.VehicleSts = 1;

        if (txtFromDate.Text.Trim() != "")
        {
            objEntityVehicle.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text.Trim() != "")
        {
            objEntityVehicle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }
        objBusinessVehicle.UpdateAssignVehicle(objEntityVehicle);
        if (Request.QueryString["Back"] != null && Request.QueryString["Back"] !="")
        {
            // string strVeh = hiddenRedirect.Value.ToString();
            Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Request.QueryString["Back"] + "&InsUpd=UpdAsign");
        }
        else
        {
            Response.Redirect("gen_Vehicle_Status_Management.aspx?InsUpd=UpdAsign");
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
}