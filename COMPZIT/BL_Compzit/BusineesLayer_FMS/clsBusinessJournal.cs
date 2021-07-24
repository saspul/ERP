using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_FMS;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CL_Compzit;
using System.IO;
using System.Web;
using EL_Compzit;


namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessJournal
    {
        static int globhead = 0;
        static int globfalg = 0;
        clsDataLayerJournal objDataLedger = new clsDataLayerJournal();
        public DataTable ReadLedgerDdl(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadLedgerDdl(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadCostCentrDdl(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadCostCentrDdl(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadSelectList(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadSelectList(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadSelectListById(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadSelectListById(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadJournlList(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadJournlList(objEntityShortList);
            return dtDiv;
        }
        public DataTable CheckJournlCnclSts(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.CheckJournlCnclSts(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadJournalDtlsById(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadJournalDtlsById(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadJrnlLedgrDtlsById(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadJrnlLedgrDtlsById(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadJrnlCostCntrDtlsById(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadJrnlCostCntrDtlsById(objEntityShortList);
            return dtDiv;
        }


        public void CancelJournal(clsEntityJournal objEntityShortList)
        {
            objDataLedger.CancelJournal(objEntityShortList);
        }

        public DataTable ReadLedgrListDdl(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadLedgrListDdl(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadLedgrBal(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadLedgrBal(objEntityShortList);
            return dtDiv;
        }

        public void AddJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.AddJournalDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }
        public void EditJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.EditJournalDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }
        public void ConfirmJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.ConfirmJournalDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }


        public void ConfirmJournalDtlsList(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.ConfirmJournalDtlsList(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }
        public void ReopenJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.ReopenJournalDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }

        public DataTable readRefFormate(EL_Compzit.clsEntityCommon objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.readRefFormate(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDate(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadRefNumberByDate(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDateLast(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadRefNumberByDateLast(objEntityShortList);
            return dtDiv;
        }

        public DataTable ReadCorpDtls(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadCorpDtls(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadPurchaseBalance(clsEntityJournal objEntityShortList, clsEntityJournalCostCntrDtl objEntityDtl)
        {
            DataTable dtDiv = objDataLedger.ReadPurchaseBalance(objEntityShortList, objEntityDtl);
            return dtDiv;
        }
        public DataTable ReadSalesBalance(clsEntityJournal objEntityShortList, clsEntityJournalCostCntrDtl objEntityDtl)
        {
            DataTable dtDiv = objDataLedger.ReadSalesBalance(objEntityShortList, objEntityDtl);
            return dtDiv;
        }


        public void DeleteSalePurchaseLedgers(List<clsEntityJournalCostCntrDtl> ObjEntityJrnlCstCntrDEL)
        {
            objDataLedger.DeleteSalePurchaseLedgers(ObjEntityJrnlCstCntrDEL);
        }

        public DataTable ReadSalesExpense(clsEntityJournal objEntityEmpSlry)
        {
            DataTable dtDiv = objDataLedger.ReadSalesExpense(objEntityEmpSlry);
            return dtDiv;
        }







        public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
            string strRet = "";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
            objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";


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
                    float[] headersHeading = { 60, 40 };
                    headImg.SetWidths(headersHeading);
                    headImg.WidthPercentage = 100;

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
                    var FontColour = new BaseColor(79, 167, 206);

                    if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
                    {
                        headImg.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                    }
                    else
                    {
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                    }
                    document.Add(headImg);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 50, 50 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;
                    FontColour = new BaseColor(0, 174, 239);

                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    if (dtCorp.Rows.Count > 0)
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                        footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    }
                    document.Add(footrtable);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtables = new PdfPTable(2);
                    float[] footrsBodys = { 15, 85 };
                    footrtables.SetWidths(footrsBodys);
                    footrtables.WidthPercentage = 100;

                    footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                    document.Add(footrtables);

                    if (dtLedgrdDebDtl.Rows.Count > 0)
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        var FontGray = new BaseColor(138, 138, 138);

                        PdfPTable table2 = new PdfPTable(4);
                        float[] tableBody2 = { 40, 20, 20, 20 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.HeaderRows = 1;//get header column in all pages

                        FontColour = new BaseColor(134, 152, 160);
                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });


                        var FontColour_BORDER = new BaseColor(236, 236, 236);
                        for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
                        {
                            decimal decAmnt = 0;
                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
                            {
                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
                            }
                            string valuestringAmnt = String.Format(format, decAmnt);
                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
                            {
                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else
                            {
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
                            {
                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else
                            {
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }

                        FontColour = new BaseColor(216, 49, 61);

                        decimal decTotal = 0;
                        if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                        {
                            decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
                        }
                        string valuestringTot = String.Format(format, decTotal);

                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                        if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                        {
                            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                        }
                        string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
                        FontColour = new BaseColor(0, 174, 239);

                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });

                        document.Add(table2);
                    }

                    if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                    }

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                    float pos1 = writer.GetVerticalPosition(false);

                    string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
                    {
                        table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    else
                    {
                        table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }

                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);

                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                    if (pos1 > 141)
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
        public string PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
        {

            globfalg = Version_flg;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            string strRet = "";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
            objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";
            Document document = new Document(PageSize.A4.Rotate(), 50f, 40f, 120f, 30f);
            if (Version_flg == 2)
            {
                document = new Document(PageSize.A4.Rotate(), 50f, 40f, 20f, 55f);
            }
            globhead = Convert.ToInt32(dt.Rows[0]["JURNL_CNFRM_STS"].ToString());
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            try
            {
                int precision = Convert.ToInt32(DecCnt);
                string format = String.Format("{{0:N{0}}}", precision);

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    string strImageLogo = "";

                    var FontBlue = new BaseColor(0, 174, 239);
                    var FontBlueGrey = new BaseColor(79, 167, 206);

                    if (Version_flg == 2)
                    {
                        writer.PageEvent = new PDFHeader();
                    }

                    document.Open();

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 20, 80 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    document.Add(footrtable);
                    
                    var FontRed = new BaseColor(202, 3, 20);
                    var FontGreen = new BaseColor(46, 179, 51);
                    var FontGray = new BaseColor(138, 138, 138);

                    if (dtLedgrdDebDtl.Rows.Count > 0)
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                        PdfPTable table2 = new PdfPTable(8);
                        float[] tableBody2 = { 18, 12, 12, 13, 12, 12, 12, 14 };
                        table2.SetWidths(tableBody2);
                        table2.WidthPercentage = 100;
                        table2.HeaderRows = 1;//get header column in all pages

                        var FontColour = new BaseColor(134, 152, 160);

                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("COST-G1", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("COST-G2", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        table2.AddCell(new PdfPCell(new Phrase("CC AMT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3, BorderColor = FontGray, BackgroundColor = FontColour });
                        
                        var FontColour_BORDER = new BaseColor(236, 236, 236);
                        int FLG = 0;
                        int cstcntrSts = 0;
                        for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
                        {
                            decimal decAmnt = 0;
                            DataTable dtCostCntrDebDtl = new DataTable();
                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString() != "")
                            {
                                objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString());
                                dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                            }

                            if (dtCostCntrDebDtl.Rows.Count > 0)
                            {
                                FLG = 0;

                                decimal CstAmmount = 0;
                                for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                                {
                                    decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                                    string valuestringCost = String.Format(format, costAmnt);
                                    if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                                    {
                                        string costGrp1 = dtCostCntrDebDtl.Rows[j]["GRP_NAME_ONE"].ToString();
                                        string costGrp2 = dtCostCntrDebDtl.Rows[j]["GRP_NAME_TWO"].ToString();
                                        string costCntr = dtCostCntrDebDtl.Rows[j]["COSTCNTR_NAME"].ToString();
                                        decimal DecCstAmt = 0;
                                        if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString() != "")
                                        {
                                            DecCstAmt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());
                                        }
                                        string valuestringCstAmnt = String.Format(format, DecCstAmt);
                                        CstAmmount = CstAmmount + Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());
                                        if (FLG == 0)
                                        {
                                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
                                            {
                                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
                                            }
                                            string valuestringAmnt = String.Format(format, decAmnt);

                                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            }
                                            else
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            }

                                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            }
                                            else
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            }
                                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        }
                                        else
                                        {
                                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        }
                                        table2.AddCell(new PdfPCell(new Phrase(costGrp1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        table2.AddCell(new PdfPCell(new Phrase(costGrp2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        table2.AddCell(new PdfPCell(new Phrase(costCntr, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        table2.AddCell(new PdfPCell(new Phrase(valuestringCstAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        FLG = 1;
                                    }
                                    else
                                    {
                                        cstcntrSts = 1;
                                    }
                                }
                                if (FLG == 1)
                                {
                                    if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                    {
                                        objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                    }
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
                                    table2.AddCell(new PdfPCell(new Phrase("CC-TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 3 });
                                    string CstCntrTotalDec = String.Format(format, CstAmmount);
                                    table2.AddCell(new PdfPCell(new Phrase(CstCntrTotalDec, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
                                }

                                if (FLG == 0)
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
                                    {
                                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
                                    }
                                    string valuestringAmnt = String.Format(format, decAmnt);
                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
                                    {
                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    }
                                    else
                                    {
                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    }
                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
                                    {
                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    }
                                    else
                                    {
                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    }
                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }
                            else
                            {
                                table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
                                {
                                    decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
                                }
                                string valuestringAmnt = String.Format(format, decAmnt);
                                if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                else
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
                                {
                                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                else
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                        }
                        decimal decTotal = 0;
                        if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                        {
                            decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
                        }
                        string valuestringTot = String.Format(format, decTotal);
                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                        {
                            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                        }
                        string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
                        table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 8 });
                        document.Add(table2);
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                    }
                    if (Version_flg == 2)
                    {
                        if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
                        {
                            document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                            document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        }
                    }
                    float pos1 = writer.GetVerticalPosition(false);

                    var phrase2 = new Phrase();
                    var phrase5 = new Phrase();
                    var FontBlack = new BaseColor(8, 7, 7);

                    string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 700F;

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
                    {
                        table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    else
                    {
                        table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (pos1 > 65)
                    {
                        table3.WriteSelectedRows(0, -1, 65, 90, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 65, 95, writer.DirectContent);
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
                    headtable.AddCell(new PdfPCell(new Phrase("JOURNAL", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("JOURNAL ( DRAFT)", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
                headtable.AddCell(new PdfPCell(new Phrase("____________________________________________________________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
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
                tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
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
                table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                PdfPTable headImg = new PdfPTable(3);
                string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
                headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
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
    }
}
