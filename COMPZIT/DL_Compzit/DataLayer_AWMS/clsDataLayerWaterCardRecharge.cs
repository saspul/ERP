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
// CREATED DATE:26/10/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerWaterCardRecharge
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch WATER CARD DETAILS
        public DataTable ReadWaterCard(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadCard = "WATER_CARD_RECHARGE.SP_READ_WTR_CRD";
            OracleCommand cmdReadCard = new OracleCommand();
            cmdReadCard.CommandText = strQueryReadCard;
            cmdReadCard.CommandType = CommandType.StoredProcedure;
            cmdReadCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
            cmdReadCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
            cmdReadCard.Parameters.Add("W_WCARD", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadCard);
            return dtBank;
        }

        // This Method adds water card RECHARGE details to the table
        public void AddWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryAddWaterCard = "WATER_CARD_RECHARGE.SP_INS_RECHARGE_DETAILS";
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   using (OracleCommand cmdAddWaterCard = new OracleCommand(strQueryAddWaterCard,con))
                   {
                       cmdAddWaterCard.Transaction = tran;
                       cmdAddWaterCard.CommandType = CommandType.StoredProcedure;
                       cmdAddWaterCard.Parameters.Add("W_NEXT_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.NextId;
                       cmdAddWaterCard.Parameters.Add("W_CRDNUM", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
                       cmdAddWaterCard.Parameters.Add("W_RCHAMNT", OracleDbType.Decimal).Value = objEntityWaterRecharge.RechargeAmnt;
                       cmdAddWaterCard.Parameters.Add("W_REMRK", OracleDbType.Varchar2).Value = objEntityWaterRecharge.Remark;
                       if (objEntityWaterRecharge.FileName != "")
                       {
                           cmdAddWaterCard.Parameters.Add("W_FILENAME", OracleDbType.Varchar2).Value = objEntityWaterRecharge.FileName;
                       }
                       else
                       {
                           cmdAddWaterCard.Parameters.Add("W_FILENAME", OracleDbType.Varchar2).Value = null;
                       }
                       if (objEntityWaterRecharge.FileNameAct != "")
                       {
                           cmdAddWaterCard.Parameters.Add("W_FILEACT", OracleDbType.Varchar2).Value = objEntityWaterRecharge.FileNameAct;
                       }
                       else
                       {
                           cmdAddWaterCard.Parameters.Add("W_FILEACT", OracleDbType.Varchar2).Value = null;
                       }
                       cmdAddWaterCard.Parameters.Add("W_REDATE", OracleDbType.Date).Value = objEntityWaterRecharge.RechargeDate;
                       cmdAddWaterCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                       cmdAddWaterCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                       cmdAddWaterCard.Parameters.Add("W_INSUSERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                       clsDataLayer.ExecuteNonQuery(cmdAddWaterCard);

                   }
                   tran.Commit();

               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }
             }
        }

        // This Method update water card RECHARGE details to the table
        public void UpdateWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryUpdWaterCardRech = "WATER_CARD_RECHARGE.SP_UPD_RECHARGE_DETAILS";
            using (OracleCommand cmdUpdWaterCardRech = new OracleCommand())
            {
                cmdUpdWaterCardRech.CommandText = strQueryUpdWaterCardRech;
                cmdUpdWaterCardRech.CommandType = CommandType.StoredProcedure;
                cmdUpdWaterCardRech.Parameters.Add("W_RECH_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
                cmdUpdWaterCardRech.Parameters.Add("W_CRDNUM", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
                cmdUpdWaterCardRech.Parameters.Add("W_RCHAMNT", OracleDbType.Decimal).Value = objEntityWaterRecharge.RechargeAmnt;
                cmdUpdWaterCardRech.Parameters.Add("W_REMRK", OracleDbType.Varchar2).Value = objEntityWaterRecharge.Remark;
                if (objEntityWaterRecharge.FileName != "")
                {
                    cmdUpdWaterCardRech.Parameters.Add("W_FILENAME", OracleDbType.Varchar2).Value = objEntityWaterRecharge.FileName;
                }
                else
                {
                    cmdUpdWaterCardRech.Parameters.Add("W_FILENAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityWaterRecharge.FileNameAct != "")
                {
                    cmdUpdWaterCardRech.Parameters.Add("W_FILEACT", OracleDbType.Varchar2).Value = objEntityWaterRecharge.FileNameAct;
                }
                else
                {
                    cmdUpdWaterCardRech.Parameters.Add("W_FILEACT", OracleDbType.Varchar2).Value = null;
                }
                cmdUpdWaterCardRech.Parameters.Add("W_REDATE", OracleDbType.Date).Value = objEntityWaterRecharge.RechargeDate;
                cmdUpdWaterCardRech.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                cmdUpdWaterCardRech.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                cmdUpdWaterCardRech.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                cmdUpdWaterCardRech.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdWaterCardRech);
            }
        }
        // This Method CONFIRM water card RECHARGE details to the table
        public void ConfirmWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
              OracleTransaction tran;
              using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
              {
                  con.Open();
                  tran = con.BeginTransaction();
                  try
                  {
                      string strQueryCnfrmWaterCardRech = "WATER_CARD_RECHARGE.SP_CNFRM_RCHRG_DETAILS";
                      using (OracleCommand cmdCnfrmWaterCardRech = new OracleCommand(strQueryCnfrmWaterCardRech, con))
                      {
                          cmdCnfrmWaterCardRech.Transaction = tran;
                          cmdCnfrmWaterCardRech.CommandType = CommandType.StoredProcedure;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_RECH_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_BLANCEBFR", OracleDbType.Decimal).Value = objEntityWaterRecharge.BalanceBeforeCnfrm;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_CNFRMUSERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_CNFRMSTATUS", OracleDbType.Int32).Value = objEntityWaterRecharge.Status_id;
                          cmdCnfrmWaterCardRech.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                          clsDataLayer.ExecuteNonQuery(cmdCnfrmWaterCardRech);
                      }

                      string strQueryUpdBalanceAmount = "WATER_CARD_RECHARGE.SP_UPD_BALANCE";
                      using (OracleCommand cmdUpdBalance = new OracleCommand(strQueryUpdBalanceAmount, con))
                      {
                          cmdUpdBalance.Transaction = tran;
                          cmdUpdBalance.CommandType = CommandType.StoredProcedure;
                          cmdUpdBalance.Parameters.Add("W_CRDNUM", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
                          cmdUpdBalance.Parameters.Add("W_BALAMNT", OracleDbType.Decimal).Value = objEntityWaterRecharge.BalanceAmount;
                          cmdUpdBalance.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                          cmdUpdBalance.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                          clsDataLayer.ExecuteNonQuery(cmdUpdBalance);
                      }
                      tran.Commit();
                  }

                  catch (Exception e)
                  {
                      tran.Rollback();
                      throw e;
                  }
              }
        }

        // This Method ReOPEN water card RECHARGE details to the table
        public void ReOpenWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {
                     string strQueryCnfrmWaterCardRech = "WATER_CARD_RECHARGE.SP_REOPEN_RCHRG_DETAILS";
                     using (OracleCommand cmdCnfrmWaterCardRech = new OracleCommand(strQueryCnfrmWaterCardRech,con))
                     {
                         cmdCnfrmWaterCardRech.Transaction = tran;
                         cmdCnfrmWaterCardRech.CommandType = CommandType.StoredProcedure;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_RECH_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_REOPUSERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_CNFRMSTATUS", OracleDbType.Int32).Value = objEntityWaterRecharge.Status_id;
                         cmdCnfrmWaterCardRech.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                         clsDataLayer.ExecuteNonQuery(cmdCnfrmWaterCardRech);
                     }
                     string strQueryUpdBalanceAmount = "WATER_CARD_RECHARGE.SP_UPD_BALANCE";
                     using (OracleCommand cmdUpdBalance = new OracleCommand(strQueryUpdBalanceAmount,con))
                     {
                         cmdUpdBalance.Transaction = tran;
                         cmdUpdBalance.CommandType = CommandType.StoredProcedure;
                         cmdUpdBalance.Parameters.Add("W_CRDNUM", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
                         cmdUpdBalance.Parameters.Add("W_BALAMNT", OracleDbType.Decimal).Value = objEntityWaterRecharge.BalanceAmount;
                         cmdUpdBalance.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
                         cmdUpdBalance.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
                         clsDataLayer.ExecuteNonQuery(cmdUpdBalance);
                     }
                     tran.Commit();
                 }

                 catch (Exception e)
                 {
                     tran.Rollback();
                     throw e;
                 }
             }
        }

        // This Method will fetch water card RECHARGE DEATILS BY ID
        public DataTable ReadWaterCardRechargeById(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadInsuranceType = "WATER_CARD_RECHARGE.SP_READ_WTR_RCHRG_BY_ID";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
            cmdReadInsuranceType.Parameters.Add("W_RECHARGE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }

        //Method for cancel water card RECHARGE
        public void CancelWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryCancelWaterCard = "WATER_CARD_RECHARGE.SP_CANCEL_WTR_RCHRG";
            using (OracleCommand cmdCancelWaterCard = new OracleCommand())
            {
                cmdCancelWaterCard.CommandText = strQueryCancelWaterCard;
                cmdCancelWaterCard.CommandType = CommandType.StoredProcedure;
                cmdCancelWaterCard.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
                cmdCancelWaterCard.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                cmdCancelWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelWaterCard.Parameters.Add("W_REASON", OracleDbType.Varchar2).Value = objEntityWaterRecharge.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelWaterCard);
            }
        }
        //Method for recall water card RECHARGE
        public void ReCallWaterCardRecharge(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryRecallWaterCard = "WATER_CARD_RECHARGE.SP_RECALL_WTR_RCHRG";
            using (OracleCommand cmdRecallWaterCard = new OracleCommand())
            {
                cmdRecallWaterCard.CommandText = strQueryRecallWaterCard;
                cmdRecallWaterCard.CommandType = CommandType.StoredProcedure;
                cmdRecallWaterCard.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.WaterCardRchrgeId;
                cmdRecallWaterCard.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWaterRecharge.User_Id;
                cmdRecallWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecallWaterCard);
            }
        }


        // This Method will water card RECHARGE list
        public DataTable ReadWaterCardRechargeList(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadWaterCardList = "WATER_CARD_RECHARGE.SP_READ_WTR_RCHRG_LIST";
            OracleCommand cmdReadWaterCardList = new OracleCommand();
            cmdReadWaterCardList.CommandText = strQueryReadWaterCardList;
            cmdReadWaterCardList.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCardList.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
            cmdReadWaterCardList.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
            cmdReadWaterCardList.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtWCardList = new DataTable();
            dtWCardList = clsDataLayer.ExecuteReader(cmdReadWaterCardList);
            return dtWCardList;
        }
        // This Method will fetch water RECHARGE category list BY SEARCH
        public DataTable ReadwaterCardRechargeListBySearch(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadWaterCardListBySearch = "WATER_CARD_RECHARGE.SP_READ_WTR_RCHRG_BYSEARCH";
            OracleCommand cmdReadCardListBySearch = new OracleCommand();
            cmdReadCardListBySearch.CommandText = strQueryReadWaterCardListBySearch;
            cmdReadCardListBySearch.CommandType = CommandType.StoredProcedure;
            cmdReadCardListBySearch.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWaterRecharge.Organisation_id;
            cmdReadCardListBySearch.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWaterRecharge.Corporate_id;
            if (objEntityWaterRecharge.SearchField == "")
            {
                cmdReadCardListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCardListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = objEntityWaterRecharge.SearchField;
            }
            cmdReadCardListBySearch.Parameters.Add("W_DATABASE_FIELD", OracleDbType.Varchar2).Value = objEntityWaterRecharge.DataBase_Field;
            cmdReadCardListBySearch.Parameters.Add("W_OPTION", OracleDbType.Int32).Value = objEntityWaterRecharge.Status_id;
            cmdReadCardListBySearch.Parameters.Add("W_CANCEL", OracleDbType.Int32).Value = objEntityWaterRecharge.CancelStatus;
            cmdReadCardListBySearch.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCardListBySearch);
            return dtCategoryList;
        }

        // This Method will water card RECHARGE list
        public DataTable ReadWaterCardDetails(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadWaterCard = "WATER_CARD_RECHARGE.SP_READ_WTR_CARD_DTL";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("W_CARD_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
            cmdReadWaterCard.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtWCard = new DataTable();
            dtWCard = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtWCard;
        }

        // This Method will water card RECHARGE list
        public DataTable ReadVehicleDetails(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadWaterCard = "WATER_CARD_RECHARGE.SP_READ_VEHICLE_DTL";
            OracleCommand cmdReadWaterCard = new OracleCommand();
            cmdReadWaterCard.CommandText = strQueryReadWaterCard;
            cmdReadWaterCard.CommandType = CommandType.StoredProcedure;
            cmdReadWaterCard.Parameters.Add("W_VEH_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.VehicleId;
            cmdReadWaterCard.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtWCard = new DataTable();
            dtWCard = clsDataLayer.ExecuteReader(cmdReadWaterCard);
            return dtWCard;
        }
        // This Method will fetch water card DEATILS BY ID
        public DataTable ReadWaterCardById(clsEntityLayerWaterCardRecharge objEntityWaterRecharge)
        {
            string strQueryReadInsuranceType = "WATER_CARD.SP_READ_WATERCARD_BY_ID";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWaterRecharge.CardNumberId;
            cmdReadInsuranceType.Parameters.Add(" W_WATERCARD", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }
    }
}
