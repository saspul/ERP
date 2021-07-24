using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;


namespace DL_Compzit
{
   public class clsDataLayerPartner
    {
        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "PARTNER.SP_READ_COUNTRY";
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
        //Method for fetch partnership type master table from database.
        public DataTable ReadPartshipType()
        {
            string strQueryReadCountry = "PARTNER.SP_READ_PARTSHIP_TYPE";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Methode for fetch state master details of selected country from database.
        public DataTable ReadState(clsEntityPartner objEntityPartner)
        {
            string strQueryReadState = "PARTNER.SP_READ_STATE";
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryReadState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityPartner.CountryId;
                cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadState = new DataTable();
                dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                return dtReadState;
            }
        }

        //Method for fetch city master details of selected state from datatbase.
        public DataTable ReadCity(clsEntityPartner objEntityPartner)
        {
            string strQueryReadState = "PARTNER.SP_READ_CITY";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityPartner.StateId;
                cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }
        //Procedure for read partnerlist.
        public DataTable ReadPartner(clsEntityPartner objEntityPartner)
        {
            string strQueryReadCorporateOffice = "PARTNER.SP_READ_PARTNRLIST";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporateOffice;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
                cmdReadCorporate.Parameters.Add("P_OPTION", OracleDbType.Int32).Value = objEntityPartner.StatusId;
                cmdReadCorporate.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityPartner.PartshipTypeId;
                cmdReadCorporate.Parameters.Add("P_CANCEL", OracleDbType.Int32).Value = objEntityPartner.Cancel_Status;
                cmdReadCorporate.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPartner.CommonSearchTerm;
                cmdReadCorporate.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityPartner.SearchName;
                cmdReadCorporate.Parameters.Add("M_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityPartner.SearchType;
                cmdReadCorporate.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPartner.OrderColumn;
                cmdReadCorporate.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPartner.OrderMethod;
                cmdReadCorporate.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPartner.PageMaxSize;
                cmdReadCorporate.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPartner.PageNumber;
                cmdReadCorporate.Parameters.Add("P_CORP_OFFICE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpOffice = new DataTable();
                dtCorpOffice = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpOffice;
            }
        }

        //Methode of inserting values to partner master table.
        public void insertPartner(clsEntityPartner objEntityPartner)
        {
            string strQueryInsertCorpOffice = "PARTNER.SP_INS_PARTNER";
            using (OracleCommand cmdInsertCorpOffice = new OracleCommand())
            {
                cmdInsertCorpOffice.CommandText = strQueryInsertCorpOffice;
                cmdInsertCorpOffice.CommandType = CommandType.StoredProcedure;

                cmdInsertCorpOffice.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
                cmdInsertCorpOffice.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityPartner.PartnerName;
                cmdInsertCorpOffice.Parameters.Add("C_PARTSHPTYP_ID", OracleDbType.Int32).Value = objEntityPartner.PartshipTypeId;
                cmdInsertCorpOffice.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityPartner.Address1;
                cmdInsertCorpOffice.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityPartner.Address2;
                cmdInsertCorpOffice.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityPartner.Address3;
                cmdInsertCorpOffice.Parameters.Add("C_CNTRYID", OracleDbType.Int32).Value = objEntityPartner.CountryId;
                if (objEntityPartner.StateId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityPartner.StateId;
                }
                if (objEntityPartner.CityId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityPartner.CityId;
                }
                cmdInsertCorpOffice.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityPartner.ZipCode;
                cmdInsertCorpOffice.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityPartner.Phone_Number;
                cmdInsertCorpOffice.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityPartner.Web_Address;
                cmdInsertCorpOffice.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityPartner.Email_Address;
                cmdInsertCorpOffice.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityPartner.StatusId;
                cmdInsertCorpOffice.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityPartner.UserId;
                cmdInsertCorpOffice.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntityPartner.Fax;
                cmdInsertCorpOffice.Parameters.Add("C_ENQMAIL", OracleDbType.Varchar2).Value = objEntityPartner.EnqMail;
                cmdInsertCorpOffice.Parameters.Add("C_CRN", OracleDbType.Varchar2).Value = objEntityPartner.CRNnum;
                cmdInsertCorpOffice.Parameters.Add("C_TIN", OracleDbType.Varchar2).Value = objEntityPartner.TINnum;
                cmdInsertCorpOffice.Parameters.Add("C_CCN", OracleDbType.Varchar2).Value = objEntityPartner.CCNnum;
                cmdInsertCorpOffice.Parameters.Add("C_ICONFNAME", OracleDbType.Varchar2).Value = objEntityPartner.IconFname;
                cmdInsertCorpOffice.Parameters.Add("C_ICONACTFNAME", OracleDbType.Varchar2).Value = objEntityPartner.IconActFname;
                cmdInsertCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityPartner.date;
                cmdInsertCorpOffice.Parameters.Add("C_DOCNUM", OracleDbType.Varchar2).Value = objEntityPartner.DocNum; 
                clsDataLayer.ExecuteNonQuery(cmdInsertCorpOffice);
            }

            
        }

        //Procedure for read partner by id.
        public DataTable ReadPartnerById(clsEntityPartner objEntityPartner)
        {
            string strQueryReadCorporateOffice = "PARTNER.SP_READ_PARTNRBYID";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadCorporateOffice;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
                cmdReadCorporate.Parameters.Add("P_CORP_OFFICE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpOffice = new DataTable();
                dtCorpOffice = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtCorpOffice;
            }
        }
        //Methode of updating values to partner master table.
        public void UpdatePartner(clsEntityPartner objEntityPartner)
        {
            string strQueryInsertCorpOffice = "PARTNER.SP_UPD_PARTNER";
            using (OracleCommand cmdInsertCorpOffice = new OracleCommand())
            {
                cmdInsertCorpOffice.CommandText = strQueryInsertCorpOffice;
                cmdInsertCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdInsertCorpOffice.Parameters.Add("C_PARTNERID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
                cmdInsertCorpOffice.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
                cmdInsertCorpOffice.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityPartner.PartnerName;
                cmdInsertCorpOffice.Parameters.Add("C_PARTSHPTYP_ID", OracleDbType.Int32).Value = objEntityPartner.PartshipTypeId;
                cmdInsertCorpOffice.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntityPartner.Address1;
                cmdInsertCorpOffice.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntityPartner.Address2;
                cmdInsertCorpOffice.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntityPartner.Address3;
                cmdInsertCorpOffice.Parameters.Add("C_CNTRYID", OracleDbType.Int32).Value = objEntityPartner.CountryId;
                if (objEntityPartner.StateId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntityPartner.StateId;
                }
                if (objEntityPartner.CityId == 0)
                {
                    cmdInsertCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdInsertCorpOffice.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityPartner.CityId;
                }
                cmdInsertCorpOffice.Parameters.Add("C_ZIP", OracleDbType.Varchar2).Value = objEntityPartner.ZipCode;
                cmdInsertCorpOffice.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntityPartner.Phone_Number;
                cmdInsertCorpOffice.Parameters.Add("C_WEBSITE", OracleDbType.Varchar2).Value = objEntityPartner.Web_Address;
                cmdInsertCorpOffice.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntityPartner.Email_Address;
                cmdInsertCorpOffice.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityPartner.StatusId;
                cmdInsertCorpOffice.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityPartner.UserId;
                cmdInsertCorpOffice.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntityPartner.Fax;
                cmdInsertCorpOffice.Parameters.Add("C_ENQMAIL", OracleDbType.Varchar2).Value = objEntityPartner.EnqMail;
                cmdInsertCorpOffice.Parameters.Add("C_CRN", OracleDbType.Varchar2).Value = objEntityPartner.CRNnum;
                cmdInsertCorpOffice.Parameters.Add("C_TIN", OracleDbType.Varchar2).Value = objEntityPartner.TINnum;
                cmdInsertCorpOffice.Parameters.Add("C_CCN", OracleDbType.Varchar2).Value = objEntityPartner.CCNnum;
                cmdInsertCorpOffice.Parameters.Add("C_ICONFNAME", OracleDbType.Varchar2).Value = objEntityPartner.IconFname;
                cmdInsertCorpOffice.Parameters.Add("C_ICONACTFNAME", OracleDbType.Varchar2).Value = objEntityPartner.IconActFname;
                cmdInsertCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityPartner.date;
                cmdInsertCorpOffice.Parameters.Add("C_DOCNUM", OracleDbType.Varchar2).Value = objEntityPartner.DocNum;
                clsDataLayer.ExecuteNonQuery(cmdInsertCorpOffice);
            }


        }


        //Method for checking partner name already existed or not
        public string CheckName(clsEntityPartner objEntityPartner)
        {

            string strQueryCheckCorp = "PARTNER.SP_CHECK_NAME";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_PARTNRID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityPartner.PartnerName;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }

        //Method for checking CRN number already existed or not
        public string CheckDocnum(clsEntityPartner objEntityPartner)
        {

            string strQueryCheckCorp = "PARTNER.SP_CHECK_DOCNUM";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_PARTNRID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_DOCNUM", OracleDbType.Varchar2).Value = objEntityPartner.DocNum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //Method For cancel the partner,so updating the fields in the master table(cancel userid,cancel date,cancel reason).
        public void CancelPartner(clsEntityPartner objEntityPartner)
        {
            string strQueryCancelCorpOffice = "PARTNER.SP_PARTNER_CANCEL";
            using (OracleCommand cmdCancelCorpOffice = new OracleCommand())
            {
                cmdCancelCorpOffice.CommandText = strQueryCancelCorpOffice;
                cmdCancelCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdCancelCorpOffice.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
                cmdCancelCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityPartner.date;
                cmdCancelCorpOffice.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityPartner.UserId;
                cmdCancelCorpOffice.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityPartner.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCorpOffice);
            }
        }
        public string CheckComRegNo(clsEntityPartner objEntityPartner)
        {

            string strQueryCheckCorp = "PARTNER.SP_CHECK_CRNUM";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_PARTNRID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_CRNUM", OracleDbType.Varchar2).Value = objEntityPartner.CRNnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        public string CheckComCardNo(clsEntityPartner objEntityPartner)
        {

            string strQueryCheckCorp = "PARTNER.SP_CHECK_CCNUM";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_PARTNRID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_CCNUM", OracleDbType.Varchar2).Value = objEntityPartner.CCNnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        public string CheckTIN(clsEntityPartner objEntityPartner)
        {

            string strQueryCheckCorp = "PARTNER.SP_CHECK_TINUM";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("C_PARTNRID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
            cmdCheckCorp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityPartner.Organisation_Id;
            cmdCheckCorp.Parameters.Add("C_TINUM", OracleDbType.Varchar2).Value = objEntityPartner.TINnum;
            cmdCheckCorp.Parameters.Add("C_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["C_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
        //Method For change the status
        public void StatusChange(clsEntityPartner objEntityPartner)
        {
            string strQueryCancelCorpOffice = "PARTNER.SP_CHANGE_STS";
            using (OracleCommand cmdCancelCorpOffice = new OracleCommand())
            {
                cmdCancelCorpOffice.CommandText = strQueryCancelCorpOffice;
                cmdCancelCorpOffice.CommandType = CommandType.StoredProcedure;
                cmdCancelCorpOffice.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityPartner.PartnerId;
                cmdCancelCorpOffice.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityPartner.date;
                cmdCancelCorpOffice.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityPartner.UserId;
                clsDataLayer.ExecuteNonQuery(cmdCancelCorpOffice);
            }
        }
    }
}
