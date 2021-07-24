using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;


namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerFinanceHome
    {
        public DataTable LoadBankBookDtls(clsEntityCommon objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_FINANCE_HOME.SP_READ_BANK_BOOKS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorporateID;
            cmdReadPayGrd.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityEmpSlry.Date;
            cmdReadPayGrd.Parameters.Add("L_TYPEID", OracleDbType.Varchar2).Value = objEntityEmpSlry.PrimaryGrpIds;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable LoadDebtorDtls(clsEntityCommon objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_FINANCE_HOME.SP_READ_DEBTOR_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityEmpSlry.Date;
            cmdReadPayGrd.Parameters.Add("L_CORP_IDS", OracleDbType.Varchar2).Value = objEntityEmpSlry.CorprtIds;
            cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
            cmdReadPayGrd.Parameters.Add("L_ACCNTGRP_ID", OracleDbType.Varchar2).Value = objEntityEmpSlry.PrimaryGrpIds;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadRecurrnceList(clsEntityCommon objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_FINANCE_HOME.SP_READ_RECURR_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorporateID;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadRecurrnceOrderList(clsEntityCommon objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_FINANCE_HOME.SP_READ_RECURR_ORDER_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorporateID;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public void insertNewORders(List<clsEntityCommon> objEntityNewOrdersList)
        {
            foreach (clsEntityCommon objRecur in objEntityNewOrdersList)
                   {
                       string strQueryReadRcpt = "FMS_FINANCE_HOME.SP_INS_NEW_ORDERS";
                    OracleCommand cmdReadRcpt = new OracleCommand();
                    cmdReadRcpt.CommandText = strQueryReadRcpt;
                    cmdReadRcpt.CommandType = CommandType.StoredProcedure;
                    cmdReadRcpt.Parameters.Add("L_RECUR_ID", OracleDbType.Int32).Value = objRecur.RecurMasterId;
                    cmdReadRcpt.Parameters.Add("L_RECUR_DATE", OracleDbType.Date).Value = objRecur.RecurDate;
                    cmdReadRcpt.Parameters.Add("L_RECUR_STS", OracleDbType.Int32).Value = objRecur.SectionId;
                    cmdReadRcpt.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objRecur.RecurSubId;
                    clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
                   }
        }
        public DataTable ReadOrderDtls(clsEntityCommon objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_FINANCE_HOME.SP_READ_ORDER_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.RecurSubId;
            cmdReadPayGrd.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CorporateID;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void rejectOrders(clsEntityCommon objRecur)
        {
            string strQueryReadRcpt = "FMS_FINANCE_HOME.SP_REJECT_ORDERS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("L_RECUR_ID", OracleDbType.Int32).Value = objRecur.RecurSubId;
            cmdReadRcpt.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objRecur.RecurMasterId;
            clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
        }

        //EVM 040
        public DataTable SalesTotal(clsEntityCommon objEntity)
        {
            string strQueryReadRcpt = "FMS_FINANCE_HOME.SP_READ_SALES_TOTAL";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_FINCYR_ID", OracleDbType.Int32).Value = objEntity.FinancialYrId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.CorporateID;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        public DataTable PurchaseTotal(clsEntityCommon objEntity)
        {
            string strQueryReadRcpt = "FMS_FINANCE_HOME.SP_READ_PURCHASE_TOTAL";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_FINCYR_ID", OracleDbType.Int32).Value = objEntity.FinancialYrId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.CorporateID;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        //emp-0043 start
        public DataTable ProfitAndLossAcnt_List(clsEntityCommon objEntity)
        {
            string strQueryReadRcpt = "FMS_FINANCE_HOME.SP_READ_PROFIT_AND_LOSS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_FINCYR_ID", OracleDbType.Int32).Value = objEntity.FinancialYrId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.CorporateID;
            cmdReadRcpt.Parameters.Add("R_ZERO_STATUS", OracleDbType.Int32).Value = objEntity.ShowZerosts;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadFinsYear(clsEntityCommon ObjEntity)
        {
            string strQueryFinsYr = "FMS_FINANCE_HOME.SP_READ_FINCYR";
            OracleCommand cmdReadYear = new OracleCommand();
            cmdReadYear.CommandText = strQueryFinsYr;
            cmdReadYear.CommandType = CommandType.StoredProcedure;
            cmdReadYear.Parameters.Add("R_FINCYR", OracleDbType.Varchar2).Value = ObjEntity.strYears;
            cmdReadYear.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtYear = new DataTable();
            dtYear = clsDataLayer.ExecuteReader(cmdReadYear);
            return dtYear;
        }
        //end


    }
}
