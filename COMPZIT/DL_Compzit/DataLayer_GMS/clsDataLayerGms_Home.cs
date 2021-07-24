using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using CL_Compzit;


namespace DL_Compzit.DataLayer_GMS
{
    public class clsDataLayerGms_Home
    {
        public DataTable Read_IMS_DashBoard()
        {
            string strQueryReadBankGuarnt = "GMS_IMS_DASHBOARD.SP_READ_INS_STATUS_DASHBOARD";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable Read_BankGurnt_DashBoard()
        {
            string strQueryReadBankGuarnt = "GMS_IMS_DASHBOARD.SP_READ_BANKGURNT_DASHBOARD";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
    }
}
