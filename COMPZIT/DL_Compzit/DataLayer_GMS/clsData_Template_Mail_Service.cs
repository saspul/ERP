
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;

namespace DL_Compzit.DataLayer_GMS
{
   public class clsData_Template_Mail_Service
    {


        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetCH projects
        public DataTable ReadBankDetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_GURNT_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadDivisiondetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_CORPDIV_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_DIV_ID", OracleDbType.Int32).Value = EntityTemMailServce.EmployeId;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadDesignatndetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_DESGNATN_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_DIV_ID", OracleDbType.Int32).Value = EntityTemMailServce.EmployeId;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        public DataTable ReadEmplydetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_EMPLY_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("B_DIV_ID", OracleDbType.Int32).Value = EntityTemMailServce.EmployeId;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadMailAddress(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_MAIL_ADDRS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = EntityTemMailServce.GuaranteeId;
            cmdReadBankGuarnt.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = EntityTemMailServce.TempAlertId;  
           // cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
          //  cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadFromMailDetails(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "COMMON.SP_FETCH_FROM_MAIL";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("C_USER_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.CorpOffice_Id;
            cmdReadFromMail.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }

        public void UpdateMailChk(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_UPDT_MAILALERT_CHK";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityUsrReg.GuaranteeId;
            cmdReadFromMail.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = objEntityUsrReg.TempAlertId;
            clsDataLayer.ExecuteNonQuery(cmdReadFromMail);
        }

        public DataTable ReqstGuarnteedetails(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_READ_RQSTGUARNTE_DTLS";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("B_CURRNTDATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
            //cmdReadFromMail.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = objEntityUsrReg.TempAlertId;
            cmdReadFromMail.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }
        public void UpdateRfqCloseDate(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_UPDT_RQSTGUARANTEE";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("RQST_ID", OracleDbType.Int32).Value = objEntityUsrReg.ReqstGrntId;
            // cmdReadFromMail.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = objEntityUsrReg.TempAlertId;
            clsDataLayer.ExecuteNonQuery(cmdReadFromMail);
        }
        public DataTable ReadGuranteeById(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_READ_GUARANT_BYID";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("B_GURNTID", OracleDbType.Int32).Value = objEntityUsrReg.GuaranteeId;
            cmdReadFromMail.Parameters.Add("B_CORPRT_ID", OracleDbType.Int32).Value = objEntityUsrReg.CorpOffice_Id;
            cmdReadFromMail.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }
       //this method is to stores the tracking details for the mail sending
        public void InsertMailTracking(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryInsertTrack = "TEMP_MAIL_SERVICE.SP_INS_MAILTRCKNG";
            OracleCommand cmdInsertTrack = new OracleCommand();
            cmdInsertTrack.CommandText = strQueryInsertTrack;
            cmdInsertTrack.CommandType = CommandType.StoredProcedure;
            cmdInsertTrack.Parameters.Add("TR_DATE", OracleDbType.Date).Value = objEntityUsrReg.D_Date;
            cmdInsertTrack.Parameters.Add("TR_TO", OracleDbType.Varchar2).Value = objEntityUsrReg.ToMailId;
            cmdInsertTrack.Parameters.Add("TR_FROM", OracleDbType.Varchar2).Value = objEntityUsrReg.FromMailId;
            cmdInsertTrack.Parameters.Add("TR_CC", OracleDbType.Varchar2).Value = objEntityUsrReg.CcMailId;
            cmdInsertTrack.Parameters.Add("TR_BCC", OracleDbType.Varchar2).Value = objEntityUsrReg.BccMailId;
            cmdInsertTrack.Parameters.Add("TR_SUBJECT", OracleDbType.Varchar2).Value = objEntityUsrReg.MailSubject;
            cmdInsertTrack.Parameters.Add("TR_MAILMODUL", OracleDbType.Varchar2).Value = objEntityUsrReg.MailMOdule;
            cmdInsertTrack.Parameters.Add("TR_ORG", OracleDbType.Int32).Value = objEntityUsrReg.Organisation_Id;
            cmdInsertTrack.Parameters.Add("TR_CORP", OracleDbType.Int32).Value = objEntityUsrReg.CorpOffice_Id;
            cmdInsertTrack.Parameters.Add("TR_REF", OracleDbType.Varchar2).Value = objEntityUsrReg.RefNumber;
            clsDataLayer.ExecuteNonQuery(cmdInsertTrack);
        }
        // This Method will Insurance details
        public DataTable ReadInsuranceDetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_INSURANCE_DETAILS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = EntityTemMailServce.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = EntityTemMailServce.CorpOffice_Id;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
        public DataTable ReadInsuranceByID(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_READ_INSURANCE_BYID";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityUsrReg.InsuranceID;
            cmdReadFromMail.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityUsrReg.CorpOffice_Id;
            cmdReadFromMail.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadFromMail = new DataTable();
            dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
            return dtReadFromMail;
        }
       //updates the mail sent status 
        public void UpdateMailChk_Insurance(Entity_Template_Mail_Service objEntityUsrReg)
        {
            string strQueryReadFromMail = "TEMP_MAIL_SERVICE.SP_UPDT_MAILALERT_CHK_INSU";
            OracleCommand cmdReadFromMail = new OracleCommand();
            cmdReadFromMail.CommandText = strQueryReadFromMail;
            cmdReadFromMail.CommandType = CommandType.StoredProcedure;
            cmdReadFromMail.Parameters.Add("B_INSU_ID", OracleDbType.Int32).Value = objEntityUsrReg.InsuranceID;
            cmdReadFromMail.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = objEntityUsrReg.TempAlertId;
            clsDataLayer.ExecuteNonQuery(cmdReadFromMail);
        }
        public DataTable ReadMailAddressInsurance(Entity_Template_Mail_Service EntityTemMailServce)
        {
            string strQueryReadBankGuarnt = "TEMP_MAIL_SERVICE.SP_READ_MAIL_ADDRS_INS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("B_INSU_ID", OracleDbType.Int32).Value = EntityTemMailServce.InsuranceID;
            cmdReadBankGuarnt.Parameters.Add("B_TEMALERT_ID", OracleDbType.Int32).Value = EntityTemMailServce.TempAlertId;
            cmdReadBankGuarnt.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }
    }
}
