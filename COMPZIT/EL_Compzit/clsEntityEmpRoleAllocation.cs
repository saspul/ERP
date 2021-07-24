using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
  public  class clsEntityEmpRoleAllocation
    {
        private int intEmpRoleId = 0;
        private int intDesgTypeId = 0;
        private int intJobroleId = 0;
        private int intEmpId = 0;
        private int intNextId = 0;
        private int intStatus = 0;
        private int intAllocateAll = 0;
        private int intDsgPrimary = 0;
        private int intUserId = 0;
        private int intOrgId = 0;
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
        //----------------Pageination--------------------


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
        //methode of storing designation id
        public int DesgId
        {
            get
            {
                return intDesgTypeId;
            }
            set
            {
                intDesgTypeId = value;
            }
        }

        //methode of storing jobrole id
        public int JobroleId
        {
            get
            {
                return intJobroleId;
            }
            set
            {
                intJobroleId = value;
            }
        }

        //methode of storing employee id
        public int EmployeeId
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
        // This is the property definition for storing Id of Employee role
        public int EmployeeRoleId
        {
            get
            {
                return intEmpRoleId;
            }
            set
            {
                intEmpRoleId = value;
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

      

        // This is the property definition for storing Status .
        public int EmpRoleStatusId
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
       
        // This is the property definition for storing UserId of the User logined.
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
        // This is the property definition for storing Cancelation reason .
        public string CancelReason
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
        public DateTime Date
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
  public class clsEntityLayerEmployeeRole
  {
      private int intUsrole_Id = 0;
      private int intParent_Id = 0;
      private int intRoot_Id = 0;
      private int intLvl = 0;
      private string strChildUsrole_Id = "";
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
  public class clsEntityLayerEmployeeAppRole
  {
      private int intDsgnAppRole_Id = 0;
      private int intDsgn_Id = 0;
      private int intApp_Id = 0;

      // This is the property definition for storing DSGNUSROL Id for adding to GN_DSGN_APP_ROLES table.
      public int EmpAppRole_Id
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
      public int EmpRole_Id
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
