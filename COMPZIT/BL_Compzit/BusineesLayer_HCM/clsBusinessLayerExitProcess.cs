using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerExitProcess
    {

        clsDataLayerExitProcess objDataExitPrcs = new clsDataLayerExitProcess();

        //read employee to dropdown
        public DataTable ReadToddlEmployee(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadToddlEmployee(objEntityExitProcs);
            return dtEmp;
        }

        //read employee details
        public DataTable ReadEmpDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadEmpDtls(objEntityExitProcs);
            return dtEmp;
        }

        //read division of employee
        public DataTable ReadDivsnEmp(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadDivsnEmp(objEntityExitProcs);
            return dtEmp;
        }

        //insert exit process
        public void InsertExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            objDataExitPrcs.InsertExitPrcs(objEntityExitProcs);
        }

         //read exit process
        public DataTable ReadExitProcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtExtPrcs = new DataTable();
            dtExtPrcs = objDataExitPrcs.ReadExitProcs(objEntityExitProcs);
            return dtExtPrcs;
        }

         //cancel exit process
        public void CancelExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            objDataExitPrcs.CancelExitPrcs(objEntityExitProcs);
        }

        //read employee details on exit process
        public DataTable ReadEmpExitDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadEmpExitDtls(objEntityExitProcs);
            return dtEmp;
        }

        //update exit process
        public void UpdateExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            objDataExitPrcs.UpdateExitPrcs(objEntityExitProcs);
        }

        //update confrm status
        public void UpdateConfrm(clsEntityLayerExitProcess objEntityExitProcs)
        {
            objDataExitPrcs.UpdateConfrm(objEntityExitProcs);
        }

        //check confirm status
        public DataTable CheckConfrmStatus(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.CheckConfrmStatus(objEntityExitProcs);
            return dtEmp;
        }
        //eVM-0024
        public DataTable ReadEmpIncidentDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadEmpIncidentDtls(objEntityExitProcs);
            return dtEmp;
        }
        //END


        public DataTable ReadEmpExitProcessMstrSts(clsEntityLayerExitProcess objEntityExitProcs)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPrcs.ReadEmpExitProcessMstrSts(objEntityExitProcs);
            return dtEmp;
        }
    }
}
