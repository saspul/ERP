using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerDutyRoster
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private DateTime dFromDate;
        private DateTime dToDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;
        private int intAppModeSection = 0;
        private int intEmployeeId = 0;
        private int intVehiclleId = 0;

        //FOR MARKING LEAVE
        private DateTime dateLeaveDate;

        //Start:-EVM-0009
        private int intDutyRosterId = 0;
        private int intDutyRosterDtlId = 0;

       //Start:-For Duty Slip Submission
        private int intSubmsnId = 0;       
        private int intCnfrmStsId = 0;
        private decimal decTotalWrkHr = 0;
        private decimal decNrmlWrkHr = 0;
        private decimal decIdleHr = 0;
        private decimal decFinalOT = 0;
        private decimal decRoundedOT = 0;
        private DateTime dSubmsnDate;


        //method for storing leave date
        public DateTime LeaveDate
        {
            get
            {
                return dateLeaveDate;
            }
            set
            {
                dateLeaveDate = value;
            }
        }

        //method for storing submission date
        public DateTime SubmissionDate
        {
            get
            {
                return dSubmsnDate;
            }
            set
            {
                dSubmsnDate = value;
            }
        }
        //method for storing submission id.
        public int SubmissionId
        {
            get
            {
                return intSubmsnId;
            }
            set
            {
                intSubmsnId = value;
            }
        }
       
      
        //method for storing confirm status id
        public int CnfrmStsId
        {
            get
            {
                return intCnfrmStsId;
            }
            set
            {
                intCnfrmStsId = value;
            }
        }
       
        //method for storing total work hour
        public decimal TotalWrkHr
        {
            get
            {
                return decTotalWrkHr;
            }
            set
            {
                decTotalWrkHr = value;
            }
        }
        //method for storing normal work hour
        public decimal NormalWrkHr
        {
            get
            {
                return decNrmlWrkHr;
            }
            set
            {
                decNrmlWrkHr = value;
            }
        }
        //method for storing ideal hour
        public decimal IdleHr
        {
            get
            {
                return decIdleHr;
            }
            set
            {
                decIdleHr = value;
            }
        }
        //method for storing final over time
        public decimal FinalOT
        {
            get
            {
                return decFinalOT;
            }
            set
            {
                decFinalOT = value;
            }
        }
        //method for storing rounded over time
        public decimal RoundedOT
        {
            get
            {
                return decRoundedOT;
            }
            set
            {
                decRoundedOT = value;
            }
        }
 //End:-For Duty Slip Submission


        //method for storing dutyroster id.
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
        //method for storing dutyroster detail id.
        public int DutyRosterDtlId
        {
            get
            {
                return intDutyRosterDtlId;
            }
            set
            {
                intDutyRosterDtlId = value;
            }
        }
        //Stop:-EVM-0009
        //method for storing vehicle id.
        public int VehiclleId
        {
            get
            {
                return intVehiclleId;
            }
            set
            {
                intVehiclleId = value;
            }
        }
        //methode of storing from date
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        //methode of storing from date
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        //methode of storing employee id
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
    //Start:-EMP-0009
    public class clsEntityLayerSubmissionDtl
    {
        private int intDutyRosterId = 0;
        private int intDutyRosterDtlId = 0;
        private int intSubmsnDtlId = 0;
        private int intSubmsnStsId = 0;
        private int intVhclPrsntMlg = 0;
        private string strSubmsnDtlDesc = null;
        private int intCancelStatus = 0;
        private int intVehiclleId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;

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
        //method for storing dutyroster detail id.
        public int DutyRosterDtlId
        {
            get
            {
                return intDutyRosterDtlId;
            }
            set
            {
                intDutyRosterDtlId = value;
            }
        }
        //method for storing submission detail id.
        public int SubmissionDtlId
        {
            get
            {
                return intSubmsnDtlId;
            }
            set
            {
                intSubmsnDtlId = value;
            }
        }
        //method for storing submission status id.
        public int SubmissionStsId
        {
            get
            {
                return intSubmsnStsId;
            }
            set
            {
                intSubmsnStsId = value;
            }
        }
        //method for storing vehicle present mileage.
        public int VhclPrsntMlg
        {
            get
            {
                return intVhclPrsntMlg;
            }
            set
            {
                intVhclPrsntMlg = value;
            }
        }
        //method for storing submission detail description
        public string SubmsnDtlDesc
        {
            get
            {
                return strSubmsnDtlDesc;
            }
            set
            {
                strSubmsnDtlDesc = value;
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
        //methode of storing from date
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        //methode of storing from date
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        //method for storing vehicle id.
        public int VehiclleId
        {
            get
            {
                return intVehiclleId;
            }
            set
            {
                intVehiclleId = value;
            }
        }
    }
    //End:-EMP-0009
}
