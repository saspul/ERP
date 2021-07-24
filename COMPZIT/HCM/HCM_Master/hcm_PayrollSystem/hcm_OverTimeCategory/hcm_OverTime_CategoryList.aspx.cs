using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_OverTimeCategory_hcm_OverTime_CategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {     
        Session["EditId"] = "";
        Session["OvrViewId"] = "";

        HiddenSuccessMsgType.Value = "0";
        if (Session["SuccessMsg"] != null)
        {
            HiddenSuccessMsgType.Value = Session["SuccessMsg"].ToString();
        }
        Session["SuccessMsg"] = null;
        if (!IsPostBack)
        {
            CbxCnclStatus.Checked = false;
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Overtime_Category);
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

            if (intEnableAdd == 0)
            {
                divAdd.Visible = false;
            }

            clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
            clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
            clsEntity_OverTIme_Category_List objEntity_OverTIme_Category_List = new clsEntity_OverTIme_Category_List();
            clsCommonLibrary objEntityCommon = new clsCommonLibrary();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntity_OverTime_Category.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            DataTable dtOvrtm = new DataTable();
            dtOvrtm = objBusiness_OverTime_Category.ReadOverTimeCateg(objEntity_OverTime_Category);

            string strHtm = ConvertDataTableToHTML(dtOvrtm, intEnableModify, intEnableCancel);
            divReport.InnerHtml = strHtm;

            intCorpId = 0;

            intCorpId = objEntity_OverTime_Category.Corporate_id;

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

        }

    }

    //for the list table in the list page

    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
    {
        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        // class="table table-bordered table-striped"
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";

        string strHead = "<tr>";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 35%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 28%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 15%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + dt.Columns[intColumnHeaderCount].ColumnName + "' </th>";
                strHead += " <th data-class=\"expand\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (CbxCnclStatus.Checked == false)
        {
            if (intEnableModify == 1 && intEnableCancel == 1)
            {
                strHead += "<th data-class=\"expand\">EDIT</th>";
                strHtml += "<th class=\"hasinput\" style=\"width:7%\"></th >";
                strHead += "<th data-class=\"expand\">DELETE</th></tr>";
                strHtml += "<th class=\"hasinput\" style=\"width:7%\"></th ></tr>";
            }
            if (intEnableModify == 1 && intEnableCancel == 0)
            {
                strHead += "<th data-class=\"expand\">EDIT</th>";
                strHtml += "<th class=\"hasinput\" style=\"width:7%\"></th ></tr>";
            }
            if (intEnableModify == 0 && intEnableCancel == 1)
            {
                strHead += "<th data-class=\"expand\">DELETE</th></tr>";
                strHtml += "<th class=\"hasinput\" style=\"width:7%\"></th ></tr>";
            }
            if (intEnableModify == 0 && intEnableCancel == 0)
            {

            }
        }
        else
        {
            strHead += "<th data-class=\"expand\">VIEW</th></tr>";
            strHtml += "<th class=\"hasinput\" style=\"width:7%\"></th ></tr>";
        }
        strHtml += "</tr>";
        strHtml += strHead;
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
            string strCountryId = dt.Rows[intRowBodyCount][0].ToString();
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

             
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td style=\" width:35%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td style=\" width:28%;word-break: break-all; word-wrap:break-word\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td style=\" width:15%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            string Id = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string strId = stridLength + Id + strRandom;
            if (CbxCnclStatus.Checked == false)
            {
                if (intEnableModify == 1 && intEnableCancel == 1)
                {
                    strHtml += "<td style=\"width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_OverTime_Category_Master.aspx?Id=" + strId + "\"><i class=\"fa fa-pencil\"></i></a></td>";
                    //evm-0027 
                    if (intCancTransaction != 0)
                    {
                        strHtml += "<td style=\" width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  class=\"btn btn-xs btn-default\" \"tooltip\" title=\"Delete not possible\" data-original-title=\"Edit Row\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.2\"; class=\"fa fa-trash\"></i></button></td>";
                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();'> "
                        //                   + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                    else
                    {
                      
                        strHtml += "<td style=\" width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  class=\"btn btn-xs btn-default\" \"tooltip\" title=\"Delete\" data-original-title=\"Edit Row\" onclick=\"return OpenCancelView(" + Id + ");\"><i class=\"fa fa-trash\"></i></button></td>";
                    }
                    //end
                    strHtml += "</tr>";
                }

                if (intEnableModify == 1 && intEnableCancel == 0)
                {
                    strHtml += "<td style=\"width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_OverTime_Category_Master.aspx?Id=" + strId + "\"><i class=\"fa fa-pencil\"></i></a></td>";
                    strHtml += "</tr>";
                }
                if (intEnableModify == 0 && intEnableCancel == 1)
                {
                    strHtml += "<td style=\" width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  class=\"btn btn-xs btn-default\" \"tooltip\" title=\"Delete\" data-original-title=\"Edit Row\" onclick=\"return OpenCancelView(" + Id + ");\"><i class=\"fa fa-trash\"></i></button></td>";
                    strHtml += "</tr>";
                }
                if (intEnableModify == 0 && intEnableCancel == 0)
                {
                    strHtml += "</tr>";
                }

               



            }
            else
            {
                strHtml += "<td style=\"width:7%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"View\"  onclick='return getdetails(this.href);' href=\"hcm_OverTime_Category_Master.aspx?ViewId=" + strId + "\"><i class=\"fa fa-eye\"></i></a></td>";
                strHtml += "</tr>";
            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    //for the list table in the list page
   
    protected void btnRedirect_Click(object sender, EventArgs e)
    { Session["OvrViewId"] ="";
      Session["EditId"] = "";//
      if (hiddenViewStatus.Value == "1")
            Session["OvrViewId"] = HiddenEditId.Value;

        else
            Session["EditId"] = HiddenEditId.Value;
        
        Response.Redirect("hcm_OverTime_Category_Master.aspx");
    }


    [WebMethod]
    public static string ChangeOvrtmCancel(string strCatId, string strReason, string strReasonMust, string UserId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        string strRet = "success";

        objEntity_OverTime_Category.OvrtmCatgrMasterId = Convert.ToInt32(strCatId);
        objEntity_OverTime_Category.User_Id = Convert.ToInt32(UserId);
        objEntity_OverTime_Category.Date = System.DateTime.Now;


        if (strReasonMust == "1")
        {
            objEntity_OverTime_Category.CancelReason = strReason;
        }
        else
        {
            objEntity_OverTime_Category.CancelReason = objCommon.CancelReason();
        }
        try
        {
            objBusiness_OverTime_Category.CancelOverTimeCategory(objEntity_OverTime_Category);
            Page objpage = new Page();
            objpage.Session["SuccessMsg"] = "DELETE";      
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;

    }
    [WebMethod]
    public static string EditItem(string strId)
    {
        string strRet = "success";
        Page objpage = new Page();
        objpage.Session["EditId"] = strId; 
        return strRet;
    }

    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
        clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
        clsEntity_OverTIme_Category_List objEntity_OverTIme_Category_List = new clsEntity_OverTIme_Category_List();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();


        if (CbxCnclStatus.Checked == true)
            objEntity_OverTime_Category.CancelStatus = 1;
        else
            objEntity_OverTime_Category.CancelStatus = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtOvrtm = new DataTable();

        dtOvrtm = objBusiness_OverTime_Category.ReadOverTimeCateg(objEntity_OverTime_Category);
        int intUserId = 0, intUsrRolMstrId = 0,intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
       
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Overtime_Category);
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

        string strHtm = ConvertDataTableToHTML(dtOvrtm, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
}

