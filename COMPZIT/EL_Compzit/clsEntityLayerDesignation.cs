using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityLayerDesignation
    {
        private int intDesignationId = 0;

        private  int intNextId = 0;
        private int intDesignationTypeId = 0;
        private int inttype = 0;   //emp25
        private int intDesignationStatus = 0;
        private int intAllocateAll = 0;
        //Started:-EVM-0009
        private int intAllocateAllUsr = 0;
        //Stopped
        private string strDesignationName = "";
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
        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        private string strSearchDesign = "";
        public string SearchDesign
        {
            get
            {
                return strSearchDesign;
            }
            set
            {
                strSearchDesign = value;
            }
        }
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
        public string SearchName
        {
            get
            {
                return strSearchName;
            }
            set
            {
                strSearchName = value;
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
        //Started:-EVM-0009
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
        public int Type
        {
            get
            {
                return inttype;
            }
            set
            {
                inttype = value;
            }
        }

        // This is the property definition for storing Status of Designation Master.
        public int DesignationStatus
        {
            get
            {
                return intDesignationStatus;
            }
            set
            {
                intDesignationStatus = value;
            }
        }
        // This is the property definition for storing  Name of Designation .
        public string DesignationName
        {
            get
            {
                return strDesignationName;
            }
            set
            {
                strDesignationName = value;
            }
        }
        // This is the property definition for storing UserId of the User logined.
        public int DesignationUserId
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
    public class clsEntityLayerDesignationRole
    {
        private int intUsrole_Id = 0;
        private int intParent_Id = 0;
        private int intRoot_Id = 0;
        private int intLvl = 0;
        private string strChildUsrole_Id ="";
        // This is the property definition for storing USROL Id for adding to GN_DSGN_ROLES table.
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
        // This is the property definition for storing USROL Id for adding to GN_DSGN_ROLES table.
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
        // This is the property definition for storing USROL_PARENT_ID 
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
        // This is the property definition for storing USROL_ROOT_ID 
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
        // This is the property definition for storing USROL_LVL
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
    public class clsEntityLayerDesignationAppRole
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
    //Started:-EVM-0009
    // This class will be used for storing Leave Type information.
    public class clsEntityLayerDesignationLeaveType
    {
        private int intDsgnLeaveType_Id = 0;
        private int intDsgtn_Id = 0;
        private int intLeaveType_Id = 0;

        // This is the property definition for storing DSGNUSROL Id for adding to GN_DSGN_APP_ROLES table.
        public int DsgnLeaveType_Id
        {
            get
            {
                return intDsgnLeaveType_Id;
            }
            set
            {
                intDsgnLeaveType_Id = value;
            }
        }
        // This is the property definition for storing DSGN_ID 
        public int Dsgn_Id
        {
            get
            {
                return intDsgtn_Id;
            }
            set
            {
                intDsgtn_Id = value;
            }
        }
        // This is the property definition for storing APP_ID 
        public int Leave_Type_Id
        {
            get
            {
                return intLeaveType_Id;
            }
            set
            {
                intLeaveType_Id = value;
            }
        }

    }

     public class clsEntityLayerDesignationWelfareSrvc   //EMP0025
    {
        private int intDsg_Id = 0;
        private int intWelfare_Id = 0;
      
        private decimal decQntity = 0;
        private int intWelfrSub_Id = 0;
        private string strWlfrSubId = "";
        private int intchkSts = 0;
        private int intcheckboxsts = 0;
        private decimal decActQty = 0;
        public decimal ActQty
        {
            get
            {
                return decActQty;
            }
            set
            {
                decActQty = value;
            }
        }
        public int checkboxsts
        {
            get
            {
                return intcheckboxsts;
            }
            set
            {
                intcheckboxsts = value;
            }
        }
        public int chkSts
        {
            get
            {
                return intchkSts;
            }
            set
            {
                intchkSts = value;
            }
        }
        public string WelfSub_Id
        {
            get
            {
                return strWlfrSubId;
            }
            set
            {
                strWlfrSubId = value;
            }
        }

        public int WelfrSub_Id
        {
            get
            {
                return intWelfrSub_Id;
            }
            set
            {
                intWelfrSub_Id = value;
            }
        }
        public int Dsg_Id
        {
            get
            {
                return intDsg_Id;
            }
            set
            {
                intDsg_Id = value;
            }
        }

        public int  Welfare_Id
        {
            get
            {
                return intWelfare_Id;
            }
            set
            {
                intWelfare_Id = value;
            }
        }
        public decimal Qty
        {
            get
            {
                return decQntity;
            }
            set
            {
                decQntity = value;
            }
        }
    }
    //Stopped
}
