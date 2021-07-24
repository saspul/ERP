using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:26/05/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Project .
namespace EL_Compzit
{
   public class clsEntityProject
   {
       private string strProjectName = "";
       private string strCancelreason = "";
       private int intOrgid = 0;
       private int intCorpOffice = 0;
       private DateTime ddate;
       private int intUser_Id = 0;
       public int intStatus = 0;
       private int intProjectId = 0;
       private int intUpdateDecide = 0;
       private Int64 intLeadId = 0;
       private int intCancelStatus = 0;

       
       private string strProj_Ref_Num = "";
       private string strContact_Name = "";
       private string strContact_Email = "";
       private string strContact_Phone = "";
       private string strTender_Ref = "";
       private string strClient_Ref = "";
       private string strInter_Ref = "";
       private int strCustomer_Id = 0;
       private int intGuaranteMOde_Id = 0;
       private int intManager_Id = 0;
       private int intCorp_Div_id = 0;
       private int intEmployee_Id = 0;
       private int intWarehousePrimaryId = 0;
       private string strWarehouses = "";


       private string strCommonSearchTerm = "";
       private string strSearchName = "";
       private string strSearchRef = "";
       private string strSearchCust = "";
       private int intOrderColumn = 0;
       private int intOrderMethod = 0;
       private int intPageMaxSize = 0;
       private int intPageNumber = 0;
       public string CommonSearchTerm
       {
           get
           {
               return strCommonSearchTerm;
           }
           set
           {
               strCommonSearchTerm = value;
           }
       }
       public string SearchName
       {
           get
           {
               return strSearchName;
           }
           set
           {
               strSearchName = value;
           }
       }
       public string SearchRef
       {
           get
           {
               return strSearchRef;
           }
           set
           {
               strSearchRef = value;
           }
       }
       public string SearchCust
       {
           get
           {
               return strSearchCust;
           }
           set
           {
               strSearchCust = value;
           }
       }
       public int OrderColumn
       {
           get
           {
               return intOrderColumn;
           }
           set
           {
               intOrderColumn = value;
           }
       }
       public int OrderMethod
       {
           get
           {
               return intOrderMethod;
           }
           set
           {
               intOrderMethod = value;
           }
       }
       public int PageMaxSize
       {
           get
           {
               return intPageMaxSize;
           }
           set
           {
               intPageMaxSize = value;
           }
       }
       public int PageNumber
       {
           get
           {
               return intPageNumber;
           }
           set
           {
               intPageNumber = value;
           }
       }
       //----------------Pageination--------------------


       public string WarehouseIds
       {
           get
           {
               return strWarehouses;
           }
           set
           {
               strWarehouses = value;
           }
       }
       public int WarehousePrimaryId
       {
           get
           {
               return intWarehousePrimaryId;
           }
           set
           {
               intWarehousePrimaryId = value;
           }
       }
       public int Employee_Id
       {
           get
           {
               return intEmployee_Id;
           }
           set
           {
               intEmployee_Id = value;
           }
       }
       //methode of contact name storing
       public string Proj_Ref_Num
       {
           get
           {
               return strProj_Ref_Num;
           }
           set
           {
               strProj_Ref_Num = value;
           }
       }
       //methode of contact name storing
       public string Contact_Name
       {
           get
           {
               return strContact_Name;
           }
           set
           {
               strContact_Name = value;
           }
       }
       //methode of contact email storing
       public string Contact_Email
       {
           get
           {
               return strContact_Email;
           }
           set
           {
               strContact_Email = value;
           }
       }
       //methode of contact number storing
       public string Contact_Phone
       {
           get
           {
               return strContact_Phone;
           }
           set
           {
               strContact_Phone = value;
           }
       }
       //methode of tender reference number storing
       public string Tender_Ref
       {
           get
           {
               return strTender_Ref;
           }
           set
           {
               strTender_Ref = value;
           }
       }
       //methode of client reference number storing
       public string Client_Ref
       {
           get
           {
               return strClient_Ref;
           }
           set
           {
               strClient_Ref = value;
           }
       }
       //methode of internal reference number storing
       public string Inter_Ref
       {
           get
           {
               return strInter_Ref;
           }
           set
           {
               strInter_Ref = value;
           }
       }
       //methode of customer id storing
       public int Customer_Id
       {
           get
           {
               return strCustomer_Id;
           }
           set
           {
               strCustomer_Id = value;
           }
       }
       //methode of user id storing
       public int User_Id
       {
           get
           {
               return intUser_Id;
           }
           set
           {
               intUser_Id = value;
           }
       }
       //methode of guaranrtee mode id storing
       public int GuaranteMOde_Id
       {
           get
           {
               return intGuaranteMOde_Id;
           }
           set
           {
               intGuaranteMOde_Id = value;
           }
       }
       //methode of manager id storing
       public int Manager_Id
       {
           get
           {
               return intManager_Id;
           }
           set
           {
               intManager_Id = value;
           }
       }
       //methode of corporate division id storing
       public int Corp_Div_id
       {
           get
           {
               return intCorp_Div_id;
           }
           set
           {
               intCorp_Div_id = value;
           }
       }
       //methode of cancel status storing
       public int Cancel_Status
       {
           get
           {
               return intCancelStatus;
           }
           set
           {
               intCancelStatus = value;
           }
       }
       //methode of store lead id
       public Int64 Lead_Id
       {
           get
           {
               return intLeadId;
           }
           set
           {
               intLeadId = value;
           }
       }

       //methode of storing update decide id
       public int Update_Decide
       {
           get
           {
               return intUpdateDecide;
           }
           set
           {
               intUpdateDecide = value;
           }
       }

       //Method for storing Project name
       public string ProjectName
       {
           get
           {
               return strProjectName;
           }
           set
           {
               strProjectName = value;
           }
       }
       //Method for storing Project cancel reason
       public string Project_Cancel_reason
       {
           get
           {
               return strCancelreason;
           }
           set
           {
               strCancelreason = value;
           }
       }
       //Method for storing organistion id.
       public int Organisation_Id
       {
           get
           {
               return intOrgid;
           }
           set
           {
               intOrgid = value;
           }
       }
   
       //Method for storing Project master id.
       public int Project_Master_Id
       {
           get
           {
               return intProjectId;
           }
           set
           {
               intProjectId = value;
           }
       }
       //Method for storing Corporate office id.
       public int CorpOffice_Id
       {
           get
           {
               return intCorpOffice;
           }
           set
           {
               intCorpOffice = value;
           }
       }
     
       //Method for storing the date when the event occurs.
       public DateTime D_Date
       {
           get
           {
               return ddate;
           }
           set
           {
               ddate = value;
           }
       }
       //Method of storing the Status of the project
       public int Project_Status
       {
           get
           {
               return intStatus;
           }
           set
           {
               intStatus = value;
           }
       }
    }
}
