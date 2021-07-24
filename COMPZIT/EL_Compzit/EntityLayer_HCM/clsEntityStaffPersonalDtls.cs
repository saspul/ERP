using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
     public class clsEntityStaffPersonalDtls
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intStaffId = 0;
        private int intCandId = 0;
        private string strStaffName = "";
        private string strLocalContactNumber = "";
        private string strTelephoneNumber = "";
        private string strEmail = "";
        private int intCountryId = 0;
        private DateTime dDate;
        private string strCancelReason = "";
        private int intDesigId = 0;
        private int intCrpDivId = 0;


              private string strFirstname = "";
        private string strMiddlename = "";
        private string strLastname = "";

        private string strFileName = "";
        private string strFileNameAct = "";



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

        //methode for storing first name 
        public string Firstname
        {
            get { return strFirstname; }
            set { strFirstname = value; }

        }
        //methode for storing middle name 
        public string Middlename
        {
            get { return strMiddlename; }
            set { strMiddlename = value; }

        }
        //methode for storing last name 
        public string Lastname
        {
            get { return strLastname; }
            set { strLastname = value; }

        }
        public int crprtdivision
        {
            get { return intCrpDivId; }
            set { intCrpDivId = value; }
        }



        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }
     
        }

        public int corpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        
        
        }
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
        
        }
        public int StaffId
        {
            get { return intStaffId; }
            set { intStaffId = value; }
        
        }

        public int CandidadteId
        {
            get { return intCandId; }
            set { intCandId = value; }
        
        }
        public string StaffName
        {
            get { return strStaffName;}
            set { strStaffName = value; }
        }
        public string LocalContact
        {
            get { return strLocalContactNumber; }
            set { strLocalContactNumber = value; }
        
        }
        public string TelaephoneNmbr
        {
            get { return strTelephoneNumber; }
            set { strTelephoneNumber = value; }
        
        }
        public string emailid
        {
            get { return strEmail; }
            set { strEmail = value; }
        
        
        
        }
        public int country
        {

            get { return intCountryId; }
            set { intCountryId = value; }
        
        
        }

        public DateTime Date
        {
            get { return dDate; }
            set { dDate = value; }
        }

        public string CancelReason
        {
            get { return strCancelReason; }
            set { strCancelReason = value; }
        }
        public int designationId
        {
            get { return intDesigId; }
            set { intDesigId = value; }
        }
    }   





}
