using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityOpeningLeaveAlloc
    {
        private int intCorpId = 0; private int intOrgId = 0; private int intCnclSts = 0; private int intUsrSts = 0;
        private int intDsgntnId = 0; private int intLmtdUsr = 0; private decimal intOpngLeave = 0; private decimal intBlncLeave = 0;
        private decimal decLeaveAmnt = 0; private decimal decBlncLeaveAmnt = 0; private int intEpmlyId = 0;
        private int intLeaveTyp = 0; private int intUsrId = 0; private int intCnfrmUsrId = 0; private int intCnfrmSts = 0;
        private DateTime dtCnfrmDate; private int intYear = 0;

        public int CorpId { get { return intCorpId; } set { intCorpId = value; } }
        public int OrgId { get { return intOrgId; } set { intOrgId = value; } }
        public int CancelSts { get { return intCnclSts; } set { intCnclSts = value; } }
        public int UserSts { get { return intUsrSts; } set { intUsrSts = value; } }
        public int DesignationId { get { return intDsgntnId; } set { intDsgntnId = value; } }
        public int LimitedUsrId { get { return intLmtdUsr; } set { intLmtdUsr = value; } }
        public decimal OpeningLeaveNumb { get { return intOpngLeave; } set { intOpngLeave = value; } }
        public decimal BalanceLeaveNumb { get { return intBlncLeave; } set { intBlncLeave = value; } }
        public int EmployeeId { get { return intEpmlyId; } set { intEpmlyId = value; } }
        public int LeaveType { get { return intLeaveTyp; } set { intLeaveTyp = value; } }
        public int UsrerId { get { return intUsrId; } set { intUsrId = value; } }
        public int ConfirmUserId { get { return intCnfrmUsrId; } set { intCnfrmUsrId = value; } }
        public int ConfirmSts { get { return intCnfrmSts; } set { intCnfrmSts = value; } }
        public decimal LeaveAmount { get { return decLeaveAmnt; } set { decLeaveAmnt = value; } }
        public decimal BalanceLeaveAmount { get { return decBlncLeaveAmnt; } set { decBlncLeaveAmnt = value; } }
        public DateTime ConfirmDate { get { return dtCnfrmDate; } set { dtCnfrmDate = value; } }
        public int LeaveYear { get { return intYear; } set { intYear = value; } }

    }
}
