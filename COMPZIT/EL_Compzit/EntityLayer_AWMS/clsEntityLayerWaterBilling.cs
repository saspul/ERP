using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerWaterBilling
    {
        private int intWaterFillingId = 0;
        private int intWaterCardId = 0;
        private decimal decTotalAmnt = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime ddate;
        private string strCancelReason = "";
        private int intCnfrmStatus = 0;
        private int intStatus = 0;
        private int intCancelStatus = 0;
        private string strSearchField = "";
        private string strDataBaseField = null;
        private decimal decCardCurrentAmnt = 0;
        //Property for storing Water Filling id.
        public int WaterFillingId
        {
            get
            {
                return intWaterFillingId;
            }
            set
            {
                intWaterFillingId = value;
            }
        }
        //Property for storing WaterCard id.
        public int WaterCardId
        {
            get
            {
                return intWaterCardId;
            }
            set
            {
                intWaterCardId = value;
            }
        }
        //storing the TotalAmnt
        public decimal TotalAmnt
        {
            get
            {
                return decTotalAmnt;
            }
            set
            {
                decTotalAmnt = value;
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
        public decimal CardCurrentAmnt
        {
            get
            {
                return decCardCurrentAmnt;
            }
            set
            {
                decCardCurrentAmnt = value;
            }
        }
    }
}
