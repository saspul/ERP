using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CL_Compzit;
using System.IO;
using System.Web;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessLayer_Receipt_Account
    {
        static int globfalg = 0;
        static int globhead = 0;
        clsDataLayer_Receipt_Account objDataRcpt = new clsDataLayer_Receipt_Account();
        public DataTable ReadCurrency(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadCurrency(objEntity);
            return dtRcpt;
        }
        public DataTable ReadDefualtCurrency(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadDefualtCurrency(objEntity);
            return dtRcpt;
        }

        public DataTable ReadAccountLedger(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadAccountLedger(objEntity);
            return dtRcpt;
        }

        public DataTable ReadOepningBalById(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadOepningBalById(objEntity);
            return dtRcpt;
        }
        public DataTable ReadLeadgerReceipt(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadLeadgerReceipt(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenter(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadCostCenter(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSalesBalance(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadSalesBalance(objEntity);
            return dtRcpt;
        }

        //26-06-2019

        public DataTable CheckDupBankAcNum(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.CheckDupBankAcNum(objEntity);
            return dtRcpt;
        }


        public DataTable ReadSalesbyId(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadSalesbyId(objEntity);
            return dtRcpt;
        }
        public DataTable AccntBalancebyId(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.AccntBalancebyId(objEntity);
            return dtRcpt;
        }
        public void InsertReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter)
        {
            objDataRcpt.InsertReceiptDtls(ObjEntityReceipt, ObjEntityReceiptLedger, ObjEntityReceiptCostCenter);
        }
        public DataTable ReadReceiptList(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadReceiptList(objEntity);
            return dtRcpt;
        }
        public DataTable ReadReceptDetailsById(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadReceptDetailsById(objEntity);
            return dtRcpt;
        }
        public DataTable ReadReceptLedgerDetailsById(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadReceptLedgerDetailsById(objEntity);
            return dtRcpt;
        }
        public DataTable ReadReceptLedgerDetailsByIdforPrint(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadReceptLedgerDetailsByIdforPrint(objEntity);
            return dtRcpt;
        }
        public DataTable ReadReceptCostcntrDetailsById(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadReceptCostcntrDetailsById(objEntity);
            return dtRcpt;
        }
        public void updateReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter,List<clsEntity_Receipt_Account> ObjEntityReceipLedger_Insert,List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Update,List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Delete,List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Insert,List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_update,List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Delete)
        {
            objDataRcpt.updateReceiptDtls(ObjEntityReceipt, ObjEntityReceiptLedger, ObjEntityReceiptCostCenter, ObjEntityReceipLedger_Insert, ObjEntityReceiptLedger_Update, ObjEntityReceiptLedger_Delete, ObjEntityReceiptCostCenter_Insert, ObjEntityReceiptCostCenter_update, ObjEntityReceiptCostCenter_Delete);
        }

        public void ConfirmReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter, List<clsEntity_Receipt_Account> ObjEntityReceipLedger_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Update, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_update, List<clsEntity_Receipt_Account> objEntityUpdateOB)
        {
            objDataRcpt.ConfirmReceiptDtls(ObjEntityReceipt, ObjEntityReceiptLedger, ObjEntityReceiptCostCenter, ObjEntityReceipLedger_Insert, ObjEntityReceiptLedger_Update, ObjEntityReceiptCostCenter_Insert, ObjEntityReceiptCostCenter_update, objEntityUpdateOB);

        }
        public void CancelReceiptById(clsEntity_Receipt_Account ObjEntityReceipt)
        {
            objDataRcpt.CancelReceiptById(ObjEntityReceipt);
        }
        public void ConfirmReceiptById(clsEntity_Receipt_Account ObjEntityReceipt)
        {
            objDataRcpt.ConfirmReceiptById(ObjEntityReceipt);
        }

        public DataTable ReadAcntClsingDate(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadAcntClsingDate(objEntity);
            return dtRcpt;
        }
        public void ReOpenById(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter, List<clsEntity_Receipt_Account> objEntityUpdateOB)
        {
            objDataRcpt.ReOpenById(ObjEntityReceipt, ObjEntityReceiptLedger, ObjEntityReceiptCostCenter, objEntityUpdateOB);
        }
        public DataTable ReadCrncyAbrvtn(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadCrncyAbrvtn(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadBank(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadBank(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataRcpt.readRefFormate(ObjEntitySales);
            return dtDivision;
        }

        public DataTable readFinancialYear(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataRcpt.readFinancialYear(ObjEntitySales);
            return dtDivision;
        }
        public DataTable readAcntClsDate(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataRcpt.readAcntClsDate(ObjEntitySales);
            return dtDivision;
        }
        public DataTable ReadRefNumberByDate(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataRcpt.ReadRefNumberByDate(ObjEntitySales);
            return dtDivision;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataRcpt.ReadRefNumberByDateLast(ObjEntitySales);
            return dtDivision;
        }
        public DataTable ReadCorpDtls(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadCorpDtls(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadUserName(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadUserName(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable CheckReceiptCnclSts(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.CheckReceiptCnclSts(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadCostGroup1(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadCostGroup1(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadCostGroup2(clsEntity_Receipt_Account ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataRcpt.ReadCostGroup2(ObjEntitySales);
            return dtSaleCancelChk;
        }

        public void DeleteSaleLedgers(List<clsEntity_Receipt_Account> ObjEntityReceiptLedger)
        {
            objDataRcpt.DeleteSaleLedgers(ObjEntityReceiptLedger);
        }
        //newwwwwwwwwwwwwwwwwwwwwwwww
        public DataTable ReadCreditNoteList(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadCreditNoteList(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCreditNoteDtls(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataRcpt.ReadCreditNoteDtls(objEntity);
            return dtRcpt;
        }
        //newwwwwwwwwwwwwwwwwwwwww

        public DataTable ReadDebitNoteList(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = objDataRcpt.ReadDebitNoteList(objEntity);
            return dtRcpt;
        }
        public DataTable ReadDebitNoteDtls(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = objDataRcpt.ReadDebitNoteDtls(objEntity);
            return dtRcpt;
        }

        public DataTable ReadPurchaseReturnbyId(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = objDataRcpt.ReadPurchaseReturnbyId(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSalesReturnBalance(clsEntity_Receipt_Account objEntity)
        {
            DataTable dtRcpt = objDataRcpt.ReadSalesReturnBalance(objEntity);
            return dtRcpt;
        }






        public string PdfPrintVersion1(string strrId, DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Receipt_Account ObjEntitySales, string PreparedBy, string CheckedBy, string crncyAbrvt, string crncyId, int Version_flg)
        {

            int precision = 0;
            if (dt.Rows[0]["DCML_CNT"].ToString() != "")
            {
                precision = Convert.ToInt32(dt.Rows[0]["DCML_CNT"].ToString());
            }
            string format = String.Format("{{0:N{0}}}", precision);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntitySales.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
            }
            if (ObjEntitySales.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
            }
            if (crncyId != "")
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_PRINT);
            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

            string strImageName = "Receipt_Invoice" + strrId + "_" + strNextNumber + ".pdf";

            Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            string strRet = "";
            try
            {

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    document.Open();


                    PdfPTable headImg = new PdfPTable(2);
                    float[] headersHeading = { 60, 40 };
                    headImg.SetWidths(headersHeading);
                    headImg.WidthPercentage = 100;

                    string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
                    if (dtCorp.Rows.Count > 0)
                    {
                        if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                            strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                    }

                    var FontBlue = new BaseColor(0, 174, 239);
                    var FontBlueGrey = new BaseColor(79, 167, 206);

                    if (strImageLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(100f, 80f);
                        headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                    }

                    if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")

                        headImg.AddCell(new PdfPCell(new Phrase(" RECEIPT", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                    else
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT RECEIPT", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                    document.Add(headImg);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 50, 50 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    if (dtCorp.Rows.Count > 0)
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    }

                    document.Add(footrtable);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtables = new PdfPTable(2);
                    float[] footrsBodys = { 10, 90 };
                    footrtables.SetWidths(footrsBodys);
                    footrtables.WidthPercentage = 100;

                    footrtables.AddCell(new PdfPCell(new Phrase("Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RECPT_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RECPT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    document.Add(footrtables);

                    if (dtProduct.Rows.Count > 0)
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        var FontGrey = new BaseColor(134, 152, 160);
                        var FontBordrGrey = new BaseColor(236, 236, 236);
                        var FontBordrBlack = new BaseColor(138, 138, 138);

                        PdfPTable table2 = new PdfPTable(2);
                        float[] tableBody2 = { 70, 30 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.HeaderRows = 1;//get header column in all pages

                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        
                        decimal TOTAL = 0;
                        for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                        {
                            decimal decAmnt = 0;
                            if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
                            {
                                decAmnt = Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
                            }
                            string valuestringAmnt = String.Format(format, decAmnt);
                            table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
                            {
                                TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
                            }
                        }
                        string valuestringAmnt1 = String.Format(format, TOTAL);
                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                        var FontColour = new BaseColor(216, 49, 61);
                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        
                        FontColour = new BaseColor(0, 174, 239);

                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

                        document.Add(table2);
                    }

                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "")
                    {
                        var FontColour = new BaseColor(0, 174, 239);

                        if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "3")
                        {
                            PdfPTable foottrtables = new PdfPTable(2);
                            float[] footrssBodys = { 30, 70 };
                            foottrtables.SetWidths(footrssBodys);
                            foottrtables.WidthPercentage = 100;

                            foottrtables.AddCell(new PdfPCell(new Phrase("Payment Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "0")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_CHEQUE_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_CHEQUE_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                            }
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "1")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["RCPT_DD_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_DD_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }

                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                            }
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "2")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "0")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "1")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "2")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "3")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }

                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                            }
                            foottrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                            foottrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                            document.Add(foottrtables);
                        }
                    }

                    if (dt.Rows[0]["RECPT_DSCRPTN"].ToString().Trim() != "")
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        document.Add(new Paragraph(new Chunk(dt.Rows[0]["RECPT_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    }

                    float pos1 = writer.GetVerticalPosition(false);

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);

                    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
                    {

                        table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    else
                    {
                        table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    }
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                    if (pos1 > 140)
                    {
                        table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
                    }

                    document.Close();
                }

                strRet = strImagePath + strImageName;
            }
            catch (Exception)
            {
                document.Close();
            }

            return strRet;


        }

        ////////////////////////-------------old-----------////////////////////////////
        //public string PdfPrintVersion2(string strrId, DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Receipt_Account ObjEntitySales, string PreparedBy, string CheckedBy, string crncyAbrvt, string crncyId, int Version_flg, DataTable dtSales, DataTable invoiceDtl)
        //{

        //    int precision = 0;
        //    if (dt.Rows[0]["DCML_CNT"].ToString() != "")
        //    {
        //        precision = Convert.ToInt32(dt.Rows[0]["DCML_CNT"].ToString());
        //    }
        //    string format = String.Format("{{0:N{0}}}", precision);

        //    globfalg = Version_flg;
        //    clsCommonLibrary objCommon = new clsCommonLibrary();
        //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);
        //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);

        //    clsEntityCommon objEntityCommon = new clsEntityCommon();
        //    if (ObjEntitySales.Corporate_id != 0)
        //    {
        //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
        //    }
        //    if (ObjEntitySales.Organisation_id != 0)
        //    {
        //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
        //    }
        //    if (crncyId != "")
        //    {
        //        objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
        //    }

        //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_PRINT);
        //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

        //    string strImageName = "Receipt_Invoice" + strrId + "_" + strNextNumber + ".pdf";

        //    Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);

        //    if (Version_flg != 2)
        //    {
        //        document = new Document(PageSize.A4, 50f, 40f, 20f, 30f);
        //    }


        //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

        //    string strRet = "";
        //    try
        //    {

        //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        //        {
        //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
        //            PdfWriter writer = PdfWriter.GetInstance(document, file);
        //            // writer.PageEvent = new ITextEvents();
        //            writer.PageEvent = new PDFHeader();
        //            document.Open();

        //            if (Version_flg != 2)
        //            {

        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //            }


        //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //            PdfPTable footrtable = new PdfPTable(2);
        //            float[] footrsBody = { 21, 79 };
        //            footrtable.SetWidths(footrsBody);
        //            footrtable.WidthPercentage = 100;


        //            if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
        //            {
        //                footrtable.AddCell(new PdfPCell(new Phrase("RECEIPT", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //            }
        //            else
        //            {
        //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT RECEIPT", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //            }


        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 3, HorizontalAlignment = Element.ALIGN_LEFT });
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });



        //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });



        //            footrtable.AddCell(new PdfPCell(new Phrase("Receipt # ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });





        //            document.Add(footrtable);


        //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));






        //            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "")
        //            {


        //                if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "3")
        //                {
        //                    PdfPTable foottrtables = new PdfPTable(2);
        //                    float[] footrssBodys = { 30, 70 };
        //                    foottrtables.SetWidths(footrssBodys);
        //                    foottrtables.WidthPercentage = 70;

        //                    foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;

        //                    foottrtables.AddCell(new PdfPCell(new Phrase("Receipt Details", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 2 });



        //                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
        //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "0")
        //                    {


        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
        //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                        }
        //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
        //                        }
        //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
        //                        }
        //                        if (dt.Rows[0]["RCPT_CHEQUE_NO"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Book Number", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_CHEQUE_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                        }


        //                    }
        //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "1")
        //                    {



        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });

        //                        if (dt.Rows[0]["RCPT_DD_NO"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_DD_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });



        //                        }


        //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });


        //                        }
        //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
        //                        {

        //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });


        //                        }

        //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });



        //                        }

        //                    }
        //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "2")
        //                    {

        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });


        //                        if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Transfer Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });


        //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "0")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });


        //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "1")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });

        //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "2")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });

        //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "3")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });



        //                        }



        //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
        //                        }
        //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
        //                        {

        //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
        //                        }

        //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
        //                        {

        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });

        //                        }

        //                    }

        //                    //foottrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                    //foottrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //                    document.Add(foottrtables);


        //                }
        //            }



        //            if (dtSales.Rows.Count > 0)
        //            {
        //                string AccGrp = "";

        //                if (dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
        //                    AccGrp = dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
        //                else if (dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
        //                    AccGrp = dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();


        //                if (AccGrp != "")
        //                {

        //                    PdfPTable footrtables = new PdfPTable(2);
        //                    float[] footrsBodys = { 21, 79 };
        //                    footrtables.SetWidths(footrsBodys);
        //                    footrtables.WidthPercentage = 100;

        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });







        //                    if (AccGrp == "13")
        //                    {
        //                        footrtables.AddCell(new PdfPCell(new Phrase("A/c BOOK ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });




        //                    }
        //                    else
        //                    {

        //                        footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //                    }

        //                    footrtables.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 2 });


        //                    document.Add(footrtables);

        //                }



        //            }




        //            if (dtProduct.Rows.Count > 0)
        //            {


        //                clsBusinessLayer ObjBusiness = new clsBusinessLayer();

        //                if (dtProduct.Rows.Count == 1)
        //                {
        //                    PdfPTable footrtables = new PdfPTable(5);
        //                    float[] footrsBodys = { 19, 27, 5, 15, 30 };
        //                    footrtables.SetWidths(footrsBodys);
        //                    footrtables.WidthPercentage = 100;
        //                    decimal TOTAL = 0;
        //                    TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
        //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, Colspan = 5 });


        //                    footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
        //                    footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });

        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });

        //                    decimal decAmnt = 0;
        //                    if (dtProduct.Rows[0]["RECPT_LD_AMT"].ToString() != "")
        //                    {
        //                        decAmnt = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
        //                    }
        //                    string valuestringAmnt = String.Format(format, decAmnt);


        //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
        //                    footrtables.AddCell(new PdfPCell(new Phrase(valuestringAmnt + "  " + crncyAbrvt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });

        //                    //  footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) {  Border = 0 ,HorizontalAlignment = Element.ALIGN_LEFT, Padding =8, Colspan = 3 });


        //                    //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT,  BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthTop = 0 });
        //                    //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT,  BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                    //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT,  BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                    //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT,  BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                    //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT,  BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });




        //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                    footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });



        //                    document.Add(footrtables);


        //                    //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    if (invoiceDtl.Rows.Count > 0)
        //                    {
        //                        var FontGrey = new BaseColor(134, 152, 160);
        //                        var FontBordrGrey = new BaseColor(236, 236, 236);
        //                        var FontBordrBlack = new BaseColor(138, 138, 138);
        //                        PdfPTable table2 = new PdfPTable(3);
        //                        float[] tableBody2 = { 40, 30, 30 };
        //                        table2.SetWidths(tableBody2);
        //                        table2.WidthPercentage = 100;
        //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, Colspan = 3 });

        //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                        table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });



        //                        for (int RowCount = 0; RowCount < invoiceDtl.Rows.Count; RowCount++)
        //                        {

        //                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

        //                            decimal decAmnt1 = 0;
        //                            if (invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString() != "")
        //                            {
        //                                decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString());
        //                            }
        //                            string valuestringAmnt1 = String.Format(format, decAmnt1);

        //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });


        //                        }
        //                        document.Add(table2);

        //                    }





        //                }
        //                else
        //                {

        //                    //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    var FontGrey = new BaseColor(134, 152, 160);
        //                    var FontBordrGrey = new BaseColor(236, 236, 236);
        //                    var FontBordrBlack = new BaseColor(138, 138, 138);
        //                    PdfPTable table2 = new PdfPTable(3);
        //                    float[] tableBody2 = { 40, 30, 30 };
        //                    table2.SetWidths(tableBody2);
        //                    table2.WidthPercentage = 100;
        //                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                    decimal TOTAL = 0;
        //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
        //                    {
        //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                        if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
        //                        {
        //                            TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
        //                        }
        //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["RCPT_LD_REMARKS"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

        //                        decimal decAmnt1 = 0;
        //                        if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
        //                        {
        //                            decAmnt1 = Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
        //                        }
        //                        string valuestringAmnt1 = String.Format(format, decAmnt1);
        //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

        //                    }


        //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
        //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });


        //                    string valuestringAmnt11 = String.Format(format, TOTAL);

        //                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt11, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });


        //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });

        //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
        //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

        //                    document.Add(table2);

        //                }

        //            }



        //            if (Version_flg == 2)
        //            {
        //                //PdfPTable footrtables = new PdfPTable(2);
        //                //float[] footrsBodys = { 10, 90 };
        //                //footrtables.SetWidths(footrsBodys);
        //                //footrtables.WidthPercentage = 100;

        //                //footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                //footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //                //footrtables.AddCell(new PdfPCell(new Phrase("Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RECPT_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                //footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                //footrtables.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


        //                //document.Add(footrtables);








        //                if (dt.Rows[0]["RECPT_DSCRPTN"].ToString().Trim() != "")
        //                {

        //                    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
        //                    document.Add(new Paragraph(new Chunk(dt.Rows[0]["RECPT_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
        //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                }
        //            }
        //            float pos1 = writer.GetVerticalPosition(false);


        //            PdfPTable table3 = new PdfPTable(3);
        //            float[] tableBody3 = { 33, 33, 33 };
        //            table3.SetWidths(tableBody3);
        //            table3.WidthPercentage = 100;
        //            table3.TotalWidth = 600F;

        //            var FontColourPrprd = new BaseColor(33, 150, 243);
        //            var FontColourChkd = new BaseColor(76, 175, 80);
        //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
        //            if (dt.Rows[0]["INSERT_USR"].ToString() != "")
        //            {
        //                PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
        //            }

        //            // PreparedBy = dt.Rows[0]["USR_NAME"].ToString();
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
        //            {

        //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            }
        //            else
        //            {
        //                table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            }
        //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //            //  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //            if (Version_flg == 2)
        //            {
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });



        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
        //            }
        //            // table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
        //            if (pos1 > 140)
        //            {
        //                table3.WriteSelectedRows(0, -1, 0, 160, writer.DirectContent);
        //            }
        //            else
        //            {
        //                document.NewPage();
        //                table3.WriteSelectedRows(0, -1, 0, 160, writer.DirectContent);
        //            }






        //            document.Close();
        //        }


        //        strRet = strImagePath + strImageName;
        //    }
        //    catch (Exception)
        //    {
        //        document.Close();
        //    }

        //    return strRet;


        //}

        public string PdfPrintVersion2(string strrId, DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Receipt_Account ObjEntitySales, string PreparedBy, string CheckedBy, string crncyAbrvt, string crncyId, int Version_flg, DataTable dtSales, DataTable invoiceDtl)
        {

            int precision = 0;
            if (dt.Rows[0]["DCML_CNT"].ToString() != "")
            {
                precision = Convert.ToInt32(dt.Rows[0]["DCML_CNT"].ToString());
            }
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, 0);

            globfalg = Version_flg;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntitySales.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
            }
            if (ObjEntitySales.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
            }
            if (crncyId != "")
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_PRINT);
            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "Receipt_Invoice" + strrId + "_" + strNextNumber + ".pdf";

            Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
            if (Version_flg == 2)
            {
                document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
            }
            globhead = Convert.ToInt32(dt.Rows[0]["RECPT_CNFRM_STS"].ToString());
            string strRet = "";
            try
            {

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    if (Version_flg == 2)
                    {
                        writer.PageEvent = new PDFHeader();
                        document.Open();
                    }
                    else
                    {
                        document.Open();
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                    }

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 21, 79 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;
                    footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Receipt # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    document.Add(footrtable);

                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "")
                    {
                        if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "3")
                        {
                            PdfPTable foottrtables = new PdfPTable(2);
                            float[] footrssBodys = { 30, 70 };
                            foottrtables.SetWidths(footrssBodys);
                            foottrtables.WidthPercentage = 70;
                            foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;

                            foottrtables.AddCell(new PdfPCell(new Phrase("Receipt Details", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2 });
                            foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "0")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                                if (dt.Rows[0]["RCPT_CHEQUE_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_CHEQUE_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                }
                            }
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "1")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["RCPT_DD_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_DD_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }

                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                }
                            }
                            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "2")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Transfer Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "0")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "1")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "2")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                    if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "3")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                                if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                                if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }

                                if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                }

                            }
                            document.Add(foottrtables);
                            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        }
                    }
                    if (dtSales.Rows.Count > 0)
                    {
                        string AccGrp = "";
                        if (dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
                            AccGrp = dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
                        else if (dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
                            AccGrp = dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
                        if (AccGrp != "")
                        {
                            PdfPTable footrtables = new PdfPTable(2);
                            float[] footrsBodys = { 21, 79 };
                            footrtables.SetWidths(footrsBodys);
                            footrtables.WidthPercentage = 100;

                            footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            if (AccGrp == "13")
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("A/c BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            else
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            }
                            footrtables.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 2 });
                            document.Add(footrtables);
                        }
                    }
                    if (dtProduct.Rows.Count > 0)
                    {
                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                        if (dtProduct.Rows.Count == 1)//single ledger
                        {
                            PdfPTable footrtables = new PdfPTable(5);
                            float[] footrsBodys = { 19, 27, 5, 15, 30 };
                            footrtables.SetWidths(footrsBodys);
                            footrtables.WidthPercentage = 100;

                            decimal TOTAL = 0;
                            TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
                            string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                            footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 5 });
                            footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            decimal decAmnt = 0;
                            if (dtProduct.Rows[0]["RECPT_LD_AMT"].ToString() != "")
                            {
                                decAmnt = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
                            }
                            string valuestringAmnt = String.Format(format, decAmnt);
                            footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase(valuestringAmnt + "  " + crncyAbrvt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                            document.Add(footrtables);

                            int flag = 0;

                            if (invoiceDtl.Rows.Count > 0)
                            {
                                var FontGrey = new BaseColor(134, 152, 160);
                                var FontBordrGrey = new BaseColor(236, 236, 236);
                                var FontBordrBlack = new BaseColor(138, 138, 138);

                                PdfPTable table2 = new PdfPTable(3);
                                float[] tableBody2 = { 40, 30, 30 };
                                table2.SetWidths(tableBody2);
                                table2.WidthPercentage = 100;

                                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                                table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
                                table2.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                                table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                                table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                                for (int RowCount = 0; RowCount < invoiceDtl.Rows.Count; RowCount++)
                                {
                                    if (invoiceDtl.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
                                    {
                                        if (invoiceDtl.Rows[RowCount]["SALES_REF"].ToString() != "")
                                        {
                                            if (invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString() != "")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString());
                                                string valuestringAmnt1 = String.Format(format, decAmnt1);
                                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                            if (invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString() != "")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString());
                                                string valuestringAmnt1 = String.Format(format, decAmnt1);
                                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                        }
                                        else if (invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
                                        {
                                            table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString());
                                            string valuestringAmnt1 = String.Format(format, decAmnt1);
                                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                        }
                                        flag++;
                                    }
                                }
                                if (flag > 0)
                                {
                                    document.Add(table2);
                                }
                            }
                        }
                        else //multiple ledgers
                        {
                            var FontGrey = new BaseColor(134, 152, 160);
                            var FontBordrGrey = new BaseColor(236, 236, 236);
                            var FontBordrBlack = new BaseColor(138, 138, 138);
                            var FontGreySmall = new BaseColor(236, 236, 236);

                            PdfPTable table2 = new PdfPTable(7);
                            float[] tableBody2 = { 5, 15, 12, 5, 28, 15, 20 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 4 });
                            table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 2 });
                            table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            
                            string strAmountComma = "";
                            string strAmountCommaTotal = "";
                            decimal TOTAL = 0;
                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
                                {
                                    TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
                                }
                                decimal decAmnt1 = 0;
                                if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
                                {
                                    decAmnt1 = Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
                                }
                                string valuestringAmnt1 = String.Format(format, decAmnt1);

                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["RCPT_LD_REMARKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                
                                clsBusinessLayer_Receipt_Account objBussinessPayment = new clsBusinessLayer_Receipt_Account();
                                ObjEntitySales.Status = 3;
                                ObjEntitySales.LedgerId = Convert.ToInt32(dtProduct.Rows[intRowBodyCount]["RECPT_LD_ID"].ToString());
                                invoiceDtl = objBussinessPayment.ReadReceptCostcntrDetailsById(ObjEntitySales);

                                if (invoiceDtl.Rows.Count > 0)
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = invoiceDtl.Rows.Count + 1 });
                                    table2.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
                                    table2.AddCell(new PdfPCell(new Phrase("INV.AMT(" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = invoiceDtl.Rows.Count + 1 });
                                    for (int RowCount = 0; RowCount < invoiceDtl.Rows.Count; RowCount++)
                                    {
                                        if (invoiceDtl.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
                                        {
                                            if (invoiceDtl.Rows[RowCount]["SALES_REF"].ToString() != "")
                                            {
                                                if (invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString() != "")
                                                {
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString(), objEntityCommon);
                                                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                }
                                                if (invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString() != "")
                                                {
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString(), objEntityCommon);
                                                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                }
                                            }
                                            else if (invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
                                                table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                        }
                                    }
                                }
                            }
                            string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                            table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
                            string valuestringAmnt11 = String.Format(format, TOTAL);
                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt11, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 7 });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            document.Add(table2);
                        }

                    }
                    if (Version_flg == 2)
                    {
                        if (dt.Rows[0]["RECPT_DSCRPTN"].ToString().Trim() != "")
                        {
                            document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                            document.Add(new Paragraph(new Chunk(dt.Rows[0]["RECPT_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        }
                    }

                    float pos1 = writer.GetVerticalPosition(false);

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    }
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
                    {

                        table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    else
                    {
                        table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    }
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    
                    if (pos1 > 90)
                    {
                        table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
                    }
                    document.Close();
                }
                strRet = strImagePath + strImageName;
            }
            catch (Exception)
            {
                document.Close();
                strRet = "false";
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
                //if (globfalg == 2)
                //{
                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                objEntityLayerStock.Corp_Id = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
                objEntityLayerStock.Org_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
                DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);
                clsCommonLibrary objCommon = new clsCommonLibrary();
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
                //int globhead = 1;
                PdfPTable headtable = new PdfPTable(2);
                if (globhead == 1)
                {
                    headtable.AddCell(new PdfPCell(new Phrase("RECEIPT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DRAFT RECEIPT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
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
                headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
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
                headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(45), writer.DirectContent);

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

    }
}
