using System;
using System.Text;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;

// CREATED BY:EVM-0002
// CREATED DATE:29/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerOrgVerification
    {
        // This Method for fetch the result of verification code that we give.
        public DataTable OrgVerification(clsEntityLayerOrgVerification objOrgVef)
        {
            string strCommandText = "ORGANISATION_VERIFICATION.SP_ORG_VERIFICATION";
            using (OracleCommand cmdOrgVef = new OracleCommand())
            {
                cmdOrgVef.CommandText = strCommandText;
                cmdOrgVef.CommandType = CommandType.StoredProcedure;
                cmdOrgVef.Parameters.Add("O_VERIFICATION_CODE", OracleDbType.Varchar2).Value = objOrgVef.Verification_Code;
                cmdOrgVef.Parameters.Add("O_VERIFICATION_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtOrgVef = new DataTable();
                dtOrgVef = clsDataLayer.SelectDataTable(cmdOrgVef);
                return dtOrgVef;
            }
        }

        //Method for Update status of user in parking table after sucessfull completion of email verification and to insert in and GN_EMAIL_STORE.
        public void OrgstatusChange_Mail(clsEntityLayerOrgVerification objOrgVef, string strTempalteId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                OracleTransaction tran;
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strCommandText = "ORGANISATION_VERIFICATION.SP_ORG_STATUS_UPDATE";
                    using (OracleCommand cmdOrgVef = new OracleCommand())
                    {
                        cmdOrgVef.Connection = con;
                        cmdOrgVef.Transaction = tran;
                        cmdOrgVef.CommandText = strCommandText;
                        cmdOrgVef.CommandType = CommandType.StoredProcedure;
                        cmdOrgVef.Parameters.Add("O_VERIFICATION_CODE", OracleDbType.Varchar2).Value = objOrgVef.Verification_Code;
                        cmdOrgVef.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = 2;
                        cmdOrgVef.Parameters.Add("O_DATE", OracleDbType.Date).Value = objOrgVef.Date_Verification;
                        cmdOrgVef.ExecuteNonQuery();
                    }
                    int intStatus = 0;
                    string strCommandTextMial = "MAIL.SP_INSERT_GN_EMAIL_STORE";
                    using (OracleCommand cmdStore = new OracleCommand())
                    {
                        cmdStore.Connection = con;
                        cmdStore.Transaction = tran;
                        cmdStore.CommandText = strCommandTextMial;
                        cmdStore.CommandType = CommandType.StoredProcedure;
                        cmdStore.Parameters.Add("S_TMTP_ID", OracleDbType.Int32).Value = dtTemplateDetail.Rows[0]["EMTMTP_ID"].ToString(); ;
                        cmdStore.Parameters.Add("S_TRANS_ID", OracleDbType.Int32).Value = Convert.ToInt32(objOrgVef.Organisation_Id.ToString());
                        cmdStore.Parameters.Add("S_FR0M_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_EMAIL_SENDMAIL"].ToString();
                        cmdStore.Parameters.Add("S_TO_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_APRVAL_SENDMAIL"].ToString();
                        cmdStore.Parameters.Add("S_RPLYTO_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_RPLYTO_SENDMAIL"].ToString();
                        cmdStore.Parameters.Add("S_SUBJ", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_SUBJECT"].ToString();
                        cmdStore.Parameters.Add("S_MSG", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_MESSAGE"].ToString();
                        cmdStore.Parameters.Add("S_FROM_ADDR1", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_ADDR1"].ToString();
                        cmdStore.Parameters.Add("S_DISCLAIMER", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_DISCLAIMER"].ToString();
                        cmdStore.Parameters.Add("S_SEND_STATUS", OracleDbType.Int32).Value = intStatus;
                        cmdStore.Parameters.Add("S_TMPLT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTempalteId);
                        cmdStore.ExecuteNonQuery();
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
    }
}
