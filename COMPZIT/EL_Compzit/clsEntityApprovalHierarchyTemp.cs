using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityApprovalHierarchyTemp
    {
        private int whrid = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int apptrst = 0;
        private int appmdfst = 0;
        private int apppenst = 0;
        private int smsst = 0;
        private int dashst = 0;
        private int ttcst = 0;
        private int priority = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;      
        private int intCancelStatus = 0;
        private string strName1 = "";
        private string strName = "";
        private int intMajorityAprvSts = 0;
        private DateTime dStartDate;
        private DateTime dEndDate;
        private DateTime tDate;
        private int intDesgId = 0;
        private int intEmployeeId = 0;
        private int intSubstituteEmpSts = 0;
        private int intThresholdPeriodMode = 0;
        private int intThresholdPeriodDays = 0;
        private int intAprvPendingSts = 0;
        private int intTtExceededSts = 0;
        private int intSmsSts = 0;
        private int intSystemSts = 0;
        private int intSubordinatesNum = 0;
        private int intTempId = 0;
        private int intConfirmSts = 0;

        private int intParentId = 0;
        private int intLevel = 0;
        private string docid = "";
        private string desc = "";
        private string depid = "";
        private string divid = "";
        private string strCancelreason = "";
        private int intCond = 0;
        private int inttype = 0;
        private double intMax = 0;
        private double intMin = 0;
        private int intTempDtlId = 0;
        private int intDtlId = 0;
        private int intReplaceApprvrSts = 0;

        private int intCount = 0;
        private int intMailSts = 0;
        private int intSkipLvlSts = 0;
        private int intMode = 0;
        private int intSingleApprvlSts = 0;
        private int intApprovalRuleSts = 0;
        private int intCanModify = 0;

        private int intApprvlRuleId = 0;
        private int intConditionId = 0;
        private int intConditionTypeId = 0;
        private decimal decMaxVal = 0;
        private decimal decMinVal = 0;
        private string strValues = "";
        private int intSLNo = 0;


        public int SLNo
        {
            get
            {
                return intSLNo;
            }
            set
            {
                intSLNo = value;
            }
        }
        public string CondtnValues
        {
            get
            {
                return strValues;
            }
            set
            {
                strValues = value;
            }
        }
        public decimal MinVal
        {
            get
            {
                return decMinVal;
            }
            set
            {
                decMinVal = value;
            }
        }
        public decimal MaxVal
        {
            get
            {
                return decMaxVal;
            }
            set
            {
                decMaxVal = value;
            }
        }
        public int ConditionTypeId
        {
            get
            {
                return intConditionTypeId;
            }
            set
            {
                intConditionTypeId = value;
            }
        }
        public int ConditionId
        {
            get
            {
                return intConditionId;
            }
            set
            {
                intConditionId = value;
            }
        }
        public int ApprvlRuleId
        {
            get
            {
                return intApprvlRuleId;
            }
            set
            {
                intApprvlRuleId = value;
            }
        }

        public int CanModify
        {
            get
            {
                return intCanModify;
            }
            set
            {
                intCanModify = value;
            }
        }
        public int ApprovalRuleSts
        {
            get
            {
                return intApprovalRuleSts;
            }
            set
            {
                intApprovalRuleSts = value;
            }
        }
        public int SingleApprvlSts
        {
            get
            {
                return intSingleApprvlSts;
            }
            set
            {
                intSingleApprvlSts = value;
            }
        }
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
            }
        }
        public int SkipLvlSts
        {
            get
            {
                return intSkipLvlSts;
            }
            set
            {
                intSkipLvlSts = value;
            }
        }
        public int MailSts
        {
            get
            {
                return intMailSts;
            }
            set
            {
                intMailSts = value;
            }
        }
        public int Count
        {
            get
            {
                return intCount;
            }
            set
            {
                intCount = value;
            }
        }
        public int ReplaceApprvrSts
        {
            get
            {
                return intReplaceApprvrSts;
            }
            set
            {
                intReplaceApprvrSts = value;
            }
        }
        public int DtlId
        {
            get
            {
                return intDtlId;
            }
            set
            {
                intDtlId = value;
            }
        }
        public int TempDtlId
        {
            get
            {
                return intTempDtlId;
            }
            set
            {
                intTempDtlId = value;
            }
        }
        public int Level
        {
            get
            {
                return intLevel;
            }
            set
            {
                intLevel = value;
            }
        }
        public int ParentId
        {
            get
            {
                return intParentId;
            }
            set
            {
                intParentId = value;
            }
        }
        public int ConfirmSts
        {
            get
            {
                return intConfirmSts;
            }
            set
            {
                intConfirmSts = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return dStartDate;
            }
            set
            {
                dStartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dEndDate;
            }
            set
            {
                dEndDate = value;
            }
        }
        public DateTime cDate
        {
            get
            {
                return tDate;
            }
            set
            {
                tDate = value;
            }
        }
        public int MajorityAprvSts
        {
            get
            {
                return intMajorityAprvSts;
            }
            set
            {
                intMajorityAprvSts = value;
            }
        }
        public int DesgId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
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
        public int SubstituteEmpSts
        {
            get
            {
                return intSubstituteEmpSts;
            }
            set
            {
                intSubstituteEmpSts = value;
            }
        }
        public int ThresholdPeriodMode
        {
            get
            {
                return intThresholdPeriodMode;
            }
            set
            {
                intThresholdPeriodMode = value;
            }
        }
        public int ThresholdPeriodDays
        {
            get
            {
                return intThresholdPeriodDays;
            }
            set
            {
                intThresholdPeriodDays = value;
            }
        }
        public int AprvPendingSts
        {
            get
            {
                return intAprvPendingSts;
            }
            set
            {
                intAprvPendingSts = value;
            }

        }
        public int TtExceededSts
        {
            get
            {
                return intTtExceededSts;
            }
            set
            {
                intTtExceededSts = value;
            }
        }
        public int SmsSts
        {
            get
            {
                return intSmsSts;
            }
            set
            {
                intSmsSts = value;
            }
        }
        public int SystemSts
        {
            get
            {
                return intSystemSts;
            }
            set
            {
                intSystemSts = value;
            }
        }
        public int SubordinatesNum
        {
            get
            {
                return intSubordinatesNum;
            }
            set
            {
                intSubordinatesNum = value;
            }
        }
        public int TempId
        {
            get
            {
                return intTempId;
            }
            set
            {
                intTempId = value;
            }
        }
        public int hrid
        {
            get
            {
                return whrid;
            }
            set
            {
                whrid = value;
            }
        }
        //methode storing floor name
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        public string Name1
        {
            get
            {
                return strName1;
            }
            set
            {
                strName1 = value;
            }
        }

        public string Doc
        {
            get
            {
                return docid;
            }
            set
            {
                docid = value;
            }
        }
        public string descr
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }
        public string Dep
        {
            get
            {
                return depid;
            }
            set
            {
                depid = value;
            }
        }
        public string div
        {
            get
            {
                return divid;
            }
            set
            {
                divid = value;
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
        public int apptrans
        {
            get
            {
                return apptrst;
            }
            set
            {
                apptrst = value;
            }
        }
        public int appmdf
        {
            get
            {
                return appmdfst;
            }
            set
            {
                appmdfst = value;
            }
        }
        public int appnd
        {
            get
            {
                return apppenst;
            }
            set
            {
                apppenst = value;
            }
        }
        public int sms
        {
            get
            {
                return smsst;
            }
            set
            {
                smsst = value;
            }
        }
        public int dash
        {
            get
            {
                return dashst;
            }
            set
            {
                dashst = value;
            }
        }
        public int ttc
        {
            get
            {
                return ttcst;
            }
            set
            {
               ttcst = value;
            }
        }
        public int prity
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
        //methode of provider type date storing
        public DateTime trannsDate
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

        //methode of provider name storing
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
        //methode of provider name storing
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
        public string AccommmodationType_Cancel_reason
        {
            get
            {
                return strCancelreason;
            }
            set
            {
                strCancelreason = value;
            }
        }
        public int Cond
        {
            get
            {
                return intCond;
            }
            set
            {
                intCond = value;
            }
        }
        public int type
        {
            get
            {
                return inttype;
            }
            set
            {
                inttype = value;
            }
        }
        public double Max
        {
            get
            {
                return intMax;
            }
            set
            {
                intMax = value;
            }
        }
        public double Min
        {
            get
            {
                return intMin;
            }
            set
            {
                intMin = value;
            }
        }
    }
}
