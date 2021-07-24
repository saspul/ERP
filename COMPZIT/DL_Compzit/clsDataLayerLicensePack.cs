using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:12/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerLicensePack
    {
        public void AddLicensePack(clsEntityLicensePack objEntLicPac)
        {
            //Inserting values to license pack master table.
            using (OracleCommand cmdAddLicPac = new OracleCommand())
            {
                cmdAddLicPac.InitialLONGFetchSize = 1000;
                cmdAddLicPac.CommandText = "LICENSE_PACK.SP_INSERT_APP_LICENSE_PACKS";
                cmdAddLicPac.CommandType = CommandType.StoredProcedure;
                cmdAddLicPac.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntLicPac.LicPacName;
                cmdAddLicPac.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntLicPac.LicPacStatus;
                cmdAddLicPac.Parameters.Add("P_ENDS", OracleDbType.Int32).Value = objEntLicPac.LicPacEnds;
                clsDataLayer.ExecuteNonQuery(cmdAddLicPac);
            }
        }
        // This Method checks License Pack Name in the database for duplication
        public string CheckDupLicensePackName(clsEntityLicensePack objLicPack)
        {
            string strQueryCheckLicPack = "LICENSE_PACK.SP_CHECK_APP_LICPAC_NAME";
            OracleCommand cmdCheckLicPac = new OracleCommand();

            cmdCheckLicPac.CommandText = strQueryCheckLicPack;
            cmdCheckLicPac.CommandType = CommandType.StoredProcedure;
            cmdCheckLicPac.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objLicPack.LicPacName;
            cmdCheckLicPac.Parameters.Add("L_ID", OracleDbType.Int32).Value = objLicPack.LicPackId;
            cmdCheckLicPac.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckLicPac);
            string strReturn = cmdCheckLicPac.Parameters["L_COUNT"].Value.ToString();
            cmdCheckLicPac.Dispose();
            return strReturn;

        }
    
        // This Method checks License Pack Maximum User count in the database for duplication
        public string CheckDupLicensePackMaxUserCount(clsEntityLicensePack objLicPack)
        {
            string strQueryCheckLicensePack = "LICENSE_PACK.SP_CHECK_APP_LICPAC_MAX_USER";
            OracleCommand cmdCheckLicensePac = new OracleCommand();

            cmdCheckLicensePac.CommandText = strQueryCheckLicensePack;
            cmdCheckLicensePac.CommandType = CommandType.StoredProcedure;
            cmdCheckLicensePac.Parameters.Add("L_MAX_USR", OracleDbType.Int32).Value = objLicPack.LicPacEnds;
            cmdCheckLicensePac.Parameters.Add("L_ID", OracleDbType.Int32).Value = objLicPack.LicPackId;
            cmdCheckLicensePac.Parameters.Add("L_MAX_USR_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckLicensePac);
            string strReturn = cmdCheckLicensePac.Parameters["L_MAX_USR_COUNT"].Value.ToString();
            cmdCheckLicensePac.Dispose();
            return strReturn;
        }

        public DataTable ReadLicPac(clsEntityLicensePack objLicPack)
        {
            //Read license pack master table from database         
            string strQueryReadLicPac = "LICENSE_PACK.SP_READ_APP_LICENSE_PACKS";
            DataTable dtReadLicPac = new DataTable();
            using (OracleCommand cmdReadLicPac = new OracleCommand())
            {
                cmdReadLicPac.CommandText = strQueryReadLicPac;
                cmdReadLicPac.CommandType = CommandType.StoredProcedure;
                cmdReadLicPac.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objLicPack.LicPacStatus;
                cmdReadLicPac.Parameters.Add("P_LICPAC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadLicPac = clsDataLayer.SelectDataTable(cmdReadLicPac);
            }
            return dtReadLicPac;
        }
        public DataTable ReadLicPacEdit(clsEntityLicensePack objEntLicPac)
        {
            //Read license pack master table according to their Id(Primary Key)
            string strQueryReadLicPacEdit = "LICENSE_PACK.SP_READ_APP_LICPAC_BYID";
            using (OracleCommand cmdReadLicPacEdit = new OracleCommand())
            {
                cmdReadLicPacEdit.CommandText = strQueryReadLicPacEdit;
                cmdReadLicPacEdit.CommandType = CommandType.StoredProcedure;
                cmdReadLicPacEdit.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntLicPac.LicPackId;
                cmdReadLicPacEdit.Parameters.Add("P_LICPAC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadLicPac = new DataTable();
                dtReadLicPac = clsDataLayer.SelectDataTable(cmdReadLicPacEdit);
                return dtReadLicPac;
            }
        }
        public void UpdateLicPac(clsEntityLicensePack objEntLicPac)
        {
            //For updating license pack master table with new data.         
            string strQueryUpdateLicPac = "LICENSE_PACK.SP_UPDATE_APP_LICENSE_PACKS";
            using (OracleCommand cmdUpdateLicPac = new OracleCommand())
            {
                cmdUpdateLicPac.CommandText = strQueryUpdateLicPac;
                cmdUpdateLicPac.CommandType = CommandType.StoredProcedure;
                cmdUpdateLicPac.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntLicPac.LicPackId;
                cmdUpdateLicPac.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntLicPac.LicPacName;
                cmdUpdateLicPac.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntLicPac.LicPacStatus;
                cmdUpdateLicPac.Parameters.Add("P_ENDS", OracleDbType.Int32).Value = objEntLicPac.LicPacEnds;
                clsDataLayer.ExecuteNonQuery(cmdUpdateLicPac);
            }

        }

        public void UpdateLicPacActive(clsEntityLicensePack objEntLicPac)
        {
            //Updating license pack Active filed in master table.             
            string strQueryUpdateLicPacActive = "LICENSE_PACK.SP_UPDATE_APP_LICPAC_ACTIVE";
            using (OracleCommand cmdUpdateLicPacActive = new OracleCommand())
            {
                cmdUpdateLicPacActive.CommandText = strQueryUpdateLicPacActive;
                cmdUpdateLicPacActive.CommandType = CommandType.StoredProcedure;
                cmdUpdateLicPacActive.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntLicPac.LicPackId;
                cmdUpdateLicPacActive.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntLicPac.LicPacStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdateLicPacActive);
            }

        }
    }
}
