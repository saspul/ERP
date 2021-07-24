using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using BL_Compzit.BusinessLayer_GMS;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class FMS_FMS_Reports_fms_Postdated_Cheque_fms_Postdated_Cheque_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intCorpId = 0;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
            clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString()); 
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { 
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }

            DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
            txtDateTo.Value = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString()).ToString("dd-MM-yyyy");
            LoadAccountHeadLedger();
            if (txtDateTo.Value != "")
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtDateTo.Value);
            objEntity_Cheque.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTransactionType.SelectedItem.Value);
            if (radio_Bank.Checked == true)
            {
                objEntity_Cheque.IssueStatus = 0;
                if (ddlBank.SelectedItem.Value != "--SELECT--" && ddlBank.SelectedItem.Value != "")
                    objEntity_Cheque.LedgerId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            }
            else if (radio_Party.Checked == true)
            {
                objEntity_Cheque.IssueStatus = 1;
                //if (ddlParty.SelectedItem.Value != "--SELECT--" && ddlParty.SelectedItem.Value != "")
                //{
                    if (HiddenPartyId.Value != "")
                        objEntity_Cheque.PartId = Convert.ToInt32(HiddenPartyId.Value);
                //}
            }
           DataTable dtList = objBusiness_Cheque.Read_PostdatedCheque_Report_List(objEntity_Cheque);
           DivReport.InnerHtml = ConvertDataTableToHTML(dtList);
         //  divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList);
         //  divPrintCaption.InnerHtml = PrintCaption(objEntity_Cheque);
            
        }
    }

    public void LoadAccountHeadLedger()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
        DataTable dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
        if (dtAccountGrp.Rows.Count > 0)
        {
            ddlBank.DataSource = dtAccountGrp;
            ddlBank.DataTextField = "LDGR_NAME";
            ddlBank.DataValueField = "LDGR_ID";
            ddlBank.DataBind();

        }
        ddlBank.Items.Insert(0, "--SELECT--");
    }
    [WebMethod]
    public static string LoadPartyLedger(string Type, string intOrgID, string intCorrpID)
    {
        string result = "";
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        objEntity_Cheque.Organisation_id = Convert.ToInt32(intOrgID);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(intCorrpID);
        DataTable dtChequeBook = new DataTable();
        if(Convert.ToInt32(Type)==0)
         dtChequeBook = objBusiness_Cheque.Read_SupplierLeadger(objEntity_Cheque);
        else if (Convert.ToInt32(Type) == 1)
         dtChequeBook = objBusiness_Cheque.Read_CustmerLeadger(objEntity_Cheque);
        if (dtChequeBook.Rows.Count > 0)
        {
            dtChequeBook.TableName = "dtTablePartyLedger";
            using (StringWriter sw = new StringWriter())
            {
                dtChequeBook.WriteXml(sw);
                result = sw.ToString();
            }
        }
        return result;
    }


    public string ConvertDataTableToHTML(DataTable dt)
    {
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["ORGID"] != null)
        {
            objEntityAudit.Organisation_id = Convert.ToInt32(Session["ORGID"]);
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAudit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
        DateTime acntClsDate = DateTime.MinValue;
        if (dtAcntClsDate.Rows.Count > 0)
        {
            if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
            {
                acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());

            }
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table-bordered\" width=\"100%\">";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<th class=\"th_b3 td1 tr_l\">REF#";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in \" placeholder=\"REFERENCE NUMBER\" type=\"text\">";
        strHtml += "</th >";
        if (radio_Party.Checked == true)
        {
            strHtml += "<th class=\"th_b3 tr_l\">BANK";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in \" placeholder=\"BANK\" type=\"text\">";
            strHtml += "</th >";
        }
        else if (radio_Bank.Checked == true)
        {
            strHtml += "<th class=\"th_b3 tr_l\">PARTY";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in \" placeholder=\"PARTY\" type=\"text\">";
            strHtml += "</th >";
        }
        strHtml += "<th class=\"th_b6 tr_l\">CHEQUE #";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in \" placeholder=\"CHEQUE #\" type=\"text\">";
        strHtml += "</th >";
        strHtml += "<th class=\"th_b6\">CHEQUE DATE";
        strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"CHEQUE DATE\"  type=\"text\">";
        strHtml += "</th >";
        strHtml += "<th class=\"th_b4 tr_r\">CHEQUE AMOUNT";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"CHEQUE AMOUNT\" type=\"text\">";
        strHtml += "</th >";
        strHtml += "  <th class=\"th_b4\">Clearance Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string strLedgerIds = "";
        decimal decSum = 0;
        for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
        {
            if (radio_Bank.Checked == true)
            {
                if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString())))
                {
                    strHtml += "<tr class=\"tr1\"> <th>Cheque Outward- " + dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString() + "</th><th></th><th></th><th></th><th></th><th></th></tr>";
                       strHtml += " <tr>";
                       strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString() + "</td>";
                       strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PARTY_LDGR"].ToString() + "</td>";
                       strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                       strHtml += " <td >" + dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
                       objentcommn.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                       string CoomAmount = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn);
                       strHtml += " <td class=\"tr_r\">" + CoomAmount + " " + dt.Rows[RowCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                       if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                           decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));

                       strHtml += " <td >" + dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>";

                       strHtml += " </tr>";
                }
                else
                {
                    strHtml += " <tr>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString() + "</td>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PARTY_LDGR"].ToString() + "</td>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                    strHtml += " <td >" + dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
                    objentcommn.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                    string CoomAmount = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn);
                    strHtml += " <td class=\"tr_r\">" + CoomAmount + " " + dt.Rows[RowCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                    if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                        decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));

                    strHtml += " <td >" + dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>";

                    strHtml += " </tr>";
                }
                if (strLedgerIds == "")
                    strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                else
                    strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
            }
            else if (radio_Party.Checked == true)
            {
                if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString())))
                {
                    strHtml += "<tr class=\"tr1\"> <th>Cheque Outward- " + dt.Rows[RowCount]["PARTY_LDGR"].ToString() + "</th><th></th><th></th><th></th><th></th><th></th></tr>";
                    strHtml += " <tr>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString() + "</td>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString() + "</td>";
                    strHtml += " <td  class=\"tr_l\">" + dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                    strHtml += " <td >" + dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
                    objentcommn.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                    string CoomAmount = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn);
                    strHtml += " <td class=\"tr_r\">" + CoomAmount + " " + dt.Rows[RowCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                    if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                        decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));

                    strHtml += " <td >" + dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>";

                    strHtml += " </tr>";
                }
                else
                {
                    strHtml += " <tr>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString() + "</td>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString() + "</td>";
                    strHtml += " <td class=\"tr_l\">" + dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                    strHtml += " <td >" + dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
                    objentcommn.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                    string CoomAmount = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn);
                    strHtml += " <td class=\"tr_r\">" + CoomAmount + " " + dt.Rows[RowCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                    if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                        decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));

                    strHtml += " <td >" + dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>";

                    strHtml += " </tr>";
                }
                if (strLedgerIds == "")
                    strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                else
                    strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();



            }

        }
        string Amount = objBusinessLayer.AddCommasForNumberSeperation(Convert.ToString(decSum), objentcommn);
    
        strHtml += "</tbody>";
        strHtml += " <tfoot> <tr class=\"tr1\">";
        strHtml += "  <th class=\"tr_c txt_rd bg1\">Total</th><th class=\"tr_c txt_rd bg1\"></th><th class=\"tr_c txt_rd bg1\"></th><th class=\"tr_c txt_rd bg1\"></th>";
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                strHtml += " <th  class=\"tr_r txt_rd bg1\">" + Amount + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</th>";
        }
        else
            strHtml += " <th  class=\"tr_r txt_rd bg1\">0.00</th>";
        strHtml += "  <th  class=\"tr_l txt_blu bg1\"></th>";
        strHtml += "  </tr></tfoot>";
        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    public void Generate_PDF(DataTable dt, clsEntity_Postdated_Cheque objEntity_Cheque)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        string strAsonDate = txtDateTo.Value;
        string strStatus = ddlStatus.Items[ddlStatus.SelectedIndex].Text;
        string strTransactionTyp = ddlTransactionType.Items[ddlTransactionType.SelectedIndex].Text;
        string strCategory = "", strBank = "", strParty = "";
        if (radio_Bank.Checked == true)
        {
            strCategory = "Bank";
            if (ddlBank.SelectedItem.Value != "--SELECT--")
            {
                strBank = ddlBank.Items[ddlBank.SelectedIndex].Text;
            }
        }
        else
        {
            strCategory = "Party";
            if (HiddenPartyText.Value != "")
            {
                strParty = HiddenPartyText.Value;
            }
        }

        int intOrgId = 0, Decimalcount = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.POSTDATED_CHEQUE_PDF);
        objEntityCommon.CorporateID = intCorpId;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "PostDatedCheque_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 50f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

        if (dt.Rows.Count > 0)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }

                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PDFHeader();
                document.Open();

                //filter section
                PdfPTable filterTable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                filterTable.SetWidths(footrsBody1);
                filterTable.WidthPercentage = 100;

                filterTable.AddCell(new PdfPCell(new Phrase("As On Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(strAsonDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                filterTable.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(strStatus, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                filterTable.AddCell(new PdfPCell(new Phrase("Transaction Type", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(strTransactionTyp, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                filterTable.AddCell(new PdfPCell(new Phrase("Category", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                filterTable.AddCell(new PdfPCell(new Phrase(strCategory, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                if (strBank != "")
                {
                    filterTable.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    filterTable.AddCell(new PdfPCell(new Phrase(strBank, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if (strParty != "")
                {
                    filterTable.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    filterTable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    filterTable.AddCell(new PdfPCell(new Phrase(strParty, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                document.Add(filterTable);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(6);
                float[] footrsBody = { 25, 23, 9, 12, 16, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                string strCategoryHd = "";
                if (strCategory == "Bank")
                    strCategoryHd = "PARTY";
                else
                    strCategoryHd = "BANK";

                TBCustomer.AddCell(new PdfPCell(new Phrase("Ref#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strCategoryHd, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CHEQUE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CHEQUE DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CHEQUE AMOUNT (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CLEARANCE STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                int MoneyCnt = Decimalcount;
                string format = String.Format("{{0:N{0}}}", MoneyCnt);
                string strLedgerIds = "";
                decimal decSum = 0;
                for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
                {
                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                    string CoomAmount = objBusiness.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);
                    if (radio_Bank.Checked == true)
                    {
                        if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString())))
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Cheque Outward- " + dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 6 });

                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(CoomAmount, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                            {
                                decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {

                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(CoomAmount, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                            {
                                decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        if (strLedgerIds == "")
                            strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                        else
                            strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                    }
                    else if (radio_Party.Checked == true)
                    {
                        if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString())))
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Cheque Outward- " + dt.Rows[RowCount]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 6 });

                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(CoomAmount, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                            {
                                decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(CoomAmount, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                            {
                                decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        if (strLedgerIds == "")
                            strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                        else
                            strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                    }

                }

                string Amount = objBusiness.AddCommasForNumberSeperation(Convert.ToString(decSum), objEntityCommon);
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray, Colspan = 4 });
                if (dt.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(Amount + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(Amount, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });

                document.Add(TBCustomer);


                //last
                document.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=PostDatedCheque_" + strNextNumber + ".pdf");
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }
        else
        {
        }
    }
    public DataTable GetTable()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
        if (txtDateTo.Value != "")
            objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtDateTo.Value);
        objEntity_Cheque.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTransactionType.SelectedItem.Value);
        if (radio_Bank.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 0;
            if (ddlBank.SelectedItem.Value != "--SELECT--" && ddlBank.SelectedItem.Value != "")
                objEntity_Cheque.LedgerId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        else if (radio_Party.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 1;
            if (HiddenPartyId.Value != "")
                objEntity_Cheque.PartId = Convert.ToInt32(HiddenPartyId.Value);
        }
        DataTable dt = objBusiness_Cheque.Read_PostdatedCheque_Report_List(objEntity_Cheque);

        string strAsonDate = txtDateTo.Value;
        string strStatus = ddlStatus.Items[ddlStatus.SelectedIndex].Text;
        string strTransactionTyp = ddlTransactionType.Items[ddlTransactionType.SelectedIndex].Text;
        string strCategory = "", strBank = "", strParty = "";
        if (radio_Bank.Checked == true)
        {
            strCategory = "Bank";
            if (ddlBank.SelectedItem.Value != "--SELECT--")
            {
                strBank = ddlBank.Items[ddlBank.SelectedIndex].Text;
            }
        }
        else
        {
            strCategory = "Party";
            if (HiddenPartyText.Value != "")
            {
                strParty = HiddenPartyText.Value;
            }
        }

        string strCategoryHd = "";
        if (strCategory == "Bank")
            strCategoryHd = "PARTY";
        else
            strCategoryHd = "BANK";

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }


        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("POSTDATED CHEQUE REPORT", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));


        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("As On Date :", '"' + strAsonDate + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("Status :", '"' + strStatus + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("Transaction Type :", '"' + strTransactionTyp + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("Category :", '"' + strCategory + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (strBank != "")
            table.Rows.Add(strCategory + " :", '"' + strBank + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (strParty != "")
            table.Rows.Add(strCategory + " :", '"' + strParty + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (dt.Rows.Count > 0)
        {
            table.Rows.Add("REF#", '"' + strCategoryHd + '"', "CHEQUE #", "CHEQUE DATE", "CHEQUE AMOUNT (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", "CLEARANCE STATUS");
        }
        else
        {
            table.Rows.Add("REF#", '"' + strCategoryHd + '"', "CHEQUE #", "CHEQUE DATE", "CHEQUE AMOUNT", "CLEARANCE STATUS");
        }
        int MoneyCnt = Decimalcount;
        string format = String.Format("{{0:N{0}}}", MoneyCnt);
        string strLedgerIds = "";
        decimal decSum = 0;

        if (dt.Rows.Count > 0)
        {

            for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[RowCount]["CRNCMST_ID"].ToString());
                string CoomAmount = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);

                string CHEQUEOUTWRD = "";

                string REFID = "";
                string CATEGORY = "";
                string CHEQUENO = "";
                string CHEQUEDATE = "";
                string CHEQUEAMT = "";
                string CLEARANCESTS = "";

                if (radio_Bank.Checked == true)
                {
                    if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString())))
                    {
                        CHEQUEOUTWRD = "Cheque Outward- " + dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString();
                        table.Rows.Add('"' + CHEQUEOUTWRD + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                    }
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            REFID = dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString();
                        }
                        if (intColumnBodyCount == 2)
                        {
                            CATEGORY = dt.Rows[RowCount]["PARTY_LDGR"].ToString();
                        }
                        if (intColumnBodyCount == 3)
                        {
                            CHEQUENO = dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString();
                        }
                        if (intColumnBodyCount == 4)
                        {
                            CHEQUEDATE = dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString();
                        }
                        if (intColumnBodyCount == 5)
                        {
                            CHEQUEAMT = CoomAmount;
                        }
                        if (intColumnBodyCount == 6)
                        {
                            CLEARANCESTS = dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString();
                        }
                    }
                    table.Rows.Add('"' + REFID + '"', '"' + CATEGORY + '"', '"' + CHEQUENO + '"', '"' + CHEQUEDATE + '"', '"' + CHEQUEAMT + '"', '"' + CLEARANCESTS + '"');

                    if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                    {
                        decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                    }

                    if (strLedgerIds == "")
                        strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                    else
                        strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                }
                else if (radio_Party.Checked == true)
                {
                    if (!(strLedgerIds.Contains(dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString())))
                    {
                        CHEQUEOUTWRD = "Cheque Outward- " + dt.Rows[RowCount]["PARTY_LDGR"].ToString();
                        table.Rows.Add('"' + CHEQUEOUTWRD + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                    }

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            REFID = dt.Rows[RowCount]["PST_CHEQUE_REF"].ToString();
                        }
                        if (intColumnBodyCount == 2)
                        {
                            CATEGORY = dt.Rows[RowCount]["ACCOUNT_LDGR"].ToString();
                        }
                        if (intColumnBodyCount == 3)
                        {
                            CHEQUENO = dt.Rows[RowCount]["CHQ_DTLS_NUMBER"].ToString();
                        }
                        if (intColumnBodyCount == 4)
                        {
                            CHEQUEDATE = dt.Rows[RowCount]["PST_CHEQUE_DATE"].ToString();
                        }
                        if (intColumnBodyCount == 5)
                        {
                            CHEQUEAMT = CoomAmount;
                        }
                        if (intColumnBodyCount == 6)
                        {
                            CLEARANCESTS = dt.Rows[RowCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString();
                        }
                    }
                    table.Rows.Add('"' + REFID + '"', '"' + CATEGORY + '"', '"' + CHEQUENO + '"', '"' + CHEQUEDATE + '"', '"' + CHEQUEAMT + '"', '"' + CLEARANCESTS + '"');


                    if (dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                    {
                        decSum = decSum + (Convert.ToDecimal(dt.Rows[RowCount]["CHQ_DTLS_AMOUNT"].ToString()));
                    }

                    if (strLedgerIds == "")
                        strLedgerIds = dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                    else
                        strLedgerIds = strLedgerIds + "," + dt.Rows[RowCount]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                }
            }

            string Amount = objBusinessLayer.AddCommasForNumberSeperation(Convert.ToString(decSum), objEntityCommon);
            string TOTAL = Amount;
            table.Rows.Add("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + TOTAL + '"', '"' + FORNULL + '"');
        }
        return table;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
        if (txtDateTo.Value != "")
            objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtDateTo.Value);
        objEntity_Cheque.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTransactionType.SelectedItem.Value);
        if (radio_Bank.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 0;
            if (ddlBank.SelectedItem.Value != "--SELECT--" && ddlBank.SelectedItem.Value != "")
                objEntity_Cheque.LedgerId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        else if (radio_Party.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 1;
            //if (ddlParty.SelectedItem.Value != "--SELECT--" && ddlParty.SelectedItem.Value != "")
            //{
                if (HiddenPartyId.Value != "")
                    objEntity_Cheque.PartId = Convert.ToInt32(HiddenPartyId.Value);
            //}
        }
        DataTable dtList = objBusiness_Cheque.Read_PostdatedCheque_Report_List(objEntity_Cheque);
        DivReport.InnerHtml = ConvertDataTableToHTML(dtList);
      //  divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList);
      //  divPrintCaption.InnerHtml = PrintCaption(objEntity_Cheque);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
        if (txtDateTo.Value != "")
            objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtDateTo.Value);
        objEntity_Cheque.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTransactionType.SelectedItem.Value);
        if (radio_Bank.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 0;
            if (ddlBank.SelectedItem.Value != "--SELECT--" && ddlBank.SelectedItem.Value != "")
                objEntity_Cheque.LedgerId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        else if (radio_Party.Checked == true)
        {
            objEntity_Cheque.IssueStatus = 1;
            if (HiddenPartyId.Value != "")
                objEntity_Cheque.PartId = Convert.ToInt32(HiddenPartyId.Value);
        }
        DataTable dtList = objBusiness_Cheque.Read_PostdatedCheque_Report_List(objEntity_Cheque);
        Generate_PDF(dtList, objEntity_Cheque);
    }
    public string PrintCaption(clsEntity_Postdated_Cheque objEntity_Cheque)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
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
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "POSTDATED CHEQUE REPORT";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "", strFromDate = "", strCustName = "", strCustCode = "", strCurrency = "", strCreLmt = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string Sdate = objEntity_Cheque.ChequeIssueDate.ToString("dd-MM-yyyy");
        //     GuaranteDivsn = "<B>TO DATE  : </B>" + Sdate;
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
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strUsrName = "";
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
        if (strFromDate != "")
        {
            strFromDate = "<tr><td class=\"RprtDiv\">" + strFromDate + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }


        if (strCustName != "")
        {
            strCustName = "<tr><td class=\"RprtDiv\">" + strCustName + "</td></tr>";
        }
        if (strCustCode != "")
        {
            strCustCode = "<tr><td class=\"RprtDiv\">" + strCustCode + "</td></tr>";
        }
        if (strCreLmt != "")
        {
            strCreLmt = "<tr><td class=\"RprtDiv\">" + strCreLmt + "</td></tr>";
        }
        if (strCurrency != "")
        {
            strCurrency = "<tr><td class=\"RprtDiv\">" + strCurrency + "</td></tr>";
        }

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strFromDate + strGuaranteDivsn + strCustName + strCustCode + strCreLmt + strCurrency + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


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
            headtable.AddCell(new PdfPCell(new Phrase("POSTDATED CHEQUE REPORT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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

    protected void btnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.POSTDATED_CHEQUE_CSV);
            string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Postdated Cheque/PostDatedChequeReport_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "PostDatedChequeReport_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE_CSV);
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }

        }
        catch (Exception)
        { }
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


