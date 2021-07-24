using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:24/02/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerCorporateoffice
    {
       
        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "CORPORATE_OFFICE.SP_READ_COUNTRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Methode for fetch state master details of selected country from database.
        public DataTable ReadState(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_READ_STATE";
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryReadState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityCorpOffice.CountryId;
                cmdReadState.Parameters.Add("S_SEARCH", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cancel_Reason;
                cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadState = new DataTable();
                dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                return dtReadState;
            }
        }

        //Method for fetch city master details of selected state from datatbase.
        public DataTable ReadCity(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_READ_CITY";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCorpOffice.StateId;
                cmdReadCity.Parameters.Add("C_SEARCH", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cancel_Reason;
                cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }

        //Method for fetch Corporate type table from database.
        public DataTable ReadCorporateType()
        {
            string strQueryReadCorporate = "CORPORATE_OFFICE.SP_READ_CORPORATE_TYPE";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporate;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_CORPTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpType;
            }
        }

        //Method for fetch Business type table from database.
        public DataTable ReadBsnsType()
        {
            string strQueryReadCorporate = "CORPORATE_OFFICE.SP_READ_BSNS_TYPE";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporate;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_CORPTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpType;
            }
        }
        //Method for fetch Share type table from database.
        public DataTable ReadShareType()
        {
            string strQueryReadCorporate = "CORPORATE_OFFICE.SP_READ_SHARE_TYPE";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporate;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_CORPTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpType;
            }
        }
        //Method for fetch Parent unit details from database.
        public DataTable ReadParentUnit(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadCorporate = "CORPORATE_OFFICE.SP_READ_PARENTUNT";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporate;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdReadCorporate.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCorporate.Parameters.Add("C_CORPTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpType;
            }
        }

        //Method for fetch next value from databse of current next id.
        public DataTable ReadNextId(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEntityCorpOffice.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }

        //Method for checking corporate office name already existed or not
        public string CheckCorpOffice(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorp = "CORPORATE_OFFICE.SP_CHECK_CORPOFFICE_NAME";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Corporation_Name;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //commented code may use later

        //procedure for fetch tax enable or not for the corp office
        //public string ReadTaxEnable(clsEntityCorpOffice objEntityCorpOffice)
        //{

        //    string strQueryTaxEnable = "CORPORATE_OFFICE.SP_READ_TAX_ENABLE";
        //    OracleCommand cmdTaxEnable = new OracleCommand();
        //    cmdTaxEnable.CommandText = strQueryTaxEnable;
        //    cmdTaxEnable.CommandType = CommandType.StoredProcedure;
        //    cmdTaxEnable.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
        //    cmdTaxEnable.Parameters.Add("C_TAXOUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
        //    clsDataLayer.ExecuteScalar(ref cmdTaxEnable);
        //    string strReturn = cmdTaxEnable.Parameters["C_TAXOUT"].Value.ToString();
        //    cmdTaxEnable.Dispose();
        //    return strReturn;
        //}

        //EVM-0016
        //Methode of inserting values to corporate office master table.
        public void InsertCorpOffice(clsEntityCorpOffice objEntityCorpOffice, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityCorpPartners> objEntityTrficVioltnDetilsList,List<clsEntityBankDtl> objEntityDetilsListBank)
        {
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                    {
            string strQueryInsertCorpOffice = "CORPORATE_OFFICE.SP_CORP_OFFICES";
            using (OracleCommand cmdInsertCorpOffice = new OracleCommand(strQueryInsertCorpOffice,con))
            {
                cmdInsertCorpOffice.CommandText = strQueryInsertCorpOffice;
                cmdInsertCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdInsertCorpOffice.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                cmdInsertCorpOffice.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdInsertCorpOffice.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Corporation_Name;
                cmdInsertCorpOffice.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address1;
                cmdInsertCorpOffice.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address2;
                cmdInsertCorpOffice.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address3;
                cmdInsertCorpOffice.Parameters.Add("C_CNTRYID", OracleDbType.Int32).Value = objEntityCorpOffice.CountryId;
                cmdInsertCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityCorpOffice.StateId;
                cmdInsertCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCorpOffice.CityId;
                cmdInsertCorpOffice.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityCorpOffice.ZipCode;
                cmdInsertCorpOffice.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Phone_Number;
                cmdInsertCorpOffice.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Mobile_Number;
                cmdInsertCorpOffice.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Web_Address;
                cmdInsertCorpOffice.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.Email_Address;
                cmdInsertCorpOffice.Parameters.Add("C_FISCALMNTH", OracleDbType.Int32).Value = objEntityCorpOffice.FiscalMonth;
                cmdInsertCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCorpOffice.ApplicationDate;
                cmdInsertCorpOffice.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCorpOffice.CorpStatus;
                cmdInsertCorpOffice.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCorpOffice.UserId;
                cmdInsertCorpOffice.Parameters.Add("C_CORTYPE_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpTypeId;
                cmdInsertCorpOffice.Parameters.Add("C_CORPTIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.TIN_Number;
                cmdInsertCorpOffice.Parameters.Add("C_CORPCUSTNUMBER", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cust_Care_Number;
                cmdInsertCorpOffice.Parameters.Add("C_CORPSHORTNAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Short_Name;
                cmdInsertCorpOffice.Parameters.Add("C_CORPSHORTADD", OracleDbType.Varchar2).Value = objEntityCorpOffice.Short_Address;
                cmdInsertCorpOffice.Parameters.Add("C_CORPCIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cin_Number;
                //START NEW CODE
                cmdInsertCorpOffice.Parameters.Add("C_BSNSTYPEID", OracleDbType.Int32).Value = objEntityCorpOffice.BsnsTypeId;
                cmdInsertCorpOffice.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Code;
                if (objEntityCorpOffice.ShareTypeId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_SHARETYPEID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_SHARETYPEID", OracleDbType.Int32).Value = objEntityCorpOffice.ShareTypeId;
                }
                cmdInsertCorpOffice.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntityCorpOffice.Fax;
                cmdInsertCorpOffice.Parameters.Add("C_ENQMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.EnqMail;
                cmdInsertCorpOffice.Parameters.Add("C_STRGMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.StorageMail;
                cmdInsertCorpOffice.Parameters.Add("C_RMVMAIL", OracleDbType.Int32).Value = objEntityCorpOffice.RemoveStrg;
                if (objEntityCorpOffice.ParentTypId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_PARNTID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_PARNTID", OracleDbType.Int32).Value = objEntityCorpOffice.ParentTypId;
                }
                cmdInsertCorpOffice.Parameters.Add("C_CMPSHREPER", OracleDbType.Int32).Value = objEntityCorpOffice.CmpnySharePer;
                cmdInsertCorpOffice.Parameters.Add("C_CRN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CRNnum;
                cmdInsertCorpOffice.Parameters.Add("C_CRNEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.CRNexpDate;
             

                cmdInsertCorpOffice.Parameters.Add("C_CRNISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.CRNissDate;
                cmdInsertCorpOffice.Parameters.Add("C_TIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.TINnum;
                cmdInsertCorpOffice.Parameters.Add("C_TINEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.TINexpDate;
                cmdInsertCorpOffice.Parameters.Add("C_TINISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.TINissDate;
                cmdInsertCorpOffice.Parameters.Add("C_CCN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CCNnum;
                cmdInsertCorpOffice.Parameters.Add("C_CCNEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.CCNexpDate;
                cmdInsertCorpOffice.Parameters.Add("C_CCNISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.CCNissDate;
                cmdInsertCorpOffice.Parameters.Add("C_ICON", OracleDbType.Varchar2).Value = objEntityCorpOffice.Icon;
                cmdInsertCorpOffice.Parameters.Add("C_ACTICON", OracleDbType.Varchar2).Value = objEntityCorpOffice.ActIcon;
                //END NEW CODE
                //EVM-0024
                cmdInsertCorpOffice.Parameters.Add("C_CHKIN", OracleDbType.Date).Value = objEntityCorpOffice.CheckIn;
                cmdInsertCorpOffice.Parameters.Add("C_CHKOUT", OracleDbType.Date).Value = objEntityCorpOffice.CheckOut;
                //end
                cmdInsertCorpOffice.ExecuteNonQuery();
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPermitAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_CRN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 1;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsurAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_TIN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 2;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_CCN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 3;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityCorpPartners objAttchDetail in objEntityTrficVioltnDetilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_PARTNER_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PRTNR_ID", OracleDbType.Int32).Value = objAttchDetail.PartnerId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_DOCNUM", OracleDbType.Varchar2).Value = objAttchDetail.DocumentNo;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PER", OracleDbType.Decimal).Value = objAttchDetail.SharePerc;

                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityBankDtl objAttchDetail in objEntityDetilsListBank)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_INS_BANK_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.NextValue;
                    cmdInsertAtcmntDtls.Parameters.Add("P_BANKID", OracleDbType.Int32).Value = objAttchDetail.BankId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_BRANCH", OracleDbType.Varchar2).Value = objAttchDetail.Branch;
                    cmdInsertAtcmntDtls.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = objAttchDetail.IBAN;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            tran.Commit();
                    }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
        }
        //EVM-0016
        //Procedure for read corporate office.
        public DataTable ReadCorporateOffice(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadCorporateOffice = "CORPORATE_OFFICE.SP_READ_CORP_OFFICE";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporateOffice;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdReadCorporate.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCorpOffice.CorpStatus;
                cmdReadCorporate.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCorpOffice.Cancel_Status;
                cmdReadCorporate.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityCorpOffice.CommonSearchTerm;
                cmdReadCorporate.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.SearchName;
                cmdReadCorporate.Parameters.Add("M_SEARCH_ADDRESS", OracleDbType.Varchar2).Value = objEntityCorpOffice.SearchAddress;
                cmdReadCorporate.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityCorpOffice.OrderColumn;
                cmdReadCorporate.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityCorpOffice.OrderMethod;
                cmdReadCorporate.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityCorpOffice.PageMaxSize;
                cmdReadCorporate.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityCorpOffice.PageNumber;
                cmdReadCorporate.Parameters.Add("C_CORP_OFFICE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpOffice = new DataTable();
                dtCorpOffice = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpOffice;
            }
        }
        //Method For updating the corporate office status
        public void UpdateCorpStatus(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryUpdateCorpStatus = "CORPORATE_OFFICE.SP_UPDATE_STATUS";
            using (OracleCommand cmdUpdateCorpStatus = new OracleCommand())
            {
                cmdUpdateCorpStatus.CommandText = strQueryUpdateCorpStatus;
                cmdUpdateCorpStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorpStatus.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdUpdateCorpStatus.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCorpOffice.dDate;
                cmdUpdateCorpStatus.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCorpOffice.UserId;
                cmdUpdateCorpStatus.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCorpOffice.CorpStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCorpStatus);
            }
        }
        //Method For cancel the corporate office,so updating the fields in the master table(cancel userid,cancel date,cancel reason).
        public void CancelCorpOffice(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryCancelCorpOffice = "CORPORATE_OFFICE.SP_CORP_OFFICE_CANCEL";
            using (OracleCommand cmdCancelCorpOffice = new OracleCommand())
            {
                cmdCancelCorpOffice.CommandText = strQueryCancelCorpOffice;
                cmdCancelCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdCancelCorpOffice.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdCancelCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCorpOffice.dDate;
                cmdCancelCorpOffice.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCorpOffice.UserId;
                cmdCancelCorpOffice.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCorpOffice);
            }
        }
        //Procedure for read corporate office by their id
        public DataTable ReadCorporateOfficeById(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadCorporateOfficeById = "CORPORATE_OFFICE.SP_READ_CORP_OFFICEBYID";
            using (OracleCommand cmdReadCorporateById = new OracleCommand())
            {
                cmdReadCorporateById.CommandText = strQueryReadCorporateOfficeById;
                cmdReadCorporateById.CommandType = CommandType.StoredProcedure;
                cmdReadCorporateById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCorporateById.Parameters.Add("C_CORP_OFFICE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpOfficeById = new DataTable();
                dtCorpOfficeById = clsDataLayer.SelectDataTable(cmdReadCorporateById);
                return dtCorpOfficeById;
            }
        }
        //EVM-0016
        //Methode of updating the values of the corporate office master table.
        public void UpdateCorpOffice(clsEntityCorpOffice objEntityCorpOffice, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsList, List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclDeleteAttchmntDeatilsList, List<clsEntityCorpPartners> objEntityTVDeatilsINSERTList, List<clsEntityCorpPartners> objEntityTVDeatilsUPDATEList, string[] strarrCanccldtlIds,List<clsEntityBankDtl> objEntityDetilsListBank)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                    {
            string strQueryUpdateCorpOffice = "CORPORATE_OFFICE.SP_UPDATE_CORP_OFFICES";
            using (OracleCommand cmdUpdateCorpOffice = new OracleCommand(strQueryUpdateCorpOffice,con))
            {
                cmdUpdateCorpOffice.CommandText = strQueryUpdateCorpOffice;
                cmdUpdateCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorpOffice.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdUpdateCorpOffice.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Corporation_Name;
                cmdUpdateCorpOffice.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address1;
                cmdUpdateCorpOffice.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address2;
                cmdUpdateCorpOffice.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityCorpOffice.Address3;
                cmdUpdateCorpOffice.Parameters.Add("C_CNTRYID", OracleDbType.Int32).Value = objEntityCorpOffice.CountryId;
                cmdUpdateCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityCorpOffice.StateId;
                cmdUpdateCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityCorpOffice.CityId;
                cmdUpdateCorpOffice.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityCorpOffice.ZipCode;
                cmdUpdateCorpOffice.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Phone_Number;
                cmdUpdateCorpOffice.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Mobile_Number;
                cmdUpdateCorpOffice.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Web_Address;
                cmdUpdateCorpOffice.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.Email_Address;
                cmdUpdateCorpOffice.Parameters.Add("C_FISCALMNTH", OracleDbType.Int32).Value = objEntityCorpOffice.FiscalMonth;
                cmdUpdateCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCorpOffice.ApplicationDate;
                cmdUpdateCorpOffice.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCorpOffice.CorpStatus;
                cmdUpdateCorpOffice.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCorpOffice.UserId;
                cmdUpdateCorpOffice.Parameters.Add("C_UPDATEDATE", OracleDbType.Date).Value = objEntityCorpOffice.dDate;
                cmdUpdateCorpOffice.Parameters.Add("C_CORTYPE_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpTypeId;
                cmdUpdateCorpOffice.Parameters.Add("C_CORPTIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.TIN_Number;
                cmdUpdateCorpOffice.Parameters.Add("C_CORPCUSTNUMBER", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cust_Care_Number;
                cmdUpdateCorpOffice.Parameters.Add("C_CORPSHORTNAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Short_Name;
                cmdUpdateCorpOffice.Parameters.Add("C_CORPSHORTADD", OracleDbType.Varchar2).Value = objEntityCorpOffice.Short_Address;
                cmdUpdateCorpOffice.Parameters.Add("C_CORPCIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.Cin_Number;

                //START NEW CODE
                cmdUpdateCorpOffice.Parameters.Add("C_BSNSTYPEID", OracleDbType.Int32).Value = objEntityCorpOffice.BsnsTypeId;
                cmdUpdateCorpOffice.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Code;
                if (objEntityCorpOffice.ShareTypeId == 0)
                {
                    cmdUpdateCorpOffice.Parameters.Add("C_SHARETYPEID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdUpdateCorpOffice.Parameters.Add("C_SHARETYPEID", OracleDbType.Int32).Value = objEntityCorpOffice.ShareTypeId;
                }
                cmdUpdateCorpOffice.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntityCorpOffice.Fax;
                cmdUpdateCorpOffice.Parameters.Add("C_ENQMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.EnqMail;
                cmdUpdateCorpOffice.Parameters.Add("C_STRGMAIL", OracleDbType.Varchar2).Value = objEntityCorpOffice.StorageMail;
                cmdUpdateCorpOffice.Parameters.Add("C_RMVMAIL", OracleDbType.Int32).Value = objEntityCorpOffice.RemoveStrg;
                if (objEntityCorpOffice.ParentTypId == 0)
                {
                    cmdUpdateCorpOffice.Parameters.Add("C_PARNTID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdUpdateCorpOffice.Parameters.Add("C_PARNTID", OracleDbType.Int32).Value = objEntityCorpOffice.ParentTypId;
                }
                cmdUpdateCorpOffice.Parameters.Add("C_CMPSHREPER", OracleDbType.Int32).Value = objEntityCorpOffice.CmpnySharePer;
                cmdUpdateCorpOffice.Parameters.Add("C_CRN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CRNnum;
                cmdUpdateCorpOffice.Parameters.Add("C_CRNEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.CRNexpDate;
                cmdUpdateCorpOffice.Parameters.Add("C_CRNISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.CRNissDate;
                cmdUpdateCorpOffice.Parameters.Add("C_TIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.TINnum;
                cmdUpdateCorpOffice.Parameters.Add("C_TINEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.TINexpDate;
                cmdUpdateCorpOffice.Parameters.Add("C_TINISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.TINissDate;
                cmdUpdateCorpOffice.Parameters.Add("C_CCN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CCNnum;
                cmdUpdateCorpOffice.Parameters.Add("C_CCNEXPDATE", OracleDbType.Date).Value = objEntityCorpOffice.CCNexpDate;
                cmdUpdateCorpOffice.Parameters.Add("C_CCNISSDATE", OracleDbType.Date).Value = objEntityCorpOffice.CCNissDate;
                cmdUpdateCorpOffice.Parameters.Add("C_ICON", OracleDbType.Varchar2).Value = objEntityCorpOffice.Icon;
                cmdUpdateCorpOffice.Parameters.Add("C_ACTICON", OracleDbType.Varchar2).Value = objEntityCorpOffice.ActIcon;

                //END NEW CODE
                //EVM-0024
                cmdUpdateCorpOffice.Parameters.Add("C_CHKIN", OracleDbType.Date).Value = objEntityCorpOffice.CheckIn;
                cmdUpdateCorpOffice.Parameters.Add("C_CHKOUT", OracleDbType.Date).Value = objEntityCorpOffice.CheckOut;
                //end
                cmdUpdateCorpOffice.ExecuteNonQuery();
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPermitAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_CRN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 1;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsurAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_TIN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 2;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_CCN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("F_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                    cmdInsertAtcmntDtls.Parameters.Add("F_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                    cmdInsertAtcmntDtls.Parameters.Add("F_DESC", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                    cmdInsertAtcmntDtls.Parameters.Add("F_ROLEID", OracleDbType.Varchar2).Value = 3;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            //for deleting files
            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityPerDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_DELE_CRN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ROLEID", OracleDbType.Int32).Value = 1;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityInsDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_DELE_TIN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ROLEID", OracleDbType.Int32).Value = 2;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }

            foreach (clsEntityInsuranceAndPermitAttchmntDtl objAttchDetail in objEntityVhclDeleteAttchmntDeatilsList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_DELE_CCN_ATCHMNT_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ATCHMNT_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.Parameters.Add("C_ROLEID", OracleDbType.Int32).Value = 3;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            //for partner files

            foreach (clsEntityCorpPartners objAttchDetail in objEntityTVDeatilsINSERTList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_PARTNER_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PRTNR_ID", OracleDbType.Int32).Value = objAttchDetail.PartnerId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_DOCNUM", OracleDbType.Varchar2).Value = objAttchDetail.DocumentNo;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PER", OracleDbType.Decimal).Value = objAttchDetail.SharePerc;

                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (clsEntityCorpPartners objAttchDetail in objEntityTVDeatilsUPDATEList)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.UPD_PARTNER_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PARTID", OracleDbType.Int32).Value = objAttchDetail.Corp_PartnerId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PRTNR_ID", OracleDbType.Int32).Value = objAttchDetail.PartnerId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_DOCNUM", OracleDbType.Varchar2).Value = objAttchDetail.DocumentNo;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PER", OracleDbType.Decimal).Value = objAttchDetail.SharePerc;

                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }
            foreach (string strDtlId in strarrCanccldtlIds)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);

                    string strQueryCancelDetail = "CORPORATE_OFFICE.SP_CANCEL_PARTSHPDTL";
                    using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail,con))
                    {

                        cmdCancelDetail.CommandText = strQueryCancelDetail;
                        cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                        cmdCancelDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = intDtlId;
                        cmdCancelDetail.ExecuteNonQuery();
                    }
                }
            }


            string strQueryInsertAtcmntDtlsdEL = "CORPORATE_OFFICE.SP_BANK_DTLS_DELE";
            using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtlsdEL, con))
            {
                cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtlsdEL;
                cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdInsertAtcmntDtls.ExecuteNonQuery();
            }


            foreach (clsEntityBankDtl objAttchDetail in objEntityDetilsListBank)
            {
                string strQueryInsertAtcmntDtls = "CORPORATE_OFFICE.SP_INS_BANK_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                {


                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_BANKID", OracleDbType.Int32).Value = objAttchDetail.BankId;
                    cmdInsertAtcmntDtls.Parameters.Add("P_BRANCH", OracleDbType.Varchar2).Value = objAttchDetail.Branch;
                    cmdInsertAtcmntDtls.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = objAttchDetail.IBAN;
                    cmdInsertAtcmntDtls.ExecuteNonQuery();
                }
            }


            tran.Commit();
                    }
                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;

                 }
             }
        }
        //EVM-0016
        //Method for checking corporate office name already existed or not in the time of updation
        public string CheckCorpOfficeUpdate(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorpUpdate = "CORPORATE_OFFICE.SP_CHECK_UPDATECORP_NAME";
            OracleCommand cmdCheckCorpUpdate = new OracleCommand();
            cmdCheckCorpUpdate.CommandText = strQueryCheckCorpUpdate;
            cmdCheckCorpUpdate.CommandType = CommandType.StoredProcedure;
            cmdCheckCorpUpdate.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorpUpdate.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdCheckCorpUpdate.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCorpOffice.Corporation_Name;
            cmdCheckCorpUpdate.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorpUpdate);
            string strReturn = cmdCheckCorpUpdate.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorpUpdate.Dispose();
            return strReturn;
        }

        //Method for checking how many corporate offices allowed for this organisation
        public string CheckCorpOfficeCount(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorpCount = "CORPORATE_OFFICE.SP_CHECK_CORP_COUNT";
            OracleCommand cmdCheckCorpCount = new OracleCommand();
            cmdCheckCorpCount.CommandText = strQueryCheckCorpCount;
            cmdCheckCorpCount.CommandType = CommandType.StoredProcedure;
            cmdCheckCorpCount.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorpCount.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorpCount);
            string strReturnCount = cmdCheckCorpCount.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCorpCount.Dispose();
            return strReturnCount;
        }

        //Method for fetch the corporate office count of the organisation from organisation master table
        public string CorpOfficeCount(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCorpCount = "CORPORATE_OFFICE.SP_READ_CORPCOUNT";
            OracleCommand cmdCorpCount = new OracleCommand();
            cmdCorpCount.CommandText = strQueryCorpCount;
            cmdCorpCount.CommandType = CommandType.StoredProcedure;
            cmdCorpCount.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCorpCount.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCorpCount);
            string strReturnCount = cmdCorpCount.Parameters["C_COUNT"].Value.ToString();
            cmdCorpCount.Dispose();
            return strReturnCount;
        }
        //new code
        public DataTable ReadTINFiles(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadExpInsuranceDetails = "CORPORATE_OFFICE.SP_READ_TIN_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdReadExpInsuranceDetails.Parameters.Add("F_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        public DataTable ReadCRNFiles(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadExpInsuranceDetails = "CORPORATE_OFFICE.SP_READ_CRN_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdReadExpInsuranceDetails.Parameters.Add("F_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        public DataTable ReadCCNFiles(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadExpInsuranceDetails = "CORPORATE_OFFICE.SP_READ_CCN_ATCHMNT_FILES";
            OracleCommand cmdReadExpInsuranceDetails = new OracleCommand();
            cmdReadExpInsuranceDetails.CommandText = strQueryReadExpInsuranceDetails;
            cmdReadExpInsuranceDetails.CommandType = CommandType.StoredProcedure;
            cmdReadExpInsuranceDetails.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdReadExpInsuranceDetails.Parameters.Add("F_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadExpInsuranceDetails);
            return dtCategoryList;
        }
        //Method for checking CRN number already existed or not
        public string CheckCRNnum(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorp = "CORPORATE_OFFICE.SP_CHECK_CRN";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_CRN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CRNnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //Method for checking TIN number already existed or not
        public string CheckTINnum(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorp = "CORPORATE_OFFICE.SP_CHECK_TIN";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_TIN", OracleDbType.Varchar2).Value = objEntityCorpOffice.TINnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //Method for checking CCN number already existed or not
        public string CheckCCNnum(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorp = "CORPORATE_OFFICE.SP_CHECK_CCN";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_CCN", OracleDbType.Varchar2).Value = objEntityCorpOffice.CCNnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }

        //Method for checking code already existed or not
        public string CheckCodenum(clsEntityCorpOffice objEntityCorpOffice)
        {

            string strQueryCheckCorp = "CORPORATE_OFFICE.SP_CHECK_CODE";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCorpOffice.Code;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //read organisation details
        public DataTable OrgDetails(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_READ_ORGINFO";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdReadCity.Parameters.Add("C_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }

        //read partnership details
        public DataTable ReadPartnerDetails(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_READ_PRTNER_DTLS";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCity.Parameters.Add("C_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }
        //new code
        // This Method will fetch Employee  For autocompletion from WebService
        public DataTable ReadPartnerWebService(string strLikePartner, clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadEmp = "CORPORATE_OFFICE.SP_READ_PARTNER_WEBSERVICE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("C_PARTNER", OracleDbType.Varchar2).Value = strLikePartner;
            cmdReadEmp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
            cmdReadEmp.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmployee = new DataTable();
            dtEmployee = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmployee;
        }
        //Procedure for read corporate office cancel status
        public DataTable ReadCorpSts(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadCorporateOfficeById = "CORPORATE_OFFICE.SP_READ_CORP_OFFICE_CNCL";
            using (OracleCommand cmdReadCorporateById = new OracleCommand())
            {
                cmdReadCorporateById.CommandText = strQueryReadCorporateOfficeById;
                cmdReadCorporateById.CommandType = CommandType.StoredProcedure;
                cmdReadCorporateById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCorporateById.Parameters.Add("C_CORP_OFFICE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpOfficeById = new DataTable();
                dtCorpOfficeById = clsDataLayer.SelectDataTable(cmdReadCorporateById);
                return dtCorpOfficeById;
            }
        }
        //Method for reading bank details
        public DataTable ReadBankDtls(clsEntityCorpOffice objEntityCorp)
        {
            string strQueryReadCorporate = "CORPORATE_OFFICE.SP_READ_BANKS";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporate;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorp.Organisation_Id;
                cmdReadCorporate.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCorp.CorpOfficeId;
                cmdReadCorporate.Parameters.Add("C_CORPTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpType;
            }
        }
        public DataTable ReadBankDtlsOfCorp(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_READ_BANK_DTLS";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCity.Parameters.Add("C_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }
        public DataTable checkIbanDup(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadState = "CORPORATE_OFFICE.SP_CHCK_IBAN_DUP";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CORPRTID", OracleDbType.Int32).Value = objEntityCorpOffice.CorpOfficeId;
                cmdReadCity.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdReadCity.Parameters.Add("C_IBAN", OracleDbType.Varchar2).Value = objEntityCorpOffice.Code;
                cmdReadCity.Parameters.Add("C_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }

        //EVM 24

        //Read partners
        public DataTable ReadPartners()
        {
            string strQueryReadPartners = "CORPORATE_OFFICE.SP_READ_PTNR_NAME_DNUM";
            using (OracleCommand Read_Partners = new OracleCommand())
            {
                Read_Partners.CommandText = strQueryReadPartners;
                Read_Partners.CommandType = CommandType.StoredProcedure;
                Read_Partners.Parameters.Add("PTNR_NAME_DNUM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(Read_Partners);
                return dtCorpType;
            }
        }
        //READ partner document no
        public DataTable ReadPartnersDoc(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryReadPartners = "CORPORATE_OFFICE.SP_READ_PTNR_DNUM";
            using (OracleCommand Read_Partners_doc = new OracleCommand())
            {
                Read_Partners_doc.CommandText = strQueryReadPartners;
                Read_Partners_doc.CommandType = CommandType.StoredProcedure;
                Read_Partners_doc.Parameters.Add("PTNR_ID", OracleDbType.Int32).Value = objEntityCorpOffice.PartnerId;
                Read_Partners_doc.Parameters.Add("PRTNR_DOCNUM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpType = new DataTable();
                dtCorpType = clsDataLayer.SelectDataTable(Read_Partners_doc);
                return dtCorpType;
            }
        }
        public DataTable OrgCrCard(clsEntityCorpOffice objEntityCorpOffice)
        {
            string strQueryCheckOrg = "CORPORATE_OFFICE.SP_READ_CR_ATCHMNT";
            using (OracleCommand cmdCheckOrg = new OracleCommand())
            {
                cmdCheckOrg.CommandText = strQueryCheckOrg;
                cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                cmdCheckOrg.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityCorpOffice.Organisation_Id;
                cmdCheckOrg.Parameters.Add("CR_NO", OracleDbType.Int32).Value = objEntityCorpOffice.crNo;
                cmdCheckOrg.Parameters.Add("C_ATCHMNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                return dtCheckOrg;
            }
        }
    }
}
