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

public partial class HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Emp_Conduct_Incident_hcm_Emp_Conduct_Incident_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
            clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
            HiddenRoleEdit.Value = "0";
            HiddenRoleAllDiv.Value = "0";
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
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0;
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
                        HiddenRoleEdit.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString())
                    {
                        IntAllDivision = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenRoleAllDiv.Value = "1";
                    }


                }
            }
            objEntity.AllDivisionChk = IntAllDivision;

            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               
            }
            else
            {
                divAdd.Visible = false;
            }
            divsearch.Visible = false;
            if (HiddenRoleAllDiv.Value == "1")
            {
                divsearch.Visible = true;
                ddlBusnssUnit.Focus();
            }
            int AllDivision = 1;
            LoadAllDivisionDropDowns(objEntity);

            DataTable dtList = objEmpConduct.ReadConductIncidentList(objEntity);

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate);


        }
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate)
    {
        int SaveOrConf = 0, SaveOrConfQrString = 0, pendOrfinsh = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";



        strHtml += "<tr >";



        int intCnclUsrId = 0;
        int intReCallForTAble = 0;



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:12%;text-align:left;\"> EMPLOYEE ID";


                strHtml += "	<input class=\"form-control\" placeholder=\"EMPLOYEE ID\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:left;\">REF# ";


                strHtml += "	<input class=\"form-control\" placeholder=\"REF#\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\">EMPLOYEE NAME ";


                strHtml += "	<input class=\"form-control\" placeholder=\"EMPLOYEE NAME\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:16%;text-align:left;\"> CATEGORY";


                strHtml += "	<input class=\"form-control\" style=\"text-align:left;\" placeholder=\"CATEGORY\" type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:center;\">INCIDENT DATE ";


                strHtml += "	<input class=\"form-control\" placeholder=\"INCIDENT DATE\" style=\"text-align:center;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:8%;text-align:left;\">TYPE";


                strHtml += "	<input class=\"form-control\" placeholder=\"TYPE\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:8%;text-align:left;\"> SEVERITY";//EVM-0024 -- SEVERITY


                strHtml += "	<input class=\"form-control\" placeholder=\"SEVERITY\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
          

        }
        strHtml += "<th class=\"hasinput\" style=\"width:9%;text-align:left;\">STATUS";

        strHtml += "	<input class=\"form-control\" placeholder=\"STATUS\" style=\"text-align:left;\" type=\"text\">";

        strHtml += "</th >";

        //if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        //{
            strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align: center;\"> EDIT";
        //}
        //else
        //{
        //    strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align: center;\"> VIEW";
        //}

      


        //  strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";



        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNDTINC_REFNO"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["M_REASON"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["CNDTINC_DATE"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["CNDTINC_TYPE"].ToString() == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >NEGATIVE</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >POSITIVE</td>";
                    }
                }
                else if (intColumnBodyCount == 7)
                {
                    string StrPriorityName = "";
                    string StrPriority = dt.Rows[intRowBodyCount]["CNDTINC_SEVERITY"].ToString();
                    StrPriority = StrPriority.Replace("1", "CRITICAL");
                    StrPriority = StrPriority.Replace("2", "HIGH");
                    StrPriority = StrPriority.Replace("3", "MEDIUM");
                    StrPriority = StrPriority.Replace("4", "LOW");
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + StrPriority + "</td>";
                }
                //else if (intColumnBodyCount == )
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNDTINC_TYPE"].ToString() + "</td>";
                //}
                else if (intColumnBodyCount == 8)
                {
                   
                    if (dt.Rows[intRowBodyCount]["CNDTINC_TRMNTN_USRID"].ToString() != "")
                        Status = "TERMINATED";
                   else if (dt.Rows[intRowBodyCount]["CNDTINC_CLS_USRID"].ToString() != "")
                        Status = "CLOSED";
                    else if (dt.Rows[intRowBodyCount]["CNDTINC_CNFM_USR_ID"].ToString() != "")
                        Status = "CONFIRMED";
                    else if (dt.Rows[intRowBodyCount]["CNDTINC_RECIVE"].ToString() == "1")
                        Status = "ACKNOWLEDGED";
                    else
                    {
                        Status = "SAVED";
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Status + "</td>";
                }
            }

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (Status == "CLOSED" || Status == "TERMINATED")
            {
                strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                      " href=\"hcm_Emp_Conduct_Incident.aspx?Id=" + Id + "&STS=" + Status + "\"><i class=\"fa fa-eye\"></i></a></td>";
            }
            else if (Status == "CONFIRMED" || Status == "ACKNOWLEDGED" || Status == "SAVED")
            {
                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;\" class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                           " href=\"hcm_Emp_Conduct_Incident.aspx?Id=" + Id + "&STS=" + Status + "\"><i class=\"fa fa-pencil\"></i></a></td>";
                }
                else {
                    Status = "CLOSED";
                    strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;\" class=\"tooltip\" title=\"view\" onclick='return getdetails(this.href);' " +
                             " href=\"hcm_Emp_Conduct_Incident.aspx?Id=" + Id + "&STS=" + Status + "\"><i class=\"fa fa-eye\"></i></a></td>";
                }
            }
           

         
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public void LoadAllDivisionDropDowns(clsEntity_Emp_conduct_Incident objEntity)
    {

        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
     



        DataTable dtBussUnit;
        dtBussUnit = objEmpConduct.LoadBissnusUnit(objEntity);
        if (dtBussUnit.Rows.Count > 0)
        {
            ddlBusnssUnit.DataSource = dtBussUnit;
            ddlBusnssUnit.DataTextField = "CORPRT_NAME";
            ddlBusnssUnit.DataValueField = "CORPRT_ID";
            ddlBusnssUnit.DataBind();

        }


        DataTable dtDep;
        dtDep = objEmpConduct.LoadDepartment(objEntity);
        if (dtDep.Rows.Count > 0)
        {
            ddldep.DataSource = dtDep;
            ddldep.DataTextField = "CPRDEPT_NAME";
            ddldep.DataValueField = "CPRDEPT_ID";
            ddldep.DataBind();

        }
        DataTable dtDivision;
        dtDivision = objEmpConduct.LoadDivision(objEntity);

        if (dtDivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

     

        ddlBusnssUnit.ClearSelection();
        ddldep.ClearSelection();
        ddlDivision.ClearSelection();
        ddlBusnssUnit.Items.Insert(0, "--SELECT--");
        ddldep.Items.Insert(0, "--SELECT--");
        ddlDivision.Items.Insert(0, "--SELECT--");
        

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

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

        if (ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
            objEntity.BussnessUnit = Convert.ToInt32(ddlBusnssUnit.SelectedItem.Value);

        if (ddlDivision.SelectedItem.Value != "--SELECT--")
            objEntity.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);

        if (ddldep.SelectedItem.Value != "--SELECT--")
            objEntity.DeptId = Convert.ToInt32(ddldep.SelectedItem.Value);

        objEntity.AllDivisionChk = Convert.ToInt32(HiddenRoleAllDiv.Value);

        DataTable dtList = objEmpConduct.ReadConductIncidentList(objEntity);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int upd =Convert.ToInt32(HiddenRoleEdit.Value);
        divList.InnerHtml = ConvertDataTableToHTML(dtList, upd);
        ScriptManager.RegisterStartupScript(this, GetType(), "ListLoad", "ListLoad();", true);
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void ddlBusnssUnit_SelectedIndexChanged(object sender, EventArgs e)
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
        if (ddlBusnssUnit.SelectedItem.Value != "--SELECT--")
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

    }
    protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
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
            objEntity.AllDivisionChk = Convert.ToInt32(HiddenRoleAllDiv.Value);
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

        ddlDivision.Items.Insert(0, "--SELECT--");

       

    }
}