using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityTrafficViolationSettlement
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intVehicleId = 0;
        private int intStlUserId = 0;
        private string strReceiptNo = null;
        private decimal decReceiptAmt = 0;
        private DateTime dateFromDate=DateTime.MinValue ;
        private DateTime dateToDate = DateTime.MinValue;
        private int intStlStatus = 0;
        private DateTime dateDate = DateTime.MinValue;
        private string strCancelReason = "";
        private int intCancelStatus = 0;
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
        public DateTime Date
        {
            get
            {
                return dateDate;
            }
            set
            {
                dateDate = value;
            }
        }
        public int StlStatus
        {
            get
            {
                return intStlStatus;
            }
            set
            {
                intStlStatus = value;
            }
        }
        
        public DateTime ToDate
        {
            get
            {
                return dateToDate;
            }
            set
            {
                dateToDate = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dateFromDate;
            }
            set
            {
                dateFromDate = value;
            }
        }
        //method of storing ReceiptAmt
        public decimal ReceiptAmt
        {
            get
            {
                return decReceiptAmt;
            }
            set
            {
                decReceiptAmt = value;
            }
        }
        //method of storing ReceiptNo
        public string ReceiptNo
        {
            get
            {
                return strReceiptNo;
            }
            set
            {
                strReceiptNo = value;
            }
        }
        //method of storing StlUserId
        public int StlUserId
        {
            get
            {
                return intStlUserId;
            }
            set
            {
                intStlUserId = value;
            }
        }
        //method of storing VehicleId
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
        //method of storing Oragnisation_Id
        public int Org_Id
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
        //method of storing Corporate_Id
        public int CorporateId
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
        //methode of storing User_Id
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
    }
    public class clsEntityLayerSettleList
    {
        /*private int intVehicleId = 0;
        private int intSettledStatus = 0;
        private decimal decSettledAmnt = 0;
        private DateTime dateSettled;
        */
       //private int intCancelSts = 0;
        

        private int intTrfcVioltnDtl_ID = 0;
        private int intTrfcVioltn_ID = 0;
        private decimal decimalSettleAmount = 0;
        private int intStldStatus;
        private DateTime dSetldDate;
        //method of storing ReceiptAmt

        public DateTime SetldDate
        {
            get
            {
                return dSetldDate;
            }
            set
            {
                dSetldDate = value;
            }
        }
        public int StldStatus
        {
            get
            {
                return intStldStatus;
            }
            set
            {
                intStldStatus = value;
            }
        }
        public int TrfcVioltnDtl_ID
        {
            get
            {
                return intTrfcVioltnDtl_ID;
            }
            set
            {
                intTrfcVioltnDtl_ID = value;
            }
        }
        public int TrfcVioltn_ID
        {
            get
            {
                return intTrfcVioltn_ID;
            }
            set
            {
                intTrfcVioltn_ID = value;
            }
        }
        public decimal SettleAmount
        {
            get
            {
                return decimalSettleAmount;
            }
            set
            {
                decimalSettleAmount = value;
            }
        }

    }
}
