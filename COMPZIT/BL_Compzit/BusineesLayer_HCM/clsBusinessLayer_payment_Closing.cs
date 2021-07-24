using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayer_payment_Closing
    {
        clsDataLayer_Payment_Closing objDataLayerPaymtCls = new clsDataLayer_Payment_Closing();

        public DataTable ReadMonthlySal_List(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            DataTable dtSalPrs = new DataTable();
            dtSalPrs = objDataLayerPaymtCls.ReadMonthlySal_List(objEntityPaymtCls);
            return dtSalPrs;
        }

        public DataTable ReadMonthlySal_ListById(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            DataTable dtSalPrs = new DataTable();
            dtSalPrs = objDataLayerPaymtCls.ReadMonthlySal_ListById(objEntityPaymtCls);
            return dtSalPrs;
        }

        public void ReadMonthlySal_PrsClose(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            objDataLayerPaymtCls.ReadMonthlySal_PrsClose(objEntityPaymtCls);
        }

        public DataTable ReadMonthlySal_PaidList(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            DataTable dtSalPrs = new DataTable();
            dtSalPrs = objDataLayerPaymtCls.ReadMonthlySal_PaidList(objEntityPaymtCls);
            return dtSalPrs;
        }
        public DataTable ReadBsnsUnits(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            DataTable dtSalPrs = new DataTable();
            dtSalPrs = objDataLayerPaymtCls.ReadBsnsUnits(objEntityPaymtCls);
            return dtSalPrs;
        }
        public void closePayment(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            objDataLayerPaymtCls.closePayment(objEntityPaymtCls);           
        }
        public DataTable ReadPayment_paidedList(clsEntityLayer_Payment_Closing objEntityPaymtCls)
        {
            DataTable dtSalPrs = new DataTable();
            dtSalPrs = objDataLayerPaymtCls.ReadPayment_paidedList(objEntityPaymtCls);
            return dtSalPrs;
        }
    }
}
