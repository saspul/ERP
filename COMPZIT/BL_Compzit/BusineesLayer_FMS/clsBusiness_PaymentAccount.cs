using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
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
    public class clsBusiness_PaymentAccount
    {
        static int globfalg = 0;
        static int globhead = 0;
        clsDataLayer_PaymentAccount objDataPaymnt = new clsDataLayer_PaymentAccount();
        public DataTable ReadCurrency(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCurrency(objEntity);
            return dtRcpt;
        }
        public DataTable ReadPurchaseBalance(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDiv = objDataPaymnt.ReadPurchaseBalance(objEntity);
            return dtDiv;
        }
        public DataTable ReadDefualtCurrency(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadDefualtCurrency(objEntity);
            return dtRcpt;
        }

        public DataTable ReadAccountLedger(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadAccountLedger(objEntity);
            return dtRcpt;
        }
        public DataTable ReadLeadgerReceipt(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadLeadgerReceipt(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenter(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCostCenter(objEntity);
            return dtRcpt;
        }


        public DataTable ReadSalesbyId(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadSalesbyId(objEntity);
            return dtRcpt;
        }
        public DataTable ReadOepningBalById(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadOepningBalById(objEntity);
            return dtRcpt;
        }
        public DataTable AccntBalancebyId(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.AccntBalancebyId(objEntity);
            return dtRcpt;
        }
        public void InsertPaymentMaster(clsEntityPaymentAccount objEntity, List<clsEntityPaymentAccount> objEntityPerfomList, List<clsEntityPaymentAccount> objEntityPerfomListGrps)
        {
            objDataPaymnt.InsertPaymentMaster(objEntity, objEntityPerfomList, objEntityPerfomListGrps);
        }
        public void UpdatePaymentLedgerCostCenter(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityLedgerIns, List<clsEntityPaymentAccount> objEntityLedgerUpd, List<clsEntityPaymentAccount> objEntityLedgerDel, List<clsEntityPaymentAccount> objEntityCostCenterIns, List<clsEntityPaymentAccount> objEntityCostCenterUpd, List<clsEntityPaymentAccount> objEntityCostCenterDel)
        {
            objDataPaymnt.UpdatePaymentLedgerCostCenter(objEntityPayment, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntityCostCenterUpd, objEntityCostCenterDel);
        }
        public DataTable Payment_List(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Payment_List(objEntity);
            return dtRcpt;
        }
        public DataTable Payment_List_Sum(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Payment_List_Sum(objEntity);
            return dtRcpt;
        }
        public void CancelPaymentAccount(clsEntityPaymentAccount objEntity)
        {
            objDataPaymnt.CancelPaymentAccount(objEntity);
        }
        public DataTable Read_PayemntCostByID(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Read_PayemntCostByID(objEntity);
            return dtRcpt;
        }
        public DataTable Read_PayemntLedgerByID(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Read_PayemntLedgerByID(objEntity);
            return dtRcpt;
        }
        public DataTable Read_PayemntLedgerByIDForPrint(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Read_PayemntLedgerByIDForPrint(objEntity);
            return dtRcpt;
        }
        public DataTable Read_PayemntByID(clsEntityPaymentAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Read_PayemntByID(objEntity);
            return dtRcpt;
        }
        public DataTable ChkPaymentMasterIsCancel(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ChkPaymentMasterIsCancel(objEntity);
            return dtDivision;
        }
        public DataTable ChkPaymentMasterIsCnfrm(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ChkPaymentMasterIsCnfrm(objEntity);
            return dtDivision;
        }
        public DataTable ReadChequeBooks(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadChequeBooks(objEntity);
            return dtDivision;
        }
        public DataTable ReadChequeBook_CancelIds(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadChequeBook_CancelIds(objEntity);
            return dtDivision;
        }
        public DataTable ReadChequeBook_UsedIds(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadChequeBook_UsedIds(objEntity);
            return dtDivision;
        }
        public DataTable ReadAccountClosingDate(clsEntityPaymentAccount objEntity)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadAccountClosingDate(objEntity);
            return dtDivision;
        }

        public void PayemntReOpenById(clsEntityPaymentAccount objEntity, List<clsEntityPaymentAccount> objEntityLedger, List<clsEntityPaymentAccount> objEntityLedgerCostCenter)
        {
            objDataPaymnt.PayemntReOpenById(objEntity, objEntityLedger, objEntityLedgerCostCenter);
        }
        public void CheckIssue_PaymentAccount(clsEntityPaymentAccount objEntity)
        {
            objDataPaymnt.CheckIssue_PaymentAccount(objEntity);
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.readRefFormate(ObjEntitySales);
            return dtDivision;
        }

        public DataTable ReadRefNumberByDate(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadRefNumberByDate(ObjEntitySales);
            return dtDivision;
        }
        public DataTable ReadRefNumberByDateLast(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPaymnt.ReadRefNumberByDateLast(ObjEntitySales);
            return dtDivision;
        }
        public DataTable ReadCorpDtls(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadCorpDtls(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable CheckPaymentCnclSts(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.CheckPaymentCnclSts(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadCostGroup1(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadCostGroup1(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadCostGroup2(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadCostGroup2(ObjEntitySales);
            return dtSaleCancelChk;
        }

        public DataTable ReadChequeTemId(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadChequeTemId(ObjEntitySales);
            return dtSaleCancelChk;
        }

        public void ConfirmPaymentFromList(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityLedgerIns, List<clsEntityPaymentAccount> objEntityLedgerUpd, List<clsEntityPaymentAccount> objEntityLedgerDel, List<clsEntityPaymentAccount> objEntityCostCenterIns, List<clsEntityPaymentAccount> objEntityCostCenterUpd, List<clsEntityPaymentAccount> objEntityCostCenterDel)
        {
            objDataPaymnt.ConfirmPaymentFromList(objEntityPayment, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntityCostCenterUpd, objEntityCostCenterDel);
        }

        public DataTable ReadPurchaseDebitNoteDtls(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadPurchaseDebitNoteDtls(ObjEntitySales);
            return dtSaleCancelChk;
        }
        public DataTable ReadPurchaseDebitNoteBalanceDtls(clsEntityPaymentAccount ObjEntitySales)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadPurchaseDebitNoteBalanceDtls(ObjEntitySales);
            return dtSaleCancelChk;
        }

        public void DeletePurchaseLedgers(List<clsEntityPaymentAccount> ObjEntityPymntCstCntrDEL)
        {
            objDataPaymnt.DeletePurchaseLedgers(ObjEntityPymntCstCntrDEL);
        }

        public DataTable ReadChqNoByChqbkId(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadChqNoByChqbkId(objEntity);
            return dtSaleCancelChk;
        }

        public DataTable CheckChequeNumbersAdded(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.CheckChequeNumbersAdded(objEntity);
            return dtSaleCancelChk;
        }
        public DataTable ReadCreditNoteDtls(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadCreditNoteDtls(objEntity);
            return dtSaleCancelChk;
        }
        public DataTable ReadSalesReturnbyId(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadSalesReturnbyId(objEntity);
            return dtSaleCancelChk;
        }
        public DataTable ReadSalesReturnBalance(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadSalesReturnBalance(objEntity);
            return dtSaleCancelChk;
        }

        public DataTable ReadExpensebyId(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadExpensebyId(objEntity);
            return dtSaleCancelChk;
        }
        public DataTable ReadExpenseBalance(clsEntityPaymentAccount objEntity)
        {
            DataTable dtSaleCancelChk = objDataPaymnt.ReadExpenseBalance(objEntity);
            return dtSaleCancelChk;
        }



        public string PdfPrintVersion1(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPaymentAccount ObjEntitySales)
        {
            string PreparedBy = "";
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
            string CheckedBy = "";
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntitySales.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
            }
            if (ObjEntitySales.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
            }
      
            string strId = "";
            strId = Convert.ToString(ObjEntitySales.PaymentId);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PRINT);
            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "Payment_Invoice" + strId + "_" + strNextNumber + ".pdf";

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
                    if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
                        headImg.AddCell(new PdfPCell(new Phrase(" PAYMENT", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                    else
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT PAYMENT", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });

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
                    footrtables.AddCell(new PdfPCell(new Phrase("Payment Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


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

                        table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                        decimal TOTAL = 0;
                        string strAmountComma = "";
                        for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                        {
                            strAmountComma= objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
                            table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            if (dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString() != "")
                            {
                                TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString());
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

                    if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "")
                    {
                        if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "0")
                        {
                            PdfPTable foottrtables = new PdfPTable(2);
                            float[] footrssBodys = { 30, 70 };
                            foottrtables.SetWidths(footrssBodys);
                            foottrtables.WidthPercentage = 100;

                            var FontColour = new BaseColor(0, 174, 239);

                            foottrtables.AddCell(new PdfPCell(new Phrase("Payment Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["CHKBK_NAME"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Book", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CHKBK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }

                                if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() != "")
                                {
                                    if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1" && dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
                                    {
                                        foottrtables.AddCell(new PdfPCell(new Phrase("Issue Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    }
                                }
                            }
                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                            }
                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "0")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "1")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "2")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "3")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }

                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }

                                if (dt.Rows[0]["PAYMNT_BK_BANK"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_BANK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                                if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_IBAN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                                }
                            }
                            foottrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                            foottrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                            document.Add(foottrtables);
                        }
                    }





                    if (dt.Rows[0]["PAYMNT_DSCRPTN"].ToString().Trim() != "")
                    {
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        document.Add(new Paragraph(new Chunk(dt.Rows[0]["PAYMNT_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    }
                    float pos1 = writer.GetVerticalPosition(false);
                    if (dt.Rows[0]["USR_NAME"].ToString() != "")
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    }

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
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

        ////////////////////////-------------old-----------////////////////////////////
        //public string PdfPrintVersion2And3(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPaymentAccount ObjEntitySales, int VersionFlag, DataTable dtPayment, string currency, DataTable dtCost)
        //{

        //    globfalg = VersionFlag;
        //    string PreparedBy = "";
        //    clsCommonLibrary objCommon = new clsCommonLibrary();
        //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
        //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
        //    string CheckedBy = "";
        //    int intCorpId = 0;
        //    clsEntityCommon objEntityCommon = new clsEntityCommon();
        //    if (ObjEntitySales.Corporate_id != 0)
        //    {
        //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
        //        intCorpId = ObjEntitySales.Corporate_id;
        //    }
        //    if (ObjEntitySales.Organisation_id != 0)
        //    {
        //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
        //    }
        //    //if (ObjEntitySales.CurrcyId != 0)
        //    //{
        //    //    objEntityCommon.CurrencyId = ObjEntitySales.CurrcyId;
        //    //}
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
        //            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
        //        if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
        //            currency = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

        //    }
        //    string strId = "";
        //    strId = Convert.ToString(ObjEntitySales.PaymentId);
        //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.DFLT_CURNCY_DISPLAY,
        //                                                   clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
        //                                           };
        //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PRINT);
        //    DataTable dtCorpDetail = new DataTable();
        //    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        //    //if (dtCorpDetail.Rows.Count > 0)
        //    //{
        //    //    objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        //    //}
        //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        //    string strImageName = "Payment_Invoice" + strId + "_" + strNextNumber + ".pdf";
        //    Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        //    if (VersionFlag != 2)
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

        //            //writer.PageEvent = new ITextEvents();
        //            writer.PageEvent = new PDFHeader();
        //            document.Open();


        //            if (VersionFlag != 2)
        //            {
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //            }
        //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //            PdfPTable footrtable = new PdfPTable(2);
        //            float[] footrsBody = { 20, 80 };
        //            footrtable.SetWidths(footrsBody);
        //            footrtable.WidthPercentage = 100;
        //            PdfPTable footrtableHead = new PdfPTable(2);

        //            float[] footrsBodyHead = { 100, 0 };
        //            footrtableHead.SetWidths(footrsBodyHead);
        //            footrtableHead.WidthPercentage = 100;

        //            if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
        //            {
        //                footrtableHead.AddCell(new PdfPCell(new Phrase("PAYMENT", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //                footrtableHead.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //            }
        //            else
        //            {
        //                footrtableHead.AddCell(new PdfPCell(new Phrase("DRAFT PAYMENT", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 2, HorizontalAlignment = Element.ALIGN_LEFT });
        //                footrtableHead.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //            }
        //            document.Add(footrtableHead);
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, Padding = 3, HorizontalAlignment = Element.ALIGN_LEFT });
        //            footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });



        //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });



        //            footrtable.AddCell(new PdfPCell(new Phrase("Payment # ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });





        //            document.Add(footrtable);


        //            //  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));





        //            if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "")
        //            {


        //                if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "0")
        //                {
        //                    PdfPTable foottrtables = new PdfPTable(2);
        //                    float[] footrssBodys = { 30, 70 };
        //                    foottrtables.SetWidths(footrssBodys);
        //                    foottrtables.WidthPercentage = 70;

        //                    foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;
        //                    foottrtables.AddCell(new PdfPCell(new Phrase("Payment Details :", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 2 });
        //                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
        //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
        //                    {
        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
        //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                        }
        //                        if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() != "")
        //                        {
        //                            if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1" && dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
        //                            {
        //                                foottrtables.AddCell(new PdfPCell(new Phrase("Issue Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                            }
        //                        }
        //                        if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                        }


        //                    }
        //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
        //                    {
        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
        //                        if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                        }
        //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0, });
        //                        }
        //                    }
        //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
        //                    {
        //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
        //                        if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "0")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "1")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "2")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "3")
        //                                foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                        }
        //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                        }
        //                        //if (dt.Rows[0]["PAYMNT_BK_BANK"].ToString() != "")
        //                        //{
        //                        //    foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        //    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_BANK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        //}
        //                        if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
        //                        {
        //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_IBAN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthTop = 0, BorderWidthLeft = 0 });
        //                        }
        //                    }

        //                    foottrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                    foottrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

        //                    document.Add(foottrtables);


        //                }
        //            }



        //            if (dtPayment.Rows.Count > 0)
        //            {
        //                string AccGrp = "";

        //                if (dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
        //                    AccGrp = dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
        //                else if (dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
        //                    AccGrp = dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
        //                if (AccGrp != "")
        //                {
        //                    PdfPTable footrtables = new PdfPTable(2);
        //                    float[] footrsBodys = { 15, 85 };
        //                    footrtables.SetWidths(footrsBodys);
        //                    footrtables.WidthPercentage = 100;
        //                    if (AccGrp == "13")
        //                    {
        //                        footrtables.AddCell(new PdfPCell(new Phrase("A/C BOOK ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                    }
        //                    else
        //                    {
        //                        footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase("          : " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
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
        //                    float[] footrsBodys = { 19, 37, 9, 11, 20 };
        //                    footrtables.SetWidths(footrsBodys);
        //                    footrtables.WidthPercentage = 100;
        //                    decimal TOTAL = 0;
        //                    TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString());
        //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, Colspan = 5 });


        //                    footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
        //                    footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });

        //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });

        //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
        //                    string strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);

        //                    footrtables.AddCell(new PdfPCell(new Phrase(strAmountComma + "  " + currency, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });



        //                    if (dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString() != "")
        //                    {
        //                        footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthBottom = 0 });


        //                        footrtables.AddCell(new PdfPCell(new Phrase("Payee Name:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
        //                    }
        //                    else
        //                    {
        //                        footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
        //                        footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });

        //                    }


        //                    document.Add(footrtables);


        //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    if (dtCost.Rows.Count > 0)
        //                    {
        //                        var FontGrey = new BaseColor(134, 152, 160);
        //                        var FontBordrGrey = new BaseColor(236, 236, 236);
        //                        var FontBordrBlack = new BaseColor(138, 138, 138);
        //                        PdfPTable table2 = new PdfPTable(3);
        //                        float[] tableBody2 = { 40, 30, 30 };
        //                        table2.SetWidths(tableBody2);
        //                        table2.WidthPercentage = 100;
        //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, Colspan = 3 });

        //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE #.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                        table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

        //                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });



        //                        for (int RowCount = 0; RowCount < dtCost.Rows.Count; RowCount++)
        //                        {
        //                            if (dtCost.Rows[RowCount]["PURCHS_REF"].ToString() != "")
        //                            {
        //                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString(), objEntityCommon);
        //                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                            }
        //                        }
        //                        document.Add(table2);

        //                    }





        //                }
        //                else
        //                {

        //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //                    var FontGrey = new BaseColor(134, 152, 160);
        //                    var FontBordrGrey = new BaseColor(236, 236, 236);
        //                    var FontBordrBlack = new BaseColor(138, 138, 138);
        //                    PdfPTable table2 = new PdfPTable(3);
        //                    float[] tableBody2 = { 40, 30, 30 };
        //                    table2.SetWidths(tableBody2);
        //                    table2.WidthPercentage = 100;
        //                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
        //                    string strAmountComma = "";
        //                    decimal TOTAL = 0;
        //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
        //                    {
        //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
        //                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
        //                        if (dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString() != "")
        //                        {
        //                            TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString());
        //                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);

        //                        }

        //                    }


        //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
        //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
        //                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });



        //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 3 });

        //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
        //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

        //                    document.Add(table2);

        //                }

        //            }


        //            if (dt.Rows[0]["PAYMNT_DSCRPTN"].ToString().Trim() != "")
        //            {

        //                document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
        //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["PAYMNT_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

        //            }
        //            float pos1 = writer.GetVerticalPosition(false);

        //            PdfPTable table3 = new PdfPTable(3);
        //            float[] tableBody3 = { 33, 33, 33 };
        //            table3.SetWidths(tableBody3);
        //            table3.WidthPercentage = 100;
        //            table3.TotalWidth = 600F;
        //            var FontBordrBlak = new BaseColor(138, 138, 138);
        //            var FontColourPrprd = new BaseColor(33, 150, 243);
        //            var FontColourChkd = new BaseColor(76, 175, 80);
        //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
        //            if (dt.Rows[0]["USR_NAME"].ToString() != "")
        //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
        //            if (dt.Rows[0]["INSERT_USR"].ToString() != "")
        //            {
        //                PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
        //            }
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

        //            table3.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("ID No.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Mobile No.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Signature", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontBordrBlak });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, Border = 0 });


        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

        //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
        //            {

        //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            }
        //            else
        //            {
        //                table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            }
        //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


        //            if (VersionFlag == 2)
        //            {
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
        //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
        //            }
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
        //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });

        //            if (pos1 > 300)
        //            {
        //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
        //                table3.WriteSelectedRows(0, -1, 50, 320, writer.DirectContent);
        //            }
        //            else
        //            {
        //                document.NewPage();
        //                table3.WriteSelectedRows(0, -1, 50, 320, writer.DirectContent);
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

        public string PdfPrintVersion2And3(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPaymentAccount ObjEntitySales, int VersionFlag, DataTable dtPayment, string currency, DataTable dtCost)
        {
            globfalg = VersionFlag;
            string PreparedBy = "";
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
            string CheckedBy = "";
            int intCorpId = 0;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (ObjEntitySales.Corporate_id != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
                intCorpId = ObjEntitySales.Corporate_id;
            }
            if (ObjEntitySales.Organisation_id != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
            }

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                    currency = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }

            string strId = "";
            strId = Convert.ToString(ObjEntitySales.PaymentId);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.DFLT_CURNCY_DISPLAY,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                   };
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PRINT);
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            int DecCnt = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());

            globhead = Convert.ToInt32(dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString());

            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
            string strImageName = "Payment_Invoice" + strId + "_" + strNextNumber + ".pdf";
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
                    PdfPTable footrtableHead = new PdfPTable(2);

                    float[] footrsBodyHead = { 100, 0 };
                    footrtableHead.SetWidths(footrsBodyHead);
                    footrtableHead.WidthPercentage = 100;
                    document.Add(footrtableHead);

                    footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Payment # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    document.Add(footrtable);

                    if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "")
                    {
                        if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "0")
                        {
                            PdfPTable foottrtables = new PdfPTable(2);
                            float[] footrssBodys = { 30, 70 };
                            foottrtables.SetWidths(footrssBodys);
                            foottrtables.WidthPercentage = 70;

                            foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;
                            foottrtables.AddCell(new PdfPCell(new Phrase("Payment Details :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, Colspan = 2 });
                            foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                }
                                if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() != "")
                                {
                                    if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1" && dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
                                    {
                                        foottrtables.AddCell(new PdfPCell(new Phrase("Issue Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                    }
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
                                }
                            }

                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0, });
                                }
                            }

                            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
                            {
                                foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                                if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Transfer Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "0")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "1")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "2")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "3")
                                        foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                                if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
                                {
                                    foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                    foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_IBAN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthTop = 0, BorderWidthLeft = 0 });
                                }
                            }
                            document.Add(foottrtables);
                            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                        }
                    }

                    if (dtPayment.Rows.Count > 0)
                    {
                        string AccGrp = "";
                        if (dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
                            AccGrp = dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
                        else if (dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
                            AccGrp = dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
                        if (AccGrp != "")
                        {
                            PdfPTable footrtables = new PdfPTable(2);
                            float[] footrsBodys = { 15, 85 };
                            footrtables.SetWidths(footrsBodys);
                            footrtables.WidthPercentage = 100;

                            if (AccGrp == "13")
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("A/C BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            else
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                footrtables.AddCell(new PdfPCell(new Phrase("            : " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            document.Add(footrtables);
                        }
                    }

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                    if (dtProduct.Rows.Count > 0)
                    {
                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();

                        decimal TOTAL = 0;

                        var FontGrey = new BaseColor(134, 152, 160);
                        var FontBordrGrey = new BaseColor(236, 236, 236);
                        var FontBordrBlack = new BaseColor(138, 138, 138);
                        var FontGreySmall = new BaseColor(236, 236, 236);

                        if (dtProduct.Rows.Count == 1)//single ledger
                        {
                            PdfPTable footrtables = new PdfPTable(5);
                            float[] footrsBodys = { 19, 37, 9, 11, 20 };
                            footrtables.SetWidths(footrsBodys);
                            footrtables.WidthPercentage = 100;

                            TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString());
                            string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));

                            footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                            string strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
                            footrtables.AddCell(new PdfPCell(new Phrase(strAmountComma + "  " + currency, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });

                            if (dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString() != "")
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                                footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthBottom = 0 });

                                footrtables.AddCell(new PdfPCell(new Phrase("Payee Name:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0 });
                                footrtables.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                            }
                            else
                            {
                                footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                                footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                            }
                            document.Add(footrtables);

                            if (dtCost.Rows.Count > 0)
                            {
                                PdfPTable table2 = new PdfPTable(3);
                                float[] tableBody2 = { 40, 30, 30 };
                                table2.SetWidths(tableBody2);
                                table2.WidthPercentage = 100;

                                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                                table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
                                table2.AddCell(new PdfPCell(new Phrase("INVOICE #.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                                table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                                table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

                                decimal value = 0;
                                int precision = DecCnt;
                                string format = String.Format("{{0:N{0}}}", precision);
                                string valuestring = String.Format(format, value);
                                int flag = 0;

                                for (int RowCount = 0; RowCount < dtCost.Rows.Count; RowCount++)
                                {
                                    if (dtCost.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
                                    {
                                        if (dtCost.Rows[RowCount]["PURCHS_REF"].ToString() != "")
                                        {
                                            if (dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString() != "")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString(), objEntityCommon);
                                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                            if (dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString(), objEntityCommon);
                                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                        }
                                        else if (dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
                                        {
                                            table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
                                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
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
                            PdfPTable table2 = new PdfPTable(7);
                            float[] tableBody2 = { 5, 15, 12, 5, 28, 15, 20 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 4 });
                            table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 2 });
                            table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                            
                            string strAmountComma = "";
                            string strAmountCommaTotal = "";
                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                if (dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString() != "")
                                {
                                    TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString());
                                    strAmountCommaTotal = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                                }

                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

                                decimal value = 0;
                                int precision = DecCnt;
                                string format = String.Format("{{0:N{0}}}", precision);
                                string valuestring = String.Format(format, value);
                                int flag = 0;

                                clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
                                ObjEntitySales.Payment_Ledgr_Id = Convert.ToInt32(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_ID"].ToString());
                                dtCost = objBussinessPayment.Read_PayemntCostByID(ObjEntitySales);
                                if (dtCost.Rows.Count > 0)
                                {
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtCost.Rows.Count + 1 });
                                    table2.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
                                    table2.AddCell(new PdfPCell(new Phrase("INV.AMT(" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtCost.Rows.Count + 1 });
                                    
                                    for (int RowCount = 0; RowCount < dtCost.Rows.Count; RowCount++)
                                    {
                                        if (dtCost.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
                                        {
                                            if (dtCost.Rows[RowCount]["PURCHS_REF"].ToString() != "")
                                            {
                                                if (dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString() != "")
                                                {
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString(), objEntityCommon);
                                                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                }
                                                if (dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                                                {
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                    table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString(), objEntityCommon);
                                                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                }
                                            }
                                            else if (dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
                                            {
                                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                                strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
                                                table2.AddCell(new PdfPCell(new Phrase("Opening balance ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
                                                table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                                            }
                                            flag++;
                                        }
                                    }
                                }
                            }
                            string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                            table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
                            table2.AddCell(new PdfPCell(new Phrase(strAmountCommaTotal, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                            table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 7 });
                            document.Add(table2);
                        }
                    }

                    float pos1 = writer.GetVerticalPosition(false);

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    var FontBordrBlak = new BaseColor(138, 138, 138);
                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);

                    if (dt.Rows[0]["USR_NAME"].ToString() != "")
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    }
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                    table3.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });

                    table3.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("ID No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("Mobile No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("Signature", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlak });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
                    {
                        table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    else
                    {
                        table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    }
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    if (pos1 > 240)
                    {
                        table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
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

                PdfPTable headtable = new PdfPTable(2);
                if (globhead == 1)
                {
                    headtable.AddCell(new PdfPCell(new Phrase("PAYMENT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DRAFT PAYMENT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
     
        //public class ITextEvents : PdfPageEventHelper
        //{

        //    // This is the contentbyte object of the writer
        //    PdfContentByte cb;

        //    // we will put the final number of pages in a template
        //    PdfTemplate headerTemplate, footerTemplate;

        //    // this is the BaseFont we are going to use for the header / footer
        //    BaseFont bf = null;

        //    // This keeps track of the creation time
        //    DateTime PrintTime = DateTime.Now;


        //    #region Fields
        //    private string _header;
        //    #endregion

        //    #region Properties
        //    public string Header
        //    {
        //        get { return _header; }
        //        set { _header = value; }
        //    }
        //    #endregion


        //    public override void OnOpenDocument(PdfWriter writer, Document document)
        //    {
        //        try
        //        {
        //            PrintTime = DateTime.Now;
        //            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //            cb = writer.DirectContent;
        //            headerTemplate = cb.CreateTemplate(100, 100);
        //            footerTemplate = cb.CreateTemplate(100, 100);
        //        }
        //        catch (DocumentException de)
        //        {
        //            //handle exception here
        //        }
        //        catch (System.IO.IOException ioe)
        //        {
        //            //handle exception here
        //        }
        //    }

        //    public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        //    {
        //        base.OnEndPage(writer, document);

        //        iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        //        iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

        //        if (globfalg == 2)
        //        {
        //            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        //            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        //            objEntityLayerStock.Corp_Id = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
        //            objEntityLayerStock.Org_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
        //            DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);
        //            clsCommonLibrary objCommon = new clsCommonLibrary();
        //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
        //            if (dtCorp.Rows.Count > 0)
        //            {
        //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
        //                {
        //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
        //                    strImageLogo = imaeposition + icon;
        //                }
        //            }
        //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
        //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
        //            image.ScaleToFit(600f, 80f);

        //            //Create PdfTable object
        //            PdfPTable pdfTab = new PdfPTable(1);
        //            PdfPCell pdfCell1 = new PdfPCell(image);

        //            //set the alignment of all three cells and set border to 0
        //            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
        //            pdfCell1.Border = 0;
        //            //add all three cells into PdfTable
        //            pdfTab.AddCell(pdfCell1);


        //            pdfTab.TotalWidth = document.PageSize.Width - 80f;
        //            pdfTab.WidthPercentage = 70;

        //            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
        //            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
        //            //Third and fourth param is x and y position to start writing             
        //            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
        //        }



        //        String text = "Page " + writer.PageNumber + " of ";
        //        ////Add paging to header
        //        //{
        //        //    cb.BeginText();
        //        //    cb.SetFontAndSize(bf, 12);
        //        //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
        //        //    cb.ShowText(text);
        //        //    cb.EndText();
        //        //    float len = bf.GetWidthPoint(text, 12);
        //        //    //Adds "12" in Page 1 of 12
        //        //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
        //        //}
        //        //Add paging to footer
        //        {
        //            cb.BeginText();
        //            cb.SetFontAndSize(bf, 12);
        //            cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(30));
        //            cb.ShowText(text);
        //            cb.EndText();
        //            float len = bf.GetWidthPoint(text, 12);
        //            cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
        //        }
        //    }

        //    public override void OnCloseDocument(PdfWriter writer, Document document)
        //    {
        //        base.OnCloseDocument(writer, document);

        //        //headerTemplate.BeginText();
        //        //headerTemplate.SetFontAndSize(bf, 12);
        //        //headerTemplate.SetTextMatrix(0, 0);
        //        //headerTemplate.ShowText((writer.PageNumber).ToString());
        //        //headerTemplate.EndText();

        //        footerTemplate.BeginText();
        //        footerTemplate.SetFontAndSize(bf, 12);
        //        footerTemplate.SetTextMatrix(0, 0);
        //        footerTemplate.ShowText((writer.PageNumber).ToString());
        //        footerTemplate.EndText();


        //    }
        //}

     


    }

}
