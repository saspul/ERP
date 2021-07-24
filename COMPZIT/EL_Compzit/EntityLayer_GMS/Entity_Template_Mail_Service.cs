using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL_Compzit.EntityLayer_GMS
{
   public class Entity_Template_Mail_Service
    {
        private int intReqstGrntId = 0;
        private int intGuaranteeId = 0;
        private int intContactUser = 0;
        private int intguarantNoDays = 0;
        private string intgurntNo = "";
        private int intTempAlertId = 0;
        private int intGuarntMod = 0;
        private int intEmployeId = 0;
        private int intNextIdForRqst = 0;
        private int intbankid = 0;
        private int intOwnerEmply = 0;
        private int intsubcontract = 0;
        private int intcurrency = 0;
        private int intcustomer = 0;
        private int intcontrctr = 0;
        private int intprojectId = 0;
        private int intguarcatgryId = 0;
        private int intBiding = 0;
        private int intAarded = 0;
        private int intCusSuply = 0;
        private int intStatusGurnt = 0;
        private int intStatusSrch = 0;

        private decimal decAmount = 0;
        private DateTime dateopenDate;
        private DateTime dateExpireDate;
        private DateTime datetoDate;

        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;

        public int intConfirmStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";
        private string strCntrctname = "";
        private string strRefNumber = "";
        private string straddress = "";
        private string strsubject = "";
        private string strDescrption = "";
        private string stremail = "";
        private string stremplyNme = "";
        private string strRemarks = "";
        private string strToMailId = "";
        private string strFromMailId = "";
        private string strRefNum = "";
        private string strMailSubject = "";
        private string strCcMailId = "";
        private string strBccMailId = "";
        private string strMailMOdule = "";
        private int intInsuranceID=0;

        public int InsuranceID
        {
            get { return intInsuranceID; }
            set { intInsuranceID = value; }
        }


        //method  for storing to mail id
        public string MailMOdule
        {
            get
            {
                return strMailMOdule;
            }
            set
            {
                strMailMOdule = value;
            }
        }
        //method  for storing to mail id
        public string ToMailId
        {
            get
            {
                return strToMailId;
            }
            set
            {
                strToMailId = value;
            }
        }
        //method  for storing from mail id
        public string FromMailId
        {
            get
            {
                return strFromMailId;
            }
            set
            {
                strFromMailId = value;
            }
        }
        //method  for storing mail ref number
        public string RefNum
        {
            get
            {
                return strRefNum;
            }
            set
            {
                strRefNum = value;
            }
        }
        //method  for storing mail subject
        public string MailSubject
        {
            get
            {
                return strMailSubject;
            }
            set
            {
                strMailSubject = value;
            }
        }

        //method  for storing CC mail id
        public string CcMailId
        {
            get
            {
                return strCcMailId;
            }
            set
            {
                strCcMailId = value;
            }
        }
       //method  for storing BCC mail id
        public string BccMailId
        {
            get
            {
                return strBccMailId;
            }
            set
            {
                strBccMailId = value;
            }
        }
        //Method of storing the Status of the Complaint 
        public int ReqstGrntId
        {
            get
            {
                return intReqstGrntId;
            }
            set
            {
                intReqstGrntId = value;
            }
        }
        public string Remarks
        {
            get
            {
                return strRemarks;
            }
            set
            {
                strRemarks = value;
            }
        }


        public int GuartStsSrch
        {
            get
            {
                return intStatusSrch;
            }
            set
            {
                intStatusSrch = value;
            }
        }

        public int StatusIdCheck
        {
            get
            {
                return intStatusGurnt;
            }
            set
            {
                intStatusGurnt = value;
            }
        }
        public int GuaranteeId
        {
            get
            {
                return intGuaranteeId;
            }
            set
            {
                intGuaranteeId = value;
            }
        }
        public int CusSuply
        {
            get
            {
                return intCusSuply;
            }
            set
            {
                intCusSuply = value;
            }
        }
        public int Awarded
        {
            get
            {
                return intAarded;
            }
            set
            {
                intAarded = value;
            }
        }
        public int Biding
        {
            get
            {
                return intBiding;
            }
            set
            {
                intBiding = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return datetoDate;
            }
            set
            {
                datetoDate = value;
            }
        }
        public int TempAlertId
        {
            get
            {
                return intTempAlertId;
            }
            set
            {
                intTempAlertId = value;
            }
        }
        public int ContactPersnUsrId
        {
            get
            {
                return intContactUser;
            }
            set
            {
                intContactUser = value;
            }
        }
        public int GuaranteeNoDays
        {
            get
            {
                return intguarantNoDays;
            }
            set
            {
                intguarantNoDays = value;
            }
        }
        public string GuaranteeNo
        {
            get
            {
                return intgurntNo;
            }
            set
            {
                intgurntNo = value;
            }
        }
        public string Email
        {
            get
            {
                return stremail;
            }
            set
            {
                stremail = value;
            }
        }
        public int GuarCatgryId
        {
            get
            {
                return intguarcatgryId;
            }
            set
            {
                intguarcatgryId = value;
            }
        }
        public int ProjectId
        {
            get
            {
                return intprojectId;
            }
            set
            {
                intprojectId = value;
            }
        }
        public int Contrctr
        {
            get
            {
                return intcontrctr;
            }
            set
            {
                intcontrctr = value;
            }
        }
        public int Customer
        {
            get
            {
                return intcustomer;
            }
            set
            {
                intcustomer = value;
            }
        }
        public DateTime ExpireDate
        {
            get
            {
                return dateExpireDate;
            }
            set
            {
                dateExpireDate = value;
            }
        }
        public int Currency
        {
            get
            {
                return intcurrency;
            }
            set
            {
                intcurrency = value;
            }
        }
        public int SubContractId
        {
            get
            {
                return intsubcontract;
            }
            set
            {
                intsubcontract = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescrption;
            }
            set
            {
                strDescrption = value;
            }
        }
        public string Subject
        {
            get
            {
                return strsubject;
            }
            set
            {
                strsubject = value;
            }
        }
        public string Address
        {
            get
            {
                return straddress;
            }
            set
            {
                straddress = value;
            }
        }
        public int OwnershipEmply
        {
            get
            {
                return intOwnerEmply;
            }
            set
            {
                intOwnerEmply = value;
            }
        }

        public DateTime OpenDate
        {
            get
            {
                return dateopenDate;
            }
            set
            {
                dateopenDate = value;
            }
        }

        public int BankId
        {
            get
            {
                return intbankid;
            }
            set
            {
                intbankid = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return decAmount;
            }
            set
            {
                decAmount = value;
            }
        }

        public string RefNumber
        {
            get
            {
                return strRefNumber;
            }
            set
            {
                strRefNumber = value;
            }
        }

        public int NextIdForRqst
        {
            get
            {
                return intNextIdForRqst;
            }
            set
            {
                intNextIdForRqst = value;
            }
        }

        public int EmployeId
        {
            get
            {
                return intEmployeId;
       

            }
            set
            {
                intEmployeId = value;
            }
        }
        public int Guarantee_Method
        {
            get
            {
                return intGuarntMod;
            }
            set
            {
                intGuarntMod = value;
            }
        }

        public string EmployeName
        {
            get
            {
                return stremplyNme;
            }
            set
            {
                stremplyNme = value;
            }
        }


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
        //Method of storing the Status of the Complaint
        public int Guarantee_Confirm_Status
        {
            get
            {
                return intConfirmStatus;
            }
            set
            {
                intConfirmStatus = value;
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

        //Method for storing Complaint cancel reason
        public string Cancel_reason
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
    }
}
