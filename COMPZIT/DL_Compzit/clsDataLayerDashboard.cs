using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using CL_Compzit;
using Oracle.DataAccess.Client;

namespace DL_Compzit
{
    public class clsDataLayerDashboard
    {
        //THIS METHORD IS FOR READING TOTAL LEAD,WON LEAD,LOSS LEAD OF CURRENT MONTH OF CURRENT USER
        public DataTable Read_WL_Lead_Count_of_CurrentMonth(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_TWL_LD_CNT_OF_CURNT_MNTH";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //THIS METHORD IS FOR READING TOTAL  NEW LEAD,APPROVED LEAD,ACTIVE LEAD OF CURRENT USER
        public DataTable Read_Total_New_Aprv_Actv_Lead_Count(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_NEW_APRV_ACT_DLVR_LD_CNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //THIS METHORD IS FOR READING TOTAL UNREAD MAIL OF USER AND ALSO DIVISON AND TEAM IF SECRATORY BASED ON CHILD ROLE
        public DataTable Read_UnReadMail(clsEntityMailConsole objEntityMail)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_MAILCOUNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
            cmdReadCount.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
            cmdReadCount.Parameters.Add("M_STREID", OracleDbType.Int32).Value = objEntityMail.Email_Store;
            cmdReadCount.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
            cmdReadCount.Parameters.Add("M_MAILENABLE", OracleDbType.Int32).Value = objEntityMail.All_Mail_Enable;
            cmdReadCount.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMailCount = new DataTable();
            dtMailCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtMailCount;
        }
        //THIS METHORD IS FOR READING TOTAL  COUNT OF OPEN,ABOUT TO BREACH,BREACHED,UPCOMING TASK OF CURRENT USER
        public DataTable Read_Total_Task_Count(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_TASK_CNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaskCount = new DataTable();
            dtTaskCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtTaskCount;
        }
        //THIS METHORD IS FOR READING TASK LIST BASED ON TASK_LIST_MODE(1.ABOUT TO BREACH,2.BREACHED,3.OPEN,4.UPCOMMING)OF CURRENT USER
        public DataTable Read_Task_List(clsEntityLeadCreation objEntityLead, int intListMode)
        {
            string strQueryReadList = "DASHBOARD.SP_RD_TASK_MANIPULATE_LIST";
            OracleCommand cmdReadTaskList = new OracleCommand();
            cmdReadTaskList.CommandText = strQueryReadList;
            cmdReadTaskList.CommandType = CommandType.StoredProcedure;
            cmdReadTaskList.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadTaskList.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadTaskList.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadTaskList.Parameters.Add("D_TASK_LIST_MODE", OracleDbType.Int32).Value = intListMode;
            cmdReadTaskList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLead.CommonSearchTerm;
            cmdReadTaskList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLead.OrderColumn;
            cmdReadTaskList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLead.OrderMethod;
            cmdReadTaskList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLead.PageMaxSize;
            cmdReadTaskList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLead.PageNumber;
            cmdReadTaskList.Parameters.Add("M_PRINT", OracleDbType.Int32).Value = objEntityLead.Allocate_UserId;
            cmdReadTaskList.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaskList = new DataTable();
            dtTaskList = clsDataLayer.ExecuteReader(cmdReadTaskList);
            return dtTaskList;
        }

        //THIS METHORD  IS FOR READING  TEAM LIST FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_TeamList_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadList = "DASHBOARD.SP_RD_TEAMLIST_FOR_TEAMHEAD";
            OracleCommand cmdReadTeamList = new OracleCommand();
            cmdReadTeamList.CommandText = strQueryReadList;
            cmdReadTeamList.CommandType = CommandType.StoredProcedure;
            cmdReadTeamList.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            cmdReadTeamList.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadTeamList.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadTeamList.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTeamList = new DataTable();
            dtTeamList = clsDataLayer.ExecuteReader(cmdReadTeamList);
            return dtTeamList;
        }

        //THIS METHORD IS FOR READING COUNT OF APROVAL PENDING LEADS OF TEAM FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_Count_ApprvlPendingLead_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadList = "DASHBOARD.SP_RD_CNT_APRVLPNDG_FOR_THEAD";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadList;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_TEAM_ID", OracleDbType.Int32).Value = objEntityLead.Team;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }

        //THIS METHORD IS FOR READING COUNT OF UNREAD ALLOCATED MAIL OF TEAM FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_Count_UnreadAllocatedMail_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadList = "DASHBOARD.SP_RD_CNT_UNREAD_ALLCTMAIL_TM";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadList;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_TEAM_ID", OracleDbType.Int32).Value = objEntityLead.Team;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }

