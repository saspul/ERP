using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayerDutyRejoin
    {
       clsDataLayerDutyRejoin objDataRejoin = new clsDataLayerDutyRejoin();
       public DataTable ReadRejoinList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           DataTable dtCountryList = objDataRejoin.ReadRejoinList(objEntityDutyRejoin);
           return dtCountryList;
       }
       public DataTable ReadConfirmList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           DataTable dtCountryList = objDataRejoin.ReadConfirmList(objEntityDutyRejoin);
           return dtCountryList;
       }
       public DataTable ReadRejectedList(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           DataTable dtCountryList = objDataRejoin.ReadRejectedList(objEntityDutyRejoin);
           return dtCountryList;
       }
       public void AddRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.AddRejoin(objEntityDutyRejoin);        
       }
       public void ConfirmRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.ConfirmRejoin(objEntityDutyRejoin);
       }
       public void ReporterConfirm(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.ReporterConfirm(objEntityDutyRejoin);
       }
       public void HRconfirm(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.HRconfirm(objEntityDutyRejoin);
       }
       public void RejectRejoin(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.RejectRejoin(objEntityDutyRejoin);
       }
       public DataTable ReportOfficerRead(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           DataTable dtCountryList = objDataRejoin.ReportOfficerRead(objEntityDutyRejoin);
           return dtCountryList;
       }
       public void ReporterConfirmReject(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           objDataRejoin.ReporterConfirmReject(objEntityDutyRejoin);
       }
       public DataTable ReadLeaveDetails(clsEntityLayerDutyRejoin objEntityDutyRejoin)
       {
           DataTable dtCountryList = objDataRejoin.ReadLeaveDetails(objEntityDutyRejoin);
           return dtCountryList;
       }
       public void updateLeaveInfo(string[] arrLEave)
       {
           objDataRejoin.updateLeaveInfo(arrLEave);
       }
       public void InsertUserLeavTyp(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           objDataRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
       }
    }
}
