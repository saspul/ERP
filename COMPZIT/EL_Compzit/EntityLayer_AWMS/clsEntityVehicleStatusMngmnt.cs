using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityVehicleStatusMngmnt
    {
        private int intVehicleId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intDivisionId = 0;

        private int intCnfrm = 0;
        private int intVehAsignId = 0;
        private int intNextIdForAssign = 0;
        private int intAssignMode = 0;
        private int intAssignedToUser = 0;
        private int intAssignedToPrjct = 0;
        private int intVehicleStsTyp = 0;
        private int intVehicleSts = 0;
        private DateTime dateFromDate;
        private DateTime dateToDate;
        private string StrVehicleAgnDescriptn = "";
        private int intAsignStatus = 0;
        private string strCancelReason = "";



        //method for storing asign id
        public int Cnfrm_Sts
        {
            get
            {
                return intCnfrm;
            }
            set
            {
                intCnfrm = value;
            }
        }
        //method for storing asign id
        public int VehAsignId
        {
            get
            {
                return intVehAsignId;
            }
            set
            {
                intVehAsignId = value;
            }
        }
        //method for storing cancel reason
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
        //method for storing asign status id
        public int AsignStatus
        {
            get
            {
                return intAsignStatus;
            }
            set
            {
                intAsignStatus = value;
            }
        }
        //method for storing vehicle asign description
        public string VehicleAgnDescriptn
        {
            get
            {
                return StrVehicleAgnDescriptn;
            }
            set
            {
                StrVehicleAgnDescriptn = value;
            }
        }
        //method for storing to date
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
        //method for storing from date of assign
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
        //method for storing vehicle status id
        public int VehicleSts
        {
            get
            {
                return intVehicleSts;
            }
            set
            {
                intVehicleSts = value;
            }
        }
        //method for storing vehicle status type
        public int VehicleStsTyp
        {
            get
            {
                return intVehicleStsTyp;
            }
            set
            {
                intVehicleStsTyp = value;
            }
        }
        //method for storing assigned to project id
        public int AssignedToPrjct
        {
            get
            {
                return intAssignedToPrjct;
            }
            set
            {
                intAssignedToPrjct = value;
            }
        }
        //method for storing assigned to user id
        public int AssignedToUser
        {
            get
            {
                return intAssignedToUser;
            }
            set
            {
                intAssignedToUser = value;
            }
        }
        //method of storing assign mode
        public int AssignMode
        {
            get
            {
                return intAssignMode;
            }
            set
            {
                intAssignMode = value;
            }
        }

        //method of storing next id
        public int NextIdForAssign
        {
            get
            {
                return intNextIdForAssign;
            }
            set
            {
                intNextIdForAssign = value;
            }
        }

        //methode of storing Vehicle_Id
        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        //methode of storing Vehicle_Id
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
        //methode of storing Oragnisation_Id
        public int Org_Id
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
        //methode of storing Corporate_Id
        public int CorporateId
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
        //methode of storing User_Id
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


    }
}
