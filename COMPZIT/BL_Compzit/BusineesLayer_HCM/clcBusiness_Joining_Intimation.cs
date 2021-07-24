using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit
{
   public class clcBusiness_Joining_Intimation
    {

       clsDataLayer_Joining_Intimation objDataShortlist = new clsDataLayer_Joining_Intimation();

       public DataTable ReadDivision(clsEntity_Joining_Intimation objEntityShortList)
        {
            DataTable dtDiv = objDataShortlist.ReadDivision(objEntityShortList);
            return dtDiv;
        }
       public DataTable ReadDepartment(clsEntity_Joining_Intimation objEntityShortList)
        {
            DataTable dtDpt = objDataShortlist.ReadDepartment(objEntityShortList);
            return dtDpt;
        }
       public DataTable ReadProject(clsEntity_Joining_Intimation objEntityShortList)
        {
            DataTable dtPrj = objDataShortlist.ReadProject(objEntityShortList);
            return dtPrj;
        }

       public DataTable ReadJoingReqrmntList(clsEntity_Joining_Intimation objEntityShortList)
        {
            DataTable dtPrj = objDataShortlist.ReadJoingReqrmntList(objEntityShortList);
            return dtPrj;
        }
       public DataTable ReadAprvdManPwrReqstListByid(clsEntity_Joining_Intimation objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.ReadAprvdManPwrReqstListByid(objEntityShortList);
           return dtPrj;
       }
       public DataTable ReadCandidates(clsEntity_Joining_Intimation objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.ReadCandidates(objEntityShortList);
           return dtPrj;
       }
       public DataTable ReadCandidatesReport(clsEntity_Joining_Intimation objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.ReadCandidatesReport(objEntityShortList);
           return dtPrj;
       }

       public DataTable ReadSelected_Candidates(clsEntity_Joining_Intimation objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.ReadSelected_Candidates(objEntityShortList);
           return dtPrj;
       }
       public DataTable EmailIdFetch(SelectedCandiate objEntityShortList)
       {
           DataTable dtPrj = objDataShortlist.EmailIdFetch(objEntityShortList);
           return dtPrj;
       }


       public void EmailStsUpdate(SelectedCandiate objEntityShortList)
       {
    objDataShortlist.EmailStsUpdate(objEntityShortList);
        
       }
       //update joining status evm-0019 Start
       public void UpdJoinStatus(SelectedCandiate objEntityShortList)
       {
           objDataShortlist.UpdJoinStatus(objEntityShortList);

       }//evm-0019 end

       public DataTable ReadLeaveTyp(clsEntity_Joining_Intimation objEntityShortlist)
       {
           DataTable dtPrj = objDataShortlist.ReadLeaveTyp(objEntityShortlist);
           return dtPrj;
       }

       public DataTable ReadNoticePeriod(clsEntity_Joining_Intimation objEntityShortlist)
       {
           DataTable dtPrj = objDataShortlist.ReadNoticePeriod(objEntityShortlist);
           return dtPrj;
       }

       public void UpdJoinDate(SelectedCandiate objEntityShortlist)
       {
           objDataShortlist.UpdJoinDate(objEntityShortlist);
       }

       public DataTable ReadJobDescrptn(clsEntity_Joining_Intimation objEntityShortlist)
       {
           DataTable dtPrj = objDataShortlist.ReadJobDescrptn(objEntityShortlist);
           return dtPrj;
       }

       public DataTable ReadAppointmtParamtrs(clsEntity_Joining_Intimation objEntityShortlist)
       {
           DataTable dtPrj = objDataShortlist.ReadAppointmtParamtrs(objEntityShortlist);
           return dtPrj;
       }



    }
}
