using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
    public class cls_DataLayer_Emp_Transfer
    {
        //FOR READING BUSSINESS UNIUTS
        public DataTable ReadBussinessUnit(clsEntity_Emp_Transfer  ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = new DataTable();
            using (OracleCommand cmdReadbusiness = new OracleCommand())
            {
                cmdReadbusiness.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_BUSINESS_UNIT";
                cmdReadbusiness.CommandType = CommandType.StoredProcedure;
                cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadbusiness.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
            }
            return dtBusinessUnit;
        }
        // FOR READING EMPLOYEES BY B U
        public DataTable ReadEmployees(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtEmployees = new DataTable();
            using (OracleCommand cmdReadEmployeesByBU = new OracleCommand())
            {
                cmdReadEmployeesByBU.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_EMPLOYEES";
                cmdReadEmployeesByBU.CommandType = CommandType.StoredProcedure;
                cmdReadEmployeesByBU.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadEmployeesByBU.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadEmployeesByBU.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtEmployees = clsDataLayer.SelectDataTable(cmdReadEmployeesByBU);
            }
            return dtEmployees;
        }
        //READ EMPLOYEE DETAILS BY ID
        public DataTable ReadEmployeesDetailsById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtEmpDetails = new DataTable();
            using (OracleCommand cmdReadEmpDetailsByid = new OracleCommand())
            {
                cmdReadEmpDetailsByid.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_EMP_DATABYID";
                cmdReadEmpDetailsByid.CommandType = CommandType.StoredProcedure;
                cmdReadEmpDetailsByid.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadEmpDetailsByid.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadEmpDetailsByid.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
                cmdReadEmpDetailsByid.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtEmpDetails = clsDataLayer.SelectDataTable(cmdReadEmpDetailsByid);
            }
            return dtEmpDetails;
        }
        //READ ALL DEPARTMENTS
        public DataTable ReadCorporateDepartments(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtCorpDepartments = new DataTable();
            using (OracleCommand cmdReadCorpDep = new OracleCommand())
            {
                cmdReadCorpDep.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_CORP_DEP";
                cmdReadCorpDep.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDep.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadCorpDep.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadCorpDep.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCorpDepartments = clsDataLayer.SelectDataTable(cmdReadCorpDep);
            }
            return dtCorpDepartments;
        }
        //READ ALL DIVISIONS
        public DataTable ReadDivisions(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtDivisions = new DataTable();
            using (OracleCommand cmdReadDivisions = new OracleCommand())
            {
                cmdReadDivisions.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_CORP_DIV";
                cmdReadDivisions.CommandType = CommandType.StoredProcedure;
                cmdReadDivisions.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadDivisions.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadDivisions.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentId;
                cmdReadDivisions.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtDivisions = clsDataLayer.SelectDataTable(cmdReadDivisions);
            }
            return dtDivisions;
        }
        //READC ALL P[AYGRADES
        public DataTable ReadPaygrade(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtPaygrade = new DataTable();
            using (OracleCommand cmdReadPaygrade = new OracleCommand())
            {
                cmdReadPaygrade.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_PAYGRADE";
                cmdReadPaygrade.CommandType = CommandType.StoredProcedure;
                cmdReadPaygrade.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadPaygrade.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadPaygrade.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtPaygrade = clsDataLayer.SelectDataTable(cmdReadPaygrade);
            }
            return dtPaygrade;
        }
        //READ ALL SPOSEORS LIST
        public DataTable ReadSponsor(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtEmpSponsor = new DataTable();
            using (OracleCommand cmdReadSponsor= new OracleCommand())
            {
                cmdReadSponsor.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_SPONSOR";
                cmdReadSponsor.CommandType = CommandType.StoredProcedure;
                cmdReadSponsor.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadSponsor.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadSponsor.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtEmpSponsor = clsDataLayer.SelectDataTable(cmdReadSponsor);
            }
            return dtEmpSponsor;
        }
        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadProjects(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtProjectcs = new DataTable();
            using (OracleCommand cmdReadProjects = new OracleCommand())
            {
                cmdReadProjects.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_PROJECTS";
                cmdReadProjects.CommandType = CommandType.StoredProcedure;
                cmdReadProjects.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadProjects.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadProjects.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtProjectcs = clsDataLayer.SelectDataTable(cmdReadProjects);
            }
            return dtProjectcs;
        }


        public void InsertEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerDivList, List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "HCM_EMPLOYEE_TRANSFR.SP_INS_EMPLOYEE_TRNSFR";
                    using (OracleCommand cmdInsertEmployeeTransfer = new OracleCommand())
                    {
                        cmdInsertEmployeeTransfer.Transaction = tran;
                        cmdInsertEmployeeTransfer.Connection = con;
                        cmdInsertEmployeeTransfer.CommandText = strQueryInsertDsgn;
                        cmdInsertEmployeeTransfer.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        clsDataLayer objDatatLayer = new clsDataLayer();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_TRANSFER);
                        objEntCommon.CorporateID = ObjEntityEmpTransfer.CorpId;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        ObjEntityEmpTransfer.Emp_TrnsId = Convert.ToInt32(strNextNum);

                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNSFR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_MODE", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Mode;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Type;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_METHD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Method;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_FRM", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
                        if (ObjEntityEmpTransfer.Todate == DateTime.MinValue)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TO", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TO", OracleDbType.Date).Value = ObjEntityEmpTransfer.Todate;
                        }
                        if (ObjEntityEmpTransfer.EmployeeId != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_USRID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.EmployeeId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_USRID", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_BUID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.BusinesUnitId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PYGRD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_RPRTR", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ReporterId;
                        if (ObjEntityEmpTransfer.SponsorId == 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_SPNSRID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_SPNSRID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorId;
                        }
                        if (ObjEntityEmpTransfer.ProjectId == 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PRJCTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PRJCTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ProjectId;
                        }
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_INSUSR", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_OLDBU", OracleDbType.Int32).Value = ObjEntityEmpTransfer.BusinesUnitId_Old;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_ORGID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                        if (ObjEntityEmpTransfer.EmpId != "")
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_NEW_EMPID", OracleDbType.Varchar2).Value = ObjEntityEmpTransfer.EmpId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_NEW_EMPID", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityEmpTransfer.manPOwerId != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_MANPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.manPOwerId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_MANPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.DepartmentIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DEPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.PaygradeIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_PAYID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_PAYID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.SponsorIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_SPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_SPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.DivisionIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DVID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivisionIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DVID", OracleDbType.Int32).Value = null;
                        }

                        if (ObjEntityEmpTransfer.EmpType != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_ETYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.EmpType;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_ETYP", OracleDbType.Int32).Value = null;
                        }

                        cmdInsertEmployeeTransfer.ExecuteNonQuery();
                    }

                    string strQueryInsertInterviewCatDtl = "HCM_EMPLOYEE_TRANSFR.SP_INS_EMPDIVISIONS";
                    foreach (clsEntity_Emp_Transfer ObjEntityEmpTransferDiv in objEntitylayerDivList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_DIV_ID", OracleDbType.Varchar2).Value = ObjEntityEmpTransferDiv.DivisionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }


                    string strQueryInsertEmpDtl = "HCM_EMPLOYEE_TRANSFR.SP_INS_EMPTRNS_EMP";
                    foreach (clsEntity_Emp_Transfer ObjEntityEmpTransferEmp in objEntitylayerEmpList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertEmpDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EMPTRNSID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EMPLOYEE_ID", OracleDbType.Int32).Value = ObjEntityEmpTransferEmp.EmployeeId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_NEWEMP_ID", OracleDbType.Varchar2).Value = ObjEntityEmpTransferEmp.EmpId;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }


        public void UpdateEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerDivList, List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "HCM_EMPLOYEE_TRANSFR.SP_UPD_EMPLOYEE_TRNSFR";
                    using (OracleCommand cmdInsertEmployeeTransfer = new OracleCommand())
                    {
                        cmdInsertEmployeeTransfer.Transaction = tran;
                        cmdInsertEmployeeTransfer.Connection = con;
                        cmdInsertEmployeeTransfer.CommandText = strQueryInsertDsgn;
                        cmdInsertEmployeeTransfer.CommandType = CommandType.StoredProcedure;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNSFR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_MODE", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Mode;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Type;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_METHD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Method;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_FRM", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
                        if (ObjEntityEmpTransfer.Todate == DateTime.MinValue)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TO", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_TO", OracleDbType.Date).Value = ObjEntityEmpTransfer.Todate;
                        }
                        if (ObjEntityEmpTransfer.EmployeeId != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_USRID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.EmployeeId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_USRID", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_BUID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.BusinesUnitId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PYGRD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_RPRTR", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ReporterId;
                        if (ObjEntityEmpTransfer.SponsorId == 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_SPNSRID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_SPNSRID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorId;
                        }
                        if (ObjEntityEmpTransfer.ProjectId == 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PRJCTID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_PRJCTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ProjectId;
                        }
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_INSUSR", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_OLDBU", OracleDbType.Int32).Value = ObjEntityEmpTransfer.BusinesUnitId_Old;
                        cmdInsertEmployeeTransfer.Parameters.Add("E_TRNS_ORGID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                        if (ObjEntityEmpTransfer.EmpId != "")
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_NEW_EMPID", OracleDbType.Varchar2).Value = ObjEntityEmpTransfer.EmpId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_NEW_EMPID", OracleDbType.Varchar2).Value = null;
                        }
                        if (ObjEntityEmpTransfer.manPOwerId != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_MANPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.manPOwerId;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_MANPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.DepartmentIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DEPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.PaygradeIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_PAYID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_PAYID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.SponsorIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_SPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_SPID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntityEmpTransfer.DivisionIdOld != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DVID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivisionIdOld;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_DVID", OracleDbType.Int32).Value = null;
                        }

                        if (ObjEntityEmpTransfer.EmpType != 0)
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_ETYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.EmpType;
                        }
                        else
                        {
                            cmdInsertEmployeeTransfer.Parameters.Add("E_OLD_ETYP", OracleDbType.Int32).Value = null;
                        }

                        cmdInsertEmployeeTransfer.ExecuteNonQuery();
                    }


                    string strQueryDeleteDiv = "HCM_EMPLOYEE_TRANSFR.SP_DELETE_TRNSDIVID";
                    using (OracleCommand cmdDeleteEmployeeTransfer = new OracleCommand())
                    {
                        cmdDeleteEmployeeTransfer.Transaction = tran;
                        cmdDeleteEmployeeTransfer.Connection = con;
                        cmdDeleteEmployeeTransfer.CommandText = strQueryDeleteDiv;
                        cmdDeleteEmployeeTransfer.CommandType = CommandType.StoredProcedure;
                        cmdDeleteEmployeeTransfer.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                        cmdDeleteEmployeeTransfer.ExecuteNonQuery();
                    }
                    string strQueryDeleteusr = "HCM_EMPLOYEE_TRANSFR.SP_DELETE_TRNSUSRID";
                    using (OracleCommand cmdDeleteusr = new OracleCommand())
                    {
                        cmdDeleteusr.Transaction = tran;
                        cmdDeleteusr.Connection = con;
                        cmdDeleteusr.CommandText = strQueryDeleteusr;
                        cmdDeleteusr.CommandType = CommandType.StoredProcedure;
                        cmdDeleteusr.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                        cmdDeleteusr.ExecuteNonQuery();
                    }
                    string strQueryInsertInterviewCatDtl = "HCM_EMPLOYEE_TRANSFR.SP_INS_EMPDIVISIONS";
                    foreach (clsEntity_Emp_Transfer ObjEntityEmpTransferDiv in objEntitylayerDivList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_DIV_ID", OracleDbType.Varchar2).Value = ObjEntityEmpTransferDiv.DivisionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }


                    string strQueryInsertEmpDtl = "HCM_EMPLOYEE_TRANSFR.SP_INS_EMPTRNS_EMP";
                    foreach (clsEntity_Emp_Transfer ObjEntityEmpTransferEmp in objEntitylayerEmpList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertEmpDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EMPTRNSID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EMPLOYEE_ID", OracleDbType.Int32).Value = ObjEntityEmpTransferEmp.EmployeeId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_NEWEMP_ID", OracleDbType.Varchar2).Value = ObjEntityEmpTransferEmp.EmpId;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }
        public void ConfirmEmpTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            string strQueryUpdateDate = "HCM_EMPLOYEE_TRANSFR.SP_CONFIRM_TRANSFER";
            OracleCommand cmdUpdateDate = new OracleCommand();
            cmdUpdateDate.CommandText = strQueryUpdateDate;
            cmdUpdateDate.CommandType = CommandType.StoredProcedure;
            cmdUpdateDate.Parameters.Add("EMP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
            cmdUpdateDate.Parameters.Add("E_INSUSR", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
            clsDataLayer.ExecuteNonQuery(cmdUpdateDate);
        }
        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadEmployeeTransferList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_EMPTRNS_LIST";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadList.Parameters.Add("E_TRNS_MODE", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Mode;
                cmdReadList.Parameters.Add("E_TRNS_TYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Type;
                cmdReadList.Parameters.Add("E_TRNS_METHD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Trans_Method;
                cmdReadList.Parameters.Add("E_TRNS_LINKMAN", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ManPowerLinked;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }
        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadEmployeeTransferById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_EMPTRNS_BY_ID";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadList.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }

        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadManpowerRequestList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_MANPOWER";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadList.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }
        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadManpowerRequestDetailsById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_MAN_PWRRQST_BY_ID";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.manPOwerId;
                cmdReadList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadList.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }

        // FOR READING EMPLOYEES LIST
        public DataTable ReadEmployeeList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtEmployees = new DataTable();
            using (OracleCommand cmdReadEmployeeList = new OracleCommand())
            {
                cmdReadEmployeeList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_EMPLOYEE_lIST";
                cmdReadEmployeeList.CommandType = CommandType.StoredProcedure;
                cmdReadEmployeeList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadEmployeeList.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadEmployeeList.Parameters.Add("E_DEPT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentId;
                cmdReadEmployeeList.Parameters.Add("E_DIV_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivisionId;
                cmdReadEmployeeList.Parameters.Add("E_PGD_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeId;
                cmdReadEmployeeList.Parameters.Add("E_SPNSR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorId;
                cmdReadEmployeeList.Parameters.Add("E_TYPE", OracleDbType.Int32).Value = ObjEntityEmpTransfer.EmpType;
                cmdReadEmployeeList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtEmployees = clsDataLayer.SelectDataTable(cmdReadEmployeeList);
            }
            return dtEmployees;
        }

        public void UpdateEmpTransferDates(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            string strQueryUpdateDate = "HCM_EMPLOYEE_TRANSFR.SP_UPDATE_TRANSFER_DATES";
            OracleCommand cmdUpdateDate = new OracleCommand();
            cmdUpdateDate.CommandText = strQueryUpdateDate;
            cmdUpdateDate.CommandType = CommandType.StoredProcedure;
            cmdUpdateDate.Parameters.Add("EMP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
            cmdUpdateDate.Parameters.Add("EMP_FROM", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
            if (ObjEntityEmpTransfer.Todate != DateTime.MinValue)
            {
                cmdUpdateDate.Parameters.Add("EMP_TO", OracleDbType.Date).Value = ObjEntityEmpTransfer.Todate;
            }
            else
            {
                cmdUpdateDate.Parameters.Add("EMP_TO", OracleDbType.Date).Value = null;
            }
            clsDataLayer.ExecuteNonQuery(cmdUpdateDate);
        }
        //READ EMPLOYEE TRANSFER FROM DATE AND TO DATE
        public DataTable ReadEmployeeTransferDate(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_TRANSFER_DATES";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("EMP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }

        public DataTable ReadEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_E_TRNS_FRM";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }

        public DataTable ReadEmployeeTransferUsrId(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = new DataTable();
            using (OracleCommand cmdReadList = new OracleCommand())
            {
                cmdReadList.CommandText = "HCM_EMPLOYEE_TRANSFR.SP_READ_USRID";
                cmdReadList.CommandType = CommandType.StoredProcedure;
                cmdReadList.Parameters.Add("E_TRNSFR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                cmdReadList.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtLIST = clsDataLayer.SelectDataTable(cmdReadList);
            }
            return dtLIST;
        }

        public void updateUserId(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            foreach (clsEntity_Emp_Transfer objEmpTransEmpIds in objEntitylayerEmpList)
            {
                string strQueryUpdateuserId = "HCM_EMPLOYEE_TRANSFR.SP_UPDATE_USRID";

                using (OracleCommand cmdReadList = new OracleCommand())
                {
                    cmdReadList.CommandText = strQueryUpdateuserId;
                    cmdReadList.CommandType = CommandType.StoredProcedure;
                    cmdReadList.Parameters.Add("E_TRNS_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Emp_TrnsId;
                    cmdReadList.Parameters.Add("E_USRID", OracleDbType.Int32).Value = objEmpTransEmpIds.UserId;
                    cmdReadList.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                    cmdReadList.Parameters.Add("E_CPRDEPT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepartmentId;
                    cmdReadList.Parameters.Add("E_PYGRD_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PaygradeId;
                    cmdReadList.Parameters.Add("E_EMPTRNS_RPRTR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ReporterId;
                    if (ObjEntityEmpTransfer.SponsorId == 0)
                    {
                        cmdReadList.Parameters.Add("E_SPSNSR_ID", OracleDbType.Int32).Value = null;
                    }
                    else
                    {
                        cmdReadList.Parameters.Add("E_SPSNSR_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.SponsorId;
                    }
                    if (ObjEntityEmpTransfer.ProjectId == 0)
                    {
                        cmdReadList.Parameters.Add("E_PROJECT_ID", OracleDbType.Int32).Value = null;
                    }
                    else
                    {
                        cmdReadList.Parameters.Add("E_PROJECT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ProjectId;
                    }
                    clsDataLayer.ExecuteNonQuery(cmdReadList);
                }
            }
        }
    }
}
