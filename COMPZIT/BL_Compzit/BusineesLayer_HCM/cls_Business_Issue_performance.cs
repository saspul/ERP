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
    public class cls_Business_Issue_performance
    {
        clsDataLayer_Issue_Performance objDataPerformance = new clsDataLayer_Issue_Performance();
        public void InsertPerformanceIssue(clsEntity_Issue_Performance objEntityPerformanceIssue, List<clsEntity_Employees_list> ObjEntityEmployeesList, List<clsEntity_Evaluator_list> ObjEntityEvaluatorList)
        {
            objDataPerformance.InsertPerformanceIssue(objEntityPerformanceIssue,ObjEntityEmployeesList, ObjEntityEvaluatorList);
        }
        public void UpdatePerformanceIssue(clsEntity_Issue_Performance objEntityPerformanceIssue, List<clsEntity_Employees_list> ObjEntityEmployeesList, List<clsEntity_Evaluator_list> ObjEntityEvaluatorList)
        {
            objDataPerformance.UpdatePerformanceIssue(objEntityPerformanceIssue, ObjEntityEmployeesList, ObjEntityEvaluatorList);
        }
        public DataTable ReadDepartment(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataPerformance.ReadDepartment(objEntityPerformanceIssue);
            return dtDept;
        }
        public DataTable ReadDesignation(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtDesignation = new DataTable();
            dtDesignation = objDataPerformance.ReadDesignation(objEntityPerformanceIssue);
            return dtDesignation;
        }
        public DataTable ReadEmployee(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataPerformance.ReadEmployee(objEntityPerformanceIssue);
            return dtEmp;
        }
        public DataTable ReadPerformanceTemplate(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataPerformance.ReadPerformanceTemplate(objEntityPerformanceIssue);
            return dtEmp;
        }
        public DataTable ReadServiceDetailsList(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadServiceDetailsList(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable ReadServiceDetailsById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadServiceDetailsById(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable ReadEmployeeById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadEmployeeById(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable ReadEvaluatorsById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadEvaluatorsById(objEntityPerformanceIssue);
            return dtList;
        }
        public void CancelIsssuePrfrm(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            objDataPerformance.CancelIsssuePrfrm(objEntityPerformanceIssue);
        }
        public void ChangeIssueStatus(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            objDataPerformance.ChangeIssueStatus(objEntityPerformanceIssue);
        }
        public void Confirm_PerfrmIssue(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            objDataPerformance.Confirm_PerfrmIssue(objEntityPerformanceIssue);
        }
        public DataTable ReadAnalyzePerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadAnalyzePerform(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable ReadConfirmPerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.ReadConfirmPerform(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable RemovePerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.RemovePerform(objEntityPerformanceIssue);
            return dtList;
        }
        public DataTable RemoveEvalEmp(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            DataTable dtList = new DataTable();
            dtList = objDataPerformance.RemoveEvalEmp(objEntityPerformanceIssue);
            return dtList;
        }
    }
}
