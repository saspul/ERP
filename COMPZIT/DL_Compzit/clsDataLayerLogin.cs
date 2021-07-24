using System;
using System.Configuration;
using System.Text;
using System.Data;
using EL_Compzit;
using Oracle.DataAccess.Client;

// CREATED BY:EVM-0002
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE
namespace DL_Compzit
{
    public class clsDataLayerLogin
    {
        public DataTable LoadLogin(clsEntityLayerLogin objEntLogin)
        {
            //Get correct userid of emailid and password that passed from user master table. 
            using (OracleCommand cmdLogin = new OracleCommand())
            {
                cmdLogin.CommandText = "LOAD_LOGIN.SP_CHECK_LOGIN";
                //"SELECT USR_ID FROM gn_users WHERE usr_email= :LOG_USREMAIL AND usr_pwd= :LOG_USRPWD";
                cmdLogin.CommandType = CommandType.StoredProcedure;
                cmdLogin.Parameters.Add("LOG_USREMAIL", OracleDbType.Varchar2).Value = objEntLogin.UserEmail;
                cmdLogin.Parameters.Add("LOG_USRPWD", OracleDbType.Varchar2).Value = objEntLogin.UserPwd;
                cmdLogin.Parameters.Add("LOG_ORGID", OracleDbType.Int32).Value = objEntLogin.OrgId;
                cmdLogin.Parameters.Add("LOG_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLoginDetail = new DataTable();
                dtLoginDetail = clsDataLayer.SelectDataTable(cmdLogin);
                return dtLoginDetail;

            }


        }
        public DataTable ReadPremise(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadPrimise_Id = "LOAD_LOGIN.SP_READ_PRIMISEID_BY_ENCWRKID";
            OracleCommand cmdPrimiseId = new OracleCommand();

            cmdPrimiseId.CommandText = strQueryReadPrimise_Id;
            cmdPrimiseId.CommandType = CommandType.StoredProcedure;
            cmdPrimiseId.Parameters.Add("L_ENCRYPTWRKID", OracleDbType.Varchar2).Value = objEntityLogin.EncryptedWrkStnId;
            cmdPrimiseId.Parameters.Add("LOG_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdPrimiseId);
            return dtLoginDetail;

        }
        // METHOD TO FIND COUNT OF WORKSTN ID BASED ON ENCRYTED VALUE IN COOKIE
        public string CheckEncryptedWrkStnId(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadWrkId = "LOAD_LOGIN.SP_READ_ENCRYPTEDWRKSTNID";
            OracleCommand cmdReadWrkId = new OracleCommand();

            cmdReadWrkId.CommandText = strQueryReadWrkId;
            cmdReadWrkId.CommandType = CommandType.StoredProcedure;
            cmdReadWrkId.Parameters.Add("L_WRKID", OracleDbType.Varchar2).Value = objEntityLogin.EncryptedWrkStnId;
            cmdReadWrkId.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadWrkId);
            string strReturn = cmdReadWrkId.Parameters["L_COUNT"].Value.ToString();
            cmdReadWrkId.Dispose();
            return strReturn;

        }
        // METHOD TO decide if to show new registration link when  it is not cloud condition.If count is zero make visible if not zero make the lnk invisble
        public string CheckForNewReg()
        {
            string strQueryReadOrgId = "LOAD_LOGIN.SP_NOTCLOUD_VERIFICATION";
            OracleCommand cmdReadOrgId = new OracleCommand();

            cmdReadOrgId.CommandText = strQueryReadOrgId;
            cmdReadOrgId.CommandType = CommandType.StoredProcedure;

            cmdReadOrgId.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadOrgId);
            string strReturn = cmdReadOrgId.Parameters["C_COUNT"].Value.ToString();
            cmdReadOrgId.Dispose();
            return strReturn;

        }
        // METHOD TO decide if  TO PROCEED  for app admin .If all template type are not entered in GN_EMAIL_TEMPLATE THEN procedure return 0 else 1.If 0 then app admin will not be able to proceed
        public string CheckForEmailTemplatesPresent()
        {
            string strQueryReadOrgId = "LOAD_LOGIN.SP_EMAILTEMPLATE_VERIFICATION";
            OracleCommand cmdReadOrgId = new OracleCommand();

            cmdReadOrgId.CommandText = strQueryReadOrgId;
            cmdReadOrgId.CommandType = CommandType.StoredProcedure;

            cmdReadOrgId.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadOrgId);
            string strReturn = cmdReadOrgId.Parameters["C_COUNT"].Value.ToString();
            cmdReadOrgId.Dispose();
            return strReturn;

        }

