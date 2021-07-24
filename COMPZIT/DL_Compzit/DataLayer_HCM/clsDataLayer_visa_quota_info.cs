using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_visa_quota_info
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        public DataTable ReadVisaTyp(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISATYP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadSelectNations(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_NATION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadBussnsUnit(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_BUSINESS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public void AddVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_INS_VISA_QUOTA";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("P_ISSUEDATE", OracleDbType.Date).Value = objEntityVisaQuot.IssueDate;
                cmdReadPayGrd.Parameters.Add("P_EXPIRYDATE", OracleDbType.Date).Value = objEntityVisaQuot.ExpiryDate;
                cmdReadPayGrd.Parameters.Add("P_BUNDLE_NUM", OracleDbType.Varchar2).Value = objEntityVisaQuot.BundleNum;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public void AddVisaQuotaDetails(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_INS_VISA_QUOTA_DETAILS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("P_NUM_VISA", OracleDbType.Int32).Value = objEntityVisaQuot.NumVisa;
                cmdReadPayGrd.Parameters.Add("P_NATION", OracleDbType.Int32).Value = objEntityVisaQuot.CountryId;
                cmdReadPayGrd.Parameters.Add("P_BUSINESS_ID", OracleDbType.Int32).Value = objEntityVisaQuot.BussnsId;
                cmdReadPayGrd.Parameters.Add("P_VISATYP_ID", OracleDbType.Int32).Value = objEntityVisaQuot.VisaTyp;
                cmdReadPayGrd.Parameters.Add("P_GENDER_ID", OracleDbType.Int32).Value = objEntityVisaQuot.Gender;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public DataTable ReadVisaDetailsList(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISADETAILS_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadVisaDetailsId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISADETAILS_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VISADETAIL_ID", OracleDbType.Int32).Value = objEntityVisaQuot.VisaDetailId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void UpDateVisaQuotaDetails(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_UPD_VISA_QUOTA_DETAILS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("P_VISADETAIL_ID", OracleDbType.Int32).Value = objEntityVisaQuot.VisaDetailId;
                cmdReadPayGrd.Parameters.Add("P_NUM_VISA", OracleDbType.Int32).Value = objEntityVisaQuot.NumVisa;
                cmdReadPayGrd.Parameters.Add("P_NATION", OracleDbType.Int32).Value = objEntityVisaQuot.CountryId;
                cmdReadPayGrd.Parameters.Add("P_BUSINESS_ID", OracleDbType.Int32).Value = objEntityVisaQuot.BussnsId;
                cmdReadPayGrd.Parameters.Add("P_VISATYP_ID", OracleDbType.Int32).Value = objEntityVisaQuot.VisaTyp;
                cmdReadPayGrd.Parameters.Add("P_GENDER_ID", OracleDbType.Int32).Value = objEntityVisaQuot.Gender;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }


        public void CancelVisaDtls(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CANCEL_VISA_QUOTA_DETAILS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               
                cmdReadPayGrd.Parameters.Add("P_VISADETAIL_ID", OracleDbType.Int32).Value = objEntityVisaQuot.VisaDetailId;
                 cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public DataTable ReadVisaquotaList(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISAQUOTA_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityVisaQuot.Cancel_Status;
            if (objEntityVisaQuot.FromDate == DateTime.MinValue)
                cmdReadPayGrd.Parameters.Add("P_DATE_FRM", OracleDbType.Date).Value = null;
            else
                cmdReadPayGrd.Parameters.Add("P_DATE_FRM", OracleDbType.Date).Value = objEntityVisaQuot.FromDate;
            if (objEntityVisaQuot.ToDate == DateTime.MinValue)
                cmdReadPayGrd.Parameters.Add("P_DATE_TO", OracleDbType.Date).Value = null;
            else
                cmdReadPayGrd.Parameters.Add("P_DATE_TO", OracleDbType.Date).Value = objEntityVisaQuot.ToDate;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public DataTable ReadVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISAQUOTA_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public void CancelVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CANCEL_VISA_QUOTA";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityVisaQuot.Cancel_Reason;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }


        public void UpDateVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_UPDCNFM_VISA_QUOTA";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("p_CONFMCHK", OracleDbType.Int32).Value = objEntityVisaQuot.ConfrmChkId;
                cmdReadPayGrd.Parameters.Add("P_ISSUEDATE", OracleDbType.Date).Value = objEntityVisaQuot.IssueDate;
                cmdReadPayGrd.Parameters.Add("P_EXPIRYDATE", OracleDbType.Date).Value = objEntityVisaQuot.ExpiryDate;
                cmdReadPayGrd.Parameters.Add("P_BUNDLE_NUM", OracleDbType.Varchar2).Value = objEntityVisaQuot.BundleNum;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                cmdReadPayGrd.Parameters.Add("P_VISATYP", OracleDbType.Int32).Value = objEntityVisaQuot.VisaTyp;
                cmdReadPayGrd.Parameters.Add("P_VISATYP_NUM", OracleDbType.Int32).Value = objEntityVisaQuot.NumVisa;
               


                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public void ReopenVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_REOPEN_VISA_QUOTA";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                //cmdReadPayGrd.Parameters.Add("p_CONFMCHK", OracleDbType.Int32).Value = objEntityVisaQuot.ConfrmChkId;
              //  cmdReadPayGrd.Parameters.Add("P_ISSUEDATE", OracleDbType.Date).Value = objEntityVisaQuot.IssueDate;
                //cmdReadPayGrd.Parameters.Add("P_EXPIRYDATE", OracleDbType.Date).Value = objEntityVisaQuot.ExpiryDate;
               // cmdReadPayGrd.Parameters.Add("P_BUNDLE_NUM", OracleDbType.Int32).Value = objEntityVisaQuot.BundleNum;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;


                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }


        public DataTable ReadEmailId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISAQUOTA_EMAIL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public DataTable ReadVisaquotaListForMail(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISAQUOTA_FOR_MAIL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityVisaQuot.dateNow;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void UpdVisaquotaMailSts(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_UPD_MAILSTATUS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                 cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;


                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }




        public void ReCallBundleNumber(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_RECALL_VISAQUOTA_BUNDL_NUM";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();


                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }



        public DataTable DuplCheckVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CHECK_VISAQUOTA_BUNDL_NUM";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_NUM", OracleDbType.Varchar2).Value = objEntityVisaQuot.BundleNum;
         
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public DataTable ReadVisaTypForRenew(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_READ_VISATYP_RENEW";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public DataTable DuplCheckVisaQuotaType(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CHECK_VISAQUOTA_VISATYP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_DTLID", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaDetailId;
            cmdReadPayGrd.Parameters.Add("P_TYP", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaTyp;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CTRYID", OracleDbType.Int32).Value = objEntityVisaQuot.CountryId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadVisaCountId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CHECK_VISATYP_COUNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
           // cmdReadPayGrd.Parameters.Add("P_DTLID", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaDetailId;
            cmdReadPayGrd.Parameters.Add("P_TYP", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaTyp;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadVisaDetailbyid(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "VISA_QUOTA.SP_CHECK_VISATYP_COUNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
           // cmdReadPayGrd.Parameters.Add("P_DTLID", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaDetailId;
            cmdReadPayGrd.Parameters.Add("P_TYP", OracleDbType.Varchar2).Value = objEntityVisaQuot.VisaTyp;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        
        
    }
}
