using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsData_ImmigrationTaskReport
    {
       public DataTable ReadImgratnRnd(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_IMGRATN_RND";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;
              
               cmdReadImgratnRndByID.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.Orgid;
               cmdReadImgratnRndByID.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpOffice;
               cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }
       public DataTable ReadCandidate(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_CANDIDATE";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;

               cmdReadImgratnRndByID.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.Orgid;
               cmdReadImgratnRndByID.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpOffice;
               cmdReadImgratnRndByID.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }
       public DataTable ReadProject(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_PROJECT";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;

               cmdReadImgratnRndByID.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.Orgid;
               cmdReadImgratnRndByID.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpOffice;
               cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }
       public DataTable ReadEmployee(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_EMPLOYEE";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;

               cmdReadImgratnRndByID.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.Orgid;
               cmdReadImgratnRndByID.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpOffice;
               cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }
       public DataTable ReadEmployeebyDtlId(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_EMPLOYEEBY_DTLID";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;
               cmdReadImgratnRndByID.Parameters.Add("R_DTLID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgrtnId;
               cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }

       public DataTable ReadImmigrationTask(clsEntity_ImmigrationTaskReport objEntityLayerImgratnRnd)
       {
           DataTable dtImgratnRndByID = new DataTable();
           using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
           {
               cmdReadImgratnRndByID.CommandText = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_IMMIGRATION_TASK";
               cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;
               cmdReadImgratnRndByID.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.Orgid;
               cmdReadImgratnRndByID.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpOffice;
               cmdReadImgratnRndByID.Parameters.Add("R_IMGROUN", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgrtnRndId;
               cmdReadImgratnRndByID.Parameters.Add("R_CANDID", OracleDbType.Varchar2).Value = objEntityLayerImgratnRnd.CandidateId;
               cmdReadImgratnRndByID.Parameters.Add("R_PJTID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.pjtId;
               cmdReadImgratnRndByID.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.EmployeeId;
               cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
           }
           return dtImgratnRndByID;
       }
       public DataTable ReadCorporateAddress(clsEntity_ImmigrationTaskReport objEntityLayerManpwr)
       {
           string strQueryReadCorp = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_CORP_ADDRSS_PRINT";
           OracleCommand cmdReadCorp = new OracleCommand();
           cmdReadCorp.CommandText = strQueryReadCorp;
           cmdReadCorp.CommandType = CommandType.StoredProcedure;
           cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.Orgid;
           cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpOffice;
           cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCorp = new DataTable();
           dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
           return dtCorp;
       }
       public DataTable readCandidateById(clsEntity_ImmigrationTaskReport objEntityLayerManpwr)
       {
           string strQueryReadCorp = "HCM_IMMIGRATION_TASK_REPORT.SP_READ_IMMGRTNDTL_BY_CANDID";
           OracleCommand cmdReadCorp = new OracleCommand();
           cmdReadCorp.CommandText = strQueryReadCorp;
           cmdReadCorp.CommandType = CommandType.StoredProcedure;

           cmdReadCorp.Parameters.Add("I_DTLID", OracleDbType.Int32).Value = objEntityLayerManpwr.CandId;
           cmdReadCorp.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCorp = new DataTable();
           dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
           return dtCorp;
       }
    }
}
