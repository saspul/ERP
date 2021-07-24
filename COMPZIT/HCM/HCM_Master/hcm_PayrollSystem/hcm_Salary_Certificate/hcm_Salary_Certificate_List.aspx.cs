using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;

public partial class HCM_HCM_Master_hcm_Salary_Certificate_hcm_Salary_Certificate_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EDIT_ID"] = null;
            Session["VIEW_ID"] = null;

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableConfirm = 0;

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Salary_Certificate);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }


            clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();
            clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntitySalryCertfct.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntitySalryCertfct.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                               };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


            if (dtCorpDetail.Rows.Count > 0)
            {
                string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();

                hiddenCnclrsnMust.Value = CnclrsnMust;

                objEntitySalryCertfct.HRApprovalSts = 0;
                objEntitySalryCertfct.CancelSts = 0;
                if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    objEntitySalryCertfct.EmployeeId = 0;
                }
                else
                {
                    objEntitySalryCertfct.EmployeeId = intUserId;
                }

                DataTable dtSlryCertfctReqst = objBusinessSalryCertfct.ReadSalaryCertfctReqsts(objEntitySalryCertfct);

                int ddlSts = Convert.ToInt32(ddlStatus.SelectedItem.Value);

                string strhtm = ConvertDataTableToHTML(dtSlryCertfctReqst, intEnableAdd, intEnableCancel, intEnableHrConfirm, ddlSts);
                divList.InnerHtml = strhtm;

            }
        }
    }


    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableCancel, int intEnableHrConfirm, int ddlSts)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"dt_basic\" class=\"table table-striped table-bordered \"  >";

        strHtml += "<thead>";
        strHtml += "<tr>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th  style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th  style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th   style=\"width:20%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th   style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                if (ddlSts == 0)
                {
                    strHtml += "<th   style=\"width:15%;text-align: center; word-wrap:break-word;\">REQUEST DATE</th>";
                }
                else if (ddlSts ==1)
                {
                    strHtml += "<th   style=\"width:15%;text-align: center; word-wrap:break-word;\">APPROVED DATE</th>";
                }
                else if (ddlSts == 2)
                {
                    strHtml += "<th   style=\"width:15%;text-align: center; word-wrap:break-word;\">REJECTED DATE</th>";
                }
            }

        }
        if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th  style=\"width:5%; word-wrap:break-word;text-align: center;\">EDIT </th>";
        }
        strHtml += "</tr>";
        strHtml += "</thead>";

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                string Sts = "Pending";
                if (dt.Rows[intRowBodyCount]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "1")
                {
                    Sts = "Approved";
                }
                if (dt.Rows[intRowBodyCount]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "2")
                {
                    Sts = "Rejected";
                }

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class='tdT' style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class='tdT' style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\">" + Sts + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    if (ddlSts == 0)
                    {
                        strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\">" + dt.Rows[intRowBodyCount]["SLRYCRTFCT_INS_DATE"].ToString() + "</td>";
                    }
                    else if (ddlSts == 1)
                    {
                        strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\">" + dt.Rows[intRowBodyCount]["SLRYCRTFCT_HR_APPROVAL_DATE"].ToString() + "</td>";
                    }
                    else if (ddlSts == 2)
                    {
                        strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\">" + dt.Rows[intRowBodyCount]["SLRYCRTFCT_RJCT_DATE"].ToString() + "</td>";
                    }
                }
            }

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (dt.Rows[intRowBodyCount]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "1" || dt.Rows[intRowBodyCount]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "2")
                {
                    strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='View' class=\"btn btn-xs btn-default\" data-original-title=\"View Row\" onclick=\"return ViewItem('" + strId + "');\"><i class=\"fa fa-eye\"></i></button>";
                }
                else
                {
                    strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='Edit' class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return EditItem('" + strId + "');\"><i class=\"fa fa-pencil\"></i></button>";
                }
            }
            else
            {
                strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='View' class=\"btn btn-xs btn-default\" data-original-title=\"View Row\" onclick=\"return ViewItem('" + strId + "');\"><i class=\"fa fa-eye\"></i></button>";
            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (hiddenEdit.Value != "0")
        {
            Session["EDIT_ID"] = hiddenEdit.Value;
            Session["VIEW_ID"] = null;
        }
        else if (hiddenView.Value != "0")
        {
            Session["VIEW_ID"] = hiddenView.Value;
            Session["EDIT_ID"] = null;
        }
        else
        {
            Response.Redirect("hcm_Salary_Certificate_List.aspx");
        }
        Response.Redirect("hcm_Salary_Certificate.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableConfirm = 0;

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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Salary_Certificate);
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
            }
        }

        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            divAdd.Visible = true;
        }
        else
        {
            divAdd.Visible = false;
        }


        clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();
        clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntitySalryCertfct.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitySalryCertfct.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitySalryCertfct.HRApprovalSts = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        int ddlSts = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntitySalryCertfct.CancelSts = 0;
        if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            objEntitySalryCertfct.EmployeeId = 0;
        }
        else
        {
            objEntitySalryCertfct.EmployeeId = intUserId;
        }

        DataTable dtSlryCertfctReqst = objBusinessSalryCertfct.ReadSalaryCertfctReqsts(objEntitySalryCertfct);

        string strhtm = ConvertDataTableToHTML(dtSlryCertfctReqst, intEnableAdd, intEnableCancel, intEnableHrConfirm, ddlSts);
        divList.InnerHtml = strhtm;
    }



}