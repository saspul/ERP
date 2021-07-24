using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class cls_Data_Bulk_LabourCard_Print
    {
        public DataTable LoadDep(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "BULK_LABOUR_CARD_PRINT.SP_READ_DEPARTMENT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadEmployeeCode(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string strQueryReadEmploy = "BULK_LABOUR_CARD_PRINT.SP_READ_EMPLOYEE_CODE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpOffice;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
 
        public DataTable ReadEmployeeDetailsList(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string strQueryReadEmploy = "BULK_LABOUR_CARD_PRINT.SP_READ_EMPLOYEE_DTLS_LIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpOffice;
            cmdReadEmp.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityBulkPrint.Month;
            cmdReadEmp.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            cmdReadEmp.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntityBulkPrint.Dep;
            cmdReadEmp.Parameters.Add("P_STAF_WORKER", OracleDbType.Int32).Value = objEntityBulkPrint.StffWrkr;
            cmdReadEmp.Parameters.Add("P_EMP_FIRST", OracleDbType.Int32).Value = objEntityBulkPrint.EmpIdFirst;
            cmdReadEmp.Parameters.Add("P_EMP_SECOND", OracleDbType.Int32).Value = objEntityBulkPrint.EmpIdSecond;
            cmdReadEmp.Parameters.Add("P_PRINT_STS", OracleDbType.Int32).Value = objEntityBulkPrint.Print_Sts;
            cmdReadEmp.Parameters.Add("P_MAIL_STS", OracleDbType.Int32).Value = objEntityBulkPrint.Mail_Sts;

            cmdReadEmp.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityBulkPrint.CommonSearchTerm;
            cmdReadEmp.Parameters.Add("P_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityBulkPrint.SearchCode;
            cmdReadEmp.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityBulkPrint.SearchName;
            cmdReadEmp.Parameters.Add("P_SEARCH_DESG", OracleDbType.Varchar2).Value = objEntityBulkPrint.SearchDesignation;
            cmdReadEmp.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityBulkPrint.OrderColumn;
            cmdReadEmp.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityBulkPrint.OrderMethod;
            cmdReadEmp.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityBulkPrint.PageMaxSize;
            cmdReadEmp.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityBulkPrint.PageNumber;

            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        public DataTable LoadSalaryPrssPaymentTable(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "BULK_LABOUR_CARD_PRINT.SP_READ_EMP_PYMNT_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //EVM-0027
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Varchar2).Value = objEntityBulkPrint.MultipleEmpId;
            //ENd
            cmdReadPayGrd.Parameters.Add("P_PAIDFINSH", OracleDbType.Int32).Value = objEntityBulkPrint.PaidFinish;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityBulkPrint.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            string pmonth = objEntityBulkPrint.Month.ToString("00");
            //pdate.Month.ToString();
            string pyear = objEntityBulkPrint.Year.ToString();
            //pdate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadPayGrd.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        //EVM-0043
        public DataTable EmailIdFetch(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string StrQueryFetchmail = "BULK_LABOUR_CARD_PRINT.SP_GET_MAIL_ID";
            OracleCommand cmdGetEmail = new OracleCommand();
            cmdGetEmail.CommandText = StrQueryFetchmail;
            cmdGetEmail.CommandType = CommandType.StoredProcedure;
            cmdGetEmail.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityBulkPrint.UserId;
            cmdGetEmail.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMail = new DataTable();
            dtMail = clsDataLayer.ExecuteReader(cmdGetEmail);
            return dtMail;
        }

        public void UpdateEmail(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            string StrQueryUpdatemail = "BULK_LABOUR_CARD_PRINT.SP_UPDATE_MAIL";
            OracleCommand cmdUpdateEmail = new OracleCommand();
            cmdUpdateEmail.CommandText = StrQueryUpdatemail;
            cmdUpdateEmail.CommandType = CommandType.StoredProcedure;
            cmdUpdateEmail.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityBulkPrint.UserId;
            cmdUpdateEmail.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityBulkPrint.Month;
            cmdUpdateEmail.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            clsDataLayer.ExecuteNonQuery(cmdUpdateEmail);
        }
        //EVM-0043 END

    }
}
