using System.Collections.Generic;
using EL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class cls_Business_SupplierOutstanding
    {
        clsDataLayerSupplierOutstaning objDataCredit = new clsDataLayerSupplierOutstaning();
        public DataTable ReadSupplier(clsEntitySupplierOutstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadSupplier(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSuppliersDetails(clsEntitySupplierOutstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadSuppliersDetails(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSupplierInfo(clsEntitySupplierOutstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadSupplierInfo(objEntity);
            return dtRcpt;
        }
    }
}
