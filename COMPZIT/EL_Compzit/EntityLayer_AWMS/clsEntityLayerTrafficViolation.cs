using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerTrafficViolation
    {

        private int intTrafcVltnId = 0;
        private int intVehicleId = 0;
        private string strReceiptNum = "";
        private decimal decReceiptAmnt = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intStldUserId = 0;
        private DateTime ddate;
        private string strCancelReason = "";
        private int intCnfrmStatus = 0;
        private int intStatus = 0;
        private int intCancelStatus = 0;
        private string strSearchField = "";
        private string strDataBaseField = null;
        private decimal decVioltnAmnt = 0;

        private string strRefNo = "";
        public string RefNo
        {
            get
            {
                return strRefNo;
            }
            set
            {
                strRefNo = value;
            }
        }
        //Property for storing traffic violation id.
        public int TrafficVltnId
        {
            get
            {
                return intTrafcVltnId;
            }
            set
            {
                intTrafcVltnId = value;
            }
        }
        //Property for storing vehicle id.
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
        //storing the ReceiptNumber
        public string ReceiptNumber
        {
            get
            {
                return strReceiptNum;
            }
            set
            {
                strReceiptNum = value;
            }
        }
        //storing the ReceiptAmnt
        public decimal RecptAmnt
        {
            get
            {
                return decReceiptAmnt;
            }
            set
            {
                decReceiptAmnt = value;
            }
        }
        //Property for storing organistion id.
        public int Organisation_Id
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }

        //Property for storing Corporate office id.
        public int CorpOffice_Id
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
            }
        }
        //Property for storing user id who do the event.
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
        //Property for storing settled user id who do the event.
        public int StldUser_Id
        {
            get
            {
                return intStldUserId;
            }
            set
            {
                intStldUserId = value;
            }
        }
        //Property for storing the date when the event occurs.
        public DateTime D_Date
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }

        //Property for storing CanceReason 
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
        //Property for storing Cnfrm_Status.
        public int Cnfrm_Status
        {
            get
            {
                return intCnfrmStatus;
            }
            set
            {
                intCnfrmStatus = value;
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
        //storing the TotalAmnt
        public decimal VioltnAmnt
        {
            get
            {
                return decVioltnAmnt;
            }
            set
            {
                decVioltnAmnt = value;
            }
        }
    }
}

