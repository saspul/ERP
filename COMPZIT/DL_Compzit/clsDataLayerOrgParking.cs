using System;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerOrgParking
    {
        //Method for fetch registration type table from database.
        public DataTable ReadOrganisationType()
        {
            string strQueryReadOrganisation = "ORGANISATION_PARKING.SP_READ_ORGANISATION";
            using (OracleCommand cmdReadOrganisation = new OracleCommand())
            {
                cmdReadOrganisation.CommandText = strQueryReadOrganisation;
                cmdReadOrganisation.CommandType = CommandType.StoredProcedure;
                cmdReadOrganisation.Parameters.Add("O_ORGTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtOrganisation = new DataTable();
                dtOrganisation = clsDataLayer.SelectDataTable(cmdReadOrganisation);
                return dtOrganisation;
            }
        }
        public DataTable ReadFramework()
        {
            string strQueryReadOrganisation = "ORGANISATION_PARKING.SP_READ_FRAEWORK";
            using (OracleCommand cmdReadOrganisation = new OracleCommand())
            {
                cmdReadOrganisation.CommandText = strQueryReadOrganisation;
                cmdReadOrganisation.CommandType = CommandType.StoredProcedure;
                cmdReadOrganisation.Parameters.Add("O_ORGTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtOrganisation = new DataTable();
                dtOrganisation = clsDataLayer.SelectDataTable(cmdReadOrganisation);
                return dtOrganisation;
            }
        }
        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "ORGANISATION_PARKING.SP_READ_COUNTRY";
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
        public DataTable ReadState(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryReadState = "ORGANISATION_PARKING.SP_READ_STATE";
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryReadState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityOrgParking.CountryId;
                cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadState = new DataTable();
                dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                return dtReadState;
            }
        }

        //Method for fetch city master details of selected state from datatbase.
        public DataTable ReadCity(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryReadState = "ORGANISATION_PARKING.SP_READ_CITY";
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = strQueryReadState;
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityOrgParking.StateId;
                cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCity = new DataTable();
                dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                return dtReadCity;
            }
        }

        //Methode for invoke license pack master table from database.
        public DataTable ReadLicensePack()
        {
            string strQueryReadLicense = "ORGANISATION_PARKING.SP_READ_LICENSEPACK";
            using (OracleCommand cmdReadLicense = new OracleCommand())
            {
                cmdReadLicense.CommandText = strQueryReadLicense;
                cmdReadLicense.CommandType = CommandType.StoredProcedure;
                cmdReadLicense.Parameters.Add("L_LICENSEPACK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadLicense = new DataTable();
                dtReadLicense = clsDataLayer.SelectDataTable(cmdReadLicense);
                return dtReadLicense;
            }
        }

        //Method for fetch corporate pack from database.
        public DataTable ReadCorporatePack()
        {
            string strQueryReadLicense = "ORGANISATION_PARKING.SP_READ_CORPORATEPACK";
            using (OracleCommand cmdReadCorporate = new OracleCommand())
            {
                cmdReadCorporate.CommandText = strQueryReadLicense;
                cmdReadCorporate.CommandType = CommandType.StoredProcedure;
                cmdReadCorporate.Parameters.Add("C_CORPORATEPACK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCorporate = new DataTable();
                dtReadCorporate = clsDataLayer.SelectDataTable(cmdReadCorporate);
                return dtReadCorporate;
            }
        }

        //Method for fetch license pack maxmimum user details from license pack master table of the selected license pack.
        public DataTable ReadLicPacCount(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryReadLicPacCount = "ORGANISATION_PARKING.SP_READ_LICENSEPACKCOUNT";
            using (OracleCommand cmdReadLicPacCount = new OracleCommand())
            {
                cmdReadLicPacCount.CommandText = strQueryReadLicPacCount;
                cmdReadLicPacCount.CommandType = CommandType.StoredProcedure;
                cmdReadLicPacCount.Parameters.Add("L_LICENSEPACKID", OracleDbType.Int32).Value = objEntityOrgParking.LicPacId;
                cmdReadLicPacCount.Parameters.Add("L_LICENSEPACKCOUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLicPacCount = new DataTable();
                dtLicPacCount = clsDataLayer.SelectDataTable(cmdReadLicPacCount);
                return dtLicPacCount;
            }

        }

        //Method for fetch corporate pack count allowed offices count from corporate pack master table of selected corporate pack.
        public DataTable ReadCorPacCount(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryReadCorPacCount = "ORGANISATION_PARKING.SP_READ_CORPORATEPACKCOUNT";
            using (OracleCommand cmdReadCorPacCount = new OracleCommand())
            {
                cmdReadCorPacCount.CommandText = strQueryReadCorPacCount;
                cmdReadCorPacCount.CommandType = CommandType.StoredProcedure;
                cmdReadCorPacCount.Parameters.Add("C_CORPORATEPACKID", OracleDbType.Int32).Value = objEntityOrgParking.CorPacId;
                cmdReadCorPacCount.Parameters.Add("C_CORPORATEPACKCOUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorPacCount = new DataTable();
                dtCorPacCount = clsDataLayer.SelectDataTable(cmdReadCorPacCount);
                return dtCorPacCount;
            }

        }

        //Method for fetch next value from databse of current next id.
        public DataTable ReadNextId(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEntityOrgParking.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }

        //Methode for checking current already exist on table.
        public DataTable EmailCheck(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryEmailCheck = "ORGANISATION_PARKING.SP_EMAIL_CHECKING";
            using (OracleCommand cmdEmailCheck = new OracleCommand())
            {
                cmdEmailCheck.CommandText = strQueryEmailCheck;
                cmdEmailCheck.CommandType = CommandType.StoredProcedure;
                cmdEmailCheck.Parameters.Add("E_EMAIL", OracleDbType.Varchar2).Value = objEntityOrgParking.Email_Address;
                cmdEmailCheck.Parameters.Add("E_EMAILCOUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmailCheck = new DataTable();
                dtEmailCheck = clsDataLayer.SelectDataTable(cmdEmailCheck);
                return dtEmailCheck;
            }

        }

        //Methode for checking current already exist on Usertable.
        public DataTable EmailCheckUser(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryEmailCheckUser = "ORGANISATION_PARKING.SP_EMAIL_CHECKINGUSER";
            using (OracleCommand cmdEmailCheckUser = new OracleCommand())
            {
                cmdEmailCheckUser.CommandText = strQueryEmailCheckUser;
                cmdEmailCheckUser.CommandType = CommandType.StoredProcedure;
                cmdEmailCheckUser.Parameters.Add("E_EMAIL", OracleDbType.Varchar2).Value = objEntityOrgParking.Email_Address;
                cmdEmailCheckUser.Parameters.Add("E_EMAILCOUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmailCheckUser = new DataTable();
                dtEmailCheckUser = clsDataLayer.SelectDataTable(cmdEmailCheckUser);
                return dtEmailCheckUser;
            }

        }

        //Method of inserting values to organisation parking table and GN_EMAIL_STORE.
        public void InsertOrgParking_Mail(clsEntityOrgParking objEntityOrgParking, string strTempalteId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
           
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                OracleTransaction tran;
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    string strQueryInsertOrgPar = "ORGANISATION_PARKING.SP_INSERT_PARKING";
                    using (OracleCommand cmdInsertOrgPar = new OracleCommand())
                    {
                        cmdInsertOrgPar.Connection = con;
                        cmdInsertOrgPar.Transaction = tran;
                        cmdInsertOrgPar.CommandText = strQueryInsertOrgPar;
                        cmdInsertOrgPar.CommandType = CommandType.StoredProcedure;
                        cmdInsertOrgPar.Parameters.Add("O_PARK_ID", OracleDbType.Int32).Value = objEntityOrgParking.NextValue;
                        cmdInsertOrgPar.Parameters.Add("O_TYPE_ID", OracleDbType.Int32).Value = objEntityOrgParking.OrgTypeId;
                        cmdInsertOrgPar.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objEntityOrgParking.Organisation_Name;
                        cmdInsertOrgPar.Parameters.Add("O_ADD1", OracleDbType.Varchar2).Value = objEntityOrgParking.Address1;
                        cmdInsertOrgPar.Parameters.Add("O_ADD2", OracleDbType.Varchar2).Value = objEntityOrgParking.Address2;
                        cmdInsertOrgPar.Parameters.Add("O_ADD3", OracleDbType.Varchar2).Value = objEntityOrgParking.Address3;
                        cmdInsertOrgPar.Parameters.Add("O_CNTRYID", OracleDbType.Int32).Value = objEntityOrgParking.CountryId;
                        cmdInsertOrgPar.Parameters.Add("O_STATEID", OracleDbType.Int32).Value = objEntityOrgParking.StateId;
                        cmdInsertOrgPar.Parameters.Add("O_CITYID", OracleDbType.Int32).Value = objEntityOrgParking.CityId;
                        cmdInsertOrgPar.Parameters.Add("O_ZIP", OracleDbType.Varchar2).Value = objEntityOrgParking.ZipCode;
                        cmdInsertOrgPar.Parameters.Add("O_PHONE", OracleDbType.Varchar2).Value = objEntityOrgParking.Phone_Number;
                        cmdInsertOrgPar.Parameters.Add("O_MOBILE", OracleDbType.Varchar2).Value = objEntityOrgParking.Mobile_Number;
                        cmdInsertOrgPar.Parameters.Add("O_WEBSITE", OracleDbType.Varchar2).Value = objEntityOrgParking.Web_Address;
                        cmdInsertOrgPar.Parameters.Add("O_EMAIL", OracleDbType.Varchar2).Value = objEntityOrgParking.Email_Address;
                        cmdInsertOrgPar.Parameters.Add("O_PWD", OracleDbType.Varchar2).Value = objEntityOrgParking.EncryptPassword;
                        cmdInsertOrgPar.Parameters.Add("O_LICPACID", OracleDbType.Int32).Value = objEntityOrgParking.LicPacId;
                        cmdInsertOrgPar.Parameters.Add("O_LICPACCOUNT", OracleDbType.Int32).Value = objEntityOrgParking.LicPacCount;
                        cmdInsertOrgPar.Parameters.Add("O_CORPACID", OracleDbType.Int32).Value = objEntityOrgParking.CorPacId;
                        cmdInsertOrgPar.Parameters.Add("O_CORPACCOUNT", OracleDbType.Int32).Value = objEntityOrgParking.CorPacCount;
                        cmdInsertOrgPar.Parameters.Add("O_STATUSID", OracleDbType.Int32).Value = objEntityOrgParking.OrgStatusId;
                        cmdInsertOrgPar.Parameters.Add("O_STDATE", OracleDbType.Date).Value = objEntityOrgParking.OrganisationStatusDate;
                        cmdInsertOrgPar.Parameters.Add("O_INSERTIP", OracleDbType.Varchar2).Value = objEntityOrgParking.IP_Address;
                        cmdInsertOrgPar.Parameters.Add("O_INSERTDATE", OracleDbType.Date).Value = objEntityOrgParking.OrgInsertDate;
                        cmdInsertOrgPar.Parameters.Add("O_VERIFICATION", OracleDbType.Varchar2).Value = objEntityOrgParking.Verification_Code;
                        cmdInsertOrgPar.Parameters.Add("O_CONTACTNAME", OracleDbType.Varchar2).Value = objEntityOrgParking.Contact_Person;
                        cmdInsertOrgPar.Parameters.Add("O_FRAMEWORK_ID", OracleDbType.Int32).Value = objEntityOrgParking.FrameworkId;                        
                        cmdInsertOrgPar.ExecuteNonQuery();
                    } 
                    
                    int intStatus = 0;
                    string strCommandText = "MAIL.SP_INSERT_GN_EMAIL_STORE";
                    using (OracleCommand cmdStore = new OracleCommand())
                    {
                        cmdStore.Connection = con;
                        cmdStore.Transaction = tran;
                        cmdStore.CommandText = strCommandText;
                        cmdStore.CommandType = CommandType.StoredProcedure;
                        cmdStore.Parameters.Add("S_TMTP_ID", OracleDbType.Int32).Value = dtTemplateDetail.Rows[0]["EMTMTP_ID"].ToString(); ;
                        cmdStore.Parameters.Add("S_TRANS_ID", OracleDbType.Int32).Value = Convert.ToInt32(objEntityOrgParking.NextValue.ToString());
                        cmdStore.Parameters.Add("S_FR0M_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_EMAIL_SENDMAIL"].ToString();
                        cmdStore.Parameters.Add("S_TO_MAIL", OracleDbType.Varchar2).Value = objEntityOrgParking.Email_Address;
                        cmdStore.Parameters.Add("S_RPLYTO_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_RPLYTO_SENDMAIL"].ToString();
                        cmdStore.Parameters.Add("S_SUBJ", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_SUBJECT"].ToString();
                        cmdStore.Parameters.Add("S_MSG", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_MESSAGE"].ToString();
                        cmdStore.Parameters.Add("S_FROM_ADDR1", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_ADDR1"].ToString();
                        cmdStore.Parameters.Add("S_DISCLAIMER", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_DISCLAIMER"].ToString();
                        cmdStore.Parameters.Add("S_SEND_STATUS", OracleDbType.Int32).Value = intStatus;
                        cmdStore.Parameters.Add("S_TMPLT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTempalteId);
                        cmdStore.ExecuteNonQuery();
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

        //public void InsertToStoreDetail(string strTempalteId, string strToAddr, string strTransId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        //{
        //    int intStatus = 0;
        //    string strCommandText = "MAIL.SP_INSERT_GN_EMAIL_STORE";
        //    using (OracleCommand cmdStore = new OracleCommand())
        //    {
        //        cmdStore.CommandText = strCommandText;
        //        cmdStore.CommandType = CommandType.StoredProcedure;
        //        cmdStore.Parameters.Add("S_TMTP_ID", OracleDbType.Int32).Value = dtTemplateDetail.Rows[0]["EMTMTP_ID"].ToString(); ;
        //        cmdStore.Parameters.Add("S_TRANS_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTransId);
        //        cmdStore.Parameters.Add("S_FR0M_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_EMAIL_SENDMAIL"].ToString();
        //        cmdStore.Parameters.Add("S_TO_MAIL", OracleDbType.Varchar2).Value = strToAddr;
        //        cmdStore.Parameters.Add("S_RPLYTO_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_RPLYTO_SENDMAIL"].ToString();
        //        cmdStore.Parameters.Add("S_SUBJ", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_SUBJECT"].ToString();
        //        cmdStore.Parameters.Add("S_MSG", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_MESSAGE"].ToString();
        //        cmdStore.Parameters.Add("S_FROM_ADDR1", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_ADDR1"].ToString();
        //        cmdStore.Parameters.Add("S_DISCLAIMER", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_DISCLAIMER"].ToString();
        //        cmdStore.Parameters.Add("S_SEND_STATUS", OracleDbType.Int32).Value = intStatus;
        //        cmdStore.Parameters.Add("S_TMPLT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTempalteId);
        //        clsDataLayer.ExecuteNonQuery(cmdStore);
        //    }
        //}
        //Method for checking organisation name already existed in the table.
        public DataTable CheckOrg(clsEntityOrgParking objEntityOrgParking)
        {
            string strQueryCheckOrg = "ORGANISATION_PARKING.SP_CHECK_ORG_NAME";
            using (OracleCommand cmdCheckOrg = new OracleCommand())
            {
                cmdCheckOrg.CommandText = strQueryCheckOrg;
                cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                cmdCheckOrg.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objEntityOrgParking.Organisation_Name;
                cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                return dtCheckOrg;
            }
        }
    }
}