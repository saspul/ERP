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
   public class clsBusinessLayer_Exit_Intrvw_Process
    {
        clsDataLayer_Exit_Intrvw_Process objDataExitIntrvwProcess = new clsDataLayer_Exit_Intrvw_Process();

        public DataTable ReadDtlsList(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadDtlsList(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadDesignation(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadDesignation(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadEmployee(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadEmployee(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadEmployeeDlts(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadEmployeeDlts(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadEmployeeDivsn(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadEmployeeDivsn(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadQuestions(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public void InsertQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess, List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList)
        {
            objDataExitIntrvwProcess.InsertQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
        }
        public DataTable ReadAnswers(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadAnswers(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public void UpdateQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess, List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList)
        {
            objDataExitIntrvwProcess.UpdateQuestions(objEntityExitIntrvwProcess, objEntityExitIntrvwProcessList);
        }
        public DataTable ReadMstrId(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadMstrId(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
        public DataTable ReadBySearch(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtIndenter = objDataExitIntrvwProcess.ReadBySearch(objEntityExitIntrvwProcess);
            return dtIndenter;
        }
       //EVM -0024
        public DataTable ReadUserId(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
        {
            DataTable dtUserId = objDataExitIntrvwProcess.ReadUserId(objEntityExitIntrvwProcess);
            return dtUserId;
        }
    }
}
