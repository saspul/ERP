using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_FMS;
using DL_Compzit.DataLayer_FMS;
using System.Data;
namespace BL_Compzit.BusineesLayer_FMS
{
  public  class clsBusinessLayerSupplier
    {
       clsDataLayerSupplier objDataSupplier = new clsDataLayerSupplier();

       public DataTable CheckSupplierCnclSts(clsEntitySupplier objEntityShortList)
        {
            DataTable dtDiv = objDataSupplier.CheckSupplierCnclSts(objEntityShortList);
            return dtDiv;
        }
       public DataTable ReadSupplierList(clsEntitySupplier objEntityShortList)
        {
            DataTable dtDiv = objDataSupplier.ReadSupplierList(objEntityShortList);
            return dtDiv;
        }
       public DataTable ReadSupplierDtlsById(clsEntitySupplier objEntityShortList)
        {
            DataTable dtDiv = objDataSupplier.ReadSupplierDtlsById(objEntityShortList);
            return dtDiv;
        }
       public DataTable CheckDupName(clsEntitySupplier objEntityShortList)
        {
            DataTable dtDiv = objDataSupplier.CheckDupName(objEntityShortList);
            return dtDiv;
        }
       public void AddSupplier(clsEntitySupplier objEntityShortList, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
        {
            objDataSupplier.AddSupplier(objEntityShortList, objEnitytSupplierCntctList);
        }
       public void UpdateSupplier(clsEntitySupplier objEntityShortList, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
        {
            objDataSupplier.UpdateSupplier(objEntityShortList, objEnitytSupplierCntctList);
        }
       public void UpdateLedgerSts(clsEntitySupplier objEntityShortList)
       {
           objDataSupplier.UpdateLedgerSts(objEntityShortList);
       }
       public void CancelSupplier(clsEntitySupplier objEntityShortList)
        {
            objDataSupplier.CancelSupplier(objEntityShortList);
        }

       public DataTable ReadVendorCatgry(clsEntitySupplier objEntityEmpSlry)
       {
           DataTable dtDiv = objDataSupplier.ReadVendorCatgry(objEntityEmpSlry);
           return dtDiv;
       }

       public DataTable ReadContactDtls(clsEntitySupplier objEntityEmpSlry)
       {
           DataTable dtDiv = objDataSupplier.ReadContactDtls(objEntityEmpSlry);
           return dtDiv;
       }

    }
}

