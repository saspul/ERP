using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:20/05/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerReports
    {
        //creating objects for data layer
        clsDataLayerReports objDataLayerReports = new clsDataLayerReports();
      
        //read divisions based on organisation id and corporate office id
        public DataTable Read_Divisions(clsEntityReports objEntityReports)
        {
            DataTable dtDivisions = objDataLayerReports.Read_Division(objEntityReports);
            return dtDivisions;
        }

        //read lead summary report on the basis of time limit and division
        public DataTable Read_Lead_Summary(clsEntityReports objEntityReport)
        {
            DataTable dtLeadSummary = objDataLayerReports.Read_Lead_Summary(objEntityReport);
            return dtLeadSummary;
        }

        //methode for selecting the lead details on the basis of date period and division and user id and status
        public DataTable Read_Lead_Summary_Popup(clsEntityReports objEntityReport)
        {
            DataTable dtLeadSummaryPopup = objDataLayerReports.Read_Lead_Summary_Popup(objEntityReport);
            return dtLeadSummaryPopup;
        }
        //readf corporate details for printing
        public DataTable Read_Corp_Details(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadCorporateAddress(objEntityReport);
            return dtCorp;
        }
        //fetch lead count on the basis of status and division
        public DataTable Read_Active_Leads(clsEntityReports objEntityReport)
        {
            DataTable dtActiveLeads = objDataLayerReports.Read_Active_Leads(objEntityReport);
            return dtActiveLeads;
        }
        //fetch lead details based on division
        public DataTable Read_Active_Leads_Popup(clsEntityReports objEntityReport)
        {
            DataTable dtActiveLeadsPopup = objDataLayerReports.Read_Active_Leads_Popup(objEntityReport);
            return dtActiveLeadsPopup;
        }
        //fetch product details based on division
        public DataTable Read_Product_List(clsEntityReports objEntityReport)
        {
            DataTable dtProductList = objDataLayerReports.Read_Product_List(objEntityReport);
            return dtProductList;
        }
        public DataTable Read_Division(clsEntityReports objEntityReport)
        {
            DataTable dtReadDivision = objDataLayerReports.Read_Division(objEntityReport);
            return dtReadDivision;
        }


        //read quotation summary report on the basis of time limit and division
        public DataTable Read_Qtn_Summary(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.Read_Qtn_Summary(objEntityReport);
            return dtQtnSummary;
        }

        //method for selecting the quotation details on the basis of date period and division and user id and status
        public DataTable Read_Quotation_Summary_Popup(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummaryPopup = objDataLayerReports.Read_Quotation_Summary_Popup(objEntityReport);
            return dtQtnSummaryPopup;
        }

        public DataTable ReadCustomer(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadCustomer(objEntityBnkGuarnte);
            return dtCustom;
        }
        public DataTable ReadProject(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadProject(objEntityBnkGuarnte);
            return dtCustom;
        }
        public DataTable ReadStatus(clsEntityReports objEntitySt)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadStatus(objEntitySt);
            return dtCustom;
        }
        public DataTable ReadEmployee(clsEntityReports objEntitySt)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadEmployee(objEntitySt);
            return dtCustom;
        }
        public DataTable getDataLeadDivision(clsEntityReports objEntitySt)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.getDataLeadDivision(objEntitySt);
            return dtCustom;
        }

        public DataTable ReadCustomerExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadCustomerExe(objEntityReport);
            return dtQtnSummary;
        }

        public DataTable ReadProjectExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadProjectExe(objEntityReport);
            return dtQtnSummary;
        }
        public DataTable ReadStatusExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadStatusExe(objEntityReport);
            return dtQtnSummary;
        }

        public DataTable ReadOpenLeadReprtList(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadOpenLeadReprtList(objEntityReport);
            return dtQtnSummary;
        }

        public DataTable ReadStatusSalesExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadStatusSalesExe(objEntityReport);
            return dtQtnSummary;
        }
        public DataTable ReadCustomerSalesExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadCustomerSalesExe(objEntityReport);
            return dtQtnSummary;
        }

        public DataTable ReadOpenLeadReprtSalesExeList(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadOpenLeadReprtSalesExeList(objEntityReport);
            return dtQtnSummary;
        }
        public DataTable ReadProjectSalesExe(clsEntityReports objEntityReport)
        {
            DataTable dtQtnSummary = objDataLayerReports.ReadProjectSalesExe(objEntityReport);
            return dtQtnSummary;
        }
        public DataTable ReadStatusWinLose(clsEntityReports objEntitySt)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadStatusWinLose(objEntitySt);
            return dtCustom;
        }

        public DataTable getLeadDataByDate(clsEntityReports objEntitySt)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.getLeadDataByDate(objEntitySt);
            return dtCustom;
        }
        public DataTable ReadCustomerForBookingReport(clsEntityReports objEntityReport)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadCustomerForBookingReport(objEntityReport);
            return dtCustom;
        }
        public DataTable ReadSalesExecutiveBkngRpt(clsEntityReports objEntityReport)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadSalesExecutiveBkngRpt(objEntityReport);
            return dtCustom;
        }
        //Fetching Sales Executive List for ddl
        public DataTable ReadSalesExecutiveList(clsEntityReports objEntityReport)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadSalesExecutiveList(objEntityReport);
            return dtCustom;
        }
        //Fetching Booking report for Division Manager
        public DataTable ReadDivisionManagerBkngRpt(clsEntityReports objEntityReport)
        {
            DataTable dtCustom = new DataTable();
            dtCustom = objDataLayerReports.ReadDivisionManagerBkngRpt(objEntityReport);
            return dtCustom;
        }
        //EVM-0016
        public DataTable ReadEmployeeByDivisionId(clsEntityReports objEntityReport)
        {

            DataTable dtEmployee = objDataLayerReports.ReadEmployeeByDivisionId(objEntityReport);
            return dtEmployee;
        }
        //EVM-0016
        public DataTable ReadProjectByDivisionId(clsEntityReports objEntityReport)
        {

            DataTable dtEmployee = objDataLayerReports.ReadProjectByDivisionId(objEntityReport);
            return dtEmployee;
        }


        //evm-0020
        public DataTable ReadCurrencyLoad(clsEntityReports objEntityReport)
        {
            DataTable dtCurrency = objDataLayerReports.ReadCurrencyLoad(objEntityReport);
            return dtCurrency;
        }

        public string ReadLeadQtnGrpCount(clsEntityReports objEntityReport)
        {
            string dtGrpDtls = objDataLayerReports.ReadLeadQtnGrpCount(objEntityReport);
            return dtGrpDtls;
        }

        public DataTable ReadGroupDetails(clsEntityReports objEntityReport)
        {
            DataTable dtGrpDtls = objDataLayerReports.ReadGroupDetails(objEntityReport);
            return dtGrpDtls;
        }
        public DataTable ReadGroupAmount(clsEntityReports objEntityReport)
        {
            DataTable dtGrpDtls = objDataLayerReports.ReadGroupAmount(objEntityReport);
            return dtGrpDtls;
        }
        public DataTable Readopenleadsales(clsEntityReports objEntityReport)
        {
            DataTable dtGrpDtls = objDataLayerReports.Read_Open_Leads_Sales(objEntityReport);
            return dtGrpDtls;
        }

        public DataTable getReadProductlist(clsEntityReports objEntityReport)
        {
            DataTable dtGrpDtls = objDataLayerReports.getReadProductlist(objEntityReport);
            return dtGrpDtls;
        }
    }
}
