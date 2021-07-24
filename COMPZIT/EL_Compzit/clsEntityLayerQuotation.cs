using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityLayerQuotation
    {
        private int intQuotationId = 0;
        private int intQtnRefSerialId = 0;
        private string strQuotationRefNumbr = "";
        private DateTime dQuotationDate;     
        private int intLead_Id = 0;
        private string strQuotnComment = "";
        private int intCurncyMastrId = 0;
        private string strPriceTerm = "";
        private string strManufacturerTerm = "";
        private string strPaymntTerm = "";
        private string strDeliveryPeriod = "";
        private string strDeliveryTerm = "";
        private string strValidityTerm = "";
        private string strWarrantyTerm = "";
        private decimal decGrossAmnt = 0;
        private int intDiscMode = 0;
        private decimal decDiscValue = 0;
        private decimal decDiscTotalAmnt = 0;
        private decimal decNetAmnt = 0;
        private int intMailStatus = 0;
        private int intUserId = 0;
        private DateTime ddate;
        private int intQuotationStatus = 0;
        private int intApprovedStatus = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private string strDivsnid = "";
        private int intProductId = 0;
        private int intTaxId = 0;
        private int intTemplateTypeId = 0;
        private int intTermTemplateId = 0;
        private int intQtnTemplateId = 0;

        private int intQtnRevisionVersn = 0;

        private int intReopenRsn_Id = 0;
        private string strReopenRsnDescrptn = "";
      
        //emv 0019      
        private string strToMail = "";
        private string strCcMail = "";
        private string strBCcMail = "";

        private int intcustomerId = 0;

        //Property for storing Quotation id.
        public int QuotationId
        {
            get
            {
                return intQuotationId;
            }
            set
            {
                intQuotationId = value;
            }
        }
        //Property for storing QtnRefSerial id.
        public int QtnRefSerialId
        {
            get
            {
                return intQtnRefSerialId;
            }
            set
            {
                intQtnRefSerialId = value;
            }
        }
        //Property for storing Quotation RefNumbr.
        public string QuotationRefNumbr
        {
            get
            {
                return strQuotationRefNumbr;
            }
            set
            {
                strQuotationRefNumbr = value;
            }
        }

        //Property for storing the date of Quotation.
        public DateTime QuotationDate
        {
            get
            {
                return dQuotationDate;
            }
            set
            {
                dQuotationDate = value;
            }
        }
        //Property for storing comment of quotation
        public string QuotnComment
        {
            get
            {
                return strQuotnComment;
            }
            set
            {
                strQuotnComment = value;
            }
        }
        //Property for storing  Lead  id.
        public int Lead_Id
        {
            get
            {
                return intLead_Id;
            }
            set
            {
                intLead_Id = value;
            }
        }
        //Property of storing id of currency master
        public int CurncyMastrId
        {
            get
            {
                return intCurncyMastrId;
            }
            set
            {
                intCurncyMastrId = value;
            }
        }

        //Property for storing PriceTerm of quotation
        public string PriceTerm
        {
            get
            {
                return strPriceTerm;
            }
            set
            {
                strPriceTerm = value;
            }
        }

        //Property for storing ManufacturerTerm of quotation
        public string ManufacturerTerm
        {
            get
            {
                return strManufacturerTerm;
            }
            set
            {
                strManufacturerTerm = value;
            }
        }

        //Property for storing DeliveryPeriod of quotation
        public string DeliveryPeriod
        {
            get
            {
                return strDeliveryPeriod;
            }
            set
            {
                strDeliveryPeriod = value;
            }
        }
        //Property for storing PaymntTerm of quotation
        public string PaymntTerm
        {
            get
            {
                return strPaymntTerm;
            }
            set
            {
                strPaymntTerm = value;
            }
        }
        //Property for storing  DeliveryTerm of quotation
        public string DeliveryTerm
        {
            get
            {
                return strDeliveryTerm;
            }
            set
            {
                strDeliveryTerm = value;
            }
        }
        //Property for storing  ValidityTerm of quotation
        public string ValidityTerm
        {
            get
            {
                return strValidityTerm;
            }
            set
            {
                strValidityTerm = value;
            }
        }
        //Property for storing  WarrantyTerm of quotation
        public string WarrantyTerm
        {
            get
            {
                return strWarrantyTerm;
            }
            set
            {
                strWarrantyTerm = value;
            }
        }
        //storing the GrossAmnt
        public decimal GrossAmnt
        {
            get
            {
                return decGrossAmnt;
            }
            set
            {
                decGrossAmnt = value;
            }
        }

        //storing the Disc mode
        public int DiscMode
        {
            get
            {
                return intDiscMode;
            }
            set
            {
                intDiscMode = value;
            }
        }
        //storing the Disc value
        public decimal DiscValue
        {
            get
            {
                return decDiscValue;
            }
            set
            {
                decDiscValue = value;
            }
        }
        //storing the Disc Total Amnt
        public decimal DiscTotalAmnt
        {
            get
            {
                return decDiscTotalAmnt;
            }
            set
            {
                decDiscTotalAmnt = value;
            }
        }

        //storing the Disc  Net Amnt
        public decimal NetAmnt
        {
            get
            {
                return decNetAmnt;
            }
            set
            {
                decNetAmnt = value;
            }
        }

        //Property for storing Mail Status.
        public int MailStatus
        {
            get
            {
                return intMailStatus;
            }
            set
            {
                intMailStatus = value;
            }
        }
        //Property for storing user id who do the event.
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
        //Property for storing the date when the event occurs.
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
        //Property for storing Quotation Status.
        public int QuotationStatus
        {
            get
            {
                return intQuotationStatus;
            }
            set
            {
                intQuotationStatus = value;
            }
        }

        //Property for storing Approved Status.
        public int ApprovedStatus
        {
            get
            {
                return intApprovedStatus;
            }
            set
            {
                intApprovedStatus = value;
            }
        }
      
        //Property for storing organistion id.
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

        //Property for storing Corporate office id.
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
     
        //Property for storing  Division Ids
        public string Divisionids
        {
            get
            {
                return strDivsnid;
            }
            set
            {
                strDivsnid = value;
            }
        }
        //Property of storing id of Product Master
        public int Product_Id
        {
            get
            {
                return intProductId;
            }
            set
            {
                intProductId = value;
            }
        }
        //Property for storing Tax id.
        public int TaxId
        {
            get
            {
                return intTaxId;
            }
            set
            {
                intTaxId = value;
            }
        }
        //Property for storing individual Term Template id.
        public int TermTemplateId
        {
            get
            {
                return intTermTemplateId;
            }
            set
            {
                intTermTemplateId = value;
            }
        }
        //Property for storing Template TypeId .
        public int TermTemplateTypeId
        {
            get
            {
                return intTemplateTypeId;
            }
            set
            {
                intTemplateTypeId = value;
            }
        }
        //Property for storing Quotation Template TypeId .
        public int QuotationTemplateTypeId
        {
            get
            {
                return intQtnTemplateId;
            }
            set
            {
                intQtnTemplateId = value;
            }
        }
        public int QtnRevisionVersn
        {
            get
            {
                return intQtnRevisionVersn;
            }
            set
            {
                intQtnRevisionVersn = value;
            }
        }
        //Property for storing Reopen Reason id.
        public int ReopenRsn_Id
        {
            get
            {
                return intReopenRsn_Id;
            }
            set
            {
                intReopenRsn_Id = value;
            }
        }
        //Property for storing Quotation ReopenRsn Descrptn.
        public string ReopenRsnDescrptn
        {
            get
            {
                return strReopenRsnDescrptn;
            }
            set
            {
                strReopenRsnDescrptn = value;
            }
        }

        //evm 0019
        public string ToMail
        {
            get { return strToMail; }
            set { strToMail = value; }
        }
        public string CcMail
        {
            get { return strCcMail; }
            set { strCcMail = value; }
        }
        public string BCcMail
        {
            get { return strBCcMail; }
            set { strBCcMail = value; }
        }

        //Start:-EMP-0009
        private int intBckUpID = 0;

        public int BckupId
        {
            get
            {
                return intBckUpID;
            }
            set
            {
                intBckUpID = value;
            }
        }

        //Stop:-EMP-0009
       //Property for storing Customer id.
        public int CustomerId
        {
            get
            {
                return intcustomerId;
            }
            set
            {
                intcustomerId = value;
            }
        }
    }

}
