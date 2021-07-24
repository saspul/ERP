using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_LeaveFacltyAssmntList
    {
        private int intLevFacltyAssmntDtlId = 0;
        private int intLevFacltyAssmntId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime DateUsrDate;
        private DateTime Datefinish;
        private DateTime DateClose;
        private DateTime dateFromDate=DateTime.MinValue;
        private DateTime dateToDate=DateTime.MinValue;

        private int intCandId = 0;
        private int intRqstId = 0;
        private int intEmployeeId = 0;
        private int intParticularId = 0;
        private int intStatusId = 0;
        private int intFinishStatusId = 0;
        private int intCloseStatusId = 0;
        private int intVehicleId = 0;
        private int intVisatypeId = 0;
        private int intFinishstatus = 0;
        private int intCloseSts = 0;
        private int intFlightTypeId = 0;
        private int intRoomTypeId = 0;
        private int intLeavId = 0;


        private int intStaffWorkerChk = 0;
        public int LeavId
        {
            get
            {
                return intLeavId;
            }
            set
            {
                intLeavId = value;
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
        public int RadioStaffChk
        {
            get
            {
                return intStaffWorkerChk;
            }
            set
            {
                intStaffWorkerChk = value;
            }
        }

        public int FlightTypeId
        {
            get
            {
                return intFlightTypeId;
            }
            set
            {
                intFlightTypeId = value;
            }
        }
        public int RoomTypeId
        {
            get
            {
                return intRoomTypeId;
            }
            set
            {
                intRoomTypeId = value;
            }
        }
        public DateTime FinishDate
        {
            get
            {
                return Datefinish;
            }
            set
            {
                Datefinish = value;
            }
        }
        public DateTime CloseDate
        {
            get
            {
                return DateClose;
            }
            set
            {
                DateClose = value;
            }
        }
        public int Finishstatus
        {
            get
            {
                return intFinishstatus;
            }
            set
            {
                intFinishstatus = value;
            }
        }
        public int CloseSts
        {
            get
            {
                return intCloseSts;
            }
            set
            {
                intCloseSts = value;
            }
        }
        public int VisatypeId
        {
            get
            {
                return intVisatypeId;
            }
            set
            {
                intVisatypeId = value;
            }
        }
        public DateTime UsrDate
        {
            get
            {
                return DateUsrDate;
            }
            set
            {
                DateUsrDate = value;
            }
        }

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
        public int CloseStatusId
        {
            get
            {
                return intCloseStatusId;
            }
            set
            {
                intCloseStatusId = value;
            }
        }
        public int FinishStatusId
        {
            get
            {
                return intFinishStatusId;
            }
            set
            {
                intFinishStatusId = value;
            }
        }
        public int StatusId
        {
            get
            {
                return intStatusId;
            }
            set
            {
                intStatusId = value;
            }
        }
        public int ParticularId
        {
            get
            {
                return intParticularId;
            }
            set
            {
                intParticularId = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public int LevFacltyAssmntDtlId
        {
            get
            {
                return intLevFacltyAssmntDtlId;
            }
            set
            {
                intLevFacltyAssmntDtlId = value;
            }
        }
        public int LevFacltyAssmntId
        {
            get
            {
                return intLevFacltyAssmntId;
            }
            set
            {
                intLevFacltyAssmntId = value;
            }
        }

        public int Orgid
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
        public int CorpOffice
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
        public int CandId
        {
            get
            {
                return intCandId;
            }
            set
            {
                intCandId = value;
            }
        }

        public int ReqstID
        {
            get
            {
                return intRqstId;
            }
            set
            {
                intRqstId = value;
            }
        }
    }
}
