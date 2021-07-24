using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;

// CREATED BY:EVM-0001
// CREATED DATE:24/02/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinesslayerCorporateOffice
    {
        //Creating objects for datalayer.
        clsDataLayerCorporateoffice objDataLayerCorpOffice = new clsDataLayerCorporateoffice();
        public DataTable ReadCorpType()
        {
            DataTable dtReadCorp = objDataLayerCorpOffice.ReadCorporateType();
            return dtReadCorp;
        }
        public DataTable ReadBsnsType()
        {
            DataTable dtReadCorp = objDataLayerCorpOffice.ReadBsnsType();
            return dtReadCorp;
        }
        public DataTable ReadShareType()
        {
            DataTable dtReadCorp = objDataLayerCorpOffice.ReadShareType();
            return dtReadCorp;
        }
        public DataTable ReadParentUnit(clsEntityCorpOffice objEntityCorp)
        {
            DataTable dtReadCorp = objDataLayerCorpOffice.ReadParentUnit(objEntityCorp);
            return dtReadCorp;
        }
        //Method for passing country table from datalayer to uilayer.
        public DataTable ReadCountry()
        {
            DataTable dtReadCountry = objDataLayerCorpOffice.ReadCountry();
            return dtReadCountry;
        }
        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityCorpOffice objEntityCorp)
        {
            DataTable dtReadnextId = objDataLayerCorpOffice.ReadNextId(objEntityCorp);
            return dtReadnextId;
        }
        //Method for passing state details in between the datalayer and ui layer.
        public DataTable ReadState(clsEntityCorpOffice objEntityCorp)
        {
            DataTable dtReadState = objDataLayerCorpOffice.ReadState(objEntityCorp);
            return dtReadState;
        }
        //Method for passing city details in between the datalayer and ui layer.
        public DataTable ReadCity(clsEntityCorpOffice objEntityCorp)
        {
            DataTable dtReadCity = objDataLayerCorpOffice.ReadCity(objEntityCorp);
            return dtReadCity;
        }
        //Method for passing the details about newly registering corporate office from ui layer to datalayer.
        public void InsertCorpOffice(clsEntityCorpOffice ObjEntitycorpOffice, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityCorpPartners> objEntityTrficVioltnDetilsList,List<clsEntityBankDtl> objEntityDetilsListBank)
        {
            objDataLayerCorpOffice.InsertCorpOffice(ObjEntitycorpOffice, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityTrficVioltnDetilsList, objEntityDetilsListBank);
        }
        //Method to passing the count of corporate office name in table
        public string CheckCorpOffice(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckCorpOffice(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method for passing corporate office table from data layer to ui layer.
        public DataTable ReadCorpOffice(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOffice = objDataLayerCorpOffice.ReadCorporateOffice(ObjEntitycorpOffice);
            return dtCorpOffice;
        }
        //Method for passing new status details from ui layer to datalayer for updation
        public void UpdateStatus(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            //if status is active then set in active if status is inactive then set active.
            if (ObjEntitycorpOffice.CorpStatus == 1)
            {
                ObjEntitycorpOffice.CorpStatus=0;
            }
            else
            {
                ObjEntitycorpOffice.CorpStatus = 1;
            }
            objDataLayerCorpOffice.UpdateCorpStatus(ObjEntitycorpOffice);
        }
        //Method for cancel corporate office, data passed from ui layer to data layer.
        public void CancelCorpOffice(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            objDataLayerCorpOffice.CancelCorpOffice(ObjEntitycorpOffice);
        }
        //Method for passing corporate office table by their id from data layer to ui layer.
        public DataTable ReadCorpOfficeById(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadCorporateOfficeById(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        //Method for passing the values to the datalayer for update corpoffice master table
        public void UpdateCorpOffice(clsEntityCorpOffice ObjEntitycorpOffice, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclDeleteAttchmntDeatilsList, List<clsEntityCorpPartners> objEntityTVDeatilsINSERTList, List<clsEntityCorpPartners> objEntityTVDeatilsUPDATEList, string[] strarrCanccldtlIds, List<clsEntityBankDtl> objEntityDetilsListBank)
        {
            objDataLayerCorpOffice.UpdateCorpOffice(ObjEntitycorpOffice, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerDeleteAttchmntDeatilsList, objEntityInsDeleteAttchmntDeatilsList, objEntityVhclDeleteAttchmntDeatilsList, objEntityTVDeatilsINSERTList, objEntityTVDeatilsUPDATEList, strarrCanccldtlIds, objEntityDetilsListBank);
        }
        //Method for passing the corporate office name and id to the datalayer for checking corporate office uniqueness
        public string CheckCorpNameUpdate(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckCorpOfficeUpdate(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method for passing count how many offices registered yet by current org
        public string CheckCorpOfficeCount(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strOfficeCheck = objDataLayerCorpOffice.CheckCorpOfficeCount(ObjEntitycorpOffice);
            return strOfficeCheck;
        }
        //Method of passing count of how many offices allowed to this organisation
        public string CorpOfficeCount(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strOfficeCount = objDataLayerCorpOffice.CorpOfficeCount(ObjEntitycorpOffice);
            return strOfficeCount;
        }
        //new code
        public DataTable ReadTINFiles(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadTINFiles(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        public DataTable ReadCRNFiles(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadCRNFiles(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        public DataTable ReadCCNFiles(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadCCNFiles(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        //Method to passing the count of CRN number in table
        public string CheckCRNnum(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckCRNnum(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method to passing the count of CRN number in table
        public string CheckTINnum(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckTINnum(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method to passing the count of CRN number in table
        public string CheckCCNnum(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckCCNnum(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method to passing the count of  code in table
        public string CheckCodenum(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            string strReturn = objDataLayerCorpOffice.CheckCodenum(ObjEntitycorpOffice);
            return strReturn;
        }
        //Method for reading organisation details
        public DataTable OrgDetails(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.OrgDetails(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        //Method for reading partnership details
        public DataTable ReadPartnerDetails(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadPartnerDetails(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        //new code
        // This Method will fetch Employee  For autocompletion from WebService
        public DataTable ReadPartnerWebService(string strLikePartner, clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtReadEmployee = objDataLayerCorpOffice.ReadPartnerWebService(strLikePartner, ObjEntitycorpOffice);
            return dtReadEmployee;
        }
        public DataTable ReadCorpSts(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtReadEmployee = objDataLayerCorpOffice.ReadCorpSts(ObjEntitycorpOffice);
            return dtReadEmployee;
        }
        //Method for reading bank details
        public DataTable ReadBankDtls(clsEntityCorpOffice objEntityCorp)
        {
            DataTable dtReadState = objDataLayerCorpOffice.ReadBankDtls(objEntityCorp);
            return dtReadState;
        }
        public DataTable ReadBankDtlsOfCorp(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.ReadBankDtlsOfCorp(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }
        public DataTable checkIbanDup(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtCorpOfficeById = objDataLayerCorpOffice.checkIbanDup(ObjEntitycorpOffice);
            return dtCorpOfficeById;
        }

        //EVM 24

        // Read Parters
        public DataTable ReadPartners()
        {
            DataTable dtReadEmployee = objDataLayerCorpOffice.ReadPartners();
            return dtReadEmployee;
        }
        // Read Document number of each partners
        public DataTable ReadPartnersDoc(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtReadEmployee = objDataLayerCorpOffice.ReadPartnersDoc(ObjEntitycorpOffice);
            return dtReadEmployee;
        }
        // Read Org attachment details
        public DataTable OrgCrCard(clsEntityCorpOffice ObjEntitycorpOffice)
        {
            DataTable dtOrgDetal = objDataLayerCorpOffice.OrgCrCard(ObjEntitycorpOffice);
            return dtOrgDetal;
        }


    }
}
