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
// CREATED DATE:24/10/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBusinessLayerWaterCard
    {
        // This Method will fetch vehicle class details
        public DataTable ReadBank(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            DataTable dtReadbank = objDataLayerWater.ReadBank(objEntityWater);
            return dtReadbank;
        }
       //this metthod will read the vehicle numbers
       public DataTable ReadVehicleNumber(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            DataTable dtReadveh = objDataLayerWater.ReadVehicleNumber(objEntityWater);
            return dtReadveh;
        }
        // This Method adds water card details to the table
        public void AddWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            objDataLayerWater.AddWaterCard(objEntityWater);
        }
        // This Method update water card details to the table
        public void UpdateWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            objDataLayerWater.UpdateWaterCard(objEntityWater);
        }
        //Method for cancel water card
        public void CancelWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            objDataLayerWater.CancelWaterCard(objEntityWater);
        }
               //Method for recall water card
        public void ReCallWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            objDataLayerWater.ReCallWaterCard(objEntityWater);
        }
        // This Method checks water card number in the database for duplication.
        public string CheckWaterCardNumber(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            string dupname = objDataLayerWater.CheckWaterCardNumber(objEntityWater);
            return dupname;
        }
               // This Method checks water card Name in the database for duplication.
        public string CheckWaterCardName(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            string dupname = objDataLayerWater.CheckWaterCardName(objEntityWater);
            return dupname;
        }
        // This Method will fetch vehicle DEATILS BY ID
        public DataTable ReadWaterCardById(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            DataTable dtReadWatermaster = objDataLayerWater.ReadWaterCardById(objEntityWater);
            return dtReadWatermaster;
        }
        // This Method will water card list
        public DataTable ReadWaterCardList(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            DataTable dtReadWaterCard = objDataLayerWater.ReadWaterCardList(objEntityWater);
            return dtReadWaterCard;
        }
        // This Method will fetch water category list BY SEARCH
        public DataTable ReadwaterCardListBySearch(clsEntityLayerWaterCardMaster objEntityWater)
        {
            clsDataLayerWaterCardMaster objDataLayerWater = new clsDataLayerWaterCardMaster();
            DataTable dtReadWaterCard = objDataLayerWater.ReadwaterCardListBySearch(objEntityWater);
            return dtReadWaterCard;
        }
    }
}
