using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE
namespace EL_Compzit
{
    public class clsEntityLayerLogin
    {
        private string strUserId="";
        private int intUserId;
        private int intUsroleId;
        private string strUserEmail="";
        private string strUserPwd="";
        private int intWorkStatnId;
        private char charAppType ;
        private string strEncryptedWrkStnId;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intPremiseId = 0;
        private int intCmpAppId = 0;
        private int intDsgnTypId = 0;

        private int intFrameworkTypId = 0;
        private int intFrameworkId = 0;
        public int FrameworkTypId
        {
            get
            {
                return intFrameworkTypId;
            }
            set
            {
                intFrameworkTypId = value;
            }
        }
        public int FrameworkId
        {
            get
            {
                return intFrameworkId;
            }
            set
            {
                intFrameworkId = value;
            }
        }

        //Method of storing App Id
        public int Cmp_AppId
        {
            get
            {
                return intCmpAppId;
            }
            set
            {
                intCmpAppId = value;
            }
        }
        //Method of storing Premise id
        public int PremiseId
        {
            get
            {
                return intPremiseId;
            }
            set
            {
                intPremiseId = value;
            }
        }
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
        //This method for storing Encrypted WrkStn Id.
        public string EncryptedWrkStnId
        {
            get
            {
                return strEncryptedWrkStnId;
            }
            set
            {
                strEncryptedWrkStnId = value;
            }
        }
        //This method for storing User Email id from login.
        public string UserEmail
        {
            get
            {
                return strUserEmail;
            }
            set
            {
                strUserEmail = value;
            }
        }
        //This method for storing   Application type ie if its Web Application OR Desktop Application id from login.
        public char AppType
        {
            get
            {
                return charAppType;
            }
            set
            {
                charAppType = value;
            }
        }

        //This method for storing user password from login.
        public string UserPwd
        {
            get
            {
                return strUserPwd;
            }
            set
            {
                strUserPwd = value;
            }
        }

        //This method for storing User id from login.
        public string UserId
        {
            get
            {
                return strUserId;
            }
            set
            {
                strUserId = value;
            }
        }
        //This method for storing UserRole id from login.
        public int UsroleId
        {
            get
            {
                return intUsroleId;
            }
            set
            {
                intUsroleId = value;
            }
        }
        //This method for storing User id from login.
        public int UserIdInt
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
        //This method for storing Work id .
        public int WorkStatnId
        {
            get
            {
                return intWorkStatnId;
            }
            set
            {
                intWorkStatnId = value;
            }
        }
        //This method for storing Dsgn Type Id .
        public int DsgnTypId
        {
            get
            {
                return intDsgnTypId;
            }
            set
            {
                intDsgnTypId = value;
            }
        }
    }
}
