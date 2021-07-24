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
    public class clsBusinessLayerExitPartialProcess
    {
        clsDataLayerExitPartialProcess objDataExitPartialProcess = new clsDataLayerExitPartialProcess();

        //read employee to dropdown
        public DataTable ReadToddlDesignation(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPartialProcess.ReadToddlDesignation(objEntityLayerExitPartialProcess);
            return dtEmp;
        }

        //read employee details to table
        public DataTable ReadEmployeeExit(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            DataTable dtEmp = new DataTable();
            dtEmp = objDataExitPartialProcess.ReadEmployeeExit(objEntityLayerExitPartialProcess);
            return dtEmp;
        }

        ////read division by employee id
        public DataTable ReadDivsnEmp(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            DataTable dtDivEmp = new DataTable();
            dtDivEmp = objDataExitPartialProcess.ReadDivsnEmp(objEntityLayerExitPartialProcess);
            return dtDivEmp;
        }
        //read Employee Particular Dtls By Id
        public DataTable ReadEmpDtlsById(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = objDataExitPartialProcess.ReadEmpDtlsById(objEntityLayerExitPartialProcess);
            return dtEmpDtlsById;
        }

       
        public DataTable ReadExitProcessDtlsByID(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = objDataExitPartialProcess.ReadExitProcessDtlsByID(objEntityLayerExitPartialProcess);
            return dtEmpDtlsById;
        }
        // This Method checks exit process
        public string CheckExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strReturn = objDataExitPartialProcess.CheckExitProcess(objEntityLayerExitPartialProcess);
            return strReturn;
        }


        //update ticket status
        public void updPartialExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            objDataExitPartialProcess.updPartialExitProcess(objEntityLayerExitPartialProcess);
        }

        public void closePartialExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            objDataExitPartialProcess.closePartialExitProcess(objEntityLayerExitPartialProcess);
        }

       

    }
}
