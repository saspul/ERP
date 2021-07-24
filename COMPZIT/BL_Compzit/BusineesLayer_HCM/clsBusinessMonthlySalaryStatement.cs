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
    public class clsBusinessMonthlySalaryStatement
    {
        clsDataLayerMonthlySalaryStatement objData = new clsDataLayerMonthlySalaryStatement();
        public DataTable LoadSalaryPrssListPrssTable(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objData.LoadSalaryPrssListPrssTable(objEntitySalary);
            return dtGuarnt;
        }
        public DataTable LoadSalaryPrssListPrssTableDept(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objData.LoadSalaryPrssListPrssTableDept(objEntitySalary);
            return dtGuarnt;
        }
        //EVM-0027 05-02-2019
        public DataTable ReadAllwnc(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objData.ReadAllwnc(objEntitySalary);
            return dtGuarnt;
        }
        public DataTable ReadDedctn(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objData.ReadDedctn(objEntitySalary);
            return dtGuarnt;
        }
        //END
        //EVM-0027
        public DataTable ReadAllowanceDetails(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.ReadAllowanceDetails(objEntityPayroll_Report);
        }
        public DataTable ReadDeductionDetails(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.ReadDeductionDetails(objEntityPayroll_Report);
        }
        //END

        public DataTable ReadEmpManualy_Add_Dedn_Dtls(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.ReadEmpManualy_Add_Dedn_Dtls(objEntityPayroll_Report);
        }
        public DataTable LoadMonthlySalList(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.LoadMonthlySalList(objEntityPayroll_Report);
        }
        public DataTable ReadOTctgries(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.ReadOTctgries(objEntityPayroll_Report);
        }
        public DataTable ReadOTdtls(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            return objData.ReadOTdtls(objEntityPayroll_Report);
        }
    }
}
