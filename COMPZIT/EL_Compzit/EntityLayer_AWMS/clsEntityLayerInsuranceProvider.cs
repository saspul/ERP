using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerInsuranceProvider
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strPrvdrAddress = "";
        private string strPrvdrName = "";
        private int IntPrvdrType = 0;
        private int intInsuranceId = 0;
        private int intCancelStatus = 0;
        private int intInsuranceType = 0;
        private int intNextNumber = 0;

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchType = "";
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
        public string SearchType
        {
            get
            {
                return strSearchType;
            }
            set
            {
                strSearchType = value;
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

       //methode of Next id storing
        public int InsuranceType
        {
            get
            {
                return intInsuranceType;
            }
            set
            {
                intInsuranceType = value;
            }
        }
        //methode of Next id storing
        public int NextNumber
        {
            get
            {
                return intNextNumber;
            }
            set
            {
                intNextNumber = value;
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
        public int Status_id
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
        //methode of provider type id storing
        public int Provider_Type
        {
            get
            {
                return IntPrvdrType;
            }
            set
            {
                IntPrvdrType = value;
            }
        }
        //methode of provider name storing
        public string Provider_Name
        {
            get
            {
                return strPrvdrName;
            }
            set
            {
                strPrvdrName = value;
            }
        }
        //methode of provider name storing
        public string Provider_Address
        {
            get
            {
                return strPrvdrAddress;
            }
            set
            {
                strPrvdrAddress = value;
            }
        }
       //methode of provider type id storing
        public int InsuranceId
        {
            get
            {
                return intInsuranceId;
            }
            set
            {
                intInsuranceId = value;
            }
        }
        //methode of provider type id storing
        public DateTime Date
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
       //methode of provider name storing
        public int CancelStatus
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

      
    }
}
