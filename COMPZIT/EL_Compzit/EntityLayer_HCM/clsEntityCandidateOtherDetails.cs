using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityCandidateOtherDetails
    {
        private int intUsrRegistrationId = 0;
        private int candid = 0;
        private string strName1 = "";
        private string strName2 = "";
        private string strAddress1 = "";
        private string strAddress2 = "";
        private string strOccupation1 = "";
        private string strOccupation2 = "";
        private string strPhonenumber = "";
        private string strPhonenumber2 = "";
        private int intreportstats = 0;
        private int intsecurstats = 0;
        private DateTime dateJoining;
        private int intBldgrpId = 0;
        private DateTime dob;
        private int insuserid = 0;
        private DateTime insuserdate;
        private string strUserMobile = "";
        private int intuserid = 0;
        private string spocu = "";
        private string strImigDocName = "";
        private int intUserCrprtId = 0;
        private int intUserOrgId = 0;
        private int intillnessstats = 0;
        private string strillnessstats = "";
        private int intStaffother_Id = 0;
        private int intprevsworkstats = 0;
        private string strprevsworkstats = "";
  
        private int intrelatnstats = 0;
        private string strrelatnstats = "";
        private int intaplybfrstats = 0;
        private string straplybfrdtls = "";
        private string strdoc = "";

      
        public int UsrRegistrationId
        {
            get
            {
                return intUsrRegistrationId;
            }
            set
            {
                intUsrRegistrationId = value;
            }
        }

        
        
        public int UserID
        {
            get
            {
                return intuserid;
            }
            set
            {
                intuserid = value;
            }
        }
        public int CandId
        {
            get
            {
                return candid;
            }
            set
            {
                candid = value;
            }
        }

        // This is the property definition for storing name of User.
        public string Name1
        {
            get
            {
                return strName1;
            }
            set
            {
                strName1 = value;
            }
        }
        public string Name2
        {
            get
            {
                return strName2;
            }
            set
            {
                strName2 = value;
            }
        }
        // This is the property definition for storing Id of Designation assigned to User .
        public int BloodGroupId
        {
            get
            {
                return intBldgrpId;
            }
            set
            {
                intBldgrpId = value;
            }
        }
        //013
        // This is the property definition for storing Id of Job Role assigned to User .
        public int ReportStatus
        {
            get
            {
                return intreportstats;
            }
            set
            {
                intreportstats = value;
            }
        }
        // This is the property definition for storing Date of Joining .
        public DateTime JoiningDate
        {
            get
            {
                return dateJoining;
            }
            set
            {
                dateJoining = value;
            }
        }
        public DateTime Dob
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }
        //methode of first name storing
        public string Address1
        {
            get
            {
                return strAddress1;
            }
            set
            {
                strAddress1 = value;
            }
        }
        //methode of middle name storing
        public string Address2
        {
            get
            {
                return strAddress2;
            }
            set
            {
                strAddress2 = value;
            }
        }
        //methode of last name storing
        public string Occupation1
        {
            get
            {
                return strOccupation1;
            }
            set
            {
                strOccupation1 = value;
            }
        }
        public string Occupation2
        {
            get
            {
                return strOccupation2;
            }
            set
            {
                strOccupation2 = value;
            }
        }
        //methode of country id storing
        public string Phonenumber1
        {
            get
            {
                return strPhonenumber;
            }
            set
            {
                strPhonenumber = value;
            }
        }
        public string Phonenumber2
        {
            get
            {
                return strPhonenumber2;
            }
            set
            {
                strPhonenumber2 = value;
            }
        }
        // This is the property definition for storing CORPRT_ID for adding divisions.
        public int CrprtId
        {
            get
            {
                return intUserCrprtId;
            }
            set
            {
                intUserCrprtId = value;
            }
        }
 //This is the property definition for storing Organisation Id of the User .
        public int UserOrgId
        {
            get
            {
                return intUserOrgId;
            }
            set
            {
                intUserOrgId = value;
            }
        }
        public int illnesstatus
        {
            get
            {
                return intillnessstats;
            }
            set
            {
                intillnessstats = value;
            }
        }
        public int preemploymentsts 
        {
            get
            {
                return intprevsworkstats;
            }
            set
            {
                intprevsworkstats = value;
            }
        }
        public int Relationstats
        {
            get
            {
                return intrelatnstats;
            }
            set
            {
                intrelatnstats = value;
            }
        }
        public string Relationdetails
        {
            get
            {
                return strrelatnstats;
            }
            set
            {
                strrelatnstats = value;
            }
        }
        public string PreviousAppdetails
        {
            get
            {
                return strprevsworkstats;
            }
            set
            {
                strprevsworkstats = value;
            }
        }
        public string IllnesDetails
        {
            get
            {
                return strillnessstats;
            }
            set
            {
                strillnessstats = value;
            }
        }
        public int AppliedBfrSts
        {
            get
            {
                return intaplybfrstats;
            }
            set
            {
                intaplybfrstats = value;
            }
        }
        public string AppliedBfrDtls
        {
            get
            {
                return straplybfrdtls;
            }
            set
            {
                straplybfrdtls = value;
            }
        }
        public int InsUserId
        {
            get
            {
                return insuserid;
            }
            set
            {
                insuserid = value;
            }
        }
        public DateTime InsUserDate
        {
            get
            {
                return insuserdate;
            }
            set
            {
                insuserdate = value;
            }
        }
        public string SpOcu
        {
            get
            {
                return spocu;           
            }
            set
            {
                spocu = value;
            }
        }
        public string Document
        {
            get
            {
                return strdoc;
            }
            set
            {
                strdoc = value;
            }
        }
        public int SecurSts
        {
            get
            {
                return intsecurstats;
            }
            set
            {
                intsecurstats = value;
            }
        }

        public string ImigDocName
        {
            get
            {
                return strImigDocName;
            }
            set
            {
                strImigDocName = value;
            }
        }

        public int Staffother_Id
        {
            get
            {
                return intStaffother_Id;
            }
            set
            {
                intStaffother_Id = value;
            }
        }
    }


   public class clsEntityStaffOtherSub
   {
       private string strOtherDocuFileName;
       private string strOtherDocuActualName;
       private int intWorkerDetailID;

       public int WorkerDetailID
       {
           get { return intWorkerDetailID; }
           set { intWorkerDetailID = value; }
       }

       public string OtherDocuActualName
       {
           get { return strOtherDocuActualName; }
           set { strOtherDocuActualName = value; }
       }

       public string OtherDocuFileName
       {
           get { return strOtherDocuFileName; }
           set { strOtherDocuFileName = value; }
       }

   } 

}
