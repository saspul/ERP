using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusiness_Candidate_Login
    {
       clsData_Candidate_Login objDataShortlist = new clsData_Candidate_Login();

       public void AddLogin(clsEntityCandidatelogin objEntityShortList)
        {
            objDataShortlist.AddLogin(objEntityShortList);
         
        }
       public DataTable Readlogin(clsEntityCandidatelogin objEntityShortList)
        {
            DataTable dtDpt = objDataShortlist.Readlogin(objEntityShortList);
            return dtDpt;
        }
       public DataTable ReadCandidates(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadCandidates(objEntityShortList);
           return dtDpt;
       }

       public DataTable Checklogin(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.Checklogin(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadRegisteredCandidates(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadRegisteredCandidates(objEntityShortList);
           return dtDpt;
       }

       public void UpdateCandidatesId(clsEntityCandidatelogin objEntityShortList)
       {
          // DataTable dtDpt = objDataShortlist.UpdateCandidatesId(objEntityShortList);
           clsData_Candidate_Login ObjDataCandDtls = new clsData_Candidate_Login();
           ObjDataCandDtls.UpdateCandidatesId(objEntityShortList);
         
       }
       public void UpdateCnfrmSts(clsEntityCandidatelogin objEntityCandloging)
       {
           clsData_Candidate_Login objDataLayerCandloging = new clsData_Candidate_Login();
           objDataLayerCandloging.UpdateCnfrmSts(objEntityCandloging);
       }

       //EVM-0027
       public DataTable ReadStaffDetails(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadStaffDetails(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadCorpDtls(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadCorpDtls(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadLanguageDetails(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadLanguageDetails(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadExperienceDetails(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadExperienceDetails(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadQualification(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadQualification(objEntityShortList);
           return dtDpt;
       }
       public DataTable ReadDepentantDetails(clsEntityCandidatelogin objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadDepentantDetails(objEntityShortList);
           return dtDpt;
       }
        //END
    }
}
