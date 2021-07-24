using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_GMS
{
    public class clsEntityLayerInsuranceTypMaster
    {

        private int intInsrTypId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";
        private string strInsrTypname = "";


        //Method for storing Complaint master id.
        public string InsrTypname
        {
            get
            {
                return strInsrTypname;
            }
            set
            {
                strInsrTypname = value;
            }
        }
        //Method for storing Complaint master id.
        public int InsrTypId
        {
            get
            {
                return intInsrTypId;
            }
            set
            {
                intInsrTypId = value;
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
        public int InsrTypStatus
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
