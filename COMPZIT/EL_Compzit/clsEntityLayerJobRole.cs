using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{

    public class clsEntityLayerJobRole
    {

        private int intJobRoleId = 0;

        private int intNextId = 0;
        private int intDesignationId = 0;
        private int intDesignationTypeId = 0;
        private int intJobRoleStatus = 0;
        private int intAllocateAll = 0;
        private int intAllocateAllUsr = 0;
        private string strJobRoleName = "";
        private int intUserId = 0;
        private int intDsgOrgId = 0;
        private int intDsgPrimary = 0;
        private char charDsgControl;
        private string strCnclReason = "";
        private DateTime dateofEvent;
        private int intCorpOfficeId = 0;
        private int intParentId = 0;
        private int intAppId = 0;
        private char charAppType;
        private int intCancelStatus = 0;
        private int intUserLimited = 1;

        //----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearchJOB = "";


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
        public string SearchJOB
        {
            get
            {
                return strSearchJOB;
            }
            set
            {
                strSearchJOB = value;
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

        //This method for storing   Application type ie if its Web Application OR Desktop Application id.
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
        //Method of storing Parent id
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
        //Method of storing App id
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
        //Method of storing corporate office id
        public int CorpOfficeId
        {
            get
            {
                return intCorpOfficeId;
            }
            set
            {
                intCorpOfficeId = value;
            }
        }
        // This is the property definition for storing Id of Designation.
        public int JobRoleId
        {
            get
            {
                return intJobRoleId;
            }
            set
            {
                intJobRoleId = value;
            }
        }
        // This is the property definition if to allocate for all user the updated designation .
        public int AllocateAll
        {
            get
            {
                return intAllocateAll;
            }
            set
            {
                intAllocateAll = value;
            }
        }
        // This is the property definition if to allocate for all user the updated leave type designation .
        public int AllocateAllUsr
        {
            get
            {
                return intAllocateAllUsr;
            }
            set
            {
                intAllocateAllUsr = value;
            }
        }
        //Stopped

        // This is the property definition for storing Next Id of Designation in MASTER_ID_GENERATION table.
        public int NextId
        {
            get
            {
                return intNextId;
            }
            set
            {
                intNextId = value;
            }
        }

        // This is the property definition for storing Designation Type Id of Designation.
        public int DesignationId
        {
            get
            {
                return intDesignationId;
            }
            set
            {
                intDesignationId = value;
            }
        }
        //intDesignationTypeId
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
        // This is the property definition for storing Status of Designation Master.
        public int JobRoleStatus
        {
            get
            {
                return intJobRoleStatus;
            }
            set
            {
                intJobRoleStatus = value;
            }
        }
        // This is the property definition for storing  Name of Job Role .
        public string JobRoleName
        {
            get
            {
                return strJobRoleName;
            }
            set
            {
                strJobRoleName = value;
            }
        }
        // This is the property definition for storing UserId of the User logined.
        public int UserID
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
        // This is the property definition for storing Cancelation reason .
        public string DesignationCancelReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }
        // This is the property definition for storing Date of updation, cancelation and insertion .
        public DateTime DsgnDate
        {
            get
            {
                return dateofEvent;
            }
            set
            {
                dateofEvent = value;
            }
        }
        // This is the property definition for storing Organisation Id of the User logined.
        public int DsgnOrgId
        {
            get
            {
                return intDsgOrgId;
            }
            set
            {
                intDsgOrgId = value;
            }
        }
        // This is the property definition for storing if Designation is Primary or not.
        public int DsgnPrimary
        {
            get
            {
                return intDsgPrimary;
            }
            set
            {
                intDsgPrimary = value;
            }
        }
        // This is the property definition for storing  Control type of Designation .
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
        // This is the property definition for storing if User is Limited or not.
        public int UserLimited
        {
            get
            {
                return intUserLimited;
            }
            set
            {
                intUserLimited = value;
            }
        }

    }
    // This class will be used for storing User Role information.
    public class clsEntityLayerJobRlRole
    {
        private int intUsrole_Id = 0;
        private int intParent_Id = 0;
        private int intRoot_Id = 0;
        private int intLvl = 0;
        private string strChildUsrole_Id = "";
        public string strChildRolId
        {
            get
            {
                return strChildUsrole_Id;
            }
            set
            {
                strChildUsrole_Id = value;
            }
        }
        public int UsrRolId
        {
            get
            {
                return intUsrole_Id;
            }
            set
            {
                intUsrole_Id = value;
            }
        }
        public int UsrRolParentlId
        {
            get
            {
                return intParent_Id;
            }
            set
            {
                intParent_Id = value;
            }
        }
        public int UsrRolRootId
        {
            get
            {
                return intRoot_Id;
            }
            set
            {
                intRoot_Id = value;
            }
        }
        public int UsrRolLevel
        {
            get
            {
                return intLvl;
            }
            set
            {
                intLvl = value;
            }
        }


    }

    // This class will be used for storing Dsgn App Role information.
    public class clsEntityLayerJobRlAppRole
    {
        private int intDsgnAppRole_Id = 0;
        private int intDsgn_Id = 0;
        private int intApp_Id = 0;

        // This is the property definition for storing DSGNUSROL Id for adding to GN_DSGN_APP_ROLES table.
        public int DsgnAppRole_Id
        {
            get
            {
                return intDsgnAppRole_Id;
            }
            set
            {
                intDsgnAppRole_Id = value;
            }
        }
        // This is the property definition for storing DSGN_ID 
        public int Dsgn_Id
        {
            get
            {
                return intDsgn_Id;
            }
            set
            {
                intDsgn_Id = value;
            }
        }
        // This is the property definition for storing APP_ID 
        public int App_Id
        {
            get
            {
                return intApp_Id;
            }
            set
            {
                intApp_Id = value;
            }
        }

    }


}
