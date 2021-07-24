using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0012
// CREATED DATE:28/03/2017
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerTrafficViolationSettlement
    {
        clsDataLayerTrafficViolationSettlement objDataTrafficViolationSettlement = new clsDataLayerTrafficViolationSettlement();
        public DataTable ReadViolations(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            DataTable dtViolations = objDataTrafficViolationSettlement.ReadViolations(objEntityTrafficViolation);
            return dtViolations;
        }
         // This Method will fetch Pending Violations By Vehicle ID
        public DataTable ReadViolationsByVehID(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            DataTable dtViolationsByVehID = objDataTrafficViolationSettlement.ReadViolationsByVehID(objEntityTrafficViolation);
            return dtViolationsByVehID;
        }
        // This Method will fetch Employees
        public DataTable ReadEmployees(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            DataTable dtEmployees = objDataTrafficViolationSettlement.ReadEmployees(objEntityTrafficViolation);
            return dtEmployees;
        }
        // THIS METHOD WILL UPDATE TRAFFIC VIOLATIONS
        public void Update_TrafficVioltn(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            objDataTrafficViolationSettlement.Update_TrafficVioltn(objEntityLayerTrafficVltn, objEntityLayerSettleList);
        }
        // This Method will fetch Settled Violations
        public DataTable ReadSettledViolations(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            DataTable dtViolations = objDataTrafficViolationSettlement.ReadSettledViolations(objEntityTrafficViolation);
            return dtViolations;
        }
        // This Method will fetch VEHICLE No  and in case of Settled entry Details are fetched
        public DataTable ReadVehicleNoDtl(clsEntityTrafficViolationSettlement objEntityTrafficViolation)
        {
            DataTable dtViolations = objDataTrafficViolationSettlement.ReadVehicleNoDtl(objEntityTrafficViolation);
            return dtViolations;
        }
        //CONFIRM
        public void ConfirmSettlement(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            objDataTrafficViolationSettlement.ConfirmSettlement(objEntityLayerTrafficVltn, objEntityLayerSettleList);

        }
        //ReOpen Traffic Violation
        public void ReOpenTrafficViolation(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            objDataTrafficViolationSettlement.ReOpenTrafficViolation(objEntityLayerTrafficVltn, objEntityLayerSettleList);

        }
       
        //Cancel Traffic Violation By List
        public void CancelTrafficViolationByList(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn, List<clsEntityLayerSettleList> objEntityLayerSettleList)
        {
            objDataTrafficViolationSettlement.CancelTrafficViolationByList(objEntityLayerTrafficVltn, objEntityLayerSettleList);

        }
        //Check Dup ReceiptNo
        public DataTable CheckDupReceiptNo(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn)
        {
            DataTable dtReceiptDtl = objDataTrafficViolationSettlement.CheckDupReceiptNo(objEntityLayerTrafficVltn);
            return dtReceiptDtl;
        }
        public DataTable CheckDupReceiptNoByID(clsEntityTrafficViolationSettlement objEntityLayerTrafficVltn)
        {
            DataTable dtReceiptDtl = objDataTrafficViolationSettlement.CheckDupReceiptNoByID(objEntityLayerTrafficVltn);
            return dtReceiptDtl;
        }
    }
}
