using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityJoiningWorker
    {
        private int intWorkerID=0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private string strWorkerName="";
        private int intDivision=0;
        private int intDesignation=0;
        private string strPassportNo="";
        private DateTime dateJoiningDate=DateTime.MinValue;
        private DateTime dateFormFillDate = DateTime.MinValue;
        private string strSiteNo="";
        private string strLicenceFileName="";
        private string strCertificateFileName="";
        private string strComments="";
        private string strLicenceActualName="";

        private int intUserId = 0;
        private DateTime dDate = DateTime.MinValue;
        private string strCancelReason = "";
        private int intCancelStatus = 0;
        private string strCertificateActualName="";

        private int intWorkerStatus=0;

        private int inCandidateID=0;

        private int intConfirmStatus=0;

        public int ConfirmStatus
        {
            get { return intConfirmStatus; }
            set { intConfirmStatus = value; }
        }


        public int CandidateID
        {
            get { return inCandidateID; }
            set { inCandidateID = value; }
        }


        public int WorkerStatus
        {
            get { return intWorkerStatus; }
            set { intWorkerStatus = value; }
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
        public string CertificateActualName
        {
            get { return strCertificateActualName; }
            set { strCertificateActualName = value; }
        }

        public string LicenceActualName
        {
            get { return strLicenceActualName; }
            set { strLicenceActualName = value; }
        }
        

        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }

        public string CertificateFileName
        {
            get { return strCertificateFileName; }
            set { strCertificateFileName = value; }
        }

        public string LicenceFileName
        {
            get { return strLicenceFileName; }
            set { strLicenceFileName = value; }
        }

        public string SiteNo
        {
            get { return strSiteNo; }
            set { strSiteNo = value; }
        }

        public DateTime FormFillDate
        {
            get { return dateFormFillDate; }
            set { dateFormFillDate = value; }
        }

        public DateTime JoiningDate
        {
            get { return dateJoiningDate; }
            set { dateJoiningDate = value; }
        }

        public string PassportNo
        {
            get { return strPassportNo; }
            set { strPassportNo = value; }
        }


        public int Designation
        {
            get { return intDesignation; }
            set { intDesignation = value; }
        }


        public int Division
        {
            get { return intDivision; }
            set { intDivision = value; }
        }


        public string WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }


        public int WorkerID
        {
            get { return intWorkerID; }
            set { intWorkerID = value; }
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
    }
    public class clsJoiningWorkerDtl
    {
        private string strOtherDocuFileName;
        private string strOtherDocuActualName;
        private int intWorkerDetailID;

        public int WorkerDetailID
        {
            get { return intWorkerDetailID; }
            set { intWorkerDetailID = value; }
        }
        
        public string OtherDocuActualName
        {
            get { return strOtherDocuActualName; }
            set { strOtherDocuActualName = value; }
        }
        
        public string OtherDocuFileName
        {
            get { return strOtherDocuFileName; }
            set { strOtherDocuFileName = value; }
        }

    } 
}
