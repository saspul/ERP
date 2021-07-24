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
// CREATED BY:EVM-0012
// CREATED DATE:28/03/2017
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerTrafficViolationSettlement
    {
        // This Method will fetch Pending Violations
        public DataTable ReadViolations(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            string strQueryReadViolations = "TRAFFIC_VIOLATION_SETTLEMENT.SP_READ_PENDING_VIOLATIONS";
            OracleCommand cmdReadViolations = new OracleCommand();
            cmdReadViolations.CommandText = strQueryReadViolations;
            cmdReadViolations.CommandType = CommandType.StoredProcedure;
            cmdReadViolations.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityTrafficViolation.Org_Id;
            cmdReadViolations.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.CorporateId;
            cmdReadViolations.Parameters.Add("TVS_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtViolations = new DataTable();
            dtViolations = clsDataLayer.ExecuteReader(cmdReadViolations);
            return dtViolations;
        }
        // This Method will fetch Pending Violations By Vehicle ID
        public DataTable ReadViolationsByVehID(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            string strQueryReadViolationsByVehID = "TRAFFIC_VIOLATION_SETTLEMENT.SP_READ_VIOLATIONS_BY_VHCL_ID";
            OracleCommand cmdReadViolations = new OracleCommand();
            cmdReadViolations.CommandText = strQueryReadViolationsByVehID;
            cmdReadViolations.CommandType = CommandType.StoredProcedure;
            cmdReadViolations.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityTrafficViolation.Org_Id;
            cmdReadViolations.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.CorporateId;
            cmdReadViolations.Parameters.Add("TVS_VHCL_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.VehicleId;
            cmdReadViolations.Parameters.Add("TVS_RCPTNUM", OracleDbType.Varchar2).Value = objEntityTrafficViolation.ReceiptNo;
            cmdReadViolations.Parameters.Add("TVS_STLDSTATS", OracleDbType.Int32).Value = objEntityTrafficViolation.StlStatus;
            if (objEntityTrafficViolation.CancelStatus != 0)
            {
                cmdReadViolations.Parameters.Add("TVS_CNCL_STS", OracleDbType.Int32).Value = objEntityTrafficViolation.CancelStatus;
            }
            else
            {
                cmdReadViolations.Parameters.Add("TVS_CNCL_STS", OracleDbType.Int32).Value = null;

            }
                cmdReadViolations.Parameters.Add("TVS_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtViolationsByVehID = new DataTable();
            dtViolationsByVehID = clsDataLayer.ExecuteReader(cmdReadViolations);
            return dtViolationsByVehID;
        }
        // This Method will fetch Employees
        public DataTable ReadEmployees(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            string strQueryReadEmployees = "TRAFFIC_VIOLATION_SETTLEMENT.SP_READ_EMPLOYEES";
            OracleCommand cmdReadEmployees = new OracleCommand();
            cmdReadEmployees.CommandText = strQueryReadEmployees;
            cmdReadEmployees.CommandType = CommandType.StoredProcedure;
            cmdReadEmployees.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityTrafficViolation.Org_Id;
            cmdReadEmployees.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.CorporateId;
            cmdReadEmployees.Parameters.Add("TVS_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmployees = new DataTable();
            dtEmployees = clsDataLayer.ExecuteReader(cmdReadEmployees);
            return dtEmployees;
        }


        //New
        //Update  details to  table
        public void Update_TrafficVioltn(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION_SETTLEMENT.SP_UPDATE_TRFCVLTN";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    {
                    using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                    {
                        cmdUpdateTrfcVioltn.Transaction = tran;

                        cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;

                        cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objDetail.TrfcVioltn_ID;
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_VHCLID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNo;

                        if (objEntityLayerTrafficVltn.StlUserId == 0)
                        {
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STLDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StlUserId;
                        }
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_RCPTAMNT", OracleDbType.Decimal).Value = objEntityLayerTrafficVltn.ReceiptAmt;
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
                        cmdUpdateTrfcVioltn.Parameters.Add("TV_UPDUSERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                        //cmdUpdateTrfcVioltn.Parameters.Add("TV_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.D_Date;
                        cmdUpdateTrfcVioltn.ExecuteNonQuery();

                    }}
                    //Update to  traffic violation Detail table
                    foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    {

                        string strQueryUpdateDetail = "TRAFFIC_VIOLATION_SETTLEMENT.SP_UPDATE_TRFCVLTN_DTL";
                        using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                        {
                            cmdUpdateDetail.Transaction = tran;

                            cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                            cmdUpdateDetail.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objDetail.TrfcVioltn_ID;
                            cmdUpdateDetail.Parameters.Add("TV_DTLID", OracleDbType.Int32).Value = objDetail.TrfcVioltnDtl_ID;
                            cmdUpdateDetail.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNo;                           
                            cmdUpdateDetail.Parameters.Add("TV_STLDSTATS", OracleDbType.Int32).Value = objDetail.StldStatus;
                            cmdUpdateDetail.Parameters.Add("TV_STLDAMNT", OracleDbType.Decimal).Value = objDetail.SettleAmount;
                            
                            if (objEntityLayerTrafficVltn.StlUserId == 0)
                            {
                                cmdUpdateDetail.Parameters.Add("TV_STLD_USRID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdUpdateDetail.Parameters.Add("TV_STLD_USRID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StlUserId;
                            }
                            if (objDetail.SetldDate != DateTime.MinValue)
                            {
                                cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = objDetail.SetldDate;
                            }
                            else
                            {
                                cmdUpdateDetail.Parameters.Add("TV_STLDDATE", OracleDbType.Date).Value = null;
                            }
                            cmdUpdateDetail.ExecuteNonQuery();
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
            string strQueryUpdateReceiptAmt = "TRAFFIC_VIOLATION_SETTLEMENT.SP_UPD_RCPT_AMNT_BYID";
            OracleTransaction tran2;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran2 = con.BeginTransaction();

                try
                {
                    foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    {
                        using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateReceiptAmt, con))
                        {
                            cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objDetail.TrfcVioltn_ID;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
                            cmdUpdateTrfcVioltn.ExecuteNonQuery();
                        }
                    }
                    tran2.Commit();

                }
                catch (Exception e)
                {
                    tran2.Rollback();
                    throw e;
                }
            }
        }
        // This Method will fetch Settled Violations
        public DataTable ReadSettledViolations(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            string strQueryReadViolations = "TRAFFIC_VIOLATION_SETTLEMENT.SP_READ_SETTLED_VIOLATIONS";
            OracleCommand cmdReadViolations = new OracleCommand();
            cmdReadViolations.CommandText = strQueryReadViolations;
            cmdReadViolations.CommandType = CommandType.StoredProcedure;
            cmdReadViolations.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityTrafficViolation.Org_Id;
            cmdReadViolations.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.CorporateId;
            if (objEntityTrafficViolation.FromDate == DateTime.MinValue)
            {
                cmdReadViolations.Parameters.Add("TVS_FROM_DATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadViolations.Parameters.Add("TVS_FROM_DATE", OracleDbType.Date).Value = objEntityTrafficViolation.FromDate;
            }
            if (objEntityTrafficViolation.ToDate == DateTime.MinValue)
            {
                cmdReadViolations.Parameters.Add("TVS_TO_DATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadViolations.Parameters.Add("TVS_TO_DATE", OracleDbType.Date).Value = objEntityTrafficViolation.ToDate;

            }
                 if (objEntityTrafficViolation.CancelStatus == 1)
            {
                cmdReadViolations.Parameters.Add("TVS_CNCL_STS", OracleDbType.Int32).Value = objEntityTrafficViolation.CancelStatus;
            }
            else
            {
                cmdReadViolations.Parameters.Add("TVS_CNCL_STS", OracleDbType.Int32).Value = null;

            }
                cmdReadViolations.Parameters.Add("TVS_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtViolations = new DataTable();
            dtViolations = clsDataLayer.ExecuteReader(cmdReadViolations);
            return dtViolations;
        }
        // This Method will fetch VEHICLE No  and in case of Settled entry Details are fetched
        public DataTable ReadVehicleNoDtl(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            string strQueryReadViolations = "TRAFFIC_VIOLATION_SETTLEMENT.SP_READ_VHCL_NO_DTL";
            OracleCommand cmdReadViolations = new OracleCommand();
            cmdReadViolations.CommandText = strQueryReadViolations;
            cmdReadViolations.CommandType = CommandType.StoredProcedure;
            cmdReadViolations.Parameters.Add("TV_VHCL_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.VehicleId;
            cmdReadViolations.Parameters.Add("TV_RCPTNUM", OracleDbType.Varchar2).Value = objEntityTrafficViolation.ReceiptNo;
            cmdReadViolations.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityTrafficViolation.Org_Id;
            cmdReadViolations.Parameters.Add("TV_CORPRT_ID", OracleDbType.Int32).Value = objEntityTrafficViolation.CorporateId;
            cmdReadViolations.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtViolations = new DataTable();
            dtViolations = clsDataLayer.ExecuteReader(cmdReadViolations);
            return dtViolations;
        }
        // This Method will confirm 


        public void ConfirmSettlement(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION_SETTLEMENT.SP_UPDATE_TRFCVLTN_CNFRM_STS";
            OracleTransaction tran;
            
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    {
                        using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                        {
                            cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objDetail.TrfcVioltn_ID;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STATUS", OracleDbType.Int32).Value = 1;//confirmed
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STS_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STS_DATE", OracleDbType.Date).Value = objEntityLayerTrafficVltn.Date;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
                            cmdUpdateTrfcVioltn.ExecuteNonQuery();
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
        //To re open
        public void ReOpenTrafficViolation(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION_SETTLEMENT.SP_UPDATE_TRFCVLTN_CNFRM_STS";
            OracleTransaction tran;
            
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    {
                        using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                        {
                            cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objDetail.TrfcVioltn_ID;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STATUS", OracleDbType.Int32).Value = 0;//to re open
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STS_USERID", OracleDbType.Int32).Value = null;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_STS_DATE", OracleDbType.Date).Value = null;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
                            cmdUpdateTrfcVioltn.ExecuteNonQuery();
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
        
        // This Method checks Duplicate ReceiptNo
        //public string CheckDupReceiptNo(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn)
        //{
        //    string strQueryCheckReceiptNo = "TRAFFIC_VIOLATION_SETTLEMENT.SP_CHECK_DUP_RCPT_NUMBER";
        //    OracleCommand cmdCheckReceiptNo = new OracleCommand();

        //    cmdCheckReceiptNo.CommandText = strQueryCheckReceiptNo;
        //    cmdCheckReceiptNo.CommandType = CommandType.StoredProcedure;
        //    if (objEntityLayerTrafficVltn.VehicleId != 0)
        //    {
        //        cmdCheckReceiptNo.Parameters.Add("TVS_VHCL_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.VehicleId;
        //    }
        //    else
        //    {
        //        cmdCheckReceiptNo.Parameters.Add("TVS_VHCL_ID", OracleDbType.Int32).Value = null;
        //    }
        //        cmdCheckReceiptNo.Parameters.Add("TVS_RCPT", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNo;
        //    cmdCheckReceiptNo.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
        //    cmdCheckReceiptNo.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
        //    cmdCheckReceiptNo.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
        //    clsDataLayer.ExecuteScalar(ref cmdCheckReceiptNo);
        //    string strReturn = cmdCheckReceiptNo.Parameters["D_COUNT"].Value.ToString();
        //    cmdCheckReceiptNo.Dispose();
        //    return strReturn;

        //}
        //To re open
        public void CancelTrafficViolationByList(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            string strQueryUpdateTrfcVioltn = "TRAFFIC_VIOLATION_SETTLEMENT.SP_CANCEL_TRFCVLTN";
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    //foreach (clsEntityLayerSettleList objDetail in objEntityLayerSettleList)
                    //{
                        using (OracleCommand cmdUpdateTrfcVioltn = new OracleCommand(strQueryUpdateTrfcVioltn, con))
                        {
                            cmdUpdateTrfcVioltn.CommandType = CommandType.StoredProcedure;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_USERID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.User_Id;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_REASON", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.CancelReason;
                            cmdUpdateTrfcVioltn.Parameters.Add("TV_RECPT", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.StlUserId;
                            cmdUpdateTrfcVioltn.ExecuteNonQuery();
                        }
                    //}
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
        public DataTable CheckDupReceiptNo(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn)
        {
            string strQueryCheckReceiptNo = "TRAFFIC_VIOLATION_SETTLEMENT.SP_CHECK_DUP_RCPT_NUMBER";
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
            cmdCheckReceiptNo.Parameters.Add("TVS_RCPT", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNo;
            cmdCheckReceiptNo.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
            cmdCheckReceiptNo.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
            cmdCheckReceiptNo.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdCheckReceiptNo);
            return dtDtl;

        }
        public DataTable CheckDupReceiptNoByID(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn)
        {
            string strQueryCheckReceiptNo = "TRAFFIC_VIOLATION_SETTLEMENT.SP_CHECK_DUP_RCPT_NUMBER_BYID";
            OracleCommand cmdCheckReceiptNo = new OracleCommand();

            cmdCheckReceiptNo.CommandText = strQueryCheckReceiptNo;
            cmdCheckReceiptNo.CommandType = CommandType.StoredProcedure;
            cmdCheckReceiptNo.Parameters.Add("TVS_RCPT", OracleDbType.Varchar2).Value = objEntityLayerTrafficVltn.ReceiptNo;
            cmdCheckReceiptNo.Parameters.Add("TVS_ORGID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.Org_Id;
            cmdCheckReceiptNo.Parameters.Add("TVS_CORPRT_ID", OracleDbType.Int32).Value = objEntityLayerTrafficVltn.CorporateId;
            cmdCheckReceiptNo.Parameters.Add("TV_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdCheckReceiptNo);
            return dtDtl;

        }
    }
}
