using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL_Compzit
{
    public class clsEntityLayerBank
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intStatus = 0;
        private int intBankId = 0;
        private string strName = null;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strAddrs = null;
        private string strAccNo = null;
        private string strIfsc = null;
        private string strSwift = null;
        private string strIBank = null;
        private DateTime date;

        //EVM-0027 sep 18
        private int intHCMStatus = 0;

        private string strChequeBk = "";

        private int intChkNumFrm = 0;
        private int intChkNumTo = 0;
        private int intChkStatus = 0;
        private int intChkTemp = 0;

        private string strChequeLfNums = "";

        private string strUpdOrIns = "";

        private int intChkBookId = 0;


        private int intLedgerSts = 0;
        private int intLedgerId = 0;



        private string strCommonSearchTerm = "";
        private string strSearchBank = "";
        private string strSearchAccount = "";
        private string strSearchIban = "";
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
        public string SearchBank
        {
            get
            {
                return strSearchBank;
            }
            set
            {
                strSearchBank = value;
            }
        }
        public string SearchAccount
        {
            get
            {
                return strSearchAccount;
            }
            set
            {
                strSearchAccount = value;
            }
        }
        public string SearchIban
        {
            get
            {
                return strSearchIban;
            }
            set
            {
                strSearchIban = value;
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

        //15-03-2019
        private string strChqLfCnclRsn = "";
        public string ChqCnclRsn
        {
            get
            {
                return strChqLfCnclRsn;
            }
            set
            {
                strChqLfCnclRsn = value;
            }
        }
        private int intCnclChqSts = 0;
        public int CancelChqSts
        {
            get
            {
                return intCnclChqSts;
            }
            set
            {
                intCnclChqSts = value;
            }
        }
        //END
        public int LedgerSts
        {
            get
            {
                return intLedgerSts;
            }
            set
            {
                intLedgerSts = value;
            }
        }
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


        public int ChkBookId
        {
            get
            {
                return intChkBookId;
            }
            set
            {
                intChkBookId = value;
            }
        }

        public string UpdOrIns
        {
            get
            {
                return strUpdOrIns;
            }
            set
            {
                strUpdOrIns = value;
            }
        }

      

        public string ChequeLfNums
        {
            get
            {
                return strChequeLfNums;
            }
            set
            {
                strChequeLfNums = value;
            }
        }
        public int ChkTemp
        {
            get
            {
                return intChkTemp;
            }
            set
            {
                intChkTemp = value;
            }
        }
        public int ChkStatus
        {
            get
            {
                return intChkStatus;
            }
            set
            {
                intChkStatus = value;
            }
        }
        public int ChkNumTo
        {
            get
            {
                return intChkNumTo;
            }
            set
            {
                intChkNumTo = value;
            }
        }
        public int ChkNumFrm
        {
            get
            {
                return intChkNumFrm;
            }
            set
            {
                intChkNumFrm = value;
            }
        }
        public string ChequeBk
        {
            get
            {
                return strChequeBk;
            }
            set
            {
                strChequeBk = value;
            }
        }

        public int HCMStatus
        {
            get
            {
                return intHCMStatus;
            }
            set
            {
                intHCMStatus = value;
            }
        }
        //END sep 18

        //evm-0027

        private string strIBankShortName = null;

        public string BankShortName
        {
            get
            {
                return strIBankShortName;
            }
            set
            {
                strIBankShortName = value;
            }
        }
        //END
        //methode of storing  bankid 
        public int BankId
        {
            get
            {
                return intBankId;
            }
            set
            {
                intBankId = value;
            }
        }
        //methode of storing bank name 
        public string BankName
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

        //methode of storing bank address 
        public string BankAddrs
        {
            get
            {
                return strAddrs;
            }
            set
            {
                strAddrs = value;
            }
        }

        //methode of storing bank account number
        public string AccNo
        {
            get
            {
                return strAccNo;
            }
            set
            {
                strAccNo = value;
            }
        }
        //methode of storing bank IFSC code
        public string IfscCode
        {
            get
            {
                return strIfsc;
            }
            set
            {
                strIfsc = value;
            }
        }

        //methode of storing bank swift code
        public string SwiftCode
        {
            get
            {
                return strSwift;
            }
            set
            {
                strSwift = value;
            }
        }
        //methode of storing Ibank number
        public string IBank
        {
            get
            {
                return strIBank;
            }
            set
            {
                strIBank = value;
            }
        }
        //methode of storing bank swift code
        public DateTime BankDate
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }


        //method of storing cancel reason
        public string CanclReason
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

        //methode of storing  cancel status 
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


    }
}