        //this method is  for listing unread mails list allocated for team lead from dashboard 
        public DataTable Read_MailList_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadMailList = "DASHBOARD.SP_RD_MAILLIST_FOR_TEAMHEAD";
            OracleCommand cmdReadMailList = new OracleCommand();
            cmdReadMailList.CommandText = strQueryReadMailList;
            cmdReadMailList.CommandType = CommandType.StoredProcedure;
            cmdReadMailList.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityLead.User_Id;
            cmdReadMailList.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadMailList.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadMailList.Parameters.Add("D_TEAM_ID ", OracleDbType.Int32).Value = objEntityLead.Team;
            cmdReadMailList.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadMailList = new DataTable();
            dtReadMailList = clsDataLayer.ExecuteReader(cmdReadMailList);
            return dtReadMailList;
        }


        //THIS METHORD IS FOR READING PENDING VEHICLE ASSIGN CONFIRM OF CURRENT USER
        public DataTable Read_Asn_Cnfrm_Count(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_ASGN_CNFRM_PNDNG_CNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaskCount = new DataTable();
            dtTaskCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtTaskCount;
        }
        //THIS METHORD IS FOR READING  DATA FOR SALES EXEC DASHBOARD
        public DataTable Read_Amt_Sales_Executive(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadAmt = "DASHBOARD.SP_READ_AMT_SALES_EXECUTIVE";
            OracleCommand cmdReadAmt = new OracleCommand();
            cmdReadAmt.CommandText = strQueryReadAmt;
            cmdReadAmt.CommandType = CommandType.StoredProcedure;
            cmdReadAmt.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadAmt.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadAmt.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadAmt.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAmt = new DataTable();
            dtAmt = clsDataLayer.ExecuteReader(cmdReadAmt);
            return dtAmt;
        }
        //THIS METHORD IS FOR READING DATA FOR SALES EXEC DASHBOARD
        public DataTable Read_Count_Sales_Executive(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_COUNT_SALES_EXECUTIVE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //THIS METHORD IS FOR READING Leads_Count_ById FOR SALES EXEC DASHBOARD
        public DataTable Read_Leads_Count_ById_Monthly(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_LEADS_COUNT_BYID";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //THIS METHORD IS FOR READING Read_Leads_Amt_ById_Monthly FOR SALES EXEC DASHBOARD
        public DataTable Read_Leads_Amt_ById_Monthly(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_RD_LEADS_AMT_BYID";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //MONTHLY WON LEADS(DEALS) DIVISION WISE CLIENT LIST
        public DataTable Read_MonthlyWonLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_WON_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        // --OPEN LEADS(DEALS) DIVISION WISE PROJECT LIST
        public DataTable Read_MonthlyOpenLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_OPEN_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //-- CLOSED LEADS(DEALS) DIVISION WISE PROJECT LIST
        public DataTable Read_MonthlyClosedLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_CLOSED_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //--LEADS LOSS MONTH WISE
        public DataTable Read_MonthlyLostLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_LOST_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //--TOP AGED LEAD
        public DataTable Read_TopAgedLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_TOP_AGED_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //--TOTAL WON LEAD MONTHLY BY DIV for Bar diagram
        public DataTable Read_TotalWonLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_TOTAL_WON_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //--TOTAL WON LEAD MONTHLY BY DIV  for Bar diagram
        public DataTable Read_TotalLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_TOTAL_LEADS_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        //--Product cat by div
        public DataTable Read_Product_Cat_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_PRD_CAT_BY_DIV";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ACTIVE_USR_ID", OracleDbType.Int32).Value = objEntityLead.Active_UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }

        //AWMS DASHBOARD
        public DataTable Read_Vehicle_Details(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_VECH_DETIALS";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        public DataTable Read_Vehicle_InService(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_VECH_COUNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        public DataTable Read_Vehicle_ByYear(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_VECH_YEAR";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_YEAR", OracleDbType.Int32).Value = objEntityLead.FinYearId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        public DataTable Read_Vehicle_ByType(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_VECH_TYPE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCount = new DataTable();
            dtCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtCount;
        }
        public DataTable Read_Water_Card(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_WATER_CARD";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        public DataTable Read_DriverAvailChart(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_DRIV_AVAIL_CHART";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        //READ SETTLED VIOLATION
        public DataTable ReadSetteledViolationMonthly(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_SETTLED_VIOLATIONS_MON";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        //READ PENDING VIOLATION
        public DataTable ReadPendingViolationMonthly(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_PENDING_VIOLATIONS_MON";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        //READ READ_PROJECT_VEHICLE_CLASS COUNT
        public DataTable ReadVehicleCountProjectWise(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_PROJECT_VEHICLE_CLASS";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        //READ READ PROJECT_LIST VEHICLE_CLASS 
        public DataTable ReadVehicleProjectList(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadWaterCard = "DASHBOARD.SP_READ_PROJECT_LIST_VEHICLE";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadWaterCard.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadWaterCard.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtLeadCount;
        }
        //READ READ PERMIT_COUNT 
        public DataTable ReadPermitCount(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_PERMIT_COUNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_MONTHLY", OracleDbType.Int32).Value = objEntityLead.Status;
            cmdReadCount.Parameters.Add("D_FROMDATE", OracleDbType.Varchar2).Value = objEntityLead.From_Date;
            cmdReadCount.Parameters.Add("D_TO_DATE", OracleDbType.Varchar2).Value = objEntityLead.To_Date;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ READ INSUR_COUNT 
        public DataTable ReadInsurCount(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_INSUR_COUNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_MONTHLY", OracleDbType.Int32).Value = objEntityLead.Status;
            cmdReadCount.Parameters.Add("D_FROMDATE", OracleDbType.Varchar2).Value = objEntityLead.From_Date;
            cmdReadCount.Parameters.Add("D_TO_DATE", OracleDbType.Varchar2).Value = objEntityLead.To_Date;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        // for hcm dashboard
        //READ EMPLOYEE LIST TO FILL IN THE TABLE
        public DataTable ReadEmployees(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMPLOYEES";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        // for hcm dashboard
        //Employee details to bind with the bar diagram
        public DataTable ReadDivisions(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_DIVISIONS";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //Employee details to bind with the bar diagram
        public DataTable ReadEmployeesForBarDia(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMPS_HCM_DIAG";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_DIV_ID", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //Employee details to bind with the bar diagram
        public DataTable ReadEmployesAllocated(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMPS_ALLOTED";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_DIV_ID", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //Employee details to bind with the bar diagram
        public DataTable ReadEmployesOnLeave(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMPS_ONLEAVE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_DIV_ID", OracleDbType.Int32).Value = objEntityLead.DivisionId;
            cmdReadCount.Parameters.Add("D_TODY_DATE", OracleDbType.Date).Value = DateTime.Today;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityLead.Org_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityLead.Corp_Id;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
    
        //Employee details list pending approval
        public DataTable ReadPendingCounts(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_PENDING_COUNTS";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDash.UserId;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        

                //Employee details list Count from employee Conduct
        public DataTable ReadPendingCountsEmploeeConduct(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_COUNTS_EMP_CODUCT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDash.UserId;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //READ ACCOMODATION DETAILS
        public DataTable ReadAccodetails(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_ACCOMO_DETAILS";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //READ flight applied list
        public DataTable ReadFlyTodayList(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_FLIGHT_TODAY";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ flight applied list
        public DataTable ReadFlightAppliedList(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_FLIGHT_APPLIED";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ flight applied list
        public DataTable ReadFlightBuyList(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_FLIGHT_BUY";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ flight applied list
        public DataTable ReadFlightAmountList(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_FLIGHT_AMOUNT";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //READ flight applied list
        public DataTable ReadEmpArrive(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMP_ARRIVE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ flight applied list
        public DataTable ReadEmpADepart(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMP_DEPART";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //READ list of empoyee birthday
        public DataTable ReadEmpBirthdayList(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMP_BRTHDYLIST";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }

        //READ NEXT LEAVE DAY
        public DataTable ReadNextLeave(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_READ_EMP_NEXTLEAVE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityDash.UserId;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
        //READ EMPLOYEE ISSUE PERFORMANCE
        public DataTable ReadExpiredEmpPerformance(clsEntityDashBoard objEntityDash)
        {
            string strQueryReadCount = "DASHBOARD.SP_EMP_PERFORMANCE_ISSUE";
            OracleCommand cmdReadCount = new OracleCommand();
            cmdReadCount.CommandText = strQueryReadCount;
            cmdReadCount.CommandType = CommandType.StoredProcedure;
            cmdReadCount.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityDash.Organisation_Id;
            cmdReadCount.Parameters.Add("D_CORPRT_ID", OracleDbType.Int32).Value = objEntityDash.CorporateID;
            cmdReadCount.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeadCount = new DataTable();
            dtLeadCount = clsDataLayer.ExecuteReader(cmdReadCount);
            return dtLeadCount;
        }
    }
}
