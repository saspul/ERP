using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;


namespace DL_Compzit.DataLayer_HCM
{
    public class clsDatalayerEndOfServiceLeaveStlmnt
    {

        //fetch employee list for dropdownlist

        public DataTable readGratuityDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_CORP_GRTUTY_DATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }


        public DataTable ReadExitEmployeeList(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_EXIT_EMPLOYEE_LIST";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        public DataTable ReadExitEmployeeByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_EXIT_EMPLOYEE_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        public DataTable ReadEmpSalaryDeduction(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_EMP_SALARY_DEDUCTION";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_EMP_SAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        public DataTable ReadEmpSalaryAllowance(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_EMP_SALARY_ALWANC";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_EMP_SAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        public DataTable ReadEmpSalaryGratuityLeaveDays(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_GRATUITY_LVE_SAL_DAYS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_EMP_SAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        public DataTable ReadEmpSalaryDtl(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_BASIC_PAY_ALLOWANCE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.Date;
            cmdReadEmp.Parameters.Add("L_FROM_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.DateStartDate;
            cmdReadEmp.Parameters.Add("L_EMP_SAL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        public DataTable ReadExitEmpTotalAvailableLves(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_TOTAL_EMPLOYEE_LEAVE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
       
        public DataTable ReadExitEmpRejoinDtls(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_EXIT_EMP_CUSTOM_DTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
     
        public void AddEndSrvLveStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
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
                    string strQueryAddEndSrvLveStlmnt = "END_OF_SERVICE_LEAVE_STLMNT.SP_INS_END_SRV_LVE_STLMNT";
                    using (OracleCommand cmdAddEndSrvLveStlmnt = new OracleCommand(strQueryAddEndSrvLveStlmnt, con))
                    {
                        cmdAddEndSrvLveStlmnt.CommandText = strQueryAddEndSrvLveStlmnt;
                        cmdAddEndSrvLveStlmnt.CommandType = CommandType.StoredProcedure;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_EMPOLYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_DATE_OF_LEAVING", OracleDbType.Date).Value = objEntityLevStlmnt.DateOfLeaving;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_EMPLOYEE_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeStatus;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_COMMENTS_REMARKS", OracleDbType.Varchar2).Value = objEntityLevStlmnt.Comments;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LAST_REJOIN_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.DateReJoin;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LVE_SAL_ELIGIBLE_DAYS", OracleDbType.Decimal).Value = objEntityLevStlmnt.EligibleDaysLveSalary;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_GRATUITY_ELIGIBLE_DAYS", OracleDbType.Decimal).Value = objEntityLevStlmnt.EligibleDaysLveGratuity;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_GRATUITY_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.GratuityAmount;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LVE_SAL_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.LeaveSalary;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_CUR_MONTH_SAL", OracleDbType.Decimal).Value = objEntityLevStlmnt.CurrentMonthSalary;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_MONTH_SAL", OracleDbType.Decimal).Value = objEntityLevStlmnt.PreviousMonthSalary;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_OTHER_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.OtherAmount;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_TICKET_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.TicketAmount;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_OTHER_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.OtherDeduction;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_NET_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.NetAmount;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_CNFRM_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.ConfirmStatus;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_INS_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_BASICPAY", OracleDbType.Decimal).Value = objEntityLevStlmnt.Bacispay;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_ADDITION", OracleDbType.Decimal).Value = objEntityLevStlmnt.Addition;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.Deduction;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_PYMT_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.EmpPaymentDeduction;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_OT_ADDITION", OracleDbType.Decimal).Value = objEntityLevStlmnt.OT_Addition;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_MESS_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.MessAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEAVE_DEDUCT", OracleDbType.Varchar2).Value = objEntityLevStlmnt.CancelReason;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_ELIGBL_OPEN", OracleDbType.Decimal).Value = objEntityLevStlmnt.OpenElgibleDays;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_LEAVESAL_OPEN", OracleDbType.Decimal).Value = objEntityLevStlmnt.OpenLeaveSalary;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_GRTJOIN_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.GrtJoinDateSts;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_LV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.LvArrearAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_OTHER_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOtherAmount;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_OTHER_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOtherDeduction;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_ADDITON_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevAdditionAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_OVERTIME_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOvertimeAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_DEDUCTN_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevDeductionAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_PAYMNT_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevPaymntDedAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_FROM_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.FromDate;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_ARR_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevMnthArrAmt;
                        if (objEntityLevStlmnt.PrevMntRejoinDate != DateTime.MinValue)
                        {
                            cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_REJOIN", OracleDbType.Date).Value = objEntityLevStlmnt.PrevMntRejoinDate;
                        }
                        else
                        {
                            cmdAddEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_REJOIN", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_MESS_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevMessAmnt;
                        cmdAddEndSrvLveStlmnt.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddEndSrvLveStlmnt.ExecuteNonQuery();
                        strReturn = cmdAddEndSrvLveStlmnt.Parameters["L_OUT"].Value.ToString();
                        cmdAddEndSrvLveStlmnt.Dispose();
                    }
                    foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityAdditionList)
                    {
                        string strQuerySubDetail = "END_OF_SERVICE_LEAVE_STLMNT.SP_INS_ADDITION_DTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                        {
                            cmdAddSubDetail.CommandText = strQuerySubDetail;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("E_ALWID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                            cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                            cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                            cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                            cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                            cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                            cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                            cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                            cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                            cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityDeductionList)
                    {
                        string strQuerySubDetail = "END_OF_SERVICE_LEAVE_STLMNT.SP_INS_DEDUCTION_DTL";
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
                            cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                            cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                            cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                            cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
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
        // This Method update  details 
        public void UpdateEndSrvLveStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
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
                    string strQueryAddEndSrvLveStlmnt = "END_OF_SERVICE_LEAVE_STLMNT.SP_UPD_END_SRV_LVE_STLMNT";
                    using (OracleCommand cmdUpdateEndSrvLveStlmnt = new OracleCommand(strQueryAddEndSrvLveStlmnt, con))
                    {
                        cmdUpdateEndSrvLveStlmnt.CommandText = strQueryAddEndSrvLveStlmnt;
                        cmdUpdateEndSrvLveStlmnt.CommandType = CommandType.StoredProcedure;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_EMPOLYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_DATE_OF_LEAVING", OracleDbType.Date).Value = objEntityLevStlmnt.DateOfLeaving;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_EMPLOYEE_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeStatus;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_COMMENTS_REMARKS", OracleDbType.Varchar2).Value = objEntityLevStlmnt.Comments;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LAST_REJOIN_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.DateReJoin;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LVE_SAL_ELIGIBLE_DAYS", OracleDbType.Decimal).Value = objEntityLevStlmnt.EligibleDaysLveSalary;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_GRATUITY_ELIGIBLE_DAYS", OracleDbType.Decimal).Value = objEntityLevStlmnt.EligibleDaysLveGratuity;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_GRATUITY_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.GratuityAmount;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LVE_SAL_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.LeaveSalary;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_CUR_MONTH_SAL", OracleDbType.Decimal).Value = objEntityLevStlmnt.CurrentMonthSalary;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_MONTH_SAL", OracleDbType.Decimal).Value = objEntityLevStlmnt.PreviousMonthSalary;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_OTHER_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.OtherAmount;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_TICKET_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.TicketAmount;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_OTHER_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.OtherDeduction;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_NET_AMOUNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.NetAmount;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_CNFRM_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.ConfirmStatus;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_UPD_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_BASICPAY", OracleDbType.Decimal).Value = objEntityLevStlmnt.Bacispay;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_ADDITION", OracleDbType.Decimal).Value = objEntityLevStlmnt.Addition;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVCLVE_STLMT_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.Deduction;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_PYMT_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.EmpPaymentDeduction;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_OT_ADDITION", OracleDbType.Decimal).Value = objEntityLevStlmnt.OT_Addition;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_MESS_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.MessAmnt;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEAVE_DEDUCT", OracleDbType.Varchar2).Value = objEntityLevStlmnt.CancelReason;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_ELIGBL_OPEN", OracleDbType.Decimal).Value = objEntityLevStlmnt.OpenElgibleDays;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_LEAVESAL_OPEN", OracleDbType.Decimal).Value = objEntityLevStlmnt.OpenLeaveSalary;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_GRTJOIN_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.GrtJoinDateSts;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_SRVLVE_LV_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.LvArrearAmnt;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_OTHER_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOtherAmount;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_OTHER_DEDUCTION", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOtherDeduction;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_ADDITON_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevAdditionAmnt;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_OVERTIME_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevOvertimeAmnt;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_DEDUCTN_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevDeductionAmnt;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_PAYMNT_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevPaymntDedAmnt;
                        if (objEntityLevStlmnt.FromDate != DateTime.MinValue)
                            cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_FROM_DATE", OracleDbType.Date).Value = objEntityLevStlmnt.FromDate;
                        else
                            cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_FROM_DATE", OracleDbType.Date).Value = DBNull.Value;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_CHANGE_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.CancelStatus;
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_ARR_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevMnthArrAmt;
                        if (objEntityLevStlmnt.PrevMntRejoinDate != DateTime.MinValue)
                        {
                            cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_REJOIN", OracleDbType.Date).Value = objEntityLevStlmnt.PrevMntRejoinDate;
                        }
                        else
                        {
                            cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_PREV_MNTH_REJOIN", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdUpdateEndSrvLveStlmnt.Parameters.Add("L_LEVSETLMT_PREV_MESS_AMNT", OracleDbType.Decimal).Value = objEntityLevStlmnt.PrevMessAmnt;
                        cmdUpdateEndSrvLveStlmnt.ExecuteNonQuery();
                    }
                    if (objEntityLevStlmnt.CancelStatus == 1)
                    {
                        foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityAdditionList)
                        {
                            string strQuerySubDetail = "END_OF_SERVICE_LEAVE_STLMNT.SP_INS_ADDITION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_ALWID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                                cmdAddSubDetail.Parameters.Add("E_FINAL_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeTo;
                                cmdAddSubDetail.Parameters.Add("E_PREVMNTH_STS", OracleDbType.Int32).Value = objSubSettlmt.AdditnStatus;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                        foreach (clsEntityLayerEmpSalary objSubSettlmt in objEntityDeductionList)
                        {
                            string strQuerySubDetail = "END_OF_SERVICE_LEAVE_STLMNT.SP_INS_DEDUCTION_DTL";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetail, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandText = strQuerySubDetail;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("E_DEDID", OracleDbType.Int32).Value = objSubSettlmt.AlownceId;
                                cmdAddSubDetail.Parameters.Add("E_PAYGRD_ID", OracleDbType.Int32).Value = objSubSettlmt.SalaryAllwnceId;
                                cmdAddSubDetail.Parameters.Add("E_LEVSTLMNT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                                cmdAddSubDetail.Parameters.Add("E_PROS_AMNT", OracleDbType.Decimal).Value = objSubSettlmt.AmountRangeFrm;
                                cmdAddSubDetail.Parameters.Add("E_PERCTG", OracleDbType.Decimal).Value = objSubSettlmt.Percentge;
                                cmdAddSubDetail.Parameters.Add("E_AMNT_PER_STS", OracleDbType.Int32).Value = objSubSettlmt.PercOrAmountChk;
                                cmdAddSubDetail.Parameters.Add("E_BASIC_TOTAL_STS", OracleDbType.Int32).Value = objSubSettlmt.BasicOrTotalAmtChk;
                                cmdAddSubDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                                cmdAddSubDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                                cmdAddSubDetail.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                                cmdAddSubDetail.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
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
        //Read list 
        public DataTable ReadSrvLevStlmntList(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {

            DataTable dtSrvLevStlmntList = new DataTable();
            using (OracleCommand cmdReadSrvLevStlmntList = new OracleCommand())
            {
                cmdReadSrvLevStlmntList.CommandText = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_END_SRV_LVE_STLMNT";
                cmdReadSrvLevStlmntList.CommandType = CommandType.StoredProcedure;
                if (objEntityLevStlmnt.EmployeeID == 0)
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_EMPOLYEE_ID", OracleDbType.Int32).Value =null;
                }
                else
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_EMPOLYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;

                }
                if (objEntityLevStlmnt.EmployeeStatus == 0)
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_EMPLOYEE_STS", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_EMPLOYEE_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeStatus;
                }
                if (objEntityLevStlmnt.DateOfLeaving!=DateTime.MinValue)
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_DATE_OF_LEAVING", OracleDbType.Date).Value = objEntityLevStlmnt.DateOfLeaving;
                }
                else
                {
                    cmdReadSrvLevStlmntList.Parameters.Add("L_DATE_OF_LEAVING", OracleDbType.Date).Value = null;
                }


                cmdReadSrvLevStlmntList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityLevStlmnt.CancelStatus;
                cmdReadSrvLevStlmntList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                cmdReadSrvLevStlmntList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                cmdReadSrvLevStlmntList.Parameters.Add("L_CNFRM_STS", OracleDbType.Int32).Value = objEntityLevStlmnt.ConfirmStatus;

                cmdReadSrvLevStlmntList.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtSrvLevStlmntList = clsDataLayer.SelectDataTable(cmdReadSrvLevStlmntList);
            }
            return dtSrvLevStlmntList;
        }
        //READ BY ID
        public DataTable ReadSrvLevStlmntByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            DataTable dtSrvLevStlmntDetails = new DataTable();
            using (OracleCommand cmdReadSrvLevStlmntDetails = new OracleCommand())
            {
                cmdReadSrvLevStlmntDetails.CommandText = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_END_SRV_LVE_BYID";
                cmdReadSrvLevStlmntDetails.CommandType = CommandType.StoredProcedure;
                cmdReadSrvLevStlmntDetails.Parameters.Add("L_SRVCLVE_STLMT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                cmdReadSrvLevStlmntDetails.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                cmdReadSrvLevStlmntDetails.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                cmdReadSrvLevStlmntDetails.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtSrvLevStlmntDetails = clsDataLayer.SelectDataTable(cmdReadSrvLevStlmntDetails);
            }
            return dtSrvLevStlmntDetails;
        }
       
        //delete  
        public void CancelSrvLevStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryCancelSrvLevStlmnt = "END_OF_SERVICE_LEAVE_STLMNT.SP_CANCEL_END_SRV_LVE_STLMNT";
            using (OracleCommand cmdCancelSrvLevStlmnt = new OracleCommand())
            {
                cmdCancelSrvLevStlmnt.CommandText = strQueryCancelSrvLevStlmnt;
                cmdCancelSrvLevStlmnt.CommandType = CommandType.StoredProcedure;
                cmdCancelSrvLevStlmnt.Parameters.Add("L_SRVCLVE_STLMT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                cmdCancelSrvLevStlmnt.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.UserId;
                cmdCancelSrvLevStlmnt.Parameters.Add("L_REASON", OracleDbType.Varchar2).Value = objEntityLevStlmnt.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelSrvLevStlmnt);
            }
        }

        public DataTable ReadPreSalaryDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_LAST_SALARY_DATE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }
        //READ LEV DETAILS BY ID
        public DataTable ReadLevDetailsByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            DataTable dtSrvLevStlmntDetails = new DataTable();
            using (OracleCommand cmdReadSrvLevStlmntDetails = new OracleCommand())
            {
                clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                DateTime dateCurrent = objDataLayerDateTime.DateAndTime();
                int dayValue = 1;
                int mtValue = 1;
                int yrValue = dateCurrent.Year;
                DateTime dateFrom = (new DateTime(yrValue, mtValue, dayValue));
                cmdReadSrvLevStlmntDetails.CommandText = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_LEAVEDTL_BY_EMP";
                cmdReadSrvLevStlmntDetails.CommandType = CommandType.StoredProcedure;
                cmdReadSrvLevStlmntDetails.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EmployeeID;
                cmdReadSrvLevStlmntDetails.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = dateFrom;
                cmdReadSrvLevStlmntDetails.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityLevStlmnt.Date;
                cmdReadSrvLevStlmntDetails.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtSrvLevStlmntDetails = clsDataLayer.SelectDataTable(cmdReadSrvLevStlmntDetails);
            }
            return dtSrvLevStlmntDetails;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
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


          // This method is for fetching mess amount
        public DataTable ReadMessDeductionByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_MESS_AMOUNT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeID;
            cmdReadCorp.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateOfLeaving;
            cmdReadCorp.Parameters.Add("L_SETTLDDT_FROM", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadCorp.Parameters.Add("P_PREV_MNTH_STS", OracleDbType.Int32).Value = objEntityLeaveSettlmt.ConfirmStatus;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadLeaveDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            string strQueryReadCorp = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_LEAVE_DATES";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeID;
            cmdReadCorp.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateStartDate;
            cmdReadCorp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.DateEndDate;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadLeavSettlmentDat(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerManpwr)
        {
            string strQueryReadCorp = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_LEAV_SETTLMENT_DATE ";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerManpwr.EmployeeID;
            string ddtMonth = objEntityLayerManpwr.DateStartDate.ToString("MM");
            string ddtYear = objEntityLayerManpwr.DateStartDate.ToString("yyyy");
            string combmonthyear = ddtMonth + "-" + ddtYear;
            cmdReadCorp.Parameters.Add("P_MONTHYEAR", OracleDbType.Varchar2).Value = combmonthyear;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadRejoinLeave(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerManpwr)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_REJOIN_LEAVE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("E_LID", OracleDbType.Int32).Value = objEntityLayerManpwr.LeaveId;
            cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadRemainingLeaveCountFromGn_User_Lv(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerManpwr)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_PEOSESS.SP_READ_REMAIN_LV_COUNT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityLayerManpwr.EmployeeID;
            cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }


        public void UpdateSettledStatus(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryUpdateStatus = "END_OF_SERVICE_LEAVE_STLMNT.SP_UPDATE_STLMNT_STATUS";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("L_SRVCLVE_STLMT_ID", OracleDbType.Int32).Value = objEntityLevStlmnt.EndSrvLveStlmntID;
                clsDataLayer.ExecuteNonQuery(cmd);
            }
        }

        public void PaidAll_UpdateSettledStatus(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            string strQueryUpdateStatus = "END_OF_SERVICE_LEAVE_STLMNT.SP_UPDATE_STLMNT_STATUS_ALL";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLevStlmnt.OrgId;
                cmd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLevStlmnt.CorpId;
                clsDataLayer.ExecuteNonQuery(cmd);
            }
        }

        public DataTable ReadLastLeavDateEmp_Id(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "END_OF_SERVICE_LEAVE_STLMNT.SP_READ_LAST_LEAV_EMP_ID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.OrgId;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpId;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.EmployeeID;
            cmdReadEmp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
    }
}
