using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Configuration;
using HashingUtility;
using CL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:26/10/2015
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit
{
 public class clsDataLayerChangePassword
    {  // This Method checks User's current password if it is correct or not in the database 
        public string CheckCurrentPasswd(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            string strQueryCheckPwd = "CHANGE_PSWD.SP_CHECK_CURRENT_PSWD";
            OracleCommand cmdCheckUsrPwd = new OracleCommand();

            cmdCheckUsrPwd.CommandText = strQueryCheckPwd;
            cmdCheckUsrPwd.CommandType = CommandType.StoredProcedure;
            cmdCheckUsrPwd.Parameters.Add("LOG_USRID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
            cmdCheckUsrPwd.Parameters.Add("LOG_CURRENT_PWD", OracleDbType.Varchar2).Value = objEntityUsrReg.UserOldPsw;
            cmdCheckUsrPwd.Parameters.Add("LOG_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
            cmdCheckUsrPwd.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckUsrPwd);
            string strReturn = cmdCheckUsrPwd.Parameters["L_COUNT"].Value.ToString();
            cmdCheckUsrPwd.Dispose();
            return strReturn;

        }
     //EVM-0016
        // This Method Updates the PASSWORD OF THE USER in the database
        public void UpdatePassword(clsEntityLayerUserRegistration objEntityUsrReg)
        {

            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {


                    string strCommandText = "CHANGE_PSWD.SP_UPDATE_PSWD";
                    using (OracleCommand cmdUpdatePwd = new OracleCommand(strCommandText,con))
                    {
                       cmdUpdatePwd.CommandType = CommandType.StoredProcedure;
                        cmdUpdatePwd.Parameters.Add("C_PWD", OracleDbType.Varchar2).Value = objEntityUsrReg.UserPsw;
                        cmdUpdatePwd.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                        cmdUpdatePwd.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityUsrReg.UserOrgId;
                        cmdUpdatePwd.ExecuteNonQuery();
                    }

                    string strQueryAddChngPaswd = "CHANGE_PSWD.SP_INSERT_TRACK_CHANGE_PWD";
                    using (OracleCommand cmdAddChangePaswd = new OracleCommand(strQueryAddChngPaswd,con))
                    {
                         cmdAddChangePaswd.CommandType = CommandType.StoredProcedure;
                        cmdAddChangePaswd.Parameters.Add("C_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                        cmdAddChangePaswd.Parameters.Add("C_OLD_USR_PWD", OracleDbType.Varchar2).Value = objEntityUsrReg.UserOldPsw;
                        cmdAddChangePaswd.Parameters.Add("C_NEW_USR_PWD", OracleDbType.Varchar2).Value = objEntityUsrReg.UserPsw;
                        cmdAddChangePaswd.Parameters.Add("C_PWD_TRCK_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                        cmdAddChangePaswd.Parameters.Add("C_PWD_TRCK_DATE", OracleDbType.Date).Value = objEntityUsrReg.UserDate;

                        cmdAddChangePaswd.ExecuteNonQuery();

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
        // This method is for fetch the email id,username,login name of user from the database
        //0006
        public DataTable ReadMailId(clsEntityLayerUserRegistration objEntityUsrReg)
        {

            string strCommandText = "CHANGE_PSWD.SP_MAIL_NOTIFICATION";
            using (OracleCommand cmdReadMailId = new OracleCommand())
            {
                cmdReadMailId.CommandText = strCommandText;
                cmdReadMailId.CommandType = CommandType.StoredProcedure;
                cmdReadMailId.Parameters.Add("C_USR_ID", OracleDbType.Int32).Value = objEntityUsrReg.UserId;
                cmdReadMailId.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadMailId = new DataTable();
                dtReadMailId = clsDataLayer.ExecuteReader(cmdReadMailId);
                return dtReadMailId;
            }

        }
    }
}
