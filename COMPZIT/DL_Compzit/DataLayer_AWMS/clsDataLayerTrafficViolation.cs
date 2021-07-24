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
using CL_Compzit;
// CREATED BY:EVM-0009
// CREATED DATE:30/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
  public class clsDataLayerTrafficViolation
    {
        // This Method will fetch Vehicle details
      public DataTable ReadVehicleNumber(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
        {
            string strQueryReadVehicle = "TRAFFIC_VIOLATION.SP_READ_VHCL_NUMBER";
            OracleCommand cmdReadVehicle = new OracleCommand();
            cmdReadVehicle.CommandText = strQueryReadVehicle;
            cmdReadVehicle.CommandType = CommandType.StoredProcedure;       
            cmdReadVehicle.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
            cmdReadVehicle.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
            cmdReadVehicle.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadVehicle);
            return dtVehicle;
        }
      // This Method will fetch Employee details
      public DataTable ReadEmployee(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadVehicle = "TRAFFIC_VIOLATION.SP_READ_EMPLOYEE";
          OracleCommand cmdReadVehicle = new OracleCommand();
          cmdReadVehicle.CommandText = strQueryReadVehicle;
          cmdReadVehicle.CommandType = CommandType.StoredProcedure;
          cmdReadVehicle.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadVehicle.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadVehicle.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtVehicle = new DataTable();
          dtVehicle = clsDataLayer.ExecuteReader(cmdReadVehicle);
          return dtVehicle;
      }
      // This Method will fetch Employee  For autocompletion from WebService
      public DataTable ReadEmployeesWebService(string strLikeEmployee, clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadEmp = "TRAFFIC_VIOLATION.SP_READ_EMPLOYEE_WEBSERVICE";
          OracleCommand cmdReadEmp = new OracleCommand();
          cmdReadEmp.CommandText = strQueryReadEmp;
          cmdReadEmp.CommandType = CommandType.StoredProcedure;
          cmdReadEmp.Parameters.Add("TV_EMPLOYEE", OracleDbType.Varchar2).Value = strLikeEmployee;
          cmdReadEmp.Parameters.Add("TV_VHCL_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
          cmdReadEmp.Parameters.Add("TV_VIOLTN_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
          cmdReadEmp.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadEmp.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadEmp.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmployee = new DataTable();
          dtEmployee = clsDataLayer.ExecuteReader(cmdReadEmp);
          return dtEmployee;
      }
      // This Method will fetch Violation  For autocompletion from WebService
      public DataTable ReadViolationWebService(string strLikeViolation, clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadVioltn = "TRAFFIC_VIOLATION.SP_READ_VIOLATION_WEBSERVICE";
          OracleCommand cmdReadVioltn = new OracleCommand();
          cmdReadVioltn.CommandText = strQueryReadVioltn;
          cmdReadVioltn.CommandType = CommandType.StoredProcedure;
          cmdReadVioltn.Parameters.Add("TV_VIOLATION", OracleDbType.Varchar2).Value = strLikeViolation;
          cmdReadVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadVioltn.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadVioltn.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtViolation = new DataTable();
          dtViolation = clsDataLayer.ExecuteReader(cmdReadVioltn);
          return dtViolation;
      }
      // This Method will fetch vehicle DETAILS
      public DataTable ReadWaterVehicleDtlByID(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadVhcl = "TRAFFIC_VIOLATION.SP_READ_VHCL_DTL_BYID";
          OracleCommand cmdReadVhcl = new OracleCommand();
          cmdReadVhcl.CommandText = strQueryReadVhcl;
          cmdReadVhcl.CommandType = CommandType.StoredProcedure;
          cmdReadVhcl.Parameters.Add("TV_VHCLID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
          cmdReadVhcl.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadVhcl.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadVhcl.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtWtrCrd = new DataTable();
          dtWtrCrd = clsDataLayer.ExecuteReader(cmdReadVhcl);
          return dtWtrCrd;
      }
      //insert traffic violation  details to  table
      public int Insert_TrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn,  List<clsEntityLayerTrafficViolationDtl> objEntityTrficVioltnDetilsList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryInsertTrfcVioltn = "TRAFFIC_VIOLATION.SP_INSERT_TRFICVIOLTN";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  using (OracleCommand cmdInsertTrficVioltn = new OracleCommand(strQueryInsertTrfcVioltn, con))
                  {
                      cmdInsertTrficVioltn.Transaction = tran;

                      cmdInsertTrficVioltn.CommandType = CommandType.StoredProcedure;

                      clsEntityCommon objEntCommon = new clsEntityCommon();
                      objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRAFFIC_VIOLATION);
                      objEntCommon.CorporateID = objEntityLayerTrafficVltn.CorpOffice_Id;
                      string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                      objEntityLayerTrafficVltn.TrafficVltnId = Convert.ToInt32(strNextNum);

                      cmdInsertTrficVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdInsertTrficVioltn.Parameters.Add("TV_VHCLID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
                      cmdInsertTrficVioltn.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;
                      if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                      {
                          cmdInsertTrficVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                      }
                      else
                      {
                          cmdInsertTrficVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                      }
                     
                      cmdInsertTrficVioltn.Parameters.Add("TV_RCPTAMNT", OracleDbType.Decimal).Value = objEntityLayerTrafficVltn.RecptAmnt;
                      cmdInsertTrficVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdInsertTrficVioltn.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
                      cmdInsertTrficVioltn.Parameters.Add("TV_INSUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                      cmdInsertTrficVioltn.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                      //evm-0027
                      cmdInsertTrficVioltn.Parameters.Add("TV_REFNO", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.RefNo;
                      //end
                      cmdInsertTrficVioltn.ExecuteNonQuery();

                  }
                  //insert to  Detail table
                  foreach (clsEntityLayerTrafficViolationDtl objDetail in objEntityTrficVioltnDetilsList)
                  {

                      string strQueryInsertDetail = "TRAFFIC_VIOLATION.SP_INSERT_TRFICVIOLTN_DTL";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                          cmdAddInsertDetail.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objDetail.Violtndate;
                          cmdAddInsertDetail.Parameters.Add("TV_USRID", OracleDbType.Int32).Value = objDetail.UserId;
                          cmdAddInsertDetail.Parameters.Add("TV_CMPLNTMSTRID", OracleDbType.Int32).Value = objDetail.Violation;
                          cmdAddInsertDetail.Parameters.Add("TV_AMNT", OracleDbType.Decimal).Value = objDetail.VioltnAmnt;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatusId;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettledAmnt;
                          if ( objDetail.Settleddate != DateTime.MinValue)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.Settleddate;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                          }
                          cmdAddInsertDetail.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
                          cmdAddInsertDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                          if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                          }
                          cmdAddInsertDetail.ExecuteNonQuery();
                      }
                  }

                  tran.Commit();
                  return objEntityLayerTrafficVltn.TrafficVltnId;
              }

              catch (Exception e)
              {
                  tran.Rollback();
                  throw e;

              }

          }
      }
      // This Method will fetch traffic violation  list BY SEARCH
      public DataTable ReadTrficVioltnListBySearch(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadListBySearch = "TRAFFIC_VIOLATION.SP_READ_TRFICVIOLTN_BYSEARCH";
          OracleCommand cmdReadListBySearch = new OracleCommand();
          cmdReadListBySearch.CommandText = strQueryReadListBySearch;
          cmdReadListBySearch.CommandType = CommandType.StoredProcedure;
          cmdReadListBySearch.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadListBySearch.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          if (objEntityLayerTrafficVltn.SearchField.Trim() == "")
          {
              cmdReadListBySearch.Parameters.Add("TV_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
          }
          else
          {
              cmdReadListBySearch.Parameters.Add("TV_SEARCH_WORD", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.SearchField.Trim();
          }
          cmdReadListBySearch.Parameters.Add("TV_DATABASE_FIELD", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.DataBase_Field;
          cmdReadListBySearch.Parameters.Add("TV_OPTION", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Status_id;
          cmdReadListBySearch.Parameters.Add("TV_CANCEL", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CancelStatus;
          cmdReadListBySearch.Parameters.Add("TV_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategoryList = new DataTable();
          dtCategoryList = clsDataLayer.ExecuteReader(cmdReadListBySearch);
          return dtCategoryList;
      }
      // This Method will fetch traffic violation details  BY ID
      public DataTable ReadTraficVioltnById(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadById = "TRAFFIC_VIOLATION.SP_READ_TRFICVIOLTN_BY_ID";
          OracleCommand cmdReadById = new OracleCommand();
          cmdReadById.CommandText = strQueryReadById;
          cmdReadById.CommandType = CommandType.StoredProcedure;
          cmdReadById.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
          cmdReadById.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadById.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadById.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtDtl = new DataTable();
          dtDtl = clsDataLayer.ExecuteReader(cmdReadById);
          return dtDtl;
      }
      //Update  details to  table while reopening,add the value to traffic violation
      public void Reopen_TrficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
       //string strQueryUpdateWtrCard = "WATER_BILLING.SP_UPD_WTRCARD_BALANCE";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  //using (OracleCommand cmdUpdateWtrCrdBal = new OracleCommand(strQueryUpdateWtrCard, con))
                  //{
                  //    cmdUpdateWtrCrdBal.Transaction = tran;

                  //    cmdUpdateWtrCrdBal.CommandType = CommandType.StoredProcedure;

                  //    cmdUpdateWtrCrdBal.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                  //    cmdUpdateWtrCrdBal.Parameters.Add("W_CURNTAMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.CardCurrentAmnt;
                  //    cmdUpdateWtrCrdBal.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                  //    cmdUpdateWtrCrdBal.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
                  //    cmdUpdateWtrCrdBal.ExecuteNonQuery();

                  //}



                  string strQueryUpdateCnfrmStatus = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVIOLTN_CNFRM_STS";
                  using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateCnfrmStatus, con))
                  {
                      cmdUpdateStatus.Transaction = tran;

                      cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                      cmdUpdateStatus.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdUpdateStatus.Parameters.Add("TV_STATUS", OracleDbType.Int32).Value = 0;//confirmed
                      cmdUpdateStatus.Parameters.Add("TV_STS_USERID", OracleDbType.Int32).Value = null;
                      cmdUpdateStatus.Parameters.Add("TV_STS_DATE", OracleDbType.Date).Value = null;
                      cmdUpdateStatus.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdUpdateStatus.ExecuteNonQuery();
                  }

                  string strQueryUpdateReopenDtl = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN_CNFRMRECL";
                  using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateReopenDtl, con))
                  {
                      cmdUpdateStatus.Transaction = tran;

                      cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                      cmdUpdateStatus.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdUpdateStatus.Parameters.Add("TV_STS_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                      cmdUpdateStatus.Parameters.Add("TV_STS_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                      cmdUpdateStatus.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdUpdateStatus.ExecuteNonQuery();
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
      //Method for recall Cancelled traffic violation
      public void ReCallCanceledTrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryRecallCancelled = "TRAFFIC_VIOLATION.SP_RECALL_CNCLD_TRFCVLTN";
          using (OracleCommand cmdRecallCancelled = new OracleCommand())
          {
              cmdRecallCancelled.CommandText = strQueryRecallCancelled;
              cmdRecallCancelled.CommandType = CommandType.StoredProcedure;
              cmdRecallCancelled.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
              cmdRecallCancelled.Parameters.Add("TV_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
              cmdRecallCancelled.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
              clsDataLayer.ExecuteNonQuery(cmdRecallCancelled);
          }
      }
      //Method for cancel traffic violation
      public void CancelTrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryCancel = "TRAFFIC_VIOLATION.SP_CANCEL_TRFCVLTN";
          using (OracleCommand cmdCancel = new OracleCommand())
          {
              cmdCancel.CommandText = strQueryCancel;
              cmdCancel.CommandType = CommandType.StoredProcedure;
              cmdCancel.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
              cmdCancel.Parameters.Add("TV_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
              cmdCancel.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
              cmdCancel.Parameters.Add("TV_REASON", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.CancelReason;
              clsDataLayer.ExecuteNonQuery(cmdCancel);
          }
      }
      // This Method FETCHES  DETAILS BASED ON  ID FOR DISPALYING
      public DataTable ReadTrafficVioltnDetail(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryReadTVDtl = "TRAFFIC_VIOLATION.SP_READ_TRFCVLTN_DTL";
          OracleCommand cmdReadTVDtl = new OracleCommand();
          cmdReadTVDtl.CommandText = strQueryReadTVDtl;
          cmdReadTVDtl.CommandType = CommandType.StoredProcedure;
          cmdReadTVDtl.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
          cmdReadTVDtl.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdReadTVDtl.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdReadTVDtl.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtDtl = new DataTable();
          dtDtl = clsDataLayer.ExecuteReader(cmdReadTVDtl);
          return dtDtl;
      }
      //Update  details to  table
      public void Update_TrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnInsertDetails, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnUpdateDetails, string[] strarrCancldtlIds)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                  {
                      cmdUpdateTrfcVioltn.Transaction = tran;

                      cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;

                      cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_VHCLID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                      if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                      {
                          cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                      }
                      else
                      {
                          cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                      }
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTAMNT", OracleDbType.Decimal).Value = objEntityLayerTrafficVltn.RecptAmnt;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_UPDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                      //evm-0027
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_REFNO", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.RefNo;
                      //END
                      cmdUpdateTrfcVioltn.ExecuteNonQuery();

                  }
                  //Update to  traffic violation Detail table
                  foreach (clsEntityLayerTrafficViolationDtl objDetail in objEntityTrafficVioltnUpdateDetails)
                  {

                      string strQueryUpdateDetail = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN_DTL";
                      using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                      {
                          cmdUpdateDetail.Transaction = tran;

                          cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                          cmdUpdateDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                          cmdUpdateDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = objDetail.TrficVioltn_DtlId;
                          cmdUpdateDetail.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objDetail.Violtndate;
                          cmdUpdateDetail.Parameters.Add("TV_USRID", OracleDbType.Int32).Value = objDetail.UserId;
                          cmdUpdateDetail.Parameters.Add("TV_CMPLNTMSTRID", OracleDbType.Int32).Value = objDetail.Violation;
                          cmdUpdateDetail.Parameters.Add("TV_AMNT", OracleDbType.Decimal).Value = objDetail.VioltnAmnt;
                          cmdUpdateDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatusId;
                          cmdUpdateDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettledAmnt;
                          if (objDetail.Settleddate != DateTime.MinValue)
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.Settleddate;
                          }
                          else
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                          }
                          cmdUpdateDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                          if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                          }
                          else
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                          }
                          cmdUpdateDetail.ExecuteNonQuery();
                      }
                  }
                  //insert to  traffic violation Detail table
                  foreach (clsEntityLayerTrafficViolationDtl objDetail in objEntityTrafficVioltnInsertDetails)
                  {
                      string strQueryInsertDetail = "TRAFFIC_VIOLATION.SP_INSERT_TRFICVIOLTN_DTL";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                          cmdAddInsertDetail.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objDetail.Violtndate;
                          cmdAddInsertDetail.Parameters.Add("TV_USRID", OracleDbType.Int32).Value = objDetail.UserId;
                          cmdAddInsertDetail.Parameters.Add("TV_CMPLNTMSTRID", OracleDbType.Int32).Value = objDetail.Violation;
                          cmdAddInsertDetail.Parameters.Add("TV_AMNT", OracleDbType.Decimal).Value = objDetail.VioltnAmnt;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatusId;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettledAmnt;
                          if (objDetail.Settleddate != DateTime.MinValue)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.Settleddate;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                          }
                          cmdAddInsertDetail.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
                          cmdAddInsertDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                          if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                          }
                          cmdAddInsertDetail.ExecuteNonQuery();

                      }
                  }


                  //Cancel the rows that have been cancelled when editing in Detail table
                  foreach (string strDtlId in strarrCancldtlIds)
                  {
                      if (strDtlId != "" && strDtlId != null)
                      {
                          int intDtlId = Convert.ToInt32(strDtlId);

                          string strQueryCancelDetail = "TRAFFIC_VIOLATION.SP_CANCEL_TRFCVLTN_DTL";
                          using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                          {
                              cmdCancelDetail.Transaction = tran;

                              cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                              cmdCancelDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                              cmdCancelDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = intDtlId;

                              cmdCancelDetail.ExecuteNonQuery();
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
      //Update  details to  table
      public void Confirm_TraficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnInsertDetails, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnUpdateDetails, string[] strarrCancldtlIds)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {

                  using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                  {
                      cmdUpdateTrfcVioltn.Transaction = tran;

                      cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;

                      cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_VHCLID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                      if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                      {
                          cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                      }
                      else
                      {
                          cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                      }
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTAMNT", OracleDbType.Decimal).Value = objEntityLayerTrafficVltn.RecptAmnt;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_UPDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                      //EVM-0027
                      cmdUpdateTrfcVioltn.Parameters.Add("TV_REFNO", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.RefNo;
                      //END
                      cmdUpdateTrfcVioltn.ExecuteNonQuery();

                  }
                  //Update to  traffic violation Detail table
                  foreach (clsEntityLayerTrafficViolationDtl objDetail in objEntityTrafficVioltnUpdateDetails)
                  {

                      string strQueryUpdateDetail = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN_DTL";
                      using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                      {
                          cmdUpdateDetail.Transaction = tran;

                          cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                          cmdUpdateDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                          cmdUpdateDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = objDetail.TrficVioltn_DtlId;
                          cmdUpdateDetail.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objDetail.Violtndate;
                          cmdUpdateDetail.Parameters.Add("TV_USRID", OracleDbType.Int32).Value = objDetail.UserId;
                          cmdUpdateDetail.Parameters.Add("TV_CMPLNTMSTRID", OracleDbType.Int32).Value = objDetail.Violation;
                          cmdUpdateDetail.Parameters.Add("TV_AMNT", OracleDbType.Decimal).Value = objDetail.VioltnAmnt;
                          cmdUpdateDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatusId;
                          cmdUpdateDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettledAmnt;
                          if (objDetail.Settleddate != DateTime.MinValue)
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.Settleddate;
                          }
                          else
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                          }
                          cmdUpdateDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                          if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                          }
                          else
                          {
                              cmdUpdateDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                          }
                          cmdUpdateDetail.ExecuteNonQuery();
                      }
                  }
                  //insert to  traffic violation Detail table
                  foreach (clsEntityLayerTrafficViolationDtl objDetail in objEntityTrafficVioltnInsertDetails)
                  {
                      string strQueryInsertDetail = "TRAFFIC_VIOLATION.SP_INSERT_TRFICVIOLTN_DTL";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                          cmdAddInsertDetail.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objDetail.Violtndate;
                          cmdAddInsertDetail.Parameters.Add("TV_USRID", OracleDbType.Int32).Value = objDetail.UserId;
                          cmdAddInsertDetail.Parameters.Add("TV_CMPLNTMSTRID", OracleDbType.Int32).Value = objDetail.Violation;
                          cmdAddInsertDetail.Parameters.Add("TV_AMNT", OracleDbType.Decimal).Value = objDetail.VioltnAmnt;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatusId;
                          cmdAddInsertDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettledAmnt;
                          if (objDetail.Settleddate != DateTime.MinValue)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.Settleddate;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                          }
                          cmdAddInsertDetail.Parameters.Add("TV_CORPID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
                          cmdAddInsertDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;

                          if (objEntityLayerTrafficVltn.StldUser_Id == 0)
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                          }
                          else
                          {
                              cmdAddInsertDetail.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StldUser_Id;
                          }
                          cmdAddInsertDetail.ExecuteNonQuery();

                      }
                  }


                  //Cancel the rows that have been cancelled when editing in Detail table
                  foreach (string strDtlId in strarrCancldtlIds)
                  {
                      if (strDtlId != "" && strDtlId != null)
                      {
                          int intDtlId = Convert.ToInt32(strDtlId);

                          string strQueryCancelDetail = "TRAFFIC_VIOLATION.SP_CANCEL_TRFCVLTN_DTL";
                          using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                          {
                              cmdCancelDetail.Transaction = tran;

                              cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                              cmdCancelDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                              cmdCancelDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = intDtlId;

                              cmdCancelDetail.ExecuteNonQuery();
                          }
                      }
                  }

                  //---------------------------------------------------------------------------change other than update method is code below


                  string strQueryUpdateStatus = "TRAFFIC_VIOLATION.SP_UPDATE_TRFCVLTN_CNFRM_STS";
                  using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateStatus, con))
                  {
                      cmdUpdateStatus.Transaction = tran;

                      cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                      cmdUpdateStatus.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
                      cmdUpdateStatus.Parameters.Add("TV_STATUS", OracleDbType.Int32).Value = 1;//confirmed
                      cmdUpdateStatus.Parameters.Add("TV_STS_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                      cmdUpdateStatus.Parameters.Add("TV_STS_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                      cmdUpdateStatus.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
                      cmdUpdateStatus.ExecuteNonQuery();
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
      // This Method checks Duplicate ReceiptNo
      public DataTable CheckDupReceiptNo(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryCheckReceiptNo = "TRAFFIC_VIOLATION.SP_CHECK_DUP_RCPT_NUMBER";
          OracleCommand cmdCheckReceiptNo = new OracleCommand();

          cmdCheckReceiptNo.CommandText = strQueryCheckReceiptNo;
          cmdCheckReceiptNo.CommandType = CommandType.StoredProcedure;
          if (objEntityLayerTrafficVltn.VehicleId != 0)
          {
              cmdCheckReceiptNo.Parameters.Add("TVS_VHCL_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
          }
          else
          {
              cmdCheckReceiptNo.Parameters.Add("TVS_VHCL_ID", OracleDbType.Int32).Value = null;
          }
          cmdCheckReceiptNo.Parameters.Add("TVS_RCPT", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;
          cmdCheckReceiptNo.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdCheckReceiptNo.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdCheckReceiptNo.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtDtl = new DataTable();
          dtDtl = clsDataLayer.ExecuteReader(cmdCheckReceiptNo);
          return dtDtl;

      }
      
      public string CheckDupReceiptNoByID(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
      {
          string strQueryCheckReceiptNoByID = "TRAFFIC_VIOLATION.SP_CHECK_DUP_RCPT_NUMBER_BYID";
          OracleCommand cmdCheckReceiptNo = new OracleCommand();

          cmdCheckReceiptNo.CommandText = strQueryCheckReceiptNoByID;
          cmdCheckReceiptNo.CommandType = CommandType.StoredProcedure;
          if (objEntityLayerTrafficVltn.TrafficVltnId != 0)
          {
              cmdCheckReceiptNo.Parameters.Add("TVS_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.TrafficVltnId;
          }
          else
          {
              cmdCheckReceiptNo.Parameters.Add("TVS_ID", OracleDbType.Int32).Value = null;
          }
         
          cmdCheckReceiptNo.Parameters.Add("TVS_RCPT", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNumber;
          cmdCheckReceiptNo.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Organisation_Id;
          cmdCheckReceiptNo.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorpOffice_Id;
          cmdCheckReceiptNo.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdCheckReceiptNo);
          string strReturn = cmdCheckReceiptNo.Parameters["D_COUNT"].Value.ToString();
          cmdCheckReceiptNo.Dispose();
          return strReturn;

      }
    }
}
