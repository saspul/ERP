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
    public class clsDataLayerGmsReports
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        //this table will division details
        public DataTable ReadDivision(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadExpiredGurntyReprtList(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_EXP_BANKGURLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdReadBankGuarnt.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityBnkGuarnte.BankId;
      
            cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CATID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarCatgryId;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
           cmdReadBankGuarnt.Parameters.Add("B_CURRENCYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadCtagory(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_CATAGRY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable Read_Guarantee_List(clsEntityReports objEntityReport)
        {
            string strQueryReadProductList = "REPORTGMS.SP_READ_GUARANTY_LIST_BY_TYPE";
            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadProductList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadProductList.Parameters.Add("P_CAT_ID", OracleDbType.Int32).Value = objEntityReport.GuaranteeTypeId;
                cmdReadProductList.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityReport.GuaranteeModeId;
                cmdReadProductList.Parameters.Add("P_CURRENCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadProductList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }
        //method for fetching Category BASED ON Mode
        public DataTable Read_Category(clsEntityReports objEntityReport)
        {
            string strQueryReadCategory = "REPORTGMS.SP_READ_GUARANTY_TYPE";
            using (OracleCommand cmdReadCategory = new OracleCommand())
            {
                cmdReadCategory.CommandText = strQueryReadCategory;
                cmdReadCategory.CommandType = CommandType.StoredProcedure;
                cmdReadCategory.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadCategory.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;

                cmdReadCategory.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityReport.GuaranteeModeId;

                cmdReadCategory.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCategory = new DataTable();
                dtReadCategory = clsDataLayer.ExecuteReader(cmdReadCategory);
                return dtReadCategory;
            }
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityReports objEntRprt)
        {
            string strQueryReadCorp = "REPORTS.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntRprt.Corporate_Id;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntRprt.Organisation_Id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        //fetch client guarantee list
        public DataTable ReadClientGurntyReprtList(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_CLIENT_BANKGURLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;
            cmdReadBankGuarnt.Parameters.Add("B_SUPPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeTempID;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CURNCY", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadSuppGurntyReprtList(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_SUPPLR_BANKGURLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;
            cmdReadBankGuarnt.Parameters.Add("B_SUPPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuaranteeTempID;
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CURRENCYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        //fetch project list from database.
        public DataTable ReadProject(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_PROJECT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;
    
            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        // TO FETCH PROJECT WISE GUARANTEE REPORT
        public DataTable ReadGurntyReprtProjctWise(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_PRJCTWISE_BANKGURLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            cmdReadBankGuarnt.Parameters.Add("B_PRJCTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ProjctId;
            cmdReadBankGuarnt.Parameters.Add("B_CATID", OracleDbType.Int32).Value = objEntityBnkGuarnte.GuarCatgryId;
            cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;

            cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CURNCY", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable getDataSuppliGuar(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarntSuppli = "SUPPLIER_REPORT.SP_SUPPLR_BANKGURLIST";
            OracleCommand cmdReadBankGuarntSuppli = new OracleCommand();
            cmdReadBankGuarntSuppli.CommandText = strQueryReadBankGuarntSuppli;
            cmdReadBankGuarntSuppli.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarntSuppli.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Division_Id;
            cmdReadBankGuarntSuppli.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarntSuppli.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarntSuppli.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarntSuppli.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarntSuppli);
            return dtCategory;
        }
        public DataTable Read_Expiry_LIstDetails(clsEntityReports objEntityReport)
        {
            string strQueryReadProductList = "REPORTGMS.SP_READ_GUARANTY_LIST_EXPIRY";

            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                //        if(objEntityReport.GuaranteeExpiryRangeTO==new DateTime())
                //{
                //    objEntityReport.GuaranteeExpiryRangeTO = null;          
                //}
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadProductList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadProductList.Parameters.Add("P_CAT_ID", OracleDbType.Int32).Value = objEntityReport.GuaranteeTypeId;
                cmdReadProductList.Parameters.Add("P_TEMP", OracleDbType.Int32).Value = objEntityReport.GuaranteeTempID;
                cmdReadProductList.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityReport.GuaranteeExpiryRangeTO;
                cmdReadProductList.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadProductList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }

        //--EVM-0014 Get Supplier wise report
        public DataTable Fetch_Division(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        //--EVM-0014 Get Supplier wise report
        public DataTable Fetch_Bank(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_BANK";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
                 cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable READ_SUPPLIER(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_SUPPLIER";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable READ_Client(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_CLIENT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable Read_MailTrackingDetails(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "GMS_REPORTS.READ_MAILTRACKING";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;

            cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
                public DataTable ReadCurrency(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READ_CURRENCY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadDefualtCurrency(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "BANK_GUARANTEE.SP_READDEFLT_CURRENCY";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

    
    }
}
