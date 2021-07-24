using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
 public  class clsBusinessVisaQuotaStatusReport
    {
     clsDataLayerVisaQuotaStatusReport objDataVisaQuota = new clsDataLayerVisaQuotaStatusReport();
     public DataTable ReadVisaTyp(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataVisaQuota.ReadVisaTyp(objEntityVisaQuot);
            return dtGuarnt;
        }
     public DataTable ReadBundleNumber(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
     {
         DataTable dtGuarnt = new DataTable();
         dtGuarnt = objDataVisaQuota.ReadBundleNumber(objEntityVisaQuot);
         return dtGuarnt;
     }

     public DataTable ReadSelectNations(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataVisaQuota.ReadSelectNations(objEntityVisaQuot);
            return dtGuarnt;
        }

     public DataTable ReadBussnsUnit(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataVisaQuota.ReadBussnsUnit(objEntityVisaQuot);
            return dtGuarnt;
        }

     public DataTable ReadVisaQuotaStatus(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
     {
         DataTable dtGuarnt = new DataTable();
         dtGuarnt = objDataVisaQuota.ReadVisaQuotaStatus(objEntityVisaQuot);
         return dtGuarnt;
     }
     public DataTable ReadCount(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
     {
         DataTable dtGuarnt = new DataTable();
         dtGuarnt = objDataVisaQuota.ReadCount(objEntityVisaQuot);
         return dtGuarnt;
     }
     public DataTable ReadCorporateAddress(clsEntityVisaQuotaStatusReport objEntityReqrmntAlctn)
     {
         DataTable dtCorp = new DataTable();
         dtCorp = objDataVisaQuota.ReadCorporateAddress(objEntityReqrmntAlctn);
         return dtCorp;
     }
    }
}
