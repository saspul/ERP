using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
//using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;

namespace BL_Compzit.BusinessLayer_HCM
{
    public class clsBusinessLayerJobDetails
    {
        clsDataLayerJobDetails objDataLayerJobDetails = new clsDataLayerJobDetails();
        public void AddJobDetails(clsEntityJobDetails ObjEntityJobDetails)
        {
            objDataLayerJobDetails.AddJobDetails(ObjEntityJobDetails);

        }
        public void AddProjAssign(clsEntityProjectAssign ObjEntityProjectAssign)
        {
            objDataLayerJobDetails.AddProjectDetails( ObjEntityProjectAssign);

        }
        public DataTable ReadProjAssign(clsEntityProjectAssign ObjEntityProjectAssign)
        {
             DataTable dtProjectassign= objDataLayerJobDetails.ReadProjectList(ObjEntityProjectAssign);
             return dtProjectassign;
        }
        public DataTable ReadProjAssignById(clsEntityProjectAssign ObjEntityProjectAssign)
        {
            DataTable dtProjectassign = objDataLayerJobDetails.ReadProjectLisByidt(ObjEntityProjectAssign);
            return dtProjectassign;
        }
        public void UpdateJobDetails(clsEntityJobDetails ObjEntityJobDetails)
        {
            objDataLayerJobDetails.UpdateJobDetails(ObjEntityJobDetails);
        }
        ////Method of passing JobDetails master table data from datalayer to ui layer
        //public DataTable CancelJobDetailsById(clsEntityJobDetails ObjEntityJobDetails)
        //{
        //    DataTable dtReadsupplier = objDataLayerJobDetails.CancelJobDetailsById(ObjEntityJobDetails);
        //    return dtReadsupplier;
        //}
        //////Method of cancelling 
        //public DataTable ReadJobDetailsById(clsEntityJobDetails ObjEntityJobDetails)
        //{
        //    DataTable dtReadsupplier = objDataLayerJobDetails.ReadJobDetailsById(ObjEntityJobDetails);
        //    return dtReadsupplier;
        //}
        public DataTable ReadProject(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadProject(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public DataTable ReadDivision(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadDivision(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public DataTable ReadDepartment(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadDepartments(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public DataTable ReadDesignation(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadDesignation(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public DataTable ReadSponsor(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadSponsor(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public DataTable ReadAccomodation(clsEntityJobDetails ObjEntityJobDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadAccomodation(ObjEntityJobDetails);
            return dtReadsupplier;
        }
        public void UpdateProjectDetails(clsEntityProjectAssign ObjEntityDetails)
        {
            objDataLayerJobDetails.UpdateProjectList(ObjEntityDetails);
        }
        public DataTable ReadJobtDetails(clsEntityJobDetails ObjEntityDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadJobList(ObjEntityDetails);
            return dtReadsupplier;
        }
        public void DeleteProjectDetails(clsEntityProjectAssign ObjEntityDetails)
        {
             objDataLayerJobDetails.DeleteProject(ObjEntityDetails);
           
        }
        public string Checkproj_Assign(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strReturn = objDataLayerJobDetails.Checkproj_Assign(objEntityEntityJobDetails);
            return strReturn;
        }
        public DataTable ReadDesignationType(clsEntityJobDetails objEntityEntityJobDetails)
        {
            DataTable dtdesignation = objDataLayerJobDetails.ReadDesignationType(objEntityEntityJobDetails);
            return dtdesignation;
        }
        //EVM-0024
        public void UpdateProbationDate(clsEntityJobDetails ObjEntityJobDetails)
        {
            objDataLayerJobDetails.UpdateProbationDate(ObjEntityJobDetails);
        }
        public DataTable ReadJobProbation(clsEntityJobDetails ObjEntityDetails)
        {
            DataTable dtReadsupplier = objDataLayerJobDetails.ReadJobProbation(ObjEntityDetails);
            return dtReadsupplier;
        }
    }
}
