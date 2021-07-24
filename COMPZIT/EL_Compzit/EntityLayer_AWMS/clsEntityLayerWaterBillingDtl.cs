using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerWaterBillingDtl
    {
        private int intWtrFillingDtlId = 0;
        private int intWaterFillingId = 0;
        private string strRcptNumber = "";
        private DateTime dRcptdate;
        private int intVhclId = 0;
        private decimal decRcptAmnt = 0;
        private int intCancelSts = 0;

        //Method of storing Detail id of Water Filling 
        public int WtrFilling_DtlId
        {
            get
            {
                return intWtrFillingDtlId;
            }
            set
            {
                intWtrFillingDtlId = value;
            }
        }

        //Property for storing Water Filling id.
        public int WaterFillingId
        {
            get
            {
                return intWaterFillingId;
            }
            set
            {
                intWaterFillingId = value;
            }
        }
            //Property for storing Rcpt Number.
        public string RcptNumber
        {
            get
            {
                return strRcptNumber;
            }
            set
            {
                strRcptNumber = value;
           
            }
        }
             //Property for storing the date of Receipt.
        public DateTime Rcptdate
        {
            get
            {
                return dRcptdate;
            }
            set
            {
                dRcptdate = value;
            }
        }
        //Property of storing the Vhcl id
        public int VhclId
        {
            get
            {
                return intVhclId;
            }
            set
            {
                intVhclId = value;
            }
        }
   
        //property of storing Rcpt Amnt
        public decimal RcptAmnt
        {
            get
            {
                return decRcptAmnt;
            }
            set
            {
                decRcptAmnt = value;
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
       
    }
}
