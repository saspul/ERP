using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityChequeTemplate
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private string strCancelReason = null;
        private string strName = null;
        private string strFileName = null;
        private string strActFileName = null;
        private string strActFileNameFi = null;

        private decimal decWidth = 0;
        private decimal decHeight = 0;
        private decimal decPayeeLeft = 0;
        private decimal decPayeeTop = 0;
        private decimal decDateLeft = 0;
        private decimal decDateTop = 0;
        private decimal decAmntWord1Left = 0;
        private decimal decAmntWord1Top = 0;
        private decimal decAmntWord2Left = 0;
        private decimal decAmntWord2Top = 0;
        private decimal decAmntNumLeft = 0;
        private decimal decAmntNumTop = 0;

        private int intcnclStatus = 0;
        private int intcncl_sts = 0;
        private int intTcsId = 0;
        private string strPayeeName = null;
        private string dtPaymentDate = null;
        private string strAmunt_word_one = null;
        private string strAmunt_word_two = null;
        private decimal decAmntNum = 0;

        private int intPrintPosition = 0;

        private int intWordOneLength = 0;
        public int WordOneLength
        {
            get
            {
                return intWordOneLength;
            }
            set
            {
                intWordOneLength = value;
            }
        }
        public int PrintPosition
        {
            get
            {
                return intPrintPosition;
            }
            set
            {
                intPrintPosition = value;
            }
        }


        //methode storing no of floor in the accomodedation
        public string PaymentDate
        {
            get 
            { return dtPaymentDate; 
            }
            set 
            { dtPaymentDate = value; 
            }
        }
        public string PayeeName
        {
            get
            {
                return strPayeeName;
            }
            set
            {
                strPayeeName = value;
            }
        }
        public string Amunt_word_one
        {
            get
            {
                return strAmunt_word_one;
            }
            set
            {
                strAmunt_word_one = value;
            }
        }

        public string Amunt_word_two
        {
            get
            {
                return strAmunt_word_two;
            }
            set
            {
                strAmunt_word_two = value;
            }
        }


        public decimal AmntNum
        {
            get
            {
                return decAmntNum;
            }
            set
            {
                decAmntNum = value;
            }
        }

        public decimal AmntNumLeft
        {
            get
            {
                return decAmntNumLeft;
            }
            set
            {
                decAmntNumLeft = value;
            }
        }
        public decimal AmntNumTop
        {
            get
            {
                return decAmntNumTop;
            }
            set
            {
                decAmntNumTop = value;
            }
        }

        public decimal Width
        {
            get
            {
                return decWidth;
            }
            set
            {
                decWidth = value;
            }
        }
        public decimal Height
        {
            get
            {
                return decHeight;
            }
            set
            {
                decHeight = value;
            }
        }
        public decimal PayeeLeft
        {
            get
            {
                return decPayeeLeft;
            }
            set
            {
                decPayeeLeft = value;
            }
        }
        public decimal PayeeTop
        {
            get
            {
                return decPayeeTop;
            }
            set
            {
                decPayeeTop = value;
            }
        }
        public decimal DateLeft
        {
            get
            {
                return decDateLeft;
            }
            set
            {
                decDateLeft = value;
            }
        }
        public decimal DateTop
        {
            get
            {
                return decDateTop;
            }
            set
            {
                decDateTop = value;
            }
        }
        public decimal AmntWord1Left
        {
            get
            {
                return decAmntWord1Left;
            }
            set
            {
                decAmntWord1Left = value;
            }
        }
        public decimal AmntWord1Top
        {
            get
            {
                return decAmntWord1Top;
            }
            set
            {
                decAmntWord1Top = value;
            }
        }
        public decimal AmntWord2Left
        {
            get
            {
                return decAmntWord2Left;
            }
            set
            {
                decAmntWord2Left = value;
            }
        }
        public decimal AmntWord2Top
        {
            get
            {
                return decAmntWord2Top;
            }
            set
            {
                decAmntWord2Top = value;
            }
        }

        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        public string ActFileName
        {
            get
            {
                return strActFileName;
            }
            set
            {
                strActFileName = value;
            }
        }
        public string FinalTops
        {
            get
            {
                return strActFileNameFi;
            }
            set
            {
                strActFileNameFi = value;
            }
        }
        //methode of cancel status
        public int cncl_sts
        {
            get
            {
                return intcncl_sts;
            }
            set
            {
                intcncl_sts = value;
            }
        }


        public int ChequeTemplateId
        {
            get
            {
                return intTcsId;
            }
            set
            {
                intTcsId = value;
            }
        }

        public int cnclStatus
        {
            get
            {
                return intcnclStatus;
            }
            set
            {
                intcnclStatus = value;
            }
        }

        //methode of organisation id storing
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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

        //methode of user id storing
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
        //methode of status id storing
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

        //methode of provider name storing
        public string CancelReason
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
   
    }
}
