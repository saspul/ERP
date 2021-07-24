using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_GMS
{
    public class classEntityLayerNotifi_Temp
    {

        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;
        private int intCancelStatus = 0;

        private int intNotTempId = 0;
        private int intNotTypeId = 0;
        private int intTempTypeId = 0;
        private int intDefaultOrNot = 0;

        private int intTempDetailId = 0;
        private int intTemplateDetStatus = 0;
        private int intTempDetPeriod = 0;
        private int intTempDetailPeriodCount = 0;
        private int intIsDashBoard = 0;
        private int intIsEmail = 0;

        private int intTemplateAlertId = 0;
        private int intTemplateAlertOptId = 0;
        private int intTemplateWhoNotifyId = 0;


        private string strTemplateName = "";
        private string strTemplateNotifyWhoMail = "";
        private string strCancelReason = "";


        //Method for storing Cancel Reason.
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
        //Method for storing template notify Mail.
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
        //Method for storing template name.
        public string TemplateName
        {
            get
            {
                return strTemplateName;
            }
            set
            {
                strTemplateName = value;
            }
        }
        //Method for storing who will notify id.
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
        //Method for storing template alert option id.
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
        //Method for storing default type id.
        public int DefaultOrNot
        {
            get
            {
                return intDefaultOrNot;
            }
            set
            {
                intDefaultOrNot = value;
            }
        }
        //Method for storing notification type id.
        public int TempTypeId
        {
            get
            {
                return intTempTypeId;
            }
            set
            {
                intTempTypeId = value;
            }
        }
        //Method for storing notification type id.
        public int NotTypeId
        {
            get
            {
                return intNotTypeId;
            }
            set
            {
                intNotTypeId = value;
            }
        }
        //Method for storing template id.
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
        //Method for storing status id.
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
        //Method for storing organistion id.
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
    }



    public class NotificationTemplateDetail
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

    public class NotificationTemplateAlert
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
