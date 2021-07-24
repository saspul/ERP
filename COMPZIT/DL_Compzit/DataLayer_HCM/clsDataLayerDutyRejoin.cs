using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
  public  class clsDataLayerDutyRejoin
    {
      public DataTable ReadRejoinList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          DataTable dtConsultancytype = new DataTable();
          using (OracleCommand cmdReadConsultancytype = new OracleCommand())
          {
              cmdReadConsultancytype.CommandText = "DUTY_REJOIN.SP_READ_REJOIN_LIST";
              cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
              cmdReadConsultancytype.Parameters.Add("R_ORGID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.orgid;
              cmdReadConsultancytype.Parameters.Add("R_CORPTID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.CorpId;
              cmdReadConsultancytype.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdReadConsultancytype.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
          }
          return dtConsultancytype;
      }
      public DataTable ReadConfirmList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          DataTable dtConsultancytype = new DataTable();
          using (OracleCommand cmdReadConsultancytype = new OracleCommand())
          {
              cmdReadConsultancytype.CommandText = "DUTY_REJOIN.SP_READ_CONFIRM_LIST";
              cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
              cmdReadConsultancytype.Parameters.Add("R_ORGID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.orgid;
              cmdReadConsultancytype.Parameters.Add("R_CORPTID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.CorpId;
              cmdReadConsultancytype.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdReadConsultancytype.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
          }
          return dtConsultancytype;
      }
      public DataTable ReadRejectedList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          DataTable dtConsultancytype = new DataTable();
          using (OracleCommand cmdReadConsultancytype = new OracleCommand())
          {
              cmdReadConsultancytype.CommandText = "DUTY_REJOIN.SP_READ_REJECT_LIST";
              cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
              cmdReadConsultancytype.Parameters.Add("R_ORGID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.orgid;
              cmdReadConsultancytype.Parameters.Add("R_CORPTID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.CorpId;
              cmdReadConsultancytype.Parameters.Add("R_USERDATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdReadConsultancytype.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
          }
          return dtConsultancytype;
      }

      public void AddRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_INSERT_REJOIN";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityDutyRejoin.EmployeeId;
              cmdAddConsultancyMstr.Parameters.Add("R_LEAVEID", OracleDbType.Int32).Value = objEntityDutyRejoin.LeaveId;
              cmdAddConsultancyMstr.Parameters.Add("R_REJN_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.RejoinDate;
              cmdAddConsultancyMstr.Parameters.Add("R_HANDOVR_STS", OracleDbType.Int32).Value = objEntityDutyRejoin.PassHandOverSts;
              cmdAddConsultancyMstr.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.orgid;
              cmdAddConsultancyMstr.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.CorpId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdAddConsultancyMstr.Parameters.Add("R_HALFDAY_STS", OracleDbType.Int32).Value = objEntityDutyRejoin.HalfdayStatus;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }


      public void ConfirmRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_CONFIRM_REJOIN";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }

      public void ReporterConfirm(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_REPORTER_CONFIRM";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }
      public void HRconfirm(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_HR_CONFIRM";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdAddConsultancyMstr.Parameters.Add("R_SALA_PROC_STS", OracleDbType.Int32).Value = objEntityDutyRejoin.SalProcsSts;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }

      public void RejectRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_REJECT_REJOIN";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdAddConsultancyMstr.Parameters.Add("R_REASON", OracleDbType.Varchar2).Value = objEntityDutyRejoin.RejectReason;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }

      public DataTable ReportOfficerRead(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          DataTable dtConsultancytype = new DataTable();
          using (OracleCommand cmdReadConsultancytype = new OracleCommand())
          {
              cmdReadConsultancytype.CommandText = "DUTY_REJOIN.SP_READ_REPORTOFCR_ID";
              cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
              cmdReadConsultancytype.Parameters.Add("R_USERID", OracleDbType.Varchar2).Value = objEntityDutyRejoin.UserId;
              cmdReadConsultancytype.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
          }
          return dtConsultancytype;
      }

      public void ReporterConfirmReject(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_REPORTER_CONFIRM_RJCT";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
          {
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.UserId;
              cmdAddConsultancyMstr.Parameters.Add("R_INS_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.UserDate;
              cmdAddConsultancyMstr.Parameters.Add("R_REJN_DATE", OracleDbType.Date).Value = objEntityDutyRejoin.RejoinDate;
              cmdAddConsultancyMstr.Parameters.Add("R_STS", OracleDbType.Int32).Value = objEntityDutyRejoin.Status;
              cmdAddConsultancyMstr.Parameters.Add("R_SALA_PROC_STS", OracleDbType.Int32).Value = objEntityDutyRejoin.SalProcsSts;
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }
      public DataTable ReadLeaveDetails(clsEntityLayerDutyRejoin objEntityDutyRejoin)
      {
          DataTable dtConsultancytype = new DataTable();
          using (OracleCommand cmdReadConsultancytype = new OracleCommand())
          {
              cmdReadConsultancytype.CommandText = "DUTY_REJOIN.SP_READ_LEAVE_DETAILS";
              cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
              cmdReadConsultancytype.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityDutyRejoin.DutyRejoinId;
              cmdReadConsultancytype.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
          }
          return dtConsultancytype;
      }
      public void updateLeaveInfo(string[] arrLEave)
      {
          string strQueryAddConsultancyMstr = "DUTY_REJOIN.SP_UPD_LEAVE_INFO";
          using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
           {
              clsCommonLibrary objCommon = new clsCommonLibrary();
              cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
              cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
              cmdAddConsultancyMstr.Parameters.Add("R_LEAVE_ID", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[2]);
              cmdAddConsultancyMstr.Parameters.Add("R_LEAVE_PAGE", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[3]);
              cmdAddConsultancyMstr.Parameters.Add("R_LEAVE_USER_ID", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[10]);
              cmdAddConsultancyMstr.Parameters.Add("R_INS_USER_ID", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[0]);
              cmdAddConsultancyMstr.Parameters.Add("R_FROM_SECTION", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[4]);
              if(arrLEave[5]!=""){
                  cmdAddConsultancyMstr.Parameters.Add("R_TO_DATE", OracleDbType.Date).Value = objCommon.textToDateTime(arrLEave[5]); 
              cmdAddConsultancyMstr.Parameters.Add("R_TO_SECTION", OracleDbType.Int32).Value = Convert.ToInt32(arrLEave[6]);
              }
              else{
                  cmdAddConsultancyMstr.Parameters.Add("R_TO_DATE", OracleDbType.Date).Value = DBNull.Value;
              cmdAddConsultancyMstr.Parameters.Add("R_TO_SECTION", OracleDbType.Int32).Value = DBNull.Value;
              }
              cmdAddConsultancyMstr.Parameters.Add("R_LEAVE_COUNT", OracleDbType.Decimal).Value = Convert.ToDecimal(arrLEave[7]);
              cmdAddConsultancyMstr.Parameters.Add("R_DIFF_COUNT", OracleDbType.Decimal).Value = Convert.ToDecimal(arrLEave[8]);
              clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
          }
      }
      public void InsertUserLeavTyp(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "DUTY_REJOIN.SP_INS_REMAINGLEV";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.RemingLev;

          clsDataLayer.ExecuteNonQuery(cmdReadEmp);

      }


    }
}
