using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessEmpAcessMgmt
    {
        clsDataLayerEmpAccessMgmt objDataEmpAccessMgmt = new clsDataLayerEmpAccessMgmt();
        // checking employeeID 
        public DataTable checkEmpcode(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
            DataTable dtEmpId = objDataEmpAccessMgmt.checkEmpcode(objEntEmpAcesMgmt);
            return dtEmpId;
        }
        //This Method for inserting correct data into table
        public void InsertAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt,List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {
            objDataEmpAccessMgmt.InsertAttendenceSheet(objEntEmpAcesMgmt, objEntityEmpAccessMgmtList);
        }
        //Read check-in and check-out time of business unit
        public DataTable ReadChkinAndChkOut(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
            DataTable dtChkinAndChkOut = objDataEmpAccessMgmt.ReadChkinAndChkOut(objEntEmpAcesMgmt);
            return dtChkinAndChkOut;
        }
        //This Method for inserting incorrect data into table
        public void InsertIncorrectAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt, List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {
            objDataEmpAccessMgmt.InsertIncorrectAttendenceSheet(objEntEmpAcesMgmt, objEntityEmpAccessMgmtList);
        }
        // Checks the empployee is present is marked on the table
        public DataTable ReadAttendence(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt)
        {
            DataTable dtAttendence = objDataEmpAccessMgmt.ReadAttendence(objEntEmpAcesMgmt);
            return dtAttendence;
        }

        public void UpdateDuplicateAttendenceSheet(clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt, List<clsEntityEmplyeeAccessMgmt> objEntityEmpAccessMgmtList)
        {
            objDataEmpAccessMgmt.UpdateDuplicateAttendenceSheet(objEntEmpAcesMgmt, objEntityEmpAccessMgmtList);
        }
    }
}
