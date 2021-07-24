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
   public class clsDataLayer_Account_Close
    {
       public void InsertAccountClosing(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_INSERT_ACCOUNT_CLOSE";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_CLOSE_DATE", OracleDbType.Date).Value = objEntity.FromDate;                           
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
               cmdReadPayGrd.Parameters.Add("P_YEAREND_STS", OracleDbType.Int32).Value = objEntity.YearEndStatus;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }


       public DataTable ReadCloseDates(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_READ_CLS_DATE_LIST";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_FISCALYR_ID", OracleDbType.Int32).Value = objEntity.FinancialYrId;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable ReadOutStandingBal(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_READ_OUTSTND_BALANCE_LIST";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("FROM_DATE", OracleDbType.Date).Value = objEntity.FromDate;
           cmdReadPayGrd.Parameters.Add("TO_DATE", OracleDbType.Date).Value = objEntity.CurrentDate;
           cmdReadPayGrd.Parameters.Add("ACCNT_GRPID", OracleDbType.Int32).Value = objEntity.AccntGrpid;
           
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable ReadAccntGrpList(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_READ_ACCOUNT_GRP_LIST";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
          

           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable CheckAccountClosingDate(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CHECK_ACCNTCLS_DATE";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("FROM_DATE", OracleDbType.Date).Value = objEntity.FromDate;

           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable CheckAccountClsDateCnclSts(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CHECK_ACCNTCLS_CNCLSTS";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ACCNTCLSID", OracleDbType.Int32).Value = objEntity.AccountClsId;
       
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }



       public void CancelAccntClsDate(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CNCL_ACCOUNT_CLOSE_DATE";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AccountClsId;
               cmdReadPayGrd.Parameters.Add("J_CNCL_REASON", OracleDbType.Varchar2).Value = objEntity.Cancel_Reason;
               cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntity.User_Id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }

       public void ConfirmAccntClsDate(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CNFRM_ACCOUNT_CLOSE_DATE";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AccountClsId;
               cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntity.User_Id;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }
       public DataTable CheckAccountClsDateConfirmStatus(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CKECK_CNFRM_DATE";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AccountClsId;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable CheckNonConfirmStatus(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CKECK_NON_CONFIRM";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public DataTable CheckYearEndClose(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CKECK_YEAREND";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_FISCALYR_ID", OracleDbType.Int32).Value = objEntity.FinancialYrId;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }
       public void RecallAccountClose(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_RECALL_ACCOUNT_CLOSE";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AccountClsId;
               cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntity.User_Id;
               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }

       public DataTable CheckYearEndClosingDate(clsEntityLayer_Account_Close objEntity)
       {
           string strQueryReadPayGrd = "ACCOUNT_CLOSE.SP_CHECK_YEAREND_CLSDATE";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntity.FromDate;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }


    }
}
