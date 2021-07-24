using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
 public class clsDataLayerSalaryEntryProcess
    {

     public DataTable ReadEmployee(clsEntitySalaryEntryProcess objentityPassport)
     {
         string strQueryReadPayGrd = "HCM_SALARY_ENTRY_PROCESS.SP_READ_EMPLOYEE_TABLE";
         OracleCommand cmdReadJob = new OracleCommand();
         cmdReadJob.CommandText = strQueryReadPayGrd;
         cmdReadJob.CommandType = CommandType.StoredProcedure;
         cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
         cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
         cmdReadJob.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objentityPassport.department;
         cmdReadJob.Parameters.Add("P_EMP_TYPE", OracleDbType.Int32).Value = objentityPassport.EmployeeType;
         cmdReadJob.Parameters.Add("P_SORT", OracleDbType.Int32).Value = objentityPassport.SortBy;
         cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
         DataTable dtCategory = new DataTable();
         dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
         return dtCategory;
     }
    }
}
