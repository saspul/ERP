using System;
using System.Collections.Generic;
using EL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CL_Compzit;
using System.IO;
using System.Web;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessPostdated_Cheque
    {
        //0039
        static int globfalg = 0;
        static int globhead = 0;
        //end
        clsDataLayer_Postdated_Cheque objDataCheque = new clsDataLayer_Postdated_Cheque();

        public DataTable Read_SupplierLeadger(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_SupplierLeadger(objEntityCheque);
            return dtRcpt;
        }
        public DataTable ReadChequeBooks(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadChequeBooks(objEntityCheque);
            return dtDivision;
        }
        //0039
        public DataTable Read_PayemntByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_PayemntByID(objEntityCheque);
            return dtRcpt;
        }

        public DataTable Read_PayemntLedgerByIDForPrint(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_PayemntLedgerByIDForPrint(objEntityCheque);
            return dtRcpt;
        }

        public DataTable Read_PayemntCostByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_PayemntCostByID(objEntityCheque);
            return dtRcpt;
        }

        public DataTable ReadCorpDtls(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtSaleCancelChk = objDataCheque.ReadCorpDtls(objEntityCheque);
            return dtSaleCancelChk;
        }

        public DataTable AccntBalancebyId(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.AccntBalancebyId(objEntityCheque);
            return dtRcpt;
        }
        //end
        public DataTable ReadChequeBook_CancelIds(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadChequeBook_CancelIds(objEntityCheque);
            return dtDivision;
        }
        public DataTable ReadChequeBook_UsedIds(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadChequeBook_UsedIds(objEntityCheque);
            return dtDivision;
        }
        public DataTable ReadRefFormate(clsEntityCommon ObjEntityCommon)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadRefFormate(ObjEntityCommon);
            return dtDivision;
        }
        public DataTable ReadRefNumberByDate(clsEntity_Postdated_Cheque objEntityCheques)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadRefNumberByDate(objEntityCheques);
            return dtDivision;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataCheque.ReadRefNumberByDateLast(objEntityCheque);
            return dtDivision;
        }
        public void InsertPostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
        {
            objDataCheque.InsertPostDatedCheque(objEntityCheque, objEntityChequeList);
        }
        public DataTable PostDatedCheque_List(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.PostDatedCheque_List(objEntityCheque);
            return dtRcpt;
        }

        public DataTable Read_PostDatedChequeByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_PostDatedChequeByID(objEntityCheque);
            return dtRcpt;
        }
        public DataTable Read_Cheque_Dtls_ById(clsEntity_Postdated_Cheque objEntityCheque)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCheque.Read_Cheque_Dtls_ById(objEntityCheque);
            return dtRcpt;
        }
           public void UpdatePostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
        {
            objDataCheque.UpdatePostDatedCheque(objEntityCheque, objEntityChequeList);
        }
           public void CancelPostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque)
        {
            objDataCheque.CancelPostDatedCheque(objEntityCheque);
        }
           public void UpdateChequePaidRejectStatus(clsEntity_Postdated_Cheque objEntityCheque)
           {
               objDataCheque.UpdateChequePaidRejectStatus(objEntityCheque);
           }
           public void Confirm_List(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
           {
               objDataCheque.Confirm_List(objEntityCheque, objEntityChequeList);
           }
           public void Reopen_list(clsEntity_Postdated_Cheque objEntityCheque)
           {
               objDataCheque.Reopen_list(objEntityCheque);
           }
           public DataTable CheckChequeCanceled(clsEntity_Postdated_Cheque objEntity)
           {
               DataTable dtDivision = new DataTable();
               dtDivision = objDataCheque.CheckChequeCanceled(objEntity);
               return dtDivision;
           }
           public DataTable CheckChequeConfirmed(clsEntity_Postdated_Cheque objEntity)
           {
               DataTable dtDivision = new DataTable();
               dtDivision = objDataCheque.CheckChequeConfirmed(objEntity);
               return dtDivision;
           }
           public DataTable CheckChequePaid(clsEntity_Postdated_Cheque objEntity)
           {
               DataTable dtDivision = new DataTable();
               dtDivision = objDataCheque.CheckChequePaid(objEntity);
               return dtDivision;
           }
           public DataTable CheckChequeIsPaid_Reject(clsEntity_Postdated_Cheque objEntity)
           {
               DataTable dtDivision = new DataTable();
               dtDivision = objDataCheque.CheckChequeIsPaid_Reject(objEntity);
               return dtDivision;
           }
           public DataTable Read_Cheque_Dtls_By_ChequeId(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.Read_Cheque_Dtls_By_ChequeId(objEntityCheque);
               return dtRcpt;
           }
           public DataTable Read_Cheque_Dtls_Payment(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.Read_Cheque_Dtls_Payment(objEntityCheque);
               return dtRcpt;
           }
           public DataTable CheckDupBankAcNum(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.CheckDupBankAcNum(objEntityCheque);
               return dtRcpt;
           }

           //Report
           public DataTable Read_CustmerLeadger(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.Read_CustmerLeadger(objEntityCheque);
               return dtRcpt;
           }
           public DataTable Read_PostdatedCheque_Report_List(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.Read_PostdatedCheque_Report_List(objEntityCheque);
               return dtRcpt;
           }
           public DataTable Read_PostdatedCheque_Home_List(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = new DataTable();
               dtRcpt = objDataCheque.Read_PostdatedCheque_Home_List(objEntityCheque);
               return dtRcpt;
           }

           public DataTable ReadChqNoByChqbkId(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = objDataCheque.ReadChqNoByChqbkId(objEntityCheque);
               return dtRcpt;
           }

           public DataTable ReadSalesPurchase(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = objDataCheque.ReadSalesPurchase(objEntityCheque);
               return dtRcpt;
           }

           public DataTable ReadIncomeExpenses(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = objDataCheque.ReadIncomeExpenses(objEntityCheque);
               return dtRcpt;
           }

           public DataTable CheckChequeNumbersAdded(clsEntity_Postdated_Cheque objEntityCheque)
           {
               DataTable dtRcpt = objDataCheque.CheckChequeNumbersAdded(objEntityCheque);
               return dtRcpt;
           }







            //0039 pfd v1
           public string PdfPrintVersion1(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Postdated_Cheque objEntityCheque)
           {
               string PreparedBy = "";
               clsCommonLibrary objCommon = new clsCommonLibrary();
               int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE);
               string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE);
               string CheckedBy = "";
               clsEntityCommon objEntityCommon = new clsEntityCommon();
               if (objEntityCheque.Corporate_id != 0)
               {
                   objEntityCommon.CorporateID = objEntityCheque.Corporate_id;
               }
               if (objEntityCheque.Organisation_id != 0)
               {
                   objEntityCommon.Organisation_Id = objEntityCheque.Organisation_id;
               }
               objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.POSTDATED_CHEQUE_FILE);
               string strId = "";
               strId = Convert.ToString(objEntityCheque.PaymentId);
               clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

               string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
               string strImageName = "Postdated_Cheque" + strId + "_" + strNextNumber + ".pdf";

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

                       var FontBlue = new BaseColor(0, 174, 239);
                       var FontBlueGrey = new BaseColor(79, 167, 206);
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
                       if (dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                           headImg.AddCell(new PdfPCell(new Phrase("POSTDATED CHEQUE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                       else
                           headImg.AddCell(new PdfPCell(new Phrase("DRAFT POSTDATED CHEQUE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });

                       float[] headersHeading = { 60, 40 };
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
                       document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                       PdfPTable footrtables = new PdfPTable(2);
                       float[] footrsBodys = { 20, 80 };
                       footrtables.SetWidths(footrsBodys);
                       footrtables.WidthPercentage = 100;

                       footrtables.AddCell(new PdfPCell(new Phrase("Postdated cheque Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                       footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                       footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                       footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                       footrtables.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                       footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                       document.Add(footrtables);

                       if (dtProduct.Rows.Count > 0)
                       {
                           objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                           var FontGrey = new BaseColor(134, 152, 160);
                           var FontBordrGrey = new BaseColor(236, 236, 236);
                           var FontBordrBlack = new BaseColor(138, 138, 138);

                           PdfPTable table2 = new PdfPTable(2);
                           float[] tableBody2 = { 70, 30 };
                           table2.SetWidths(tableBody2);
                           table2.WidthPercentage = 100;
                           table2.HeaderRows = 1;//get header column in all pages

                           table2.AddCell(new PdfPCell(new Phrase("CHEQUE NUMBER", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table2.AddCell(new PdfPCell(new Phrase("CHEQUE DATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           
                           decimal TOTAL = 0;
                           string strAmountComma = "";
                           for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                           {
                               strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);
                               table2.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table2.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["CHQ_DTLS_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               if (dtProduct.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                               {
                                   TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString());
                                   strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                               }
                           }
                           var FontColour = new BaseColor(216, 49, 61);
                           clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                           string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                           table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                           FontColour = new BaseColor(0, 174, 239);

                           table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                           table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey, Colspan = 7 });
                           table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

                           document.Add(table2);
                       }

                       float pos1 = writer.GetVerticalPosition(false);
                       //if (dt.Rows[0]["USR_NAME"].ToString() != "")
                       //    CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                       //if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                       //{
                       //    PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                       //}

                       PdfPTable table3 = new PdfPTable(3);
                       float[] tableBody3 = { 33, 33, 33 };
                       table3.SetWidths(tableBody3);
                       table3.WidthPercentage = 100;
                       table3.TotalWidth = 600F;

                       table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                       if (dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                       {
                           table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       }
                       else
                       {
                           table3.AddCell(new PdfPCell(new Phrase("   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       }
                       table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                       var FontColourPrprd = new BaseColor(33, 150, 243);
                       var FontColourChkd = new BaseColor(76, 175, 80);
                       var FontColourAuthrsd = new BaseColor(255, 87, 34);

                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                       table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                       if (pos1 > 25)
                       {
                           table3.WriteSelectedRows(0, -1, 0, 50, writer.DirectContent);
                       }
                       else
                       {
                           document.NewPage();
                           table3.WriteSelectedRows(0, -1, 0, 50, writer.DirectContent);
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

           //0039
           public string PdfPrintVersion2And3(DataTable dtforprnnt, DataTable dtLDGRdTLS, DataTable dtCorp, clsEntity_Postdated_Cheque objEntityCheque, int VersionFlag, string currency)
           {
               globfalg = VersionFlag;
               string PreparedBy = "";
               clsCommonLibrary objCommon = new clsCommonLibrary();
               int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE);
               string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.POSTDATED_CHEQUE);
               string CheckedBy = "";
               int intCorpId = 0;
               clsEntityCommon objEntityCommon = new clsEntityCommon();
               if (objEntityCheque.Corporate_id != 0)
               {
                   objEntityCommon.CorporateID = objEntityCheque.Corporate_id;
                   intCorpId = objEntityCheque.Corporate_id;
               }
               if (objEntityCheque.Organisation_id != 0)
               {
                   objEntityCommon.Organisation_Id = objEntityCheque.Organisation_id;
               }

               if (dtforprnnt.Rows.Count > 0)
               {
                   if (dtforprnnt.Rows[0]["CRNCMST_ID"].ToString() != "")
                       objEntityCommon.CurrencyId = Convert.ToInt32(dtforprnnt.Rows[0]["CRNCMST_ID"].ToString());
                   if (dtforprnnt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                       currency = dtforprnnt.Rows[0]["CRNCMST_ABBRV"].ToString();
               }

               string strId = "";
               strId = Convert.ToString(objEntityCheque.PaymentId);
               clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
               clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.DFLT_CURNCY_DISPLAY,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                   };
               objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.POSTDATED_CHEQUE_FILE);
               DataTable dtCorpDetail = new DataTable();
               dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
               int DecCnt = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());

               //0039
               globhead = Convert.ToInt32(dtforprnnt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString());
               //end
               string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
               string strImageName = "Postdated_Cheque" + strId + "_" + strNextNumber + ".pdf";
               Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
               if (VersionFlag == 2)
               {
                   document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
               }
               Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
               string strRet = "";
               try
               {
                   using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                   {
                       FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                       PdfWriter writer = PdfWriter.GetInstance(document, file);
                       if (VersionFlag == 2)
                       {
                           writer.PageEvent = new PDFHeader();
                           document.Open();
                       }
                       else
                       {
                           document.Open();
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                       }



                       PdfPTable footrtable = new PdfPTable(2);
                       float[] footrsBody = { 20, 80 };
                       footrtable.SetWidths(footrsBody);
                       footrtable.WidthPercentage = 100;
                       //PdfPTable footrtableHead = new PdfPTable(2);


                       footrtable.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                       footrtable.AddCell(new PdfPCell(new Phrase("Postdated Cheque #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                       //0039
                       footrtable.AddCell(new PdfPCell(new Phrase("Transaction Type", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                       {
                           footrtable.AddCell(new PdfPCell(new Phrase(": Payment", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       }
                       else if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                       {
                           footrtable.AddCell(new PdfPCell(new Phrase(": Reciept", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       }
                       //end

                       footrtable.AddCell(new PdfPCell(new Phrase("A/C BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["ACCOUNT_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       if (dtforprnnt.Rows[0]["BANK_ACC_NO"].ToString() != "")
                       {
                           footrtable.AddCell(new PdfPCell(new Phrase("A/C # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                           footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                       } 
                       document.Add(footrtable);

                       document.Add(new Paragraph(new Chunk("Cheque Details", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
                       document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


                       var FontGrey = new BaseColor(134, 152, 160);
                       var FontBordrGrey = new BaseColor(236, 236, 236);
                       var FontBordrBlack = new BaseColor(138, 138, 138);
                       var FontGreySmall = new BaseColor(236, 236, 236);
                       var FontColour = new BaseColor(255, 255, 255);

                       string strAmountComma = "";
                       string strAmountCommaTotal = "";
                       decimal TOTAL = 0;

                       PdfPTable table4 = new PdfPTable(3);
                       float[] table4Body = { 33, 33, 34 };
                       table4.SetWidths(table4Body);
                       table4.WidthPercentage = 100;
                       clsBusinessLayer ObjBusiness = new clsBusinessLayer();

                        string strcurrenWord;
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                       {
                           PdfPTable table41 = new PdfPTable(4);
                           float[] table4Body1 = { 25, 25, 25,25 };
                           table41.SetWidths(table4Body1);
                           table41.WidthPercentage = 100;

                           table41.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

                           table41.AddCell(new PdfPCell(new Phrase("Cheque #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table41.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table41.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });


                           for (int intRowBodyCount = 0; intRowBodyCount < dtLDGRdTLS.Rows.Count; intRowBodyCount++)
                           {
                               if (dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                               {
                                   TOTAL += Convert.ToDecimal(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString());
                                   strAmountCommaTotal = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                                   strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                               }
                              
                               if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                               {
                                   table41.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_BANK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               }

                               table41.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table41.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table41.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }
                           strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                           table41.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                           table41.AddCell(new PdfPCell(new Phrase(" " + TOTAL, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontColour, BorderColor = FontBordrBlack });
                           document.Add(table41);
                       }
                       else
                       {
                           table4.AddCell(new PdfPCell(new Phrase("Cheque #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table4.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table4.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });


                           for (int intRowBodyCount = 0; intRowBodyCount < dtLDGRdTLS.Rows.Count; intRowBodyCount++)
                           {
                               if (dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                               {
                                   TOTAL += Convert.ToDecimal(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString());
                                   strAmountCommaTotal = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                                   strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                               }


                               table4.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table4.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                               table4.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }

                             strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                           table4.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                           table4.AddCell(new PdfPCell(new Phrase(" " + TOTAL, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontColour, BorderColor = FontBordrBlack });
                           document.Add(table4);
                       }

                       document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    

                       PdfPTable footrtables = new PdfPTable(5);
                       float[] footrsBodys = { 19, 37, 9, 11, 20 };
                       footrtables.SetWidths(footrsBodys);
                       footrtables.WidthPercentage = 100;

                       footrtables.AddCell(new PdfPCell(new Phrase("Party   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                       footrtables.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                       footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                       footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                       footrtables.AddCell(new PdfPCell(new Phrase(strAmountComma + "  " + currency, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });

                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                       {
                           footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                           footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                           footrtables.AddCell(new PdfPCell(new Phrase("Payee Name:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0 });
                           footrtables.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PST_CHEQUE_PAYEE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                       }
                       else
                       {
                           footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                           footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK , BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                         
                       }
                       document.Add(footrtables);

                       document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


                       if (dtforprnnt.Rows[0]["PST_CHEQUE_METHOD_STS"].ToString() == "1")
                       {

                           PdfPTable table6 = new PdfPTable(3);
                           float[] table6Bodys = { 33, 33, 34 };
                           table6.SetWidths(table6Bodys);
                           table6.WidthPercentage = 100;

                           table6.AddCell(new PdfPCell(new Phrase("Invoice #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table6.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                           table6.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

                           if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                           {
                               table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }
                           else if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                           {
                               table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }
                           if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                           {
                               table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }
                           else if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                           {
                               table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           }
                          // table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           table6.AddCell(new PdfPCell(new Phrase(" " + TOTAL, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                           document.Add(table6);
                       }

                       if (dtforprnnt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString().Trim() != "")
                       {
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                           document.Add(new Paragraph(new Chunk(dtforprnnt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                           document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                       }
                 
                       //0039
                       float pos1 = writer.GetVerticalPosition(false);
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                       {
                           CheckedBy = dtforprnnt.Rows[0]["USR_NAME"].ToString();
                       }
                       PreparedBy = dtforprnnt.Rows[0]["INSERT_USR"].ToString();
                       PdfPTable table3 = new PdfPTable(3);
                       float[] tableBody3 = { 33, 33, 33 };
                       table3.SetWidths(tableBody3);
                       table3.WidthPercentage = 100;
                       table3.TotalWidth = 600F;
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                       {

                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                           table3.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });
                           table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });

                           table3.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                           table3.AddCell(new PdfPCell(new Phrase("ID No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                           table3.AddCell(new PdfPCell(new Phrase("Mobile No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                           table3.AddCell(new PdfPCell(new Phrase("Signature", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlack });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, Border = 0 });

                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                           table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                       }
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                       {
                           var FontColourPrprd = new BaseColor(33, 150, 243);
                           var FontColourChkd = new BaseColor(76, 175, 80);
                           var FontColourAuthrsd = new BaseColor(255, 87, 34);
                       }
                       table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                       table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                       {
                           if (pos1 > 240)
                           {
                               table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
                           }
                           else
                           {
                               document.NewPage();
                               table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
                           }
                       }
                       if (dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "1")
                       {
                           if (VersionFlag == 2)
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
                       }
                       //END

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


         //0039
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

                   PdfPTable headtable = new PdfPTable(2);
                   if (globhead == 1)
                   {
                       headtable.AddCell(new PdfPCell(new Phrase("POSTDATED CHEQUE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                   }
                   else
                   {
                       headtable.AddCell(new PdfPCell(new Phrase("DRAFT POSTDATED CHEQUE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
                   //}
                   //else
                   //{
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                   //}

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
          //end

    }
    
}
