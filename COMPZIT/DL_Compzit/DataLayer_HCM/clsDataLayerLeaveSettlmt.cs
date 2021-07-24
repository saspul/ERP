using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerLeaveSettlmt
    {
        //read employee details

        public DataTable ReadOffDays(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_OFFDAYS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadMonthlyOffDays(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_MONTHLYOFFDAYS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadHoliday(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_HOLIDAY";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.FromDate;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
     

        public DataTable ReadEmpLeaveTypes(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_EMP_DETAILS_LEAVETYPES";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


        public DataTable ReadEmpDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_EMP_DETAILS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee's leave details
        public DataTable ReadLeaveDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEAVE_DETAILS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        //read employee's TOTAL LEAVE
        public DataTable ReadTotalLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_TOTAL_EMPLOYEE_LEAVE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee rejoin date
        public DataTable ReadRejoin(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_REJOIN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        //read employee opening rejoin date
        public DataTable ReadOpenRejoin(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_OPEN_REJOIN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        //read employee join date if no rejoin date
        public DataTable ReadJoinDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_JOINDT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        //read employee insert date if no join date
        public DataTable ReadInsertDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_INSERTDT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read basic pay of employee
        public DataTable ReadBasicPay(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_BASIC_PAY";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }
        //read allowance of employee
        public DataTable ReadAllowance(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_ALLOWANCE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }
        //read deductn of employee
        public DataTable ReadDeduction(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_DEDUCTN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }
        //insert  leave settlmt for the employee OtherAmt
        public void InsertEmployeeDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList) 
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strReturn = "";
                    string strQueryAddExit = "LEAVE_SETTLEMENT.SP_INS_EMP_DETAILS";
                    using (OracleCommand cmdAddEmp = new OracleCommand(strQueryAddExit, con))
                    {
                        cmdAddEmp.CommandText = strQueryAddExit;
                        cmdAddEmp.CommandType = CommandType.StoredProcedure;
                        cmdAddEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                        cmdAddEmp.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                        cmdAddEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_SETTLMTDAYS", OracleDbType.Double).Value = objEntityLeaveSettlmt.SettlmtDays;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_COMMNT", OracleDbType.Varchar2).Value = objEntityLeaveSettlmt.Remarks;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_REJOINDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.RejoinDate;
                        if (objEntityLeaveSettlmt.SettlmtDate != DateTime.MinValue)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LST_SETLMTDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LST_SETLMTDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_BASIC_PAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.BasicPay;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_ADDITN_AMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Allowance;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_DEDUCTN_AMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Deduction;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_TOTAL_PAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.TotalPay;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_SAL_PERDAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.SalaryPerDay;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEVSALARY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.LeaveSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PRVMNTH_SAL", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMnthSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_CRNTMNTH_SAL", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.CurrentMnthSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_TICKTAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.TicktAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OTHERAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OtherAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OTHERDEDCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OtherDeductionAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_NETAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.NetAmount;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_INS_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.Date;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OVERTM", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Overtm;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PYMNT_DEDUCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PaymntDeductn;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_MESS_DEDTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.DedctnMess;
                        if (objEntityLeaveSettlmt.LeaveId != 0)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVE", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVE", OracleDbType.Int32).Value = null;
                        }

                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_FIXED_ALLOWNC_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.FixedAllowance;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_MODE", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Mode;
                        if (objEntityLeaveSettlmt.Mode == 1)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_DATE_SETTLE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateSettle;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_DATE_SETTLE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_DAYSDEDUCT", OracleDbType.Varchar2).Value = objEntityLeaveSettlmt.CnclReason;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_ELIGBL_OPEN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OpenElgibleDays;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVESAL_OPEN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OpenLeaveSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.LeaveArrearAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_ADDITON_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevAdditionAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OVERTIME_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOvertimeAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevArrearAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_DEDUCTN_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevDeductionAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_PAYMNT_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevPaymntDedAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_MESSDED_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMessDedAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OTHERAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOtherAddAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OTHERDEDCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOtherDedAmnt;
                        cmdAddEmp.Parameters.Add("E_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.FromDate;
                        cmdAddEmp.Parameters.Add("E_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.ToDate;
                        cmdAddEmp.Parameters.Add("E_PREV_MNTH_ARR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMnthArrAmt;
                        if (objEntityLeaveSettlmt.PrevMntRejoinDate != DateTime.MinValue)
                        {
                            cmdAddEmp.Parameters.Add("E_PREV_MNTH_REJOIN", OracleDbType.Date).Value = objEntityLeaveSettlmt.PrevMntRejoinDate;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_PREV_MNTH_REJOIN", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEmp.Parameters.Add("E_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddEmp.ExecuteNonQuery();
                        strReturn = cmdAddEmp.Parameters["E_OUT"].Value.ToString();
                        cmdAddEmp.Dispose();
                    }
                    foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityAdditionList)
                    {                      
                            string strQuerySubDetail = "LEAVE_SETTLEMENT.SP_INS_ADDITION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_ALWID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                                cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                                cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                    }
                    foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityDeductionList)
                    {
                            string strQuerySubDetail = "LEAVE_SETTLEMENT.SP_INS_DEDUCTION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_DEDID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_PERCTG", OracleDbType.Decimal).Value = objSubSettlmt.Percentge;
                                cmdAddSubDetail.Parameters.Add("E_AMNT_PER_STS", OracleDbType.Int32).Value = objSubSettlmt.PercOrAmountChk;
                                cmdAddSubDetail.Parameters.Add("E_BASIC_TOTAL_STS", OracleDbType.Int32).Value = objSubSettlmt.BasicOrTotalAmtChk;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                                cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                                cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                                cmdAddSubDetail.ExecuteNonQuery();
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
        //read leave settlmt list 
        public DataTable ReadLeaveSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEAVE_SETTLMT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_SETTLMT_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.ConfrmStatus;
            cmdReadEmp.Parameters.Add("E_CANCEL", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CancelStatus;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }
        //read leave settlmt for respective employee
        public DataTable ReadLeaveSettlmt_ById(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEAVE_SETTLMT_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_LEVSETLMT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }

        //update employee leave settlmt
        public void UpdateEmployeeDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt, List<clsEntityLayerLeaveSettlmt> objEntityLeaveTypSettlmt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryAddExit = "LEAVE_SETTLEMENT.SP_UPD_EMP_DETAILS";
                    using (OracleCommand cmdAddEmp = new OracleCommand())
                    {
                        cmdAddEmp.Transaction = tran;
                        cmdAddEmp.CommandText = strQueryAddExit;
                        cmdAddEmp.CommandType = CommandType.StoredProcedure;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
                        cmdAddEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                        cmdAddEmp.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                        cmdAddEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_SETTLMTDAYS", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.SettlmtDays;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_COMMNT", OracleDbType.Varchar2).Value = objEntityLeaveSettlmt.Remarks;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_REJOINDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.RejoinDate;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_BASIC_PAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.BasicPay;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_ADDITN_AMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Allowance;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_DEDUCTN_AMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Deduction;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_TOTAL_PAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.TotalPay;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_SAL_PERDAY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.SalaryPerDay;
                        if (objEntityLeaveSettlmt.SettlmtDate != DateTime.MinValue)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LST_SETLMTDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LST_SETLMTDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEVSALARY", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.LeaveSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PRVMNTH_SAL", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMnthSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_CRNTMNTH_SAL", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.CurrentMnthSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_TICKTAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.TicktAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OTHERAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OtherAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OTHERDEDCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OtherDeductionAmt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_NETAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.NetAmount;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_CONFRMSTS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.ConfrmStatus;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_INS_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.Date;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_OVERTM", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.Overtm;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PYMNT_DEDUCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PaymntDeductn;
                        if (objEntityLeaveSettlmt.LeaveId != 0)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVE", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVE", OracleDbType.Int32).Value = null;
                        }
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_FIXED_ALLOWNC_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.FixedAllowance;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_MODE", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Mode;
                        if (objEntityLeaveSettlmt.Mode == 1)
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_DATE_SETTLE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateSettle;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_LEVSETLMT_DATE_SETTLE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_DAYSDEDUCT", OracleDbType.Varchar2).Value = objEntityLeaveSettlmt.CnclReason;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_ELIGBL_OPEN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OpenElgibleDays;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LEAVESAL_OPEN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.OpenLeaveSalary;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_LV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.LeaveArrearAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_ADDITON_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevAdditionAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OVERTIME_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOvertimeAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevArrearAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_DEDUCTN_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevDeductionAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_PAYMNT_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevPaymntDedAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_MESSDED_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMessDedAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OTHERAMT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOtherAddAmnt;
                        cmdAddEmp.Parameters.Add("E_LEVSETLMT_PREV_OTHERDEDCTN", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevOtherDedAmnt;
                        cmdAddEmp.Parameters.Add("E_MONTH", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Month;
                        cmdAddEmp.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Year;
                        if(objEntityLeaveSettlmt.FromDate!=DateTime.MinValue)
                         cmdAddEmp.Parameters.Add("E_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.FromDate;
                        else
                         cmdAddEmp.Parameters.Add("E_FROM_DATE", OracleDbType.Date).Value = DBNull.Value;
                        if (objEntityLeaveSettlmt.ToDate != DateTime.MinValue)
                         cmdAddEmp.Parameters.Add("E_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.ToDate;
                        else
                         cmdAddEmp.Parameters.Add("E_TO_DATE", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddEmp.Parameters.Add("E_CHANGE_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CancelStatus;
                        cmdAddEmp.Parameters.Add("E_PREV_MNTH_ARR_AMNT", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.PrevMnthArrAmt;
                        if (objEntityLeaveSettlmt.PrevMntRejoinDate != DateTime.MinValue)
                        {
                            cmdAddEmp.Parameters.Add("E_PREV_MNTH_REJOIN", OracleDbType.Date).Value = objEntityLeaveSettlmt.PrevMntRejoinDate;
                        }
                        else
                        {
                            cmdAddEmp.Parameters.Add("E_PREV_MNTH_REJOIN", OracleDbType.Date).Value = DBNull.Value;
                        }
                        clsDataLayer.ExecuteNonQuery(cmdAddEmp);
                    }
                    if (objEntityLeaveSettlmt.ConfrmStatus == 1)
                    {
                        foreach (clsEntityLayerLeaveSettlmt objSubSettlmt in objEntityLeaveTypSettlmt)
                        {
                            {
                                string strQuerySubDetail = "LEAVE_SETTLEMENT.SP_UPD_LEAVE_ELIGIBL_DAYS";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand())
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandText = strQuerySubDetail;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objSubSettlmt.EmployeeId;
                                    cmdAddSubDetail.Parameters.Add("E_LEAVETYP_ID", OracleDbType.Int32).Value = objSubSettlmt.LeaveTypeId;
                                    cmdAddSubDetail.Parameters.Add("E_LEAVE_YEAR", OracleDbType.Int32).Value = objSubSettlmt.Year;
                                    cmdAddSubDetail.Parameters.Add("E_BALANCE", OracleDbType.Decimal).Value = objSubSettlmt.BalanceLeave;
                                    clsDataLayer.ExecuteNonQuery(cmdAddSubDetail);
                                }
                            }
                        }
                    }
                    if (objEntityLeaveSettlmt.CancelStatus == 1)
                    {
                        foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityAdditionList)
                        {
                            string strQuerySubDetail = "LEAVE_SETTLEMENT.SP_INS_ADDITION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_ALWID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                                cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                                cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                        foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityDeductionList)
                        {
                            string strQuerySubDetail = "LEAVE_SETTLEMENT.SP_INS_DEDUCTION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_DEDID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_PERCTG", OracleDbType.Decimal).Value = objSubSettlmt.Percentge;
                                cmdAddSubDetail.Parameters.Add("E_AMNT_PER_STS", OracleDbType.Int32).Value = objSubSettlmt.PercOrAmountChk;
                                cmdAddSubDetail.Parameters.Add("E_BASIC_TOTAL_STS", OracleDbType.Int32).Value = objSubSettlmt.BasicOrTotalAmtChk;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                                cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                                cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                                cmdAddSubDetail.ExecuteNonQuery();
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

        public void UpdateEligibleDaysCount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryAddExit = "LEAVE_SETTLEMENT.SP_UPD_LEAVE_ELIGIBL_DAYS";
            using (OracleCommand cmdAddEmp = new OracleCommand())
            {
                cmdAddEmp.CommandText = strQueryAddExit;
                cmdAddEmp.CommandType = CommandType.StoredProcedure;
                cmdAddEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdAddEmp.Parameters.Add("E_LEAVETYP_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveTypeId;
                cmdAddEmp.Parameters.Add("E_LEAVE_YEAR", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Year;
                cmdAddEmp.Parameters.Add("E_BALANCE", OracleDbType.Decimal).Value = objEntityLeaveSettlmt.BalanceLeave;
                clsDataLayer.ExecuteNonQuery(cmdAddEmp);
            }
        }

        //read confirm status
        public DataTable ReadConfrmStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_CONFRM_STS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_LEVSETLMT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }
        //cancel leav settlmt
        public void CancelLeavSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryAddExit = "LEAVE_SETTLEMENT.SP_CANCEL_LEAVSETTLMT";
            using (OracleCommand cmdAddEmp = new OracleCommand())
            {
                cmdAddEmp.CommandText = strQueryAddExit;
                cmdAddEmp.CommandType = CommandType.StoredProcedure;
                cmdAddEmp.Parameters.Add("E_LEVSETLMT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
                cmdAddEmp.Parameters.Add("E_LEVSETLMT_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                cmdAddEmp.Parameters.Add("E_LEVSETLMT_CNCL_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.Date;
                cmdAddEmp.Parameters.Add("E_LEVSETLMT_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityLeaveSettlmt.CnclReason;
                clsDataLayer.ExecuteNonQuery(cmdAddEmp);
            }
        }

        //read employees list
        public DataTable ReadEmp(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_EMP";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee LEAVDTLS
        public DataTable ReadEmpLeav(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_EMP_LEAVDTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read monthly salary of employee
        public DataTable ReadMonthsalary(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_EMP_MNTHSLRY";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_PREVMNTH", OracleDbType.Int32).Value = objEntityLeaveSettlmt.PrevMnth;
            cmdReadEmp.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Year;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSal = new DataTable();
            dtSal = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtSal;
        }

        //read employee overtime addition
        public DataTable ReadOvertimeAdd(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_OVERTIMESAL";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_SDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadEmp.Parameters.Add("E_EDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            string pmonth = objEntityLeaveSettlmt.DateEndDate.Month.ToString("00");
            string pyear = objEntityLeaveSettlmt.DateEndDate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            // cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadEmp.Parameters.Add("E_LDATE", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        //read employee deduction by deductn master
        public DataTable ReadDeductionMaster(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_DEDUCTN_EMPMASTER";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            string pmonth = objEntityLeaveSettlmt.DateEndDate.Month.ToString("00");
            string pyear = objEntityLeaveSettlmt.DateEndDate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
           // cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadEmp.Parameters.Add("E_LDATE", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "LEAVE_SETTLEMENT.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        //read leave type details
        public DataTable ReadLeavTyp(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEVTYPDTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadLeavSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEVSETTLMT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        public DataTable ReadLastSettldDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LSTSETTLDDATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadMnthly(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_MNTHLYSAL_PRCSD";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadCorpSal(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_CORPRT_SALDATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public void ClearArrearAmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_UPDATE_ARREARAMT";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }

        public void UpdateLeaveSettld(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_UPDATE_LEAVESETTLD";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("L_LEAVEID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveTypId;
                cmdReadEmp.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
                cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.Date;
                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }

        public DataTable ReadLstOvertimeAndDeductn(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LSTSETTLD_OVERTMDEDCTN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            string pmonth = objEntityLeaveSettlmt.SettlmtDate.Month.ToString("00");
            string pyear = objEntityLeaveSettlmt.SettlmtDate.Year.ToString();
            string combmonthyear = pmonth + "-" + pyear;
            // cmdReadPayGrd.Parameters.Add("P_MONYR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadEmp.Parameters.Add("E_LDATE", OracleDbType.Varchar2).Value = combmonthyear;
            //cmdReadEmp.Parameters.Add("E_STDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            //cmdReadEmp.Parameters.Add("E_ENDDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadMessAmount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LSTSETTLD_MESSAMNT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_SETTLDDT", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateSettle;
            cmdReadEmp.Parameters.Add("L_SETTLDDT_FROM", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;            
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("P_PREV_MNTH_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.ConfrmStatus;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadPaidLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_PAID_LEAVES";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadPaidLeaveForMultipleYrs(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_PAID_LV_MULTIPL_YRS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadLeaveDate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "LEAVE_SETTLEMENT.SP_READ_LEAVE_DATES";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
            cmdReadCorp.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadCorp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadMonthlyLeaveForMultipleYrs(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_MONTHLY_LV_MULTIPL_YRS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
            cmdReadEmp.Parameters.Add("L_SDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateSettle;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadMonthlyLeaveTotal(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_READ_MONTHLY_LEAVES";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.SettlmtDate;
                cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadMonthlyLastDate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_READ_MONTHLY_DATE";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadEligibleLeaveCount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_READ_ELIGIBLELEAVECOUNT";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Year;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadMonthlyConfirmLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_CONFIRM_LV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_LVID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadLastSettlementDetails(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LASTSETTLE_AND_REJOIN";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_LVID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        public DataTable ReadPrevLeaveDetails(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LVAFTERSETTLE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_LDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateSettle;
            cmdReadEmp.Parameters.Add("L_LDATEND", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


        public DataTable ReadOpeningLeaveInfo(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_READ_OPEN_LEAVE_INFO";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }
        public DataTable ReadLeaveArrearAmnt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryCancelInterviewCat = "LEAVE_SETTLEMENT.SP_RD_LEAVE_AREAR_AMNT";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryCancelInterviewCat;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtEmp;
            }
        }

        public void UpdateSettledStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryUpdateStatus = "LEAVE_SETTLEMENT.SP_UPDATE_STLMNT_STATUS";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("E_LEVSETLMT_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveSettlmtId;
                clsDataLayer.ExecuteNonQuery(cmd);
            }
        }

        public void PaidAll_UpdateSettledStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryUpdateStatus = "LEAVE_SETTLEMENT.SP_UPDATE_STLMNT_STATUS_ALL";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                cmd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                clsDataLayer.ExecuteNonQuery(cmd);
            }
        }


        public DataTable ReadEmpManualy_Add_Dedn_Details(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryUpdateStatus = "LEAVE_SETTLEMENT.SP_READ_MANUAL_ADD_DED_DTLS";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
                cmd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
                cmd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
                cmd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Month;
                cmd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Year;
                cmd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmd);
                return dtEmp;
            }
        }
        public DataTable ReadAttendance(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_ATTENDANCE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("L_LDATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadEmp.Parameters.Add("L_LDATEND", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


        public DataTable ReadProbationEnddate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_PROBATION_END_DATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeId;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadLeaveDateMiss(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "LEAVE_SETTLEMENT.SP_READ_LEAVE_DATES_MISS";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.UserId;
            cmdReadCorp.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadCorp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadLeaveDetailsRj(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "LEAVE_SETTLEMENT.SP_READ_LEAVE_DETAILS_RJ";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.LeaveId;
            cmdReadEmp.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


    }
}
