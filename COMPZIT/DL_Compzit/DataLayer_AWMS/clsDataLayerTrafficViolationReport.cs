using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit.EntityLayer_AWMS;

namespace DL_Compzit.DataLayer_AWMS
{

    public   class clsDataLayerTrafficViolationReport
    {
        // This Method adds Traffic Violation details to the database
        public DataTable ReadViolationreport(clsEntityLayerTrafficViolationReport objviolation,List<clsEntityLayerEmployee> objviolatedemp)

        {
            string strQueryViolationreport = "TRAFFIC_VIOLATION_REPORT.SP_TRAFIC_VIOLATION_REPORTSHOW";
            DataTable dtGridDisp = new DataTable();
    
            foreach (clsEntityLayerEmployee objEmplist in objviolatedemp)
            {
                if (objEmplist.searchby == "Employee")
                {

                    DataTable dttraffic = new DataTable();
                    using (OracleCommand cmdViolationreport = new OracleCommand())
                    {
                        cmdViolationreport.CommandText = strQueryViolationreport;
                        cmdViolationreport.CommandType = CommandType.StoredProcedure;
                        cmdViolationreport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objviolation.CorpId;
                        cmdViolationreport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objviolation.OrgID;
                        cmdViolationreport.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objEmplist.EmployeeID;
                        cmdViolationreport.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = objviolation.vehicleid;
                        cmdViolationreport.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objviolation.Status;
                        cmdViolationreport.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = objviolation.FromDate;
                        cmdViolationreport.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objviolation.ToDate;
                        cmdViolationreport.Parameters.Add("P_VIOLENCE_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



                        dttraffic = clsDataLayer.SelectDataTable(cmdViolationreport);

                    }
                    dtGridDisp.Merge(dttraffic);
                    dtGridDisp.AcceptChanges();
                }
            }
            foreach (clsEntityLayerEmployee objEmplist in objviolatedemp)
            {
                if (objEmplist.searchby == "vechcle")
                {
                    DataTable dttraffic = new DataTable();
                    using (OracleCommand cmdViolationreport = new OracleCommand())
                    {
                        cmdViolationreport.CommandText = strQueryViolationreport;
                        cmdViolationreport.CommandType = CommandType.StoredProcedure;
                        cmdViolationreport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objviolation.CorpId;
                        cmdViolationreport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objviolation.OrgID;
                        cmdViolationreport.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objviolation.EmployeeID;
                        cmdViolationreport.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = objEmplist.vehicleid;
                        cmdViolationreport.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objviolation.Status;
                        cmdViolationreport.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = objviolation.FromDate;
                        cmdViolationreport.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objviolation.ToDate;
                        cmdViolationreport.Parameters.Add("P_VIOLENCE_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



                        dttraffic = clsDataLayer.SelectDataTable(cmdViolationreport);

                    }
                    dtGridDisp.Merge(dttraffic);
                    dtGridDisp.AcceptChanges();
                }
            }
            return dtGridDisp;
        }
        public DataTable ReadEmployee(clsEntityLayerTrafficViolationReport objreademploye)
        {
            string strQueryViolationReadEmployee = "TRAFFIC_VIOLATION_REPORT.SP_READ_EMPLOYEES";
            using (OracleCommand cmdViolationReadEmployee = new OracleCommand())
            {
                cmdViolationReadEmployee.CommandText = strQueryViolationReadEmployee;
                cmdViolationReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdViolationReadEmployee.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objreademploye.EmployeeID;
                cmdViolationReadEmployee.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objreademploye.CorpId;
                cmdViolationReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objreademploye.OrgID;
                cmdViolationReadEmployee.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdViolationReadEmployee);
                return dtGridDisp;
            }
        }

        public DataTable ReadVehicle(clsEntityLayerTrafficViolationReport objreademploye)
        {
            string strQueryViolationReadEmployee = "TRAFFIC_VIOLATION_REPORT.SP_READ_VEHICLES";
            using (OracleCommand cmdViolationReadEmployee = new OracleCommand())
            {
                cmdViolationReadEmployee.CommandText = strQueryViolationReadEmployee;
                cmdViolationReadEmployee.CommandType = CommandType.StoredProcedure;
                cmdViolationReadEmployee.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objreademploye.CorpId;
                cmdViolationReadEmployee.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objreademploye.OrgID;
                cmdViolationReadEmployee.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdViolationReadEmployee);
                return dtGridDisp;
            }
        }
    }
}
