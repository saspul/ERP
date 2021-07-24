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

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Joining_Worker_hcm_Joining_WorkerList : System.Web.UI.Page
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Worker);
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

                hiddenEnableModify.Value = Convert.ToString(intEnableModify);
                hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);


                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');

                   
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];


                   
                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.ClearSelection();
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }



                //Creating objects for business layer
      


                clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
                clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
                //  objEntityJoiningWorker.ConsultancyStatus = 1;
                DataTable dtCorpDetail = new DataTable();
                int intCorpId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"].ToString());
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE 

                                                               };

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


                if (dtCorpDetail.Rows.Count > 0)
                {
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





                    if (Request.QueryString["Id"] != null)
                    {//when Canceled

                        string strRandomMixedId = Request.QueryString["Id"].ToString();
                        string strLenghtofId = strRandomMixedId.Substring(0, 2);
                        int intLenghtofId = Convert.ToInt16(strLenghtofId);
                        string strId = strRandomMixedId.Substring(2, intLenghtofId);

                        objEntityJoiningWorker.WorkerID = Convert.ToInt32(strId);
                        objEntityJoiningWorker.UserId = intUserId;

                        objEntityJoiningWorker.Date = System.DateTime.Now;

                        if (CnclrsnMust == "0")
                        {
                            objEntityJoiningWorker.CancelReason = objCommon.CancelReason();
                            objBusinessLayerJoiningWorker.CancelJoiningWkr(objEntityJoiningWorker);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            DataTable dtProductSrch = new DataTable();
                           
                            if (HiddenSearchField.Value == "")
                            {
                                
                                objEntityJoiningWorker.ConfirmStatus = 0;
                                objEntityJoiningWorker.CancelStatus = 0; 
                            }

                            dtProductSrch = objBusinessLayerJoiningWorker.ReadJoinigWorkerList(objEntityJoiningWorker);

                            string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;
                            //ModalPopupExtenderCncl.Show();

                        }





                    }
                    else
                    {


                        if (HiddenSearchField.Value == "")
                        {
                            
                            objEntityJoiningWorker.ConfirmStatus = 0;
                            objEntityJoiningWorker.CancelStatus = 0;
                        }
                        else
                        {
                            string strHidden = "";
                            strHidden = HiddenSearchField.Value;

                            string[] strSearchFields = strHidden.Split(',');
                         
                            string strddlStatus = strSearchFields[0];
                            string strCbxStatus = strSearchFields[1];

                            if (strddlStatus != null && strddlStatus != "")
                            {
                                if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                                {
                                    ddlStatus.ClearSelection();
                                    ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                                    objEntityJoiningWorker.ConfirmStatus = Convert.ToInt32(strddlStatus);
                                }
                            }
                            if (strCbxStatus == "1")
                            {
                                cbxCnclStatus.Checked = true;
                            }
                            else
                            {
                                cbxCnclStatus.Checked = false;
                            }

                            objEntityJoiningWorker.CancelStatus = Convert.ToInt32(strCbxStatus);
                        }

                        //to view
                        DataTable dtProductSrch = new DataTable();
                        dtProductSrch = objBusinessLayerJoiningWorker.ReadJoinigWorkerList(objEntityJoiningWorker);

                        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
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
                        }

                    }
                }
            }
        }
    }
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
                strHtml += "<th class=\"thT\" style=\"width:38%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:28%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
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
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
          

            strHtml += "<tr  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}


                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:38%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:28%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
           // int sts = Convert.ToInt32(dt.Rows[intRowBodyCount]["WKR_CONFM_STS"]);
            

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (dt.Rows[intRowBodyCount][5].ToString() != "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                              " href=\"hcm_Joining_Worker.aspx?Id=" + Id + "\">" + "<img src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                     " href=\"hcm_Joining_Worker.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";

                }
                   
                }

            }
            if (cbxCnclStatus.Checked == true)
            {
               
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                         " href=\"hcm_Joining_Worker.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
       
            }
            
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {



                    if (HiddenSearchField.Value == "")
                    {
                        if (dt.Rows[intRowBodyCount][5].ToString() != "1")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"  onclick='return CancelAlert(this.href);' " +
                           " href=\"hcm_Joining_WorkerList.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                               + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                    }
                    else
                    {
                        if (dt.Rows[intRowBodyCount][5].ToString() != "1")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                           " href=\"hcm_Joining_WorkerList.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                               + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                    }

                    //DISABLE
                    //else
                    //{

                    //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"  onclick='return CancelNotPossible();' >"
                    //            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                    //}



                }
                //else
                //{

                //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                //}
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
        //Creating objects for business layer
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        int intCorpId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (HiddenSearchField.Value == "")
        {
           
            objEntityJoiningWorker.ConfirmStatus = 0;
            objEntityJoiningWorker.CancelStatus = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');
            string strddlStatus = strSearchFields[0];
            string strCbxStatus = strSearchFields[1];




            if (strddlStatus != null && strddlStatus != "")
            {
                if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                {
                    ddlStatus.ClearSelection();
                    ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                    objEntityJoiningWorker.ConfirmStatus = Convert.ToInt32(strddlStatus);
                }
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            objEntityJoiningWorker.CancelStatus = Convert.ToInt32(strCbxStatus);
        }

        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessLayerJoiningWorker.ReadJoinigWorkerList(objEntityJoiningWorker);

        int intEnableModify = 0, intEnableCancel = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);
        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityJoiningWorker.WorkerID = Convert.ToInt32(hiddenRsnid.Value);

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityJoiningWorker.Date = System.DateTime.Now;

            objEntityJoiningWorker.CancelReason = txtCnclReason.Text.Trim();
            objBusinessLayerJoiningWorker.CancelJoiningWkr(objEntityJoiningWorker);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }
}