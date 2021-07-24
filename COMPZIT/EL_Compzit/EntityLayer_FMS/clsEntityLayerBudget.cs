using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
   public class clsEntityLayerBudget
    {
        private int intBudgetId = 0;
        private int intMode = 0;
        private int intYear = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private string strCancelReason = null;
        private string strBudgtName = null;
        private DateTime dToDate;
        private DateTime dFromDate;
        private decimal decTotAmnt = 0;
        private int LedgerCCMode = 0;
        public int LedgerCC_Mode
        {
            get
            {
                return LedgerCCMode;
            }
            set
            {
                LedgerCCMode = value;
            }
        }
        public decimal BudgetTotAmnt
        {
            get
            {
                return decTotAmnt;
            }
            set
            {
                decTotAmnt = value;
            }
        }
        public string BudgtName
        {
            get
            {
                return strBudgtName;
            }
            set
            {
                strBudgtName = value;
            }
        }
       
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }

            set
            {
                dFromDate = value;
            }
        }
        public DateTime BudgetDate
        {
            get
            {
                return dToDate;
            }

            set
            {
                dToDate = value;
            }
        }

        public int BudgetId
        {
            get
            {
                return intBudgetId;
            }
            set
            {
                intBudgetId = value;
            }
        }

        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }
        //Method of storing id of Main Category 
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
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
        public int ConfirmSts
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
   public class clsEntityBudgetLedgerDtl
   {
       private int intBudgetId = 0;
       private int intLedgerId = 0;
       private int intBudgtLedgerId = 0;
       private decimal decTotAmntJan = 0;
       private decimal decTotAmntFeb = 0;
       private decimal decTotAmntMar = 0;
       private decimal decTotAmntApr = 0;
       private decimal decTotAmntMay = 0;
       private decimal decTotAmntJun = 0;
       private decimal decTotAmntJul = 0;
       private decimal decTotAmntAug = 0;
       private decimal decTotAmntSep = 0;
       private decimal decTotAmntOct = 0;
       private decimal decTotAmntNov = 0;
       private decimal decTotAmntDec = 0;
       private int intTabMode = 0;
       private int intMainTabId = 0;
       private string strCancelReason = null;
       private decimal decLedgerTotAmnt = 0;
       public decimal LedgerTotal
       {
           get
           {
               return decLedgerTotAmnt;
           }
           set
           {
               decLedgerTotAmnt = value;
           }
       }
       public string Reason
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
       public int TabMode
       {
           get
           {
               return intTabMode;
           }
           set
           {
               intTabMode = value;
           }
       }
       public int MainTabId
       {
           get
           {
               return intMainTabId;
           }
           set
           {
               intMainTabId = value;
           }
       }
       public decimal TotAmntJan
       {
           get
           {
               return decTotAmntJan;
           }
           set
           {
               decTotAmntJan = value;
           }
       }
       public decimal TotAmntFeb
       {
           get
           {
               return decTotAmntFeb;
           }
           set
           {
               decTotAmntFeb = value;
           }
       }
       public decimal TotAmntMar
       {
           get
           {
               return decTotAmntMar;
           }
           set
           {
               decTotAmntMar = value;
           }
       }
       public decimal TotAmntApr
       {
           get
           {
               return decTotAmntApr;
           }
           set
           {
               decTotAmntApr = value;
           }
       }
       public decimal TotAmntMay
       {
           get
           {
               return decTotAmntMay;
           }
           set
           {
               decTotAmntMay = value;
           }
       }
       public decimal TotAmntJun
       {
           get
           {
               return decTotAmntJun;
           }
           set
           {
               decTotAmntJun = value;
           }
       }
       public decimal TotAmntJul
       {
           get
           {
               return decTotAmntJul;
           }
           set
           {
               decTotAmntJul = value;
           }
       }
       public decimal TotAmntAug
       {
           get
           {
               return decTotAmntAug;
           }
           set
           {
               decTotAmntAug = value;
           }
       }
       public decimal TotAmntSep
       {
           get
           {
               return decTotAmntSep;
           }
           set
           {
               decTotAmntSep = value;
           }
       }
       public decimal TotAmntOct
       {
           get
           {
               return decTotAmntOct;
           }
           set
           {
               decTotAmntOct = value;
           }
       }
       public decimal TotAmntNov
       {
           get
           {
               return decTotAmntNov;
           }
           set
           {
               decTotAmntNov = value;
           }
       }
       public decimal TotAmntDec
       {
           get
           {
               return decTotAmntDec;
           }
           set
           {
               decTotAmntDec = value;
           }
       }

       public int BudgetId
       {
           get
           {
               return intBudgetId;
           }
           set
           {
               intBudgetId = value;
           }
       }
       //Method of storing id of Main Category 
       public int LedgerId
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
       //Method of storing id of organisation
       public int BudgetLedgerId
       {
           get
           {
               return intBudgtLedgerId;
           }
           set
           {
               intBudgtLedgerId = value;
           }
       }

   }
   public class clsEntityBudgetCostCntrDtl
   {
       private int intBudgetId = 0;
       private int intBudgtLedgerId = 0;
       private int intCostCenterId = 0;
       private int intBudgetCostCntrId = 0;
       private string strPurSaleRefNum = null;
       private decimal decTotAmntJan = 0;
       private decimal decTotAmntFeb = 0;
       private decimal decTotAmntMar = 0;
       private decimal decTotAmntApr = 0;
       private decimal decTotAmntMay = 0;
       private decimal decTotAmntJun = 0;
       private decimal decTotAmntJul = 0;
       private decimal decTotAmntAug = 0;
       private decimal decTotAmntSep = 0;
       private decimal decTotAmntOct = 0;
       private decimal decTotAmntNov = 0;
       private decimal decTotAmntDec = 0;
       private int intTabMode = 0;
       private int intMainTabId = 0;
       private int intSubTabId = 0;

       private string strCancelReason = null;
       private decimal decCCTotAmnt = 0;

       public decimal CCTotal
       {
           get
           {
               return decCCTotAmnt;
           }
           set
           {
               decCCTotAmnt = value;
           }
       }
       public string Reason
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
       public decimal TotAmntJan
       {
           get
           {
               return decTotAmntJan;
           }
           set
           {
               decTotAmntJan = value;
           }
       }
       public decimal TotAmntFeb
       {
           get
           {
               return decTotAmntFeb;
           }
           set
           {
               decTotAmntFeb = value;
           }
       }
       public decimal TotAmntMar
       {
           get
           {
               return decTotAmntMar;
           }
           set
           {
               decTotAmntMar = value;
           }
       }
       public decimal TotAmntApr
       {
           get
           {
               return decTotAmntApr;
           }
           set
           {
               decTotAmntApr = value;
           }
       }
       public decimal TotAmntMay
       {
           get
           {
               return decTotAmntMay;
           }
           set
           {
               decTotAmntMay = value;
           }
       }
       public decimal TotAmntJun
       {
           get
           {
               return decTotAmntJun;
           }
           set
           {
               decTotAmntJun = value;
           }
       }
       public decimal TotAmntJul
       {
           get
           {
               return decTotAmntJul;
           }
           set
           {
               decTotAmntJul = value;
           }
       }
       public decimal TotAmntAug
       {
           get
           {
               return decTotAmntAug;
           }
           set
           {
               decTotAmntAug = value;
           }
       }
       public decimal TotAmntSep
       {
           get
           {
               return decTotAmntSep;
           }
           set
           {
               decTotAmntSep = value;
           }
       }
       public decimal TotAmntOct
       {
           get
           {
               return decTotAmntOct;
           }
           set
           {
               decTotAmntOct = value;
           }
       }
       public decimal TotAmntNov
       {
           get
           {
               return decTotAmntNov;
           }
           set
           {
               decTotAmntNov = value;
           }
       }
       public decimal TotAmntDec
       {
           get
           {
               return decTotAmntDec;
           }
           set
           {
               decTotAmntDec = value;
           }
       }
      
       public int TabMode
       {
           get
           {
               return intTabMode;
           }
           set
           {
               intTabMode = value;
           }
       }
       public int MainTabId
       {
           get
           {
               return intMainTabId;
           }
           set
           {
               intMainTabId = value;
           }
       }
       public int SubTabId
       {
           get
           {
               return intSubTabId;
           }
           set
           {
               intSubTabId = value;
           }
       }
      
       public int BudgetCostCntrId
       {
           get
           {
               return intBudgetCostCntrId;
           }
           set
           {
               intBudgetCostCntrId = value;
           }
       }
       public string PurSaleRefNum
       {
           get
           {
               return strPurSaleRefNum;
           }
           set
           {
               strPurSaleRefNum = value;
           }
       }
      


       public int BudgetId
       {
           get
           {
               return intBudgetId;
           }
           set
           {
               intBudgetId = value;
           }
       }
       //Method of storing id of Main Category 
       public int CostCenterId
       {
           get
           {
               return intCostCenterId;
           }
           set
           {
               intCostCenterId = value;
           }
       }
       //Method of storing id of organisation
       public int BudgetLedgerId
       {
           get
           {
               return intBudgtLedgerId;
           }
           set
           {
               intBudgtLedgerId = value;
           }
       }

   }
}
