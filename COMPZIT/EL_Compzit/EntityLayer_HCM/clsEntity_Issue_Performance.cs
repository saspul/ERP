using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Issue_Performance
    {
        private int intIssue = 0;
        private int intUsrId=0;
        private int intOrgId = 0;
        private int intCorpId=0;
        private string strRef;
        private DateTime dtIssuedate;
        private string strIssue;
        private int intRev = 0;
        private int intFrqncy = 0;
        private int intPerfrmTemplt = 0;
        private int intSelfEval = 0;
        private int intSelfGoal = 0;
        private int intROEval = 0;
        private int intROGoal = 0;
        private int intDMEval = 0;
        private int intDMGoal = 0;
        private int intHREval = 0;
        private int intHRGoal = 0;
        private int intGMEval = 0;
        private int intGMGoal = 0;
        private int intEmp = 0;
        private int intConfrmSts = 0;
        private int intddlEval = 0;
        private int intEvalGoal = 0;
        private int intStatus = 0;
        private DateTime dtFrom;
        private DateTime dtTo;
        private string strCnclRsn;
        private int intCancel = 0;
        private int intEmpid = 0;
        private int intDsgnid = 0;
        private int intDeptId = 0;
        private int intEvalDsgnid = 0;
        private int intEvalDeptId = 0;
        private int intEvalEmpid = 0;

        private int intTmpltBkupId = 0;
        private int intTmpltBkupQtnId = 0;
        public int TemplateBkUpID
        {
            get
            {
                return intTmpltBkupId;
            }
            set
            {
                intTmpltBkupId = value;
            }
        }
        public int QuestionBkUpID
        {
            get
            {
                return intTmpltBkupQtnId;
            }
            set
            {
                intTmpltBkupQtnId = value;
            }
        }
        public int EvalDeptID
        {
            get
            {
                return intEvalDeptId;
            }
            set
            {
                intEvalDeptId = value;
            }
        }
        public int EvalDsgnID
        {
            get
            {
                return intEvalDsgnid;
            }
            set
            {
                intEvalDsgnid = value;
            }
        }
        public int EvalEmpID
        {
            get
            {
                return intEvalEmpid;
            }
            set
            {
                intEvalEmpid = value;
            }
        }
        public int DeptID
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
            }
        }
        public int DsgnID
        {
            get
            {
                return intDsgnid;
            }
            set
            {
                intDsgnid = value;
            }
        }
    
        public int EmpID
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        }
        public int Cancel_Status
        {
            get
            {
                return intCancel;
            }
            set
            {
                intCancel = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dtTo;
            }
            set
            {
                dtTo = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dtFrom;
            }
            set
            {
                dtFrom = value;
            }
        }
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
        public int EvalutorGoal
        {
            get
            {
                return intEvalGoal;
            }
            set
            {
                intEvalGoal = value;
            }
        }
        public int IssueId
        {
            get
            {
                return intIssue;
            }
            set
            {
                intIssue = value;
            }
        }
        public int UserId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        public int OrgId
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
        public int Corp_Id
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
        public string Ref_No
        {
            get
            {
                return strRef;
            }
            set
            {
                strRef = value;
            }
        }
        public DateTime IssueDate
        {
            get
            {
                return dtIssuedate;
            }
            set
            {
                dtIssuedate = value;
            }
        }
        public string Issue
        {
            get
            {
                return strIssue;
            }
            set
            {
                strIssue = value;
            }
        }
        public int Rev_No
        {
            get
            {
                return intRev;
            }
            set
            {
                intRev = value;
            }
        }
        public int Frequency
        {
            get
            {
                return intFrqncy;
            }
            set
            {
                intFrqncy = value;
            }
        }
        public int PerfrmTempltId
        {
            get
            {
                return intPerfrmTemplt;
            }
            set
            {
                intPerfrmTemplt = value;
            }
        }
        public int SelfEvaluate
        {
            get
            {
                return intSelfEval;
            }
            set
            {
                intSelfEval = value;
            }
        }
        public int SelfGoal
        {
            get
            {
                return intSelfGoal;
            }
            set
            {
                intSelfGoal = value;
            }
        }
        public int ROEvaluate
        {
            get
            {
                return intROEval;
            }
            set
            {
                intROEval = value;
            }
        }
        public int ROGoal
        {
            get
            {
                return intROGoal;
            }
            set
            {
                intROGoal = value;
            }
        }
        public int DMEvaluate
        {
            get
            {
                return intDMEval;
            }
            set
            {
                intDMEval = value;
            }
        }
        public int DMGoal
        {
            get
            {
                return intDMGoal;
            }
            set
            {
                intDMGoal = value;
            }
        }
        public int HREvaluate
        {
            get
            {
                return intHREval;
            }
            set
            {
                intHREval = value;
            }
        }
        public int HRGoal
        {
            get
            {
                return intHRGoal;
            }
            set
            {
                intHRGoal = value;
            }
        }
        public int GMEvaluate
        {
            get
            {
                return intGMEval;
            }
            set
            {
                intGMEval = value;
            }
        }
        public int GMGoal
        {
            get
            {
                return intGMGoal;
            }
            set
            {
                intGMGoal = value;
            }
        }
        public int EmpDeptDsgn
        {
            get
            {
                return intEmp;
            }
            set
            {
                intEmp = value;
            }
        }
        public int ConfirmStatus
        {
            get
            {
                return intConfrmSts;
            }
            set
            {
                intConfrmSts = value;
            }
        }
        public string CancelReason 
        {

            get { return strCnclRsn; }
            set { strCnclRsn = value; }
        }
       public int EDDEval
        {
            get
            {
                return intddlEval;
            }
            set
            {
                intddlEval = value;
            }
        }

    }
    public class clsEntity_Employees_list
    {
        private int intDesgnId = 0;
        private int intEmpsId = 0;
        private int intDeptId = 0;

        public int DesignationId
        {
            get { return intDesgnId; }
            set { intDesgnId = value; }
        }
        public int EmpId
        {
            get { return intEmpsId; }
            set { intEmpsId = value; }
        }
        public int DeptId
        {
            get { return intDeptId; }
            set { intDeptId = value; }
        }
    }
    public class clsEntity_Evaluator_list
    {
        private int intEvalEmpId = 0;
        private int intEvalEmpGoal = 0;
        private int intEvalDeptId = 0;
        private int intDeptGoal = 0;
        private int intDsgnDeptId = 0;
        private int intDsgnGoal = 0;
        public int EvaluaterEmpId
        {
            get { return intEvalEmpId; }
            set { intEvalEmpId = value; }
        }
        public int EmpEvaluatorGoal
        {
            get { return intEvalEmpGoal; }
            set { intEvalEmpGoal = value; }
        }
        public int EvaluaterDeptId
        {
            get { return intEvalDeptId; }
            set { intEvalDeptId = value; }
        }
        public int DeptEvaluatorGoal
        {
            get { return intDeptGoal; }
            set { intDeptGoal = value; }
        }
        public int EvaluaterDsgntId
        {
            get { return intDsgnDeptId; }
            set { intDsgnDeptId = value; }
        }
        public int DsgnEvaluatorGoal
        {
            get { return intDsgnGoal; }
            set { intDsgnGoal = value; }
        }
    }
}
