using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Configuration;
using HashingUtility;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDatalayerOpeningLeaveAlloc
    {
        public DataTable ReadUsers(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            string strCommandText = "LEAVE_ALLOCATION.SP_READ_USERS";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.OrgId;
                cmdGrid.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.CorpId;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityOpngLvAlloc.UserSts;
                cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityOpngLvAlloc.CancelSts;
                cmdGrid.Parameters.Add("C_DSGNID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.DesignationId;
                cmdGrid.Parameters.Add("C_LIMITEDORNOT", OracleDbType.Int32).Value = objEntityOpngLvAlloc.LimitedUsrId;
                cmdGrid.Parameters.Add("U_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUsers = new DataTable();
                dtUsers = clsDataLayer.SelectDataTable(cmdGrid);
                return dtUsers;
            }
        }
        public DataTable ReadLeaveTypes(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            string strCommandText = "LEAVE_ALLOCATION.SP_READ_LEAVE_TYPES";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.OrgId;
                cmdGrid.Parameters.Add("L_CRPRT_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.CorpId;
                cmdGrid.Parameters.Add("L_LTYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeaveType = new DataTable();
                dtLeaveType = clsDataLayer.SelectDataTable(cmdGrid);
                return dtLeaveType;
            }
        }
        public void InsertLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            try
            {
                string strCommandText = "LEAVE_ALLOCATION.SP_INSERT_LEAVE_ALLOC";
                using (OracleCommand cmdGrid = new OracleCommand())
                {
                    cmdGrid.CommandText = strCommandText;
                    cmdGrid.CommandType = CommandType.StoredProcedure;
                    cmdGrid.Parameters.Add("O_USER_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.EmployeeId;
                    cmdGrid.Parameters.Add("O_LEAVE_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.LeaveType;
                    cmdGrid.Parameters.Add("O_NUMB_LEAVE", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.OpeningLeaveNumb;
                    cmdGrid.Parameters.Add("O_BLNC_NUMB_LEAVE", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.BalanceLeaveNumb;
                    cmdGrid.Parameters.Add("O_LEAVE_AMNT", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.LeaveAmount;
                    cmdGrid.Parameters.Add("O_BLNC_LEAVE_AMNT", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.BalanceLeaveAmount;                
                    cmdGrid.Parameters.Add("O_YEAR", OracleDbType.Int32).Value = objEntityOpngLvAlloc.LeaveYear;       
                    //20-03-2019
                    cmdGrid.Parameters.Add("O_ORGID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.OrgId;
                    cmdGrid.Parameters.Add("O_CORPID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.CorpId;
                    //end
                    clsDataLayer.ExecuteNonQuery(cmdGrid);
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }
        public void UpdateLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            string strCommandText = "LEAVE_ALLOCATION.SP_UPDATE_LEAVE_ALLOC";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("O_OPNG_LVTYP_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.UsrerId;
                cmdGrid.Parameters.Add("O_NUMB_LEAVE", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.OpeningLeaveNumb;
                cmdGrid.Parameters.Add("O_BLNC_NUMB_LEAVE", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.BalanceLeaveNumb;
                cmdGrid.Parameters.Add("O_LEAVE_AMNT", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.LeaveAmount;
                cmdGrid.Parameters.Add("O_BLNC_LEAVE_AMNT", OracleDbType.Decimal).Value = objEntityOpngLvAlloc.BalanceLeaveAmount;
                cmdGrid.Parameters.Add("O_YEAR", OracleDbType.Int32).Value = objEntityOpngLvAlloc.LeaveYear;               
                clsDataLayer.ExecuteNonQuery(cmdGrid);
            }
        }
        public void ConfirmLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            string strCommandText = "LEAVE_ALLOCATION.SP_CONFIRM_LEAVE_ALLOC";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("O_USER_ID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.UsrerId;
                cmdGrid.Parameters.Add("O_CNFRM_STS", OracleDbType.Int32).Value = objEntityOpngLvAlloc.ConfirmSts;
                cmdGrid.Parameters.Add("O_CNFRM_USRID", OracleDbType.Int32).Value = objEntityOpngLvAlloc.ConfirmUserId;
                clsDataLayer.ExecuteNonQuery(cmdGrid);
            }
        }
    }
}
