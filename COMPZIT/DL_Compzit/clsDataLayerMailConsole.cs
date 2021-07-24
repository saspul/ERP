using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:08/04/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerMailConsole
    {


        // This Method fetch mail protocols from database
        public DataTable ReadMailProtocol()
        {
            string strCommandText = "MAIL_CONSOLE_CONFIG.SP_READ_MAIL_PROTOCOL";
            using (OracleCommand cmdReadProtocol = new OracleCommand())
            {
                cmdReadProtocol.CommandText = strCommandText;
                cmdReadProtocol.CommandType = CommandType.StoredProcedure;
                cmdReadProtocol.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtProtocol = new DataTable();
                dtProtocol = clsDataLayer.SelectDataTable(cmdReadProtocol);
                return dtProtocol;
            }
        }

        //insert mail console details to the datatbase
        public void AddMailConsole(clsEntityMailConsole objEntityMailConsole)
        {

            string strQueryAddMailConsole = "MAIL_CONSOLE_CONFIG.SP_INSERT_MAIL_CONFIG";
            using (OracleCommand cmdAddMail = new OracleCommand())
            {

                cmdAddMail.CommandText = strQueryAddMailConsole;
                cmdAddMail.CommandType = CommandType.StoredProcedure;
                cmdAddMail.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objEntityMailConsole.Email_Address;
                cmdAddMail.Parameters.Add("M_PASSWORD", OracleDbType.Varchar2).Value = objEntityMailConsole.Password;
                cmdAddMail.Parameters.Add("M_PROTOID", OracleDbType.Int64).Value = objEntityMailConsole.Protocol_Id;
                cmdAddMail.Parameters.Add("M_INSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.In_Service_Name;
                cmdAddMail.Parameters.Add("M_INPORT", OracleDbType.Int64).Value = objEntityMailConsole.In_Port_Number;
                cmdAddMail.Parameters.Add("M_OUTSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.Out_Service_Name;
                cmdAddMail.Parameters.Add("M_OUTPORT", OracleDbType.Int64).Value = objEntityMailConsole.Out_Port_Number;
                cmdAddMail.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMailConsole.Organisation_Id;
                cmdAddMail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
                cmdAddMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMailConsole.User_Id;
                cmdAddMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMailConsole.D_Date;
                cmdAddMail.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityMailConsole.Console_Status;
                cmdAddMail.Parameters.Add("M_SSL", OracleDbType.Int32).Value = objEntityMailConsole.SSL_Status;
                cmdAddMail.Parameters.Add("M_SIGNATURE", OracleDbType.Varchar2).Value = objEntityMailConsole.Signature;
                
                clsDataLayer.ExecuteNonQuery(cmdAddMail);
            }
        }

        //update mail console details to the datatbase based on mail id
        public void UpdateMailConsole(clsEntityMailConsole objEntityMailConsole)
        {

            string strQueryAddMailConsole = "MAIL_CONSOLE_CONFIG.SP_UPDATE_MAIL_CONFIG";
            using (OracleCommand cmdUpdateMail = new OracleCommand())
            {

                cmdUpdateMail.CommandText = strQueryAddMailConsole;
                cmdUpdateMail.CommandType = CommandType.StoredProcedure;
                cmdUpdateMail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
                cmdUpdateMail.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objEntityMailConsole.Email_Address;
                cmdUpdateMail.Parameters.Add("M_PASSWORD", OracleDbType.Varchar2).Value = objEntityMailConsole.Password;
                cmdUpdateMail.Parameters.Add("M_PROTOID", OracleDbType.Int64).Value = objEntityMailConsole.Protocol_Id;
                cmdUpdateMail.Parameters.Add("M_INSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.In_Service_Name;
                cmdUpdateMail.Parameters.Add("M_INPORT", OracleDbType.Int64).Value = objEntityMailConsole.In_Port_Number;
                cmdUpdateMail.Parameters.Add("M_OUTSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.Out_Service_Name;
                cmdUpdateMail.Parameters.Add("M_OUTPORT", OracleDbType.Int64).Value = objEntityMailConsole.Out_Port_Number;
                cmdUpdateMail.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMailConsole.Organisation_Id;
                cmdUpdateMail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
                cmdUpdateMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMailConsole.User_Id;
                cmdUpdateMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMailConsole.D_Date;
                cmdUpdateMail.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityMailConsole.Console_Status;
                cmdUpdateMail.Parameters.Add("M_SSL", OracleDbType.Int32).Value = objEntityMailConsole.SSL_Status;
                cmdUpdateMail.Parameters.Add("M_SIGNATURE", OracleDbType.Varchar2).Value = objEntityMailConsole.Signature;

                clsDataLayer.ExecuteNonQuery(cmdUpdateMail);
            }
        }


        //update mail console details to the datatbase based on mail id without password updation
        public void UpdateMailConsoleWithOut(clsEntityMailConsole objEntityMailConsole)
        {

            string strQueryAddMailConsole = "MAIL_CONSOLE_CONFIG.SP_UPDATE_MAIL_CONFIG_WTHOUT";
            using (OracleCommand cmdUpdateMail = new OracleCommand())
            {

                cmdUpdateMail.CommandText = strQueryAddMailConsole;
                cmdUpdateMail.CommandType = CommandType.StoredProcedure;
                cmdUpdateMail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
                cmdUpdateMail.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objEntityMailConsole.Email_Address;
                cmdUpdateMail.Parameters.Add("M_PROTOID", OracleDbType.Int64).Value = objEntityMailConsole.Protocol_Id;
                cmdUpdateMail.Parameters.Add("M_INSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.In_Service_Name;
                cmdUpdateMail.Parameters.Add("M_INPORT", OracleDbType.Int64).Value = objEntityMailConsole.In_Port_Number;
                cmdUpdateMail.Parameters.Add("M_OUTSERVICENAME", OracleDbType.Varchar2).Value = objEntityMailConsole.Out_Service_Name;
                cmdUpdateMail.Parameters.Add("M_OUTPORT", OracleDbType.Int64).Value = objEntityMailConsole.Out_Port_Number;
                cmdUpdateMail.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMailConsole.Organisation_Id;
                cmdUpdateMail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
                cmdUpdateMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMailConsole.User_Id;
                cmdUpdateMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMailConsole.D_Date;
                cmdUpdateMail.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityMailConsole.Console_Status;
                cmdUpdateMail.Parameters.Add("M_SSL", OracleDbType.Int32).Value = objEntityMailConsole.SSL_Status;
                cmdUpdateMail.Parameters.Add("M_SIGNATURE", OracleDbType.Varchar2).Value = objEntityMailConsole.Signature;

                clsDataLayer.ExecuteNonQuery(cmdUpdateMail);
            }
        }

        //cancel mail console based on id so update cancel related fields
        public void CancelMailConsole(clsEntityMailConsole objEntityMailConsole)
        {

            string strQueryCancelMailConsole = "MAIL_CONSOLE_CONFIG.SP_CANCEL_MAIL_CONFIG";
            using (OracleCommand cmdCancelMail = new OracleCommand())
            {

                cmdCancelMail.CommandText = strQueryCancelMailConsole;
                cmdCancelMail.CommandType = CommandType.StoredProcedure;
                cmdCancelMail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
                cmdCancelMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMailConsole.User_Id;
                cmdCancelMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMailConsole.D_Date;
                cmdCancelMail.Parameters.Add("M_REASON", OracleDbType.Varchar2).Value = objEntityMailConsole.Cancel_Reason;

                clsDataLayer.ExecuteNonQuery(cmdCancelMail);
            }
        }

        // This Method fetch mail console details based on mail id
        public DataTable ReadMailConsoleById(clsEntityMailConsole objEntityMailConsole)
        {
            string strQueryReadMail = "MAIL_CONSOLE_CONFIG.SP_READ_MAIL_BYID";
            using (OracleCommand cmdReadMailById = new OracleCommand())
            {
                cmdReadMailById.CommandText = strQueryReadMail;
                cmdReadMailById.CommandType = CommandType.StoredProcedure;
                cmdReadMailById.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
                cmdReadMailById.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMailConsole.Organisation_Id;
                cmdReadMailById.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
                cmdReadMailById.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMailConsole = new DataTable();
                dtMailConsole = clsDataLayer.SelectDataTable(cmdReadMailById);
                return dtMailConsole;
            }
        }

        //check email address duplication, checking the email address already existed in the table or not
        public string CheckEmailAddress(clsEntityMailConsole objEntityMailConsole)
        {
            string strQueryCheckEmailAddress = "MAIL_CONSOLE_CONFIG.SP_CHECK_EMAIL";
            OracleCommand cmdCheckEmail = new OracleCommand();
            cmdCheckEmail.CommandText = strQueryCheckEmailAddress;
            cmdCheckEmail.CommandType = CommandType.StoredProcedure;
            cmdCheckEmail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
            cmdCheckEmail.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objEntityMailConsole.Email_Address;
            cmdCheckEmail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
            cmdCheckEmail.Parameters.Add("M_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckEmail);
            string strReturn = cmdCheckEmail.Parameters["M_OUT"].Value.ToString();
            cmdCheckEmail.Dispose();
            return strReturn;
        }


        // This Method fetch mail console based on corporate and organisation id
        public DataTable ReadMailConsole(clsEntityMailConsole objEntityMailConsole)
        {
            string strQueryReadMailConsole = "MAIL_CONSOLE_CONFIG.SP_READ_EMAIL_TABLE";
            using (OracleCommand cmdReadMailConsole = new OracleCommand())
            {
                cmdReadMailConsole.CommandText = strQueryReadMailConsole;
                cmdReadMailConsole.CommandType = CommandType.StoredProcedure;
                cmdReadMailConsole.Parameters.Add("M_OPTION", OracleDbType.Int32).Value = objEntityMailConsole.Console_Status;
                cmdReadMailConsole.Parameters.Add("M_CANCEL", OracleDbType.Int32).Value = objEntityMailConsole.Cancel_Status;
                cmdReadMailConsole.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMailConsole.Organisation_Id;
                cmdReadMailConsole.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMailConsole.Corporate_Id;
                cmdReadMailConsole.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityMailConsole.CommonSearchTerm;
                cmdReadMailConsole.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityMailConsole.SearchName;
                cmdReadMailConsole.Parameters.Add("M_SEARCH_PROTOCOL", OracleDbType.Varchar2).Value = objEntityMailConsole.SearchProtocol;
                cmdReadMailConsole.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityMailConsole.OrderColumn;
                cmdReadMailConsole.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityMailConsole.OrderMethod;
                cmdReadMailConsole.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityMailConsole.PageMaxSize;
                cmdReadMailConsole.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityMailConsole.PageNumber;
                cmdReadMailConsole.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMailConsole = new DataTable();
                dtMailConsole = clsDataLayer.SelectDataTable(cmdReadMailConsole);
                return dtMailConsole;
            }
        }
        public void UpdateStatus(clsEntityMailConsole objEntityMailConsole)
        {

            string strQueryAddMailConsole = "MAIL_CONSOLE_CONFIG.SP_UPDATE_STATUS";
            using (OracleCommand cmdUpdateMail = new OracleCommand())
            {
                cmdUpdateMail.CommandText = strQueryAddMailConsole;
                cmdUpdateMail.CommandType = CommandType.StoredProcedure;
                cmdUpdateMail.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityMailConsole.Mail_Console_Id;
                cmdUpdateMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMailConsole.User_Id;
                cmdUpdateMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMailConsole.D_Date;
                cmdUpdateMail.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityMailConsole.Console_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateMail);
            }
        }

    }
}
