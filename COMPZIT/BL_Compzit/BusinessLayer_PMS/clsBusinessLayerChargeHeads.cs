using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_PMS;
using EL_Compzit.EntityLayer_PMS;

namespace BL_Compzit.BusinessLayer_PMS
{
   public  class clsBusinessLayerChargeHeads
   {
       clsDataLayerChargeHeads objDatalayerChargeHead = new clsDataLayerChargeHeads();
       public void InsertChargeHead(clsEntityChargeHeads objEntityChargeHead, List<clsEntityChargeHeads> objEntityVendorcat)
        {
            objDatalayerChargeHead.InsertChargeHead(objEntityChargeHead, objEntityVendorcat);
        }

       public void updateChargeHead(clsEntityChargeHeads objEntityChargeHead, List<clsEntityChargeHeads> objEntityVendorcat)
        {
            objDatalayerChargeHead.updateChargeHead(objEntityChargeHead, objEntityVendorcat);
        }
        public DataTable ReadChargeHead(clsEntityChargeHeads objEntityChargeHead)
        {
            DataTable dtChargeHead = new DataTable();
            dtChargeHead = objDatalayerChargeHead.ReadChargeHead(objEntityChargeHead);
            return dtChargeHead;
        }

        public void CancelChargeHead(clsEntityChargeHeads objEntityChargeHead)
        {
            objDatalayerChargeHead.CancelChargeHead(objEntityChargeHead);
        }

        public DataTable ReadChargeHead_ByID(clsEntityChargeHeads objEntityChargeHead)
        {
            DataTable dtChargeHead = new DataTable();
            dtChargeHead = objDatalayerChargeHead.ReadChargeHead_ByID(objEntityChargeHead);
            return dtChargeHead;
        }
        public DataTable ChargeHeadDplctnChk(clsEntityChargeHeads objEntityChargeHead)
        {
            DataTable dtChargeHead = new DataTable();
            dtChargeHead = objDatalayerChargeHead.ChargeHeadDplctnChk(objEntityChargeHead);
            return dtChargeHead;
        }
        public DataTable ReadChargeHeadCategory(clsEntityChargeHeads objEntityChargeHead)
        {
            DataTable dtChargeHead = new DataTable();
            dtChargeHead = objDatalayerChargeHead.ReadChargeHeadCategory(objEntityChargeHead);
            return dtChargeHead;
        }
        public DataTable ReadChargeHeadCategoryByID(clsEntityChargeHeads objEntityChargeHead)
        {
            DataTable dtChargeHead = new DataTable();
            dtChargeHead = objDatalayerChargeHead.ReadChargeHeadCategoryByID(objEntityChargeHead);
            return dtChargeHead;
        }

    }
}