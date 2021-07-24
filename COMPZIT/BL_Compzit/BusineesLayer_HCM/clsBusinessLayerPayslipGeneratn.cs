using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;


namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerPayslipGeneratn
    {
        clsDataLayerPayslipGeneratn objDataPayslip = new clsDataLayerPayslipGeneratn();

        public DataTable ReadEmployeeDtls(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            DataTable dtPayslip = objDataPayslip.ReadEmployeeDtls(objEntityPayslip);
            return dtPayslip;
        }

        public DataTable ReadDivisn(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            DataTable dtPayslip = objDataPayslip.ReadDivisn(objEntityPayslip);
            return dtPayslip;
        }

        public DataTable ReadProcessdEmployees(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            DataTable dtPayslip = objDataPayslip.ReadProcessdEmployees(objEntityPayslip);
            return dtPayslip;
        }


    }
}
