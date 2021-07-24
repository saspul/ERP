using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayerNoticePeriod
    {
       clsDataLayerNoticePeriod objDataLayerNoticePeriod = new clsDataLayerNoticePeriod();
       public DataTable ReadDesgntn( clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayerNoticePeriod.ReadDesgntn(objEntityNoticePeriod);
            return dtInterviewCatList;
        }
       public DataTable CheckDuplctn(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {
           DataTable dtInterviewCatList = new DataTable();
           dtInterviewCatList = objDataLayerNoticePeriod.CheckDuplctn(objEntityNoticePeriod);
           return dtInterviewCatList;
       }
       public DataTable ReadNoticePrdDtlsById(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {
           DataTable dtInterviewCatList = new DataTable();
           dtInterviewCatList = objDataLayerNoticePeriod.ReadNoticePrdDtlsById(objEntityNoticePeriod);
           return dtInterviewCatList;
       }
       public DataTable ReadNoticePrdList(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {
           DataTable dtInterviewCatList = new DataTable();
           dtInterviewCatList = objDataLayerNoticePeriod.ReadNoticePrdList(objEntityNoticePeriod);
           return dtInterviewCatList;
       }
       public void AddNoticePrdDtls(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {

           objDataLayerNoticePeriod.AddNoticePrdDtls(objEntityNoticePeriod);
       }
       public void UpdateNoticePrd(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {

           objDataLayerNoticePeriod.UpdateNoticePrd(objEntityNoticePeriod);
       }
       public void CancelNoticePrdDtls(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {

           objDataLayerNoticePeriod.CancelNoticePrdDtls(objEntityNoticePeriod);
       }
       public void ChangeStatus(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {

           objDataLayerNoticePeriod.ChangeStatus(objEntityNoticePeriod);
       }
       public DataTable CheckExtProcess(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {
           DataTable dtInterviewCatList = new DataTable();
           dtInterviewCatList = objDataLayerNoticePeriod.CheckExtProcess(objEntityNoticePeriod);
           return dtInterviewCatList;
       }

       public DataTable ReadNoticePrdAllocationList(clsEntityLayerNoticePeriod objEntityNoticePeriod)
       {
           DataTable dtInterviewCatList = new DataTable();
           dtInterviewCatList = objDataLayerNoticePeriod.ReadNoticePrdAllocationList(objEntityNoticePeriod);
           return dtInterviewCatList;
       }

    }
}
