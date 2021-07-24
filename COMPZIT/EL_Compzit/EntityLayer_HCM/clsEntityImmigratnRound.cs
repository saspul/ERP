using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityImmigratnRound
    {

        private int intUserId = 0;
        private int intImgRndId = 0;
        private string strImgRndName = null;
        private int strImgRndStatus = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private DateTime date;
        private int intCancelStatus = 0;
        private string strCancelReason = null;


        public int UserId
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

        public int ImgratnRound_Id
        {
            get
            {
                return intImgRndId;
            }
            set
            {
                intImgRndId = value;
            }
        }


        public string ImgratnRound_Name
        {
            get
            {
                return strImgRndName;
            }
            set
            {
                strImgRndName = value;
            }
        }


        public int ImgratnRound_Status
        {
            get
            {
                return strImgRndStatus;
            }
            set
            {
                strImgRndStatus = value;
            }
        }


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


        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }


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


    }


    public class clsEntityImmigratnRoundDetails
    {

        private int intImgRndDtlId = 0;
        private string strImgRndDtlName = null;
        private int intImgRndDtlStatus = 0;
        private int intImgRndCmplt = 0;


        public int ImgratnRoundDtl_Id
        {
            get
            {
                return intImgRndDtlId;
            }
            set
            {
                intImgRndDtlId = value;
            }
        }


        public string ImgratnRoundDtl_Name
        {
            get
            {
                return strImgRndDtlName;
            }
            set
            {
                strImgRndDtlName = value;
            }
        }


        public int ImgratnRoundDtl_Status
        {
            get
            {
                return intImgRndDtlStatus;
            }
            set
            {
                intImgRndDtlStatus = value;
            }
        }


        public int ImgratnRoundDtl_Cmplt
        {
            get
            {
                return intImgRndCmplt;
            }
            set
            {
                intImgRndCmplt = value;
            }
        }




    }


}
