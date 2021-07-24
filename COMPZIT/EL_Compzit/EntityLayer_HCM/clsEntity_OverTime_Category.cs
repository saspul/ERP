using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_OverTime_Category
    {
        private int intOvrtmCatgrMasterId = 0;
        private string strOvrtmCatgName = "";
        private double intOvrtmRate = 0;
        private int intStatus = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strSearchField = null;
        private int intCancelStatus = 0;

        
        //methode of overtime category master id storing
        public int OvrtmCatgrMasterId
        {
            get
            {
                return intOvrtmCatgrMasterId;
            }
            set
            {
                intOvrtmCatgrMasterId = value;
            }
        }

        //methode of overtime category name storing
        public string OvrtmCategoryName
        {
            get
            {
                return strOvrtmCatgName;
            }
            set
            {
                strOvrtmCatgName = value;
            }
        }

        public double OvrtmCategoryRate
        {
            get
            {
                return intOvrtmRate;
            }
            set
            {
                intOvrtmRate = value;
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

        //methode of Organisation id storing
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

        //methode of date storing
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

        //methode of Cancel reason storing
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
        //methode of Cancel Status storing
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

        //methode of provider name storing
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
    }
    public class clsEntity_OverTIme_Category_List
    {

        private int intOvrtmCatgrDtlsId = 0;
        private int intPayGradeId = 0;

        //methode of overtime category details id storing
        public int OvrtmCategoryDtlsId
        {
            get
            {
                return intOvrtmCatgrDtlsId;
            }
            set
            {
                intOvrtmCatgrDtlsId = value;
            }
        }

        //methode of overtime Pay Grade id storing
        public int PayGradeId
        {
            get
            {
                return intPayGradeId;
            }
            set
            {
                intPayGradeId = value;
            }
        }

    }
}
