using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.HCM
{
   public class clsEntity_Pay_Grade_Master
    {

       private int intOrgid = 0;
       private int intCorpOffice = 0;
       private int intUserId = 0;
       private int intPayGrdStatus = 0;
       private int intAdditnStatus = 0;
       private int intDedctnStatus=0;
       private int intRestrctRange = 0;
       private int intRestrctLimit = 0;
       private int intSalaryAllwnceId = 0;
       private int intSlaryDedctnId = 0;
       private int intPercOrAmountChk = 0;
       private int intBasicOrTotalAmtChk = 0;
       private int intNextIdForPayGrade = 0;
       private int intcurrcyId = 0;
       private int intCancel_Status = 0;
       private int intAlownceId = 0;
       private int intDedctnId = 0;

       private string strPayGrdName = "";
       private string strCancel_reason = "";
       

      
       private decimal decAmountRangeFrm = 0;
       private decimal decAmountRangeTo = 0;
       private decimal decPercentge = 0;
       private DateTime ddate = new DateTime();

       private decimal decPercentgeTo = 0;
       private int intRestrctLimitPerc = 0;

       public decimal PercentgeTo
       {
           get
           {
               return decPercentgeTo;
           }
           set
           {
               decPercentgeTo = value;
           }
       }

       public int RestrctLimitPerc
       {
           get
           {
               return intRestrctLimitPerc;
           }
           set
           {
               intRestrctLimitPerc = value;
           }
       }


       public int DedctnId
       {
           get
           {
               return intDedctnId;
           }
           set
           {
               intDedctnId = value;
           }
       }
       public int AlownceId
       {
           get
           {
               return intAlownceId;
           }
           set
           {
               intAlownceId = value;
           }
       }
       public string Cancel_reason
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
       public int currcyId
       {
           get
           {
               return intcurrcyId;
           }
           set
           {
               intcurrcyId = value;
           }
       }
       public string PayGrdName
       {
           get
           {
               return strPayGrdName;
           }
           set
           {
               strPayGrdName = value;
           }
       }
       public int NextIdForPayGrade
       {
           get
           {
               return intNextIdForPayGrade;
           }
           set
           {
               intNextIdForPayGrade = value;
           }
       }
       public decimal AmountRangeTo
       {
           get
           {
               return decAmountRangeTo;
           }
           set
           {
               decAmountRangeTo = value;
           }
       }
       public decimal Percentge
       {
           get
           {
               return decPercentge;
           }
           set
           {
               decPercentge = value;
           }
       }
       public int BasicOrTotalAmtChk
       {
           get
           {
               return intBasicOrTotalAmtChk;
           }
           set
           {
               intBasicOrTotalAmtChk = value;
           }
       }
       public int PercOrAmountChk
       {
           get
           {
               return intPercOrAmountChk;
           }
           set
           {
               intPercOrAmountChk = value;
           }
       }
       public decimal AmountRangeFrm
       {
           get
           {
               return decAmountRangeFrm;
           }
           set
           {
               decAmountRangeFrm = value;
           }
       }
       public int SlaryDedctnId
       {
           get
           {
               return intSlaryDedctnId;
           }
           set
           {
               intSlaryDedctnId = value;
           }
       }

        public int SalaryAllwnceId
       {
           get
           {
               return intSalaryAllwnceId;
           }
           set
           {
               intSalaryAllwnceId = value;
           }
       }

       public int RestrctLimit
       {
           get
           {
               return intRestrctLimit;
           }
           set
           {
               intRestrctLimit = value;
           }
       }
       public int RestrctRange
       {
           get
           {
               return intRestrctRange;
           }
           set
           {
               intRestrctRange = value;
           }
       }
       public int DedctnStatus
       {
           get
           {
               return intDedctnStatus;
           }
           set
           {
               intDedctnStatus = value;
           }
       }

       public int AdditnStatus
       {
           get
           {
               return intAdditnStatus;
           }
           set
           {
               intAdditnStatus = value;
           }
       }
       public int PayGrdStatus
       {
           get
           {
               return intPayGrdStatus;
           }
           set
           {
               intPayGrdStatus = value;
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
        //Method for storing the date when the event occurs.
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
    }
}
