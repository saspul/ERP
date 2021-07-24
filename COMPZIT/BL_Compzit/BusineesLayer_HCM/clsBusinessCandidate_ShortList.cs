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
   public class clsBusinessCandidate_ShortList
    {
       clsDatalayerCandidate_ShortList objDataShortlist = new clsDatalayerCandidate_ShortList();

        public DataTable ReadDivision(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtDiv = objDataShortlist.ReadDivision(objEntityShortList);
           return dtDiv;
       }
        public DataTable ReadDepartment(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtDpt = objDataShortlist.ReadDepartment(objEntityShortList);
           return dtDpt;
       }
        public DataTable ReadDesignation(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtDesig = objDataShortlist.ReadDesignation(objEntityShortList);
           return dtDesig;
       }
       public DataTable ReadConsultancies(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtConsult = objDataShortlist.ReadConsultancies(objEntityShortList);
           return dtConsult;
       }
       public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtList = objDataShortlist.ReadAprvdManPwrReqstList(objEntityShortList);
           return dtList;
       }
       public DataTable ReadAprvdManPwrReqstListByid(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtList = objDataShortlist.ReadAprvdManPwrReqstListByid(objEntityShortList);
           return dtList;
       }
        public DataTable ReadProject(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.ReadProject(objEntityShortList);
           return dtPrj;
       }
        public DataTable ReadCandidates(clsEntityLayer_Candidate_ShortList objEntityShortList)
        {
            DataTable dtPrj = objDataShortlist.ReadCandidates(objEntityShortList);
            return dtPrj;
        }
       // public DataTable ReadCandidates(clsEntityLayer_Candidate_ShortList objEntityShortList)
     //   {
      //      DataTable dtPrj = objDataShortlist.ReadCandidates(objEntityShortList);
       //     return dtPrj;
    //    }
        public void AddCandidateShortList(clsEntityLayer_Candidate_ShortList objEntityShortList, List<ShortListedCandiate> objlistShortList)
        {
            objDataShortlist.AddShortList(objEntityShortList, objlistShortList);

        }
        public void UpdateCandidateShortList(CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment)
        {
            //objDataShortlist.UpdateManpowerRecruitment(ObjEntityManpowerRecruitment);
        }
        public void ChangeStatus(clsEntityLayer_Candidate_ShortList objEntityShortList)
        {
            objDataShortlist.ChangeStatus(objEntityShortList);
        }
        public DataTable ReadSelected_Candidates(clsEntityLayer_Candidate_ShortList objEntityShortList)
       {
           DataTable dtDiv = objDataShortlist.ReadSelected_Candidates(objEntityShortList);
           return dtDiv;
       }


        public void UpdateShortlist(clsEntityLayer_Candidate_ShortList objEntityShortList, List<ShortListedCandiate> objlistShortList)
        {
           objDataShortlist.UpdateShortlist(objEntityShortList, objlistShortList);
           
        }
        public void ConfirmEntries(clsEntityLayer_Candidate_ShortList objEntityShortList)
        {
            objDataShortlist.ConfirmEntries(objEntityShortList);

        }
        public void ConfirmCandidateId(clsEntityLayer_Candidate_ShortList objEntityShortList)
        {
            objDataShortlist.ConfirmCandidateId(objEntityShortList);

        }
    }
    
}
