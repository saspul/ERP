using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Text;
using System.Xml;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Notice_Period_hcm_Notice_Period_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //Creating objects for business layer
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
           
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenFieldUserId.Value = Session["USERID"].ToString();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notice_Period);
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
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }



                if (Session["USERID"] != null)
                {
                    objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                objEntityNoticePeriod.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                if (cbxCnclStatus.Checked == true)
                {
                    objEntityNoticePeriod.CancelStatus = 1;
                }
                else
                {
                    objEntityNoticePeriod.CancelStatus = 0;
                }

                DataTable dt = objBusinessNoticePeriod.ReadNoticePrdList(objEntityNoticePeriod);

                string strHtm = ConvertDataTableToHTML(dt, intEnableModify, intEnableCancel, intEnableRecall);
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
                        else if (strInsUpd == "StsCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                        }
                       
                    }
                    if (Request.QueryString["Srch"] != null)
                    {
                        ddlStatus.ClearSelection();
                        ddlStatus.Items.FindByValue(Request.QueryString["Srch"].ToString()).Selected = true;

                    }



            }
        }
    }



    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {

        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtChk = objBusinessNoticePeriod.CheckExtProcess(objEntityNoticePeriod);


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

      



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
           
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:68%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NOTICE PERIOD (DAYS)</th>";
            }

           


        }
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (cbxCnclStatus.Checked == true)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
        else
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";

            }


            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            }
          
        }
       

       


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string strShow = "true";
            foreach (DataRow dr in dtChk.Rows)
            {
                if (dr["DSGN_ID"].ToString() == dt.Rows[intRowBodyCount]["DSGN_ID"].ToString())
                {
                    strShow = "false";
                }
            }

            string strStatusMode = "";
            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
               
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:68%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            strStatusMode = dt.Rows[intRowBodyCount][3].ToString();
           
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) && cbxCnclStatus.Checked == false)              
                {
                    if (strStatusMode == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strStatusMode == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" >" +
                            "<img  style=\"\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" >" +
                          "<img  style=\"\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }


                if (cbxCnclStatus.Checked == true)
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                          " href=\"hcm_Notice_Period.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }
                else
                {
                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {



                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                              " href=\"hcm_Notice_Period.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                    }



                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {

                        if (strShow == "true")
                        {
                            strHtml += "<td class=\"tdT\" class=\"tooltip\" title=\"Delete\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                                "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png'  onclick='return CancelAlert(" + strId + ");' /></td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" class=\"tooltip\" title=\"Delete\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                                "<img style=\"opacity: 0.2;cursor: initial; \"  src='/Images/Icons/delete.png' onclick='return CancelNotAlert();' /></td>";
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
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

        if (hiddenRsnid.Value != "")
        {
            objEntityNoticePeriod.NoticePrdId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityNoticePeriod.UserDate = System.DateTime.Now;

            objEntityNoticePeriod.CnclReason = txtCnclReason.Text.Trim();
            objBusinessNoticePeriod.CancelNoticePrdDtls(objEntityNoticePeriod);

            Response.Redirect("hcm_Notice_Period_List.aspx?InsUpd=Cncl&Srch=" + ddlStatus.SelectedItem.Value);

            }

       
      
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

         
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenFieldUserId.Value = Session["USERID"].ToString();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Notice_Period);
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

                clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
                clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

                if (Session["USERID"] != null)
                {
                    objEntityNoticePeriod.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityNoticePeriod.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityNoticePeriod.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                objEntityNoticePeriod.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                if (cbxCnclStatus.Checked == true)
                {
                    objEntityNoticePeriod.CancelStatus = 1;
                }
                else
                {
                    objEntityNoticePeriod.CancelStatus = 0;
                }

                DataTable dt = objBusinessNoticePeriod.ReadNoticePrdList(objEntityNoticePeriod);
                string strHtm = ConvertDataTableToHTML(dt, intEnableModify, intEnableCancel, intEnableRecall);
                //Write to divReport
                divReport.InnerHtml = strHtm;
            }
    }


    [WebMethod]
    public static string ChangeSponsorStatus(int CatId, string CatStatus, int EmpId)
    {

        //Creating objects for business layer
        clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
        clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();
        string strRet = "success";
        objEntityNoticePeriod.NoticePrdId = CatId;
        objEntityNoticePeriod.UserId = EmpId;
        objEntityNoticePeriod.UserDate = System.DateTime.Now;
        try
        {
            objBusinessNoticePeriod.ChangeStatus(objEntityNoticePeriod);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }

}