using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit;
using System.Data;

namespace DL_Compzit
{
    public class clsDataLayerHelpDoc
    {

        public DataTable ReadUserRollByURL(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_USERROL_BYURL";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.PageURL;
                cmdHelpDoc.Parameters.Add("H_FULL_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.FullPageURL;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadMainUserRolsByAppId(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_MAIN_USERROL_BYAPPID";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_APP_ID", OracleDbType.Int32).Value = objEntityHelpDoc.AppId;
                cmdHelpDoc.Parameters.Add("H_SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityHelpDoc.SearchString;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadUserRolsByUserRolId(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_USERROL_BYID";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_PARENT_ID", OracleDbType.Int32).Value = objEntityHelpDoc.UserRolId;
                cmdHelpDoc.Parameters.Add("H_SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityHelpDoc.SearchString;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public void SaveHelpDoc(clsEntityHelpDoc objEntityHelpDoc)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strSectionId = "";

                    if (objEntityHelpDoc.ActionMode == "btnSaveSub"|| objEntityHelpDoc.ActionMode == "btnSaveControl")
                    {
                        strSectionId =Convert.ToString(objEntityHelpDoc.SectionId);
                    }
                    if (objEntityHelpDoc.ActionMode == "btnSaveMain")
                    {
                    //1
                    string strQueryInsertAtcmntDtls = "HELP_DOC.SP_INS_DOC_MASTER";
                    OracleCommand cmdInsertAtcmntDtls = new OracleCommand();
                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    if (objEntityHelpDoc.ParentSectionId == 0)
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_PARENT_SECTION_ID", OracleDbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_PARENT_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.ParentSectionId;
                    }
                    if (objEntityHelpDoc.UserRolId != 0)
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_USROL_ID", OracleDbType.Int32).Value = objEntityHelpDoc.UserRolId;
                    }
                    else
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_USROL_ID", OracleDbType.Int32).Value =DBNull.Value;
                    }


                    cmdInsertAtcmntDtls.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHelpDoc.Status;
                    cmdInsertAtcmntDtls.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = objEntityHelpDoc.Priority;

                    cmdInsertAtcmntDtls.Parameters.Add("H_USR_ID", OracleDbType.Int32).Value = objEntityHelpDoc.UserId;
                    cmdInsertAtcmntDtls.Parameters.Add("H_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    clsDataLayer.ExecuteScalar(ref cmdInsertAtcmntDtls);
                    strSectionId = cmdInsertAtcmntDtls.Parameters["H_OUT"].Value.ToString();


                    //2
                    string strQueryInsertAtcmntDtls1 = "HELP_DOC.SP_INS_DOC_MASTER_REF";
                    using (OracleCommand cmdInsertAtcmntDtls1 = new OracleCommand())
                    {
                        cmdInsertAtcmntDtls1.CommandText = strQueryInsertAtcmntDtls1;
                        cmdInsertAtcmntDtls1.CommandType = CommandType.StoredProcedure;
                        cmdInsertAtcmntDtls1.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = Convert.ToInt32(strSectionId);
                        cmdInsertAtcmntDtls1.Parameters.Add("H_SECTIO_NAME", OracleDbType.NVarchar2).Value = objEntityHelpDoc.SectionName;
                        clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls1);
                    }
                    
                    }

                    //3
                    string strQueryInsertAtcmntDtls2 = "HELP_DOC.SP_INS_DOC_DTLS";
                    OracleCommand cmdInsertAtcmntDtls2 = new OracleCommand();
                    cmdInsertAtcmntDtls2.CommandText = strQueryInsertAtcmntDtls2;
                    cmdInsertAtcmntDtls2.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls2.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = Convert.ToInt32(strSectionId);
                    cmdInsertAtcmntDtls2.Parameters.Add("H_DTLS_TYPE", OracleDbType.Int32).Value = objEntityHelpDoc.HelpDocType;
                    if (objEntityHelpDoc.ActionMode == "btnSaveControl")
                    {
                        cmdInsertAtcmntDtls2.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = objEntityHelpDoc.ControlId;
                    }
                    else
                    {
                        cmdInsertAtcmntDtls2.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = DBNull.Value;
                    }

                    if (objEntityHelpDoc.ActionMode == "btnSaveSub" || objEntityHelpDoc.ActionMode == "btnSaveControl")
                    {
                        cmdInsertAtcmntDtls2.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = objEntityHelpDoc.Priority;
                    }
                    else
                    {
                        cmdInsertAtcmntDtls2.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = DBNull.Value;
                    }

                    cmdInsertAtcmntDtls2.Parameters.Add("H_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    clsDataLayer.ExecuteScalar(ref cmdInsertAtcmntDtls2);
                    string strDtlId = cmdInsertAtcmntDtls2.Parameters["H_OUT"].Value.ToString();

                    //4
                    string strQueryInsertAtcmntDtls3 = "HELP_DOC.SP_INS_DOC_DTLS_REF";
                    using (OracleCommand cmdInsertAtcmntDtls3 = new OracleCommand())
                    {
                        cmdInsertAtcmntDtls3.CommandText = strQueryInsertAtcmntDtls3;
                        cmdInsertAtcmntDtls3.CommandType = CommandType.StoredProcedure;
                        cmdInsertAtcmntDtls3.Parameters.Add("H_DTLS_ID", OracleDbType.Int32).Value = Convert.ToInt32(strDtlId);
                        cmdInsertAtcmntDtls3.Parameters.Add("H_TITLE", OracleDbType.NVarchar2).Value = objEntityHelpDoc.Title;
                        cmdInsertAtcmntDtls3.Parameters.Add("H_DESCRIPTION", OracleDbType.Clob).Value = objEntityHelpDoc.Description;
                        clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls3);
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

        public void UpdateHelpDoc(clsEntityHelpDoc objEntityHelpDoc)
        {
           OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
            con.Open();
            tran = con.BeginTransaction();
            try
            {

            if (objEntityHelpDoc.ActionMode == "btnUpdateMain")
            {
                //1
                string strQueryInsertAtcmntDtls = "HELP_DOC.SP_UPD_DOC_MASTER";

                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand())
                {
                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;

                    cmdInsertAtcmntDtls.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;

                    if (objEntityHelpDoc.ParentSectionId == 0)
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_PARENT_SECTION_ID", OracleDbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        cmdInsertAtcmntDtls.Parameters.Add("H_PARENT_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.ParentSectionId;
                    }

                    cmdInsertAtcmntDtls.Parameters.Add("H_USROL_ID", OracleDbType.Int32).Value = objEntityHelpDoc.UserRolId;
                    cmdInsertAtcmntDtls.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHelpDoc.Status;
                    cmdInsertAtcmntDtls.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = objEntityHelpDoc.Priority;
                    cmdInsertAtcmntDtls.Parameters.Add("H_USR_ID", OracleDbType.Int32).Value = objEntityHelpDoc.UserId;

                    clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
                }


                //2
                string strQueryInsertAtcmntDtls1 = "HELP_DOC.SP_UPD_DOC_MASTER_REF";
                using (OracleCommand cmdInsertAtcmntDtls1 = new OracleCommand())
                {
                    cmdInsertAtcmntDtls1.CommandText = strQueryInsertAtcmntDtls1;
                    cmdInsertAtcmntDtls1.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls1.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;
                    cmdInsertAtcmntDtls1.Parameters.Add("H_SECTIO_NAME", OracleDbType.NVarchar2).Value = objEntityHelpDoc.SectionName;
                    clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls1);
                }
            }

            //3
            string strQueryInsertAtcmntDtls2 = "HELP_DOC.SP_UPD_DOC_DTLS";
            using (OracleCommand cmdInsertAtcmntDtls2 = new OracleCommand())
            {
                cmdInsertAtcmntDtls2.CommandText = strQueryInsertAtcmntDtls2;
                cmdInsertAtcmntDtls2.CommandType = CommandType.StoredProcedure;
                cmdInsertAtcmntDtls2.Parameters.Add("H_DTLS_ID", OracleDbType.Int32).Value = objEntityHelpDoc.HelpDocDtlsId;
                cmdInsertAtcmntDtls2.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;
                cmdInsertAtcmntDtls2.Parameters.Add("H_DTLS_TYPE", OracleDbType.Int32).Value = objEntityHelpDoc.HelpDocType;
                if (objEntityHelpDoc.ActionMode == "btnUpdateControl")
                {
                    cmdInsertAtcmntDtls2.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = objEntityHelpDoc.ControlId;
                }
                else
                {
                    cmdInsertAtcmntDtls2.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = DBNull.Value;
                }

                if (objEntityHelpDoc.ActionMode == "btnUpdateSub" || objEntityHelpDoc.ActionMode == "btnUpdateControl")
                {
                    cmdInsertAtcmntDtls2.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = objEntityHelpDoc.Priority;
                }
                else
                {
                    cmdInsertAtcmntDtls2.Parameters.Add("H_PRIORITY", OracleDbType.Int32).Value = DBNull.Value;
                }

                clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls2);

            }

