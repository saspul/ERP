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
    public class clsBusiness_Interview_Panel
    {
        clsDataLayer_InterView_Panel objDataJobIntervPanel = new clsDataLayer_InterView_Panel();

        public DataTable ReadDivision(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtDiv = objDataJobIntervPanel.ReadDivision(objEntityIntrPanel);
            return dtDiv;
        }
        public DataTable ReadDepartment(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtDiv = objDataJobIntervPanel.ReadDepartment(objEntityIntrPanel);
            return dtDiv;
        }
        public DataTable ReadProject(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtDiv = objDataJobIntervPanel.ReadProject(objEntityIntrPanel);
            return dtDiv;
        }
        public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtDiv = objDataJobIntervPanel.ReadAprvdManPwrReqstList(objEntityIntrPanel);
            return dtDiv;
        }
         public DataTable ReadManPwrReqstById(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtDiv = objDataJobIntervPanel.ReadManPwrReqstById(objEntityIntrPanel);
            return dtDiv;
        }
         public DataTable ReadInterviewTempData(clsEntityLayer_InterViewPanel objEntityIntrPanel)
         {
             DataTable dtDiv = objDataJobIntervPanel.ReadInterviewTempData(objEntityIntrPanel);
             return dtDiv;
         }
         // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadEmployee(clsEntityLayer_InterViewPanel objEntityIntrPanel)
         {
             DataTable dtEmp = objDataJobIntervPanel.ReadEmployee(objEntityIntrPanel);
             return dtEmp;
         }
         // This Method will fetCH AL THE DIVISIONS
        public DataTable ReadInterViewPanel(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtPanel = objDataJobIntervPanel.ReadInterViewPanel(objEntityIntrPanel);
            return dtPanel;
        }

         // This Method will fetCH AL DATA OF INTERVIEW PANEL
        public DataTable ReadInterViewPanelDetail(clsEntityLayer_InterViewPanel objEntityIntrPanel)
        {
            DataTable dtPanel = objDataJobIntervPanel.ReadInterViewPanelDetail(objEntityIntrPanel);
            return dtPanel;
        }
        public int Insert_Interv_Panel(clsEntityLayer_InterViewPanel objEntityPanel, List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetail)
        {
            int intPanel = objDataJobIntervPanel.Insert_Interv_Panel(objEntityPanel, objEntityPanelDetail);
            return intPanel;
        }

        public void Update_Interv_Panel(List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailAdd, List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailUpdate)
        {
            objDataJobIntervPanel.Update_Interv_Panel(objEntityPanelDetailAdd, objEntityPanelDetailUpdate);
        }
         public void Delete_Interv_Panel(List<clsEntityLayer_InterViewPanel_Dtl> objEntityPanelDetailDel)
        {
            objDataJobIntervPanel.Delete_Interv_Panel(objEntityPanelDetailDel);
        }

    }
}
