using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityHelpDoc
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intAppId = 0;
        private string strPageURL = "";
        private string strFullPageURL = "";
        private int intUserRolId = 0;
        private int intParentId = 0;

        private int intPriority = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intSectionId = 0;
        private int intParentSectionId = 0;
        private string strCancelReason = "";
        private int intMasterRefId = 0;
        private string strSectionName = "";
        private int intLanguageId = 0;
        private int intHelpDocDtlsId = 0;
        private int intHelpDocType = 0;
        private string strControlId = "";
        private int intHelpDocDtlsRefId = 0;
        private string strTitle = "";
        private string strDescription = "";
        private string strActionMode = "";

        private string strSearchString = "";

        public string SearchString
        {
            get
            {
                return strSearchString;
            }
            set
            {
                strSearchString = value;
            }
        }


        public string FullPageURL
        {
            get
            {
                return strFullPageURL;
            }
            set
            {
                strFullPageURL = value;
            }
        }

        public string ActionMode
        {
            get
            {
                return strActionMode;
            }
            set
            {
                strActionMode = value;
            }
        }


        public int Priority
        {
            get
            {
                return intPriority;
            }
            set
            {
                intPriority = value;
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


        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }

        public string Title
        {
            get
            {
                return strTitle;
            }
            set
            {
                strTitle = value;
            }
        }
        public string ControlId
        {
            get
            {
                return strControlId;
            }
            set
            {
                strControlId = value;
            }
        }

        public string SectionName
        {
            get
            {
                return strSectionName;
            }
            set
            {
                strSectionName = value;
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

        public int HelpDocDtlsRefId
        {
            get
            {
                return intHelpDocDtlsRefId;
            }
            set
            {
                intHelpDocDtlsRefId = value;
            }
        }

        public int HelpDocType
        {
            get
            {
                return intHelpDocType;
            }
            set
            {
                intHelpDocType = value;
            }
        }
        public int HelpDocDtlsId
        {
            get
            {
                return intHelpDocDtlsId;
            }
            set
            {
                intHelpDocDtlsId = value;
            }
        }

        public int LanguageId
        {
            get
            {
                return intLanguageId;
            }
            set
            {
                intLanguageId = value;
            }
        }

        public int MasterRefId
        {
            get
            {
                return intMasterRefId;
            }
            set
            {
                intMasterRefId = value;
            }
        }

        public int ParentSectionId
        {
            get
            {
                return intParentSectionId;
            }
            set
            {
                intParentSectionId = value;
            }
        }
        public int SectionId
        {
            get
            {
                return intSectionId;
            }
            set
            {
                intSectionId = value;
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
        public int UserRolId
        {
            get
            {
                return intUserRolId;
            }
            set
            {
                intUserRolId = value;
            }
        }

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
        public int AppId
        {
            get
            {
                return intAppId;
            }
            set
            {
                intAppId = value;
            }
        }

        public string PageURL
        {
            get
            {
                return strPageURL;
            }
            set
            {
                strPageURL = value;
            }
        }

    }
}
