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
    public class clsBusinessLayerOnBoardingPartialProcess
    {
        clsDataLayerOnBoardingPartialProcess objDataPartialProcess = new clsDataLayerOnBoardingPartialProcess();

        public DataTable ReadReqrmtLoad(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadReqrmtLoad(objEntityPartialProcess);
            return dtDiv;
        }
        public DataTable ReadAssignedProcessList(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadAssignedProcessList(objEntityPartialProcess);
            return dtDiv;
        }
        public DataTable ReadEmpInfoById(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadEmpInfoById(objEntityPartialProcess);
            return dtDiv;
        }
        public DataTable ReadEmpPrtclrInfoById(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadEmpPrtclrInfoById(objEntityPartialProcess);
            return dtDiv;
        }
        public void addVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.addVisa(objEntityPartialProcess);
        }
        public void addFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.addFlight(objEntityPartialProcess);
        }
        public void addRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.addRoom(objEntityPartialProcess);
        }
        public void CloseVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.CloseVisa(objEntityPartialProcess);
        }
        public void CloseFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.CloseFlight(objEntityPartialProcess);
        }
        public void CloseRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.CloseRoom(objEntityPartialProcess);
        }
        public void CloseAirpt(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.CloseAirpt(objEntityPartialProcess);
        }
        public void finishVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess, string visadtlID, string visaID)
        {
            objDataPartialProcess.finishVisa(objEntityPartialProcess, visadtlID, visaID);
        }

        public void finishVisaStatus(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.finishVisaStatus(objEntityPartialProcess);
        }
        public void finishFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.finishFlight(objEntityPartialProcess);
        }
        public void finishRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.finishRoom(objEntityPartialProcess);
        }
        public void finishAirpt(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            objDataPartialProcess.finishAirpt(objEntityPartialProcess);
        }
        public DataTable ReadAsgndEmpPartclr(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadAsgndEmpPartclr(objEntityPartialProcess);
            return dtDiv;
        }

        public DataTable checkFinishOrClsed(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
            return dtDiv;
        }

        public DataTable ReadVisaQuota(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
        {
            DataTable dtDiv = objDataPartialProcess.ReadVisaQuota(objEntityPartialProcess);
            return dtDiv;
        }
        public DataTable ReadVisaQuota(clsEntityOnBoardingPartialProcess objEntityPartialProcess,int intvisatyp,int intNationId)
        {
            DataTable dtDiv = objDataPartialProcess.ReadVisaQuota(objEntityPartialProcess, intvisatyp, intNationId);
            return dtDiv;
        }
        public DataTable ReadVisaDetails(string VisaqtID, string CntryNm)
        {
            DataTable dtDiv = objDataPartialProcess.ReadVisaDetails(VisaqtID, CntryNm);
            return dtDiv;
        }
        
    }
}