            //4
            string strQueryInsertAtcmntDtls3 = "HELP_DOC.SP_UPD_DOC_DTLS_REF";
            using (OracleCommand cmdInsertAtcmntDtls3 = new OracleCommand())
            {
                cmdInsertAtcmntDtls3.CommandText = strQueryInsertAtcmntDtls3;
                cmdInsertAtcmntDtls3.CommandType = CommandType.StoredProcedure;
                cmdInsertAtcmntDtls3.Parameters.Add("H_DTLS_ID", OracleDbType.Int32).Value = objEntityHelpDoc.HelpDocDtlsId;
                cmdInsertAtcmntDtls3.Parameters.Add("H_TITLE", OracleDbType.NVarchar2).Value = objEntityHelpDoc.Title;
                cmdInsertAtcmntDtls3.Parameters.Add("H_DESCRIPTION", OracleDbType.Clob).Value = objEntityHelpDoc.Description;
                clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls3);
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

        public DataTable ReadSectionsByURL(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_SECTIONS_BYURL";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.PageURL;
                cmdHelpDoc.Parameters.Add("H_FULL_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.FullPageURL;
                cmdHelpDoc.Parameters.Add("H_SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityHelpDoc.SearchString;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadEditView(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_EDIT_VIEW";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.PageURL;
                cmdHelpDoc.Parameters.Add("H_FULL_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.FullPageURL;
                cmdHelpDoc.Parameters.Add("H_DTLS_TYPE", OracleDbType.Int32).Value = objEntityHelpDoc.HelpDocType;
                cmdHelpDoc.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = objEntityHelpDoc.ControlId;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }


        public DataTable ReadCurrentPageControls(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_CURR_PAGE_CTRLS";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.PageURL;
                cmdHelpDoc.Parameters.Add("H_FULL_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.FullPageURL;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadControlsDescription(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_CNTRL_DESCRPTN";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;
                cmdHelpDoc.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = objEntityHelpDoc.ControlId;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }




                /*HelpDoc-View*/


        public DataTable ReadHelpCenterSections(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_HELP_CENTER_SECTIONS";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_APP_ID", OracleDbType.Int32).Value = objEntityHelpDoc.AppId;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadHelpCenterDetails(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_HELP_CENTER_DETAILS";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;

                if (objEntityHelpDoc.ControlId != "")
                {
                    cmdHelpDoc.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = objEntityHelpDoc.ControlId;
                }
                else
                {
                    cmdHelpDoc.Parameters.Add("H_CONTROL_ID", OracleDbType.Varchar2).Value = DBNull.Value;
                }

                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }












        public DataTable ReadHelpCenterDetailsById(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_HELP_CENTER_DTLS_BYID";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_SECTION_ID", OracleDbType.Int32).Value = objEntityHelpDoc.SectionId;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadHelpCenterSearch(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_SEARCH_BYTITLE";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_SEARCH_TXT", OracleDbType.Int32).Value = objEntityHelpDoc.SearchString;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

        public DataTable ReadAppIdUserRolId(clsEntityHelpDoc objEntityHelpDoc)
        {
            string strQuery = "HELP_DOC.SP_READ_APPID_USROL_ID";
            using (OracleCommand cmdHelpDoc = new OracleCommand())
            {
                cmdHelpDoc.CommandText = strQuery;
                cmdHelpDoc.CommandType = CommandType.StoredProcedure;
                cmdHelpDoc.Parameters.Add("H_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.PageURL;
                cmdHelpDoc.Parameters.Add("H_FULL_URL", OracleDbType.Varchar2).Value = objEntityHelpDoc.FullPageURL;
                cmdHelpDoc.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdHelpDoc);
                return dt;
            }
        }

    }
}
