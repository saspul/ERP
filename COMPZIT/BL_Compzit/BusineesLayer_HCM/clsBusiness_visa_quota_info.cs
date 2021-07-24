using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_visa_quota_info
    {
        clsDataLayer_visa_quota_info objDataPayGrd = new clsDataLayer_visa_quota_info();
     
        public DataTable ReadVisaTyp(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaTyp(objEntityVisaQuot);
            return dtGuarnt;
        }
        public DataTable ReadSelectNations(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadSelectNations(objEntityVisaQuot);
            return dtGuarnt;
        }

        public DataTable ReadBussnsUnit(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadBussnsUnit(objEntityVisaQuot);
            return dtGuarnt;
        }

        public void AddVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
           
             objDataPayGrd.AddVisaQuota(objEntityVisaQuot);
        
        }

        public void AddVisaQuotaDetails(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.AddVisaQuotaDetails(objEntityVisaQuot);
        
        }

        public DataTable ReadVisaDetailsList(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaDetailsList(objEntityVisaQuot);
            return dtGuarnt;
        }

        public DataTable ReadVisaDetailsId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaDetailsId(objEntityVisaQuot);
            return dtGuarnt;
        }
        public void UpDateVisaQuotaDetails(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.UpDateVisaQuotaDetails(objEntityVisaQuot);

        }
        public void CancelVisaDtls(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.CancelVisaDtls(objEntityVisaQuot);

        }

        public DataTable ReadVisaquotaList(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaquotaList(objEntityVisaQuot);
            return dtGuarnt;
        }
        public DataTable ReadVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaQuota(objEntityVisaQuot);
            return dtGuarnt;
        }
        public void CancelVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.CancelVisaQuota(objEntityVisaQuot);

        }

        public void UpDateVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.UpDateVisaQuota(objEntityVisaQuot);

        }

        public void ReopenVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.ReopenVisaQuota(objEntityVisaQuot);

        }

        public DataTable ReadEmailId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadEmailId(objEntityVisaQuot);
            return dtGuarnt;
        }


        public DataTable ReadVisaquotaListForMail(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaquotaListForMail(objEntityVisaQuot);
            return dtGuarnt;
        }

        public void UpdVisaquotaMailSts(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.UpdVisaquotaMailSts(objEntityVisaQuot);

        }
        public object objEntityVisaQuot { get; set; }

        public void ReCallBundleNumber(clsEntity_visa_quota_info objEntityVisaQuot)
        {

            objDataPayGrd.ReCallBundleNumber(objEntityVisaQuot);

        }

        public DataTable DuplCheckVisaQuota(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.DuplCheckVisaQuota(objEntityVisaQuot);
            return dtGuarnt;
        }

        public DataTable ReadVisaTypForRenew(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaTypForRenew(objEntityVisaQuot);
            return dtGuarnt;
        }
        public DataTable DuplCheckVisaQuotaType(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.DuplCheckVisaQuotaType(objEntityVisaQuot);
            return dtGuarnt;
        }
        public DataTable ReadVisaCountId(clsEntity_visa_quota_info objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPayGrd.ReadVisaCountId(objEntityVisaQuot);
            return dtGuarnt;
        }
        
        
    }
}
