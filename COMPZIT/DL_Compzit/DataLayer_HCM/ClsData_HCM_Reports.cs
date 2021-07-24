using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
   public class ClsData_HCM_Reports
    {
        //FOR READING MANPOWER REQUREMENT PROCESS STATUS
       public DataTable ReadManpwrReqmtProcessDetls(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = new DataTable();
            using (OracleCommand cmdReadbusiness = new OracleCommand())
            {
                cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_MANPWR_PRCSSDTL_REPT";
                cmdReadbusiness.CommandType = CommandType.StoredProcedure;
                cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
                cmdReadbusiness.Parameters.Add("E_DEPD", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DeptId;
                cmdReadbusiness.Parameters.Add("E_PROJCTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PrjctId;
                cmdReadbusiness.Parameters.Add("E_EMPID", OracleDbType.Varchar2).Value = ObjEntityEmpTransfer.EmpId;
                cmdReadbusiness.Parameters.Add("E_FROMDT", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
                cmdReadbusiness.Parameters.Add("E_TODT", OracleDbType.Date).Value = ObjEntityEmpTransfer.ToDate;
                cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
            }
            return dtBusinessUnit;
        }

       public DataTable ReadShrtlistedCandidateList(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = new DataTable();
            using (OracleCommand cmdReadbusiness = new OracleCommand())
            {
                cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_SRTLST_CANDIDATE_LIST";
                cmdReadbusiness.CommandType = CommandType.StoredProcedure;
                cmdReadbusiness.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
                cmdReadbusiness.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
                cmdReadbusiness.Parameters.Add("P_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
                cmdReadbusiness.Parameters.Add("P_REQRMNTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ManPwrId;
                cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
            }
            return dtBusinessUnit;
        }

       public DataTable readSchdlList(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_SCHDL_DTLS";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("P_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ManPwrId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

       //
       public DataTable ReadDepts(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_DEPARTMNTS";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }
       public DataTable ReadProject(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_PROJECT";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }
       public DataTable ReadEmployes(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_EMPLOYEES";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

       public DataTable ReadAprvdManpwrRqst(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_MANPOWER_REQ";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

       //TO READ MANPOWER SUMMERY DETAILS

       public DataTable ReadManpwrSummaryDetls(clsEntityManpwr_Process_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_MANPWR_SUMRY_DTL_REPT";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.OrgId;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpId;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.UserId;
               cmdReadbusiness.Parameters.Add("E_MANPWRID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.ManPwrId;
               cmdReadbusiness.Parameters.Add("E_PROJCTID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.PrjctId;
                cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }


       //check


       public DataTable checkCandStatus(clsEntityManpwr_Process_Report objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "HCM_REPORTS_PHASE1.SP_CHCK_CAND_STS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.UserId;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ManPwrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }



       //public DataTable readSchdlList(clsEntityManpwr_Process_Report objEntityIntervewProcess)
       //{
       //    string strQueryReadPayGrd = "HCM_REPORTS_PHASE1.SP_READ_SCHDL_DTLS";
       //    OracleCommand cmdReadJob = new OracleCommand();
       //    cmdReadJob.CommandText = strQueryReadPayGrd;
       //    cmdReadJob.CommandType = CommandType.StoredProcedure;
       //    cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.UserId;
       //    cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ManPwrId;
       //    cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
       //    DataTable dtCategory = new DataTable();
       //    dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
       //    return dtCategory;
       //}

       public DataTable readQualifiedLevel(clsEntityManpwr_Process_Report objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "HCM_REPORTS_PHASE1.SP_CHCK_QUALFD_STS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.UserId;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ManPwrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }


       public DataTable readCompleteLevel(clsEntityManpwr_Process_Report objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "HCM_REPORTS_PHASE1.SP_CHCK_CMPLTD_LVLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.UserId;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ManPwrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable readSchdlLVlEditInfoDtls(clsEntityManpwr_Process_Report objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "HCM_REPORTS_PHASE1.SP_READ_SCHDLEDIT_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.UserId;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ManPwrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }


    }
   public class clsData_Leave_Management_Report
   {
       //FOR READING LEAVE TYPE
       public DataTable ReadLeaveTyp(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_LEAVE_REQUEST_TYP";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_id;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Corporate_id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

       public DataTable ReadDepts(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_DEPARTMNTS";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_id;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Corporate_id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

       public DataTable ReadDivision(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_DIVISION";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_id;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Corporate_id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }
       public DataTable ReadLeaveManagementReport(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_LEAVMANG_REPORT";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_id;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Corporate_id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepId;
               cmdReadbusiness.Parameters.Add("E_FROMDT", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
               cmdReadbusiness.Parameters.Add("E_TODT", OracleDbType.Date).Value = ObjEntityEmpTransfer.ToDate;
               cmdReadbusiness.Parameters.Add("E_LEAVETYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.LeaveTypeMasterId;
               cmdReadbusiness.Parameters.Add("E_DIVID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }


       public DataTable ReadTotalNumLeavesTaken(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_REMAINLEV_BYYEAR";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
          
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("L_Lev", OracleDbType.Int32).Value = ObjEntityEmpTransfer.LeaveTypeMasterId;
               cmdReadbusiness.Parameters.Add("L_Year", OracleDbType.Int32).Value = ObjEntityEmpTransfer.NoOfDays;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

         public DataTable READ_DIVISION_BYEMPID(clsEntity_Leave_Management_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_DIVISION_BYID";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_id;
               cmdReadbusiness.Parameters.Add("E_CORP_ID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Corporate_id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DepId;
               cmdReadbusiness.Parameters.Add("E_FROMDT", OracleDbType.Date).Value = ObjEntityEmpTransfer.FromDate;
               cmdReadbusiness.Parameters.Add("E_TODT", OracleDbType.Date).Value = ObjEntityEmpTransfer.ToDate;
               cmdReadbusiness.Parameters.Add("E_LEAVETYP", OracleDbType.Int32).Value = ObjEntityEmpTransfer.LeaveTypeMasterId;
               cmdReadbusiness.Parameters.Add("E_DIVID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivId;
               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }

             
        

   }
   public class clsData_Mess_CalCulation_Report
   {
       public DataTable ReadAccomodation(clsEntity_Mess_Bill_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_ACCOMODATION";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_Id;
               cmdReadbusiness.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpOffice_Id;

               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }


       public DataTable ReadAccomodationDetails(clsEntity_Mess_Bill_Report ObjEntityEmpTransfer)
       {
           DataTable dtBusinessUnit = new DataTable();
           using (OracleCommand cmdReadbusiness = new OracleCommand())
           {
               cmdReadbusiness.CommandText = "HCM_REPORTS_PHASE1.SP_READ_ACCOMODATION_BYID";
               cmdReadbusiness.CommandType = CommandType.StoredProcedure;
               cmdReadbusiness.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.Organisation_Id;
               cmdReadbusiness.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.CorpOffice_Id;
               cmdReadbusiness.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.User_Id;
               cmdReadbusiness.Parameters.Add("E_ACOMDTNID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.AccomoDationId;

               cmdReadbusiness.Parameters.Add("E_DIVID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DivsnId;
               cmdReadbusiness.Parameters.Add("E_DEPID", OracleDbType.Int32).Value = ObjEntityEmpTransfer.DeptId;

               cmdReadbusiness.Parameters.Add("E_FROMDT", OracleDbType.Date).Value = ObjEntityEmpTransfer.Fromdate;
               cmdReadbusiness.Parameters.Add("E_TODT", OracleDbType.Date).Value = ObjEntityEmpTransfer.Todate;


               cmdReadbusiness.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtBusinessUnit = clsDataLayer.SelectDataTable(cmdReadbusiness);
           }
           return dtBusinessUnit;
       }
       

   }

    
}
