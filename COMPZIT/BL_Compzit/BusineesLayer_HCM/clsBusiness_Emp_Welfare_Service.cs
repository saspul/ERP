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
    public class clsBusiness_Emp_Welfare_Service
    {
        clsDataLayer_Emp_Welfare_service objDataWelfareService = new clsDataLayer_Emp_Welfare_service();

        public DataTable ReadDivision(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataWelfareService.ReadDivision(objEntityWelfare);
            return dtDivision;
        }
        public DataTable ReadDepartment(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataWelfareService.ReadDepartment(objEntityWelfare);
            return dtDept;
        }
        public DataTable ReadDesignation(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtDesignation = new DataTable();
            dtDesignation = objDataWelfareService.ReadDesignation(objEntityWelfare);
            return dtDesignation;
        }
        public DataTable ReadEmployee(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataWelfareService.ReadEmployee(objEntityWelfare);
            return dtEmp;
        }
        public DataTable ReadCategory(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataWelfareService.ReadCategory(objEntityWelfare);
            return dtEmp;
        }
        public DataTable ReadCurrency(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataWelfareService.ReadCurrency(objEntityWelfare);
            return dtEmp;
        }
        public DataTable ReadDefualtCurrency(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataWelfareService.ReadDefualtCurrency(objEntityWelfare);
            return dtEmp;
        }
        public void AddWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare, List<clsEntity_Department_list> ObjEntityDepartmentList, List<clsEntity_Designation_list> ObjEntityDesignationList, List<clsEntity_Division_list> ObjEntityDivisionList, List<clsEntity_Employee_list> ObjEntityEmployeeList, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls)
        {
            objDataWelfareService.AddWelfareService(objEntityWelfare, ObjEntityDepartmentList, ObjEntityDesignationList, ObjEntityDivisionList, ObjEntityEmployeeList, objWelfare_LimitDtls);
        }
        public DataTable ReadServiceSubDtlById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceSubDtlById(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceDetailsList(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceDetailsList(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceDetailsById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceDetailsById(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceDesigById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceDesigById(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceDivisionById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceDivisionById(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceEmployeeById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceEmployeeById(objEntityWelfare);
            return dtList;
        }
        public DataTable ReadServiceDeptById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.ReadServiceDeptById(objEntityWelfare);
            return dtList;
        }
        public void UpdateWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare, List<clsEntity_Department_list> ObjEntityDepartmentList, List<clsEntity_Designation_list> ObjEntityDesignationList, List<clsEntity_Division_list> ObjEntityDivisionList, List<clsEntity_Employee_list> ObjEntityEmployeeList, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Insert, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Update, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Delete)
        {
            objDataWelfareService.UpdateWelfareService(objEntityWelfare, ObjEntityDepartmentList, ObjEntityDesignationList, ObjEntityDivisionList, ObjEntityEmployeeList, objWelfare_LimitDtls_Insert, objWelfare_LimitDtls_Update, objWelfare_LimitDtls_Delete);
        }
        public void CancelWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            objDataWelfareService.CancelWelfareService(objEntityWelfare);
        }
        public void ChangeServiceStatus(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            objDataWelfareService.ChangeServiceStatus(objEntityWelfare);
        }
        public DataTable CheckCategoryId(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            DataTable dtList = new DataTable();
            dtList = objDataWelfareService.CheckCategoryId(objEntityWelfare);
            return dtList;
        }
    }
}
