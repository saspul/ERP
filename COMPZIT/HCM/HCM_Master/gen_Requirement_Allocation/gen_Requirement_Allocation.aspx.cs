using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_gen_Requirement_Allocation_gen_Requirement_Allocationaspx : System.Web.UI.Page
{

    clsBusinessRequirementAllocation objBusinessRqrmntAlctn = new clsBusinessRequirementAllocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Corp_DivisionLoad();
            Corp_DepartmentLoad();
            ProjectLoad();
            clsEntityRequirementAllocation objEntityReqrmntAlctn = new clsEntityRequirementAllocation();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0,intEnableHRallocation=0,intEnableSelfAllocation=0,intEnableEditAllocation=0;
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

            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Requirement_Allocation);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldHRallocation.Value = "true";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString())
                    {
                        intEnableSelfAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldSelfAllocation.Value = "true";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString())
                    {
                        intEnableEditAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldEditAllocation.Value = "true";
                    }

                }
               


                if (intEnableHRallocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableSelfAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnAllocate.Visible = true;

                }
                else
                {

                    btnAllocate.Visible = false;

                }

                EmployeeLoad();
                hiddenAllocateReallocate.Value = "0";

                if (Session["USERID"] != null)
                {
                    objEntityReqrmntAlctn.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                int intOrgId = 0;
                if (Session["ORGID"] != null)
                {
                    objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }



                if (radioAllocated.Checked == true)
                {
                    objEntityReqrmntAlctn.ReqrmntAlctnDtl_Id = 1;//status for allocated

                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessRqrmntAlctn.ReadRequirementList(objEntityReqrmntAlctn);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intCorpId, intOrgId);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                }
                else if (radioNotAllocated.Checked == true)
                {
                    objEntityReqrmntAlctn.ReqrmntAlctnDtl_Id = 0;//status for not allocated

                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessRqrmntAlctn.ReadRequirementList(objEntityReqrmntAlctn);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intCorpId, intOrgId);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                }



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
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intCorpId, int intOrgId)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";


        

        strHtml += "<th class=\"thT\" style=\"text-align: left; word-wrap:break-word;display:none;\">ALLOCATE</th>";
        strHtml += "<th class=\"thT\" style=\"text-align: left; word-wrap:break-word;display:none;\">ALLOCATE</th>";

        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">ALLOCATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">RE-ALLOCATE</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";   //emp25
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";  //emp25
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:6%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: left; word-wrap:break-word;\">ALLOCATED TO</th>";
            }
        }
       


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        HiddenFieldCbxCount.Value = Convert.ToString(dt.Rows.Count);
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            clsEntityRequirementAllocation objEntityReqrmntAlctn = new clsEntityRequirementAllocation();
            objEntityReqrmntAlctn.Reqrmnt_Id=Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
            DataTable dtChck= objBusinessRqrmntAlctn.ChkRqrmntAlcted(objEntityReqrmntAlctn);
            if (dtChck.Rows.Count > 0)
            {
                hiddenAllocateReallocate.Value = "1";
            }
            else
            {
                hiddenAllocateReallocate.Value = "0";
            }

            strHtml += "<tr  >";
            strHtml += "<td id=\"ReqrmntId" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
            strHtml += "<td id=\"RqmntAlctDtlId" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\">";

            if (dtChck.Rows.Count > 0)
            {
                strHtml += "<input id=\"cbx" + intRowBodyCount + "\"  disabled  type=\"checkbox\" checked onkeydown=\"return isEnter(event);\" />";
            }
            else
            {
                strHtml += "<input id=\"cbx" + intRowBodyCount + "\"  type=\"checkbox\" onchange=\"return ChangeCbx();\" onkeydown=\"return isEnter(event);\" />";
            }
           
            strHtml +="</td>";


            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\">";

            if (dtChck.Rows.Count > 0 && HiddenFieldEditAllocation.Value == "true" && HiddenFieldHRallocation.Value == "true")
            {
                strHtml += "<input id=\"cbxRe" + intRowBodyCount + "\" onchange=\"return ChangeCbx();\" type=\"checkbox\"   onkeydown=\"return isEnter(event);\" />";
            }

            else
            {
                strHtml += "<input id=\"cbxRe" + intRowBodyCount + "\"  disabled  type=\"checkbox\"  onkeydown=\"return isEnter(event);\" />";
            }




            strHtml += "</td>";

            count++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";  //emp25
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["DIVISION"].ToString() + "</td>";  //emp25
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            strHtml += "</tr>";
           
        }
       

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
   
    public void Corp_DepartmentLoad()
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
        DataTable dtSubConrt = objBussinessJobNOtify.ReadDepartment(objEntityJobNotify);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDep.DataSource = dtSubConrt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }

        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }
    public void ProjectLoad()
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
        DataTable dtProjct = objBussinessJobNOtify.ReadProject(objEntityJobNotify);
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");


    }
    public void EmployeeLoad()
    {
        clsEntityRequirementAllocation objEntityReqrmntAlctn = new clsEntityRequirementAllocation();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReqrmntAlctn.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenFieldSelfAllocation.Value == "true")
        {
            objEntityReqrmntAlctn.SelfAlctnSts = 1;
        }

        DataTable dtSubConrt = objBusinessRqrmntAlctn.ReadEmployeeList(objEntityReqrmntAlctn);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtSubConrt;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");


    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        EmployeeLoad();
        clsEntityRequirementAllocation objEntityReqrmntAlctn = new clsEntityRequirementAllocation();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityReqrmntAlctn.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityReqrmntAlctn.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }




        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityReqrmntAlctn.Deprt_Id = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityReqrmntAlctn.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }

        objEntityReqrmntAlctn.User_Id = intUserId;

        if (radioAllocated.Checked == true)
        {
            objEntityReqrmntAlctn.ReqrmntAlctnDtl_Id = 1;//status for allocated
            hiddenAllocateReallocate.Value = "1";
        }
        else if (radioNotAllocated.Checked == true)
        {
            objEntityReqrmntAlctn.ReqrmntAlctnDtl_Id = 0;//status for not allocated
            hiddenAllocateReallocate.Value = "0";
        }

        DataTable dtContract = new DataTable();
        dtContract = objBusinessRqrmntAlctn.ReadRequirementList(objEntityReqrmntAlctn);


        int intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Requirement_Allocation);
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

            }
        }

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intCorpId, intOrgId);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnAllocation_Click(object sender, EventArgs e)
    {
        clsEntityRequirementAllocation objEntityReqrmntAlctn = new clsEntityRequirementAllocation();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReqrmntAlctn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReqrmntAlctn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReqrmntAlctn.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityReqrmntAlctn.D_Date = System.DateTime.Now;

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.REQUIREMENT_ALLOCATION);
        objEntityCommon.CorporateID = objEntityReqrmntAlctn.CorpOffice_Id;
        objEntityCommon.Organisation_Id = objEntityReqrmntAlctn.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityReqrmntAlctn.ReqrmntAlctn_Id = Convert.ToInt32(strNextId);

            string strRqrmntId = "";
            string[] strarrRqrmntIds = strRqrmntId.Split(',');
            if (HiddenFieldReqrmntIds.Value != "" && HiddenFieldReqrmntIds.Value != null)
            {
                strRqrmntId = HiddenFieldReqrmntIds.Value;
                strarrRqrmntIds = strRqrmntId.Split(',');

            }



         string strRqrmntReId = "";
            string[] strarrRqrmntReIds = strRqrmntReId.Split(',');
            if (HiddenFieldReAlctnIds.Value != "" && HiddenFieldReAlctnIds.Value != null)
            {
                strRqrmntReId = HiddenFieldReAlctnIds.Value;
                strarrRqrmntReIds = strRqrmntReId.Split(',');

            }



        

            if (HiddenFieldHRallocation.Value == "true")
            {
                objEntityReqrmntAlctn.Employee_Id = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
            else
            {
                objEntityReqrmntAlctn.Employee_Id = objEntityReqrmntAlctn.User_Id;
            }


            objBusinessRqrmntAlctn.insertReqrmntAlctnDtls(objEntityReqrmntAlctn, strarrRqrmntIds, strarrRqrmntReIds);
        Response.Redirect("gen_Requirement_Allocation.aspx?InsUpd=Ins");
       

    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
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
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityJobNotify.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }


        DataTable dtProjct = objBussinessJobNOtify.ReadProject(objEntityJobNotify);
        ddlProject.Items.Clear();
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");
    }
    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {
        clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        clsEntityLayer_JobNotification objEntityJobNotify = new clsEntityLayer_JobNotification();
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

        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDep.SelectedItem.Value);
            objEntityJobNotify.Deprt_Id = Dept;
            DataTable dtSubConrt = objBussinessJobNOtify.ReadDivision(objEntityJobNotify);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtSubConrt;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }
    }


}