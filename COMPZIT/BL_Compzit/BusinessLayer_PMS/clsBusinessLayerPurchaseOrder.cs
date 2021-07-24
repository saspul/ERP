using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_PMS;
using DL_Compzit.DataLayer_PMS;
using EL_Compzit.EntityLayer_FMS;
using EL_Compzit;

namespace BL_Compzit.BusinessLayer_PMS
{
    public class clsBusinessLayerPurchaseOrder
    {
        clsDataLayerPurchaseOrder objDataPurchaseOrder = new clsDataLayerPurchaseOrder();

        public DataTable ReadModeOfSupply(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadModeOfSupply(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadProjects(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadProjects(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadWarehouse(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadWarehouse(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadVendor(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadVendor(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadVendorCntctPrsn(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadVendorCntctPrsn(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadDocumntWrkflow(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadDocumntWrkflow(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadDivision(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadDivision(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadCustomers(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadCustomers(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadPOCntctPrsn(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPOCntctPrsn(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadProducts(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadProducts(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadVehicles(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadVehicles(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadEmployeeDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadEmployeeDtls(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadProductTaxDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadProductTaxDtls(objEntityPurchaseOrder);
            return dt;
        }
        public void InsertPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objPurchaseProductList, List<clsEntityPurchaseOrder> objPurchaseChrgHeadList, List<clsEntityPurchaseOrder> objPurchaseAttchmntList, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
        {
            objDataPurchaseOrder.InsertPurchaseOrder(objEntityPurchaseOrder, objPurchaseProductList, objPurchaseChrgHeadList, objPurchaseAttchmntList, objEnitytSupplierCntctList);
        }
        public DataTable ReadPurchaseOrderList(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPurchaseOrderList(objEntityPurchaseOrder);
            return dt;
        }
        public void CancelPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            objDataPurchaseOrder.CancelPurchaseOrder(objEntityPurchaseOrder);
        }
        public DataTable ReadPurchaseOrderById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadPurchaseOrderDetailsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPurchaseOrderDetailsById(objEntityPurchaseOrder);
            return dt;
        }
        public void UpdatePurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objPurchaseProductList, List<clsEntityPurchaseOrder> objPurchaseProductDeleteList, List<clsEntityPurchaseOrder> objPurchaseChrgHeadList, List<clsEntityPurchaseOrder> objPurchaseAttchmntList, List<clsEntityPurchaseOrder> objPurchaseAttchmntDeleteList, List<clsEntitySupplierContact> objEnitytSupplierCntctList, List<clsEntityApprovalConsole> objEntityApprvlCnslList)
        {
            objDataPurchaseOrder.UpdatePurchaseOrder(objEntityPurchaseOrder, objPurchaseProductList, objPurchaseProductDeleteList, objPurchaseChrgHeadList, objPurchaseAttchmntList, objPurchaseAttchmntDeleteList, objEnitytSupplierCntctList, objEntityApprvlCnslList);
        }
        public void ReopenPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            objDataPurchaseOrder.ReopenPurchaseOrder(objEntityPurchaseOrder);
        }
        public DataTable ReadChargeHeads(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadChargeHeads(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadPurchaseOrderChrgHeadsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPurchaseOrderChrgHeadsById(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadPurchaseOrderAttachmntsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadPurchaseOrderAttachmntsById(objEntityPurchaseOrder);
            return dt;
        }
        public DataTable ReadNoteDetails(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadNoteDetails(objEntityPurchaseOrder);
            return dt;
        }
        public void InsertNote(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objEntityPurchaseOrderAttchmnts)
        {
            objDataPurchaseOrder.InsertNote(objEntityPurchaseOrder, objEntityPurchaseOrderAttchmnts);
        }

        public DataTable ReadContactDtlsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadContactDtlsById(objEntityPurchaseOrder);
            return dt;
        }

        public DataTable ReadStatusDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadStatusDtls(objEntityPurchaseOrder);
            return dt;
        }

        public DataTable ReadCommentDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadCommentDtls(objEntityPurchaseOrder);
            return dt;
        }

        public void InsertComments(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            objDataPurchaseOrder.InsertComments(objEntityPurchaseOrder);
        }

        public DataTable ReadLocationDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            DataTable dt = objDataPurchaseOrder.ReadLocationDtls(objEntityPurchaseOrder);
            return dt;
        }

    }
}
