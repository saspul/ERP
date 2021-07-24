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
   public class clsEntityLayerWaterCardMaster
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

        private string strCardNumber = "";
        private DateTime dateCardExpiry;
        private int intBankId = 0;
        private decimal intOpeningAmount = 0;
        private decimal intBalanceAmount = 0;
        private int intVehNumber = 0;
        private decimal intAlertAmount = 0;
        private string strCardName = "";
        private DateTime CardIsuuedDate;
        private int intWaterCardMasterId = 0;


        //methode of watercard master id storing
        public int WaterCardMasterId
        {
            get
            {
                return intWaterCardMasterId;
            }
            set
            {
                intWaterCardMasterId = value;
            }
        }
        //methode of card issue date storing
        public DateTime CardIsuedDate
        {
            get
            {
                return CardIsuuedDate;
            }
            set
            {
                CardIsuuedDate = value;
            }
        }
        //methode of card name storing
        public string CardName
        {
            get
            {
                return strCardName;
            }
            set
            {
                strCardName = value;
            }
        }
        //methode of alert amount storing
        public decimal AlertAmount
        {
            get
            {
                return intAlertAmount;
            }
            set
            {
                intAlertAmount = value;
            }
        }
        //methode of vehicle number storing
        public int VehNumber
        {
            get
            {
                return intVehNumber;
            }
            set
            {
                intVehNumber = value;
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
        //methode of opening amount storing
        public decimal OpeningAmount
        {
            get
            {
                return intOpeningAmount;
            }
            set
            {
                intOpeningAmount = value;
            }
        }
        //methode of bank id storing
        public int BankId
        {
            get
            {
                return intBankId;
            }
            set
            {
                intBankId = value;
            }
        }
        //methode of Card expiry date storing
        public DateTime CardExpiry
        {
            get
            {
                return dateCardExpiry;
            }
            set
            {
                dateCardExpiry = value;
            }
        }
        //methode of Card Number storing
        public string CardNumber
        {
            get
            {
                return strCardNumber;
            }
            set
            {
                strCardNumber = value;
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
