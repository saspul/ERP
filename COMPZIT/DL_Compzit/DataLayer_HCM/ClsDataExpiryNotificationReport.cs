using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class ClsDataExpiryNotificationReport
    {
        public DataTable Read_Expiry_Notification_List(ClsEntityExpiryNotificationReport objEntityReport)
        {
            string strQueryReadProductList = "HCM_REPORTS.SP_EXPIRY_NOTIFICATION";
            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadProductList.Parameters.Add("P_DOCTYPEID", OracleDbType.Int32).Value = objEntityReport.Document_Type;

                //EVM--27

                cmdReadProductList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.DivsnId;

                cmdReadProductList.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityReport.DeptId;

                if (objEntityReport.FromDt != DateTime.MinValue)
                {
                    cmdReadProductList.Parameters.Add("P_DATEFROM", OracleDbType.Date).Value = objEntityReport.FromDt;
                }
                else
                {
                    cmdReadProductList.Parameters.Add("P_DATEFROM", OracleDbType.Date).Value = null;
                }
                if (objEntityReport.ToDate != DateTime.MinValue)
                {
                    cmdReadProductList.Parameters.Add("P_DATETO", OracleDbType.Date).Value = objEntityReport.ToDate;
                }
                else
                {
                    cmdReadProductList.Parameters.Add("P_DATETO", OracleDbType.Date).Value = null;
                }

                //cmdReadProductList.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityReport.DocStatus;
                //END
                cmdReadProductList.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityReport.Status;

                cmdReadProductList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(ClsEntityExpiryNotificationReport objEntRprt)
        {
            string strQueryReadCorp = "REPORTS.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntRprt.Corporate_Id;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntRprt.Organisation_Id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadDivision(ClsEntityExpiryNotificationReport objEntRprt)
        {
            string strQueryReadDivision = "HCM_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntRprt.Organisation_Id;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntRprt.Corporate_Id;
            cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntRprt.DeptId;
            cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        public DataTable ReadDepts(ClsEntityExpiryNotificationReport objEntRprt)
        {
            string strQueryReadDepts = "HCM_REPORTS.SP_READ_DEPARTMENTS";
            OracleCommand cmdReadDepts = new OracleCommand();
            cmdReadDepts.CommandText = strQueryReadDepts;
            cmdReadDepts.CommandType = CommandType.StoredProcedure;
            cmdReadDepts.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntRprt.Organisation_Id;
            cmdReadDepts.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntRprt.Corporate_Id;
            cmdReadDepts.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadDepts);
            return dtDepts;
        }
}
}
