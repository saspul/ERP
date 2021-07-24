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
    public class cls_Business_Credit_Note
    {
        //0039
        static int globhead = 0;
        //end
        clsDataLayer_Credit_Note objDataCredit = new clsDataLayer_Credit_Note();
        public DataTable ReadLeadger(clsEntity_Credit_Note objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadLeadger(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenter(clsEntity_Credit_Note objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadCostCenter(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSalesBalance(clsEntity_Credit_Note objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadSalesBalance(objEntity);
            return dtRcpt;
        }

        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCredit.readRefFormate(ObjEntitySales);
            return dtDivision;
        }
        public void AddCreditNote(clsEntity_Credit_Note ObjEntityCredit, List<clsEntity_Credit_Note> objEntitylLedgrList, List<clsEntity_Credit_Note> objEntityCostcentrList, List<clsEntity_Credit_Note> objEntitySaleList)
        {
            objDataCredit.AddCreditNote(ObjEntityCredit, objEntitylLedgrList, objEntityCostcentrList, objEntitySaleList);
        }
        public DataTable ReadCreditNoteList(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNoteList(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_By_ID(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_By_ID(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Ledger_By_ID(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Ledger_Cost_By_ID(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Ledger_Cost_By_ID(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadLedgrBalance(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadLedgrBalance(ObjEntityCredit);
            return dtDiv;
        }

        public void UpdateCredit_Note(clsEntity_Credit_Note ObjEntityCredit, List<clsEntity_Credit_Note> objEntityLedgerIns, List<clsEntity_Credit_Note> objEntityLedgerUpd, List<clsEntity_Credit_Note> objEntityLedgerDel, List<clsEntity_Credit_Note> objEntityCostCenterIns, List<clsEntity_Credit_Note> objEntitySaleList)
        {
            objDataCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
        }
        public void ConfirmCredit_Note(clsEntity_Credit_Note ObjEntityCredit, List<clsEntity_Credit_Note> objEntityLedgerIns, List<clsEntity_Credit_Note> objEntityLedgerUpd, List<clsEntity_Credit_Note> objEntityLedgerDel, List<clsEntity_Credit_Note> objEntityCostCenterIns, List<clsEntity_Credit_Note> objEntitySaleList)
        {
            objDataCredit.ConfirmCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
        }
        public DataTable CheckCreditNoteCnclSts(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.CheckCreditNoteCnclSts(ObjEntityCredit);
            return dtDiv;
        }
        public void CancelCreditNote(clsEntity_Credit_Note ObjEntityCredit)
        {
            objDataCredit.CancelCreditNote(ObjEntityCredit);
        }
        public void CreditNoteReOpenById(clsEntity_Credit_Note ObjEntityCredit, List<clsEntity_Credit_Note> objEntityLedger, List<clsEntity_Credit_Note> objEntityLedgerCostCenter)
        {
            objDataCredit.CreditNoteReOpenById(ObjEntityCredit, objEntityLedger, objEntityLedgerCostCenter);
        }
        public DataTable ReadRefNumberByDate(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadRefNumberByDate(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadRefNumberByDateLast(ObjEntityCredit);
            return dtDiv;
        }

        public DataTable ReadCorpDtls(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCorpDtls(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Credit(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Credit(ObjEntityCredit);
            return dtDiv;
        }
        public DataTable ReadCreditNote_Debit(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadCreditNote_Debit(ObjEntityCredit);
            return dtDiv;
        }

        public DataTable ReadInvoiceDtls(clsEntity_Credit_Note ObjEntityCredit)
        {
            DataTable dtDiv = objDataCredit.ReadInvoiceDtls(ObjEntityCredit);
            return dtDiv;
        }

        public DataTable ReadSalesbyId(clsEntity_Credit_Note objEntity)
        {
            DataTable dtDiv = objDataCredit.ReadSalesbyId(objEntity);
            return dtDiv;
        }

        public void DeleteSaleLedgers(List<clsEntity_Credit_Note> ObjEntityCrdtNoteCstCntrDEL)
        {
            objDataCredit.DeleteSaleLedgers(ObjEntityCrdtNoteCstCntrDEL);
        }

        public DataTable ReadSalesReturnBalance(clsEntity_Credit_Note objEntity)
        {
            DataTable dtDiv = objDataCredit.ReadSalesReturnBalance(objEntity);
            return dtDiv;
        }









        public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDedit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Credit_Note ObjEntityCredit)
        {
            string strRet = "";

            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
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

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
            string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";


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
                    document.Open(); PdfPTable headImg = new PdfPTable(2);

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
                    if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() != "1")
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                    else
                        headImg.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

                    float[] headersHeading = { 70, 30 };
                    headImg.SetWidths(headersHeading);
                    headImg.WidthPercentage = 100;

                    document.Add(headImg);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 50, 50 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

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
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtables = new PdfPTable(2);
                    float[] footrsBodys = { 20, 80 };
                    footrtables.SetWidths(footrsBodys);
                    footrtables.WidthPercentage = 100;

                    footrtables.AddCell(new PdfPCell(new Phrase("Credit Note Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
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

                    if (dtDedit.Rows.Count > 0)
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        PdfPTable table2 = new PdfPTable(2);
                        float[] tableBody2 = { 70, 25 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                        for (int intRowBodyCount = 0; intRowBodyCount < dtDedit.Rows.Count; intRowBodyCount++)
                        {
                            decimal decAmnt = 0;
                            if (dtLedgrdDebDtl.Rows.Count > 0)
                            {
                                if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                                {
                                    decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                                }
                            }
                            string valuestringAmnt = String.Format(format, decAmnt);
                            if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                            else
                                table2.AddCell(new PdfPCell(new Phrase(dtDedit.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        }

                        var FontRed = new BaseColor(202, 3, 20);

                        decimal decTotal = 0;
                        //if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                        //{
                        //    decTotal = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
                        //}
                        if (dtLedgrdDebDtl.Rows.Count > 0)
                        {
                            if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                            {
                                decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                            }
                        }
                        string valuestringTot = String.Format(format, decTotal);
                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        //   table2.AddCell(new PdfPCell(new Phrase("AMOUNT (IN WORDS)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontBlue, Colspan = 2, BorderColor = FontBordrGrey });

                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                        table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                        document.Add(table2);
                    }

                    //if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString().Trim() != "")
                    //{
                    //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    //    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                    //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                    //}

                    float pos1 = writer.GetVerticalPosition(false);


                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    string CheckedBy = "";
                    if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }
                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);

                    //EVM0027 AUG 27
                    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    //END
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

                    if (pos1 > 140)
                    {
                        table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
                        //  table3.WriteSelectedRows(0, -1, 65, 120, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);

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

        //public string PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDedit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Credit_Note ObjEntityCredit, int Version_flg, DataTable dtinvoiceDtls)
        //{
        //    string strRet = "";
        //    clsCommonLibrary objCommon = new clsCommonLibrary();
        //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
        //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
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
        //    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
        //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
        //    string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        //    string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";
        //    string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
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
        //            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            {
        //                strdraft = "CREDIT NOTE";
        //            }
        //            else
        //            {
        //                strdraft = "CREDIT NOTE ( DRAFT )";
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

        //            //if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            //{
        //            //    footrtable.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
        //            //}
        //            //else
        //            //{
        //            //    footrtable.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
        //            //}
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase("Credit Note Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

        //            if (dtLedgrdDebDtl.Rows.Count > 0)
        //            {
        //                footrtable.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //                if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
        //                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            }
        //            else
        //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
        //            document.Add(footrtable);
        //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

        //            var FontGrey = new BaseColor(134, 152, 160);
        //            var FontBordrGrey = new BaseColor(236, 236, 236);
        //            var FontBordrBlack = new BaseColor(138, 138, 138);
        //            if (dtDedit.Rows.Count > 0)
        //            {
        //                PdfPTable table2 = new PdfPTable(2);
        //                float[] tableBody2 = { 70, 25 };
        //                table2.SetWidths(tableBody2);
        //                table2.WidthPercentage = 100;
        //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                for (int intRowBodyCount = 0; intRowBodyCount < dtDedit.Rows.Count; intRowBodyCount++)
        //                {
        //                    decimal decAmnt = 0;
        //                    if (dtLedgrdDebDtl.Rows.Count > 0)
        //                    {
        //                        if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
        //                        {
        //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
        //                        }
        //                    }
        //                    string valuestringAmnt = String.Format(format, decAmnt);

        //                    string NARRATION = "";

        //                    if (dtDedit.Rows[0]["LDGR_CR_REMRKS"].ToString() != "")
        //                    {
        //                        NARRATION = dtDedit.Rows[0]["LDGR_CR_REMRKS"].ToString();
        //                    }
        //                    else if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
        //                    {
        //                        NARRATION = dt.Rows[0]["CR_NOTE_NARRATION"].ToString();
        //                    }

        //                    Font myNormalFont = FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK);
        //                    string line1 = dtDedit.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "";
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
        //                decimal decTotal = 0;
        //                if (dtLedgrdDebDtl.Rows.Count > 0)
        //                {
        //                    if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
        //                    {
        //                        decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
        //                    }
        //                }
        //                string valuestringTot = String.Format(format, decTotal);
        //                string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
        //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
        //                document.Add(table2);
        //            }


        //            if (dtinvoiceDtls.Rows.Count > 0)
        //            {
        //                PdfPTable table2 = new PdfPTable(3);
        //                float[] tableBody2 = { 40, 30, 30 };
        //                table2.SetWidths(tableBody2);
        //                table2.WidthPercentage = 100;
        //                table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
        //                table2.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                table2.AddCell(new PdfPCell(new Phrase("AMOUNT(" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
        //                {
        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_CR_AMOUNT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                }
        //                document.Add(table2);
        //            }
        //            float pos1 = writer.GetVerticalPosition(false);
        //            string CheckedBy = "";
        //            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
        //            {
        //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
        //            }
        //            PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
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
        public string PdfPrintVersion2(DataTable dtLDGRdTLSdbcr, string Id, DataTable dt, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Credit_Note ObjEntityCredit, int Version_flg, DataTable dtinvoiceDtls)
        {
            string strRet = "";
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
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
            //0039
            globhead = Convert.ToInt32(dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString());
            //end
            clsBusinessLayer ObjBusiness = new clsBusinessLayer();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
            string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
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

                    //if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    //{
                    //    footrtable.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
                    //}
                    //else
                    //{
                    //    footrtable.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
                    //}
                    //footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 2, HorizontalAlignment = Element.ALIGN_LEFT });
                    //footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Credit Note Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    //if (dtLedgrdDebDtl.Rows.Count > 0)
                    //{
                    //    footrtable.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    //    if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
                    //        footrtable.AddCell(new PdfPCell(new Phrase(":       " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    //}
                    //else
                    //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    document.Add(footrtable);
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                    var FontGrey = new BaseColor(134, 152, 160);
                    var FontBordrGrey = new BaseColor(236, 236, 236);
                    var FontBordrBlack = new BaseColor(138, 138, 138);

                    if (dtLDGRdTLSdbcr.Rows.Count > 2) //multiple ledgers
                    {
                        var FontGreySmall = new BaseColor(236, 236, 236);

                        PdfPTable table10 = new PdfPTable(8);
                        float[] table10Body2 = { 5, 15, 12, 5, 28, 15, 10, 10 };
                        table10.SetWidths(table10Body2);
                        table10.WidthPercentage = 100;
                        table10.HeaderRows = 1;

                        table10.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 3 });
                        table10.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 3 });
                        table10.AddCell(new PdfPCell(new Phrase("DEBIT " + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        table10.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

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
                                previd = Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1 - 1]["LDGR_CR_ID"].ToString());
                            }
                            if (Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_ID"].ToString()) != previd)//evm 0044
                            {
                                cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();

                                ObjEntityCredit.Ledger_Credit_Id = Convert.ToInt32(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_ID"].ToString());
                                dtinvoiceDtls = objBussinessCredit.ReadInvoiceDtls(ObjEntityCredit);

                                if (dtLDGRdTLSdbcr.Rows.Count > 0)
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_DR_CR_STATUS"].ToString() == "0")
                                    {
                                        if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString() != "")
                                        {
                                            decDbAmnt = decDbAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString());
                                        }
                                    }
                                    else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_DR_CR_STATUS"].ToString() == "1")
                                    {
                                        if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString() != "")
                                        {
                                            decCrAmnt = decCrAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString());
                                        }
                                    }
                                }

                                string valuestringDbAmnt = String.Format(format, decDbAmnt);
                                string valuestringCrAmnt = String.Format(format, decCrAmnt);

                                table10.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });
                                table10.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_REMRKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_DR_CR_STATUS"].ToString() == "0")
                                {

                                    table10.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    table10.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                                else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_DR_CR_STATUS"].ToString() == "1")
                                {
                                    table10.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    table10.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount1]["LDGR_CR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }

                                if (dtinvoiceDtls.Rows.Count > 0)
                                {
                                    table10.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtinvoiceDtls.Rows.Count + 1 });
                                    table10.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table10.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
                                    table10.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table10.AddCell(new PdfPCell(new Phrase("INV.AMT " + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table10.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2, Rowspan = dtinvoiceDtls.Rows.Count + 1 });

                                    for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
                                    {
                                        if (dtinvoiceDtls.Rows[RowCount]["SALES_REF"].ToString() != "")
                                        {
                                            if (dtinvoiceDtls.Rows[RowCount]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                                            {
                                                table10.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table10.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                table10.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = ObjBusiness.AddCommasForNumberSeperation(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_CR_AMOUNT"].ToString(), objEntityCommon);
                                                table10.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                        }
                                    }
                                }

                            }//evm 0044
                        }

                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        string strDbcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        string strCrcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decCrAmnt));
                        table10.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
                        string DbvaluestringAmnt = String.Format(format, decDbAmnt);
                        string CrvaluestringAmnt = String.Format(format, decCrAmnt);

                        //0039
                        table10.AddCell(new PdfPCell(new Phrase(CrvaluestringAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        table10.AddCell(new PdfPCell(new Phrase(CrvaluestringAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                        table10.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 8 });
                        table10.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8 });
                        table10.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                        document.Add(table10);

                    }
                    else //2 ledgers
                    {

                        PdfPTable table2 = new PdfPTable(4);
                        float[] tableBody2 = { 35, 35, 15, 15 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        //0039
                        table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        //end
                        //table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        decimal decDbAmnt = 0;
                        decimal decCrAmnt = 0;

                        for (int intRowBodyCount = 0; intRowBodyCount < dtLDGRdTLSdbcr.Rows.Count; intRowBodyCount++)
                        {

                            if (dtLDGRdTLSdbcr.Rows.Count > 0)
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "0")
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString() != "")
                                    {
                                        decDbAmnt = decDbAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString());
                                    }
                                }
                                else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "1")
                                {
                                    if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString() != "")
                                    {
                                        decCrAmnt = decCrAmnt + Convert.ToDecimal(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString());
                                    }
                                }
                            }
                            string valuestringDbAmnt = String.Format(format, decDbAmnt);
                            string valuestringCrAmnt = String.Format(format, decCrAmnt);

                            string NARRATION = "";

                            if (dtLDGRdTLSdbcr.Rows.Count > 0)
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_REMRKS"].ToString() != "")
                                {
                                    NARRATION = dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_REMRKS"].ToString();
                                }
                            }
                            //else if (dt.Rows[intRowBodyCount]["CR_NOTE_NARRATION"].ToString() != "")
                            //{
                            //  NARRATION = dt.Rows[intRowBodyCount]["CR_NOTE_NARRATION"].ToString();
                            //}

                            Font myNormalFont = FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK);

                            string line1 = dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "";
                            string line2 = "\n" + NARRATION;
                            Paragraph p1 = new Paragraph();
                            Phrase ph1 = new Phrase(line1, myNormalFont);
                            Phrase ph2 = new Phrase(line2, myNormalFont);
                            p1.Add(ph1);
                            p1.Add(ph2);
                            PdfPCell mycell = new PdfPCell(p1);


                            table2.AddCell(new PdfPCell(mycell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                            if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "0")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() != "")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_REMRKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                                }
                                else
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                            else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "1")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() != "")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_REMRKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                                else
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }

                            if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "0")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString() != "")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                            else if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_DR_CR_STATUS"].ToString() == "1")
                            {
                                if (dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString() != "")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase(dtLDGRdTLSdbcr.Rows[intRowBodyCount]["LDGR_CR_AMT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                }
                            }
                        }


                        string valuestringTot = String.Format(format, decDbAmnt);
                        string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decDbAmnt));
                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });

                        //table2.AddCell(new PdfPCell(new Phrase(" " + valuestringTot, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                        document.Add(table2);


                        if (dtinvoiceDtls.Rows.Count > 0)
                        {
                            PdfPTable table12 = new PdfPTable(3);
                            float[] table12Body2 = { 40, 30, 30 };
                            table12.SetWidths(table12Body2);
                            table12.WidthPercentage = 100;
                            table12.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
                            table12.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            table12.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            table12.AddCell(new PdfPCell(new Phrase("AMOUNT(" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            for (int RowCount = 0; RowCount < dtinvoiceDtls.Rows.Count; RowCount++)
                            {
                                table12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                table12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                table12.AddCell(new PdfPCell(new Phrase(dtinvoiceDtls.Rows[RowCount]["CST_CNTR_CR_AMOUNT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            }
                            document.Add(table12);
                        }

                    }


                    //0039

                    //ENDDDDD

                    float pos1 = writer.GetVerticalPosition(false);
                    string CheckedBy = "";
                    if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }
                    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
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
                //headtable.AddCell(new PdfPCell(new Phrase("CREDIT NOTE LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (globhead == 1)
                {
                    headtable.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
                //table3.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(60), writer.DirectContent);
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
