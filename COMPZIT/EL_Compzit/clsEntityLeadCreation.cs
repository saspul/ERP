using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityLeadCreation
    {
        private int intRefId;
        private string projectTenderNo;//0013
        private string strProjectRefNum = "";
        private int intLeadsId=0;
        private int intUserId=0;
        private int intLeadSrcId=0;
        private DateTime dtLeadDate;
        private DateTime dDate;
        private string strDescription;
        private string strCustomerName;
        private int intDivisionId;
        private string strTitle;
        private int intTeamId;
        private string strAttachement;
        private string strComments;
        private string strProject="";
        private string strClient="";
        private string strContractor="";
        private string strConsultant="";
        private string strAdd1;
        private string strAdd2;
        private string strAdd3;
        private int intCountryId;
        private int intStateId;
        private int intCityId;
        private string strZipCode;
        private string strTinNo;
        private string strTwitter;
        private string strFacebook;
        private string strGoogle;
        private string strLinkedIn;
        private string strMobile;
        private string strPhone;
        private string strWeb;
        private string strEmail;
        private int intLeadRateId;
        private int intCorpId;
        private int intOrgId;
        private int intPrefixId=0;
        private int intStatus=1;
        private int intMediaId = 0;
        private string strMediaDescription = null;
        private Int64 intMlboxId;
        private int intFinYrId;
        private string strDivCode;
        private int intWorkAreaId;
        private int intLossReasonId=0;
        private int intAllocateUserId = 0;
        private int intActiveUserId = 0;
        private int intOldActiveUserId = 0;
        private int intNewActiveUserId = 0;
        private int intCustomerId = 0;
        private string strFromdate = null;
        private string strToDate = null;
        private int intProjectId = 0;
        private int intClientId = 0;
        private int intContractorId = 0;
        private int intConsultantId = 0;
        private int intMailId = 0;
        private int intQuotation_Id = 0;
        private int intQtnFile_Type = 0;
        private int intMailSendAllwd = 0;

        private string strCcTextboxContent = "";
        private Int64 intPrvsCcMailid = 0;
        private string strBCcTextboxContent = "";
        private Int64 intPrvsBCcMailid = 0;



        private int intProjectStatus=0;

        private int intProjectManagerID = 0;

        private string strInternalRefNum ="";

        private int intLeadStatus = 0;

        private decimal decWinAmount = 0;



        private string strCommonSearchTerm = "";
        private string strSearchDate = "";
        private string strSearchCust = "";
        private string strSearchOwner = "";
        private string strSearchRef = "";
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
        public string SearchDate
        {
            get
            {
                return strSearchDate;
            }
            set
            {
                strSearchDate = value;
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
        public string SearchOwner
        {
            get
            {
                return strSearchOwner;
            }
            set
            {
                strSearchOwner = value;
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


        public decimal WinAmount
        {
            get { return decWinAmount; }
            set { decWinAmount = value; }
        }
        public int LeadStatus
        {
            get { return intLeadStatus; }
            set { intLeadStatus = value; }
        }

        public int ProjectManagerID
        {
            get { return intProjectManagerID; }
            set { intProjectManagerID = value; }
        }
        public string InternalRefNum
        {
            get { return strInternalRefNum; }
            set { strInternalRefNum = value; }
        }

        public int ProjectStatus
        {
            get { return intProjectStatus; }
            set { intProjectStatus = value; }
        }
        

        //methode for store the mail id is allowed to send mail
        public int MailSendAllwd
        {
            get
            {
                return intMailSendAllwd;
            }
            set
            {
                intMailSendAllwd = value;
            }
        }
        //methode for store the mail box id
        public string ProjectRefNum
        {
            get
            {
                return strProjectRefNum;
            }
            set
            {
                strProjectRefNum = value;
            }
        }

        //methode for store the mail box id
        public int Mail_Box_Id
        {
            get
            {
                return intMailId;
            }
            set
            {
                intMailId = value;
            }
        }


        //method for store Project id
        public int Project_Id
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
        //method for store Client id
        public int Client_Id
        {
            get
            {
                return intClientId;
            }
            set
            {
                intClientId = value;
            }
        }
        //method for store Contractor id
        public int Contractor_Id
        {
            get
            {
                return intContractorId;
            }
            set
            {
                intContractorId = value;
            }
        }
        //method for store Consultant id
        public int Consultant_Id
        {
            get
            {
                return intConsultantId;
            }
            set
            {
                intConsultantId = value;
            }
        }

        //methode for store from date
        public string From_Date
        {
            get
            {
                return strFromdate;
            }
            set
            {
                strFromdate = value;
            }

        }

        //methode of storing to date
        public string To_Date
        {
            get
            {
                return strToDate;
            }
            set
            {
                strToDate = value;
            }
        }

        //method for store customer id
        public int Customer_Id
        {
            get
            {
                return intCustomerId;
            }
            set
            {
                intCustomerId = value;
            }
        }
        //Method for storing id of project tender.0013 
        public string Project_Tender_Id
        {
            get
            {
                return projectTenderNo;
            }
            set
            {
                projectTenderNo = value;
            }
        }
        //Method for storing prefix id of customer. 
        public int Ref_Id
        {
            get
            {
                return intRefId;
            }
            set
            {
                intRefId = value;
            }
        }

        public int WorkAreaId
        {
            get
            {
                return intWorkAreaId;
            }
            set
            {
                intWorkAreaId = value;
            }
        }

        public int FinYearId
        {
            get
            {
                return intFinYrId;
            }
            set
            {
                intFinYrId = value;
            }
        }

        public Int64 MailBoxId
        {
            get
            {
                return intMlboxId;
            }
            set
            {
                intMlboxId = value;
            }
        }

        public int NamePrefix_Id
        {
            get
            {
                return intPrefixId;
            }
            set
            {
                intPrefixId = value;
            }
        }

        

        //Method for storing user id who do the event. 
        public int User_Id 
        {
            get 
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }

        //Method for storing Lead id for identifying lead source.
        public int LeadSourceId
        {
            get
            {
                return intLeadSrcId;
            }
            set
            {
                intLeadSrcId = value;
            }
        }

        public int LeadId
        {
            get
            {
                return intLeadsId;
            }
            set
            {
                intLeadsId = value;
            }
        }

        //Method for storing Lead Date.
        public DateTime LeadDate
        {
            get
            {
                return dtLeadDate;
            }
            set
            {
                dtLeadDate = value;
            }
        }
        //methd ins usr dte
        public DateTime InsertDate
        {
            get
            {
                return dDate;
            }
            set
            {
                dDate = value;
            }
        }

        //Method for storing Description among Lead.
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }

        //Method for storing Customer Name.
        public string Customer_Name
        {
            get
            {
                return strCustomerName;
            }
            set
            {
                strCustomerName = value;
            }
        }

        public string DivisionCode
        {
            get
            {
                return strDivCode;
            }
            set
            {
                strDivCode = value;
            }
        }

        //Method for storing Division id for identifying Division.
        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }

        //Method for storing Title .
        public string Title
        {
            get
            {
                return strTitle;
            }
            set
            {
                strTitle = value;
            }
        }

        //Method for storing Team Id for selecting Team .
        public int Team
        {
            get
            {
                return intTeamId;
            }
            set
            {
                intTeamId = value;
            }
        }

        //Method for storing Attachments.
        public string Attachement
        {
            get
            {
                return strAttachement;
            }
            set
            {
                strAttachement = value;
            }
        }

        //Method for storing Comments.
        public string Comments
        {
            get
            {
                return strComments;
            }
            set
            {
                strComments = value;
            }
        }

        //Method for storing project Name.
        public string Project
        {
            get
            {
                return strProject;
            }
            set
            {
                strProject = value;
            }
        }

        //Method for storing Client name. 
        public string Client
        {
            get
            {
                return strClient;
            }
            set
            {
                strClient = value;
            }
        }

        //Method for storing consulting person.
        public string Consultant
        {
            get
            {
                return strConsultant;
            }
            set
            {
                strConsultant = value;
            }
        }

        //Method for storing contractor .
        public string Contractor
        {
            get
            {
                return strContractor;
            }
            set
            {
                strContractor = value;
            }
        }

        //Method for storing Address line 1 of customer.
        public string Address1
        {
            get
            {
                return strAdd1;
            }
            set
            {
                strAdd1 = value;
            }
        }

        //Method for storing Address line 2 of customer.
        public string Address2
        {
            get
            {
                return strAdd2;
            }
            set
            {
                strAdd2 = value;
            }
        }

        //Method for storing Address line 3 of customer.
        public string Address3
        {
            get
            {
                return strAdd3;
            }
            set
            {
                strAdd3 = value;
            }
        }

        //Method for storing Country id.
        public int CountryId
        {
            get 
            {
                return intCountryId;
            }
            set
            {
                intCountryId = value;
            }
        }

        //Method for storing State id.
        public int StateId
        {
            get
            {
                return intStateId;
            }
            set
            {
                intStateId = value;
            }
        }

        //Method for storing City id.
        public int CityId
        {
            get
            {
                return intCityId;
            }
            set
            {
                intCityId = value;
            }
        }

        //Method for storing Zipcode.
        public string ZipCode
        {
            get
            {
                return strZipCode;
            }
            set
            {
                strZipCode = value;
            }
        }

        //Method for storing Tin number.
        public string TinNumber
        {
            get
            {
                return strTinNo;
            }
            set
            {
                strTinNo = value;
            }
        }

        //Method for Mobile number.
        public string Mobile
        {
            get
            {
                return strMobile;
            }
            set
            {
                strMobile = value;
            }
        }

        //Method for storing phone numnber.
        public string  Phone
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        //Method for storing email .
        public string Email
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }

        //Method for storing web address.
        public string Web
        {
            get
            {
                return strWeb;
            }
            set
            {
                strWeb = value;
            }
        }

        //Method for storing lead Rating id.
        public int LeadRating
        {
            get
            {
                return intLeadRateId;
            }
            set
            {
                intLeadRateId = value;
            }
        }

        public int Corp_Id
        {
            get
            {
                return intCorpId;
            }
            set
            { 
                intCorpId = value; 
            }
        }

        public int Org_Id
        {
            get
            {
                return intOrgId;
            }
            set
            {
                intOrgId = value;
            }
        }

        public int Status
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
        //methode of storing media id
        public int Media_Id
        {
            get
            {
                return intMediaId;
            }
            set
            {
                intMediaId = value;
            }
        }
        //methode of storing media description
        public string Media_Description
        {
            get
            {
                return strMediaDescription;
            }
            set
            {
                strMediaDescription = value;
            }
        }
        //property of storing Loss Reason Id
        public int LossReasonId
        {
            get
            {
                return intLossReasonId;
            }
            set
            {
                intLossReasonId = value;
            }
        }
        public int Allocate_UserId
        {
            get
            {
                return intAllocateUserId;
            }
            set
            {
                intAllocateUserId = value;
            }
        }
        public int Active_UserId
        {
            get
            {
                return intActiveUserId;
            }
            set
            {
                intActiveUserId = value;
            }
        }
        public int OldActive_UserId
        {
            get
            {
                return intOldActiveUserId;
            }
            set
            {
                intOldActiveUserId = value;
            }
        }
        public int NewActive_UserId
        {
            get
            {
                return intNewActiveUserId;
            }
            set
            {
                intNewActiveUserId = value;
            }
        }
        //005 start
        public int Quotation_Id
        {
            get
            {
                return intQuotation_Id;
            }
            set
            {
                intQuotation_Id = value;
            }
        }
        public int QtnFile_Type
        {
            get
            {
                return intQtnFile_Type;
            }
            set
            {
                intQtnFile_Type = value;
            }
        }

        public string CcTextboxContent
        {
            get
            {
                return strCcTextboxContent;
            }
            set
            {
                strCcTextboxContent = value;
            }
        }
        public Int64 PrvsCcMailid
        {
            get
            {
                return intPrvsCcMailid;
            }
            set
            {
                intPrvsCcMailid = value;
            }
        }
        public string BCcTextboxContent
        {
            get
            {
                return strBCcTextboxContent;
            }
            set
            {
                strBCcTextboxContent = value;
            }
        }
        public Int64 PrvsBCcMailid
        {
            get
            {
                return intPrvsBCcMailid;
            }
            set
            {
                intPrvsBCcMailid = value;
            }
        }
    }

    public class clsEntityTask
    { 
     private int intTaskId=0;
     private int intUserId =0;
     private DateTime dtDate;
     private int intCorpId=0;
     private int intOrgId = 0;
     private int LeadId = 0;
     private string strDescription = "";
     private int intTaskstatus = 0;
     private int intsubjectId =0;
     private DateTime dtDueDate;
    
    
     private int intActiveUserId = 0;
     private int intClosestatus = 0;
        public int TaskId
        {
            get
            {
                return intTaskId;
            }
            set
            {
                intTaskId = value;
            }
        }

        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }

        public int Corp_Id
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }

        public int Org_Id
        {
            get { return intOrgId; }
            set { intOrgId = value; }
        }

        public int User_Id
        {
            get { return intUserId; }
            set { intUserId = value; }
        }

        public int Lead_Id
        {
            get { return LeadId; }
            set { LeadId = value; }
        }

        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        public int TaskStatus
        {
            get { return intTaskstatus; }
            set { intTaskstatus = value; }
        }

        public DateTime DueDate
        {
            get { return dtDueDate; }
            set { dtDueDate = value; }
        }

        public int TaskSubjectId
        {
            get { return intsubjectId; }
            set { intsubjectId = value; }
        }
        public int CloseStatus
        {
            get { return intClosestatus; }
            set { intClosestatus = value; }
        }
        public int ActiveUserId
        {
            get { return intActiveUserId; }
            set { intActiveUserId = value; }
        }

    }

    public class clsEntityFollowUp
    {
       private int intFollupId=0;
       private int intUserId=0;
       private int intActiveUserId = 0;
       private int intCorpId=0;
       private int intOrgId = 0;
       private int LeadSrceID=0;
       private int LeadId=0;
       private DateTime dFollowUpDate;
       private DateTime dtDate;
       private string strDescription="";

       public int FollupId
       {
           get { return intFollupId; }
           set { intFollupId = value; }
       }
       public int Org_Id
       {
           get
           {
               return intOrgId;
           }
           set
           {
               intOrgId = value;
           }
       }
        public int Corp_Id
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }
        
        public int User_Id
        {
            get { return intUserId; }
            set { intUserId = value; }
        }
        public int ActiveUserId
        {
            get { return intActiveUserId; }
            set { intActiveUserId = value; }
        }
        public int Lead_Id
        {
            get { return LeadId; }
            set { LeadId = value; }
        }

        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        
        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        public DateTime FollowUpDate
        {
            get { return dFollowUpDate; }
            set { dFollowUpDate = value; }
        }

        public int LeadSourceId
        {
            get { return LeadSrceID; }
            set { LeadSrceID = value; }
        }

    }
    
}
    