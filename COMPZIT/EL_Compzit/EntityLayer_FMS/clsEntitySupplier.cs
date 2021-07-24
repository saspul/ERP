using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
   public class clsEntitySupplier
    {

        private int intLedgerId = 0;
        private string strLedgerName = null;
        private int intCurrencyId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strLedgerAddess = null;
        private decimal decCreditLimit = 0;
        private int intDays = 0;
        private int intLdgerSts = 0;
        private int intLdgerID = 0;
        private string strLedgerAddess2 = null;
        private string strLedgerAddess3 = null;
        private string strContact = null;
        private int intVendrCatgry = 0;
        private decimal decRating = 0;


        public decimal Rating
        {
            get
            {
                return decRating;
            }

            set
            {
                decRating = value;
            }
        }
        public int VendorCatgry
        {
            get
            {
                return intVendrCatgry;
            }

            set
            {
                intVendrCatgry = value;
            }
        }
        public string ContactNo
        {
            get
            {
                return strContact;
            }

            set
            {
                strContact = value;
            }
        }
        public string AddessTwo
        {
            get
            {
                return strLedgerAddess2;
            }

            set
            {
                strLedgerAddess2 = value;
            }
        }
        public string AddessThree
        {
            get
            {
                return strLedgerAddess3;
            }

            set
            {
                strLedgerAddess3 = value;
            }
        }

        public int LedgerId
        {
            get
            {
                return intLdgerID;
            }

            set
            {
                intLdgerID = value;
            }
        }
        public int LedgerSts
        {
            get
            {
                return intLdgerSts;
            }

            set
            {
                intLdgerSts = value;
            }
        }
        public int Days
        {
            get
            {
                return intDays;
            }

            set
            {
                intDays = value;
            }
        }
       
        public decimal CreditLimit
        {
            get
            {
                return decCreditLimit;
            }

            set
            {
                decCreditLimit = value;
            }
        }



       


        public string Addess
        {
            get
            {
                return strLedgerAddess;
            }

            set
            {
                strLedgerAddess = value;
            }
        }

       
       


        //Method of storing id of Category 
        public int SupplierId
        {
            get
            {
                return intLedgerId;
            }
            set
            {
                intLedgerId = value;
            }
        }
        //Method of storing Category  name
        public string SupplierName
        {
            get
            {
                return strLedgerName;
            }

            set
            {
                strLedgerName = value;
            }
        }
       
        //Method of storing id of Main Category 
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }
        //Method of storing id of organisation
        public int Org_Id
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
        //Method of storing id of corporate office
        public int Corp_Id
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
        //Method of storing Category status
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
        //Method of store the userid
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
        //Method of storing the date when event occurs
        public DateTime D_Date
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
        //Method of storing the cancel reason
        public string Cancel_Reason
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



    }

   public class clsEntitySupplierContact
   {
       private string strContactName = "";
       private string strContactAddress = "";
       private string strContactMobile = "";
       private string strContactPhone = "";
       private string strContactWebsite = "";
       private string strContactEmail = "";

       public string ContactEmail
       {
           get
           {
               return strContactEmail;
           }

           set
           {
               strContactEmail = value;
           }
       }
       public string ContactWebsite
       {
           get
           {
               return strContactWebsite;
           }

           set
           {
               strContactWebsite = value;
           }
       }
       public string ContactPhone
       {
           get
           {
               return strContactPhone;
           }

           set
           {
               strContactPhone = value;
           }
       }
       public string ContactMobile
       {
           get
           {
               return strContactMobile;
           }

           set
           {
               strContactMobile = value;
           }
       }
       public string ContactAddress
       {
           get
           {
               return strContactAddress;
           }

           set
           {
               strContactAddress = value;
           }
       }
       public string ContactName
       {
           get
           {
               return strContactName;
           }

           set
           {
               strContactName = value;
           }
       }


   }
}
