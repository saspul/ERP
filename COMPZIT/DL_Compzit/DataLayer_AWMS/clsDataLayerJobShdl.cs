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
// CREATED BY:EVM-0001
// CREATED DATE:27/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
 public class clsDataLayerJobShdl
    {

        // This Method will fetch time slots
        public DataTable ReadTimeSlotMasters( clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadTimeSlot = "JOB_SCHEDULE.SP_READ_TIMESLOTLIST";
            OracleCommand cmdReadTimeSlot = new OracleCommand();
            cmdReadTimeSlot.CommandText = strQueryReadTimeSlot;
            cmdReadTimeSlot.CommandType = CommandType.StoredProcedure;
            cmdReadTimeSlot.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadTimeSlot.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadTimeSlot.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadTimeSlot);
            return dtRecords;
        }
        // This Method will FETCH DETAIL FROM TIMESLOT MASTER REGARDING THE TIMESLOT SELECTED
        public DataTable ReadTimeSlotById(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadTimeSlot = "JOB_SCHEDULE.SP_READ_TIMESLOTDTL_BYID";
            OracleCommand cmdReadTimeSlot = new OracleCommand();
            cmdReadTimeSlot.CommandText = strQueryReadTimeSlot;
            cmdReadTimeSlot.CommandType = CommandType.StoredProcedure;
            cmdReadTimeSlot.Parameters.Add("J_TIMESLOTID", OracleDbType.Int32).Value = objEntityJobShdl.TimeSlotId;
            cmdReadTimeSlot.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadTimeSlot.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadTimeSlot.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadTimeSlot);
            return dtRecords;
        }


        // This Method will fetch Jobs  For autocompletion from WebService
        public DataTable ReadJobsWebService(string strLikeJobName, clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadJobs = "JOB_SCHEDULE.SP_READ_JOB_NAME_WEBSERVICE";
            OracleCommand cmdReadJobs = new OracleCommand();
            cmdReadJobs.CommandText = strQueryReadJobs;
            cmdReadJobs.CommandType = CommandType.StoredProcedure;
            cmdReadJobs.Parameters.Add("J_JOBLIKENAME", OracleDbType.Varchar2).Value = strLikeJobName;
            cmdReadJobs.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadJobs.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadJobs.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadJobs);
            return dtList;
        }
        // This Method will fetch Vehicle  For autocompletion from WebService
        public DataTable ReadVehiclesWebService(string strLikeVhclNumbr, clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadVhcls = "JOB_SCHEDULE.SP_READ_VHCL_NUMBR_WEBSERVICE";
            OracleCommand cmdReadVhcls = new OracleCommand();
            cmdReadVhcls.CommandText = strQueryReadVhcls;
            cmdReadVhcls.CommandType = CommandType.StoredProcedure;
            cmdReadVhcls.Parameters.Add("J_VHCLLIKENUMBR", OracleDbType.Varchar2).Value = strLikeVhclNumbr;
            cmdReadVhcls.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadVhcls.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadVhcls.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadVhcls);
            return dtList;
        }
        // This Method will fetch Vehicle  For autocompletion from WebService
        public DataTable ReadProjectsWebService(string strLikeProjectName, clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadPrjcts = "JOB_SCHEDULE.SP_READ_PRJCT_NAME_WEBSERVICE";
            OracleCommand cmdReadPrjcts = new OracleCommand();
            cmdReadPrjcts.CommandText = strQueryReadPrjcts;
            cmdReadPrjcts.CommandType = CommandType.StoredProcedure;
            cmdReadPrjcts.Parameters.Add("J_PRJCTLIKENAME", OracleDbType.Varchar2).Value = strLikeProjectName;
            cmdReadPrjcts.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadPrjcts.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadPrjcts.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadPrjcts);
            return dtList;
        }

        // This Method will fetch Time list  For autocompletion from WebService
        public DataTable ReadTimeListWebService(string strLikeTime, clsEntityLayerJobScheduleDtl objEntityJobShdlDtl)
        {
            string strQueryReadTime = "JOB_SCHEDULE.SP_READ_TIME_LIST_WEBSERVICE";
            OracleCommand cmdReadTime = new OracleCommand();
            cmdReadTime.CommandText = strQueryReadTime;
            cmdReadTime.CommandType = CommandType.StoredProcedure;
            cmdReadTime.Parameters.Add("J_TIMEDIFFSTS", OracleDbType.Int32).Value = objEntityJobShdlDtl.TimeDiffrncSts;
            cmdReadTime.Parameters.Add("J_STR_FROM_TIME", OracleDbType.Varchar2).Value = objEntityJobShdlDtl.FromTimeString;
            cmdReadTime.Parameters.Add("J_STR_TO_TIME", OracleDbType.Varchar2).Value = objEntityJobShdlDtl.ToTimeString;
            cmdReadTime.Parameters.Add("J_TIMELIKENAME", OracleDbType.Varchar2).Value = strLikeTime;       
            cmdReadTime.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadTime);
            return dtList;
        }


        //insert Quatation details to  table
        public int Insert_JobScheduling(clsEntityLayerJobSchedule objEntityJobShdl, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsPeriodWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsDayWise, List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtl)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertJobShdl = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG";
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
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOBSCHDL);
                        objEntCommon.CorporateID = objEntityJobShdl.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityJobShdl.JobSchdlId = Convert.ToInt32(strNextNum);

                        cmdInsertJobSchdlng.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                        cmdInsertJobSchdlng.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
                        cmdInsertJobSchdlng.Parameters.Add("J_FRMDATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
                        cmdInsertJobSchdlng.Parameters.Add("J_TODATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
                        cmdInsertJobSchdlng.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
                        cmdInsertJobSchdlng.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                        cmdInsertJobSchdlng.Parameters.Add("J_INSUSERID", OracleDbType.Int32).Value = objEntityJobShdl.User_Id;
                        cmdInsertJobSchdlng.ExecuteNonQuery();

                    }
                    //insert to  Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsPeriodWise)
                    {
                        string strQueryInsertDetail = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                            cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                            cmdAddInsertDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddInsertDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                            cmdAddInsertDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddInsertDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    if (objEntityJobShdl.IsWeekWiseAvailable != 0)
                    {
                        foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsDayWise)
                        {


                            string strQueryInsertDetail = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_DTL";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                                cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                                cmdAddInsertDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                                cmdAddInsertDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                                cmdAddInsertDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                                cmdAddInsertDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                                cmdAddInsertDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                                cmdAddInsertDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                                if (objDetail.JobId == 0)
                                {
                                    cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                                }
                                cmdAddInsertDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                                cmdAddInsertDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }

                        if (objEntityJobScheduleWeekDayDtl != null)
                        {
                            string strQueryInsertWeekDtl = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_WEEKDTL";
                            foreach (clsEntityLayerJobSchdlWeekDayDtl objDetail in objEntityJobScheduleWeekDayDtl)
                            {
                                using (OracleCommand cmdInsertWeekDtl = new OracleCommand())
                                {
                                    cmdInsertWeekDtl.Transaction = tran;
                                    cmdInsertWeekDtl.Connection = con;
                                    cmdInsertWeekDtl.CommandText = strQueryInsertWeekDtl;
                                    cmdInsertWeekDtl.CommandType = CommandType.StoredProcedure;
                                    cmdInsertWeekDtl.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                                    cmdInsertWeekDtl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                                    cmdInsertWeekDtl.Parameters.Add("J_WEEKDAYSNUMBR", OracleDbType.Int32).Value = objDetail.WeekDaysId;
                                    cmdInsertWeekDtl.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    tran.Commit();
                    return objEntityJobShdl.JobSchdlId;
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }
        // This Method FETCHES  DETAILS BASED ON  AND SHDLWISE_MODE ID FOR DISPALYING
        public DataTable ReadJobSchdlDetail(clsEntityLayerJobSchedule objEntityJobShdl,int intSchdlWiseMode)
        {
            string strQueryReadJSDtl = "JOB_SCHEDULE.SP_READ_JOBSHDL_DTL";
            OracleCommand cmdReadDtl = new OracleCommand();
            cmdReadDtl.CommandText = strQueryReadJSDtl;
            cmdReadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadDtl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdReadDtl.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadDtl.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadDtl.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = intSchdlWiseMode;
            cmdReadDtl.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadDtl);
            return dtDtl;
        }
        // This Method FETCHES  DETAILS BASED ON  AND SHDLWISE_MODE ID FOR DISPALYING
        public DataTable ReadJobSchdlWeekDetail(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadJSDtl = "JOB_SCHEDULE.SP_READ_JOBSHDL_WEEKDTL";
            OracleCommand cmdReadDtl = new OracleCommand();
            cmdReadDtl.CommandText = strQueryReadJSDtl;
            cmdReadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadDtl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;          
            cmdReadDtl.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadDtl);
            return dtDtl;
        }


        //Update  details to  table
        public void Update_JobScheduling(clsEntityLayerJobSchedule objEntityJobShdl, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsINSERTPeriodWise,List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsUPDATEPeriodWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsINSERTDayWise,List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsUPDATEDayWise, List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtl,  string[] strarrCancldtlIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateJobShdl = "JOB_SCHEDULE.SP_UPDATE_JOBSHDL";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdUpdateJobShdl = new OracleCommand(strQueryUpdateJobShdl, con))
                    {
                        cmdUpdateJobShdl.Transaction = tran;

                        cmdUpdateJobShdl.CommandType = CommandType.StoredProcedure;

                        cmdUpdateJobShdl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                        cmdUpdateJobShdl.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
                        cmdUpdateJobShdl.Parameters.Add("J_FRMDATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
                        cmdUpdateJobShdl.Parameters.Add("J_TODATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
                        cmdUpdateJobShdl.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
                        cmdUpdateJobShdl.Parameters.Add("J_UPDUSERID", OracleDbType.Int32).Value = objEntityJobShdl.User_Id;
                        cmdUpdateJobShdl.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityJobShdl.D_Date;
                        cmdUpdateJobShdl.ExecuteNonQuery();

                    }

                    //delete Week Details
                    string strQueryDeleteWeekDetail = "JOB_SCHEDULE.SP_DELETE_JOBSHDL_WEEKDTL";
                    using (OracleCommand cmdDltWeekDetail = new OracleCommand(strQueryDeleteWeekDetail, con))
                    {
                        cmdDltWeekDetail.Transaction = tran;

                        cmdDltWeekDetail.CommandType = CommandType.StoredProcedure;
                        cmdDltWeekDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;

                        cmdDltWeekDetail.ExecuteNonQuery();
                    }

                    //Update to  quotation Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsUPDATEPeriodWise)
                    {

                        string strQueryUpdateDetail = "JOB_SCHEDULE.SP_UPDATE_JOBSHDL_DTL";
                        using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                        {
                            cmdUpdateDetail.Transaction = tran;

                            cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                            cmdUpdateDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                            cmdUpdateDetail.Parameters.Add("J_DTLID", OracleDbType.Int32).Value = objDetail.JobSchdlDtlId;
                            cmdUpdateDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdUpdateDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                            cmdUpdateDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdUpdateDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdUpdateDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdUpdateDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdUpdateDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdUpdateDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdUpdateDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdUpdateDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                            cmdUpdateDetail.ExecuteNonQuery();
                        }
                    }


                   

                    //Update to  quotation Detail table
                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsUPDATEDayWise)
                    {

                        string strQueryUpdateDetail = "JOB_SCHEDULE.SP_UPDATE_JOBSHDL_DTL";
                        using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                        {
                            cmdUpdateDetail.Transaction = tran;

                            cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                            cmdUpdateDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                            cmdUpdateDetail.Parameters.Add("J_DTLID", OracleDbType.Int32).Value = objDetail.JobSchdlDtlId;
                            cmdUpdateDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdUpdateDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                            cmdUpdateDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdUpdateDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdUpdateDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdUpdateDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdUpdateDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value =null;

                            }
                            else
                            {
                                cmdUpdateDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdUpdateDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdUpdateDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                            cmdUpdateDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsINSERTPeriodWise)
                    {


                        string strQueryInsertDetail = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                            cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                            cmdAddInsertDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                            cmdAddInsertDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                            cmdAddInsertDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                            cmdAddInsertDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                            cmdAddInsertDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                            cmdAddInsertDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                            if (objDetail.JobId == 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                            }
                            cmdAddInsertDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                            cmdAddInsertDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    if (objEntityJobShdl.IsWeekWiseAvailable != 0)
                    {
                        foreach (clsEntityLayerJobScheduleDtl objDetail in objEntityJobScheduleDtlsINSERTDayWise)
                        {


                            string strQueryInsertDetail = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_DTL";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                                cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                                cmdAddInsertDetail.Parameters.Add("J_TMSLTID", OracleDbType.Int32).Value = objDetail.TimeSlotId;
                                cmdAddInsertDetail.Parameters.Add("J_SHDLWISE_MODE", OracleDbType.Int32).Value = objDetail.SchdlWiseMode;
                                cmdAddInsertDetail.Parameters.Add("J_FROM_TIME", OracleDbType.TimeStamp).Value = objDetail.FromTime;
                                cmdAddInsertDetail.Parameters.Add("J_TO_TIME", OracleDbType.TimeStamp).Value = objDetail.ToTime;
                                cmdAddInsertDetail.Parameters.Add("J_VHCLID", OracleDbType.Int32).Value = objDetail.VhclId;
                                cmdAddInsertDetail.Parameters.Add("J_PRJCTID", OracleDbType.Int32).Value = objDetail.PrjctId;
                                if (objDetail.JobId == 0)
                                {
                                    cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdAddInsertDetail.Parameters.Add("J_JOBID", OracleDbType.Int32).Value = objDetail.JobId;
                                }
                                cmdAddInsertDetail.Parameters.Add("J_JOBNAME", OracleDbType.Varchar2).Value = objDetail.JobName;
                                cmdAddInsertDetail.Parameters.Add("J_JOBMODE", OracleDbType.Int32).Value = objDetail.JobMode;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }

                        if (objEntityJobScheduleWeekDayDtl != null)
                        {
                            string strQueryInsertWeekDtl = "JOB_SCHEDULE.SP_INSERT_JOBSHDLNG_WEEKDTL";
                            foreach (clsEntityLayerJobSchdlWeekDayDtl objDetail in objEntityJobScheduleWeekDayDtl)
                            {
                                using (OracleCommand cmdInsertWeekDtl = new OracleCommand())
                                {
                                    cmdInsertWeekDtl.Transaction = tran;
                                    cmdInsertWeekDtl.Connection = con;
                                    cmdInsertWeekDtl.CommandText = strQueryInsertWeekDtl;
                                    cmdInsertWeekDtl.CommandType = CommandType.StoredProcedure;
                                    cmdInsertWeekDtl.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
                                    cmdInsertWeekDtl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                                    cmdInsertWeekDtl.Parameters.Add("J_WEEKDAYSNUMBR", OracleDbType.Int32).Value = objDetail.WeekDaysId;
                                    cmdInsertWeekDtl.ExecuteNonQuery();
                                }
                            }
                        }
                    }


                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "JOB_SCHEDULE.SP_CANCEL_JOBSHDL_DTL";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;

                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                                cmdCancelDetail.Parameters.Add("J_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    //Confirm 
                    if (objEntityJobShdl.ToConfirm == 1)
                    {
                        string strQueryInsertDetail = "JOB_SCHEDULE.SP_CONFIRM_JOBSHDL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                            cmdAddInsertDetail.Parameters.Add("J_CNFRM_USRID", OracleDbType.Int32).Value = objEntityJobShdl.User_Id;
                            cmdAddInsertDetail.Parameters.Add("J_CNFRM_DATE", OracleDbType.Date).Value = objEntityJobShdl.D_Date;
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
         //start-0009
        // This Method will FETCH DETAIL FROM TIMESLOT MASTER REGARDING THE TIMESLOT SELECTED
        public DataTable ReadFromToDateByUsrId(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadFromToDate = "JOB_SCHEDULE.SP_READ_DATEDTL_BYUSERID";
            OracleCommand cmdReadFromToDate = new OracleCommand();
            cmdReadFromToDate.CommandText = strQueryReadFromToDate;
            cmdReadFromToDate.CommandType = CommandType.StoredProcedure;
            cmdReadFromToDate.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
            cmdReadFromToDate.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadFromToDate.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadFromToDate.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdReadFromToDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadFromToDate);
            return dtRecords;
        }
        // This Method will fetch employee job schedule details
        public DataTable ReadEmployeeJSList(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadEmpJS = "JOB_SCHEDULE.SP_READ_EMP_JSLIST";
            OracleCommand cmdReadEmpJS = new OracleCommand();
            cmdReadEmpJS.CommandText = strQueryReadEmpJS;
            cmdReadEmpJS.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJS.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdReadEmpJS.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdReadEmpJS.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadEmpJS);
            return dtRecords;
        }
        // This Method will fetch number of job schedule against a employee
        public DataTable ReadEmployeeNoOfJSList(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadEmpJS = "JOB_SCHEDULE.SP_READ_EMP_NO_JSLIST";
            OracleCommand cmdReadEmpJS = new OracleCommand();
            cmdReadEmpJS.CommandText = strQueryReadEmpJS;
            cmdReadEmpJS.CommandType = CommandType.StoredProcedure;
            cmdReadEmpJS.Parameters.Add("J_EMPID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
            cmdReadEmpJS.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadEmpJS);
            return dtRecords;
        }
        // This Method will fetch employee name
        public DataTable ReadEmpName(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryReadEmp = "JOB_SCHEDULE.SP_READ_EMP_NAME";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("J_EMPID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
            cmdReadEmp.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtRecords;
        }
        public void CloseSchedule(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryCloseOther = "JOB_SCHEDULE.SP_CLOSE_SCHEDULE";
            using (OracleCommand cmdCloseOther = new OracleCommand())
            {
                cmdCloseOther.CommandText = strQueryCloseOther;
                cmdCloseOther.CommandType = CommandType.StoredProcedure;
                cmdCloseOther.Parameters.Add("J_SHDLID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                cmdCloseOther.Parameters.Add("J_UID", OracleDbType.Int32).Value = objEntityJobShdl.User_Id;
                cmdCloseOther.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityJobShdl.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdCloseOther);
            }
        }
     //stop-0009
     //EVM-0012 start
        public void JobScheduleConfirmRecl(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryConfirmRecl = "JOB_SCHEDULE.SP_UPDATE_JOBSHDL_CNFRMRECL";
            using (OracleCommand cmdConfirmRecl = new OracleCommand())
            {
                cmdConfirmRecl.CommandText = strQueryConfirmRecl;
                cmdConfirmRecl.CommandType = CommandType.StoredProcedure;
                cmdConfirmRecl.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
                cmdConfirmRecl.Parameters.Add("JOBSHDL_CNFRMRECL_USR_ID", OracleDbType.Int32).Value = objEntityJobShdl.User_Id;
                cmdConfirmRecl.Parameters.Add("JOBSHDL_CNFRMRECL_DATE", OracleDbType.Date).Value = objEntityJobShdl.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdConfirmRecl);
            }
        }
     // METHOD TO FETCH TIME OF VHCL BY START ANS END DATE
        public DataTable ReadVhclDtlByDate(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_READ_VHCL_DTL_BY_DATE";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_VHCL_ID", OracleDbType.Int32).Value = objEntityJobShdl.VehicleID;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }
        //EVM-0012 end
        public DataTable ReadDutyRstr(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_READ_DUTYRSTR";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_EMP_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlUserId;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }
        public DataTable readVhclScdldDtls(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_READ_VHCL_SHDL_DTLS";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_VHCL_ID", OracleDbType.Int32).Value = objEntityJobShdl.VehicleID;
            cmdVhclDtlByDate.Parameters.Add("J_DTL_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }

        public DataTable readDays(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_READ_DAYS";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }
       

     //Start:-EMP-0009
        public DataTable readVhclScdldDtlsDuty(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_RD_VHCL_SDL_DTLS_DUTY";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_VHCL_ID", OracleDbType.Int32).Value = objEntityJobShdl.VehicleID;
            cmdVhclDtlByDate.Parameters.Add("J_DTL_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;         
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }

        public DataTable ReadPrjctByVhcl(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_RD_PRJCT_BY_VHCL";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_VHCL_ID", OracleDbType.Int32).Value = objEntityJobShdl.VehicleID;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
            cmdVhclDtlByDate.Parameters.Add("J_CORPT_ID", OracleDbType.Int32).Value = objEntityJobShdl.CorpOffice_Id;
            cmdVhclDtlByDate.Parameters.Add("J_ORG_ID", OracleDbType.Int32).Value = objEntityJobShdl.Organisation_Id;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }



        public DataTable readVhclScdldDtlsScdlID(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            string strQueryVhclDtlByDate = "JOB_SCHEDULE.SP_READ_VHCL_SHDL_IDS";
            OracleCommand cmdVhclDtlByDate = new OracleCommand();
            cmdVhclDtlByDate.CommandText = strQueryVhclDtlByDate;
            cmdVhclDtlByDate.CommandType = CommandType.StoredProcedure;
            cmdVhclDtlByDate.Parameters.Add("J_VHCL_ID", OracleDbType.Int32).Value = objEntityJobShdl.VehicleID;
            cmdVhclDtlByDate.Parameters.Add("J_DTL_ID", OracleDbType.Int32).Value = objEntityJobShdl.JobSchdlId;
            cmdVhclDtlByDate.Parameters.Add("J_END_DATE", OracleDbType.Date).Value = objEntityJobShdl.Todate;
            cmdVhclDtlByDate.Parameters.Add("J_START_DATE", OracleDbType.Date).Value = objEntityJobShdl.Fromdate;
            cmdVhclDtlByDate.Parameters.Add("J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRecords = new DataTable();
            dtRecords = clsDataLayer.ExecuteReader(cmdVhclDtlByDate);
            return dtRecords;
        }
       
     //End:-EMP-0009
    }
}
