using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerEndOfServiceLeaveStlmnt
    {

        public DataTable readGratuityDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.readGratuityDate(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }

        public DataTable ReadExitEmployeeList(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadExitEmployeeList(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadExitEmployeeByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadExitEmployeeByID(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadEmpSalaryDeduction(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadEmpSalaryDeduction(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadEmpSalaryAllowance(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadEmpSalaryAllowance(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadEmpSalaryGratuityLeaveDays(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadEmpSalaryGratuityLeaveDays(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadEmpSalaryDtl(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadEmpSalaryDtl(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadExitEmpTotalAvailableLves(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadExitEmpTotalAvailableLves(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public DataTable ReadExitEmpRejoinDtls(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadExitEmpRejoinDtls(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        public void AddEndSrvLveStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            objDataEndServiceLveStlmnt.AddEndSrvLveStlmnt(objEntityLevStlmnt, objEntityAdditionList, objEntityDeductionList);
        }
        // This Method update  details 
        public void UpdateEndSrvLveStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt, List<clsEntityLayerEmpSalary> objEntityAdditionList, List<clsEntityLayerEmpSalary> objEntityDeductionList)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            objDataEndServiceLveStlmnt.UpdateEndSrvLveStlmnt(objEntityLevStlmnt, objEntityAdditionList, objEntityDeductionList);
        }
        //Read list 
        public DataTable ReadSrvLevStlmntList(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadSrvLevStlmntList(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        //READ BY ID
        public DataTable ReadSrvLevStlmntByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadSrvLevStlmntByID(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        //delete  
        public void CancelSrvLevStlmnt(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            objDataEndServiceLveStlmnt.CancelSrvLevStlmnt(objEntityLevStlmnt);
        }
        public DataTable ReadPreSalaryDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadPreSalaryDate(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        //READ LEV DETAILS BY ID
        public DataTable ReadLevDetailsByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmployeeDtl = new DataTable();
            dtEmployeeDtl = objDataEndServiceLveStlmnt.ReadLevDetailsByID(objEntityLevStlmnt);
            return dtEmployeeDtl;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadCorporateAddress(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }

        //Calculating mess amount
        public DataTable ReadMessDeductionByID(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadMessDeductionByID(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadLeaveDate(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLeaveSettlmt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadLeaveDate(objEntityLeaveSettlmt);
            return dtLevSetlmt;
        }
        public DataTable ReadLeavSettlmentDat(clsEntityLayerEndOfServiceLeaveStlmnt objEntitySalary)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = objDataEndServiceLveStlmnt.ReadLeavSettlmentDat(objEntitySalary);
            return dtEmp_List;
        }
        public DataTable ReadRejoinLeave(clsEntityLayerEndOfServiceLeaveStlmnt objEntitySalary)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadRejoinLeave(objEntitySalary);
            return dtLevSetlmt;
        }
        public DataTable ReadRemainingLeaveCountFromGn_User_Lv(clsEntityLayerEndOfServiceLeaveStlmnt objEntitySalary)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadRemainingLeaveCountFromGn_User_Lv(objEntitySalary);
            return dtLevSetlmt;
        }

        public void UpdateSettledStatus(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            objDataEndServiceLveStlmnt.UpdateSettledStatus(objEntityLevStlmnt);
        }

        public void PaidAll_UpdateSettledStatus(clsEntityLayerEndOfServiceLeaveStlmnt objEntityLevStlmnt)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            objDataEndServiceLveStlmnt.PaidAll_UpdateSettledStatus(objEntityLevStlmnt);
        }

        public DataTable ReadLastLeavDateEmp_Id(clsEntityLayerEndOfServiceLeaveStlmnt objEntitySalary)
        {
            clsDatalayerEndOfServiceLeaveStlmnt objDataEndServiceLveStlmnt = new clsDatalayerEndOfServiceLeaveStlmnt();
            DataTable dtLevSetlmt = new DataTable();
            dtLevSetlmt = objDataEndServiceLveStlmnt.ReadLastLeavDateEmp_Id(objEntitySalary);
            return dtLevSetlmt;
        }
    }
}
