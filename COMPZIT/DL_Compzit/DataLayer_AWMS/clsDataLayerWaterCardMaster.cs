using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0005
// CREATED DATE:24/10/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerWaterCardMaster
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch bank name
        public DataTable ReadBank(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryReadBank = "WATER_CARD.SP_READ_BANK";
            OracleCommand cmdReadBank = new OracleCommand();
            cmdReadBank.CommandText = strQueryReadBank;
            cmdReadBank.CommandType = CommandType.StoredProcedure;
            cmdReadBank.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdReadBank.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            cmdReadBank.Parameters.Add(" W_BANK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadBank);
            return dtBank;
        }
         public DataTable ReadVehicleNumber(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryReadVeh = "WATER_CARD.SP_READ_VEHICLE_NUMBER";
            OracleCommand cmdReadVeh = new OracleCommand();
            cmdReadVeh.CommandText = strQueryReadVeh;
            cmdReadVeh.CommandType = CommandType.StoredProcedure;
            cmdReadVeh.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdReadVeh.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            cmdReadVeh.Parameters.Add(" W_VEH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadVeh);
            return dtBank;
        }
        
        // This Method adds water card details to the table
        public void AddWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryAddWaterCard = "WATER_CARD.SP_INS_CARD_DETAILS";
            using (OracleCommand cmdAddWaterCard = new OracleCommand())
            {
                cmdAddWaterCard.CommandText = strQueryAddWaterCard;
                cmdAddWaterCard.CommandType = CommandType.StoredProcedure;
                cmdAddWaterCard.Parameters.Add("W_CRDNUM", OracleDbType.Varchar2).Value = objEntityWater.CardNumber;
                cmdAddWaterCard.Parameters.Add("W_CRDEXPIRY", OracleDbType.Date).Value = objEntityWater.CardExpiry;
                cmdAddWaterCard.Parameters.Add("W_BANKID", OracleDbType.Int32).Value = objEntityWater.BankId;
                cmdAddWaterCard.Parameters.Add("W_OPNGAMNT", OracleDbType.Decimal).Value = objEntityWater.OpeningAmount;
                cmdAddWaterCard.Parameters.Add("W_CURAMNT", OracleDbType.Decimal).Value = objEntityWater.BalanceAmount;
                if (objEntityWater.VehNumber != 0)
                {
                    cmdAddWaterCard.Parameters.Add("W_VEHNUM", OracleDbType.Int32).Value = objEntityWater.VehNumber;
                }
                else
                {
                    cmdAddWaterCard.Parameters.Add("W_VEHNUM", OracleDbType.Int32).Value = null;
                }
                cmdAddWaterCard.Parameters.Add("W_ALRTAMNT", OracleDbType.Decimal).Value = objEntityWater.AlertAmount;
                cmdAddWaterCard.Parameters.Add("W_CARDNAME", OracleDbType.Varchar2).Value = objEntityWater.CardName;
                if (objEntityWater.CardIsuedDate!=DateTime.MinValue)
                {
                    cmdAddWaterCard.Parameters.Add("W_CRDISUEDATE", OracleDbType.Date).Value = objEntityWater.CardIsuedDate;
                }
                else
                {
                    cmdAddWaterCard.Parameters.Add("W_CRDISUEDATE", OracleDbType.Date).Value = null;
                }
                cmdAddWaterCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
                cmdAddWaterCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
                cmdAddWaterCard.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWater.Status_id;
                cmdAddWaterCard.Parameters.Add("W_INSUSERID", OracleDbType.Int32).Value = objEntityWater.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddWaterCard);
            }
        }

        // This Method update water card details to the table
        public void UpdateWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryUpdWaterCard = "WATER_CARD.SP_UPD_CARD_DETAILS";
            using (OracleCommand cmdUpdWaterCard = new OracleCommand())
            {
                cmdUpdWaterCard.CommandText = strQueryUpdWaterCard;
                cmdUpdWaterCard.CommandType = CommandType.StoredProcedure;
                cmdUpdWaterCard.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
                cmdUpdWaterCard.Parameters.Add("W_CRDNUM", OracleDbType.Varchar2).Value = objEntityWater.CardNumber;
                cmdUpdWaterCard.Parameters.Add("W_CRDEXPIRY", OracleDbType.Date).Value = objEntityWater.CardExpiry;
                cmdUpdWaterCard.Parameters.Add("W_BANKID", OracleDbType.Int32).Value = objEntityWater.BankId;
                cmdUpdWaterCard.Parameters.Add("W_OPNGAMNT", OracleDbType.Decimal).Value = objEntityWater.OpeningAmount;
                cmdUpdWaterCard.Parameters.Add("W_CURAMNT", OracleDbType.Decimal).Value = objEntityWater.BalanceAmount;
                if (objEntityWater.VehNumber != 0)
                {
                    cmdUpdWaterCard.Parameters.Add("W_VEHNUM", OracleDbType.Int32).Value = objEntityWater.VehNumber;
                }
                else
                {
                    cmdUpdWaterCard.Parameters.Add("W_VEHNUM", OracleDbType.Int32).Value = null;
                }
                cmdUpdWaterCard.Parameters.Add("W_ALRTAMNT", OracleDbType.Decimal).Value = objEntityWater.AlertAmount;
                cmdUpdWaterCard.Parameters.Add("W_CARDNAME", OracleDbType.Varchar2).Value = objEntityWater.CardName;
                if (objEntityWater.CardIsuedDate!=DateTime.MinValue)
                {
                    cmdUpdWaterCard.Parameters.Add("W_CRDISUEDATE", OracleDbType.Date).Value = objEntityWater.CardIsuedDate;
                }
                else
                {
                    cmdUpdWaterCard.Parameters.Add("W_CRDISUEDATE", OracleDbType.Date).Value = null;
                }
                cmdUpdWaterCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
                cmdUpdWaterCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
                cmdUpdWaterCard.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWater.Status_id;
                cmdUpdWaterCard.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWater.User_Id;
                cmdUpdWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdWaterCard);
            }
        }
        // This Method checks water card number in the database for duplication.
        public string CheckWaterCardNumber(clsEntityLayerWaterCardMaster objEntityWater)
        {

            string strQueryCheckCardNumber = "WATER_CARD.SP_CHECK_CARD_NUMBER";
            OracleCommand cmdCheckCardNumber = new OracleCommand();
            cmdCheckCardNumber.CommandText = strQueryCheckCardNumber;
            cmdCheckCardNumber.CommandType = CommandType.StoredProcedure;
            cmdCheckCardNumber.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
            cmdCheckCardNumber.Parameters.Add("W_CRDNUM", OracleDbType.Varchar2).Value = objEntityWater.CardNumber;
            cmdCheckCardNumber.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            cmdCheckCardNumber.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdCheckCardNumber.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCardNumber);
            string strReturn = cmdCheckCardNumber.Parameters["W_COUNT"].Value.ToString();
            cmdCheckCardNumber.Dispose();
            return strReturn;
        }
        // This Method checks water card Name in the database for duplication.
        public string CheckWaterCardName(clsEntityLayerWaterCardMaster objEntityWater)
        {

            string strQueryCheckCardNumber = "WATER_CARD.SP_CHECK_CARD_NAME";
            OracleCommand cmdCheckCardNumber = new OracleCommand();
            cmdCheckCardNumber.CommandText = strQueryCheckCardNumber;
            cmdCheckCardNumber.CommandType = CommandType.StoredProcedure;
            cmdCheckCardNumber.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
            cmdCheckCardNumber.Parameters.Add("W_CRDNME", OracleDbType.Varchar2).Value = objEntityWater.CardName;
            cmdCheckCardNumber.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            cmdCheckCardNumber.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdCheckCardNumber.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCardNumber);
            string strReturn = cmdCheckCardNumber.Parameters["W_COUNT"].Value.ToString();
            cmdCheckCardNumber.Dispose();
            return strReturn;
        }

        // This Method will fetch water card DEATILS BY ID
        public DataTable ReadWaterCardById(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryReadInsuranceType = "WATER_CARD.SP_READ_WATERCARD_BY_ID";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
            cmdReadInsuranceType.Parameters.Add(" W_WATERCARD", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }

        //Method for cancel water card
        public void CancelWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryCancelWaterCard = "WATER_CARD.SP_CANCEL_WATER_CARD";
            using (OracleCommand cmdCancelWaterCard = new OracleCommand())
            {
                cmdCancelWaterCard.CommandText = strQueryCancelWaterCard;
                cmdCancelWaterCard.CommandType = CommandType.StoredProcedure;
                cmdCancelWaterCard.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
                cmdCancelWaterCard.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWater.User_Id;
                cmdCancelWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelWaterCard.Parameters.Add("W_REASON", OracleDbType.Varchar2).Value = objEntityWater.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelWaterCard);
            }
        }
        //Method for recall water card
        public void ReCallWaterCard(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryRecallWaterCard = "WATER_CARD.SP_RECALL_WATER_CARD";
            using (OracleCommand cmdRecallWaterCard = new OracleCommand())
            {
                cmdRecallWaterCard.CommandText = strQueryRecallWaterCard;
                cmdRecallWaterCard.CommandType = CommandType.StoredProcedure;
                cmdRecallWaterCard.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWater.WaterCardMasterId;
                cmdRecallWaterCard.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWater.User_Id;
                cmdRecallWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecallWaterCard);
            }
        }


        // This Method will water card list
        public DataTable ReadWaterCardList(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryReadWaterCardList = "WATER_CARD.SP_READ_WATER_CARD_LIST";
            OracleCommand cmdReadWaterCardList = new OracleCommand();
            cmdReadWaterCardList.CommandText = strQueryReadWaterCardList;
            cmdReadWaterCardList.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCardList.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdReadWaterCardList.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            cmdReadWaterCardList.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtWCardList = new DataTable();
            dtWCardList = clsDataLayer.ExecuteReader(cmdReadWaterCardList);
            return dtWCardList;
        }
        // This Method will fetch water category list BY SEARCH
        public DataTable ReadwaterCardListBySearch(clsEntityLayerWaterCardMaster objEntityWater)
        {
            string strQueryReadWaterCardListBySearch = "WATER_CARD.SP_READ_WTR_CRD_LIST_BYSEARCH";
            OracleCommand cmdReadCardListBySearch = new OracleCommand();
            cmdReadCardListBySearch.CommandText = strQueryReadWaterCardListBySearch;
            cmdReadCardListBySearch.CommandType = CommandType.StoredProcedure;
            cmdReadCardListBySearch.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWater.Organisation_id;
            cmdReadCardListBySearch.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWater.Corporate_id;
            if (objEntityWater.SearchField == "")
            {
                cmdReadCardListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCardListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = objEntityWater.SearchField;
            }
            cmdReadCardListBySearch.Parameters.Add("W_DATABASE_FIELD", OracleDbType.Varchar2).Value = objEntityWater.DataBase_Field;
            cmdReadCardListBySearch.Parameters.Add("W_OPTION", OracleDbType.Int32).Value = objEntityWater.Status_id;
            cmdReadCardListBySearch.Parameters.Add("W_CANCEL", OracleDbType.Int32).Value = objEntityWater.CancelStatus;
            cmdReadCardListBySearch.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCardListBySearch);
            return dtCategoryList;
        }
       
    }
}
