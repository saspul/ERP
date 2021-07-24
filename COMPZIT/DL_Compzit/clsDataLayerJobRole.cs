using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerJobRole
    {
        // This Method for fetching the Compzit Modules by user id.Fetching modules only which is allowed for user.
        public DataTable DisplayCompzitModuleByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            string strCommandText = "JOB_ROLE.SP_RD_CMPZIT_MODULE_BYUSRID";
            using (OracleCommand cmdCmpztModule = new OracleCommand())
            {
                cmdCmpztModule.CommandText = strCommandText;
                cmdCmpztModule.CommandType = CommandType.StoredProcedure;
                cmdCmpztModule.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdCmpztModule.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispCmpztModule = new DataTable();
                dtDispCmpztModule = clsDataLayer.SelectDataTable(cmdCmpztModule);
                return dtDispCmpztModule;
            }
        }
        //To select designation type details
        public DataTable ReadDsgnDetails(clsEntityLayerJobRole objEntityJobRl)
        {
            DataTable dtDsgnTypeDetails = new DataTable();
            using (OracleCommand cmdReadDsgnType = new OracleCommand())
            {
                cmdReadDsgnType.CommandText = "JOB_ROLE.SP_READ_DESIGNATION";
                //cmdReadDsgnType.CommandText = "DESIGNATION_MASTER.SP_READ_GN_DESIGNATIONS";
                cmdReadDsgnType.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnType.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityJobRl.DsgControl.ToString();
                cmdReadDsgnType.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = objEntityJobRl.DesignationTypeId;
                cmdReadDsgnType.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityJobRl.DsgnOrgId;
                cmdReadDsgnType.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdReadDsgnType.Parameters.Add("D_DSGN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               
                dtDsgnTypeDetails = clsDataLayer.SelectDataTable(cmdReadDsgnType);
            }
            return dtDsgnTypeDetails;

        }
        //Read Desgnation master table according to their Id(Primary Key)
        public DataTable ReadDsgnMasterEdit(clsEntityLayerJobRole objEntityJobRl)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "JOB_ROLE.SP_READ_DSGN_MASTER_BYID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.DesignationId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Read Desgnation APP Roles master table according to their Dsgn Id(Primary Key)
        public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerJobRole objEntityJobRl)
        {
            using (OracleCommand cmdReadDsgnApp = new OracleCommand())
            {
                cmdReadDsgnApp.CommandText = "JOB_ROLE.SP_READ_DSGN_APPROLE_BY_DSGNID";
                cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.DesignationId;
                cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnAppMasterEdit = new DataTable();
                dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
                return dtDsgnAppMasterEdit;
            }
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerJobRole objEntityJobRl)
        {
            string strCommandText = "JOB_ROLE.SP_RD_USR_IFLIMITED_BYUSRID";
            using (OracleCommand cmdUserDtl = new OracleCommand())
            {
                cmdUserDtl.CommandText = strCommandText;
                cmdUserDtl.CommandType = CommandType.StoredProcedure;
                cmdUserDtl.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdUserDtl.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispUserDtl = new DataTable();
                dtDispUserDtl = clsDataLayer.SelectDataTable(cmdUserDtl);
                return dtDispUserDtl;
            }
        }
        //Method for fetch DesignationControl from database of by designation id.
        public string ReadDsgnControl(clsEntityLayerJobRole objEntityJobRl)
        {
            string strQueryReadControl = "JOB_ROLE.SP_READ_DSGTYP_CNTRL_BY_ID";
            OracleCommand cmdReadControl = new OracleCommand();

            cmdReadControl.CommandText = strQueryReadControl;
            cmdReadControl.CommandType = CommandType.StoredProcedure;
            cmdReadControl.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.DesignationId;
            cmdReadControl.Parameters.Add("D_CONTROL", OracleDbType.Varchar2, 1).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadControl);
            string strReturn = cmdReadControl.Parameters["D_CONTROL"].Value.ToString();
            cmdReadControl.Dispose();
            return strReturn;

        }
        // This Method displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityLayerJobRole objEntityJobRl)
        {
            string strCommandText = "JOB_ROLE.SP_READ_USR_ROLE_MSTR";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityJobRl.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityJobRl.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityJobRl.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityJobRl.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityJobRl.UserID;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityJobRl.UserLimited;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        public DataTable DisplayUserolMstrFramewrk(clsEntityLayerJobRole objEntityDsgn)
        {
            string strCommandText = "JOB_ROLE.SP_READ_USR_ROLE_MSTR_FRAMEWRK";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityDsgn.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityDsgn.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityDsgn.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserID;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityDsgn.UserLimited;
                cmdGrid.Parameters.Add("D_FRAMEWRK_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        // This Method checks JOB ROLE Name in the database for duplication
        public string CheckDupJobRlNameIns(clsEntityLayerJobRole objDsgn)
        {
            string strQueryCheckDsgnName = "JOB_ROLE.SP_CHECK_INS_GN_JOBRL_NAME";
            OracleCommand cmdCheckJobRlName = new OracleCommand();

            cmdCheckJobRlName.CommandText = strQueryCheckDsgnName;
            cmdCheckJobRlName.CommandType = CommandType.StoredProcedure;
            cmdCheckJobRlName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.JobRoleId;
            cmdCheckJobRlName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objDsgn.JobRoleName;
            cmdCheckJobRlName.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objDsgn.DsgnOrgId;
            cmdCheckJobRlName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckJobRlName);
            string strReturn = cmdCheckJobRlName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckJobRlName.Dispose();
            return strReturn;

        }
        //Method for fetch next value from database of current next id.
        public DataTable ReadNextId(clsEntityLayerJobRole objEntityDsgn)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = objEntityDsgn.NextId;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }
        //Methode of inserting values to Designation and Desgnation Roles table.
        public void InsertJobRlDetail(clsEntityLayerJobRole objEntityDsgn, List<clsEntityLayerJobRlRole> objlisDsgnRolDtls, List<clsEntityLayerJobRlAppRole> objlisDsgnAppRolDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "JOB_ROLE.SP_INS_JOBRL_MSTR";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                        cmdInsertDsgn.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDsgn.JobRoleName;
                        cmdInsertDsgn.Parameters.Add("D_DSGN_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                        cmdInsertDsgn.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityDsgn.JobRoleStatus;
                        cmdInsertDsgn.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserID;
                        cmdInsertDsgn.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                        if (objEntityDsgn.CorpOfficeId == 0)
                        {
                            cmdInsertDsgn.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = null;

                        }
                        else
                        {
                            cmdInsertDsgn.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                        }
                        cmdInsertDsgn.ExecuteNonQuery();

                    }
                   
                    string strQueryInsertDsgnRole = "JOB_ROLE.SP_INS_JOBRL_ROLES";
                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId; 
                            cmdInsertDsgRole.Parameters.Add("D_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }
                    
                    string strQueryInsertDsgnAppRole = "JOB_ROLE.SP_INS_JOBRL_APP_ROLES";
                    foreach (clsEntityLayerJobRlAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId; 
                            cmdInsertDsgAppRole.Parameters.Add("D_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

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
        // This Method displays Designation details from the database
        public DataTable GridDisplayJobRole(clsEntityLayerJobRole objEntityDsgn)
        {
            string strCommandText = "JOB_ROLE.SP_READ_GN_JOB_ROLE_MASTER";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
                cmdGrid.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityDsgn.JobRoleStatus;
                cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityDsgn.Cancel_Status;
                cmdGrid.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_DSGN_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                if (objEntityDsgn.CorpOfficeId==0)
                {
                    cmdGrid.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = null;

                }
                else
                {
                cmdGrid.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                }
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserID;
                cmdGrid.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }




        public DataTable GridDisplayJobRolelist(clsEntityLayerJobRole objEntityDsgn)
        {
            string strCommandText = "JOB_ROLE.SP_READ_GN_JOB_ROLE_MASTERLST";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
                cmdGrid.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityDsgn.JobRoleStatus;
                cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityDsgn.Cancel_Status;
                cmdGrid.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_DSGN_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                if (objEntityDsgn.CorpOfficeId == 0)
                {
                    cmdGrid.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = null;

                }
                else
                {
                    cmdGrid.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                }
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserID;

                cmdGrid.Parameters.Add("D_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityDsgn.CommonSearchTerm;
                cmdGrid.Parameters.Add("D_SEARCH_JOB", OracleDbType.Varchar2).Value = objEntityDsgn.SearchJOB;

                cmdGrid.Parameters.Add("D_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityDsgn.OrderColumn;
                cmdGrid.Parameters.Add("D_ORDER_METHOD", OracleDbType.Int32).Value = objEntityDsgn.OrderMethod;
                cmdGrid.Parameters.Add("D_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityDsgn.PageMaxSize;
                cmdGrid.Parameters.Add("D_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityDsgn.PageNumber;



                cmdGrid.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }



        //Read JOBRL_MASTER table according to their Id(Primary Key)
        public DataTable ReadJobRLMasterById(clsEntityLayerJobRole objEntityDsgn)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "JOB_ROLE.SP_READ_GN_JOBRL_MASTER_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        ////Read Desgnation APP Roles master table according to their Dsgn Id(Primary Key)
        //public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerDesignation objEntityDsgn)
        //{
        //    using (OracleCommand cmdReadDsgnApp = new OracleCommand())
        //    {
        //        cmdReadDsgnApp.CommandText = "DESIGNATION_MASTER.SP_READ_DSGN_APPROLE_BY_DSGNID";
        //        cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
        //        cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
        //        cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtDsgnAppMasterEdit = new DataTable();
        //        dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
        //        return dtDsgnAppMasterEdit;
        //    }
        //}
        //Read ReadJobRl Roles table according to their Id(Primary Key)
        public DataTable ReadJobRlRoles(clsEntityLayerJobRole objEntityJobRl)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "JOB_ROLE.SP_READ_GN_JOBRL_ROLES_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.JobRoleId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Read Approles by ID
        public DataTable ReadJobRlAppRoles(clsEntityLayerJobRole objEntityJobRl)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "JOB_ROLE.SP_READ_GN_JOBRL_APPRL_BY_ID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.JobRoleId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
        //Update Job Role
        //Method of inserting values to Designation and Desgnation Roles table.
        public void UpdateJobRlDetail(clsEntityLayerJobRole objEntityDsgn, List<clsEntityLayerJobRlRole> objlisDsgnRolDtls, List<clsEntityLayerJobRlAppRole> objlisDsgnAppRolDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "JOB_ROLE.SP_UPD_JOBRL_MSTR";
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                        cmdInsertDsgn.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDsgn.JobRoleName;
                        cmdInsertDsgn.Parameters.Add("D_DSGN_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                        cmdInsertDsgn.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityDsgn.JobRoleStatus;
                        cmdInsertDsgn.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.UserID;
                        cmdInsertDsgn.ExecuteNonQuery();

                    }

                    string strQueryInsertDsgnRole = "JOB_ROLE.SP_INS_JOBRL_ROLES";
                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                            cmdInsertDsgRole.Parameters.Add("D_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }
                    string strQueryInsertDsgnAppRole = "JOB_ROLE.SP_INS_JOBRL_APP_ROLES";
                    foreach (clsEntityLayerJobRlAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                            cmdInsertDsgAppRole.Parameters.Add("D_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                            cmdInsertDsgAppRole.ExecuteNonQuery();
                        }
                    }
                    //if allocate all is checked  only 
                    if (objEntityDsgn.AllocateAll == 1)
                    {
                        // DELETE USEROLE AND USRAPPROLE 
                        //AND AGAIN INSERT TO IT BASED ON NEW VALUES
                        string strQueryInsDelUserRoles = "JOB_ROLE.SP_DELINS_USR_ROLS_BY_JOBRLID";
                        using (OracleCommand cmdInsertDelUsrRole = new OracleCommand())
                        {

                            cmdInsertDelUsrRole.Transaction = tran;
                            cmdInsertDelUsrRole.Connection = con;
                            cmdInsertDelUsrRole.CommandText = strQueryInsDelUserRoles;
                            cmdInsertDelUsrRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDelUsrRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.JobRoleId;
                            cmdInsertDelUsrRole.Parameters.Add("D_COPRID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                            cmdInsertDelUsrRole.ExecuteNonQuery();

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
        // This Method checks JOB ROLE Name in the database for duplication (FOR UPDATE)
        public string CheckDupJobRlNameUpd(clsEntityLayerJobRole objDsgn)
        {
            string strQueryCheckDsgnName = "JOB_ROLE.SP_CHECK_UPD_GN_JOBRL_NAME";
            OracleCommand cmdCheckDsgnName = new OracleCommand();

            cmdCheckDsgnName.CommandText = strQueryCheckDsgnName;
            cmdCheckDsgnName.CommandType = CommandType.StoredProcedure;
            cmdCheckDsgnName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.JobRoleId;
            cmdCheckDsgnName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objDsgn.JobRoleName;
            cmdCheckDsgnName.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objDsgn.DsgnOrgId;
            cmdCheckDsgnName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDsgnName);
            string strReturn = cmdCheckDsgnName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDsgnName.Dispose();
            return strReturn;

        }
        //Method for updating Job Role cancel details in job role master table.
        public void UpdateJobRlCancel(clsEntityLayerJobRole objEntDsgn)
        {

            using (OracleCommand cmdupdateDsgnCancel = new OracleCommand())
            {
                cmdupdateDsgnCancel.InitialLONGFetchSize = 1000;
                cmdupdateDsgnCancel.CommandText = "JOB_ROLE.SP_UPDATE_JOBRLMASTR_CANCEL";
                cmdupdateDsgnCancel.CommandType = CommandType.StoredProcedure;
                cmdupdateDsgnCancel.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntDsgn.JobRoleId;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELID", OracleDbType.Int32).Value = objEntDsgn.UserID;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELREASON", OracleDbType.Varchar2).Value = objEntDsgn.DesignationCancelReason;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELDATE", OracleDbType.Date).Value = objEntDsgn.DsgnDate;
                clsDataLayer.ExecuteNonQuery(cmdupdateDsgnCancel);
            }
        }
        //Method for recall Job Role

        public void ReCallJobRl(clsEntityLayerJobRole objEntDsgn)
        {
            string strQueryRecallJobRl = "JOB_ROLE.SP_RECALL_JOBRL_MASTER";
            using (OracleCommand cmdRecallJobRl = new OracleCommand())
            {
                cmdRecallJobRl.CommandText = strQueryRecallJobRl;
                cmdRecallJobRl.CommandType = CommandType.StoredProcedure;
                cmdRecallJobRl.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntDsgn.JobRoleId;
                cmdRecallJobRl.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntDsgn.UserID;
                clsDataLayer.ExecuteNonQuery(cmdRecallJobRl);
            }
        }


        public void CanclJobRl(clsEntityLayerJobRole objEntDsgn)
        {
            string strQueryCanclJobRl = "JOB_ROLE.SP_CHANGESTS";
            using (OracleCommand cmdCanclJobRl = new OracleCommand())
            {
                cmdCanclJobRl.CommandText = strQueryCanclJobRl;
                cmdCanclJobRl.CommandType = CommandType.StoredProcedure;
                cmdCanclJobRl.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntDsgn.JobRoleId;
                cmdCanclJobRl.Parameters.Add("D_STS", OracleDbType.Int32).Value = objEntDsgn.JobRoleStatus;
                clsDataLayer.ExecuteNonQuery(cmdCanclJobRl);
            }
        }


        //Method for fetch Job rol App Role  master table by their  jobrl_id(primary key).
        public DataTable ReadJobRlAppRoleByJobRl(clsEntityLayerJobRole objEntityJobRl)
        {
            using (OracleCommand cmdReadDsgnApp = new OracleCommand())
            {
                cmdReadDsgnApp.CommandText = "JOB_ROLE.SP_READ_APPROLE_BY_JOBRLID";
                cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityJobRl.JobRoleId;
                cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnAppMasterEdit = new DataTable();
                dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
                return dtDsgnAppMasterEdit;
            }
        }
      

    }
}
