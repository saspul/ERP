using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using System.Data;
using CL_Compzit;
using System.Text;
using EL_Compzit;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class Master_gen_Designation_gen_DesignationAdd : System.Web.UI.Page
{
    //Created objects for business layer
    clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
    protected void Page_Load(object sender, EventArgs e)
    {

        txtDesignationName.Attributes.Add("onkeypress", "return isTag(event)");
        txtDesignationName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDesignationType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlDesignationType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        CbxAllocateAll.Attributes.Add("onkeypress", "return DisableEnter(event)");
        CbxAllocateAll.Attributes.Add("onchange", "IncrmntConfrmCounter()");
      //  cbxlCompzitModules.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //start 0009
        cbxAllocateAllUsr.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxAllocateAllUsr.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxlLeaveTypes.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxlLeaveTypes.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //stop 0009

        //On not is post back
        if (!IsPostBack)
        {
           // divAllocateAll.Visible = false;
           // divAllocateAllUsr.Visible = false;
            HiddenDesgId.Value = "0";   //EMP0025
            HiddenView.Value = "0";
            //  Treefill();
            txtDesignationName.Focus();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
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
            //start 0009
            clsEntityLayerDesignation objEntityDesgLeaveType = new clsEntityLayerDesignation();

            if (Session["ORGID"] != null)
            {
                objEntityDesgLeaveType.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());


            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            hiddenDsgnControlId.Value = "C";
            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
            {

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityDesgLeaveType.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            //stop 0009

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                btnAddf.Visible = false;
                btnAddClosef.Visible = false;
                btnUpdatef.Visible = true;
                btnUpdateClosef.Visible = true;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //start 0009

                objEntityDesgLeaveType.DesignationId = Convert.ToInt32(strId);
                HiddenDesgId.Value = "0";      //EMP0025
                HiddenDesgId.Value = strId.ToString();
                BindLeaveTypes(objEntityDesgLeaveType);
                //stop 0009
                UpdateView(strId);
             //   divAllocateAll.Visible = true;
                //start 0009
                //divAllocateAllUsr.Visible = true;
                //stop 0009
                lblEntry.InnerText = "Edit Designation";
            }

              //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAddf.Visible = false;
                btnAddClosef.Visible = false;
                btnClear.Visible = false;
                btnClearf.Visible = false;
                btnUpdatef.Visible = false;
                btnUpdateClosef.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //start 0009
                HiddenView.Value = "1";
                objEntityDesgLeaveType.DesignationId = Convert.ToInt32(strId);
                BindLeaveTypes(objEntityDesgLeaveType);
                //stop 0009
                UpdateView(strId);
                txtDesignationName.Enabled = false;
                ddlDesignationType.Enabled = false;
                // TreeViewCompzit_AppAdminstration.Enabled = false;
                // TreeViewCompzit_SalesAutomation.Enabled = false;      

                cbxStatus.Enabled = false;

                lblEntry.InnerText = "View Designation";
            }
            //else if (Request.QueryString["InUpd"] != null)
            //{

            //    lblEntry.InnerText= "Edit Designation";
            //    btnAdd.Visible = false;
            //    btnAddClose.Visible = false;
            //    btnAddf.Visible = false;
            //    btnAddClosef.Visible = false;
            //    string strRandomMixedId = Request.QueryString["InUpd"].ToString();
            //    string strLenghtofId = strRandomMixedId.Substring(0, 2);
            //    int intLenghtofId = Convert.ToInt16(strLenghtofId);
            //    string strId = strRandomMixedId.Substring(2, intLenghtofId);
            //    UpdateView(strId);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);



            //}

            else
            {
                lblEntry.InnerText= "Add Designation";
                DropDownBind();
                BindCompzitModules();
                //start 0009

                objEntityDesgLeaveType.DesignationId = 0;
                BindLeaveTypes(objEntityDesgLeaveType);
                //stop 0009
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                btnUpdatef.Visible = false;
                btnUpdateClosef.Visible = false;
                btnAddf.Visible = true;
                btnAddClosef.Visible = true;
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
                }
                // clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();  //EMP0025
                // objEntityDsgn.DesignationId = Convert.ToInt32(HiddenDesgId.Value);
                // DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgn);
                //// DataTable dtWelfar = objBusinessLayerDsgnMaster.ReadDsgnWelfare(objEntityDsgn);
                // DataTable dtWelfar = null;
                // if (dtWelfareScvc.Rows.Count > 0)
                // {
                //     //  lblWelfareSrvc.Visible = true;
                //     string strHtm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar);
                //     //Write to divReport
                //     divReport.InnerHtml = strHtm;
                // }
                // else
                // {
                //     lblWelfareSrvc.Visible = false;
                // }
                lblWelfareSrvc.Visible = false;
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }

                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdatef.Visible = false;
            }

          

        }

    }

    #region Enumerations;
    //Enumeration for identifying apllication typeid 
    private enum APPS
    {
        APP_ADMINSTRATION =1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM=3,
        GUARANTEE_MANAGEMENT_SYSTEM=4,
        HUMAN_CAPITAL_MANAGEMENT=5,
        FINANCE_MANAGEMENT_SYSTEM = 6,
        PROCUREMENT_MANAGEMENT_SYSTEM = 7,
    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2
     
    }

    #endregion

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtWelfar)   //EMP0025
    {

        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();
        // class="table table-bordered table-striped"


        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        //strHtml += "<tr class=\"main_table_head\">";


        //for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        //{
        //    if (intColumnHeaderCount == 0)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">Service</th>";
        //    }



        //}

        //strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();


        strHtml += "<tbody>";

        string strId = "";
        if (Request.QueryString["InUpd"] != null)
        {
            string strRandomMixedId = Request.QueryString["InUpd"].ToString();
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
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"trId_" + intRowBodyCount + " \"  >";


            clsBusinessLayerDesignation objBusinessLayerDsgnMstr = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

          
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (HiddenView.Value == "0")
                {

                    if (intColumnBodyCount == 1)
                    {

                        // strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:45%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</td>";
                        strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a class=\"tooltip\"  style=\"cursor:pointer;color: blue;\"  title=\"Go To View\" onclick=\"return preview('" + dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "," + strId +","+dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() +"');\" >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</a></td>";
                        strHtml += "<td id=\"tdDesgId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + strId + "</td>";
                        HiddenWelfareId.Value = dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString();
                        HiddenDesgId.Value = strId;
                    }


                }
                else
                {
                    if (intColumnBodyCount == 1)
                    {

                        // strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:45%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</td>";
                        strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a class=\"tooltip\"  style=\"cursor:pointer;color: blue;\"  title=\"Go To View\"  >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</a></td>";
                        strHtml += "<td id=\"tdDesgId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + strId + "</td>";
                        HiddenWelfareId.Value = dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString();
                        HiddenDesgId.Value = strId;
                    }

                }
              
               
             

            }

            strHtml += "</tr>";

        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\" colspan=\"4\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No Data Available</td>";


        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();


    }
    [WebMethod]
    public static string preview1(string strid, string strdesgid)
    {

        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();
        clsBusinesslayerCorpDept objBusinessLayerCorpDept = new clsBusinesslayerCorpDept();

        Master_gen_Designation_gen_DesignationAdd obj = new Master_gen_Designation_gen_DesignationAdd();
        string Details = obj.ConvertDataTable(strid, strdesgid);


        return Details;


    }
    public string ConvertDataTable(string Id, string strdesgid)
    {
       
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
        clsEntityLayerDesignationWelfareSrvc objEntityWelfareDesg=new clsEntityLayerDesignationWelfareSrvc();
        objEntityDsgn.DesignationId = Convert.ToInt32(strdesgid);
        objEntityWelfareDesg.Dsg_Id = Convert.ToInt32(strdesgid);
       
        objEntityWelfareDesg.Welfare_Id = Convert.ToInt32(Id);
        DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgn);
       DataTable dtWelfarById = objBusinessLayerDsgnMaster.ReadDsgnWelfareById(objEntityWelfareDesg);
       DataTable dtWelfar = new DataTable();
        string   WelfareSubId = "";
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
           objEntityWelfareDesg.WelfSub_Id =WelfareSubId;
           dtWelfar = objBusinessLayerDsgnMaster.ReadDsgnWelfare(objEntityWelfareDesg);
       }


        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"

        string strHtml = "<table id=\"ReportTableWelfare\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        int count = dtWelfarById.Rows.Count;
       
        int wlchecked1 = 0;
        int chkCount=0;

        int flag = 0;
        if(flag==0)
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

                        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
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
                     strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
                 }
                 else
                     strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
             }
             else if (wlchecked1 == 0)
             {
                 strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
             }
             else if (wlchecked1 == 2)
             {
                 strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";

             }
         }
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtWelfarById.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">From</th>";


            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">To</th>";

            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Frequency</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">Limit</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Unit</th>";
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
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange("+count+");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";
                    }
                    else if (wlchecked==0)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
                    }
                    else if (wlchecked == 2)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";
                    
                    }

                }
                else
                {

                    strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                    strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
                    
                }
            }
            else
            {

                strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox \" checked=\"checked\"  style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
            }




            for (int intColumnBodyCount = 0; intColumnBodyCount < dtWelfarById.Columns.Count; intColumnBodyCount++)
            {

                //     strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"IncrmntConfrmCounter();\" /></td>";
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRMPERD"].ToString() + "</td>";


                }

                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_TOPERD"].ToString() + "</td>";
                    //  strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;display:none; \"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdSubtId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdWelfareId_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "</td>";



                }
                else if (intColumnBodyCount == 2)
                {
                    string Frequancy = dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRQNCY"].ToString();
                    if (Frequancy == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >1 Month</td>";
                    }
                    if (Frequancy == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >2 Month</td>";
                    }
                    if (Frequancy == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >1 Year</td>";
                    }
                    if (Frequancy == "3")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >Per Visit</td>";
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

                                strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + strQntity + "\"  maxlength=\"10\" onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";

                            }
                            else
                            {

                                strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                            }

                        }
                        else
                        {


                            strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                            strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                            strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                        }
                    }
                    else
                    {

                        strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"   onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
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

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strunt + "</td>";

                }
            }

            strHtml += "</tr>";

        }
        if (dtWelfarById.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\" colspan=\"6\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No Data Available</td>";


        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();


    }



    //Assign Compzit module against user.
    public void BindCompzitModules()
    {
       // cbxlCompzitModules.Items.Clear();
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
        DataTable dtModuleDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");

        }
        else
        {
            objEntityDsgn.DesignationUserId = Convert.ToInt32(Session["USERID"].ToString());
        }

        if (hiddenPrimaryDecision.Value != "")
        {
            objEntityDsgn.DsgnPrimary = Convert.ToInt32(hiddenPrimaryDecision.Value);
        }

        dtModuleDetails = objBusinessLayerDsgnMaster.DisplayCompzitModuleByUsrId(objEntityDsgn);
  
        if (dtModuleDetails.Rows.Count > 0)
        {
            divCompzitModuleList.Visible = true;
            divCompzitModuleNoList.Visible = false;
        }
        else
        {

            divCompzitModuleList.Visible = false;
            divCompzitModuleNoList.Visible = true;
        }
        //if (dtModuleDetails.Rows.Count > 0)
        //{
        //    divCompzitModuleList.Visible = true;
        //    divCompzitModuleNoList.Visible = false;
        //    cbxlCompzitModules.DataSource = dtModuleDetails;
        //    cbxlCompzitModules.DataTextField = "PRTZAPP_NAME";
        //    cbxlCompzitModules.DataValueField = "PRTZAPP_ID";
        //    cbxlCompzitModules.DataBind();
        //}
        //else
        //{

        //    divCompzitModuleList.Visible = false;
        //    divCompzitModuleNoList.Visible = true;
        //}
    }

    //start 0009
    //Assign Leave Types against user.
    public void BindLeaveTypes(clsEntityLayerDesignation objEntityDesgLeaveType)
    {
        cbxlLeaveTypes.Items.Clear();    
        DataTable dtLeaveTypeDetails = new DataTable();

        dtLeaveTypeDetails = objBusinessLayerDsgnMaster.DisplayLeaveType(objEntityDesgLeaveType);
        if (dtLeaveTypeDetails.Rows.Count > 0)
        {
            divLeaveTypeList.Visible = true;
            divLeaveTypeNoList.Visible = false;
            cbxlLeaveTypes.DataSource = dtLeaveTypeDetails;
            cbxlLeaveTypes.DataTextField = "LEAVETYP_NAME";
            cbxlLeaveTypes.DataValueField = "LEAVETYP_ID";
            cbxlLeaveTypes.DataBind();
        }
        else
        {

            divLeaveTypeList.Visible = false;
            divLeaveTypeNoList.Visible = true;
        }
    }
    //stop 0009


    //Assign Designation Type details from GN_DESG_TYPE table to dropdownlist.
    public void DropDownBind(string strDsgnTypeName = null)
    {
        ddlDesignationType.Items.Clear();
        clsEntityLayerDesignation objEntityDsgn = null;
        objEntityDsgn = new clsEntityLayerDesignation();
        DataTable dtDsgnTypeDetails = new DataTable();
        if (Session["DSGN_CONTROL"] == null)
        {
            Response.Redirect("../../Default.aspx");

        }
        else
        {
            objEntityDsgn.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
        }
        dtDsgnTypeDetails = objBusinessLayerDsgnMaster.ReadDsgnTypeDetails(objEntityDsgn);

        ddlDesignationType.DataSource = dtDsgnTypeDetails;
        ddlDesignationType.DataTextField = "DSGTYP_NAME";
        ddlDesignationType.DataValueField = "DSGTYP_ID";//DSGTYP_ID
        ddlDesignationType.DataBind();
        ddlDesignationType.Items.Insert(0, "--SELECT--");
        if (strDsgnTypeName != null)
        {
            if (ddlDesignationType.Items.FindByText(strDsgnTypeName) != null)
            {
                ddlDesignationType.Items.FindByText(strDsgnTypeName).Selected = true;
            }
        }
    }
    //Fetching the table from business layer and assign them in our fields.
    public void UpdateView(string strDesgnId)
    {

        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

        objEntityDsgn.DesignationId = Convert.ToInt32(strDesgnId);
        DataTable dtDsgnMastr = objBusinessLayerDsgnMaster.ReadDsgnMasterEdit(objEntityDsgn);

        if (dtDsgnMastr.Rows.Count > 0)
        {
            hiddenPrimaryDecision.Value = dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString();
        }

        BindCompzitModules();

        DataTable dtDsgnAppRoles = objBusinessLayerDsgnMaster.ReadDsgnAppRoleByDsgnId(objEntityDsgn);
        for (int intcountApp = 0; intcountApp < dtDsgnAppRoles.Rows.Count; intcountApp++)
        {
            if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
            {

                HiddenFieldAppChecked.Value += dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() + ",";
            }
            //if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
            //{
            //    HiddenFieldAppChecked.Value += dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString();
            //    foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
            //    {
                   
            //        if (itemCheckBoxModules.Value == dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString())
            //        {
                        
            //            itemCheckBoxModules.Selected = true;
            //        }
            //        else
            //        {
            //            // Item is not selected, do something else.
            //        }
            //    }
            //}

        }


        clsEntityLayerDesignation objEntityDsgnWelfareSrvc = new clsEntityLayerDesignation();   //EMP0025
        objEntityDsgnWelfareSrvc.DesignationId = Convert.ToInt32(strDesgnId);

        DataTable dtWelfareScvclist = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgnWelfareSrvc);
        // DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfare(objEntityDsgnWelfareSrvc);
        DataTable dtWelfareScvc = null;
        if (dtWelfareScvclist.Rows.Count > 0)
        {


            string strHtm = ConvertDataTableToHTML(dtWelfareScvclist, dtWelfareScvc);
            //Write to divReport
            divReport.InnerHtml = strHtm;
          //  divWelfareService.Attributes["style"] = "display:block;";
        }
        else
        {
           // divWelfareService.Attributes["style"] = "display:none;";
        }

       



        //Start 0009  
        //To view selected leave types for updation
        clsEntityLayerDesignationLeaveType objEntityDesgLeaveType = new clsEntityLayerDesignationLeaveType();
        objEntityDesgLeaveType.Dsgn_Id = Convert.ToInt32(strDesgnId);
        DataTable dtDsgnLeaveType = objBusinessLayerDsgnMaster.ReadDsgnLeaveTypeByDsgnId(objEntityDesgLeaveType);
        DataTable dtDsgnLeaveTypeEnable = objBusinessLayerDsgnMaster.ReadDsgnLeaveTypeEnableByDsgnId(objEntityDesgLeaveType);
        for (int intcountLeaveType = 0; intcountLeaveType < dtDsgnLeaveType.Rows.Count; intcountLeaveType++)
        {

            if (dtDsgnLeaveType.Rows[intcountLeaveType]["LEAVETYP_ID"].ToString() != "")
            {
                foreach (ListItem itemCheckBoxLeaveType in cbxlLeaveTypes.Items)
                {

                    if (itemCheckBoxLeaveType.Value == dtDsgnLeaveType.Rows[intcountLeaveType]["LEAVETYP_ID"].ToString())
                    {
                        itemCheckBoxLeaveType.Selected = true;

                    }

                    else
                    {
                        // Item is not selected, do something else.
                    }
                }
            }
        }
        for (int intcountLeaveType = 0; intcountLeaveType < dtDsgnLeaveTypeEnable.Rows.Count; intcountLeaveType++)
        {
            if (dtDsgnLeaveTypeEnable.Rows[intcountLeaveType]["LEAVETYP_ID"].ToString() != "")
            {
                foreach (ListItem itemCheckBoxLeaveType in cbxlLeaveTypes.Items)
                {

                    if (itemCheckBoxLeaveType.Value == dtDsgnLeaveTypeEnable.Rows[intcountLeaveType]["LEAVETYP_ID"].ToString())
                    {
                        itemCheckBoxLeaveType.Enabled = false;

                    }

                    else
                    {
                        // Item is not selected, do something else.
                    }
                }
            }
        }




        //Stop 0009
        char charDsgTypCntrl = 'A';
        if (dtDsgnMastr.Rows.Count > 0)
        {
            charDsgTypCntrl = Convert.ToChar(dtDsgnMastr.Rows[0]["DSGN_CONTROL"].ToString());
            Treefill(charDsgTypCntrl);
            txtDesignationName.Text = dtDsgnMastr.Rows[0]["DSGN_NAME"].ToString();
            Int32 intPrimary = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString());

            if (intPrimary == Convert.ToInt32(clsCommonLibrary.DesignationType.Primary))
            {
                DropDownBind();
                ddlDesignationType.Items.Clear();
                ListItem lst = new ListItem("Corporate Administrator", "3");
                ddlDesignationType.Items.Insert(0, lst);

                //  ddlDesignationType.Items.Insert(0, "Corporate Administrator");
                //  ddlDesignationType.Enabled = false;
            }
            else
            {
                DropDownBind(dtDsgnMastr.Rows[0]["DSGTYP_NAME"].ToString());

            }


            int intStatus = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            int type = Convert.ToInt32(dtDsgnMastr.Rows[0]["D_TYPE"]);  //emp25
            if (type == 0)
            {
                RadioStaff.Checked = true;

            }
            else
            {
                RadioLabour.Checked = true;
            }

            string strUsrRoleChildRole = "";
            for (int intcount = 0; intcount < dtDsgnMastr.Rows.Count; intcount++)
            {

                if (dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() != "")
                {
                    if (intcount == 0)
                    {
                        strUsrRoleChildRole = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString();
                        if (dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString() != "")
                        {
                            string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString();

                            string[] strChildren = strchildRoleDefn.Split('-');
                            foreach (string strChild in strChildren)
                            {
                                string strBind = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() + "." + strChild;
                                strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                            }

                        }

                    }
                    else if (intcount > 0)
                    {
                        strUsrRoleChildRole = strUsrRoleChildRole + "," + dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString();

                        if (dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString() != "")
                        {

                            string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString();

                            string[] strChildren = strchildRoleDefn.Split('-');
                            foreach (string strChild in strChildren)
                            {
                                string strBind = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() + "." + strChild;
                                strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                            }


                        }
                    }

                }

            }
            if (strUsrRoleChildRole != "")
            {
                HiddenFieldcbxChecked.Value = strUsrRoleChildRole;
                //foreach (TreeNode node in TreeViewCompzit_AppAdminstration.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_SalesAutomation.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_AutoWorkshopManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_GuaranteeManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                ////TreeViewCompzit_HumanCapitalManagement
                //foreach (TreeNode node in TreeViewCompzit_HumanCapitalManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_FinanceManagementSystem.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_ProcurementManagementSystem.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);//PMS
                //}


            }

        }
    }

    public class clsWBData //EMP0025
    {
        public string DesgId { get; set; }
       
        public string limit { get; set; }
        public string WelfareSubId { get; set; }
        public string chkSts { get; set; }
        public string CheckboxSts { get; set; }
        public string ActLimt { get; set; }

    }
    public void SelectNodesRecursive(TreeNode oParentNode, string strNodeValue)
    {
        string[] strValues = strNodeValue.Split(',');
        foreach (string strSingleValue in strValues)
        {
            if (oParentNode.Value == strSingleValue)
            {
                oParentNode.Checked = true;

            }
        }
        // Start recursion on all subnodes.
        foreach (TreeNode oSubNode in oParentNode.ChildNodes)
        {
            SelectNodesRecursive(oSubNode, strNodeValue);
        }
    }





    public void Treefill(char charDsgTypCntrl)
    {
        int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
        int intUserId = 0;
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
        DataTable dtUserDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");

        }
        else
        {
            objEntityDsgn.DesignationUserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = objEntityDsgn.DesignationUserId;
        }
        dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
        if (dtUserDetails.Rows.Count > 0)
        {
            intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
        }
        Treefill_CRM_App(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_SFA(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_AWMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_GMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_HCM(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_FMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_PMS(charDsgTypCntrl, intUserLimited, intUserId);//PMS

    }
   
    public void Treefill_CRM_App(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        //TreeViewCompzit_AppAdminstration.Nodes.Clear();
        //TreeViewCompzit_SalesAutomation.Nodes.Clear();
        //TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
        //TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
        //TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
        //TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
        //TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();
        treeApp.InnerHtml = "";
        treeSfa.InnerHtml = "";
        treeAwms.InnerHtml = "";
        treeGms.InnerHtml = "";
        treeHcm.InnerHtml = "";
        treeFms.InnerHtml = "";
        treePms.InnerHtml = "";
        PopulateRootLevel(1, 'W', APPS.APP_ADMINSTRATION, charDsgTypCntrl, intUserLimited, intUserId);
    }

    public void Treefill_CRM_SFA(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(2, 'W', APPS.SALES_FORCE_AUTOMATION, charDsgTypCntrl, intUserLimited, intUserId);
    }

    public void Treefill_CRM_AWMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(3, 'W', APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }

    public void Treefill_CRM_GMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(4, 'W', APPS.GUARANTEE_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }
    //TreeViewCompzit_HumanCapitalManagement
    public void Treefill_CRM_HCM(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(5, 'W', APPS.HUMAN_CAPITAL_MANAGEMENT, charDsgTypCntrl, intUserLimited, intUserId);
    }

    public void Treefill_CRM_FMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(6, 'W', APPS.FINANCE_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }

    public void Treefill_CRM_PMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(7, 'W', APPS.PROCUREMENT_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);//PMS
    }

    private void PopulateRootLevel(int intAppId, char chAppType, APPS Appsid, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    {   //Created objects for business layer
        clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
        objEntityDsgn.ParentId = 0;
        objEntityDsgn.AppId = intAppId;
        objEntityDsgn.AppType = chAppType;
        objEntityDsgn.DsgControl = charUsrolCntrl;
        objEntityDsgn.DesignationUserId = intUserId;
        objEntityDsgn.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"]!=null&&Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEntityDsgn.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstrFramewrk(objEntityDsgn);
        }
        else
        {
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstr(objEntityDsgn);
        }

        if (Appsid == APPS.APP_ADMINSTRATION)
        {
            treeApp.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.SALES_FORCE_AUTOMATION)
        {
            treeSfa.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM)
        {
            treeAwms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.GUARANTEE_MANAGEMENT_SYSTEM)
        {
            treeGms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.HUMAN_CAPITAL_MANAGEMENT)
        {
            treeHcm.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.FINANCE_MANAGEMENT_SYSTEM)
        {
            treeFms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.PROCUREMENT_MANAGEMENT_SYSTEM)//PMS
        {
            treePms.InnerHtml=PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }


    }

    private string PopulateSubLevel(int parentid, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    { //Created objects for business layer
        clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();

        clsEntityLayerDesignation objEntityDsgn = null;
        objEntityDsgn = new clsEntityLayerDesignation();
        objEntityDsgn.ParentId = parentid;
        objEntityDsgn.AppId = intAppId;
        objEntityDsgn.AppType = chAppType;
        objEntityDsgn.DsgControl = charUsrolCntrl;
        objEntityDsgn.DesignationUserId = intUserId;
        objEntityDsgn.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"]!=null&&Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEntityDsgn.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstrFramewrk(objEntityDsgn);
        }
        else
        {
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstr(objEntityDsgn);
        }
        return PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 2);
    }



    private string PopulateNodes(DataTable dt, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId, Int32 lev)
    {
        string strHtml = "";
        foreach (DataRow dr in dt.Rows)
        {
            int intUsrRolMstrId, intLimitedEnableAdd = 0, intLimitedEnableModify = 0, intLimitedEnableCancel = 0, intLimitedEnableFind = 0, intLimitedEnableRateUpdation = 0;
            int intLimitedEnableConfirm = 0, intLimitedEnableApprove = 0, intLimitedEnableReOpen = 0, intLimitedEnableReturn = 0, intLimitedEnableWin = 0, intLimitedEnableLoss = 0;
            int intLimitedEnableAllocate = 0, intLimitedEnableAllMails = 0, intLimitedEnableMailAllocate = 0, intLimitedEnableMailForword = 0, intLimitedEnableMailAttach = 0, intLimitedEnableClose = 0, intLimitedEnableSuplier_Guarantee_Permission = 0, intLimitedEnableClient_Guarantee_Permission = 0;
            int intLimitedEnableRenew = 0, intLimitedEnableHRallocation = 0, intLimitedEnableSelfAllocation = 0, intLimitedEditAllocation = 0, intLimitedGMAllocation = 0;
            int intLimitedEnableReissue = 0, intLimitedEnableOnHold = 0, intLimitedEnableBussinessunit = 0, intLimitedAllDivision = 0, intLimitedFmsAudit = 0, intAccountSecific = 0, intBusinessSecific = 0, intLimitedFmsAccount = 0, intDiscount = 0, intFiscalYrEdit = 0, intAdministrator_Privileges = 0, intRecurring = 0, intChequePrint = 0;  //evm-0023-05-04-19
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (lev == 1)
            {
                strHtml += "<ul>";
            }
            else
            {
                strHtml += "<ul class=\"uilist\">";
            }
            strHtml += "<li>";
            strHtml += "<i class=\"button-checkbox\">";
            strHtml += "<button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
            strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "\" type=\"checkbox\" class=\"hidden\">";
            strHtml += "</i>";
            strHtml += "<span>" + dr["USROL_NAME"].ToString() + "</span>";



            //TreeNode tn = new TreeNode();
            //tn.Text = dr["USROL_NAME"].ToString();
            //tn.Value = dr["USROL_ID"].ToString();
            //tn.NavigateUrl = "javascript:void(0)";
            //nodes.Add(tn);



           //Getting child roles based on user role maser id for cheching for the limited user case
            intUsrRolMstrId = Convert.ToInt32(dr["USROL_ID"].ToString());
            DataTable dtChildRolForLimited = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRolForLimited.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolForLimited.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intLimitedEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intLimitedEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intLimitedEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        intLimitedEnableFind = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        intLimitedEnableRateUpdation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intLimitedEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intLimitedEnableApprove= Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intLimitedEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString())
                    {
                        intLimitedEnableReturn = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString())
                    {
                        intLimitedEnableWin= Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString())
                    {
                        intLimitedEnableLoss = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString())
                    {
                        intLimitedEnableAllocate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString())
                    {
                        intLimitedEnableAllMails = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString())
                    {
                        intLimitedEnableMailAllocate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString())
                    {
                        intLimitedEnableMailForword = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString())
                    {
                        intLimitedEnableMailAttach = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intLimitedEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                    {
                        intLimitedEnableSuplier_Guarantee_Permission = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        intLimitedEnableClient_Guarantee_Permission = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intLimitedEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intLimitedEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString())
                    {
                        intLimitedEnableSelfAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString())
                    {
                        intLimitedEditAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString())
                    {
                        intLimitedEnableReissue = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intLimitedGMAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString())
                    {
                        intLimitedEnableOnHold = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        intLimitedEnableBussinessunit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        intLimitedFmsAudit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intLimitedFmsAccount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAccountSecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString())
                    {
                        intFiscalYrEdit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString()) //evm-0023-05-04-19
                    {
                        intAdministrator_Privileges = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString()) 
                    {
                        intRecurring = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString())
                    {
                        intChequePrint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }

              
            }
            //If node has child nodes, then enable on-demand populating
            //   tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"].ToString()) > 0);
            if (dr["USROL_CHLDRL_DEFN"].ToString() != "")
            {
                strHtml += "<ul class=\"uilist\">";
                string strChildDef = dr["USROL_CHLDRL_DEFN"].ToString();
                // Split string on spaces.
                // ... This will separate all the words.
                string[] strChildDefArrWords = strChildDef.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ADD</span>";
                        strHtml += " </li>";
                        //TreeNode tnAdd = new TreeNode();
                        //tnAdd.Text = "ADD";
                        //tnAdd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString();
                        //tnAdd.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnAdd);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MODIFY</span>";
                        strHtml += " </li>";
                        //TreeNode tnModify = new TreeNode();
                        //tnModify.Text = "MODIFY";
                        //tnModify.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString();
                        //tnModify.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnModify);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CANCEL</span>";
                        strHtml += " </li>";
                        //TreeNode tnCncl = new TreeNode();
                        //tnCncl.Text = "CANCEL";
                        //tnCncl.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString();
                        //tnCncl.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnCncl);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableFind== Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>FIND</span>";
                        strHtml += " </li>";
                        //TreeNode tnFind = new TreeNode();
                        //tnFind.Text = "FIND";
                        //tnFind.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString();
                        //tnFind.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnFind);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRateUpdation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RATE UPDATION</span>";
                        strHtml += " </li>";
                        //TreeNode tnRateUpd = new TreeNode();
                        //tnRateUpd.Text = "RATE UPDATION";
                        //tnRateUpd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString();
                        //tnRateUpd.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnRateUpd);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        //TreeNode tnConfm = new TreeNode();
                        //tnConfm.Text = "CONFIRM";
                        //tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString();
                        //tnConfm.NavigateUrl = "javascript:void(0)";
                        //tn.ChildNodes.Add(tnConfm);
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CONFIRM</span>";
                        strHtml += " </li>";
                    }
               
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableApprove == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>DM ALLOCATION</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RE-OPEN</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReturn == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RETURN</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableWin == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>WIN</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableLoss == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>LOSS</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALLOCATE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllMails == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>VIEW ALL MAILS</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MAIL ALLOCATE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailForword == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MAIL FORWARD</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAttach == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>LEAD ATTACH</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClose == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CLOSE</span>";
                        strHtml += " </li>";
                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSuplier_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>SUPPLIER_GUARANTEE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClient_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CLIENT_GUARANTEE</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RENEW</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableHRallocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>HR ALLOCATION</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSelfAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>SELF ALLOCATION</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEditAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>EDIT ALLOCATION</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReissue == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>REISSUE</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedGMAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>GM ALLOCATION</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableOnHold == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ON HOLD</span>";
                        strHtml += " </li>";

                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableBussinessunit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                       strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALL BUSINESS UNIT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedAllDivision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALL DIVISION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAccount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ACCOUNT</span>";
                        strHtml += " </li>";
                    
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>AUDIT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAccountSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ACCOUNT SPECIFIC</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intBusinessSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>BUSINESS SPECIFIC</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intDiscount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>DISCOUNT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intFiscalYrEdit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>FINANCIAL YEAR EDIT</span>";
                        strHtml += " </li>";
                    }

                        //evm-0023-05-04-19
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAdministrator_Privileges == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ADMINISTRATOR PRIVILEGES</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intRecurring == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RECURRING</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intChequePrint == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CHEQUE PRINT</span>";
                        strHtml += " </li>";
                    }
                }
                strHtml += "</ul>";
                // PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), tn);

            }

            if (Convert.ToInt32(dr["childnodecount"].ToString()) > 0)
            {
                PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), intAppId, chAppType, charUsrolCntrl,intUserLimited, intUserId);

            }
            strHtml += "</li>";
            strHtml += "</ul>";
        }
        return strHtml;

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
       
        Button clickedButton = sender as Button;
        clsEntityLayerDesignation objEntityDsg = new clsEntityLayerDesignation();
       
        List<clsEntityLayerDesignationAppRole> objlisDsgnAppRol = new List<clsEntityLayerDesignationAppRole>();
        string[] app = HiddenFieldAppChecked.Value.Split(',');
        foreach (string itemCheckBoxModules in app)
        {

            if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
            {
                clsEntityLayerDesignationAppRole objDsgnAppRol = new clsEntityLayerDesignationAppRole();

                // If the item is selected.
             
                if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                {
                    intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active); 
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                {
                    intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active); 
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                {
                    intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active); 
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                {
                    intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                {
                    intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                {
                    intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))//PMS
                {
                    intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }


                objDsgnAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules);
                objlisDsgnAppRol.Add(objDsgnAppRol);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }

        //start 0009
        //add data to designation leave type table
        List<clsEntityLayerDesignationLeaveType> objlistLeaveType = new List<clsEntityLayerDesignationLeaveType>();
        foreach (ListItem itemCheckBoxLeaveType in cbxlLeaveTypes.Items)
        {

            if (itemCheckBoxLeaveType.Selected)
            {

                clsEntityLayerDesignationLeaveType objDsgn = new clsEntityLayerDesignationLeaveType();
                objDsgn.Leave_Type_Id = Convert.ToInt32(itemCheckBoxLeaveType.Value);
                objlistLeaveType.Add(objDsgn);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }

        //Stop 0009

        List<clsEntityLayerDesignationRole> objlisDsgnRol = new List<clsEntityLayerDesignationRole>();

        clsEntityLayerDesignation objEntityDsgn = null;
        objEntityDsgn = new clsEntityLayerDesignation();
        objEntityDsgn.DesignationName = txtDesignationName.Text.ToUpper().Trim();
        if (Session["ORGID"] != null)
        {

            objEntityDsgn.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        string strNameCount = objBusinessLayerDsgnMaster.CheckDupDesignationNameIns(objEntityDsgn);
        if (strNameCount == "0")
        {
            if (Session["USERID"] != null)
            {
                objEntityDsgn.DesignationUserId = Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityDsgn.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Designation);
            DataTable dtNextId = objBusinessLayerDsgnMaster.ReadNextId(objEntityDsgn);
            objEntityDsgn.DesignationId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
            HiddenDesgId.Value = objEntityDsgn.DesignationId.ToString();
            objEntityDsgn.DesignationTypeId = Convert.ToInt32(ddlDesignationType.SelectedItem.Value);

            if (RadioStaff.Checked)
            {
                objEntityDsgn.Type = 0;
            }
            else
            {
                objEntityDsgn.Type = 1;
            }
           


            objEntityDsgn.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.NonPrimary);
            objEntityDsgn.DsgControl = objBusinessLayerDsgnMaster.ReadDsgnControl(objEntityDsgn);
            if (cbxStatus.Checked)
            {
                objEntityDsgn.DesignationStatus = 1;
            }
            else
            {
                objEntityDsgn.DesignationStatus = 0;
            }



            if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                //TreeNodeCollection objNodeCollection_COMPZIT_AppAdmin = TreeViewCompzit_AppAdminstration.CheckedNodes;
                string[] appS = HiddenFieldApp.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_AppAdmin = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_AppAdmin = new List<clsEntityLayerDesignationRole>();
                     foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_AppAdmin.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_AppAdmin.Add(objEntityDsgnRole);
                        }


                    }
                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolAppAdministration = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolAppAdministration = Merge(objlisDsgnRolMainDtls_AppAdmin, objlisDsgnRolChildrenDtls_AppAdmin);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolAppAdministration)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }

            }
            if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldSfa.Value.Split(',');
                if (appS.Length > 0)
                {



                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_SFA = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_SFA = new List<clsEntityLayerDesignationRole>();
                     foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_SFA.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_SFA.Add(objEntityDsgnRole);
                        }
                    }

                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolSFA = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolSFA = Merge(objlisDsgnRolMainDtls_SFA, objlisDsgnRolChildrenDtls_SFA);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolSFA)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldAwms.Value.Split(',');
                if (appS.Length > 0)
                {

                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_WMS = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_WMS = new List<clsEntityLayerDesignationRole>();
                    foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_WMS.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_WMS.Add(objEntityDsgnRole);
                        }
                    }
                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_WMS, objlisDsgnRolChildrenDtls_WMS);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldGms.Value.Split(',');
                if (appS.Length > 0)
                {



                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerDesignationRole>();
                   foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_GMS.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_GMS.Add(objEntityDsgnRole);
                        }
                    }
                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldHcm.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerDesignationRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerDesignationRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerDesignationRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
                            if ((strchild.Length - 1) > 0)
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objEntityDsgnRole.strChildRolId = strchild[1];
                                objlisDsgnRolChildrenDtls_HCM.Add(objEntityDsgnRole);
                            }
                            else
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objlisDsgnRolMainDtls_HCM.Add(objEntityDsgnRole);
                            }

                        }
                    }

                    List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldFms.Value.Split(',');
                if (appS.Length > 0)
                {



                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerDesignationRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerDesignationRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerDesignationRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
                            if ((strchild.Length - 1) > 0)
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objEntityDsgnRole.strChildRolId = strchild[1];
                                objlisDsgnRolChildrenDtls_FMS.Add(objEntityDsgnRole);
                            }
                            else
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objlisDsgnRolMainDtls_FMS.Add(objEntityDsgnRole);
                            }

                        }
                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))//PMS
            {
                string[] appS = HiddenFieldPms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerDesignationRole>();
                    List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerDesignationRole>();
                   foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_PMS.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_PMS.Add(objEntityDsgnRole);
                        }
                    }
                    }


                    List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }






            //DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgn);    //EMP0025
            //List<clsEntityLayerDesignationWelfareSrvc> objListDesgWelfare = new List<clsEntityLayerDesignationWelfareSrvc>();


            //string jsonData = Hiddenchecklist.Value;
            //string c = jsonData.Replace("\"{", "\\{");
            //string d = c.Replace("\\n", "\r\n");
            //string g = d.Replace("\\", "");
            //string h = g.Replace("}\"]", "}]");
            //string i = h.Replace("}\",", "},");
            //List<clsWBData> objWBDataList = new List<clsWBData>();
            //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
            //foreach (clsWBData objclsWBData in objWBDataList)
            //{
            //    clsEntityLayerDesignationWelfareSrvc objDsgn = new clsEntityLayerDesignationWelfareSrvc();

            //    objDsgn.Dsg_Id = Convert.ToInt32(objclsWBData.DesgId);
            //    objDsgn.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
            //    objDsgn.Qty = Convert.ToDecimal(objclsWBData.limit);
            //    objListDesgWelfare.Add(objDsgn);
            //}



            objBusinessLayerDsgnMaster.InsertDesignationDetail(objEntityDsgn, objlisDsgnRol, objlisDsgnAppRol, objlistLeaveType);

            if (clickedButton.ID == "btnAdd")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strRandom = objCommon.Random_Number();
                int ID = Convert.ToInt32( HiddenDesgId.Value);

                string desgId = ID.ToString();
                int intIdLength = desgId.Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + desgId + strRandom;

                Response.Redirect("gen_Designation.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_DesignationList.aspx?InsUpd=Ins");
            }

           else if (clickedButton.ID == "btnAddf")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strRandom = objCommon.Random_Number();
                int ID = Convert.ToInt32(HiddenDesgId.Value);

                string desgId = ID.ToString();
                int intIdLength = desgId.Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + desgId + strRandom;

                Response.Redirect("gen_Designation.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClosef")
            {
                Response.Redirect("gen_DesignationList.aspx?InsUpd=Ins");
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtDesignationName.Focus();
        }
    }


    private List<clsEntityLayerDesignationRole> Merge(List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls, List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls)
    {

        List<clsEntityLayerDesignationRole> objlisDsgnRol = null;
        objlisDsgnRol = new List<clsEntityLayerDesignationRole>();
        foreach (clsEntityLayerDesignationRole objDsgnRolMainDtls in objlisDsgnRolMainDtls)
        {
            string strchild = "";
            foreach (clsEntityLayerDesignationRole objDsgnRolChildrenDtls in objlisDsgnRolChildrenDtls)
            {

                if (objDsgnRolMainDtls.UsrRolId == objDsgnRolChildrenDtls.UsrRolId)
                {
                    if (strchild != "")
                    {
                        strchild = strchild + "-" + objDsgnRolChildrenDtls.strChildRolId;
                    }
                    else
                    {

                        strchild = objDsgnRolChildrenDtls.strChildRolId;
                    }
                }
            }
            objDsgnRolMainDtls.strChildRolId = strchild;

        }
        return objlisDsgnRolMainDtls;

    }
  
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
        Button clickedButton = sender as Button;


        //start 0009
        //add data to designation leave type table
        List<clsEntityLayerDesignationLeaveType> objlistLeaveType = new List<clsEntityLayerDesignationLeaveType>();

        foreach (ListItem itemCheckBoxLeaveType in cbxlLeaveTypes.Items)
        {

            if (itemCheckBoxLeaveType.Selected)
            {

                clsEntityLayerDesignationLeaveType objDsgn = new clsEntityLayerDesignationLeaveType();
                objDsgn.Leave_Type_Id = Convert.ToInt32(itemCheckBoxLeaveType.Value);
                objlistLeaveType.Add(objDsgn);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }

        //Stop

        List<clsEntityLayerDesignationAppRole> objlisDsgnAppRol = new List<clsEntityLayerDesignationAppRole>();
        string[] app = HiddenFieldAppChecked.Value.Split(',');
        foreach (string itemCheckBoxModules in app)
        {

            if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
            {
                clsEntityLayerDesignationAppRole objDsgnAppRol = new clsEntityLayerDesignationAppRole();

                // If the item is selected.

                if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                {
                    intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                {
                    intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                {
                    intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                {
                    intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                {
                    intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                {
                    intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))//PMS
                {
                    intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                

                objDsgnAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules);
                objlisDsgnAppRol.Add(objDsgnAppRol);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }


        if (Request.QueryString["Id"] != null)
        {
            clsEntityLayerDesignation objEntityDsgn = null;
            objEntityDsgn = new clsEntityLayerDesignation();
            objEntityDsgn.DesignationName = txtDesignationName.Text.ToUpper().Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityDsgn.DesignationId = Convert.ToInt32(strId);
            if (Session["ORGID"] != null)
            {

                objEntityDsgn.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            string strNameCount = objBusinessLayerDsgnMaster.CheckDupDesignationNameUpd(objEntityDsgn);
            if (strNameCount == "0")
            {
                objEntityDsgn.DesignationTypeId = Convert.ToInt32(ddlDesignationType.SelectedItem.Value);

                if (Session["USERID"] != null)
                {
                    objEntityDsgn.DesignationUserId = Convert.ToInt32(Session["USERID"].ToString());

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["DSGN_CONTROL"] != null)
                {

                    if (Session["DSGN_CONTROL"].ToString() == "C" || Session["DSGN_CONTROL"].ToString() == "c")
                    {
                        if (Session["CORPOFFICEID"] != null)
                        {

                            objEntityDsgn.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"]);
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        
                        }
                    }
              }
                else if (Session["DSGN_CONTROL"] == null)
                 {
                     Response.Redirect("~/Default.aspx");
                 }

                objEntityDsgn.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.NonPrimary);
                if (hiddenPrimaryDecision.Value == "1")
                {
                    objEntityDsgn.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.Primary);

                }
                else if (hiddenPrimaryDecision.Value == "0")
                {
                    objEntityDsgn.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.NonPrimary);
                }
                objEntityDsgn.DsgControl = objBusinessLayerDsgnMaster.ReadDsgnControl(objEntityDsgn);
                if (CbxAllocateAll.Checked)
                {
                    objEntityDsgn.AllocateAll = 1;
                }
                else
                {
                    objEntityDsgn.AllocateAll = 0;
                }
                //Start 0009
                if (cbxAllocateAllUsr.Checked)
                {
                    objEntityDsgn.AllocateAllUsr = 1;
                }
                else
                {
                    objEntityDsgn.AllocateAllUsr = 0;
                }
                //Stop 0009


                if (RadioStaff.Checked)   //emp25
                {
                    objEntityDsgn.Type = 0;
                }
                else
                {
                    objEntityDsgn.Type = 1;
                }


              
                if (cbxStatus.Checked)
                {
                    objEntityDsgn.DesignationStatus = 1;
                }
                else
                {
                    objEntityDsgn.DesignationStatus = 0;
                }


                List<clsEntityLayerDesignationRole> objlisDsgnRol = new List<clsEntityLayerDesignationRole>();


                if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    string[] appS = HiddenFieldApp.Value.Split(',');
                    if (appS.Length > 0)
                    {


                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_POnline = null;
                        objlisDsgnRolMainDtls_POnline = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_POnline = null;
                        objlisDsgnRolChildrenDtls_POnline = new List<clsEntityLayerDesignationRole>();
                         foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_POnline.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_POnline.Add(objEntityDsgnRole);
                        }
                    }
                        }


                        List<clsEntityLayerDesignationRole> objlisDsgnRolPOnl = null;
                        objlisDsgnRolPOnl = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolPOnl = Merge(objlisDsgnRolMainDtls_POnline, objlisDsgnRolChildrenDtls_POnline);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolPOnl)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }

                }
                if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    string[] appS = HiddenFieldSfa.Value.Split(',');
                    if (appS.Length > 0)
                    {


                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_Finance = null;
                        objlisDsgnRolMainDtls_Finance = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_Finance = null;
                        objlisDsgnRolChildrenDtls_Finance = new List<clsEntityLayerDesignationRole>();
                        foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_Finance.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_Finance.Add(objEntityDsgnRole);
                        }
                    }
                        }


                        List<clsEntityLayerDesignationRole> objlisDsgnRolFin = null;
                        objlisDsgnRolFin = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolFin = Merge(objlisDsgnRolMainDtls_Finance, objlisDsgnRolChildrenDtls_Finance);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolFin)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }

                if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {


                    string[] appS = HiddenFieldAwms.Value.Split(',');
                    if (appS.Length > 0)
                    {


                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_AWMS = null;
                        objlisDsgnRolMainDtls_AWMS = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_AWMS = null;
                        objlisDsgnRolChildrenDtls_AWMS = new List<clsEntityLayerDesignationRole>();
                        foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_AWMS.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_AWMS.Add(objEntityDsgnRole);
                        }
                    }
                        }


                        List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = null;
                        objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_AWMS, objlisDsgnRolChildrenDtls_AWMS);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }
                if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    string[] appS = HiddenFieldGms.Value.Split(',');
                    if (appS.Length > 0)
                    {


                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_GMS = null;
                        objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_GMS = null;
                        objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerDesignationRole>();
                       foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                        clsEntityLayerDesignationRole objEntityDsgnRole = null;
                        objEntityDsgnRole = new clsEntityLayerDesignationRole();

                        string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objEntityDsgnRole.strChildRolId = strchild[1];
                            objlisDsgnRolChildrenDtls_GMS.Add(objEntityDsgnRole);
                        }
                        else
                        {
                            objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                            objlisDsgnRolMainDtls_GMS.Add(objEntityDsgnRole);
                        }
                    }
                        }


                        List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = null;
                        objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }
                if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    string[] appS = HiddenFieldHcm.Value.Split(',');
                    if (appS.Length > 0)
                    {



                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_HCM = null;
                        objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_HCM = null;
                        objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerDesignationRole>();
                        foreach (string itemCheckBoxModules in appS)
                        {
                            if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                            {
                                clsEntityLayerDesignationRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerDesignationRole();

                                string[] strchild = itemCheckBoxModules.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_HCM.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_HCM.Add(objEntityDsgnRole);
                                }

                            }

                        }
                        List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = null;
                        objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }
                if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    string[] appS = HiddenFieldFms.Value.Split(',');
                    if (appS.Length > 0)
                    {


                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_FMS = null;
                        objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_FMS = null;
                        objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerDesignationRole>();
                         foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                            clsEntityLayerDesignationRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerDesignationRole();
                         string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objEntityDsgnRole.strChildRolId = strchild[1];
                                objlisDsgnRolChildrenDtls_FMS.Add(objEntityDsgnRole);
                            }
                            else
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objlisDsgnRolMainDtls_FMS.Add(objEntityDsgnRole);
                            }

                        }
                         }


                        List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = null;
                        objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }
}
                    
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }
                if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))//PMS
                {

                      string[] appS = HiddenFieldPms.Value.Split(',');
            if (appS.Length > 0)
            {



                        List<clsEntityLayerDesignationRole> objlisDsgnRolMainDtls_PMS = null;
                        objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerDesignationRole>();
                        List<clsEntityLayerDesignationRole> objlisDsgnRolChildrenDtls_PMS = null;
                        objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerDesignationRole>();
                         foreach (string itemCheckBoxModules in appS)
                {
                    if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                    {
                            clsEntityLayerDesignationRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerDesignationRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
                        if ((strchild.Length - 1) > 0)
                        {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objEntityDsgnRole.strChildRolId = strchild[1];
                                objlisDsgnRolChildrenDtls_PMS.Add(objEntityDsgnRole);
                            }
                            else
                            {
                                objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                objlisDsgnRolMainDtls_PMS.Add(objEntityDsgnRole);
                            }

                        }
                         }

                        List<clsEntityLayerDesignationRole> objlisDsgnRolWMS = null;
                        objlisDsgnRolWMS = new List<clsEntityLayerDesignationRole>();
                        objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                        foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolWMS)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    }
                    else
                    {
                        // lblSelectedNodes.Text = "Select Node(s).";
                    }
                }



                //DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgn);    //EMP0025
                //List<clsEntityLayerDesignationWelfareSrvc> objListDesgWelfare = new List<clsEntityLayerDesignationWelfareSrvc>();


                //string jsonData = Hiddenchecklist.Value;
                //string c = jsonData.Replace("\"{", "\\{");
                //string d = c.Replace("\\n", "\r\n");
                //string g = d.Replace("\\", "");
                //string h = g.Replace("}\"]", "}]");
                //string i = h.Replace("}\",", "},");
                //List<clsWBData> objWBDataList = new List<clsWBData>();
                //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
                //foreach (clsWBData objclsWBData in objWBDataList)
                //{
                //    clsEntityLayerDesignationWelfareSrvc objDsgn = new clsEntityLayerDesignationWelfareSrvc();

                //    objDsgn.Dsg_Id = Convert.ToInt32(objclsWBData.DesgId);
                //    objDsgn.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
                //    objDsgn.Qty = Convert.ToDecimal(objclsWBData.limit);
                //    objListDesgWelfare.Add(objDsgn);
                //}

                objBusinessLayerDsgnMaster.UpdateDesignationDetail(objEntityDsgn, objlisDsgnRol, objlisDsgnAppRol, objlistLeaveType);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Designation.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_DesignationList.aspx?InsUpd=Upd");
                }
               else if (clickedButton.ID == "btnUpdatef")
                {
                    Response.Redirect("gen_Designation.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClosef")
                {
                    Response.Redirect("gen_DesignationList.aspx?InsUpd=Upd");
                }   
               

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtDesignationName.Focus();
            }
        }
    }




    protected void ddlDesignationType_SelectedIndexChanged(object sender, EventArgs e)
    {


        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
     
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();       
        
        char charDsgTypCntrl = 'A';
        if (ddlDesignationType.SelectedItem.Value != "--SELECT--")
        {
            objEntityDsgn.DesignationTypeId = Convert.ToInt32(ddlDesignationType.SelectedItem.Value);
            charDsgTypCntrl = Convert.ToChar(objBusinessLayerDsgnMaster.ReadDsgnControl(objEntityDsgn));
            Treefill(charDsgTypCntrl);
        }
        else
        {
            BindCompzitModules();
            treeApp.InnerHtml = "";
            treeSfa.InnerHtml = "";
            treeAwms.InnerHtml = "";
            treeGms.InnerHtml = "";
            treeHcm.InnerHtml = "";
            treeFms.InnerHtml = "";
            treePms.InnerHtml = "";
        }
      //   ddlDesignationType.Focus(); //evm-0023
       // UpdateView(ddlDesignationType.SelectedItem.Value);
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
        clsEntityLayerDesignationWelfareSrvc objEntityWelfareDesg = new clsEntityLayerDesignationWelfareSrvc();
        if (Session["ORGID"] != null)
        {

            objEntityDsgn.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["DSGN_CONTROL"] != null)
        {

            if (Session["DSGN_CONTROL"].ToString() == "C" || Session["DSGN_CONTROL"].ToString() == "c")
            {
                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityDsgn.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");

                }
            }
        }
        else if (Session["DSGN_CONTROL"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityWelfareDesg.Dsg_Id = Convert.ToInt32(HiddenDesgId.Value);

        objEntityWelfareDesg.Welfare_Id = Convert.ToInt32(HiddenWelfareId.Value);
        objEntityDsgn.DesignationId = Convert.ToInt32(HiddenDesgId.Value);
        DataTable dtWelfareScvclist = objBusinessLayerDsgnMaster.ReadDsgnWelfareSrvc(objEntityDsgn);
        // DataTable dtWelfareScvc = objBusinessLayerDsgnMaster.ReadDsgnWelfare(objEntityDsgnWelfareSrvc);
        DataTable dtWelfareScvc = null;
        bool existsCus = dtWelfareScvclist.Select().ToList().Exists(row => row["WLFRSRVC_ID"].ToString().ToUpper() == HiddenWelfareId.Value);
        if (existsCus == true)
        {



            List<clsEntityLayerDesignationWelfareSrvc> objListDesgWelfare = new List<clsEntityLayerDesignationWelfareSrvc>();


            string jsonData = Hiddenchecklist.Value;
            if (jsonData == "[]")
            {
                objEntityWelfareDesg.Dsg_Id = Convert.ToInt32(HiddenDesgId.Value);
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
                    clsEntityLayerDesignationWelfareSrvc objDesg = new clsEntityLayerDesignationWelfareSrvc();

                    objDesg.Dsg_Id = Convert.ToInt32(objclsWBData.DesgId);
                    objEntityDsgn.DesignationId = objDesg.Dsg_Id;

                    objDesg.Qty = Convert.ToDecimal(objclsWBData.limit);
                    objDesg.WelfrSub_Id = Convert.ToInt32(objclsWBData.WelfareSubId);
                    objDesg.chkSts = Convert.ToInt32(objclsWBData.chkSts);
                    objDesg.checkboxsts = Convert.ToInt32(objclsWBData.CheckboxSts);
                    objDesg.ActQty = Convert.ToDecimal(objclsWBData.ActLimt);
                    objListDesgWelfare.Add(objDesg);
                }
            }
            objBusinessLayerDsgnMaster.Insert_DesgWelfare(objListDesgWelfare, objEntityWelfareDesg);
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", "SuccessMessage();", true);
        }
        else
        {
            if (dtWelfareScvclist.Rows.Count > 0)
            {

                string strHtmmm = ConvertDataTableToHTML(dtWelfareScvclist, dtWelfareScvc);
                //Write to divReport
                divReport.InnerHtml = strHtmmm;
                divWelfareService.Attributes["style"] = "display:block;";
            }
            else
            {
                divWelfareService.Attributes["style"] = "display:none;";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ValueNotFoundMessage", "ValueNotFoundMessage();", true);
        }
    }
  
























}