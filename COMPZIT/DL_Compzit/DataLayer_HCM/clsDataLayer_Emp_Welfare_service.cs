using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Emp_Welfare_service
    {
        public DataTable ReadDivision(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadDivision = "WELFARE_SERVICE.SP_READ_CORP_DIV";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadDivision.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadDivision.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        public DataTable ReadDepartment(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadDepartment = "WELFARE_SERVICE.SP_READ_CORP_DEP";
            OracleCommand cmdReadDepartment = new OracleCommand();
            cmdReadDepartment.CommandText = strQueryReadDepartment;
            cmdReadDepartment.CommandType = CommandType.StoredProcedure;
            cmdReadDepartment.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadDepartment.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadDepartment.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepartment = new DataTable();
            dtDepartment = clsDataLayer.ExecuteReader(cmdReadDepartment);
            return dtDepartment;
        }
        public DataTable ReadDesignation(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadDesignation = "WELFARE_SERVICE.SP_READ_DESGN";
            OracleCommand cmdReadDesignation = new OracleCommand();
            cmdReadDesignation.CommandText = strQueryReadDesignation;
            cmdReadDesignation.CommandType = CommandType.StoredProcedure;
            cmdReadDesignation.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadDesignation.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDesignation);
            return dtCategory;
        }
        public DataTable ReadEmployee(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadEmployee = "WELFARE_SERVICE.SP_READ_EMPLOYEES";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadEmployee.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable ReadCategory(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadEmployee = "WELFARE_SERVICE.SP_READ_WELFARE_CATEGORY";
            OracleCommand cmdReadEmployee = new OracleCommand();
            cmdReadEmployee.CommandText = strQueryReadEmployee;
            cmdReadEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadEmployee.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadEmployee.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadEmployee.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadEmployee);
            return dtCategory;
        }
        public DataTable ReadCurrency(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadCurrency = "WELFARE_SERVICE.SP_READ_CURRENCY";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadCurrency;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadCurrency.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadCurrency.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtCategory;
        }
        public DataTable ReadDefualtCurrency(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadCurrency = "WELFARE_SERVICE.SP_READDEFLT_CURRENCY";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadCurrency;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadCurrency.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadCurrency.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtCategory;
        }
        public void AddWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare, List<clsEntity_Department_list> ObjEntityDepartmentList, List<clsEntity_Designation_list> ObjEntityDesignationList, List<clsEntity_Division_list> ObjEntityDivisionList, List<clsEntity_Employee_list> ObjEntityEmployeeList, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "WELFARE_SERVICE.SP_INSERT_WLFR_SERVICE";
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
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_WELFARE_SERVICE);
                        objEntCommon.CorporateID = objEntityWelfare.CorpId;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityWelfare.WelfareServiceId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                        cmdAddService.Parameters.Add("CATID", OracleDbType.Int32).Value = objEntityWelfare.CategoryId;
                        cmdAddService.Parameters.Add("SNAME", OracleDbType.Varchar2).Value = objEntityWelfare.ServiceName;
                        cmdAddService.Parameters.Add("SDESC", OracleDbType.Varchar2).Value = objEntityWelfare.ServiceDescription;
                      
                        cmdAddService.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityWelfare.Status;
                        cmdAddService.Parameters.Add("ALDIV", OracleDbType.Int32).Value = objEntityWelfare.AllDivision;
                        cmdAddService.Parameters.Add("ALDEPT", OracleDbType.Int32).Value = objEntityWelfare.AllDepartment;
                        cmdAddService.Parameters.Add("ALDSGN", OracleDbType.Int32).Value = objEntityWelfare.AllDesignation;
                        cmdAddService.Parameters.Add("ALEMP", OracleDbType.Int32).Value = objEntityWelfare.AllEmployee;
                        cmdAddService.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityWelfare.UserId;
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Welfare_Limit_list objSubDetail in objWelfare_LimitDtls)
                    {

                        string strQuerySubDetails = "WELFARE_SERVICE.SP_INSERT_WLFR_SERVICE_SUBDTLS";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddSubDetail.Parameters.Add("QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("MADTORY", OracleDbType.Int32).Value = objSubDetail.Mandatory;
                            cmdAddSubDetail.Parameters.Add("UNIT", OracleDbType.Int32).Value = objSubDetail.Unit;
                            cmdAddSubDetail.Parameters.Add("FRQNCY", OracleDbType.Int32).Value = objSubDetail.Frequency;
                            if (objSubDetail.CurrencyId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = objSubDetail.CurrencyId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.FromPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = objSubDetail.FromPeriod;
                            }
                            if (objSubDetail.ToPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = objSubDetail.ToPeriod;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    if (objEntityWelfare.AllDepartment == 0)
                    {

                        foreach (clsEntity_Department_list objDetail in ObjEntityDepartmentList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_DEPT";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objDetail.DepartmentId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objEntityWelfare.AllDesignation == 0)
                    {

                        foreach (clsEntity_Designation_list objDetail in ObjEntityDesignationList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SRVC_DSGN";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value =objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objDetail.DesignationId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }


                        }
                    }
                    if (objEntityWelfare.AllDivision == 0)
                    {
                        foreach (clsEntity_Division_list objDetail in ObjEntityDivisionList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_DIV";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DIVID", OracleDbType.Int32).Value = objDetail.DivisionId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objEntityWelfare.AllEmployee == 0)
                    {
                        foreach (clsEntity_Employee_list objDetail in ObjEntityEmployeeList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_EMP";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                                cmdAddInsertDetail.ExecuteNonQuery();
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
        public DataTable ReadServiceSubDtlById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryDesigById = "WELFARE_SERVICE.SP_READ_DTLS_BYID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryDesigById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public DataTable ReadServiceDetailsList(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadServices = "WELFARE_SERVICE.SP_READSERVICELIST";
            OracleCommand cmdReadServices = new OracleCommand();
            cmdReadServices.CommandText = strQueryReadServices;
            cmdReadServices.CommandType = CommandType.StoredProcedure;
            cmdReadServices.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadServices.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            if (objEntityWelfare.FromPeriod != DateTime.MinValue)
            {
                cmdReadServices.Parameters.Add("FROMDATE", OracleDbType.Date).Value = objEntityWelfare.FromPeriod;
            }
            else
            {
                cmdReadServices.Parameters.Add("FROMDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityWelfare.ToPeriod != DateTime.MinValue)
            {
                cmdReadServices.Parameters.Add("TODATE", OracleDbType.Date).Value = objEntityWelfare.ToPeriod;
            }
            else
            {
                cmdReadServices.Parameters.Add("TODATE", OracleDbType.Date).Value = null;
            }
            cmdReadServices.Parameters.Add("DESGN", OracleDbType.Int32).Value = objEntityWelfare.DesignationId;
            cmdReadServices.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityWelfare.Status;
            cmdReadServices.Parameters.Add("CANCELSTS", OracleDbType.Int32).Value = objEntityWelfare.Cancel_Status;
            cmdReadServices.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadServices);
            return dtCategory;
        }
        public DataTable ReadServiceDetailsById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryReadCurrency = "WELFARE_SERVICE.SP_READ_SERVICEBYID";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadCurrency;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
            cmdReadCurrency.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
            cmdReadCurrency.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadCurrency.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtCategory;
        }
        public DataTable ReadServiceDesigById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryDesigById = "WELFARE_SERVICE.SP_READ_DESINATION_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryDesigById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public DataTable ReadServiceDeptById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryDeptById = "WELFARE_SERVICE.SP_READ_DEPARTMENT_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryDeptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public DataTable ReadServiceDivisionById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryDeptById = "WELFARE_SERVICE.SP_READ_DIVISION_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryDeptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public DataTable ReadServiceEmployeeById(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryEmptById = "WELFARE_SERVICE.SP_READ_EMPLOYEE_BY_ID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryEmptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
        public void UpdateWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare, List<clsEntity_Department_list> ObjEntityDepartmentList, List<clsEntity_Designation_list> ObjEntityDesignationList, List<clsEntity_Division_list> ObjEntityDivisionList, List<clsEntity_Employee_list> ObjEntityEmployeeList, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Insert, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Update, List<clsEntity_Welfare_Limit_list> objWelfare_LimitDtls_Delete)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "WELFARE_SERVICE.SP_UPDATE_WLFR_SERVICE";
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
                        cmdAddService.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                        cmdAddService.Parameters.Add("CATID", OracleDbType.Int32).Value = objEntityWelfare.CategoryId;
                        cmdAddService.Parameters.Add("SNAME", OracleDbType.Varchar2).Value = objEntityWelfare.ServiceName;
                        cmdAddService.Parameters.Add("SDESC", OracleDbType.Varchar2).Value = objEntityWelfare.ServiceDescription;

                        cmdAddService.Parameters.Add("STS", OracleDbType.Int32).Value = objEntityWelfare.Status;
                        cmdAddService.Parameters.Add("ALDIV", OracleDbType.Int32).Value = objEntityWelfare.AllDivision;
                        cmdAddService.Parameters.Add("ALDEPT", OracleDbType.Int32).Value = objEntityWelfare.AllDepartment;
                        cmdAddService.Parameters.Add("ALDSGN", OracleDbType.Int32).Value = objEntityWelfare.AllDesignation;
                        cmdAddService.Parameters.Add("ALEMP", OracleDbType.Int32).Value = objEntityWelfare.AllEmployee;
                        cmdAddService.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityWelfare.OrgId;
                        cmdAddService.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityWelfare.CorpId;
                        cmdAddService.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityWelfare.UserId;
                        cmdAddService.ExecuteNonQuery();
                    }
                    //Update to sub table

                    foreach (clsEntity_Welfare_Limit_list objSubDetail in objWelfare_LimitDtls_Update)
                    {

                        string strQuerySubDetails = "WELFARE_SERVICE.SP_UPDATE_WLFR_SERVICE_SUBDTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("SUB_ID", OracleDbType.Int32).Value = objSubDetail.Welfare_SubDtlId;
                            cmdAddSubDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddSubDetail.Parameters.Add("QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("MADTORY", OracleDbType.Int32).Value = objSubDetail.Mandatory;
                            cmdAddSubDetail.Parameters.Add("UNIT", OracleDbType.Int32).Value = objSubDetail.Unit;
                            cmdAddSubDetail.Parameters.Add("FRQNCY", OracleDbType.Int32).Value = objSubDetail.Frequency;
                            if (objSubDetail.CurrencyId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = objSubDetail.CurrencyId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.FromPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = objSubDetail.FromPeriod;
                            }
                            if (objSubDetail.ToPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = objSubDetail.ToPeriod;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                        //string strQueryUpdateLimit = "WELFARE_SERVICE.SP_UPD_WLFRSUBDTLS";
                        //using (OracleCommand cmdUpdateLimitl = new OracleCommand(strQueryUpdateLimit, con))
                        //{
                        //    cmdUpdateLimitl.Transaction = tran;
                        //    cmdUpdateLimitl.CommandType = CommandType.StoredProcedure;
                        //    cmdUpdateLimitl.Parameters.Add("SUB_ID", OracleDbType.Int32).Value = objSubDetail.Welfare_SubDtlId;
                        //    cmdUpdateLimitl.Parameters.Add("QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                        //    cmdUpdateLimitl.ExecuteNonQuery();
                        //}
                    }
                    foreach (clsEntity_Welfare_Limit_list objSubDetail in objWelfare_LimitDtls_Delete)
                    {
                        {
                            string strQueryChangeStatus = "WELFARE_SERVICE.DETETEWELFARE_SUBTABLE";
                            using (OracleCommand cmdChangeStatus = new OracleCommand())
                            {
                                cmdChangeStatus.CommandText = strQueryChangeStatus;
                                cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                cmdChangeStatus.Parameters.Add("WEL_SUBID", OracleDbType.Int32).Value = objSubDetail.Welfare_SubDtlId;
                                cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityWelfare.UserId;
                                clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
                            }
                        }
                    }
                    foreach (clsEntity_Welfare_Limit_list objSubDetail in objWelfare_LimitDtls_Insert)
                    {

                        string strQuerySubDetails = "WELFARE_SERVICE.SP_INSERT_WLFR_SERVICE_SUBDTLS";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddSubDetail.Parameters.Add("QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("MADTORY", OracleDbType.Int32).Value = objSubDetail.Mandatory;
                            cmdAddSubDetail.Parameters.Add("UNIT", OracleDbType.Int32).Value = objSubDetail.Unit;
                            cmdAddSubDetail.Parameters.Add("FRQNCY", OracleDbType.Int32).Value = objSubDetail.Frequency;
                            if (objSubDetail.CurrencyId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = objSubDetail.CurrencyId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("CURRENCY", OracleDbType.Int32).Value = null;
                            }
                            if (objSubDetail.FromPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATEFROM", OracleDbType.Date).Value = objSubDetail.FromPeriod;
                            }
                            if (objSubDetail.ToPeriod == DateTime.MinValue)
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("DATETO", OracleDbType.Date).Value = objSubDetail.ToPeriod;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }

                    if (objEntityWelfare.AllDepartment == 0)
                    {
                        string strQueryStatusDetails = "WELFARE_SERVICE.SP_MODIFY_WLFR_SRVC_DEPT";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }


                        foreach (clsEntity_Department_list objDetail in ObjEntityDepartmentList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_DEPT";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DEPTID", OracleDbType.Int32).Value = objDetail.DepartmentId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objEntityWelfare.AllDesignation == 0)
                    {
                        string strQueryStatusDetails = "WELFARE_SERVICE.SP_MODIFY_WLFR_SRVC_DSGN";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }

                        foreach (clsEntity_Designation_list objDetail in ObjEntityDesignationList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SRVC_DSGN";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DSGNID", OracleDbType.Int32).Value = objDetail.DesignationId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }


                        }
                    }
                    if (objEntityWelfare.AllDivision == 0)
                    {
                        string strQueryStatusDetails = "WELFARE_SERVICE.SP_MODIFY_WLFR_SRVC_DIV";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                        foreach (clsEntity_Division_list objDetail in ObjEntityDivisionList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_DIV";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("DIVID", OracleDbType.Int32).Value = objDetail.DivisionId;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    if (objEntityWelfare.AllEmployee == 0)
                    {
                        string strQueryStatusDetails = "WELFARE_SERVICE.SP_MODIFY_WLFR_SRVC_EMP";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryStatusDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                        foreach (clsEntity_Employee_list objDetail in ObjEntityEmployeeList)
                        {

                            string strQueryInsertDetails = "WELFARE_SERVICE.SP_INSRT_UPD_WLFR_SERVICE_EMP";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("SRVC_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                                cmdAddInsertDetail.Parameters.Add("EMPID", OracleDbType.Int32).Value = objDetail.EmployeeId;
                                cmdAddInsertDetail.ExecuteNonQuery();
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
        public void CancelWelfareService(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQuerylWelfare = "WELFARE_SERVICE.SP_CANCEL_WELFARE_SERVICE";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                cmdlWelfare.Parameters.Add("W_CNSL_USRID", OracleDbType.Int32).Value = objEntityWelfare.UserId;
                cmdlWelfare.Parameters.Add("W_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityWelfare.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public void ChangeServiceStatus(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQuerylWelfare = "WELFARE_SERVICE.SP_UPD_CHANGE_STATUS";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfare.WelfareServiceId;
                cmdlWelfare.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWelfare.Status;
                cmdlWelfare.Parameters.Add("W_UPDUSERID", OracleDbType.Varchar2).Value = objEntityWelfare.UserId;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public DataTable CheckCategoryId(clsEntity_Emp_Welfare_Service objEntityWelfare)
        {
            string strQueryEmptById = "WELFARE_SERVICE.SP_CHECK_CATEGORYID";
            OracleCommand cmdReadHol = new OracleCommand();
            cmdReadHol.CommandText = strQueryEmptById;
            cmdReadHol.CommandType = CommandType.StoredProcedure;
            cmdReadHol.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityWelfare.CategoryId;
            cmdReadHol.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavTyp = new DataTable();
            dtLeavTyp = clsDataLayer.ExecuteReader(cmdReadHol);
            return dtLeavTyp;
        }
    }
}