        // METHOD TO decide if  TO PROCEED  for app admin .If all template type are not entered in GN_EMAIL_TEMPLATE THEN procedure return 0 else 1.If 0 then app admin will not be able to proceed
        public Int32 DefaultMailTemplateExists()
        {
            string strProcedureName = "LOAD_LOGIN.SP_CHECK_EMLTEMPLATE_IN_CONFIG";
            OracleCommand cmdEmlTemplateInConfig = new OracleCommand();

            cmdEmlTemplateInConfig.CommandText = strProcedureName;
            cmdEmlTemplateInConfig.CommandType = CommandType.StoredProcedure;

            cmdEmlTemplateInConfig.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdEmlTemplateInConfig);
            Int32 intReturn = Convert.ToInt32(cmdEmlTemplateInConfig.Parameters["C_COUNT"].Value.ToString());
            cmdEmlTemplateInConfig.Dispose();
            return intReturn;

        }

        // METHOD TO decide if to show Send Mail link when  it is not cloud condition.If count is zero make invisible if not zero make the lnk visble
        public string CheckForShowingSendMail()
        {
            string strQueryReadOrgId = "LOAD_LOGIN.SP_RESENDMAIL_NOTONCLOUD_VER";
            OracleCommand cmdReadOrgId = new OracleCommand();

            cmdReadOrgId.CommandText = strQueryReadOrgId;
            cmdReadOrgId.CommandType = CommandType.StoredProcedure;

            cmdReadOrgId.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadOrgId);
            string strReturn = cmdReadOrgId.Parameters["C_COUNT"].Value.ToString();
            cmdReadOrgId.Dispose();
            return strReturn;

        }

        // METHOD  for CHECKING FOR EMAIL ID PRESENT IN GN_PARKING_ORG ALSO TO SELECT STATUS IF FOUND
        public DataTable CheckReSendMAil_Notify(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadId = "LOAD_LOGIN.SP_RESENDMAIL_NOTIFICATION";
            OracleCommand cmdReadId = new OracleCommand();


            cmdReadId.CommandText = strQueryReadId;
            cmdReadId.CommandType = CommandType.StoredProcedure;
            cmdReadId.Parameters.Add("CHECK_USREMAIL", OracleDbType.Varchar2).Value = objEntityLogin.UserEmail;
            cmdReadId.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadId);
            return dtLoginDetail;

        }

        /*METHOD for CHECKING If there is any MAIL IN GN_EMAIL_STORE with send status='0' ie. not send corresponding to TransationId,TempalteId email address provided
 .This checking is necessary as if we are inserting again to GN_EMAIL_STORE then uniquness error occurs 
 So if mail is not here that is count is 0 then resend mail as done in organisation with values from organisation parking table
 else send mail using this data*/
        public string CheckEmailStore(Int64 intTransationId, int intTempalteId)
        {
            string strQueryReadOrgId = "LOAD_LOGIN.SP_RESENDMAIL_CHECK_STORE";
            OracleCommand cmdReadOrgId = new OracleCommand();

            cmdReadOrgId.CommandText = strQueryReadOrgId;
            cmdReadOrgId.CommandType = CommandType.StoredProcedure;
            cmdReadOrgId.Parameters.Add("TRANS_ID", OracleDbType.Int64).Value = intTransationId;
            cmdReadOrgId.Parameters.Add("TMPLATE_ID", OracleDbType.Int32).Value = intTempalteId;
            cmdReadOrgId.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadOrgId);
            string strReturn = cmdReadOrgId.Parameters["C_COUNT"].Value.ToString();
            cmdReadOrgId.Dispose();
            return strReturn;

        }



        // METHOD TO FIND CORPORATE NAME
        public DataTable ReadCorporateName(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadName = "LOAD_LOGIN.SP_READ_CORPORATENAME";
            OracleCommand cmdReadName = new OracleCommand();



            cmdReadName.CommandText = strQueryReadName;
            cmdReadName.CommandType = CommandType.StoredProcedure;
            cmdReadName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityLogin.CorpOfficeId;
            cmdReadName.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadName);
            return dtLoginDetail;

          
           

        }
        // METHOD TO FIND Organisation NAME
        public DataTable ReadOrganisationName(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadName = "LOAD_LOGIN.SP_READ_ORGNAME";
            OracleCommand cmdReadName = new OracleCommand();

            cmdReadName.CommandText = strQueryReadName;
            cmdReadName.CommandType = CommandType.StoredProcedure;
            cmdReadName.Parameters.Add("O_ORGID", OracleDbType.Int32).Value = objEntityLogin.OrgId;
            cmdReadName.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output; 
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadName);
            return dtLoginDetail;

        }
        // METHOD TO FIND Premise NAME
        public DataTable ReadPremiseName(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadName = "LOAD_LOGIN.SP_READ_PRIMISENAME";
            OracleCommand cmdReadName = new OracleCommand();

            cmdReadName.CommandText = strQueryReadName;
            cmdReadName.CommandType = CommandType.StoredProcedure;
            cmdReadName.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityLogin.PremiseId;
            cmdReadName.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadName);
            return dtLoginDetail;

        }
        // METHOD TO FIND whether to show landing page or not if app type menu count is 0 then directly show sales force home page
        //or if sales force count is 0 then dirctly show app adminstration  home page
        //if both not 0 then show landing page
        public DataTable Read_AppMenuCount(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadCount = "LOAD_LOGIN.SP_READ_USR_APPMENUCOUNT";
            OracleCommand cmdReadCount = new OracleCommand();

            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityLogin.UserIdInt;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCountDetail = new DataTable();
            dtCountDetail = clsDataLayer.SelectDataTable(cmdReadCount);
            return dtCountDetail;

        }
        //get useroleId based on userid and Appid
        public DataTable Read_AppMenuDtl(int intUserId,int IntAppId)
        {
            string strQueryReadDtl = "LOAD_LOGIN.SP_READ_USR_APPMENUDTL";
            OracleCommand cmdReadDtl = new OracleCommand();

            cmdReadDtl.CommandText = strQueryReadDtl;
            cmdReadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadDtl.Parameters.Add("U_ID", OracleDbType.Int32).Value = intUserId;
            cmdReadDtl.Parameters.Add("L_PRTZAPP_ID", OracleDbType.Int32).Value = IntAppId;
            cmdReadDtl.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCountDetail = new DataTable();
            dtCountDetail = clsDataLayer.SelectDataTable(cmdReadDtl);
            return dtCountDetail;

        }
        //METHOD for Reading USER IMAGE AND OTHER DETAILS
        public DataTable Read_UserInfo(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadUsrInfo = "LOAD_LOGIN.SP_READ_USR_INFO_BYID";
            OracleCommand cmdReadUsrInfo = new OracleCommand();

            cmdReadUsrInfo.CommandText = strQueryReadUsrInfo;
            cmdReadUsrInfo.CommandType = CommandType.StoredProcedure;
            cmdReadUsrInfo.Parameters.Add("U_ID", OracleDbType.Int32).Value = objEntityLogin.UserIdInt;
            cmdReadUsrInfo.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtUsrDetail = new DataTable();
            dtUsrDetail = clsDataLayer.SelectDataTable(cmdReadUsrInfo);
            return dtUsrDetail;

        }
        //METHOD  for Reading  Corporate Offices  of a organization when organization adminstrator login.Inorder him to choose a corporate
        public DataTable Read_CorpOffc_ByOrgId(clsEntityLayerLogin objEntityLogin)
        {
            string strQueryReadCorp = "LOAD_LOGIN.SP_READ_CORPOFC_BY_ORG_ADMIN";
            OracleCommand cmdReadCorpOfc = new OracleCommand();

            cmdReadCorpOfc.CommandText = strQueryReadCorp;
            cmdReadCorpOfc.CommandType = CommandType.StoredProcedure;
            cmdReadCorpOfc.Parameters.Add("U_ORGID", OracleDbType.Int32).Value = objEntityLogin.OrgId;
            cmdReadCorpOfc.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCrpDetail = new DataTable();
            dtCrpDetail = clsDataLayer.SelectDataTable(cmdReadCorpOfc);
            return dtCrpDetail;

        }
        public DataTable ReadAcsCorpBy_Usr(clsEntityLayerLogin objEntityLogin)
        {
            using (OracleCommand cmdReadDsgnEdit = new OracleCommand())
            {
                cmdReadDsgnEdit.CommandText = "LOAD_LOGIN.SP_READ_USR_ACS_CPRT_BYUSR";
                cmdReadDsgnEdit.CommandType = CommandType.StoredProcedure;
                cmdReadDsgnEdit.Parameters.Add("IN_USER_ID", OracleDbType.Int32).Value = objEntityLogin.UserIdInt;
                cmdReadDsgnEdit.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDsgnMasterEdit = new DataTable();
                dtDsgnMasterEdit = clsDataLayer.ExecuteReader(cmdReadDsgnEdit);
                return dtDsgnMasterEdit;
            }
        }
    }
}
