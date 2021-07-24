using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using DL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerSalaryCertificate
    {

        clsDataLayerSalaryCertificate objDataLayerSalryCertfct = new clsDataLayerSalaryCertificate();

        public DataTable ReadEmployeeDtls(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadEmployeeDtls(objEntitySalaryCertfct);
            return dtSalary;
        }

        public DataTable ReadBasicPay(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadBasicPay(objEntitySalaryCertfct);
            return dtSalary;
        }

        public DataTable ReadAllowance(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadAllowance(objEntitySalaryCertfct);
            return dtSalary;
        }

        public DataTable ReadDivision(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadDivision(objEntitySalaryCertfct);
            return dtSalary;
        }

        public void InsertSalaryCertfctRequest(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            objDataLayerSalryCertfct.InsertSalaryCertfctRequest(objEntitySalaryCertfct);
        }

        public DataTable ReadSalaryCertfctReqsts(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadSalaryCertfctReqsts(objEntitySalaryCertfct);
            return dtSalary;
        }

        public DataTable ReadRequestById(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            DataTable dtSalary = objDataLayerSalryCertfct.ReadRequestById(objEntitySalaryCertfct);
            return dtSalary;
        }

        public void UpdateApproveSalaryReqst(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            objDataLayerSalryCertfct.UpdateApproveSalaryReqst(objEntitySalaryCertfct);
        }

        public void UpdateRejectSalaryReqst(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            objDataLayerSalryCertfct.UpdateRejectSalaryReqst(objEntitySalaryCertfct);
        }

    }
}
