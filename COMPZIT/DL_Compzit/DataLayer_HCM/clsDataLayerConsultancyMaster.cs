using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerConsultancyMaster
    {
        //This Method for fetching the COUNTRY LIST
        public DataTable ReadCountryList()
        {
            DataTable dtCountryList = new DataTable();
            using (OracleCommand cmdReadCountryList = new OracleCommand())
            {
                cmdReadCountryList.CommandText = "CONSULTANCY_MASTER.SP_READ_GEN_COUNTRY_MSTR";
                cmdReadCountryList.CommandType = CommandType.StoredProcedure;
                cmdReadCountryList.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCountryList = clsDataLayer.SelectDataTable(cmdReadCountryList);
            }
            return dtCountryList;

        }
        //This Method for fetching the Consultancy type
        public DataTable ReadConsultancytype()
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "CONSULTANCY_MASTER.SP_READ_GN_CONSULTANCY_TYPE";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;

        }
        // This Method adds Consultancy details to the database
        public void AddConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            string strQueryAddConsultancyMstr = "CONSULTANCY_MASTER.SP_INSERT_GEN_CONSULTANCY_MSTR";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_NAME", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyName;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_ADDR", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyAddress;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_REG_STATUS", OracleDbType.Int32).Value = objEntityConslt.RegStatus;
                if (objEntityConslt.ConsultancyTypeId == 0)
                {
                    cmdAddConsultancyMstr.Parameters.Add("C_CNSLTTYPE_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddConsultancyMstr.Parameters.Add("C_CNSLTTYPE_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyTypeId;
                }
                if (objEntityConslt.CountryId == 0)
                {
                    cmdAddConsultancyMstr.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddConsultancyMstr.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objEntityConslt.CountryId;
                }
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_LOCATION", OracleDbType.Varchar2).Value = objEntityConslt.Location;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_REG_NO", OracleDbType.Varchar2).Value = objEntityConslt.RegNo;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_EMAIL", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyEmail;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_PHONE", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyPhone;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_STATUS", OracleDbType.Int32).Value = objEntityConslt.ConsultancyStatus;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_CNTCT_NAME", OracleDbType.Varchar2).Value = objEntityConslt.ContactName;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityConslt.ContactEmail;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_CNTCT_MOBILE", OracleDbType.Varchar2).Value = objEntityConslt.ContactMobile;
                cmdAddConsultancyMstr.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityConslt.OrgId;
                cmdAddConsultancyMstr.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityConslt.CorpId;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_INS_USR_ID", OracleDbType.Int32).Value = objEntityConslt.UserId;
                cmdAddConsultancyMstr.Parameters.Add("C_CNSLT_INS_DATE", OracleDbType.Date).Value = objEntityConslt.Date;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }
        // This Method checks Consultancy Name in the database for duplication (FOR UPDATE AND INSERT)
        public string CheckDupConsultancyName(clsEntityConsultancyMaster objEntityConslt)
        {
            string strQueryCheckConsultancyName = "CONSULTANCY_MASTER.SP_CHECK_GEN_CONSULTANCY_MSTR";
            OracleCommand cmdCheckConsultancyName = new OracleCommand();
            cmdCheckConsultancyName.CommandText = strQueryCheckConsultancyName;
            cmdCheckConsultancyName.CommandType = CommandType.StoredProcedure;
            if (objEntityConslt.ConsultancyId == 0)
            {
                cmdCheckConsultancyName.Parameters.Add("C_CNSLT_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdCheckConsultancyName.Parameters.Add("C_CNSLT_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyId;
            }
            cmdCheckConsultancyName.Parameters.Add("C_CNSLT_NAME", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyName;
            cmdCheckConsultancyName.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityConslt.OrgId;
            cmdCheckConsultancyName.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityConslt.CorpId;
            cmdCheckConsultancyName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckConsultancyName);
            string strReturn = cmdCheckConsultancyName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckConsultancyName.Dispose();
            return strReturn;

        }
        //Read Consultancy list 
        public DataTable ReadConsultancyList(clsEntityConsultancyMaster objEntityConslt)
        {
            DataTable dtConsultancyList = new DataTable();
            using (OracleCommand cmdReadConsultancyList = new OracleCommand())
            {
                cmdReadConsultancyList.CommandText = "CONSULTANCY_MASTER.SP_READ_GEN_CONSULTANCY_MSTR";
                cmdReadConsultancyList.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancyList.Parameters.Add("C_CNSLTTYPE_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyTypeId;
                cmdReadConsultancyList.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objEntityConslt.CountryId;
                cmdReadConsultancyList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityConslt.ConsultancyStatus;
                cmdReadConsultancyList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityConslt.CancelStatus;
                cmdReadConsultancyList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityConslt.OrgId;
                cmdReadConsultancyList.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityConslt.CorpId;
                cmdReadConsultancyList.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancyList = clsDataLayer.SelectDataTable(cmdReadConsultancyList);
            }
            return dtConsultancyList;
        }
        //Read Consultancy DETAIL 
        public DataTable ReadConsultancyByID(clsEntityConsultancyMaster objEntityConslt)
        {
            DataTable dtConsultancyDetails = new DataTable();
            using (OracleCommand cmdReadConsultancyDetails = new OracleCommand())
            {
                cmdReadConsultancyDetails.CommandText = "CONSULTANCY_MASTER.SP_RD_CONSULTANCY_MSTR_BYID";
                cmdReadConsultancyDetails.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancyDetails.Parameters.Add("C_CNSLT_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyId;
                cmdReadConsultancyDetails.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityConslt.OrgId;
                cmdReadConsultancyDetails.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityConslt.CorpId;
                cmdReadConsultancyDetails.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancyDetails = clsDataLayer.SelectDataTable(cmdReadConsultancyDetails);
            }
            return dtConsultancyDetails;
        }
        // This Method update Consultancy details 
        public void UpdateConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            string strQueryUpdateConsultancy = "CONSULTANCY_MASTER.SP_UPD_GEN_CONSULTANCY_MSTR";
            using (OracleCommand cmdUpdateConsultancy = new OracleCommand())
            {
                cmdUpdateConsultancy.CommandText = strQueryUpdateConsultancy;
                cmdUpdateConsultancy.CommandType = CommandType.StoredProcedure;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyId;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_NAME", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyName;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_ADDR", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyAddress;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_REG_STATUS", OracleDbType.Int32).Value = objEntityConslt.RegStatus;
                if (objEntityConslt.ConsultancyTypeId == 0)
                {
                    cmdUpdateConsultancy.Parameters.Add("C_CNSLTTYPE_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdUpdateConsultancy.Parameters.Add("C_CNSLTTYPE_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyTypeId;
                }
                if (objEntityConslt.CountryId == 0)
                {
                    cmdUpdateConsultancy.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdUpdateConsultancy.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objEntityConslt.CountryId;
                }
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_LOCATION", OracleDbType.Varchar2).Value = objEntityConslt.Location;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_REG_NO", OracleDbType.Varchar2).Value = objEntityConslt.RegNo;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_EMAIL", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyEmail;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_PHONE", OracleDbType.Varchar2).Value = objEntityConslt.ConsultancyPhone;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_STATUS", OracleDbType.Int32).Value = objEntityConslt.ConsultancyStatus;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_CNTCT_NAME", OracleDbType.Varchar2).Value = objEntityConslt.ContactName;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_CNTCT_EMAIL", OracleDbType.Varchar2).Value = objEntityConslt.ContactEmail;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_CNTCT_MOBILE", OracleDbType.Varchar2).Value = objEntityConslt.ContactMobile;
                cmdUpdateConsultancy.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityConslt.OrgId;
                cmdUpdateConsultancy.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityConslt.CorpId;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_UPD_USR_ID", OracleDbType.Int32).Value = objEntityConslt.UserId;
                cmdUpdateConsultancy.Parameters.Add("C_CNSLT_UPD_DATE", OracleDbType.Date).Value = objEntityConslt.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateConsultancy);
            }
        }
        // This Method delete Consultancy details 
        public void CancelConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            string strQueryCancelConsultancy = "CONSULTANCY_MASTER.SP_CANCEL_CONSULTANCY";
            using (OracleCommand cmdCancelConsultancy = new OracleCommand())
            {
                cmdCancelConsultancy.CommandText = strQueryCancelConsultancy;
                cmdCancelConsultancy.CommandType = CommandType.StoredProcedure;
                cmdCancelConsultancy.Parameters.Add("C_CNSLT_ID", OracleDbType.Int32).Value = objEntityConslt.ConsultancyId;
                cmdCancelConsultancy.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityConslt.UserId;
                cmdCancelConsultancy.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityConslt.Date;
                cmdCancelConsultancy.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityConslt.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelConsultancy);
            }
        }
    }
}
