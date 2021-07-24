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
   public class clsDatalayerWelfareServiceTransaction
    {
        public DataTable ReadEmployee(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_EMPLOYEE_TABLE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objentityPassport.division;
            cmdReadJob.Parameters.Add("P_DSGNTN", OracleDbType.Int32).Value = objentityPassport.designation;
            cmdReadJob.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objentityPassport.employee;
            cmdReadJob.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objentityPassport.department;
            cmdReadJob.Parameters.Add("P_EMP_TYPE", OracleDbType.Int32).Value = objentityPassport.EmployeeType;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmpServiceCtgry(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_WELFARE_SERVICES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objentityPassport.employee;
            cmdReadJob.Parameters.Add("D_DESGID", OracleDbType.Int32).Value = objentityPassport.designation;
            cmdReadJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmployeeDDL(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_EMPLOYEE_DDL";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objentityPassport.division;
            cmdReadJob.Parameters.Add("P_DSGNTN", OracleDbType.Int32).Value = objentityPassport.designation;
            cmdReadJob.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objentityPassport.department;
            cmdReadJob.Parameters.Add("P_EMP_TYPE", OracleDbType.Int32).Value = objentityPassport.EmployeeType;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public DataTable ReadServiceDtlEmp(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_SERVICE_DTL";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_SERID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objentityPassport.employee;
            cmdReadJob.Parameters.Add("P_DATE", OracleDbType.Date).Value = objentityPassport.Date;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public void insertServEmpData(clsEntityWelfareServiceTransaction objentityPassport, List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_WELFARE_SER_TRANSACTION.SP_INSERT_WLFR_SERV_EMP_DATA";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;

                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_WELFARE_SERVICE_TRANS);
                        objEntCommon.CorporateID = objentityPassport.CorpId;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objentityPassport.ServiceId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("SRVCTRANS_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                        cmdAddService.Parameters.Add("DESG_ID", OracleDbType.Int32).Value = objentityPassport.designation;
                        if(objentityPassport.division!=0)
                        cmdAddService.Parameters.Add("DIVSN_ID", OracleDbType.Int32).Value = objentityPassport.division;
                        else
                            cmdAddService.Parameters.Add("DIVSN_ID", OracleDbType.Int32).Value = null;
                        if(objentityPassport.employee!=0)
                            cmdAddService.Parameters.Add("EMP_ID", OracleDbType.Int32).Value = objentityPassport.employee;
                        else
                            cmdAddService.Parameters.Add("EMP_ID", OracleDbType.Int32).Value = null;
                        cmdAddService.Parameters.Add("ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objentityPassport.UserId;
                        cmdAddService.Parameters.Add("USR_DATE", OracleDbType.Date).Value = System.DateTime.Now;

                        if (objentityPassport.department != 0)
                            cmdAddService.Parameters.Add("DEPT_ID", OracleDbType.Int32).Value = objentityPassport.department;
                        else
                            cmdAddService.Parameters.Add("DEPT_ID", OracleDbType.Int32).Value = null;
                        if (objentityPassport.ServiceDateId != 0)
                            cmdAddService.Parameters.Add("SERV_ID", OracleDbType.Int32).Value = objentityPassport.ServiceDateId;
                        else
                            cmdAddService.Parameters.Add("SERV_ID", OracleDbType.Int32).Value = null;
                        cmdAddService.Parameters.Add("EMP_TYPE", OracleDbType.Int32).Value = objentityPassport.EmployeeType;
                        cmdAddService.ExecuteNonQuery();
                    }

                        foreach (clsEntityWelfareServiceTransactionDtl objDetail in objEntityTrficVioltnDetilsList)
                        {

                            string strQueryInsertDetails = "HCM_WELFARE_SER_TRANSACTION.SP_INS_WLFR_SERV_EMP_DATA_DTL";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVCTRANS_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                                cmdAddInsertDetail.Parameters.Add("EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                                cmdAddInsertDetail.Parameters.Add("SERVID", OracleDbType.Int32).Value = objDetail.ServiceId;
                                cmdAddInsertDetail.Parameters.Add("ALLOT_DATE", OracleDbType.Date).Value = objDetail.AllotedDate;
                                cmdAddInsertDetail.Parameters.Add("ALLOT_NUM", OracleDbType.Decimal).Value = objDetail.AllotedNum;
                                cmdAddInsertDetail.Parameters.Add("REMAIN", OracleDbType.Decimal).Value = objDetail.RemainingNum;
                                cmdAddInsertDetail.Parameters.Add("STS", OracleDbType.Int32).Value = 0;
                                cmdAddInsertDetail.Parameters.Add("TOT_ALLOT_NUM", OracleDbType.Decimal).Value = objDetail.TotalAllot;
                                cmdAddInsertDetail.Parameters.Add("COLOR_STS", OracleDbType.Int32).Value = objDetail.ColorStatus;
                                cmdAddInsertDetail.Parameters.Add("AVAILBTY", OracleDbType.Varchar2).Value = objDetail.Availability;
                                cmdAddInsertDetail.Parameters.Add("LIMIT", OracleDbType.Varchar2).Value = objDetail.Limit;
                                cmdAddInsertDetail.Parameters.Add("SERVDATE_ID", OracleDbType.Int32).Value = objDetail.ServiceDateId;
                                cmdAddInsertDetail.ExecuteNonQuery();
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
        public DataTable ReadServiceTransList(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_STS", OracleDbType.Int32).Value = objentityPassport.CancelStatus;
            if (objentityPassport.FromDate != DateTime.MinValue)
            {
                cmdReadJob.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objentityPassport.FromDate;
            }
            else
            {
                cmdReadJob.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = null;
            }
            if (objentityPassport.ToDate != DateTime.MinValue)
            {
                cmdReadJob.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objentityPassport.ToDate;
            }
            else
            {
                cmdReadJob.Parameters.Add("P_TODATE", OracleDbType.Date).Value = null;
            }
            cmdReadJob.Parameters.Add("P_CNCLSTS", OracleDbType.Int32).Value = objentityPassport.CnclStsCbx;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable readServTransDtlById(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_SERVTRANS_BY_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable readEmpWiseData(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_SERVTRANS_BY_USRID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objentityPassport.UserId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void updateServEmpData(clsEntityWelfareServiceTransaction objentityPassport, List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_WELFARE_SER_TRANSACTION.SP_UPDATE_WLFR_SERV_EMP_DATA";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("SRVCTRANS_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objentityPassport.UserId;
                        cmdAddService.Parameters.Add("USR_DATE", OracleDbType.Date).Value = System.DateTime.Now;
                        cmdAddService.Parameters.Add("STS", OracleDbType.Int32).Value = objentityPassport.CancelStatus;
                        cmdAddService.ExecuteNonQuery();
                    }

                    string strQueryInsertDetailsS = "HCM_WELFARE_SER_TRANSACTION.SP_DEL_WLFR_SERV_EMP_DATA_DTL";
                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetailsS, con))
                    {
                        cmdAddInsertDetail.Transaction = tran;
                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddInsertDetail.Parameters.Add("SRVCTRANS_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                        cmdAddInsertDetail.ExecuteNonQuery();
                    }

                    foreach (clsEntityWelfareServiceTransactionDtl objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "HCM_WELFARE_SER_TRANSACTION.SP_INS_WLFR_SERV_EMP_DATA_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("SRVCTRANS_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                            cmdAddInsertDetail.Parameters.Add("EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                            cmdAddInsertDetail.Parameters.Add("SERVID", OracleDbType.Int32).Value = objDetail.ServiceId;
                            cmdAddInsertDetail.Parameters.Add("ALLOT_DATE", OracleDbType.Date).Value = objDetail.AllotedDate;
                            cmdAddInsertDetail.Parameters.Add("ALLOT_NUM", OracleDbType.Decimal).Value = objDetail.AllotedNum;
                            cmdAddInsertDetail.Parameters.Add("REMAIN", OracleDbType.Decimal).Value = objDetail.RemainingNum;
                            cmdAddInsertDetail.Parameters.Add("STS", OracleDbType.Int32).Value = objentityPassport.CancelStatus;
                            cmdAddInsertDetail.Parameters.Add("TOT_ALLOT_NUM", OracleDbType.Decimal).Value = objDetail.TotalAllot;
                            cmdAddInsertDetail.Parameters.Add("COLOR_STS", OracleDbType.Int32).Value = objDetail.ColorStatus;
                            cmdAddInsertDetail.Parameters.Add("AVAILBTY", OracleDbType.Varchar2).Value = objDetail.Availability;
                            cmdAddInsertDetail.Parameters.Add("LIMITS", OracleDbType.Varchar2).Value = objDetail.Limit;
                            cmdAddInsertDetail.Parameters.Add("SERVDATE_ID", OracleDbType.Int32).Value = objDetail.ServiceDateId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public DataTable ReadServiceDtlEmpDate(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_READ_SERVICE_DTL_DATE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_SERID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objentityPassport.employee;
            cmdReadJob.Parameters.Add("P_DATE1", OracleDbType.Varchar2).Value = objentityPassport.Date1Month;
            cmdReadJob.Parameters.Add("P_DATE2", OracleDbType.Varchar2).Value = objentityPassport.Date2Month;
            cmdReadJob.Parameters.Add("P_YEAR", OracleDbType.Varchar2).Value = objentityPassport.DateYear;
            cmdReadJob.Parameters.Add("P_FRQNCY", OracleDbType.Int32).Value = objentityPassport.CancelStatus;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable CheckServDtlDateDup(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_CHK_SERV_DTL_DATE_DUP";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_SERID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objentityPassport.employee;
            cmdReadJob.Parameters.Add("P_DATE", OracleDbType.Date).Value = objentityPassport.Date;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDivisionDDL(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_RD_DIVISION_DDL";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objentityPassport.department;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }


        public DataTable ReadServiceSearch(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_RD_SERV_SEARCH_DDL";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objentityPassport.CorpId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objentityPassport.OrgId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void CancelWelfareTransctn(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryCancelCategory = "HCM_WELFARE_SER_TRANSACTION.SP_CANCEL_WELFARE_TRANS";
            using (OracleCommand cmdCancelCategory = new OracleCommand())
            {
                cmdCancelCategory.CommandText = strQueryCancelCategory;
                cmdCancelCategory.CommandType = CommandType.StoredProcedure;
                cmdCancelCategory.Parameters.Add("P_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
                cmdCancelCategory.Parameters.Add("P_CNSL_USRID", OracleDbType.Int32).Value = objentityPassport.UserId;
                cmdCancelCategory.Parameters.Add("P_CNSL_RSN", OracleDbType.Varchar2).Value = objentityPassport.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCategory);
            }
        }
        public DataTable checkConfrmSts(clsEntityWelfareServiceTransaction objentityPassport)
        {
            string strQueryReadPayGrd = "HCM_WELFARE_SER_TRANSACTION.SP_CHK_CNFRM_STS";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objentityPassport.ServiceId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }


    }
}
