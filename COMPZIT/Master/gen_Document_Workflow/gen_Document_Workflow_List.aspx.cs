using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using System.Data;
using System.Web.Services;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Script.Serialization;
using System.IO;
public partial class Master_gen_Document_Workflow_gen_Document_Workflow_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        if (!IsPostBack)
        {
            this.dldocsec.Focus();
            Read_Document();

            clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntity.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntity.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intedit = 0, intreopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Document_Workflow);
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
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intedit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intreopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
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

            clsBusinessLayerPMS objBusinessWrkflow = new clsBusinessLayerPMS();
            clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

            objEntityWrkFlow.Corporate_id = objEntity.Corporate_id;
            objEntityWrkFlow.Organisation_id = objEntity.Organisation_id;
            objEntityWrkFlow.User_Id = objEntity.User_Id;

            if (dldocsec.SelectedItem.Value != "--Select--")
            {
                objEntityWrkFlow.Doc = dldocsec.SelectedItem.Value;
            }
            else
            {
                objEntityWrkFlow.Doc = "0";
            }
            objEntityWrkFlow.Status_id = Convert.ToInt32(dlstatus.SelectedItem.Value);
            if (cbxCnclStatus.Checked == true)
            {
                objEntityWrkFlow.CancelStatus = 1;
            }

            DataTable dtList = objBusinessWrkflow.ReadDocumentWrkflowList(objEntityWrkFlow);
            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //Msgbox(strId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenCancelPrimaryId.Value = strId;
                }
            }
            //HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Error")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
                }
                else if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "AlCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
                }
                else if (strInsUpd == "Sts")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChng", "SuccessStatusChng();", true);
                }
                else if (strInsUpd == "Cnfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfm", "SuccessCnfm();", true);
                }
                else if (strInsUpd == "AlrdyCncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyDeleted", "AlreadyDeleted();", true);
                }
            }
        }
    }
    [WebMethod]
    public static string CancelReason(string strCnclId, string strCancelMust, string strUserID, string strCancelReason, string strOrgIdID, string strCorpID)
    {
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspaspr = new clsBusinessLayerApprovalHierarchyTemp();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCnclId;

        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objentityPass.TempId =Convert.ToInt32( strId);
        objentityPass.User_Id =Convert.ToInt32( strUserID);
        objentityPass.Organisation_id = Convert.ToInt32(strOrgIdID);
         DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
        string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        if (dat.Trim() != "")
        {
            objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
        }
        if (strCancelMust == "1")
        {
            objentityPass.CancelReason = strCancelReason;
           
        }

        else
        {
            objentityPass.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBussinesspaspr.cancelDocwrkData(objentityPass);
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }




    [WebMethod]
    public static string ChangeStatus(string strStsId, string Status)
    {

        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspaspr = new clsBusinessLayerApprovalHierarchyTemp();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successchng";
        string strRandomMixedId = strStsId;

        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objentityPass1.TempId =Convert.ToInt32( strId);

        if (Status == "1")
        {
            objentityPass1.Status_id = 0;
        }
        else
        {
            objentityPass1.Status_id = 1;
        }
        try
        {

            objEntitybuspms.StatusChangeDocwrk(objentityPass1);
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }

    public void Read_Document()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();



        DataTable doc = objEntitybuspms.Read_Document();
        dldocsec.Items.Clear();
        dldocsec.DataSource = doc;
        dldocsec.DataValueField = "DOC_ID";
        dldocsec.DataTextField = "DOC_NAME";
        dldocsec.DataBind();
        dldocsec.Items.Insert(0, "--Select--");




    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intedit, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int CancelSts = 0;
        if (cbxCnclStatus.Checked == true)
        {
            CancelSts = 1;
        }

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";

        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr id=\"SearchRow\" >";

        strHtml += "<th class=\"col-md-4 tr_l\">DOCUMENT NAME ";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in \"  placeholder=\" Document Name\"  type=\"text\">";
        strHtml += "</th >";


        strHtml += "<th class=\"col-md-4 tr_l\" >DOCUMENT SECTION ";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in \" placeholder=\" Document Section\"  type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-1\" style=\"word-wrap:break-word;\">STATUS ";
        strHtml += "</th >";

        strHtml += " <th class=\"col-md-2\" >Actions</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";

        strHtml += "<tbody>";

        int intCancTransaction = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strHtml += "<tr >";

            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["DOC_NAME"].ToString() + "</td>";

            int ConfirmStatus = 0;
            if (dt.Rows[intRowBodyCount]["WRKFLW_CONFRM_STS"].ToString() != "")
            {
                ConfirmStatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["WRKFLW_CONFRM_STS"].ToString());
            }

            int Status = Convert.ToInt32(dt.Rows[intRowBodyCount]["WRKFLW_STATUS"].ToString());
            if (Status == 0)
            {
                if (CancelSts == 0)
                {
                    if (ConfirmStatus == 0)
                    {
                        strHtml += "<td><button class=\"btn tab_but1 butn6\" onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\">Inactive</button></td>";
                    }
                    else
                    {
                        strHtml += "<td><button class=\"btn tab_but1 butn6\" onclick=\"return StatusNotPossible();\">Inactive</button></td>";
                    }
                }
                else
                {
                    strHtml += "<td>Inactive</td>";
                }
            }
            else
            {
                if (CancelSts == 0)
                {
                    if (ConfirmStatus == 0)
                    {
                        strHtml += "<td><button class=\"btn tab_but1 butn1\" onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\">Active</button></td>";
                    }
                    else
                    {
                        strHtml += "<td><button class=\"btn tab_but1 butn6\" onclick=\"return StatusNotPossible();\">Active</button></td>";
                    }
                }
                else
                {
                    strHtml += "<td>Active</td>";
                }
            }

            strHtml += "<td class=\"td1\"><div class=\"btn_stl1\">";

            if (ConfirmStatus == 1 && Status == 1 && CancelSts == 0)
            {
                strHtml += "<a class=\"btn act_btn bn8\" title=\"Replace Approver\" onclick='return getdetails(this.href);' "+
                                    " href=\"gen_Document_Workflow.aspx?ReId=" + Id + "\"><i class=\"fa fa-refresh\"></i></a>";
            }
            else
            {
                strHtml += "<a class=\"btn act_btn bn8\" title=\"Replace Approver\" disabled=\"disabled\"><i class=\"fa fa-refresh\"></i></a>";
            }

            if (intedit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (CancelSts == 0)
                {
                    if (ConfirmStatus == 0)
                    {
                        strHtml += "<a class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                        " href=\"gen_Document_Workflow.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                    }
                    else
                    {
                        strHtml += "<a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                        " href=\"gen_Document_Workflow.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                    }
                }
            }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (CancelSts == 0)
                {
                    if (intCancTransaction == 0 && ConfirmStatus == 0)
                    {
                        strHtml += "<a href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                    }
                    else
                    {
                        strHtml += "<a href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return CancelNotPossible();\" disabled=\"\"><i class=\"fa fa-trash\"></i></a>";
                    }
                }
            }

            if (CancelSts == 1)
            {
                strHtml += "<a class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                      " href=\"gen_Document_Workflow.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
            }

            strHtml += "</div></td>";

            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public void Msgbox(String s)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + s + "');", true);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void button1_click(object sender, EventArgs e)
    {
       
       
    }

    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
    //    clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
    //    clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
    //    if (dldocsec.SelectedItem.Text != "--Select--")
    //    {
    //        int intUpdate = 1, intEnableCancel = 1, intedit = 1;
           
    //        if (dlstatus.SelectedItem.ToString() == "Active")
    //        {
    //            objentityPass1.Doc = dldocsec.SelectedItem.ToString();
    //            objentityPass1.Status_id = 1;
               
    //            DataTable dtList = objEntitybuspms.ReadDocwrkflw(objentityPass1);
    //            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);
    //        }
    //        else if (dlstatus.SelectedItem.ToString() == "Inactive")
    //        {
    //            objentityPass1.Doc = dldocsec.SelectedItem.ToString();
    //            objentityPass1.Status_id = 0;
    //            DataTable dtList = objEntitybuspms.ReadDocwrkflw(objentityPass1);
              
    //            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);
    //        }
    //        else
    //        {
    //            objentityPass1.Doc = dldocsec.SelectedItem.ToString();
    //            DataTable dtList = objEntitybuspms.ReadDocumentwrk();
    //            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);
    //        }
            

    //    }

    //  else
    //    {
    //        if (dldocsec.SelectedItem.Text == "--Select--")
    //        {
    //            int intUpdate = 1, intEnableCancel = 1, intedit = 1;
    //            if (dlstatus.SelectedItem.Text != "All")
    //            {
                  
    //                if (dlstatus.SelectedItem.ToString() == "Active")
    //                {
    //                    objentityPass1.Status_id = 1;
    //                    DataTable dtList1 = objEntitybuspms.ReadDocwrkflwsts(objentityPass1);
    //                    divList.InnerHtml = ConvertDataTableToHTML(dtList1, intUpdate, intedit, intEnableCancel);
    //                }
    //                else if (dlstatus.SelectedItem.ToString() == "Inactive")
    //                {
    //                    objentityPass1.Status_id = 0;
    //                    DataTable dtList1 = objEntitybuspms.ReadDocwrkflwsts(objentityPass1);
    //                    divList.InnerHtml = ConvertDataTableToHTML(dtList1, intUpdate, intedit, intEnableCancel);
    //                }
    //            }
    //                else
    //                {
    //                    DataTable dtList = objEntitybuspms.ReadDocumentwrk();
    //                    divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);
    //                }
    //            }
               
    //        }
       


    //    if (cbxCnclStatus.Checked == true)
    //    {
    //        int intUpdate = 0, intEnableCancel = 0, intedit = 0;
    //        DataTable dtList2 = objEntitybuspms.ReadDocwrkflwcncl();
    //        divList.InnerHtml = ConvertDataTableToHTML(dtList2, intUpdate, intedit, intEnableCancel);
            
    //    }
       
    //  // Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=''");
    //}

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerPMS objBusinessWrkflow = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWrkFlow.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWrkFlow.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityWrkFlow.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intedit = 0, intreopen = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Document_Workflow);
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
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intedit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intreopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }
            }
        }

        if (dldocsec.SelectedItem.Value != "--Select--")
        {
            objEntityWrkFlow.Doc = dldocsec.SelectedItem.Value;
        }
        else
        {
            objEntityWrkFlow.Doc = "0";
        }
        objEntityWrkFlow.Status_id = Convert.ToInt32(dlstatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
        {
            objEntityWrkFlow.CancelStatus = 1;
        }

        DataTable dtList = objBusinessWrkflow.ReadDocumentWrkflowList(objEntityWrkFlow);
        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intedit, intEnableCancel);


    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
       
        
    }
    public string PrintCaption(clsEntityApprovalHierarchyTemp ObjEntityRequest)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corporate_id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_id;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "DOCUMENT WORKFLOW";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // GuaranteDivsn = "<B> DATE  : </B>" + ObjEntityRequest.FromDate.ToString("dd-MM-yyyy");
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        StringBuilder sbCap = new StringBuilder();
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteBank = "", strUsrName = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (GuaranteDivsn != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string CnclSts, string statusid,string docsec)
    {
        string strReturn = "";
        clsBusinessLayerPMS objBusinessWrkflow = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityWrkFlow.Organisation_id= Convert.ToInt32(orgID);

        objEntityWrkFlow.Corporate_id = Convert.ToInt32(corptID);
        objEntityWrkFlow.CancelStatus = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityWrkFlow.Status_id = Convert.ToInt32(statusid);

        objEntityWrkFlow.Doc = docsec;
        DataTable dtCategory = objBusinessWrkflow.ReadDocumentWrkflowList(objEntityWrkFlow);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.DOCUMENT_WORKFLOW);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DOCUMENT_WORKFLOW);
        objEntityCommon.CorporateID = objEntityWrkFlow.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityWrkFlow.Organisation_id;
        string strNextNumber = objBusinesslayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "documentworkflowlist_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string format = String.Format("{{0:N{0}}}", 2);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                // footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                // if (SupName != "")
                //{
                //footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT BOOK  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                // footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //footrtable.AddCell(new PdfPCell(new Phrase(SupName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                // }
                  if (docsec== "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DOCUMENT SECTION  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
             
                    footrtable.AddCell(new PdfPCell(new Phrase("Purchase Order", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (docsec == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DOCUMENT SECTION  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
             
                    footrtable.AddCell(new PdfPCell(new Phrase("Sales Order", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
               // else 
               // {
                   // footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
              //  }
                footrtable.AddCell(new PdfPCell(new Phrase("WORKFLOW STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (statusid == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Inactive", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Active", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                //else if (PurchaseStatus == "3")
                // {
                //     footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                // }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 24, 18, 14 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DOCUMENT NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DOCUMENT SECTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();
                if (dtCategory.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                    {
                        string strId = dtCategory.Rows[0][0].ToString();
                        int usrId = Convert.ToInt32(strId);
                        int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                        int CNT = intRowBodyCount + 1;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strStatusImg = "";
                        if (dtCategory.Rows[intRowBodyCount]["WRKFLW_STATUS"].ToString() == "1")
                        {
                            strStatusImg = "Active";
                        }

                        else
                        {
                            strStatusImg = "Inactive";
                        }




                        TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                    }
                    // TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                }

                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 7 });

                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
        }
        catch (Exception)
        {
            document.Close();
            strRet = "";
        }
        return strRet;
    }
    public class PDFHeader : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate footerTemplate;
        BaseFont bf = null;
        DateTime PrintTime = DateTime.Now;
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(200, 200);
            }
            catch (DocumentException de)
            {
                //handle exception here
            }
            catch (System.IO.IOException ioe)
            {
                //handle exception here
            }
        }

        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon ObjEntityCommon = new clsEntityCommon();
            clsBusinessLayer objDataCommon = new clsBusinessLayer();
            ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
            if (dtCorp.Rows.Count > 0)
            {
                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                {
                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                    strImageLogo = imaeposition + icon;
                }
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            //Head Table
            PdfPTable headtable = new PdfPTable(2);
            headtable.AddCell(new PdfPCell(new Phrase("DOCUMENT WORKFLOW LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            }
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            float[] headersHeading = { 80, 20 };
            headtable.SetWidths(headersHeading);
            headtable.WidthPercentage = 100;
            document.Add(headtable);
            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;
            tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            float pos9 = writer.GetVerticalPosition(false);
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            // base.OnEndPage(writer, document);
            string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

            headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }

            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;

            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
            }
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }
    [WebMethod]
    public static string PrintCSV(string orgID, string corptID, string CnclSts, string statusid,string docsec)
    {
        string strReturn = "";
        clsBusinessLayerPMS objBusinessWrkflow = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        Master_gen_Document_Workflow_gen_Document_Workflow_List OBJ = new Master_gen_Document_Workflow_gen_Document_Workflow_List();
        objEntityWrkFlow.Organisation_id = Convert.ToInt32(orgID);

        objEntityWrkFlow.Corporate_id = Convert.ToInt32(corptID);
        objEntityWrkFlow.CancelStatus = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);
        objEntityWrkFlow.Status_id = Convert.ToInt32(statusid);

        objEntityWrkFlow.Doc = docsec;

        DataTable dtCategory =  objBusinessWrkflow.ReadDocumentWrkflowList(objEntityWrkFlow);

        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntityWrkFlow, CnclSts, statusid, docsec);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityApprovalHierarchyTemp objEntityWrkFlow, string CnclSts, string statusid, string docsec)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, objEntityWrkFlow, CnclSts, statusid, docsec);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (objEntityWrkFlow.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = objEntityWrkFlow.Corporate_id;
        }
        if (objEntityWrkFlow.Organisation_id!= 0)
        {
            objEntityCommon.Organisation_Id = objEntityWrkFlow.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DOCUMENT_WORKFLOW_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/PMS_CSV/Document_workflow/DocumentworkflowList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "DocumentworkflowList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DOCUMENT_WORKFLOW_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityApprovalHierarchyTemp objEntityWrkFlow, string CnclSts, string statusid, string docsec)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (objEntityWrkFlow.Corporate_id != 0)
        {
            intCorpId = objEntityWrkFlow.Corporate_id;
        }

        //DataTable dtCorpDetail = new DataTable();
        //dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        //int Decimalcount = 0;
        //if (dtCorpDetail.Rows.Count > 0)
        //{
        //    objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        //    Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        //}

        string FORNULL = "";
        DataTable table = new DataTable();
        string strRandom = objCommon.Random_Number();
        table.Columns.Add("DOCUMENT WORKFLOW LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        //table.Columns.Add("    ", typeof(string));
        //table.Columns.Add("     ", typeof(string));
        //table.Columns.Add("      ", typeof(string));

        //table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //if (Suplier != "")
        //    table.Rows.Add("SUPPLIER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////if (Status == "1")
        ////    table.Rows.Add("STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////else if (Status == "0")
        ////    table.Rows.Add("STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////else
         

           if (docsec == "1")
               table.Rows.Add("DOCUEMNT SECTION :", "Purchase Order", '"' + FORNULL + '"', '"' + FORNULL + '"');
           else if (docsec == "2")
               table.Rows.Add("DOCUEMNT SECTION :", "Sales Order", '"' + FORNULL + '"', '"' + FORNULL + '"');
           //else
              // table.Rows.Add("DOCUEMNT SECTION :", " ", '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (statusid == "1")
            table.Rows.Add("WORKFLOW STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (statusid == "0")
            table.Rows.Add("WORKFLOW STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("WORKFLOW STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"');

        //table.Rows.Add("PURCHASE STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("DOCUMENT NAME", "DOCUMENT SECTION", "STATUS");

        if (dtCategory.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                string strId = dtCategory.Rows[0][0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                int CNT = intRowBodyCount + 1;

                string strStatusImg = "";
                if (dtCategory.Rows[intRowBodyCount]["WRKFLW_STATUS"].ToString() == "1")
                {
                    strStatusImg = "ACTIVE";
                }
                else
                {

                    strStatusImg = "INACTIVE";

                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString() + '"', '"' + strStatusImg + '"');

            }

        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        return table;
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}