using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:26/05/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinesslayerProject
    {
        //Creating object for datalayer
        clsDataLayerProject objDataLayerProject = new clsDataLayerProject();

        //Method of passing Project name count that have in the table.
        public string Check_Project_Name(clsEntityProject objEntityProject)
        {
            string strCount = objDataLayerProject.CheckProjectName(objEntityProject);
            return strCount;
        }
        //Method for inserting data about Projects to the Project master table and returning the project id
        // adding Project in Lead  Master
        public string Insert_Project_Return_PrjctId(clsEntityProject objEntityProject)
        {
            string strId = objDataLayerProject.Insert_Project_Return_PrjctId(objEntityProject);
            return strId;
        }
        //Method of passing data about Project for insertion from ui layer to datalayer.
        public void Insert_Project(clsEntityProject objEntityProject)
        {
            objDataLayerProject.Insert_Project(objEntityProject);
        }
        //Method for passing Project master table from datalayer to uilayer for list view.
        public DataTable ReadProjectList(clsEntityProject objEntityProject)
        {
            DataTable dtProjectList = objDataLayerProject.ReadProjectList(objEntityProject);
            return dtProjectList;
        }
        //Passing the details about new status about the Project 
        public void Update_Project_Status(clsEntityProject objEntityProject)
        {
            if (objEntityProject.Project_Status == 1)
            {
                objEntityProject.Project_Status = 0;
            }
            else
            {
                objEntityProject.Project_Status = 1;
            }
            objDataLayerProject.Update_Project_Status(objEntityProject);
        }
        //Method of passing Project table from datalayer to ui layer with their id
        public DataTable ReadProjectById(clsEntityProject objEntityProject)
        {
            DataTable dtProjectById = objDataLayerProject.ReadProjectListById(objEntityProject);
            return dtProjectById;
        }
        //Method for passing data about Project modification for updation ui layer to data layer
        public void Update_Project(clsEntityProject objEntityProject)
        {
            objDataLayerProject.Update_Project(objEntityProject);
        }
        //Passing Project name for checking duplication at the time of updation
        public string Check_Project_NameUpdation(clsEntityProject objEntityProject)
        {
            string strCount = objDataLayerProject.CheckProjectNameUpdate(objEntityProject);
            return strCount;
        }
        //Method for cancel the department so passing data about department that get cancel
        public void Cancel_Project(clsEntityProject objEntityProject)
        {
            objDataLayerProject.Cancel_Project(objEntityProject);
        }
        public void ReCall_Project(clsEntityProject objEntityProject)
        {
            objDataLayerProject.ReCall_Project(objEntityProject);
        }
        //Method for READ EXISTING CUSTOMERS
        public DataTable ReadExistingCustomer(clsEntityProject objEntityProject)
        {
            DataTable dtCustomer = objDataLayerProject.ReadExistingCustomer(objEntityProject);
            return dtCustomer;
        }
        public DataTable ReadExistingEmployee(clsEntityProject objEntityProject)
        {
            DataTable dteMP = objDataLayerProject.ReadExistingEmployee(objEntityProject);
            return dteMP;
        }
        //Method for READ DIVISION
        public DataTable ReadDivisionByUser(clsEntityProject objEntityProject)
        {
            DataTable dtDivision = objDataLayerProject.ReadDivisionByUser(objEntityProject);
            return dtDivision;
        }
        public DataTable ReadEmployeeDetail(clsEntityProject objEntityProject)
        {
            DataTable dtDivision = objDataLayerProject.ReadEmployeeDetail(objEntityProject);
            return dtDivision;
        }

        public DataTable ReadWarehouses(clsEntityProject objEntityProject)
        {
            DataTable dtDivision = objDataLayerProject.ReadWarehouses(objEntityProject);
            return dtDivision;
        }

        public string CheckInternalRefNumber(clsEntityProject objEntityProject)
        {
            string strCount = objDataLayerProject.CheckInternalRefNumber(objEntityProject);
            return strCount;
        }
        public string CheckInternalRefNumberUpdation(clsEntityProject objEntityProject)
        {
            string strCount = objDataLayerProject.CheckInternalRefNumberUpdation(objEntityProject);
            return strCount;
        }

    }
}
