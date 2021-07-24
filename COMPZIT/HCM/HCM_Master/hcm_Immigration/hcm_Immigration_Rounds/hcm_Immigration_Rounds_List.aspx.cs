using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Rounds_hcm_Immigration_Rounds_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Round);
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


                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;
                }
                else
                {
                    divAdd.Visible = false;
                }


                hiddenEnableModify.Value = Convert.ToString(intEnableModify);
                hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);


                clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
                clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();


                DataTable dtCorpDetail = new DataTable();
                int intCorpId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    objEntityImgratnRnd.UserId = Convert.ToInt32(Session["USERID"].ToString());
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                               };

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

                        objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(strId);

                        objEntityImgratnRnd.UserId = intUserId;

                        objEntityImgratnRnd.Date = System.DateTime.Now;


                        if (CnclrsnMust == "0")
                        {
                            //if cancelreasn=0
                            objEntityImgratnRnd.CancelReason = objCommon.CancelReason();

                            objBusinessImgratnRnd.CancelImgratnRnd(objEntityImgratnRnd);
                            Response.Redirect("hcm_Immigration_Rounds_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            //if cancelreasn=1
                            DataTable dtImgratnRnd = new DataTable();
                            objEntityImgratnRnd.ImgratnRound_Status = 1;
                            objEntityImgratnRnd.CancelStatus = 0;

                            dtImgratnRnd = objBusinessImgratnRnd.ReadImgratnRnd(objEntityImgratnRnd);

                            string strHtm = ConvertDataTableToHTML(dtImgratnRnd, intEnableModify, intEnableCancel);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;
                        }

                    //if not cancelled
                    }
                    else if (Request.QueryString["StsCh"] != null)
                    {
                        //if status changed
                        string strRandomMixedId = Request.QueryString["StsCh"].ToString();
                        string strLenghtofId = strRandomMixedId.Substring(0, 2);
                        int intLenghtofId = Convert.ToInt16(strLenghtofId);
                        string strId = strRandomMixedId.Substring(2, intLenghtofId);

                        objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(strId);
                        objEntityImgratnRnd.UserId = intUserId;
                        objEntityImgratnRnd.Date = System.DateTime.Now;

                        DataTable dtCancelCheck = new DataTable();
                        dtCancelCheck = objBusinessImgratnRnd.CheckCancelImgrtnRndId(objEntityImgratnRnd);


                        objBusinessImgratnRnd.StatusChangeImgratnRnd(objEntityImgratnRnd);

                        Response.Redirect("hcm_Immigration_Rounds_List.aspx?InsUpd=StsCh");

                    }
                    else
                    {
                        //viewing table

                        DataTable dtImgratnRnd = new DataTable();
                        objEntityImgratnRnd.ImgratnRound_Status = 1;
                        objEntityImgratnRnd.CancelStatus = 0;

                        dtImgratnRnd = objBusinessImgratnRnd.ReadImgratnRnd(objEntityImgratnRnd);

                        string strHtm = ConvertDataTableToHTML(dtImgratnRnd, intEnableModify, intEnableCancel);
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
                            else if (strInsUpd == "StsCh")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                            }
                        }
                    }



                }

            }


        }
    }



    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
    {


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
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:58%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                if (cbxCnclStatus.Checked == false)
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
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
                    strHtml += "<td class=\"tdT\" style=\" width:58%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    if (cbxCnclStatus.Checked == false)
                    {
                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "ACTIVE")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick='return ChangeStatus();' href=\"hcm_Immigration_Rounds_List.aspx?StsCh=" + Id + "\"\" >" +
                                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick='return ChangeStatus();' href=\"hcm_Immigration_Rounds_List.aspx?StsCh=" + Id + "\"\" >" +
                                  "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {
                            if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "ACTIVE")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"cursor:pointer;\" title=\"Make Inactive\" >" +
                                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"cursor:pointer;\" title=\" Make Active\"  >" +
                                  "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                            }
                        }
                    }

                }

            }


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"hcm_Immigration_Round.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }

            }

            if (cbxCnclStatus.Checked == true)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"hcm_Immigration_Round.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";

            }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (intCancTransaction == 0)
                    {
                        clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
                        clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

                        objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(strId);

                        DataTable dtCancelCheck = new DataTable();
                        dtCancelCheck = objBusinessImgratnRnd.CheckCancelImgrtnRndId(objEntityImgratnRnd);

                        if (dtCancelCheck.Rows.Count > 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                          + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"   onclick='return CancelAlert(this.href);' " +
                            " href=\"hcm_Immigration_Rounds_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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

        clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
        clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();


        int intCorpId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityImgratnRnd.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlStatus.SelectedItem.Value != "")
        {
            objEntityImgratnRnd.ImgratnRound_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }

        if (cbxCnclStatus.Checked == true)
        {
            objEntityImgratnRnd.CancelStatus = 1;
        }
        else
        {
            objEntityImgratnRnd.CancelStatus = 0;
        }

        DataTable dtImgratnRnd = new DataTable();
        dtImgratnRnd = objBusinessImgratnRnd.ReadImgratnRnd(objEntityImgratnRnd);

        int intEnableModify = 0, intEnableCancel = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);

        string strHtm = ConvertDataTableToHTML(dtImgratnRnd, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }





    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //cancel reasn
        clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
        clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(hiddenRsnid.Value);

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityImgratnRnd.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityImgratnRnd.Date = System.DateTime.Now;
            objEntityImgratnRnd.CancelReason = txtCnclReason.Text.Trim();

            objBusinessImgratnRnd.CancelImgratnRnd(objEntityImgratnRnd);

            Response.Redirect("hcm_Immigration_Rounds_List.aspx?InsUpd=Cncl");
        }


    }
}