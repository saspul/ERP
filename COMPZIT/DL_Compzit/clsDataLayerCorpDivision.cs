using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerCorpDivision
    {
       
         //This Method adds Corporate Division details to the database
   
    
        public DataTable ReadNextId(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryReadNextId = "NEXT_ID_GENERATION.SP_MASTERID";
            using (OracleCommand cmdReadNextId = new OracleCommand())
            {
                cmdReadNextId.CommandText = strQueryReadNextId;
                cmdReadNextId.CommandType = CommandType.StoredProcedure;
                cmdReadNextId.Parameters.Add("M_NEXTID", OracleDbType.Int32).Value = clsCommonLibrary.MasterId.Corporate_Division;
                cmdReadNextId.Parameters.Add("M_NEXTVALUE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadnextId = new DataTable();
                dtReadnextId = clsDataLayer.SelectDataTable(cmdReadNextId);
                return dtReadnextId;
            }
        }


        public void AddCorporateDivisionMstr(clsEntityCorpDivision objEntityCorpDiv)
        {
           
            string strQueryAddCoprDiv = "CORPORATE_DIVISION.SP_INSERT_GEN_CORP_DIVISIONS";
            using (OracleCommand cmdAddCorpDiv = new OracleCommand())
            {
                
                cmdAddCorpDiv.CommandText = strQueryAddCoprDiv;
                cmdAddCorpDiv.CommandType = CommandType.StoredProcedure;
                cmdAddCorpDiv.Parameters.Add("D_DIVID", OracleDbType.Int32).Value = objEntityCorpDiv.DivisionId;
                cmdAddCorpDiv.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objEntityCorpDiv.CorpDivisionName;
                cmdAddCorpDiv.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objEntityCorpDiv.DivStatus;
                cmdAddCorpDiv.Parameters.Add("D_CODE", OracleDbType.Varchar2).Value = objEntityCorpDiv.DivisionCode;
                cmdAddCorpDiv.Parameters.Add("D_EMAIL_ID", OracleDbType.Varchar2).Value = objEntityCorpDiv.EmailId;
                cmdAddCorpDiv.Parameters.Add("D_ICON", OracleDbType.Varchar2).Value = objEntityCorpDiv.DivisionIcon;
                cmdAddCorpDiv.Parameters.Add("D_INS_USR_ID", OracleDbType.Int32).Value = objEntityCorpDiv.InsertUsrId;
                cmdAddCorpDiv.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityCorpDiv.OrgId;
                cmdAddCorpDiv.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityCorpDiv.CorpId;
                cmdAddCorpDiv.Parameters.Add("D_STORAGE_MAIL", OracleDbType.Varchar2).Value = objEntityCorpDiv.Mail_Storage_Email;
                cmdAddCorpDiv.Parameters.Add("D_REMOVE_STS", OracleDbType.Int32).Value = objEntityCorpDiv.Remove_Mail_Store;
                    
                clsDataLayer.ExecuteNonQuery(cmdAddCorpDiv);
            }

          
        }

        // This Method fetch CorpDiv table from the database to the list
        public DataTable ReadCorpDivisionTable(clsEntityCorpDivision objCorpDiv)
        {

            string strQueryAddState = "CORPORATE_DIVISION.SP_READ_CORP_DIVISION";
            DataTable dtCorPDivTable = new DataTable();
            using (OracleCommand cmdReadCoprDiv = new OracleCommand())
            {
                cmdReadCoprDiv.CommandText = strQueryAddState;
                cmdReadCoprDiv.CommandType = CommandType.StoredProcedure;
                cmdReadCoprDiv.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
                cmdReadCoprDiv.Parameters.Add("S_COPRID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
                cmdReadCoprDiv.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objCorpDiv.DivStatus;
                cmdReadCoprDiv.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objCorpDiv.Cancel_Status;
                cmdReadCoprDiv.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objCorpDiv.CommonSearchTerm;
                cmdReadCoprDiv.Parameters.Add("M_SEARCH_DIVISION", OracleDbType.Varchar2).Value = objCorpDiv.SearchDivision;
                cmdReadCoprDiv.Parameters.Add("M_SEARCH_CODE", OracleDbType.Varchar2).Value = objCorpDiv.SearchCode;
                cmdReadCoprDiv.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objCorpDiv.OrderColumn;
                cmdReadCoprDiv.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objCorpDiv.OrderMethod;
                cmdReadCoprDiv.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objCorpDiv.PageMaxSize;
                cmdReadCoprDiv.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objCorpDiv.PageNumber;
                cmdReadCoprDiv.Parameters.Add("S_CORPDIV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCorPDivTable = clsDataLayer.ExecuteReader(cmdReadCoprDiv);
            }
            return dtCorPDivTable;
        }
        // This Method fetch CorpDiv table from the database
        public DataTable EditViewCorpDiv(clsEntityCorpDivision objCorpDiv)
        {
            string strCommandText = "CORPORATE_DIVISION.SP_READ_GEN_CORPDIV_BYID";
            using (OracleCommand cmdEditView = new OracleCommand())
            {
                cmdEditView.CommandText = strCommandText;
                cmdEditView.CommandType = CommandType.StoredProcedure;
                cmdEditView.Parameters.Add("D_DIVID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
                cmdEditView.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEditView = new DataTable();
                dtEditView = clsDataLayer.SelectDataTable(cmdEditView);
                return dtEditView;
            }
        }


        //method to update corp div details to the table
        public void UpdateCorpDivision(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryUpdCrpDiv = "CORPORATE_DIVISION.SP_UPDATE_GEN_CORP_DIVISION";
            using (OracleCommand cmdUpdateCorpDiv = new OracleCommand())
            {
                cmdUpdateCorpDiv.CommandText = strQueryUpdCrpDiv;
                cmdUpdateCorpDiv.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorpDiv.Parameters.Add("D_DIVID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
                cmdUpdateCorpDiv.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objCorpDiv.CorpDivisionName;
                cmdUpdateCorpDiv.Parameters.Add("D_EMAIL_ID", OracleDbType.Varchar2).Value = objCorpDiv.EmailId;
                cmdUpdateCorpDiv.Parameters.Add("D_CODE", OracleDbType.Varchar2).Value = objCorpDiv.DivisionCode;
                cmdUpdateCorpDiv.Parameters.Add("D_ICON", OracleDbType.Varchar2).Value = objCorpDiv.DivisionIcon;
                cmdUpdateCorpDiv.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objCorpDiv.DivStatus;
                cmdUpdateCorpDiv.Parameters.Add("D_UPD_USR_ID", OracleDbType.Int32).Value = objCorpDiv.UpdateUsrId;
                cmdUpdateCorpDiv.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
                cmdUpdateCorpDiv.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
                cmdUpdateCorpDiv.Parameters.Add("D_STORAGE_MAIL", OracleDbType.Varchar2).Value = objCorpDiv.Mail_Storage_Email;
                cmdUpdateCorpDiv.Parameters.Add("D_REMOVE_STS", OracleDbType.Int32).Value = objCorpDiv.Remove_Mail_Store;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCorpDiv);
            }


           

            
                    
        }

        //method to update corp div details to the table
        public void Update_Division_Status(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryUpdCrpDiv = "CORPORATE_DIVISION.SP_UPDATE_GEN_CORP_DIV_STS";
            using (OracleCommand cmdUpdateCorpDiv = new OracleCommand())
            {
                cmdUpdateCorpDiv.CommandText = strQueryUpdCrpDiv;
                cmdUpdateCorpDiv.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorpDiv.Parameters.Add("D_DIVID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
                cmdUpdateCorpDiv.Parameters.Add("D_STATUS", OracleDbType.Int32).Value = objCorpDiv.DivStatus;
                cmdUpdateCorpDiv.Parameters.Add("D_UPD_USR_ID", OracleDbType.Int32).Value = objCorpDiv.UpdateUsrId;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCorpDiv);
            }






        }
        //method to update cancel reasons of corp div details to the table
        public void UpdateCorpDivCancel(clsEntityCorpDivision objCorpDivr)
        {
            
            using (OracleCommand cmdUpdateCorpDivCancel = new OracleCommand())
            {
                cmdUpdateCorpDivCancel.InitialLONGFetchSize = 1000;
                cmdUpdateCorpDivCancel.CommandText = "CORPORATE_DIVISION.SP_UPDATE_CORPDIV_CANCEL";
                cmdUpdateCorpDivCancel.CommandType = CommandType.StoredProcedure;
                cmdUpdateCorpDivCancel.Parameters.Add("D_ID", OracleDbType.Int32).Value = objCorpDivr.DivisionId;
                cmdUpdateCorpDivCancel.Parameters.Add("D_CANCELID", OracleDbType.Int32).Value = objCorpDivr.CanceltUsrId;
                cmdUpdateCorpDivCancel.Parameters.Add("D_CANCELREASON", OracleDbType.Varchar2).Value = objCorpDivr.CancelReason;
                cmdUpdateCorpDivCancel.Parameters.Add("D_CANCELDATE", OracleDbType.Date).Value = objCorpDivr.CancelUsrDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCorpDivCancel);
            }
        }


        public string CheckDupDivNameUpdate(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryCheckDivNameUpdate = "CORPORATE_DIVISION.SP_CHK_CORP_DIV_DUPLICATION";
            OracleCommand cmdCheckDivName = new OracleCommand();
            cmdCheckDivName.CommandText = strQueryCheckDivNameUpdate;
            cmdCheckDivName.CommandType = CommandType.StoredProcedure;
            cmdCheckDivName.Parameters.Add("D_ID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
            cmdCheckDivName.Parameters.Add("D_NAME", OracleDbType.Varchar2).Value = objCorpDiv.CorpDivisionName;
            cmdCheckDivName.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
            cmdCheckDivName.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
            cmdCheckDivName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDivName);
            string strReturn = cmdCheckDivName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDivName.Dispose();
            return strReturn;
        }

        public string CheckDupDivEmail(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryCheckDivNameUpdate = "CORPORATE_DIVISION.SP_CHK_CORP_DIV_EMAIL_DUP";
            OracleCommand cmdCheckDivEmail = new OracleCommand();
            cmdCheckDivEmail.CommandText = strQueryCheckDivNameUpdate;
            cmdCheckDivEmail.CommandType = CommandType.StoredProcedure;
            cmdCheckDivEmail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
            cmdCheckDivEmail.Parameters.Add("D_EMAIL", OracleDbType.Varchar2).Value = objCorpDiv.EmailId;
            cmdCheckDivEmail.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
            cmdCheckDivEmail.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
            cmdCheckDivEmail.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDivEmail);
            string strReturn = cmdCheckDivEmail.Parameters["D_COUNT"].Value.ToString();
            cmdCheckDivEmail.Dispose();
            return strReturn;
        }

        public string CheckDupDivCode(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryCheckDupDivCode = "CORPORATE_DIVISION.SP_CHK_CORP_DIV_CODE_DUPLIC";
            OracleCommand cmdDupDivCode = new OracleCommand();
            cmdDupDivCode.CommandText = strQueryCheckDupDivCode;
            cmdDupDivCode.CommandType = CommandType.StoredProcedure;
            cmdDupDivCode.Parameters.Add("D_ID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
            cmdDupDivCode.Parameters.Add("D_CODE", OracleDbType.Varchar2).Value = objCorpDiv.DivisionCode;
            cmdDupDivCode.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
            cmdDupDivCode.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
            cmdDupDivCode.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdDupDivCode);
            string strReturn = cmdDupDivCode.Parameters["D_COUNT"].Value.ToString();
            cmdDupDivCode.Dispose();
            return strReturn;
        }

        //method to update mail console setting table
        public void UpdateMailConsole(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryUpdMailConsole = "CORPORATE_DIVISION.SP_UPDATE_MAIL_SETTINGS";
            using (OracleCommand cmdUpdateMailConsole = new OracleCommand())
            {
                cmdUpdateMailConsole.CommandText = strQueryUpdMailConsole;
                cmdUpdateMailConsole.CommandType = CommandType.StoredProcedure;
                cmdUpdateMailConsole.Parameters.Add("M_ID", OracleDbType.Int32).Value = objCorpDiv.Mail_Settings_Id;
                cmdUpdateMailConsole.Parameters.Add("M_DIVID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
                cmdUpdateMailConsole.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objCorpDiv.EmailId;
                if (objCorpDiv.Password == "" || objCorpDiv.Password == null)
                    cmdUpdateMailConsole.Parameters.Add("M_PASSWORD", OracleDbType.Varchar2).Value = null;
                else
                    cmdUpdateMailConsole.Parameters.Add("M_PASSWORD", OracleDbType.Varchar2).Value = objCorpDiv.Password;                    
                cmdUpdateMailConsole.Parameters.Add("M_SERVICENAME", OracleDbType.Varchar2).Value = objCorpDiv.Service_Name;
                cmdUpdateMailConsole.Parameters.Add("M_PORT_NUMBER", OracleDbType.Int64).Value = objCorpDiv.Port_Number;
                cmdUpdateMailConsole.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objCorpDiv.UpdateUsrId;
                cmdUpdateMailConsole.Parameters.Add("M_DATE", OracleDbType.Date).Value = objCorpDiv.UpdUsrDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateMailConsole);
            }
        }

        // This Method fetch mail console settings details based on division id
        public DataTable ReadMailSettings(clsEntityCorpDivision objCorpDiv)
        {
            string strQueryReadMail = "CORPORATE_DIVISION.SP_READ_MAIL_SETTINGS";
            using (OracleCommand cmdReadMail = new OracleCommand())
            {
                cmdReadMail.CommandText = strQueryReadMail;
                cmdReadMail.CommandType = CommandType.StoredProcedure;
                cmdReadMail.Parameters.Add("D_DIVID", OracleDbType.Int32).Value = objCorpDiv.DivisionId;
                cmdReadMail.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objCorpDiv.OrgId;
                cmdReadMail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objCorpDiv.CorpId;
                cmdReadMail.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadMail = new DataTable();
                dtReadMail = clsDataLayer.SelectDataTable(cmdReadMail);
                return dtReadMail;
            }
        }

      

       

    }
}
