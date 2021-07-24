using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:05/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
    public class clsEntityCorpDept
    {
        private  string strDeptName = null;
        private  string strCancelreason = null;
        private  int intOrgid = 0;
        private  int intCorpOffice = 0;
        private  DateTime ddate;
        private  int intUserId = 0;
        public  int intStatus = 0;
        private  int? intDeptId = 0;
        private  int intDeptMasterId = 0;
        private int intDepID = 0;
        private int intCancelStatus = 0;
        private int intDivisionId = 0;


        private string strCommonSearchTerm = "";
        private string strSearchDepartment = "";
        private string strSearchMainDepartment = "";
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
        public string SearchMainDepartment
        {
            get
            {
                return strSearchMainDepartment;
            }
            set
            {
                strSearchMainDepartment = value;
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
        //Method for storing Department id .
        public int intDep_Id
        {
            get
            {
                return intDepID;
            }
            set
            {
                intDepID = value;
            }
        }
        //Method for storing Department name
        public string Department_Name
        {
            get
            {
                return strDeptName;
            }
            set
            {
                strDeptName = value;
            }
        }
        //Method for storing Department cancel reason
        public string Department_Cancel_reason
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
        //Method for storing Department id.
        public int? Department_Id
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
            }
        }
        //Method for storing Department master id.
        public int Department_Master_Id
        {
            get
            {
                return intDeptMasterId;
            }
            set
            {
                intDeptMasterId = value;
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
        //Method for storing user the date when the event occurs.
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
        //Method of storing the status of the department
        public int Dept_Status
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
        //method to store the Id of Division
        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        
    }
    public class clsEntityCorpIdListIns
    {
        private int intCorpIdListId =0;
        //Method of storing the of business unit List
        public int CorpIdList
        {
            get
            {
                return intCorpIdListId;
            }
            set
            {
                intCorpIdListId = value;
            }
        }
    }

    public class clsEntityCorpIdListToDel
    {
        private string strCorpIdListToDel = "";
        //Method of storing the of business unit List
        public string CorpIdListToDel
        {
            get
            {
                return strCorpIdListToDel;
            }
            set
            {
                strCorpIdListToDel = value;
            }
        }
    }


    //evm-0023
    public class clsEntityDeptDivListIns
    {
        private int intDeptDivListId =0;
        //Method of storing division List
        public int DeptDivList
        {
            get
            {
                return intDeptDivListId;
            }
            set
            {
                intDeptDivListId = value;
            }
        }
    }
    //evm-0023
    public class clsEntityDeptDivListDel
    {
        private string strDeptDivIdToDel = "";
        //Method of del storing division List
        public string DeptDivIdToDel
        {
            get
            {
                return strDeptDivIdToDel;
            }
            set
            {
                strDeptDivIdToDel = value;
            }
        }
    }
    public class clsEntityLayerDepartmentWelfareSrvc   //EMP0025
    {
        private int intDept_Id = 0;
        private int intWelfare_Id = 0;
        private int intWlfrSub_Id = 0;
        private decimal decQty = 0;
        private decimal decActQty = 0;
        private string strWelfSub_Id = "";
        private int intchkSts = 0;
        private int intcheckboxsts = 0;
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
                return strWelfSub_Id;
            }
            set
            {
                strWelfSub_Id = value;
            }
        }
        public int Dept_Id
        {
            get
            {
                return intDept_Id;
            }
            set
            {
                intDept_Id = value;
            }
        }

        public int Welfare_Id
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
        public int WelfrSub_Id
        {
            get
            {
                return intWlfrSub_Id;
            }
            set
            {
                intWlfrSub_Id = value;
            }
        }
        public decimal Qty
        {
            get
            {
                return decQty;
            }
            set
            {
                decQty = value;
            }
        }
    }
}
