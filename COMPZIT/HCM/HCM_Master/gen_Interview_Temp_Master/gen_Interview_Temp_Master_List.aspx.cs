using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_Interview_Temp_Master_gen_Interview_Temp_Master_List : System.Web.UI.Page
{
    clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
    protected void Page_Load(object sender, EventArgs e)
    {
        //clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ddlStatus.Focus();
            clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();

          
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Interview_Template);
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
                    objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                 
                    string strCbxStatus = strSearchFields[0];


                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }


                if (Request.QueryString["canId"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["canId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityIntrvTem.NextTempId = Convert.ToInt32(strId);
                    objEntityIntrvTem.User_Id = intUserId;

                    objEntityIntrvTem.D_Date = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityIntrvTem.Cancel_Reason = objCommon.CancelReason();

                            objBusinessIntrvTem.CancelinterviewTem(objEntityIntrvTem);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {



                            //  clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
                            DataTable dtContract = new DataTable();
                            //dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);
                            objEntityIntrvTem.TempSts = 1;
                            dtContract = objBusinessIntrvTem.ReadinterviewTemList(objEntityIntrvTem);

                            string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;


                        }

                    }



                }
                else
                {
                    //to view

                    if (HiddenSearchField.Value == "")
                    {
                        objEntityIntrvTem.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                           string strCbxStatus = strSearchFields[0];
                           string strStatus = strSearchFields[1];
                        
                      
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                            // objEntityJobDesrp.Cancel_Status = 1;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                            //objEntityJobDesrp.Cancel_Status = 0;
                        }
                        objEntityIntrvTem.TempSts = Convert.ToInt32(strStatus);

                        objEntityIntrvTem.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    objEntityIntrvTem.User_Id = intUserId;

                    DataTable dtContract = new DataTable();
                    objEntityIntrvTem.TempSts = 1;
                    dtContract = objBusinessIntrvTem.ReadinterviewTemList(objEntityIntrvTem);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
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
                }
            }
        }

    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }

      //  strHtml += "<th class=\"thT\" style=\"width:6%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                
                
                strHtml += "<th class=\"thT\" style=\"width:65%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
         


        }
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">STATUS</th>";
            }
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:7%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:7%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }

        //if (intReCallForTAble == 1)
        //{
        //    if (intEnableRecall == 1)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
        //    }
        //}


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
        //    strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
            count++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:65%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
              

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

             strStatusMode = dt.Rows[intRowBodyCount][2].ToString();


            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\"  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img   style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\"  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Interview_Temp_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:7%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Interview_Temp_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\"width:7%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                 " href=\"gen_Interview_Temp_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


            }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Interview_Temp_Master_List.aspx?canId=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                               " href=\"gen_Interview_Temp_Master_List.aspx?canId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:9%; word-wrap:break-word;text-align: center;\"></td>";
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

   
    //  at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenSearchField.Value == "")
        {
            objEntityIntrvTem.Cancel_Status = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');
                    string strCbxStatus = strSearchFields[0];
                    string strSts = strSearchFields[1];
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
                // objEntityJobDesrp.Cancel_Status = 1;
            }
            else
            {
                cbxCnclStatus.Checked = false;
                //objEntityJobDesrp.Cancel_Status = 0;
            }

            objEntityIntrvTem.Cancel_Status = Convert.ToInt32(strCbxStatus);
            objEntityIntrvTem.TempSts = Convert.ToInt32(strSts);
        }
        objEntityIntrvTem.User_Id = intUserId;

        DataTable dtContract = new DataTable();
        dtContract = objBusinessIntrvTem.ReadinterviewTemList(objEntityIntrvTem);




        int intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Interview_Template);
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

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer


        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();


        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityIntrvTem.NextTempId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityIntrvTem.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityIntrvTem.D_Date = System.DateTime.Now;

            objEntityIntrvTem.Cancel_Reason = txtCnclReason.Text.Trim();
            objBusinessIntrvTem.CancelinterviewTem(objEntityIntrvTem);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Interview_Temp_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus)
    {

        clsBusnssLyr_gen_Interview_Temp objBusinessIntrvTem = new clsBusnssLyr_gen_Interview_Temp();
        clsEntity_Interview_Temp objEntityIntrvTem = new clsEntity_Interview_Temp();

        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityIntrvTem.TempSts = 0;
        }
        else
        {
            objEntityIntrvTem.TempSts = 1;
        }
        objEntityIntrvTem.NextTempId = strCatId;
        try
        {
            objBusinessIntrvTem.ChangeRequestStatus(objEntityIntrvTem);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
}