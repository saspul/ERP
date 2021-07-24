using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using System.Text;
using System.Data;
using CL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_Employee_Transfer_hcm_Emp_Transfer_List : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EDIT_TRNSFR"] = null;
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0,intEnableRenew=0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //Allocating child roles
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAddSection.Visible = true;
            }
            else
            {
                divAddSection.Visible = false;
            }
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
            objEntitylayerEmployeeTrnsfr.Trans_Type = 2;
            objEntitylayerEmployeeTrnsfr.Trans_Method = 2;
            objEntitylayerEmployeeTrnsfr.Trans_Mode = 1;
            objEntitylayerEmployeeTrnsfr.ManPowerLinked = 1;
            DataTable dtEmpTransferList = objBusinessEmployeeTrnsfr.ReadEmployeeTransferList(objEntitylayerEmployeeTrnsfr);
            string tableInner = ConvertDataTableToHTML(dtEmpTransferList, intEnableModify, intEnableRenew);
            divList.InnerHtml = tableInner;


            DataTable dtEmpTransfer = objBusinessEmployeeTrnsfr.ReadEmployeeTransfer(objEntitylayerEmployeeTrnsfr);
            List<clsEntity_Emp_Transfer> objEntitylayerEmpList = new List<clsEntity_Emp_Transfer>();
            int EmpTransMode = 0;
            if (dtEmpTransfer.Rows.Count > 0)
            {
                objEntitylayerEmployeeTrnsfr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                for (int cnt = 0; cnt < dtEmpTransfer.Rows.Count; cnt++)
                {
                    objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["EMPTRNS_ID"].ToString());

                    EmpTransMode = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["EMPTRNS_MODE"].ToString());
                    objEntitylayerEmployeeTrnsfr.Trans_Mode = EmpTransMode;
                    if (EmpTransMode == 1)
                    {
                        clsEntity_Emp_Transfer objEntitylayerEmpTrnsEmp = new clsEntity_Emp_Transfer();
                        objEntitylayerEmpTrnsEmp.UserId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["USR_ID"].ToString());
                        objEntitylayerEmpList.Add(objEntitylayerEmpTrnsEmp);
                    }
                    else
                    {
                        objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["EMPTRNS_ID"].ToString());
                        DataTable dtEmpTransferid = objBusinessEmployeeTrnsfr.ReadEmployeeTransferUsrId(objEntitylayerEmployeeTrnsfr);

                        foreach (DataRow dtRow in dtEmpTransferid.Rows)
                        {
                            clsEntity_Emp_Transfer objEntitylayerEmpTrnsEmp = new clsEntity_Emp_Transfer();
                            objEntitylayerEmpTrnsEmp.UserId = Convert.ToInt32(dtRow["USR_ID"].ToString());
                            objEntitylayerEmpList.Add(objEntitylayerEmpTrnsEmp);
                        }
                    }
                    objEntitylayerEmployeeTrnsfr.CorpId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["CORPRT_ID"].ToString());
                    objEntitylayerEmployeeTrnsfr.DepartmentId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["CPRDEPT_ID"].ToString());
                    objEntitylayerEmployeeTrnsfr.PaygradeId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["PYGRD_ID"].ToString());
                    objEntitylayerEmployeeTrnsfr.ReporterId = Convert.ToInt32(dtEmpTransfer.Rows[cnt]["EMPTRNS_RPRTR_ID"].ToString());
                    if (dtEmpTransfer.Rows[0]["SPSNSR_ID"].ToString() != "")
                    {
                        objEntitylayerEmployeeTrnsfr.SponsorId = Convert.ToInt32(dtEmpTransfer.Rows[0]["SPSNSR_ID"].ToString());
                    }

                    if (dtEmpTransfer.Rows[0]["PROJECT_ID"].ToString() != "")
                    {

                        objEntitylayerEmployeeTrnsfr.ProjectId = Convert.ToInt32(dtEmpTransfer.Rows[0]["PROJECT_ID"].ToString());

                    }
                }

            }

            objBusinessEmployeeTrnsfr.updateUserId(objEntitylayerEmployeeTrnsfr, objEntitylayerEmpList);

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableRenew=0;

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        //Allocating child roles
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                {
                    intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
            }
        }

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
        if (radioBulk.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.Trans_Mode = 2;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.Trans_Mode = 1;
        }
        if (radioBUtransfer.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.Trans_Type = 1;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.Trans_Type = 2;
        }
        if (radioManReq.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.ManPowerLinked = 1;
        }
        if (radioPermanent.Checked == true)
        {
            objEntitylayerEmployeeTrnsfr.Trans_Method = 1;
        }
        else
        {
            objEntitylayerEmployeeTrnsfr.Trans_Method = 2;
        }
        DataTable dtEmpTransferList = objBusinessEmployeeTrnsfr.ReadEmployeeTransferList(objEntitylayerEmployeeTrnsfr);
        string tableInner = ConvertDataTableToHTML(dtEmpTransferList, intEnableModify, intEnableRenew);
        divList.InnerHtml = tableInner;
    }
    protected void btnSingleTransfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("/HCM/HCM_Master/hcm_Employee_Transfer/hcm_Emp_Transfer_Single.aspx");
    }
    protected void btnBulkTransfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("/HCM/HCM_Master/hcm_Employee_Transfer/hcm_Emp_Transfer_Bulk.aspx");
    }

    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableRenew)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";


        if (radioIndividual.Checked == true)
        {
            strHtml += "<th  style=\"width:30%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
        }
        else
        {
            strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">NO. EMPLOYEES</th>";
        }


        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";

        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">PAYGRADE</th>";

        strHtml += "<th  style=\"width:10%;text-align: center; word-wrap:break-word;text-align: center;\">FROM DATE</th>";
        if (radioTemporary.Checked == true)
        {
            strHtml += "<th  style=\"width:10%;text-align: center; word-wrap:break-word;text-align: center;\">TO DATE</th>";
        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th  style=\"width:5%;text-align: right; word-wrap:break-word;\">EDIT</th>";
        }
        if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th  style=\"width:5%;text-align: right; word-wrap:break-word;\">RENEW</th>";
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr>";

            string Id = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string strId = stridLength + Id + strRandom;

            if (radioIndividual.Checked == true)
            {
                strHtml += "<td style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["NAME"].ToString() + "</td>";
            }
            else
            {
                strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["COUNT"].ToString() + "</td>";
            }
            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";

            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PAY GRADE"].ToString() + "</td>";

            strHtml += "<td style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["FROM DATE"].ToString() + "</td>";
            if (radioTemporary.Checked == true)
            {
                strHtml += "<td style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["TO DATE"].ToString() + "</td>";
            }


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (dt.Rows[intRowBodyCount]["EMPTRNS_MODE"].ToString() == "1")
                {
                    strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a  class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                       " href=\"hcm_Emp_Transfer_Single.aspx?EditId=" + strId + "\"><i class=\"fa fa-pencil\"></i></a>";
                }
                else
                {
                    strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a  class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                      " href=\"hcm_Emp_Transfer_Bulk.aspx?EditId=" + strId + "\"><i class=\"fa fa-pencil\"></i></a>";

                }

            }
            if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (dt.Rows[intRowBodyCount]["EMPTRNS_CNFRM_USR_ID"].ToString() != "")
                strHtml += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" > <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left: 0.8%;\" title=\"Renew\" onclick=\"return OpenViewRenwl('" + Id + "');\"><img src=\"/Images/Icons/Renewal.png\"> </a> </td>";
                else
                strHtml += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" > <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:0.5;margin-left: 0.8%;\" title=\"Renew\" onclick=\"return OpenViewRenwlInvalid();\"><img src=\"/Images/Icons/Renewal.png\"> </a> </td>";
   
            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string RenewEmptransfer(string strEmpTransId, string strFromDate, string strToDate)
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(strEmpTransId);
        objEntitylayerEmployeeTrnsfr.FromDate = objCommon.textToDateTime(strFromDate);
        objEntitylayerEmployeeTrnsfr.Todate = objCommon.textToDateTime(strToDate);
        objBusinessEmployeeTrnsfr.UpdateEmpTransferDates(objEntitylayerEmployeeTrnsfr);
        return "true";
    }
    [WebMethod]
    public static string[] readEmptransferDates(string strEmpTransId)
    {
        clsBussiness_Emp_Transfer objBusinessEmployeeTrnsfr = new clsBussiness_Emp_Transfer();
        clsEntity_Emp_Transfer objEntitylayerEmployeeTrnsfr = new clsEntity_Emp_Transfer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string[] strpass = new string[2];
        objEntitylayerEmployeeTrnsfr.Emp_TrnsId = Convert.ToInt32(strEmpTransId);
        DataTable dtDates = objBusinessEmployeeTrnsfr.ReadEmployeeTransferDate(objEntitylayerEmployeeTrnsfr);
        if (dtDates.Rows.Count > 0)
        {
            strpass[0] = dtDates.Rows[0]["EMPTRNS_FROM"].ToString();
            strpass[1] = dtDates.Rows[0]["EMPTRNS_TO"].ToString(); 
        }

        return strpass;
    }
}