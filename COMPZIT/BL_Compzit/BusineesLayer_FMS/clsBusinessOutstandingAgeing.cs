using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessOutstandingAgeing
    {
        clsDataLayerOutstandingAgeing objDataPaymnt = new clsDataLayerOutstandingAgeing();
        public DataTable Ageing_List(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List(objEntity);
            return dtRcpt;
        }
        public DataTable Ageing_List_ById(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List_ById(objEntity);
            return dtRcpt;
        }
        public DataTable Ageing_List_Supplier(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List_Supplier(objEntity);
            return dtRcpt;
        }
        public DataTable Ageing_List_ById_Supplier(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List_ById_Supplier(objEntity);
            return dtRcpt;
        }

        public DataTable ReadOepningBalById(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadOepningBalById(objEntity);
            return dtRcpt;
        }

        public DataTable ReadPendingReceipts(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadPendingReceipts(objEntity);
            return dtRcpt;
        }

        public DataTable ReadPendingPayments(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadPendingPayments(objEntity);
            return dtRcpt;
        }

        public DataTable ReadPostdatedChqDtls(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadPostdatedChqDtls(objEntity);
            return dtRcpt;
        }
        //--0044
        public DataTable Ageing_List_SupplierCrdtPrd(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List_SupplierCrdtPrd(objEntity);
            return dtRcpt;
        }
        public DataTable Ageing_ListCrdtPrd(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_ListCrdtPrd (objEntity);
            return dtRcpt;
        }
        public DataTable Ageing_List_ByIdCrdPrd(clsEntityOutstandingAgeing objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.Ageing_List_ByIdCrdPrd (objEntity);
            return dtRcpt;
        }
        //--0044

    }
}
