using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:15/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerDateAndTime
    {
        //Method for fetch date and time from server
        public DateTime DateAndTime()
        {
            string strQueryDateTime = "DATE_AND_TIME.SP_READ_DATE_AND_TIME";
            OracleCommand cmdDateTime = new OracleCommand();
            cmdDateTime.CommandText = strQueryDateTime;
            cmdDateTime.CommandType = CommandType.StoredProcedure;
            cmdDateTime.Parameters.Add("D_DATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtDate= clsDataLayer.ExecuteReader(cmdDateTime);
           DateTime dReturn = Convert.ToDateTime(dtDate.Rows[0]["SYSDATE"]);
            cmdDateTime.Dispose();
            return dReturn;
        }


        //Method for fetch date and time from server in string in 'dd-mm-yyyy'
        public string DateAndTimeString()
        {
            string strQueryDateTime = "DATE_AND_TIME.SP_READ_DATE_AND_TIME_IN_STR";
            OracleCommand cmdDateTime = new OracleCommand();
            cmdDateTime.CommandText = strQueryDateTime;
            cmdDateTime.CommandType = CommandType.StoredProcedure;
            cmdDateTime.Parameters.Add("STR_DATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDate = clsDataLayer.ExecuteReader(cmdDateTime);
            string strReturn = Convert.ToString(dtDate.Rows[0]["STRDATE"]);
        
            cmdDateTime.Dispose();
            return strReturn;
        }

    
    }
}
