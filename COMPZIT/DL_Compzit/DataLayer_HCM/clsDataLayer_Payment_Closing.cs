using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Payment_Closing
    {
        // Read Monthly Salary Details
        public DataTable ReadMonthlySal_List(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryList = "HCM_PAYMENT_CLOSING.SP_READ_MONTHLYSAL_LIST";
            OracleCommand cmdReadSalaryList = new OracleCommand();
            cmdReadSalaryList.CommandText = strQueryReadSalaryList;
            cmdReadSalaryList.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
            cmdReadSalaryList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
            cmdReadSalaryList.Parameters.Add("P_SAVCONF", OracleDbType.Int32).Value = objEntityPaymtCls.SavConf;
            cmdReadSalaryList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryList);
            return dtSalList;
        }

        // Read Salary details By Id
        public DataTable ReadMonthlySal_ListById(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryListById = "HCM_PAYMENT_CLOSING.SP_READ_MONTHLYSAL_LISTBY_USR";
            OracleCommand cmdReadSalaryListById = new OracleCommand();
            cmdReadSalaryListById.CommandText = strQueryReadSalaryListById;
            cmdReadSalaryListById.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryListById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
            cmdReadSalaryListById.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryListById.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
            cmdReadSalaryListById.Parameters.Add("P_SAVCONF", OracleDbType.Int32).Value = objEntityPaymtCls.SavConf;
            cmdReadSalaryListById.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryListById);
            return dtSalList;
        }

        

        public void ReadMonthlySal_PrsClose(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryPrsCls = "HCM_PAYMENT_CLOSING.SP_SALARYPROCESS_CLOSE";
            OracleCommand cmdReadSalaryPrsCls = new OracleCommand();
            cmdReadSalaryPrsCls.CommandText = strQueryReadSalaryPrsCls;
            cmdReadSalaryPrsCls.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryPrsCls.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
            cmdReadSalaryPrsCls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryPrsCls.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteReader(cmdReadSalaryPrsCls);

        }

        public DataTable ReadMonthlySal_PaidList(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryPaidList = "HCM_PAYMENT_CLOSING.SP_SALARY_PAID_LIST";
            OracleCommand cmdReadSalaryPaidList = new OracleCommand();
            cmdReadSalaryPaidList.CommandText = strQueryReadSalaryPaidList;
            cmdReadSalaryPaidList.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryPaidList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
            cmdReadSalaryPaidList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryPaidList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPaymtCls.CorprtId;
            cmdReadSalaryPaidList.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
            cmdReadSalaryPaidList.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityPaymtCls.Month;
            cmdReadSalaryPaidList.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPaymtCls.Year;
            cmdReadSalaryPaidList.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityPaymtCls.Staff_Worker;
            cmdReadSalaryPaidList.Parameters.Add("P_BSNS_UNT", OracleDbType.Int32).Value = objEntityPaymtCls.BusnsUnitId;
            if (objEntityPaymtCls.date != DateTime.MinValue)
            {
                cmdReadSalaryPaidList.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPaymtCls.date;
            }
            else
            {
               cmdReadSalaryPaidList.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadSalaryPaidList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryPaidList);
            return dtSalList;
        }

        public DataTable ReadBsnsUnits(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryPaidList = "HCM_PAYMENT_CLOSING.SP_READ_BUSNS_UNITS";
            OracleCommand cmdReadSalaryPaidList = new OracleCommand();
            cmdReadSalaryPaidList.CommandText = strQueryReadSalaryPaidList;
            cmdReadSalaryPaidList.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryPaidList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryPaidList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryPaidList);
            return dtSalList;
        }
        public void closePayment(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryAddConsultancyMstr = "HCM_PAYMENT_CLOSING.SP_CLOSE_PAYMENT";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPaymtCls.CloseId;
                cmdAddConsultancyMstr.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityPaymtCls.UserId;
                cmdAddConsultancyMstr.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
                cmdAddConsultancyMstr.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPaymtCls.date;
                cmdAddConsultancyMstr.Parameters.Add("P_PAID_AMNT", OracleDbType.Decimal).Value = objEntityPaymtCls.PaidAmnt;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }
        public DataTable ReadPayment_paidedList(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            string strQueryReadSalaryPaidedList = "HCM_PAYMENT_CLOSING.SP_lIST_AFTER_PAID";
            OracleCommand cmdReadSalaryPaidList = new OracleCommand();
            cmdReadSalaryPaidList.CommandText = strQueryReadSalaryPaidedList;
            cmdReadSalaryPaidList.CommandType = CommandType.StoredProcedure;
            cmdReadSalaryPaidList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPaymtCls.OrgId;
            cmdReadSalaryPaidList.Parameters.Add("P_CORPRTID", OracleDbType.Int32).Value = objEntityPaymtCls.CorprtId;
            cmdReadSalaryPaidList.Parameters.Add("P_MONTH", OracleDbType.Varchar2).Value = objEntityPaymtCls.SMonth;
            cmdReadSalaryPaidList.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPaymtCls.Year;
            cmdReadSalaryPaidList.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPaymtCls.Mode;
            cmdReadSalaryPaidList.Parameters.Add("P_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalList = new DataTable();
            dtSalList = clsDataLayer.ExecuteReader(cmdReadSalaryPaidList);
            return dtSalList;
        }

    }
}
