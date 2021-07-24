using EL_Compzit.EntityLayer_AWMS;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataResignation_Approval
    {
        public DataTable ReadLeavallocndtlBySearch(clsEntityLayerresignationApproval objEntitApproval)
        {
            string strQueryReadEmploy = "RESIGNATION_APPROVAL.SP_READ_RESIGNATION_BYSEARCH";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntitApproval.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntitApproval.Corporate_id;
            cmdReadEmp.Parameters.Add("L_EMPID", OracleDbType.Int32).Value = objEntitApproval.EmployeeId;
            cmdReadEmp.Parameters.Add("L_STSSRCH", OracleDbType.Int32).Value = objEntitApproval.StatsSrch;
            cmdReadEmp.Parameters.Add("L_ROLESRCH", OracleDbType.Int32).Value = objEntitApproval.EmplySrch;

            cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavAllcn = new DataTable();
            dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeavAllcn;


        }
        public DataTable ReadLeavallocndtlByid(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryReadEmploy = "RESIGNATION_APPROVAL.SP_READ_RESIGNATION_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
            cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavAllcn = new DataTable();
            dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeavAllcn;


        }
        public void Gm_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_UPD_GM_APPROVAL";
          

                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                    cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                    cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                    cmdUpdateCntrctCat.Parameters.Add("C_REASN", OracleDbType.Varchar2).Value = objEntityLev.GmReason;


                    clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }

            

        }
        public void Hr_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            if (objEntityLev.SearchField != "FinalHr")
            {
                string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_UPD_HR_APPROVAL";

                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                    cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                    cmdUpdateCntrctCat.Parameters.Add("C_LEAVINGDATE", OracleDbType.Date).Value = objEntityLev.ResignationToDate;
                    cmdUpdateCntrctCat.Parameters.Add("C_REASN", OracleDbType.Varchar2).Value = objEntityLev.CancelReason;

                    cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;



                    clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }
            }
            else
            {
                string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_UPD_FINALHR_APPROVAL";
                using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
                {
                    cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                    cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                    cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                    cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                    cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                   
                    cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;

                    cmdUpdateCntrctCat.Parameters.Add("C_FNLHR_RSN", OracleDbType.Varchar2).Value = objEntityLev.CancelReason;

                    clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
                }
            }

        }
        public void ReprtingEmploy_Approve(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_UPD_REPORTING_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                 cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_RO_RSN", OracleDbType.Varchar2).Value = objEntityLev.RoReason;


                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void DIVMANAGER_APPROVA(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_UPD_DIVMANAGER_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                 cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_DM_RSN", OracleDbType.Varchar2).Value = objEntityLev.DmReason;


                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void Reject(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_REJECT_REQST";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                 cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_REJCT_RSN", OracleDbType.Varchar2).Value = objEntityLev.CancelReason;



                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void Close(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "RESIGNATION_APPROVAL.SP_CLOSE_REQST";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Resignation_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;



                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
        public DataTable ReadEmployee(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryReadEmploy = "RESIGNATION_APPROVAL.SP_READ_RESIGNEMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        public DataTable ReadEmployeeDivsn(clsEntityLayerresignationApproval objEntityLev)
        {
            string strQueryReadEmploy = "RESIGNATION_APPROVAL.SP_EXIT_DIVISIONREAD";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
    }
}
