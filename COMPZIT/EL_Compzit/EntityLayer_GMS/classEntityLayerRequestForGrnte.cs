using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_GMS
{
    public class classEntityLayerRequestForGrnte
    {
        private int intNextIdForRqst = 0;
        private int intReqForGuarId = 0;
        private int intGuarTypeId = 0;
        private int intGuarCatId = 0;
        private int intProjectId = 0;
        private int intCustomerId = 0;
        private int intJobCat_Id = 0;
        private Int64 intValidity = 0;
        private int intCurrencyId = 0;
        private int intEmployeId = 0;
        private decimal decAmount = 0;

        private string strRemarks = "";
        private string strContactName = "";
        private string strContactMail = "";
        private string strInFavrOf = "";
        private DateTime dateProjCloseDate;
        private string strRefNumber = "";
        //EVM0016
        private int intNextId = 0;
        private string strFileName = "";
        private string strFileNameAct = "";
        //EVM0016
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;
        public int intConfirmStatus=0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";
        private string strCntrctname = "";

        //Method for storing the date when the event occurs.
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
        //Method for storing the date when the event occurs.
        public int ReqForGuarId
        {
            get
            {
                return intReqForGuarId;
            }
            set
            {
                intReqForGuarId = value;
            }
        }
        //Method for storing the date when the event occurs.
        public DateTime ProjCloseDate
        {
            get
            {
                return dateProjCloseDate;
            }
            set
            {
                dateProjCloseDate = value;
            }
        }
        //Method for storing in favour of 
        public string InFavrOf
        {
            get
            {
                return strInFavrOf;
            }
            set
            {
                strInFavrOf = value;
            }
        }
        //Method for storing contact mail
        public string ContactMail
        {
            get
            {
                return strContactMail;
            }
            set
            {
                strContactMail = value;
            }
        }
        //Method for storing contact name
        public string ContactName
        {
            get
            {
                return strContactName;
            }
            set
            {
                strContactName = value;
            }
        }
        //Method for storing remarks
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
        //Method for storing amount
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
        //Method for storing currency id
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
        //Method for storing currency id
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }
        //Method for storing validity
        public Int64 Validity
        {
            get
            {
                return intValidity;
            }
            set
            {
                intValidity = value;
            }
        }
        //Method for job category id
        public int JobCat_Id
        {
            get
            {
                return intJobCat_Id;
            }
            set
            {
                intJobCat_Id = value;
            }
        }
       
        //Method for storing customer id
        public int CustomerId
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
        //Method for storing Guarantee category id
        public int GuarCatId
        {
            get
            {
                return intGuarCatId;
            }
            set
            {
                intGuarCatId = value;
            }
        }
        //Method for storing Guarantee type id
        public int GuarTypeId
        {
            get
            {
                return intGuarTypeId;
            }
            set
            {
                intGuarTypeId = value;
            }
        }
       
        //Method for storing project id
        public int ProjectId
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
       
       
        //Method for storing reference number
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
        //Method for storing Complaint master id.
        public string Cntrctname
        {
            get
            {
                return strCntrctname;
            }
            set
            {
                strCntrctname = value;
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
        //Method of storing the Status of the Complaint
        public int Guarantee_Status
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
        //EVM-0016
        //methode of file name storing
        public string FileNameAct
        {
            get
            {
                return strFileNameAct;
            }
            set
            {
                strFileNameAct = value;
            }
        }
        //methode of file name storing
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        //methode of RFG master id storing
        public int NextId
        {
            get
            {
                return intNextId;
            }
            set
            {
                intNextId = value;
            }
        }
        //EVM-0016
    }
}
