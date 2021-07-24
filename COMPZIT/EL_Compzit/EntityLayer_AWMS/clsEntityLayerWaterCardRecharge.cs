using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0005
// CREATED DATE:24/10/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerWaterCardRecharge
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;

        private int intNextId = 0;
        private int intWaterCardRchrgeId = 0;
        private int intCardNumberId = 0;
        private DateTime dateRecharge;
        private decimal decRechargeAmnt = 0;
        private decimal intBalanceAmount = 0;
        private decimal intBalanceBeforeCnfrm = 0;
        private string strFileName = "";
        private string strFileNameAct = "";
        private string strRemark = "";
        private int intVehicleId = 0;


        //methode of storing balance before confirming
        public int VehicleId
        {
            get
            {
                return intVehicleId;
            }
            set
            {
                intVehicleId = value;
            }
        }
        //methode of storing balance before confirming
        public decimal BalanceBeforeCnfrm
        {
            get
            {
                return intBalanceBeforeCnfrm;
            }
            set
            {
                intBalanceBeforeCnfrm = value;
            }
        }
        //methode of watercard master id storing
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
        //methode of watercard master id storing
        public int WaterCardRchrgeId
        {
            get
            {
                return intWaterCardRchrgeId;
            }
            set
            {
                intWaterCardRchrgeId = value;
            }
        }
        //methode of file name storing
        public string Remark
        {
            get
            {
                return strRemark;
            }
            set
            {
                strRemark = value;
            }
        }
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
        //methode of watercard master id storing
        public int CardNumberId
        {
            get
            {
                return intCardNumberId;
            }
            set
            {
                intCardNumberId = value;
            }
        }
        //methode of card issue date storing
        public DateTime RechargeDate
        {
            get
            {
                return dateRecharge;
            }
            set
            {
                dateRecharge = value;
            }
        }

        //methode of alert amount storing
        public decimal RechargeAmnt
        {
            get
            {
                return decRechargeAmnt;
            }
            set
            {
                decRechargeAmnt = value;
            }
        }
      
        //methode of balance amount storing
        public decimal BalanceAmount
        {
            get
            {
                return intBalanceAmount;
            }
            set
            {
                intBalanceAmount = value;
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
        //methode of provider name storing
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
