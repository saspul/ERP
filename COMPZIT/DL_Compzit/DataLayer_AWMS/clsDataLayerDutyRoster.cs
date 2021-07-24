using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;
// CREATED BY:EVM-0005
// CREATED DATE:17/03/2017
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerDutyRoster
    {
        // This Method will fetch emlpoyee datas
        public DataTable ReadEmployee(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmp = "DUTY_ROSTER.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("D_EMPID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmp.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdReadEmp.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdReadEmp.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpList = new DataTable();
            dtEmpList = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmpList;
        }

        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_JOBSHDL_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

      
        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlByDateEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_JOBSHDL_DETAIL_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlByDayWise(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_JOBSHDL_DAYWISE_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
       
        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlForDayEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_JOBSHDL_FORADAY_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlForDayEmpDaywise(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_RD_JBSHDL_FRDY_BY_EMP_DY_WS";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        // This Method will fetch emlpoyee wise duty sheduled datas
        public DataTable ReadDutyShdlForDayEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_DUTYSHDL_FORDAY_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

        // This Method will fetch holiday detail
        public DataTable ReadHolidays(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_HOLI_DAYS";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdReadEmpJob.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

        // This Method will fetch VEHICLE detail
        public DataTable ReadVehicleById(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadVeh = "DUTY_ROSTER.SP_READ_VEHICLE_BY_ID";
            OracleCommand cmdReadVeh = new OracleCommand();
            cmdReadVeh.CommandText = strQueryReadVeh;
            cmdReadVeh.CommandType = CommandType.StoredProcedure;
            cmdReadVeh.Parameters.Add("D_VEH_ID", OracleDbType.Int32).Value = objEntityDutyRost.VehiclleId;
            cmdReadVeh.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadVeh);
            return dtJobShdlList;
        }

        //START:-EVM-0009
        //For inserting job schedule details

        public void insertScheduleDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseList, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseListUpd, string[] strCanclDtlIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertJobShdl = "DUTY_ROSTER.SP_INSERT_DUTYRSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                    {
                        cmdInsertJobSchdlng.Transaction = tran;

                        cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DUTY_ROSTER);
                        objEntCommon.CorporateID = objEntityDutyRost.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityDutyRost.DutyRosterId = Convert.ToInt32(strNextNum);

                        cmdInsertJobSchdlng.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.DutyRosterId;
                        cmdInsertJobSchdlng.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
                        cmdInsertJobSchdlng.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_SCLDJOB_STS", OracleDbType.Int32).Value = objEntityDutyRost.Status_id;
                        cmdInsertJobSchdlng.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
                        cmdInsertJobSchdlng.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
                        cmdInsertJobSchdlng.Parameters.Add("D_INSUSERID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                        cmdInsertJobSchdlng.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                        cmdInsertJobSchdlng.ExecuteNonQuery();

                    }
                    //insert to  Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityobScheduleDtlPeriodWiseList)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_INSERT_DUTYRSTR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.DutyRosterId;
                            cmdAddInsertDetail.Parameters.Add("D_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("D_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddInsertDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    //update to  Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityobScheduleDtlPeriodWiseListUpd)
                    {
                        string strQueryUpdDetail = "DUTY_ROSTER.SP_UPD_DUTYRSTR_DTL";
                        using (OracleCommand cmdAddUpdDetail = new OracleCommand(strQueryUpdDetail, con))
                        {
                            cmdAddUpdDetail.Transaction = tran;
                            cmdAddUpdDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddUpdDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.DutyRosterDtlId;
                            cmdAddUpdDetail.Parameters.Add("D_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddUpdDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddUpdDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddUpdDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddUpdDetail.Parameters.Add("D_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddUpdDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddUpdDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddUpdDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddUpdDetail.ExecuteNonQuery();
                        }
                    }

                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strCanclDtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "DUTY_ROSTER.SP_DELETE_DUTYSHDL_DTL";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;

                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("D_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
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


        public void updateScheduleDetails(List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseList, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseListUpd, string[] strCanclDtlIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    //insert to  Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityobScheduleDtlPeriodWiseList)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_INSERT_DUTYRSTR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDetail.DutyRosterId;
                            cmdAddInsertDetail.Parameters.Add("D_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("D_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddInsertDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    //update to  Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityobScheduleDtlPeriodWiseListUpd)
                    {
                        string strQueryUpdDetail = "DUTY_ROSTER.SP_UPD_DUTYRSTR_DTL";
                        using (OracleCommand cmdAddUpdDetail = new OracleCommand(strQueryUpdDetail, con))
                        {
                            cmdAddUpdDetail.Transaction = tran;
                            cmdAddUpdDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddUpdDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objDetail.DutyRosterDetailId;
                            cmdAddUpdDetail.Parameters.Add("D_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddUpdDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddUpdDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddUpdDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddUpdDetail.Parameters.Add("D_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddUpdDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddUpdDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddUpdDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddUpdDetail.ExecuteNonQuery();
                        }
                    }

                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strCanclDtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "DUTY_ROSTER.SP_DELETE_DUTYSHDL_DTL";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;

                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("D_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
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

        
        //To check data Already exist in th table
        public string CheckDutyRoster(clsEntityLayerDutyRoster objEntityDutyRost)
        {

            string strQueryCheck = "DUTY_ROSTER.SP_CHECK_DUTYRSTR";
            OracleCommand cmdCheck = new OracleCommand();
            cmdCheck.CommandText = strQueryCheck;
            cmdCheck.CommandType = CommandType.StoredProcedure;
            cmdCheck.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdCheck.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdCheck.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheck);
            string strReturn = cmdCheck.Parameters["D_COUNT"].Value.ToString();
            cmdCheck.Dispose();
            return strReturn;
        }
        public DataTable ReadDutyslipCreateOrNOt(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_DTYSLP_CRTORNOT";
            OracleCommand cmdInsertJobSchdlng = new OracleCommand();
            cmdInsertJobSchdlng.CommandText = strQueryReadEmpJob;
            cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;
            cmdInsertJobSchdlng.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdInsertJobSchdlng.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdInsertJobSchdlng.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdInsertJobSchdlng.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdInsertJobSchdlng);
            return dtJobShdlList;

        }
        //For reading dutyslip details of a employee daywise
        public DataTable ReadDutyslipDtl(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_DTYSLP_FORADAY_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        //For inserting job submission details
        public void insertJobSbmsnDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertJobShdl = "DUTY_ROSTER.SP_INSERT_DUTYSBMSN_MSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                    {
                        cmdInsertJobSchdlng.Transaction = tran;

                        cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DUTY_ROSTER_SUBMISSION);
                        objEntCommon.CorporateID = objEntityDutyRost.Corporate_id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityDutyRost.SubmissionId = Convert.ToInt32(strNextNum);

                        cmdInsertJobSchdlng.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                        cmdInsertJobSchdlng.Parameters.Add("D_DUTYID", OracleDbType.Int32).Value = objEntityDutyRost.DutyRosterId;
                        cmdInsertJobSchdlng.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
                        cmdInsertJobSchdlng.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.SubmissionDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_STRT_DATE", OracleDbType.TimeStamp).Value = objEntityDutyRost.FromDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_END_DATE", OracleDbType.TimeStamp).Value = objEntityDutyRost.ToDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_TOTAL_WRKHR", OracleDbType.Decimal).Value = objEntityDutyRost.TotalWrkHr;
                        cmdInsertJobSchdlng.Parameters.Add("D_NRML_WRKHR", OracleDbType.Decimal).Value = objEntityDutyRost.NormalWrkHr;
                        if (objEntityDutyRost.IdleHr != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_IDLEHR", OracleDbType.Decimal).Value = objEntityDutyRost.IdleHr;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_IDLEHR", OracleDbType.Decimal).Value = null;
                        }
                        if (objEntityDutyRost.FinalOT != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_FINAL_OT", OracleDbType.Decimal).Value = objEntityDutyRost.FinalOT;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_FINAL_OT", OracleDbType.Decimal).Value = null;
                        }
                        if (objEntityDutyRost.RoundedOT != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_RNDED_OT", OracleDbType.Decimal).Value = objEntityDutyRost.RoundedOT;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_RNDED_OT", OracleDbType.Decimal).Value = null;
                        }
                        cmdInsertJobSchdlng.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
                        cmdInsertJobSchdlng.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
                        cmdInsertJobSchdlng.Parameters.Add("D_INSUSERID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                        cmdInsertJobSchdlng.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                        cmdInsertJobSchdlng.ExecuteNonQuery();

                    }
                    //insert to  submission Detail table
                    foreach (clsEntityLayerSubmissionDtl objDetail in objEntityJobSubmsnDtlList)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_INSERT_DUTYSBMSN_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                            cmdAddInsertDetail.Parameters.Add("D_DUTYDTL_ID", OracleDbType.Int32).Value = objDetail.DutyRosterDtlId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromDate;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToDate;
                            cmdAddInsertDetail.Parameters.Add("D_SBMSNSTS_ID", OracleDbType.Int32).Value = objDetail.SubmissionStsId;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VehiclleId;
                            cmdAddInsertDetail.Parameters.Add("D_PRSNTMLG", OracleDbType.Int32).Value = objDetail.VhclPrsntMlg;
                            cmdAddInsertDetail.Parameters.Add("D_DESC", OracleDbType.Varchar2).Value = objDetail.SubmsnDtlDesc;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }


                    //insert to  additional jobs table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityAddtnlJobsList)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_INSERT_DUTYSBMSN_ADTL_JOBS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
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

        //To check dutyslip submitted for an employee on a date
        public string CheckDutySlpSubmsnSts(clsEntityLayerDutyRoster objEntityDutyRost)
        {

            string strQueryCheck = "DUTY_ROSTER.SP_CHECK_DUTYSLP_SBMTED";
            OracleCommand cmdCheck = new OracleCommand();
            cmdCheck.CommandText = strQueryCheck;
            cmdCheck.CommandType = CommandType.StoredProcedure;
            cmdCheck.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdCheck.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdCheck.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheck);
            string strReturn = cmdCheck.Parameters["D_COUNT"].Value.ToString();
            cmdCheck.Dispose();
            return strReturn;
        }

        //For reading dutyslip submission time sheet details of a employee daywise
        public DataTable ReadDutySlipSbmsnTimesheetDtl(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_SBMSN_TIMESHT_DTL";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_TDAY_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        //For reading dutyslip job submission  details of a employee daywise
        public DataTable ReadDutySlipSbmsnDtl(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_SBMSN_JOB_DTL";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        //For reading dutyslip submission additional job details of a employee daywise
        public DataTable ReadDutySlipSbmsnAddtnlJobDtl(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_SBMSN_ADDTLJOB_DTL";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

        //For updating job submission details
        public void updateJobSbmsnDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListAdd, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListUpdate, string[] strCanclDtlIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertJobShdl = "DUTY_ROSTER.SP_UPDATE_DUTYSBMSN_MSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                    {
                        cmdInsertJobSchdlng.Transaction = tran;
                        cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;
                        cmdInsertJobSchdlng.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                        cmdInsertJobSchdlng.Parameters.Add("D_STRT_DATE", OracleDbType.TimeStamp).Value = objEntityDutyRost.FromDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_END_DATE", OracleDbType.TimeStamp).Value = objEntityDutyRost.ToDate;
                        cmdInsertJobSchdlng.Parameters.Add("D_TOTAL_WRKHR", OracleDbType.Decimal).Value = objEntityDutyRost.TotalWrkHr;
                        cmdInsertJobSchdlng.Parameters.Add("D_NRML_WRKHR", OracleDbType.Decimal).Value = objEntityDutyRost.NormalWrkHr;
                        if (objEntityDutyRost.IdleHr != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_IDLEHR", OracleDbType.Decimal).Value = objEntityDutyRost.IdleHr;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_IDLEHR", OracleDbType.Decimal).Value = null;
                        }
                        if (objEntityDutyRost.FinalOT != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_FINAL_OT", OracleDbType.Decimal).Value = objEntityDutyRost.FinalOT;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_FINAL_OT", OracleDbType.Decimal).Value = null;
                        }
                        if (objEntityDutyRost.RoundedOT != 0)
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_RNDED_OT", OracleDbType.Decimal).Value = objEntityDutyRost.RoundedOT;
                        }
                        else
                        {
                            cmdInsertJobSchdlng.Parameters.Add("D_RNDED_OT", OracleDbType.Decimal).Value = null;
                        }
                        cmdInsertJobSchdlng.Parameters.Add("D_UPDUSERID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                        cmdInsertJobSchdlng.Parameters.Add("D_UPDDATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                        cmdInsertJobSchdlng.ExecuteNonQuery();

                    }
                    //insert to  submission Detail table
                    foreach (clsEntityLayerSubmissionDtl objDetail in objEntityJobSubmsnDtlList)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_UPDATE_DUTYSBMSN_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                            cmdAddInsertDetail.Parameters.Add("D_DUTYDTL_ID", OracleDbType.Int32).Value = objDetail.DutyRosterDtlId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromDate;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToDate;
                            cmdAddInsertDetail.Parameters.Add("D_SBMSNSTS_ID", OracleDbType.Int32).Value = objDetail.SubmissionStsId;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VehiclleId;
                            cmdAddInsertDetail.Parameters.Add("D_PRSNTMLG", OracleDbType.Int32).Value = objDetail.VhclPrsntMlg;
                            cmdAddInsertDetail.Parameters.Add("D_DESC", OracleDbType.Varchar2).Value = objDetail.SubmsnDtlDesc;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }


                    //insert to  additional jobs table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityAddtnlJobsListAdd)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_INSERT_DUTYSBMSN_ADTL_JOBS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    //UPDATE  additional jobs table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityAddtnlJobsListUpdate)
                    {
                        string strQueryInsertDetail = "DUTY_ROSTER.SP_UPD_DUTYSBMSN_ADTL_JOBS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                            cmdAddInsertDetail.Parameters.Add("D_DTLID", OracleDbType.Int32).Value = objDetail.JobSchdlDtlId;
                            cmdAddInsertDetail.Parameters.Add("D_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("D_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            cmdAddInsertDetail.Parameters.Add("D_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strCanclDtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "DUTY_ROSTER.DELETE_ADTL_JOBS";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;
                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("D_DTLID", OracleDbType.Int32).Value = intDtlId;
                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
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
        //To read duty submission status details
        public DataTable ReadSts()
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_STS";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        // This Method will fetch emlpoyee wise leave details
        public DataTable ReadLeaveDtlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_LEAVEDTL_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }

        // This Method will fetch emlpoyee wise leave details for a single day
        public DataTable ReadSingleLeaveDtlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_SINGL_LEAVE_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_TO_DT", OracleDbType.Date).Value = objEntityDutyRost.ToDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        // This Method confirm submission details
        public void confirmSubmision(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryUpdateFuelType = "DUTY_ROSTER.SP_CNFRM_SBMSN";
            using (OracleCommand cmdUpdateFuelType = new OracleCommand())
            {
                cmdUpdateFuelType.CommandText = strQueryUpdateFuelType;
                cmdUpdateFuelType.CommandType = CommandType.StoredProcedure;

                cmdUpdateFuelType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                cmdUpdateFuelType.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                cmdUpdateFuelType.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateFuelType);
            }
        }
        // This Method reopen submission details
        public void reopenSubmision(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryUpdateFuelType = "DUTY_ROSTER.SP_REOPEN_SBMSN";
            using (OracleCommand cmdUpdateFuelType = new OracleCommand())
            {
                cmdUpdateFuelType.CommandText = strQueryUpdateFuelType;
                cmdUpdateFuelType.CommandType = CommandType.StoredProcedure;
                cmdUpdateFuelType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
                cmdUpdateFuelType.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                cmdUpdateFuelType.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateFuelType);
            }
        }
        //STOP:-EVM-0009


        //For reading week wise duty off
        public DataTable ReadWeeklyDutyOff(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpOff = "DUTY_ROSTER.SP_READ_WKLY_OFFDTY";
            OracleCommand cmdReadEmpOff = new OracleCommand();
            cmdReadEmpOff.CommandText = strQueryReadEmpOff;
            cmdReadEmpOff.CommandType = CommandType.StoredProcedure;
            cmdReadEmpOff.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdReadEmpOff.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdReadEmpOff.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpOff);
            return dtJobShdlList;
        }

        //For reading month wise duty off
        public DataTable ReadMonthlyDutyOff(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpOff = "DUTY_ROSTER.SP_READ_MNTHLY_OFFDTY";
            OracleCommand cmdReadEmpOff = new OracleCommand();
            cmdReadEmpOff.CommandText = strQueryReadEmpOff;
            cmdReadEmpOff.CommandType = CommandType.StoredProcedure;
            cmdReadEmpOff.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdReadEmpOff.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdReadEmpOff.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpOff);
            return dtJobShdlList;
        }


        // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadDutyShdlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadEmpJob = "DUTY_ROSTER.SP_READ_DUTYSHDL_BY_EMP";
            OracleCommand cmdReadEmpJob = new OracleCommand();
            cmdReadEmpJob.CommandText = strQueryReadEmpJob;
            cmdReadEmpJob.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJob.Parameters.Add("D_EMP_ID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadEmpJob.Parameters.Add("D_FRM_DT", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
            cmdReadEmpJob.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtJobShdlList = new DataTable();
            dtJobShdlList = clsDataLayer.ExecuteReader(cmdReadEmpJob);
            return dtJobShdlList;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadCorp = "DUTY_ROSTER.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadEmpDetail(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadCorp = "DUTY_ROSTER.SP_READ_EMPLOYEE_DETAIL";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        // This Method confirm submission details
        public void PrintStsUpdate(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryUpdateFuelType = "DUTY_ROSTER.SP_PRINT_STS_UPDT";
            using (OracleCommand cmdUpdateFuelType = new OracleCommand())
            {
                cmdUpdateFuelType.CommandText = strQueryUpdateFuelType;
                cmdUpdateFuelType.CommandType = CommandType.StoredProcedure;

                cmdUpdateFuelType.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.DutyRosterId;
                cmdUpdateFuelType.Parameters.Add("D_USRID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
                cmdUpdateFuelType.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateFuelType);
            }
        }



        public void AddLeavAlloctnDetails(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryReadEmploy = "DUTY_ROSTER.SP_INS_LEAVALLOCTN_DETAILS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadEmploy;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;

                clsEntityCommon objEntCommon = new clsEntityCommon();
                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_ALLOCATION);
                objEntCommon.CorporateID = objEntityDutyRost.Corporate_id;
                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                int intLeaveId = Convert.ToInt32(strNextNum);

                cmdReadEmp.Parameters.Add("L_LEAVID", OracleDbType.Int32).Value = intLeaveId;
                cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityDutyRost.EmployeeId;
                cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = 1;
                cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityDutyRost.LeaveDate;
                cmdReadEmp.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = 1;
                cmdReadEmp.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = 1;
                cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
                cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
                cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }


        public DataTable readVhclDetails(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadCorp = "DUTY_ROSTER.SP_READ_VHCL_DETAIL";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public void updateVhclMlg(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryReadEmploy = "DUTY_ROSTER.SP_UPD_VHCL_MLG";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadEmploy;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("D_VHCLID", OracleDbType.Int32).Value = objEntityDutyRost.VehiclleId;
                cmdReadEmp.Parameters.Add("D_MLG", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
               clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }
        //Start:-EMP-0009
        public void UpdateDutySlipSts(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryReadEmploy = "DUTY_ROSTER.SP_UPD_DTYSLP_STS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadEmploy;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDutyRost.Organisation_id;
                cmdReadEmp.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityDutyRost.Corporate_id;
                cmdReadEmp.Parameters.Add("D_DATE", OracleDbType.Date).Value = objEntityDutyRost.FromDate;
                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }
        public DataTable readEmpDateDtls(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            string strQueryReadCorp = "DUTY_ROSTER.SP_READ_EMP_DATE_DTLS";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDutyRost.User_Id;
            cmdReadCorp.Parameters.Add("D_SUBID", OracleDbType.Int32).Value = objEntityDutyRost.SubmissionId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        //End:EMP-0009
    }
}
