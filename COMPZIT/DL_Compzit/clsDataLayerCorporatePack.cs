using System;
using System.Configuration;
using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:12/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Corporate Pack and also updating and viewing the same .

namespace DL_Compzit
{
    public class clsDataLayerCorporatePack
    {
        // This Method adds Corporate Pack details to the database
        public void AddCorporatePack(clsEntityCorporatePack objCrpPack)
        {
            string strQueryAddCrpPack = "CORPORATE_PACK.SP_INSERT_APP_CORPORATE_PACKS";
            using (OracleCommand cmdAddCorPac = new OracleCommand())
            {
                cmdAddCorPac.CommandText = strQueryAddCrpPack;
                cmdAddCorPac.CommandType = CommandType.StoredProcedure;
                cmdAddCorPac.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objCrpPack.CrpPackName;
                cmdAddCorPac.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objCrpPack.CrpStatus;
                cmdAddCorPac.Parameters.Add("P_COUNT", OracleDbType.Int32).Value = objCrpPack.CrprtPackCnt;
                clsDataLayer.ExecuteNonQuery(cmdAddCorPac);
            }
        }


        // This Method checks Corporate Pack Name in the database for duplication
        public string CheckDupCorporatePackName(clsEntityCorporatePack objCrpPack)
        {
            string strQueryCheckCrpPack = "CORPORATE_PACK.SP_CHECK_APP_CORPAC_NAME";
            OracleCommand cmdCheckCorPac = new OracleCommand();

            cmdCheckCorPac.CommandText = strQueryCheckCrpPack;
            cmdCheckCorPac.CommandType = CommandType.StoredProcedure;
            cmdCheckCorPac.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objCrpPack.CrpPackName;
            cmdCheckCorPac.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCrpPack.CrprtPackId;
            cmdCheckCorPac.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorPac);
            string strReturn = cmdCheckCorPac.Parameters["P_COUNT"].Value.ToString();
            cmdCheckCorPac.Dispose();
            return strReturn;

        }
        // This Method checks Corporate Pack Count in the database for duplication
        public string CheckDupCorporatePackCount(clsEntityCorporatePack objCrpPack)
        {
            string strQueryCheckCrpPack = "CORPORATE_PACK.SP_CHECK_APP_CORPAC_OFC_COUNT";
            OracleCommand cmdCheckCorPac = new OracleCommand();

            cmdCheckCorPac.CommandText = strQueryCheckCrpPack;
            cmdCheckCorPac.CommandType = CommandType.StoredProcedure;
            cmdCheckCorPac.Parameters.Add("P_OFC_COUNT", OracleDbType.Int32).Value = objCrpPack.CrprtPackCnt;
            cmdCheckCorPac.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCrpPack.CrprtPackId;
            cmdCheckCorPac.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorPac);
            string strReturn = cmdCheckCorPac.Parameters["P_COUNT"].Value.ToString();
            cmdCheckCorPac.Dispose();
            return strReturn;

        }


        // This Method displays Corporate Pack details from the database
        public DataTable GridDisplay(clsEntityCorporatePack objCrpPack)
        {
            string strCommandText = "CORPORATE_PACK.SP_READ_APP_CORPORATE_PACKS";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objCrpPack.CrpStatus;
                cmdGrid.Parameters.Add("P_CORPAC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        // This Method Updates the Status of Corporate Pack  to the database
        public void UpdateStatus(clsEntityCorporatePack objCrpPack)
        {
            string strCommandText = "CORPORATE_PACK.SP_UPDATE_APP_CORPAC_ACTIVE";
            using (OracleCommand cmdUpdatestatus = new OracleCommand())
            {
                cmdUpdatestatus.CommandText = strCommandText;
                cmdUpdatestatus.CommandType = CommandType.StoredProcedure;
                cmdUpdatestatus.Parameters.Add("P_ID", OracleDbType.Int32).Value = objCrpPack.CrprtPackId;
                cmdUpdatestatus.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objCrpPack.CrpStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdatestatus);
            }
        }
        // This Method select the details from the database when Edit Button is Clicked
        public DataTable EditPack(clsEntityCorporatePack objCrpPack)
        {
            string strCommandText = "CORPORATE_PACK.SP_READ_APP_CORPAC_BYID";
            using (OracleCommand cmdEditPack = new OracleCommand())
            {
                cmdEditPack.CommandText = strCommandText;
                cmdEditPack.CommandType = CommandType.StoredProcedure;
                cmdEditPack.Parameters.Add("P_ID", OracleDbType.Int32).Value = objCrpPack.CrprtPackId;
                cmdEditPack.Parameters.Add("P_CORPAC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEditPack = new DataTable();
                dtEditPack = clsDataLayer.SelectDataTable(cmdEditPack);
                return dtEditPack;
            }
        }
        // This Method Updates  Corporate Pack details  to the database
        public void UpdateCorporatePack(clsEntityCorporatePack objCrpPack)
        {
            string strQueryUpdCrpPack = "CORPORATE_PACK.SP_UPDATE_APP_CORPORATE_PACKS";
            using (OracleCommand cmdUpdateCorPac = new OracleCommand())
            {
                cmdUpdateCorPac.CommandText = strQueryUpdCrpPack;
                cmdUpdateCorPac.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorPac.Parameters.Add("P_ID", OracleDbType.Int32).Value = objCrpPack.CrprtPackId;
                cmdUpdateCorPac.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objCrpPack.CrpPackName;
                cmdUpdateCorPac.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objCrpPack.CrpStatus;
                cmdUpdateCorPac.Parameters.Add("P_COUNT", OracleDbType.Int32).Value = objCrpPack.CrprtPackCnt;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCorPac);
            }

        }
    }
}
