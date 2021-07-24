using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;

namespace DL_Compzit
{
   public class clsDataLayerEmpRoleAllocation
    {
        //Method for fetch designation master table from database.
        public DataTable ReadDesignation(int orgId,int userId)
        {
            string strQueryReadCountry = "EMPLOYEE_ROLE.SP_READ_DESG";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = orgId;
                cmdReadCountry.Parameters.Add("E_USRID", OracleDbType.Int32).Value = userId;
                cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Method for fetch jobrole master table from database.
        public DataTable ReadJobRole(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strQueryReadCountry = "EMPLOYEE_ROLE.SP_READ_JOBROLE";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("E_DSGNID", OracleDbType.Int32).Value = objEmpRoleAllocation.DesgId;
                cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Method for fetch employee details from database.
        public DataTable ReadEmployee(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strQueryReadCountry = "EMPLOYEE_ROLE.SP_READ_EMPLOYEE";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("E_JOBRLID", OracleDbType.Int32).Value = objEmpRoleAllocation.JobroleId;
                cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        // This Method for fetching the Compzit Modules by user id.Fetching modules only which is allowed for user.
        public DataTable DisplayCompzitModuleByUsrId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strCommandText = "EMPLOYEE_ROLE.SP_RD_CMPZIT_MODULE_BYUSRID";
            using (OracleCommand cmdCmpztModule = new OracleCommand())
            {
                cmdCmpztModule.CommandText = strCommandText;
                cmdCmpztModule.CommandType = CommandType.StoredProcedure;
                if (objEmpRoleAllocation.UserId == 0)
                {
                    cmdCmpztModule.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdCmpztModule.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.UserId;
                }
                cmdCmpztModule.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispCmpztModule = new DataTable();
                dtDispCmpztModule = clsDataLayer.SelectDataTable(cmdCmpztModule);
                return dtDispCmpztModule;
            }
        }
        //Method for fetch DesignationControl from database of by employee id.
        public string ReadDsgnControl(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strQueryReadControl = "EMPLOYEE_ROLE.SP_READ_DSGTYP_CNTRL_BY_ID";
            OracleCommand cmdReadControl = new OracleCommand();

            cmdReadControl.CommandText = strQueryReadControl;
            cmdReadControl.CommandType = CommandType.StoredProcedure;
            cmdReadControl.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.DesgId;
            cmdReadControl.Parameters.Add("E_CONTROL", OracleDbType.Varchar2, 1).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadControl);
            string strReturn = cmdReadControl.Parameters["E_CONTROL"].Value.ToString();
            cmdReadControl.Dispose();
            return strReturn;

        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strCommandText = "EMPLOYEE_ROLE.SP_RD_USR_IFLIMITED_BYUSRID";
            using (OracleCommand cmdUserDtl = new OracleCommand())
            {
                cmdUserDtl.CommandText = strCommandText;
                cmdUserDtl.CommandType = CommandType.StoredProcedure;
                cmdUserDtl.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.UserId;
                cmdUserDtl.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispUserDtl = new DataTable();
                dtDispUserDtl = clsDataLayer.SelectDataTable(cmdUserDtl);
                return dtDispUserDtl;
            }
        }
        // This Method displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strCommandText = "EMPLOYEE_ROLE.SP_READ_USR_ROLE_MSTR";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEmpRoleAllocation.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEmpRoleAllocation.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEmpRoleAllocation.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.UserId;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEmpRoleAllocation.UserLimited;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        public DataTable DisplayUserolMstrFramewrk(clsEntityEmpRoleAllocation objEntityDsgn)
        {
            string strCommandText = "EMPLOYEE_ROLE.SP_READ_USR_ROLE_MSTR_FRAMEWRK";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityDsgn.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityDsgn.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityDsgn.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserId;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityDsgn.UserLimited;
                cmdGrid.Parameters.Add("D_FRAMEWRK_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        //Read Desgnation master table according to their Id(Primary Key)
        public DataTable ReadDsgnMasterEdit(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "EMPLOYEE_ROLE.SP_READ_DSGN_MASTER_BYID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Read Desgnation APP Roles master table according to their Dsgn Id(Primary Key)
        public DataTable ReadDsgnAppRoleByDsgnId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            using (OracleCommand cmdReadDsgnApp = new OracleCommand())
            {
                cmdReadDsgnApp.CommandText = "EMPLOYEE_ROLE.SP_READ_DSGN_APPROLE_BY_DSGNID";
                cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnAppMasterEdit = new DataTable();
                dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
                return dtDsgnAppMasterEdit;
            }
        }
        //Method for fetch next value from database of current next id.
        public DataTable ReadNextId(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEmpRoleAllocation.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }
        //Methode of inserting values to employee Roles table.
        public void InsertEmpRlDetail(clsEntityEmpRoleAllocation objEmpRoleAllocation, List<clsEntityLayerEmployeeRole> objlisDsgnRolDtls, List<clsEntityLayerEmployeeAppRole> objlisDsgnAppRolDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "EMPLOYEE_ROLE.SP_INS_EMPRLALCTN_MSTR";
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeRoleId;
                        cmdInsertDsgn.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.DesgId;
                        cmdInsertDsgn.Parameters.Add("E_JOBRL_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.JobroleId;
                        cmdInsertDsgn.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                        cmdInsertDsgn.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEmpRoleAllocation.EmpRoleStatusId;
                        cmdInsertDsgn.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.UserId;
                        cmdInsertDsgn.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.OrgId;
                        cmdInsertDsgn.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.CorpOfficeId;
                        cmdInsertDsgn.ExecuteNonQuery();

                    }

                    string strQueryInsertDsgnRole = "EMPLOYEE_ROLE.SP_INS_EMPRL_ROLES";
                    foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                            cmdInsertDsgRole.Parameters.Add("E_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }
                    //NOT OK FROM HERE
                    string strQueryInsertDsgnAppRole = "EMPLOYEE_ROLE.SP_INS_EMPRL_APP_ROLES";
                    foreach (clsEntityLayerEmployeeAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                            cmdInsertDsgAppRole.Parameters.Add("E_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                            cmdInsertDsgAppRole.ExecuteNonQuery();
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

        public DataTable ReadEmproleList(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            string strQueryReadCountry = "EMPLOYEE_ROLE.SP_READ_EMPLIST_SRCH";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEmpRoleAllocation.OrgId;
                cmdReadCountry.Parameters.Add("E_DSGNID", OracleDbType.Int32).Value = objEmpRoleAllocation.DesgId;
                cmdReadCountry.Parameters.Add("E_JOBRLID", OracleDbType.Int32).Value = objEmpRoleAllocation.JobroleId;

                cmdReadCountry.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEmpRoleAllocation.CommonSearchTerm;
                cmdReadCountry.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEmpRoleAllocation.SearchName;
                cmdReadCountry.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEmpRoleAllocation.OrderColumn;
                cmdReadCountry.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEmpRoleAllocation.OrderMethod;
                cmdReadCountry.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEmpRoleAllocation.PageMaxSize;
                cmdReadCountry.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEmpRoleAllocation.PageNumber;

                cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        //Read employee master table according to their Id(Primary Key)
        public DataTable ReadEmpRLMasterById(clsEntityEmpRoleAllocation objEmpRoleAllocation)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "EMPLOYEE_ROLE.SP_READ_EMPRLALLC_MASTER_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeRoleId;
                cmdReadDsgnEdit.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }

        //Update Employee Role
        //Method of inserting values to user roles and user app Roles table.
        public void UpdateEmpRlDetail(clsEntityEmpRoleAllocation objEmpRoleAllocation, List<clsEntityLayerEmployeeRole> objlisDsgnRolDtls, List<clsEntityLayerEmployeeAppRole> objlisDsgnAppRolDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "EMPLOYEE_ROLE.SP_UPD_EMPRLALLC_MSTR";
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeRoleId;
                        cmdInsertDsgn.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.DesgId;
                        cmdInsertDsgn.Parameters.Add("E_JOBRL_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.JobroleId;
                        cmdInsertDsgn.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                        cmdInsertDsgn.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEmpRoleAllocation.EmpRoleStatusId;
                        cmdInsertDsgn.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.UserId;
                        cmdInsertDsgn.ExecuteNonQuery();

                    }

                    string strQueryInsertDsgnRole = "EMPLOYEE_ROLE.SP_INS_EMPRL_ROLES";
                    foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                            cmdInsertDsgRole.Parameters.Add("E_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }
                    //NOT OK FROM HERE
                    string strQueryInsertDsgnAppRole = "EMPLOYEE_ROLE.SP_INS_EMPRL_APP_ROLES";
                    foreach (clsEntityLayerEmployeeAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEmpRoleAllocation.EmployeeId;
                            cmdInsertDsgAppRole.Parameters.Add("E_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                            cmdInsertDsgAppRole.ExecuteNonQuery();
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

    }
}
