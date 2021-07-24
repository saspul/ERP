using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:01/04/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerQuotation
    {

        //Creating objects for datalayer
        clsDataLayerQuotation objDataLayerQuotation = new clsDataLayerQuotation();

        // This Method will fetch Products For Drop Down
        public DataTable ReadProducts(int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadProducts(intListMode, objEntityQuotation);
            return dtReadProduct;
        }
        // This Method will fetch Product  For autocompletion from WebService
        public DataTable ReadProductsWebService(string strProductLikeName, int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadProductsWebService(strProductLikeName,intListMode, objEntityQuotation);
            return dtReadProduct;
        }
        // This Method will fetch Tax For Drop Down
        public DataTable ReadTax(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadTax = objDataLayerQuotation.ReadTax( objEntityQuotation);
            return dtReadTax;
        }
        // This Method will fetch Units For Drop Down
        public DataTable ReadUnit(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadUnit = objDataLayerQuotation.ReadUnit( objEntityQuotation);
            return dtReadUnit;
        }
        // This Method FETCHES PRODUCT DETAILS BASED ON PRODUCT SELECTED IN ENTRY VIA WEB SERVICE
        public DataTable ReadSelctdPrdctDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadPrdctDtl = objDataLayerQuotation.ReadSelctdPrdctDtl(objEntityQuotation);
            return dtReadPrdctDtl;
        }
        // This Method FETCHES TAX DETAILS BASED ON TAX SELECTED IN ENTRY VIA WEB SERVICE
        public DataTable ReadSelctdTaxDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadTaxDtl = objDataLayerQuotation.ReadSelctdTaxDtl(objEntityQuotation);
            return dtReadTaxDtl;
        }
        // This Method FETCHES LEAD DETAILS BASED ON LEAD ID FOR DISPALYING LEAD DETAILS
        public DataTable ReadLeadDtlForDisplay(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadLeadDtl = objDataLayerQuotation.ReadLeadDtlForDisplay(objEntityQuotation);
            return dtReadLeadDtl;
        }

        //Add Quotation Details
        public void InsertQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationDetails, List<clsEntityLayerQuotationDtl> objEntityQuotatiDtlGrp, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDetails)
        {
            objDataLayerQuotation.InsertQuotation(objEntityQuotation, objEntityQuotationDetails,objEntityQuotatiDtlGrp, objEntityQuotationAttchmntDetails);

        }
        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOTATION TABLE
        public DataTable ReadQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtn = objDataLayerQuotation.ReadQuotation(objEntityQuotation);
            return dtReadQtn;
        }
        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOT_DTLS TABLE
        public DataTable ReadQuotationDetail(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnDtl = objDataLayerQuotation.ReadQuotationDetail(objEntityQuotation);
            return dtReadQtnDtl;
        }
        // This Method FETCHES QUOTATION ATTACHMENTS BASED ON QUOTATION ID FROM GN_QOTN_ATTACHMENTS
        public DataTable ReadQuotationAttchmnt(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadQuotationAttchmnt(objEntityQuotation);
            return dtReadQtnAttchmnt;
        }
        //Update Quotation Details
        public void UpdateQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            objDataLayerQuotation.UpdateQuotation(objEntityQuotation, objEntityQuotationInsertDetails, objEntityQuotationUpdateDetails, strarrCancldtlIds,objEntityQuotationDetailsGrp,objEntityQuotationDetailsGrpUpd,strarrCancldtlGrpIds, objEntityQuotationAttchmntINSERTDetails, objEntityQuotationAttchmntDELETEDetails);

        }
        //Confirm Quotation Details
        public void ConfirmQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            objDataLayerQuotation.ConfirmQuotation(objEntityQuotation, objEntityQuotationInsertDetails, objEntityQuotationUpdateDetails, strarrCancldtlIds, objEntityQuotationDetailsGrp, objEntityQuotationDetailsGrpUpd, strarrCancldtlGrpIds, objEntityQuotationAttchmntINSERTDetails, objEntityQuotationAttchmntDELETEDetails);

        }
        // This Method FETCHES CUSTOMER DETAILS BASED ON LEAD ID FROM GN_LEADS TABLE FOR SHOWING IN PDF
        public DataTable ReadCstmrDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl= objDataLayerQuotation.ReadCstmrDtlForPDF(objEntityQuotation);
            return dtReadDtl;
        }
        // This Method FETCHES CORP DETAILS BASED ON CORP ID FROM GN_CORP_OFFICES TABLE FOR SHOWING IN PDF
        public DataTable ReadCorpDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadCorpDtlForPDF(objEntityQuotation);
            return dtReadDtl;
        }
        //Approve Quotation Details
        public void ApproveQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            objDataLayerQuotation.ApproveQuotation(objEntityQuotation, objEntityQuotationInsertDetails, objEntityQuotationUpdateDetails, strarrCancldtlIds, objEntityQuotationDetailsGrp, objEntityQuotationDetailsGrpUpd, strarrCancldtlGrpIds, objEntityQuotationAttchmntINSERTDetails, objEntityQuotationAttchmntDELETEDetails);

        }
        // This Method change quotation status to Return
        public void ReturnQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            objDataLayerQuotation.ReturnQuotation(objEntityQuotation);

        }
        // This Method change quotation status to ReOpen
        public void ReOpenQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            objDataLayerQuotation.ReOpenQuotation(objEntityQuotation);

        }
        // This Method change quotation status to Delivered
        public void DeliverQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            objDataLayerQuotation.DeliverQuotation(objEntityQuotation);

        }
        // This Method  is for fetching CORPORATE MAIL MESSAGE BASED ON CORP TEMPLATE TYP ID AND CORP ID 
        public DataTable ReadCorpMailContent(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadMsg = objDataLayerQuotation.ReadCorpMailContent(objEntityCommon);
            return dtReadMsg;
        }
        // This Method change quotation status to Delivered
        public void ReSendMailQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            objDataLayerQuotation.ReSendMailQuotation(objEntityQuotation);

        }
        // This Method  is for fetching CORPORATE MAIL MESSAGE BASED ON CORP TEMPLATE TYP ID AND CORP ID 
        public DataTable ReadActvUsrDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadActvUsrDtlForPDF(objEntityQuotation);
            return dtReadDtl;
        }
        // This Method FETCHES TEAM HEAD  DTL AND DIVISION NAME OF THE LEAD FOR DISPLAYING IN THE PDF DOCUMENT  BASED ON LEAD ID  FOR SHOWING IN PDF
        public DataTable ReadTeamHeadDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadTeamHeadDtlForPDF(objEntityQuotation);
            return dtReadDtl;
        }
        // THIS Method FETCHES TERMS BASED ON CORPORATE AND ORGANIZATION AND QUOTATION TEMPLATE ID
        public DataTable ReadTermTemplate(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadTermTemplate(objEntityQuotation);
            return dtReadDtl;
        }
        // THIS Method FETCHES TERM DESCRIPTION BASED ON CORPORATE AND ORGANIZATION AND TERM TEMPLATE ID
        public DataTable ReadSelectedTermDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadSelectedTermDtl(objEntityQuotation);
            return dtReadDtl;
        }
        // THIS Method FETCHES MONTH AND YEAR OF QTN DATE IF QTN_ID IS NOT ZERO OR FETCH CURRENT MNTH AND YEAR
        public DataTable ReadMnthYearForRefNum(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadMnthYearForRefNum(objEntityQuotation);
            return dtReadDtl;
        }
        // This Method will fetch Reopen Reason For Drop Down
        public DataTable ReadReopenReasonMstr(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReopenRsn = objDataLayerQuotation.ReadReopenReasonMstr(objEntityQuotation);
            return dtReopenRsn;
        }

        // This Method FETCHES PROJECT DTL FOR DISPLAYING IN THE PDF DOCUMENT  BASED ON LEAD ID  FOR SHOWING IN PDF
        public DataTable ReadProjectDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadProjectDtlForPDF(objEntityQuotation);
            return dtReadDtl;
        }
        //This method will fetch the availability sts of the product
        public DataTable ReadAvailbltyStsload(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadDtl = objDataLayerQuotation.ReadAvailbltyStsload(objEntityQuotation);
            return dtReadDtl;
        }
        //evm 0019
        public void Add_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            objDataLayerQuotation.Add_Adtnl_Mail(objentityAdtnl);
        }
        public DataTable Read_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            DataTable dtReadCategory = objDataLayerQuotation.Read_Adtnl_Mail(objentityAdtnl);
            return dtReadCategory;
        }
        public void Delete_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            objDataLayerQuotation.Delete_Adtnl_Mail(objentityAdtnl);
        }
        public void Update_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            objDataLayerQuotation.Update_Adtnl_Mail(objentityAdtnl);
        }
        public DataTable ReadQuotationByTemplateId(clsEntityLayerQuotation objentityAdtnl)
        {
            DataTable dtReadCategory = objDataLayerQuotation.ReadQuotationByTemplateId(objentityAdtnl);
            return dtReadCategory;
        }
        //Start:-EMP-0009
        //For adding to backup table
        public void AddQuotationBckup(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQtnGrpDtlsList, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails)
        {
            objDataLayerQuotation.AddQuotationBckup(objEntityQuotation,objEntityQtnGrpDtlsList, objEntityQuotationInsertDetails, objEntityQuotationAttchmntINSERTDetails);

        }
        //For read revised quatation list
        public DataTable ReadRvsdQuotation(clsEntityLayerQuotation objentityAdtnl)
        {
            DataTable dtReadCategory = objDataLayerQuotation.ReadRvsdQuotation(objentityAdtnl);
            return dtReadCategory;
        }
        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOTATION BACKUP TABLE
        public DataTable ReadQuotationBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtn = objDataLayerQuotation.ReadQuotationBckup(objEntityQuotation);
            return dtReadQtn;
        }
        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOT_DTLS BACKUP TABLE
        public DataTable ReadQuotationDetailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnDtl = objDataLayerQuotation.ReadQuotationDetailBckup(objEntityQuotation);
            return dtReadQtnDtl;
        }
        // This Method FETCHES QUOTATION ATTACHMENTS BASED ON QUOTATION ID FROM GN_QOTN_ATTACHMENTS BACKUP TABLE
        public DataTable ReadQuotationAttchmntBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadQuotationAttchmntBckup(objEntityQuotation);
            return dtReadQtnAttchmnt;
        }
        //For adding from backup table to make it final
        public void InsertQuotationFrmBckup(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQtnGrpDtlsList, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails)
        {
            objDataLayerQuotation.InsertQuotationFrmBckup(objEntityQuotation,objEntityQtnGrpDtlsList, objEntityQuotationInsertDetails, objEntityQuotationAttchmntINSERTDetails);

        }
        //Currency Selection
        public DataTable ReadCurrencyLoad(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnDtl = objDataLayerQuotation.ReadCurrencyLoad(objEntityQuotation);
            return dtReadQtnDtl;
        }
        //End:-EMP-0009
        //For  Search by cuistomer
        public DataTable ReadQuotationByTemplateIdBysearch(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadQuotationByTemplateIdBysearch(objEntityQuotation);
            return dtReadQtnAttchmnt;


        }
        public DataTable ReadCutomerList(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadCutomerList(objEntityQuotation);
            return dtReadQtnAttchmnt;


        }
        //QCLD4 EVM0012
        public void InsertQuotationMailBackup(clsEntityLayerQuotation objEntityQuotation, clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList,clsEntityLayerQuotation InsertQuotationMailBackup)
        {
            objDataLayerQuotation.InsertQuotationMailBackup(objEntityQuotation, objEntityMail, objEntityMailAttachList, InsertQuotationMailBackup);
        }
        public DataTable ReadQuotationMailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadQuotationMailBckup(objEntityQuotation);
            return dtReadQtnAttchmnt;
        }
        public DataTable ReadQuotationMailAttachmntBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadQtnAttchmnt = objDataLayerQuotation.ReadQuotationMailAttachmntBckup(objEntityQuotation);
            return dtReadQtnAttchmnt;
        }
        public void ChangeAttachStatus(clsEntityLayerQuotation objEntityQuotation, string[] strStsAttchIds)
        {
            objDataLayerQuotation.ChangeAttachStatus(objEntityQuotation, strStsAttchIds);
        }

        // This Method will fetch Product  For autocompletion from WebService
        public DataTable ReadProductcatgryWebService(string strProductLikeName, int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadProductsWebService(strProductLikeName, intListMode, objEntityQuotation);
            return dtReadProduct;
        }

        public DataTable ReadQuotationGrpDetailByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadQuotationGrpDetailByQtnId(objEntityQuotation);
            return dtReadProduct;
        }
        public DataTable ReadQuotationCatDetailByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadQuotationCatDetailByQtnId(objEntityQuotation);
            return dtReadProduct;
        }

        public DataTable ReadQuotationGrpDetailBckupByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadQuotationGrpDetailBckupByQtnId(objEntityQuotation);
            return dtReadProduct;
        }
        public DataTable ReadQuotationCatDetailBckupByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadQuotationCatDetailBckupByQtnId(objEntityQuotation);
            return dtReadProduct;
        }
         public DataTable ReadQuotationAddtnMailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            DataTable dtReadProduct = objDataLayerQuotation.ReadQuotationAddtnMailBckup(objEntityQuotation);
            return dtReadProduct;
        }


         public void ConfirmQuotationList(clsEntityLayerQuotation objEntityQuotation)
         {
             objDataLayerQuotation.ConfirmQuotationList(objEntityQuotation);

         }
    }
}
