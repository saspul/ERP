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
   public class clsDataLayerEmployeeDailyWorkHour
    {
        //This Method for checking employee name
        public DataTable checkEmpcode(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_EMPCODE";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_CODE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.ActFileName;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHour.DateOfWork;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }
        //This Method for checking employee name
        public DataTable checkJobname(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_JOBNAME";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_JOB", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.FileName;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }


        //Insert into the tables
        public void InsertDailyWorkHourSheet(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour, List<clsEntityEmployeeDailyWorkHourDtl> objEntityEmpDailyHrList, string[] strarrDupValues)     
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strinsertimgrnd = "EMPLOYEE_DAILY_WORK_HOUR.SP_INS_DAILY_WORK_HOUR_MSTR";
                    using (OracleCommand cmdInsImgrtnrnd = new OracleCommand())
                    {
                        cmdInsImgrtnrnd.Transaction = tran;
                        cmdInsImgrtnrnd.Connection = con;

                        cmdInsImgrtnrnd.CommandText = strinsertimgrnd;
                        cmdInsImgrtnrnd.CommandType = CommandType.StoredProcedure;
                        cmdInsImgrtnrnd.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.EmpDlyWrkHrID;
                        cmdInsImgrtnrnd.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHour.DateOfWork;
                        cmdInsImgrtnrnd.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.HolidaySts;
                        cmdInsImgrtnrnd.Parameters.Add("E_FILE_NAME", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.FileName;
                        cmdInsImgrtnrnd.Parameters.Add("E_ACT_FILE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.ActFileName;
                        cmdInsImgrtnrnd.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                        cmdInsImgrtnrnd.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                        cmdInsImgrtnrnd.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.UserId;
                        cmdInsImgrtnrnd.Parameters.Add("E_IDLE_HR_CMN", OracleDbType.Decimal).Value = objEntityEmpDailyWorkHour.IdleHourCmn;
                        cmdInsImgrtnrnd.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                        cmdInsImgrtnrnd.ExecuteNonQuery();
                    }

                    string strinsertimgrnddtls = "EMPLOYEE_DAILY_WORK_HOUR.SP_INS_DAILY_WORK_HOUR_DTLS";                
                    foreach (clsEntityEmployeeDailyWorkHourDtl objWrkDtl in objEntityEmpDailyHrList)
                    {
                        using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                        {
                            cmdinsImgrtnrndDtls.Transaction = tran;
                            cmdinsImgrtnrndDtls.Connection = con;

                            cmdinsImgrtnrndDtls.CommandText = strinsertimgrnddtls;
                            cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.EmpDlyWrkHrID;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objWrkDtl.UserId;
                            if (objWrkDtl.OT != 0)
                            {
                                cmdinsImgrtnrndDtls.Parameters.Add("E_OT", OracleDbType.Decimal).Value = objWrkDtl.OT;
                            }
                            else
                            {
                                cmdinsImgrtnrndDtls.Parameters.Add("E_OT", OracleDbType.Decimal).Value = null;
                            }
                            cmdinsImgrtnrndDtls.Parameters.Add("E_REMARK", OracleDbType.Varchar2).Value = objWrkDtl.Remark;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_NAME", OracleDbType.Varchar2).Value = objWrkDtl.EmployeeName;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_DESG", OracleDbType.Varchar2).Value = objWrkDtl.Designation;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_ATT", OracleDbType.Varchar2).Value = objWrkDtl.Attendance;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_IDLE_HR", OracleDbType.Decimal).Value = objWrkDtl.IdleHour;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_RNDED_OT", OracleDbType.Decimal).Value = objWrkDtl.RoundedOT;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_PROJECT_ID", OracleDbType.Varchar2).Value = objWrkDtl.ProjectId;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = objWrkDtl.InsTableSts;
                            cmdinsImgrtnrndDtls.ExecuteNonQuery();
                        }
                    }


                    string strinsertimgrnddtlss = "EMPLOYEE_DAILY_WORK_HOUR.SP_DELE_DAILY_WORK_HOUR_DTLS";

                  
                    if(strarrDupValues!=null){
                    foreach (string strDtlId in strarrDupValues)
                    {
                        string[] strarrDup = strDtlId.Split('-');
                        if (strarrDup[0] !="")
                        {

                            using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                            {
                                cmdinsImgrtnrndDtls.Transaction = tran;
                                cmdinsImgrtnrndDtls.Connection = con;
                                cmdinsImgrtnrndDtls.CommandText = strinsertimgrnddtlss;
                                cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                                cmdinsImgrtnrndDtls.Parameters.Add("E_ID", OracleDbType.Int32).Value = Convert.ToInt32(strarrDup[0]);
                                cmdinsImgrtnrndDtls.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                                cmdinsImgrtnrndDtls.ExecuteNonQuery();
                            }
                        }
                    }
                }






                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }


        //This Method for read worksheet list
        public DataTable readDailywrksheetList(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_WRKSHEET_LIST";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                //cmdReadConsultancytype.Parameters.Add("E_MONTH", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.Month;
                //cmdReadConsultancytype.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.Year;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.StrDate;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }
        //This Method for read worksheet sheet details
        public DataTable readDailywrksheetDtls(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_WRKSHEET_DTL";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.EmpDlyWrkHrID;
                cmdReadConsultancytype.Parameters.Add("E_ATTENDANCE_MODE", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.AttandanceMode;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        //This Method for reading OT categories
        public DataTable readOTcategories(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_OT_CTGRS";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }


        //This Method for check holiday
        public DataTable checkHoliday(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHK_HOLIDAY";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHour.DateOfWork;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        public DataTable readDailywrkShtMnthYear(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_RD_WRKSHT_MNTH_AND_YEAR";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        public void UpdateWrkDtl(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_UPD_WRK_DTL";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdAddConsultancyMstr.Parameters.Add("E_IDLE_HR", OracleDbType.Decimal).Value = objEntityEmpDailyWorkHourDtl.IdleHour;
                cmdAddConsultancyMstr.Parameters.Add("E_RNDED_OT", OracleDbType.Decimal).Value = objEntityEmpDailyWorkHourDtl.RoundedOT;
                cmdAddConsultancyMstr.Parameters.Add("E_REMRK", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHourDtl.Remark;
                cmdAddConsultancyMstr.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.InsTableSts;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }

        public void ConfirmDtls(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_CNFRM_WRK_DTL";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.EmpDlyWrkHrID;
                cmdAddConsultancyMstr.Parameters.Add("E_USER_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.UserId;
                cmdAddConsultancyMstr.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }

        public DataTable ConfrmSts(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_RD_CNFRM_STS";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }


        public DataTable checkEmpcodeDB(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_EMPCODE_DB";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_CODE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.ActFileName;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHour.DateOfWork;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }


        public void ReopenAttendanceSheet(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_REOPN_WRK_DTL";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHourDtl.DateOfWork;
                cmdAddConsultancyMstr.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.EmpDlyWrkHrID;
                cmdAddConsultancyMstr.Parameters.Add("E_USER_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdAddConsultancyMstr.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.InsTableSts;
                cmdAddConsultancyMstr.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.CorpId;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }





        }



        //This Method for checking employee name
        public DataTable checkProjectCode(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_PROJCT_CODE";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_CODE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.FileName;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        //This Method for read worksheet list
        public DataTable readLastDailywrksheetList(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_LAST_WRKSHEET_LIST";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        public DataTable checkOTCategory(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_OT_CATEGORY";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_OTCATG", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.OTCatgName;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        public void InsertMonthlyWorkHourSheet(List<clsEntityEmployeeDailyWorkHour> objEntityEmpDailyMasterList, List<clsEntityEmployeeDailyWorkHourDtl> objEntityEmpDailyHrList, string[] strarrDupValues)
        {
            int insTableSts = 0;
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertimgrnd = "EMPLOYEE_DAILY_WORK_HOUR.SP_INS_DAILY_WORK_HOUR_MSTR";                   
                    foreach (clsEntityEmployeeDailyWorkHour objWrk in objEntityEmpDailyMasterList)
                    {
                        using (OracleCommand cmdInsImgrtnrnd = new OracleCommand())
                        {
                            cmdInsImgrtnrnd.Transaction = tran;
                            cmdInsImgrtnrnd.Connection = con;

                            cmdInsImgrtnrnd.CommandText = strinsertimgrnd;
                            cmdInsImgrtnrnd.CommandType = CommandType.StoredProcedure;
                            cmdInsImgrtnrnd.Parameters.Add("E_ID", OracleDbType.Int32).Value = objWrk.EmpDlyWrkHrID;
                            cmdInsImgrtnrnd.Parameters.Add("E_DATE", OracleDbType.Date).Value = objWrk.DateOfWork;
                            cmdInsImgrtnrnd.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = objWrk.HolidaySts;
                            cmdInsImgrtnrnd.Parameters.Add("E_FILE_NAME", OracleDbType.Varchar2).Value = objWrk.FileName;
                            cmdInsImgrtnrnd.Parameters.Add("E_ACT_FILE", OracleDbType.Varchar2).Value = objWrk.ActFileName;
                            cmdInsImgrtnrnd.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objWrk.CorpId;
                            cmdInsImgrtnrnd.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objWrk.orgid;
                            cmdInsImgrtnrnd.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objWrk.UserId;
                            cmdInsImgrtnrnd.Parameters.Add("E_IDLE_HR_CMN", OracleDbType.Decimal).Value = objWrk.IdleHourCmn;
                            cmdInsImgrtnrnd.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = objWrk.InsTableSts;
                            insTableSts = objWrk.InsTableSts;
                            cmdInsImgrtnrnd.ExecuteNonQuery();
                        }
                    }

                    string strinsertimgrnddtls = "EMPLOYEE_DAILY_WORK_HOUR.SP_INS_DAILY_WORK_HOUR_DTLS";
                    foreach (clsEntityEmployeeDailyWorkHourDtl objWrkDtl in objEntityEmpDailyHrList)
                    {
                        using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                        {
                            cmdinsImgrtnrndDtls.Transaction = tran;
                            cmdinsImgrtnrndDtls.Connection = con;

                            cmdinsImgrtnrndDtls.CommandText = strinsertimgrnddtls;
                            cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_ID", OracleDbType.Int32).Value = objWrkDtl.EmpDlyWrkHrID;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objWrkDtl.UserId;
                            if (objWrkDtl.OT != 0)
                            {
                                cmdinsImgrtnrndDtls.Parameters.Add("E_OT", OracleDbType.Decimal).Value = objWrkDtl.OT;
                            }
                            else
                            {
                                cmdinsImgrtnrndDtls.Parameters.Add("E_OT", OracleDbType.Decimal).Value = null;
                            }
                            cmdinsImgrtnrndDtls.Parameters.Add("E_REMARK", OracleDbType.Varchar2).Value = objWrkDtl.Remark;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objWrkDtl.CorpId;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_NAME", OracleDbType.Varchar2).Value = objWrkDtl.EmployeeName;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_DESG", OracleDbType.Varchar2).Value = objWrkDtl.Designation;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_ATT", OracleDbType.Varchar2).Value = objWrkDtl.Attendance;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_IDLE_HR", OracleDbType.Decimal).Value = objWrkDtl.IdleHour;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_RNDED_OT", OracleDbType.Decimal).Value = objWrkDtl.RoundedOT;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_PROJECT_ID", OracleDbType.Varchar2).Value = objWrkDtl.ProjectId;
                            cmdinsImgrtnrndDtls.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = objWrkDtl.InsTableSts;
                            cmdinsImgrtnrndDtls.ExecuteNonQuery();
                        }
                    }


                    string strinsertimgrnddtlss = "EMPLOYEE_DAILY_WORK_HOUR.SP_DELE_DAILY_WORK_HOUR_DTLS";
                    if (strarrDupValues != null)
                    {
                        foreach (string strDtlId in strarrDupValues)
                        {
                            string[] strarrDup = strDtlId.Split('-');
                            if (strarrDup[0] != "")
                            {

                                using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                                {
                                    cmdinsImgrtnrndDtls.Transaction = tran;
                                    cmdinsImgrtnrndDtls.Connection = con;
                                    cmdinsImgrtnrndDtls.CommandText = strinsertimgrnddtlss;
                                    cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                                    cmdinsImgrtnrndDtls.Parameters.Add("E_ID", OracleDbType.Int32).Value = Convert.ToInt32(strarrDup[0]);
                                    cmdinsImgrtnrndDtls.Parameters.Add("E_INS_TABLE_STS", OracleDbType.Int32).Value = insTableSts;
                                    cmdinsImgrtnrndDtls.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
        }
        public void ConfReopAll(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_CONF_REOP_ALL";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.orgid;
                cmdAddConsultancyMstr.Parameters.Add("E_CORPRTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.CorpId;
                cmdAddConsultancyMstr.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdAddConsultancyMstr.Parameters.Add("E_DATE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHourDtl.StrDate;
                cmdAddConsultancyMstr.Parameters.Add("E_MODE", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.AttandanceMode;
                cmdAddConsultancyMstr.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.InsTableSts;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }
        public DataTable checkAllConfReop(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_CHECK_ALL_CONF";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPRTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.UserId;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.StrDate;
                cmdReadConsultancytype.Parameters.Add("E_MODE", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.AttandanceMode;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }
        public DataTable ReadMasterIds(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_IDS";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_CORPRTID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.UserId;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Varchar2).Value = objEntityEmpDailyWorkHour.StrDate;
                cmdReadConsultancytype.Parameters.Add("E_MODE", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.AttandanceMode;
                cmdReadConsultancytype.Parameters.Add("E_TABLE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.InsTableSts;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }
        public DataTable ReadFirstUploadData(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_RD_FIRST_UPLOAD_DATA";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_USER_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdReadConsultancytype.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHourDtl.DateOfWork;
                cmdReadConsultancytype.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.orgid;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }

        public void removeLeaveAllocation(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_DELE_LEAVE";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_USER_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.UserId;
                cmdAddConsultancyMstr.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmpDailyWorkHourDtl.DateOfWork;
                cmdAddConsultancyMstr.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.CorpId;
                cmdAddConsultancyMstr.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.orgid;
                cmdAddConsultancyMstr.Parameters.Add("E_LEAVETYP_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.ProjectId;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }
        public void UpdateAmendmentAttendance(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl)
        {
            string strQueryAddConsultancyMstr = "EMPLOYEE_DAILY_WORK_HOUR.SP_UPD_AMENDMENT_ATTENDANCE";
            using (OracleCommand cmdAddConsultancyMstr = new OracleCommand())
            {
                cmdAddConsultancyMstr.CommandText = strQueryAddConsultancyMstr;
                cmdAddConsultancyMstr.CommandType = CommandType.StoredProcedure;
                cmdAddConsultancyMstr.Parameters.Add("E_DTL_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.EmpDlyWrkHrID;
                cmdAddConsultancyMstr.Parameters.Add("E_CHANGE_STS", OracleDbType.Int32).Value = objEntityEmpDailyWorkHourDtl.CorpId;
                cmdAddConsultancyMstr.Parameters.Add("E_ARREAR_AMNT", OracleDbType.Decimal).Value = objEntityEmpDailyWorkHourDtl.RoundedOT;
                clsDataLayer.ExecuteNonQuery(cmdAddConsultancyMstr);
            }
        }

        public DataTable readAmenmentDtl(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtConsultancytype = new DataTable();
            using (OracleCommand cmdReadConsultancytype = new OracleCommand())
            {
                cmdReadConsultancytype.CommandText = "EMPLOYEE_DAILY_WORK_HOUR.SP_READ_AMENT_DTL";
                cmdReadConsultancytype.CommandType = CommandType.StoredProcedure;
                cmdReadConsultancytype.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.EmpDlyWrkHrID;
                cmdReadConsultancytype.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.CorpId;
                cmdReadConsultancytype.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmpDailyWorkHour.orgid;
                cmdReadConsultancytype.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtConsultancytype = clsDataLayer.SelectDataTable(cmdReadConsultancytype);
            }
            return dtConsultancytype;
        }



    }
}
