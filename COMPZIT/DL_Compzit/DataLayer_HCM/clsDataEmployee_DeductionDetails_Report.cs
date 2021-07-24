using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System.Data;
namespace DL_Compzit.DataLayer_HCM
{
  public  class clsDataEmployee_DeductionDetails_Report
    {

      public DataTable ReadDivision(clsEntityEmployee_DeductionDetails_Report objEntityjob)
        {
            string strQueryReadPayGrd = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.orgid;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UserId;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityjob.DeptId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
      public DataTable ReadDepartment(clsEntityEmployee_DeductionDetails_Report objEntityjob)
        {
            string strQueryReadPayGrd = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.orgid;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UserId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
      public DataTable ReadDesignation(clsEntityEmployee_DeductionDetails_Report objEntityjob)
        {
            string strQueryReadPayGrd = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_DESGNTN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.orgid;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UserId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
      public DataTable ReadDeductionList(clsEntityEmployee_DeductionDetails_Report objEntityjob)
      {
          string strQueryReadPayGrd = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_DEDUCTN_MSTR";
          OracleCommand cmdReadJob = new OracleCommand();
          cmdReadJob.CommandText = strQueryReadPayGrd;
          cmdReadJob.CommandType = CommandType.StoredProcedure;
          cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.orgid;
          cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
          cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityjob.DeptId;
          cmdReadJob.Parameters.Add("P_DVSNID", OracleDbType.Int32).Value = objEntityjob.divisionId;
          cmdReadJob.Parameters.Add("P_DESGNID", OracleDbType.Int32).Value = objEntityjob.desgId;
          cmdReadJob.Parameters.Add("P_TYPEID", OracleDbType.Int32).Value = objEntityjob.type;
          cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
          return dtCategory;
      }
      public DataTable ReadDeductionById(clsEntityEmployee_DeductionDetails_Report objEntityEmployeeDeduction)
      {
          string strQueryReadPayGrd = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_DEDUCTN_MSTRBY_ID";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadPayGrd;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

          cmdReadPayGrd.Parameters.Add("P_EMPDEDTN_ID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.UserId;
          cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.orgid;
          cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDeduction.CorpId;
          cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtCategory;
      }
      public DataTable ReadCorporateAddress(clsEntityEmployee_DeductionDetails_Report objEntityLayerManpwr)
      {
          string strQueryReadCorp = "HCM_EMPLOYEE_DEDUCTION_REPORT.SP_READ_CORP_ADDRSS_PRINT";
          OracleCommand cmdReadCorp = new OracleCommand();
          cmdReadCorp.CommandText = strQueryReadCorp;
          cmdReadCorp.CommandType = CommandType.StoredProcedure;
          cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.orgid;
          cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
          cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCorp = new DataTable();
          dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
          return dtCorp;
      }

    }
}
