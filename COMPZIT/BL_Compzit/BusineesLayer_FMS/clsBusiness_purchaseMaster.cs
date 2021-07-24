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
    public class clsBusiness_purchaseMaster
    {
        static int globfalg = 0;
        static int globhead = 0;
        clsDataLayer_PurchaseMaster objDataPurchaseMaster = new clsDataLayer_PurchaseMaster();
        public DataTable ReadCurrencies(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDiv = objDataPurchaseMaster.ReadCurrencies(objEntityPurchase);
            return dtDiv;
        }
        public DataTable ReadCustomerLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadCustomerLdger(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadBankLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadBankLdger(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadProductTax(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadProductTax(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadProductLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadProductLdger(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadPurchseOnList(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPurchseOnList(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadPurchseOnList_Sum(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPurchseOnList_Sum(objEntityPurchase);
            return dtDivision;
        }
        public void InsertPurchaseMaster(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList, List<clsEntityPurchaseMaster> objEntityAttahmentList, List<clsEntityPurchaseMaster_list> ObjEntitySalesCCList)
        {
            objDataPurchaseMaster.InsertPurchaseMaster(objEntityPurchase, objEntityPurchaseList, objEntityAttahmentList, ObjEntitySalesCCList);
        }
        public void UpdatePurchaseMaster(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList, List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Update, List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Delete, List<clsEntityPurchaseMaster> objEntityAttahmentList, List<clsEntityPurchaseMaster> objEntityDeleteAttchmntList, List<clsEntityPurchaseMaster_list> ObjEntitySalesCCList)
        {
            objDataPurchaseMaster.UpdatePurchaseMaster(objEntityPurchase, objEntityPurchaseList, ObjEntityPurchaseList_Update, ObjEntityPurchaseList_Delete, objEntityAttahmentList, objEntityDeleteAttchmntList, ObjEntitySalesCCList);
        }
        public void CancelProductMaster(clsEntityPurchaseMaster objEntityPurchase)
        {
            objDataPurchaseMaster.CancelProductMaster(objEntityPurchase);
        }
        public void ChangeProducStatus(clsEntityPurchaseMaster objEntityPurchase)
        {
            objDataPurchaseMaster.ChangeProducStatus(objEntityPurchase);
        }
        public DataTable ReadPurchaseById(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPurchaseById(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadProductPurchaseById(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadProductPurchaseById(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ChkProductMasterIsCancel(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ChkProductMasterIsCancel(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ChkProductMasterIsCnfrm(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ChkProductMasterIsCnfrm(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadSupplierCredits(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadSupplierCredits(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadPaymentCash(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPaymentCash(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadDefultLdgr(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadDefultLdgr(objEntityPurchase);
            return dtDivision;
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.readRefFormate(ObjEntitySales);
            return dtDivision;
        }

        public DataTable chkOrderNoDuplication(clsEntityPurchaseMaster objEntityShortList)
        {
            DataTable dtDiv = objDataPurchaseMaster.chkOrderNoDuplication(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDate(clsEntityPurchaseMaster objEntityShortList)
        {
            DataTable dtDiv = objDataPurchaseMaster.ReadRefNumberByDate(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadRefNumberByDateLast(clsEntityPurchaseMaster objEntityShortList)
        {
            DataTable dtDiv = objDataPurchaseMaster.ReadRefNumberByDateLast(objEntityShortList);
            return dtDiv;
        }
        public void ReopenPurchase(clsEntityPurchaseMaster objEntityShortList)
        {
            objDataPurchaseMaster.ReopenPurchase(objEntityShortList);
        }
        public DataTable ReadCorpDtls(clsEntityPurchaseMaster objEntityShortList)
        {
            DataTable dtDiv = objDataPurchaseMaster.ReadCorpDtls(objEntityShortList);
            return dtDiv;
        }
        public DataTable ReadProductName(clsEntityPurchaseMaster objEntityShortList)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadProductName(objEntityShortList);
            return dtDivision;
        }
        public DataTable ReadAttachmentById(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadAttachmentById(objEntityPurchase);
            return dtDivision;
        }
        public void ConfirmPurchase(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList)
        {
            objDataPurchaseMaster.ConfirmPurchase(objEntityPurchase, objEntityPurchaseList);
        }
        public DataTable ReadPrintVersion(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPrintVersion(objEntityPurchase);
            return dtDivision;
        }
        public DataTable ReadBankDetails(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadBankDetails(objEntityPurchase);
            return dtDivision;
        }

        public DataTable ReadPurchaseCCDetails(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadPurchaseCCDetails(objEntityPurchase);
            return dtDivision;
        }

        //evm 0044
        public DataTable ReadSupplierCreditsById(clsEntityPurchaseMaster objEntityPurchase)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPurchaseMaster.ReadSupplierCreditsById(objEntityPurchase);
            return dtDivision;
        }




        public string PdfPrintVersion1(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPurchaseMaster ObjEntitySales, string PreparedBy)
        {


            string strRet = "true";

            int intCorpId = ObjEntitySales.CorpId;

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                     };
            DataTable dtCorpDetail = new DataTable();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int TaxEnable = 0;
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }
            string strId = "";

            strId = Convert.ToString(ObjEntitySales.PurchaseId);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);



            if (ObjEntitySales.CorpId != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.CorpId;
            }
            if (ObjEntitySales.OrgId != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.OrgId;
            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PRINT);
            string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

            string strImageName = "Purchase_Invoice" + strId + "_" + strNextNumber + ".pdf";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

            Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            try
            {

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {

                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);

                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    document.Open();

                    string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);

                    if (dtCorp.Rows.Count > 0)
                    {
                        if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                        {
                            string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                            string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

                            strImageLogo = imaeposition + icon;
                        }
                    }

                    var FontBlue = new BaseColor(0, 174, 239);
                    var FontBlueGrey = new BaseColor(79, 167, 206);

                    PdfPTable headImg = new PdfPTable(2);
                    float[] headersHeading = { 60, 40 };
                    headImg.SetWidths(headersHeading);
                    headImg.WidthPercentage = 100;

                    if (strImageLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strImageLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(100f, 80f);
                        headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
                        headImg.AddCell(new PdfPCell(new Phrase(" PAYABLE INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                    else
                        headImg.AddCell(new PdfPCell(new Phrase("DRAFT PAYABLE INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });

                    document.Add(headImg);

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable footrtable = new PdfPTable(3);
                    float[] footrsBody = { 40, 30, 30 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    Font myFont = FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue);
                    Font myNormalFont = FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK);

                    string line1 = dtCorp.Rows[0][0].ToString() + "\n";

                    string line2 = dtCorp.Rows[0][4].ToString() + "\n";
                    string line3 = dtCorp.Rows[0][1].ToString() + "\n";
                    string line4 = dtCorp.Rows[0][2].ToString() + "\n";
                    string line5 = dtCorp.Rows[0][3].ToString() + "\n";
                    string line6 = "   " + "\n";


                    Paragraph p1 = new Paragraph();
                    Phrase ph1 = new Phrase(line1, myFont);
                    Phrase ph2 = new Phrase(line2, myNormalFont);
                    Phrase ph3 = new Phrase(line3, myNormalFont);
                    Phrase ph4 = new Phrase(line4, myNormalFont);
                    Phrase ph5 = new Phrase(line5, myNormalFont);
                    Phrase ph6 = new Phrase(line6, myNormalFont);
                    p1.Add(ph1);
                    p1.Add(ph2);
                    p1.Add(ph3);
                    p1.Add(ph4);
                    p1.Add(ph5);
                    p1.Add(ph6);

                    PdfPCell mycell = new PdfPCell(p1);
                    line1 = " Purchase No. :" + "\n";
                    line2 = dt.Rows[0]["PURCHS_REF"].ToString() + "\n";
                    line3 = "   " + "\n";
                    p1 = new Paragraph();
                    ph1 = new Phrase(line1, myFont);
                    ph2 = new Phrase(line2, myNormalFont);
                    ph3 = new Phrase(line3, myNormalFont);
                    p1.Add(ph1);
                    p1.Add(ph3);
                    p1.Add(ph2);

                    PdfPCell newInvoicecell = new PdfPCell(p1);
                    line1 = " Date :" + "\n";
                    line2 = dt.Rows[0]["PURCHS_DATE"].ToString() + "\n";
                    line3 = "   " + "\n";
                    p1 = new Paragraph();
                    ph1 = new Phrase(line1, myFont);
                    ph2 = new Phrase(line2, myNormalFont);
                    ph3 = new Phrase(line3, myNormalFont);
                    p1.Add(ph1);
                    p1.Add(ph3);
                    p1.Add(ph2);

                    PdfPCell newDatecell = new PdfPCell(p1);
                    line1 = "Order No. :" + "\n";
                    line2 = dt.Rows[0]["PURCHS_ORDERNO"].ToString() + "\n";
                    p1 = new Paragraph();
                    ph1 = new Phrase(line1, myFont);
                    ph2 = new Phrase(line2, myNormalFont);
                    p1.Add(ph1);
                    p1.Add(ph2);

                    PdfPCell newSupplierDetailscell = new PdfPCell(p1);

                    line1 = "To :" + "\n";
                    if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
                    {

                        line2 = dt.Rows[0]["PURCH_SUP_NAME"].ToString() + "\n";
                        line3 = dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() + "\n";
                        line4 = dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() + "\n";
                        line5 = dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() + "\n";
                        line6 = "   " + "\n";

                        p1 = new Paragraph();
                        ph1 = new Phrase(line1, myNormalFont);
                        ph2 = new Phrase(line2, myNormalFont);
                        ph3 = new Phrase(line3, myNormalFont);
                        ph4 = new Phrase(line4, myNormalFont);
                        ph5 = new Phrase(line5, myNormalFont);
                        ph6 = new Phrase(line6, myNormalFont);
                        p1.Add(ph1);
                        p1.Add(ph6);
                        p1.Add(ph2);
                        p1.Add(ph3);
                        p1.Add(ph4);
                        p1.Add(ph5);

                    }

                    else
                    {
                        line2 = dt.Rows[0]["SUPLIR_NAME"].ToString() + "\n";
                        if (dt.Rows[0]["SUPLIR_NAME"].ToString() != "")
                        {
                            line2 = dt.Rows[0]["SUPLIR_NAME"].ToString() + "\n";
                        }
                        else if (dt.Rows[0]["SUPPLIER"].ToString() != "")
                        {
                            line2 = dt.Rows[0]["SUPPLIER"].ToString() + "\n";
                        }
                        line3 = dt.Rows[0]["SUPLIR_ADDRESS"].ToString() + "\n";
                        line4 = dt.Rows[0]["SUPLIR_ADDRESS2"].ToString() + "\n";
                        line5 = dt.Rows[0]["SUPLIR_ADDRESS3"].ToString() + "\n";
                        line6 = "   " + "\n";

                        p1 = new Paragraph();
                        ph1 = new Phrase(line1, myNormalFont);
                        ph2 = new Phrase(line2, myNormalFont);
                        ph3 = new Phrase(line3, myNormalFont);
                        ph4 = new Phrase(line4, myNormalFont);
                        ph5 = new Phrase(line5, myNormalFont);
                        ph6 = new Phrase(line6, myNormalFont);
                        p1.Add(ph1);
                        p1.Add(ph6);
                        p1.Add(ph2);
                        p1.Add(ph3);
                        p1.Add(ph4);
                        p1.Add(ph5);

                    }
                    PdfPCell newContactNocell = new PdfPCell(p1);

                    line1 = "Contact Number :" + "\n";
                    if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
                    {

                        line2 = dt.Rows[0]["PURCH_SUP_CONTACT_NO"].ToString() + "\n";

                        line3 = "   " + "\n";
                        p1 = new Paragraph();
                        ph1 = new Phrase(line1, myNormalFont);
                        ph2 = new Phrase(line2, myNormalFont);
                        ph3 = new Phrase(line3, myNormalFont);
                        p1.Add(ph1);
                        p1.Add(ph3);
                        p1.Add(ph2);
                    }
                    else
                    {
                        line2 = dt.Rows[0]["SUPLIR_CONTACTNO"].ToString() + "\n";

                        line3 = "   " + "\n";
                        p1 = new Paragraph();
                        ph1 = new Phrase(line1, myNormalFont);
                        ph2 = new Phrase(line2, myNormalFont);
                        ph3 = new Phrase(line3, myNormalFont);
                        p1.Add(ph1);
                        p1.Add(ph3);
                        p1.Add(ph2);
                    }


                    PdfPCell newOrdercell = new PdfPCell(p1);
                    footrtable.AddCell(new PdfPCell(mycell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Rowspan = 3 });
                    footrtable.AddCell(new PdfPCell(newInvoicecell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    footrtable.AddCell(new PdfPCell(newDatecell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    footrtable.AddCell(new PdfPCell(newContactNocell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    footrtable.AddCell(new PdfPCell(newOrdercell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    footrtable.AddCell(new PdfPCell(newSupplierDetailscell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    footrtable.AddCell(new PdfPCell() { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

                    document.Add(footrtable);
                    string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "", ntttlWord = "";
                    decimal grosttl = 0, taxttl = 0, discnt = 0, netTottl;

                    var FontGrey = new BaseColor(134, 152, 160);
                    var FontBordrGrey = new BaseColor(236, 236, 236);
                    if (dtProduct.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() == "")
                        {
                            if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
                            {
                                grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
                                grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                                grossTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
                            {
                                taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
                                taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                                taxTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
                            {
                                discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
                                discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                                discTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                            {
                                netTottl = (grosttl + taxttl) - discnt;
                                netTotal = netTottl.ToString();
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                                netTotal = strNetAmountDebitComma;
                            }
                        }
                        else
                        {
                            if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
                            {
                                grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
                                grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                                grossTotal = strNetAmountDebitComma;
                            }

                            if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
                            {
                                taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
                                taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                                taxTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
                            {
                                discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
                                discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                                discTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                            {
                                netTottl = (grosttl + taxttl) - discnt;
                                netTotal = netTottl.ToString();
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                                netTotal = strNetAmountDebitComma;
                            }
                        }
                        string strcurrenWord = "";
                        if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                        {
                            clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                            netTottl = (grosttl + taxttl) - discnt;
                            ntttlWord = netTottl.ToString();
                            strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, ntttlWord);
                        }

                        var FontRed = new BaseColor(202, 3, 20);
                        var FontGreen = new BaseColor(46, 179, 51);
                        var FontGray = new BaseColor(138, 138, 138);
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        if (TaxEnable == 1)
                        {
                            PdfPTable table2 = new PdfPTable(6);
                            float[] tableBody2 = { 33, 10, 10, 12, 10, 15 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            else
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                string ProductPrice = "";
                                string ProductDisAmt = "";
                                string ProductTaxAmt = "";
                                string ProductTtlAmt = "";
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
                                {
                                    ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                    ProductPrice = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
                                {
                                    ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                    ProductDisAmt = strNetAmountDebitComma;
                                }

                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "")
                                {
                                    ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
                                    ProductTaxAmt = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
                                {
                                    ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                    ProductTtlAmt = strNetAmountDebitComma;
                                }

                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }

                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                            table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            table2.AddCell(new PdfPCell(new Phrase("Tax Amount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            document.Add(table2);
                        }
                        else
                        {
                            PdfPTable table2 = new PdfPTable(5);
                            float[] tableBody2 = { 36, 16, 16, 16, 16 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            else
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                string ProductPrice = "";
                                string ProductDisAmt = "";
                                string ProductTaxAmt = "";
                                string ProductTtlAmt = "";
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
                                {
                                    ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                    ProductPrice = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
                                {
                                    ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                    ProductDisAmt = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
                                {
                                    ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                    ProductTtlAmt = strNetAmountDebitComma;
                                }
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                                table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                                table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            }

                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                            table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
                            table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
                            table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
                            table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                            document.Add(table2);
                        }
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                        PdfPTable tablettl = new PdfPTable(2);
                        float[] tablettlBody = { 0, 100 };
                        tablettl.SetWidths(tablettlBody);
                        tablettl.WidthPercentage = 100;

                        tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                        tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3, BackgroundColor = FontBlue });
                        document.Add(tablettl);
                    }
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { PaddingTop = 30 });


                    string CheckedBy = "";
                    if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }
                    if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    }

                    var FontColourPrprd = new BaseColor(33, 150, 243);
                    var FontColourChkd = new BaseColor(76, 175, 80);
                    var FontColourAuthrsd = new BaseColor(255, 87, 34);

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 0, PaddingTop = 30, PaddingLeft = 0, PaddingRight = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 0, PaddingTop = 30, PaddingLeft = 0, PaddingRight = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 0, PaddingTop = 30, PaddingLeft = 0, PaddingRight = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                    table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                    table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);

                    document.Close();
                    strRet = strImagePath + strImageName;
                }
            }
            catch (Exception)
            {
                document.Close();
                strRet = "false";
            }

            return strRet;
        }

        public string PdfPrintVersion2And3(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPurchaseMaster ObjEntitySales, string PreparedBy, int VersionId)
        {
            globfalg = VersionId;
            string strRet = "true";
            int intCorpId = ObjEntitySales.CorpId;
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                     };
            DataTable dtCorpDetail = new DataTable();
            int TaxEnable = 0;
            int intCurrencyID = 0;
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                intCurrencyID = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }
            string strId = "";
            strId = Convert.ToString(ObjEntitySales.PurchaseId);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            objEntityCommon.CurrencyId = intCurrencyID;
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
            }
            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);
            if (ObjEntitySales.CorpId != 0)
            {
                objEntityCommon.CorporateID = ObjEntitySales.CorpId;
            }
            if (ObjEntitySales.OrgId != 0)
            {
                objEntityCommon.Organisation_Id = ObjEntitySales.OrgId;
            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PRINT);
            string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

            string strImageName = "Purchase_Invoice" + strId + "_" + strNextNumber + ".pdf";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

            Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
            if (VersionId == 2)
            {
                document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
            }
            globhead = Convert.ToInt32(dt.Rows[0]["PURCHS_CNFRM_STS"].ToString());
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            try
            {
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    var FontBlue = new BaseColor(0, 174, 239);
                    var FontBlueGrey = new BaseColor(79, 167, 206);
                    if (VersionId == 2)
                    {
                        writer.PageEvent = new PDFHeader();
                        document.Open();
                    }
                    else
                    {
                        document.Open();
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                    }

                    PdfPTable footrtable = new PdfPTable(2);
                    float[] footrsBody = { 20, 80 };
                    footrtable.SetWidths(footrsBody);
                    footrtable.WidthPercentage = 100;

                    string SupName = "";
                    string AddOne = "";
                    string AddTwo = "";
                    string AddThree = "";
                    if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
                    {
                        if (dt.Rows[0]["PURCH_SUP_NAME"].ToString() != "")
                        {
                            SupName = dt.Rows[0]["PURCH_SUP_NAME"].ToString();
                        }
                        if (dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() != "")
                        {
                            AddOne = dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString();
                        }
                        if (dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() != "")
                        {
                            AddTwo = dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString();
                        }
                        if (dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() != "")
                        {
                            AddThree = dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString();
                        }
                    }
                    else
                    {
                        if (dt.Rows[0]["SUPLIR_NAME"].ToString() != "")
                        {
                            SupName = dt.Rows[0]["SUPLIR_NAME"].ToString();
                        }
                        else if (dt.Rows[0]["SUPPLIER"].ToString() != "")
                        {
                            SupName = dt.Rows[0]["SUPPLIER"].ToString();
                        }
                        if (dt.Rows[0]["SUPLIR_ADDRESS"].ToString() != "")
                        {
                            AddOne = dt.Rows[0]["SUPLIR_ADDRESS"].ToString();
                        }
                        if (dt.Rows[0]["SUPLIR_ADDRESS2"].ToString() != "")
                        {
                            AddTwo = dt.Rows[0]["SUPLIR_ADDRESS2"].ToString();
                        }
                        if (dt.Rows[0]["SUPLIR_ADDRESS3"].ToString() != "")
                        {
                            AddThree = dt.Rows[0]["SUPLIR_ADDRESS3"].ToString();
                        }
                    }
                    footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, Colspan = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Invoice Reference #", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, PaddingTop = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, PaddingTop = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, PaddingTop = 6 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase(SupName.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AddOne.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AddTwo.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AddThree.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                    document.Add(footrtable);
                    
                    string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "", ntttlWord = "";
                    decimal grosttl = 0, taxttl = 0, discnt = 0, netTottl;

                    var FontGrey = new BaseColor(134, 152, 160);
                    var FontBordrGrey = new BaseColor(236, 236, 236);
                    var FontRed = new BaseColor(202, 3, 20);
                    var FontGreen = new BaseColor(46, 179, 51);
                    var FontGray = new BaseColor(138, 138, 138);

                    if (dtProduct.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() == "")
                        {
                            if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
                            {
                                grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
                                grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                                grossTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
                            {
                                taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
                                taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                                taxTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
                            {
                                discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
                                discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                                discTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                            {
                                netTottl = (grosttl + taxttl) - discnt;
                                netTotal = netTottl.ToString();
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                                netTotal = strNetAmountDebitComma;
                            }
                        }
                        else
                        {
                            if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
                            {
                                grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
                                grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                                grossTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
                            {
                                taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
                                taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                                taxTotal = strNetAmountDebitComma;

                            }
                            if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
                            {
                                discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
                                discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                                discTotal = strNetAmountDebitComma;
                            }
                            if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                            {
                                netTottl = (grosttl + taxttl) - discnt;
                                netTotal = netTottl.ToString();
                                string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                                netTotal = strNetAmountDebitComma;
                            }
                        }

                        string strcurrenWord = "";
                        if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                        {
                            clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                            netTottl = (grosttl + taxttl) - discnt;

                            ntttlWord = netTottl.ToString();
                            strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, ntttlWord);
                        }

                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                        if (TaxEnable == 1)
                        {
                            PdfPTable table2 = new PdfPTable(8);
                            float[] tableBody2 = { 5, 25, 9, 10, 7, 10, 20, 14 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            else
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                string ProductPrice = "";
                                string ProductDisAmt = "";
                                string ProductTaxAmt = "";
                                string ProductTtlAmt = "";
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
                                {
                                    ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                    ProductPrice = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
                                {
                                    ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                    ProductDisAmt = strNetAmountDebitComma;
                                }

                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "")
                                {
                                    ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
                                    ProductTaxAmt = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
                                {
                                    ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                    ProductTtlAmt = strNetAmountDebitComma;
                                }
                                string strRemarks = "";
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
                                    strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
                                int SlNo = intRowBodyCount + 1;
                                table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                            table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                            table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                            table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                            table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthLeft = 0 });
                            table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                            document.Add(table2);
                        }
                        else
                        {
                            PdfPTable table2 = new PdfPTable(7);
                            float[] tableBody2 = { 5, 32, 10, 11, 12, 16, 14 };
                            table2.SetWidths(tableBody2);
                            table2.WidthPercentage = 100;
                            table2.HeaderRows = 1;//get header column in all pages

                            table2.AddCell(new PdfPCell(new Phrase("Sl#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                            else
                                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                            for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                            {
                                string ProductPrice = "";
                                string ProductDisAmt = "";
                                string ProductTaxAmt = "";
                                string ProductTtlAmt = "";

                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
                                {
                                    ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                    ProductPrice = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
                                {
                                    ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                    ProductDisAmt = strNetAmountDebitComma;
                                }
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
                                {
                                    ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
                                    string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                    ProductTtlAmt = strNetAmountDebitComma;
                                }
                                string strRemarks = "";
                                if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
                                    strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
                                int SlNo = intRowBodyCount + 1;
                                table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });
                            table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                            table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                            table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                            table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            document.Add(table2);
                        }

                        PdfPTable tablettl = new PdfPTable(2);
                        float[] tablettlBody = { 86, 14 };
                        tablettl.SetWidths(tablettlBody);
                        tablettl.WidthPercentage = 100;
                        
                        tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
                        tablettl.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
                        document.Add(tablettl);

                        PdfPTable footrtables = new PdfPTable(2);
                        float[] footrsBodys = { 20, 80 };
                        footrtables.SetWidths(footrsBodys);
                        footrtables.WidthPercentage = 100;

                        string OrderNo = "";
                        string strTerms = "";
                        string strDescription = "";
                        if (dt.Rows[0]["PURCHS_ORDERNO"].ToString() != "")
                            OrderNo = dt.Rows[0]["PURCHS_ORDERNO"].ToString();
                        if (dt.Rows[0]["PURCHS_DESCRIPTION"].ToString() != "")
                            strDescription = dt.Rows[0]["PURCHS_DESCRIPTION"].ToString();
                        if (dt.Rows[0]["PURCHS_TERMS"].ToString() != "")
                            strTerms = dt.Rows[0]["PURCHS_TERMS"].ToString();
                        footrtables.AddCell(new PdfPCell(new Phrase("Purchase Order No.", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, PaddingTop = 10 });
                        footrtables.AddCell(new PdfPCell(new Phrase(": " + OrderNo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, PaddingTop = 10 });
                        footrtables.AddCell(new PdfPCell(new Phrase("Remarks ", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                        footrtables.AddCell(new PdfPCell(new Phrase(": " + strDescription, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                        footrtables.AddCell(new PdfPCell(new Phrase("Terms ", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                        footrtables.AddCell(new PdfPCell(new Phrase(": " + strTerms, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1 });
                        document.Add(footrtables);
                    }

                    float pos1 = writer.GetVerticalPosition(false);
                    string CheckedBy = "";
                    if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
                    {
                        CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                    }
                    if (dt.Rows[0]["INSERT_USR"].ToString() != "")
                    {
                        PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
                    }

                    PdfPTable table3 = new PdfPTable(3);
                    float[] tableBody3 = { 33, 33, 33 };
                    table3.SetWidths(tableBody3);
                    table3.WidthPercentage = 100;
                    table3.TotalWidth = 600F;

                    table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
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
                    strRet = strImagePath + strImageName;
                }
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
                    headtable.AddCell(new PdfPCell(new Phrase("PAYABLE INVOICE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase("DRAFT PAYABLE INVOICE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    }
}
