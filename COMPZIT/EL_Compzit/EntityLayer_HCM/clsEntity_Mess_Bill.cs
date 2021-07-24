using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntity_Mess_Bill
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intAccomoDationId = 0;
        private int intMessBillId = 0;
        private int intEmpId = 0;
        private decimal intTotalAmount = 0;
        private int intCancelStatus = 0;
        private DateTime dtFromdate;
        private DateTime dtTodate;
        private string strcancelReason = "";

        private string strSearchString = "";

        private int intConfirmStatus = 0;
        public int ConfirmStatus
        {
            get
            {
                return intConfirmStatus;
            }
            set
            {
                intConfirmStatus = value;
            }
        }
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

        //method for storing cancel reason
        public int CancelStatus
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
        //method for storing cancel reason
        public string cancelReason
        {
            get
            {
                return strcancelReason;
            }
            set
            {
                strcancelReason = value;
            }
        }
        //method for storing mess bill id
        public decimal TotalAmount
        {
            get
            {
                return intTotalAmount;
            }
            set
            {
                intTotalAmount = value;
            }
        }
        //method for storing mess bill id
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
        //method for storing mess bill id
        public int MessBillId
        {
            get
            {
                return intMessBillId;
            }
            set
            {
                intMessBillId = value;
            }
        }
        //method for storing bill id
        public int AccomoDationId
        {
            get
            {
                return intAccomoDationId;
            }
            set
            {
                intAccomoDationId = value;
            }
        }
        //method for storing bill id
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

        //Method for storing the to date.
        public DateTime Todate
        {
            get
            {
                return dtTodate;
            }
            set
            {
                dtTodate = value;
            }
        }
        //Method for storing the from date.
        public DateTime Fromdate
        {
            get
            {
                return dtFromdate;
            }
            set
            {
                dtFromdate = value;
            }
        }
    }
   public class clsEntity_Mess_Bill_EMP_DTLS
   {

       private int intEmpId = 0;
       private int intMessEmpDys = 0;
       private Decimal intMessEmpAmt;

       private int intChangeSts = 0;
       private int intMessMonth = 0;
       private int intMessYear = 0;
       public int MessMonth
       {
           get
           {
               return intMessMonth;
           }
           set
           {
               intMessMonth = value;
           }
       }
       public int MessYear
       {
           get
           {
               return intMessYear;
           }
           set
           {
               intMessYear = value;
           }
       }

       public int ChangeSts
       {
           get
           {
               return intChangeSts;
           }
           set
           {
               intChangeSts = value;
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

       public int MessEmpDys
       {
           get
           {
               return intMessEmpDys;
           }
           set
           {
               intMessEmpDys = value;
           }
       }
       public Decimal MessEmpAmt
       {
           get
           {
               return intMessEmpAmt;
           }
           set
           {
               intMessEmpAmt = value;
           }
       }
   }
}
