using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;


namespace BL_Compzit
{
    public class clsBusinessLayerDashboard
    {
        clsDataLayerDashboard objDataLayerDashboard = new clsDataLayerDashboard();

        //THIS METHORD IS FOR READING TOTAL LEAD,WON LEAD,LOSS LEAD OF CURRENT MONTH OF CURRENT USER
        public DataTable Read_WL_Lead_Count_of_CurrentMonth(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCountList = objDataLayerDashboard.Read_WL_Lead_Count_of_CurrentMonth(objEntityLead);
            return dtCountList;
        }
        //THIS METHORD IS FOR READING TOTAL  NEW LEAD,APPROVED LEAD,ACTIVE LEAD OF CURRENT USER
        public DataTable Read_Total_New_Aprv_Actv_Lead_Count(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCountList = objDataLayerDashboard.Read_Total_New_Aprv_Actv_Lead_Count(objEntityLead);
            return dtCountList;
        }
        //THIS METHORD IS FOR READING TOTAL UNREAD MAIL OF USER AND ALSO DIVISON AND TEAM IF SECRATORY BASED ON CHILD ROLE
        public DataTable Read_UnReadMail(clsEntityMailConsole objEntityMail)
        {
            DataTable dtCountList = objDataLayerDashboard.Read_UnReadMail(objEntityMail);
            return dtCountList;
        }
        //THIS METHORD IS FOR READING TOTAL  COUNT OF OPEN,ABOUT TO BREACH,BREACHED,UPCOMING TASK OF CURRENT USER
        public DataTable Read_Total_Task_Count(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCountList = objDataLayerDashboard.Read_Total_Task_Count(objEntityLead);
            return dtCountList;
        }

        //THIS METHORD IS FOR READING TASK LIST BASED ON TASK_LIST_MODE(1.ABOUT TO BREACH,2.BREACHED,3.OPEN,4.UPCOMMING)OF CURRENT USER
        public DataTable Read_Task_List(clsEntityLeadCreation objEntityLead, int intListMode)
        {
            DataTable dtList = objDataLayerDashboard.Read_Task_List(objEntityLead, intListMode);
            return dtList;
        }

        //THIS METHORD  IS FOR READING  TEAM LIST FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_TeamList_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerDashboard.Read_TeamList_For_TeamHead(objEntityLead);
            return dtList;
        }

