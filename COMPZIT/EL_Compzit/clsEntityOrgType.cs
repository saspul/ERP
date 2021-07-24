using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:22/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Organisation type .
namespace EL_Compzit
{
    public class clsEntityOrgType
    {
        private int intOrgTypId = 0;
        private string strOrgName = "";
        private int intStatus = 0;
        private int intUserId;
        private string strCnclReason = "";
        private DateTime dateofEvent;
        private int intCancelStatus = 0;

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
        // This is the property definition for storing Id of Orgaisation Master.
        public int OrgTypId
        {
            get
            {
                return intOrgTypId;
            }
            set
            {
                intOrgTypId = value;
            }
        }
        // This is the property definition for storing UserId of the User logined.
        public int OrgUserId
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

        // This is the property definition for storing Status of Organisation Master.
        public int OrgStatus
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
        // This is the property definition for storing Organisation name entered .
        public string OrgName
        {
            get
            {
                return strOrgName;
            }
            set
            {
                strOrgName = value;
            }
        }
        // This is the property definition for storing Cancelation reason .
        public string OrgCancelReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }
        // This is the property definition for storing Date of updation and cancelation .
        public DateTime OrgDate
        {
            get
            {
                return dateofEvent;
            }
            set
            {
                dateofEvent = value;
            }
        }
    }
}
