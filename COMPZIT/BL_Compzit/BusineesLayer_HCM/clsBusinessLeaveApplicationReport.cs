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
   public class clsBusinessLeaveApplicationReport
    {
       clsDataLayerLeaveApplicationReport objDataOnBoarding_Status = new clsDataLayerLeaveApplicationReport();
       public DataTable ReadLeaveType(clsEntityLeaveApplicationReport objEntityLayerOnBoarding_Status)
        {
            DataTable dtAprvdManPwr = new DataTable();
            dtAprvdManPwr = objDataOnBoarding_Status.ReadLeaveType(objEntityLayerOnBoarding_Status);
            return dtAprvdManPwr;
        }
       public DataTable ReadListReport(clsEntityLeaveApplicationReport objEntityLayerOnBoarding_Status)
       {
           DataTable dtAprvdManPwr = new DataTable();
           dtAprvdManPwr = objDataOnBoarding_Status.ReadListReport(objEntityLayerOnBoarding_Status);
           return dtAprvdManPwr;
       }
    }
}
