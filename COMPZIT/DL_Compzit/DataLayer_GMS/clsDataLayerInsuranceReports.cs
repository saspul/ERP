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
    public class clsDataLayerInsuranceReports
    {

        public DataTable ReadDivision(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            string strQueryRead = "GMS_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadInsure = new OracleCommand();
            cmdReadInsure.CommandText = strQueryRead;
            cmdReadInsure.CommandType = CommandType.StoredProcedure;
            cmdReadInsure.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.User_Id;
            cmdReadInsure.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Organisation_Id;
            cmdReadInsure.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Corporate_Id;
            cmdReadInsure.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadInsure);
            return dtDivision;
        }


        public DataTable ReadCurrency(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            string strQueryRead = "INSURANCE_REPORTS.SP_READ_CURRENCY";
            OracleCommand cmdReadInsure = new OracleCommand();
            cmdReadInsure.CommandText = strQueryRead;
            cmdReadInsure.CommandType = CommandType.StoredProcedure;
            //cmdReadInsure.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.User_Id;
            cmdReadInsure.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Organisation_Id;
            cmdReadInsure.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Corporate_Id;
            cmdReadInsure.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCurrency = new DataTable();
            dtCurrency = clsDataLayer.ExecuteReader(cmdReadInsure);
            return dtCurrency;
        }
        public DataTable ReadDefualtCurrency(clsEntityInsuraceReports ObjEntityInsuraceReports)
        {
            string strQueryRead = "INSURANCE_REPORTS.SP_READDEFLT_CURRENCY";
            OracleCommand cmdReadInsure = new OracleCommand();
            cmdReadInsure.CommandText = strQueryRead;
            cmdReadInsure.CommandType = CommandType.StoredProcedure;
            //cmdReadInsure.Parameters.Add("B_USERID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.User_Id;
            cmdReadInsure.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Organisation_Id;
            cmdReadInsure.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = ObjEntityInsuraceReports.Corporate_Id;
            cmdReadInsure.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDefuCurrency = new DataTable();
            dtDefuCurrency = clsDataLayer.ExecuteReader(cmdReadInsure);
            return dtDefuCurrency;
        }



        public DataTable Read_ExpiryRange_LIstDetails(clsEntityInsuraceReports objEntityInsReport)
        {
            string strQueryReadProductList = "INSURANCE_REPORTS.SP_READ_INSURE_RANGE_EXPIRY";

            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = strQueryReadProductList;
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityInsReport.Corporate_Id;
                cmdReadList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityInsReport.Organisation_Id;
                cmdReadList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityInsReport.User_Id;
                cmdReadList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityInsReport.Division_Id;
                cmdReadList.Parameters.Add("P_TEMP", OracleDbType.Int32).Value = objEntityInsReport.InsurTempID;
                cmdReadList.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityInsReport.InsurExpiryRangeTO;
                cmdReadList.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityInsReport.CurrencyId;
                cmdReadList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadList = new DataTable();
                dtReadList = clsDataLayer.SelectDataTable(cmdReadList);
                return dtReadList;
            }
        }

        public DataTable ReadCorporateAddress(clsEntityInsuraceReports objEntRprt)
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
    }
}
