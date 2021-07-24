using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Data;
using System.Text;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Employee_Exit_Process_hcm_Emp_Exit_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            EmpLoad();
            LoadEmpExitPrcssMastrSts();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Exit_Process);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }


            //Creating objects for business layer

            clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
            clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

            if (Session["USERID"] != null)
            {
                objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            int intOrgId = 0;

            if (Session["ORGID"] != null)
            {
                objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
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

                // checking cancelled or not first
                string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();


                if (Request.QueryString["Id"] != null)
                {
                    //when Canceled
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntitylayrExitPrcs.ExitProcsId = Convert.ToInt32(strId);

                    objEntitylayrExitPrcs.UserId = intUserId;

                    objEntitylayrExitPrcs.Date = System.DateTime.Now;


                    if (CnclrsnMust == "0")
                    {
                        //if cancelreasn=0
                        objEntitylayrExitPrcs.CancelReason = objCommon.CancelReason();

                        objBusinessExitProcs.CancelExitPrcs(objEntitylayrExitPrcs);
                        Response.Redirect("hcm_Emp_Exit_Process_List.aspx?InsUpd=Cncl");
                    }
                    else
                    {
                        //if cancelreasn=1
                        objEntitylayrExitPrcs.CancelStatus = 0;

                        DataTable dtExtPrcs = new DataTable();
                        dtExtPrcs = objBusinessExitProcs.ReadExitProcs(objEntitylayrExitPrcs);

                        string strHtm = ConvertDataTableToHTML(dtExtPrcs, intEnableModify, intEnableCancel);
                        //Write to divReport
                        divReport.InnerHtml = strHtm;

                        hiddenRsnid.Value = strId;
                    }

                    //if not cancelled
                }
                else
                {

                    //viewing table

                    objEntitylayrExitPrcs.CancelStatus = 0;

                    DataTable dtExtPrcs = new DataTable();
                    dtExtPrcs = objBusinessExitProcs.ReadExitProcs(objEntitylayrExitPrcs);

                    string strHtm = ConvertDataTableToHTML(dtExtPrcs, intEnableModify, intEnableCancel);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;


                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Save")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                        }
                        else if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Conf")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                        }
                    }
                }
            }
        }

    }

    public void EmpLoad()
    {
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntitylayrExitPrcs.Mode = 2;

        DataTable dtEmp = new DataTable();
        dtEmp = objBusinessExitProcs.ReadToddlEmployee(objEntitylayrExitPrcs);

        ddlEmployee.Items.Clear();

        ddlEmployee.DataSource = dtEmp;

        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    public void LoadEmpExitPrcssMastrSts()
    {
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        DataTable dtEmpExitPrcssMastrSts = objBusinessExitProcs.ReadEmpExitProcessMstrSts(objEntitylayrExitPrcs);
        
        ddlStatus.DataSource = dtEmpExitPrcssMastrSts;
        ddlStatus.DataTextField = "EXIT_PRCS_STS_NAME";
        ddlStatus.DataValueField = "EXIT_PRCS_STS_ID";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, "--SELECT STATUS--");
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";

        string status = "";

        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:28%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
           
        }
        if (cbxCnclStatus.Checked == false)
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT </th>";
            }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }

        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW </th>";
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a   style=\"cursor:pointer;color: blue;\"  title=\"View\" onclick=\"return ExitProssId('" + Id + "');\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a> </td>";
                    //strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "1")
                    {
                        status = "RESIGNATION";
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "2")
                    {
                        status = "TERMINATION";                        
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "3")
                    {
                        status = "RETIREMENT";
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "4")
                    {
                        status = "ABSCOND";
                    }
                    if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "5")
                    {
                        status = "DEATH";
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "6")
                    {
                        status = "REJOIN";
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "7")
                    {
                        status = "UNDER POLICE CUSTODY";
                    }
                    else if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "8")
                    {
                        status = "OTHER";
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + status + "</td>";
                }
            }


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (dt.Rows[intRowBodyCount]["EXTPRCS_CONFRMSTS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                  " href=\"hcm_Emp_Exit_Process.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                              " href=\"hcm_Emp_Exit_Process.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                }

            }
            if (cbxCnclStatus.Checked == true)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"hcm_Emp_Exit_Process.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
            }


            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (intCancTransaction == 0)
                    {
                        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
                        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

                        objEntitylayrExitPrcs.ExitProcsId = Convert.ToInt32(strId);

                        DataTable dtCancelCheck = new DataTable();
                        dtCancelCheck = objBusinessExitProcs.CheckConfrmStatus(objEntitylayrExitPrcs);

                        if (dtCancelCheck.Rows.Count > 0)
                        {
                            if (dtCancelCheck.Rows[0]["EXTPRCS_CONFRMSTS"].ToString() == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                              + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else if (dtCancelCheck.Rows[0]["EXTPRCS_CONFRMSTS"].ToString() == "0")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"   onclick='return CancelAlert(this.href);' " +
                                " href=\"hcm_Emp_Exit_Process_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                    }
                }

            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Exit_Process);
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


        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        if (Session["USERID"] != null)
        {
            objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        int intOrgId = 0;

        if (Session["ORGID"] != null)
        {
            objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (cbxCnclStatus.Checked == true)
        {
            objEntitylayrExitPrcs.CancelStatus = 1;
        }
        else
        {
            objEntitylayrExitPrcs.CancelStatus = 0;
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntitylayrExitPrcs.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        if (ddlStatus.SelectedItem.Value != "--SELECT STATUS--")
        {
            objEntitylayrExitPrcs.ExitProcsStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }


        DataTable dtExtPrcs = new DataTable();
        dtExtPrcs = objBusinessExitProcs.ReadExitProcs(objEntitylayrExitPrcs);

        string strHtm = ConvertDataTableToHTML(dtExtPrcs, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //cancel reasn
        clsEntityLayerExitProcess objEntitylayrExitPrcs = new clsEntityLayerExitProcess();
        clsBusinessLayerExitProcess objBusinessExitProcs = new clsBusinessLayerExitProcess();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntitylayrExitPrcs.ExitProcsId = Convert.ToInt32(hiddenRsnid.Value);

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitylayrExitPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntitylayrExitPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntitylayrExitPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntitylayrExitPrcs.Date = System.DateTime.Now;
            objEntitylayrExitPrcs.CancelReason = txtCnclReason.Text.Trim();

            objBusinessExitProcs.CancelExitPrcs(objEntitylayrExitPrcs);

            Response.Redirect("hcm_Emp_Exit_Process_List.aspx?InsUpd=Cncl");
        }
    }
}