using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using DL_Compzit;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerDutyRosterReports
    {
        // This Method will fetch employees working details
        public DataTable ReadDutyRosterReports(clsEntityLayerDutyRosterReports objEntityDutyRostReprt, List<clsEntityDutyRosterReportEmpselection> objlistEmplyList)
        {
            string strQueryReadEmp = "AWMS_REPORTS.SP_READ_DUTY_ROSTER_REPORT";
            DataTable dtDutyRosterList = new DataTable();
            if (objlistEmplyList.Count > 0)
            {
                foreach (clsEntityDutyRosterReportEmpselection objEmplylist in objlistEmplyList)
                {
                    DataTable dttraffic = new DataTable();
                    OracleCommand cmdReadDutyRoster = new OracleCommand();
                    cmdReadDutyRoster.CommandText = strQueryReadEmp;
                    cmdReadDutyRoster.CommandType = CommandType.StoredProcedure;
                    if (objEmplylist.DateSelection == 0)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_USERID", OracleDbType.Int32).Value = objEmplylist.EmpSelectionId;

                    }
                    else
                        cmdReadDutyRoster.Parameters.Add("SDR_USERID", OracleDbType.Int32).Value = 0;

                    cmdReadDutyRoster.Parameters.Add("SDR_ORGID", OracleDbType.Int32).Value = objEntityDutyRostReprt.OrgId;
                    cmdReadDutyRoster.Parameters.Add("SDR_CORPRTID", OracleDbType.Int32).Value = objEntityDutyRostReprt.CorprtId;
                    if (objEntityDutyRostReprt.FromDate == DateTime.MinValue)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_FROMDATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_FROMDATE", OracleDbType.Date).Value = objEntityDutyRostReprt.FromDate;
                    }

                    if (objEntityDutyRostReprt.ToDate == DateTime.MinValue)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_TODATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {

                        cmdReadDutyRoster.Parameters.Add("SDR_TODATE", OracleDbType.Date).Value = objEntityDutyRostReprt.ToDate;
                    }
                    cmdReadDutyRoster.Parameters.Add("SDR_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                    dttraffic = clsDataLayer.SelectDataTable(cmdReadDutyRoster);
                    dtDutyRosterList.Merge(dttraffic);
                    dtDutyRosterList.AcceptChanges();
                }
                return dtDutyRosterList;
            }
            else
            {
                DataTable dttraffic = new DataTable();
                    OracleCommand cmdReadDutyRoster = new OracleCommand();
                    cmdReadDutyRoster.CommandText = strQueryReadEmp;
                    cmdReadDutyRoster.CommandType = CommandType.StoredProcedure;
                    if (objEntityDutyRostReprt.EmplyId != 0)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_USERID", OracleDbType.Int32).Value = objEntityDutyRostReprt.EmplyId;

                    }
                    else
                        cmdReadDutyRoster.Parameters.Add("SDR_USERID", OracleDbType.Int32).Value = 0;

                    cmdReadDutyRoster.Parameters.Add("SDR_ORGID", OracleDbType.Int32).Value = objEntityDutyRostReprt.OrgId;
                    cmdReadDutyRoster.Parameters.Add("SDR_CORPRTID", OracleDbType.Int32).Value = objEntityDutyRostReprt.CorprtId;
                    if (objEntityDutyRostReprt.FromDate == DateTime.MinValue)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_FROMDATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_FROMDATE", OracleDbType.Date).Value = objEntityDutyRostReprt.FromDate;
                    }

                    if (objEntityDutyRostReprt.ToDate == DateTime.MinValue)
                    {
                        cmdReadDutyRoster.Parameters.Add("SDR_TODATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {

                        cmdReadDutyRoster.Parameters.Add("SDR_TODATE", OracleDbType.Date).Value = objEntityDutyRostReprt.ToDate;
                    }
                    cmdReadDutyRoster.Parameters.Add("SDR_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                    dttraffic = clsDataLayer.SelectDataTable(cmdReadDutyRoster);
                    dttraffic = clsDataLayer.SelectDataTable(cmdReadDutyRoster);
                    dtDutyRosterList.Merge(dttraffic);
                    dtDutyRosterList.AcceptChanges();
                }
            return dtDutyRosterList;
        }
              

        public DataTable ReadEmployeeDetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadEmp = "AWMS_REPORTS.SP_READ_EMPLOYEES";
            OracleCommand cmdReadDutyRoster = new OracleCommand();
            cmdReadDutyRoster.CommandText = strQueryReadEmp;
            cmdReadDutyRoster.CommandType = CommandType.StoredProcedure;
            cmdReadDutyRoster.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityDutyRostReprt.OrgId;
            cmdReadDutyRoster.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityDutyRostReprt.CorprtId;
            cmdReadDutyRoster.Parameters.Add("T_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDutyRosterList = new DataTable();
            dtDutyRosterList = clsDataLayer.ExecuteReader(cmdReadDutyRoster);
            return dtDutyRosterList;
        }

        public DataTable ReadEmployeeJobdetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            //old
            string strQueryReadEmp = "AWMS_REPORTS.SP_READ_EMPLOYEE_JOB_DETAILS";
            OracleCommand cmdReadDutyRoster = new OracleCommand();
            cmdReadDutyRoster.CommandText = strQueryReadEmp;
            cmdReadDutyRoster.CommandType = CommandType.StoredProcedure;
            cmdReadDutyRoster.Parameters.Add("E_EMPLYID", OracleDbType.Int32).Value = objEntityDutyRostReprt.EmplyJobId;
            cmdReadDutyRoster.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDutyRosterList = new DataTable();
            dtDutyRosterList = clsDataLayer.ExecuteReader(cmdReadDutyRoster);
            return dtDutyRosterList;
        }
        //Read Additional job deatails
        public DataTable ReadEmployeeAdditionalJobdetails(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadEmp = "AWMS_REPORTS.SP_READ_ADDTNLJOB_DETAILS";
            OracleCommand cmdReadDutyRoster = new OracleCommand();
            cmdReadDutyRoster.CommandText = strQueryReadEmp;
            cmdReadDutyRoster.CommandType = CommandType.StoredProcedure;
            cmdReadDutyRoster.Parameters.Add("E_EMPLYID", OracleDbType.Int32).Value = objEntityDutyRostReprt.EmplyJobId;
            cmdReadDutyRoster.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDutyRosterList = new DataTable();
            dtDutyRosterList = clsDataLayer.ExecuteReader(cmdReadDutyRoster);
            return dtDutyRosterList;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadCorp = "AWMS_REPORTS.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityDutyRostReprt.CorprtId;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityDutyRostReprt.OrgId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadHolidayDate(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadHoliday = "AWMS_REPORTS.SP_READ_HOLIDAY";
            OracleCommand cmdReadHoliday = new OracleCommand();
            cmdReadHoliday.CommandText = strQueryReadHoliday;
            cmdReadHoliday.CommandType = CommandType.StoredProcedure;
            cmdReadHoliday.Parameters.Add("H_FROMDATE", OracleDbType.Date).Value = objEntityDutyRostReprt.dateFromDate;
            cmdReadHoliday.Parameters.Add("H_TODATE", OracleDbType.Date).Value = objEntityDutyRostReprt.dateToDate;
            cmdReadHoliday.Parameters.Add("H_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtHoliday = new DataTable();
            dtHoliday = clsDataLayer.ExecuteReader(cmdReadHoliday);
            return dtHoliday;
        }
        public DataTable ReadLeaveDate(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadHoliday = "AWMS_REPORTS.SP_READ_LEAVE";
            OracleCommand cmdReadHoliday = new OracleCommand();
            cmdReadHoliday.CommandText = strQueryReadHoliday;
            cmdReadHoliday.CommandType = CommandType.StoredProcedure;
            cmdReadHoliday.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityDutyRostReprt.UserId;       
            cmdReadHoliday.Parameters.Add("H_FROMDATE", OracleDbType.Date).Value = objEntityDutyRostReprt.dateFromDate;
            cmdReadHoliday.Parameters.Add("H_TODATE", OracleDbType.Date).Value = objEntityDutyRostReprt.dateToDate;
            cmdReadHoliday.Parameters.Add("H_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtHoliday = new DataTable();
            dtHoliday = clsDataLayer.ExecuteReader(cmdReadHoliday);
            return dtHoliday;
        }

        public DataTable ReadAllEmployee(clsEntityLayerDutyRosterReports objEntityDutyRostReprt)
        {
            string strQueryReadAllEmployee = "AWMS_REPORTS.SP_READ_ALL_EMPLOYEE";
            OracleCommand cmdReadAllEmployee = new OracleCommand();
            cmdReadAllEmployee.CommandText = strQueryReadAllEmployee;
            cmdReadAllEmployee.CommandType = CommandType.StoredProcedure;
            cmdReadAllEmployee.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityDutyRostReprt.UserId;
            cmdReadAllEmployee.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityDutyRostReprt.OrgId;
            cmdReadAllEmployee.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityDutyRostReprt.CorprtId;
            cmdReadAllEmployee.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtHoliday = new DataTable();
            dtHoliday = clsDataLayer.ExecuteReader(cmdReadAllEmployee);
            return dtHoliday;
        }
    }
}
