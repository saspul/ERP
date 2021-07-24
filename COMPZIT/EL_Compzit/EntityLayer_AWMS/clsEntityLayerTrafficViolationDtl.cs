using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerTrafficViolationDtl
    {
        private int intTrafcVltnDtlId = 0;
        private int intTrafcVltnId = 0;
        private int intVehicleId = 0;     
        private int intEmpId = 0;
        private DateTime dateVioltn;
        private int intVioltnId=0;
        private decimal decVioltnAmnt = 0;
        private int intSettledStatus = 0;
        private decimal decSettledAmnt = 0;
        private DateTime dateSettled;
        private int intCancelSts = 0;

        //Method of storing Detail id of Traffic Violation 
        public int TrficVioltn_DtlId
        {
            get
            {
                return intTrafcVltnDtlId;
            }
            set
            {
                intTrafcVltnDtlId = value;
            }
        }

        //Property for storing Traffic Violation  id.
        public int TrficVioltnId
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
        //Property for storing Vehicle  id.
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
        //Property for storing Employee  id.
        public int UserId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        
        //Property for storing the date of Violation.
        public DateTime Violtndate
        {
            get
            {
                return dateVioltn;
            }
            set
            {
                dateVioltn = value;
            }
        }
        //Property of storing the Violation
        public int Violation
        {
            get
            {
                return intVioltnId;
            }
            set
            {
                intVioltnId = value;
            }
        }

        //property of storing Violation Amnt
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
        //Property for storing Settled Status.
        public int StldStatusId
        {
            get
            {
                return intSettledStatus;
            }
            set
            {
                intSettledStatus = value;
            }
        }
        //property of storing Settled Amnt
        public decimal SettledAmnt
        {
            get
            {
                return decSettledAmnt;
            }
            set
            {
                decSettledAmnt = value;
            }
        }
        //Property for storing the date of Settlement.
        public DateTime Settleddate
        {
            get
            {
                return dateSettled;
            }
            set
            {
                dateSettled = value;
            }
        }

        //Property for storing  cancel status of item
        public int CancelSts
        {
            get
            {
                return intCancelSts;
            }
            set
            {
                intCancelSts = value;
            }
        }

    }
}
