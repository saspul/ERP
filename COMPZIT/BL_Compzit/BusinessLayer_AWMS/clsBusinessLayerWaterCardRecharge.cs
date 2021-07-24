using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0005
// CREATED DATE:27/10/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerWaterCardRecharge
    {
        // This Method will fetch vehicle class details
        // This Method will fetch WATER CARD DETAILS
        public DataTable ReadWaterCard(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadCard = objDataLayerWater.ReadWaterCard(objEntityWaterRecharge);
            return dtReadCard;
        }
        // This Method adds water card RECHARGE details to the table
        public void AddWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.AddWaterCardRecharge(objEntityWaterRecharge);
            
        }

        // This Method update water card RECHARGE details to the table
        public void UpdateWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.UpdateWaterCardRecharge(objEntityWaterRecharge);
        }
                // This Method CONFIRM water card RECHARGE details to the table
        public void ConfirmWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.ConfirmWaterCardRecharge(objEntityWaterRecharge);
        }
                // This Method ReOPEN water card RECHARGE details to the table
        public void ReOpenWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.ReOpenWaterCardRecharge(objEntityWaterRecharge);
        }
        //Method for cancel water card RECHARGE
        public void CancelWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.CancelWaterCardRecharge(objEntityWaterRecharge);
        }
        //Method for recall water card RECHARGE
        public void ReCallWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            objDataLayerWater.ReCallWaterCardRecharge(objEntityWaterRecharge);
        }


        // This Method will fetch water card RECHARGE DEATILS BY ID
        public DataTable ReadWaterCardRechargeById(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterRecahrge = objDataLayerWater.ReadWaterCardRechargeById(objEntityWaterRecharge);
            return dtReadWaterRecahrge;
        }
        // This Method will water card RECHARGE list
        public DataTable ReadWaterCardRechargeList(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterRecahrge = objDataLayerWater.ReadWaterCardRechargeList(objEntityWaterRecharge);
            return dtReadWaterRecahrge;
        }
        // This Method will fetch water RECHARGE category list BY SEARCH
        public DataTable ReadwaterCardRechargeListBySearch(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterRecahrge = objDataLayerWater.ReadwaterCardRechargeListBySearch(objEntityWaterRecharge);
            return dtReadWaterRecahrge;
        }
                // This Method will water card RECHARGE list
        public DataTable ReadWaterCardDetails(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterRecahrge = objDataLayerWater.ReadWaterCardDetails(objEntityWaterRecharge);
            return dtReadWaterRecahrge;
        }
                // This Method will water card RECHARGE list
        public DataTable ReadVehicleDetails(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterRecahrge = objDataLayerWater.ReadVehicleDetails(objEntityWaterRecharge);
            return dtReadWaterRecahrge;
        }
                // This Method will fetch water card DEATILS BY ID
        public DataTable ReadWaterCardById(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            clsDataLayerWaterCardRecharge objDataLayerWater = new clsDataLayerWaterCardRecharge();
            DataTable dtReadWaterCard = objDataLayerWater.ReadWaterCardById(objEntityWaterRecharge);
            return dtReadWaterCard;
        }
    }
}
