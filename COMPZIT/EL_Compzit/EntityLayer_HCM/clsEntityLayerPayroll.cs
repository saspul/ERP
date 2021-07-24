using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerPayroll
    {
        private int IntCorp_Id = 0;
        private int IntOrg_Id = 0;
        private int IntUser_id = 0;
        private int IntStatus = 0;
        private int IntMode = 0;
        private string strName = null;
        private DateTime InsDate;
        private DateTime UpdDate;
        private DateTime CnclDate;
        private int IntInsUser_id = 0;
        private int IntUpdUser_id = 0;
        private int IntCnclUser_id = 0;
        private int intCancel_Status = 0;
        private string strCancel_reason = "";
        private string strUpdName = null;
        private int IntPayrl_id = 0;
        private int IntPayrollType = 0;
        //evm-0027


        private int IntDirectPaymentSts = 0;
        private string strCode = null;




        //----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private string strSearchMode = "";
       
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
        public string SearchCode
        {
            get
            {
                return strSearchCode;
            }
            set
            {
                strSearchCode = value;
            }
        }
        
        public string SearchMode
        {
            get
            {
                return strSearchMode;
            }
            set
            {
                strSearchMode = value;
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










        public int DirectPaymentSts
        {
            get
            {
                return IntDirectPaymentSts;
            }
            set
            {
                IntDirectPaymentSts = value;
            }
        }

        public string Code
        {
            get
            {
                return strCode;
            }
            set
            {
                strCode = value;
            }
        }

        private int IntPrimaryStatus = 0;
        public int PrimaryStatus
        {
            get
            {
                return IntPrimaryStatus;
            }
            set
            {
                IntPrimaryStatus = value;
            }
        }

        //end
        public int PayrollType
        {
            get
            {
                return IntPayrollType;
            }
            set
            {
                IntPayrollType = value;
            }
        }
        public int CorpOffice_Id
        {
            get
            {
                return IntCorp_Id;
            }
            set
            {
                IntCorp_Id = value;
            }
        }

        public int Organisation_Id
        {
            get
            {
                return IntOrg_Id;
            }
            set
            {
                IntOrg_Id = value;
            }
        }

        public int User_Id
        {
            get
            {
                return IntUser_id;
            }
            set
            {
                IntUser_id = value;
            }
        }

        public int Status
        {
            get
            {
                return IntStatus;
            }
            set
            {
                IntStatus = value;
            }
        }

        public int Mode
        {
            get
            {
                return IntMode;
            }
            set
            {
                IntMode = value;
            }
        }

        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }

        public DateTime InsDateTime
        {
            get
            {
                return InsDate;
            }
            set
            {
                InsDate = value;
            }
        }
        public DateTime UpdDateTime
        {
            get
            {
                return UpdDate;
            }
            set
            {
                UpdDate = value;
            }
        }
        public DateTime CnclDateTime
        {
            get
            {
                return CnclDate;
            }
            set
            {
                CnclDate = value;
            }

        }
         public int InsUser_Id
        {
            get
            {
                return IntInsUser_id;
            }
            set
            {
                IntUser_id = value;
            }
        }
         public int UpdUser_Id
        {
            get
            {
                return IntUpdUser_id;
            }
            set
            {
                IntUpdUser_id = value;
            }
        }
         public int CnclUser_Id
        {
            get
            {
                return IntCnclUser_id;
            }
            set
            {
                IntCnclUser_id = value;
            }
        }

         public string Cancel_Reason
         {
             get
             {
                 return strCancel_reason;
             }
             set
             {
                 strCancel_reason = value;
             }
         }

         public int Cancel_Status
         {
             get
             {
                 return intCancel_Status;
             }
             set
             {
                 intCancel_Status = value;
             }
         }
         public string UpdName
         {
             get
             {
                 return strUpdName;
             }
             set
             {
                 strUpdName = value;
             }
         }

         public int Payrl_ID
         {
             get
             {
                 return IntPayrl_id;
             }
             set
             {
                 IntPayrl_id = value;
             }
         }

    }

}
