using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.IO;
using System.Data;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text;
public partial class MasterPage_Default : System.Web.UI.Page
{
    clsBusinesslayerCorpDept objBusinessLayerCorpDept = new clsBusinesslayerCorpDept();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions.


        txtDeptName.Attributes.Add("onkeypress", "return isTag(event)");
        txtDeptName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlMainDeptName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlMainDeptName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbDeptStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlBu.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbDeptStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDiv.Attributes.Add("onkeypress", "return DisableEnter(event)");


        //If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.
        
        if (!IsPostBack)
        {
            //EVM-0012
            //Divisions_Load(); // evm-0023
            HiddenDeptId.Value = "0";
            HiddenView.Value = "0";
            LoadBusinessUnits();
            txtDeptName.Focus();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Corporate_Department);
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

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                    btnUpdateF.Visible = true;
                }
                else
                {

                    btnUpdate.Visible = false;
                    btnUpdateF.Visible = false;
                }
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenDeptId.Value = strId.ToString();//EMP0025
                Update(strId);
                lblEntry.InnerText = "Edit Corporate Department";
                lblEntryB.InnerText = "Edit Corporate Department";

            }
            else if (Request.QueryString["InsUpd"] != null)
            {
                string strRandomMixedId = Request.QueryString["InsUpd"].ToString();
              string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
              string strId = strRandomMixedId.Substring(2, intLenghtofId);
              Update(strId);
              lblEntry.InnerText = "Edit Corporate Department";
              lblEntryB.InnerText = "Edit Corporate Department";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
            }
            else if (Request.QueryString["InsUp"] != null)
            {
                string strRandomMixedId = Request.QueryString["InsUp"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                Update(strId);
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenDeptId.Value = strId.ToString();
                View(strId);

                lblEntry.InnerText = "View Corporate Department";
                lblEntryB.InnerText = "View Corporate Department";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else if (Request.QueryString["InsWelfare"] != null)
            {
                string strRandomMixedId = Request.QueryString["InsWelfare"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.InnerText = "Edit Corporate Department";
                lblEntryB.InnerText = "Edit Corporate Department";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", "SuccessMessage();", true);
            }
            else if (Request.QueryString["ErrorWelfare"] != null)
            {
                string strRandomMixedId = Request.QueryString["ErrorWelfare"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.InnerText = "Edit Corporate Department";
                lblEntryB.InnerText = "Edit Corporate Department";
                ScriptManager.RegisterStartupScript(this, GetType(), "ValueNotFoundMessage", "ValueNotFoundMessage();", true);
            }
            else
            {
                lblEntry.InnerText = "Add Corporate Department";
                lblEntryB.InnerText = "Add Corporate Department";
                Department_Load();
                //Divisions_Load(); //EVM-0023

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    // if (strInsUpd == "Ins")
                    //  {
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    // }
                    if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
                divWelfareService.Attributes["style"] = "display:none;";
     //lblWelfareSrvc.Visible = false;
                //clsEntityCorpDept objEntityDept = new clsEntityCorpDept();
                //objEntityDept.Department_Id = Convert.ToInt32(HiddenDeptId.Value);
                //DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
                //DataTable dtWelfar = objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityDept);
                //dtWelfar = null;
                //if (dtWelfareScvc.Rows.Count > 0)
                //{
                //    string strHtm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar);
                //    //Write to divReport
                //    divReport.InnerHtml = strHtm;
                //}
                //else
                //{
                //    lblWelfareSrvc.Visible = false;
                //}
            }

        }
    

    }
    public string ConvertDataTableToHTML(DataTable dt, DataTable dtWelfar)   //EMP0025
    {

        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();
        // class="table table-bordered table-striped"
        string strHtml ="<ul class=\"wel_li\" id=\"ReportTable\">";
                 
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        string strId = "";
        if (Request.QueryString["InsUp"] != null)
        {
            string strRandomMixedId = Request.QueryString["InsUp"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
          strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        else if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
          strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        else if (Request.QueryString["ErrorWelfare"] != null)
        {

            string strRandomMixedId = Request.QueryString["ErrorWelfare"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        else if (Request.QueryString["InsWelfare"] != null)
        {

            string strRandomMixedId = Request.QueryString["InsWelfare"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
       
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<li id=\"trId_" + intRowBodyCount + " \"  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (HiddenView.Value == "0")
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<a style=\"cursor:pointer;\" id=\"tdName_" + intRowBodyCount + " \" onclick=\"return preview('" + dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "," + strId + "," + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "');\"><i class=\"fa fa-arrow-circle-right\"></i>" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</a>";
                        strHtml += "<a id=\"tdDeptId_" + intRowBodyCount + " \"  style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + strId + "</a>";
                        HiddenWelfareId.Value = dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString();
                        HiddenDeptId.Value = strId;
                    }

                }
                else
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<a style=\"cursor:pointer;\" id=\"tdName_" + intRowBodyCount + " \"><i class=\"fa fa-arrow-circle-right\"></i>" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</a>";
                        strHtml += "<a id=\"tdDeptId_" + intRowBodyCount + " \"  style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + strId + "</a>";
                        HiddenWelfareId.Value = dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString();
                        HiddenDeptId.Value = strId;

                    }
                }               
            }

            strHtml += "</li>";

        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<li>No Data Available</li>";
        }
        strHtml += "</ul>";



        sb.Append(strHtml);
        return sb.ToString();


    }


    [WebMethod]
    public static string preview1(string strid, string strdeptid)
    {
    
        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();
        clsBusinesslayerCorpDept objBusinessLayerCorpDept = new clsBusinesslayerCorpDept();
      
        MasterPage_Default obj = new MasterPage_Default();
        string Details = obj.ConvertDataTable(strid, strdeptid);


        return Details;

      
    }
    public string ConvertDataTable(string Id, string strdeptid)
    {
        clsEntityCorpDept objEntityDept = new clsEntityCorpDept();   //emp0025
        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();



        objEntityDept.Department_Id = Convert.ToInt32(strdeptid);
        objEntityWelfare.Dept_Id = Convert.ToInt32(strdeptid);
        objEntityWelfare.Welfare_Id = Convert.ToInt32(Id);
        DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
       
    
        DataTable dtWelfarById = objBusinessLayerCorpDept.ReadDsgnWelfareById(objEntityWelfare);

        DataTable dtWelfar = new DataTable();
        string WelfareSubId = "";
        if (dtWelfarById.Rows.Count > 0)
        {
            for (int i = 0; i < dtWelfarById.Rows.Count; i++)
            {
                //   objEntityWelfareDesg.WelfrSub_Id = Convert.ToInt32(dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString());
                if (WelfareSubId == "")
                {
                    WelfareSubId = dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString();
                }

                else
                {
                    WelfareSubId = WelfareSubId + "," + dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString();
                }
            }
            objEntityWelfare.WelfSub_Id = WelfareSubId;
            dtWelfar = objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityWelfare); 
        }
            



        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"

        string strHtml = "<table id=\"ReportTableWelfare\" class=\"table table-bordered\">";
        //add header row
        strHtml += "<thead class=\"thead1\" id=\"ReportTableWelfareH\">";
        strHtml += "<tr>";
        int count = dtWelfarById.Rows.Count;
    
        int wlchecked1 = 0;
        int chkCount = 0;

        int flag = 0;
        if (flag == 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtWelfarById.Rows.Count; intRowBodyCount++)
            {
                if (dtWelfar != null)
                {
                    if (dtWelfar.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                        {

                            if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                            {
                                if (dtWelfar.Rows[intRowCount]["WLFRSRVC_CNCLDATE"].ToString() == "")
                                {
                                    chkCount = chkCount + 1;
                                    wlchecked1 = 1;
                                    break;
                                }
                                else if (dtWelfar.Rows[intRowCount]["WLFRSRVC_CNCLDATE"].ToString() != "")
                                {
                                    wlchecked1 = 2;
                                    break;
                                }
                            }

                        }



                    }
                    else
                    {
                         strHtml += "<th class=\"th_b5 tr_l\">";
                  strHtml += "<span class=\"button-checkbox lbr_chk flt_n\" style=\"float: none;\">";
                  strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"selectAll(" + count + ")\" ng-model=\"all\"></button>";
                    strHtml += "<input type=\"checkbox\" class=\"hidden\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\" onkeypress=\"return DisableEnter(event)\" />";
                  strHtml += "</span>";
                  strHtml += "</th>";
                       
                        flag = 1;
                        break;
                    }


                }
            }
        }
        if (flag == 0)
        {
            if (wlchecked1 == 1)
            {
                if (chkCount == count)
                {
                    strHtml += "<th class=\"th_b5 tr_l\">";
                    strHtml += "<span class=\"button-checkbox lbr_chk flt_n\" style=\"float: none;\">";
                    strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"selectAll(" + count + ")\" ng-model=\"all\"></button>";
                    strHtml += "<input type=\"checkbox\" class=\"hidden\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\" onkeypress=\"return DisableEnter(event)\" />";
                    strHtml += "</span>";
                    strHtml += "</th>";
                }
                else
                {
                    strHtml += "<th class=\"th_b5 tr_l\">";
                    strHtml += "<span class=\"button-checkbox lbr_chk flt_n\" style=\"float: none;\">";
                    strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"selectAll(" + count + ")\" ng-model=\"all\"></button>";
                    strHtml += "<input type=\"checkbox\" class=\"hidden\"  Id=\"cbxSelectAll\" title=\"Select All\" onkeypress=\"return DisableEnter(event)\" />";
                    strHtml += "</span>";
                    strHtml += "</th>";
                }
            }
            else if (wlchecked1 == 0)
            {
                strHtml += "<th class=\"th_b5 tr_l\">";
                strHtml += "<span class=\"button-checkbox lbr_chk flt_n\" style=\"float: none;\">";
                strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"selectAll(" + count + ")\" ng-model=\"all\"></button>";
                strHtml += "<input type=\"checkbox\" class=\"hidden\"  Id=\"cbxSelectAll\" title=\"Select All\" onkeypress=\"return DisableEnter(event)\" />";
                strHtml += "</span>";
                strHtml += "</th>";
            }
            else if (wlchecked1 == 2)
            {
                strHtml += "<th class=\"th_b5 tr_l\">";
                strHtml += "<span class=\"button-checkbox lbr_chk flt_n\" style=\"float: none;\">";
                strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"selectAll(" + count + ")\" ng-model=\"all\"></button>";
                strHtml += "<input type=\"checkbox\" class=\"hidden\"  Id=\"cbxSelectAll\" title=\"Select All\" onkeypress=\"return DisableEnter(event)\" />";
                strHtml += "</span>";
                strHtml += "</th>";
            }
        }




        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtWelfarById.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"col-md-2\">From</th>";
                

            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-2\">To</th>";
               
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-2\">Frequency</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-3 tr_c\">Limit</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"col-md-3\">Unit</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
     //   hiddenRowCount.Value = dtWelfareScvc.Rows.Count.ToString();

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dtWelfarById.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"trId_" + intRowBodyCount + " \"  >";
         //   strHtml += "<td id=\"tdCount_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows.Count.ToString() + "</td>";
            int wlchecked = 0;
            if (dtWelfar != null)
            {
                if (dtWelfar.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                    {

                        if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                        {
                            if (dtWelfar.Rows[intRowCount]["WLFRSRVC_CNCLDATE"].ToString() == "")
                            {
                                wlchecked = 1;
                                break;
                            }
                            else if (dtWelfar.Rows[intRowCount]["WLFRSRVC_CNCLDATE"].ToString() != "")
                            {
                                wlchecked = 2;
                                break;
                            }
                        }

                    }

                    if (wlchecked == 1)
                    {
                        strHtml += "<td id=\"tdchkbx_" + intRowBodyCount + " \">";
                       strHtml += "<span class=\"button-checkbox\">";
                       strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"CheckBoxChange(" + count + ");\" ng-model=\"all\"></button>";
                       strHtml += "<input type=\"checkbox\" class=\"hidden\" checked=\"checked\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" />";
                       strHtml += "</span>";
                       strHtml += "</td>";

                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";
                    }
                    else if (wlchecked==0)
                    {
                        strHtml += "<td id=\"tdchkbx_" + intRowBodyCount + " \">";
                        strHtml += "<span class=\"button-checkbox\">";
                        strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"CheckBoxChange(" + count + ");\" ng-model=\"all\"></button>";
                        strHtml += "<input type=\"checkbox\" class=\"hidden\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" />";
                        strHtml += "</span>";
                        strHtml += "</td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
                    }
                    else if (wlchecked == 2)
                    {
                        strHtml += "<td id=\"tdchkbx_" + intRowBodyCount + " \">";
                        strHtml += "<span class=\"button-checkbox\">";
                        strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"CheckBoxChange(" + count + ");\" ng-model=\"all\"></button>";
                        strHtml += "<input type=\"checkbox\" class=\"hidden\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" />";
                        strHtml += "</span>";
                        strHtml += "</td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";
                    }

                }
                else
                {
                    strHtml += "<td id=\"tdchkbx_" + intRowBodyCount + " \">";
                    strHtml += "<span class=\"button-checkbox\">";
                    strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"CheckBoxChange(" + count + ");\" ng-model=\"all\"></button>";
                    strHtml += "<input type=\"checkbox\" class=\"hidden\" checked=\"checked\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" />";
                    strHtml += "</span>";
                    strHtml += "</td>";
                    strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
                }
            }
            else
            {
                strHtml += "<td id=\"tdchkbx_" + intRowBodyCount + " \">";
                strHtml += "<span class=\"button-checkbox\">";
                strHtml += "<button type=\"button\" class=\"btn-d\" data-color=\"p\" onclick=\"CheckBoxChange(" + count + ");\" ng-model=\"all\"></button>";
                strHtml += "<input type=\"checkbox\" class=\"hidden\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" />";
                strHtml += "</span>";
                strHtml += "</td>";
                strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
            }




            for (int intColumnBodyCount = 0; intColumnBodyCount < dtWelfarById.Columns.Count; intColumnBodyCount++)
            {

           //     strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"IncrmntConfrmCounter();\" /></td>";
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tr_c\">" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRMPERD"].ToString() + "</td>";
                   
                }
               
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tr_c\">" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_TOPERD"].ToString() + "</td>";
                  //  strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;display:none; \"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdDepSubtId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdWelfareId_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "</td>";

                   
                   
                }
                else if (intColumnBodyCount == 2)
                {
                    string Frequancy = dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRQNCY"].ToString();
                    if (Frequancy == "0")
                    {
                        strHtml += "<td class=\"tr_c\"   >1 Month</td>";
                    }
                    if (Frequancy == "1")
                    {
                        strHtml += "<td class=\"tr_c\"  >2 Month</td>";
                    }
                    if (Frequancy == "2")
                    {
                        strHtml += "<td class=\"tr_c\"   >1 Year</td>";
                    }
                    if (Frequancy == "3")
                    {
                        strHtml += "<td class=\"tr_c\"   >Per Visit</td>";
                    }
                  //  strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRQNCY"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    int qty = 0;
                    string strQntity = "";
                    if (dtWelfar != null)
                    {

                        if (dtWelfar.Rows.Count > 0)
                        {
                            for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                            {
                                if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                                {
                                    strQntity = dtWelfar.Rows[intRowCount]["WLFRSRVC_QNTY"].ToString();
                                    qty = 1;
                                    break;
                                }
                            }
                            if (qty == 1)
                            {

                                strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tr_r\" ><input class=\"fg2_inp2 fg2_inp3 tr_r flt_r\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + strQntity + "\"  maxlength=\"10\" onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";

                            }
                            else
                            {

                                strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tr_r\"><input  class=\"fg2_inp2 fg2_inp3 tr_r flt_r\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                            }

                        }
                        else
                        {


                            strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tr_r\"><input  class=\"fg2_inp2 fg2_inp3 tr_r flt_r\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                            strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                            strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                        }
                    }
                    else
                    {

                        strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tr_r\"><input  class=\"fg2_inp2 fg2_inp3 tr_r flt_r\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"   onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                        strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                        strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                    }
                  


                }
                else if (intColumnBodyCount == 4)
                {
                    string unit = dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_UNIT"].ToString();
                    string strunt = "";
                    if (unit == "0")
                    {
                        strunt = "Liter";

                    }
                    else if (unit == "1")
                    {
                        strunt = "Amount";

                    }
                    else if (unit == "2")
                    {
                        strunt = "Count";

                    }
                    else if (unit == "3")
                    {
                        strunt = "KiloGram";

                    }
                    else if (unit == "4")
                    {
                        strunt = "Meter";

                    }

                    strHtml += "<td class=\"td1\">" + strunt + "</td>";

                 }
            }

            strHtml += "</tr>";

        }
        if (dtWelfarById.Rows.Count == 0)
        {
            strHtml += "<td class=\"tr_l\" colspan=\"6\">No Data Available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();


    }

    //Load active business units
    public void LoadBusinessUnits()
    {
        EL_Compzit.clsEntityCorpDept objEntityDept = new EL_Compzit.clsEntityCorpDept();
        if (Session["ORGID"] != null)
        {
            objEntityDept.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

        DataTable dtCorpoffice = objBusinessLayerCorpDept.ReadCorpOffice(objEntityDept);
        if (dtCorpoffice.Rows.Count > 0)
        {
            ddlBu.DataSource = dtCorpoffice;
            ddlBu.DataTextField = "CORPRT_NAME";
            ddlBu.DataValueField = "CORPRT_ID";
            ddlBu.DataBind();
        }
    }

    //Method for assigning corporate departments to the dropdown list
    public void Department_Load(int intDeptId = 0)
    {
        EL_Compzit.clsEntityCorpDept objEntityDept = new EL_Compzit.clsEntityCorpDept();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDept.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDept.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (intDeptId != 0)
        {
            objEntityDept.intDep_Id = intDeptId;
        }
        DataTable dtCorpDept = objBusinessLayerCorpDept.ReadCorpDept(objEntityDept);
        DataView dvDept = new DataView(dtCorpDept);
        dvDept.Sort = "CPRDEPT_NAME";
        ddlMainDeptName.DataSource = dvDept;
        for (int intDtCnt = 0; intDtCnt < dtCorpDept.Rows.Count; intDtCnt++)
        {
            ddlMainDeptName.DataTextField = "CPRDEPT_NAME";
            ddlMainDeptName.DataValueField = "CPRDEPT_ID";
            ddlMainDeptName.DataBind();
        }
        ddlMainDeptName.Items.Insert(0, "--SELECT MAIN DEPARTMENT--");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
       
            EL_Compzit.clsEntityCorpDept objEntityDept = new EL_Compzit.clsEntityCorpDept();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityDept.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityDept.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }



            //If no main department selected
            if (ddlMainDeptName.SelectedItem.Text.ToString() == "--SELECT MAIN DEPARTMENT--")
            {
                objEntityDept.Department_Id = null;
            }
            //If selected
            else
            {
                objEntityDept.Department_Id = Convert.ToInt32(ddlMainDeptName.SelectedItem.Value);
            }


            //Status checkbox checked
            if (cbDeptStatus.Checked == true)
            {
                objEntityDept.Dept_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityDept.Dept_Status = 0;
            }
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
               strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityDept.Department_Master_Id = Convert.ToInt32(strDeptId);
            }
            else if (Request.QueryString["InsUp"] != null)
            {
                 strRandomMixedId = Request.QueryString["InsUp"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityDept.Department_Master_Id = Convert.ToInt32(strDeptId);
            }
            else if (Request.QueryString["InsWelfare"] != null)
            {
                strRandomMixedId = Request.QueryString["InsWelfare"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityDept.Department_Master_Id = Convert.ToInt32(strDeptId);
            }
            else if (Request.QueryString["ErrorWelfare"] != null)
            {
                strRandomMixedId = Request.QueryString["ErrorWelfare"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityDept.Department_Master_Id = Convert.ToInt32(strDeptId);
            }

            objEntityDept.User_Id = Convert.ToInt32(Session["USERID"]);
            objEntityDept.D_Date = System.DateTime.Now;
            txtDeptName.Value = txtDeptName.Value.ToUpper();
            objEntityDept.Department_Name = txtDeptName.Value;
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerCorpDept.Check_Dept_Name(objEntityDept);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                //Read selected business units for this department
                //evm-0023 start

                List<clsEntityCorpIdListIns> objBusinessUnitInsList = new List<clsEntityCorpIdListIns>();
                string strCanclDtlIdC = "";
                string[] strarrCancldtlIdsC = strCanclDtlIdC.Split(',');
                if (HiddenFieldBusnsUnitValues.Value != "" && HiddenFieldBusnsUnitValues.Value != null)
                {
                    strCanclDtlIdC = HiddenFieldBusnsUnitValues.Value;
                    strarrCancldtlIdsC = strCanclDtlIdC.Split(',');

                }
                foreach (string strDtlId in strarrCancldtlIdsC)
                {
                    if (strDtlId != "")
                    {
                        clsEntityCorpIdListIns objBusinessUnitIns = new clsEntityCorpIdListIns();
                        objBusinessUnitIns.CorpIdList = Convert.ToInt32(strDtlId);
                        objBusinessUnitInsList.Add(objBusinessUnitIns);
                    }
                }



               

                //Read selected divisions units for this department
                List<clsEntityDeptDivListIns> objEntityDeptDivListIns = new List<clsEntityDeptDivListIns>();



                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (HiddenFieldDivisionValues.Value != "" && HiddenFieldDivisionValues.Value != null)
                {
                    strCanclDtlId = HiddenFieldDivisionValues.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }
                foreach (string strDtlId in strarrCancldtlIds)
                {
                    if (strDtlId != "")
                    {
                        clsEntityDeptDivListIns objEntityDeptDiv = new clsEntityDeptDivListIns();
                        objEntityDeptDiv.DeptDivList = Convert.ToInt32(strDtlId);
                        objEntityDeptDivListIns.Add(objEntityDeptDiv);
                    }
                }
                //evm-0023 end

                //DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);//EMP0025

                //List<clsEntityLayerDepartmentWelfareSrvc> objListDeptgWelfare = new List<clsEntityLayerDepartmentWelfareSrvc>();


                //string jsonData = Hiddenchecklist.Value;
                //string c = jsonData.Replace("\"{", "\\{");
                //string d = c.Replace("\\n", "\r\n");
                //string g = d.Replace("\\", "");
                //string h = g.Replace("}\"]", "}]");
                //string k = h.Replace("}\",", "},");
                //List<clsWBData> objWBDataList = new List<clsWBData>();
                //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
                //foreach (clsWBData objclsWBData in objWBDataList)
                //{
                //    clsEntityLayerDepartmentWelfareSrvc objDept = new clsEntityLayerDepartmentWelfareSrvc();

                //    objDept.Dept_Id = Convert.ToInt32(objclsWBData.DeptId);
                //    objDept.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
                //    objDept.Qty = Convert.ToDecimal(objclsWBData.limit);
                //    objListDeptgWelfare.Add(objDept);
                //}

                objBusinessLayerCorpDept.Update_Dept(objEntityDept, objBusinessUnitInsList, objEntityDeptDivListIns);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    //Response.Redirect("gen_Corp_Dept.aspx?InsUpd=" + Id);
                    Response.Redirect("gen_Corp_Dept.aspx?InsUp=" + strRandomMixedId);

                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_Corp_DeptList.aspx?InsUpd=Upd");
                }
                
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtDeptName.Focus();
            }
        //}
    }


    public class clsWBData //EMP0025
    {
        public string DeptId { get; set; }
        public string WelfareId { get; set; }
        public string limit { get; set; }
        public string WelfareSubId { get; set; }
        public string chkSts { get; set; }
        public string CheckboxSts { get; set; }
        public string ActLimt { get; set; }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
     

        EL_Compzit.clsEntityCorpDept objEntityDept = new EL_Compzit.clsEntityCorpDept();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDept.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDept.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        //If no main department selected

        if (ddlMainDeptName.SelectedItem.Text.ToString() == "--SELECT MAIN DEPARTMENT--")
        {
            objEntityDept.Department_Id = null;
        }
        //If selected
        else
        {
            objEntityDept.Department_Id = Convert.ToInt32(ddlMainDeptName.SelectedItem.Value);
        }
        //Status checkbox checked
        if (cbDeptStatus.Checked == true)
        {
            objEntityDept.Dept_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityDept.Dept_Status = 0;
        }
        objEntityDept.User_Id = Convert.ToInt32(Session["USERID"]);
        objEntityDept.D_Date = System.DateTime.Now;
        txtDeptName.Value = txtDeptName.Value.ToUpper().Trim();
        objEntityDept.Department_Name = txtDeptName.Value;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerCorpDept.Check_Dept_Name(objEntityDept);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            //this List stores the selected Business units
            List<clsEntityCorpIdListIns> objListclass = new List<clsEntityCorpIdListIns>();
            string strCanclDtlIdC = "";
            string[] strarrCancldtlIdsC = strCanclDtlIdC.Split(',');
            if (HiddenFieldBusnsUnitValues.Value != "" && HiddenFieldBusnsUnitValues.Value != null)
            {
                strCanclDtlIdC = HiddenFieldBusnsUnitValues.Value;
                strarrCancldtlIdsC = strCanclDtlIdC.Split(',');

            }
            foreach (string strDtlId in strarrCancldtlIdsC)
            {
                if (strDtlId != "")
                {
                    clsEntityCorpIdListIns objBusinessUnitIns = new clsEntityCorpIdListIns();
                    objBusinessUnitIns.CorpIdList = Convert.ToInt32(strDtlId);
                    objListclass.Add(objBusinessUnitIns);
                }
            }
            //evm-0023 start
            List<clsEntityDeptDivListIns> objEntityDeptDivListIns = new List<clsEntityDeptDivListIns>();

            

        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (HiddenFieldDivisionValues.Value != "" && HiddenFieldDivisionValues.Value != null)
        {
            strCanclDtlId = HiddenFieldDivisionValues.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }
        foreach (string strDtlId in strarrCancldtlIds)
        {
            if (strDtlId != "")
            {
                clsEntityDeptDivListIns objEntityDeptDiv = new clsEntityDeptDivListIns();
                objEntityDeptDiv.DeptDivList = Convert.ToInt32(strDtlId);
                objEntityDeptDivListIns.Add(objEntityDeptDiv);
            }
        }


           
            //evm-0023 end
        DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);//EMP0025

        //List<clsEntityLayerDepartmentWelfareSrvc> objListDeptgWelfare = new List<clsEntityLayerDepartmentWelfareSrvc>();


        //string jsonData = Hiddenchecklist.Value;
        //string c = jsonData.Replace("\"{", "\\{");
        //string d = c.Replace("\\n", "\r\n");
        //string g = d.Replace("\\", "");
        //string h = g.Replace("}\"]", "}]");
        //string k = h.Replace("}\",", "},");
        //List<clsWBData> objWBDataList = new List<clsWBData>();
        //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
        //foreach (clsWBData objclsWBData in objWBDataList)
        //{
        //    clsEntityLayerDepartmentWelfareSrvc objDept = new clsEntityLayerDepartmentWelfareSrvc();

        //    objDept.Dept_Id = Convert.ToInt32(objclsWBData.DeptId);
        //    objDept.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
        //    objDept.Qty = Convert.ToDecimal(objclsWBData.limit);
        //    objListDeptgWelfare.Add(objDept);
        //}


        //evm-0023 end

        objBusinessLayerCorpDept.Insert_Dept(objEntityDept, objListclass, objEntityDeptDivListIns);

        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strRandom = objCommon.Random_Number();
               int ID= objEntityDept.Department_Master_Id;

               string deptId = ID.ToString();
               int intIdLength = deptId.Length;
               string stridLength = intIdLength.ToString("00");
               string Id = stridLength + deptId + strRandom;

               //Response.Redirect("hcm_Emp_Conduct.aspx?InsUpd=" + Id);
               Response.Redirect("gen_Corp_Dept.aspx?InsUpd=" + Id);
               // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                //clsEntityCorpDept objEntityDept = new clsEntityCorpDept();
             //objEntityDept.Department_Id = Convert.ToInt32(HiddenDeptId.Value);
             // //DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
             //   DataTable dtWelfar = objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityDept);
             //   dtWelfar = null;
             //   if (dtWelfareScvc.Rows.Count > 0)
             //   {
             //       string strHtm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar);
             //       //Write to divReport
             //       divReport.InnerHtml = strHtm;
             //   }
             //   else
             //   {
             //       lblWelfareSrvc.Visible = false;
             //   }
            }
        else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Corp_DeptList.aspx?InsUpd=Ins");
            }
          
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtDeptName.Focus();
        }

    }


    public void View(string strDId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        EL_Compzit.clsEntityCorpDept objEntCorpDept = new EL_Compzit.clsEntityCorpDept();
        objEntCorpDept.Department_Master_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerCorpDept.ReadDeptById(objEntCorpDept);
        //Read selected business units for this department
        DataTable dtBusinessUnitsById = objBusinessLayerCorpDept.ReadBusinessUnitsById(objEntCorpDept);
        //Load Checkbox list selections
        HiddenFieldBusnsUnitValues.Value = "";
        if (dtBusinessUnitsById.Rows.Count > 0)
        {           
                for (int count = 0; count < dtBusinessUnitsById.Rows.Count; count++)
                {
                    string intType = dtBusinessUnitsById.Rows[count]["CORPRT_ID"].ToString();

                    if (HiddenFieldBusnsUnitValues.Value == "")
                    {
                        HiddenFieldBusnsUnitValues.Value =  intType;
                    }
                    else
                    {
                        HiddenFieldBusnsUnitValues.Value = HiddenFieldBusnsUnitValues.Value + "," + intType;
                    }
                }
        }

        // evm-0023 start
        DataTable dtCorpDivById = objBusinessLayerCorpDept.ReadDivisionById(objEntCorpDept);
        //Load Checkbox list division selections
        HiddenFieldDivisionValues.Value = "";
        if (dtCorpDivById.Rows.Count > 0)
        {           
                for (int count = 0; count < dtCorpDivById.Rows.Count; count++)
                {
                    string intType = dtCorpDivById.Rows[count]["CPRDIV_ID"].ToString();
                    if (HiddenFieldDivisionValues.Value == "")
                    {
                        HiddenFieldDivisionValues.Value = intType;
                    }
                    else
                    {
                        HiddenFieldDivisionValues.Value = HiddenFieldDivisionValues.Value + "," + intType;
                    }
                }
        }
        // evm-0023  end
        
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtDeptName.Value = dtDeptById.Rows[0]["DEPTMAIN"].ToString();
        

        ddlMainDeptName.Items.Clear();

        if (dtDeptById.Rows[0]["DEPTSUB"].ToString() == "")
        {
            ddlMainDeptName.Items.Insert(0, "--SELECT MAIN DEPARTMENT--");
        }
        else
        {
            ddlMainDeptName.Items.Clear();
            ListItem lst = new ListItem(dtDeptById.Rows[0]["DEPTSUB"].ToString(), dtDeptById.Rows[0]["DEPTSUBID"].ToString());
            ddlMainDeptName.Items.Insert(0, lst);
        }
        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["CPRDEPT_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbDeptStatus.Checked = true;
        }
        else
        {
            cbDeptStatus.Checked = false;
        }
        
        txtDeptName.Disabled = true;
        
        ddlMainDeptName.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbDeptStatus.Disabled = true;
        ddlBu.Enabled = false;
        ddlDiv.Enabled = false;
        //chkbxListBusinessUnit.Enabled = false;
        //cbxListCorpDiv.Enabled = false;

        HiddenView.Value = "1";
        clsEntityCorpDept objEntityDept = new clsEntityCorpDept();   //emp0025
        objEntityDept.Department_Id = Convert.ToInt32(HiddenDeptId.Value);
        DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
       // DataTable dtWelfar = objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityDept);
        DataTable dtWelfar =new DataTable();
        dtWelfar=null;
        if (dtWelfareScvc.Rows.Count > 0)
        {
            string strHtm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar);
            divReport.InnerHtml = strHtm;
            divWelfareService.Attributes["style"] = "display:block;";
        }
        else
        {
            divWelfareService.Attributes["style"] = "display:none;";
        }

       
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strDId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateCloseF.Visible = true;
        txtDeptName.Focus();
      //  EL_Compzit.clsEntityCorpDept objEntCorpDept = new EL_Compzit.clsEntityCorpDept();
        clsEntityCorpDept objEntCorpDept = new clsEntityCorpDept();
        objEntCorpDept.Department_Master_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerCorpDept.ReadDeptById(objEntCorpDept);
        //Read selected business units for this department
        DataTable dtBusinessUnitsById = objBusinessLayerCorpDept.ReadBusinessUnitsById(objEntCorpDept);
        HiddenFieldBusnsUnitValues.Value = "";
        //Load Checkbox list selections
        if (dtBusinessUnitsById.Rows.Count > 0)
        {
            for (int count = 0; count < dtBusinessUnitsById.Rows.Count; count++)
            {
                string intType = dtBusinessUnitsById.Rows[count]["CORPRT_ID"].ToString();

                if (HiddenFieldBusnsUnitValues.Value == "")
                {
                    HiddenFieldBusnsUnitValues.Value = intType;
                }
                else
                {
                    HiddenFieldBusnsUnitValues.Value = HiddenFieldBusnsUnitValues.Value + "," + intType;
                }
            }
        }

        // evm-0023 start
        DataTable dtCorpDivById = objBusinessLayerCorpDept.ReadDivisionById(objEntCorpDept);
        HiddenFieldDivisionValues.Value = "";
        //Load Checkbox list division selections
        if (dtCorpDivById.Rows.Count > 0)
        {
            for (int count = 0; count < dtCorpDivById.Rows.Count; count++)
            {
                string intType = dtCorpDivById.Rows[count]["CPRDIV_ID"].ToString();
                if (HiddenFieldDivisionValues.Value == "")
                {
                    HiddenFieldDivisionValues.Value = intType;
                }
                else
                {
                    HiddenFieldDivisionValues.Value = HiddenFieldDivisionValues.Value + "," + intType;
                }
            }
        }
        clsEntityCorpDept objEntityDept = new clsEntityCorpDept();   //emp0025
        objEntityDept.Department_Id = Convert.ToInt32(strDId);
       DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
        DataTable dtWelfar = new DataTable();
        dtWelfar = null;
        // dtWelfar=   objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityDept);
        if (dtWelfareScvc.Rows.Count > 0)
        {
            string strHtm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar);
            divReport.InnerHtml = strHtm;
            divWelfareService.Attributes["style"] = "display:block;";
        }
        else
        {
            divWelfareService.Attributes["style"] = "display:none;";
        }
        // evm-0023  end
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtDeptName.Value = dtDeptById.Rows[0]["DEPTMAIN"].ToString();
        Int32 intDepId = Convert.ToInt32(dtDeptById.Rows[0]["CPRDEPT_ID"].ToString());
        Department_Load(intDepId);
        if (dtDeptById.Rows[0]["DEPTSUB"].ToString() == "")
        {
            ddlMainDeptName.Items.FindByText("--SELECT MAIN DEPARTMENT--").Selected = true;
        }
        else
        {
            //ie IF MAIN  DEPARTMENT  IS ACTIVE
            if (dtDeptById.Rows[0]["DEPTSUBSTATUS"].ToString() == "1" && dtDeptById.Rows[0]["DEPTSUBCNCL_USR_ID"].ToString() == "")
            {
                ddlMainDeptName.Items.FindByText(dtDeptById.Rows[0]["DEPTSUB"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtDeptById.Rows[0]["DEPTSUB"].ToString(), dtDeptById.Rows[0]["DEPTSUBID"].ToString());
                ddlMainDeptName.Items.Insert(1, lst);

                SortDDL(ref this.ddlMainDeptName);

                ddlMainDeptName.Items.FindByText(dtDeptById.Rows[0]["DEPTSUB"].ToString()).Selected = true;
            }
        }
        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["CPRDEPT_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbDeptStatus.Checked = true;
        }
        else
        {
            cbDeptStatus.Checked = false;
        }

        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateCloseF.Visible = true;
    }
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
    public static string GetDivisions(string ChckedItems)
    {
        StringBuilder sb = new StringBuilder();
        clsBusinesslayerCorpDept objBusinessLayerCorpDept = new clsBusinesslayerCorpDept();
        clsEntityCorpDept objEntityDept = new clsEntityCorpDept();
      
        DataSet dt = new DataSet();
        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (ChckedItems != "" && ChckedItems != null)
        {
            strCanclDtlId = ChckedItems;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }
        DataTable FinalDt = new DataTable();
        foreach (string strDtlId in strarrCancldtlIds)
        {
            if (strDtlId != "")
            {
                objEntityDept.CorpOffice_Id = Convert.ToInt32(strDtlId);
                DataTable dts = objBusinessLayerCorpDept.ReadCorporateDivisionOffice(objEntityDept);
                if(dts.Rows.Count>0)
                FinalDt.Merge(dts);
            }
        }
        foreach (DataRow dr in FinalDt.Rows)
        {
            sb.Append("<option value=\"" + dr["CPRDIV_ID"].ToString() + "\">" + dr["CPRDIV_NAME"].ToString() + "</option>");
        }
        dt.Tables.Add(FinalDt);
        return sb.ToString();
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        EL_Compzit.clsEntityCorpDept objEntityDept = new EL_Compzit.clsEntityCorpDept();
        clsEntityLayerDepartmentWelfareSrvc objEntityWelfareDept = new clsEntityLayerDepartmentWelfareSrvc();
        Button clickedButton = sender as Button;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDept.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDept.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

     
        objEntityWelfareDept.Dept_Id = Convert.ToInt32(HiddenDeptId.Value);


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string deptId = HiddenDeptId.Value;
        int intIdLength = deptId.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + deptId + strRandom;

        objEntityWelfareDept.Welfare_Id = Convert.ToInt32(HiddenWelfareId.Value);
        objEntityDept.Department_Id = Convert.ToInt32(HiddenDeptId.Value);
        DataTable dtWelfareScvc = objBusinessLayerCorpDept.ReadDeptnWelfareSrvc(objEntityDept);
       //  DataTable dtWelfar = objBusinessLayerCorpDept.ReadDsgnWelfare(objEntityDept);
        DataTable dtWelfar = new DataTable();
        dtWelfar = null;
        bool existsCus = dtWelfareScvc.Select().ToList().Exists(row => row["WLFRSRVC_ID"].ToString().ToUpper() == HiddenWelfareId.Value);
        if (existsCus == true)
        {

            List<clsEntityLayerDepartmentWelfareSrvc> objListDeptgWelfare = new List<clsEntityLayerDepartmentWelfareSrvc>();


            string jsonData = Hiddenchecklist.Value;
            if (jsonData == "[]")
            {
                objEntityWelfareDept.Dept_Id = Convert.ToInt32(HiddenDeptId.Value);
            }
            else
            {

                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                List<clsWBData> objWBDataList = new List<clsWBData>();
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
                foreach (clsWBData objclsWBData in objWBDataList)
                {
                    clsEntityLayerDepartmentWelfareSrvc objDept = new clsEntityLayerDepartmentWelfareSrvc();

                    objDept.Dept_Id = Convert.ToInt32(objclsWBData.DeptId);
                    objDept.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
                    objDept.Qty = Convert.ToDecimal(objclsWBData.limit);
                    objDept.WelfrSub_Id = Convert.ToInt32(objclsWBData.WelfareSubId);
                    objDept.checkboxsts = Convert.ToInt32(objclsWBData.CheckboxSts);
                    objDept.chkSts = Convert.ToInt32(objclsWBData.chkSts);
                    objDept.ActQty = Convert.ToDecimal(objclsWBData.ActLimt);
                    objListDeptgWelfare.Add(objDept);
                }
            }
            objBusinessLayerCorpDept.Insert_DeptWelfare(objListDeptgWelfare, objEntityWelfareDept);
           
            if (clickedButton.ID == "btnRsnSave")
            {
                //Response.Redirect("gen_Corp_Dept.aspx?InsUpd=" + Id);
               
                Response.Redirect("gen_Corp_Dept.aspx?InsWelfare=" + Id);

            }

          
        }
        else
        {
            if (dtWelfareScvc.Rows.Count > 0)
            {

                string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfareScvc);
                //Write to divReport
                divReport.InnerHtml = strHtmmm;
                divWelfareService.Attributes["style"] = "display:block;";
            }
            else
            {
                divWelfareService.Attributes["style"] = "display:none;";
            }
            Response.Redirect("gen_Corp_Dept.aspx?ErrorWelfare=" + Id);
           
        }
    }
}