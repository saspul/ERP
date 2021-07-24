using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDatalayerPayroll
    {

        // This Method add the Payroll details to the table
        public void Add_Payroll_Details(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryPayrol = "PAYROLL_MASTER.SP_ADD_PAYROLL";
            using (OracleCommand cmdReadPayroll  = new OracleCommand())
            {
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                cmdReadPayroll.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayrl.Organisation_Id;
                cmdReadPayroll.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayrl.CorpOffice_Id;
                cmdReadPayroll.Parameters.Add("P_INSUSRID", OracleDbType.Int32).Value = objEntityPayrl.User_Id;
                cmdReadPayroll.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPayrl.Name;
                cmdReadPayroll.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPayrl.Status;
                cmdReadPayroll.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPayrl.Mode;
                cmdReadPayroll.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityPayrl.InsDateTime;
                cmdReadPayroll.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityPayrl.PayrollType;
                cmdReadPayroll.Parameters.Add("P_PRIMAY", OracleDbType.Int32).Value = objEntityPayrl.PrimaryStatus;
                cmdReadPayroll.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityPayrl.Code;
                cmdReadPayroll.Parameters.Add("P_DIRECT_STS", OracleDbType.Int32).Value = objEntityPayrl.DirectPaymentSts;


               // cmdReadPayroll.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdReadPayroll );
            }
        }

        //methode for fetch the payroll details from the data
        public DataTable Fetch_Payroll_Details_List(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryReadPayrl = "PAYROLL_MASTER.SP_READ_PAYROLL_LIST";
            using (OracleCommand cmdReadPayrol = new OracleCommand())
            {
                cmdReadPayrol.CommandText = strQueryReadPayrl;
                cmdReadPayrol.CommandType = CommandType.StoredProcedure;
                cmdReadPayrol.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPayrl.Status;
                cmdReadPayrol.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityPayrl.Cancel_Status;
                cmdReadPayrol.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayrl.Organisation_Id;
                cmdReadPayrol.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayrl.CorpOffice_Id;
                cmdReadPayrol.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayrl.User_Id;


                cmdReadPayrol.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPayrl.CommonSearchTerm;
                cmdReadPayrol.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityPayrl.SearchName;
                cmdReadPayrol.Parameters.Add("P_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityPayrl.SearchCode;
                cmdReadPayrol.Parameters.Add("P_SEARCH_MODE", OracleDbType.Varchar2).Value = objEntityPayrl.SearchMode;

                cmdReadPayrol.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPayrl.OrderColumn;
                cmdReadPayrol.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPayrl.OrderMethod;
                cmdReadPayrol.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPayrl.PageMaxSize;
                cmdReadPayrol.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPayrl.PageNumber;


                cmdReadPayrol.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPayrl = new DataTable();
                dtPayrl = clsDataLayer.SelectDataTable(cmdReadPayrol);
                return dtPayrl;
            }
        }


         public DataTable Fetch_Payroll_Details(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryReadPayrl = "PAYROLL_MASTER.SP_READ_PAYROLL";
            using (OracleCommand cmdReadPayrol = new OracleCommand())
            {
                cmdReadPayrol.CommandText = strQueryReadPayrl;
                cmdReadPayrol.CommandType = CommandType.StoredProcedure;
                cmdReadPayrol.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPayrl.Status;
                cmdReadPayrol.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityPayrl.Cancel_Status;
                cmdReadPayrol.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayrl.Organisation_Id;
                cmdReadPayrol.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayrl.CorpOffice_Id;
                cmdReadPayrol.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayrl.User_Id;
                cmdReadPayrol.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPayrl = new DataTable();
                dtPayrl = clsDataLayer.SelectDataTable(cmdReadPayrol);
                return dtPayrl;
            }
        }

        public void Update_Payroll(clsEntityLayerPayroll objEntityPayrol)
        {
            string strQueryPayrol = "PAYROLL_MASTER.SP_UPDT_PAYROLL";
            using (OracleCommand cmdReadPayroll = new OracleCommand())
            {
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                cmdReadPayroll.Parameters.Add("P_UPDUSRID", OracleDbType.Int32).Value = objEntityPayrol.User_Id;
                cmdReadPayroll.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayrol.Payrl_ID;
                cmdReadPayroll.Parameters.Add("P_UPDNAME", OracleDbType.Varchar2).Value = objEntityPayrol.UpdName;
                cmdReadPayroll.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPayrol.Status;
                cmdReadPayroll.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPayrol.Mode;
                cmdReadPayroll.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = objEntityPayrol.UpdDateTime;
                cmdReadPayroll.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityPayrol.PayrollType;
                cmdReadPayroll.Parameters.Add("P_PRIMAY", OracleDbType.Int32).Value = objEntityPayrol.PrimaryStatus;
                cmdReadPayroll.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityPayrol.Code;
                cmdReadPayroll.Parameters.Add("P_DIRECT_STS", OracleDbType.Int32).Value = objEntityPayrol.DirectPaymentSts;
                // cmdReadPayroll.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdReadPayroll);
            }

        }
        public void Change_Status(clsEntityLayerPayroll objEntityPayrol)
        {
            string strQueryPayrol = "PAYROLL_MASTER.SP_CHANGE_STS_PAYROLL";
            using (OracleCommand cmdReadPayroll = new OracleCommand())
            {
                cmdReadPayroll.CommandText = strQueryPayrol;
                cmdReadPayroll.CommandType = CommandType.StoredProcedure;
                cmdReadPayroll.Parameters.Add("P_PAYRLID", OracleDbType.Int32).Value = objEntityPayrol.Payrl_ID;
                cmdReadPayroll.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPayrol.Status;            
                // cmdReadPayroll.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdReadPayroll);
            }

        }

        //Method for cancel Payroll
        public void Cancel_Payroll(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryCancelJobCat = "PAYROLL_MASTER.SP_CANCEL_PAYRL";
            using (OracleCommand cmdCancelJobCat = new OracleCommand())
            {
                cmdCancelJobCat.CommandText = strQueryCancelJobCat;
                cmdCancelJobCat.CommandType = CommandType.StoredProcedure;
                cmdCancelJobCat.Parameters.Add("P_PAYRLID", OracleDbType.Int32).Value = objEntityPayrl.Payrl_ID;
                cmdCancelJobCat.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayrl.CnclUser_Id;
                cmdCancelJobCat.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayrl.CnclDateTime;
                cmdCancelJobCat.Parameters.Add("P_REASON", OracleDbType.Varchar2).Value = objEntityPayrl.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelJobCat);
            }
        }
        //Fetch Payrl name 
        public string Fetch_Payroll_Name(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryView = "PAYROLL_MASTER.SP_CHECK_PAYRL_NAME";
            OracleCommand cmdUpdDetail = new OracleCommand();
                  cmdUpdDetail.CommandText = strQueryView;
                cmdUpdDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdDetail.Parameters.Add("P_PAYRL_ID", OracleDbType.Int32).Value = objEntityPayrl.Payrl_ID;
                cmdUpdDetail.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPayrl.Name;
                cmdUpdDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayrl.Organisation_Id;
                cmdUpdDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayrl.CorpOffice_Id;
                cmdUpdDetail.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdUpdDetail);
                string strReturn = cmdUpdDetail.Parameters["P_COUNT"].Value.ToString();
                cmdUpdDetail.Dispose();
                return strReturn;
            
        }
        public string FetchPayrollCode(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryView = "PAYROLL_MASTER.SP_CHECK_PAYRL_CODE";
            OracleCommand cmdUpdDetail = new OracleCommand();
            cmdUpdDetail.CommandText = strQueryView;
            cmdUpdDetail.CommandType = CommandType.StoredProcedure;
            cmdUpdDetail.Parameters.Add("P_PAYRL_ID", OracleDbType.Int32).Value = objEntityPayrl.Payrl_ID;
            cmdUpdDetail.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityPayrl.Code;
            cmdUpdDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayrl.Organisation_Id;
            cmdUpdDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayrl.CorpOffice_Id;
            cmdUpdDetail.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdUpdDetail);
            string strReturn = cmdUpdDetail.Parameters["P_COUNT"].Value.ToString();
            cmdUpdDetail.Dispose();
            return strReturn;

        }
        //Fetch data by Id 
        public DataTable getDataById(clsEntityLayerPayroll objEntityPayrl)
        {
            string strQueryView = "PAYROLL_MASTER.SP_GET_DATABYID";
            using (OracleCommand cmdUpdDetail = new OracleCommand())
            {
                cmdUpdDetail.CommandText = strQueryView;
                cmdUpdDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdDetail.Parameters.Add("P_PAYRL", OracleDbType.Int32).Value = objEntityPayrl.Payrl_ID;               
                cmdUpdDetail.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdUpdDetail);
                return dtCheckOrg;
            }
        }
    }
}
