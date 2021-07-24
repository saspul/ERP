using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerJobScheduleDtl
    {
       private int intDutyRosterId = 0;
       private int intDutyRosterDetailId = 0;
        private int intJobSchdlDtlId = 0;
        private int intJobSchdlId = 0;
        private int intTimeSlotId = 0;
        private int intSchdlMode= 0;
        private DateTime dFromTime;
        private DateTime dToTime;
        private int intVhclId = 0;
        private int intPrjctId = 0;
        private int intJobId = 0;
        private string strJobName = "";
        private int intCancelSts = 0;
        private int intJobMode= 0;
        private int intTimeDiffrncSts = 0;
        private string strFromTime="";
        private string strToTime="";

        //method for storing dutyroster detail id.
        public int DutyRosterDetailId
        {
            get
            {
                return intDutyRosterDetailId;
            }
            set
            {
                intDutyRosterDetailId = value;
            }
        }
        //method for storing dutyroster detail id.
        public int DutyRosterId
        {
            get
            {
                return intDutyRosterId;
            }
            set
            {
                intDutyRosterId = value;
            }
        }
        //Method of storing Detail id of job schedule 
        public int JobSchdlDtlId
        {
            get
            {
                return intJobSchdlDtlId;
            }
            set
            {
                intJobSchdlDtlId = value;
            }
        }

        //Property for storing Job Schdl id.
        public int JobSchdlId
        {
            get
            {
                return intJobSchdlId;
            }
            set
            {
                intJobSchdlId = value;
            }
        }
        //Property for storing TimeSlot id.
        public int TimeSlotId
        {
            get
            {
                return intTimeSlotId;
            }
            set
            {
                intTimeSlotId = value;
            }
        }

        //Property for storing SchdlWise Mode.
        public int SchdlWiseMode
        {
            get
            {
                return intSchdlMode;
            }
            set
            {
                intSchdlMode = value;
            }
        }

        //Property for storing the from time .
        public DateTime FromTime
        {
            get
            {
                return dFromTime;
            }
            set
            {
                dFromTime = value;
            }
        }

        //Property for storing the To time .
        public DateTime ToTime
        {
            get
            {
                return dToTime;
            }
            set
            {
                dToTime = value;
            }
        }
        //Property of storing the Vhcl id
        public int VhclId
        {
            get
            {
                return intVhclId;
            }
            set
            {
                intVhclId = value;
            }
        }
        //Property of storing the Prjct id
        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }
        //Property of storing the job id
        public int JobId
        {
            get
            {
                return intJobId;
            }
            set
            {
                intJobId = value;
            }
        }
        //Property for storing Job Name.
        public string JobName
        {
            get
            {
                return strJobName;
            }
            set
            {
                strJobName = value;

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
        //Property for storing Job Mode.
        public int JobMode
        {
            get
            {
                return intJobMode;
            }
            set
            {
                intJobMode = value;
            }
        }
        //Property for storing the status of time diff sts if from time is less than to time then sts is 0 if not is 1
        public int TimeDiffrncSts
        {
            get
            {
                return intTimeDiffrncSts;
            }
            set
            {
                intTimeDiffrncSts = value;
            }
        }

        //Property for storing Job Name.
        public string FromTimeString
        {
            get
            {
                return strFromTime;
            }
            set
            {
                strFromTime = value;

            }
        }
        //Property for storing Job Name.
        public string ToTimeString
        {
            get
            {
                return strToTime;
            }
            set
            {
                strToTime = value;

            }
        }

    }


   public class clsEntityLayerJobSchdlWeekDayDtl
   {
       private int intJobSchdlWeekDayDtlId = 0;
       private int intJobSchdlId = 0;
       private int intWeekDaysId = 0;      
       private int intCancelSts = 0;


       //Method of storing Detail id of job schedule 
       public int JobSchdlWeekDayDtlId
       {
           get
           {
               return intJobSchdlWeekDayDtlId;
           }
           set
           {
               intJobSchdlWeekDayDtlId = value;
           }
       }



       //Property for storing Job Schdl id.
       public int JobSchdlId
       {
           get
           {
               return intJobSchdlId;
           }
           set
           {
               intJobSchdlId = value;
           }
       }
       //Property for storing WeekDays id.
       public int WeekDaysId
       {
           get
           {
               return intWeekDaysId;
           }
           set
           {
               intWeekDaysId = value;
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
