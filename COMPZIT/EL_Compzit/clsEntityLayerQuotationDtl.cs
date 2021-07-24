using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
  public class clsEntityLayerQuotationDtl
    {
        private int intQtnDtlId = 0;
        private int intProductId = 0;
        private int intUOMId = 0;
        private decimal decQuantity = 0;
        private decimal decCostPrice = 0;
        private string strHike = "";
        private decimal decRate = 0;
        private decimal decItemDiscntAmnt = 0;
        private decimal decAmount = 0;
        private int intStockSts = 0;
        private int intCancelSts = 0;
        private string strItemDescription = null;
        private int intTaxId = 0;
        private decimal decTaxPecentage = 0;
        private decimal decTaxAmnt = 0;
        private string strProductName = "";
        private string strUOMName = "";
        private string strCatName = "";
        private int intProductMode = 1;// for making it default .Used in template 1(Standard)
        private int intPrint = 0;

        private string strPrdctGroupName = "";
        private int intPrdctGrpId = 0;
        private decimal decGrpGrossAmnt = 0;
        private decimal decGrpNetAmnt = 0;
        private int decGrpDiscmode = 0;
        private decimal decGrpDiscvalue = 0;
        private decimal decGrpDiscAmount = 0;
        private int intOrderNumberId = 0;

        public int OrderNumberId
        {
            get
            {
                return intOrderNumberId;
            }
            set
            {
                intOrderNumberId = value;
            }
        }

        public int GrpDiscmode
        {
            get
            {
                return decGrpDiscmode;
            }
            set
            {
                decGrpDiscmode = value;
            }
        }
        public decimal GrpGrossAmnt
        {
            get
            {
                return decGrpGrossAmnt;
            }
            set
            {
                decGrpGrossAmnt = value;
            }
        }
        public decimal GrpNetAmnt
        {
            get
            {
                return decGrpNetAmnt;
            }
            set
            {
                decGrpNetAmnt = value;
            }
        }
        public decimal GrpDiscvalue
        {
            get
            {
                return decGrpDiscvalue;
            }
            set
            {
                decGrpDiscvalue = value;
            }
        }
        public decimal GrpDiscAmount
        {
            get
            {
                return decGrpDiscAmount;
            }
            set
            {
                decGrpDiscAmount = value;
            }
        }
        //Method of storing Detail name of product group 
        public string PrdctGroupName
        {
            get
            {
                return strPrdctGroupName;
            }
            set
            {
                strPrdctGroupName = value;
            }
        }
        //Method of storing Detail id of product group 
        public int PrdctGrpId
        {
            get
            {
                return intPrdctGrpId;
            }
            set
            {
                intPrdctGrpId = value;
            }
        }
        //Method of storing Detail id of Quotation 
        public int Print
        {
            get
            {
                return intPrint;
            }
            set
            {
                intPrint = value;
            }
        }
        //Method of storing Detail id of Quotation 
        public int QtnDtl_Id
        {
            get
            {
                return intQtnDtlId;
            }
            set
            {
                intQtnDtlId = value;
            }
        }
     

        //Property of storing the Item id
        public int ProductId
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
        //Method of storing id of unit 
        public int UOMId
        {
            get
            {
                return intUOMId;
            }
            set
            {
                intUOMId = value;
            }
        }
        //property of storing quanties of item 
        public decimal Quantity
        {
            get
            {
                return decQuantity;
            }
            set
            {
                decQuantity = value;
            }
        }
        //Property for storing Price of item.
        public decimal CostPrice
        {
            get
            {
                return decCostPrice;
            }
            set
            {
                decCostPrice = value;
            }
        }
        //Property for storing Hike of item.
        public string Hike
        {
            get
            {
                return strHike;
            }
            set
            {
                strHike = value;
            }
        }
        //Property  storing Rate of item
        public decimal Rate
        {
            get
            {
                return decRate;
            }
            set
            {
                decRate = value;
            }
        }
        //Property for storing discount amount against item
        public decimal ItemDiscntAmnt
        {
            get
            {
                return decItemDiscntAmnt;
            }
            set
            {
                decItemDiscntAmnt = value;
            }
        }


        //Property for storing  Amount  against item
        public decimal Amount
        {
            get
            {
                return decAmount;
            }
            set
            {
                decAmount = value;
            }
        }
        //Property for storing stock status of item
        public int StockSts
        {
            get
            {
                return intStockSts;
            }
            set
            {
                intStockSts = value;
            }
        }

        //Property for storing  cancel status of item
        public int CancelSts
        {
            get
            {
                return intCancelSts;
            }
            set
            {
                intCancelSts = value;
            }
        }
        //Property for storing  Description  against item
        public string ItemDescription
        {
            get
            {
                return strItemDescription;
            }
            set
            {
                strItemDescription = value;
            }
        }
        //Property for storing Tax  against item
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
        //Property for storing  Tax Pecentage  against item
        public decimal TaxPecentage
        {
            get
            {
                return decTaxPecentage;
            }
            set
            {
                decTaxPecentage = value;
            }
        }
        //Property for storing  Tax amount  against item
        public decimal TaxAmnt
        {
            get
            {
                return decTaxAmnt;
            }
            set
            {
                decTaxAmnt = value;
            }
        }
        //Property for storing  item name
        public string ProductName
        {
            get
            {
                return strProductName;
            }
            set
            {
                strProductName = value;
            }
        }
        //Property for storing  unut name
        public string UOMName
        {
            get
            {
                return strUOMName;
            }
            set
            {
                strUOMName = value;
            }
        }
        //Method of storing Mode  of adding item Quotation 
        public int ProductMode
        {
            get
            {
                return intProductMode;
            }
            set
            {
                intProductMode = value;
            }
        }
       //Method of storing Mode  of adding item Quotation 
        public string ProductCategory
        {
            get
            {
                return strCatName;
            }
            set
            {
                strCatName = value;
            }
        }
      
    }
}
