using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayer_InterViewPanel
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;
        private int intIntrvPanelId = 0;
        private int intIntervPanelDetailId = 0;
        private int intTemplateId = 0;
        private int intTemplateDetailId = 0;

        private int intManPwrRqstId = 0;


        public int TemplateDetailId
        {
            get
            {
                return intTemplateDetailId;
            }
            set
            {
                intTemplateDetailId = value;
            }
        }
        public int TemplateId
        {
            get
            {
                return intTemplateId;
            }
            set
            {
                intTemplateId = value;
            }
        }
        public int IntervPanelDetailId
        {
            get
            {
                return intIntervPanelDetailId;
            }
            set
            {
                intIntervPanelDetailId = value;
            }
        }
        public int IntrvPanelId
        {
            get
            {
                return intIntrvPanelId;
            }
            set
            {
                intIntrvPanelId = value;
            }
        }
        public int ManPwrRqstId
        {
            get
            {
                return intManPwrRqstId;
            }
            set
            {
                intManPwrRqstId = value;
            }
        }

        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }
        public int Deprt_Id
        {
            get
            {
                return intDeprt_Id;
            }
            set
            {
                intDeprt_Id = value;
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
        public int DivId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
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

    }
    public class clsEntityLayer_InterViewPanel_Dtl
    {

        private int intPanelid = 0;
        private int intPanelDtlId = 0;
        private int intEmpId = 0;
        private int intDfltStsId = 0;
        private int intTempDtlId = 0;
        private int intTempId = 0;
        private int intCorpId = 0;

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
        public int Panelid
        {
            get
            {
                return intPanelid;
            }
            set
            {
                intPanelid = value;
            }
        }
        public int PanelDtlId
        {
            get
            {
                return intPanelDtlId;
            }
            set
            {
                intPanelDtlId = value;
            }
        }
        public int EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        public int DfltStsId
        {
            get
            {
                return intDfltStsId;
            }
            set
            {
                intDfltStsId = value;
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

    }
}
