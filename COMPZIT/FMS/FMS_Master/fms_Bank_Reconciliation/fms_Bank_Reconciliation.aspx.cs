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
using System.IO;
using Newtonsoft.Json;

public partial class FMS_FMS_Master_fms_Bank_Reconciliation_fms_Bank_Reconciliation : System.Web.UI.Page
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
        ddlAccount.Focus();
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            string Strdatenow =   objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime ToDate =ObjCommonlib.textToDateTime(Strdatenow);
            txtFromdate.Value = ToDate.AddDays(-30).ToString("dd-MM-yyyy"); ;
            txtTodate.Value = DateTime.Now.ToString("dd-MM-yyyy"); 
           // LeadgerLoad();
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



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
            }



        }
    }

    public void LeadgerLoad()
    {
        clsEntityBankReconciliation ObjEntityRequest = new clsEntityBankReconciliation();

        clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLedger = objBussiness.ReadLeadger(ObjEntityRequest);

        if (dtLedger.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();

        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
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
            objEntity.VoucherTyp = Convert.ToInt32(HiddenVouchrTyp.Value);
        }

        string strDtlId = "";
        string[] strarrdtlIds = strDtlId.Split(',');
        if (HiddenVouchers.Value != "" && HiddenVouchers.Value != null)
        {
            strDtlId = HiddenVouchers.Value;
            strarrdtlIds = strDtlId.Split(',');

        }
       objBussiness.SaveReconciliation(objEntity, strarrdtlIds);

        Response.Redirect("fms_Bank_Reconciliation.aspx?InsUpd=Ins");

    }

    [WebMethod]
    public static string[] AccntDetailsById(string intAccntId, string intuserid, string intorgid, string intcorpid)
    {
        string[] result =new string[3] ;
        clsEntityBankReconciliation objEntity = new clsEntityBankReconciliation();

        clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        int corp = Convert.ToInt32(intcorpid);
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = corp;
        objEntity.LedgId = Convert.ToInt32(strId);
      //  objEntity.VoucherTyp = Convert.ToInt32(intVoucherTyp);
       // HiddenVouchrTyp.Value = VOUCHERTYP;
        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma = "";
        DataTable dtList = objBussiness.ReadBankReconciliationById(objEntity);
         result[0] = dtList.Rows.Count.ToString();
        if (dtList.Rows.Count > 0)
        {
            // clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, corp);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }



            sb.Append("<table class=\"display table-bordered\" style=\"width:100%\" id=\"TableVouchers\" >");
            sb.Append("<thead class=\"thead1\">");
            sb.Append(" <th class=\"col-md-1 td1\">REF#</th>");
            sb.Append("  </th>");
            sb.Append(" <th class=\"col-md-2\">VOUCHER TYPE");
            sb.Append("   </th>");
            sb.Append("  <th class=\"col-md-2 tr_r\">PAYMENT MODE");
            sb.Append("  </th>");
            sb.Append("   <th class=\"col-md-3 tr_c\">PAYMENT MODE#</th>");
            sb.Append("   </th>");
            sb.Append("   <th class=\"col-md-1 tr_c\">DATE</th>");
            sb.Append("   </th>");
            sb.Append(" <th class=\"col-md-1 tr_r\">CREDIT</th>");
            sb.Append(" </th>");
            sb.Append("  <th class=\"col-md-1 tr_r\">DEBIT</th>");
            sb.Append(" </th>");
            sb.Append("  <th class=\"col-md-1 tr_c\">Actions</th>");
            sb.Append("  </th>");
            sb.Append(" </tr>");
            sb.Append(" </thead>");
            sb.Append(" <tbody>");
           
            for (int row1 = 0; row1 < dtList.Rows.Count; row1++)
            {

                decimal NetAmount = 0;
                if (dtList.Rows[row1]["TOTAL_AMNT"].ToString() != "")
                {
                    strNetAmount = dtList.Rows[row1]["TOTAL_AMNT"].ToString();
                    NetAmount = Convert.ToDecimal(strNetAmount);
                    if (NetAmount < 0)
                    {
                        strsurAbrv = "CR";
                        NetAmount = -(NetAmount);
                    }
                    else
                        strsurAbrv = "DR";
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }

                string ModeNumber = "";

                if (dtList.Rows[row1]["PAYMNT_MODE"].ToString() == "CHEQUE")
                {
                    ModeNumber = dtList.Rows[row1]["CHQ_NUMBER"].ToString();
                }
                else if (dtList.Rows[row1]["PAYMNT_MODE"].ToString() == "DD")
                {
                    ModeNumber =  dtList.Rows[row1]["DD_NUMBER"].ToString();
                }
                else if (dtList.Rows[row1]["PAYMNT_MODE"].ToString() == "BANK TRANSFER")
                {
                    ModeNumber = dtList.Rows[row1]["BK_MODE"].ToString();
                }

                sb.Append("<tr id=\"SelectRow" + row1.ToString() + "\" class=\"tr1\" >");
                sb.Append("<td  id=\"tdRef" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["ID"].ToString() + " " + strsurAbrv + "</td>");
                sb.Append("<td  id=\"tdSaleRef" + row1.ToString() + "\" >" + dtList.Rows[row1]["REF"].ToString() + "</td>");
                    // he possible values are:-
                    //0. Receipt
                    //1. Payment
                    //2.Journal
                    //3.Credit Note
                    //4. Debit Note
                    //5.Sale
                    //6.Purchase
                string strVocherType = "";
                if (dtList.Rows[row1]["VOCHR_TYP"].ToString() == "0")
                {
                    strVocherType = "RECEIPT";
                }
                else if (dtList.Rows[row1]["VOCHR_TYP"].ToString() == "1")
                {
                    strVocherType = "PAYMENT";
                }
                else if (dtList.Rows[row1]["VOCHR_TYP"].ToString() == "2")
                {
                    strVocherType = "JOURNAL";
                }
                sb.Append("<td id=\"tdVoucherType" + row1.ToString() + "\" >" + strVocherType + "</td>");
                if (dtList.Rows[row1]["PAYMNT_MODE"].ToString() != "")
                {
                    sb.Append("<td  id=\"tdPaymentMode" + row1.ToString() + "\" >" + dtList.Rows[row1]["PAYMNT_MODE"].ToString() + "</td>");
                    sb.Append("<td  id=\"tdNumber" + row1.ToString() + "\" >" + ModeNumber + "</td>");
                }
                else
                {
                    sb.Append("<td  id=\"tdPaymentMode" + row1.ToString() + "\" ></td>");
                    sb.Append("<td  id=\"tdNumber" + row1.ToString() + "\" >"+ModeNumber+"</td>");
                }
                sb.Append("<td  id=\"tdDate" + row1.ToString() + "\">" + dtList.Rows[row1]["VOCHR_DATE"].ToString() + "</td>");

                if (dtList.Rows[row1]["VOCHR_STS"].ToString() == "DR")
                {
                    strNetAmount = dtList.Rows[row1]["TOTAL_AMNT"].ToString();
                    NetAmount = Convert.ToDecimal(strNetAmount);

                    if (NetAmount > 0)
                    {
                        strsurAbrv = "DR";
                       // NetAmount = -(NetAmount);
                    }
                    else
                    {
                        strsurAbrv = "CR";
                        //NetAmount = -(NetAmount);
                    }
                }
                else
                {
                    strNetAmount = dtList.Rows[row1]["TOTAL_AMNT"].ToString();
                    NetAmount = Convert.ToDecimal(strNetAmount);
                    if (-(NetAmount) < 0)
                    {
                        strsurAbrv = "CR";
                        //NetAmount = -(NetAmount);
                    }
                    else
                    {
                        strsurAbrv = "DR";
                        //NetAmount = -(NetAmount);
                    }

                }
                    if (strsurAbrv == "CR")
                    {
                        sb.Append("<td class=\"tr_r\" id=\"tdCredit" + row1.ToString() + "\" >" + strNetAmountWithComma + "</td>");
                        sb.Append("<td class=\"tr_r\" id=\"tdDebit" + row1.ToString() + "\" ></td>");
                    }
                    else
                    {
                        sb.Append("<td class=\"tr_r\" id=\"tdCredit" + row1.ToString() + "\" ></td>");
                        sb.Append("<td class=\"tr_r\" id=\"tdDebit" + row1.ToString() + "\" >" + strNetAmountWithComma + "</td>");
                    }

                sb.Append(" <td><div class=\"check1\"> ");
                sb.Append("<label class=\"switch\">");
                //sb.Append("<span class=\"button-checkbox\">");
                //sb.Append("<button type=\"button\" class=\"btn-d\" data-color=\"p\"></button>");
                sb.Append("<input type=\"checkbox\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtList.Rows[row1]["ID"].ToString() + "\" id=\"cbMandatory" + row1.ToString() + "\" />");
                sb.Append(" <span class=\"slider_tog round\"></span>");
               sb.Append("</label></td>");



                    //sb.Append("<td  > <label class=\"form1 mar_bo tr_c \" > <span class=\"button-checkbox\" ><button type=\"button\" class=\"btn-d\" ></button><input type=\"checkbox\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtList.Rows[row1]["ID"].ToString() + "\" id=\"cbMandatory" + row1.ToString() + "\"/></span></label></td>");

                // sb.Append("<td class=\"smart-form\" id=\"tdDate" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                //   sb.Append("<td class=\"smart-form\" id=\"tdAmnt" + row1.ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtList.Rows[row1]["SALES_NET_TOTAL"].ToString() + "</td>");
                // sb.Append("<td id="tdUsrId' + RowNum + '" style="display: none;">' + USRID + '</td>");
                sb.Append("</tr>");



            }
            sb.Append(" </tbody>");
            sb.Append("</table>");
            result[1] = sb.ToString();

        }

        return result;

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string Reopen_Reconciled(string StrId, string orgid, string corpid)
    {
        clsEntityBankReconciliation ObjEntityRequest = new clsEntityBankReconciliation();
        clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int flag = 0;
        string strRets = "successReCall";
        string strRandomMixedId = StrId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.LedgId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(orgid);
        //ObjEntityRequest.VoucherTyp = Convert.ToInt32(intVoucherTyp);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(corpid);
        try
        {
            objBussiness.Recall_Reconciled(ObjEntityRequest);
        }
        catch
        {
            strRets = "failed";
        }
        HttpContext.Current.Session["SuccessMsg"] = strRets;
        return strRets;
    }
}