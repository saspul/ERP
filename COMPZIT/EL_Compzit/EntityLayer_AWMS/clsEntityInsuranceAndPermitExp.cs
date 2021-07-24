using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityInsuranceAndPermitRenewal
    {
        private int intVehId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private string strInsDate = null;
        private DateTime strOldDate ;
        private int intRenewalId = 0;
        private string strVehNmber =null;
        private string strVehClass = null;
        private string intOldNmbr = null;
        private string intNEwNmbr = null;
        private DateTime strNewDate;
        private int intInsrnPrvdr = 0;
        private int intNewInsrnPrvdr = 0;
        private int intDisplayMode = 0;
        private DateTime strFromDate;
        private DateTime strToDate;
        private int intInsrnceRnwlId = 0;
        private int intPermitRnwlId = 0;
        private string strCancelreason = "";
        private int intCancelCheck = 0;
        private int intStatusForNew = 0;
        private int intNextNumInsure = 0;
        private int intNextNumPer = 0;
        private decimal intNewInsureAmount = 0;
        private decimal intOldInsureAmount = 0;
        private string strOldFileName = "";
        private string strNewFileName = "";
        private int intInsrnCovrgTyp = 0;
        private int intNewInsrnCovrgTyp = 0;
        private int intMode = 0;

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
        //methode of storing insurance date
        public string NewFileName
        {
            get
            {
                return strNewFileName;
            }
            set
            {
                strNewFileName = value;
            }
        }
        //methode of storing insurance date
        public string OldFileName
        {
            get
            {
                return strOldFileName;
            }
            set
            {
                strOldFileName = value;
            }
        }
        //for storinginsurance amount
        public decimal OldInsureAmount
        {
            get
            {
                return intOldInsureAmount;
            }
            set
            {
                intOldInsureAmount = value;
            }
        }
        //for storinginsurance amount
        public decimal NewInsureAmount
        {
            get
            {
                return intNewInsureAmount;
            }
            set
            {
                intNewInsureAmount = value;
            }
        }
        //for storing next number
        public int NextNumInsure
        {
            get
            {
                return intNextNumInsure;
            }
            set
            {
                intNextNumInsure = value;
            }
        }
        //for storing value next number
        public int NextNumPer
        {
            get
            {
                return intNextNumPer;
            }
            set
            {
                intNextNumPer = value;
            }
        }
        //for storing value for cancel check
        public int StatusForNew
        {
            get
            {
                return intStatusForNew;
            }
            set
            {
                intStatusForNew = value;
            }
        }
        //for storing value for cancel check
        public int CancelCheck
        {
            get
            {
                return intCancelCheck;
            }
            set
            {
                intCancelCheck = value;
            }
        }
        //method of storing cancel reason
        public string Cancelreason
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
        //method of storing insurance renewal id
        public int InsrnceRnwlId
        {
            get
            {
                return intInsrnceRnwlId;
            }
            set
            {
                intInsrnceRnwlId = value;
            }
        }
        //method of storing permit renewal id
        public int PermitRnwlId
        {
            get
            {
                return intPermitRnwlId;
            }
            set
            {
                intPermitRnwlId = value;
            }
        }
        //method of storing to date
        public DateTime FromDate
        {
            get
            {
                return strFromDate;
            }
            set
            {
                strFromDate = value;
            }
        }
        //method of storing to date
        public DateTime ToDate
        {
            get
            {
                return strToDate;
            }
            set
            {
                strToDate = value;
            }
        }
        //method of storing Display mode id
        public int DisplayMode
        {
            get
            {
                return intDisplayMode;
            }
            set
            {
                intDisplayMode = value;
            }
        }
        //method of storing the Vehicle id
        public int VehicleId
        {
            get
            {
                return intVehId;
            }
            set
            {
                intVehId = value;
            }
        }

        //method of storing the Insurance id
        public int InsPrvdrId
        {
            get
            {
                return intInsrnPrvdr;
            }
            set
            {
                intInsrnPrvdr = value;
            }
        }

        //method of storing the New Insurance provider id
        public int NewInsPrvdrId
        {
            get
            {
                return intNewInsrnPrvdr;
            }
            set
            {
                intNewInsrnPrvdr = value;
            }
        }


        //method of storing the organisation id
        public int Organisation_Id
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

        //method of storing corporate office id
        public int Corporate_Id
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

        //method of storing the user id
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

        //methode of storing insurance date
        public string InsuDate
        {
            get
            {
                return strInsDate;
            }
            set
            {
                strInsDate = value;
            }
        }

        //method of storing the permit date
        public DateTime OldDate
        {
            get
            {
                return strOldDate;
            }
            set
            {
                strOldDate = value;
            }
        }
        //methode of vehicle renewal id storing
        public int RenewalId
        {
            get
            {
                return intRenewalId;
            }
            set
            {
                intRenewalId = value;
            }
        }

        //method for storing vehicle number
        public string VehiclNmbr
        {
            get
            {
                return strVehNmber;
            }
            set
            {
                strVehNmber = value;
            }
        }

        //method for storing vehicle class
        public string VehclClass
        {
            get
            {
                return strVehClass;
            }
            set
            {
                strVehClass = value;
            }
        }

        //method for storing old insurance/permit number
        public string OldNumber
        {
            get
            {
                return intOldNmbr;
            }
            set
            {
                intOldNmbr = value;
            }
        }

        //method for storing new insurance/permit number

        public string NewNumber
        {
            get
            {
                return intNEwNmbr;
            }
            set
            {
                intNEwNmbr = value;
            }
        }

        //method for storing new date

        public DateTime NewDate
        {

            get
            {
                return strNewDate;
            }
            set
            {
                strNewDate = value;

            }
        }
        //method of storing the old category type id
        public int InsCovrgTypId
        {
            get
            {
                return intInsrnCovrgTyp;
            }
            set
            {
                intInsrnCovrgTyp = value;
            }
        }

        //method of storing the New category type id
        public int NewInsCovrgTypId
        {
            get
            {
                return intNewInsrnCovrgTyp;
            }
            set
            {
                intNewInsrnCovrgTyp = value;
            }
        }


    }
}