        //THIS METHORD IS FOR READING COUNT OF APROVAL PENDING LEADS OF TEAM FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_Count_ApprvlPendingLead_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerDashboard.Read_Count_ApprvlPendingLead_For_TeamHead(objEntityLead);
            return dtList;
        }

        //THIS  METHORD IS FOR READING COUNT OF UNREAD ALLOCATED MAIL OF TEAM FOR  TEAM HEAD DASHBOARD 
        public DataTable Read_Count_UnreadAllocatedMail_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtList = objDataLayerDashboard.Read_Count_UnreadAllocatedMail_For_TeamHead(objEntityLead);
            return dtList;
        }

        //This method is for listing unread mails list allocated for team lead from dashboard 
        public DataTable Read_MailList_For_TeamHead(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtReadMailList = objDataLayerDashboard.Read_MailList_For_TeamHead(objEntityLead);
            return dtReadMailList;
        }

        public DataTable Read_Asn_Cnfrm_Count(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCountList = objDataLayerDashboard.Read_Asn_Cnfrm_Count(objEntityLead);
            return dtCountList;
        }
        //THIS METHORD IS FOR READING  DATA FOR SALES EXEC DASHBOARD
        public DataTable Read_Amt_Sales_Executive(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtAmt = objDataLayerDashboard.Read_Amt_Sales_Executive(objEntityLead);
            return dtAmt;
        }
        //THIS METHORD IS FOR READING DATA FOR SALES EXEC DASHBOARD
        public DataTable Read_Count_Sales_Executive(clsEntityLeadCreation objEntityLead)
        {

            DataTable dtCount = objDataLayerDashboard.Read_Count_Sales_Executive(objEntityLead);
            return dtCount;
        }
        //THIS METHORD IS FOR READING Leads_Count_ById FOR SALES EXEC DASHBOARD Graph
        public DataTable Read_Leads_Count_ById_Monthly(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Leads_Count_ById_Monthly(objEntityLead);
            return dtCount;
        }
        //THIS METHORD IS FOR READING Read_Leads_Amt_ById_Monthly FOR SALES EXEC DASHBOARD Graph
        public DataTable Read_Leads_Amt_ById_Monthly(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Leads_Amt_ById_Monthly(objEntityLead);
            return dtCount;
        }

        //MONTHLY WON LEADS(DEALS) DIVISION WISE CLIENT LIST
        public DataTable Read_MonthlyWonLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_MonthlyWonLeads_ByDiv(objEntityLead);
            return dtCount;
        }
        // --OPEN LEADS(DEALS) DIVISION WISE PROJECT LIST
        public DataTable Read_MonthlyOpenLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_MonthlyOpenLeads_ByDiv(objEntityLead);
            return dtCount;
        }
        //-- CLOSED LEADS(DEALS) DIVISION WISE PROJECT LIST
        public DataTable Read_MonthlyClosedLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_MonthlyClosedLeads_ByDiv(objEntityLead);
            return dtCount;
        }
        //--LEADS LOSS MONTH WISE
        public DataTable Read_MonthlyLostLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_MonthlyLostLeads_ByDiv(objEntityLead);

            return dtCount;
        }
        //--TOP AGED LEAD
        public DataTable Read_TopAgedLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_TopAgedLeads_ByDiv(objEntityLead);

            return dtCount;
        }

        //--TOTAL WON LEAD MONTHLY BY DIV for Bar diagram
        public DataTable Read_TotalWonLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_TotalWonLeads_ByDiv(objEntityLead);
            return dtCount;
        }
        //--TOTAL WON LEAD MONTHLY BY DIV  for Bar diagram
        public DataTable Read_TotalLeads_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_TotalLeads_ByDiv(objEntityLead);
            return dtCount;
        }
        //--Product cat by div
        public DataTable Read_Product_Cat_ByDiv(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Product_Cat_ByDiv(objEntityLead);
            return dtCount;
        }
        //AWMS DASHBOARD
        public DataTable Read_Vehicle_Details(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Vehicle_Details(objEntityLead);

            return dtCount;
        }
        public DataTable Read_Vehicle_InService(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Vehicle_InService(objEntityLead);

            return dtCount;
        }
        public DataTable Read_Vehicle_ByYear(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Vehicle_ByYear(objEntityLead);

            return dtCount;
        }
        public DataTable Read_Vehicle_ByType(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Vehicle_ByType(objEntityLead);
            return dtCount;
        }
        public DataTable Read_Water_Card(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_Water_Card(objEntityLead);
            return dtCount;
        }
        public DataTable Read_DriverAvailChart(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.Read_DriverAvailChart(objEntityLead);
            return dtCount;
        }
        //READ SETTLED VIOLATION
        public DataTable ReadSetteledViolationMonthly(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadSetteledViolationMonthly(objEntityLead);
            return dtCount;
        }


        //READ PENDING VIOLATION
        public DataTable ReadPendingViolationMonthly(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadPendingViolationMonthly(objEntityLead);
            return dtCount;
        }
        public DataTable ReadVehicleCountProjectWise(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadVehicleCountProjectWise(objEntityLead);
            return dtCount;
        }
        //READ READ PROJECT_LIST VEHICLE_CLASS 
        public DataTable ReadVehicleProjectList(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadVehicleProjectList(objEntityLead);
            return dtCount;
        }

        //READ READ PERMIT_COUNT 
        public DataTable ReadPermitCount(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadPermitCount(objEntityLead);
            return dtCount;
        }
        //READ READ INSUR_COUNT 
        public DataTable ReadInsurCount(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadInsurCount(objEntityLead);
            return dtCount;
        }


        //Employee details to bind with the bar diagram
        public DataTable ReadDivisions(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadDivisions(objEntityLead);
            return dtCount;
        }
        //Employee details to bind with the bar diagram
        public DataTable ReadEmployeesForBarDia(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmployeesForBarDia(objEntityLead);
            return dtCount;
        }  //Employee details to bind with the bar diagram
        public DataTable ReadEmployesAllocated(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmployesAllocated(objEntityLead);
            return dtCount;
        }
         //Employee details to bind with the bar diagram
        public DataTable ReadEmployesOnLeave(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmployesOnLeave(objEntityLead);
            return dtCount;
        }

        //Employee details list of  birthday
        public DataTable ReadPendingCounts(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadPendingCounts(objEntityDash);
            return dtCount;
        }

        //READ ACCOMODATION DETAILS
        public DataTable ReadAccodetails(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadAccodetails(objEntityDash);
            return dtCount;
        }
          //READ flight applied list
        public DataTable ReadFlyTodayList(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadFlyTodayList(objEntityDash);
            return dtCount;
        }
         //READ flight applied list
        public DataTable ReadFlightAppliedList(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadFlightAppliedList(objEntityDash);
            return dtCount;
        }
          //READ flight applied list
        public DataTable ReadFlightBuyList(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadFlightBuyList(objEntityDash);
            return dtCount;
        }

         //READ flight applied list
        public DataTable ReadFlightAmountList(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadFlightAmountList(objEntityDash);
            return dtCount;
        }
        //READ flight applied list
        public DataTable ReadEmpArrive(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmpArrive(objEntityDash);
            return dtCount;
        }

        //READ flight applied list
        public DataTable ReadEmpADepart(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmpADepart(objEntityDash);
            return dtCount;
        }

       //READ list of empoyee birthday
        public DataTable ReadEmpBirthdayList(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadEmpBirthdayList(objEntityDash);
            return dtCount;
        }
         //READ NEXT LEAVE DAY
        public DataTable ReadNextLeave(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadNextLeave(objEntityDash);
            return dtCount;
        }

        //READ Employee Conduct Count
        public DataTable ReadPendingCountsEmploeeConduct(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadPendingCountsEmploeeConduct(objEntityDash);
            return dtCount;
        }
        public DataTable ReadExpiredEmpPerformance(clsEntityDashBoard objEntityDash)
        {
            DataTable dtCount = objDataLayerDashboard.ReadExpiredEmpPerformance(objEntityDash);
            return dtCount;
        }
    }
}
