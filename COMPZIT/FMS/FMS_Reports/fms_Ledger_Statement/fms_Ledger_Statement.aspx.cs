using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class FMS_FMS_Reports_fms_Ledger_Statement_fms_Ledger_Statement : System.Web.UI.Page
{

    clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
    clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            LoadAccountGroup();
            LoadLedgers();
            LoadCodes();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLedgerStatmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = objEntityLedgerStatmnt.CorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Request.QueryString["Corpid"] != null)
            {
                string strRandomMixedId = Request.QueryString["Corpid"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strCorpId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityLedgerStatmnt.CorpId = Convert.ToInt32(strCorpId);
                intCorpId = objEntityLedgerStatmnt.CorpId;
            }

            if (Session["ORGID"] != null)
            {
                objEntityLedgerStatmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            hiddenDate.Value = objBusiness.LoadCurrentDate().ToString("dd-MM-yyyy");

            objEntityCommon.CorporateID = objEntityLedgerStatmnt.CorpId;
            objEntityCommon.Organisation_Id = objEntityLedgerStatmnt.OrgId;

            hiddenCorpId.Value = objEntityLedgerStatmnt.CorpId.ToString();

            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Request.QueryString["Corpid"] != null)
            {
                if (Session["ORGID"] != null)
                {
                    objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                DataTable dtfinaclYear1 = objBusiness.ReadFinancialYear(objEntityCommon);
                if (dtfinaclYear1.Rows.Count > 0)
                {
                    if (dtfinaclYear1.Rows[0]["FINCYR_ID"].ToString() != "")
                    {
                        objEntityCommon.FinancialYrId = Convert.ToInt32(dtfinaclYear1.Rows[0]["FINCYR_ID"].ToString());
                    }
                }
                else
                {
                    DataTable dtCorpDetail1 = new DataTable();
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer1 = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetail1 = objBusiness.LoadGlobalDetail(arrEnumer1, intCorpId);
                    if (dtCorpDetail1.Rows.Count > 0)
                    {
                        if (dtCorpDetail1.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            objEntityCommon.FinancialYrId = Convert.ToInt32(dtCorpDetail1.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }
            }

            DateTime CurrntDate = objCommon.textToDateTime(hiddenDate.Value);

            DataTable dtfinaclYear = objBusiness.ReadFinancialYearById(objEntityCommon);

            HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
            HiddenEndDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

            if (CurrntDate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && CurrntDate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
            {
                txtTodate.Value = DateTime.Now.ToString("dd-MM-yyyy");
                if (CurrntDate.AddDays(-30) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                {
                    txtFromdate.Value = CurrntDate.AddDays(-30).ToString("dd-MM-yyyy");
                }
                else
                {
                    txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                }
            }
            else
            {
                CurrntDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                txtFromdate.Value = CurrntDate.AddDays(-30).ToString("dd-MM-yyyy");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                                    clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS ,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE 
                                                        };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDefaultCrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenCodeStatus.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();
                HiddenFieldDecmlCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

                if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                {
                    HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                }
            }

            if (radioDetail.Checked == true)
            {
                objEntityLedgerStatmnt.Mode = 0;
            }
            else
            {
                objEntityLedgerStatmnt.Mode = 1;
            }

            if (hiddenLedgerIds.Value != "")
            {
                objEntityLedgerStatmnt.LedgerIds = hiddenLedgerIds.Value.TrimEnd(',', ' ');
            }
            else
            {
                objEntityLedgerStatmnt.LedgerIds = "''";
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLedgerStatmnt.LedgerIds = strId;
                hiddenLedgerIds.Value = strId;
            }

            if (txtFromdate.Value != "")
            {
                objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(txtFromdate.Value);
            }
            if (txtTodate.Value != "")
            {
                objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(txtTodate.Value);
            }
            if (txtLedgerRangeFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLedgerStatmnt.LedgerFromRange = Convert.ToInt32(txtLedgerRangeFrom.SelectedItem.Value);
            }
            if (txtLedgerRangeTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLedgerStatmnt.LedgerToRange = Convert.ToInt32(txtLedgerRangeTo.SelectedItem.Value);
            }

            if (txtH1RangeFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLedgerStatmnt.H1LedgerFromRange = Convert.ToInt32(txtH1RangeFrom.SelectedItem.Value);
            }
            if (txtH1RangeTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLedgerStatmnt.H1LedgerToRange = Convert.ToInt32(txtH1RangeTo.SelectedItem.Value);
            }

            if (txtH2RangeFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLedgerStatmnt.H2LedgerFromRange = Convert.ToInt32(txtH2RangeFrom.SelectedItem.Value);
            }
            if (txtH2RangeTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLedgerStatmnt.H2LedgerToRange = Convert.ToInt32(txtH2RangeTo.SelectedItem.Value);
            }

            if (txtCCCodeRangeFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLedgerStatmnt.CCFromRange = Convert.ToInt32(txtCCCodeRangeFrom.SelectedItem.Value);
            }
            if (txtCCCodeRangeTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLedgerStatmnt.CCToRange = Convert.ToInt32(txtCCCodeRangeTo.SelectedItem.Value);
            }
            if (ddlParentGroup.SelectedItem.Value != "" && ddlParentGroup.SelectedItem.Value != "--SELECT GROUP--")
            {
                objEntityLedgerStatmnt.AccountGrpId = Convert.ToInt32(ddlParentGroup.SelectedItem.Value.ToString());
            }
            if (cbxExtngSplr.Checked)
            {
                objEntityLedgerStatmnt.AllLedgersStatus = 1;
            }
            else
            {
                objEntityLedgerStatmnt.AllLedgersStatus = 0;
            }

            if (cbxSubLedgerSts.Checked == true)
            {
                objEntityLedgerStatmnt.SubLedgerStatus = 1;
            }
            else
            {
                objEntityLedgerStatmnt.SubLedgerStatus = 0;
            }

            DataTable dtMain = objBusinessLedgerStatmnt.ReadLedgerStatementMain(objEntityLedgerStatmnt);

            string strHtm = "";
            if (objEntityLedgerStatmnt.Mode == 0)
            {
                strHtm = ConvertDataTableToHTMLDetail(dtMain, 0);
            }
            else
            {
                strHtm = ConvertDataTableToHTMLSummary(dtMain, 0);
            }
            divReport.InnerHtml = strHtm;
            if (objEntityLedgerStatmnt.Mode == 0)
            {
                divPrintReport.InnerHtml = ConvertDataTableToHTMLDetail(dtMain, 1);
            }
            else
            {
                divPrintReport.InnerHtml = ConvertDataTableToHTMLSummary(dtMain, 1);
            }

            cbxExtngSplr.Focus();
        }
    }
    
    public void LoadAccountGroup()
    {
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntity.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntity.Corp_Id = intCorpId;
            objEntityCommon.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;
            objEntityCommon.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccountGrp = objBusiness.ReadAccountGrps(objEntityCommon);
        if (dtAccountGrp.Rows.Count > 0)
        {
            ddlParentGroup.DataSource = dtAccountGrp;
            ddlParentGroup.DataTextField = "ACNT_GRP_NAME";
            ddlParentGroup.DataValueField = "ACNT_GRP_ID";
            ddlParentGroup.DataBind();
        }
        ddlParentGroup.Items.Insert(0, "--SELECT GROUP--");

    }
    
    public void LoadLedgers()
    {
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedgerStatmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Corpid"] != null)
        {
            string strRandomMixedId = Request.QueryString["Corpid"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strCorpId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityLedgerStatmnt.CorpId = Convert.ToInt32(strCorpId);
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedgerStatmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (cbxSubLedgerSts.Checked == true)
        {
            objEntityLedgerStatmnt.SubLedgerStatus = 1;
        }
        else
        {
            objEntityLedgerStatmnt.SubLedgerStatus = 0;
        }

        DataTable dtLedger = objBusinessLedgerStatmnt.ReadLedgers(objEntityLedgerStatmnt);
        if (dtLedger.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }

        //if (hiddenLedgerIds.Value != "")
        //{
        //    foreach (string str in hiddenLedgerIds.Value.Split(','))
        //    {
        //        if (str != "")
        //        {
        //            if (ddlLedger.Items.FindByValue(str) != null)
        //            {
        //                ddlLedger.Items.FindByValue(str).Selected = true;
        //            }
        //        }
        //    }
        //}

    }

    public void LoadCodes()
    {
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedgerStatmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedgerStatmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCode = new DataTable();

        objEntityLedgerStatmnt.CodeType = 0;
        dtCode = objBusinessLedgerStatmnt.ReadCodes(objEntityLedgerStatmnt);

        txtLedgerRangeFrom.Items.Clear();
        txtLedgerRangeTo.Items.Clear();
        if (dtCode.Rows.Count > 0)
        {
            txtLedgerRangeFrom.DataSource = dtCode;
            txtLedgerRangeFrom.DataTextField = "LDGR_CODE";
            txtLedgerRangeFrom.DataValueField = "LDGR_CODE";
            txtLedgerRangeFrom.DataBind();

            txtLedgerRangeTo.DataSource = dtCode;
            txtLedgerRangeTo.DataTextField = "LDGR_CODE";
            txtLedgerRangeTo.DataValueField = "LDGR_CODE";
            txtLedgerRangeTo.DataBind();
        }
        txtLedgerRangeFrom.Items.Insert(0, "--SELECT FROM--");
        txtLedgerRangeTo.Items.Insert(0, "--SELECT TO--");

        objEntityLedgerStatmnt.CodeType = 1;
        dtCode = objBusinessLedgerStatmnt.ReadCodes(objEntityLedgerStatmnt);

        txtH1RangeFrom.Items.Clear();
        txtH1RangeTo.Items.Clear();
        if (dtCode.Rows.Count > 0)
        {
            txtH1RangeFrom.DataSource = dtCode;
            txtH1RangeFrom.DataTextField = "COSTGRP_CODE";
            txtH1RangeFrom.DataValueField = "COSTGRP_CODE";
            txtH1RangeFrom.DataBind();

            txtH1RangeTo.DataSource = dtCode;
            txtH1RangeTo.DataTextField = "COSTGRP_CODE";
            txtH1RangeTo.DataValueField = "COSTGRP_CODE";
            txtH1RangeTo.DataBind();
        }
        txtH1RangeFrom.Items.Insert(0, "--SELECT FROM--");
        txtH1RangeTo.Items.Insert(0, "--SELECT TO--");

        objEntityLedgerStatmnt.CodeType = 2;
        dtCode = objBusinessLedgerStatmnt.ReadCodes(objEntityLedgerStatmnt);

        txtH2RangeFrom.Items.Clear();
        txtH2RangeTo.Items.Clear();
        if (dtCode.Rows.Count > 0)
        {
            txtH2RangeFrom.DataSource = dtCode;
            txtH2RangeFrom.DataTextField = "COSTGRP_CODE";
            txtH2RangeFrom.DataValueField = "COSTGRP_CODE";
            txtH2RangeFrom.DataBind();

            txtH2RangeTo.DataSource = dtCode;
            txtH2RangeTo.DataTextField = "COSTGRP_CODE";
            txtH2RangeTo.DataValueField = "COSTGRP_CODE";
            txtH2RangeTo.DataBind();
        }
        txtH2RangeFrom.Items.Insert(0, "--SELECT FROM--");
        txtH2RangeTo.Items.Insert(0, "--SELECT TO--");

        objEntityLedgerStatmnt.CodeType = 3;
        dtCode = objBusinessLedgerStatmnt.ReadCodes(objEntityLedgerStatmnt);

        txtCCCodeRangeFrom.Items.Clear();
        txtCCCodeRangeTo.Items.Clear();
        if (dtCode.Rows.Count > 0)
        {
            txtCCCodeRangeFrom.DataSource = dtCode;
            txtCCCodeRangeFrom.DataTextField = "COSTCNTR_CODE";
            txtCCCodeRangeFrom.DataValueField = "COSTCNTR_CODE";
            txtCCCodeRangeFrom.DataBind();

            txtCCCodeRangeTo.DataSource = dtCode;
            txtCCCodeRangeTo.DataTextField = "COSTCNTR_CODE";
            txtCCCodeRangeTo.DataValueField = "COSTCNTR_CODE";
            txtCCCodeRangeTo.DataBind();
        }
        txtCCCodeRangeFrom.Items.Insert(0, "--SELECT FROM--");
        txtCCCodeRangeTo.Items.Insert(0, "--SELECT TO--");

    }

    //detail table
    public string ConvertDataTableToHTMLDetail(DataTable dt, int Print)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCrncyId.Value);

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"datatable_fixed_column\" class=\"table-bordered\" width=\"100%\">");

        sb.Append("<thead class=\"thead1\">");
        sb.Append("<tr>");

        sb.Append("<th class=\"th_b6 tr_c\" >DATE ");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"DATE\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b3 tr_l\" >PARTICULARS");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"PARTICULARS\" type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b2 tr_l\" >REF#");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"REFERENCE NUMBER\" type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b4 tr_c\" >VOUCHER TYPE");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"VOUCHER TYPE\" type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b6 tr_r\" >DEBIT");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b6 tr_r\" >CREDIT");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b2 tr_r\" >CLOSING BALANCE");
        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CLOSING BALANCE\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"th_b11 tr_l\">Narration");
        sb.Append("</th>");

        sb.Append("</tr>");

        sb.Append("</thead>");

        sb.Append("<tbody>");

        decimal decPrevsAmnt = 0;

        decimal decTotalDebit = 0;
        decimal decTotalCredit = 0;
        decimal decTotalClosing = 0;

        decimal decSubLdgrDebit = 0;
        decimal decSubLdgrCredit = 0;
        decimal decSubLdgrClosing = 0;
        int RecordsCnt = 0;
        string SubLedgerName = "";
        int GrpCnt = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string LedgerName = dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
            objEntityLedgerStatmnt.Ledger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_ID"].ToString());

            int SubLedger = 0;
            if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
            {
                SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
            }

            //Subledger grouping

            int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

            if (cbxSubLedgerSts.Checked == true && RecordsCnt == 0)
            {
                string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                SubLedgerName = SubLedgerNm;
                if (GrpCnt % 2 == 0)
                {
                    sb.Append("<tr class=\"tr_grp_odd\">");
                }
                else
                {
                    sb.Append("<tr class=\"tr_grp_even\">");
                }
                sb.Append("<th class=\"tr_c\" ></th>");
                sb.Append("<th class=\"tr_l\">" + SubLedgerNm + "</th>");
                sb.Append("<th class=\"tr_l\" ></th>");
                sb.Append("<th class=\"tr_c\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_l\" ></th>");
                sb.Append("</tr>");

                decSubLdgrDebit = 0;
                decSubLdgrCredit = 0;
                decSubLdgrClosing = 0;
            }

            string strStyle = "";
            if (RecordsCnt != 0)
            {
                strStyle = "padding-left: " + (Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LEVEL"].ToString()) * 30) + "px!important;";
            }

            if (numberOfRecords > 1)
            {
                RecordsCnt++;
            }

            //Heading
            sb.Append("<tr class=\"tr1\">");
            sb.Append("<th class=\"tr_c\" ></th>");
            sb.Append("<th class=\"tr_l txt_blu\" style=\"" + strStyle + "\" >" + LedgerName + "</th>");
            sb.Append("<th class=\"tr_l\" ></th>");
            sb.Append("<th class=\"tr_c\" ></th>");
            sb.Append("<th class=\"tr_r\" ></th>");
            sb.Append("<th class=\"tr_r\" ></th>");
            sb.Append("<th class=\"tr_r\" ></th>");
            sb.Append("<th class=\"tr_l\" ></th>");
            sb.Append("</tr>");

            //Opening Balance
            decimal OpengBal = 0;
            sb.Append("<tr>");

            DataTable dtPostDate = objBusinessLedgerStatmnt.ReadPostdatedChqDtls(objEntityLedgerStatmnt);//Postdated chq
            if (dtPostDate.Rows.Count > 0)
            {
                sb.Append("<td class=\"tr_c\" ><span href=\"javascript:;\" class=\"ad_pst\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay(" + objEntityLedgerStatmnt.Ledger + ");\"><i class=\"fa fa-list-alt ad_fa ad_fa1 ad_posd\"></i></span><br></td>");
            }
            else
            {
                sb.Append("<td class=\"tr_c\" ></td>");
            }
            sb.Append("<td class=\"tr_r txt_blu\"  >Opening Balance</td>");
            sb.Append("<td class=\"tr_l\"  ></td>");
            sb.Append("<td class=\"tr_l\"  ></td>");

            OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
            if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
            {
                string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                sb.Append("<td class=\"tr_r\" ></td>");
                sb.Append("<td class=\"tr_r txt_blu\"  >" + strOpenNetAmountWithComma + "</td>");
            }
            else
            {
                string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                sb.Append("<td class=\"tr_r txt_blu\"  >" + strOpenNetAmountWithComma + "</td>");
                sb.Append("<td class=\"tr_r\"  ></td>");
            }

            string strNetAmountWithCommaOpen = "";
            if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) >= 0)
            {
                strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon) + " DR";
            }
            else
            {
                strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon) + " CR";
            }
            sb.Append("<td class=\"tr_r txt_blu\"  >" + strNetAmountWithCommaOpen + "</td>");
            sb.Append("<td class=\"tr_l\" ></th>");
            sb.Append("</tr>");

            decPrevsAmnt = OpengBal;

            //------------------------ledger details----------------------

            DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStatmnt);

            string VouchrAcntId = "";

            for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
            {
                objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_ID"].ToString());

                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strRandom = objCommon.Random_Number();
                string strId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
                int intIdLength = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                //cost center
                DataTable dtCCDtls = objBusinessLedgerStatmnt.ReadLedgerStatementCostCentreDtls(objEntityLedgerStatmnt);

                sb.Append("<td class=\"tr_c\"> " + dtDtls.Rows[intRow]["VOCHR_DATE"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" > " + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<br/>");
                if (dtCCDtls.Rows.Count > 0)
                {
                    sb.Append("<a href=\"javascript:;\" class=\"pull-right ad_cc1 js-open-modal\" title=\"Cost Centre\" onclick=\"return CostCentreDisplay('" + objEntityLedgerStatmnt.VoucherId + "');\"><i class=\"fa fa-filter ad_fa _ldr\">CC</i></a>");
                }

                //0039
                objEntityLedgerStatmnt.VoucherAccId = Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString());
                DataTable dt34 = objBusinessLedgerStatmnt.Readvoucherinfo(objEntityLedgerStatmnt);

                if (dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString() == "5" || dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString() == "6")
                {
                    if (dt34.Rows.Count > 0)
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"pull-right js-open-modal\"  data-toggle=\"modal\" data-target=\"#Modal_method4\" title=\"Transaction details\" onclick=\"return CheckInfo('" + dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() + "');\"><i class=\"fa fa-file-text ad_fa18 mar_dtl\" aria-hidden=\"true\"></i></a");
                    }
                } 
                //end

                if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count for journal/credit note/debit note(as per details present or not)
                {
                    sb.Append("<a onclick=\"return DivDisplay(" + intRow + "," + objEntityLedgerStatmnt.Ledger + "," + dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() + "," + dtDtls.Rows[intRow]["VOCHR_ID"].ToString() + ");\" class=\"pull-right apd1\" title=\"As Per Details\" style=\"cursor:pointer;\" ><i class=\"fa fa-newspaper-o ad_fa ad_fa1 mar_dtl\"></i> </a><br/>");
                    sb.Append("<div id=\"divAsPerDtls" + objEntityLedgerStatmnt.Ledger + intRow + "\" class=\"divCls collapse det_a d_a1\" ></div>");
                }
                sb.Append("</td>");
                sb.Append("<td class=\"tr_l\"  >" + "<a title=\"Click to view\" href=\"javascript:;\" onclick=\"return LinkClick('" + Id + "','" + dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString() + "');\" style=\"color:#0058a3;text-align:center\">" + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + "" + "</a></td>");

                sb.Append("<td class=\"tr_c\"  > " + dtDtls.Rows[intRow]["VOCHR_TYP"].ToString() + "</td>");

                string strDebitAmount = "";
                strDebitAmount = dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString();
                string strNetAmountWithCommaDebit = "";
                if (strDebitAmount != "")
                {
                    strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(strDebitAmount, objEntityCommon);
                }
                sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaDebit + "</td>");

                string strCreditAmount = "";
                strCreditAmount = dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString();
                string strNetAmountWithCommaCredit = "";
                if (strCreditAmount != "")
                {
                    strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation((0 - Convert.ToDecimal(strCreditAmount)).ToString(), objEntityCommon);
                }
                sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaCredit + "</td>");

                decimal Debit = 0;
                if (strDebitAmount != "")
                {
                    Debit = Convert.ToDecimal(strDebitAmount);
                }
                decimal Credit = 0;
                if (strCreditAmount != "")
                {
                    Credit = Convert.ToDecimal(strCreditAmount);
                }
                decTotalCredit += Credit;
                decTotalDebit += Debit;

                decimal Closing = 0;
                Closing = Debit + Credit + decPrevsAmnt;
                decTotalClosing += Closing;

                string strNetAmountWithCommaClose = "";
                if (Closing >= 0)
                {
                    strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation(Closing.ToString(), objEntityCommon) + " DR";
                }
                else
                {
                    strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation((0 - Closing).ToString(), objEntityCommon) + " CR";
                }
                sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaClose + "</td>");
                decPrevsAmnt = Closing;

                sb.Append("<td class=\"tr_l\" >" + dtDtls.Rows[intRow]["VOCHR_DSCRPTN"].ToString() + "</th>");

                sb.Append("</tr>");

                VouchrAcntId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
            }

            //------------------------ledger details----------------------

            //total amount

            if (OpengBal >= 0)
            {
                decTotalDebit = decTotalDebit + OpengBal;
            }
            else
            {
                decTotalCredit = decTotalCredit + OpengBal;
            }
            decTotalClosing = decTotalDebit + decTotalCredit;

            string strNetAmountWithCommaTotalDebit = "0";
            if (decTotalDebit != 0)
            {
                strNetAmountWithCommaTotalDebit = objBusiness.AddCommasForNumberSeperation(decTotalDebit.ToString(), objEntityCommon);
            }

            string strNetAmountWithCommaTotalCredit = "0";
            if (decTotalCredit != 0)
            {
                strNetAmountWithCommaTotalCredit = objBusiness.AddCommasForNumberSeperation((0 - decTotalCredit).ToString(), objEntityCommon);
            }

            string strNetAmountWithComma = "";
            if (decPrevsAmnt >= 0)
            {
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon) + " DR";
            }
            else
            {
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon) + " CR";
            }

            sb.Append("<tr>");
            sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
            sb.Append("<td class=\"tr_r txt_rd bg1\" >Total Balance</th>");
            sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
            sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
            sb.Append("<td class=\"tr_r txt_gr bg1\" >" + strNetAmountWithCommaTotalDebit + " DR</th>");
            sb.Append("<td class=\"tr_r txt_rd bg1\" >" + strNetAmountWithCommaTotalCredit + " CR</th>");
            if (decPrevsAmnt >= 0)
            {
                sb.Append("<td class=\"tr_r txt_gr bg1\" >" + strNetAmountWithComma + "</th>");
            }
            else
            {
                sb.Append("<td class=\"tr_r txt_rd bg1\" >" + strNetAmountWithComma + "</th>");
            }
            sb.Append("<td class=\"tr_l txt_rd bg1\" ></th>");
            sb.Append("</tr>");

            //Subledger grouping amnt

            decSubLdgrDebit += decTotalDebit;
            decSubLdgrCredit += decTotalCredit;
            decSubLdgrClosing += decTotalClosing;

            if (cbxSubLedgerSts.Checked == true && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
            {
                if (GrpCnt % 2 == 0)
                {
                    sb.Append("<tr class=\"tr_grp_odd\">");
                }
                else
                {
                    sb.Append("<tr class=\"tr_grp_even\">");
                }
                sb.Append("<th class=\"tr_c\" ></th>");
                sb.Append("<th class=\"tr_l\">" + SubLedgerName + "</th>");
                sb.Append("<th class=\"tr_l\" ></th>");
                sb.Append("<th class=\"tr_c\" ></th>");

                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";

                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");

                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrCredit).ToString(), objEntityCommon) + " CR";

                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");

                if (decSubLdgrClosing >= 0)
                {
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                    sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");
                }
                else
                {
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                    sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");
                }
                sb.Append("<td class=\"tr_l\" ></th>");
                sb.Append("</tr>");

                RecordsCnt = 0;
                GrpCnt++;
            }

            decTotalCredit = 0;
            decTotalDebit = 0;
            decPrevsAmnt = 0;
        }

        sb.Append("</tbody>");

        sb.Append("</table>");

        string str = sb.ToString();

        return sb.ToString();
    }
    public string ConvertDataTableToHTMLDetail_PDF(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        string strRet = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int Decimalcount = 0, intCorpId = 0;
        intCorpId = Convert.ToInt32(CorpId);
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
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string strRandom = objCommon.Random_Number();

        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);
        objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(datefrom);
        objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(dateto);

        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.LEDGER_STATEMENT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_STATEMENT_PDF);
        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "LedgerStatmntDetail" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                //filter section
                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 25, 5, 70 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(datefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DETAILED", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SUMMARY", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                
                if (Ledgers != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("LEDGERS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(Ledgers.TrimEnd(',', ' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("ALL LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (AllLedgerSts == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("YES", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("NO", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                if (AccntGroup != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AccntGroup, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (LedgerRangeFrom != "" || LedgerRangeTo != "")
                {
                    if (LedgerRangeFrom == "")
                    {
                        LedgerRangeFrom = "0";
                    }
                    if (LedgerRangeTo == "")
                    {
                        LedgerRangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("LEDGER CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(LedgerRangeFrom + " - " + LedgerRangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (H1RangeFrom != "" || H1RangeTo != "")
                {
                    if (H1RangeFrom == "")
                    {
                        H1RangeFrom = "0";
                    }
                    if (H1RangeTo == "")
                    {
                        H1RangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("HIERARCHY 1 CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(H1RangeFrom + " - " + H1RangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (H2RangeFrom != "" || H2RangeTo != "")
                {
                    if (H2RangeFrom == "")
                    {
                        H2RangeFrom = "0";
                    }
                    if (H2RangeTo == "")
                    {
                        H2RangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("HIERARCHY 2 CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(H2RangeFrom + " - " + H2RangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (CCCodeRangeFrom != "" || CCCodeRangeTo != "")
                {
                    if (CCCodeRangeFrom == "")
                    {
                        CCCodeRangeFrom = "0";
                    }
                    if (CCCodeRangeTo == "")
                    {
                        CCCodeRangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("CC CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CCCodeRangeFrom + " - " + CCCodeRangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("INCLUDE SUB-LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (SubLedgerSts == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("YES", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 8 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("NO", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 8 });
                }

                document.Add(footrtable);

                PdfPTable TBCustomer = new PdfPTable(8);
                float[] footrsBody = { 10, 20, 10, 10, 10, 10, 15, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);
                var FontSmallBlue = new BaseColor(220, 224, 230);
                var FontSmallViolet = new BaseColor(226, 220, 230);
                var FontDark = new BaseColor(196, 197, 207);
                var FontLight = new BaseColor(196, 206, 207);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("VOUCHER TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CLOSING BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("NARRATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                decimal decPrevsAmnt = 0;

                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;
                decimal decTotalClosing = 0;

                decimal decSubLdgrDebit = 0;
                decimal decSubLdgrCredit = 0;
                decimal decSubLdgrClosing = 0;
                int RecordsCnt = 0;
                string SubLedgerName = "";
                int GrpCnt = 0;

                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    string LedgerName = dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
                    objEntityLedgerStatmnt.Ledger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_ID"].ToString());

                    int SubLedger = 0;
                    if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
                    {
                        SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
                    }

                    //Subledger grouping

                    int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

                    if (SubLedgerSts == "1" && RecordsCnt == 0)
                    {
                        string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                        SubLedgerName = SubLedgerNm;

                        var strColour = FontDark;
                        if (GrpCnt % 2 == 0)
                        {
                            strColour = FontDark;
                        }

                        TBCustomer.AddCell(new PdfPCell(new Phrase(SubLedgerNm, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = strColour, BorderColor = FontGray, Colspan = 8, Padding = 5 });

                        decSubLdgrDebit = 0;
                        decSubLdgrCredit = 0;
                        decSubLdgrClosing = 0;
                    }

                    int intStyle = 0;
                    if (RecordsCnt != 0)
                    {
                        intStyle = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LEVEL"].ToString()) * 30;
                    }

                    if (numberOfRecords > 1)
                    {
                        RecordsCnt++;
                    }

                    //Heading
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallBlue, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(LedgerName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallBlue, BorderColor = FontGray, PaddingRight = intStyle, Colspan = 7 });

                    //Opening Balance
                    decimal OpengBal = 0;

                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Opening Balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray ,PaddingRight = 2, });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
                    if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
                    {
                        string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strOpenNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strOpenNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }

                    string strNetAmountWithCommaOpen = "";
                    if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) >= 0)
                    {
                        strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon) + " DR";
                    }
                    else
                    {
                        strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon) + " CR";
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaOpen, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    decPrevsAmnt = OpengBal;

                    //------------------------ledger details----------------------

                    DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStatmnt);

                    string VouchrAcntId = "";

                    for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
                    {
                        objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_ID"].ToString());

                        string strId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
                        int intIdLength = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtDtls.Rows[intRow]["VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        PdfPTable TBCustomerAsPrDtls = new PdfPTable(2);
                        float[] footrsBodyAsPrDtls = { 60, 40 };
                        TBCustomerAsPrDtls.SetWidths(footrsBodyAsPrDtls);
                        TBCustomerAsPrDtls.WidthPercentage = 100;

                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(dtDtls.Rows[intRow]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 2, BorderColor = iTextSharp.text.BaseColor.WHITE });
                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 2, BorderColor = iTextSharp.text.BaseColor.WHITE });

                        //opposite ledger count for journal/credit note/debit note(as per details present)
                        if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)
                        {
                            int flag = 0;
                            StringBuilder sbPop = new StringBuilder();

                            objEntityLedgerStatmnt.VoucherAccntId = Convert.ToInt32(strId);
                            DataTable dtPrintDtls = objBusinessLedgerStatmnt.ReadLedgerStatementAsPerDtls(objEntityLedgerStatmnt);

                            for (int intRowDtls = 0; intRowDtls < dtPrintDtls.Rows.Count; intRowDtls++)
                            {
                                if (dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "" || dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
                                {

                                    if (dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "")
                                    {
                                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(dtPrintDtls.Rows[intRowDtls]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, BorderColor = iTextSharp.text.BaseColor.WHITE });
                                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() + " DR", FontFactory.GetFont("Calibri", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, BorderColor = iTextSharp.text.BaseColor.WHITE });
                                    }
                                    if (dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
                                    {
                                        decimal CrdtAmnt = 0 - Convert.ToDecimal(dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString());
                                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(dtPrintDtls.Rows[intRowDtls]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, BorderColor = iTextSharp.text.BaseColor.WHITE });
                                        TBCustomerAsPrDtls.AddCell(new PdfPCell(new Phrase(CrdtAmnt.ToString() + "CR", FontFactory.GetFont("Calibri", 7, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, BorderColor = iTextSharp.text.BaseColor.WHITE });
                                    }
                                    flag++;
                                }
                            }
                        }

                        TBCustomer.AddCell(TBCustomerAsPrDtls);

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtDtls.Rows[intRow]["VOCHR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtDtls.Rows[intRow]["VOCHR_TYP"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        string strDebitAmount = "";
                        strDebitAmount = dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString();
                        string strNetAmountWithCommaDebit = "";
                        if (strDebitAmount != "")
                        {
                            strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(strDebitAmount, objEntityCommon);
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaDebit, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        string strCreditAmount = "";
                        strCreditAmount = dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString();
                        string strNetAmountWithCommaCredit = "";
                        if (strCreditAmount != "")
                        {
                            strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation((0 - Convert.ToDecimal(strCreditAmount)).ToString(), objEntityCommon);
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaCredit, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        decimal Debit = 0;
                        if (strDebitAmount != "")
                        {
                            Debit = Convert.ToDecimal(strDebitAmount);
                        }
                        decimal Credit = 0;
                        if (strCreditAmount != "")
                        {
                            Credit = Convert.ToDecimal(strCreditAmount);
                        }
                        decTotalCredit += Credit;
                        decTotalDebit += Debit;

                        decimal Closing = 0;
                        Closing = Debit + Credit + decPrevsAmnt;
                        decTotalClosing += Closing;

                        string strNetAmountWithCommaClose = "";
                        if (Closing >= 0)
                        {
                            strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation(Closing.ToString(), objEntityCommon) + " DR";
                        }
                        else
                        {
                            strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation((0 - Closing).ToString(), objEntityCommon) + " CR";
                        }

                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaClose, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        decPrevsAmnt = Closing;

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtDtls.Rows[intRow]["VOCHR_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        VouchrAcntId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
                    }

                    //------------------------ledger details----------------------

                    //total amount

                    if (OpengBal >= 0)
                    {
                        decTotalDebit = decTotalDebit + OpengBal;
                    }
                    else
                    {
                        decTotalCredit = decTotalCredit + OpengBal;
                    }
                    decTotalClosing = decTotalDebit + decTotalCredit;

                    string strNetAmountWithCommaTotalDebit = "0";
                    if (decTotalDebit != 0)
                    {
                        strNetAmountWithCommaTotalDebit = objBusiness.AddCommasForNumberSeperation(decTotalDebit.ToString(), objEntityCommon);
                    }

                    string strNetAmountWithCommaTotalCredit = "0";
                    if (decTotalCredit != 0)
                    {
                        strNetAmountWithCommaTotalCredit = objBusiness.AddCommasForNumberSeperation((0 - decTotalCredit).ToString(), objEntityCommon);
                    }

                    string strNetAmountWithComma = "";
                    if (decPrevsAmnt >= 0)
                    {
                        strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon) + " DR";
                    }
                    else
                    {
                        strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon) + " CR";
                    }

                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total Balance", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaTotalDebit + " DR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaTotalCredit + " CR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });


                    if (decPrevsAmnt >= 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });


                    //Subledger grouping amnt

                    decSubLdgrDebit += decTotalDebit;
                    decSubLdgrCredit += decTotalCredit;
                    decSubLdgrClosing += decTotalClosing;

                    if (SubLedgerSts == "1" && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(SubLedgerName, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrCredit).ToString(), objEntityCommon) + " CR";
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        if (decSubLdgrClosing >= 0)
                        {
                            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        }
                        else
                        {
                            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        RecordsCnt = 0;
                        GrpCnt++;
                    }

                    decTotalCredit = 0;
                    decTotalDebit = 0;
                    decPrevsAmnt = 0;
                }

                if (dt.Rows.Count == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
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
    public string ConvertDataTableToHTMLDetail_CSV(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dtList = GetTableListDetail(dt, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
        string strResult = DataTableToCSV(dtList, ',');

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_STATEMENT_CSV);

        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "LedgerStatmntDetail" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.LEDGER_STATEMENT_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableListDetail(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int Decimalcount = 0, intCorpId = 0;
        intCorpId = Convert.ToInt32(CorpId);
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
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        int precision = Convert.ToInt32(Decimalcount);
        string format = String.Format("{{0:N{0}}}", precision);

        string strRandom = objCommon.Random_Number();

        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);
        objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(datefrom);
        objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(dateto);

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("LEDGER STATEMENT", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Columns.Add("      ", typeof(string));
        table.Columns.Add("       ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "FROM DATE :" + '"', '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "TO DATE :" + '"', '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (Mode == "0")
        {
            table.Rows.Add('"' + "MODE :" + '"', '"' + "DETAILED" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "MODE :" + '"', '"' + "SUMMARY" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (Ledgers != "")
        {
            table.Rows.Add('"' + "LEDGERS :" + '"', '"' + Ledgers.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (AllLedgerSts == "1")
        {
            table.Rows.Add('"' + "ALL LEDGER :" + '"', '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "ALL LEDGER :" + '"', '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (AccntGroup != "")
        {
            table.Rows.Add('"' + "ACCOUNT GROUP :" + '"', '"' + AccntGroup + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (LedgerRangeFrom != "" || LedgerRangeTo != "")
        {
            if (LedgerRangeFrom == "")
            {
                LedgerRangeFrom = "0";
            }
            if (LedgerRangeTo == "")
            {
                LedgerRangeTo = "MAX";
            }
            table.Rows.Add('"' + "LEDGER CODE RANGE :" + '"', '"' + LedgerRangeFrom + " - " + LedgerRangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (H1RangeFrom != "" || H1RangeTo != "")
        {
            if (H1RangeFrom == "")
            {
                H1RangeFrom = "0";
            }
            if (H1RangeTo == "")
            {
                H1RangeTo = "MAX";
            }
            table.Rows.Add('"' + "HIERARCHY 1 CODE RANGE :" + '"', '"' + H1RangeFrom + " - " + H1RangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (H2RangeFrom != "" || H2RangeTo != "")
        {
            if (H2RangeFrom == "")
            {
                H2RangeFrom = "0";
            }
            if (H2RangeTo == "")
            {
                H2RangeTo = "MAX";
            }
            table.Rows.Add('"' + "HIERARCHY 2 CODE RANGE :" + '"', '"' + H2RangeFrom + " - " + H2RangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (CCCodeRangeFrom != "" || CCCodeRangeTo != "")
        {
            if (CCCodeRangeFrom == "")
            {
                CCCodeRangeFrom = "0";
            }
            if (CCCodeRangeTo == "")
            {
                CCCodeRangeTo = "MAX";
            }
            table.Rows.Add('"' + "CC CODE RANGE :" + '"', '"' + CCCodeRangeFrom + " - " + CCCodeRangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (SubLedgerSts == "1")
        {
            table.Rows.Add('"' + "INCLUDE SUB-LEDGER :" + '"', '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "INCLUDE SUB-LEDGER :" + '"', '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }


        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "DATE" + '"', '"' + "PARTICULARS" + '"', '"' + "REF#" + '"', '"' + "VOUCHER TYPE" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"', '"' + "CLOSING BALANCE" + '"', '"' + "NARRATION" + '"');

        decimal decPrevsAmnt = 0;

        decimal decTotalDebit = 0;
        decimal decTotalCredit = 0;
        decimal decTotalClosing = 0;

        decimal decSubLdgrDebit = 0;
        decimal decSubLdgrCredit = 0;
        decimal decSubLdgrClosing = 0;
        int RecordsCnt = 0;
        string SubLedgerName = "";
        int GrpCnt = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            table.Rows.Add();

            string LedgerName = dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
            objEntityLedgerStatmnt.Ledger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_ID"].ToString());

            int SubLedger = 0;
            if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
            {
                SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
            }

            //Subledger grouping

            int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

            if (SubLedgerSts == "1" && RecordsCnt == 0)
            {
                string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                SubLedgerName = SubLedgerNm;

                table.Rows.Add('"' + SubLedgerNm + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

                decSubLdgrDebit = 0;
                decSubLdgrCredit = 0;
                decSubLdgrClosing = 0;
            }

            if (numberOfRecords > 1)
            {
                RecordsCnt++;
            }

            //Heading

            table.Rows.Add('"' + FORNULL + '"', '"' + LedgerName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            //Opening Balance
            decimal OpengBal = 0;
            OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());

            string strDebit = "";
            string strCredit = "";
            if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
            {
                string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                strCredit = strOpenNetAmountWithComma;
            }
            else
            {
                string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                strDebit = strOpenNetAmountWithComma;
            }

            string strNetAmountWithCommaOpen = "";
            if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) >= 0)
            {
                strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon) + " DR";
            }
            else
            {
                strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon) + " CR";
            }

            table.Rows.Add('"' + FORNULL + '"', '"' + "Opening Balance" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strDebit + '"', '"' + strCredit + '"', '"' + strNetAmountWithCommaOpen + '"', '"' + FORNULL + '"');


            decPrevsAmnt = OpengBal;

            //------------------------ledger details----------------------

            DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStatmnt);

            string VouchrAcntId = "";

            for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
            {
                objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_ID"].ToString());

                string strId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
                int intIdLength = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string strDebitAmount = "";
                strDebitAmount = dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString();
                string strNetAmountWithCommaDebit = "";
                if (strDebitAmount != "")
                {
                    strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(strDebitAmount, objEntityCommon);
                }

                string strCreditAmount = "";
                strCreditAmount = dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString();
                string strNetAmountWithCommaCredit = "";
                if (strCreditAmount != "")
                {
                    strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation((0 - Convert.ToDecimal(strCreditAmount)).ToString(), objEntityCommon);
                }

                decimal Debit = 0;
                if (strDebitAmount != "")
                {
                    Debit = Convert.ToDecimal(strDebitAmount);
                }
                decimal Credit = 0;
                if (strCreditAmount != "")
                {
                    Credit = Convert.ToDecimal(strCreditAmount);
                }
                decTotalCredit += Credit;
                decTotalDebit += Debit;

                decimal Closing = 0;
                Closing = Debit + Credit + decPrevsAmnt;
                decTotalClosing += Closing;

                string strNetAmountWithCommaClose = "";
                if (Closing >= 0)
                {
                    strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation(Closing.ToString(), objEntityCommon) + " DR";
                }
                else
                {
                    strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation((0 - Closing).ToString(), objEntityCommon) + " CR";
                }

                decPrevsAmnt = Closing;

                table.Rows.Add('"' + dtDtls.Rows[intRow]["VOCHR_DATE"].ToString() + '"', '"' + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + '"', '"' + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + '"', '"' + dtDtls.Rows[intRow]["VOCHR_TYP"].ToString() + '"', '"' + strNetAmountWithCommaDebit + '"', '"' + strNetAmountWithCommaCredit + '"', '"' + strNetAmountWithCommaClose + '"', '"' + dtDtls.Rows[intRow]["VOCHR_DSCRPTN"].ToString() + '"');

                //opposite ledger count for journal/credit note/debit note(as per details present)
                if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)
                {
                    int flag = 0;
                    StringBuilder sbPop = new StringBuilder();

                    objEntityLedgerStatmnt.VoucherAccntId = Convert.ToInt32(strId);
                    DataTable dtPrintDtls = objBusinessLedgerStatmnt.ReadLedgerStatementAsPerDtls(objEntityLedgerStatmnt);

                    for (int intRowDtls = 0; intRowDtls < dtPrintDtls.Rows.Count; intRowDtls++)
                    {
                        if (dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "" || dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
                        {

                            if (dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "")
                            {
                                table.Rows.Add('"' + FORNULL + '"', '"' + dtPrintDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + " => " + dtPrintDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() + " DR" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                            }
                            if (dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
                            {
                                decimal CrdtAmnt = 0 - Convert.ToDecimal(dtPrintDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString());
                                table.Rows.Add('"' + FORNULL + '"', '"' + dtPrintDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + " => " + CrdtAmnt.ToString() + "CR" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                            }
                            flag++;
                        }
                    }
                }


                VouchrAcntId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
            }

            //------------------------ledger details----------------------

            //total amount

            if (OpengBal >= 0)
            {
                decTotalDebit = decTotalDebit + OpengBal;
            }
            else
            {
                decTotalCredit = decTotalCredit + OpengBal;
            }
            decTotalClosing = decTotalDebit + decTotalCredit;

            string strNetAmountWithCommaTotalDebit = "0";
            if (decTotalDebit != 0)
            {
                strNetAmountWithCommaTotalDebit = objBusiness.AddCommasForNumberSeperation(decTotalDebit.ToString(), objEntityCommon);
            }

            string strNetAmountWithCommaTotalCredit = "0";
            if (decTotalCredit != 0)
            {
                strNetAmountWithCommaTotalCredit = objBusiness.AddCommasForNumberSeperation((0 - decTotalCredit).ToString(), objEntityCommon);
            }

            string strNetAmountWithComma = "";
            if (decPrevsAmnt >= 0)
            {
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon) + " DR";
            }
            else
            {
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon) + " CR";
            }

            table.Rows.Add('"' + FORNULL + '"', '"' + "Total Balance" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strNetAmountWithCommaTotalDebit + " DR" + '"', '"' + strNetAmountWithCommaTotalCredit + " CR" + '"', '"' + strNetAmountWithComma + '"', '"' + FORNULL + '"');

            //Subledger grouping amnt

            decSubLdgrDebit += decTotalDebit;
            decSubLdgrCredit += decTotalCredit;
            decSubLdgrClosing += decTotalClosing;

            if (SubLedgerSts == "1" && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
            {
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";
                string strSubDebit = strNetAmountWithComma;

                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrCredit).ToString(), objEntityCommon) + " CR";
                string strSubCredit = strNetAmountWithComma;

                if (decSubLdgrClosing >= 0)
                {
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                }
                else
                {
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                }
                string strSubTotal = strNetAmountWithComma;

                table.Rows.Add('"' + SubLedgerName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strSubDebit + '"', '"' + strSubCredit + '"', '"' + strSubTotal + '"', '"' + FORNULL + '"');


                RecordsCnt = 0;
                GrpCnt++;
            }

            decTotalCredit = 0;
            decTotalDebit = 0;
            decPrevsAmnt = 0;
        }

        return table;
    }


    //summary table
    public string ConvertDataTableToHTMLSummary(DataTable dt, int Print)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCrncyId.Value);

        StringBuilder sb = new StringBuilder();

        if (cbxSubLedgerSts.Checked == true)
        {
            sb.Append("<table id=\"datatable_fixed_column\" class=\"table-bordered\" width=\"100%\" >");
        }
        else
        {
            sb.Append("<table id=\"datatable_fixed_column\" class=\"table-bordered display\" width=\"100%\" >");
        }

        sb.Append("<thead class=\"thead1\">");
        sb.Append("<tr>");

        sb.Append("<th class=\"col-md-4 tr_l\" >PARTICULARS");
        sb.Append("  <input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"PARTICULARS\" type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"col-md-2 tr_r\" >OPENING BALANCE");
        sb.Append(" <input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"OPENING BALANCE\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"col-md-2 tr_r\" >DEBIT");
        sb.Append(" <input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"col-md-2 tr_r\" >CREDIT");
        sb.Append(" <input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("<th class=\"col-md-2 tr_r\" >CLOSING BALANCE");
        sb.Append(" <input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CLOSING BALANCE\"  type=\"text\">");
        sb.Append("</th >");

        sb.Append("</tr>");

        sb.Append("</thead>");


        sb.Append("<tbody>");

        decimal decSubLdgrDebit = 0;
        decimal decSubLdgrCredit = 0;
        decimal decSubLdgrClosing = 0;
        int RecordsCnt = 0;
        string SubLedgerName = "";
        int GrpCnt = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int SubLedger = 0;
            if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
            {
                SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
            }
            int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

            if (cbxSubLedgerSts.Checked == true && RecordsCnt == 0)
            {
                string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                SubLedgerName = SubLedgerNm;
                if (GrpCnt % 2 == 0)
                {
                    sb.Append("<tr class=\"tr_grp_odd\">");
                }
                else
                {
                    sb.Append("<tr class=\"tr_grp_even\">");
                }
                sb.Append("<th class=\"tr_l\">" + SubLedgerNm + "</th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("<th class=\"tr_r\" ></th>");
                sb.Append("</tr>");

                decSubLdgrDebit = 0;
                decSubLdgrCredit = 0;
                decSubLdgrClosing = 0;
            }

            string strStyle = "";
            if (cbxSubLedgerSts.Checked == true)
            {
                if (GrpCnt != 0)
                {
                    strStyle = "padding-left: " + (RecordsCnt * 10) + "px!important;";
                }

                if (numberOfRecords > 1)
                {
                    RecordsCnt++;
                }

                if (RecordsCnt == numberOfRecords)
                {
                    RecordsCnt = 0;
                }
            }

            decimal decTotalClosing = 0;

            sb.Append("<tr>");

            sb.Append("<td class=\"tr_l\" style=\"" + strStyle + "\" > " + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>");

            decimal OpengBal = 0;

            if (dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
            {
                OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());

                if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
                {
                    string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                    sb.Append("<td class=\"tr_r\" >" + strOpenNetAmountWithComma + " CR</td>");
                }
                else
                {
                    string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                    sb.Append("<td class=\"tr_r\" >" + strOpenNetAmountWithComma + " DR</td>");
                }
            }
            else
            {
                sb.Append("<td class=\"tr_r\" ></td>");
            }

            decSubLdgrDebit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString());
            decSubLdgrCredit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString());

            string strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
            sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaDebit + "</td>");

            string strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon) + "";
            sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaCredit + "</td>");

            decTotalClosing = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString()) - Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString()) + OpengBal;

            if (decTotalClosing >= 0)
            {
                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon);
                sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithComma + " DR</td>");
            }
            else
            {
                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon);
                sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithComma + " CR</td>");
            }
            decSubLdgrClosing += decTotalClosing;

            sb.Append("</tr>");

            string strNetAmountWithCommaAmnt = "";
            if (cbxSubLedgerSts.Checked == true && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
            {
                if (GrpCnt % 2 == 0)
                {
                    sb.Append("<tr class=\"tr_grp_odd\">");
                }
                else
                {
                    sb.Append("<tr class=\"tr_grp_even\">");
                }
                sb.Append("<th class=\"tr_l\">" + SubLedgerName + "</th>");
                sb.Append("<th class=\"tr_r\" ></th>");

                strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";

                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithCommaAmnt + "</th>");

                strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrCredit).ToString(), objEntityCommon) + " CR";

                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithCommaAmnt + "</th>");

                if (decSubLdgrClosing >= 0)
                {
                    strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                    sb.Append("<th class=\"tr_r\" >" + strNetAmountWithCommaAmnt + "</th>");
                }
                else
                {
                    strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                    sb.Append("<th class=\"tr_r\" >" + strNetAmountWithCommaAmnt + "</th>");
                }
                sb.Append("</tr>");

                RecordsCnt = 0;
                GrpCnt++;
            }

        }

        sb.Append("</tbody>");

        sb.Append("</table>");

        return sb.ToString();
    }
    public string ConvertDataTableToHTMLSummary_PDF(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        string strRet = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int Decimalcount = 0, intCorpId = 0;
        intCorpId = Convert.ToInt32(CorpId);
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
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string strRandom = objCommon.Random_Number();

        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.LEDGER_STATEMENT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_STATEMENT_PDF);
        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "LedgerStatmntSummary" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                //filter section
                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 25, 5, 70 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(datefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DETAILED", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SUMMARY", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                if (Ledgers != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("LEDGERS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(Ledgers.TrimEnd(',', ' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("ALL LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (AllLedgerSts == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("YES", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("NO", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                if (AccntGroup != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AccntGroup, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (LedgerRangeFrom != "" || LedgerRangeTo != "")
                {
                    if (LedgerRangeFrom == "")
                    {
                        LedgerRangeFrom = "0";
                    }
                    if (LedgerRangeTo == "")
                    {
                        LedgerRangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("LEDGER CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(LedgerRangeFrom + " - " + LedgerRangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (H1RangeFrom != "" || H1RangeTo != "")
                {
                    if (H1RangeFrom == "")
                    {
                        H1RangeFrom = "0";
                    }
                    if (H1RangeTo == "")
                    {
                        H1RangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("HIERARCHY 1 CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(H1RangeFrom + " - " + H1RangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (H2RangeFrom != "" || H2RangeTo != "")
                {
                    if (H2RangeFrom == "")
                    {
                        H2RangeFrom = "0";
                    }
                    if (H2RangeTo == "")
                    {
                        H2RangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("HIERARCHY 2 CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(H2RangeFrom + " - " + H2RangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (CCCodeRangeFrom != "" || CCCodeRangeTo != "")
                {
                    if (CCCodeRangeFrom == "")
                    {
                        CCCodeRangeFrom = "0";
                    }
                    if (CCCodeRangeTo == "")
                    {
                        CCCodeRangeTo = "MAX";
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase("CC CODE RANGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CCCodeRangeFrom + " - " + CCCodeRangeTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("INCLUDE SUB-LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (SubLedgerSts == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("YES", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 8 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("NO", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 8 });
                }

                document.Add(footrtable);

                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 30, 20, 15, 15, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);
                var FontSmallBlue = new BaseColor(220, 224, 230);
                var FontSmallViolet = new BaseColor(226, 220, 230);
                var FontDark = new BaseColor(196, 197, 207);
                var FontLight = new BaseColor(196, 206, 207);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("OPENING BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CLOSING BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                decimal decSubLdgrDebit = 0;
                decimal decSubLdgrCredit = 0;
                decimal decSubLdgrClosing = 0;
                int RecordsCnt = 0;
                string SubLedgerName = "";
                int GrpCnt = 0;

                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    //sub-ledger
                    int SubLedger = 0;
                    if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
                    {
                        SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
                    }
                    int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

                    if (SubLedgerSts == "1" && RecordsCnt == 0)
                    {
                        string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                        SubLedgerName = SubLedgerNm;

                        var strColour = FontDark;
                        if (GrpCnt % 2 == 0)
                        {
                            strColour = FontDark;
                        }

                        TBCustomer.AddCell(new PdfPCell(new Phrase(SubLedgerNm, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = strColour, BorderColor = FontGray, Colspan = 5 });

                        decSubLdgrDebit = 0;
                        decSubLdgrCredit = 0;
                        decSubLdgrClosing = 0;
                    }

                    int intStyle = 0;
                    if (SubLedgerSts == "1")
                    {
                        if (GrpCnt != 0)
                        {
                            intStyle = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LEVEL"].ToString()) * 30;
                        }

                        if (numberOfRecords > 1)
                        {
                            RecordsCnt++;
                        }

                        if (RecordsCnt == numberOfRecords)
                        {
                            RecordsCnt = 0;
                        }
                    }

                    decimal decTotalClosing = 0;

                    //summary table
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, PaddingRight = intStyle });

                    decimal OpengBal = 0;

                    if (dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
                    {
                        OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());

                        if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
                        {
                            string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strOpenNetAmountWithComma+ " CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strOpenNetAmountWithComma + " DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }

                    decSubLdgrDebit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString());
                    decSubLdgrCredit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString());

                    string strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaDebit, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    string strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon) + "";
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaCredit, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                    decTotalClosing = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString()) - Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString()) + OpengBal;

                    if (decTotalClosing >= 0)
                    {
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma+ " DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma+ " CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    decSubLdgrClosing += decTotalClosing;

                    //sub-ledger total
                    string strNetAmountWithCommaAmnt = "";
                    if (SubLedgerSts == "1" && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(SubLedgerName, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrCredit).ToString(), objEntityCommon) + " CR";
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });

                        if (decSubLdgrClosing >= 0)
                        {
                            strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        }
                        else
                        {
                            strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithCommaAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontDark, BorderColor = FontGray });
                        }

                        RecordsCnt = 0;
                        GrpCnt++;
                    }

                }

                if (dt.Rows.Count == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
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
    public string ConvertDataTableToHTMLSummary_CSV(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dtList = GetTableListSummary(dt, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
        string strResult = DataTableToCSV(dtList, ',');

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_STATEMENT_CSV);

        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "LedgerStatmntSummary" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.LEDGER_STATEMENT_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableListSummary(DataTable dt, string CorpId, string OrgId, string AllLedgerSts, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string Ledgers, string Mode, string SubLedgerSts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int Decimalcount = 0, intCorpId = 0;
        intCorpId = Convert.ToInt32(CorpId);
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
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        int precision = Convert.ToInt32(Decimalcount);
        string format = String.Format("{{0:N{0}}}", precision);

        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("LEDGER STATEMENT", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "FROM DATE :" + '"', '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "TO DATE :" + '"', '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (Mode == "0")
        {
            table.Rows.Add('"' + "MODE :" + '"', '"' + "DETAILED" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "MODE :" + '"', '"' + "SUMMARY" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (Ledgers != "")
        {
            table.Rows.Add('"' + "LEDGERS :" + '"', '"' + Ledgers.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (AllLedgerSts == "1")
        {
            table.Rows.Add('"' + "ALL LEDGER :" + '"', '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "ALL LEDGER :" + '"', '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (AccntGroup != "")
        {
            table.Rows.Add('"' + "ACCOUNT GROUP :" + '"', '"' + AccntGroup + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (LedgerRangeFrom != "" || LedgerRangeTo != "")
        {
            if (LedgerRangeFrom == "")
            {
                LedgerRangeFrom = "0";
            }
            if (LedgerRangeTo == "")
            {
                LedgerRangeTo = "MAX";
            }
            table.Rows.Add('"' + "LEDGER CODE RANGE :" + '"', '"' + LedgerRangeFrom + " - " + LedgerRangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (H1RangeFrom != "" || H1RangeTo != "")
        {
            if (H1RangeFrom == "")
            {
                H1RangeFrom = "0";
            }
            if (H1RangeTo == "")
            {
                H1RangeTo = "MAX";
            }
            table.Rows.Add('"' + "HIERARCHY 1 CODE RANGE :" + '"', '"' + H1RangeFrom + " - " + H1RangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (H2RangeFrom != "" || H2RangeTo != "")
        {
            if (H2RangeFrom == "")
            {
                H2RangeFrom = "0";
            }
            if (H2RangeTo == "")
            {
                H2RangeTo = "MAX";
            }
            table.Rows.Add('"' + "HIERARCHY 2 CODE RANGE :" + '"', '"' + H2RangeFrom + " - " + H2RangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (CCCodeRangeFrom != "" || CCCodeRangeTo != "")
        {
            if (CCCodeRangeFrom == "")
            {
                CCCodeRangeFrom = "0";
            }
            if (CCCodeRangeTo == "")
            {
                CCCodeRangeTo = "MAX";
            }
            table.Rows.Add('"' + "CC CODE RANGE :" + '"', '"' + CCCodeRangeFrom + " - " + CCCodeRangeTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        if (SubLedgerSts == "1")
        {
            table.Rows.Add('"' + "INCLUDE SUB-LEDGER :" + '"', '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "INCLUDE SUB-LEDGER :" + '"', '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }


        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "PARTICULARS" + '"', '"' + "OPENING BALANCE" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"', '"' + "CLOSING BALANCE" + '"');

        decimal decSubLdgrDebit = 0;
        decimal decSubLdgrCredit = 0;
        decimal decSubLdgrClosing = 0;
        int RecordsCnt = 0;
        string SubLedgerName = "";
        int GrpCnt = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //sub-ledger
            int SubLedger = 0;
            if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
            {
                SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
            }
            int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

            if (SubLedgerSts == "1" && RecordsCnt == 0)
            {
                string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

                SubLedgerName = SubLedgerNm;

                table.Rows.Add();
                table.Rows.Add('"' + SubLedgerNm + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

                decSubLdgrDebit = 0;
                decSubLdgrCredit = 0;
                decSubLdgrClosing = 0;
            }

            if (SubLedgerSts == "1")
            {
                if (numberOfRecords > 1)
                {
                    RecordsCnt++;
                }

                if (RecordsCnt == numberOfRecords)
                {
                    RecordsCnt = 0;
                }
            }

            decimal decTotalClosing = 0;

            //summary table

            decimal OpengBal = 0;
            string strOpen = "";

            if (dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
            {
                OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());

                if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
                {
                    string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
                    strOpen = strOpenNetAmountWithComma + " CR";
                }
                else
                {
                    string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
                    strOpen = strOpenNetAmountWithComma + " DR";
                }
            }

            decSubLdgrDebit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString());
            decSubLdgrCredit += Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString());

            string strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
            string strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon) + "";

            decTotalClosing = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString()) - Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString()) + OpengBal;

            string strNet = "";
            if (decTotalClosing >= 0)
            {
                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon);
                strNet = strNetAmountWithComma + " DR";
            }
            else
            {
                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon);
                strNet = strNetAmountWithComma + " CR";
            }

            table.Rows.Add('"' + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + '"', '"' + strOpen + '"', '"' + strNetAmountWithCommaDebit + '"', '"' + strNetAmountWithCommaCredit + '"', '"' + strNet + '"');


            decSubLdgrClosing += decTotalClosing;

            //sub-ledger total
            string strNetAmountWithCommaAmnt = "";
            if (SubLedgerSts == "1" && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
            {
                string strSubDebit = "";
                string strSubCredit = "";
                strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";
                strSubDebit = strNetAmountWithCommaAmnt;

                strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrCredit).ToString(), objEntityCommon) + " CR";
                strSubCredit = strNetAmountWithCommaAmnt;

                string strSubTotal = "";
                if (decSubLdgrClosing >= 0)
                {
                    strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
                    strSubTotal = strNetAmountWithCommaAmnt;
                }
                else
                {
                    strNetAmountWithCommaAmnt = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
                    strSubTotal = strNetAmountWithCommaAmnt;
                }

                table.Rows.Add('"' + SubLedgerName + '"', '"' + FORNULL + '"', '"' + strSubDebit + '"', '"' + strSubCredit + '"', '"' + strSubTotal + '"');

                RecordsCnt = 0;
                GrpCnt++;
            }

        }

        return table;
    }


    //check which print
    [WebMethod]
    public static string List_Print(string CorpId, string OrgId, string AllLedgerSts, string AccntGroupId, string AccntGroup, string LedgerRangeFrom, string LedgerRangeTo, string H1RangeFrom, string H1RangeTo, string H2RangeFrom, string H2RangeTo, string CCCodeRangeFrom, string CCCodeRangeTo, string datefrom, string dateto, string LedgerIds, string Ledgers, string Mode, string SubLedgerSts, string strPrintMode)
    {
        string result = "";

        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();

        FMS_FMS_Reports_fms_Ledger_Statement_fms_Ledger_Statement OBJ = new FMS_FMS_Reports_fms_Ledger_Statement_fms_Ledger_Statement();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);

        objEntityLedgerStatmnt.Mode = Convert.ToInt32(Mode);

        if (LedgerIds != "")
        {
            objEntityLedgerStatmnt.LedgerIds = LedgerIds.TrimEnd(',', ' ');
        }
        else
        {
            objEntityLedgerStatmnt.LedgerIds = "''";
        }
        if (datefrom != "")
        {
            objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(datefrom);
        }
        if (dateto != "")
        {
            objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(dateto);
        }
        if (LedgerRangeFrom != "")
        {
            objEntityLedgerStatmnt.LedgerFromRange = Convert.ToInt32(LedgerRangeFrom);
        }
        if (LedgerRangeFrom != "")
        {
            objEntityLedgerStatmnt.LedgerToRange = Convert.ToInt32(LedgerRangeFrom);
        }

        if (H1RangeFrom != "")
        {
            objEntityLedgerStatmnt.H1LedgerFromRange = Convert.ToInt32(H1RangeFrom);
        }
        if (H1RangeTo != "")
        {
            objEntityLedgerStatmnt.H1LedgerToRange = Convert.ToInt32(H1RangeTo);
        }

        if (H2RangeFrom != "")
        {
            objEntityLedgerStatmnt.H2LedgerFromRange = Convert.ToInt32(H2RangeFrom);
        }
        if (H2RangeTo != "")
        {
            objEntityLedgerStatmnt.H2LedgerToRange = Convert.ToInt32(H2RangeTo);
        }

        if (CCCodeRangeFrom != "")
        {
            objEntityLedgerStatmnt.CCFromRange = Convert.ToInt32(CCCodeRangeFrom);
        }
        if (CCCodeRangeTo != "")
        {
            objEntityLedgerStatmnt.CCToRange = Convert.ToInt32(CCCodeRangeTo);
        }
        if (AccntGroupId != "")
        {
            objEntityLedgerStatmnt.AccountGrpId = Convert.ToInt32(AccntGroupId);
        }
        objEntityLedgerStatmnt.AllLedgersStatus = Convert.ToInt32(AllLedgerSts);
        objEntityLedgerStatmnt.SubLedgerStatus = Convert.ToInt32(SubLedgerSts);

        if (Ledgers.Contains("‡") == true)
        {
            Ledgers = Ledgers.Replace("‡", "\"");
        }
        if (Ledgers.Contains("¦") == true)
        {
            Ledgers = Ledgers.Replace("¦", "\'");
        }

        DataTable dtMain = objBusinessLedgerStatmnt.ReadLedgerStatementMain(objEntityLedgerStatmnt);

        if (strPrintMode == "pdf")
        {
            if (objEntityLedgerStatmnt.Mode == 0)
            {
                result = OBJ.ConvertDataTableToHTMLDetail_PDF(dtMain, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
            }
            else
            {
                result = OBJ.ConvertDataTableToHTMLSummary_PDF(dtMain, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
            }
        }
        else if ((strPrintMode == "csv"))
        {
            if (objEntityLedgerStatmnt.Mode == 0)
            {
                result = OBJ.ConvertDataTableToHTMLDetail_CSV(dtMain, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
            }
            else
            {
                result = OBJ.ConvertDataTableToHTMLSummary_CSV(dtMain, CorpId, OrgId, AllLedgerSts, AccntGroup, LedgerRangeFrom, LedgerRangeTo, H1RangeFrom, H1RangeTo, H2RangeFrom, H2RangeTo, CCCodeRangeFrom, CCCodeRangeTo, datefrom, dateto, Ledgers, Mode, SubLedgerSts);
            }
        }
        return result;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedgerStatmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Corpid"] != null)
        {
            string strRandomMixedId = Request.QueryString["Corpid"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strCorpId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityLedgerStatmnt.CorpId = Convert.ToInt32(strCorpId);
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedgerStatmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (radioDetail.Checked == true)
        {
            objEntityLedgerStatmnt.Mode = 0;
        }
        else
        {
            objEntityLedgerStatmnt.Mode = 1;
        }

        if (hiddenLedgerIds.Value != "")
        {
            objEntityLedgerStatmnt.LedgerIds = hiddenLedgerIds.Value.TrimEnd(',', ' ');
        }
        else
        {
            objEntityLedgerStatmnt.LedgerIds = "''";
        }
        if (txtFromdate.Value != "")
        {
            objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(txtFromdate.Value);
        }
        if (txtTodate.Value != "")
        {
            objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(txtTodate.Value);
        }
        if (txtLedgerRangeFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntityLedgerStatmnt.LedgerFromRange = Convert.ToInt32(txtLedgerRangeFrom.SelectedItem.Value);
        }
        if (txtLedgerRangeTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntityLedgerStatmnt.LedgerToRange = Convert.ToInt32(txtLedgerRangeTo.SelectedItem.Value);
        }

        if (txtH1RangeFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntityLedgerStatmnt.H1LedgerFromRange = Convert.ToInt32(txtH1RangeFrom.SelectedItem.Value);
        }
        if (txtH1RangeTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntityLedgerStatmnt.H1LedgerToRange = Convert.ToInt32(txtH1RangeTo.SelectedItem.Value);
        }

        if (txtH2RangeFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntityLedgerStatmnt.H2LedgerFromRange = Convert.ToInt32(txtH2RangeFrom.SelectedItem.Value);
        }
        if (txtH2RangeTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntityLedgerStatmnt.H2LedgerToRange = Convert.ToInt32(txtH2RangeTo.SelectedItem.Value);
        }

        if (txtCCCodeRangeFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntityLedgerStatmnt.CCFromRange = Convert.ToInt32(txtCCCodeRangeFrom.SelectedItem.Value);
        }
        if (txtCCCodeRangeTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntityLedgerStatmnt.CCToRange = Convert.ToInt32(txtCCCodeRangeTo.SelectedItem.Value);
        }
        if (ddlParentGroup.SelectedItem.Value != "" && ddlParentGroup.SelectedItem.Value!="--SELECT GROUP--")
        {
            objEntityLedgerStatmnt.AccountGrpId =Convert.ToInt32(ddlParentGroup.SelectedItem.Value.ToString());
        }
        if (cbxExtngSplr.Checked)
        {
            objEntityLedgerStatmnt.AllLedgersStatus = 1;
        }
        else
        {
            objEntityLedgerStatmnt.AllLedgersStatus = 0;
        }

        if (cbxSubLedgerSts.Checked == true)
        {
            objEntityLedgerStatmnt.SubLedgerStatus = 1;
        }
        else
        {
            objEntityLedgerStatmnt.SubLedgerStatus = 0;
        }

        DataTable dtMain = objBusinessLedgerStatmnt.ReadLedgerStatementMain(objEntityLedgerStatmnt);

        string strHtm = "";
        if (objEntityLedgerStatmnt.Mode == 0)
        {
            strHtm = ConvertDataTableToHTMLDetail(dtMain, 0);
        }
        else
        {
            strHtm = ConvertDataTableToHTMLSummary(dtMain, 0);
        }
        divReport.InnerHtml = strHtm;
        if (objEntityLedgerStatmnt.Mode == 0)
        {
            divPrintReport.InnerHtml = ConvertDataTableToHTMLDetail(dtMain, 1);
        }
        else
        {
            divPrintReport.InnerHtml = ConvertDataTableToHTMLSummary(dtMain, 1);
        }
    }

    [WebMethod]
    public static string LoadAsPerDetails(string OrgId, string CorpId, string LdgrId, string Row, string FrmDate, string ToDate, string VochrAcntId, string VochrId)
    {
        string strReturn = ""; string strDebitDtls = "", strCreditDtls = ""; int flag = 0, CntDup = 0, Dup = 0;

        StringBuilder sbPop = new StringBuilder();//as per details

        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();
        clsCommonLibrary objEntityCommon = new clsCommonLibrary();

        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);
        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
        objEntityLedgerStatmnt.Ledger = Convert.ToInt32(LdgrId);
        objEntityLedgerStatmnt.FromDate = objEntityCommon.textToDateTime(FrmDate);
        objEntityLedgerStatmnt.ToDate = objEntityCommon.textToDateTime(ToDate);
        objEntityLedgerStatmnt.VoucherAccntId = Convert.ToInt32(VochrAcntId);
        objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(VochrId);

        DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementAsPerDtls(objEntityLedgerStatmnt);

        for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
        {
            if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
            {
                if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "")
                {
                    sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + " " + dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
                }
                if (dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
                {
                    decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString());
                    sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + " " + CrdtAmnt.ToString() + "CR</span> <br/>");
                }
                flag++;
            }
        }

        strReturn = sbPop.ToString();

        if (flag == 0)
        {
            strReturn = "";
        }

        return strReturn;
    }


    //[WebMethod]
    //public static string LoadAsPerDetails(string OrgId, string CorpId, string LdgrId, string Row, string FrmDate, string ToDate, string VochrAcntId)
    //{
    //    string strReturn = ""; string strDebitDtls = "", strCreditDtls = ""; int flag = 0, CntDup = 0, Dup = 0;

    //    StringBuilder sbPop = new StringBuilder();//as per details

    //    clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
    //    clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();
    //    clsCommonLibrary objEntityCommon = new clsCommonLibrary();

    //    objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);
    //    objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
    //    objEntityLedgerStatmnt.Ledger = Convert.ToInt32(LdgrId);
    //    objEntityLedgerStatmnt.FromDate = objEntityCommon.textToDateTime(FrmDate);
    //    objEntityLedgerStatmnt.ToDate = objEntityCommon.textToDateTime(ToDate);

    //    DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStatmnt);

    //    for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
    //    {
    //        if (VochrAcntId == dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString())
    //        {
    //            //if journal/credit note/debit note
    //            if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //            {
    //                if (CntDup == Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()))
    //                {
    //                    CntDup = 0;
    //                }
    //                else
    //                {
    //                    if (CntDup > 0 && (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != ""))
    //                    {
    //                        if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "")
    //                        {
    //                            sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                        }
    //                        if (dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                        {
    //                            decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString());
    //                            sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                        }
    //                        flag++;
    //                    }
                       
    //                }
    //                CntDup++;
    //            }
    //            //if payment/receipt
    //            else if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 0 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 1)
    //            {
    //                //if accnt book
    //                if (dtDtls.Rows[intRow]["VOCHR_BANK_STATUS"].ToString() == "1")
    //                {
    //                    if (CntDup == Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()))
    //                    {
    //                        CntDup = 0;
    //                    }
    //                    else
    //                    {
    //                        if (CntDup > 0 && (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != ""))
    //                        {
    //                            if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "")
    //                            {
    //                                sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                            }
    //                            if (dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                            {
    //                                decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString());
    //                                sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                            }
    //                            flag++;
    //                        }

    //                    }
    //                    CntDup++;
    //                }
    //                else
    //                {
    //                    if (Dup == 0)
    //                    {
    //                        if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                        {
    //                            if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "")
    //                            {
    //                                sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                            }
    //                            if (dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                            {
    //                                decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString());
    //                                sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                            }
    //                            flag++;
    //                        }
    //                        Dup++;
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                {
    //                    if (dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() != "")
    //                    {
    //                        sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + " " + dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                    }
    //                    if (dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString() != "")
    //                    {
    //                        decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString());
    //                        sbPop.Append("<span>" + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + " " + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                    }
    //                    flag++;
    //                }
    //            }


     
    //        }
    //    }

    //    strReturn = sbPop.ToString();

    //    if (flag == 0)
    //    {
    //        strReturn = "";
    //    }

    //    return strReturn;
    //}

    //0039
    [WebMethod]
    public static string checkDetails(string intorgid, string intcorpid, string datefrom, string dateTo, string VoucherAccId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();
        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(intorgid);
        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(intcorpid);
        objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(datefrom);
        objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(dateTo);
        //objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(VoucherId);
        //0039
        objEntityLedgerStatmnt.VoucherAccId = Convert.ToInt32(VoucherAccId);
        //end

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";

        strHtml += "<th class=\"col-md-3 tr_l\">REF #";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_l\" >DATE";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_r\" >SETTLED AMOUNT";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";

        //0039
        DataTable dt34 = objBusinessLedgerStatmnt.Readvoucherinfo(objEntityLedgerStatmnt);
        //end

        if (dt34.Rows.Count > 0)
        {
            for (int intCount = 0; intCount < dt34.Rows.Count; intCount++)
            {
                strHtml += "<tr>";
                if (dt34.Rows[intCount]["VOCHR_REF"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_l\" >" + dt34.Rows[intCount]["VOCHR_REF"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                if (dt34.Rows[intCount]["VOCHR_DATE"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_l\" >" + dt34.Rows[intCount]["VOCHR_DATE"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                if (dt34.Rows[intCount]["VOCHR_SETL_AMT"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_r\"  >" + dt34.Rows[intCount]["VOCHR_SETL_AMT"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                strHtml += "</tr>";
            }
            strHtml += "</tbody>";
            strHtml += "</table>";
            sb.Append(strHtml);
        }
        return sb.ToString();
    }

    //end

    [WebMethod]
    public static string CostCentreDetails(string intorgid, string intcorpid, string datefrom, string dateTo, string VoucherId)
    {                
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();
        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(intorgid);
        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(intcorpid);
        objEntityLedgerStatmnt.FromDate = objCommon.textToDateTime(datefrom);
        objEntityLedgerStatmnt.ToDate = objCommon.textToDateTime(dateTo);
        objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(VoucherId);
        DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementCostCentreDtls(objEntityLedgerStatmnt);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";

        strHtml += "<th class=\"col-md-3 td1\">COST CENTRE";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-3 tr_l\">COST GROUP 1";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_l\" >COST GROUP 2";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT AMOUNT";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT AMOUNT";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        if (dtDtls.Rows.Count > 0)
        {
            for (int intCount = 0; intCount < dtDtls.Rows.Count; intCount++)
            {
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_l\" >" + dtDtls.Rows[intCount]["COSTCNTR_NAME"].ToString() + "</td>";
                if (dtDtls.Rows[intCount]["COST_GRP1"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_l\" >" + dtDtls.Rows[intCount]["COST_GRP1"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                if (dtDtls.Rows[intCount]["COST_GRP2"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_l\" >" + dtDtls.Rows[intCount]["COST_GRP2"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                if (dtDtls.Rows[intCount]["DEBIT_AMNT"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_r\"  >" + dtDtls.Rows[intCount]["DEBIT_AMNT"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                if (dtDtls.Rows[intCount]["CREDIT_AMNT"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_r\">" + dtDtls.Rows[intCount]["CREDIT_AMNT"].ToString() + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                }
                strHtml += "</tr>";
            }
            strHtml += "</tbody>";
            strHtml += "</table>";
            sb.Append(strHtml);
        }
        return sb.ToString();
    }

    [WebMethod]
    public static string LoadPostdatedChqDtls(string OrgId, string CorpId, string LdgrId, string Crncy)
    {
        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityLedgerStatmnt.OrgId = Convert.ToInt32(OrgId);
        objEntityLedgerStatmnt.CorpId = Convert.ToInt32(CorpId);
        objEntityLedgerStatmnt.Ledger = Convert.ToInt32(LdgrId);
        objEntityCommon.CurrencyId = Convert.ToInt32(Crncy);
        DataTable dtPostDate = objBusinessLedgerStatmnt.ReadPostdatedChqDtls(objEntityLedgerStatmnt);//Postdated chq

        StringBuilder sbPop = new StringBuilder();

        sbPop.Append("<thead class=\"thead1\">");
        sbPop.Append("<tr>");
        sbPop.Append("<th class=\"col-md-2 td1 tr_l\">Ref#</th>");
        sbPop.Append("<th class=\"col-md-3 tr_l\">Bank</th>");
        sbPop.Append("<th class=\"col-md-1 tr_l\">Cheque#</th>");
        sbPop.Append("<th class=\"col-md-2\">Cheque Date</th>");
        sbPop.Append("<th class=\"col-md-2 tr_r\">Amount</th>");
        sbPop.Append("<th class=\"col-md-2\">Status</th>");
        sbPop.Append("</tr>");
        sbPop.Append("</thead>");

        sbPop.Append("<tbody>");

        for (int intRow = 0; intRow < dtPostDate.Rows.Count; intRow++)
        {
            sbPop.Append("<tr>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["PST_CHEQUE_REF"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["LDGR_NAME"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_NUMBER"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_c\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_CHQ_DATE"].ToString() + "</td>");

            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(dtPostDate.Rows[intRow]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);

            sbPop.Append("<td class=\"tr_r\">" + strNetAmountWithComma + "</td>");
            sbPop.Append("<td>" + dtPostDate.Rows[intRow]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>");
            sbPop.Append("</tr>");
        }

        sbPop.Append("</tbody>");

        return sbPop.ToString();
    }

    //public string ConvertDataTableToHTMLDetail(DataTable dt, int Print)
    //{
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCrncyId.Value);

    //    StringBuilder sb = new StringBuilder();

    //    if (Print == 1)
    //    {
    //        ConvertDataTableToPrint(dt);

    //        sb.Append("<table id=\"PrintTable\" class=\"tab\">");

    //        sb.Append("<thead>");
    //        sb.Append("<tr class=\"top_row\">");

    //        sb.Append("<th class=\"thT\" style=\"width:10%;text-align:left;\">DATE ");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:15%;text-align:left;\">PARTICULARS");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:15%;text-align:left;\">REFERENCE NUMBER");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:10%;text-align:center;\">VOUCHER TYPE");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:10%;text-align:right;\">DEBIT");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:10%;text-align:right;\">CREDIT");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:15%;text-align:right;\">CLOSING BALANCE");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"thT\" style=\"width:15%;text-align:left;\">Narration");
    //        sb.Append("</th>");

    //        sb.Append("</tr>");

    //        sb.Append("</thead>");
    //    }
    //    else
    //    {
    //        sb.Append("<table id=\"datatable_fixed_column\" class=\"table-bordered\" width=\"100%\">");

    //        sb.Append("<thead class=\"thead1\">");
    //        sb.Append("<tr>");

    //        sb.Append("<th class=\"th_b6 tr_c\" >DATE ");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"DATE\"  type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b3 tr_l\" >PARTICULARS");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"PARTICULARS\" type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b2 tr_l\" >REF#");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\"REFERENCE NUMBER\" type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b4 tr_c\" >VOUCHER TYPE");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"VOUCHER TYPE\" type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b6 tr_r\" >DEBIT");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\"  type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b6 tr_r\" >CREDIT");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b2 tr_r\" >CLOSING BALANCE");
    //        sb.Append("<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CLOSING BALANCE\"  type=\"text\">");
    //        sb.Append("</th >");

    //        sb.Append("<th class=\"th_b11 tr_l\">Narration");
    //        sb.Append("</th>");

    //        sb.Append("</tr>");

    //        sb.Append("</thead>");
    //    }

    //    sb.Append("<tbody>");

    //    decimal decPrevsAmnt = 0;

    //    decimal decTotalDebit = 0;
    //    decimal decTotalCredit = 0;
    //    decimal decTotalClosing = 0;

    //    decimal decSubLdgrDebit = 0;
    //    decimal decSubLdgrCredit = 0;
    //    decimal decSubLdgrClosing = 0;
    //    int RecordsCnt = 0;
    //    string SubLedgerName = "";
    //    int GrpCnt = 0;

    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
    //        string LedgerName = dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
    //        objEntityLedgerStatmnt.Ledger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_ID"].ToString());

    //        int SubLedger = 0;
    //        if (dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString() != "")
    //        {
    //            SubLedger = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LDGR_ID"].ToString());
    //        }

    //        //Subledger grouping

    //        int numberOfRecords = dt.AsEnumerable().Where(x => x["LDGRSUB_LDGR_ID"].ToString() == SubLedger.ToString()).ToList().Count;

    //        if (cbxSubLedgerSts.Checked == true && RecordsCnt == 0)
    //        {
    //            string SubLedgerNm = dt.Rows[intRowBodyCount]["SELCTDLDGR_NAME"].ToString();

    //            SubLedgerName = SubLedgerNm;
    //            if (GrpCnt % 2 == 0)
    //            {
    //                sb.Append("<tr class=\"tr_grp_odd\">");
    //            }
    //            else
    //            {
    //                sb.Append("<tr class=\"tr_grp_even\">");
    //            }
    //            sb.Append("<th class=\"tr_c\" ></th>");
    //            sb.Append("<th class=\"tr_l\">" + SubLedgerNm + "</th>");
    //            sb.Append("<th class=\"tr_l\" ></th>");
    //            sb.Append("<th class=\"tr_c\" ></th>");
    //            sb.Append("<th class=\"tr_r\" ></th>");
    //            sb.Append("<th class=\"tr_r\" ></th>");
    //            sb.Append("<th class=\"tr_r\" ></th>");
    //            sb.Append("<th class=\"tr_l\" ></th>");
    //            sb.Append("</tr>");

    //            decSubLdgrDebit = 0;
    //            decSubLdgrCredit = 0;
    //            decSubLdgrClosing = 0;
    //        }

    //        string strStyle = "";
    //        if (RecordsCnt != 0)
    //        {
    //            strStyle = "padding-left: " + (Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGRSUB_LEVEL"].ToString()) * 30) + "px!important;";
    //        }

    //        if (numberOfRecords > 1)
    //        {
    //            RecordsCnt++;
    //        }

    //        //Heading
    //        sb.Append("<tr class=\"tr1\">");
    //        sb.Append("<th class=\"tr_c\" ></th>");
    //        sb.Append("<th class=\"tr_l txt_blu\" style=\"" + strStyle + "\" >" + LedgerName + "</th>");
    //        sb.Append("<th class=\"tr_l\" ></th>");
    //        sb.Append("<th class=\"tr_c\" ></th>");
    //        sb.Append("<th class=\"tr_r\" ></th>");
    //        sb.Append("<th class=\"tr_r\" ></th>");
    //        sb.Append("<th class=\"tr_r\" ></th>");
    //        sb.Append("<th class=\"tr_l\" ></th>");
    //        sb.Append("</tr>");

    //        //Opening Balance
    //        decimal OpengBal = 0;
    //        sb.Append("<tr>");

    //        DataTable dtPostDate = objBusinessLedgerStatmnt.ReadPostdatedChqDtls(objEntityLedgerStatmnt);//Postdated chq
    //        if (dtPostDate.Rows.Count > 0 && Print == 0)
    //        {
    //            sb.Append("<td class=\"tr_c\" ><span href=\"javascript:;\" class=\"ad_pst\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay(" + objEntityLedgerStatmnt.Ledger + ");\"><i class=\"fa fa-list-alt ad_fa ad_fa1 ad_posd\"></i></span><br></td>");
    //        }
    //        else
    //        {
    //            sb.Append("<td class=\"tr_c\" ></td>");
    //        }
    //        sb.Append("<td class=\"tr_r txt_blu\"  >Opening Balance</td>");
    //        sb.Append("<td class=\"tr_l\"  ></td>");
    //        sb.Append("<td class=\"tr_l\"  ></td>");

    //        OpengBal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
    //        if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) < 0)
    //        {
    //            string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon);
    //            sb.Append("<td class=\"tr_r\" ></td>");
    //            sb.Append("<td class=\"tr_r txt_blu\"  >" + strOpenNetAmountWithComma + "</td>");
    //        }
    //        else
    //        {
    //            string strOpenNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon);
    //            sb.Append("<td class=\"tr_r txt_blu\"  >" + strOpenNetAmountWithComma + "</td>");
    //            sb.Append("<td class=\"tr_r\"  ></td>");
    //        }

    //        string strNetAmountWithCommaOpen = "";
    //        if (Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString()) >= 0)
    //        {
    //            strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation(OpengBal.ToString(), objEntityCommon) + " DR";
    //        }
    //        else
    //        {
    //            strNetAmountWithCommaOpen = objBusiness.AddCommasForNumberSeperation((0 - OpengBal).ToString(), objEntityCommon) + " CR";
    //        }
    //        sb.Append("<td class=\"tr_r txt_blu\"  >" + strNetAmountWithCommaOpen + "</td>");
    //        sb.Append("<td class=\"tr_l\" ></th>");
    //        sb.Append("</tr>");

    //        decPrevsAmnt = OpengBal;

    //        //----ledger details----

    //        DataTable dtDtls = objBusinessLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStatmnt);

    //        string VouchrSts = "";

    //        int Cnt = 0, CntDup = 0, CntDbtCrdt = 0, CntDupDbtCrdt = 0;

    //        string VouchrAcntId = "";

    //        for (int intRow = 0; intRow < dtDtls.Rows.Count; intRow++)
    //        {
    //            objEntityLedgerStatmnt.VoucherId = Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_ID"].ToString());

    //            if (dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() != VouchrAcntId)
    //            {
    //                Cnt = 0;
    //                CntDbtCrdt = 0;
    //            }

    //            clsCommonLibrary objCommon = new clsCommonLibrary();
    //            string strRandom = objCommon.Random_Number();
    //            string strId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
    //            int intIdLength = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString().Length;
    //            string stridLength = intIdLength.ToString("00");
    //            string Id = stridLength + strId + strRandom;

    //            //cost center
    //            DataTable dtCCDtls = objBusinessLedgerStatmnt.ReadLedgerStatementCostCentreDtls(objEntityLedgerStatmnt);


    //            //----------------duplication with credit and debit side-------------------

    //            if (dtDtls.Rows[intRow]["TOTAL_DEBIT_AMNT"].ToString() != "")
    //            {
    //                VouchrSts = "0";
    //            }
    //            else if (dtDtls.Rows[intRow]["TOTAL_CREDIT_AMNT"].ToString() != "")
    //            {
    //                VouchrSts = "1";
    //            }

    //            //if ledger duplicates in both credit and debit
    //            if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRCNTDUP_DEBIT"].ToString()) > 0 && Convert.ToInt32(dtDtls.Rows[intRow]["VCHRCNTDUP_CREDIT"].ToString()) > 0)
    //            {
    //                if ((dtDtls.Rows[intRow]["TOTAL_DEBIT_AMNT"].ToString() != "" && dtDtls.Rows[intRow]["TOTAL_DEBIT_AMNT"].ToString() == dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString()) || (dtDtls.Rows[intRow]["TOTAL_CREDIT_AMNT"].ToString() != "" && dtDtls.Rows[intRow]["TOTAL_CREDIT_AMNT"].ToString() == dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString()))
    //                {
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //                    {
    //                        Cnt = 0;
    //                    }
    //                    else
    //                    {
    //                        CntDbtCrdt = 0;
    //                    }
    //                }
    //                else
    //                {
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //                    {
    //                        Cnt++;
    //                    }
    //                    else
    //                    {
    //                        CntDbtCrdt++;
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRDUPCNT"].ToString()) > 1)
    //                {
    //                    //duplicate in journal/credit note/debit note
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                    {
    //                        //if ledger has either 1 credit/debit entry
    //                        if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHROPPDUP"].ToString()) < 0)
    //                        {
    //                            if (VouchrSts != "" && VouchrSts == dtDtls.Rows[intRow]["VOCHR_STS"].ToString())
    //                            {

    //                                if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //                                {
    //                                    CntDup++;
    //                                }
    //                                else
    //                                {
    //                                    CntDupDbtCrdt++;
    //                                }

    //                                if (CntDupDbtCrdt != (Convert.ToInt32(dtDtls.Rows[intRow]["VCHROPPDUPCNT"].ToString()) - 1))
    //                                {
    //                                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //                                    {
    //                                        CntDup = 0;
    //                                        Cnt = 0;
    //                                    }
    //                                    else
    //                                    {
    //                                        CntDbtCrdt = 0;
    //                                        CntDupDbtCrdt = 0;
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    //if opposite ledger duplicates in both credit and debit
    //                                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRCNTDUPOPP_DEBIT"].ToString()) > 0 && Convert.ToInt32(dtDtls.Rows[intRow]["VCHRCNTDUPOPP_CREDIT"].ToString()) > 0)
    //                                    {
    //                                        if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //                                        {
    //                                            Cnt++;
    //                                        }
    //                                        else
    //                                        {
    //                                            CntDbtCrdt++;
    //                                        }
    //                                    }
    //                                }
    //                            }


    //                        }
    //                    }
    //                }
    //            }

    //            //----------------duplication with credit and debit side-------------------



    //            if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) > 2)//opposite ledger count(as per details present or not)
    //            {
    //                if (Cnt == 0)
    //                {
    //                    sb.Append("<td class=\"tr_c\"> " + dtDtls.Rows[intRow]["VOCHR_DATE"].ToString() + "</td>");
    //                    //as per details for journal/credit note/debit note multiple duplicatn present
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                    {
    //                        sb.Append("<td class=\"tr_l\" > " + LedgerName + "<br/>");
    //                    }
    //                    else
    //                    {
    //                        sb.Append("<td class=\"tr_l\" > " + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<br/>");
    //                    }
    //                    if (dtCCDtls.Rows.Count > 0 && Print == 0)
    //                    {
    //                        sb.Append("<a href=\"javascript:;\" class=\"pull-right ad_cc1 js-open-modal\" title=\"Cost Centre\" onclick=\"return CostCentreDisplay('" + objEntityLedgerStatmnt.VoucherId + "');\"><i class=\"fa fa-filter ad_fa _ldr\">CC</i></a>");
    //                    }

    //                    //as per details for journal/credit note/debit note multiple duplicatn present
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                    {
    //                        Cnt++;

    //                        if (Print == 0)
    //                        {
    //                            sb.Append("<a onclick=\"return DivDisplay(" + intRow + "," + objEntityLedgerStatmnt.Ledger + "," + dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() + ");\" class=\"pull-right apd1\" title=\"As Per Details\" style=\"cursor:pointer;\" ><i class=\"fa fa-newspaper-o ad_fa ad_fa1 mar_dtl\"></i> </a><br/>");
    //                            sb.Append("<div id=\"divAsPerDtls" + objEntityLedgerStatmnt.Ledger + intRow + "\" class=\"divCls collapse det_a d_a1\" ></div>");
    //                        }
    //                        else //show as per details on print
    //                        {
    //                            int flag = 0, CntDupDtls = 0;

    //                            StringBuilder sbPop = new StringBuilder();

    //                            sbPop.Append("<div id=\"divAsPerDtls" + objEntityLedgerStatmnt.Ledger + intRow + "\" class=\"divCls\" >");

    //                            for (int intRowDtls = 0; intRowDtls < dtDtls.Rows.Count; intRowDtls++)
    //                            {
    //                                if (dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() == dtDtls.Rows[intRowDtls]["VOCHR_ACCNT_ID"].ToString())
    //                                {
    //                                    if (Convert.ToInt32(dtDtls.Rows[intRowDtls]["VCHRTTLCNT"].ToString()) > 2)//as per details present
    //                                    {
    //                                        if (Convert.ToInt32(dtDtls.Rows[intRowDtls]["VCHRDUPCNT"].ToString()) < 2)//not duplicates
    //                                        {
    //                                            if (dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
    //                                            {
    //                                                if (dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "")
    //                                                {
    //                                                    sbPop.Append("<span>" + dtDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + " " + dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                                                }
    //                                                if (dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
    //                                                {
    //                                                    decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString());
    //                                                    sbPop.Append("<span>" + dtDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + " " + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                                                }
    //                                                flag++;
    //                                            }

    //                                        }
    //                                        else
    //                                        {
    //                                            //if journal/credit note/debit note
    //                                            if (Convert.ToInt32(dtDtls.Rows[intRowDtls]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRowDtls]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRowDtls]["VOCHR_TYPID"].ToString()) == 4)
    //                                            {
    //                                                if (CntDupDtls == Convert.ToInt32(dtDtls.Rows[intRowDtls]["VCHRTTLCNT"].ToString()))
    //                                                {
    //                                                    CntDupDtls = 0;
    //                                                }
    //                                                else
    //                                                {
    //                                                    if (CntDupDtls > 0 && (dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "" || dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != ""))
    //                                                    {
    //                                                        if (dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() != "")
    //                                                        {
    //                                                            sbPop.Append("<span>" + dtDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + dtDtls.Rows[intRowDtls]["DEBIT_AMNT"].ToString() + " DR</span><br/>");
    //                                                        }
    //                                                        if (dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString() != "")
    //                                                        {
    //                                                            decimal CrdtAmnt = 0 - Convert.ToDecimal(dtDtls.Rows[intRowDtls]["CREDIT_AMNT"].ToString());
    //                                                            sbPop.Append("<span>" + dtDtls.Rows[intRowDtls]["LDGR_NAME"].ToString() + "<span class=\"pull-right\">" + CrdtAmnt.ToString() + "CR</span> <br/>");
    //                                                        }
    //                                                        flag++;
    //                                                    }

    //                                                }
    //                                                CntDupDtls++;
    //                                            }
    //                                        }

    //                                    }

    //                                }
    //                            }

    //                            sbPop.Append("</div>");

    //                            sb.Append(sbPop);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Cnt = 0;
    //                    }


    //                    sb.Append("</td>");

    //                    if (Print == 0)
    //                    {
    //                        sb.Append("<td class=\"tr_l\"  >" + "<a title=\"Click to view\" href=\"javascript:;\" onclick=\"return LinkClick('" + Id + "','" + dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString() + "');\" style=\"color:#0058a3;text-align:center\">" + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + "" + "</a></td>");
    //                    }
    //                    else
    //                    {
    //                        sb.Append("<td class=\"tr_l\"  >" + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + "</td>");
    //                    }
    //                    sb.Append("<td class=\"tr_c\"  > " + dtDtls.Rows[intRow]["VOCHR_TYP"].ToString() + "</td>");

    //                    string strDebitAmount = "";
    //                    //as per details for journal/credit note/debit note multiple duplicatn present
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                    {
    //                        strDebitAmount = dtDtls.Rows[intRow]["TOTAL_DEBIT_AMNT"].ToString();
    //                    }
    //                    else
    //                    {
    //                        strDebitAmount = dtDtls.Rows[intRow]["DEBIT_AMNT"].ToString();
    //                    }
    //                    string strNetAmountWithCommaDebit = "";
    //                    if (strDebitAmount != "")
    //                    {
    //                        strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(strDebitAmount, objEntityCommon);
    //                    }
    //                    sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaDebit + "</td>");

    //                    string strCreditAmount = "";
    //                    //as per details for journal/credit note/debit note multiple duplicatn present
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                    {
    //                        strCreditAmount = dtDtls.Rows[intRow]["TOTAL_CREDIT_AMNT"].ToString();
    //                    }
    //                    else
    //                    {
    //                        strCreditAmount = dtDtls.Rows[intRow]["CREDIT_AMNT"].ToString();
    //                    }
    //                    string strNetAmountWithCommaCredit = "";
    //                    if (strCreditAmount != "")
    //                    {
    //                        strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation((0 - Convert.ToDecimal(strCreditAmount)).ToString(), objEntityCommon);
    //                    }
    //                    sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaCredit + "</td>");

    //                    decimal Debit = 0;
    //                    if (strDebitAmount != "")
    //                    {
    //                        Debit = Convert.ToDecimal(strDebitAmount);
    //                    }
    //                    decimal Credit = 0;
    //                    if (strCreditAmount != "")
    //                    {
    //                        Credit = Convert.ToDecimal(strCreditAmount);
    //                    }
    //                    decTotalCredit += Credit;
    //                    decTotalDebit += Debit;

    //                    decimal Closing = 0;
    //                    Closing = Debit + Credit + decPrevsAmnt;
    //                    decTotalClosing += Closing;

    //                    string strNetAmountWithCommaClose = "";
    //                    if (Closing >= 0)
    //                    {
    //                        strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation(Closing.ToString(), objEntityCommon) + " DR";
    //                    }
    //                    else
    //                    {
    //                        strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation((0 - Closing).ToString(), objEntityCommon) + " CR";
    //                    }
    //                    sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaClose + "</td>");
    //                    decPrevsAmnt = Closing;

    //                    sb.Append("<td class=\"tr_l\" >" + dtDtls.Rows[intRow]["VOCHR_DSCRPTN"].ToString() + "</th>");

    //                    sb.Append("</tr>");
    //                }
    //                else
    //                {
    //                    if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRDUPCNT"].ToString()) > 1)
    //                    {
    //                        //duplicate in journal/credit note/debit note
    //                        if (Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 2 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 3 || Convert.ToInt32(dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString()) == 4)
    //                        {
    //                            //if ledger has no either 1 credit/debit entry
    //                            if (Convert.ToInt32(dtDtls.Rows[intRow]["VCHROPPDUP"].ToString()) >= 0)
    //                            {
    //                                CntDup++;
    //                            }

    //                            if (CntDup == (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRTTLCNT"].ToString()) - 1))
    //                            {
    //                                Cnt = 0;
    //                                CntDup = 0;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                //as per details not present
    //                if ((dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString() != VouchrAcntId && Convert.ToInt32(dtDtls.Rows[intRow]["VCHRDUPCNT"].ToString()) < 2) || (Convert.ToInt32(dtDtls.Rows[intRow]["VCHRDUPCNT"].ToString()) > 1))
    //                {

    //                    if (CntDbtCrdt == 0)
    //                    {
    //                        sb.Append("<td class=\"tr_c\"> " + dtDtls.Rows[intRow]["VOCHR_DATE"].ToString() + "</td>");
    //                        sb.Append("<td class=\"tr_l\" > " + dtDtls.Rows[intRow]["LDGR_NAME"].ToString() + "<br/>");
    //                        if (dtCCDtls.Rows.Count > 0 && Print == 0)
    //                        {
    //                            sb.Append("<a href=\"javascript:;\" class=\"pull-right ad_cc1 js-open-modal\" title=\"Cost Centre\" onclick=\"return CostCentreDisplay('" + objEntityLedgerStatmnt.VoucherId + "');\"><i class=\"fa fa-filter ad_fa _ldr\">CC</i></a>");
    //                        }
    //                        sb.Append("</td>");
    //                        if (Print == 0)
    //                        {
    //                            sb.Append("<td class=\"tr_l\"  >" + "<a title=\"Click to view\" href=\"javascript:;\" onclick=\"return LinkClick('" + Id + "','" + dtDtls.Rows[intRow]["VOCHR_TYPID"].ToString() + "');\" style=\"color:#0058a3;text-align:center\">" + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + "" + "</a></td>");
    //                        }
    //                        else
    //                        {
    //                            sb.Append("<td class=\"tr_l\"  >" + dtDtls.Rows[intRow]["VOCHR_REF"].ToString() + "</td>");
    //                        }

    //                        sb.Append("<td class=\"tr_c\"  > " + dtDtls.Rows[intRow]["VOCHR_TYP"].ToString() + "</td>");

    //                        string strDebitAmount = dtDtls.Rows[intRow]["TOTAL_DEBIT_AMNT"].ToString();
    //                        string strNetAmountWithCommaDebit = "";
    //                        if (strDebitAmount != "")
    //                        {
    //                            strNetAmountWithCommaDebit = objBusiness.AddCommasForNumberSeperation(strDebitAmount, objEntityCommon);
    //                        }
    //                        sb.Append("<td class=\"tr_r\"   >" + strNetAmountWithCommaDebit + "</td>");

    //                        string strCreditAmount = dtDtls.Rows[intRow]["TOTAL_CREDIT_AMNT"].ToString();
    //                        string strNetAmountWithCommaCredit = "";
    //                        if (strCreditAmount != "")
    //                        {
    //                            strNetAmountWithCommaCredit = objBusiness.AddCommasForNumberSeperation((0 - Convert.ToDecimal(strCreditAmount)).ToString(), objEntityCommon);
    //                        }
    //                        sb.Append("<td class=\"tr_r\"   >" + strNetAmountWithCommaCredit + "</td>");

    //                        decimal Debit = 0;
    //                        if (strDebitAmount != "")
    //                        {
    //                            Debit = Convert.ToDecimal(strDebitAmount);
    //                        }
    //                        decimal Credit = 0;
    //                        if (strCreditAmount != "")
    //                        {
    //                            Credit = Convert.ToDecimal(strCreditAmount);
    //                        }
    //                        decTotalCredit += Credit;
    //                        decTotalDebit += Debit;

    //                        decimal Closing = 0;
    //                        Closing = Debit + Credit + decPrevsAmnt;
    //                        decTotalClosing += Closing;

    //                        string strNetAmountWithCommaClose = "";
    //                        if (Closing >= 0)
    //                        {
    //                            strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation(Closing.ToString(), objEntityCommon) + " DR";
    //                        }
    //                        else
    //                        {
    //                            strNetAmountWithCommaClose = objBusiness.AddCommasForNumberSeperation((0 - Closing).ToString(), objEntityCommon) + " CR";
    //                        }

    //                        sb.Append("<td class=\"tr_r\"  >" + strNetAmountWithCommaClose + "</td>");
    //                        decPrevsAmnt = Closing;

    //                        sb.Append("<td class=\"tr_l\" >" + dtDtls.Rows[intRow]["VOCHR_DSCRPTN"].ToString() + "</th>");

    //                        sb.Append("</tr>");

    //                    }
    //                }
    //            }

    //            VouchrAcntId = dtDtls.Rows[intRow]["VOCHR_ACCNT_ID"].ToString();
    //        }

    //        //total amount

    //        if (OpengBal >= 0)
    //        {
    //            decTotalDebit = decTotalDebit + OpengBal;
    //        }
    //        else
    //        {
    //            decTotalCredit = decTotalCredit + OpengBal;
    //        }
    //        decTotalClosing = decTotalDebit + decTotalCredit;

    //        string strNetAmountWithCommaTotalDebit = "0";
    //        if (decTotalDebit != 0)
    //        {
    //            strNetAmountWithCommaTotalDebit = objBusiness.AddCommasForNumberSeperation(decTotalDebit.ToString(), objEntityCommon);
    //        }

    //        string strNetAmountWithCommaTotalCredit = "0";
    //        if (decTotalCredit != 0)
    //        {
    //            strNetAmountWithCommaTotalCredit = objBusiness.AddCommasForNumberSeperation((0 - decTotalCredit).ToString(), objEntityCommon);
    //        }

    //        string strNetAmountWithComma = "";
    //        if (decPrevsAmnt >= 0)
    //        {
    //            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(decTotalClosing.ToString(), objEntityCommon) + " DR";
    //        }
    //        else
    //        {
    //            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decTotalClosing).ToString(), objEntityCommon) + " CR";
    //        }

    //        sb.Append("<tr>");
    //        sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
    //        sb.Append("<td class=\"tr_r txt_rd bg1\" >Total Balance</th>");
    //        sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
    //        sb.Append("<td class=\"tr_r txt_rd bg1\" ></th>");
    //        sb.Append("<td class=\"tr_r txt_gr bg1\" >" + strNetAmountWithCommaTotalDebit + " DR</th>");
    //        sb.Append("<td class=\"tr_r txt_rd bg1\" >" + strNetAmountWithCommaTotalCredit + " CR</th>");
    //        if (decPrevsAmnt >= 0)
    //        {
    //            sb.Append("<td class=\"tr_r txt_gr bg1\" >" + strNetAmountWithComma + "</th>");
    //        }
    //        else
    //        {
    //            sb.Append("<td class=\"tr_r txt_rd bg1\" >" + strNetAmountWithComma + "</th>");
    //        }
    //        sb.Append("<td class=\"tr_l txt_rd bg1\" ></th>");
    //        sb.Append("</tr>");

    //        //Subledger grouping amnt

    //        decSubLdgrDebit += decTotalDebit;
    //        decSubLdgrCredit += decTotalCredit;
    //        decSubLdgrClosing += decTotalClosing;

    //        if (cbxSubLedgerSts.Checked == true && (RecordsCnt == numberOfRecords || RecordsCnt == 0))
    //        {
    //            if (GrpCnt % 2 == 0)
    //            {
    //                sb.Append("<tr class=\"tr_grp_odd\">");
    //            }
    //            else
    //            {
    //                sb.Append("<tr class=\"tr_grp_even\">");
    //            }
    //            sb.Append("<th class=\"tr_c\" ></th>");
    //            sb.Append("<th class=\"tr_l\">" + SubLedgerName + "</th>");
    //            sb.Append("<th class=\"tr_l\" ></th>");
    //            sb.Append("<th class=\"tr_c\" ></th>");

    //            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrDebit).ToString(), objEntityCommon) + " DR";

    //            sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");

    //            strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrCredit).ToString(), objEntityCommon) + " CR";

    //            sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");

    //            if (decSubLdgrClosing >= 0)
    //            {
    //                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((decSubLdgrClosing).ToString(), objEntityCommon) + " DR";
    //                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");
    //            }
    //            else
    //            {
    //                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation((0 - decSubLdgrClosing).ToString(), objEntityCommon) + " CR";
    //                sb.Append("<th class=\"tr_r\" >" + strNetAmountWithComma + "</th>");
    //            }
    //            sb.Append("<td class=\"tr_l\" ></th>");
    //            sb.Append("</tr>");

    //            RecordsCnt = 0;
    //            GrpCnt++;
    //        }

    //        decTotalCredit = 0;
    //        decTotalDebit = 0;
    //        decPrevsAmnt = 0;
    //    }

    //    sb.Append("</tbody>");

    //    sb.Append("</table>");

    //    string str = sb.ToString();

    //    return sb.ToString();
    //}

    public void ConvertDataTableToPrint(DataTable dt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayerReports objBusinessReport = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityReports.Corporate_Id = objEntityReports.Corporate_Id;
        objEntityReports.Organisation_Id = objEntityReports.Organisation_Id;
        DataTable dtCorp = objBusinessReport.Read_Corp_Details(objEntityReports);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";

        string strTitle = "LEDGER STATEMENT";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        StringBuilder sbCap = new StringBuilder();
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strUsrName = "", strFilters = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }

        strFilters = "<tr><td><B>" + strTitle + " DETAIL</B></td></tr>";
        if (txtFromdate.Value != "")
        {
            strFilters += "<tr><td><B> FROM DATE  : </B>" + txtFromdate.Value + "</td></tr>";
        }
        if (txtTodate.Value != "")
        {
            strFilters += "<tr><td><B> TO DATE  : </B>" + txtTodate.Value + "</td></tr>";
        }
  
        //if (hiddenLedgerNames.Value != "")
        //{
        //    strFilters += "<tr><td><B> LEDGERS  : </B>" + hiddenLedgerNames.Value + "</td></tr>";
        //}

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strFilters + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        divPrintCaption.InnerHtml = sbCap.ToString();

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
            headtable.AddCell(new PdfPCell(new Phrase("LEDGER STATEMENT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
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