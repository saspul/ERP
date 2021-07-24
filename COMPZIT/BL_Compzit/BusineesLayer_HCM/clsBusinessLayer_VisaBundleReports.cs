using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayer_VisaBundleReports
    {
        public DataTable ReadVisaQuota(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            clsDataLayer_VisaBundleReports objDataVisaBundle = new clsDataLayer_VisaBundleReports();
            DataTable dtVisaQuota = new DataTable();
            dtVisaQuota = objDataVisaBundle.ReadVisaQuota(objEntityLayerVisaBundle);
            return dtVisaQuota;
        }


        public DataTable ReadVisaQuotaById(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            clsDataLayer_VisaBundleReports objDataVisaBundle = new clsDataLayer_VisaBundleReports();
            DataTable dtVisaQuotaId = new DataTable();
            dtVisaQuotaId = objDataVisaBundle.ReadVisaQuotaById(objEntityLayerVisaBundle);
            return dtVisaQuotaId;
        }


        public DataTable ReadVisaDetailsById(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            clsDataLayer_VisaBundleReports objDataVisaBundle = new clsDataLayer_VisaBundleReports();
            DataTable dtVisaDtls = new DataTable();
            dtVisaDtls = objDataVisaBundle.ReadVisaDetailsById(objEntityLayerVisaBundle);
            return dtVisaDtls;
        }


        public DataTable ReadCorporateAddress(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            clsDataLayer_VisaBundleReports objDataVisaBundle = new clsDataLayer_VisaBundleReports();
            DataTable dtCorp = new DataTable();
            dtCorp = objDataVisaBundle.ReadCorporateAddress(objEntityLayerVisaBundle);
            return dtCorp;

        }






    }
}
