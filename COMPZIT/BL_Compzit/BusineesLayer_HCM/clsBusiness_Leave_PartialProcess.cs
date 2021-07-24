using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Leave_PartialProcess
    {
        clsDataLayer_Leave_PartialProcess objDataLeavePartialPrcs=new clsDataLayer_Leave_PartialProcess();

        //read employee to dropdown
        public DataTable ReadToddlEmployee(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavePartialPrcs.ReadToddlEmployee(objEntityLayerLeavePartialPrcs);
            return dtEmp;
        }

        //read employee details to table
        public DataTable ReadEmployeeLeave(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataLeavePartialPrcs.ReadEmployeeLeave(objEntityLayerLeavePartialPrcs);
            return dtEmp;
        }

        //read division by employee id
        public DataTable ReadDivsnEmp(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtDivEmp = new DataTable();
            dtDivEmp = objDataLeavePartialPrcs.ReadDivsnEmp(objEntityLayerLeavePartialPrcs);
            return dtDivEmp;
        }

        //read Employee Dtls By levid
        public DataTable ReadallAssignstatus(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = objDataLeavePartialPrcs.ReadallAssignstatus(objEntityLayerLeavePartialPrcs);
            return dtEmpDtlsById;
        }

        //read Employee Particular Dtls By Id
        public DataTable ReadEmpDtlsByLevId(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = objDataLeavePartialPrcs.ReadEmpDtlsByLevId(objEntityLayerLeavePartialPrcs);
            return dtEmpDtlsById;
        }

        //update ticket status
        public void updTicktSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.updTicktSts(objEntityLayerLeavePartialPrcs);
        }

        //update settlement status
        public void updSettlmtSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.updSettlmtSts(objEntityLayerLeavePartialPrcs);
        }

        //read finished or closed
        public DataTable ReadFinishdOrClosd(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            DataTable dtCheckdOrClosd = new DataTable();
            dtCheckdOrClosd = objDataLeavePartialPrcs.ReadFinishdOrClosd(objEntityLayerLeavePartialPrcs);
            return dtCheckdOrClosd;
        }

        //update exit process status
        public void updExitSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.updExitSts(objEntityLayerLeavePartialPrcs);
        }

        //close ticket
        public void closeTicket(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.closeTicket(objEntityLayerLeavePartialPrcs);
        }

        //close settlemt
        public void closeSettlmt(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.closeSettlmt(objEntityLayerLeavePartialPrcs);
        }

        //close exit process
        public void closeExitPrcs(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.closeExitPrcs(objEntityLayerLeavePartialPrcs);
        }

        //finish ticket
        public void finishTicket(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.finishTicket(objEntityLayerLeavePartialPrcs);
        }

        //finish settlment
        public void finishSettlmt(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.finishSettlmt(objEntityLayerLeavePartialPrcs);
        }

        //finish exit process
        public void finishExitPrcs(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            objDataLeavePartialPrcs.finishExitPrcs(objEntityLayerLeavePartialPrcs);
        }
       
        

    }
}
