using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;
using HashingUtility;

// CREATED BY:EVM-0002
// CREATED DATE:20/05/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerReports
    {

        //Method for read divisions based on organisation and corporate office id
        public DataTable ReadDivision(clsEntityReports objEntityReport)
        {
            string strQueryReaDivisions = "REPORTS.SP_READ_DIVISION";
            using (OracleCommand cmdReadDivisions = new OracleCommand())
            {
                cmdReadDivisions.CommandText = strQueryReaDivisions;
                cmdReadDivisions.CommandType = CommandType.StoredProcedure;
                cmdReadDivisions.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadDivisions.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadDivisions.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadDivisions.Parameters.Add("S_DIVISION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDivision = new DataTable();
                dtDivision = clsDataLayer.SelectDataTable(cmdReadDivisions);
                return dtDivision;
            }
        }
        //methode for selecting the report on the basis of date period and division
        public DataTable Read_Lead_Summary(clsEntityReports objEntityReport)
        {
            string strQueryReaLeadSummary = "REPORTS.SP_READ_LEAD_SUMMARY_ONDIV";
            using (OracleCommand cmdReadLeadSummary = new OracleCommand())
            {
                cmdReadLeadSummary.CommandText = strQueryReaLeadSummary;
                cmdReadLeadSummary.CommandType = CommandType.StoredProcedure;
                cmdReadLeadSummary.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadLeadSummary.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadLeadSummary.Parameters.Add("S_FROMDATE", OracleDbType.Varchar2).Value = objEntityReport.From_Date;
                cmdReadLeadSummary.Parameters.Add("S_TODATE", OracleDbType.Varchar2).Value = objEntityReport.To_Date;
                cmdReadLeadSummary.Parameters.Add("S_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadLeadSummary.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadLeadSummary.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadLeadSummary.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadLeadSummary.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadLeadSummary.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadLeadSummary.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadLeadSummary.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSummary = new DataTable();
                dtLeadSummary = clsDataLayer.SelectDataTable(cmdReadLeadSummary);
                return dtLeadSummary;
            }
        }

        //methode for selecting the lead details on the basis of date period and division and user id and status
        public DataTable Read_Lead_Summary_Popup(clsEntityReports objEntityReport)
        {
            string strQueryReaLeadSummaryPopup = "REPORTS.SP_READ_LEAD_SUMMARY_POPUP";
            using (OracleCommand cmdReadLeadSummaryPopup = new OracleCommand())
            {
                cmdReadLeadSummaryPopup.CommandText = strQueryReaLeadSummaryPopup;
                cmdReadLeadSummaryPopup.CommandType = CommandType.StoredProcedure;

                cmdReadLeadSummaryPopup.Parameters.Add("S_FROMDATE", OracleDbType.Varchar2).Value = objEntityReport.From_Date;
                cmdReadLeadSummaryPopup.Parameters.Add("S_TODATE", OracleDbType.Varchar2).Value = objEntityReport.To_Date;
                cmdReadLeadSummaryPopup.Parameters.Add("S_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadLeadSummaryPopup.Parameters.Add("S_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadLeadSummaryPopup.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = objEntityReport.Lead_Status;
                cmdReadLeadSummaryPopup.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadLeadSummaryPopup.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadLeadSummaryPopup.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadLeadSummaryPopup.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadLeadSummaryPopup.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadLeadSummaryPopup.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadLeadSummaryPopup.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadLeadSummaryPopup.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadLeadSummaryPopup.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSummary = new DataTable();
                dtLeadSummary = clsDataLayer.SelectDataTable(cmdReadLeadSummaryPopup);
                return dtLeadSummary;
            }
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityReports objEntRprt)
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


        //methode for fetching the lead count on the basis of status and division
        public DataTable Read_Active_Leads(clsEntityReports objEntityReport)
        {
            string strQueryReaActiveLeads = "REPORTS.SP_READ_ACTIVE_LEADS";
            using (OracleCommand cmdReadActiveLeads = new OracleCommand())
            {
                cmdReadActiveLeads.CommandText = strQueryReaActiveLeads;
                cmdReadActiveLeads.CommandType = CommandType.StoredProcedure;
                cmdReadActiveLeads.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadActiveLeads.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadActiveLeads.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadActiveLeads.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadActiveLeads.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadActiveLeads.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadActiveLeads.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadActiveLeads.Parameters.Add("M_CRNCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadActiveLeads.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtActiveLeads = new DataTable();
                dtActiveLeads = clsDataLayer.SelectDataTable(cmdReadActiveLeads);
                return dtActiveLeads;
            }
        }


        //methode for fetching the lead details on the basis of division
        public DataTable Read_Active_Leads_Popup(clsEntityReports objEntityReport)
        {
            string strQueryReaActiveLeadsPopup = "REPORTS.SP_READ_ACTIVE_LEADS_POPUP";
            using (OracleCommand cmdReadActiveLeadsPopup = new OracleCommand())
            {
                cmdReadActiveLeadsPopup.CommandText = strQueryReaActiveLeadsPopup;
                cmdReadActiveLeadsPopup.CommandType = CommandType.StoredProcedure;
                cmdReadActiveLeadsPopup.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadActiveLeadsPopup.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadActiveLeadsPopup.Parameters.Add("L_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;

                cmdReadActiveLeadsPopup.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadActiveLeadsPopup.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadActiveLeadsPopup.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadActiveLeadsPopup.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadActiveLeadsPopup.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadActiveLeadsPopup.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadActiveLeadsPopup.Parameters.Add("M_CRNCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadActiveLeadsPopup.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtActiveLeads = new DataTable();
                dtActiveLeads = clsDataLayer.SelectDataTable(cmdReadActiveLeadsPopup);
                return dtActiveLeads;
            }
        }

        //method for fetching product details 
        public DataTable Read_Product_List(clsEntityReports objEntityReport)
        {
            string strQueryReadProductList = "REPORTS.SP_READ_PRODUCT_LIST";
            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadProductList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadProductList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }

        //method for fetching DIVISION BASED ON USER
        public DataTable Read_Division(clsEntityReports objEntityReport)
        {
            string strQueryReadDivision = "REPORTS.SP_READ_DIVISION";
            using (OracleCommand cmdReadDivision = new OracleCommand())
            {
                cmdReadDivision.CommandText = strQueryReadDivision;
                cmdReadDivision.CommandType = CommandType.StoredProcedure;
                cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadDivision.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadDivision = new DataTable();
                dtReadDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
                return dtReadDivision;
            }
        }

        //method for selecting the report on the basis of date period and division
        public DataTable Read_Qtn_Summary(clsEntityReports objEntityReport)
        {
            string strQueryReaQtnSummary = "REPORTS.SP_READ_QTN_SUMMARY_ONDIV";
            using (OracleCommand cmdReadQtnSummary = new OracleCommand())
            {
                cmdReadQtnSummary.CommandText = strQueryReaQtnSummary;
                cmdReadQtnSummary.CommandType = CommandType.StoredProcedure;
                cmdReadQtnSummary.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadQtnSummary.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadQtnSummary.Parameters.Add("S_FROMDATE", OracleDbType.Varchar2).Value = objEntityReport.From_Date;
                cmdReadQtnSummary.Parameters.Add("S_TODATE", OracleDbType.Varchar2).Value = objEntityReport.To_Date;
                cmdReadQtnSummary.Parameters.Add("S_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadQtnSummary.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadQtnSummary.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadQtnSummary.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadQtnSummary.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadQtnSummary.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadQtnSummary.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadQtnSummary.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSummary = new DataTable();
                dtLeadSummary = clsDataLayer.SelectDataTable(cmdReadQtnSummary);
                return dtLeadSummary;
            }
        }




        //method for selecting the quotation details on the basis of date period and division and user id and status
        public DataTable Read_Quotation_Summary_Popup(clsEntityReports objEntityReport)
        {
            string strQueryReaQuotationSummaryPopup = "REPORTS.SP_READ_QTN_SUMMARY_POPUP";
            using (OracleCommand cmdReadQuotationSummaryPopup = new OracleCommand())
            {
                cmdReadQuotationSummaryPopup.CommandText = strQueryReaQuotationSummaryPopup;
                cmdReadQuotationSummaryPopup.CommandType = CommandType.StoredProcedure;

                cmdReadQuotationSummaryPopup.Parameters.Add("S_FROMDATE", OracleDbType.Varchar2).Value = objEntityReport.From_Date;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_TODATE", OracleDbType.Varchar2).Value = objEntityReport.To_Date;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_DIVID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = objEntityReport.Quotaion_Status;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadQuotationSummaryPopup.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadQuotationSummaryPopup.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeadSummary = new DataTable();
                dtLeadSummary = clsDataLayer.SelectDataTable(cmdReadQuotationSummaryPopup);
                return dtLeadSummary;
            }
        }


        // EVM-0014 load Customer name
        public DataTable ReadCustomer(clsEntityReports objEntityCust)
        {
            string strQueryReadCustName = "LEAD_REPORT_DIVISION.SP_READ_CUSTOMER";
            using (OracleCommand cmdReadBankGuarnt = new OracleCommand())
            {
                cmdReadBankGuarnt.CommandText = strQueryReadCustName;
                cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
                cmdReadBankGuarnt.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityCust.User_Id;
                cmdReadBankGuarnt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCust.Organisation_Id;
                cmdReadBankGuarnt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCust.Corporate_Id;
                cmdReadBankGuarnt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
                return dtCust;
            }
        }
        // EVM-0014 load PROJECT name
        public DataTable ReadProject(clsEntityReports objEntityProj)
        {
            string strQueryReadProj = "LEAD_REPORT_DIVISION.SP_READ_PROJECT";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProj.User_Id;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProj.Organisation_Id;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProj.Corporate_Id;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        // EVM-0014 load STATUS
        public DataTable ReadStatus(clsEntityReports objEntitystat)
        {
            string strQueryReaStat = "LEAD_REPORT_DIVISION.SP_READ_STATUS";
            using (OracleCommand cmdReadStatus = new OracleCommand())
            {
                cmdReadStatus.CommandText = strQueryReaStat;
                cmdReadStatus.CommandType = CommandType.StoredProcedure;
                cmdReadStatus.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadStatus);
                return dtCust;
            }
        }
        // EVM-0014 load LOAD EMPLOYEE NAME
        public DataTable ReadEmployee(clsEntityReports objEntityEmp)
        {
            string strQueryReadEmp = "LEAD_REPORT_DIVISION.SP_READ_EMPLOYEE";
            using (OracleCommand cmdReademp = new OracleCommand())
            {
                cmdReademp.CommandText = strQueryReadEmp;
                cmdReademp.CommandType = CommandType.StoredProcedure;
                cmdReademp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.User_Id;
                cmdReademp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmp.Organisation_Id;
                cmdReademp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmp.Corporate_Id;
                cmdReademp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReademp);
                return dtCust;
            }
        }
        // EVM-0014 load table data
        public DataTable getDataLeadDivision(clsEntityReports objEntityEmp)
        {
            string strQueryReadLeadDiv = "LEAD_REPORT_DIVISION.SP_READ_FETCH_DATA";
            OracleCommand cmdReadLeadDiv = new OracleCommand();
            cmdReadLeadDiv.CommandText = strQueryReadLeadDiv;
            cmdReadLeadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadLeadDiv.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.User_Id;
            cmdReadLeadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmp.Organisation_Id;
            cmdReadLeadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmp.Corporate_Id;
            cmdReadLeadDiv.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityEmp.Division_Id;
            cmdReadLeadDiv.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityEmp.StatusId;
            cmdReadLeadDiv.Parameters.Add("P_PROJID", OracleDbType.Int32).Value = objEntityEmp.ProjectId;
            cmdReadLeadDiv.Parameters.Add("P_CUSTID", OracleDbType.Int32).Value = objEntityEmp.CustomerId;
            cmdReadLeadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.EmployeeId;
            cmdReadLeadDiv.Parameters.Add("P_CRNCYID", OracleDbType.Int32).Value = objEntityEmp.CurrencyId;
            //------------------------------------------Pagination------------------------------------------------
            cmdReadLeadDiv.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityEmp.CommonSearchTerm;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityEmp.SearchRef;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityEmp.SearchDate;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_ASSIGNTO", OracleDbType.Varchar2).Value = objEntityEmp.SearchAssignTo;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityEmp.SearchProject;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityEmp.SearchCustomer;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_STATUS", OracleDbType.Varchar2).Value = objEntityEmp.SearchStatus;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_QUOTREF", OracleDbType.Varchar2).Value = objEntityEmp.SearchQuotRef;
            cmdReadLeadDiv.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityEmp.OrderColumn;
            cmdReadLeadDiv.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityEmp.OrderMethod;
            cmdReadLeadDiv.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityEmp.PageMaxSize;
            cmdReadLeadDiv.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityEmp.PageNumber;
            //------------------------------------------Pagination------------------------------------------------
            cmdReadLeadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadLeadDiv);
            return dtCategory;
        }


        //method for fetching Customer Details 
        public DataTable ReadCustomerExe(clsEntityReports objEntityReport)
        {
            string strQueryReadProductList = "REPORT_LEAD.SP_READ_CUSTOMERS";
            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }
        //method for fetching Project Details 
        public DataTable ReadProjectExe(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_PROJECT";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }


        //method for fetching Lead Status Details 
        public DataTable ReadStatusExe(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_LEADSTS";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        //method for fetching Lead  Details 
        public DataTable ReadOpenLeadReprtList(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_LEADLIST";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            if (objEntityBnkGuarnte.ProjctId == 0)
            {
                cmdReadBankGuarnt.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("L_PRJCTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.ProjctId;
            }
            cmdReadBankGuarnt.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityBnkGuarnte.LeadStsId;
            if (objEntityBnkGuarnte.CustomerId == 0)
            {
                cmdReadBankGuarnt.Parameters.Add("L_CUSTID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("L_CUSTID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CustomerId;
            }
            cmdReadBankGuarnt.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CURNCYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;
            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }


        public DataTable ReadStatusSalesExe(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_LEADSTS_EXE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        //method for fetching Customer Details 
        public DataTable ReadCustomerSalesExe(clsEntityReports objEntityReport)
        {
            string strQueryReadProductList = "REPORT_LEAD.SP_READ_CUSTOMERS_EXE";
            using (OracleCommand cmdReadProductList = new OracleCommand())
            {
                cmdReadProductList.CommandText = strQueryReadProductList;
                cmdReadProductList.CommandType = CommandType.StoredProcedure;
                cmdReadProductList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadProductList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadProductList.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadProductList = new DataTable();
                dtReadProductList = clsDataLayer.SelectDataTable(cmdReadProductList);
                return dtReadProductList;
            }
        }
        //method for fetching Project Details 
        public DataTable ReadProjectSalesExe(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_PROJECT_EXE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;
            cmdReadBankGuarnt.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        //method for fetching Lead  Details 
        public DataTable ReadOpenLeadReprtSalesExeList(clsEntityReports objEntityBnkGuarnte)
        {
            string strQueryReadBankGuarnt = "REPORT_LEAD.SP_READ_LEADLIST_EXE";
            OracleCommand cmdReadBankGuarnt = new OracleCommand();
            cmdReadBankGuarnt.CommandText = strQueryReadBankGuarnt;
            cmdReadBankGuarnt.CommandType = CommandType.StoredProcedure;

            if (objEntityBnkGuarnte.LeadDateTo != DateTime.MinValue)
            {

                cmdReadBankGuarnt.Parameters.Add("B_LEAD_DATETO", OracleDbType.Date).Value = objEntityBnkGuarnte.LeadDateTo;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_LEAD_DATETO", OracleDbType.Date).Value = null;
            }
            if (objEntityBnkGuarnte.LeadDate != DateTime.MinValue)
            {

                cmdReadBankGuarnt.Parameters.Add("B_LEAD_DATE", OracleDbType.Date).Value = objEntityBnkGuarnte.LeadDate;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("B_LEAD_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityBnkGuarnte.ProjctId == 0)
            {
                cmdReadBankGuarnt.Parameters.Add("L_PRJCTID", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("L_PRJCTID", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.ProjctId;
            }
            cmdReadBankGuarnt.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityBnkGuarnte.LeadStsId;
            if (objEntityBnkGuarnte.CustomerId == 0)
            {
                cmdReadBankGuarnt.Parameters.Add("L_CUSTID", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadBankGuarnt.Parameters.Add("L_CUSTID", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.CustomerId;
            }
            cmdReadBankGuarnt.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadBankGuarnt.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Organisation_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityBnkGuarnte.Corporate_Id;
            cmdReadBankGuarnt.Parameters.Add("L_CURNCYID", OracleDbType.Int32).Value = objEntityBnkGuarnte.CurrencyId;

            cmdReadBankGuarnt.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.CommonSearchTerm;
            cmdReadBankGuarnt.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.SearchRef;
            cmdReadBankGuarnt.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.SearchDate;
            cmdReadBankGuarnt.Parameters.Add("M_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.SearchProject;
            cmdReadBankGuarnt.Parameters.Add("M_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.SearchCustomer;
            cmdReadBankGuarnt.Parameters.Add("M_SEARCH_QUOTREF", OracleDbType.Varchar2).Value = objEntityBnkGuarnte.SearchQuotRef;
            cmdReadBankGuarnt.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityBnkGuarnte.OrderColumn;
            cmdReadBankGuarnt.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityBnkGuarnte.OrderMethod;
            cmdReadBankGuarnt.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityBnkGuarnte.PageMaxSize;
            cmdReadBankGuarnt.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityBnkGuarnte.PageNumber;


            cmdReadBankGuarnt.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadBankGuarnt);
            return dtCategory;
        }

        // EVM-0014 load STATUS WIN/LOSS/QUOTESUBMIT
        public DataTable ReadStatusWinLose(clsEntityReports objEntitystat)
        {
            string strQueryReaStat = "LEAD_REPORT_DIVISION.SP_READ_STATUS_WIN";
            using (OracleCommand cmdReadStatus = new OracleCommand())
            {
                cmdReadStatus.CommandText = strQueryReaStat;
                cmdReadStatus.CommandType = CommandType.StoredProcedure;
                cmdReadStatus.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadStatus);
                return dtCust;
            }
        }
        // EVM-0014 load table data BY LEAD DATE
        public DataTable getLeadDataByDate(clsEntityReports objEntityEmp)
        {
            string strQueryReadLeadDiv = "LEAD_REPORT_DIVISION.SP_READ_DATA_BY_DATE";
            OracleCommand cmdReadLeadDiv = new OracleCommand();
            cmdReadLeadDiv.CommandText = strQueryReadLeadDiv;
            cmdReadLeadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadLeadDiv.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.User_Id;
            cmdReadLeadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmp.Organisation_Id;
            cmdReadLeadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmp.Corporate_Id;
            cmdReadLeadDiv.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityEmp.Division_Id;
            cmdReadLeadDiv.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityEmp.StatusId;
            cmdReadLeadDiv.Parameters.Add("P_PROJID", OracleDbType.Int32).Value = objEntityEmp.ProjectId;
            cmdReadLeadDiv.Parameters.Add("P_CUSTID", OracleDbType.Int32).Value = objEntityEmp.CustomerId;
            cmdReadLeadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityEmp.EmployeeId;

            if (objEntityEmp.FDate != DateTime.MinValue)
            {
                cmdReadLeadDiv.Parameters.Add("P_FDATE", OracleDbType.Date).Value = objEntityEmp.FDate;
            }
            else
            {
                cmdReadLeadDiv.Parameters.Add("P_FDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityEmp.LDate != DateTime.MinValue)
            {
                cmdReadLeadDiv.Parameters.Add("P_LDATE", OracleDbType.Date).Value = objEntityEmp.LDate;
            }
            else
            {
                cmdReadLeadDiv.Parameters.Add("P_LDATE", OracleDbType.Date).Value = null;
            }

            cmdReadLeadDiv.Parameters.Add("P_CRNCYID", OracleDbType.Int32).Value = objEntityEmp.CurrencyId;

            cmdReadLeadDiv.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityEmp.CommonSearchTerm;
            cmdReadLeadDiv.Parameters.Add("M_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityEmp.SearchRef;
            cmdReadLeadDiv.Parameters.Add("M_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityEmp.SearchDate;
            cmdReadLeadDiv.Parameters.Add("M_SEARCH_ASSIGN", OracleDbType.Varchar2).Value = objEntityEmp.SearchAssignTo;
            cmdReadLeadDiv.Parameters.Add("M_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityEmp.SearchProject;
            cmdReadLeadDiv.Parameters.Add("M_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityEmp.SearchCustomer;
            cmdReadLeadDiv.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityEmp.OrderColumn;
            cmdReadLeadDiv.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityEmp.OrderMethod;
            cmdReadLeadDiv.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityEmp.PageMaxSize;
            cmdReadLeadDiv.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityEmp.PageNumber;

            cmdReadLeadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadLeadDiv);
            return dtCategory;
        }
        //EVM-0012
        //method for fetching Customer Details for booking report for sales executive
        public DataTable ReadCustomerForBookingReport(clsEntityReports objEntityReport)
        {
            string strQueryReadCustomerList = "REPORTS.SP_READ_CUSTOMERS_BKNG_RPT";
            using (OracleCommand cmdReadCustomerList = new OracleCommand())
            {
                cmdReadCustomerList.CommandText = strQueryReadCustomerList;
                cmdReadCustomerList.CommandType = CommandType.StoredProcedure;
                cmdReadCustomerList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadCustomerList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadCustomerList.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCustomerList = new DataTable();
                dtReadCustomerList = clsDataLayer.SelectDataTable(cmdReadCustomerList);
                return dtReadCustomerList;
            }
        }
        //method for fetching booking report for sales executive
        public DataTable ReadSalesExecutiveBkngRpt(clsEntityReports objEntityReport)
        {
            string strQueryReadBkngRpt = "REPORTS.SP_READ_BOOKING_REPORT";
            using (OracleCommand cmdReadSalesExecutiveBkngRpt = new OracleCommand())
            {

                cmdReadSalesExecutiveBkngRpt.CommandText = strQueryReadBkngRpt;
                cmdReadSalesExecutiveBkngRpt.CommandType = CommandType.StoredProcedure;

                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_YEAR", OracleDbType.Int32).Value = objEntityReport.Year;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_MONTH", OracleDbType.Varchar2).Value = objEntityReport.Month;

                if (objEntityReport.Quarter == 0)
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_QUARTER", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_QUARTER", OracleDbType.Int32).Value = objEntityReport.Quarter;
                }
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CSTMR_ID", OracleDbType.Varchar2).Value = objEntityReport.CustomerId;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_USR_ID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CURNCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityReport.SearchRef;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_QUARTER", OracleDbType.Varchar2).Value = objEntityReport.SearchQuarter;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_MONTH", OracleDbType.Varchar2).Value = objEntityReport.SearchMonth;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityReport.SearchProject;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityReport.SearchCustomer;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_QUOTREF", OracleDbType.Varchar2).Value = objEntityReport.SearchQuotRef;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_STATUS", OracleDbType.Varchar2).Value = objEntityReport.SearchStatus;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;

                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadBkngRpt = new DataTable();
                dtReadBkngRpt = clsDataLayer.SelectDataTable(cmdReadSalesExecutiveBkngRpt);
                return dtReadBkngRpt;
            }
        }
        //Fetching Sales Executive List for ddl
        public DataTable ReadSalesExecutiveList(clsEntityReports objEntityReport)
        {
            string strQueryReadSalesExecutiveList = "REPORTS.SP_READ_SALES_EXEC_DIVSN_MGR";
            using (OracleCommand cmdReadSalesExecutiveList = new OracleCommand())
            {
                cmdReadSalesExecutiveList.CommandText = strQueryReadSalesExecutiveList;
                cmdReadSalesExecutiveList.CommandType = CommandType.StoredProcedure;
                cmdReadSalesExecutiveList.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadSalesExecutiveList.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadSalesExecutiveList.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadSalesExecutiveList.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCustomerList = new DataTable();
                dtReadCustomerList = clsDataLayer.SelectDataTable(cmdReadSalesExecutiveList);
                return dtReadCustomerList;
            }
        }
        //Fetching Booking report for Division Manager
        public DataTable ReadDivisionManagerBkngRpt(clsEntityReports objEntityReport)
        {
            string strQueryReadBkngRpt = "REPORTS.SP_READ_BKNG_RPT_FOR_DIVSN_MGR";
            using (OracleCommand cmdReadSalesExecutiveBkngRpt = new OracleCommand())
            {

                cmdReadSalesExecutiveBkngRpt.CommandText = strQueryReadBkngRpt;
                cmdReadSalesExecutiveBkngRpt.CommandType = CommandType.StoredProcedure;

                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_YEAR", OracleDbType.Int32).Value = objEntityReport.Year;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_MONTH", OracleDbType.Varchar2).Value = objEntityReport.Month;

                if (objEntityReport.Quarter == 0)
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_QUARTER", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_QUARTER", OracleDbType.Int32).Value = objEntityReport.Quarter;
                }
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CSTMR_ID", OracleDbType.Varchar2).Value = objEntityReport.CustomerId;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_USR_ID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                if (objEntityReport.SalesExecutiveId == 0)
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_SALES_EXE_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_SALES_EXE_ID", OracleDbType.Int32).Value = objEntityReport.SalesExecutiveId;
                }
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_CURNCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                //------------------------------------------Pagination------------------------------------------------
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityReport.SearchRef;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_QUARTER", OracleDbType.Varchar2).Value = objEntityReport.SearchQuarter;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_MONTH", OracleDbType.Varchar2).Value = objEntityReport.SearchMonth;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_ASSIGNTO", OracleDbType.Varchar2).Value = objEntityReport.SearchAssignTo;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityReport.SearchProject;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityReport.SearchCustomer;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_QUOTREF", OracleDbType.Varchar2).Value = objEntityReport.SearchQuotRef;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_SEARCH_STATUS", OracleDbType.Varchar2).Value = objEntityReport.SearchStatus;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                //------------------------------------------Pagination------------------------------------------------
                cmdReadSalesExecutiveBkngRpt.Parameters.Add("B_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadBkngRpt = new DataTable();
                dtReadBkngRpt = clsDataLayer.SelectDataTable(cmdReadSalesExecutiveBkngRpt);
                return dtReadBkngRpt;
            }
        }
        //EVM-0016
        public DataTable ReadEmployeeByDivisionId(clsEntityReports objEntityReport)
        {
            string strQueryReadEmployeeByDivision = "REPORTS.SP_READ_EMPLOYEE_BY_DIVISION";
            using (OracleCommand cmdReadEmployeeByDivision = new OracleCommand())
            {
                cmdReadEmployeeByDivision.CommandText = strQueryReadEmployeeByDivision;
                cmdReadEmployeeByDivision.CommandType = CommandType.StoredProcedure;
                cmdReadEmployeeByDivision.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_DIV_ID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadEmployee = new DataTable();
                dtReadEmployee = clsDataLayer.SelectDataTable(cmdReadEmployeeByDivision);
                return dtReadEmployee;
            }
        }
        //EVM-0016
        public DataTable ReadProjectByDivisionId(clsEntityReports objEntityReport)
        {
            string strQueryReadEmployeeByDivision = "REPORTS.SP_PROJECT_BY_DIVISION";
            using (OracleCommand cmdReadEmployeeByDivision = new OracleCommand())
            {
                cmdReadEmployeeByDivision.CommandText = strQueryReadEmployeeByDivision;
                cmdReadEmployeeByDivision.CommandType = CommandType.StoredProcedure;
                cmdReadEmployeeByDivision.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_USR_ID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_DIV_ID", OracleDbType.Int32).Value = objEntityReport.Division_Id;
                cmdReadEmployeeByDivision.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadEmployee = new DataTable();
                dtReadEmployee = clsDataLayer.SelectDataTable(cmdReadEmployeeByDivision);
                return dtReadEmployee;
            }
        }

        //evm-0020
        public DataTable ReadCurrencyLoad(clsEntityReports objEntityReport)
        {
            string strQueryReadQtnAttchmnt = "REPORTS.SP_READ_CURNCY_LOAD";
            OracleCommand cmdReadCurrency = new OracleCommand();
            cmdReadCurrency.CommandText = strQueryReadQtnAttchmnt;
            cmdReadCurrency.CommandType = CommandType.StoredProcedure;
            cmdReadCurrency.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
            cmdReadCurrency.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
            cmdReadCurrency.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadCurrency);
            return dtDtl;
        }

        public string ReadLeadQtnGrpCount(clsEntityReports objEntityReport)
        {
            string strQueryReadGrpCount = "REPORTS.SP_READ_GROUPCOUNT";
            OracleCommand cmdReadGrpCount = new OracleCommand();
            cmdReadGrpCount.CommandText = strQueryReadGrpCount;
            cmdReadGrpCount.CommandType = CommandType.StoredProcedure;
            cmdReadGrpCount.Parameters.Add("LD_QTN", OracleDbType.Int32).Value = objEntityReport.LdQtnId;
            cmdReadGrpCount.Parameters.Add("GRP_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadGrpCount);
            string intReturn = cmdReadGrpCount.Parameters["GRP_COUNT"].Value.ToString();
            cmdReadGrpCount.Dispose();
            return intReturn;

        }

        public DataTable ReadGroupAmount(clsEntityReports objEntityReport)
        {
            string strQueryReadQtnGrp = "REPORTS.SP_READ_GRP_AMT";
            OracleCommand cmdReadGrpDtls = new OracleCommand();
            cmdReadGrpDtls.CommandText = strQueryReadQtnGrp;
            cmdReadGrpDtls.CommandType = CommandType.StoredProcedure;
            cmdReadGrpDtls.Parameters.Add("LD_QTN", OracleDbType.Int32).Value = objEntityReport.LdQtnId;
            cmdReadGrpDtls.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
            cmdReadGrpDtls.Parameters.Add("GRP_DTLS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadGrpDtls);
            return dtDtl;
        }

        public DataTable ReadGroupDetails(clsEntityReports objEntityReport)
        {
            string strQueryReadQtnGrp = "REPORTS.SP_READ_GRP_DTLS";
            OracleCommand cmdReadGrpDtls = new OracleCommand();
            cmdReadGrpDtls.CommandText = strQueryReadQtnGrp;
            cmdReadGrpDtls.CommandType = CommandType.StoredProcedure;
            cmdReadGrpDtls.Parameters.Add("LD_QTN", OracleDbType.Int32).Value = objEntityReport.LdQtnId;
            cmdReadGrpDtls.Parameters.Add("GRP_ID", OracleDbType.Int32).Value = objEntityReport.GroupId;
            cmdReadGrpDtls.Parameters.Add("GRP_AMT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadGrpDtls);
            return dtDtl;
        }
        public DataTable Read_Open_Leads_Sales(clsEntityReports objEntityReport)
        {
            string strQueryReaActiveLeads = "REPORTS.SP_READ_OPEN_LEADS_SALES";
            using (OracleCommand cmdReadActiveLeads = new OracleCommand())
            {
                cmdReadActiveLeads.CommandText = strQueryReaActiveLeads;
                cmdReadActiveLeads.CommandType = CommandType.StoredProcedure;
                cmdReadActiveLeads.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityReport.Organisation_Id;
                cmdReadActiveLeads.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityReport.Corporate_Id;
                cmdReadActiveLeads.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityReport.User_Id;
                cmdReadActiveLeads.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = objEntityReport.StatusId;
                if (objEntityReport.CustomerId == 0)
                {
                    cmdReadActiveLeads.Parameters.Add("L_CUSTOMER", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadActiveLeads.Parameters.Add("L_CUSTOMER", OracleDbType.Int32).Value = objEntityReport.CustomerId;

                }
                if (objEntityReport.ProjctId == 0)
                {
                    cmdReadActiveLeads.Parameters.Add("L_PROJECT", OracleDbType.Int32).Value = null;

                }
                else
                {
                    cmdReadActiveLeads.Parameters.Add("L_PROJECT", OracleDbType.Int32).Value = objEntityReport.ProjctId;

                }

                cmdReadActiveLeads.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityReport.CommonSearchTerm;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityReport.SearchName;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_UDATE", OracleDbType.Varchar2).Value = objEntityReport.To_Date;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_PROJECT", OracleDbType.Varchar2).Value = objEntityReport.ProjctName;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_CUSTOMER", OracleDbType.Varchar2).Value = objEntityReport.Customername;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_OPSTATUS", OracleDbType.Varchar2).Value = objEntityReport.GroupName;
                cmdReadActiveLeads.Parameters.Add("M_SEARCH_QUOTREF", OracleDbType.Varchar2).Value = objEntityReport.Month;
                cmdReadActiveLeads.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityReport.OrderColumn;
                cmdReadActiveLeads.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityReport.OrderMethod;
                cmdReadActiveLeads.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityReport.PageMaxSize;
                cmdReadActiveLeads.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityReport.PageNumber;
                cmdReadActiveLeads.Parameters.Add("M_CRNCYID", OracleDbType.Int32).Value = objEntityReport.CurrencyId;
                cmdReadActiveLeads.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtActiveLeads = new DataTable();
                dtActiveLeads = clsDataLayer.SelectDataTable(cmdReadActiveLeads);
                return dtActiveLeads;
            }
        }



        public DataTable getReadProductlist(clsEntityReports objEntityEmp)
        {
            string strQueryReadLeadDiv = "REPORTS.SP_READ_FETCH_PRODUCTLIST";
            OracleCommand cmdReadLeadDiv = new OracleCommand();
            cmdReadLeadDiv.CommandText = strQueryReadLeadDiv;
            cmdReadLeadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadLeadDiv.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityEmp.User_Id;
            cmdReadLeadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityEmp.Organisation_Id;
            cmdReadLeadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityEmp.Corporate_Id;
            cmdReadLeadDiv.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityEmp.Division_Id;
            cmdReadLeadDiv.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityEmp.StatusId;
            cmdReadLeadDiv.Parameters.Add("P_PRONATURE", OracleDbType.Int32).Value = objEntityEmp.ProjectId;
            cmdReadLeadDiv.Parameters.Add("P_GROUPID", OracleDbType.Int32).Value = objEntityEmp.GroupId;
            cmdReadLeadDiv.Parameters.Add("P_CATGID", OracleDbType.Int32).Value = objEntityEmp.GuarCatgryId;

            //------------------------------------------Pagination------------------------------------------------
            cmdReadLeadDiv.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityEmp.CommonSearchTerm;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityEmp.SearchCode;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_PRODUCT", OracleDbType.Varchar2).Value = objEntityEmp.SearchProduct;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_GROUP", OracleDbType.Varchar2).Value = objEntityEmp.SearchGroup;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_CATEGORY", OracleDbType.Varchar2).Value = objEntityEmp.SearchCategory;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_BRAND", OracleDbType.Varchar2).Value = objEntityEmp.SearchBrand;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_DIVISION", OracleDbType.Varchar2).Value = objEntityEmp.SearchDivision;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_NATURE", OracleDbType.Varchar2).Value = objEntityEmp.Searchnature;
            cmdReadLeadDiv.Parameters.Add("P_SEARCH_EXCODE", OracleDbType.Varchar2).Value = objEntityEmp.SearchExcode;
            cmdReadLeadDiv.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityEmp.OrderColumn;
            cmdReadLeadDiv.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityEmp.OrderMethod;
            cmdReadLeadDiv.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityEmp.PageMaxSize;
            cmdReadLeadDiv.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityEmp.PageNumber;
            //------------------------------------------Pagination------------------------------------------------
            cmdReadLeadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadLeadDiv);
            return dtCategory;
        }
    }
}
