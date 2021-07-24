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
using CL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:01/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerWaterBilling
    {


        // This Method will fetch Vehicle  For autocompletion from WebService
       public DataTable ReadVehiclesWebService(string strLikeVhclNumbr, clsEntityLayerWaterBilling objEntityWatrBilling)
        {
            string strQueryReadVhcls = "WATER_BILLING.SP_READ_VHCL_NUMBRS_WEBSERVICE";
            OracleCommand cmdReadVhcls = new OracleCommand();
            cmdReadVhcls.CommandText = strQueryReadVhcls;
            cmdReadVhcls.CommandType = CommandType.StoredProcedure;
            cmdReadVhcls.Parameters.Add("W_VHCLLIKENUMBR", OracleDbType.Varchar2).Value = strLikeVhclNumbr;
            cmdReadVhcls.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
            cmdReadVhcls.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
            cmdReadVhcls.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadVhcls);
            return dtVehicle;
        }

       // This Method will fetch WATER CARD DETAILS
       public DataTable ReadWaterCard(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryReadCard = "WATER_BILLING.SP_READ_WTR_CRD";
           OracleCommand cmdReadCard = new OracleCommand();
           cmdReadCard.CommandText = strQueryReadCard;
           cmdReadCard.CommandType = CommandType.StoredProcedure;
           cmdReadCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
           cmdReadCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
           cmdReadCard.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtWtrCrd = new DataTable();
           dtWtrCrd = clsDataLayer.ExecuteReader(cmdReadCard);
           return dtWtrCrd;
       }

       // This Method will fetch WATER CARD DETAILS
       public DataTable ReadWaterCardDtlByID(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryReadCard = "WATER_BILLING.SP_READ_WTR_CRD_DTL_BYID";
           OracleCommand cmdReadCard = new OracleCommand();
           cmdReadCard.CommandText = strQueryReadCard;
           cmdReadCard.CommandType = CommandType.StoredProcedure;
           cmdReadCard.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
           cmdReadCard.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
           cmdReadCard.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
           cmdReadCard.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtWtrCrd = new DataTable();
           dtWtrCrd = clsDataLayer.ExecuteReader(cmdReadCard);
           return dtWtrCrd;
       }



       //insert Quatation details to  table
       public int Insert_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingDetails)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryInsertWtrFilng = "WATER_BILLING.SP_INSERT_WTRBILLING";
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdInsertWtrFilng = new OracleCommand(strQueryInsertWtrFilng, con))
                   {
                       cmdInsertWtrFilng.Transaction = tran;

                       cmdInsertWtrFilng.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.WATER_BILLING);
                       objEntCommon.CorporateID = objEntityWatrBilling.CorpOffice_Id;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityWatrBilling.WaterFillingId = Convert.ToInt32(strNextNum);

                       cmdInsertWtrFilng.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                       cmdInsertWtrFilng.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                       cmdInsertWtrFilng.Parameters.Add("W_BILL_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.TotalAmnt;
                       cmdInsertWtrFilng.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdInsertWtrFilng.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
                       cmdInsertWtrFilng.Parameters.Add("Q_INSUSERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
                       cmdInsertWtrFilng.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;

                       cmdInsertWtrFilng.ExecuteNonQuery();

                   }
                   //insert to  Detail table
                   foreach (clsEntityLayerWaterBillingDtl objDetail in objEntityWaterBillingDetails)
                   {

                       string strQueryInsertDetail = "WATER_BILLING.SP_INSERT_WTRBILLING_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_NUM", OracleDbType.Varchar2).Value = objDetail.RcptNumber;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_DATE", OracleDbType.Date).Value = objDetail.Rcptdate;
                           cmdAddInsertDetail.Parameters.Add("W_VHCL_ID", OracleDbType.Int32).Value = objDetail.VhclId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_AMNT", OracleDbType.Decimal).Value = objDetail.RcptAmnt;
                           cmdAddInsertDetail.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;

                           cmdAddInsertDetail.ExecuteNonQuery();
                       }
                   }
                  
                   tran.Commit();
                   return objEntityWatrBilling.WaterFillingId;
               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }


       // This Method FETCHES  DETAILS BASED ON  ID FOR DISPALYING
       public DataTable ReadWaterBilingDetail(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryReadWBDtl = "WATER_BILLING.SP_READ_WTRBILLING_DTL";
           OracleCommand cmdReadWBDtl = new OracleCommand();
           cmdReadWBDtl.CommandText = strQueryReadWBDtl;
           cmdReadWBDtl.CommandType = CommandType.StoredProcedure;
           cmdReadWBDtl.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
           cmdReadWBDtl.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
           cmdReadWBDtl.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
           cmdReadWBDtl.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtDtl = new DataTable();
           dtDtl = clsDataLayer.ExecuteReader(cmdReadWBDtl);
           return dtDtl;
       }

       //Update  details to  table
       public void Update_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingInsertDetails, List<clsEntityLayerWaterBillingDtl> objEntitWaterBillingUpdateDetails, string[] strarrCancldtlIds)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryUpdateWtrBiling = "WATER_BILLING.SP_UPDATE_WTRBILLING";
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdUpdateWtrFilng = new OracleCommand(strQueryUpdateWtrBiling, con))
                   {
                       cmdUpdateWtrFilng.Transaction = tran;

                       cmdUpdateWtrFilng.CommandType = CommandType.StoredProcedure;

                       cmdUpdateWtrFilng.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                       cmdUpdateWtrFilng.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                       cmdUpdateWtrFilng.Parameters.Add("W_BILL_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.TotalAmnt;
                       cmdUpdateWtrFilng.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateWtrFilng.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
                       cmdUpdateWtrFilng.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
                       cmdUpdateWtrFilng.ExecuteNonQuery();

                   }
                   //Update to  quotation Detail table
                   foreach (clsEntityLayerWaterBillingDtl objDetail in objEntitWaterBillingUpdateDetails)
                   {

                       string strQueryUpdateDetail = "WATER_BILLING.SP_UPDATE_WTRBILLING_DTL";
                       using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                       {
                           cmdUpdateDetail.Transaction = tran;

                           cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                           cmdUpdateDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                           cmdUpdateDetail.Parameters.Add("W_DTLID", OracleDbType.Int32).Value = objDetail.WtrFilling_DtlId;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_NUM", OracleDbType.Varchar2).Value = objDetail.RcptNumber;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_DATE", OracleDbType.Date).Value = objDetail.Rcptdate;
                           cmdUpdateDetail.Parameters.Add("W_VHCL_ID", OracleDbType.Int32).Value = objDetail.VhclId;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_AMNT", OracleDbType.Decimal).Value = objDetail.RcptAmnt;
                           cmdUpdateDetail.ExecuteNonQuery();
                       }
                   }
                   //insert to  quotation Detail table
                   foreach (clsEntityLayerWaterBillingDtl objDetail in objEntityWaterBillingInsertDetails)
                   {
                        string strQueryInsertDetail = "WATER_BILLING.SP_INSERT_WTRBILLING_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_NUM", OracleDbType.Varchar2).Value = objDetail.RcptNumber;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_DATE", OracleDbType.Date).Value = objDetail.Rcptdate;
                           cmdAddInsertDetail.Parameters.Add("W_VHCL_ID", OracleDbType.Int32).Value = objDetail.VhclId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_AMNT", OracleDbType.Decimal).Value = objDetail.RcptAmnt;
                           cmdAddInsertDetail.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;

                           cmdAddInsertDetail.ExecuteNonQuery();
                       
                       }
                   }


                   //Cancel the rows that have been cancelled when editing in Detail table
                   foreach (string strDtlId in strarrCancldtlIds)
                   {
                       if (strDtlId != "" && strDtlId != null)
                       {
                           int intDtlId = Convert.ToInt32(strDtlId);

                           string strQueryCancelDetail = "WATER_BILLING.SP_CANCEL_WTRBILLING_DTL";
                           using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                           {
                               cmdCancelDetail.Transaction = tran;

                               cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                               cmdCancelDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                               cmdCancelDetail.Parameters.Add("W_DTLID", OracleDbType.Int32).Value = intDtlId;

                               cmdCancelDetail.ExecuteNonQuery();
                           }
                       }
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

       //Update  details to  table
       public void Confirm_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingInsertDetails, List<clsEntityLayerWaterBillingDtl> objEntitWaterBillingUpdateDetails, string[] strarrCancldtlIds)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryUpdateWtrBiling = "WATER_BILLING.SP_UPDATE_WTRBILLING";
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdUpdateWtrFilng = new OracleCommand(strQueryUpdateWtrBiling, con))
                   {
                       cmdUpdateWtrFilng.Transaction = tran;

                       cmdUpdateWtrFilng.CommandType = CommandType.StoredProcedure;

                       cmdUpdateWtrFilng.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                       cmdUpdateWtrFilng.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                       cmdUpdateWtrFilng.Parameters.Add("W_BILL_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.TotalAmnt;
                       cmdUpdateWtrFilng.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateWtrFilng.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
                       cmdUpdateWtrFilng.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
                       cmdUpdateWtrFilng.ExecuteNonQuery();

                   }
                   //Update to  quotation Detail table
                   foreach (clsEntityLayerWaterBillingDtl objDetail in objEntitWaterBillingUpdateDetails)
                   {

                       string strQueryUpdateDetail = "WATER_BILLING.SP_UPDATE_WTRBILLING_DTL";
                       using (OracleCommand cmdUpdateDetail = new OracleCommand(strQueryUpdateDetail, con))
                       {
                           cmdUpdateDetail.Transaction = tran;

                           cmdUpdateDetail.CommandType = CommandType.StoredProcedure;
                           cmdUpdateDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                           cmdUpdateDetail.Parameters.Add("W_DTLID", OracleDbType.Int32).Value = objDetail.WtrFilling_DtlId;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_NUM", OracleDbType.Varchar2).Value = objDetail.RcptNumber;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_DATE", OracleDbType.Date).Value = objDetail.Rcptdate;
                           cmdUpdateDetail.Parameters.Add("W_VHCL_ID", OracleDbType.Int32).Value = objDetail.VhclId;
                           cmdUpdateDetail.Parameters.Add("W_RCPT_AMNT", OracleDbType.Decimal).Value = objDetail.RcptAmnt;
                           cmdUpdateDetail.ExecuteNonQuery();
                       }
                   }
                   //insert to  quotation Detail table
                   foreach (clsEntityLayerWaterBillingDtl objDetail in objEntityWaterBillingInsertDetails)
                   {
                       string strQueryInsertDetail = "WATER_BILLING.SP_INSERT_WTRBILLING_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_NUM", OracleDbType.Varchar2).Value = objDetail.RcptNumber;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_DATE", OracleDbType.Date).Value = objDetail.Rcptdate;
                           cmdAddInsertDetail.Parameters.Add("W_VHCL_ID", OracleDbType.Int32).Value = objDetail.VhclId;
                           cmdAddInsertDetail.Parameters.Add("W_RCPT_AMNT", OracleDbType.Decimal).Value = objDetail.RcptAmnt;
                           cmdAddInsertDetail.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;

                           cmdAddInsertDetail.ExecuteNonQuery();

                       }
                   }


                   //Cancel the rows that have been cancelled when editing in Detail table
                   foreach (string strDtlId in strarrCancldtlIds)
                   {
                       if (strDtlId != "" && strDtlId != null)
                       {
                           int intDtlId = Convert.ToInt32(strDtlId);

                           string strQueryCancelDetail = "WATER_BILLING.SP_CANCEL_WTRBILLING_DTL";
                           using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                           {
                               cmdCancelDetail.Transaction = tran;

                               cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                               cmdCancelDetail.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                               cmdCancelDetail.Parameters.Add("W_DTLID", OracleDbType.Int32).Value = intDtlId;

                               cmdCancelDetail.ExecuteNonQuery();
                           }
                       }
                   }

                   //---------------------------------------------------------------------------change other than update method is code below


                   string strQueryUpdateStatus = "WATER_BILLING.SP_UPDATE_WTRBILLING_CNFRM_STS";
                   using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateStatus, con))
                   {
                       cmdUpdateStatus.Transaction = tran;

                       cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                       cmdUpdateStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                       cmdUpdateStatus.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = 1;//confirmed
                       cmdUpdateStatus.Parameters.Add("W_STS_USERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
                       cmdUpdateStatus.Parameters.Add("W_STS_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
                       cmdUpdateStatus.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateStatus.ExecuteNonQuery();
                   }

                   string strQueryUpdateCardAmnt = "WATER_BILLING.SP_UPD_WTRCARD_BALANCE";
                   using (OracleCommand cmdUpdateWtrCrdBal = new OracleCommand(strQueryUpdateCardAmnt, con))
                   {
                       cmdUpdateWtrCrdBal.Transaction = tran;

                       cmdUpdateWtrCrdBal.CommandType = CommandType.StoredProcedure;

                       cmdUpdateWtrCrdBal.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_CURNTAMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.CardCurrentAmnt;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
                       cmdUpdateWtrCrdBal.ExecuteNonQuery();
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

       // This Method will fetch water card details and billing  DEATILS BY ID
       public DataTable ReadWaterBillingById(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryReadById = "WATER_BILLING.SP_READ_WTRBILLING_BY_ID";
           OracleCommand cmdReadById = new OracleCommand();
           cmdReadById.CommandText = strQueryReadById;
           cmdReadById.CommandType = CommandType.StoredProcedure;
           cmdReadById.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
           cmdReadById.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
           cmdReadById.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
           cmdReadById.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtDtl = new DataTable();
           dtDtl = clsDataLayer.ExecuteReader(cmdReadById);
           return dtDtl;
       }

       //Update  details to  table while reopening,add the value to watercard
       public void Reopen_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryUpdateWtrCard = "WATER_BILLING.SP_UPD_WTRCARD_BALANCE";
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdUpdateWtrCrdBal = new OracleCommand(strQueryUpdateWtrCard, con))
                   {
                       cmdUpdateWtrCrdBal.Transaction = tran;

                       cmdUpdateWtrCrdBal.CommandType = CommandType.StoredProcedure;

                       cmdUpdateWtrCrdBal.Parameters.Add("W_CRDID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterCardId;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_CURNTAMNT", OracleDbType.Decimal).Value = objEntityWatrBilling.CardCurrentAmnt;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateWtrCrdBal.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;               
                       cmdUpdateWtrCrdBal.ExecuteNonQuery();

                   }



                   string strQueryUpdateCnfrmStatus = "WATER_BILLING.SP_UPDATE_WTRBILLING_CNFRM_STS";
                   using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateCnfrmStatus, con))
                   {
                       cmdUpdateStatus.Transaction = tran;

                       cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                       cmdUpdateStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
                       cmdUpdateStatus.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = 0;//confirmed
                       cmdUpdateStatus.Parameters.Add("W_STS_USERID", OracleDbType.Int32).Value = null;
                       cmdUpdateStatus.Parameters.Add("W_STS_DATE", OracleDbType.Date).Value = null;
                       cmdUpdateStatus.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateStatus.ExecuteNonQuery();
                   }

                   string strQueryUpdateReopenDtl = "WATER_BILLING.SP_UPDATE_WTRBILLING_CNFRMRECL";
                   using (OracleCommand cmdUpdateStatus = new OracleCommand(strQueryUpdateReopenDtl, con))
                   {
                       cmdUpdateStatus.Transaction = tran;

                       cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                       cmdUpdateStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;                     
                       cmdUpdateStatus.Parameters.Add("W_STS_USERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
                       cmdUpdateStatus.Parameters.Add("W_STS_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
                       cmdUpdateStatus.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
                       cmdUpdateStatus.ExecuteNonQuery();
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

       //Method for recall Cancelled water billing
       public void ReCallCanceledWaterBilling(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryRecallCancelled = "WATER_BILLING.SP_RECALL_CNCLD_WTRFILNG";
           using (OracleCommand cmdRecallCancelled = new OracleCommand())
           {
               cmdRecallCancelled.CommandText = strQueryRecallCancelled;
               cmdRecallCancelled.CommandType = CommandType.StoredProcedure;
               cmdRecallCancelled.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
               cmdRecallCancelled.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
               cmdRecallCancelled.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
               clsDataLayer.ExecuteNonQuery(cmdRecallCancelled);
           }
       }

       //Method for cancel water billing
       public void CancelWaterBilling(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryCancel = "WATER_BILLING.SP_CANCEL_WTRFILNG";
           using (OracleCommand cmdCancel = new OracleCommand())
           {
               cmdCancel.CommandText = strQueryCancel;
               cmdCancel.CommandType = CommandType.StoredProcedure;
               cmdCancel.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWatrBilling.WaterFillingId;
               cmdCancel.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityWatrBilling.User_Id;
               cmdCancel.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityWatrBilling.D_Date;
               cmdCancel.Parameters.Add("W_REASON", OracleDbType.Varchar2).Value = objEntityWatrBilling.CancelReason;
               clsDataLayer.ExecuteNonQuery(cmdCancel);
           }
       }


       // This Method will fetch water bill  list BY SEARCH
       public DataTable ReadWaterBillingListBySearch(clsEntityLayerWaterBilling objEntityWatrBilling)
       {
           string strQueryReadListBySearch = "WATER_BILLING.SP_READ_WTRFILNG_BYSEARCH";
           OracleCommand cmdReadListBySearch = new OracleCommand();
           cmdReadListBySearch.CommandText = strQueryReadListBySearch;
           cmdReadListBySearch.CommandType = CommandType.StoredProcedure;
           cmdReadListBySearch.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWatrBilling.Organisation_Id;
           cmdReadListBySearch.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWatrBilling.CorpOffice_Id;
           if (objEntityWatrBilling.SearchField.Trim() == "")
           {
               cmdReadListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
           }
           else
           {
               cmdReadListBySearch.Parameters.Add("W_SEARCH_WORD", OracleDbType.Varchar2).Value = objEntityWatrBilling.SearchField.Trim();
           }
           cmdReadListBySearch.Parameters.Add("W_DATABASE_FIELD", OracleDbType.Varchar2).Value = objEntityWatrBilling.DataBase_Field;
           cmdReadListBySearch.Parameters.Add("W_OPTION", OracleDbType.Int32).Value = objEntityWatrBilling.Status_id;
           cmdReadListBySearch.Parameters.Add("W_CANCEL", OracleDbType.Int32).Value = objEntityWatrBilling.CancelStatus;
           cmdReadListBySearch.Parameters.Add("W_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategoryList = new DataTable();
           dtCategoryList = clsDataLayer.ExecuteReader(cmdReadListBySearch);
           return dtCategoryList;
       }
    }
}
