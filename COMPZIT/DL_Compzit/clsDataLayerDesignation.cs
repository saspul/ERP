using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace DL_Compzit
{
    public class clsDataLayerDesignation
    {
        //To select designation type details
        public DataTable ReadDesignationTypeDetails(clsEntityLayerDesignation objEntityDsgn)
        {
            DataTable dtDsgnTypeDetails = new DataTable();
            using (OracleCommand cmdReadDsgnType = new OracleCommand())
            {
                cmdReadDsgnType.CommandText = "DESIGNATION_MASTER.SP_READ_DSGN_TYPE_BY_USRID";
                cmdReadDsgnType.CommandType = CommandType.StoredProcedure;               
                cmdReadDsgnType.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl.ToString();
                cmdReadDsgnType.Parameters.Add("D_DSGN_TYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtDsgnTypeDetails = clsDataLayer.SelectDataTable(cmdReadDsgnType);
            }
            return dtDsgnTypeDetails;

        }
        // This Method displays User Role details from the database
        public DataTable GridDisplayUserRole()
        {
            string strCommandText = "DESIGNATION_MASTER.SP_READ_GN_USR_ROLE_MASTER";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        // This Method displays Designation details from the database
        public DataTable GridDisplayDesignation(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_READ_GN_DESIGNATIONS";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
                cmdGrid.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                cmdGrid.Parameters.Add("D_OPTION", OracleDbType.Int32).Value = objEntityDsgn.DesignationStatus;
                cmdGrid.Parameters.Add("D_CANCEL", OracleDbType.Int32).Value = objEntityDsgn.Cancel_Status;
                cmdGrid.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityDsgn.CommonSearchTerm;
                cmdGrid.Parameters.Add("D_SEARCH_DESIGN", OracleDbType.Varchar2).Value = objEntityDsgn.SearchDesign;
                cmdGrid.Parameters.Add("AT_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityDsgn.OrderColumn;
                cmdGrid.Parameters.Add("AT_ORDER_METHOD", OracleDbType.Int32).Value = objEntityDsgn.OrderMethod;
                cmdGrid.Parameters.Add("AT_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityDsgn.PageMaxSize;
                cmdGrid.Parameters.Add("AT_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityDsgn.PageNumber;
                cmdGrid.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        //Read Desgnation master table according to their Id(Primary Key)
        public DataTable ReadDsgnMasterEdit(clsEntityLayerDesignation objEntityDsgn)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "DESIGNATION_MASTER.SP_READ_DSGN_MASTER_BYID";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }

        // This Method Updates the Status of Designation in the database
        public void UpdateStatus(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_UPD_GN_DESIGNATIONS_STATUS";
            using (OracleCommand cmdUpdateStatus = new OracleCommand())
            {
                cmdUpdateStatus.CommandText = strCommandText;
                cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateStatus.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                cmdUpdateStatus.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityDsgn.DesignationStatus;
                cmdUpdateStatus.Parameters.Add("D_UPD_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                cmdUpdateStatus.Parameters.Add("D_UPD_DATE", OracleDbType.Date).Value = objEntityDsgn.DsgnDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateStatus);
            }
        }
        //Method for fetch next value from database of current next id.
        public DataTable ReadNextId(clsEntityLayerDesignation objEntityDsgn)
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
        //Method for fetch DesignationControl from database of by designation type id.
        public string ReadDsgnControl(clsEntityLayerDesignation objEntityDsgn)
        {
            string strQueryReadControl = "DESIGNATION_MASTER.SP_READ_DSGTYP_CNTRL_BY_ID";
            OracleCommand cmdReadControl = new OracleCommand();

            cmdReadControl.CommandText = strQueryReadControl;
            cmdReadControl.CommandType = CommandType.StoredProcedure;
            cmdReadControl.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
            cmdReadControl.Parameters.Add("D_CONTROL", OracleDbType.Varchar2, 1).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadControl);
            string strReturn = cmdReadControl.Parameters["D_CONTROL"].Value.ToString();
            cmdReadControl.Dispose();
            return strReturn;

        }
        //Methode of inserting values to Designation and Desgnation Roles table.
        public void InsertDesignationDetails(clsEntityLayerDesignation objEntityDsgn, List<clsEntityLayerDesignationRole> objlisDsgnRolDtls, List<clsEntityLayerDesignationAppRole> objlisDsgnAppRolDtls, List<clsEntityLayerDesignationLeaveType> objlistLeaveType)
        {
          
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "DESIGNATION_MASTER.SP_INS_DSG_MSTR";
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                        cmdInsertDsgn.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDsgn.DesignationName;
                        cmdInsertDsgn.Parameters.Add("DTYP_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
                        cmdInsertDsgn.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityDsgn.DesignationStatus;
                        cmdInsertDsgn.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                        cmdInsertDsgn.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                        cmdInsertDsgn.Parameters.Add("D_PRIMARY", OracleDbType.Int32).Value = objEntityDsgn.DsgnPrimary;
                        cmdInsertDsgn.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl;
                        cmdInsertDsgn.Parameters.Add("D_TYPE", OracleDbType.Int32).Value = objEntityDsgn.Type;
                        cmdInsertDsgn.ExecuteNonQuery();

                    }

                    string strQueryInsertDsgnRole = "DESIGNATION_MASTER.SP_INS_DSGROLE_MSTR";
                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDsgRole.Parameters.Add("D_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }

                    string strQueryInsertDsgnAppRole = "DESIGNATION_MASTER.SP_INS_DSGAPPROLE_MSTR";
                    foreach (clsEntityLayerDesignationAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDsgAppRole.Parameters.Add("D_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                            cmdInsertDsgAppRole.ExecuteNonQuery();
                        }
                    }
                    //Start 0009
                    //To add data to designation leave type table
                    string strQueryAddDesgLeaveType = "DESIGNATION_MASTER.SP_ADD_DESG_LEAVE_TYPE";
                    foreach (clsEntityLayerDesignationLeaveType objDsgn in objlistLeaveType)
                    {
                        using (OracleCommand cmdAddDesgLeaveType = new OracleCommand())
                        {
                            cmdAddDesgLeaveType.Transaction = tran;
                            cmdAddDesgLeaveType.Connection = con;
                            cmdAddDesgLeaveType.CommandText = strQueryAddDesgLeaveType;
                            cmdAddDesgLeaveType.CommandType = CommandType.StoredProcedure;
                            cmdAddDesgLeaveType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdAddDesgLeaveType.Parameters.Add("D_LEAVETYP_ID", OracleDbType.Int32).Value = objDsgn.Leave_Type_Id;
                            cmdAddDesgLeaveType.ExecuteNonQuery();
                        }
                    }

               
                    //Stop 0009
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        // This Method checks Designation Name in the database for duplication
        public string CheckDupDesignationNamesIns(clsEntityLayerDesignation objDsgn)
        {
            string strQueryCheckDsgnName = "DESIGNATION_MASTER.SP_CHECK_INS_GN_DSGN_NAME";
            OracleCommand cmdCheckDsgnName = new OracleCommand();

            cmdCheckDsgnName.CommandText = strQueryCheckDsgnName;
            cmdCheckDsgnName.CommandType = CommandType.StoredProcedure;
            cmdCheckDsgnName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objDsgn.DesignationName;
            cmdCheckDsgnName.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objDsgn.DsgnOrgId;
            cmdCheckDsgnName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDsgnName);
            string strReturn = cmdCheckDsgnName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDsgnName.Dispose();
            return strReturn;

        }
        // This Method checks Designation Name in the database for duplication when updation
        public string CheckDupDesignationNamesUpd(clsEntityLayerDesignation objDsgn)
        {
            string strQueryCheckDsgnName = "DESIGNATION_MASTER.SP_CHECK_UPD_GN_DSGN_NAME";
            OracleCommand cmdCheckDsgnName = new OracleCommand();

            cmdCheckDsgnName.CommandText = strQueryCheckDsgnName;
            cmdCheckDsgnName.CommandType = CommandType.StoredProcedure;
            cmdCheckDsgnName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.DesignationId;
            cmdCheckDsgnName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objDsgn.DesignationName;
            cmdCheckDsgnName.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objDsgn.DsgnOrgId;
            cmdCheckDsgnName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDsgnName);
            string strReturn = cmdCheckDsgnName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDsgnName.Dispose();
            return strReturn;

        }
        //Method for updating Designation cancel details in gn_Designation master table.
        public void UpdateDsgnCancel(clsEntityLayerDesignation objEntDsgn)
        {

            using (OracleCommand cmdupdateDsgnCancel = new OracleCommand())
            {
                cmdupdateDsgnCancel.InitialLONGFetchSize = 1000;
                cmdupdateDsgnCancel.CommandText = "DESIGNATION_MASTER.SP_UPDATE_DSGNMASTR_CANCEL";
                cmdupdateDsgnCancel.CommandType = CommandType.StoredProcedure;
                cmdupdateDsgnCancel.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntDsgn.DesignationId;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELID", OracleDbType.Int32).Value = objEntDsgn.DesignationUserId;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELREASON", OracleDbType.Varchar2).Value = objEntDsgn.DesignationCancelReason;
                cmdupdateDsgnCancel.Parameters.Add("D_CANCELDATE", OracleDbType.Date).Value = objEntDsgn.DsgnDate;
                clsDataLayer.ExecuteNonQuery(cmdupdateDsgnCancel);
            }
        }

        //Methode of updating values to Designation and Desgnation Roles table.
        public void UpdateDesignationDetails(clsEntityLayerDesignation objEntityDsgn, List<clsEntityLayerDesignationRole> objlisDsgnRolDtls, List<clsEntityLayerDesignationAppRole> objlisDsgnAppRolDtls, List<clsEntityLayerDesignationLeaveType> objlistLeaveType)
        {
           
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "DESIGNATION_MASTER.SP_UPDT_DSG_MSTR";
                    using (OracleCommand cmdInsertDsgn = new OracleCommand())
                    {

                        cmdInsertDsgn.Transaction = tran;
                        cmdInsertDsgn.Connection = con;
                        cmdInsertDsgn.CommandText = strQueryInsertDsgn;
                        cmdInsertDsgn.CommandType = CommandType.StoredProcedure;
                        cmdInsertDsgn.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                        cmdInsertDsgn.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityDsgn.DesignationName;
                        cmdInsertDsgn.Parameters.Add("DTYP_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationTypeId;
                        cmdInsertDsgn.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityDsgn.DesignationStatus;
                        cmdInsertDsgn.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                        cmdInsertDsgn.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;
                        cmdInsertDsgn.Parameters.Add("D_PRIMARY", OracleDbType.Int32).Value = objEntityDsgn.DsgnPrimary;
                        cmdInsertDsgn.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityDsgn.DsgControl;
                        cmdInsertDsgn.Parameters.Add("D_TYPE", OracleDbType.Int32).Value = objEntityDsgn.Type;
                        cmdInsertDsgn.ExecuteNonQuery();

                    }
                    string strQueryInsertDsgnRole = "DESIGNATION_MASTER.SP_INS_DSGROLE_MSTR";
                    foreach (clsEntityLayerDesignationRole objDsgnRol in objlisDsgnRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgRole = new OracleCommand())
                        {
                            cmdInsertDsgRole.Transaction = tran;
                            cmdInsertDsgRole.Connection = con;
                            cmdInsertDsgRole.CommandText = strQueryInsertDsgnRole;
                            cmdInsertDsgRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDsgRole.Parameters.Add("D_USROL_ID", OracleDbType.Int32).Value = objDsgnRol.UsrRolId;
                            cmdInsertDsgRole.Parameters.Add("DSG_CHILDROLE", OracleDbType.Varchar2).Value = objDsgnRol.strChildRolId;
                            cmdInsertDsgRole.ExecuteNonQuery();
                        }
                    }
                    string strQueryInsertDsgnAppRole = "DESIGNATION_MASTER.SP_INS_DSGAPPROLE_MSTR";
                    foreach (clsEntityLayerDesignationAppRole objDsgnAppRol in objlisDsgnAppRolDtls)
                    {
                        using (OracleCommand cmdInsertDsgAppRole = new OracleCommand())
                        {
                            cmdInsertDsgAppRole.Transaction = tran;
                            cmdInsertDsgAppRole.Connection = con;
                            cmdInsertDsgAppRole.CommandText = strQueryInsertDsgnAppRole;
                            cmdInsertDsgAppRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDsgAppRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDsgAppRole.Parameters.Add("D_APP_ID", OracleDbType.Int32).Value = objDsgnAppRol.App_Id;

                            cmdInsertDsgAppRole.ExecuteNonQuery();
                        }
                    }
                    //Start 0009
                    //To add data to designation leave type table
                    string strQueryAddDesgLeaveType = "DESIGNATION_MASTER.SP_ADD_DESG_LEAVE_TYPE";
                    foreach (clsEntityLayerDesignationLeaveType objDsgn in objlistLeaveType)
                    {
                        using (OracleCommand cmdAddDesgLeaveType = new OracleCommand())
                        {
                            cmdAddDesgLeaveType.Transaction = tran;
                            cmdAddDesgLeaveType.Connection = con;
                            cmdAddDesgLeaveType.CommandText = strQueryAddDesgLeaveType;
                            cmdAddDesgLeaveType.CommandType = CommandType.StoredProcedure;
                            cmdAddDesgLeaveType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdAddDesgLeaveType.Parameters.Add("D_LEAVETYP_ID", OracleDbType.Int32).Value = objDsgn.Leave_Type_Id;
                            cmdAddDesgLeaveType.ExecuteNonQuery();
                        }
                    }
                    //if allocate all is checked for all designation leave type  
                    if (objEntityDsgn.AllocateAllUsr == 1)
                    {
                        // UPDATE USR  DESGN LEAVE TYPE 
                        //AND AGAIN INSERT TO IT BASED ON NEW VALUES
                        string strQueryUpdUserLeaveTypes = "DESIGNATION_MASTER.SP_UPD_USR_LEAVTYP_BY_DSGID";
                        using (OracleCommand cmdInsertDelUsrLeaveTypes = new OracleCommand())
                        {

                           cmdInsertDelUsrLeaveTypes .Transaction = tran;
                           cmdInsertDelUsrLeaveTypes .Connection = con;
                           cmdInsertDelUsrLeaveTypes.CommandText = strQueryUpdUserLeaveTypes;
                           cmdInsertDelUsrLeaveTypes .CommandType = CommandType.StoredProcedure;
                           cmdInsertDelUsrLeaveTypes .Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                           cmdInsertDelUsrLeaveTypes .Parameters.Add("D_COPRID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                           cmdInsertDelUsrLeaveTypes.Parameters.Add("D_CNCLDATE", OracleDbType.Date).Value = System.DateTime.Now;
                           cmdInsertDelUsrLeaveTypes .ExecuteNonQuery();

                        }
                        string strQueryInsUserLeaveTypes = "DESIGNATION_MASTER.SP_INS_USR_LEAVTYP_BY_DSGID";
                        using (OracleCommand cmdInsertDelUsrLeaveTypes = new OracleCommand())
                        {

                            cmdInsertDelUsrLeaveTypes.Transaction = tran;
                            cmdInsertDelUsrLeaveTypes.Connection = con;
                            cmdInsertDelUsrLeaveTypes.CommandText = strQueryInsUserLeaveTypes;
                            cmdInsertDelUsrLeaveTypes.CommandType = CommandType.StoredProcedure;
                            cmdInsertDelUsrLeaveTypes.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDelUsrLeaveTypes.Parameters.Add("D_COPRID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                            cmdInsertDelUsrLeaveTypes.ExecuteNonQuery();

                        }




                    }
                    //Stop 0009

                    //if allocate all is checked  only 
                    if (objEntityDsgn.AllocateAll == 1)
                    {
                        // DELETE USEROLE AND USRAPPROLE 
                        //AND AGAIN INSERT TO IT BASED ON NEW VALUES
                        string strQueryInsDelUserRoles = "DESIGNATION_MASTER.SP_DELINS_USER_ROLES_BY_DSGID";
                        using (OracleCommand cmdInsertDelUsrRole = new OracleCommand())
                        {

                            cmdInsertDelUsrRole.Transaction = tran;
                            cmdInsertDelUsrRole.Connection = con;
                            cmdInsertDelUsrRole.CommandText = strQueryInsDelUserRoles;
                            cmdInsertDelUsrRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDelUsrRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                            cmdInsertDelUsrRole.Parameters.Add("D_COPRID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;                        
                            cmdInsertDelUsrRole.ExecuteNonQuery();

                        }
                        // DELETE JOBRLROLE AND JOBRLAPPROLE 
                        //AND AGAIN INSERT TO IT BASED ON NEW VALUES
                        //EVM-0012
                        string strQueryInsDelJobRlRoles = "DESIGNATION_MASTER.SP_DELINS_JOBRL_ROLES_BY_DSGID";
                        using (OracleCommand cmdInsertDelUsrRole = new OracleCommand())
                        {

                            cmdInsertDelUsrRole.Transaction = tran;
                            cmdInsertDelUsrRole.Connection = con;
                            cmdInsertDelUsrRole.CommandText = strQueryInsDelJobRlRoles;
                            cmdInsertDelUsrRole.CommandType = CommandType.StoredProcedure;
                            cmdInsertDelUsrRole.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
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
        // This Method displays USROL MASTR details from the database for showing in TREE
        public DataTable DisplayUserolMstr(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_READ_USR_ROLE_MSTR";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityDsgn.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityDsgn.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityDsgn.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityDsgn.UserLimited;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        public DataTable DisplayUserolMstrFramewrk(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_READ_USR_ROLE_MSTR_FRAMEWRK";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strCommandText;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objEntityDsgn.AppId;
                cmdGrid.Parameters.Add("PARENTID", OracleDbType.Int32).Value = objEntityDsgn.ParentId;
                cmdGrid.Parameters.Add("M_APPTYPE", OracleDbType.Char).Value = objEntityDsgn.AppType;
                cmdGrid.Parameters.Add("M_CNTRLTYPE", OracleDbType.Char).Value = objEntityDsgn.DsgControl;
                cmdGrid.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                cmdGrid.Parameters.Add("D_LMTD_USR", OracleDbType.Int32).Value = objEntityDsgn.UserLimited;
                cmdGrid.Parameters.Add("D_FRAMEWRK_ID", OracleDbType.Int32).Value = objEntityDsgn.CorpOfficeId;
                cmdGrid.Parameters.Add("P_USR_ROLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        // This Method for fetching the Compzit Modules by user id.Fetching modules only which is allowed for user.
        public DataTable DisplayCompzitModuleByUsrId(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_CMPZIT_MODULE_BYUSRID";
            using (OracleCommand cmdCmpztModule = new OracleCommand())
            {
                cmdCmpztModule.CommandText = strCommandText;
                cmdCmpztModule.CommandType = CommandType.StoredProcedure;
                cmdCmpztModule.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                cmdCmpztModule.Parameters.Add("D_PRIMARY_ID", OracleDbType.Int32).Value = objEntityDsgn.DsgnPrimary;
                cmdCmpztModule.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispCmpztModule = new DataTable();
                dtDispCmpztModule = clsDataLayer.SelectDataTable(cmdCmpztModule);
                return dtDispCmpztModule;
            }
        }
        // This Method for   IF User is LIMITED OR NOT.
        public DataTable ReadIfUserLimitedByUsrId(clsEntityLayerDesignation objEntityDsgn)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_USR_IFLIMITED_BYUSRID";
            using (OracleCommand cmdUserDtl = new OracleCommand())
            {
                cmdUserDtl.CommandText = strCommandText;
                cmdUserDtl.CommandType = CommandType.StoredProcedure;
                cmdUserDtl.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationUserId;
                cmdUserDtl.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispUserDtl = new DataTable();
                dtDispUserDtl = clsDataLayer.SelectDataTable(cmdUserDtl);
                return dtDispUserDtl;
            }
        }
        //Read Desgnation APP Roles master table according to their Dsgn Id(Primary Key)
        public DataTable ReadDsgnAppRoleByDsgnId(clsEntityLayerDesignation objEntityDsgn)
        {
            using (OracleCommand cmdReadDsgnApp = new OracleCommand())
            {
                cmdReadDsgnApp.CommandText = "DESIGNATION_MASTER.SP_READ_DSGN_APPROLE_BY_DSGNID";
                cmdReadDsgnApp.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnApp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                cmdReadDsgnApp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnAppMasterEdit = new DataTable();
                dtDsgnAppMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnApp);
                return dtDsgnAppMasterEdit;
            }
        }
       //Started:-EVM-0009
        //Fetch   the leave types from leave type master table and displayed to the checkboxlist.
        public DataTable DisplayLeaveType(clsEntityLayerDesignation objEntityDsgnLeaveType)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_LEAVE_TYPE";
            using (OracleCommand cmdLeaveType = new OracleCommand())
            {
                cmdLeaveType.CommandText = strCommandText;
                cmdLeaveType.CommandType = CommandType.StoredProcedure;
                cmdLeaveType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgnLeaveType.DesignationId;
                cmdLeaveType.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDsgnLeaveType.CorpOfficeId;
                cmdLeaveType.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDsgnLeaveType.DsgnOrgId;
                cmdLeaveType.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispLeaveType = new DataTable();
                dtDispLeaveType = clsDataLayer.SelectDataTable(cmdLeaveType);
                return dtDispLeaveType;
            }
        }

        // This Method for fetching the leave type by designation id.Fetching modules only which is allowed for user.
        public DataTable ReadDsgnLeaveTypeByDsgnId(clsEntityLayerDesignationLeaveType objEntityDsgnLeaveType)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_LEAVE_TYPE_BYUSRID";
            using (OracleCommand cmdLeaveType = new OracleCommand())
            {
                cmdLeaveType.CommandText = strCommandText;
                cmdLeaveType.CommandType = CommandType.StoredProcedure;
                cmdLeaveType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgnLeaveType.Dsgn_Id;
                cmdLeaveType.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispLeaveType = new DataTable();
                dtDispLeaveType = clsDataLayer.SelectDataTable(cmdLeaveType);
                return dtDispLeaveType;
            }
        }
        // This Method for fetching the leave type by designation id.Fetching modules only which is allowed for user.
        public DataTable ReadDsgnLeaveTypeEnableByDsgnId(clsEntityLayerDesignationLeaveType objEntityDsgnLeaveType)
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_LEAVE_TYPE_ENABLE_BYID";
            using (OracleCommand cmdLeaveType = new OracleCommand())
            {
                cmdLeaveType.CommandText = strCommandText;
                cmdLeaveType.CommandType = CommandType.StoredProcedure;
                cmdLeaveType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgnLeaveType.Dsgn_Id;
                cmdLeaveType.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispLeaveType = new DataTable();
                dtDispLeaveType = clsDataLayer.SelectDataTable(cmdLeaveType);
                return dtDispLeaveType;
            }
        }


        public DataTable ReadDsgnWelfare(clsEntityLayerDesignationWelfareSrvc objEntityDsgnwelfaresrc)   //EMP0025
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_WELFARE";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgnwelfaresrc.Dsg_Id;
                cmdwelfare.Parameters.Add("DSUB_ID", OracleDbType.Varchar2).Value = objEntityDsgnwelfaresrc.WelfSub_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }
        public DataTable ReadDsgnWelfareSrvc(clsEntityLayerDesignation objEntityDsgnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "DESIGNATION_MASTER.SP_READ_WELFARE_SERVICES";
            using (OracleCommand cmdWelfareSrvc = new OracleCommand())
            {
                cmdWelfareSrvc.CommandText = strCommandText;
                cmdWelfareSrvc.CommandType = CommandType.StoredProcedure;
                cmdWelfareSrvc.Parameters.Add("D_DESGID", OracleDbType.Int32).Value = objEntityDsgnWelfareSrvc.DesignationId;
                cmdWelfareSrvc.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtWelfareScvc = new DataTable();
                dtWelfareScvc = clsDataLayer.SelectDataTable(cmdWelfareSrvc);
                return dtWelfareScvc;
            }
        }
        public DataTable ReadDsgnWelfareById(clsEntityLayerDesignationWelfareSrvc objEntityDesgnWelfareSrvc)   //EMP0025
        {
            string strCommandText = "DESIGNATION_MASTER.SP_RD_WELFARE_BYID";
            using (OracleCommand cmdwelfare = new OracleCommand())
            {
                cmdwelfare.CommandText = strCommandText;
                cmdwelfare.CommandType = CommandType.StoredProcedure;
                cmdwelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDesgnWelfareSrvc.Welfare_Id;
                cmdwelfare.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDispwelfare = new DataTable();
                dtDispwelfare = clsDataLayer.SelectDataTable(cmdwelfare);
                return dtDispwelfare;
            }
        }


        public void Insert_DesgWelfare(List<clsEntityLayerDesignationWelfareSrvc> objListDesgWelfare, clsEntityLayerDesignationWelfareSrvc objEntityDsgn)
        {
        
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                  
                    foreach (clsEntityLayerDesignationWelfareSrvc objDsgn in objListDesgWelfare)
                    {
                        int chkSts = objDsgn.chkSts;
                        int checkboxStatus = objDsgn.checkboxsts;

                        if (checkboxStatus == 1)
                        {
                            if (chkSts == 0)
                            {
                                string strQueryAddDesgWelfareSrvc = "DESIGNATION_MASTER.SP_ADD_DESG_WELFARE";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dsg_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.Qty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string strQueryAddDesgWelfareSrvc = "DESIGNATION_MASTER.SP_UPDATE_DESG_WELFAREQTY";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dsg_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.Qty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            if (chkSts == 0)
                            {

                                string strQueryAddDesgWelfareSrvc = "DESIGNATION_MASTER.SP_ADD_DESG_WELFARECNCL ";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dsg_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_QNTY", OracleDbType.Decimal).Value = objDsgn.ActQty;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }


                            }
                            else
                            {
                                string strQueryAddDesgWelfareSrvc = "DESIGNATION_MASTER.SP_UPDATE_DESG_WELFARECNCLDATE";
                                using (OracleCommand cmdAddDesgWelfare = new OracleCommand())
                                {
                                    cmdAddDesgWelfare.Transaction = tran;
                                    cmdAddDesgWelfare.Connection = con;
                                    cmdAddDesgWelfare.CommandText = strQueryAddDesgWelfareSrvc;
                                    cmdAddDesgWelfare.CommandType = CommandType.StoredProcedure;
                                    cmdAddDesgWelfare.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDsgn.Dsg_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARE_ID", OracleDbType.Int32).Value = objEntityDsgn.Welfare_Id;
                                    cmdAddDesgWelfare.Parameters.Add("D_WELFARESUB_ID", OracleDbType.Decimal).Value = objDsgn.WelfrSub_Id;
                                    cmdAddDesgWelfare.ExecuteNonQuery();
                                }
                            } 
                        }
                       
                    }
                    tran.Commit();
                    //return objEntityCorpdept.intDep_Id;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }

        }

        //Stopped
        public DataTable ReadDesignmasById(clsEntityLayerDesignation objEntityDsgn)
        {
            string strQueryRecallDsgn = "DESIGNATION_MASTER.SP_READ_DSGN_BYID";
            using (OracleCommand cmdRecall = new OracleCommand())
            {
                cmdRecall.CommandText = strQueryRecallDsgn;
                cmdRecall.CommandType = CommandType.StoredProcedure;
                cmdRecall.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDsgn.DesignationId;
                cmdRecall.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDsgn.DsgnOrgId;

                cmdRecall.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtAcco = new DataTable();
                dtAcco = clsDataLayer.SelectDataTable(cmdRecall);
                return dtAcco;
            }
        }
       
    }
}
