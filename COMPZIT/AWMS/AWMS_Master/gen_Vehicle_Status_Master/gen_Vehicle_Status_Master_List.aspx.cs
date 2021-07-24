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
using System.Xml;
using Newtonsoft.Json;
using System.Text;
// CREATED BY:EVM-0008
// CREATED DATE:02/12/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class AWMS_AWMS_Master_gen_Vehicle_Status_Master_gen_Vehicle_Status_Master_List : System.Web.UI.Page
{
    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
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
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Master);

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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
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
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }



                //Creating objects for business layer

                clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
                clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityVehStsMstr.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityVehStsMstr.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }


                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityVehStsMstr.VehId = Convert.ToInt32(strId);
                    objEntityVehStsMstr.User_Id = intUserId;

                    objEntityVehStsMstr.Date = System.DateTime.Now;

                    DataTable dtLeaveTypDetail = new DataTable();
                    dtLeaveTypDetail = objBusnssVehStsMstr.ReadVStatusById(objEntityVehStsMstr);
                    string strName = "", strNameCount = "0";
                    if (dtLeaveTypDetail.Rows.Count > 0)
                    {

                        strName = dtLeaveTypDetail.Rows[0]["VHCLSTS_NAME"].ToString();
                    }

                    if (strName != "")
                    {
                        objEntityVehStsMstr.ClassName = strName;
                    }
                    strNameCount = objBusnssVehStsMstr.CheckVehStsName(objEntityVehStsMstr);


                    if (strNameCount == "0")
                    {

                        objBusnssVehStsMstr.ReCallVStatus(objEntityVehStsMstr);

                        Response.Redirect("gen_Vehicle_Status_Master_List.aspx?InsUpd=Recl");
                    }
                    else
                    {


                        if (strNameCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCardName", "DuplicationCardName();", true);

                        }
                    }


                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    objEntityVehStsMstr.Status_id = 1;
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        objEntityVehStsMstr.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(objEntityVehStsMstr.Status_id.ToString()).Selected = true;


                    }

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityVehStsMstr.VehId = Convert.ToInt32(strId);
                    objEntityVehStsMstr.User_Id = intUserId;

                    objEntityVehStsMstr.Date = System.DateTime.Now;
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityVehStsMstr.CancelReason = objCommon.CancelReason();


                            objBusnssVehStsMstr.CancelVStatusMstr(objEntityVehStsMstr);

                            Response.Redirect("gen_Vehicle_Status_Master_List.aspx?InsUpd=Cncl&Srch=" + objEntityVehStsMstr.Status_id + "");


                        }
                        else
                        {
                            DataTable dtLeaveType = new DataTable();
                            objEntityVehStsMstr.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                            dtLeaveType = objBusnssVehStsMstr.ReadVStatusMstrList(objEntityVehStsMstr);
                            string strHtm = ConvertDataTableToHTML(dtLeaveType, intEnableModify, intEnableCancel, intEnableRecall);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;

                        }

                    }



                }
                else
                {
                    //to view
                    DataTable dtLeavTyp = new DataTable();
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        objEntityVehStsMstr.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(objEntityVehStsMstr.Status_id.ToString()).Selected = true;


                    }
                    objEntityVehStsMstr.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    dtLeavTyp = objBusnssVehStsMstr.ReadVStatusMstrList(objEntityVehStsMstr);
                    string strHtm = ConvertDataTableToHTML(dtLeavTyp, intEnableModify, intEnableCancel, intEnableRecall);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

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
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                        }
                    }
                }

            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {
        int intddlStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        //for assigning column for reopen

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"thT\" style=\"width:65%;text-align: left; word-wrap:break-word;\">" + "VEHICLE STATUS NAME" + "</th>";

            }
            if (intColumnHeaderCount == 2)
            {

                strHtml += "<th class=\"thT\" style=\"width:13%; word-wrap:break-word; text-align: center;\">" + "STATUS TYPE" + "</th>";

            }
            else if (intColumnHeaderCount == 3)
            {

                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";

            }

            



        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (cbxCnclStatus.Checked == false)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> VIEW</th>";
            }
        }
        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> DELETE</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL </th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            //FOR CANCELED COLUMN IDENTIFICATION ICON
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
               
                if (intColumnBodyCount == 1)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:65%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
               
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                          " href=\"gen_Vehicle_Status_Master.aspx?Id=" + Id + "\">" + "<img title=\"Edit\" style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                     " href=\"gen_Vehicle_Status_Master.aspx?ViewId=" + Id + "\">" + "<img title=\"View\" style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                             " href=\"gen_Vehicle_Status_Master_List.aspx?Id=" + Id + "&Srch=" + intddlStatus + "\">" + "<img title=\"Delete\" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                    + "<img title=\"Delete\" style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                }
            }
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    if (intCnclUsrId == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReCallAlert(this.href);' " +
                             " href=\"gen_Vehicle_Status_Master_List.aspx?ReId=" + Id + "&Srch=" + intddlStatus + "\">" + "<img title=\"Recall\" src='/Images/Icons/recover.png' /> " + "</a> </td>";

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
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {


        //Creating objects for business layer

        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityVehStsMstr.VehId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityVehStsMstr.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            int status = Convert.ToInt32(ddlStatus.SelectedItem.Value);

            objEntityVehStsMstr.Date = System.DateTime.Now;

            objEntityVehStsMstr.CancelReason = txtCnclReason.Text.Trim();


            objBusnssVehStsMstr.CancelVStatusMstr(objEntityVehStsMstr);


            Response.Redirect("gen_Vehicle_Status_Master_List.aspx?InsUpd=Cncl&Srch=" + status + "");



        }
    }



    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusniessLayerVehicleStatusMaster objBusnssVehStsMstr = new clsBusniessLayerVehicleStatusMaster();
        clsEntityVehicleStatusMaster objEntityVehStsMstr = new clsEntityVehicleStatusMaster();

        objEntityVehStsMstr.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
            objEntityVehStsMstr.CancelStatus = 1;
        else
            objEntityVehStsMstr.CancelStatus = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehStsMstr.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehStsMstr.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtLeave = new DataTable();

        dtLeave = objBusnssVehStsMstr.ReadVStatusMstrList(objEntityVehStsMstr);


        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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


        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
            hiddenRoleRecall.Value = "1";
        }
        else
        {
            intEnableRecall = 0;
            hiddenRoleRecall.Value = "0";
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Status_Master);
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

        string strHtm = ConvertDataTableToHTML(dtLeave, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
}