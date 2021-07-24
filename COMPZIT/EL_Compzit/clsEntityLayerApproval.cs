using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:22/02/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Organisation Approval.

namespace EL_Compzit
{
    public class clsEntityLayerApproval
    {
        private  int intParkid = 0;
        private  int intStatus = 0;
        private  DateTime Date;
        private  int intUserId = 0;
        private  string strReason = null;

        //Method for storing Park id.
        public int Park_id
        {
            get
            {
                return intParkid;
            }
            set
            {
                intParkid = value;
            }
        }

        //Method for storing status of organisation.
        public int Status
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

        //Method for storing Date of the event.
        public DateTime Date_Update
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }

        //Method for storing userid.
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

        //Method for storing rejection reason.
        public string Reason
        {
            get
            {
                return strReason;
            }
            set
            {
                strReason = value;
            }
        }
    }
}
