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
    public class clsBusiness_LeaveFacltyAssmntList
    {
        clsData_LeaveFacltyAssmntList objLeavFacltyAssmnt = new clsData_LeaveFacltyAssmntList();
        public DataTable ReadEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployee(objEntityOnBoarding);
            return dtDetail;
        }

        public DataTable ReadLevEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadLevEmployee(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReademplydtlsNotAssgnd(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReademplydtlsNotAssgnd(objEntityOnBoarding);
            return dtDetail;
        }

        public DataTable ReadDivisionOfEmp(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadDivisionOfEmp(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadEmployeesList(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployeesList(objEntityOnBoarding);
            return dtDetail;
        }

        public int Insert_LeaveFacltyAssmnt(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            int dtDetail = objLeavFacltyAssmnt.Insert_LeaveFacltyAssmnt(objEntityOnBoarding);
            return dtDetail;
        }

        public void Insert_Process_Detail(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingFlight, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingRoom, clsEntity_LeaveFacltyAssmntList objEntityOnBoardingAir, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList2, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList3, List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList4, string FlihtChk)
        {
            objLeavFacltyAssmnt.Insert_Process_Detail(objEntityOnBoarding, objEntityOnBoardingFlight, objEntityOnBoardingRoom, objEntityOnBoardingAir, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4, FlihtChk);
        }


        public DataTable ReadLevEmplyById(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadLevEmplyById(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadFlightDetailByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadFlightDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }

        public DataTable ReadEmpByLeavAssmntDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmpByLeavAssmntDtl(objEntityOnBoarding);
            return dtDetail;
        }


        public DataTable ReadSettlmentByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadSettlmentByCandId(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadExitProcssByCandId(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadExitProcssByCandId(objEntityOnBoarding);
            return dtDetail;
        }
        public void UpdateFlightDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateFlightDtl(objEntityOnBoarding);
            
        }
        public void UpdateSettlmentDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateSettlmentDtl(objEntityOnBoarding);

        }
        public void UpdateExitProcssDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateExitProcssDtl(objEntityOnBoarding);

        }
        public void DeleteEmployee(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.DeleteEmployee(objEntityOnBoarding);

        }
        public void InsertEmployee(List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.InsertEmployee(objEntityOnBoarding);

        }

        public void RecallProcess(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.RecallProcess(objEntityOnBoarding);

        }

        public DataTable ReadStaffdtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadStaffdtl(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable ReadWorkerDtl(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadWorkerDtl(objEntityOnBoarding);
            return dtDetail;
        }
        public DataTable CheckStatusBefrEdit1(clsEntity_LeaveFacltyAssmntList objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.CheckStatusBefrEdit1(objEntityOnBoarding);
            return dtDetail;
        }
        
        
        
        
    }
}
