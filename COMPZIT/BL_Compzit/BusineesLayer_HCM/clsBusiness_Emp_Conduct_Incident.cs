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
    public class clsBusiness_Emp_Conduct_Incident
    {
        clsDataLayer_Emp_Conduct_Incident objDataConduct_Incident = new clsDataLayer_Emp_Conduct_Incident();
        public void InsertConductIncident(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.InsertConductIncident(objEntityConduct_Incident);          
        }
        public void Update_ConductIncident(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.Update_ConductIncident(objEntityConduct_Incident);
        }

        public DataTable LoadBissnusUnit(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadBissnusUnit(objEntityConduct_Incident);
          return dt;
        }
        public DataTable LoadDepartment(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadDepartment(objEntityConduct_Incident);
            return dt;
        }
        public DataTable LoadDivision(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadDivision(objEntityConduct_Incident);
            return dt;
        }
        public DataTable LoadEmployee(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadEmployee(objEntityConduct_Incident);
            return dt;
        }
        public DataTable LoadCategoery(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadCategoery(objEntityConduct_Incident);
            return dt;
        }
        public DataTable LoadCategoryDescrption(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.LoadCategoryDescrption(objEntityConduct_Incident);
            return dt;
        }

        public DataTable ReadConductIncidentList(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadConductIncidentList(objEntityConduct_Incident);
            return dt;
        }
        public DataTable ReadIncidentDetailsByid(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadIncidentDetailsByid(objEntityConduct_Incident);
            return dt;
        }
        public DataTable ReadConductEmployee(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadConductEmployee(objEntityConduct_Incident);
            return dt;
        }
        public DataTable readConductEmployeeById(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.readConductEmployeeById(objEntityConduct_Incident);
            return dt;
        }
        public void InsertConductReplay(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.InsertConductReplay(objEntityConduct_Incident);
        }
        public DataTable ReadMessage(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadMessage(objEntityConduct_Incident);
            return dt;
        }

        public DataTable ReadChatMessageByid(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadChatMessageByid(objEntityConduct_Incident);
            return dt;
        }

        public DataTable ReadUsermail(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {

            DataTable dt = objDataConduct_Incident.ReadUsermail(objEntityConduct_Incident);
            return dt;
        }
        public DataTable PdfEmployeeDetails(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            DataTable dt = objDataConduct_Incident.PdfEmployeeDetails(objEntityConduct_Incident);
            return dt;
        }


        public void Confirm_ConductIncident(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.Confirm_ConductIncident(objEntityConduct_Incident);
        }

        public void CloseConductIncident(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.CloseConductIncident(objEntityConduct_Incident);
        }
        public void CancelMessageBox(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            objDataConduct_Incident.CancelMessageBox(objEntityConduct_Incident);
        }
        public DataTable CancelNotPossible(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            DataTable dt = objDataConduct_Incident.CancelNotPossible(objEntityConduct_Incident);
            return dt;
        }
        public DataTable TerminationNotPossible(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            DataTable dt = objDataConduct_Incident.TerminationNotPossible(objEntityConduct_Incident);
            return dt;
        }

        public DataTable TerminationNotPossibleConfrm(clsEntity_Emp_conduct_Incident objEntityConduct_Incident)
        {
            DataTable dt = objDataConduct_Incident.TerminationNotPossibleConfrm(objEntityConduct_Incident);
            return dt;
        }
        
        
    }
}
