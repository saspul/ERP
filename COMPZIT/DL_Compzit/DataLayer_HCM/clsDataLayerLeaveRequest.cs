using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
  public  class clsDataLayerLeaveRequest
    {
      public DataTable ReadLeavTypdtl(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LEVTYP";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveRequest.Organisation_id;
          cmdReadEmp.Parameters.Add("L_CORPTID", OracleDbType.Int32).Value = objEntityLeaveRequest.Corporate_id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }

      public DataTable CheckTrvlDtlShow(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_CHK_TRVL_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_TYPE_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }

      public DataTable ReadFmlyDtls(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_FMLY_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadCity(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_CITY";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadLeaveRqstById(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_RQSTDTL_BYID";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadDepntIds(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_DEPNTIDS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadRemLeav(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_REMAINLEV_BYYEAR";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_REM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadLeaveRqstList(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LEAVERST_LIST";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_APRVL_STS", OracleDbType.Int32).Value = objEntityLeaveRequest.StatsSrch;
          if (objEntityLeaveRequest.LeaveFrmDate != DateTime.MinValue)
          {
              cmdReadEmp.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          }
          else
          {
              cmdReadEmp.Parameters.Add("L_FROMDATE", OracleDbType.Date).Value = null;
          }
          if (objEntityLeaveRequest.LeaveToDate != DateTime.MinValue)
          {
              cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveToDate;
          }
          else
          {
              cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
          }
          cmdReadEmp.Parameters.Add("L_SYSDATE", OracleDbType.Date).Value = objEntityLeaveRequest.DateOfTrvl;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public string confmAllocnCount(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LEVALLTN_CONT";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdReadEmp);
          string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
          cmdReadEmp.Dispose();
          return strLeav;

      }
      public DataTable FrmSgleDate(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_FRMSNGLEDATE_COUNT";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public void AddLeavReqstDetails(clsEntityLeaveRequest objEntityLeaveRequest, string[] strarrDepntIds)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryInsertJobShdl = "LEAVE_REQUEST.SP_INS_LEAVE_RQST_DTLS";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                  {

                      clsEntityCommon objEntCommon = new clsEntityCommon();
                      objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_REQUEST);
                      objEntCommon.CorporateID = objEntityLeaveRequest.Corporate_id;
                      string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                      objEntityLeaveRequest.LeaveRqstId = Convert.ToInt32(strNextNum);

                      cmdInsertJobSchdlng.Transaction = tran;
                      cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                      cmdInsertJobSchdlng.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
                      cmdInsertJobSchdlng.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_MULDAYS", OracleDbType.Int32).Value = objEntityLeaveRequest.MulDaysChk;
                      cmdInsertJobSchdlng.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
                      cmdInsertJobSchdlng.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveFromSection;
                      if (objEntityLeaveRequest.LeaveToDate != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveToDate;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                      }
                      if (objEntityLeaveRequest.LeaveToSection != 0)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveToSection;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = null;
                      }
                      cmdInsertJobSchdlng.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.NumOfLeave;
                      cmdInsertJobSchdlng.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveRequest.Organisation_id;
                      cmdInsertJobSchdlng.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveRequest.Corporate_id;
                      cmdInsertJobSchdlng.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_DESC", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Description;
                      cmdInsertJobSchdlng.Parameters.Add("L_TRVL_STS", OracleDbType.Int32).Value = objEntityLeaveRequest.TravelStatus;
                      //Start:-For Travel Details
                      if (objEntityLeaveRequest.DateOfTrvl != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATETRVL", OracleDbType.Date).Value = objEntityLeaveRequest.DateOfTrvl;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATETRVL", OracleDbType.Date).Value = null;
                      }
                      if (objEntityLeaveRequest.DateOfRetrn != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATERETRN", OracleDbType.Date).Value = objEntityLeaveRequest.DateOfRetrn;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATERETRN", OracleDbType.Date).Value = null;
                      }
                      cmdInsertJobSchdlng.Parameters.Add("L_DESTN", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Destination;
                      cmdInsertJobSchdlng.Parameters.Add("L_AIRPRFD", OracleDbType.Varchar2).Value = objEntityLeaveRequest.AirlinePrfrd;
                      cmdInsertJobSchdlng.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Address;
                      cmdInsertJobSchdlng.Parameters.Add("L_TELENO", OracleDbType.Varchar2).Value = objEntityLeaveRequest.TeleNo;
                      cmdInsertJobSchdlng.Parameters.Add("L_LCLCONTNO", OracleDbType.Varchar2).Value = objEntityLeaveRequest.LocalCntctNo;
                      cmdInsertJobSchdlng.Parameters.Add("L_EMAIL", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Email;
                      cmdInsertJobSchdlng.Parameters.Add("L_CMNT", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Comment;
                      cmdInsertJobSchdlng.Parameters.Add("L_NEED_TCKT", OracleDbType.Int32).Value = objEntityLeaveRequest.TcketNeeded;
                      cmdInsertJobSchdlng.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLeaveRequest.PaidLvStatus;
                      
                      //End:-For Travel Details

                      cmdInsertJobSchdlng.ExecuteNonQuery();

                  }

                  if (strarrDepntIds != null)
                  {
                      foreach (string strDtlId in strarrDepntIds)
                      {
                          if (strDtlId != "" && strDtlId != null)
                          {
                              int intDtlId = Convert.ToInt32(strDtlId);

                              string strQueryCancelDetail = "LEAVE_REQUEST.SP_INS_LEAVE_FMLY_DTLS";
                              using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                              {
                                  cmdCancelDetail.Transaction = tran;
                                  cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                  cmdCancelDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
                                  cmdCancelDetail.Parameters.Add("L_DTLID", OracleDbType.Int32).Value = intDtlId;
                                  cmdCancelDetail.ExecuteNonQuery();
                              }
                          }
                      }
                  }
                  tran.Commit();

              }

              catch (Exception e)
              {
                  tran.Rollback();
                  throw e;

              }
          }
      }


      public void UpdateLeaveRqstDtls(clsEntityLeaveRequest objEntityLeaveRequest, string[] strarrDepntIds)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryInsertJobShdl = "LEAVE_REQUEST.SP_UPD_LEAVE_RQST_DTLS";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                  {

                      cmdInsertJobSchdlng.Transaction = tran;
                      cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                      cmdInsertJobSchdlng.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
                      cmdInsertJobSchdlng.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_MULDAYS", OracleDbType.Int32).Value = objEntityLeaveRequest.MulDaysChk;
                      cmdInsertJobSchdlng.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
                      cmdInsertJobSchdlng.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveFromSection;
                     
                      if (objEntityLeaveRequest.LeaveToDate != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveToDate;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                      }
                      if (objEntityLeaveRequest.LeaveToSection != 0)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveToSection;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = null;
                      }
                      cmdInsertJobSchdlng.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.NumOfLeave;
                      cmdInsertJobSchdlng.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveRequest.Organisation_id;
                      cmdInsertJobSchdlng.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveRequest.Corporate_id;
                      cmdInsertJobSchdlng.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
                      cmdInsertJobSchdlng.Parameters.Add("L_DESC", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Description;
                      cmdInsertJobSchdlng.Parameters.Add("L_TRVL_STS", OracleDbType.Int32).Value = objEntityLeaveRequest.TravelStatus;
                      //Start:-For Travel Details
                      if (objEntityLeaveRequest.DateOfTrvl != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATETRVL", OracleDbType.Date).Value = objEntityLeaveRequest.DateOfTrvl;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATETRVL", OracleDbType.Date).Value = null;
                      }
                      if (objEntityLeaveRequest.DateOfRetrn != DateTime.MinValue)
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATERETRN", OracleDbType.Date).Value = objEntityLeaveRequest.DateOfRetrn;
                      }
                      else
                      {
                          cmdInsertJobSchdlng.Parameters.Add("L_DATERETRN", OracleDbType.Date).Value = null;
                      }
                      cmdInsertJobSchdlng.Parameters.Add("L_DESTN", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Destination;
                      cmdInsertJobSchdlng.Parameters.Add("L_AIRPRFD", OracleDbType.Varchar2).Value = objEntityLeaveRequest.AirlinePrfrd;
                      cmdInsertJobSchdlng.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Address;
                      cmdInsertJobSchdlng.Parameters.Add("L_TELENO", OracleDbType.Varchar2).Value = objEntityLeaveRequest.TeleNo;
                      cmdInsertJobSchdlng.Parameters.Add("L_LCLCONTNO", OracleDbType.Varchar2).Value = objEntityLeaveRequest.LocalCntctNo;
                      cmdInsertJobSchdlng.Parameters.Add("L_EMAIL", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Email;
                      cmdInsertJobSchdlng.Parameters.Add("L_CMNT", OracleDbType.Varchar2).Value = objEntityLeaveRequest.Comment;
                      cmdInsertJobSchdlng.Parameters.Add("L_NEED_TCKT", OracleDbType.Int32).Value = objEntityLeaveRequest.TcketNeeded;
                      cmdInsertJobSchdlng.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveRequest.date;
                      cmdInsertJobSchdlng.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLeaveRequest.PaidLvStatus;

                      //End:-For Travel Details

                      cmdInsertJobSchdlng.ExecuteNonQuery();

                  }


                  //Start:-For delete from fmly dtls
                  string strQueryCancelDetails = "LEAVE_REQUEST.SP_DELE_LEAVE_FMLY_DTLS";
                  using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetails, con))
                  {
                      cmdCancelDetail.Transaction = tran;
                      cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                      cmdCancelDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
                      cmdCancelDetail.ExecuteNonQuery();
                  }
                  //End:-For delete from fmly dtls


                  if (strarrDepntIds != null)
                  {
                      
                      foreach (string strDtlId in strarrDepntIds)
                      {
                          if (strDtlId != "" && strDtlId != null)
                          {
                              int intDtlId = Convert.ToInt32(strDtlId);

                              string strQueryCancelDetail = "LEAVE_REQUEST.SP_INS_LEAVE_FMLY_DTLS";
                              using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                              {
                                  cmdCancelDetail.Transaction = tran;
                                  cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                  cmdCancelDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
                                  cmdCancelDetail.Parameters.Add("L_DTLID", OracleDbType.Int32).Value = intDtlId;
                                  cmdCancelDetail.ExecuteNonQuery();
                              }
                          }
                      }
                  }
                  tran.Commit();

              }

              catch (Exception e)
              {
                  tran.Rollback();
                  throw e;

              }
          }
      }


      public void InsertUserNewLevRow(clsEntityLeaveRequest objEntityLeaveRequest)
      {

          OracleTransaction tran;

          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  string strQueryReadEmploy = "LEAVE_REQUEST.SP_INS_NEWROW_USR";
                  using (OracleCommand cmdReadEmp = new OracleCommand(strQueryReadEmploy, con))
                  {                      
                      cmdReadEmp.Transaction = tran;
                      cmdReadEmp.CommandType = CommandType.StoredProcedure;
                      cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
                      cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
                      cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
                      cmdReadEmp.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.OpeningLv;
                      cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.RemingLev;
                      cmdReadEmp.Parameters.Add("L_BALLEAVE", OracleDbType.Decimal).Value = objEntityLeaveRequest.NumOfLeaveNew;
                      cmdReadEmp.ExecuteNonQuery();
                      

                  }
                  tran.Commit();
              }
              catch (Exception ex)
              {
                  tran.Rollback();
                  throw ex;
              }
             
          }
      }
      public void DeleteUSerLeaveTypes(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_DELE_USR_LEAVE_TYPES";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          clsDataLayer.ExecuteNonQuery(cmdReadEmp);

      }
      public void ConfirmLeavAllocnDtl(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_CONFIRM";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveRequest.date;
          cmdReadEmp.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLeaveRequest.PaidLvStatus;
          clsDataLayer.ExecuteNonQuery(cmdReadEmp);

      }
      public string chkUserLevCount(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_USRLEVCOUNTFRM";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdReadEmp);
          string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
          cmdReadEmp.Dispose();
          return strLeav;

      }
      public void InsertUserLeavTyp(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_INS_REMAINGLEV";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;

          //  cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
          cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLeaveRequest.RemingLev;

          clsDataLayer.ExecuteNonQuery(cmdReadEmp);

      }
      public string chkUserToLevCount(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_USRLEVCOUNTTO";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;

          cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveToDate;
          cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdReadEmp);
          string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
          cmdReadEmp.Dispose();
          return strLeav;

      }

      public void CancelRqst(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_CNCL_RQST";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveRequest.date;
          clsDataLayer.ExecuteNonQuery(cmdReadEmp);

      }
      public DataTable CheckEmpType(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_EMP_TYPE";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadUserDetails(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_EMP_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadGendrMrtSts(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LVE_GNDRMRTL_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadDesgDtls(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LVE_DESG_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadPayGrdedtls(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LVE_PAYGRD_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ReadExpDtls(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_READ_LVE_EXP_DTLS";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }
      public DataTable ChkDatesInLeavReqst(clsEntityLeaveRequest objEntityLeaveRequest){
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_CHKDATES_LEVRQST";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.LeaveRqstId;
          cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLeaveRequest.Leave_Id;
          cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLeaveRequest.LeaveFrmDate;
          cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;

      }

      public DataTable CheckReportOffcr(clsEntityLeaveRequest objEntityLeaveRequest)
      {
          string strQueryReadEmploy = "LEAVE_REQUEST.SP_CHK_REPORTING_OFFCR";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmploy;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("L_EMP_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.User_Id;
          cmdReadEmp.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Organisation_id;
          cmdReadEmp.Parameters.Add("L_CRPRT_ID", OracleDbType.Int32).Value = objEntityLeaveRequest.Corporate_id;
          cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtLeav;
      }
    }
}
