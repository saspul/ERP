using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using System.Threading.Tasks;

namespace DL_Compzit
{
    public class clsDataLayerContactDtls
    {
        //Method for fetch Realation table from database.
        public DataTable ReadRelate()
        {
            string strQueryReadRelate = "EMPLOYEE_CONTACT_DETAIS.SP_READ_RELATION";
            using (OracleCommand cmdReadRelation = new OracleCommand())
            {
                cmdReadRelation.CommandText = strQueryReadRelate;
                cmdReadRelation.CommandType = CommandType.StoredProcedure;
                cmdReadRelation.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRealate = new DataTable();
                dtRealate = clsDataLayer.ExecuteReader(cmdReadRelation);
                return dtRealate;
            }
        }
        public void Add_Emp_Contact_Details(clsEntityLayerContactDtls objentityEmp)
        {
            string strQueryAddContactlDtls = "EMPLOYEE_CONTACT_DETAIS.SP_INS_CONTACT_DETAILS";
            using (OracleCommand cmdAddContactDtls = new OracleCommand())
            {
                cmdAddContactDtls.CommandText = strQueryAddContactlDtls;
                cmdAddContactDtls.CommandType = CommandType.StoredProcedure;
                cmdAddContactDtls.Parameters.Add("P_EMPUSRID", OracleDbType.Int32).Value = objentityEmp.EmpID;
                cmdAddContactDtls.Parameters.Add("P_ADDR1", OracleDbType.Varchar2).Value = objentityEmp.Address1;
                cmdAddContactDtls.Parameters.Add("P_ADDR2", OracleDbType.Varchar2).Value = objentityEmp.Address2;
                cmdAddContactDtls.Parameters.Add("P_ADDR3", OracleDbType.Varchar2).Value = objentityEmp.Address3;
                cmdAddContactDtls.Parameters.Add("P_CNTRYID", OracleDbType.Int32).Value = objentityEmp.CountryId;
                cmdAddContactDtls.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = objentityEmp.StateId;
                cmdAddContactDtls.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = objentityEmp.CityId;
                cmdAddContactDtls.Parameters.Add("P_ZIPCODE", OracleDbType.Varchar2).Value = objentityEmp.ZipCode;
                cmdAddContactDtls.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Email_Address;
                cmdAddContactDtls.Parameters.Add("P_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Mobile_Number;
                cmdAddContactDtls.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Phone_Number;
                cmdAddContactDtls.Parameters.Add("P_FAX", OracleDbType.Varchar2).Value = objentityEmp.Fax;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR1", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address1;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR2", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address2;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR3", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address3;
                cmdAddContactDtls.Parameters.Add("P_CUM_CNTRYID", OracleDbType.Int32).Value = objentityEmp.Cmu_CountryId;
                cmdAddContactDtls.Parameters.Add("P_CUM_STATEID", OracleDbType.Int32).Value = objentityEmp.Cmu_StateId;
                cmdAddContactDtls.Parameters.Add("P_CUM_CITYID", OracleDbType.Int32).Value = objentityEmp.Cmu_CityId;
                cmdAddContactDtls.Parameters.Add("P_CUM_ZIPCODE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_ZipCode;
                cmdAddContactDtls.Parameters.Add("P_CUM_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Email_Address;
                cmdAddContactDtls.Parameters.Add("P_CUM_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Mobile_Number;
                cmdAddContactDtls.Parameters.Add("P_CUM_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Phone_Number;
                cmdAddContactDtls.Parameters.Add("P_CUM_FAX", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Fax;
                cmdAddContactDtls.Parameters.Add("P_EMG_NAME", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Name;
                cmdAddContactDtls.Parameters.Add("P_EMG_RELAT", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Relation;
                cmdAddContactDtls.Parameters.Add("P_EMG_ADR", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Address;
                cmdAddContactDtls.Parameters.Add("P_EMG_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Moble;
                cmdAddContactDtls.Parameters.Add("P_EMG_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Phone;
                cmdAddContactDtls.Parameters.Add("P_EMG_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Email;
                cmdAddContactDtls.Parameters.Add("P_EMG_FAX", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Fax;
                cmdAddContactDtls.Parameters.Add("P_INS_USRID", OracleDbType.Int32).Value = objentityEmp.Ins_Userid;
                cmdAddContactDtls.Parameters.Add("P_INS_DATE", OracleDbType.Date).Value = objentityEmp.Ins_date;
                //cmdAddContactDtls.Parameters.Add("P_UPD_USRID", OracleDbType.Varchar2).Value = objentityEmp.Upd_Userid;
                //cmdAddContactDtls.Parameters.Add("P_UPD_DATE", OracleDbType.Date).Value = objentityEmp.Upd_Date;
                cmdAddContactDtls.Parameters.Add("P_CORPRTID", OracleDbType.Int32).Value = objentityEmp.CorpOffice_Id;
                cmdAddContactDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityEmp.Organisation_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddContactDtls);
            }
        }
        public DataTable Read_Contact_Details(clsEntityLayerContactDtls objentity)
        {
            string strQueryReadContact = "EMPLOYEE_CONTACT_DETAIS.SP_FETCH_CONTACT_DETAILS";
            using (OracleCommand cmdReadContact = new OracleCommand())
            {
                cmdReadContact.CommandText = strQueryReadContact;
                cmdReadContact.CommandType = CommandType.StoredProcedure;
                cmdReadContact.Parameters.Add("P_EMCNDT_ID", OracleDbType.Int32).Value = objentity.EmpID;
                cmdReadContact.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRealate = new DataTable();
                dtRealate = clsDataLayer.ExecuteReader(cmdReadContact);
                return dtRealate;
            }
        }


        public void Update_Emp_Contact_Details(clsEntityLayerContactDtls objentityEmp)
        {
            string strQueryUpdtcontctDtls = "EMPLOYEE_CONTACT_DETAIS.SP_UPD_CONTACT_DETAILS";
            using (OracleCommand cmdAddContactDtls = new OracleCommand())
            {
                cmdAddContactDtls.CommandText = strQueryUpdtcontctDtls;
                cmdAddContactDtls.CommandType = CommandType.StoredProcedure;
                cmdAddContactDtls.Parameters.Add("P_EMCNDT_ID", OracleDbType.Int32).Value = objentityEmp.EmpID;
                cmdAddContactDtls.Parameters.Add("P_ADDR1", OracleDbType.Varchar2).Value = objentityEmp.Address1;
                cmdAddContactDtls.Parameters.Add("P_ADDR2", OracleDbType.Varchar2).Value = objentityEmp.Address2;
                cmdAddContactDtls.Parameters.Add("P_ADDR3", OracleDbType.Varchar2).Value = objentityEmp.Address3;
                cmdAddContactDtls.Parameters.Add("P_CNTRYID", OracleDbType.Int32).Value = objentityEmp.CountryId;
                cmdAddContactDtls.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = objentityEmp.StateId;
                cmdAddContactDtls.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = objentityEmp.CityId;
                cmdAddContactDtls.Parameters.Add("P_ZIPCODE", OracleDbType.Varchar2).Value = objentityEmp.ZipCode;
                cmdAddContactDtls.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Email_Address;
                cmdAddContactDtls.Parameters.Add("P_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Mobile_Number;
                cmdAddContactDtls.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Phone_Number;
                cmdAddContactDtls.Parameters.Add("P_FAX", OracleDbType.Varchar2).Value = objentityEmp.Fax;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR1", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address1;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR2", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address2;
                cmdAddContactDtls.Parameters.Add("P_CUM_ADR3", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Address3;
                cmdAddContactDtls.Parameters.Add("P_CUM_CNTRYID", OracleDbType.Int32).Value = objentityEmp.Cmu_CountryId;
                cmdAddContactDtls.Parameters.Add("P_CUM_STATEID", OracleDbType.Int32).Value = objentityEmp.Cmu_StateId;
                cmdAddContactDtls.Parameters.Add("P_CUM_CITYID", OracleDbType.Int32).Value = objentityEmp.Cmu_CityId;
                cmdAddContactDtls.Parameters.Add("P_CUM_ZIPCODE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_ZipCode;
                cmdAddContactDtls.Parameters.Add("P_CUM_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Email_Address;
                cmdAddContactDtls.Parameters.Add("P_CUM_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Mobile_Number;
                cmdAddContactDtls.Parameters.Add("P_CUM_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Phone_Number;
                cmdAddContactDtls.Parameters.Add("P_CUM_FAX", OracleDbType.Varchar2).Value = objentityEmp.Cmu_Fax;
                cmdAddContactDtls.Parameters.Add("P_EMG_NAME", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Name;
                cmdAddContactDtls.Parameters.Add("P_EMG_RELAT", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Relation;
                cmdAddContactDtls.Parameters.Add("P_EMG_ADR", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Address;
                cmdAddContactDtls.Parameters.Add("P_EMG_MOBILE", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Moble;
                cmdAddContactDtls.Parameters.Add("P_EMG_PHONE", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Phone;
                cmdAddContactDtls.Parameters.Add("P_EMG_EMAIL", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Email;
                cmdAddContactDtls.Parameters.Add("P_EMG_FAX", OracleDbType.Varchar2).Value = objentityEmp.Emrg_Fax;
                cmdAddContactDtls.Parameters.Add("P_UPD_USRID", OracleDbType.Varchar2).Value = objentityEmp.Upd_Userid;
                cmdAddContactDtls.Parameters.Add("P_UPD_DATE", OracleDbType.Date).Value = objentityEmp.Upd_Date;
                clsDataLayer.ExecuteNonQuery(cmdAddContactDtls);
            }
        }
        public DataTable ReadCountry(clsEntityLayerContactDtls objentity)
        {
            string strQueryReadContact = "EMPLOYEE_CONTACT_DETAIS.SP_READ_COUNTRY";
            using (OracleCommand cmdReadContact = new OracleCommand())
            {
                cmdReadContact.CommandText = strQueryReadContact;
                cmdReadContact.CommandType = CommandType.StoredProcedure;
                cmdReadContact.Parameters.Add("CON_ID", OracleDbType.Int32).Value = objentity.CountryId;
                cmdReadContact.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRealate = new DataTable();
                dtRealate = clsDataLayer.ExecuteReader(cmdReadContact);
                return dtRealate;
            }
        }
    }
}
