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
  public class clsBusinessSales
    {
      static int globfalg = 0;
      static int globhead = 0;

      clsDataLayer_Sales objDataSales=new  clsDataLayer_Sales();
      public DataTable ReadCustomerLedger(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadCustomerLedger(ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadAccountName(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadAccountName(ObjEntitySales);
          return dtReadTcsList;
      }
      public void ConfirmExpenseDetls(clsEntitySales ObjEntitySales)
      {


          objDataSales.ConfirmExpenseDetls(ObjEntitySales);

      }
      public DataTable ReadProducts(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadProducts(ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadTax(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadTax(ObjEntitySales);
          return dtReadTcsList;
      }

      public void InsertSalesDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesList, List<clsEntitySales> ObjEntitySalesAttachmntList, List<clsEntitySales> ObjEntitySalesCCList)
      {
          objDataSales.InsertSalesDetls(ObjEntitySales, ObjEntitySalesList, ObjEntitySalesAttachmntList, ObjEntitySalesCCList);
      }
      public DataTable ReadSalesDetailsList(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadSalesDetailsList(ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadSalesDetailsList_Sum(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadSalesDetailsList_Sum(ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadSalesDetailsById(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadSalesDetailsById(ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadProductSalesById(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadProductSalesById(ObjEntitySales);
          return dtReadTcsList;
      }
      public void UpdateSalesDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesInsertList, List<clsEntitySales> ObjEntitySalesUpdateList, List<clsEntitySales> ObjEntitySalesDeleteList, List<clsEntitySales> ObjEntitySalesAttachmntList, List<clsEntitySales> ObjEntityDeleteSalesAttachmntList, List<clsEntitySales> ObjEntitySalesCCList)
      {
          objDataSales.UpdateSalesDetls(ObjEntitySales, ObjEntitySalesInsertList, ObjEntitySalesUpdateList, ObjEntitySalesDeleteList, ObjEntitySalesAttachmntList, ObjEntityDeleteSalesAttachmntList, ObjEntitySalesCCList);
      }
      public void CancelSalesDtlsById(clsEntitySales ObjEntitySales)
      {
          objDataSales.CancelSalesDtlsById(ObjEntitySales);
      }
      public void ChangeStatusById(clsEntitySales ObjEntitySales)
      {
          objDataSales.ChangeStatusById(ObjEntitySales);
      }
      public void ConfmSaleDetlById(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesListINS, List<clsEntitySales> ObjEntitySalesListUPD)
      {
          objDataSales.ConfmSaleDetlById(ObjEntitySales, ObjEntitySalesListINS, ObjEntitySalesListUPD);
      }
      public DataTable SaleCancelChk(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.SaleCancelChk(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadCurrency(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadCurrency(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadDefualtCurrency(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadDefualtCurrency(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadCrncyAbrvtn(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadCrncyAbrvtn(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadCustomerCredits(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadCustomerCredits(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadCustomerDtls(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadCustomerDtls(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadCorpDtls(clsEntitySales ObjEntitySales)
      {
          DataTable dtSaleCancelChk = objDataSales.ReadCorpDtls(ObjEntitySales);
          return dtSaleCancelChk;
      }
      public DataTable ReadDefultLdgr(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadDefultLdgr(ObjEntitySales);
          return dtDivision;
      }
      public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.readRefFormate(ObjEntitySales);
          return dtDivision;
      }

      public DataTable readFinancialYear(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.readFinancialYear(ObjEntitySales);
          return dtDivision;
      }
      public DataTable readAcntClsDate(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.readAcntClsDate(ObjEntitySales);
          return dtDivision;
      }
      public DataTable ReadRefNumberByDate(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadRefNumberByDate(ObjEntitySales);
          return dtDivision;
      }
      public DataTable ReadRefNumberByDateLast(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadRefNumberByDateLast(ObjEntitySales);
          return dtDivision;
      }
      public void ReopenSales(clsEntitySales ObjEntitySales)
      {
          objDataSales.ReopenSales(ObjEntitySales);
      }
      public DataTable ReadProductName(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadProductName(ObjEntitySales);
          return dtDivision;
      }
      public DataTable ReadAttachmentById(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadAttachmentById(ObjEntitySales);
          return dtDivision;
      }
      public void ConfirmSales(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesList)
      {
          objDataSales.ConfirmSales(ObjEntitySales, ObjEntitySalesList);
      }
      public DataTable ReadPrintVersion(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadPrintVersion(ObjEntitySales);
          return dtDivision;
      }
      public DataTable ReadBankDetails(clsEntitySales ObjEntitySales)
      {
          DataTable dtDivision = new DataTable();
          dtDivision = objDataSales.ReadBankDetails(ObjEntitySales);
          return dtDivision;
      }

      public DataTable ReadSaleCCDetails(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadSaleCCDetails(ObjEntitySales);
          return dtReadTcsList;
      }

      public DataTable ReadSaleCreditDtls(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadSaleCreditDtls(ObjEntitySales);
          return dtReadTcsList;
      }

      public void DeleteDuplicateSales(clsEntitySales ObjEntitySales)
      {
          objDataSales.DeleteDuplicateSales(ObjEntitySales);
      }

      //evm 0044 16/01/2020
      public string CheckCodeDuplicatn(clsEntitySales ObjEntitySales)
      {
          string count = objDataSales.CheckCodeDuplicatn(ObjEntitySales);
          return count;
      }
      //evm 0044 09/03/2020
      public DataTable ReadLedger(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadLedgers (ObjEntitySales);
          return dtReadTcsList;
      }
      public DataTable ReadExpenseData(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadExpenseData(ObjEntitySales);
          return dtReadTcsList;
      }


      public DataTable ReadExpense_Data(clsEntitySales ObjEntitySales)
      {
          DataTable dtReadTcsList = objDataSales.ReadExpense_Data(ObjEntitySales);
          return dtReadTcsList;
      }

      //-------------------
      public void InsertExpenseDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesDetailList, List<clsEntitySales> ObjEntitySalesPrdtList)
      {
          objDataSales.InsertExpenseDetls(ObjEntitySales, ObjEntitySalesDetailList, ObjEntitySalesPrdtList);
      }
      public void UpdateExpenseDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesDetailList, List<clsEntitySales> ObjEntitySalesPrdtList, List<clsEntitySales> ObjEntitySalesDeleteList, List<clsEntitySales> ObjEntitySalesProductDeleteList)
      {
          objDataSales.UpdateExpenseDetls(ObjEntitySales, ObjEntitySalesDetailList, ObjEntitySalesPrdtList, ObjEntitySalesDeleteList, ObjEntitySalesProductDeleteList);
      }

      public void ReopenExpense(clsEntitySales ObjEntitySales)
      {
          objDataSales.ReopenExpense(ObjEntitySales);
      }







      public string PdfPrintVersion1(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy, int Version_flg)
      {
          string strRet = "true";

          int intCorpId = ObjEntitySales.Corporate_id;

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

          clsCommonLibrary objCommon = new clsCommonLibrary();
          int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
          string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);


        
          if (ObjEntitySales.Corporate_id != 0)
          {
              objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
          }
          if (ObjEntitySales.Organisation_id != 0)
          {
              objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
          }

          clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
          objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
          string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
          string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

          Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
          Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
          try
          {

              using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
              {
                  System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

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
                  float[] headersHeading = { 70, 30 };
                  headImg.SetWidths(headersHeading);
                  headImg.WidthPercentage = 100;

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

                  if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
                      headImg.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                  else
                      headImg.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                  document.Add(headImg);

                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                  PdfPTable footrtable = new PdfPTable(2);
                  float[] footrsBody = { 50, 50 };
                  footrtable.SetWidths(footrsBody);
                  footrtable.WidthPercentage = 100;

                  footrtable.AddCell(new PdfPCell(new Phrase("From", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtable.AddCell(new PdfPCell(new Phrase("For", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][0].ToString() != "")
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      else
                          footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CUSTOMER"].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  else
                  {
                      footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CUSTOMER"].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][4].ToString().Trim() != "")
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      }

                      else
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      }
                  }
                  else
                  {
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  document.Add(footrtable);

                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                  PdfPTable footrtables = new PdfPTable(2);
                  float[] footrsBodys = { 15, 85 };
                  footrtables.SetWidths(footrsBodys);
                  footrtables.WidthPercentage = 100;

                  footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  document.Add(footrtables);

                  var FontGrey = new BaseColor(134, 152, 160);
                  var FontBordrGrey = new BaseColor(236, 236, 236);

                  if (dtProduct.Rows.Count > 0)
                  {
                      string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
                      string strcurrenWord = "", strCrncyAbbrv = "";
                      if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
                      {
                          strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;
                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }
                      else
                      {
                          strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;
                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }

                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                      var FontRed = new BaseColor(202, 3, 20);
                      var FontGreen = new BaseColor(46, 179, 51);
                      var FontGray = new BaseColor(138, 138, 138);

                      if (TaxEnable == 1)
                      {
                          PdfPTable table2 = new PdfPTable(6);
                          float[] tableBody2 = { 34, 10, 14, 12, 15, 15 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";
                              string ProductTaxAmt = "";
                              string ProductTtlAmt = "";

                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
                              {
                                  ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
                                  ProductTaxAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;
                              }

                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          }
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                          table2.AddCell(new PdfPCell(new Phrase("Gross Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                          table2.AddCell(new PdfPCell(new Phrase("Tax Amount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                          table2.AddCell(new PdfPCell(new Phrase("Discount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                          table2.AddCell(new PdfPCell(new Phrase("Net Total   ", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                          document.Add(table2);
                      }
                      else
                      {
                          PdfPTable table2 = new PdfPTable(5);
                          float[] tableBody2 = { 38, 12, 12, 16, 22 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";

                              string ProductTtlAmt = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;
                              }

                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;
                              }

                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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

                      tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                      tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });
                      document.Add(tablettl);
                  }
                  if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
                  {
                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                      document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                      document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                  }

                  string CheckedBy = "";
                  if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
                  {
                      CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                  }

                  var FontColourPrprd = new BaseColor(33, 150, 243);
                  var FontColourChkd = new BaseColor(76, 175, 80);
                  var FontColourAuthrsd = new BaseColor(255, 87, 34);

                  float pos1 = writer.GetVerticalPosition(false);

                  PdfPTable table3 = new PdfPTable(3);
                  float[] tableBody3 = { 33, 33, 33 };
                  table3.SetWidths(tableBody3);
                  table3.WidthPercentage = 100;
                  table3.TotalWidth = 600F;

                  PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();

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
                  }
                  else
                  {
                      document.NewPage();
                      table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
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

      public string PdfPrintVersion2(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy, int Version_flg)
      {
          globfalg = Version_flg;
          string strRet = "true";
          int intCorpId = ObjEntitySales.Corporate_id;
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
          clsCommonLibrary objCommon = new clsCommonLibrary();
          int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
          string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
          if (ObjEntitySales.Corporate_id != 0)
          {
              objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
          }
          if (ObjEntitySales.Organisation_id != 0)
          {
              objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
          }
          clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
          objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
          string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
          string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

          DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);
          Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
          if (Version_flg == 2)
          {
              document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
          }
          globhead = Convert.ToInt32(dt.Rows[0]["SALES_CNFRM_STS"].ToString());
          Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
          try
          {
              using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
              {
                  System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));
                  FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                  PdfWriter writer = PdfWriter.GetInstance(document, file);
                  var FontBlue = new BaseColor(0, 174, 239);
                  var FontBlueGrey = new BaseColor(79, 167, 206);
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
                  }
                  PdfPTable footrtable = new PdfPTable(2);
                  float[] footrsBody = { 20, 80 };
                  footrtable.SetWidths(footrsBody);
                  footrtable.WidthPercentage = 100;

                  footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                  footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                  
                  Font myFont = FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK);
                  Font myNormalFont = FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK);

                  string line1 = "Invoice Reference#     :       ";
                  string line2 = dt.Rows[0]["SALES_REF"].ToString();
                  Paragraph p1 = new Paragraph();
                  Phrase ph1 = new Phrase(line1, myFont);
                  Phrase ph2 = new Phrase(line2, myNormalFont);
                  p1.Add(ph1);
                  p1.Add(ph2);
                  PdfPCell mycell = new PdfPCell(p1);
                  footrtable.AddCell(new PdfPCell(mycell) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
                  footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingTop = 10 });
                  footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][0].ToString() != "")
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      else
                          footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CUSTOMER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                  }

                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][4].ToString().Trim() != "")
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      }
                      else
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                          footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      }
                  }
                  else
                  {
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                  }
                  document.Add(footrtable);

                  var FontGrey = new BaseColor(134, 152, 160);
                  var FontBordrGrey = new BaseColor(236, 236, 236);

                  if (dtProduct.Rows.Count > 0)
                  {
                      string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
                      string strcurrenWord = "", strCrncyAbbrv = "";
                      if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
                      {
                          strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;

                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }
                      else
                      {
                          strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;

                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }
                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));

                      var FontRed = new BaseColor(202, 3, 20);
                      var FontGreen = new BaseColor(46, 179, 51);
                      var FontGray = new BaseColor(138, 138, 138);
                      var FontColour = new BaseColor(134, 152, 160);
                      var FontWhite = new BaseColor(255, 255, 255);

                      if (TaxEnable == 1)
                      {
                          PdfPTable table2 = new PdfPTable(8);
                          float[] tableBody2 = { 5, 23, 8, 12, 10, 9, 15, 18 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";
                              string ProductTaxAmt = "";
                              string ProductTtlAmt = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
                              {
                                  ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
                                  ProductTaxAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != null)
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;
                              }
                              string strRemark = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
                              {
                                  strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();
                                  if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_INVRMRK_STS"].ToString() == "1")
                                  {
                                      strRemark = "";
                                  }
                              }
                              int SlNo = intRowBodyCount + 1;

                              table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_DESC_STS"].ToString() == "1" && dtProduct.Rows[intRowBodyCount]["PRDT_DESCRIPTION"].ToString() != "")
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              else if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_INVRMRK_STS"].ToString() == "1" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              else
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          }
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });
                          table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                          table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                          table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                          table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthRight = 0 });
                          table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthLeft = 0 });
                          table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 7, });
                          table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
                          document.Add(table2);
                      }
                      else
                      {
                          PdfPTable table2 = new PdfPTable(7);
                          float[] tableBody2 = { 5, 29, 8, 12, 12, 14, 20 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";
                              string ProductTtlAmt = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;

                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;

                              }

                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;

                              }
                              string strRemark = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
                              {
                                  strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();
                                  if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_INVRMRK_STS"].ToString() == "1")
                                  {
                                      strRemark = "";
                                  }
                              }
                              int slNo = intRowBodyCount + 1;
                              table2.AddCell(new PdfPCell(new Phrase(slNo.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_DESC_STS"].ToString() == "1" && dtProduct.Rows[intRowBodyCount]["PRDT_DESCRIPTION"].ToString() != "")
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              else if (dtProduct.Rows[intRowBodyCount]["PRDCT_DISPLAY_NAME_INVRMRK_STS"].ToString() == "1" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              else
                              {
                                  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              }
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          }
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });
                          table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                          table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
                          table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                          table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 6, });
                          table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
                          document.Add(table2);
                      }
                      if (Version_flg == 2)
                      {
                          PdfPTable footrtables = new PdfPTable(2);
                          float[] footrsBodys = { 20, 80 };
                          footrtables.SetWidths(footrsBodys);
                          footrtables.WidthPercentage = 100;

                          footrtables.AddCell(new PdfPCell(new Phrase("Sale Order No.      :      ", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingTop = 10 });
                          footrtables.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingTop = 10 });
                          if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
                          {
                              footrtables.AddCell(new PdfPCell(new Phrase("Remarks               :      ", FontFactory.GetFont("Calibri", 8, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                              footrtables.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          }
                          document.Add(footrtables);

                          document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                          var phrase2 = new Phrase();
                          var phrase5 = new Phrase();
                          if (dtBankDtls.Rows.Count > 0)
                          {
                              phrase2.Add(new Chunk("Make all cheques payable to ", FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));

                              if (dtCorp.Rows.Count > 0)
                              {
                                  if (dtCorp.Rows[0][0].ToString() != "")
                                  {
                                      phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                      phrase5.Add(new Chunk(" Bank Details for ", FontFactory.GetFont("Calibri", 8, Font.UNDERLINE)));
                                      phrase5.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD | Font.UNDERLINE)));
                                      phrase5.Add(new Chunk("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  }
                              }
                              document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });
                              document.Add(new Paragraph(phrase5) { Alignment = Element.ALIGN_CENTER, });
                              var phrase4 = new Phrase();
                              var phrase6 = new Phrase();
                              var phrase7 = new Phrase();
                              var phrase9 = new Phrase();

                              if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
                              {
                                  phrase6.Add(new Chunk(" IBAN ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  phrase6.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                              }
                              if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
                              {
                                  phrase7.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                              }
                              if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
                              {
                                  phrase7.Add(new Chunk(" Bank ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                              }
                              if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
                              {
                                  phrase9.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  phrase9.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                              }
                              document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });
                              document.Add(new Paragraph(phrase6) { Alignment = Element.ALIGN_CENTER });
                              document.Add(new Paragraph(phrase7) { Alignment = Element.ALIGN_CENTER });
                              document.Add(new Paragraph(phrase9) { Alignment = Element.ALIGN_CENTER });
                          }
                      }

                  }

                  float pos1 = writer.GetVerticalPosition(false);

                  string CheckedBy = "";
                  if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
                  {
                      CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                  }
                  PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();

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
                  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
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

      //START EVM 040
      public string PdfPrintVersion4(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy, int Version_flg)
      {
          globfalg = Version_flg;
          string strRet = "true";

          int intCorpId = ObjEntitySales.Corporate_id;

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

          clsCommonLibrary objCommon = new clsCommonLibrary();
          int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
          string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);



          if (ObjEntitySales.Corporate_id != 0)
          {
              objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
          }
          if (ObjEntitySales.Organisation_id != 0)
          {
              objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
          }

          clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
          objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
          DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);
          string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
          string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

          Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
          Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
          try
          {

              using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
              {
                  System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

                  FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                  PdfWriter writer = PdfWriter.GetInstance(document, file);

                  writer.PageEvent = new PDFHeader();

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
                  //if (Version_flg == 4)
                  //{
                  //    writer.PageEvent = new PDFHeader();
                  //    document.Open();
                  //}
                  //else
                  //{
                  //    document.Open();
                  //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                  //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
                  //}
                  PdfPTable headImg = new PdfPTable(2);
                  float[] headersHeading = { 70, 30 };
                  headImg.SetWidths(headersHeading);
                  headImg.WidthPercentage = 100;

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

                  if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
                      headImg.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                  else
                      headImg.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
                  document.Add(headImg);

                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                  PdfPTable footrtable = new PdfPTable(2);
                  float[] footrsBody = { 50, 50 };
                  footrtable.SetWidths(footrsBody);
                  footrtable.WidthPercentage = 100;

                  footrtable.AddCell(new PdfPCell(new Phrase("From", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtable.AddCell(new PdfPCell(new Phrase("For", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][0].ToString() != "")
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      else
                          footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CUSTOMER"].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  else
                  {
                      footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CUSTOMER"].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  if (dtCust.Rows.Count > 0)
                  {
                      if (dtCust.Rows[0][4].ToString().Trim() != "")
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      }

                      else
                      {
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                          footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      }
                  }
                  else
                  {
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                      footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  }
                  document.Add(footrtable);

                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                  document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                  PdfPTable footrtables = new PdfPTable(2);
                  float[] footrsBodys = { 15, 85 };
                  footrtables.SetWidths(footrsBodys);
                  footrtables.WidthPercentage = 100;

                  footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase("Guest Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                  footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_GUEST_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                  document.Add(footrtables);

                  var FontGrey = new BaseColor(134, 152, 160);
                  var FontBordrGrey = new BaseColor(236, 236, 236);

                  if (dtProduct.Rows.Count > 0)
                  {
                      string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
                      string strcurrenWord = "", strCrncyAbbrv = "";
                      if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
                      {
                          strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;
                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }
                      else
                      {
                          strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                          if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                          {
                              grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
                              grossTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                          {
                              taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
                              taxTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                          {
                              discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
                              discTotal = strNetAmountDebitComma;
                          }
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                              string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
                              netTotal = strNetAmountDebitComma;
                          }
                          objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());
                          if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                          {
                              clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                              strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                          }
                      }

                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                      var FontRed = new BaseColor(202, 3, 20);
                      var FontGreen = new BaseColor(46, 179, 51);
                      var FontGray = new BaseColor(138, 138, 138);

                      if (TaxEnable == 1)
                      {
                          PdfPTable table2 = new PdfPTable(6);
                          float[] tableBody2 = { 34, 10, 14, 12, 15, 15 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT/SERVICE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";
                              string ProductTaxAmt = "";
                              string ProductTtlAmt = "";

                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
                              {
                                  ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
                                  ProductTaxAmt = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;
                              }

                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          }
                          table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
                          table2.AddCell(new PdfPCell(new Phrase("Gross Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                          table2.AddCell(new PdfPCell(new Phrase("Tax Amount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                          table2.AddCell(new PdfPCell(new Phrase("Discount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
                          table2.AddCell(new PdfPCell(new Phrase("Net Total   ", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
                          table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                          document.Add(table2);
                      }
                      else
                      {
                          PdfPTable table2 = new PdfPTable(5);
                          float[] tableBody2 = { 38, 12, 12, 16, 22 };
                          table2.SetWidths(tableBody2);
                          table2.WidthPercentage = 100;
                          table2.HeaderRows = 1;//get header column in all pages

                          table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                          table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                          for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
                          {
                              string ProductPrice = "";
                              string ProductDisAmt = "";

                              string ProductTtlAmt = "";
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
                              {
                                  ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
                                  ProductPrice = strNetAmountDebitComma;
                              }
                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
                              {
                                  ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
                                  ProductDisAmt = strNetAmountDebitComma;
                              }

                              if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
                              {
                                  ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
                                  string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
                                  ProductTtlAmt = strNetAmountDebitComma;
                              }

                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                              table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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

                      tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                      tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });
                      document.Add(tablettl);

                      var phrase2 = new Phrase();
                      var phrase5 = new Phrase();
                      if (dtBankDtls.Rows.Count > 0)
                      {
                          phrase2.Add(new Chunk("Make all cheques payable to ", FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));

                          if (dtCorp.Rows.Count > 0)
                          {
                              if (dtCorp.Rows[0][0].ToString() != "")
                              {
                                  phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                                  phrase5.Add(new Chunk(" Bank Details for ", FontFactory.GetFont("Calibri", 8, Font.UNDERLINE)));
                                  phrase5.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD | Font.UNDERLINE)));
                                  phrase5.Add(new Chunk("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              }
                          }
                          document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });
                          document.Add(new Paragraph(phrase5) { Alignment = Element.ALIGN_CENTER, });
                          var phrase4 = new Phrase();
                          var phrase6 = new Phrase();
                          var phrase7 = new Phrase();
                          var phrase9 = new Phrase();
                          var phrase8 = new Phrase();



                          if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
                          {
                              phrase6.Add(new Chunk(" IBAN ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              phrase6.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                          }
                          if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
                          {
                              phrase7.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                          }
                          if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
                          {
                              phrase7.Add(new Chunk(" Bank ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                          }
                          if (dtBankDtls.Rows[0]["BANK_ADDRESS"].ToString().Trim() != "")
                          {
                              phrase8.Add(new Chunk(" ADDRESS ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              phrase8.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ADDRESS"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                          }
                          if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
                          {
                              phrase9.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK)));
                              phrase9.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Calibri", 8, BaseColor.BLACK)));
                          }
                          document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });
                          document.Add(new Paragraph(phrase6) { Alignment = Element.ALIGN_CENTER });
                          document.Add(new Paragraph(phrase7) { Alignment = Element.ALIGN_CENTER });
                          document.Add(new Paragraph(phrase8) { Alignment = Element.ALIGN_CENTER });

                          document.Add(new Paragraph(phrase9) { Alignment = Element.ALIGN_CENTER });
                      }

                  }
                  if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
                  {
                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                      document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                      document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                      document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                  }

                  string CheckedBy = "";
                  if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
                  {
                      CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                  }

                  var FontColourPrprd = new BaseColor(33, 150, 243);
                  var FontColourChkd = new BaseColor(76, 175, 80);
                  var FontColourAuthrsd = new BaseColor(255, 87, 34);

                  float pos1 = writer.GetVerticalPosition(false);

                  PdfPTable table3 = new PdfPTable(3);
                  float[] tableBody3 = { 33, 33, 33 };
                  table3.SetWidths(tableBody3);
                  table3.WidthPercentage = 100;
                  table3.TotalWidth = 600F;

                  PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();

                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                  table3.AddCell(new PdfPCell(new Phrase("*****************************************************************************************", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                  table3.AddCell(new PdfPCell(new Phrase("Please note that all foreign bank transfer charges have to be paid by the sender ", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                  table3.AddCell(new PdfPCell(new Phrase("and not be deducted from the invoice amount ", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                  table3.AddCell(new PdfPCell(new Phrase("*****************************************************************************************", FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                  table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });


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
      //END 040

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
              if (globfalg != 4)
              {
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
                      headtable.AddCell(new PdfPCell(new Phrase("SALES INVOICE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                  }
                  else
                  {
                      headtable.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
