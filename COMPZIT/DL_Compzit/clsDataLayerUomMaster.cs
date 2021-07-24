using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;



// CREATED BY:EVM-0002
// CREATED DATE:16/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Unit of measurements(Uom) detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
    public class clsDataLayerUomMaster
    {
        // This Method adds Uom details to the Uom master table
       
        public void AddUomMstr(clsEntityUomMaster objEntityUom)
        {
            string strQueryAddUomMstr = "UOM_MASTER.SP_INSERT_UOM";
            using (OracleCommand cmdAddUom = new OracleCommand())
            {
                cmdAddUom.CommandText = strQueryAddUomMstr;
                cmdAddUom.CommandType = CommandType.StoredProcedure;
                cmdAddUom.Parameters.Add("U_NAME", OracleDbType.Varchar2).Value = objEntityUom.Uom_name;
                cmdAddUom.Parameters.Add("U_CODE", OracleDbType.Varchar2).Value = objEntityUom.Uom_Code;
                cmdAddUom.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUom.Org_Id;
                cmdAddUom.Parameters.Add("U_CORPID", OracleDbType.Int32).Value = objEntityUom.Corp_Id;
                cmdAddUom.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUom.Unit_Status;
                cmdAddUom.Parameters.Add("U_INSUSERID", OracleDbType.Int32).Value = objEntityUom.User_Id;
                cmdAddUom.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUom.D_Date;
                
                clsDataLayer.ExecuteNonQuery(cmdAddUom);
            }
        }

        //Method for change the active / inactive status of Uom master
        public void UomStatusChange(clsEntityUomMaster objEntityUom)
        {
            string strQueryUomStatus = "UOM_MASTER.SP_UPDATE_STATUS";
            using (OracleCommand cmdUomStatus = new OracleCommand())
            {
                cmdUomStatus.CommandText = strQueryUomStatus;
                cmdUomStatus.CommandType = CommandType.StoredProcedure;
                cmdUomStatus.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
                cmdUomStatus.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUom.Unit_Status;
                cmdUomStatus.Parameters.Add("U_USERID", OracleDbType.Int32).Value = objEntityUom.User_Id;
                cmdUomStatus.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUom.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUomStatus);
            }
        }

        //Method for Updating uom Details
        public void UpdateUom(clsEntityUomMaster objEntityUom)
        {
            string strQueryUpdateUom = "UOM_MASTER.SP_UPDATE_UOM";
            using (OracleCommand cmdUpdateUom = new OracleCommand())
            {
                cmdUpdateUom.CommandText = strQueryUpdateUom;
                cmdUpdateUom.CommandType = CommandType.StoredProcedure;
                cmdUpdateUom.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
                cmdUpdateUom.Parameters.Add("U_NAME", OracleDbType.Varchar2).Value = objEntityUom.Uom_name;
                cmdUpdateUom.Parameters.Add("U_CODE", OracleDbType.Varchar2).Value = objEntityUom.Uom_Code;
                cmdUpdateUom.Parameters.Add("U_STATUS", OracleDbType.Int32).Value = objEntityUom.Unit_Status;
                cmdUpdateUom.Parameters.Add("U_UPDUSERID", OracleDbType.Int32).Value = objEntityUom.User_Id;
                cmdUpdateUom.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUom.D_Date;
                
                clsDataLayer.ExecuteNonQuery(cmdUpdateUom);
            }
        }
       
        //Method for cancel uom
        public void CancelUom(clsEntityUomMaster objEntityUom)
        {
            string strQueryCancelUom = "UOM_MASTER.SP_CANCEL_UOM";
            using (OracleCommand cmdCancelUom = new OracleCommand())
            {
                cmdCancelUom.CommandText = strQueryCancelUom;
                cmdCancelUom.CommandType = CommandType.StoredProcedure;
                cmdCancelUom.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
                cmdCancelUom.Parameters.Add("U_USERID", OracleDbType.Int32).Value = objEntityUom.User_Id;
                cmdCancelUom.Parameters.Add("U_DATE", OracleDbType.Date).Value = objEntityUom.D_Date;
                cmdCancelUom.Parameters.Add("U_REASON", OracleDbType.Varchar2).Value = objEntityUom.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelUom);
            }
        }

        // This Method checks uom name in the database for duplication.
        public string CheckUomName(clsEntityUomMaster objEntityUom)
        {
            string strQueryCheckUomName = "UOM_MASTER.SP_CHECK_UOM_NAME";
            OracleCommand cmdCheckUomName = new OracleCommand();
            cmdCheckUomName.CommandText = strQueryCheckUomName;
            cmdCheckUomName.CommandType = CommandType.StoredProcedure;
            cmdCheckUomName.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
            cmdCheckUomName.Parameters.Add("U_NAME", OracleDbType.Varchar2).Value = objEntityUom.Uom_name;
            cmdCheckUomName.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUom.Org_Id;
            cmdCheckUomName.Parameters.Add("U_CORPID", OracleDbType.Int32).Value = objEntityUom.Corp_Id;
            cmdCheckUomName.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUomName);
            string strReturn = cmdCheckUomName.Parameters["U_COUNT"].Value.ToString();
            cmdCheckUomName.Dispose();
            return strReturn;
        }

        // This Method checks uom code in the database for duplication.
        public string CheckUomCode(clsEntityUomMaster objEntityUom)
        {
            string strQueryCheckUomCode = "UOM_MASTER.SP_CHECK_UOM_CODE";
            OracleCommand cmdCheckUomCode = new OracleCommand();
            cmdCheckUomCode.CommandText = strQueryCheckUomCode;
            cmdCheckUomCode.CommandType = CommandType.StoredProcedure;
            cmdCheckUomCode.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
            cmdCheckUomCode.Parameters.Add("U_CODE", OracleDbType.Varchar2).Value = objEntityUom.Uom_Code;
            cmdCheckUomCode.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityUom.Org_Id;
            cmdCheckUomCode.Parameters.Add("U_CORPID", OracleDbType.Int32).Value = objEntityUom.Corp_Id;
            cmdCheckUomCode.Parameters.Add("U_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUomCode);
            string strReturn = cmdCheckUomCode.Parameters["U_COUNT"].Value.ToString();
            cmdCheckUomCode.Dispose();
            return strReturn;
        }

        // This Method will fetch Uom master table by ID
        public DataTable ReadUomById(clsEntityUomMaster objEntityUom)
        {
            string strQueryReadUomById = "UOM_MASTER.SP_READ_UOM_BYID";
            OracleCommand cmdReadUomById = new OracleCommand();
            cmdReadUomById.CommandText = strQueryReadUomById;
            cmdReadUomById.CommandType = CommandType.StoredProcedure;
            cmdReadUomById.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
            cmdReadUomById.Parameters.Add("U_UOM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadUomById);
            return dtBank;
        }
        //Method for cancelling Uom master so updating cancel related fields
        public void CancelUomMaster(clsEntityUomMaster objEntityUom)
        {
            string strQueryCancelUom = "UOM_MASTER.SP_CANCEL_UOM";
            using (OracleCommand cmdCancelUom = new OracleCommand())
            {
                cmdCancelUom.InitialLONGFetchSize = 1000;
                cmdCancelUom.CommandText = strQueryCancelUom;
                cmdCancelUom.CommandType = CommandType.StoredProcedure;
                cmdCancelUom.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityUom.Uom_Id;
                cmdCancelUom.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityUom.User_Id;
                cmdCancelUom.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityUom.D_Date;
                cmdCancelUom.Parameters.Add("T_REASON", OracleDbType.Varchar2).Value = objEntityUom.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelUom);
            }
        }

        public DataTable ReadUnitMasterTable(clsEntityUomMaster objEntityUom)
        {

            string strQueryAddState = "UOM_MASTER.SP_READ_UNITLIST";
            DataTable dtUOMTable = new DataTable();
            using (OracleCommand cmdReadUOM = new OracleCommand())
            {
                cmdReadUOM.CommandText = strQueryAddState;
                cmdReadUOM.CommandType = CommandType.StoredProcedure;
                cmdReadUOM.Parameters.Add("D_OPTION", OracleDbType.Int32).Value = objEntityUom.Unit_Status;
                cmdReadUOM.Parameters.Add("D_CANCEL", OracleDbType.Int32).Value = objEntityUom.Cancel_Status;
                cmdReadUOM.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityUom.Org_Id;
                cmdReadUOM.Parameters.Add("D_COPRID", OracleDbType.Int32).Value = objEntityUom.Corp_Id;

                cmdReadUOM.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityUom.CommonSearchTerm;
                cmdReadUOM.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityUom.SearchName;
                cmdReadUOM.Parameters.Add("M_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityUom.SearchCode;
                cmdReadUOM.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityUom.OrderColumn;
                cmdReadUOM.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityUom.OrderMethod;
                cmdReadUOM.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityUom.PageMaxSize;
                cmdReadUOM.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityUom.PageNumber;

                cmdReadUOM.Parameters.Add("D_UNIT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtUOMTable = clsDataLayer.ExecuteReader(cmdReadUOM);
            }
            return dtUOMTable;
        }

       

    }
}

