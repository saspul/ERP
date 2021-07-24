using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLeaveRequest
    {
       clsDataLayerLeaveRequest objDataLeaveRequest = new clsDataLayerLeaveRequest();
       public DataTable ReadLeavTypdtl(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.ReadLeavTypdtl(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public DataTable CheckTrvlDtlShow(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.CheckTrvlDtlShow(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public DataTable ReadFmlyDtls(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.ReadFmlyDtls(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public void AddLeavReqstDetails(clsEntityLeaveRequest objEntityLeaveRequest,string[] strarrDepntIds)
       {
           objDataLeaveRequest.AddLeavReqstDetails(objEntityLeaveRequest, strarrDepntIds);

       }
       public DataTable ReadCity(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.ReadCity(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public DataTable ReadLeaveRqstList(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.ReadLeaveRqstList(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public DataTable ReadLeaveRqstById(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable dtReadLeav = objDataLeaveRequest.ReadLeaveRqstById(objEntityLeaveRequest);
           return dtReadLeav;
       }
       public DataTable ReadRemLeav(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadDepntIds(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadDepntIds(objEntityLeaveRequest);
           return count;
       }
       public void UpdateLeaveRqstDtls(clsEntityLeaveRequest objEntityLeaveRequest, string[] strarrDepntIds)
       {
           objDataLeaveRequest.UpdateLeaveRqstDtls(objEntityLeaveRequest, strarrDepntIds);

       }
       public void InsertUserNewLevRow(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           objDataLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);

       }
       public string confmAllocnCount(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           string count = objDataLeaveRequest.confmAllocnCount(objEntityLeaveRequest);
           return count;
       }
       public DataTable FrmSgleDate(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.FrmSgleDate(objEntityLeaveRequest);
           return count;
       }
       public void ConfirmLeavAllocnDtl(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           objDataLeaveRequest.ConfirmLeavAllocnDtl(objEntityLeaveRequest);

       }
       public string chkUserLevCount(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           string count = objDataLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
           return count;
       }
       public void InsertUserLeavTyp(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           objDataLeaveRequest.InsertUserLeavTyp(objEntityLeaveRequest);

       }
       public string chkUserToLevCount(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           string count = objDataLeaveRequest.chkUserToLevCount(objEntityLeaveRequest);
           return count;
       }
       public void CancelRqst(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           objDataLeaveRequest.CancelRqst(objEntityLeaveRequest);

       }
       public DataTable CheckEmpType(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.CheckEmpType(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadUserDetails(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadUserDetails(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadGendrMrtSts(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadGendrMrtSts(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadDesgDtls(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadDesgDtls(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadPayGrdedtls(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadPayGrdedtls(objEntityLeaveRequest);
           return count;
       }
       public DataTable ReadExpDtls(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ReadExpDtls(objEntityLeaveRequest);
           return count;
       }
       public DataTable ChkDatesInLeavReqst(clsEntityLeaveRequest objEntityLeaveRequest)
       {

           DataTable count = objDataLeaveRequest.ChkDatesInLeavReqst(objEntityLeaveRequest);
           return count;
       }
       public void DeleteUSerLeaveTypes(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           objDataLeaveRequest.DeleteUSerLeaveTypes(objEntityLeaveRequest);

       }

       public DataTable CheckReportOffcr(clsEntityLeaveRequest objEntityLeaveRequest)
       {
           DataTable count = objDataLeaveRequest.CheckReportOffcr(objEntityLeaveRequest);
           return count;
       }
    }
}
