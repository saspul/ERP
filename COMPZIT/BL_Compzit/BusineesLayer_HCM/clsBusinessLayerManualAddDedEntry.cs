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
    public class clsBusinessLayerManualAddDedEntry
    {
        clsDataLayerManualAddDedEntry objDataLayer = new clsDataLayerManualAddDedEntry();
        public DataTable ReadManualAddDed(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadManualAddDed(objEntity);
            return dtInterviewCatList;
        }
        public DataTable ReadManualAddDedEdit(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadManualAddDedEdit(objEntity);
            return dtInterviewCatList;
        }
        public DataTable ReadEmployee(clsEntityManualAddDedEntry objEntity, string strLikeEmployee)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadEmployee(objEntity, strLikeEmployee);
            return dtInterviewCatList;
        }
        public DataTable ReadSubTableId(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadSubTableId(objEntity);
            return dtInterviewCatList;
        }
        public DataTable readMonthYearData(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.readMonthYearData(objEntity);
            return dtInterviewCatList;
        }
        public DataTable checkEmployeeDuplication(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.checkEmployeeDuplication(objEntity);
            return dtInterviewCatList;
        }
        public DataTable readClearDta(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.readClearDta(objEntity);
            return dtInterviewCatList;
        }
        public DataTable ReadList(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadList(objEntity);
            return dtInterviewCatList;
        }
        public DataTable ReadDataById(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.ReadDataById(objEntity);
            return dtInterviewCatList;
        }
        public DataTable checkEmpcode(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.checkEmpcode(objEntity);
            return dtInterviewCatList;
        }
        public void insUpdEmpDtls(clsEntityManualAddDedEntry objEntity,List<clsEntityManualAddDedEntry> objAddDedList)
        {
            objDataLayer.insUpdEmpDtls(objEntity, objAddDedList);
        }
        public void insUpdEmpDtlsEdit(clsEntityManualAddDedEntry objEntity, List<clsEntityManualAddDedEntry> objAddDedList)
        {
            objDataLayer.insUpdEmpDtlsEdit(objEntity, objAddDedList);
        }
        public void ReopConfDele(clsEntityManualAddDedEntry objEntity)
        {
            objDataLayer.ReopConfDele(objEntity);
        }
        public DataTable checkEmpLeave(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.checkEmpLeave(objEntity);
            return dtInterviewCatList;
        }

        public DataTable ReadPrintList(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dt = new DataTable();
            dt = objDataLayer.ReadPrintList(objEntity);
            return dt;
        }
        public void UpdateDescription(clsEntityManualAddDedEntry objEntity)
        {
            objDataLayer.UpdateDescription(objEntity);
        }
        public DataTable readMonthYearDataEdit(clsEntityManualAddDedEntry objEntity)
        {
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataLayer.readMonthYearDataEdit(objEntity);
            return dtInterviewCatList;
        }
    }
}
