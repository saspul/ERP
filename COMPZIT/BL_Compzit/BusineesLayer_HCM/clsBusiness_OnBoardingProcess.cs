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
    public class clsBusiness_OnBoardingProcess
    {
        clsDataLayer_OnBoardingProcess objDataOnBoard = new clsDataLayer_OnBoardingProcess();
        public DataTable ReadAprvdManPwrReqstList(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadAprvdManPwrReqstList(objEntityOnBoarding);
            return dtDetail;
        }

        public DataTable ReadCandidates(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadCandidates(objEntityOnBoarding);
            return dtDetail;
        }

        public DataTable ReadVisaType(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaType(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadEmployee(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadEmployee(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadVehicle(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVehicle(objEntityOnBoarding);
            return dtDetail;
        }
        public int Insert_OnBoardProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            int id = objDataOnBoard.Insert_OnBoardProcess(objEntityOnBoarding);
            return id;
        }

        public void Insert_Process_Detail(ClsEntityOnBoardingProcess objEntityOnBoarding, ClsEntityOnBoardingProcess objEntityOnBoardingVisa, ClsEntityOnBoardingProcess objEntityOnBoardingFlight, ClsEntityOnBoardingProcess objEntityOnBoardingRoom, ClsEntityOnBoardingProcess objEntityOnBoardingAir, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList1, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList2, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList3, List<ClsEntityOnBoardingProcess> objEntityOnBoardVisaEmpList4)
        {
            objDataOnBoard.Insert_Process_Detail(objEntityOnBoarding, objEntityOnBoardingVisa, objEntityOnBoardingFlight, objEntityOnBoardingRoom, objEntityOnBoardingAir, objEntityOnBoardVisaEmpList1, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4);
        }

        public DataTable ReadCandidateById(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadCandidateById(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadVisaDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadFlightDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadFlightDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadRoomDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadRoomDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadAirDetailByCandId(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadAirDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }
         public DataTable ReadEmpByBoardDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadEmpByBoardDtl(objEntityOnBoarding);
            return dtDetail;
        }

         public void UpdateVisaDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
         {
             objDataOnBoard.UpdateVisaDtl(objEntityOnBoarding);
         }
         public void UpdateFlightDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
         {
             objDataOnBoard.UpdateFlightDtl(objEntityOnBoarding);
         }
        public void UpdateRoomDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
         {
             objDataOnBoard.UpdateRoomDtl(objEntityOnBoarding);
         }
        public void UpdateAirDtl(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            objDataOnBoard.UpdateAirDtl(objEntityOnBoarding);
        }
        public void DeleteEmployee(ClsEntityOnBoardingProcess objEntityOnBoarding)
       {
           objDataOnBoard.DeleteEmployee(objEntityOnBoarding);
       }

         public void InsertEmployee(List<ClsEntityOnBoardingProcess> objEntityOnBoardingList)
        {
            objDataOnBoard.InsertEmployee(objEntityOnBoardingList);
        }

         public void RecallProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
         {
             objDataOnBoard.RecallProcess(objEntityOnBoarding);
         }
         public void CloseProcess(ClsEntityOnBoardingProcess objEntityOnBoarding)
         {
             objDataOnBoard.CloseProcess(objEntityOnBoarding);
         }
      
             public DataTable ReadVisaBundle(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaBundle(objEntityOnBoarding);
            return dtDetail;
        }
             public DataTable ReadVisaBundleType(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaBundleType(objEntityOnBoarding);
            return dtDetail;
        }
             public DataTable ReadVisaTypeCount(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaTypeCount(objEntityOnBoarding);
            return dtDetail;
        }
             public DataTable ReadVisaDetailbyid(ClsEntityOnBoardingProcess objEntityOnBoarding)
        {
            DataTable dtDetail = objDataOnBoard.ReadVisaDetailbyid(objEntityOnBoarding);
            return dtDetail;
        }
        
    }
}
