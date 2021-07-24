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
    public class ClsBusiness_HCM_Reports
    {

        ClsData_HCM_Reports objDataJobDescrptn = new ClsData_HCM_Reports();


        public DataTable ReadManpwrReqmtProcessDetls(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadManpwrReqmtProcessDetls(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadShrtlistedCandidateList(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadShrtlistedCandidateList(objEntityjob);
            return dtGuarnt;
        }
        public DataTable readSchdlList(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.readSchdlList(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadDepts(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadDepts(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadProject(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadProject(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadEmployes(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadEmployes(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadAprvdManpwrRqst(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadAprvdManpwrRqst(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadManpwrSummaryDetls(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadManpwrSummaryDetls(objEntityjob);
            return dtGuarnt;
        }

        //check


        public DataTable checkCandStatus(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.checkCandStatus(objEntityjob);
            return dtGuarnt;
        }
        //public DataTable readSchdlList(clsEntityManpwr_Process_Report objEntityjob)
        //{
        //    DataTable dtGuarnt = new DataTable();
        //    dtGuarnt = objDataJobDescrptn.readSchdlList(objEntityjob);
        //    return dtGuarnt;
        //}
        public DataTable readQualifiedLevel(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.readQualifiedLevel(objEntityjob);
            return dtGuarnt;
        }
        public DataTable readCompleteLevel(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.readCompleteLevel(objEntityjob);
            return dtGuarnt;
        }
        public DataTable readSchdlLVlEditInfoDtls(clsEntityManpwr_Process_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.readSchdlLVlEditInfoDtls(objEntityjob);
            return dtGuarnt;
        }


    }

    public class clsBusiness_Leave_Management_Report
    {


        clsData_Leave_Management_Report objDataJobDescrptn = new clsData_Leave_Management_Report();


        public DataTable ReadLeaveTyp(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadLeaveTyp(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadDepts(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadDepts(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadDivision(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadDivision(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadLeaveManagementReport(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadLeaveManagementReport(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadTotalNumLeavesTaken(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadTotalNumLeavesTaken(objEntityjob);
            return dtGuarnt;
        }

        public DataTable READ_DIVISION_BYEMPID(clsEntity_Leave_Management_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.READ_DIVISION_BYEMPID(objEntityjob);
            return dtGuarnt;
        }
        
        
    }
    public class clsBusiness_Mess_Bill_Report
    {
        clsData_Mess_CalCulation_Report objDataJobDescrptn = new clsData_Mess_CalCulation_Report();
        public DataTable ReadAccomodation(clsEntity_Mess_Bill_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadAccomodation(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadAccomodationDetails(clsEntity_Mess_Bill_Report objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadAccomodationDetails(objEntityjob);
            return dtGuarnt;
        }


        
    }
}
