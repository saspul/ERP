using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Exit_Intrvw_Qstn_hcm_Exit_Intrvw_Qstn_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Designation();

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Interview_questions);
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


                 
                    //Creating objects for business layer
                    clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
                    clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();

                    
                    DataTable dtCorpDetail = new DataTable();
                    int intCorpId = 0;

                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                   

                    if (Request.QueryString["Id"] != null)
                    {//when Canceled

                        string strRandomMixedId = Request.QueryString["Id"].ToString();
                        string strLenghtofId = strRandomMixedId.Substring(0, 2);
                        int intLenghtofId = Convert.ToInt16(strLenghtofId);
                        string strId = strRandomMixedId.Substring(2, intLenghtofId);

                        objEntityExitIntrvwQstn.DesgId = Convert.ToInt32(strId);
                        objEntityExitIntrvwQstn.CnclUserId = intUserId;

                        objEntityExitIntrvwQstn.CnclDate = System.DateTime.Now;



                        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                        if (dtCorpDetail.Rows.Count > 0)
                        {
                            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                            if (CnclrsnMust == "0")
                            {
                                objEntityExitIntrvwQstn.CnclResn = objCommon.CancelReason();

                                objBusinessExitIntrvwQstn.DelExitIntrvwQstn(objEntityExitIntrvwQstn);
                                if (HiddenSearchField.Value == "")
                                {
                                    Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Cncl");
                                }
                                else
                                {
                                    Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                                }

                            }
                            else
                            {

                                //  clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
                                DataTable dtContract = new DataTable();
                                //dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);
                                DataTable dtCntTrnsction = new DataTable();
                                dtContract = objBusinessExitIntrvwQstn.ReadDtls(objEntityExitIntrvwQstn);
                                dtCntTrnsction = objBusinessExitIntrvwQstn.CountTransaction(objEntityExitIntrvwQstn);
                                string strHtm1 = ConvertDataTableToHTML(dtContract,dtCntTrnsction, intEnableModify, intEnableCancel);
                                //Write to divReport
                                divReport.InnerHtml = strHtm1;

                                hiddenRsnid.Value = strId;


                            }

                        }



                    }
 
                        //to view
                        DataTable dtProductSrch = new DataTable();
                        DataTable dtCntTrnsction1 = new DataTable();
                        dtProductSrch = objBusinessExitIntrvwQstn.ReadDtls(objEntityExitIntrvwQstn);
                        dtCntTrnsction1 = objBusinessExitIntrvwQstn.CountTransaction(objEntityExitIntrvwQstn);
                        string strHtm = ConvertDataTableToHTML(dtProductSrch, dtCntTrnsction1, intEnableModify, intEnableCancel);
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


    public string ConvertDataTableToHTML(DataTable dt, DataTable dtCntTrnsction, int intEnableModify, int intEnableCancel)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        int intCnclUsrId = 0;
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            if (dt.Rows[intRowBodyCount]["EXTINTRVQT_CNCL_USR_ID"].ToString() != "")
            {
                intCnclUsrId = 1;
            }

        
        }
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: center; word-wrap:break-word;\">NUMBER OF QUESTIONS</th>";
            }

        }
        if (intCnclUsrId != 0)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
        else 
        {
            if (intEnableModify != 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">EDIT</th>";
            }
            else { }
            if (intEnableCancel!=0)
            {
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">DELETE</th>";
            }
            else{}
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = 0;
            if (dtCntTrnsction.Rows.Count>0)
            {
                for (int intCnclRowcount = 0; intCnclRowcount < dtCntTrnsction.Rows.Count; intCnclRowcount++)
                {
                    if (dtCntTrnsction.Rows[intCnclRowcount]["DSGN_ID"].ToString() == dt.Rows[intRowBodyCount]["DSGN_ID"].ToString())
                    {
                        intCancTransaction = Convert.ToInt32(dtCntTrnsction.Rows[intCnclRowcount]["COUNT_TRANSACTION"].ToString());
                    }

                }
            }
            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }
            if (intCnclUsrId != 0)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"hcm_Exit_Intrvw_Qstn.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
            }
            else
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                  " href=\"hcm_Exit_Intrvw_Qstn.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                else
                {
                    
                }
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCancTransaction == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"   onclick='return CancelAlert(this.href);' " +
                                 " href=\"hcm_Exit_Intrvw_Qstn_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Delete\" onclick='return CancelNotPossible();' >"
                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                    }
                    
                        
                    
                       // strHtml += "<td class=\"tdT\" style=\"width:4%;  word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\">" + "<img style=\"opacity: 0.3;\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                    
                }
                else
                {
                  

                }

            }
       
           
            
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public void Designation()
    {
        clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
        clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDivision = objBusinessExitIntrvwQstn.ReadDesignationBySearch(objEntityExitIntrvwQstn);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDesg.Items.Clear();
            ddlDesg.DataSource = dtDivision;


            ddlDesg.DataValueField = "DSGN_ID";
            ddlDesg.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDesg.DataBind();

        }
        ddlDesg.Items.Insert(0, "--SELECT--");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
        clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDesg.SelectedItem.Value != "--SELECT--")
        {
            objEntityExitIntrvwQstn.DesgId = Convert.ToInt32(ddlDesg.SelectedItem.Value);

        }
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Interview_questions);
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
        if (ddlDesg.SelectedItem.Value != "--SELECT--" && cbxCnclStatus.Checked==false)
        {
            int desg = Convert.ToInt32(ddlDesg.SelectedItem.Value);
            objEntityExitIntrvwQstn.DesgId = desg;
            objEntityExitIntrvwQstn.SearchSts = 0;
        }
        if (cbxCnclStatus.Checked == true && ddlDesg.SelectedItem.Value == "--SELECT--")
        {        
            objEntityExitIntrvwQstn.SearchSts = 1;
        }
        if (cbxCnclStatus.Checked == true && ddlDesg.SelectedItem.Value != "--SELECT--")
        {
            int desg1 = Convert.ToInt32(ddlDesg.SelectedItem.Value);
            objEntityExitIntrvwQstn.DesgId = desg1;       
            objEntityExitIntrvwQstn.SearchSts = 2;
        }
        if (cbxCnclStatus.Checked == false && ddlDesg.SelectedItem.Value == "--SELECT--")
        {
            objEntityExitIntrvwQstn.SearchSts = 3;
        }

        hiddenEnableModify.Value = Convert.ToString(intEnableModify);
        hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);

        DataTable dtProductSrch = new DataTable();
        DataTable dtCntTrnsction = new DataTable();

                        dtProductSrch = objBusinessExitIntrvwQstn.SearchExitIntrvwQstn(objEntityExitIntrvwQstn);
                        dtCntTrnsction = objBusinessExitIntrvwQstn.CountTransaction(objEntityExitIntrvwQstn);
                        string strHtm = ConvertDataTableToHTML(dtProductSrch,dtCntTrnsction, intEnableModify, intEnableCancel);
                        //Write to divReport
                        divReport.InnerHtml = strHtm;

       
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
        clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();


        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityExitIntrvwQstn.DesgId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityExitIntrvwQstn.CnclUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityExitIntrvwQstn.CnclDate = System.DateTime.Now;

            objEntityExitIntrvwQstn.CnclResn = txtCnclReason.Text.Trim();
            objBusinessExitIntrvwQstn.DelExitIntrvwQstn(objEntityExitIntrvwQstn);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }
}