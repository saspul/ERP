using System.Collections.Generic;
using EL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessCustomer_Outstanding
    {
        clsDataLayerCustomer_Outstanding objDataCredit = new clsDataLayerCustomer_Outstanding();
        public DataTable ReadCustomers(cls_EntityCustomer_Outstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadCustomers(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCustomersDetails(cls_EntityCustomer_Outstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadCustomersDetails(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCustInfo(cls_EntityCustomer_Outstanding objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataCredit.ReadCustInfo(objEntity);
            return dtRcpt;
        }
    }
}
