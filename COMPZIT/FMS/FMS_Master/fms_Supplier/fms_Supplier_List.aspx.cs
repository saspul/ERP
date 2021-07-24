using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;

public partial class FMS_FMS_Master_fms_Supplier_fms_Supplier_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            ddlStatus.Focus();
            clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
            clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntitySupplier.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntitySupplier.Corp_Id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntitySupplier.Org_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (CbxCnclStatus.Checked == true)
            {
                objEntitySupplier.LedgerSts = 1;
            }
            else
            {
                objEntitySupplier.LedgerSts = 0;
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intAcntSpecific = 0, intBusinessSpecific = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Supplier);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active); 
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAcntSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active); 
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

            if ((intBusinessSpecific != Convert.ToInt32(clsCommonLibrary.StatusAll.Active)) && (intAcntSpecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
          
            {
                divAdd.Visible = false;
            }

           // objEntitySupplier.Corp_Id = 0;
            objEntitySupplier.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtList = objBusinessSupplier.ReadSupplierList(objEntitySupplier);

            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                if (Request.QueryString["InsUpd"] == "cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Error")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessError", "SuccessError();", true);
                }
                else if (Request.QueryString["InsUpd"] == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeleted", "SuccessDeleted();", true);
                }
                else if (Request.QueryString["InsUpd"] ==  "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
                }
                
            }
        }
       
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\">";
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 7; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-5 td1 tr_l\">SUPPLIER";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l \" placeholder=\"SUPPLIER\" type=\"text\">";
                strHtml += "</th >";
                //strHtml += "<th class=\"col-md-6 tr_l\" >SUPPLIER";
                //strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"SUPPLIER\" />";
                //strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-3 td1 tr_l\">ADDRESS";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l \" placeholder=\"ADDRESS\" type=\"text\">";
                strHtml += "</th >";
                //strHtml += "<th class=\"col-md-2 td1 tr_l\" >ADDRESS ";
                //strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"ADDRESS\" />";
                //strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-2 \" > Actions";
                //if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //{
                //    if (CbxCnclStatus.Checked == false)
                //    {
                //        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> EDIT";
                //    }
                //}
                //if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //{
                //    if (CbxCnclStatus.Checked == false)
                //    {
                //        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> DELETE";
                //    }
                //}
            }
            //else if (intColumnHeaderCount == 6)
            //{
            //    if (CbxCnclStatus.Checked == true)
            //    {
            //        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
            //    }
            //}
        }
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount][3].ToString();
            int CNT = intRowBodyCount + 1;
            for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["SUPLIR_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tr_l\" > " + dt.Rows[intRowBodyCount]["SUPLIR_ADDRESS"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += " <td> ";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            strHtml += " <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1 \" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"fms_Supplier.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                        }
                        else if (CbxCnclStatus.Checked == true)
                        {
                            strHtml += "  <a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                         " href=\"fms_Supplier.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if (dt.Rows[intRowBodyCount]["PUCH_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["DR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["CR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["JRNL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
                            {
                                strHtml += "<a  href=\"#\" style=\"opacity:0.5;z-index: 10;\" class=\"btn act_btn bn3 \" onclick=\"return DeleteNotPossible();\" title=\"Delete\" ><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                            {
                                strHtml += "<a  href=\"#\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }

                    }
                    
                     strHtml += "</td>";
                }
               

              

            }




            strHtml += "</tr>";
        }
        //if (dt.Rows.Count == 0)
        //{
        //    strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        //}

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }



    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
        clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntitySupplier.SupplierId = Convert.ToInt32(strId);
        objEntitySupplier.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntitySupplier.Cancel_Reason = cnclRsn;
        }

        else
        {
            objEntitySupplier.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBusinessSupplier.CheckSupplierCnclSts(objEntitySupplier);
            if (dt.Rows.Count == 0)
            {

                objBusinessSupplier.CancelSupplier(objEntitySupplier);
            }
            else
            {
                strRets = "UpdCancl";
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
        clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntitySupplier.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntitySupplier.Corp_Id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntitySupplier.Org_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            objEntitySupplier.LedgerSts = 1;
        }
        else
        {
            objEntitySupplier.LedgerSts = 0;
        }
        objEntitySupplier.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objBusinessSupplier.ReadSupplierList(objEntitySupplier);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Supplier);
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