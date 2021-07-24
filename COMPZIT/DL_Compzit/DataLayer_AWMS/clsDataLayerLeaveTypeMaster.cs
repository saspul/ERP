using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0008
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerLeaveTypeMaster
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();



       public string CheckLeaveName(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {

           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_CHECK_LEAVE_TYPE_NAME";
           OracleCommand cmdReadLeav = new OracleCommand();
           cmdReadLeav.CommandText = strQueryLeaveTyp;
           cmdReadLeav.CommandType = CommandType.StoredProcedure;
           cmdReadLeav.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeave.LeaveTypeMasterId;
           cmdReadLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLeave.LeaveTypeName;
           cmdReadLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeave.Organisation_id;
           cmdReadLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeave.Corporate_id;
           cmdReadLeav.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadLeav);
           string strReturn = cmdReadLeav.Parameters["L_COUNT"].Value.ToString();
           cmdReadLeav.Dispose();
           return strReturn;
       }

       // This Method adds Leave details to the table
       public void AddLeaveType(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_INS_LEAVE_TYPE_DETAILS";
           using (OracleCommand cmdAddLeav = new OracleCommand())
           {
               cmdAddLeav.CommandText = strQueryLeaveTyp;
               cmdAddLeav.CommandType = CommandType.StoredProcedure;
               cmdAddLeav.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityLeave.Status_id;
               cmdAddLeav.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeave.User_Id;
               cmdAddLeav.Parameters.Add("L_NODAYS", OracleDbType.Int32).Value = objEntityLeave.NoOfDays;
               cmdAddLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLeave.LeaveTypeName;
               cmdAddLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeave.Organisation_id;
               cmdAddLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeave.Corporate_id;
                 clsDataLayer.ExecuteNonQuery(cmdAddLeav);
           }
       }

       // This Method update holiday details to the table
       public void UpdateLeaveType(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_UPD_LEAVE_TYPE_DETAILS";
           using (OracleCommand cmdUpdLeav = new OracleCommand())
           {
               cmdUpdLeav.CommandText = strQueryLeaveTyp;
               cmdUpdLeav.CommandType = CommandType.StoredProcedure;
               cmdUpdLeav.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeave.LeaveTypeMasterId;
               cmdUpdLeav.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityLeave.Status_id;
               cmdUpdLeav.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeave.User_Id;
               cmdUpdLeav.Parameters.Add("L_NODAYS", OracleDbType.Int32).Value = objEntityLeave.NoOfDays;
               cmdUpdLeav.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityLeave.LeaveTypeName;
               cmdUpdLeav.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeave.Organisation_id;
               cmdUpdLeav.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeave.Corporate_id;
               cmdUpdLeav.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdUpdLeav);
           }
       }

    

       // This Method read leave details by id
       public DataTable ReadLeavedetailsById(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_READ_LEAVE_TYPE_BY_ID";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryLeaveTyp;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeave.LeaveTypeMasterId;
           cmdReadHol.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtLeavTyp = new DataTable();
           dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
           return dtLeavTyp;


       }

       // This Method recall leave details
       public void ReCallLeaveDetails(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_RECALL_LEAVETYP_DETAILS";
           using (OracleCommand cmdRecLev = new OracleCommand())
           {
               cmdRecLev.CommandText = strQueryLeaveTyp;
               cmdRecLev.CommandType = CommandType.StoredProcedure;
               cmdRecLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeave.LeaveTypeMasterId;
               cmdRecLev.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeave.User_Id;
               cmdRecLev.Parameters.Add("L_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdRecLev);
           }
       }

       // This Method cancel leave type details
       public void CancelLeaveType(clsEntityLayerLeaveTypeMaster objEntityLeave)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_CANCEL_LEAVE_DETAILS";
           using (OracleCommand cmdCanLev = new OracleCommand())
           {
               cmdCanLev.CommandText = strQueryLeaveTyp;
               cmdCanLev.CommandType = CommandType.StoredProcedure;
               cmdCanLev.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeave.LeaveTypeMasterId;
               cmdCanLev.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeave.User_Id;
               cmdCanLev.Parameters.Add("L_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdCanLev.Parameters.Add("L_CANRES", OracleDbType.Varchar2).Value = objEntityLeave.CancelReason;
               clsDataLayer.ExecuteNonQuery(cmdCanLev);
           }
       }


       // This Method read leave details by id
       public DataTable ReadLeaveTypeBySearch(clsEntityLayerLeaveTypeMaster objEntityHol)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_READ_LEAVETYP_BYSEARCH";
           OracleCommand cmdReadLevTypsrch = new OracleCommand();
           cmdReadLevTypsrch.CommandText = strQueryLeaveTyp;
           cmdReadLevTypsrch.CommandType = CommandType.StoredProcedure;
           cmdReadLevTypsrch.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           cmdReadLevTypsrch.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
           cmdReadLevTypsrch.Parameters.Add("L_OPTION", OracleDbType.Int32).Value = objEntityHol.Status_id;
           cmdReadLevTypsrch.Parameters.Add("L_CANCEL", OracleDbType.Int32).Value = objEntityHol.CancelStatus;
           cmdReadLevTypsrch.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtLeavTyp = new DataTable();
           dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadLevTypsrch);
           return dtLeavTyp;


       }


       public DataTable ReadConfirmedLevAllocn(clsEntityLayerLeaveTypeMaster objEntityHol)
       {
           string strQueryLeaveTyp = "LEAVE_TYPE_MASTER.SP_READ_LEAVALLOCNSTATUS";
           OracleCommand cmdReadLevTypsrch = new OracleCommand();
           cmdReadLevTypsrch.CommandText = strQueryLeaveTyp;
           cmdReadLevTypsrch.CommandType = CommandType.StoredProcedure;
          // cmdReadLevTypsrch.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           //cmdReadLevTypsrch.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
           cmdReadLevTypsrch.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityHol.LeaveTypeMasterId;
           cmdReadLevTypsrch.Parameters.Add("L_LEV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtLeavTyp = new DataTable();
           dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadLevTypsrch);
           return dtLeavTyp;


       }

    }
}