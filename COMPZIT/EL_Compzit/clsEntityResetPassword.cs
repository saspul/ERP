using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
  public  class clsEntityResetPassword
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private string strUserPsw = "";
        private int intUserId = 0;
        private DateTime dDate;
        private int intPswdTrckUsrId = 0;
        private string strOldUsrPsw = "";

        private string strCommonSearchTerm = "";
        private string strSearchEmployee = "";
        private string strSearchMail = "";
        private string strSearchDepartment = "";
        private string strSearchDesignation = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchEmployee
        {
            get
            {
                return strSearchEmployee;
            }
            set
            {
                strSearchEmployee = value;
            }
        }
        public string SearchMail
        {
            get
            {
                return strSearchMail;
            }
            set
            {
                strSearchMail = value;
            }
        }
        public string SearchDepartment
        {
            get
            {
                return strSearchDepartment;
            }
            set
            {
                strSearchDepartment = value;
            }
        }
        public string SearchDesignation
        {
            get
            {
                return strSearchDesignation;
            }
            set
            {
                strSearchDesignation = value;
            }
        }
        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------
        //Method of storing corporate office id
        public int CorpOfficeId
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


        // This is the property definition for storing Id of Orgaisation .
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
        // This is the property definition for storing Password of the User .
        public string UserPsw
        {
            get
            {
                return strUserPsw;
            }
            set
            {
                strUserPsw = value;
            }
        }
        // This is the property definition for storing Id of User for reseting.
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
        //Method of keeping date of the process.
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
        //method for storing id of user who changes the password
        public int PaswdTrackUsrId
        {
            get
            {
                return intPswdTrckUsrId;
            }
            set
            {
                intPswdTrckUsrId = value;
            }
        }
        // This is the property definition for storing old Password of the User .
        public string UserOldPsw
        {
            get
            {
                return strOldUsrPsw;
            }
            set
            {
                strOldUsrPsw = value;
            }
        }
    }
}
