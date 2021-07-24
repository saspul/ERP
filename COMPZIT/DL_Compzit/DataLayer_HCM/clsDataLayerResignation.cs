using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;


namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayerResignation
    {

        //Read employee details   
       public DataTable ReadEmpDetails(clsEntityLayerResignation objEntityResignation)
        {
            DataTable dtClearanceFormStaffList = new DataTable();
            using (OracleCommand cmdReadEmployee = new OracleCommand())
            {
                cmdReadEmployee.CommandText = "RESIGNATION.SP_READ_EMP_DTL";
                cmdReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdReadEmployee.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
                cmdReadEmployee.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityResignation.OrgId;
                cmdReadEmployee.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityResignation.CorpId;
                cmdReadEmployee.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
            }
            return dtClearanceFormStaffList;
        }
       public DataTable ReadNoticePrd(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = new DataTable();
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = "RESIGNATION.SP_READ_NTCPRD";
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadEmployee.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityResignation.OrgId;
               cmdReadEmployee.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityResignation.CorpId;
               cmdReadEmployee.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
           }
           return dtClearanceFormStaffList;
       }
       public DataTable CheckEmp(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = new DataTable();
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = "RESIGNATION.SP_CHCK_EMP_DTL";
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadEmployee.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityResignation.OrgId;
               cmdReadEmployee.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityResignation.CorpId;
               cmdReadEmployee.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
           }
           return dtClearanceFormStaffList;
       }
       //Read employee divisions   
       public DataTable ReadDivisionOfEmp(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = new DataTable();
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = "RESIGNATION.SP_READ_DIVISIONS_EMP";
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadEmployee.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
           }
           return dtClearanceFormStaffList;
       }

       public void AddResignation(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_ADD_RESIGNTN";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               if (objEntityResignation.PreferdDate != DateTime.MinValue)
               {
                   cmdReadById.Parameters.Add("R_PRFRD_DATE", OracleDbType.Date).Value = objEntityResignation.PreferdDate;
               }
               else
               {
                   cmdReadById.Parameters.Add("R_PRFRD_DATE", OracleDbType.Date).Value = null;
               }
               cmdReadById.Parameters.Add("R_REASN", OracleDbType.Varchar2).Value = objEntityResignation.Reason;
               cmdReadById.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityResignation.UserDate;
               cmdReadById.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityResignation.OrgId;
               cmdReadById.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityResignation.CorpId;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void UpdateResignation(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_UPD_RESIGNTN";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityResignation.ResgntnId;
               cmdReadById.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               if (objEntityResignation.PreferdDate != DateTime.MinValue)
               {
                   cmdReadById.Parameters.Add("R_PRFRD_DATE", OracleDbType.Date).Value = objEntityResignation.PreferdDate;
               }
               else
               {
                   cmdReadById.Parameters.Add("R_PRFRD_DATE", OracleDbType.Date).Value = null;
               }
               cmdReadById.Parameters.Add("R_REASN", OracleDbType.Varchar2).Value = objEntityResignation.Reason;
               cmdReadById.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityResignation.UserDate;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public void ConfirmResignation(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_CNFRM_RESIGNTN";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityResignation.ResgntnId;
               cmdReadById.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadById.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityResignation.UserDate;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CancelResignation(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_CNCL_RESIGNTN";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityResignation.ResgntnId;
               cmdReadById.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadById.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityResignation.UserDate;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CancelClearnceDtls(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_CNCL_CLERNC_DTLS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadById.Parameters.Add("R_CLRSTFID", OracleDbType.Int32).Value = objEntityResignation.LvStfClrId;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CancelClearnce(clsEntityLayerResignation objEntityResignation)
       {
           string strQueryReadById = "RESIGNATION.SP_CNCL_CLERNC";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("R_CLRSTFID", OracleDbType.Int32).Value = objEntityResignation.LvStfClrId;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public DataTable ReadLvStfId(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = new DataTable();
           using (OracleCommand cmdReadEmployee = new OracleCommand())
           {
               cmdReadEmployee.CommandText = "RESIGNATION.SP_READ_LV_STFID";
               cmdReadEmployee.CommandType = CommandType.StoredProcedure;
               cmdReadEmployee.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityResignation.UserId;
               cmdReadEmployee.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtClearanceFormStaffList = clsDataLayer.SelectDataTable(cmdReadEmployee);
           }
           return dtClearanceFormStaffList;
       }

    }
}
