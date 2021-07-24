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
   public class clsBusinessInterviewEvaltnReport
    {

       clsDataLayerInterviewEvaltnReport objDataOnBoarding_Status = new clsDataLayerInterviewEvaltnReport();

        //read man power reqst onboarding 
        public DataTable ReadAprvdManpwrRqst(clsEntityInterviewEvaltnReport objEntityLayerOnBoarding_Status)
        {
            DataTable dtAprvdManPwr = new DataTable();
            dtAprvdManPwr = objDataOnBoarding_Status.ReadAprvdManpwrRqst(objEntityLayerOnBoarding_Status);
            return dtAprvdManPwr;
        }
    }
}
