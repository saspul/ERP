using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_GMS
{
    public class classEntityLayerContractMaster
    {
        private int intCntrctCatId = 0;
        private int intProjectId = 0;
        private string strSub_Cntrct_Name = "";
        private string strSub_CntrctCode = "";
        private int intSubCntrctrId = 0;
        private int intJobCat_Id = 0;
        private int intParnt_SubCntrct_Id = 0;
        private string strRefNumber = "";

        private int intCntrctId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";
        private string strCntrctname = "";


        //Method for storing subcontract id
        public int CntrctId
        {
            get
            {
                return intCntrctId;
            }
            set
            {
                intCntrctId = value;
            }
        }

        //Method for storing subcontract id
        public int Parnt_SubCntrct_Id
        {
            get
            {
                return intParnt_SubCntrct_Id;
            }
            set
            {
                intParnt_SubCntrct_Id = value;
            }
        }

        //Method for storing job category uid
        public int JobCat_Id
        {
            get
            {
                return intJobCat_Id;
            }
            set
            {
                intJobCat_Id = value;
            }
        }
        //Method for storing subcontract id
        public int SubCntrctrId
        {
            get
            {
                return intSubCntrctrId;
            }
            set
            {
                intSubCntrctrId = value;
            }
        }

        //Method for storing project id
        public int ProjectId
        {
            get
            {
                return intProjectId;
            }
            set
            {
                intProjectId = value;
            }
        }
        //Method for storing contract name
        public string Sub_Cntrct_Name
        {
            get
            {
                return strSub_Cntrct_Name;
            }
            set
            {
                strSub_Cntrct_Name = value;
            }
        }
        //Method for storing sub conract id.
        public string Sub_CntrctCode
        {
            get
            {
                return strSub_CntrctCode;
            }
            set
            {
                strSub_CntrctCode = value;
            }
        }
        //Method for storing reference number
        public string RefNumber
        {
            get
            {
                return strRefNumber;
            }
            set
            {
                strRefNumber = value;
            }
        }
        //Method for storing Complaint master id.
        public string Cntrctname
        {
            get
            {
                return strCntrctname;
            }
            set
            {
                strCntrctname = value;
            }
        }
        //Method for storing Complaint master id.
        public int CntrctCatId
        {
            get
            {
                return intCntrctCatId;
            }
            set
            {
                intCntrctCatId = value;
            }
        }
        //Method for storing organistion id.
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


        //Method for storing Corporate office id.
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


        //Method for storing user id who do the event.
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
        //Method for storing the date when the event occurs.
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
        //Method of storing the Status of the Complaint
        public int  Contract_Status
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
        //methode of cancel status storing
        public int Cancel_Status
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

        //Method for storing Complaint cancel reason
        public string Cancel_reason
        {
            get
            {
                return strCancelreason;
            }
            set
            {
                strCancelreason = value;
            }
        }
    }
}
