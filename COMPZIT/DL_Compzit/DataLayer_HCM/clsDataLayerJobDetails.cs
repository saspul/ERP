using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerJobDetails
    {
        // This Method adds customer details to the customer master table
        public void AddJobDetails(clsEntityJobDetails objEntityEntityJobDetails)
        {
            //fetching next value

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryAddJobDetails = "EMPLOYEE_JOBDETAILS.SP_INSERT_EMP_JOBDTLS";
                    using (OracleCommand cmdAddJobDetails = new OracleCommand(strQueryAddJobDetails, con))
                    {

                        cmdAddJobDetails.CommandType = CommandType.StoredProcedure;
                        //generate next value
                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                        //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JobDetails);
                        objCommon.CorporateID = objEntityEntityJobDetails.CorpId;


                        cmdAddJobDetails.Parameters.Add("C_JOB_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;

                        cmdAddJobDetails.Parameters.Add("C_JOINED_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.JoinedDate;
                        cmdAddJobDetails.Parameters.Add("C_PROBATION_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.ProbationEnddate;
                        cmdAddJobDetails.Parameters.Add("C_PROBATION_PERIOD ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Probation;
                        if (objEntityEntityJobDetails.PermamanencyDate != DateTime.MinValue)
                        {
                            cmdAddJobDetails.Parameters.Add("C_PERMANENCY_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.PermamanencyDate;
                        }
                        else
                        {
                            cmdAddJobDetails.Parameters.Add("C_PERMANENCY_DATE ", OracleDbType.Date).Value = null;
                        }
                        cmdAddJobDetails.Parameters.Add("C_DESIGN ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Designation;
                        cmdAddJobDetails.Parameters.Add("C_TYPE ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.EmployeeType;

                        //evm-0027
                        if (objEntityEntityJobDetails.Sponsorid == 0)
                        {

                            cmdAddJobDetails.Parameters.Add("C_SPNSR_ID ", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddJobDetails.Parameters.Add("C_SPNSR_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Sponsorid;


                        }
                        if (objEntityEntityJobDetails.Project == 0)
                        {

                            cmdAddJobDetails.Parameters.Add("C_PROJ_ID ", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddJobDetails.Parameters.Add("C_PROJ_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Project;


                        }
                      
                        //end
                     

                        if (objEntityEntityJobDetails.Department_Id == 0)
                        {

                            cmdAddJobDetails.Parameters.Add("C_DEPT_ID ", OracleDbType.Int32).Value = null;
                        }
                        else {

                            cmdAddJobDetails.Parameters.Add("C_DEPT_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Department_Id;
       
                        
                        }
                        if (objEntityEntityJobDetails.Division == 0)
                        {

                            cmdAddJobDetails.Parameters.Add("C_DIV_ID ", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddJobDetails.Parameters.Add("C_DIV_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Division;


                        }
                          
                        cmdAddJobDetails.Parameters.Add("C_PROJ_LOC ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.ProjectLocation;
                        cmdAddJobDetails.Parameters.Add("C_JOB_TYPE  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.JobType;
                        cmdAddJobDetails.Parameters.Add("C_JOB_TITLE  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.JobTitle;
                        cmdAddJobDetails.Parameters.Add("C_JOB_DESC  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.Description;
                        if (objEntityEntityJobDetails.Accomadation_id == 0)
                        {

                            cmdAddJobDetails.Parameters.Add("C_ACCOMODATION ", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddJobDetails.Parameters.Add("C_ACCOMODATION ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Accomadation_id;
         
                        }



                                    cmdAddJobDetails.Parameters.Add("C_LOC", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.EmployeeLocation;
                        //  cmdAddJobDetails.Parameters.Add("C_PROJASSN_ID   ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.ProjectLocation;
                        cmdAddJobDetails.Parameters.Add("C_INS_DATE_ID", OracleDbType.Date).Value = objEntityEntityJobDetails.JobUserDate;



                        cmdAddJobDetails.Parameters.Add("C_INSUSR_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;


                        cmdAddJobDetails.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                        cmdAddJobDetails.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;

                        cmdAddJobDetails.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;

                        cmdAddJobDetails.ExecuteNonQuery();
                    }





                    tran.Commit();

                }


                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }

            }
        }
        public void AddProjectDetails(clsEntityProjectAssign objEntityEntityProjectAssign)
        {
            OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
            string strQueryAddProjectAssign = "EMPLOYEE_JOBDETAILS.SP_INSERT_PROJECT_ASSIGN";
            con.Open();
            using (OracleCommand cmdAddAssignDetails = new OracleCommand(strQueryAddProjectAssign, con))
            {

                cmdAddAssignDetails.CommandType = CommandType.StoredProcedure;
                //generate next value
                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();
                //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JobDetails);
                //  objCommon.CorporateID = objEntityEntityJobDetails.CorpId;



                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_JOB_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.Project_Job_Id;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.ProjectId;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_NAME ", OracleDbType.Varchar2).Value = objEntityEntityProjectAssign.ProjectName;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_START_DATE ", OracleDbType.Date).Value = objEntityEntityProjectAssign.Project_StartDate;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_END_DATE ", OracleDbType.Date).Value = objEntityEntityProjectAssign.Project_EndDate;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_COMMENTS ", OracleDbType.Varchar2).Value = objEntityEntityProjectAssign.Project_Comments;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_PROJ_STATUS ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.ProjectStatus;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_INS_DATE ", OracleDbType.Date).Value = objEntityEntityProjectAssign.UserDate;
                cmdAddAssignDetails.Parameters.Add("C_PROJASSN_INS_USR_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.UserId;

                cmdAddAssignDetails.ExecuteNonQuery();
            }
        }
        //Method for Updating JobDetails Details
        public void UpdateJobDetails(clsEntityJobDetails objEntityEntityJobDetails)
        {
           
            using (OracleConnection con = new OracleConnection())
            {
               

                //generate next value
                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();

                string strQueryUpdateJobDetails = "EMPLOYEE_JOBDETAILS.SP_UPDATE_EMP_JOBDTLS";
                using (OracleCommand cmdAddJobDetails = new OracleCommand())
                {
                    cmdAddJobDetails.CommandType = CommandType.StoredProcedure;
                    cmdAddJobDetails.CommandText = strQueryUpdateJobDetails;
                    cmdAddJobDetails.Parameters.Add("C_JOB_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;

                    cmdAddJobDetails.Parameters.Add("C_JOINED_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.JoinedDate;
                    //  cmdAddJobDetails.Parameters.Add("C_PROBATION_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.ProbationEnddate;
                    cmdAddJobDetails.Parameters.Add("C_PROBATION_PERIOD ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Probation;
                    if (objEntityEntityJobDetails.PermamanencyDate != DateTime.MinValue)
                    {
                        cmdAddJobDetails.Parameters.Add("C_PERMANENCY_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.PermamanencyDate;

                    }
                    else
                    {
                        cmdAddJobDetails.Parameters.Add("C_PERMANENCY_DATE ", OracleDbType.Date).Value = null;
                    }
                    cmdAddJobDetails.Parameters.Add("C_DESIGN ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Designation;
                    cmdAddJobDetails.Parameters.Add("C_TYPE ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.EmployeeType;
                    //evm-0027
                    if (objEntityEntityJobDetails.Sponsorid == 0)
                    {

                        cmdAddJobDetails.Parameters.Add("C_SPNSR_ID ", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddJobDetails.Parameters.Add("C_SPNSR_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Sponsorid;


                    }
                    if (objEntityEntityJobDetails.Project == 0)
                    {

                        cmdAddJobDetails.Parameters.Add("C_PROJ_ID ", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddJobDetails.Parameters.Add("C_PROJ_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Project;


                    }

                    //end



                    if (objEntityEntityJobDetails.Department_Id == 0)
                    {

                        cmdAddJobDetails.Parameters.Add("C_DEPT_ID ", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddJobDetails.Parameters.Add("C_DEPT_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Department_Id;


                    }
                    if (objEntityEntityJobDetails.Division == 0)
                    {

                        cmdAddJobDetails.Parameters.Add("C_DIV_ID ", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddJobDetails.Parameters.Add("C_DIV_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Division;


                    }

                    cmdAddJobDetails.Parameters.Add("C_PROJ_LOC ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.ProjectLocation;
                    //cmdAddJobDetails.Parameters.Add("C_JOB_TYPE  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.JobType;
                    cmdAddJobDetails.Parameters.Add("C_JOB_TITLE  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.JobTitle;
                    cmdAddJobDetails.Parameters.Add("C_JOB_DESC  ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.Description;
                    if (objEntityEntityJobDetails.Accomadation_id == 0)
                    {

                        cmdAddJobDetails.Parameters.Add("C_ACCOMODATION ", OracleDbType.Int32).Value = null;
                    }
                    else
                    {

                        cmdAddJobDetails.Parameters.Add("C_ACCOMODATION ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Accomadation_id;

                    }
                    cmdAddJobDetails.Parameters.Add("C_LOC", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.EmployeeLocation;
                    //  cmdAddJobDetails.Parameters.Add("C_PROJASSN_ID   ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.ProjectLocation;
                    cmdAddJobDetails.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.JobUserDate;



                    cmdAddJobDetails.Parameters.Add("C_UPDUSR_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;


                    cmdAddJobDetails.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                    cmdAddJobDetails.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;

                    cmdAddJobDetails.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;
                    clsDataLayer.ExecuteNonQuery(cmdAddJobDetails);
                    //cmdAddJobDetails.ExecuteNonQuery();
                }




            }
        }
         //This Method will fetch customer table by ID
        public DataTable ReadJobDetailsById(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadJobDetailsById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_BY_ID";
            OracleCommand cmdReadJobDetailsById = new OracleCommand();
            cmdReadJobDetailsById.CommandText = strQueryReadJobDetailsById;
            cmdReadJobDetailsById.CommandType = CommandType.StoredProcedure;
            cmdReadJobDetailsById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
            cmdReadJobDetailsById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
            cmdReadJobDetailsById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;
            cmdReadJobDetailsById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadJobDetailsById);
            return dtCustomer;
        }
        //This Method will fetch customer table
        public DataTable ReadJobDetailsList(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadJobDetailsById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_READ_EMPLOYEE_IMIG_LIST";
            OracleCommand cmdReadJobDetailsById = new OracleCommand();
            cmdReadJobDetailsById.CommandText = strQueryReadJobDetailsById;
            cmdReadJobDetailsById.CommandType = CommandType.StoredProcedure;
            cmdReadJobDetailsById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
            cmdReadJobDetailsById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;

            cmdReadJobDetailsById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadJobDetailsById);
            return dtCustomer;
        }
        //This Method will CANCEL   by ID
        //public DataTable CancelJobDetailsById(clsEntityJobDetails objEntityEntityJobDetails)
        //{
        //    string strQueryReadJobDetailsById = "EMPLOYEE_SPONSOR_IMIGRATION.SP_CAN_JobDetails";
        //    OracleCommand cmdReadJobDetailsById = new OracleCommand();
        //    cmdReadJobDetailsById.CommandText = strQueryReadJobDetailsById;
        //    cmdReadJobDetailsById.CommandType = CommandType.StoredProcedure;
        //    cmdReadJobDetailsById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
        //    cmdReadJobDetailsById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
        //    cmdReadJobDetailsById.Parameters.Add("C_EMPIMG_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;
        //    cmdReadJobDetailsById.Parameters.Add("C_CANDATE", OracleDbType.Date).Value = objEntityEntityJobDetails.Imigdate;
        //    cmdReadJobDetailsById.Parameters.Add("C_CANUSR_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Imig_user_id;

        //    cmdReadJobDetailsById.Parameters.Add("C_RSN", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.ImigCancelREASON;
        //    cmdReadJobDetailsById.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtCustomer = new DataTable();
        //    dtCustomer = clsDataLayer.ExecuteReader(cmdReadJobDetailsById);
        //    return dtCustomer;
        //}
      //  Method for read Project for list view.
        public DataTable ReadProject(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_PROJECT";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadProj.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Department_Id;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDivision(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_DIVISION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
             //   cmdReadProj.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Department_Id;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDepartments(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_DEPARTMENTS";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadSponsor(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_SPONSOR";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDesignation(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_DSGN_BY_USRID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = 0;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadAccomodation(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_ACCOMODATION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEntityJobDetails.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEntityJobDetails.CorpId;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadProjectList(clsEntityProjectAssign objEntityEntityProjectAssign)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_PROJECT_ASSIGN";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_JOBID", OracleDbType.Int32).Value = objEntityEntityProjectAssign.Project_Job_Id;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadProjectLisByidt(clsEntityProjectAssign objEntityEntityProjectAssign)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_PROJECT_ASSIGN_BYID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEntityProjectAssign.Project_Asgn_Id;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public void UpdateProjectList(clsEntityProjectAssign objEntityEntityProjectAssign)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_UPDATE_PROJECT_ASSIGN";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadProj.Connection = con;
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("C_PROJASSN_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.Project_Asgn_Id;

                cmdReadProj.Parameters.Add("C_PROJASSN_PROJ_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.ProjectId;
                cmdReadProj.Parameters.Add("C_PROJASSN_PROJ_NAME ", OracleDbType.Varchar2).Value = objEntityEntityProjectAssign.ProjectName;
                cmdReadProj.Parameters.Add("C_PROJASSN_PROJ_START_DATE ", OracleDbType.Date).Value = objEntityEntityProjectAssign.Project_StartDate;
                cmdReadProj.Parameters.Add("C_PROJASSN_PROJ_END_DATE ", OracleDbType.Date).Value = objEntityEntityProjectAssign.Project_EndDate;
                cmdReadProj.Parameters.Add("C_PROJASSN_PROJ_COMMENTS ", OracleDbType.Varchar2).Value = objEntityEntityProjectAssign.Project_Comments;
                cmdReadProj.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objEntityEntityProjectAssign.UserDate;
                cmdReadProj.Parameters.Add("C_UPDUSR_ID", OracleDbType.Int32).Value = objEntityEntityProjectAssign.UserId;

                cmdReadProj.ExecuteNonQuery();
            }
        }
        public void DeleteProject(clsEntityProjectAssign objEntityEntityProjectAssign)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_DELETE_ASSIGN";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadProj.Connection = con;
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("C_PROJASSN_ID ", OracleDbType.Int32).Value = objEntityEntityProjectAssign.Project_Asgn_Id;
                cmdReadProj.ExecuteNonQuery();
            }
        }
        public DataTable ReadJobList(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_PROJECT_JOBDETAIL";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.EmployeeId;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public string Checkproj_Assign(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_CHECK_PROJECT_ASSIGN";
              OracleCommand cmdReadProj = new OracleCommand();
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Project;
                cmdReadProj.Parameters.Add("P_PROJASSN_JOB_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdReadProj);
                string strReturn = cmdReadProj.Parameters["P_OUT"].Value.ToString();
                cmdReadProj.Dispose();
                return strReturn;
            
        }
        public DataTable ReadDesignationType(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadDesignation = "PERSONAL_DETAILS.SP_READ_DESIGNATION";
            OracleCommand cmdReadDesignation = new OracleCommand();
            cmdReadDesignation.CommandText = strQueryReadDesignation;
            cmdReadDesignation.CommandType = CommandType.StoredProcedure;
            cmdReadDesignation.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.UserDsgnId;
            cmdReadDesignation.Parameters.Add("P_DTLS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomer = new DataTable();
            dtCustomer = clsDataLayer.ExecuteReader(cmdReadDesignation);
            return dtCustomer;
        }
        //EVM-0024  UPDATE PROBATION DATE
        public void UpdateProbationDate(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryUpdProbation = "EMPLOYEE_JOBDETAILS.SP_UPDATE_PROBATION_DATE";
            using (OracleCommand cmdUpdProbation = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdUpdProbation.Connection = con;
                cmdUpdProbation.CommandText = strQueryUpdProbation;
                cmdUpdProbation.CommandType = CommandType.StoredProcedure;
                cmdUpdProbation.Parameters.Add("C_JOB_ID ", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;
                cmdUpdProbation.Parameters.Add("C_PROBATION_DATE ", OracleDbType.Date).Value = objEntityEntityJobDetails.ProbationEnddate;
                cmdUpdProbation.Parameters.Add("C_PROBATION_PERIOD ", OracleDbType.Varchar2).Value = objEntityEntityJobDetails.Probation;
                cmdUpdProbation.ExecuteNonQuery();
            }
        }
        //Read probation date and period
        public DataTable ReadJobProbation(clsEntityJobDetails objEntityEntityJobDetails)
        {
            string strQueryReadProj = "EMPLOYEE_JOBDETAILS.SP_READ_JOBPROBATION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("JOB_ID", OracleDbType.Int32).Value = objEntityEntityJobDetails.Job_Id;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        //END
    }
}
