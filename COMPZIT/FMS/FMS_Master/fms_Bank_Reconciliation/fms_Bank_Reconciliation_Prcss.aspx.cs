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
using System.Threading;

public partial class FMS_FMS_Master_fms_Bank_Reconciliation_fms_Bank_Reconciliation_Prcss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsEntityCommon objEntityCommon = new clsEntityCommon();
         
          
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                // objEntity.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                //  objEntity.CorpId = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                //  objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

         


            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TAX_DEDCTD_ATSRCE);
            //DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            //if (dtChildRol.Rows.Count > 0)
            //{
            //    string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            //    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            //    foreach (string strC_Role in strChildDefArrWords)
            //    {
            //        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
            //        {
            //            intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //            //HiddenRoleConf.Value = "1";
            //        }
            //        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
            //        {
            //            intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //            //HiddenRoleUpd.Value = "1";
            //        }



            //    }
            //}


            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            lblEntry.Text = "BANK RECONCILIATION";
            if (Request.QueryString["Id"] != null)
            {
                string VOUCHERTYP = "0";
                if (Request.QueryString["VOUCHRTYP"] != null)
                {
                    VOUCHERTYP = Request.QueryString["VOUCHRTYP"].ToString();
                }
                
               // lblEntry.Text = "Edit Tax Deducted at Source";
                string status = "";

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;




                Update(strId, VOUCHERTYP);

            }
         



        }

    }

    public void Update(string strP_Id, string VOUCHERTYP)
    {
        clsEntityBankReconciliation objEntity = new clsEntityBankReconciliation();

        clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
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
        objEntity.LedgId = Convert.ToInt32(strP_Id);
        objEntity.VoucherTyp = Convert.ToInt32(VOUCHERTYP);
        HiddenVouchrTyp.Value = VOUCHERTYP;
        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma="";
        DataTable dtList = objBussiness.ReadBankReconciliationById(objEntity);
        HiddenRowCount.Value = dtList.Rows.Count.ToString();
        if (dtList.Rows.Count > 0)
        {
           // clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }



            sb.Append("<table class=\"list-group bg-grey\" style=\"width:100%\" id=\"TableVouchers\" >");
            for (int row1 = 0; row1 < dtList.Rows.Count; row1++)
            {


                if (dtList.Rows[row1]["TOTAL_AMNT"].ToString() != "")
                {
                    strNetAmount = dtList.Rows[row1]["TOTAL_AMNT"].ToString();
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    if (NetAmount < 0)
                    {
                        strsurAbrv = "CR";
                        NetAmount = -(NetAmount);
                    }
                    else
                        strsurAbrv = "DR";
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }


                sb.Append("<tr class=\"list-group-item\" id=\"SelectRow" + row1.ToString() + "\" >");
                sb.Append("<td class=\"smart-form\" id=\"tdRef" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["ID"].ToString() + " " + strsurAbrv + "</td>");

                sb.Append("<td class=\"smart-form\" id=\"tdSaleRef" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtList.Rows[row1]["REF"].ToString() + " <p style=\"font-size:19px;\"><span style=\"color:#258e25;font-weight:bold;\">" + strNetAmountWithComma + " </span>  </p></td>");

                sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtList.Rows[row1]["ID"].ToString() + "\" id=\"cbMandatory" + row1.ToString() + "\"><i  style=\"margin-top:-15%;\"></i></label></td>");
               
               // sb.Append("<td class=\"smart-form\" id=\"tdDate" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["SALES_DATE"].ToString() + "</td>");
             //   sb.Append("<td class=\"smart-form\" id=\"tdAmnt" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["SALES_NET_TOTAL"].ToString() + "</td>");
                // sb.Append("<td id="tdUsrId' + RowNum + '" style="display: none;">' + USRID + '</td>");
                sb.Append("</tr>");



            }
            sb.Append("</table>");
            divBank.InnerHtml = sb.ToString();
        
        }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {

        clsEntityBankReconciliation objEntity = new clsEntityBankReconciliation();

        clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
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

        if (HiddenVouchrTyp.Value != "")
        {
         objEntity.VoucherTyp=Convert.ToInt32(HiddenVouchrTyp.Value);
        }

        string strDtlId = "";
        string[] strarrdtlIds = strDtlId.Split(',');
        if (HiddenVouchers.Value != "" && HiddenVouchers.Value != null)
        {
            strDtlId = HiddenVouchers.Value;
            strarrdtlIds = strDtlId.Split(',');

        }
        objBussiness.SaveReconciliation(objEntity, strarrdtlIds);

    }
}