using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_DayBook
    {
        public DataTable ReadTransactionMode(clsEntity_DayBook objEntity)
        {
            string strQueryReadMode = "FMS_DAY_BOOK.SP_READ_TRANSCATIONMODE";
            OracleCommand cmdReadMode = new OracleCommand();
            cmdReadMode.CommandText = strQueryReadMode;
            cmdReadMode.CommandType = CommandType.StoredProcedure;
            cmdReadMode.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadMode);
            return dtCategory;
        }
        public DataTable ReadDayBook(clsEntity_DayBook objEntity)
        {
            string strQueryReadDayBook = "FMS_DAY_BOOK.SP_READ_DAY_BOOK";
            OracleCommand cmdReadDayBook = new OracleCommand();
            cmdReadDayBook.CommandText = strQueryReadDayBook;
            cmdReadDayBook.CommandType = CommandType.StoredProcedure;
            cmdReadDayBook.Parameters.Add("R_DATE", OracleDbType.Date).Value = objEntity.DayBook_Date;
            cmdReadDayBook.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntity.TransactionType;
            cmdReadDayBook.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadDayBook.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
            cmdReadDayBook.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDayBook);
            return dtCategory;
        }
    }
}
