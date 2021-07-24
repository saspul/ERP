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
   public class clsDataLayerResetPassword
    {


        //Read user under the corporate and  organisation who are above designtion 2 and not canceled and active
        public DataTable ReadCorporateUsers(clsEntityResetPassword objEntityResetPwd)
        {
            using (OracleCommand cmdReadCrprtUser = new OracleCommand())
            {
                cmdReadCrprtUser.CommandText = "RESET_PSWD.SP_READ_USERS";
                cmdReadCrprtUser.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtUser.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityResetPwd.CorpOfficeId;
                cmdReadCrprtUser.Parameters.Add("R_ORG_ID", OracleDbType.Int32).Value = objEntityResetPwd.OrgId;
                cmdReadCrprtUser.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityResetPwd.CommonSearchTerm;
                cmdReadCrprtUser.Parameters.Add("M_SEARCH_EMPLOYEE", OracleDbType.Varchar2).Value = objEntityResetPwd.SearchEmployee;
                cmdReadCrprtUser.Parameters.Add("M_SEARCH_MAIL", OracleDbType.Varchar2).Value = objEntityResetPwd.SearchMail;
                cmdReadCrprtUser.Parameters.Add("M_SEARCH_DEPARTMENT", OracleDbType.Varchar2).Value = objEntityResetPwd.SearchDepartment;
                cmdReadCrprtUser.Parameters.Add("M_SEARCH_DESIGNATION", OracleDbType.Varchar2).Value = objEntityResetPwd.SearchDesignation;
                cmdReadCrprtUser.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityResetPwd.OrderColumn;
                cmdReadCrprtUser.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityResetPwd.OrderMethod;
                cmdReadCrprtUser.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityResetPwd.PageMaxSize;
                cmdReadCrprtUser.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityResetPwd.PageNumber;
                cmdReadCrprtUser.Parameters.Add("R_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUser = new DataTable();
                dtUser = clsDataLayer.ExecuteReader(cmdReadCrprtUser);
                return dtUser;
            }
        }
       //EVM-0016
        // This Method Updates the PASSWORD OF THE USER in the database  and insert  a row to tracking table
        public void UpdatePassword(clsEntityResetPassword objEntityResetPwd)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    string strCommandText = "RESET_PSWD.SP_UPDATE_PSWD";
                    using (OracleCommand cmdUpdatePwd = new OracleCommand(strCommandText,con))
                    {
                        cmdUpdatePwd.Transaction = tran;
                        cmdUpdatePwd.CommandType = CommandType.StoredProcedure;
                        cmdUpdatePwd.Parameters.Add("R_PWD", OracleDbType.Varchar2).Value = objEntityResetPwd.UserPsw;
                        cmdUpdatePwd.Parameters.Add("R_USRID", OracleDbType.Int32).Value = objEntityResetPwd.UserId;
                        cmdUpdatePwd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityResetPwd.OrgId;
                        cmdUpdatePwd.Parameters.Add("R_CORPRT_ID", OracleDbType.Int32).Value = objEntityResetPwd.CorpOfficeId;
                        cmdUpdatePwd.ExecuteNonQuery();
                    }

                    string strQueryAddResetPaswd = "RESET_PSWD.SP_INSERT_TRACK_RESET_PSWD";
                    using (OracleCommand cmdAddResetPaswd = new OracleCommand(strQueryAddResetPaswd,con))
                    {
                        cmdAddResetPaswd.Transaction = tran;
                        cmdAddResetPaswd.CommandType = CommandType.StoredProcedure;
                        cmdAddResetPaswd.Parameters.Add("R_USR_ID", OracleDbType.Int32).Value = objEntityResetPwd.UserId;
                        cmdAddResetPaswd.Parameters.Add("R_OLD_USR_PWD", OracleDbType.Varchar2).Value = objEntityResetPwd.UserOldPsw;
                        cmdAddResetPaswd.Parameters.Add("R_NEW_USR_PWD", OracleDbType.Varchar2).Value = objEntityResetPwd.UserPsw;
                        cmdAddResetPaswd.Parameters.Add("R_PWD_TRCK_USR_ID", OracleDbType.Int32).Value = objEntityResetPwd.PaswdTrackUsrId;
                        cmdAddResetPaswd.Parameters.Add("R_PWD_TRCK_DATE", OracleDbType.Date).Value = objEntityResetPwd.Date;

                        cmdAddResetPaswd.ExecuteNonQuery();

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
        //EVM-0016
        public DataTable ReadEmployeeAndMail(clsEntityResetPassword objEntityResetPwd)
        {
            using (OracleCommand cmdReadCrprtUser = new OracleCommand())
            {
                cmdReadCrprtUser.CommandText = "RESET_PSWD.SP_READ_USR_NM_MAIL";
                cmdReadCrprtUser.CommandType = CommandType.StoredProcedure;
                cmdReadCrprtUser.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityResetPwd.UserId;
                cmdReadCrprtUser.Parameters.Add("R_out", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUser = new DataTable();
                dtUser = clsDataLayer.ExecuteReader(cmdReadCrprtUser);
                return dtUser;
            }
        }

    }
}
