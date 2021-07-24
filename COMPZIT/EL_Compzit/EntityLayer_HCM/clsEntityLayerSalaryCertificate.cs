using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerSalaryCertificate
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intEmployeeId = 0;
        private decimal decBasicPay = 0;
        private decimal decAllowance = 0;
        private int intCancelSts = 0;
        private string strCancelReason = "";
        private DateTime dDate;
        private int intConfirmSts = 0;
        private int intHR_ApprvlSts = 0;
        private int intCertfctId = 0;
        private string strReason = "";

        public int CorpId
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
        public decimal BasicPay
        {
            get
            {
                return decBasicPay;
            }
            set
            {
                decBasicPay = value;
            }
        }
        public decimal Allowance
        {
            get
            {
                return decAllowance;
            }
            set
            {
                decAllowance = value;
            }
        }
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
        public string RejectReason
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
        public int HRApprovalSts
        {
            get
            {
                return intHR_ApprvlSts;
            }
            set
            {
                intHR_ApprvlSts = value;
            }
        }

        public int CertifictId
        {
            get
            {
                return intCertfctId;
            }
            set
            {
                intCertfctId = value;
            }
        }

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
