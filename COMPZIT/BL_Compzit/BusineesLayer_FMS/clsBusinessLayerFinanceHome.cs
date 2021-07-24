using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit;
using System.Collections.Generic;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessLayerFinanceHome
    {
        clsDataLayerFinanceHome objDataLayer = new clsDataLayerFinanceHome();
        public DataTable LoadBankBookDtls(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.LoadBankBookDtls(objEntityEmpSlry);
            return dt;
        }
        public DataTable LoadDebtorDtls(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.LoadDebtorDtls(objEntityEmpSlry);
            return dt;
        }
        public DataTable ReadRecurrnceList(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.ReadRecurrnceList(objEntityEmpSlry);
            return dt;
        }
        public void insertNewORders(List<clsEntityCommon> objEntityNewOrdersList)
        {
            objDataLayer.insertNewORders(objEntityNewOrdersList);
        }
        public DataTable ReadRecurrnceOrderList(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.ReadRecurrnceOrderList(objEntityEmpSlry);
            return dt;
        }
        public DataTable ReadOrderDtls(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.ReadOrderDtls(objEntityEmpSlry);
            return dt;
        }
        public void rejectOrders(clsEntityCommon objEntityNewOrdersList)
        {
            objDataLayer.rejectOrders(objEntityNewOrdersList);
        }

        //EVM 040
        public DataTable SalesTotal(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.SalesTotal(objEntityEmpSlry);
            return dt;
        }

        public DataTable PurchaseTotal(clsEntityCommon objEntityEmpSlry)
        {
            DataTable dt = objDataLayer.PurchaseTotal(objEntityEmpSlry);
            return dt;
        }
        //END

        //emp-0043 start
        public DataTable ProfitAndLossAcnt_List(clsEntityCommon objEntityProfitLoss)
        {
            DataTable dt = objDataLayer.ProfitAndLossAcnt_List(objEntityProfitLoss);
            return dt;
        }
        public DataTable ReadFinsYear(clsEntityCommon objEntityYear)
        {
            DataTable dt = objDataLayer.ReadFinsYear(objEntityYear);
            return dt;
        }
        //end


    }
}
