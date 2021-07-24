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
  public  class clsDataLayerInsReports
    {


      public DataTable ReadDivision(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "INSURANCE_REPORTS.SP_READ_DIVISION";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }
      public DataTable ReadCurrency(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "INSURANCE_REPORTS.SP_READ_CURRENCY";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }
      public DataTable Read_Insurance_Expiry_Details(clsEntityReports objEntityReport)
      {
          string strQueryImsReports = "INSURANCE_REPORTS.SP_READ_INSURANCE_EXPIRY";

          using (OracleCommand cmdReadInsurance = new OracleCommand())
          {
              cmdReadInsurance.CommandText = strQueryImsReports;
              cmdReadInsurance.CommandType = CommandType.StoredProcedure;
              cmdReadInsurance.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
              cmdReadInsurance.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
              cmdReadInsurance.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
              cmdReadInsurance.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
              //cmdReadInsurance.Parameters.Add("P_CAT_ID", OracleDbType.Int32).Value = objEntityReport.GuaranteeTypeId;
              cmdReadInsurance.Parameters.Add("P_PROVIDER", OracleDbType.Int32).Value = objEntityReport.InsuranceProvider;
              //cmdReadInsurance.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityReport.GuaranteeExpiryRangeTO;
              cmdReadInsurance.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
              cmdReadInsurance.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtReadProductList = new DataTable();
              dtReadProductList = clsDataLayer.SelectDataTable(cmdReadInsurance);
              return dtReadProductList;
          }
      }
      public DataTable Read_Insurance_Project_Wise(clsEntityReports objEntityReport)
      {
          string strQueryImsReports = "INSURANCE_REPORTS.SP_READ_INSURANCE_PROJECT_WISE";

          using (OracleCommand cmdReadInsurance = new OracleCommand())
          {
              cmdReadInsurance.CommandText = strQueryImsReports;
              cmdReadInsurance.CommandType = CommandType.StoredProcedure;
              cmdReadInsurance.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
              cmdReadInsurance.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
              cmdReadInsurance.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
              cmdReadInsurance.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
              //cmdReadInsurance.Parameters.Add("P_CAT_ID", OracleDbType.Int32).Value = objEntityReport.GuaranteeTypeId;
              cmdReadInsurance.Parameters.Add("P_PROJECT", OracleDbType.Int32).Value = objEntityReport.ProjctId;
              //cmdReadInsurance.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityReport.GuaranteeExpiryRangeTO;
              cmdReadInsurance.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
              cmdReadInsurance.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtReadProductList = new DataTable();
              dtReadProductList = clsDataLayer.SelectDataTable(cmdReadInsurance);
              return dtReadProductList;
          }
      }
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

      public DataTable ReadDefualtCurrency(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "INSURANCE_REPORTS.SP_READDEFLT_CURRENCY";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }
      public DataTable ReadInsuranceProvider(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "INSURANCE_REPORTS.SP_READ_INSURANCE_PROVIDER";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }
      public DataTable ReadProject(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "GMS_REPORTS.SP_READ_PROJECT";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityInsurance.Division_Id;

          cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }
      public DataTable ReadInsurance_Type(clsEntityReports objEntityInsurance)
      {
          string strQueryReadBankGuarnt = "INSURANCE_REPORTS.SP_READ_INSURANCE_TYPE";
          OracleCommand cmdReadBankGuarnt = new OracleCommand();
          cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
          cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
          //cmdReadBankGuarnt.Parameters.Add("B_DIVID", OracleDbType.Int32).Value = objEntityInsurance.Division_Id;

          cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
          cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_Id;
          cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_Id;
          cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
          return dtCategory;
      }

      public DataTable Read_Insurance_TypeReport(clsEntityReports objEntityReport)
      {
          string strQueryImsReports = "INSURANCE_REPORTS.SP_READ_INSURANCE_TYPE_WISE";

          using (OracleCommand cmdReadInsurance = new OracleCommand())
          {
              cmdReadInsurance.CommandText = strQueryImsReports;
              cmdReadInsurance.CommandType = CommandType.StoredProcedure;
              cmdReadInsurance.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
              cmdReadInsurance.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
              cmdReadInsurance.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
              cmdReadInsurance.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
              //cmdReadInsurance.Parameters.Add("P_CAT_ID", OracleDbType.Int32).Value = objEntityReport.GuaranteeTypeId;
              cmdReadInsurance.Parameters.Add("P_INS_TYPE", OracleDbType.Int32).Value = objEntityReport.InsuranceType;
              //cmdReadInsurance.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityReport.GuaranteeExpiryRangeTO;
              cmdReadInsurance.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
              cmdReadInsurance.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              DataTable dtReadProductList = new DataTable();
              dtReadProductList = clsDataLayer.SelectDataTable(cmdReadInsurance);
              return dtReadProductList;
          }
      }

    }
}
