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

public partial class Employee_Performance_Templt_Employee_Perfomance_Templt_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlStatus.Focus();
            clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
            clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UsrId = intUserId;

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
            if (CbxCnclStatus.Checked == true)
            {
                objEntity.cnclStatus = 1;
            }
            else
            {
                objEntity.cnclStatus = 0;
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel=0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Tmplt);
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
                        HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }


                }
            }

            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }


            objEntity.ActStatus = Convert.ToInt32( ddlStatus.SelectedItem.Value);
            DataTable dtList = objEmpPerfomance.ReadPerfomanceTemplateList(objEntity);

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);


           // clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

        }
        if (Request.QueryString["InsUpd"] != null)
        {
            if (Request.QueryString["InsUpd"] == "cncl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
            }
        }
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    {
      
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


        for (int intColumnHeaderCount = 0; intColumnHeaderCount <7; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\"> REFERENCE NUMBER";


                strHtml += "	<input class=\"form-control\" placeholder=\" REFERENCE NUMBER\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:35%;text-align:left;\">PERFORMANCE TEMPLATES ";


                strHtml += "	<input class=\"form-control\" placeholder=\"PERFORMANCE TEMPLATES\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:RIGHT;\">NUMBER OF GROUP ";


                strHtml += "	<input class=\"form-control\" placeholder=\"NUMBER OF GROUP\" style=\"text-align:RIGHT;\" type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:RIGHT;\">NUMBER OF QUESTION";


                strHtml += "	<input class=\"form-control\" style=\"text-align:RIGHT;\" placeholder=\"NUMBER OF QUESTION\" type=\"text\">";
                strHtml += "</th >";
            }


            else if (intColumnHeaderCount == 5)
            {
                 if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                if (CbxCnclStatus.Checked == false)
                {

                    strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> EDIT";
                   
                }
                    }
                 if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                 {
                     if (CbxCnclStatus.Checked == false)
                     {

                         strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> DELETE";

                     }
                 }
               
            }

            else if (intColumnHeaderCount == 6)
            {
                if (CbxCnclStatus.Checked == true)
                {
                    strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
                }
            }
           
           
        }
       
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><a class=\"tooltip\"  style=\"cursor:pointer;color: #4b4bf2;opacity:1;z-index: 0;\"  title=\"Go To View\" onclick=\"return FunctionPreview('" + Id + "');\" >" + dt.Rows[intRowBodyCount]["PRFMNC_TMPLT_REF"].ToString() + "</a></td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PRFMNC_TMPLT_FORM"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: RIGHT;\" > " + dt.Rows[intRowBodyCount]["Groupnum"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: RIGHT;\" >" + dt.Rows[intRowBodyCount]["QSTNNUMBER"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {


                    //string strId = dt.Rows[intRowBodyCount][0].ToString();
                    //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    //string stridLength = intIdLength.ToString("00");
                    //string Id = stridLength + strId + strRandom;

                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {

                            strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;z-index: 10;\" class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"Employee_Performance_Templt.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a></td>";

                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if (intCancTransaction==0)
                            strHtml += "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: 1;margin-left: 1%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";
                            else
                                strHtml += "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: .4;margin-left: 1%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";

                        }

                    }

                }
                else if (intColumnBodyCount == 6)
                {

                  
                    if (CbxCnclStatus.Checked == true)
                    {
                        strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;\" class=\"tooltip\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"Employee_Performance_Templt.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a></td>";


                    }
                }
               
                
            }



          
            strHtml += "</tr>";
        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }



    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.PerfomanceId = Convert.ToInt32(strId);
        objEntity.UsrId = Convert.ToInt32(usrId);
       
        if (reasonmust == "1")
        {
            objEntity.CnclRsn = cnclRsn;
        }

        else
        {
            objEntity.CnclRsn = objCommon.CancelReason();
        }

        try
        {
            objEmpPerfomance.CancelPerfomanceTemplate(objEntity);
           
        }
        catch
        {
            strRets = "failed";
        }
       
        return strRets;

    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

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
        if (CbxCnclStatus.Checked == true)
        {
            objEntity.cnclStatus = 1;
        }
        else
        {
            objEntity.cnclStatus = 0;
        }
        objEntity.ActStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objEmpPerfomance.ReadPerfomanceTemplateList(objEntity);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int  intUsrRolMstrId = 0,  intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Tmplt);
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
                    HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }


            }
        }

        if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {

        }
        else
        {
            divAdd.Visible = false;
        }

       
        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);

    }
}