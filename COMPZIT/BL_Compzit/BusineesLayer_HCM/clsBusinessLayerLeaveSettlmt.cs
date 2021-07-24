using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerLeaveSettlmt
    {
        clsDataLayerLeaveSettlmt objDataLeavSettlmt = new clsDataLayerLeaveSettlmt();
        public DataTable ReadOffDays(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadOffDays(objEntityLeaveSettlmt);
            return dtEmp;
        }
        public DataTable ReadMonthlyOffDays(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadMonthlyOffDays(objEntityLeaveSettlmt);
            return dtEmp;
        }
        public DataTable ReadHoliday(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadHoliday(objEntityLeaveSettlmt);
            return dtEmp;
        }
        public DataTable ReadOpenRejoin(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadOpenRejoin(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read employee details
        public DataTable ReadEmpLeaveTypes(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadEmpLeaveTypes(objEntityLeaveSettlmt);
            return dtEmp;
        }
        public DataTable ReadEmpDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadEmpDtls(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read employee's leave details
        public DataTable ReadLeaveDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadLeaveDtls(objEntityLeaveSettlmt);
            return dtEmp;
        }
                //read employee's TOTAL LEAVE
        public DataTable ReadTotalLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadTotalLeave(objEntityLeaveSettlmt);
            return dtEmp;
        }

        //read employee rejoin date
        public DataTable ReadRejoin(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadRejoin(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read employee join date if no rejoin date
        public DataTable ReadJoinDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadJoinDt(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read employee insert date if no join date
        public DataTable ReadInsertDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadInsertDt(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read basic pay of employee
        public DataTable ReadBasicPay(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavSettlmt.ReadBasicPay(objEntityLeaveSettlmt);
            return dtEmp;
        }
        //read allowance of employee
        public DataTable ReadAllowance(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtSal = new DataTable();
            dtSal = objDataLeavSettlmt.ReadAllowance(objEntityLeaveSettlmt);
            return dtSal;
        }
        //read deductn of employee
        public DataTable ReadDeduction(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtSal = new DataTable();
            dtSal = objDataLeavSettlmt.ReadDeduction(objEntityLeaveSettlmt);
            return dtSal;
        }
        //insert  leave settlmt for the employee
        public void InsertEmployeeDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
        {
            objDataLeavSettlmt.InsertEmployeeDtls(objEntityLeaveSettlmt, objEntityAdditionList, objEntityDeductionList);
        }
        //read leave settlmt list
        public DataTable ReadLeaveSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveSettlmt(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        //read leave settlmt for respective employee
        public DataTable ReadLeaveSettlmt_ById(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        //update employee leave settlmt
        public void UpdateEmployeeDtls(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt, List<clsEntityLayerLeaveSettlmt> objEntityLeaveTypSettlmt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
        {
            objDataLeavSettlmt.UpdateEmployeeDtls(objEntityLeaveSettlmt, objEntityLeaveTypSettlmt, objEntityAdditionList, objEntityDeductionList);
        }

        //read confirm status
        public DataTable ReadConfrmStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadConfrmStatus(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        //cancel leav settlmt
        public void CancelLeavSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.CancelLeavSettlmt(objEntityLeaveSettlmt);
        }

        public DataTable ReadEmp(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadEmp(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadEmpLeav(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadEmpLeav(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        //read monthly salary of employee
        public DataTable ReadMonthsalary(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMonthsalary(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        //read employee overtime addition
        public DataTable ReadOvertimeAdd(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadOvertimeAdd(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        //read employee deduction by deductn master
        public DataTable ReadDeductionMaster(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadDeductionMaster(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

                // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadCorporateAddress(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

                //read leave type details
        public DataTable ReadLeavTyp(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeavTyp(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadLeavSettlmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeavSettlmt(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadLastSettldDt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLastSettldDt(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadMnthly(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMnthly(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadCorpSal(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadCorpSal(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public void ClearArrearAmt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.ClearArrearAmt(objEntityLeaveSettlmt);
        }

        public void UpdateLeaveSettld(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.UpdateLeaveSettld(objEntityLeaveSettlmt);
        }

        public DataTable ReadLstOvertimeAndDeductn(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLstOvertimeAndDeductn(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadMessAmount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMessAmount(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadPaidLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadPaidLeave(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadPaidLeaveForMultipleYrs(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadPaidLeaveForMultipleYrs(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadLeaveDate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
         
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveDate(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadMonthlyLeaveForMultipleYrs(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMonthlyLeaveForMultipleYrs(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadMonthlyLeaveTotal(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMonthlyLeaveTotal(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadMonthlyLastDate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMonthlyLastDate(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadEligibleLeaveCount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadEligibleLeaveCount(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadMonthlyConfirmLeave(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadMonthlyConfirmLeave(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadLastSettlementDetails(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLastSettlementDetails(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadPrevLeaveDetails(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadPrevLeaveDetails(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadOpeningLeaveInfo(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadOpeningLeaveInfo(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public void UpdateEligibleDaysCount(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.UpdateEligibleDaysCount(objEntityLeaveSettlmt);
        }
        public DataTable ReadLeaveArrearAmnt(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveArrearAmnt(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public void UpdateSettledStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.UpdateSettledStatus(objEntityLeaveSettlmt);
        }

        public void PaidAll_UpdateSettledStatus(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            objDataLeavSettlmt.PaidAll_UpdateSettledStatus(objEntityLeaveSettlmt);
        }

        public DataTable ReadEmpManualy_Add_Dedn_Details(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadEmpManualy_Add_Dedn_Details(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadAttendance(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadAttendance(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadProbationEnddate(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadProbationEnddate(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        public DataTable ReadLeaveDateMiss(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {

            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveDateMiss(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadLeaveDetailsRj(clsEntityLayerLeaveSettlmt objEntityLeaveSettlmt)
        {

            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataLeavSettlmt.ReadLeaveDetailsRj(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
    }
}
