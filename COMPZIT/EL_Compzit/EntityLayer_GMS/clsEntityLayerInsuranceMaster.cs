using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_GMS
{
    public class clsEntityLayerInsuranceMaster
    {
        private int intInsuranceId = 0;
        private int intContactUser = 0;
        private int intNoOfDays = 0;
        private string strInsuranceNo = "";
        private int intemply = 0;
        private int intInsuranceTyp = 0;
        private int intNextIdForRqst = 0;
        private int intInsuranceProvdr = 0;
        private int intcurrency = 0;
        private int intprojectId = 0;
        private int intStatus = 0;
        private int intStatusSrch = 0;
        private int intDontNotify = 0;
        private int intNotTempId = 0;
        private decimal decAmount = 0;
        private DateTime dateopenDate;
        private DateTime dateExpireDate;
        private DateTime datetoDate;
        private DateTime dateExpireFromDate;
        private int intfromdashboard = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intConfirmStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";
        private string strRefNumber = "";
        private string strDescrption = "";
        private string stremail = "";
        private string stremplyNme = "";

        private string strPrjctname = "";
        private int intInsuranceTypMstr = 0;


        public int InsuranceTypMstr
        {
            get
            {
                return intInsuranceTypMstr;
            }
            set
            {
                intInsuranceTypMstr = value;
            }
        }


        public string ProjectName
        {
            get
            {
                return strPrjctname;
            }
            set
            {
                strPrjctname = value;
            }
        }

        public int NotTempId
        {
            get
            {
                return intNotTempId;
            }
            set
            {
                intNotTempId = value;
            }
        }
        public int DontNotify
        {
            get
            {
                return intDontNotify;
            }
            set
            {
                intDontNotify = value;
            }
        }
        public int StatusSrch
        {
            get
            {
                return intStatusSrch;
            }
            set
            {
                intStatusSrch = value;
            }
        }

        public int StatusIdCheck
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
        public int InsuranceId
        {
            get
            {
                return intInsuranceId;
            }
            set
            {
                intInsuranceId = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return datetoDate;
            }
            set
            {
                datetoDate = value;
            }
        }
        public int EmployeId
        {
            get
            {
                return intemply;
            }
            set
            {
                intemply = value;
            }
        }
        public int ContactPersnUsrId
        {
            get
            {
                return intContactUser;
            }
            set
            {
                intContactUser = value;
            }
        }
        public int NoOfDays
        {
            get
            {
                return intNoOfDays;
            }
            set
            {
                intNoOfDays = value;
            }
        }
        public string InsuranceNo
        {
            get
            {
                return strInsuranceNo;
            }
            set
            {
                strInsuranceNo = value;
            }
        }
        public string Email
        {
            get
            {
                return stremail;
            }
            set
            {
                stremail = value;
            }
        }
        public int ProjectId
        {
            get
            {
                return intprojectId;
            }
            set
            {
                intprojectId = value;
            }
        }
        public DateTime ExpireDate
        {
            get
            {
                return dateExpireDate;
            }
            set
            {
                dateExpireDate = value;
            }
        }
        public int Currency
        {
            get
            {
                return intcurrency;
            }
            set
            {
                intcurrency = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescrption;
            }
            set
            {
                strDescrption = value;
            }
        }
        public DateTime OpenDate
        {
            get
            {
                return dateopenDate;
            }
            set
            {
                dateopenDate = value;
            }
        }

        public int InsuranceProvider
        {
            get
            {
                return intInsuranceProvdr;
            }
            set
            {
                intInsuranceProvdr = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return decAmount;
            }
            set
            {
                decAmount = value;
            }
        }

        public string RefNumber
        {
            get
            {
                return strRefNumber;
            }
            set
            {
                strRefNumber = value;
            }
        }

        public int NextIdForRqst
        {
            get
            {
                return intNextIdForRqst;
            }
            set
            {
                intNextIdForRqst = value;
            }
        }

        public int InsuranceTyp
        {
            get
            {
                return intInsuranceTyp;
            }
            set
            {
                intInsuranceTyp = value;
            }
        }

        public string EmployeName
        {
            get
            {
                return stremplyNme;
            }
            set
            {
                stremplyNme = value;
            }
        }


        public int Organisation_Id
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


        //Method for storing Corporate office id.
        public int CorpOffice_Id
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


        //Method for storing user id who do the event.
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
        //Method for storing the date when the event occurs.
        public DateTime D_Date
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }
        //Method of storing the Status of the Complaint
        public int Guarantee_Confirm_Status
        {
            get
            {
                return intConfirmStatus;
            }
            set
            {
                intConfirmStatus = value;
            }
        }

        //methode of cancel status storing
        public int Cancel_Status
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

        //Method for storing Complaint cancel reason
        public string Cancel_reason
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

        //created by 0015 for dash board
        public int FromDashboard
        {
            get
            {
                return intfromdashboard;
            }
            set
            {
                intfromdashboard = value;
            }
        }
        //fro storing the expiry from date
        public DateTime ExpiryFromDate
        {
            get
            {
                return dateExpireFromDate;
            }
            set
            {
                dateExpireFromDate = value;
            }
        }





    }

    public class clsEntityLayerInsuranceAttachments
    {
        private string strFileName = "";
        private string strActualFileName = "";
        private int intAttchmntSlNumber = 0;
        private int intPictureId = 0;
        private string strLink = "";
        private int intInsuranceId = 0;


        public int InsuranceId
        {
            get
            {
                return intInsuranceId;
            }
            set
            {
                intInsuranceId = value;
            }
        }


        public string CaptionName
        {
            get
            {
                return strLink;
            }
            set
            {
                strLink = value;
            }
        }
        //Property of storing the file name of attachment
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        //Method of storing actual file name of attachment 
        public string ActualFileName
        {
            get
            {
                return strActualFileName;
            }
            set
            {
                strActualFileName = value;
            }
        }
        //Method of storing Slnumber of Lead attachment
        public int AttchmntSlNumber
        {
            get
            {
                return intAttchmntSlNumber;
            }
            set
            {
                intAttchmntSlNumber = value;
            }
        }
        public int PictureId
        {
            get
            {
                return intPictureId;
            }
            set
            {
                intPictureId = value;
            }
        }
    }
    public class InsuranceTemplateDetail
    {
        private int intNotTempId = 0;
        private int intTempDetailId = 0;
        private int intTemplateDetStatus = 0;
        private int intTempDetPeriod = 0;
        private int intTempDetailPeriodCount = 0;
        private int intIsDashBoard = 0;
        private int intIsEmail = 0;

        //Method for storing notification template.
        public int NotTempId
        {
            get
            {
                return intNotTempId;
            }
            set
            {
                intNotTempId = value;
            }
        }
        //Method for storing is mail or not.
        public int IsEmail
        {
            get
            {
                return intIsEmail;
            }
            set
            {
                intIsEmail = value;
            }
        }
        //Method for storing dashboard or not.
        public int IsDashBoard
        {
            get
            {
                return intIsDashBoard;
            }
            set
            {
                intIsDashBoard = value;
            }
        }
        //Method for storing template detail period count.
        public int TempDetailPeriodCount
        {
            get
            {
                return intTempDetailPeriodCount;
            }
            set
            {
                intTempDetailPeriodCount = value;
            }
        }
        //Method for storing template detail period.
        public int TempDetPeriod
        {
            get
            {
                return intTempDetPeriod;
            }
            set
            {
                intTempDetPeriod = value;
            }
        }
        //Method for storing template detail status id.
        public int TemplateDetStatus
        {
            get
            {
                return intTemplateDetStatus;
            }
            set
            {
                intTemplateDetStatus = value;
            }
        }
        //Method for storing template detail id.
        public int TempDetailId
        {
            get
            {
                return intTempDetailId;
            }
            set
            {
                intTempDetailId = value;
            }
        }
    }

    public class InsuranceTemplateAlert
    {
        private int intNotTempId = 0;
        private int intTemplateAlertId = 0;
        private int intTemplateAlertOptId = 0;
        private int intTemplateWhoNotifyId = 0;
        private string strTemplateNotifyWhoMail = "";

        private int intTempDetailId = 0;
        private int intTemplateDetStatus = 0;
        private int intTempDetPeriod = 0;
        private int intTempDetailPeriodCount = 0;
        private int intIsDashBoard = 0;
        private int intIsEmail = 0;

        private int intEmailSendStatus = 0;

        public int EmailSendStatus
        {
            get { return intEmailSendStatus; }
            set { intEmailSendStatus = value; }
        }

        //Method for storing is mail or not.
        public int IsEmail
        {
            get
            {
                return intIsEmail;
            }
            set
            {
                intIsEmail = value;
            }
        }
        //Method for storing dashboard or not.
        public int IsDashBoard
        {
            get
            {
                return intIsDashBoard;
            }
            set
            {
                intIsDashBoard = value;
            }
        }
        //Method for storing template detail period count.
        public int TempDetailPeriodCount
        {
            get
            {
                return intTempDetailPeriodCount;
            }
            set
            {
                intTempDetailPeriodCount = value;
            }
        }
        //Method for storing template detail period.
        public int TempDetPeriod
        {
            get
            {
                return intTempDetPeriod;
            }
            set
            {
                intTempDetPeriod = value;
            }
        }
        //Method for storing notification mail id.
        public string TemplateNotifyWhoMail
        {
            get
            {
                return strTemplateNotifyWhoMail;
            }
            set
            {
                strTemplateNotifyWhoMail = value;
            }
        }
        //Method for storing id who get notify.
        public int TemplateWhoNotifyId
        {
            get
            {
                return intTemplateWhoNotifyId;
            }
            set
            {
                intTemplateWhoNotifyId = value;
            }
        }
        //Method for storing Who will get alert .
        public int TemplateAlertOptId
        {
            get
            {
                return intTemplateAlertOptId;
            }
            set
            {
                intTemplateAlertOptId = value;
            }
        }
        //Method for storing template alert id.
        public int TemplateAlertId
        {
            get
            {
                return intTemplateAlertId;
            }
            set
            {
                intTemplateAlertId = value;
            }
        }

        //Method for storing notification template.
        public int NotTempId
        {
            get
            {
                return intNotTempId;
            }
            set
            {
                intNotTempId = value;
            }
        }
    }

}
