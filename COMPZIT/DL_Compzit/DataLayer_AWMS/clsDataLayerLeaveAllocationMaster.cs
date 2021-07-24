
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

// CREATED BY:EVM-0008
// CREATED DATE:21/12/2016
// REVIEWED BY:
// REVIEW DATE:


namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerLeaveAllocationMaster
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        public DataTable ReadEmployeedtl(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEVALLOCN_EMPLY";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
            cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        }

        public DataTable ReadLeavTypdtl(clsEntityLayerLeaveAllocationMaster objEntityLev, int ExpChck)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEVTYP";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            if (ExpChck == 0)
            {
                cmdReadEmp.Parameters.Add("L_EXPCHK", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmp.Parameters.Add("L_EXPCHK", OracleDbType.Int32).Value = ExpChck;
            }
            cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        
        }
        public DataTable ReadRemLeav(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_REMAINLEV_BYYEAR";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
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
        public DataTable ReadRemLeavNxtYr(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_REMAINLEV_BYYEAR";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
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


        public string chkUserLevCount(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_USRLEVCOUNTFRM";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
            cmdReadEmp.Dispose();
            return strLeav;

        }

        public string chkUserToLevCount(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_USRLEVCOUNTTO";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;

            cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
            cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
            cmdReadEmp.Dispose();
            return strLeav;

        }

        public DataTable ReadOPeningLeav(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_OPENINGLEAV";
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

        //public DataTable ReadChckEmply(clsEntityLayerLeaveAllocationMaster objEntityLev)
        //{
        //    string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_OPENINGLEAV";
        //    OracleCommand cmdReadEmp = new OracleCommand();
        //    cmdReadEmp.CommandText = strQueryReadEmploy;
        //    cmdReadEmp.CommandType = CommandType.StoredProcedure;

        //    cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
           
        //      cmdReadEmp.Parameters.Add("OL_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtLeav = new DataTable();
        //  //  clsDataLayer.ExecuteScalar(ref cmdReadEmp);
        //  //  string strLeav = cmdReadEmp.Parameters["L_REM"].Value.ToString();
        //    dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
        //    //cmdReadEmp.Dispose();
        //    return dtLeav;

        //}
        public void AddLeavAlloctnDetails(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_INS_LEAVALLOCTN_DETAILS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadEmploy;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;

                clsEntityCommon objEntCommon = new clsEntityCommon();
                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_ALLOCATION);
                objEntCommon.CorporateID = objEntityLev.Corporate_id;
                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                objEntityLev.LeavAllocn = Convert.ToInt32(strNextNum);

                cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                cmdReadEmp.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveFromSection;
                if (objEntityLev.LeaveToDate != DateTime.MinValue)
                {
                    cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                }
                else
                {
                    cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                }
                if (objEntityLev.LeaveToSection != 0)
                {
                    cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveToSection;
                }
                else
                {
                    cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = null;
                }
                cmdReadEmp.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = objEntityLev.NumOfLeave;
                cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                cmdReadEmp.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLev.PaidLvStatus;
                cmdReadEmp.Parameters.Add("L_ELGBL_LEAVALLOCTN_STS", OracleDbType.Int32).Value = objEntityLev.EilgiblLeaveAlloctnSts;
                cmdReadEmp.Parameters.Add("L_DAILY_LEAVE", OracleDbType.Int32).Value = objEntityLev.DailyLeaveStatus;
                if (objEntityLev.LeaveRequestID != 0)
                {
                    cmdReadEmp.Parameters.Add("L_LVE_REQST_ID", OracleDbType.Int32).Value = objEntityLev.LeaveRequestID;
                }
                else
                {
                    cmdReadEmp.Parameters.Add("L_LVE_REQST_ID", OracleDbType.Int32).Value = null;
                }
                cmdReadEmp.Parameters.Add("L_DAILY_LEAVE_SOURCE", OracleDbType.Int32).Value = objEntityLev.LeaveSource;
                clsDataLayer.ExecuteNonQuery(cmdReadEmp);
            }
        }
        public void InsertUserLeavTyp(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_INS_REMAINGLEV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            //  cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
            cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLev.RemingLev;

            clsDataLayer.ExecuteNonQuery(cmdReadEmp);

        }


               public void UpdateLeavAllocnDetls(clsEntityLayerLeaveAllocationMaster objEntityLev)
       {
           string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_UPD_LEAVALLOCTN_DETAILS";
           using (OracleCommand cmdReadEmp = new OracleCommand())
           {
               cmdReadEmp.CommandText = strQueryReadEmploy;
               cmdReadEmp.CommandType = CommandType.StoredProcedure;
               cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
               cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
               cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
               cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
               cmdReadEmp.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveFromSection;
               if (objEntityLev.LeaveToDate != DateTime.MinValue)
               {
                   cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
               }
               else
               {
                   cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
               }
               if (objEntityLev.LeaveToSection != 0)
               {
                   cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveToSection;
               }
               else
               {
                   cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = null;
               }
               cmdReadEmp.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = objEntityLev.NumOfLeave;
               cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
               cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
               cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
               cmdReadEmp.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdReadEmp.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLev.PaidLvStatus;
               cmdReadEmp.Parameters.Add("L_ELGBL_LEAVALLOCTN_STS", OracleDbType.Int32).Value = objEntityLev.EilgiblLeaveAlloctnSts;


               clsDataLayer.ExecuteNonQuery(cmdReadEmp);
           }
       }

               public void ConfirmLeavAllocnDtl(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CONFM_LEAVE_ALLOCTN_DETAILS";
                   using (OracleCommand cmdReadEmp = new OracleCommand())
                   {
                       cmdReadEmp.CommandText = strQueryReadEmploy;
                       cmdReadEmp.CommandType = CommandType.StoredProcedure;
                       cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                       cmdReadEmp.Parameters.Add("L_CONFRM", OracleDbType.Int32).Value = objEntityLev.LeaveConfmn;
                       cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                       cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                       cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                       cmdReadEmp.Parameters.Add("L_FSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveFromSection;
                       if (objEntityLev.LeaveToDate != DateTime.MinValue)
                       {
                           cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                       }
                       else
                       {
                           cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                       }
                       if (objEntityLev.LeaveToSection != 0)
                       {
                           cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = objEntityLev.LeaveToSection;
                       }
                       else
                       {
                           cmdReadEmp.Parameters.Add("L_TOSECTN", OracleDbType.Int32).Value = null;
                       }
                       cmdReadEmp.Parameters.Add("L_NUMOFLEV", OracleDbType.Decimal).Value = objEntityLev.NumOfLeave;
                       cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                       cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                       cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                       
                       cmdReadEmp.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                       cmdReadEmp.Parameters.Add("L_PAIDSTS", OracleDbType.Int32).Value = objEntityLev.PaidLvStatus;
                       cmdReadEmp.Parameters.Add("L_ELGBL_LEAVALLOCTN_STS", OracleDbType.Int32).Value = objEntityLev.EilgiblLeaveAlloctnSts;


                       clsDataLayer.ExecuteNonQuery(cmdReadEmp);
                   }
               }

               public void ReOpenLeavAlloctn(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_REOPEN_LEAVE_ALLOCTN";
                   using (OracleCommand cmdReadEmp = new OracleCommand())
                   {
                       cmdReadEmp.CommandText = strQueryReadEmploy;
                       cmdReadEmp.CommandType = CommandType.StoredProcedure;
                       cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                       cmdReadEmp.Parameters.Add("L_CONFRM", OracleDbType.Int32).Value = objEntityLev.LeaveConfmn;
                       cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                       cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                       cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                      
                       cmdReadEmp.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                       clsDataLayer.ExecuteNonQuery(cmdReadEmp);
                   }
               }
               public DataTable ReadLevAllctnById(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEAVE_ALCTN_BY_ID";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                   cmdReadEmp.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeavDetls = new DataTable();
                   dtLeavDetls = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeavDetls;

               }

               public void ReCallLeavAlloctndtl(clsEntityLayerLeaveAllocationMaster objEntityLev)
       {
           string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_RECALL_LEV_ALLOCTN_DTLS";
           using (OracleCommand cmdReadEmp = new OracleCommand())
           {
               cmdReadEmp.CommandText = strQueryReadEmploy;
               cmdReadEmp.CommandType = CommandType.StoredProcedure;
               cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
               cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
               cmdReadEmp.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdReadEmp);
           }
       }

               public void CancelLeavAlloctn(clsEntityLayerLeaveAllocationMaster objEntityLev)
       {
           string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CANCEL_LEVALLCN_DTS";
           using (OracleCommand cmdReadEmp = new OracleCommand())
           {
               cmdReadEmp.CommandText = strQueryReadEmploy;
               cmdReadEmp.CommandType = CommandType.StoredProcedure;
               cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
               cmdReadEmp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLev.User_Id;
               cmdReadEmp.Parameters.Add("L_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdReadEmp.Parameters.Add("L_CNRESN", OracleDbType.Varchar2).Value = objEntityLev.CancelReason;
               clsDataLayer.ExecuteNonQuery(cmdReadEmp);
           }
       }


               public DataTable ReadLeavallocndtlBySearch(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEVALCN_BYSEARCH";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                   cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                   cmdReadEmp.Parameters.Add("L_EMPSRCH", OracleDbType.Int32).Value = objEntityLev.EmplySrch;
                   cmdReadEmp.Parameters.Add("L_CANCEL", OracleDbType.Int32).Value = objEntityLev.CancelStatus;
                   cmdReadEmp.Parameters.Add("L_YEAR", OracleDbType.Int32).Value = objEntityLev.YearSrch;
                   cmdReadEmp.Parameters.Add("L_STSSRCH", OracleDbType.Int32).Value = objEntityLev.StatsSrch;
                   cmdReadEmp.Parameters.Add("L_LEAV_CATGRY", OracleDbType.Int32).Value = objEntityLev.LeavCatgry;
                   cmdReadEmp.Parameters.Add("L_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLev.CommonSearchTerm;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_MONTH", OracleDbType.Varchar2).Value = objEntityAcco.searcMonth;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_YEAR", OracleDbType.Varchar2).Value = objEntityAcco.SearchYear;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_NUMEMP", OracleDbType.Varchar2).Value = objEntityAcco.SearchNumEmp;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_INSDATE", OracleDbType.Varchar2).Value = objEntityAcco.SearchInsDate;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_INSTIME", OracleDbType.Varchar2).Value = objEntityAcco.SearchInsTime;
                   //cmdReadAccommodation.Parameters.Add("M_SEARCH_STATUS", OracleDbType.Varchar2).Value = objEntityAcco.SearchStatus;
                   cmdReadEmp.Parameters.Add("L_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLev.OrderColumn;
                   cmdReadEmp.Parameters.Add("L_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLev.OrderMethod;
                   cmdReadEmp.Parameters.Add("L_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLev.PageMaxSize;
                   cmdReadEmp.Parameters.Add("L_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLev.PageNumber;
                   cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeavAllcn = new DataTable();
                   dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeavAllcn;


               }

               public DataTable ReadYr(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {

                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEAVALLO_MAXYR";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_SRCH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeavAllcn = new DataTable();
                   dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeavAllcn;
               }
               public void InsertUserNewLevRow(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_INS_NEWROW_USR";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;

                   //  cmdReadEmp.Parameters.Add("L_CLASSID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("L_OPNGLEV", OracleDbType.Decimal).Value = objEntityLev.OpeningLv;
                   cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLev.RemingLev;
                   clsDataLayer.ExecuteNonQuery(cmdReadEmp);

               }
               public DataTable HolidayChck(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_HOLDAYS";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                  
                       cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                   
                    cmdReadEmp.Parameters.Add("HOLDATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }
               public DataTable ReadHolidayCountSiglDate(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_SINGLEHOL_COUNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                    cmdReadEmp.Parameters.Add("HOLDATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }
               public DataTable ReadChckEmply(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_CHCKEMPLOY_COUNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("EMPLYCOUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               public DataTable ReadHolidayCountSiglDateTo(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_SINGLEHOLTO_COUNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("HOLDATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }
       
               public DataTable ReadHolidayCountSiglDateFrm(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_SINGLEHOLFRM_COUNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("HOLDATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }
               public void InsertReopnFrom(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_INS_REOPN_LEAVE";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("L_REMLEV", OracleDbType.Decimal).Value = objEntityLev.RemingLev;
                   

                   clsDataLayer.ExecuteNonQuery(cmdReadEmp);

               }


               public string confmAllocnCount(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEVALLTN_CONT";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
            cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
            cmdReadEmp.Parameters.Add("L_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadEmp);
            string strLeav = cmdReadEmp.Parameters["L_COUNT"].Value.ToString();
            cmdReadEmp.Dispose();
            return strLeav;

        }

               public DataTable FrmSgleDate(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_FRMSNGLEDATE_COUNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                       cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                       cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                       cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                       cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }


               public DataTable ChkDatesInLeavReqst(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CHKDATES_LEVRQST";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                       cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                       cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                       cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                       cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               public DataTable ReadUserDetails(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_USERDETAILS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        
        }

               public DataTable ReadUserDetailsGnUser(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_USERDETAILSGNUSER";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
            cmdReadEmp.Parameters.Add("L_TYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtLeav;
        
        }

               public DataTable ReadWeeklyDutyOff(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_WKLY_OFFDTY";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                   cmdReadEmp.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                   cmdReadEmp.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               //For reading month wise duty off
               public DataTable ReadMonthlyDutyOff(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_MNTHLY_OFFDTY";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                   cmdReadEmp.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                   cmdReadEmp.Parameters.Add("D_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

       //READ HOLIDAY


               public DataTable ReadHolidayDate(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_HOLIDAY_FORDUTYOF";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("H_FROMDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("H_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                   cmdReadEmp.Parameters.Add("H_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }



               public DataTable ReadRejoin(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_REJOIN";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_Lev", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                   cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               public void InsLeaveArrearAmnt(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_INS_LEAVE_ARREAR_AMNT";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.User_Id;
                   cmdReadEmp.Parameters.Add("L_TYPEID", OracleDbType.Int32).Value = objEntityLev.Leave_Id;
                   cmdReadEmp.Parameters.Add("L_AMNT", OracleDbType.Decimal).Value = objEntityLev.NumOfLeave;
                   clsDataLayer.ExecuteNonQuery(cmdReadEmp);
               }
             //EVM-0012
               public DataTable CheckLeaveDatesByEmployeeCode(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CHK_LEV_DATES_EMP_CODE";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMP", OracleDbType.Varchar2).Value = objEntityLev.EmployeeCode;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               public DataTable CheckLeaveDatesByEmployeeID(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CHK_LEV_DATES_BY_EMP_ID";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMP_ID", OracleDbType.Varchar2).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;

               }

               public DataTable CheckLeaveDates(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CHK_LEV_DATES";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMP_ID", OracleDbType.Varchar2).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   if (objEntityLev.LeaveToDate == DateTime.MinValue)
                   {
                       cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = null;
                   }
                   else
                   {
                       cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                   }
                   cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;
               }

               public DataTable CheckReportOffcr(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_CHK_REPORTING_OFFCR";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_EMP_ID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                   cmdReadEmp.Parameters.Add("L_CRPRT_ID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                   cmdReadEmp.Parameters.Add("L_ALLCTN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeav = new DataTable();
                   dtLeav = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeav;
               }

              //0039
               public DataTable ReadLeaveAloctionDtls(clsEntityLayerLeaveAllocationMaster objEntityLev)
               {
                   string strQueryReadEmploy = "LEAVE_ALLOCATION.SP_READ_LEVALCN_DTLS";
                   OracleCommand cmdReadEmp = new OracleCommand();
                   cmdReadEmp.CommandText = strQueryReadEmploy;
                   cmdReadEmp.CommandType = CommandType.StoredProcedure;
                   cmdReadEmp.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLev.Organisation_id;
                   cmdReadEmp.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLev.Corporate_id;
                   cmdReadEmp.Parameters.Add("L_EMPLYID", OracleDbType.Int32).Value = objEntityLev.EmployeeId;
                   cmdReadEmp.Parameters.Add("L_FRDATE", OracleDbType.Date).Value = objEntityLev.LeaveFrmDate;
                   if (objEntityLev.LeaveToDate != DateTime.MinValue)
                   {
                       cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = objEntityLev.LeaveToDate;
                   }
                   else
                   {
                       cmdReadEmp.Parameters.Add("L_TODATE", OracleDbType.Date).Value = DBNull.Value;
                   }
                   //EVM040
                   cmdReadEmp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLev.LeavAllocn;
                   //EVM040
                   cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   DataTable dtLeavAllcn = new DataTable();
                   dtLeavAllcn = clsDataLayer.ExecuteReader(cmdReadEmp);
                   return dtLeavAllcn;
               }
                //END

    }
}
