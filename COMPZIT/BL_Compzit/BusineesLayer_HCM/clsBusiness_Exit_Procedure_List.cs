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
   public class clsBusiness_Exit_Procedure_List
    {

       clsDataLayer_Exit_Procedure_List objLeavFacltyAssmnt = new clsDataLayer_Exit_Procedure_List();
       public DataTable ReadEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployee(objEntityOnBoarding);
            return dtDetail;
        }

       public DataTable ReadLevEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadLevEmployee(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReademplydtlsNotAssgnd(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReademplydtlsNotAssgnd(objEntityOnBoarding);
            return dtDetail;
        }

       public DataTable ReadDivisionOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadDivisionOfEmp(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadEmployeesList(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmployeesList(objEntityOnBoarding);
            return dtDetail;
        }

       public int Insert_LeaveFacltyAssmnt(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            int dtDetail = objLeavFacltyAssmnt.Insert_LeaveFacltyAssmnt(objEntityOnBoarding);
            return dtDetail;
        }

       public void Insert_Process_Detail(clsEntity_Exit_Procedure_List objEntityOnBoarding, clsEntity_Exit_Procedure_List objEntityOnBoardingFlight, clsEntity_Exit_Procedure_List objEntityOnBoardingRoom, clsEntity_Exit_Procedure_List objEntityOnBoardingAir, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList2, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList3, List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList4)
        {
            objLeavFacltyAssmnt.Insert_Process_Detail(objEntityOnBoarding, objEntityOnBoardingFlight, objEntityOnBoardingRoom, objEntityOnBoardingAir, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4);
        }


       public DataTable ReadLevEmplyById(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadLevEmplyById(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadFlightDetailByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadFlightDetailByCandId(objEntityOnBoarding);
            return dtDetail;
        }

       public DataTable ReadEmpByLeavAssmntDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadEmpByLeavAssmntDtl(objEntityOnBoarding);
            return dtDetail;
        }


       public DataTable ReadSettlmentByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadSettlmentByCandId(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadExitProcssByCandId(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.ReadExitProcssByCandId(objEntityOnBoarding);
            return dtDetail;
        }
       public void UpdateFlightDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateFlightDtl(objEntityOnBoarding);

        }
       public void UpdateSettlmentDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateSettlmentDtl(objEntityOnBoarding);

        }
       public void UpdateExitProcssDtl(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.UpdateExitProcssDtl(objEntityOnBoarding);

        }
       public void DeleteEmployee(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.DeleteEmployee(objEntityOnBoarding);

        }
       public void InsertEmployee(List<clsEntity_Exit_Procedure_List> objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.InsertEmployee(objEntityOnBoarding);

        }

       public void RecallProcess(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            objLeavFacltyAssmnt.RecallProcess(objEntityOnBoarding);

        }

  


       public DataTable CheckStatusBefrEdit1(clsEntity_Exit_Procedure_List objEntityOnBoarding)
        {
            DataTable dtDetail = objLeavFacltyAssmnt.CheckStatusBefrEdit1(objEntityOnBoarding);
            return dtDetail;
        }
       public DataTable ReadClearanceOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadClearanceOfEmp(objEntityOnBoarding);
           return dtDetail;
       }
       //EVM-0024
       public DataTable ReadSettlementOfEmp(clsEntity_Exit_Procedure_List objEntityOnBoarding)
       {
           DataTable dtDetail = objLeavFacltyAssmnt.ReadSettlementOfEmp(objEntityOnBoarding);
           return dtDetail;
       }
    }
}
