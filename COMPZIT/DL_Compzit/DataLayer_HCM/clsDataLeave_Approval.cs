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
    public class clsDataLeave_Approval
    {

        public DataTable ReadLeavTypdtl(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_LEVTYP";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;

        }
        public DataTable ReadRemLeav(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_REMAINLEV_BYYEAR";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.User_Id;
            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_REM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        //public DataTable ReadRemLeavNxtYr(clsEntityLayerLeaveApproval objEntityLev)
        //{
        //    string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_REMAINLEV_BYYEAR";
        //    OracleCommand cmdReadEmp = new OracleCommand();
        //    cmdReadEmp.CommandText = strQueryReadEmploy;
        //    cmdReadEmp.CommandType = CommandType.StoredProcedure;
        //    cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
        //    cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
        //    cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
        //    cmdReadEmp.Parameters.Add("L_REM", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtLeav = new DataTable();
        //    //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
        //    //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
        //    dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
        //    //cmdReadEmp.Dispose();
        //    return dtLeav;

        //}


        public string chkUserLevCount(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_USRLEVCOUNTFRM";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.User_Id;
            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
            cmdReadEmp.Dispose();
            return strLeav;

        }

        //public string chkUserToLevCount(clsEntityLayerLeaveApproval objEntityLev)
        //{
        //    string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_USRLEVCOUNTTO";
        //    OracleCommand cmdReadEmp = new OracleCommand();
        //    cmdReadEmp.CommandText = strQueryReadEmploy;
        //    cmdReadEmp.CommandType = CommandType.StoredProcedure;
        //    cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
        //    cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;

        //    cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
        //    cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
        //    clsDataLayer.ExecuteScalar(ref cmdReadEmp);
        //    string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
        //    cmdReadEmp.Dispose();
        //    return strLeav;

        //}

        public DataTable ReadOPeningLeav(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_OPENINGLEAV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;

            cmdReadEmp.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        public DataTable ReadEmployeeTotalLve(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_TOTALLEAV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;

            cmdReadEmp.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        public DataTable ReadLeavallocndtlBySearch(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_LEVALCN_BYSEARCH";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("L_MODE", OracleDbType.Int32).Value = objEntityLev.Mode;
            cmdReadEmp.Parameters.Add("L_STSSRCH", OracleDbType.Int32).Value = objEntityLev.StatsSrch;
            if (objEntityLev.LeaveFrmDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("L_FRM_DATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;

            }
            else
                cmdReadEmp.Parameters.Add("L_FRM_DATE", OracleDbType.Date).Value = null;

            if (objEntityLev.LeaveToDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("L_TO_DATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;

            }
            else
                cmdReadEmp.Parameters.Add("L_TO_DATE", OracleDbType.Date).Value = null;
            cmdReadEmp.Parameters.Add("L_ROLESRCH", OracleDbType.Int32).Value = objEntityLev.RoleSrch;
            cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavAllcn = new DataTable();
            dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeavAllcn;


        }
        public DataTable ReadLeavallocndtlByid(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_LEVALCN_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeavAllcn = new DataTable();
            dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeavAllcn;


        }
        public void Gm_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_UPD_GM_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityLev.ApprovalStatus;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_GM_COMMENT", OracleDbType.Varchar2).Value = objEntityLev.GmComment;
              


                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void Hr_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_UPD_HR_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityLev.ApprovalStatus;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;

                cmdUpdateCntrctCat.Parameters.Add("C_HR_COMMENT", OracleDbType.Varchar2).Value = objEntityLev.HrComment;

                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void ReprtingEmploy_Approve(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_UPD_REPORTING_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityLev.ApprovalStatus;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_RO_COMMENT", OracleDbType.Varchar2).Value = objEntityLev.RoComment;
              

                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void DIVMANAGER_APPROVA(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_UPD_DIVMANAGER_APPROVAL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityLev.ApprovalStatus;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_DM_COMMENT", OracleDbType.Varchar2).Value = objEntityLev.DmComment;


                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void Reject(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_REJECT_REQST";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVAL", OracleDbType.Int32).Value = objEntityLev.ApprovalStatus;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_REJCT_RSN", OracleDbType.Varchar2).Value = objEntityLev.CancelReason;

                 

                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }


        }
        public void Close(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryUpdateCntrctCat = "LEAVE_APPROVAL.SP_CLOSE_REQST";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;

                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_REQSTATUS", OracleDbType.Int32).Value = objEntityLev.Requeststatus;
                cmdUpdateCntrctCat.Parameters.Add("C_APPROVEDATE", OracleDbType.Date).Value = objEntityLev.Date;
                cmdUpdateCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;



                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
        public DataTable ReadEmployeeDependent(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_TRAVELDEPNTD";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;

            cmdReadEmp.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        public DataTable ReadEmployeelastleave(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_READ_LEVALCN_BYEMPID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("L_USRID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;

        
            cmdReadEmp.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            //cmdReadEmp.Dispose();
            return dtLeav;

        }
        public DataTable ReadLeaveRqstById(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadleave = "LEAVE_APPROVAL.SP_READ_RQSTDTL_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadleave;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;

        }

        public void InsertUserNewLevRow(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_INS_NEWROW_USR";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.User_Id;
            cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = objEntityLev.OpeningLv;
            cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLev.RemingLev;
            cmdReadEmp.Parameters.Add("L_BALLEAVE", OracleDbType.Decimal).Value = objEntityLev.NumOfLeave;
            clsDataLayer.ExecuteNonQuery(cmdReadEmp);

        }
        public void InsertUserLeavTyp(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_INS_REMAINGLEV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            //  cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
            cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.User_Id;
            cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLev.RemingLev;

            clsDataLayer.ExecuteNonQuery(cmdReadEmp);

        }

        public void DeleteLeaveAllocationByLveRequestID(clsEntityLayerLeaveApproval objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_APPROVAL.SP_DEL_LEAVE_ALLOCATION";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_LEAVE_LVE_REQST_ID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadEmp);
        }



    }
    

}
