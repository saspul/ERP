using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL_Compzit.BusineesLayer_HCM
{
  public  class clsBusinessWelfareServiceTransaction
    {
        clsDatalayerWelfareServiceTransaction objDataPassport = new clsDatalayerWelfareServiceTransaction();
        public DataTable ReadEmployeeTableList(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadEmployee(objentityPassport);
            return dtGuarnt;
        }
        public DataTable ReadEmpServiceCtgry(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadEmpServiceCtgry(objentityPassport);
            return dtGuarnt;
        }
        public DataTable ReadEmployeeDDL(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadEmployeeDDL(objentityPassport);
            return dtGuarnt;
        }
        public DataTable ReadServiceDtlEmp(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadServiceDtlEmp(objentityPassport);
            return dtGuarnt;
        }

        public void insertServEmpData(clsEntityWelfareServiceTransaction objentityPassport, List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList)
        {
            objDataPassport.insertServEmpData(objentityPassport, objEntityTrficVioltnDetilsList);
        }
        public void updateServEmpData(clsEntityWelfareServiceTransaction objentityPassport, List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList)
        {
            objDataPassport.updateServEmpData(objentityPassport, objEntityTrficVioltnDetilsList);
        }
        public DataTable ReadServiceTransList(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadServiceTransList(objentityPassport);
            return dtGuarnt;
        }
        public DataTable readServTransDtlById(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.readServTransDtlById(objentityPassport);
            return dtGuarnt;
        }
        public DataTable readEmpWiseData(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.readEmpWiseData(objentityPassport);
            return dtGuarnt;
        }
        public DataTable ReadServiceDtlEmpDate(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadServiceDtlEmpDate(objentityPassport);
            return dtGuarnt;
        }
        public DataTable CheckServDtlDateDup(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.CheckServDtlDateDup(objentityPassport);
            return dtGuarnt;
        }

        public DataTable ReadDivisionDDL(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadDivisionDDL(objentityPassport);
            return dtGuarnt;
        }
        public DataTable ReadServiceSearch(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadServiceSearch(objentityPassport);
            return dtGuarnt;
        }
        public void CancelWelfareTransctn(clsEntityWelfareServiceTransaction objentityPassport)
        {
            objDataPassport.CancelWelfareTransctn(objentityPassport);
        }
        public DataTable checkConfrmSts(clsEntityWelfareServiceTransaction objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.checkConfrmSts(objentityPassport);
            return dtGuarnt;
        }
    }
}
