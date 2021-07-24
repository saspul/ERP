using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayerNoticePeriod
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intNoticePrdId = 0;
        private int intNoticePrdDays = 0;
        private int intNoticePrdSts = 0;
        private int intDesgId = 0;
        private string strCancelResn = "";
        private DateTime dUserDate;
        private int intCancelSts = 0;
        private int intDesignationTypeId = 0;
        private char charDsgControl;


        public char DsgControl
        {
            get
            {
                return charDsgControl;
            }
            set
            {
                charDsgControl = value;
            }
        }
        public int DesignationTypeId
        {
            get
            {
                return intDesignationTypeId;
            }
            set
            {
                intDesignationTypeId = value;
            }
        }
        public int NoticePrdDays
        {
            get
            {
                return intNoticePrdDays;
            }
            set
            {
                intNoticePrdDays = value;
            }
        }

        public int CancelStatus
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
        public string CnclReason
        {
            get
            {
                return strCancelResn;
            }
            set
            {
                strCancelResn = value;
            }
        }
      
        public DateTime UserDate
        {
            get
            {
                return dUserDate;
            }
            set
            {
                dUserDate = value;
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
        public int NoticePrdId
        {
            get
            {
                return intNoticePrdId;
            }
            set
            {
                intNoticePrdId = value;
            }
        }

        public int Status
        {
            get
            {
                return intNoticePrdSts;
            }
            set
            {
                intNoticePrdSts = value;
            }
        }
        public int DesgntnId
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

    }
}
