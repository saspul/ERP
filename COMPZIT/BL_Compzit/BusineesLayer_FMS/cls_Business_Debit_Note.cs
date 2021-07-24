﻿using System;
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
    public class cls_Business_Debit_Note
    {
        //0039
        static int globhead = 0;
        //end
        clsDataLayer_Debit_Note objDataCredit = new clsDataLayer_Debit_Note();
        public DataTable ReadLeadger(clsEntity_Debit_Note objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadLeadger(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenter(clsEntity_Debit_Note objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadCostCenter(objEntity);
            return dtRcpt;
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCredit.readRefFormate(ObjEntitySales);
            return dtDivision;
        }
        public void AddCreditNote(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntitylLedgrList, List<clsEntity_Debit_Note> objEntityCostcentrList, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            objDataCredit.AddCreditNote(ObjEntityCredit, objEntitylLedgrList, objEntityCostcentrList, objEntitySaleList);
        }
        public DataTable ReadCreditNoteList(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNoteList(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_By_ID(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_By_ID(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Ledger_By_ID(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
            return dtDiv;
        }
        //public DataTable ReadCreditNote_Ledger_Cost_By_ID(clsEntity_Debit_Note ObjEntityCredit)
        //{
        //    DataTable dtDiv = objDataCredit.ReadCreditNote_Ledger_Cost_By_ID(ObjEntityCredit);
        //    return dtDiv;
        //}
        public DataTable ReadLedgrBalance(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadLedgrBalance(ObjEntityCredit);
            return dtDiv;
        }

        public void UpdateCredit_Note(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedgerIns, List<clsEntity_Debit_Note> objEntityLedgerDel, List<clsEntity_Debit_Note> objEntityCostCenterIns, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            objDataCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
        }
        public void ConfirmCredit_Note(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedgerIns, List<clsEntity_Debit_Note> objEntityLedgerDel, List<clsEntity_Debit_Note> objEntityCostCenterIns, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            objDataCredit.ConfirmCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
        }
        public DataTable CheckCreditNoteCnclSts(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.CheckCreditNoteCnclSts(ObjEntityCredit);
            return dtDiv;
        }
        public void CancelCreditNote(clsEntity_Debit_Note ObjEntityCredit)
        {
            objDataCredit.CancelCreditNote(ObjEntityCredit);
        }
        public void CreditNoteReOpenById(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedger, List<clsEntity_Debit_Note> objEntityLedgerCostCenter)
        {
            objDataCredit.CreditNoteReOpenById(ObjEntityCredit, objEntityLedger, objEntityLedgerCostCenter);
        }
        public DataTable ReadRefNumberByDate(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadRefNumberByDate(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadRefNumberByDateLast(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCorpDtls(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCorpDtls(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Credit(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Credit(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Debit(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Debit(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadInvoiceDtls(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadInvoiceDtls(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadPurchaseBalance(clsEntity_Debit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadPurchaseBalance(ObjEntityCredit);
            return dtDiv;
        }

        public DataTable ReadSalesbyId(clsEntity_Debit_Note ObjEntityDebit)
        {
            DataTable dtDiv = objDataCredit.ReadSalesbyId(ObjEntityDebit);
            return dtDiv;
        }

        public void DeletePurchaseLedgers(List<clsEntity_Debit_Note> ObjEntityDbtNoteCstCntrDEL)
        {
            objDataCredit.DeletePurchaseLedgers(ObjEntityDbtNoteCstCntrDEL);
        }

        public DataTable ReadSalesReturnBalance(clsEntity_Debit_Note objEntity)
        {
            DataTable dtDiv = objDataCredit.ReadSalesReturnBalance(objEntity);
            return dtDiv;
        }






        public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDebit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Debit_Note ObjEntityCredit)
        {
            string strRet = "";

            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntityCredit.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
            }
            if (ObjEntityCredit.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
            }
            if (crncyId != "")
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
            }
            clsBusinessLayer ObjBusiness = new clsBusinessLayer();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBITNOTE_PRINT);
            string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "DebitNote" + Id + "_" + strNextNumber + ".pdf";

            Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            try
            {
                int precision = Convert.ToInt32(DecCnt);
                string format = String.Format("{{0:N{0}}}", precision);

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    document.Open();
                    PdfPTable headImg = new PdfPTable(2);

                    string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
                    if (dtCorp.Rows.Count > 0)
                    {
                        if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                            strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

                    }

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

                    var FontBlue = new BaseColor(0, 174, 239);
                    var FontBlueGrey = new BaseColor(79, 167, 206);
                    if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() != "1")
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT DEBIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                    else
                        headImg.AddCell(new PdfPCell(new Phrase("DEBIT NOTE", FontFactory.GetFont("Arial", 18, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

                    float[] headersHeading = { 60, 40 };
                    headImg.SetWidths(headersHeading);
                    headImg.WidthPercentage = 100;

                    document.Add(headImg);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 50, 50 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 12, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                    if (dtCorp.Rows.Count > 0)
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    }
                    document.Add(footrtable);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtables = new PdfPTable(2);
                    float[] footrsBodys = { 15, 85 };
                    footrtables.SetWidths(footrsBodys);
                    footrtables.WidthPercentage = 100;

                    footrtables.AddCell(new PdfPCell(new Phrase("Debit Note Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["DR_NOTE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["DR_NOTE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    if (dtLedgrdDebDtl.Rows.Count > 0)
                    {
                        footrtables.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
                            footrtables.AddCell(new PdfPCell(new Phrase(": " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    }
                    else
                        footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                    document.Add(footrtables);
                    var FontGrey = new BaseColor(134, 152, 160);
                    var FontBordrGrey = new BaseColor(236, 236, 236);
                    if (dtDebit.Rows.Count > 0)
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        PdfPTable table2 = new PdfPTable(2);
                        float[] tableBody2 = { 75, 25 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                        for (int intRowBodyCount = 0; intRowBodyCount < dtDebit.Rows.Count; intRowBodyCount++)
                        {
                            decimal decAmnt = 0;

                            if (dtLedgrdDebDtl.Rows.Count > 0)
                            {
                                if (dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString() != "")
                                {
                                    decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString());
                                }
                            }
                            string valuestringAmnt = String.Format(format, decAmnt);

                            if (dt.Rows[0]["DR_NOTE_NARRATION"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                            else
                                table2.AddCell(new PdfPCell(new Phrase(dtDebit.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

                        }
                        var FontRed = new BaseColor(202, 3, 20);

                        decimal decTotal = 0;
                        if (dtLedgrdDebDtl.Rows.Count > 0)
                        {
                            if (dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString() != "")
                            {
                                decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString());
                            }
                        }
                        string valuestringTot = String.Format(format, decTotal);

                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));

                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontBlue, Colspan = 2, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });

                        document.Add(table2);
                    }



                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    float pos1 = writer.GetVerticalPosition(false);
                    string CheckedBy = "";
                    if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }
                    //EVM-0027 AUG 27
                    //if (dt.Rows[0]["UPD_USR_NAME"].ToString() != "")
                    //{
                    //    PreparedBy = dt.Rows[0]["UPD_USR_NAME"].ToString();
                    //}
                    //else
                    //{
                    //    PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
                    //}

                    if (dt.Rows[0]["INS_USR_NAME"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
                    }
                    //END
                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;
                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);
                    //table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    //table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    //table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });


                    if (pos1 > 121)
                    {
                        table3.WriteSelectedRows(0, -1, 0, 120, writer.DirectContent);
                        //  table3.WriteSelectedRows(0, -1, 65, 120, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 0, 120, writer.DirectContent);

                        // table3.WriteSelectedRows(0, -1, 65, 120, writer.DirectContent);
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

        //public string PdfPrintVersion2(DataTable dtLDGRdTLSdbcr, string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDebit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Debit_Note ObjEntityCredit, int Version_flg, DataTable dtinvoiceDtls)
        //{
        //    string strRet = "";

        //    clsCommonLibrary objCommon = new clsCommonLibrary();
        //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
        //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
        //    clsEntityCommon objEntityCommon = new clsEntityCommon();
        //    if (ObjEntityCredit.Corporate_id != 0)
        //    {
        //        objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
        //    }
        //    if (ObjEntityCredit.Organisation_id != 0)
        //    {
        //        objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
        //    }
        //    if (crncyId != "")
        //    {
        //        objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
        //            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
        //    }
        //    string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";

        //    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
        //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBITNOTE_PRINT);
        //    string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        //    string strImageName = "DebitNote" + Id + "_" + strNextNumber + ".pdf";

        //    // Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

        //    Document document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
        //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        //    try
        //    {
        //        int precision = Convert.ToInt32(DecCnt);
        //        string format = String.Format("{{0:N{0}}}", precision);
        //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        //        {
        //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
        //            PdfWriter writer = PdfWriter.GetInstance(document, file);
        //            if (Version_flg == 2)
        //            {
        //                writer.PageEvent = new PDFHeader();
        //            }
        //            document.Open();
        //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
        //            if (dtCorp.Rows.Count > 0)
        //            {
        //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
        //                {
        //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
        //                    strImageLogo = imaeposition + icon;
        //                }
        //                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
        //                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
        //                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
        //                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
        //            }
        //            string strAddress = "";
        //            strAddress = strCompanyAddr1;
        //            if (strCompanyAddr2 != "")
        //            {
        //                strAddress += ", " + strCompanyAddr2;
        //            }
        //            if (strCompanyAddr3 != "")
        //            {
        //                strAddress += ", " + strCompanyAddr3;
        //            }
        //            string strdraft = "";
        //            if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            {
        //                strdraft = "DEBIT NOTE";
        //            }
        //            else
        //            {
        //                strdraft = "DEBIT NOTE ( DRAFT )";
        //            }
        //            if (Version_flg == 2)
        //            {
        //                PdfPTable headtable = new PdfPTable(2);
        //                headtable.AddCell(new PdfPCell(new Phrase(strdraft, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
        //                if (strImageLogo != "")
        //                {
        //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
        //                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
        //                    image.ScaleToFit(60f, 40f);
        //                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
        //                }
        //                else
        //                {
        //                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
        //                }
        //                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
        //                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
        //                float[] headersHeading = { 80, 20 };
        //                headtable.SetWidths(headersHeading);
        //                headtable.WidthPercentage = 100;
        //                document.Add(headtable);

        //                PdfPTable tableLine = new PdfPTable(1);
        //                float[] tableLineBody = { 100 };
        //                tableLine.SetWidths(tableLineBody);
        //                tableLine.WidthPercentage = 100;
        //                tableLine.TotalWidth = 650F;
        //                tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(60), writer.DirectContent);
        //                float pos9 = writer.GetVerticalPosition(false);

        //            }

        //            else
        //            {
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
        //            }



        //            PdfPTable footrtable = new PdfPTable(2);
        //            float[] footrsBody = { 21, 79 };
        //            footrtable.SetWidths(footrsBody);
        //            footrtable.WidthPercentage = 100;
        //            //if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            //{
        //            //    footrtable.AddCell(new PdfPCell(new Phrase("DEBIT NOTE", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
        //            //}
        //            //else
        //            //{
        //            //    footrtable.AddCell(new PdfPCell(new Phrase("DRAFT DEBIT NOTE", FontFactory.GetFont("Tahoma,Arial",9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
        //            //}
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["DR_NOTE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase("Debit note Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["DR_NOTE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });


        //            if (dtLedgrdDebDtl.Rows.Count > 0)
        //            {
        //                footrtable.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //                if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
        //                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            }
        //            else
        //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });



        //            document.Add(footrtable);
        //            var FontBordrBlack = new BaseColor(138, 138, 138);
        //            var FontGrey = new BaseColor(134, 152, 160);
        //            var FontBordrGrey = new BaseColor(236, 236, 236);
        //            if (dtDebit.Rows.Count > 0)
        //            {
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

        //                PdfPTable table2 = new PdfPTable(2);
        //                float[] tableBody2 = { 75, 25 };
        //                table2.SetWidths(tableBody2);
        //                table2.WidthPercentage = 100;
        //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                for (int intRowBodyCount = 0; intRowBodyCount < dtDebit.Rows.Count; intRowBodyCount++)
        //                {
        //                    decimal decAmnt = 0;

        //                    if (dtLedgrdDebDtl.Rows.Count > 0)
        //                    {
        //                        if (dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString() != "")
        //                        {
        //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString());
        //                        }
        //                    }
        //                    string valuestringAmnt = String.Format(format, decAmnt);

        //                    string NARRATION = "";

        //                    if (dtDebit.Rows[0]["LDGR_DR_REMARKS"].ToString() != "")
        //                    {
        //                        NARRATION = dtDebit.Rows[0]["LDGR_DR_REMARKS"].ToString();
        //                    }
        //                    else if (dt.Rows[0]["DR_NOTE_NARRATION"].ToString() != "")
        //                    {
        //                        NARRATION = dt.Rows[0]["DR_NOTE_NARRATION"].ToString();
        //                        // table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
        //                    }

        //                    Font myNormalFont = FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK);

        //                    string line1 = dtDebit.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "";

        //                    string line2 = "\n" + NARRATION;

        //                    Paragraph p1 = new Paragraph();
        //                    Phrase ph1 = new Phrase(line1, myNormalFont);
        //                    Phrase ph2 = new Phrase(line2, myNormalFont);
        //                    p1.Add(ph1);
        //                    p1.Add(ph2);
        //                    PdfPCell mycell = new PdfPCell(p1);

        //                    table2.AddCell(new PdfPCell(mycell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

        //                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                }




        //                var FontRed = new BaseColor(202, 3, 20);

        //                decimal decTotal = 0;
        //                if (dtLedgrdDebDtl.Rows.Count > 0)
        //                {
        //                    if (dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString() != "")
        //                    {
        //                        decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_DR_AMT"].ToString());
        //                    }
        //                }
        //                string valuestringTot = String.Format(format, decTotal);

        //                string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));

        //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrBlack });

        //                document.Add(table2);
        //            }



        //            if (dtinvoiceDtls.Rows.Count > 0)
        //            {


        //                PdfPTable table2 = new PdfPTable(3);
        //                float[] tableBody2 = { 40, 30, 30 };
        //                table2.SetWidths(tableBody2);
        //                table2.WidthPercentage = 100;
        //                table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });

        //                table2.AddCell(new PdfPCell(new Phrase("INVOICE NO.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                table2.AddCell(new PdfPCell(new Phrase("AMOUNT(" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });



        //                for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
        //                {

        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_DR_AMOUNT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });


        //                }
        //                document.Add(table2);

        //            }
        //            float pos1 = writer.GetVerticalPosition(false);

        //            string CheckedBy = "";
        //            if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            {
        //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
        //            }

        //            if (dt.Rows[0]["INS_USR_NAME"].ToString() != "")
        //            {
        //                PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
        //            }
        //            PdfPTable table3 = new PdfPTable(3);
        //            float[] tableBody3 = { 33, 33, 33 };
        //            table3.SetWidths(tableBody3);
        //            table3.WidthPercentage = 100;
        //            table3.TotalWidth = 600F;
        //            var FontColourPrprd = new BaseColor(33, 150, 243);
        //            var FontColourChkd = new BaseColor(76, 175, 80);
        //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
        //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            if (Version_flg == 2)
        //            {
        //                if (pos1 > 121)
        //                {
        //                    table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
        //                }
        //                else
        //                {
        //                    document.NewPage();
        //                    table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
        //                }
        //            }
        //            else
        //            {
        //                if (pos1 > 76)
        //                {
        //                    table3.WriteSelectedRows(0, -1, 0, 75, writer.DirectContent);
        //                }
        //                else
        //                {
        //                    document.NewPage();
        //                    table3.WriteSelectedRows(0, -1, 0, 75, writer.DirectContent);
        //                }
        //            }


        //            document.Close();
        //        }
        //        strRet = strImagePath + strImageName;
        //    }
        //    catch (Exception)
        //    {
        //        document.Close();
        //        strRet = "false";
        //    }

        //    return strRet;
        //}
        //0039

        //0039
        public string PdfPrintVersion2(DataTable dtLDGRdTLSdbcr, string Id, DataTable dt, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Debit_Note ObjEntityCredit, int Version_flg, DataTable dtinvoiceDtls)
        {
            string strRet = "";
            //0039
            int globhead = 0;
            //end
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.DEBIT_NOTE);
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntityCredit.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
            }
            if (ObjEntityCredit.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
            }
            if (crncyId != "")
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
            }
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";

            //0039
            globhead = Convert.ToInt32(dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString());
            //end
            clsBusinessLayer ObjBusiness = new clsBusinessLayer();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBITNOTE_PRINT);
            string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "DebitNote" + Id + "_" + strNextNumber + ".pdf";

            // Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

            Document document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            try
            {
                int precision = Convert.ToInt32(DecCnt);
                string format = String.Format("{{0:N{0}}}", precision);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    if (Version_flg == 2)
                    {
                        writer.PageEvent = new PDFHeader();
                    }
                    document.Open();

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 21, 79 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));

                    //footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT });
                    //footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["DR_NOTE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Debit note Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["DR_NOTE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });


                    //if (dtLedgrdDebDtl.Rows.Count > 0)
                    //{
                    //    footrtable.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    //    if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
                    //        footrtable.AddCell(new PdfPCell(new Phrase(":       " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    //}
                    //else
                    //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


                    document.Add(footrtable);
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));


                    var FontBordrBlack = new BaseColor(138, 138, 138);
                    var FontGrey = new BaseColor(134, 152, 160);
                    var FontBordrGrey = new BaseColor(236, 236, 236);

                    if (dtLDGRdTLSdbcr.Rows.Count > 2)//multiple ledger 
                    {

                        var FontGreySmall = new BaseColor(236, 236, 236);

                        PdfPTable tablef1 = new PdfPTable(8);
                        float[] tablef1Body2 = { 5, 15, 12, 5, 28, 15, 10, 10 };
                        tablef1.SetWidths(tablef1Body2);
                        tablef1.WidthPercentage = 100;
                        tablef1.HeaderRows = 1;

                        //tablef1.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack,, Colspan = 4  });
                        ////0039
                        //tablef1.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        //tablef1.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        ////end                                      
                        //tablef1.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        ////0039
                        tablef1.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 3 });
                        tablef1.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 3 });
                        tablef1.AddCell(new PdfPCell(new Phrase("DEBIT " + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        tablef1.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        ////end  

                        string strAmountComma = "";
                        string strAmountCommaTotal = "";
                        decimal decDbAmnt = 0;
                        decimal decCrAmnt = 0;
                        int previd = 0;
                        for (int intRowBodyCount1 = 0; intRowBodyCount1 < dtLDGRdTLSdbcr.Rows.Count; intRowBodyCount1++)
                        {
                            if (intRowBodyCount1 == 0)
                            {
                                previd = 0;
                            }
                            else
                            {
                                previd = Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1 - 1]["LDGR_DR_ID"].ToString());
                            }
                            if (Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_ID"].ToString()) != previd)
                            {
                                cls_Business_Debit_Note objBussinessDebit = new cls_Business_Debit_Note();

                                ObjEntityCredit.Ledger_Debit_Id = Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_ID"].ToString());
                                dtinvoiceDtls = objBussinessDebit.ReadInvoiceDtls(ObjEntityCredit);

                                if (dtLDGRdTLSdbcr.Rows.Count > 0)
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_CR_STATUS"].ToString() == "0")
                                    {
                                        if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString() != "")
                                        {
                                            decDbAmnt = decDbAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString());
                                        }
                                    }
                                    else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_CR_STATUS"].ToString() == "1")
                                    {
                                        if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString() != "")
                                        {
                                            decCrAmnt = decCrAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString());
                                        }
                                    }
                                }

                                string valuestringDbAmnt = String.Format(format, decDbAmnt);
                                string valuestringCrAmnt = String.Format(format, decCrAmnt);

                                tablef1.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });
                                tablef1.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_REMARKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_CR_STATUS"].ToString() == "0")
                                {

                                    tablef1.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    tablef1.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                                else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_CR_STATUS"].ToString() == "1")
                                {
                                    tablef1.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    tablef1.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_DR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }

                                if (dtinvoiceDtls.Rows.Count > 0)
                                {
                                    tablef1.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtinvoiceDtls.Rows.Count + 1 });
                                    tablef1.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    tablef1.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
                                    tablef1.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    tablef1.AddCell(new PdfPCell(new Phrase("INV.AMT " + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    tablef1.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2, Rowspan = dtinvoiceDtls.Rows.Count + 1 });

                                    for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
                                    {
                                        if (dtinvoiceDtls.Rows[RowCount]["PURCHS_REF"].ToString() != "")
                                        {
                                            if (dtinvoiceDtls.Rows[RowCount]["CST_CNTR_DR_AMOUNT"].ToString() != "")
                                            {
                                                tablef1.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                tablef1.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                tablef1.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = ObjBusiness.AddCommasForNumberSeperation(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_DR_AMOUNT"].ToString(), objEntityCommon);
                                                tablef1.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                        }
                                    }
                                }

                            }
                        }

                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        string strDbcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        string strCrcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decCrAmnt));
                        tablef1.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
                        string DbvaluestringAmnt = String.Format(format, decDbAmnt);
                        string CrvaluestringAmnt = String.Format(format, decCrAmnt);

                        //0039
                        tablef1.AddCell(new PdfPCell(new Phrase(DbvaluestringAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        tablef1.AddCell(new PdfPCell(new Phrase(DbvaluestringAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        //end
                        tablef1.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 8 });
                        tablef1.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8 });
                        tablef1.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                        document.Add(tablef1);
                    }
                    else //2 ledgers
                    {

                        PdfPTable tablef2 = new PdfPTable(4);
                        float[] tablef2Body2 = { 35, 35, 15, 15 };
                        tablef2.SetWidths(tablef2Body2);
                        tablef2.WidthPercentage = 100;
                        tablef2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        //0039
                        tablef2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        tablef2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        tablef2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        //end
                        //table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        decimal decDbAmnt = 0;
                        decimal decCrAmnt = 0;

                        for (int intRowBodyCount = 0; intRowBodyCount < dtLDGRdTLSdbcr.Rows.Count; intRowBodyCount++)
                        {
                            if (dtLDGRdTLSdbcr.Rows.Count > 0)
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "0")
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString() != "")
                                    {
                                        decDbAmnt = decDbAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString());
                                    }
                                }
                                else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "1")
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString() != "")
                                    {
                                        decCrAmnt = decCrAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString());
                                    }
                                }
                            }
                            string valuestringDbAmnt = String.Format(format, decDbAmnt);
                            string valuestringCrAmnt = String.Format(format, decCrAmnt);

                            string NARRATION = "";

                            if (dtLDGRdTLSdbcr.Rows.Count > 0)
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_REMARKS"].ToString() != "")
                                {
                                    NARRATION = dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_REMARKS"].ToString();
                                }
                            }

                            Font myNormalFont = FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK);

                            string line1 = dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "";
                            string line2 = "\n" + NARRATION;
                            Paragraph p1 = new Paragraph();
                            Phrase ph1 = new Phrase(line1, myNormalFont);
                            Phrase ph2 = new Phrase(line2, myNormalFont);
                            p1.Add(ph1);
                            p1.Add(ph2);
                            PdfPCell mycell = new PdfPCell(p1);

                            tablef2.AddCell(new PdfPCell(mycell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                            if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "0")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() != "")
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_REMARKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                                }
                                else
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                            else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "1")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() != "")
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_REMARKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                                else
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }

                            if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "0")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString() != "")
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    tablef2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                            else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_CR_STATUS"].ToString() == "1")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString() != "")
                                {
                                    tablef2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    tablef2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_DR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                        }

                        string valuestringTot = String.Format(format, decDbAmnt);
                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        tablef2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });

                        //table2.AddCell(new PdfPCell(new Phrase(" " + valuestringTot, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                        tablef2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        tablef2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        tablef2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                        document.Add(tablef2);

                        if (dtinvoiceDtls.Rows.Count > 0)
                        {
                            PdfPTable tablef12 = new PdfPTable(3);
                            float[] tablef12Body2 = { 40, 30, 30 };
                            tablef12.SetWidths(tablef12Body2);
                            tablef12.WidthPercentage = 100;
                            tablef12.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
                            tablef12.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            tablef12.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            tablef12.AddCell(new PdfPCell(new Phrase("AMOUNT(" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
                            {
                                tablef12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                tablef12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                tablef12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_DR_AMOUNT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            }
                            document.Add(tablef12);
                        }
                    }


                    float pos1 = writer.GetVerticalPosition(false);

                    string CheckedBy = "";
                    if (dt.Rows[0]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }

                    if (dt.Rows[0]["INS_USR_NAME"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
                    }
                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;
                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);
                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (Version_flg == 2)
                    {
                        if (pos1 > 121)
                        {
                            table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
                        }
                        else
                        {
                            document.NewPage();
                            table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
                        }
                    }
                    else
                    {
                        if (pos1 > 76)
                        {
                            table3.WriteSelectedRows(0, -1, 0, 75, writer.DirectContent);
                        }
                        else
                        {
                            document.NewPage();
                            table3.WriteSelectedRows(0, -1, 0, 75, writer.DirectContent);
                        }
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
        //end

        public class PDFHeader : PdfPageEventHelper
        {
            // This is the contentbyte object of the writer
            PdfContentByte cb;

            // we will put the final number of pages in a template
            PdfTemplate footerTemplate;

            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;

            // This keeps track of the creation time
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
            //0039
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
                if (globhead == 1)
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DEBIT NOTE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DRAFT DEBIT NOTE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
            //end
            public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                //base.OnEndPage(writer, document);
                string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
                PdfPTable table3 = new PdfPTable(1);
                float[] tableBody3 = { 100 };
                table3.SetWidths(tableBody3);
                table3.WidthPercentage = 100;
                table3.TotalWidth = 650F;
                table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                //table3.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(50), writer.DirectContent);
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
                headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 20, 60, 20 };
                headImg.SetWidths(headersHeading);
                headImg.WidthPercentage = 100;
                headImg.TotalWidth = document.PageSize.Width - 80f;
                headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(38), writer.DirectContent);

                String text = "Page " + writer.PageNumber + " of ";
                //Add paging to footer
                {
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 8);
                    cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(11));
                    cb.ShowText(text);
                    cb.EndText();
                    float len = bf.GetWidthPoint(text, 8);
                    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(11));
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
