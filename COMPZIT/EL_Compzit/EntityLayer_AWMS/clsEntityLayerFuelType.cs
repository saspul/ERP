using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0008
// CREATED DATE:25/11/2016
// REVIEWED BY:
// REVIEW DATE:
namespace EL_Compzit.EntityLayer_AWMS
{
  public  class clsEntityLayerFuelType
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strClassName = "";
        private int intClassId = 0;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;
        private int intImageId = 0;
        private int intAppModeSection = 0;

        //FUELTYP_ID
/*FUELTYP_NAME
GNIMGSCT_ID
FUELTYP_STATUS
ORG_ID
CORPRT_ID
FUELTYP_INS_USR_ID
FUELTYP_INS_DATE
FUELTYP_UPD_USR_ID
FUELTYP_UPD_DATE
FUELTYP_CNCL_USR_ID
FUELTYP_CNCL_DATE
FUELTYP_CNCL_REASN*/

        //----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
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


 //methode of App mode section id storing
        public int AppModeSection
        {
            get
            {
                return intAppModeSection;
            }
            set
            {
                intAppModeSection = value;
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
        //methode of vehicle class name storing
        public string ClassName
        {
            get
            {
                return strClassName;
            }
            set
            {
                strClassName = value;
            }
        }

        //methode of vehicle class id storing
        public int FuelId
        {
            get
            {
                return intClassId;
            }
            set
            {
                intClassId = value;
            }
        }
        //methode of storing date of the entry
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

        //methode of cancel reason storing storing
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
        //methode of storing cancel status
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
        //methode of storing cancel status
        public int ImageId
        {
            get
            {
                return intImageId;
            }
            set
            {
                intImageId = value;
            }
        }
        //methode of vehicle class name storing
        public string SearchField
        {
            get
            {
                return strSearchField;
            }
            set
            {
                strSearchField = value;
            }
        }
        //methode of vehicle class name storing
        public string DataBase_Field
        {
            get
            {
                return strDataBaseField;
            }
            set
            {
                strDataBaseField = value;
            }
        }
    }
}
