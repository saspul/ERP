using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0008
// CREATED DATE:02/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityVehicleStatusMaster
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
        private int intstatustypeId = 0;
        private int intAppModeSection = 0;


    


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
        public int VehId
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
        //Method for storing Ctgry id.
        public int StatusTypeId
        {
            get
            {
                return intstatustypeId;
            }
            set
            {
                intstatustypeId = value;
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

