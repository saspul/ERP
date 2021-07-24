using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerVisaProfession
    {

        private string strVisaName = null;
        private int intStatus = 0;
        private int intUserInsId = 0;
        private int intUserUpId = 0;
        private int intUserCnclId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private DateTime insDate;
        private DateTime upDate;
        private DateTime cnclDate;
        private int intVisaId = 0;
        private string strCancel_reason = "";
        private int intCancel_Status = 0;
        //Methode for storing Visa Name.
        public string VisaName
        {
            get
            {
                return strVisaName;
            }
            set
            {
                strVisaName = value;
            }
        }
        //Methode for storing status.
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
        //Methode for storing id of inserting user.
        public int UserInsId
        {
            get
            {
                return intUserInsId;
            }
            set
            {
                intUserInsId = value;
            }
        }
        //Methode for storing id of updating user.
        public int UserUpId
        {
            get
            {
                return intUserUpId;
            }
            set
            {
                intUserUpId = value;
            }
        }
        //Methode for storing id of canceling user.
        public int UserCnclId
        {
            get
            {
                return intUserCnclId;
            }
            set
            {
                intUserCnclId = value;
            }
        }
        //Methode for storing id of Corporate.
        public int CorpId
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
        //Methode for storing id of organisation.
        public int OrgId
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
        //Method of keeping date of insertion .
        public DateTime InsDate
        {
            get
            {
                return insDate;
            }
            set
            {
                insDate = value;
            }
        }
        //Method of keeping date of updation.
        public DateTime UpDate
        {
            get
            {
                return upDate;
            }
            set
            {
                upDate = value;
            }
        }
        //Method of keeping date of cancel.
        public DateTime CnclDate
        {
            get
            {
                return cnclDate;
            }
            set
            {
                cnclDate = value;
            }
        }
        //Methode for storing Visa id.
        public int VisaId
        {
            get
            {
                return intVisaId;
            }
            set
            {
                intVisaId = value;
            }
        }
        //Methode for storing Cancel Reason.
        public string Cancel_Reason
        {
            get
            {
                return strCancel_reason;
            }
            set
            {
                strCancel_reason = value;
            }
        }
        //Methode for storing Cancel Status.
        public int Cancel_Status
        {
            get
            {
                return intCancel_Status;
            }
            set
            {
                intCancel_Status = value;
            }
        }
    }
}
