using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
   public class clsEntityLayer_Tax_CollectedAt_Source
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private string strCancelReason = null;
        private string strName = null;
        private decimal decPercentage = 0;
        private int intResident_sts = 0;
        private int intTaxDeducted = 0;
        private int intcnclStatus = 0;
        private int intcncl_sts = 0;
        private int intTcsId = 0;
        //methode storing no of floor in the accomodedation

       
               //methode of cancel status
        public int cncl_sts
        {
            get
            {
                return intcncl_sts;
            }
            set
            {
                intcncl_sts = value;
            }
        }


        public int TcsId
        {
            get
            {
                return intTcsId;
            }
            set
            {
                intTcsId = value;
            }
        }
    
        public int cnclStatus
        {
            get
            {
                return intcnclStatus;
            }
            set
            {
                intcnclStatus = value;
            }
        }

        //methode of tax id storing
        public int TaxId
        {
            get
            {
                return intTaxDeducted;
            }
            set
            {
                intTaxDeducted = value;
            }
        }
        //methode of organisation id storing
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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

        //methode of user id storing
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
        //methode of status id storing
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

        public int Resident_sts
        {
            get
            {
                return intResident_sts;
            }
            set
            {
                intResident_sts = value;
            }
        }
        //methode of provider type date storing
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }

        //methode of provider name storing
        public string CancelReason
        {
            get
            {
                return strCancelReason;
            }
            set
            {
                strCancelReason = value;
            }
        }
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        public decimal Percentage
        {
            get
            {
                return decPercentage;
            }
            set
            {
                decPercentage = value;
            }
        }
       
    }
}
