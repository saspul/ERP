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
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
public partial class FMS_FMS_Master_fms_Cheque_Template_fms_Cheque_Template_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // CbxCnclStatus.Focus();
            clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
            clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
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
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

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
            if (CbxCnclStatus.Checked == true)
            {
                objEntity.cncl_sts = 1;
            }
            else
            {
                objEntity.cncl_sts = 0;
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cheque_Template);
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
            //objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtList = objEmpPerfomance.ReadList(objEntity);

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
            else if (Request.QueryString["InsUpd"] == "Error")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
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
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\">";
        //add header row
        strHtml += "<thead  class=\"thead1\">";
        strHtml += "<tr >";
        //strHtml += "<tr >";
        strHtml += "<th class=\"col-md-9 tr_l\" > NAME";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in\" placeholder=\" NAME\" type=\"text\">";
                strHtml += "</th >";
                strHtml += "<th class=\"col-md-3\">Actions";
                strHtml += " <p class=\"nbsp1\">&nbsp;</p>";
                strHtml += "   </th>";
           
                //if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //{
                //    if (CbxCnclStatus.Checked == false)
                //    {
                //        strHtml += "<th class=\"hasinput\" > EDIT";
                //    }
                //}
                //if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //{
                //    if (CbxCnclStatus.Checked == false)
                //    {
                //        strHtml += "<th class=\"hasinput\" > DELETE";
                //    }
                //}
                //if (CbxCnclStatus.Checked == true)
                //{
                //    strHtml += "<th class=\"hasinput\" > VIEW";
                //}

        //strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            int intCancTransaction = 0;


            strHtml += "<td class=\"tr_l\"  >" + dt.Rows[intRowBodyCount]["CHKTEMPLT_NAME"].ToString() + "</td>";

            strHtml += "<td class=\"td1\"> <div class=\"btn_stl1\">";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            strHtml += " <a class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"fms_Cheque_Template.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if (intCancTransaction == 0)
                                strHtml += "<a  href=\"#\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";
                            else
                                strHtml += "<a  href=\"#\" disabled=\true\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";
                        }
                    }
                    if (CbxCnclStatus.Checked == true)
                    {
                        strHtml += "<a class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Cheque_Template.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                    }
                    strHtml += "</div></td>";
            strHtml += "</tr>";
        }
       
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }



    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.ChequeTemplateId = Convert.ToInt32(strId);
        objEntity.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntity.CancelReason = cnclRsn;
        }

        else
        {
            objEntity.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objEmpPerfomance.CancelChequeTemplate(objEntity);

        }
        catch
        {
            strRets = "failed";
        }

        return strRets;
    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
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
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

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
        if (CbxCnclStatus.Checked == true)
        {
            objEntity.cncl_sts = 1;
        }
        else
        {
            objEntity.cncl_sts = 0;
        }
      //  objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objEmpPerfomance.ReadList(objEntity);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cheque_Template);
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