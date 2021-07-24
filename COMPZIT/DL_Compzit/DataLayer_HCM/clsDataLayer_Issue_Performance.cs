using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Issue_Performance
    {

        public void InsertPerformanceIssue(clsEntity_Issue_Performance objEntityPerformanceIssue, List<clsEntity_Employees_list> ObjEntityEmployeesList, List<clsEntity_Evaluator_list> ObjEntityEvaluatorList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_EMP_PERFORMANCE_ISSUE.SP_INSERT_PRFRM_FORM";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFORMANCE_ISSUE);
                        objEntCommon.CorporateID = objEntityPerformanceIssue.Corp_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityPerformanceIssue.IssueId = Convert.ToInt32(strNextNum);
                        if (objEntityPerformanceIssue.Rev_No == 1)
                        {
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFORMANCE_ISSUE_REFNO);
                            string strNextRef = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            string year = DateTime.Today.Year.ToString();
                            objEntityPerformanceIssue.Ref_No = "REF#" + year + "" + strNextRef;
                        }
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                        cmdAddService.Parameters.Add("REFN", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.Ref_No;
                        cmdAddService.Parameters.Add("ISDATE", OracleDbType.Date).Value = objEntityPerformanceIssue.IssueDate;
                        cmdAddService.Parameters.Add("ISUEPRF", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.Issue;

                        cmdAddService.Parameters.Add("REV", OracleDbType.Int32).Value = objEntityPerformanceIssue.Rev_No;
                        if (objEntityPerformanceIssue.Frequency == 0)
                        {
                            cmdAddService.Parameters.Add("FRQ", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("FRQ", OracleDbType.Int32).Value = objEntityPerformanceIssue.Frequency;

                        }

                        if (objEntityPerformanceIssue.PerfrmTempltId == 0)
                        {
                            cmdAddService.Parameters.Add("TEPLTEID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("TEPLTEID", OracleDbType.Int32).Value = objEntityPerformanceIssue.PerfrmTempltId;
                        }
                        cmdAddService.Parameters.Add("EDD", OracleDbType.Int32).Value = objEntityPerformanceIssue.EmpDeptDsgn;
                        cmdAddService.Parameters.Add("EDDEVAL", OracleDbType.Int32).Value = objEntityPerformanceIssue.EDDEval;
                        cmdAddService.Parameters.Add("SEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.SelfEvaluate;
                        cmdAddService.Parameters.Add("SGOAL", OracleDbType.Int32).Value = objEntityPerformanceIssue.SelfGoal;
                        cmdAddService.Parameters.Add("ROEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.ROEvaluate;
                        cmdAddService.Parameters.Add("ROGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.ROGoal;
                        cmdAddService.Parameters.Add("DMEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.DMEvaluate;
                        cmdAddService.Parameters.Add("DMGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.DMGoal;
                        cmdAddService.Parameters.Add("HREVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.HREvaluate;
                        cmdAddService.Parameters.Add("HRGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.HRGoal;
                        cmdAddService.Parameters.Add("GMEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.GMEvaluate;
                        cmdAddService.Parameters.Add("GMGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.GMGoal;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
                        cmdAddService.Parameters.Add("ORID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPerformanceIssue.UserId;
                        cmdAddService.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityPerformanceIssue.Status;
                        if (objEntityPerformanceIssue.DeptID == 0)
                        {
                            cmdAddService.Parameters.Add("EMPDEPT", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EMPDEPT", OracleDbType.Int32).Value = objEntityPerformanceIssue.DeptID;
                        }
                        if (objEntityPerformanceIssue.DsgnID == 0)
                        {
                            cmdAddService.Parameters.Add("EMPDSGN", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EMPDSGN", OracleDbType.Int32).Value = objEntityPerformanceIssue.DsgnID;
                        }
                        if (objEntityPerformanceIssue.EvalDeptID == 0)
                        {
                            cmdAddService.Parameters.Add("EVLDEPT", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EVLDEPT", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDeptID;
                        }
                        if (objEntityPerformanceIssue.EvalDsgnID == 0)
                        {
                            cmdAddService.Parameters.Add("EVLDSGN", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EVLDSGN", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDsgnID;
                        }
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Employees_list objSubDetail in ObjEntityEmployeesList)
                    {

                        string strQuerySubDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_INSERT_PRFRM_EMP";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;

                            if (objSubDetail.EmpId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("EID", OracleDbType.Int32).Value = objSubDetail.EmpId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("EID", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.DeptId == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("DID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DID", OracleDbType.Int32).Value = objSubDetail.DeptId;
                            }
                            if (objSubDetail.DesignationId == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objSubDetail.DesignationId;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntity_Evaluator_list objDetail in ObjEntityEvaluatorList)
                    {

                        string strQueryInsertDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_INSERT_PRFRM_EVLTR";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                            if (objDetail.EvaluaterEmpId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVID", OracleDbType.Int32).Value = objDetail.EvaluaterEmpId;

                            }
                            if (objDetail.EvaluaterDeptId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDEPTID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDEPTID", OracleDbType.Int32).Value = objDetail.EvaluaterDeptId;
                            }
                            if (objDetail.EvaluaterDsgntId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDSGNID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDSGNID", OracleDbType.Int32).Value = objDetail.EvaluaterDsgntId;
                            }
                            cmdAddInsertDetail.Parameters.Add("EVGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalutorGoal;

                            cmdAddInsertDetail.ExecuteNonQuery();
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

        public DataTable ReadDepartment(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadDepartment = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_CORP_DEP";
            OracleCommand cmdReadDepartment = new OracleCommand();
            cmdReadDepartment.CommandText = strQueryReadDepartment;
            cmdReadDepartment.CommandType = CommandType.StoredProcedure;
            cmdReadDepartment.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadDepartment.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            cmdReadDepartment.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepartment = new DataTable();
            dtDepartment = clsDataLayer.ExecuteReader(cmdReadDepartment);
            return dtDepartment;
        }
        public DataTable ReadDesignation(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadDesignation = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_DESGN";
            OracleCommand cmdReadDesignation = new OracleCommand();
            cmdReadDesignation.CommandText = strQueryReadDesignation;
            cmdReadDesignation.CommandType = CommandType.StoredProcedure;
            cmdReadDesignation.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadDesignation.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDesignation);
            return dtCategory;
        }
        public DataTable ReadEmployee(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_EMPLOYEES";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadEmployee.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            if (objEntityPerformanceIssue.DeptID != 0)
            {
                cmdReadEmployee.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objEntityPerformanceIssue.DeptID;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DEPTID", OracleDbType.Int32).Value = null;
            }
            if (objEntityPerformanceIssue.DsgnID != 0)
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objEntityPerformanceIssue.DsgnID;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
            }
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable ReadPerformanceTemplate(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_PERFRM_TEMPLT";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadEmployee.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable ReadServiceDetailsList(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadServices = "HCM_EMP_PERFORMANCE_ISSUE.SP_READSERVICELIST";
            OracleCommand cmdReadServices = new OracleCommand();
            cmdReadServices.CommandText = strQueryReadServices;
            cmdReadServices.CommandType = CommandType.StoredProcedure;
            cmdReadServices.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadServices.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            if (objEntityPerformanceIssue.FromDate != DateTime.MinValue)
            {
                cmdReadServices.Parameters.Add("FROMDATE", OracleDbType.Date).Value = objEntityPerformanceIssue.FromDate;
            }
            else
            {
                cmdReadServices.Parameters.Add("FROMDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityPerformanceIssue.ToDate != DateTime.MinValue)
            {
                cmdReadServices.Parameters.Add("TODATE", OracleDbType.Date).Value = objEntityPerformanceIssue.ToDate;
            }
            else
            {
                cmdReadServices.Parameters.Add("TODATE", OracleDbType.Date).Value = null;
            }
            cmdReadServices.Parameters.Add("DESGN", OracleDbType.Int32).Value = objEntityPerformanceIssue.PerfrmTempltId;
            cmdReadServices.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityPerformanceIssue.Status;
            cmdReadServices.Parameters.Add("CANCELSTS", OracleDbType.Int32).Value = objEntityPerformanceIssue.Cancel_Status;
            cmdReadServices.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadServices);
            return dtCategory;
        }
        public DataTable ReadServiceDetailsById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadCurrency = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_PERFRM_ISSUE_BYID";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadCurrency;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadCurrency.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            cmdReadCurrency.Parameters.Add("PID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            cmdReadCurrency.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtCategory;
        }

        public DataTable ReadEmployeeById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryDeptById = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_PERFRM_ISSUE_EMP_BYID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryDeptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("PID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public DataTable ReadEvaluatorsById(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryEmptById = "HCM_EMP_PERFORMANCE_ISSUE.SP_READ_PERFRM_EVLTR_BYID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryEmptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("PID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }

        public void UpdatePerformanceIssue(clsEntity_Issue_Performance objEntityPerformanceIssue, List<clsEntity_Employees_list> ObjEntityEmployeesList, List<clsEntity_Evaluator_list> ObjEntityEvaluatorList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "HCM_EMP_PERFORMANCE_ISSUE.UPDATE_PRFRM_FORM";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;

                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                        cmdAddService.Parameters.Add("REFN", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.Ref_No;
                        cmdAddService.Parameters.Add("ISDATE", OracleDbType.Date).Value = objEntityPerformanceIssue.IssueDate;
                        cmdAddService.Parameters.Add("ISUEPRF", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.Issue;
                        cmdAddService.Parameters.Add("REV", OracleDbType.Int32).Value = objEntityPerformanceIssue.Rev_No;
                        cmdAddService.Parameters.Add("FRQ", OracleDbType.Int32).Value = objEntityPerformanceIssue.Frequency;
                        if (objEntityPerformanceIssue.PerfrmTempltId == 0)
                        {
                            cmdAddService.Parameters.Add("TEPLTEID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("TEPLTEID", OracleDbType.Int32).Value = objEntityPerformanceIssue.PerfrmTempltId;
                        }
                        cmdAddService.Parameters.Add("EDD", OracleDbType.Int32).Value = objEntityPerformanceIssue.EmpDeptDsgn;
                        cmdAddService.Parameters.Add("EDDEVAL", OracleDbType.Int32).Value = objEntityPerformanceIssue.EDDEval;
                        cmdAddService.Parameters.Add("SEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.SelfEvaluate;
                        cmdAddService.Parameters.Add("SGOAL", OracleDbType.Int32).Value = objEntityPerformanceIssue.SelfGoal;
                        cmdAddService.Parameters.Add("ROEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.ROEvaluate;
                        cmdAddService.Parameters.Add("ROGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.ROGoal;
                        cmdAddService.Parameters.Add("DMEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.DMEvaluate;
                        cmdAddService.Parameters.Add("DMGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.DMGoal;
                        cmdAddService.Parameters.Add("HREVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.HREvaluate;
                        cmdAddService.Parameters.Add("HRGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.HRGoal;
                        cmdAddService.Parameters.Add("GMEVL", OracleDbType.Int32).Value = objEntityPerformanceIssue.GMEvaluate;
                        cmdAddService.Parameters.Add("GMGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.GMGoal;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
                        cmdAddService.Parameters.Add("ORID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPerformanceIssue.UserId;
                        cmdAddService.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityPerformanceIssue.Status;
                        if (objEntityPerformanceIssue.DeptID == 0)
                        {
                            cmdAddService.Parameters.Add("EMPDEPT", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EMPDEPT", OracleDbType.Int32).Value = objEntityPerformanceIssue.DeptID;
                        }
                        if (objEntityPerformanceIssue.DsgnID == 0)
                        {
                            cmdAddService.Parameters.Add("EMPDSGN", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EMPDSGN", OracleDbType.Int32).Value = objEntityPerformanceIssue.DsgnID;
                        }
                        if (objEntityPerformanceIssue.EvalDeptID == 0)
                        {
                            cmdAddService.Parameters.Add("EVLDEPT", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EVLDEPT", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDeptID;
                        }
                        if (objEntityPerformanceIssue.EvalDsgnID == 0)
                        {
                            cmdAddService.Parameters.Add("EVLDSGN", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("EVLDSGN", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDsgnID;
                        }
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Employees_list objSubDetail in ObjEntityEmployeesList)
                    {
                        string strQueryStatusDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_CANCEL_PRFRM_EMP";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                            if (objSubDetail.EmpId != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EID", OracleDbType.Int32).Value = objSubDetail.EmpId;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EID", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.DeptId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("DID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("DID", OracleDbType.Int32).Value = objSubDetail.DeptId;
                            }
                            if (objSubDetail.DesignationId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objSubDetail.DesignationId;
                            }
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                    }
                    foreach (clsEntity_Employees_list objSubDetail in ObjEntityEmployeesList)
                    {
                        
                        string strQuerySubDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_INSERT_PRFRM_EMP";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;

                            if (objSubDetail.EmpId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("EID", OracleDbType.Int32).Value = objSubDetail.EmpId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("EID", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.DeptId == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("DID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DID", OracleDbType.Int32).Value = objSubDetail.DeptId;
                            }
                            if (objSubDetail.DesignationId == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objSubDetail.DesignationId;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
               
                    }
                    foreach (clsEntity_Evaluator_list objDetail in ObjEntityEvaluatorList)
                    {
                        string strQueryStatusDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_CANCEL_PRFRM_EVAL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                            if (objDetail.EvaluaterEmpId != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EID", OracleDbType.Int32).Value = objDetail.EvaluaterEmpId;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EID", OracleDbType.Int32).Value = null;
                            }
                            if (objDetail.EvaluaterDeptId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("DID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("DID", OracleDbType.Int32).Value = objDetail.EvaluaterDeptId;
                            }
                            if (objDetail.EvaluaterDsgntId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objDetail.EvaluaterDsgntId;
                            }
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntity_Evaluator_list objDetail in ObjEntityEvaluatorList)
                    {
                       
                        string strQueryInsertDetails = "HCM_EMP_PERFORMANCE_ISSUE.SP_INSERT_PRFRM_EVLTR";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                            if (objDetail.EvaluaterEmpId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVID", OracleDbType.Int32).Value = objDetail.EvaluaterEmpId;

                            }
                            if (objDetail.EvaluaterDeptId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDEPTID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDEPTID", OracleDbType.Int32).Value = objDetail.EvaluaterDeptId;
                            }
                            if (objDetail.EvaluaterDsgntId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDSGNID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("EVDSGNID", OracleDbType.Int32).Value = objDetail.EvaluaterDsgntId;
                            }
                            cmdAddInsertDetail.Parameters.Add("EVGL", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalutorGoal;

                            cmdAddInsertDetail.ExecuteNonQuery();
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

        public void Confirm_PerfrmIssue(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryReadAcco = "HCM_EMP_PERFORMANCE_ISSUE.SP_INS_CONFIRM";
                    using (OracleCommand cmdReadAcco = new OracleCommand())
                    {
                        cmdReadAcco.CommandText = strQueryReadAcco;
                        cmdReadAcco.CommandType = CommandType.StoredProcedure;
                        cmdReadAcco.Parameters.Add("ISSID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                        cmdReadAcco.Parameters.Add("UID", OracleDbType.Int32).Value = objEntityPerformanceIssue.UserId;
                        cmdReadAcco.Parameters.Add("ISDATE", OracleDbType.Date).Value = objEntityPerformanceIssue.IssueDate;

                        clsDataLayer.ExecuteNonQuery(cmdReadAcco);
                    }

                    string strQueryLeaveTyp = "HCM_EMP_PERFORMANCE_ISSUE.SP_INS_TEMPLATE_BKUP";

                    using (OracleCommand cmdReadAcco = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdReadAcco.Transaction = tran;
                        cmdReadAcco.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        clsDataLayer objDatatLayer = new clsDataLayer();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_BKUP);
                        objEntCommon.CorporateID = objEntityPerformanceIssue.Corp_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityPerformanceIssue.TemplateBkUpID = Convert.ToInt32(strNextNum);
                        cmdReadAcco.Parameters.Add("BKUPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.TemplateBkUpID;
                        cmdReadAcco.Parameters.Add("ISSID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                        cmdReadAcco.Parameters.Add("TEPLTEID", OracleDbType.Int32).Value = objEntityPerformanceIssue.PerfrmTempltId;
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_GRP_BKUP);
                        objEntCommon.CorporateID = objEntityPerformanceIssue.Corp_Id;
                        string strNextNum1 = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityPerformanceIssue.QuestionBkUpID = Convert.ToInt32(strNextNum1);
                        cmdReadAcco.Parameters.Add("GRPBKID", OracleDbType.Int32).Value = objEntityPerformanceIssue.QuestionBkUpID;

                        clsDataLayer.ExecuteNonQuery(cmdReadAcco);
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

        public void CancelIsssuePrfrm(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQuerylWelfare = "HCM_EMP_PERFORMANCE_ISSUE.SP_CANCEL_PERFRMNCE";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                cmdlWelfare.Parameters.Add("W_CNSL_USRID", OracleDbType.Int32).Value = objEntityPerformanceIssue.UserId;
                cmdlWelfare.Parameters.Add("W_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public void ChangeIssueStatus(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQuerylWelfare = "HCM_EMP_PERFORMANCE_ISSUE.SP_UPD_CHANGE_STATUS";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
                cmdlWelfare.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityPerformanceIssue.Status;
                cmdlWelfare.Parameters.Add("W_UPDUSERID", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.UserId;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        //public DataTable CheckCategoryId(clsEntity_Issue_Performance objEntityPerformanceIssue)
        //{
        //    string strQueryEmptById = "HCM_EMP_PERFORMANCE_ISSUE.SP_CHECK_CATEGORYID";
        //    OracleCommand cmdReadHol = new OracleCommand();
        //    cmdReadHol.CommandText = strQueryEmptById;
        //    cmdReadHol.CommandType = CommandType.StoredProcedure;
        //    cmdReadHol.Parameters.Add("IS_NAME", OracleDbType.Varchar2).Value = objEntityPerformanceIssue.Issue;
        //    cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtLeavTyp = new DataTable();
        //    dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
        //    return dtLeavTyp;
        //}
        public DataTable ReadAnalyzePerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_ANALYZE_EMP";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ISID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            cmdReadEmployee.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPerformanceIssue.OrgId;
            cmdReadEmployee.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPerformanceIssue.Corp_Id;
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable ReadConfirmPerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_EMP_CONFIRMCOUNT";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ISID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable RemovePerform(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_CANCEL_PRFRM_EMP";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            if (objEntityPerformanceIssue.EmpID != 0)
            {
                cmdReadEmployee.Parameters.Add("EID", OracleDbType.Int32).Value = objEntityPerformanceIssue.EmpID;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("EID", OracleDbType.Int32).Value = null;
            }
            if (objEntityPerformanceIssue.DeptID == 0)
            {
                cmdReadEmployee.Parameters.Add("DID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DID", OracleDbType.Int32).Value = objEntityPerformanceIssue.DeptID;
            }
            if (objEntityPerformanceIssue.DsgnID == 0)
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objEntityPerformanceIssue.DsgnID;
            }
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable RemoveEvalEmp(clsEntity_Issue_Performance objEntityPerformanceIssue)
        {
            string strQueryReadEmployee = "HCM_EMP_PERFORMANCE_ISSUE.SP_CANCEL_PRFRM_EVAL";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ISUE_ID", OracleDbType.Int32).Value = objEntityPerformanceIssue.IssueId;
            if (objEntityPerformanceIssue.EvalEmpID != 0)
            {
                cmdReadEmployee.Parameters.Add("EID", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalEmpID;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("EID", OracleDbType.Int32).Value = null;
            }
            if (objEntityPerformanceIssue.EvalDeptID == 0)
            {
                cmdReadEmployee.Parameters.Add("DID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DID", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDeptID;
            }
            if (objEntityPerformanceIssue.EvalDsgnID == 0)
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmployee.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objEntityPerformanceIssue.EvalDsgnID;
            }
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
    }
}
