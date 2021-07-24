using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{

    public class clsEntityCancel
    {
        public enum Cancel_Table
        {
            Country_Master = 1,
            State_Master = 2,
            City_Master = 3,
            Corp_Office = 4,
            Corp_Department = 5,
            Premise = 6,
            Work_Area = 7,
            Org_Type=8,
            Designation = 9,
            Corp_Division=10,
            WorkStation=11,
            Product_Category = 12,
            UOM_Master = 13,
            Tax_Mater=14,
            Product_Group =15,
            Product_Brand =16,
            Product_Master=17,
            Customer_Group=18,
            Customer_Master=19,
            TeamHierarchy=20,
            Project=21,
            Temp_Template=22,
            Lead_Rate_Master = 23,
            Insurance_Provider = 24,
            Accommodation_Master=25,
            Vehicle_Class=26,
            User_Mstr = 27,
            Bank_master = 28,
            Job_Master = 29,        
            Vehicle_Master = 30,
            Complaint_Mstr=31,
            License_Type = 32,
            Water_Card = 33,
            Fuel_Type = 34,
            Vehicle_Status_Master = 35,
            Timslot_Master=36,
            Accommodation_Type_Master = 37,
            Holiday_Master = 38,
            Leave_Type_Master = 39,
            Contract_Category = 40,
            Job_Category = 41,
            Guarantee_Category = 42,
            Contract_Master = 43,
            Leave_Allocation=44,
            Coverage_Type = 45, 
            Bank_Guarantee = 46,
            Job_Role = 47,
            Consultancy_Master = 48,
            Payroll_Structure = 50,
            Employee_Deductn = 52,
            Employee_Allwce = 53,
            Visa_Type=54,
            Interview_Template = 55,
            Certificate_Bundle_Template = 56,
            Employee_Sponser=58,
            Performance_Template = 59,
            Cost_Group = 60,
            Insurance_Type_Master = 61,
            Overtime_Category_Master = 62,
        }
        private Int64 intId = 0;
        private int intCanceltable = 0;
        //Method of storing id
        public Int64 Id
        {
            get
            {
                return intId;
            }
            set
            {
                intId = value;
            }
        }
        //Method of storing table id
        public int Cancel_Table_Id
        {
            get
            {
                return intCanceltable;
            }
            set
            {
                intCanceltable = value;
            }
        }
    }
}
